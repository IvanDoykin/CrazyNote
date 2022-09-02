using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class GuitarControl : MonoBehaviour
    {
        public Action<bool[]> InputHasChanged;
        
        [SerializeField] private TextMeshProUGUI DEBUGhitsNmisses;
        [SerializeField] private NotesDetector _detector;
        [SerializeField] private InputModifier _input;
        
        private int DEBUG_HITS;
        public int DEBUG_MISSES;

        private void Update()
        {
            _detector.Tick();
            var input = _input.GetModifiedInput();
            var availableNotes = _detector.AvailableNotes;

            if (CompareInputWithNotes(input, availableNotes))
            {
                Debug.Log("comparing successful");
                input.RawInput.PressedKeys.Log();

                TriggerNotes(input, _detector.AvailableNotes);
                InputHasChanged(input.ModifiedKeys);
            }

            DEBUGhitsNmisses.text = "+" + DEBUG_HITS + " -" + DEBUG_MISSES;
        }

        private bool CompareInputWithNotes(Input input, List<Note> notes)
        {
            if (notes.Count == 0) return false;

            var shouldPressedNotes = new bool[input.RawInput.PressedKeys.Length];
            var closestVerticalPos = int.MaxValue;
            foreach (var note in notes.Where(note => note.VerticalPosition < closestVerticalPos))
            {
                closestVerticalPos = note.VerticalPosition;
            }

            Debug.Log("ClosestVerticalPos = " + closestVerticalPos);

            foreach (var registredNote in _detector.RegistredNotes)
            {
                if (registredNote.VerticalPosition == closestVerticalPos)
                {
                    shouldPressedNotes[registredNote.HorizontalPosition] = true;
                }
            }

            for (var i = 0; i < input.ModifiedKeys.Length; i++)
            {
                if (input.ModifiedKeys[i] != shouldPressedNotes[i] && !input.ModifiedKeys[i])
                {
                    return false;
                }
            }

            return true;
        }

        private void TriggerNotes(Input input, List<Note> notes)
        {
            var triggerNotes = new List<Note>();

            foreach (var note in notes)
            {
                if (triggerNotes.Contains(note))
                {
                    continue;
                }

                var checkNotes = _detector.GetRegistredOneTimeNotes(note.VerticalPosition);
                checkNotes.Log();

                if (CheckNotesOnPressed(input, checkNotes))
                {
                    foreach (var checkNote in checkNotes)
                    {
                        if (checkNote == null)
                        {
                            continue;
                        }

                        if (!triggerNotes.Contains(checkNote))
                        {
                            triggerNotes.Add(checkNote);
                        }
                    }
                }
            }

            if (triggerNotes.Count > 0) DEBUG_HITS++;

            triggerNotes.ToArray().Log();
            for (var i = 0; i < triggerNotes.Count; i++)
            {
                _detector.TriggerNote(triggerNotes[i]);
            }
        }

        private bool CheckNotesOnPressed(Input input, Note[] notes)
        {
            for (var i = 0; i < notes.Length; i++)
            {
                Debug.LogWarning("Input[" + i + "] = " + input.ModifiedKeys + " (notes[i] == null) = " + (notes[i] == null));
                if (input.ModifiedKeys[i] == (notes[i] == null) && !input.ModifiedKeys[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
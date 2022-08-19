using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;

namespace Game.Singleplayer
{
    public class GuitarControlRuler : MonoBehaviour
    {
        private int DEBUG_HITS = 0;
        public int DEBUG_MISSES = 0;
        [SerializeField] private TextMeshProUGUI DEBUGhitsNmisses;

        public static Action<bool[]> InputHasChanged;
        private InputModifier _input;
        private NotesDetector _detector;

        private void Awake()
        {
            _input = GetComponent<InputModifier>();
            _detector = GetComponent<NotesDetector>();
        }

        private void Update()
        {
            _detector.Tick();
            Input input = _input.GetModifiedInput();
            List<Note> availableNotes = _detector.AvailableNotes;

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
            if (notes.Count == 0)
            {
                return false;
            }

            bool[] shouldPressedNotes = new bool[input.RawInput.PressedKeys.Length];
            int closestVerticalPos = int.MaxValue;
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

            for (int i = 0; i < input.ModifiedKeys.Length; i++)
            {
                if ((input.ModifiedKeys[i] != shouldPressedNotes[i]) && !input.ModifiedKeys[i])
                {
                    return false;
                }
            }
            return true;
        }

        private void TriggerNotes(Input input, List<Note> notes)
        {
            List<Note> triggerNotes = new List<Note>();

            foreach (var note in notes)
            {
                if (triggerNotes.Contains(note))
                {
                    continue;
                }

                Note[] checkNotes = _detector.GetRegistredOneTimeNotes(note.VerticalPosition);
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

            if (triggerNotes.Count > 0)
            {
                DEBUG_HITS++;
            }

            triggerNotes.ToArray().Log();
            for (int i = 0; i < triggerNotes.Count; i++)
            {
                _detector.TriggerNote(triggerNotes[i]);
            }
        }

        private bool CheckNotesOnPressed(Input input, Note[] notes)
        {
            for (int i = 0; i < notes.Length; i++)
            {
                Debug.LogWarning("Input[" + i + "] = " + input.ModifiedKeys.ToString() + " (notes[i] == null) = " + (notes[i] == null));
                if ((input.ModifiedKeys[i] == (notes[i] == null)) && !input.ModifiedKeys[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}

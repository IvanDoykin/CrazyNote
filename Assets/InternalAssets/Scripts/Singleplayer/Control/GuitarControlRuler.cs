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

                InputHasChanged(input.ModifiedKeys);
                TriggerNotes(input, _detector.AvailableNotes);
            }

            DEBUGhitsNmisses.text = "+" + DEBUG_HITS + " -" + DEBUG_MISSES;
        }

        private bool CompareInputWithNotes(Input input, List<Note> notes)
        {
            if (notes.Count == 0)
            {
                return false;
            }

            bool[] canPressedNotes = new bool[input.RawInput.PressedKeys.Length];
            int closestVerticalPos = 1000000000;
            foreach (var note in notes.Where(note => note.VerticalPosition < closestVerticalPos))
            {
                closestVerticalPos = note.VerticalPosition;
            }

            Debug.Log("ClosestVerticalPos = " + closestVerticalPos);

            foreach (var registredNote in _detector.RegistredNotes)
            {
                if (registredNote.VerticalPosition == closestVerticalPos)
                {
                    canPressedNotes[registredNote.HorizontalPosition] = true;
                }
            }

            canPressedNotes.Log();

            for (int i = 0; i < input.RawInput.PressedKeys.Length; i++)
            {
                if (input.RawInput.PressedKeys[i] != canPressedNotes[i])
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
                Debug.LogWarning("Input[" + i + "] = " + input.RawInput.PressedKeys[i].ToString() + " (notes[i] == null) = " + (notes[i] == null));
                if (input.RawInput.PressedKeys[i] == (notes[i] == null))
                {
                    return false;
                }
            }
            return true;
        }
    }
}

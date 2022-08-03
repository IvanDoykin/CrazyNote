using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

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
            IEnumerator<Note> availableNotes = _detector.AvailableNotes;

            if (CompareInputWithNotes(input, availableNotes))
            {
                Debug.Log("comparing successful");
                InputHasChanged(input.ModifiedKeys);
                //TriggerNotes(input, _detector.RegistredNotes);
            }

            DEBUGhitsNmisses.text = "+" + DEBUG_HITS + " -" + DEBUG_MISSES;
        }

        private bool CompareInputWithNotes(Input input, IEnumerator<Note> notes)
        {
            if (!notes.MoveNext())
            {
                return false;
            }

            bool[] canPressedNotes = new bool[input.RawInput.PressedKeys.Length];
            int closestVerticalPos = 1000000000;
            while (notes.MoveNext())
            {
                if (notes.Current.VerticalPosition < closestVerticalPos)
                {
                    closestVerticalPos = notes.Current.VerticalPosition;
                }
            }

            Debug.Log("ClosestVerticalPos = " + closestVerticalPos);

            IEnumerator<Note> registredNotes = _detector.RegistredNotes;
            while (registredNotes.MoveNext())
            {
                if (registredNotes.Current.VerticalPosition == closestVerticalPos)
                {
                    canPressedNotes[registredNotes.Current.HorizontalPosition] = true;
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

        private void TriggerNotes(Input input, IEnumerator<Note> notes)
        {
            List<Note> triggerNotes = new List<Note>();
            while (notes.MoveNext())
            {
                Note[] checkNotes = _detector.GetRegistredOneTimeNotes(notes.Current.HorizontalPosition);

                Debug.Log("NOTES = " + checkNotes.Length);

                if (CheckNotesOnPressed(input, checkNotes))
                {
                    DEBUG_HITS++;
                    foreach (var note in checkNotes)
                    {
                        if (note == null)
                        {
                            continue;
                        }

                        if (!triggerNotes.Contains(note))
                        {
                            triggerNotes.Add(note);
                        }
                    }
                }
            }

            for (int i = 0; i < triggerNotes.Count; i++)
            {
                _detector.TriggerNote(triggerNotes[i]);
            }
        }

        private bool CheckNotesOnPressed(Input input, Note[] notes)
        {
            for (int i = 0; i < notes.Length; i++)
            {
                Debug.LogWarning("Input[" + i + "] = " + input.ModifiedKeys[i].ToString() + " (notes[i] == null) = " + (notes[i] == null));
                if (input.ModifiedKeys[i] && (notes[i] == null))
                {
                    return false;
                }
            }
            return true;
        }
    }
}

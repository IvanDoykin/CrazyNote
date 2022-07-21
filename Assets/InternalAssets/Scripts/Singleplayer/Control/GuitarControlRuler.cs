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
            Input input = _input.GetModifiedInput();
            IEnumerator<Note> availableNotes = _detector.AvailableNotes;

            if (CompareInputWithNotes(input, availableNotes))
            {
                InputHasChanged(input.ModifiedKeys);
                TriggerNotes(input, availableNotes);
            }

            DEBUGhitsNmisses.text = "+" + DEBUG_HITS + " -" + DEBUG_MISSES;
        }

        private bool CompareInputWithNotes(Input input, IEnumerator<Note> notes)
        {
            bool[] canPressedNotes = new bool[input.RawInput.JustPressedKeys.Length];
            while (notes.MoveNext())
            {
                canPressedNotes[notes.Current.HorizontalPosition] = true;
            }
            notes.Reset();

            for (int i = 0; i < input.RawInput.JustPressedKeys.Length; i++)
            {
                if (input.RawInput.JustPressedKeys[i] != canPressedNotes[i] && input.RawInput.JustPressedKeys[i])
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
                if (input.ModifiedKeys[notes.Current.HorizontalPosition])
                {
                    DEBUG_HITS++;
                    triggerNotes.Add(notes.Current);
                }
            }
            notes.Reset();

            for (int i = 0; i < triggerNotes.Count; i++)
            {
                _detector.TriggerNote(triggerNotes[i]);
            }
        }
    }
}

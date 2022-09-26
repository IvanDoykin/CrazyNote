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
        
        [SerializeField] private NotesHandler _handler;
        [SerializeField] private InputModifier _input;
        
        private void Update()
        {
            _handler.Tick();
            var input = _input.GetModifiedInput();

            if (TryGetCloserNoteGroup(_handler.RegistredNoteGroups, out var group))
            {
                Debug.Log("comparing successful");
                input.RawInput.PressedKeys.Log();

                TriggerNoteGroup(input, group);
            }
        }
        
        private bool TryGetCloserNoteGroup(List<NoteGroup> noteGroups, out NoteGroup closerNoteGroup)
        {
            closerNoteGroup = null;

            if (noteGroups.Count == 0)
            {
                return false;
            }

            var closestVerticalPos = int.MaxValue;
            foreach (var group in noteGroups)
            {
                if (group.VerticalPosition < closestVerticalPos)
                {
                    closestVerticalPos = group.VerticalPosition;
                    closerNoteGroup = group;
                }
            }

            return true;
        }

        private void TriggerNoteGroup(Input input, NoteGroup group)
        {
            if (group.Timer > NotesHandler.TimeToTrigger)
            {
                if (group.IsAllTriggered(input.ModifiedKeys, _handler.GetDetectedInput(group, input.ModifiedKeys.Length)))
                {
                    if (_handler.TryTriggerNoteGroup(group))
                    {
                        bool[] modifiedInput = new bool[input.ModifiedKeys.Length];
                        for (int i = 0; i < group.Notes.Length; i++)
                        {
                            modifiedInput[group.Notes[i].HorizontalPosition] = true;
                        }
                        InputHasChanged(modifiedInput);
                    }
                }
            }
        }
    }
}
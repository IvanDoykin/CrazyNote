using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class GuitarControl : MonoBehaviour
    {
        private const int triggeredNotesInRow = 2;
        public Action<bool[]> InputHasChanged;
        
        [SerializeField] private NotesHandler _handler;
        [SerializeField] private InputModifier _input;
        
        private void Update()
        {
            _handler.Tick();
            var input = _input.GetModifiedInput();

            for (int i = 0; i < triggeredNotesInRow; i++)
            {
                if (TryGetCloserNoteGroup(_handler.RegistredNoteGroups, out var group))
                {
                    Debug.Log("comparing successful");
                    input.RawInput.PressedKeys.Log();

                    TriggerNoteGroup(input, group);
                }
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
            if (group.IsAllTriggered(input.ModifiedKeys))
            {
                if (_handler.TryTriggerNoteGroup(group))
                {
                    InputHasChanged(input.ModifiedKeys);
                }
            }
        }
    }
}
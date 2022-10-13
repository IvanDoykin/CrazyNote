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

        private bool _active = true;

        public void SetActive()
        {
            _active = true;
            _handler.SetActive();
        }

        public void SetInactive()
        {
            _active = false;
            _handler.SetInactive();
        }

        private void Update()
        {
            if (!_active) return;

            _handler.Tick();
            var input = _input.GetModifiedInput();

            if (TryGetCloserNoteGroup(_handler.RegistredNoteGroups, out var group))
            {
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
            if (group.Timer > NotesHandler.TimeToTrigger && group.IsAllTriggered(input.ModifiedKeys))
            {
                _handler.TriggerNoteGroup(group);
                InputHasChanged(input.ModifiedKeys);
            }
        }
    }
}
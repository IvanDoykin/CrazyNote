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
        [SerializeField] private NotesHandler _handler;
        [SerializeField] private InputModifier _input;
        
        private int DEBUG_HITS;
        public int DEBUG_MISSES;

        private void Start()
        {
            _handler.NoteGroupHasHit += ((hit) =>
            {
                if (!hit)
                {
                    DEBUG_MISSES++;
                }
            });
        }

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

            DEBUGhitsNmisses.text = "+" + DEBUG_HITS + " -" + DEBUG_MISSES;
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
                    DEBUG_HITS++;
                    InputHasChanged(input.ModifiedKeys);
                }
            }
        }
    }
}
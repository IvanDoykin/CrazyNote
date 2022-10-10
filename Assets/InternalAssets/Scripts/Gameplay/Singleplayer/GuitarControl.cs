using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class GuitarControl : MonoBehaviour
    {
        private const float holdingTime = 0.1f;

        public Action<bool[]> InputHasChanged;
        
        [SerializeField] private NotesHandler _handler;
        [SerializeField] private InputModifier _input;

        private bool[] _lastSuccessfulInput;
        public bool[] LastSuccessfulInput => _lastSuccessfulInput;

        private bool _active = true;
        private bool _isHoldingInput = false;
        private float _holdingTimer = 0f;

        private void Start()
        {
            _lastSuccessfulInput = new bool[5];
        }

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

            if (!IsInputEqualLastInput(input.RawInput.PressedKeys))
            {
                _lastSuccessfulInput = new bool[5];
                //_isHoldingInput = false;
            }

            if (_isHoldingInput)
            {
                _holdingTimer += Time.deltaTime;

                if (_holdingTimer > holdingTime)
                {
                    _isHoldingInput = false;
                    _lastSuccessfulInput = new bool[5];
                }
            }

            if (TryGetCloserNoteGroup(_handler.RegistredNoteGroups, out var group))
            {
                TriggerNoteGroup(input, group);
            }
        }

        private bool IsInputEqualLastInput(bool[] input)
        {
            bool isEmpty = true;
            bool isEqual = true;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i])
                {
                    isEmpty = false;
                }

                if (input[i] != _lastSuccessfulInput[i] && !isEqual)
                {
                    isEqual = false;
                }
            }

            return isEmpty || (!isEmpty && isEqual);
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
                if (group.IsAllTriggered(input.ModifiedKeys, _handler.GetDetectedInput(group, input.ModifiedKeys.Length), _lastSuccessfulInput))
                {
                    if (_handler.TryTriggerNoteGroup(group))
                    {
                        Debug.Log("TRIGGER NOTE");
                        _holdingTimer = 0f;
                        _lastSuccessfulInput = new bool[input.ModifiedKeys.Length];
                        _isHoldingInput = true;

                        bool[] modifiedInput = new bool[input.ModifiedKeys.Length];

                        for (int i = 0; i < group.Notes.Length; i++)
                        {
                            modifiedInput[group.Notes[i].HorizontalPosition] = true;
                            _lastSuccessfulInput[group.Notes[i].HorizontalPosition] = true;
                        }
                        InputHasChanged(modifiedInput);
                    }
                }

                else if (group.IsAllTriggered(_lastSuccessfulInput, _handler.GetDetectedInput(group, _lastSuccessfulInput.Length), _lastSuccessfulInput))
                {
                    _handler.TryTriggerNoteGroup(group);
                }
            }
        }
    }
}
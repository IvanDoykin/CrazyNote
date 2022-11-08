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

        [SerializeField] private InputHolder _holder;
        [SerializeField] private NotesHandler _handler;
        [SerializeField] private InputModifier _input;

        [SerializeField] private AudioSource _source;

        private bool _active = true;

        private void Start()
        {
            _holder.Initialize(_input.GetModifiedInput().ModifiedKeys.Length);
            _handler.Initialize(_input.GetModifiedInput().ModifiedKeys.Length);
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
            if (!_active)
            {
                return;
            }

            _holder.Tick();
            _handler.Tick();

            var input = _input.GetModifiedInput();

            _handler.AvailableNoteInRows.Log();

            if (IsError(input.RawInput.JustPressedKeys))
            {
                _source.Play();
                InputHasChanged(input.RawInput.JustPressedKeys);
                return;
            }

            for (int i = 0; i < _handler.RegistredNoteGroups.Count; i++)
            {
                var group = _handler.RegistredNoteGroups[i];
                if (group.Timer < NotesHandler.TimeToDetect)
                {
                    continue;
                }
                var detectedKeys = group.Notes.Length;

                var inputKeys = 0;
                foreach (var key in input.RawInput.PressedKeys)
                {
                    if (key)
                    {
                        inputKeys++;
                    }
                }

                Debug.Log("INPUT = " + inputKeys + ". NEED = " + detectedKeys);
                if (inputKeys <= Mathf.Max(3, detectedKeys))
                {
                    TriggerNoteGroup(input, group);
                }
            }
        }

        private bool IsError(bool[] justPressedKeys)
        {
            for (int i = 0; i < justPressedKeys.Length; i++)
            {
                if (justPressedKeys[i] && !_handler.AvailableNoteInRows[i] && !_holder.HoldingKeys[i])
                {
                    return true;
                }
            }
            return false;
        }

        private void TriggerNoteGroup(Input input, NoteGroup group)
        {
            if (_holder.Initialized)
            {
                if (group.Timer > NotesHandler.TimeToTrigger - 0.067f / Mover.Speed && group.IsAllTriggered(input.ModifiedKeys, _holder.HoldingKeys))
                {
                    bool emptyInput = true;
                    for (int i = 0; i < input.ModifiedKeys.Length; i++)
                    {
                        if (input.ModifiedKeys[i])
                        {
                            emptyInput = false;
                            break;
                        }
                    }

                    if (!emptyInput)
                    {
                        var modifiedInput = new bool[input.ModifiedKeys.Length];
                        for (int i = 0; i < group.Notes.Length; i++)
                        {
                            modifiedInput[group.Notes[i].HorizontalPosition] = true;
                        }

                        _holder.HoldInput(modifiedInput);
                    }
                }

                if (group.Timer > NotesHandler.TimeToTrigger && group.IsAllTriggered(input.ModifiedKeys, _holder.HoldingKeys))
                {
                    InputHasChanged(input.ModifiedKeys);
                    _handler.TriggerNoteGroup(group);
                }
            }

            else
            {
                if (group.Timer > NotesHandler.TimeToTrigger - 0.067f / Mover.Speed && group.IsAllTriggered(input.ModifiedKeys))
                {
                    var modifiedInput = new bool[input.ModifiedKeys.Length];
                    for (int i = 0; i < group.Notes.Length; i++)
                    {
                        modifiedInput[group.Notes[i].HorizontalPosition] = true;
                    }

                    _holder.HoldInput(modifiedInput);
                }

                if (group.Timer > NotesHandler.TimeToTrigger && group.IsAllTriggered(input.ModifiedKeys))
                {
                    _handler.TriggerNoteGroup(group);

                    var modifiedInput = new bool[input.ModifiedKeys.Length];
                    for (int i = 0; i < group.Notes.Length; i++)
                    {
                        modifiedInput[group.Notes[i].HorizontalPosition] = true;
                    }

                    InputHasChanged(input.ModifiedKeys);
                }
            }
        }
    }
}
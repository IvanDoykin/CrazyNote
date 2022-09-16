using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace InternalAssets.Scripts
{
    public struct Input
    {
        public RawInput RawInput { get; }
        public bool[] ModifiedKeys { get; }

        public Input(RawInput rawInput, bool[] modifiedKeys)
        {
            RawInput = rawInput;

            ModifiedKeys = new bool[modifiedKeys.Length];
            modifiedKeys.CopyTo(ModifiedKeys, 0);
        }
    }

    public class InputModifier : MonoBehaviour
    {
        [SerializeField] private GuitarControl _control;
        
        [SerializeField] private List<Image> _rawInputImages;
        [SerializeField] private List<Image> _rawInputNeedUpImages;
        [SerializeField] private List<Image> _modifiedImages;
        
        private GameInput _input;
        private bool[] _lastInputKeys;
        private bool[] _needReleaseKeys;

        public bool[] LastFilteredInput { get; private set; }

        private void Awake()
        {
            _input = GetComponent<GameInput>();
            _needReleaseKeys = new bool[_input.GetRawInput().PressedKeys.Length];
            _lastInputKeys = new bool[_input.GetRawInput().PressedKeys.Length];

            LastFilteredInput = new bool[_input.GetRawInput().PressedKeys.Length];
            _control.InputHasChanged += ChangeNeedReleasedKeys;
        }

        private void OnDestroy()
        {
            _control.InputHasChanged -= ChangeNeedReleasedKeys;
        }

        private void ChangeNeedReleasedKeys(bool[] needReleaseKeys)
        {
            for (var i = 0; i < _needReleaseKeys.Length; i++)
            {
                if (needReleaseKeys[i])
                {
                    _needReleaseKeys[i] = true;
                }
            }
        }

        private bool CompareOnPositiveChanges(RawInput currentInput)
        {
            for (var i = 0; i < currentInput.PressedKeys.Length; i++)
            {
                if (!_lastInputKeys[i] && currentInput.PressedKeys[i])
                {
                    return true;
                }
            }

            return false;
        }

        public Input GetModifiedInput()
        {
            var input = _input.GetRawInput();
            
            if (CompareOnPositiveChanges(input))
            {
                StartCoroutine(DelayedReleaseNotes(input.PressedKeys));
            }

            _lastInputKeys = input.PressedKeys;

            for (var i = 0; i < input.PressedKeys.Length; i++)
            {
                if (input.PressedKeys[i])
                {
                    _rawInputImages[i].color = Color.red;
                }
                else
                {
                    _rawInputImages[i].color = Color.white;
                }
            }

            var filterPressedNotes = FilterPressedNotes(input.PressedKeys);
            SetReleasedNotes(input.ReleasedKeys);
            LastFilteredInput = filterPressedNotes;

            for (var i = 0; i < filterPressedNotes.Length; i++)
            {
                if (filterPressedNotes[i])
                {
                    _modifiedImages[i].color = Color.red;
                }
                else
                {
                    _modifiedImages[i].color = Color.white;
                }
            }

            for (var i = 0; i < _needReleaseKeys.Length; i++)
            {
                if (_needReleaseKeys[i])
                {
                    _rawInputNeedUpImages[i].color = Color.red;
                }
                else
                {
                    _rawInputNeedUpImages[i].color = Color.white;
                }
            }

            var modifiedInput = new Input(input, filterPressedNotes);
            return modifiedInput;
        }

        private IEnumerator DelayedReleaseNotes(bool[] releasedNotes)
        {
            int frameTimer = 0;
            while (frameTimer < 5)
            {
                frameTimer++;
                yield return null;
            }
            SetReleasedNotes(releasedNotes);
        }

        private void SetReleasedNotes(bool[] releasedNotes)
        {
            for (var i = 0; i < releasedNotes.Length; i++)
            {
                if (releasedNotes[i])
                {
                    _needReleaseKeys[i] = false;
                }
            }
        }

        private bool[] FilterPressedNotes(bool[] pressedNotes)
        {
            var modifyKeys = new bool[pressedNotes.Length];
            for (var i = 0; i < modifyKeys.Length; i++)
            {
                modifyKeys[i] = pressedNotes[i] && !_needReleaseKeys[i];
            }
            return modifyKeys;
        }
    }
}
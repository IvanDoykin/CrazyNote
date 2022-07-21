using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Singleplayer
{
    public struct Input
    {
        public RawInput RawInput { get; private set; }
        public bool[] ModifiedKeys { get; private set; }

        public Input(RawInput rawInput, bool[] modifiedKeys)
        {
            RawInput = rawInput;

            ModifiedKeys = new bool[modifiedKeys.Length];
            modifiedKeys.CopyTo(ModifiedKeys, 0);
        }
    }

    public class InputModifier : MonoBehaviour
    {
        private GameInput _input;
        private bool[] _needReleaseKeys;

        [SerializeField] private List<Image> rawInputImages;
        [SerializeField] private List<Image> rawInputNeedUpImages;
        [SerializeField] private List<Image> modifiedImages;

        private void Awake()
        {
            _input = GetComponent<GameInput>();
            _needReleaseKeys = new bool[_input.GetRawInput().PressedKeys.Length];
            GuitarControlRuler.InputHasChanged += ChangeNeedReleasedKeys;
        }

        private void OnDestroy()
        {
            GuitarControlRuler.InputHasChanged -= ChangeNeedReleasedKeys;
        }

        private void ChangeNeedReleasedKeys(bool[] needReleaseKeys)
        {
            for (int i = 0; i < _needReleaseKeys.Length; i++)
            {
                if (needReleaseKeys[i])
                {
                    _needReleaseKeys[i] = needReleaseKeys[i];
                }
            }
        }

        public Input GetModifiedInput()
        {
            RawInput input = _input.GetRawInput();

            for (int i = 0; i < input.PressedKeys.Length; i++)
            {
                if (input.PressedKeys[i])
                {
                    rawInputImages[i].color = Color.red;
                }
                else
                {
                    rawInputImages[i].color = Color.white;
                }
            }

            SetReleasedNotes(input.ReleasedKeys);
            bool[] filterPressedNotes = FilterPressedNotes(input.PressedKeys);

            for (int i = 0; i < filterPressedNotes.Length; i++)
            {
                if (filterPressedNotes[i])
                {
                    modifiedImages[i].color = Color.red;
                }
                else
                {
                    modifiedImages[i].color = Color.white;
                }
            }

            for (int i = 0; i < _needReleaseKeys.Length; i++)
            {
                if (_needReleaseKeys[i])
                {
                    rawInputNeedUpImages[i].color = Color.red;
                }
                else
                {
                    rawInputNeedUpImages[i].color = Color.white;
                }
            }

            return new Input(input, filterPressedNotes);
        }

        private void SetReleasedNotes(bool[] releasedNotes)
        {
            for (int i = 0; i < releasedNotes.Length; i++)
            {
                if (releasedNotes[i])
                {
                    _needReleaseKeys[i] = false;
                }
            }
        }

        private bool[] FilterPressedNotes(bool[] pressedNotes)
        {
            for (int i = 0; i < pressedNotes.Length; i++)
            {
                pressedNotes[i] &= !_needReleaseKeys[i];
            }
            return pressedNotes;
        }
    }
}
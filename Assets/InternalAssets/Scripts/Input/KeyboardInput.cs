using System;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class KeyboardInput : GameInput
    {
        private bool _initialized;
        private KeyCode[] _trackingButtons;

        private void Awake()
        {
            _trackingButtons = new KeyCode[GeneralSettings.KeysCount];
            for (var i = 0; i < GeneralSettings.KeysCount; i++)
            {
                _trackingButtons[i] = (KeyCode)Enum.Parse(typeof(KeyCode),
                    PlayerPrefs.GetString(PlayerPrefsSettings.Keyboard + (i + 1)));
            }

            _initialized = true;
        }

        private bool[] KeysDown()
        {
            var keysDown = new bool[GeneralSettings.KeysCount];
            for (var i = 0; i < GeneralSettings.KeysCount; i++)
            {
                keysDown[i] = UnityEngine.Input.GetKeyDown(_trackingButtons[i]);
            }
            return keysDown;
        }

        private bool[] Keys()
        {
            var keys = new bool[GeneralSettings.KeysCount];
            for (var i = 0; i < GeneralSettings.KeysCount; i++)
            {
                keys[i] = UnityEngine.Input.GetKey(_trackingButtons[i]);
            }
            return keys;
        }

        private bool[] KeysUp()
        {
            var keysUp = new bool[GeneralSettings.KeysCount];
            for (var i = 0; i < GeneralSettings.KeysCount; i++)
            {
                keysUp[i] = UnityEngine.Input.GetKeyUp(_trackingButtons[i]);
            }

            return keysUp;
        }


        public override RawInput GetRawInput()
        {
            if (_initialized)
            {
                return new RawInput(KeysDown(), Keys(), KeysUp());
            }

            return new RawInput(new bool[GeneralSettings.KeysCount], new bool[GeneralSettings.KeysCount],
                new bool[GeneralSettings.KeysCount]);
        }

        public override ServiceInput GetServiceInput()
        {
            if (!_initialized)
            {
                return new ServiceInput(false);
            }

            return new ServiceInput(UnityEngine.Input.GetKeyDown(KeyCode.Escape));
        }
    }
}
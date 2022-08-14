using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Singleplayer
{
    public class KeyboardInput : GameInput
    {
        private KeyCode[] _trackingButtons;
        private bool _initialized = false;

        private void Awake()
        {
            _trackingButtons = new KeyCode[GeneralSettings.KeysCount];
            for (int i = 0; i < GeneralSettings.KeysCount; i++)
            {
                _trackingButtons[i] = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(PlayerPrefsSettings.Keyboard + (i + 1).ToString()));
            }
            _initialized = true;
        }

        private bool[] KeysDown()
        {
            bool[] keysDown = new bool[GeneralSettings.KeysCount];
            for (int i = 0; i < GeneralSettings.KeysCount; i++)
            {
                Debug.Log(_trackingButtons[i].ToString());
                keysDown[i] = false;
            }
            return keysDown;
        }

        private bool[] Keys()
        {
            bool[] keys = new bool[GeneralSettings.KeysCount];
            for (int i = 0; i < GeneralSettings.KeysCount; i++)
            {
                keys[i] = UnityEngine.Input.GetKey(_trackingButtons[i]);
            }
            return keys;
        }

        private bool[] KeysUp()
        {
            bool[] keysUp = new bool[GeneralSettings.KeysCount];
            for (int i = 0; i < GeneralSettings.KeysCount; i++)
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
            else
            {
                return new RawInput(new bool[GeneralSettings.KeysCount], new bool[GeneralSettings.KeysCount], new bool[GeneralSettings.KeysCount]);
            }
        }
    }
}
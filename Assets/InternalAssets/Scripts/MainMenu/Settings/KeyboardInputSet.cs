using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class KeyboardInputSet : MonoBehaviour
    {
        private string _keyboardInput = "";

        private void Start()
        {
            UpdateInputSettings();
        }

        private void UpdateInputSettings()
        {
            _keyboardInput = "";
            for (int i = 1; i <= GeneralSettings.KeysCount; i++)
            {
                _keyboardInput += PlayerPrefs.GetString(PlayerPrefsSettings.Keyboard + i.ToString());
            }
        }

        public void SetKey(int keyPosition, KeyCode key)
        {
            PlayerPrefs.SetString(PlayerPrefsSettings.Keyboard + keyPosition.ToString(), key.ToString());
            UpdateInputSettings();
        }

        public bool CheckOnRepetition(KeyCode key)
        {
            return _keyboardInput.Contains(key.ToString());
        }
    }
}
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace InternalAssets.Scripts
{
    public class KeyboardInputPanel : MonoBehaviour
    {
        private const string waitForInputText = "Wait for input";

        public Action<KeyCode> KeyHasHandled;
        
        [Range(1, 5)] [SerializeField] private int _buttonIndex;
        [SerializeField] private TextMeshProUGUI _text;
        
        private KeyboardSettingsHandler _settingsHandler;
        private bool _waitForInput;

        public void Initialize(KeyboardSettingsHandler settingsHandler)
        {
            _settingsHandler = settingsHandler;
            if (PlayerPrefs.GetInt(PlayerPrefsSettings.PlayAnyTime) == 1)
            {
                _text.text = PlayerPrefs.GetString(PlayerPrefsSettings.Keyboard + _buttonIndex);
            }
        }

        private void OnGUI()
        {
            if (_waitForInput && Event.current.isKey)
            {
                var getKey = Event.current.keyCode;

                if (!_settingsHandler.CheckOnRepetition(getKey))
                {
                    _waitForInput = false;
                    _text.text = getKey.ToString();

                    KeyHasHandled?.Invoke(getKey);
                }
            }
        }

        public void WaitForInput()
        {
            _waitForInput = true;
            _text.text = waitForInputText;
        }
    }
}
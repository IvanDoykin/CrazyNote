using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game.MainMenu
{
    public class ButtonPanel : MonoBehaviour
    {
        private const string waitForInputText = "Wait for input";

        [Range(1, 5)]
        [SerializeField] private int _buttonNumber;
        [SerializeField] private TextMeshProUGUI _text;
        private KeyboardInputSet _inputSet;

        private bool _waitForInput = false;

        private void Start()
        {
            _inputSet = FindObjectOfType<KeyboardInputSet>();

            if (PlayerPrefs.GetInt(PlayerPrefsSettings.PlayAnyTime) == 1)
            {
                Debug.Log("not first time");
                _text.text = PlayerPrefs.GetString(PlayerPrefsSettings.Keyboard + _buttonNumber.ToString());
            }
            else
            {
                Debug.Log("first time");
            }
        }

        public void WaitForInput()
        {
            _waitForInput = true;
            _text.text = waitForInputText;
        }

        private void OnGUI()
        {
            if (_waitForInput && Event.current.isKey)
            {
                KeyCode getKey = Event.current.keyCode;

                if (!_inputSet.CheckOnRepetition(getKey))
                {
                    _waitForInput = false;
                    _text.text = getKey.ToString();
                    _inputSet.SetKey(_buttonNumber, getKey);
                }
            }
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class KeyboardSettingsHandler : MonoBehaviour
    {
        [SerializeField] private List<KeyboardInputPanel> _keyboardInputPanels = new List<KeyboardInputPanel>();
        private DefaultKeyboardSettingsInitializer _defaultKeyboardSettings;
        private string _keyboardInput = "";

        private void Start()
        {
            InitializeDefaultSettings();
            InitializeKeyboardInputPanels();
            UpdateInputSettings();
        }

        private void InitializeDefaultSettings()
        {
            _defaultKeyboardSettings = new DefaultKeyboardSettingsInitializer(this);
            _defaultKeyboardSettings.Initialize();
        }
        
        private void InitializeKeyboardInputPanels()
        {
            for (int i = 0; i < _keyboardInputPanels.Count; i++)
            {
                var index = i;
                _keyboardInputPanels[index].KeyHasHandled += (key) =>
                {
                    SetKey(index + 1, key);
                };
                _keyboardInputPanels[index].Initialize(this);
            }
        }
        
        private void UpdateInputSettings()
        {
            _keyboardInput = "";
            for (var i = 1; i <= GeneralSettings.KeysCount; i++)
            {
                _keyboardInput += PlayerPrefs.GetString(PlayerPrefsSettings.Keyboard + i);
            }
        }

        public void SetKey(int keyPosition, KeyCode key)
        {
            Debug.Log("Set " + PlayerPrefsSettings.Keyboard + keyPosition + " to " + key);
            PlayerPrefs.SetString(PlayerPrefsSettings.Keyboard + keyPosition, key.ToString());
            UpdateInputSettings();
        }

        public bool CheckOnRepetition(KeyCode key)
        {
            return _keyboardInput.Contains(key.ToString());
        }
    }
}
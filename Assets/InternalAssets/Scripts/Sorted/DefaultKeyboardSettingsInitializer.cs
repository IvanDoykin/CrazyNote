using UnityEngine;

namespace InternalAssets.Scripts
{
    public class DefaultKeyboardSettingsInitializer
    {
        private readonly KeyCode[] _defaultKeys = new KeyCode[]
            { KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.V, KeyCode.B };

        private readonly KeyboardSettingsHandler _keyboardInput;
        
        public DefaultKeyboardSettingsInitializer(KeyboardSettingsHandler keyboardInput)
        {
            _keyboardInput = keyboardInput;
        }
        
        public void Initialize()
        {
            if (PlayerPrefs.GetInt(PlayerPrefsSettings.PlayAnyTime) == 0)
            {
                PlayerPrefs.SetInt(PlayerPrefsSettings.PlayAnyTime, 1);
                for (var i = 1; i <= GeneralSettings.KeysCount; i++)
                {
                    _keyboardInput.SetKey(i, _defaultKeys[i - 1]);
                }
            }
        }
    }
}
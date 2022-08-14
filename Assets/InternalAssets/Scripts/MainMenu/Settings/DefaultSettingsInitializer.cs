using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Singleplayer
{
    public class DefaultSettingsInitializer : MonoBehaviour
    {
        private readonly KeyCode[] _defaultKeys = new KeyCode[5] { KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.V, KeyCode.B };

        private void Awake()
        {
            if (PlayerPrefs.GetInt(PlayerPrefsSettings.PlayAnyTime) == 0) 
            {
                PlayerPrefs.SetInt(PlayerPrefsSettings.PlayAnyTime, 1);
                for (int i = 1; i <= GeneralSettings.KeysCount; i++)
                {
                    FindObjectOfType<KeyboardInputSet>().SetKey(i, _defaultKeys[i - 1]);
                    Debug.Log("set key to " + _defaultKeys[i - 1]);
                } 
            }
        }
    }
}
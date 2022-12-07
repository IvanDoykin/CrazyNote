using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class GriefSettings : MonoBehaviour
    {
        public static float Speed;
        [SerializeField] private TextMeshProUGUI _text;

        private void Start()
        {
            if (PlayerPrefs.GetFloat(PlayerPrefsSettings.Speed, -1) != -1)
            {
                Speed = PlayerPrefs.GetFloat(PlayerPrefsSettings.Speed);
            }
            else
            {
                Speed = 1f;
                PlayerPrefs.SetFloat(PlayerPrefsSettings.Speed, Speed);
            }
            if (GetComponent<SceneLoader>() != null) return;
            _text.text = Speed.ToString();
        }

        public void AddSpeed()
        {
            Speed += 0.25f;
            if (Speed > 2f)
            {
                Speed = 1f;
            }
            PlayerPrefs.SetFloat(PlayerPrefsSettings.Speed, Speed);
            _text.text = Speed.ToString();
        }
    }
}
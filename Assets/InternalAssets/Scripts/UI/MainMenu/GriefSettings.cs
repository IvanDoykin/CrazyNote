using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class GriefSettings : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private void Start()
        {
            if (PlayerPrefs.GetFloat(PlayerPrefsSettings.Speed, -1) != -1)
            {
                Mover.Speed = PlayerPrefs.GetFloat(PlayerPrefsSettings.Speed);
            }
            else
            {
                Mover.Speed = 1f;
                PlayerPrefs.SetFloat(PlayerPrefsSettings.Speed, Mover.Speed);
            }
            _text.text = Mover.Speed.ToString();
        }

        public void AddSpeed()
        {
            Mover.Speed += 0.25f;
            if (Mover.Speed > 2f)
            {
                Mover.Speed = 1f;
            }
            PlayerPrefs.SetFloat(PlayerPrefsSettings.Speed, Mover.Speed);
            _text.text = Mover.Speed.ToString();
        }
    }
}
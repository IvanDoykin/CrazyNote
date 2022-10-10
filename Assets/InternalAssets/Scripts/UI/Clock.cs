using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class Clock : MonoBehaviour
    {
        private const float hourToSeconds = 3600f;
        [SerializeField] private TextMeshProUGUI _text;

        private bool _active = false;
        private float _time = 0f;

        public void Initialize(float time)
        {
            _time = time;
            _active = true;
        }

        public void Pause()
        {
            _active = false;
        }

        public void Resume()
        {
            _active = true;
        }

        private void Update()
        {
            if (_active)
            {
                _time -= Time.deltaTime;

                if (_time < 0f)
                {
                    _time = 0f;
                    _active = false;
                }

                if (_time > hourToSeconds)
                {
                    _text.text = TimeSpan.FromSeconds(_time).ToString(@"h\:mm\:ss");
                }
                else
                {
                    _text.text = TimeSpan.FromSeconds(_time).ToString(@"mm\:ss");
                }
            }
        }
    }
}
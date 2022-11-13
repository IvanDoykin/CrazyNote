using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class StartMenuSound : MonoBehaviour
    {
        private const float endOfSongOffset = 0.25f;

        public Action HasPreEnd;
        public Action HasEnd;

        [SerializeField] private AudioSource _audio;
        private bool _preEnd = false;

        public void Play()
        {
            _audio.Play();
        }

        private void Update()
        {
            if (_audio.time > _audio.clip.length - endOfSongOffset && !_preEnd)
            {
                HasPreEnd?.Invoke();
                _preEnd = true;
            }

            if (_audio.time >= _audio.clip.length && _preEnd)
            {
                HasEnd?.Invoke();
            }
        }
    }
}
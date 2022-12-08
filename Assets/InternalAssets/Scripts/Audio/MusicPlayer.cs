using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace InternalAssets.Scripts
{
    public class MusicPlayer : MonoBehaviour
    {
        public static float PlayDelay = 1.925f / GriefSettings.Speed;

        public Action MusicHasDone;

        [SerializeField] private AudioSource _audio;
        private bool _isEnd = false;

        private void Update()
        {
            if (_audio.clip != null)
            {
                if (!_isEnd && _audio.time > _audio.clip.length - 0.1f)
                {
                    _isEnd = true;
                    MusicHasDone?.Invoke();
                }
            }
        }

        public void Pause()
        {
            _audio.Pause();
        }

        public void Resume()
        {
            _audio.Play();
        }

        public void Play(AudioClip clip)
        {
            _audio.clip = clip;
            _audio.PlayDelayed(PlayDelay);
        }
    }
}
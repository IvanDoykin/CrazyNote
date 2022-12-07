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
        [SerializeField] private AudioSource _audio;

        public float ClipTime => _audio.clip.length;
        
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
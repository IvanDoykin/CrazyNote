using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace InternalAssets.Scripts
{
    public class MusicPlayer : MonoBehaviour
    {
        public const float PlayDelay = 1.925f;
        [SerializeField] private AudioSource _audio;

        public float ClipTime => _audio.clip.length;
        
        public void Play(AudioClip clip)
        {
            _audio.clip = clip;
            _audio.PlayDelayed(PlayDelay);
        }
    }
}
using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace InternalAssets.Scripts
{
    public class MusicPlayer : MonoBehaviour
    {
        private const float playDelay = 1.925f;
        [SerializeField] private AudioSource _audio;
        
        public void Play(AudioClip clip)
        {
            _audio.clip = clip;
            _audio.PlayDelayed(playDelay);
        }
    }
}
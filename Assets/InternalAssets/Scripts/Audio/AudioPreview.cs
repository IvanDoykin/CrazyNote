using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace InternalAssets.Scripts
{
    public class AudioPreview : MonoBehaviour
    {
        private const float previewLength = 10f;
        private const float fadeLength = 2f;

        [SerializeField] private AudioSource _audio;

        private void Update()
        {
            if (_audio.clip != null)
            {
                Debug.Log("time = " + _audio.time);
                if (_audio.time < fadeLength)
                {
                    _audio.volume += Time.deltaTime / fadeLength;
                }
                if (_audio.time > previewLength - fadeLength)
                {
                    _audio.volume -= Time.deltaTime / fadeLength;
                }
            }
        }

        public void SetPreview(AudioClip clip)
        {
            _audio.clip = clip;
            _audio.time = 0f;
            _audio.Play();
        }
    }
}
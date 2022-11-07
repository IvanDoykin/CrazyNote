using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace InternalAssets.Scripts
{
    public class AudioPreview : MonoBehaviour
    {
        private const string filePathHeader = "file:///";
        private const float previewLength = 10f;
        private const float lerpVolumeTime = 1.5f;
        private const float soundDelay = 0.5f;
        
        private readonly string[] _songNames = { "song.ogg", "song.mp3" };
        private readonly string[] _songTypes = { "OGGVORBIS", "MPEG" };

        [SerializeField] private AudioSource _audio;
        private bool _waitForVolumeDown;

        private void Update()
        {
            if (_audio.clip != null)
            {
                if (_audio.time >= Mathf.Clamp(_audio.clip.length / 2 + previewLength - lerpVolumeTime - soundDelay, 0,
                        _audio.clip.length) && _waitForVolumeDown)
                {
                    StartCoroutine(SmoothSetVolumeState(false));
                    _waitForVolumeDown = false;
                }

                if (_audio.time < _audio.clip.length / 2 || _audio.time >=
                    Mathf.Clamp(_audio.clip.length / 2 + previewLength, 0, _audio.clip.length))
                {
                    _audio.time = _audio.clip.length / 2;
                    _audio.volume = 0f;
                    _audio.Play();

                    StartCoroutine(SmoothSetVolumeState(true));
                    _waitForVolumeDown = true;
                }
            }
        }

        private IEnumerator SmoothSetVolumeState(bool state)
        {
            var time = 0f;
            while (time < lerpVolumeTime)
            {
                time += Time.deltaTime;

                if (state)
                {
                    _audio.volume = time / lerpVolumeTime;
                }
                else
                {
                    _audio.volume = 1 - time / lerpVolumeTime;
                }

                yield return null;
            }
        }

        public void SetPreview(AudioClip clip)
        {
            _audio.clip = clip;
            _audio.time = 0;
            _audio.volume = 0f;
            _waitForVolumeDown = false;
        }
    }
}
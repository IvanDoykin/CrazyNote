using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Game.MainMenu
{
    public class AudioPreview : MonoBehaviour
    {
        private const string filePathHeader = "file:///";
        private const float previewLength = 10f;
        private const float lerpVolumeTime = 1.5f;
        private const float soundDelay = 0.5f;

        private AudioSource _audio;
        private string[] _songNames = new string[2] { "song.ogg", "song.mp3" };
        private string[] _songTypes = new string[2] { "OGGVORBIS", "MPEG" };

        private bool waitForVolumeDown = false;

        private void Start()
        {
            _audio = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (_audio.clip != null)
            {
                if (_audio.time >= Mathf.Clamp(_audio.clip.length / 2 + previewLength - lerpVolumeTime - soundDelay, 0, _audio.clip.length) && waitForVolumeDown)
                {
                    StartCoroutine(SmoothSetVolumeState(false));
                    waitForVolumeDown = false;
                }
                if (_audio.time < _audio.clip.length / 2 || _audio.time >= Mathf.Clamp(_audio.clip.length / 2 + previewLength, 0, _audio.clip.length))
                {
                    _audio.time = _audio.clip.length / 2;
                    _audio.volume = 0f;
                    _audio.Play();

                    StartCoroutine(SmoothSetVolumeState(true));
                    waitForVolumeDown = true;
                }
            }
        }

        private IEnumerator SmoothSetVolumeState(bool state)
        {
            float time = 0f;
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

        public void SetPreview(string directory)
        {
            for (int i = 0; i < _songNames.Length; i++)
            {
                string path = directory + _songNames[i];

                if (File.Exists(path))
                {
                    StartCoroutine(SetAudioRequest(path, _songTypes[i]));
                }
            }
        }

        private IEnumerator SetAudioRequest(string path, string songType)
        {
            using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(filePathHeader + path, (AudioType)Enum.Parse(typeof(AudioType), songType)))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.ConnectionError)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    _audio.clip = DownloadHandlerAudioClip.GetContent(www);
                    _audio.time = 0;
                }
            }
        }
    }
}
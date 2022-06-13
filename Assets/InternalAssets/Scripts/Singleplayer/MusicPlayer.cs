using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace Game.Singleplayer
{
    public class MusicPlayer : MonoBehaviour
    {
        private const string filePathHeader = "file:///";
        private AudioSource _audio;

        private string[] _songNames = new string[2] { "song.ogg", "song.mp3" };
        private string[] _songTypes = new string[2] { "OGGVORBIS", "MPEG" };

        private void Awake()
        {
            _audio = GetComponent<AudioSource>();
            SetMusic(Track.Instance.Directory);
        }

        private void Start()
        {
            Play(1.925f);
        }

        public void Play(float delay)
        {
            StartCoroutine(PlayWithDelay(delay));
        }

        private IEnumerator PlayWithDelay(float time)
        {
            yield return new WaitForSeconds(time);
            _audio.Play();
        }

        public void SetMusic(string directory)
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
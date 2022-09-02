using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace InternalAssets.Scripts
{
    public class MusicHandler : MonoBehaviour
    {
        private const string filePathHeader = "file:///";

        private readonly string[] _songNames = new string[2] { "song.ogg", "song.mp3" };
        private readonly string[] _songTypes = new string[2] { "OGGVORBIS", "MPEG" };

        public Action<AudioClip> ClipHasGot;
        
        public void GetMusic(string directory)
        {
            for (var i = 0; i < _songNames.Length; i++)
            {
                var path = directory + _songNames[i];

                if (File.Exists(path))
                {
                    StartCoroutine(SetAudioRequest(path, _songTypes[i]));
                }
            }
        }
        
        private IEnumerator SetAudioRequest(string path, string songType)
        {
            using (var www = UnityWebRequestMultimedia.GetAudioClip(filePathHeader + path,
                       (AudioType)Enum.Parse(typeof(AudioType), songType)))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.ConnectionError)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    ClipHasGot?.Invoke(DownloadHandlerAudioClip.GetContent(www));
                }
            }
        }
    }
}
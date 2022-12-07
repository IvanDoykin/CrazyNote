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
        private const string songName = "Preview.mp3";
        private const string songType = "MPEG";

        public Action<AudioClip> ClipHasGot;

        public void SetPreview(string directory)
        {
            var path = directory + songName;

            if (File.Exists(path))
            {
                StartCoroutine(SetAudioRequest(path, songType));
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
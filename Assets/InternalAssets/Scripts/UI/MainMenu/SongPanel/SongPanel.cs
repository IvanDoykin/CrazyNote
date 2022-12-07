using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace InternalAssets.Scripts
{
    [RequireComponent(typeof(SongPanelView))]
    [RequireComponent(typeof(Button))]

    public class SongPanel : MonoBehaviour
    {
        private const string filePathHeader = "file:///";
        private const string songName = "Preview.mp3";
        private const string songType = "MPEG";

        public Action<SongPanel> HasSelected;
        public string Directory { get; private set; }
        private SelectableButton _button;

        private void Start()
        {
            _button = GetComponent<SelectableButton>();

            _button.HasClicked += () =>
            {
                StartCoroutine(StartGame());
            };

            _button.HasSelected += () =>
            {
                StartCoroutine(DelaySelected());
            };

            _button.HasDeselected += () =>
            {
                StopAllCoroutines();
            };
        }

        private IEnumerator StartGame()
        {
            using (var www = UnityWebRequestMultimedia.GetAudioClip(filePathHeader + Directory + "song.mp3",
                       (AudioType)Enum.Parse(typeof(AudioType), songType)))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.ConnectionError)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    FindObjectOfType<MainMenuScene>().StartGame(Directory, DownloadHandlerAudioClip.GetContent(www));
                }
            }
        }
        private IEnumerator DelaySelected()
        {
            yield return new WaitForSeconds(2f);
            HasSelected?.Invoke(this);
        }

        public void CreateFromDirectory(string directory)
        {
            SongPanelView panelView = GetComponent<SongPanelView>();
            Directory = directory;

            var info = SongsInfoParser.GetParsedInfo(directory);
            panelView.SetSongInfo(info);

            var additionalInfo = SongsInfoParser.GetAdditionalInfo(directory);
            panelView.SetAdditionalInfo(additionalInfo);
        }
    }
}
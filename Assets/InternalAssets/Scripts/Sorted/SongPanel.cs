using System;
using UnityEngine;
using UnityEngine.UI;

namespace InternalAssets.Scripts
{
    [RequireComponent(typeof(SongPanelView))]
    [RequireComponent(typeof(Button))]
    public class SongPanel : MonoBehaviour
    {
        public Action<SongPanel> HasClicked;
        public string Directory { get; private set; }

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(() =>
            {
                HasClicked?.Invoke(this);
            });
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
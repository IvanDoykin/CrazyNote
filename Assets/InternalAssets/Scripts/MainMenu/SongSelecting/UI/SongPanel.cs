using UnityEngine;

namespace Game.MainMenu.SongSelecting
{
    [RequireComponent(typeof(SongPanelView))]
    [RequireComponent(typeof(SongsInfoParser))]

    public class SongPanel : MonoBehaviour
    {
        private SongPanelView _panelView;
        private SongsInfoParser _parser;

        private string _directory;
        public string Directory => _directory;

        private void Awake()
        {
            _panelView = GetComponent<SongPanelView>();
            _parser = GetComponent<SongsInfoParser>();
        }

        public void CreateFromDirectory(string directory)
        {
            _directory = directory;

            SongConfigInfo info = _parser.GetParsedInfo(directory);
            _panelView.SetSongInfo(info);

            SongAdditionalInfo additionalInfo = _parser.GetAdditionalInfo(directory);
            _panelView.SetAdditionalInfo(additionalInfo);
        }
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InternalAssets.Scripts
{
    public class SongPanelView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _songName;
        [SerializeField] private TextMeshProUGUI _songArtist;

        [SerializeField] private Image albumImage;
        [SerializeField] private SelectableTextButton _button;

        private Color _defaultNameColor;
        private Color _defaultArtistColor;

        private void Start()
        {
            _defaultNameColor = _songName.color;
            _defaultArtistColor = _songArtist.color;

            _button.HasSelected += Select;
            _button.HasDeselected += Deselect;
        }

        private void Select()
        {
            _songName.color = Color.black;
            _songArtist.color = Color.black;
        }

        private void Deselect()
        {
            _songName.color = _defaultNameColor;
            _songArtist.color = _defaultArtistColor;
        }

        public void SetSongInfo(SongConfigInfo info)
        {
            _songName.text = info.Name;
            _songArtist.text = info.Artist;
        }

        public void SetAdditionalInfo(SongAdditionalInfo additionalInfo)
        {
            albumImage.sprite = additionalInfo.AlbumIcon;
        }
    }
}
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
using UnityEngine;
using UnityEngine.UI;

namespace Game.MainMenu.SongSelecting
{
    public struct SongAdditionalInfo
    {
        public Sprite AlbumIcon { get; private set; }

        public SongAdditionalInfo(Sprite albumIcon)
        {
            AlbumIcon = albumIcon;
        }
    }
}

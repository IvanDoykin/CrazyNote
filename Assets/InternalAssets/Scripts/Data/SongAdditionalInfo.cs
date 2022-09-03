using UnityEngine;

namespace InternalAssets.Scripts
{
    public struct SongAdditionalInfo
    {
        public Sprite AlbumIcon { get; }

        public SongAdditionalInfo(Sprite albumIcon)
        {
            AlbumIcon = albumIcon;
        }
    }
}
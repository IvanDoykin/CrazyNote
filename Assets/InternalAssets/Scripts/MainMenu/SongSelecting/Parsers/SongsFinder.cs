using System.IO;
using UnityEngine;

namespace Game.MainMenu.SongSelecting
{
    public class SongsFinder : MonoBehaviour
    {
        public string[] FindSongsDirectories()
        {
            return Directory.GetDirectories(Application.streamingAssetsPath, "*", SearchOption.TopDirectoryOnly);
        }
    }
}

using System.IO;
using UnityEngine;

namespace Game.MainMenu.SongSelecting
{
    public class SongsFinder : MonoBehaviour
    {
        [SerializeField] private string _songsPath = Application.streamingAssetsPath;

        public string[] FindSongsDirectories()
        {
            return Directory.GetDirectories(_songsPath, "*", SearchOption.TopDirectoryOnly);
        }
    }
}

using System.IO;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public static class SongsFinder
    {
        public static string[] FindSongsDirectories()
        {
            return Directory.GetDirectories(Application.streamingAssetsPath, "*", SearchOption.TopDirectoryOnly);
        }
    }
}
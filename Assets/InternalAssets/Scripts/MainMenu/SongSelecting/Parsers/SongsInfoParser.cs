using System.IO;
using UnityEngine;

namespace Game.MainMenu.SongSelecting
{
    public class SongsInfoParser : MonoBehaviour
    {
        [SerializeField] private Sprite _defaultSprite;

        private const string configName = "song.ini";
        private const string albumIconName = "album.png";

        private const string nameFieldName = "name";
        private const string artistFieldName = "artist";

        public SongConfigInfo GetParsedInfo(string directory)
        {
            string name = "";
            string artist = "";

            string[] lines = File.ReadAllLines(directory + configName);
            foreach (var line in lines)
            {
                SetParsedField(line, nameFieldName, ref name);
                SetParsedField(line, artistFieldName, ref artist);
            }

            return new SongConfigInfo(name, artist);
        }

        public SongAdditionalInfo GetAdditionalInfo(string directory)
        {
            if (File.Exists(directory + albumIconName))
            {
                string[] filePaths = Directory.GetFiles(directory, albumIconName); // Get all files of type .png in this folder
                Debug.Log(directory + albumIconName);
                //Converts desired path into byte array
                byte[] pngBytes = File.ReadAllBytes(filePaths[0]);

                //Creates texture and loads byte array data to create image
                Texture2D tex = new Texture2D(2, 2);
                tex.LoadImage(pngBytes);

                //Creates a new Sprite based on the Texture2D
                Sprite fromTex = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
                return new SongAdditionalInfo(fromTex);
            }

            return new SongAdditionalInfo(_defaultSprite);
        }

        private void SetParsedField(string parsingLine, string fieldName, ref string field)
        {
            if (parsingLine.Contains(fieldName))
            {
                field = parsingLine.Replace(fieldName, "").Trim(new char[2] { ' ', '=' });
            }
        }
    }
}

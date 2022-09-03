using System.IO;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public static class SongsInfoParser
    {
        private const string configName = "song.ini";
        private const string albumIconName = "album.png";

        private const string nameFieldName = "name";
        private const string artistFieldName = "artist";

        private static Sprite sprite; 
        private static Sprite defaultSprite
        {
            get
            {
                if (sprite == null)
                {
                    sprite = Sprite.Create(Texture2D.whiteTexture, new Rect(Vector2.zero, Vector2.one), Vector2.one / 2);
                }

                return sprite;
            }
        }

        public static SongConfigInfo GetParsedInfo(string directory)
        {
            var name = "";
            var artist = "";

            var lines = File.ReadAllLines(directory + configName);
            foreach (var line in lines)
            {
                SetParsedField(line, nameFieldName, ref name);
                SetParsedField(line, artistFieldName, ref artist);
            }

            return new SongConfigInfo(name, artist);
        }

        public static SongAdditionalInfo GetAdditionalInfo(string directory)
        {
            if (File.Exists(directory + albumIconName))
            {
                var filePaths =
                    Directory.GetFiles(directory, albumIconName); // Get all files of type .png in this folder
                //Converts desired path into byte array
                var pngBytes = File.ReadAllBytes(filePaths[0]);

                //Creates texture and loads byte array data to create image
                var tex = new Texture2D(2, 2);
                tex.LoadImage(pngBytes);

                //Creates a new Sprite based on the Texture2D
                var fromTex = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f),
                    100.0f);
                return new SongAdditionalInfo(fromTex);
            }

            return new SongAdditionalInfo(defaultSprite);
        }

        private static void SetParsedField(string parsingLine, string fieldName, ref string field)
        {
            if (parsingLine.Contains(fieldName)) field = parsingLine.Replace(fieldName, "").Trim(' ', '=');
        }
    }
}
using UnityEngine;

namespace InternalAssets.Scripts
{
    public static class SongBlockParser
    {
        private const string nameField = "Name";
        private const string artistField = "Artist";
        private const string resolutionField = "Resolution";

        public static Song Get(string directory)
        {
            var name = "";
            var artist = "";
            var resolution = 0;

            var lines = BlockParser.ParseBlockByName(directory, BlockName.Song);
            foreach (var line in lines)
            {
                if (line.Contains(nameField))
                {
                    name = line.Trim().Replace(nameField, "").Trim(' ', '=', '"');
                }

                if (line.Contains(artistField))
                {
                    artist = line.Trim().Replace(artistField, "").Trim(' ', '=', '"');
                }

                if (line.Contains(resolutionField))
                {
                    resolution = int.Parse(line.Trim().Replace(resolutionField, "").Trim(' ', '=', '"'));
                }
            }

            return new Song(name, artist, resolution);
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.MainMenu.ChartParsing
{
    public class SongBlockParser : MonoBehaviour
    {
        private const string nameField = "Name";
        private const string artistField = "Artist";
        private const string resolutionField = "Resolution";

        public static Song Get(string directory)
        {
            string name = "";
            string artist = "";
            int resolution = 0;

            string[] lines = BlockParser.ParseBlockByName(directory, BlockName.Song);
            foreach (string line in lines)
            {
                if (line.Contains(nameField))
                {
                    name = line.Replace(nameField, "").Trim(new char[3] { ' ', '=', '"' });
                }

                if (line.Contains(artistField))
                {
                    artist = line.Replace(artistField, "").Trim(new char[3] { ' ', '=', '"' });
                }

                if (line.Contains(resolutionField))
                {
                    resolution = Int32.Parse(line.Replace(resolutionField, "").Trim(new char[3] { ' ', '=', '"' }));
                }
            }

            return new Song(name, artist, resolution);
        }
    }
}

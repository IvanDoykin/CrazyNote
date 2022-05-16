using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Game.MainMenu.ChartParsing
{
    public enum BlockName
    {
        Song,
        SyncTrack,
        Events,
        ExpertSingle,
        HardSingle,
        MediumSingle,
        EasySingle
    }

    public class BlockParser : MonoBehaviour
    {
        private const string chartName = "notes.chart";

        public static string[] ParseBlockByName(string directory, BlockName blockName)
        {
            string path = directory + chartName;

            if (File.Exists(path))
            {
                List<string> outputLines = new List<string>();
                string[] lines = File.ReadAllLines(path);
                bool startParse = false;

                foreach (string line in lines)
                {
                    if (line == "{")
                    {
                        continue;
                    }

                    if (line == ("[" + blockName.ToString() + "]"))
                    {
                        startParse = true;
                        continue;
                    }

                    if (line == "}" && startParse)
                    {
                        return outputLines.ToArray();
                    }

                    if (startParse)
                    {
                        outputLines.Add(line.Trim(new char[1] { ' '}));
                    }
                }

                return new string[0];
            }

            else
            {
                Debug.LogError("File not found");
                return new string[0];
            }
        }
    }
}

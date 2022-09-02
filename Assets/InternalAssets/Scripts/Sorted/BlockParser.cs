using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace InternalAssets.Scripts
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
            var path = directory + chartName;

            if (File.Exists(path))
            {
                var outputLines = new List<string>();
                var lines = File.ReadAllLines(path);
                var startParse = false;

                foreach (var line in lines)
                {
                    if (line == "{") continue;

                    if (line == "[" + blockName + "]")
                    {
                        startParse = true;
                        continue;
                    }

                    if (line == "}" && startParse) return outputLines.ToArray();

                    if (startParse) outputLines.Add(line.Trim(' '));
                }

                return Array.Empty<string>();
            }

            Debug.LogError("File not found");
            return Array.Empty<string>();
        }
    }
}
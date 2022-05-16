using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.MainMenu.ChartParsing
{
    public class TrackBlockParser : MonoBehaviour
    {
        public static TrackBlock Get(string directory, BlockName blockName)
        {
            List<TrackEvent> sections = new List<TrackEvent>();

            string[] lines = BlockParser.ParseBlockByName(directory, blockName);

            foreach (string line in lines)
            {
                int position = 0;
                TypeCode code = TypeCode.A;
                List<string> arguments = new List<string>();

                string[] lineWithSortedPosition = line.Split('=');
                position = Int32.Parse(lineWithSortedPosition[0].Trim());

                string[] lineWithSortedTrackCode = lineWithSortedPosition[1].Trim().Split(' ');
                code = (TypeCode)Enum.Parse(typeof(TypeCode), lineWithSortedTrackCode[0]);

                for (int i = 1; i < lineWithSortedTrackCode.Length; i++)
                {
                    arguments.Add(lineWithSortedTrackCode[i]);
                }

                sections.Add(new TrackEvent(position, code, arguments));
            }

            return new TrackBlock(sections);
        }
    }
}
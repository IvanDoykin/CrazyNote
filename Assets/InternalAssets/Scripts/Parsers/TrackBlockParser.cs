using System;
using System.Collections.Generic;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public static class TrackBlockParser
    {
        public static TrackBlock Get(string directory, BlockName blockName)
        {
            var sections = new List<TrackEvent>();

            var lines = BlockParser.ParseBlockByName(directory, blockName);

            foreach (var line in lines)
            {
                var position = 0;
                var arguments = new List<string>();

                var lineWithSortedPosition = line.Split('=');
                position = int.Parse(lineWithSortedPosition[0].Trim());

                var lineWithSortedTrackCode = lineWithSortedPosition[1].Trim().Split(' ');
                var code = (TypeCode)Enum.Parse(typeof(TypeCode), lineWithSortedTrackCode[0]);

                for (var i = 1; i < lineWithSortedTrackCode.Length; i++) arguments.Add(lineWithSortedTrackCode[i]);

                sections.Add(new TrackEvent(position, code, arguments));
            }

            return new TrackBlock(sections);
        }
    }
}
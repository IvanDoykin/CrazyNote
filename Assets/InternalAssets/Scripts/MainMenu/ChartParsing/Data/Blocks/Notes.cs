using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.MainMenu.ChartParsing
{
    public class Notes
    {
        public TrackBlock TrackBlock { get; private set; }

        public Notes(TrackBlock trackBlock)
        {
            TrackBlock = trackBlock;
        }
    }
}

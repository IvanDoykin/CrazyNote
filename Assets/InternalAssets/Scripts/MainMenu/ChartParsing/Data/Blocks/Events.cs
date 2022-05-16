using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.MainMenu.ChartParsing
{
    public class Events
    {
        public TrackBlock TrackBlock { get; private set; }

        public Events(TrackBlock trackBlock)
        {
            TrackBlock = trackBlock;
        }
    }
}

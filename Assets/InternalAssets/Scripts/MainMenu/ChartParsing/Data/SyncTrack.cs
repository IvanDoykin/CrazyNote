using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.MainMenu.ChartParsing
{
    public class SyncTrack
    {
        public TrackBlock TrackBlock { get; private set; }

        public SyncTrack(TrackBlock trackBlock)
        {
            TrackBlock = trackBlock;
        }
    }
}

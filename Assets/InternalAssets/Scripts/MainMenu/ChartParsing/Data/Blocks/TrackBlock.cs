using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.MainMenu.ChartParsing
{
    public class TrackBlock
    {
        public TrackEvent[] Infos { get; protected set; }
        public TrackBlock(List<TrackEvent> _infos)
        {
            Infos = new TrackEvent[_infos.Count];
            _infos.CopyTo(Infos);
        }
    }
}
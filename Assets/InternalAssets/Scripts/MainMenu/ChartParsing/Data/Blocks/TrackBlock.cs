using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.MainMenu.ChartParsing
{
    public class TrackBlock
    {
        public List<TrackEvent> Infos { get; protected set; }
        public TrackBlock(List<TrackEvent> _infos)
        {
            Infos = new List<TrackEvent>(_infos);
        }
    }
}
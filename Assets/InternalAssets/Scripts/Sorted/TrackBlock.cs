using System.Collections.Generic;

namespace InternalAssets.Scripts
{
    public class TrackBlock
    {
        public TrackBlock(List<TrackEvent> _infos)
        {
            Infos = new List<TrackEvent>(_infos);
        }

        public List<TrackEvent> Infos { get; protected set; }
    }
}
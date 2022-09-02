using System;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class Track
    {
        public Song Song { get; private set; }
        public SyncTrack SyncTrack { get; private set; }
        public Notes Notes { get; private set; }
        public AudioClip Clip { get; private set; }

        public Track(string directory, Difficulty difficulty, AudioClip clip)
        {
            Clip = clip;
            SetTrack(directory, difficulty);
        }
        
        private void SetTrack(string directory, Difficulty difficulty)
        {
            Song = SongBlockParser.Get(directory);
            SyncTrack = new SyncTrack(TrackBlockParser.Get(directory, BlockName.SyncTrack));
            Notes = new Notes(TrackBlockParser.Get(directory, (BlockName)Enum.Parse(typeof(BlockName), difficulty + "Single")));
        }
    }
}
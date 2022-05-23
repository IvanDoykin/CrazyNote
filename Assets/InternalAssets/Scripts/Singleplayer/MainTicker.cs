using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Singleplayer {
    public class MainTicker : MonoBehaviour
    {
        public static MainTicker Instance { get; private set; }

        private int currentTick = 0;
        private int currentIndex = 0;
        private int passedNotesFromLastTempo = 0;
        private int needNotesForTempo = 0;
        private double secondsFromLastTick = 0.0;
        private double secondsForOneTick = 0.0;
        private double BPM = 0.0;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                Tick();
            }
            else
            {
                Destroy(this);
            }
        }

        private void Update()
        {
            if (secondsFromLastTick > secondsForOneTick)
            {
                currentTick++;
                secondsFromLastTick -= secondsForOneTick;
                Tick();
            }

            secondsFromLastTick += Time.deltaTime;
        }

        private void SetBPM(double bpm)
        {
            BPM = bpm;
            secondsForOneTick = 1.0 / BPM / Track.Instance.Song.Resolution;
        }

        private void SetTempo(int numerator, int denominator = 2)
        {
            //TEMPO
            needNotesForTempo = numerator;
        }

        private void Tick()
        {
            TickSyncTrack();
            TickNotes();
        }

        private void TickSyncTrack()
        {
            for (int i = currentIndex; Track.Instance.SyncTrack.TrackBlock.Infos[i].Position < currentTick; i++)
            {
                if (Track.Instance.SyncTrack.TrackBlock.Infos[i].Code == TypeCode.B)
                {
                    SetBPM(double.Parse(Track.Instance.SyncTrack.TrackBlock.Infos[i].Arguments[0]) / 1000.0);
                }
                if (Track.Instance.SyncTrack.TrackBlock.Infos[i].Code == TypeCode.TS)
                {
                    SetTempo(int.Parse(Track.Instance.SyncTrack.TrackBlock.Infos[i].Arguments[0]));
                }
            }
        }

        private void TickNotes()
        {

        }
    }
}
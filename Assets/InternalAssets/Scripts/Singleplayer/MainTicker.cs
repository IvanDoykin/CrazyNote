using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Singleplayer
{
    public class MainTicker : MonoBehaviour
    {
        public static MainTicker Instance { get; private set; }

        private SingleplayerScene singleplayerScene;

        private int currentTick = 0;
        private int currentIndex = 0;

        private double secondsFromLastTick = 0.0;
        private double secondsForOneTick = 0.0;

        private int needTicksForWide = 0;
        private int ticksfromLastWide = 0;

        private double BPM = 0.0;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                singleplayerScene = FindObjectOfType<SingleplayerScene>();
                Tick(0);
            }
            else
            {
                Destroy(this);
            }
        }

        private void Update()
        {
            while (secondsFromLastTick >= secondsForOneTick)
            {
                currentTick++;
                secondsFromLastTick -= secondsForOneTick;
                Tick(currentTick);
            }

            if (ticksfromLastWide >= needTicksForWide && needTicksForWide != 0)
            {
                ticksfromLastWide -= needTicksForWide;
                singleplayerScene.CreateWide();
            }

            secondsFromLastTick += Time.deltaTime;
            ticksfromLastWide++;
        }

        private void SetBPM(double bpm)
        {
            BPM = bpm;
            secondsForOneTick = 60.0 / BPM / Track.Instance.Song.Resolution;
        }

        private void SetTempo(int numerator, int denominator = 2)
        {
            if (currentTick != 0)
            {
                //singleplayerScene.CreateWide();
            }

            needTicksForWide = Track.Instance.Song.Resolution * numerator;
        }

        private void Tick(int tick)
        {
            TickSyncTrack(tick);
            TickNotes(tick);
        }

        private void TickSyncTrack(int tick)
        {
            Debug.Log("COUNT = " + Track.Instance.SyncTrack.TrackBlock.Infos.Count);
            if (Track.Instance.SyncTrack.TrackBlock.Infos.Count <= currentIndex)
            {
                return;
            }

            for (int i = currentIndex; Track.Instance.SyncTrack.TrackBlock.Infos[i].Position <= tick;)
            {
                if (Track.Instance.SyncTrack.TrackBlock.Infos[i].Code == TypeCode.B)
                {
                    Debug.Log("Set BPM = " + double.Parse(Track.Instance.SyncTrack.TrackBlock.Infos[i].Arguments[0]) / 1000.0);
                    SetBPM(double.Parse(Track.Instance.SyncTrack.TrackBlock.Infos[i].Arguments[0]) / 1000.0);
                }
                if (Track.Instance.SyncTrack.TrackBlock.Infos[i].Code == TypeCode.TS)
                {
                    Debug.Log("Set tempo = " + int.Parse(Track.Instance.SyncTrack.TrackBlock.Infos[i].Arguments[0]));
                    SetTempo(int.Parse(Track.Instance.SyncTrack.TrackBlock.Infos[i].Arguments[0]));
                }

                i++;
                if (Track.Instance.SyncTrack.TrackBlock.Infos.Count <= i)
                {
                    return;
                }
            }
        }

        private void TickNotes(int tick)
        {
            if (Track.Instance.Notes.TrackBlock.Infos.Count <= currentIndex)
            {
                return;
            }

            int temp = currentIndex;
            for (int i = temp; Track.Instance.Notes.TrackBlock.Infos[i].Position <= tick;)
            {
                currentIndex++;
                
                if (Track.Instance.Notes.TrackBlock.Infos[i].Code == TypeCode.N)
                {
                    if (int.Parse(Track.Instance.Notes.TrackBlock.Infos[i].Arguments[0]) > 4) return;
                    singleplayerScene.CreateNote(int.Parse(Track.Instance.Notes.TrackBlock.Infos[i].Arguments[0]));
                }

                i++;
                if (Track.Instance.SyncTrack.TrackBlock.Infos.Count <= i)
                {
                    return;
                }
            }
        }
    }
}
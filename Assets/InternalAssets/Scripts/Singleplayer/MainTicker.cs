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
        private int currentNoteIndex = 0;
        private int currentSyncIndex = 0;

        private double secondsFromLastTick = 0.0;
        private double secondsForOneTick = 0.0;

        private int needTicksForWide = 0;
        private int ticksfromLastWide = 0;

        public float BPM { get; private set; } = 0.0f;
        private bool hasNote = false;

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

            if (ticksfromLastWide >= needTicksForWide && needTicksForWide != 0 && hasNote)
            {
                ticksfromLastWide = Track.Instance.Song.Resolution - 1;
                singleplayerScene.CreateWide();
            }

            secondsFromLastTick += Time.deltaTime;
            ticksfromLastWide++;
        }

        private void SetBPM(float bpm)
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
            if (Track.Instance.SyncTrack.TrackBlock.Infos.Count <= currentSyncIndex)
            {
                return;
            }

            int temp = currentSyncIndex;
            for (int i = temp; Track.Instance.SyncTrack.TrackBlock.Infos[i].Position <= tick;)
            {
                currentSyncIndex++;

                if (Track.Instance.SyncTrack.TrackBlock.Infos[i].Code == TypeCode.B)
                {
                    Debug.Log("Set BPM = " + float.Parse(Track.Instance.SyncTrack.TrackBlock.Infos[i].Arguments[0]) / 1000.0f);
                    SetBPM(float.Parse(Track.Instance.SyncTrack.TrackBlock.Infos[i].Arguments[0]) / 1000.0f);
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
            if (Track.Instance.Notes.TrackBlock.Infos.Count <= currentNoteIndex)
            {
                return;
            }

            int temp = currentNoteIndex;
            for (int i = temp; Track.Instance.Notes.TrackBlock.Infos[i].Position <= tick;)
            {
                currentNoteIndex++;
                
                if (Track.Instance.Notes.TrackBlock.Infos[i].Code == TypeCode.N)
                {
                    if (int.Parse(Track.Instance.Notes.TrackBlock.Infos[i].Arguments[0]) > 4) return;
                    hasNote = true;
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
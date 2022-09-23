using System.Collections.Generic;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class MainTicker : MonoBehaviour
    {
        [SerializeField] private DynamicObjectsFactory _dynamicObjectsFactory;

        private Track _track;
        
        private int _currentNoteIndex;
        private int _currentSyncIndex;

        private int _currentTick;
        private bool _hasNote;

        private int _needTicksForWide;
        private double _secondsForOneTick;

        private double _secondsFromLastTick;
        private int _ticksfromLastWide;
        
        public float Bpm { get; private set; }
        
        public void Initialize(Track track)
        {
            _track = track;
            Tick(0);
        }

        private void Update()
        {
            if (_track == null)
            {
                return;
            }

            while (_secondsFromLastTick >= _secondsForOneTick)
            {
                _ticksfromLastWide++;
                _currentTick++;
                _secondsFromLastTick -= _secondsForOneTick;
                Tick(_currentTick);
            }

            if (_ticksfromLastWide >= _needTicksForWide && _needTicksForWide != 0 && _hasNote)
            {
                _ticksfromLastWide = 0;
                _dynamicObjectsFactory.CreateWide();
            }

            _secondsFromLastTick += Time.deltaTime;
        }

        private void SetBpm(float bpm)
        {
            Bpm = bpm;
            _secondsForOneTick = 60.0 / Bpm / _track.Song.Resolution;
        }

        private void SetTempo(int numerator, int denominator = 2)
        {
            if (_currentTick != 0)
            {
                _dynamicObjectsFactory.CreateWide();
            }

            _needTicksForWide = _track.Song.Resolution * numerator;
        }

        private void Tick(int tick)
        {
            TickSyncTrack(tick);
            TickNotes(tick);
        }

        private void TickSyncTrack(int tick)
        {
            if (_track.SyncTrack.TrackBlock.Infos.Count <= _currentSyncIndex) return;

            var temp = _currentSyncIndex;
            for (var i = temp; _track.SyncTrack.TrackBlock.Infos[i].Position <= tick;)
            {
                _currentSyncIndex++;

                if (_track.SyncTrack.TrackBlock.Infos[i].Code == TypeCode.B)
                {
                    SetBpm(float.Parse(_track.SyncTrack.TrackBlock.Infos[i].Arguments[0]) / 1000.0f);
                }

                if (_track.SyncTrack.TrackBlock.Infos[i].Code == TypeCode.TS)
                {
                    SetTempo(int.Parse(_track.SyncTrack.TrackBlock.Infos[i].Arguments[0]));
                }

                i++;
                if (_track.SyncTrack.TrackBlock.Infos.Count <= i)
                {
                    return;
                }
            }
        }

        private void TickNotes(int tick)
        {
            if (_track.Notes.TrackBlock.Infos.Count <= _currentNoteIndex)
            {
                return;
            }

            var temp = _currentNoteIndex;
            
            var notes = new List<Note>();
            var position = -1;
            
            for (var i = temp; _track.Notes.TrackBlock.Infos[i].Position <= tick;)
            {
                position = _track.Notes.TrackBlock.Infos[i].Position;
                _currentNoteIndex++;

                if (_track.Notes.TrackBlock.Infos[i].Code == TypeCode.N)
                {
                    if (int.Parse(_track.Notes.TrackBlock.Infos[i].Arguments[0]) <= 4)
                    {
                        _hasNote = true;
                        notes.Add(_dynamicObjectsFactory.CreateNote(int.Parse(_track.Notes.TrackBlock.Infos[i].Arguments[0])));
                    }
                }

                i++;
                
                if (_track.Notes.TrackBlock.Infos.Count <= i)
                {
                    break;
                }
            }
            
            if (notes.Count > 0)
            {
                _dynamicObjectsFactory.CreateNotesGroup(notes.ToArray(), position);
            }
        }
    }
}
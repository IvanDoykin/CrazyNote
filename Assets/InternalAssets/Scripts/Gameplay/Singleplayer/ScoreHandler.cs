using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class ScoreHandler : MonoBehaviour
    {
        private const int baseScoreForNote = 1;
        private readonly int[] needNotesForMuliplayer = { 60, 120, 180 };

        [SerializeField] private NotesHandler _notesHandler;
        [SerializeField] private ScoreCounter _scoreUI;
        [SerializeField] private ComboCounter _comboUI;
        [SerializeField] private MultiplayerBox _multiplayerUI;
        [SerializeField] private FinalUI _final;

        private float _score = 0f;
        private int _combo = 0;
        private int _multiplayer = 1;

        private int _maxCombo = 0;

        private float _hitNotes = 0f;
        private float _allNotes = 0f;

        private void Start()
        {
            _notesHandler.NoteGroupHasHit += HitNoteGroup;
            Reset();
        }

        public void Final()
        {
            StartCoroutine(DelayFinalize());
        }

        private IEnumerator DelayFinalize()
        {
            yield return new WaitForSeconds(3f);
            _final.Initialize((int)_score, _hitNotes / _allNotes, _maxCombo);
        }

        private void Reset()
        {
            _score = 0;
            _combo = 0;
            _multiplayer = 1;

            _scoreUI.SetScore((int)_score);
            _comboUI.SetCombo(_combo);
            _multiplayerUI.SetMultiplayer(_multiplayer, false);
        }
        
        private void HitNoteGroup(int notesInGroup, bool hit)
        {
            if (hit)
            {
                _hitNotes++;
                ApplyNoteGroup(notesInGroup);
            }
            else
            {
                MissNoteGroup();
            }
            _allNotes++;
        }

        private void ApplyNoteGroup(int notesInGroup)
        {
            _score += baseScoreForNote * notesInGroup * _multiplayer;
            _scoreUI.SetScore((int)_score);

            _combo++;
            if (_combo > _maxCombo)
            {
                _maxCombo = _combo;
            }

            _comboUI.SetCombo(_combo);

            if (_multiplayer <= needNotesForMuliplayer.Length)
            {
                if (_combo == needNotesForMuliplayer[_multiplayer - 1])
                {
                    _multiplayer++;
                    _multiplayerUI.SetMultiplayer(_multiplayer, false);
                }
            }
        }

        private void MissNoteGroup()
        {
            _combo = 0;
            _multiplayer = 1;

            _comboUI.SetCombo(_combo);
            _multiplayerUI.SetMultiplayer(_multiplayer, false);
        }
    }
}
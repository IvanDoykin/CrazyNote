using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class ScoreHandler : MonoBehaviour
    {
        private const int baseScoreForNote = 10;
        private readonly int[] needNotesForMuliplayer = { 5, 10, 15 };

        [SerializeField] private NotesHandler _notesHandler;
        [SerializeField] private ScoreCounter _scoreUI;
        [SerializeField] private ComboCounter _comboUI;
        [SerializeField] private MultiplayerBox _multiplayerUI;

        private float _score = 0f;
        private int _combo = 0;
        private int _multiplayer = 1;

        private void Start()
        {
            _notesHandler.NoteGroupHasHit += HitNote;
            Reset();
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
        
        private void HitNote(bool hit)
        {
            if (hit)
            {
                ApplyNote();
            }
            else
            {
                MissNote();
            }
        }

        private void ApplyNote()
        {
            _score += baseScoreForNote * _multiplayer;
            _scoreUI.SetScore((int)_score);

            _combo++;
            _comboUI.SetCombo(_combo);

            if (_multiplayer <= needNotesForMuliplayer.Length)
            {
                if (_combo > needNotesForMuliplayer[_multiplayer - 1])
                {
                    _multiplayer++;
                    _multiplayerUI.SetMultiplayer(_multiplayer, false);
                }
            }
        }

        private void MissNote()
        {
            _combo = 0;
            _multiplayer = 1;

            _comboUI.SetCombo(_combo);
            _multiplayerUI.SetMultiplayer(_multiplayer, false);
        }
    }
}
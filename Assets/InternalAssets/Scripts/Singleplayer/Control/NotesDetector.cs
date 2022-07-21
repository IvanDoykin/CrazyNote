using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Singleplayer
{
    public class NotesDetector : MonoBehaviour
    {
        private const float timeToDestroy = 2.15f;
        private const float timeToRegister = 1.975f;

        private readonly List<Note> _registredNotes = new List<Note>();
        private readonly List<Note> _availableNotes = new List<Note>();

        public IEnumerator<Note> AvailableNotes => _availableNotes.GetEnumerator();

        private void Awake()
        {
            Note.HasCreated += RegisterNote;
        }

        private void OnDestroy()
        {
            Note.HasCreated -= RegisterNote;
        }

        private void RegisterNote(Note note)
        {
            _registredNotes.Add(note);
        }

        private void Update()
        {
            TickRegistredNotes();
            TickAvailableNotes();
        }

        private void TickRegistredNotes()
        {
            for (int i = 0; i < _registredNotes.Count; i++)
            {
                _registredNotes[i].Tick();
                if (_registredNotes[i].Timer >= timeToRegister)
                {
                    _availableNotes.Add(_registredNotes[i]);
                    _registredNotes.Remove(_registredNotes[i]);
                }
            }
        }

        private void TickAvailableNotes()
        {
            bool miss = false;
            for (int i = 0; i < _availableNotes.Count; i++)
            {
                _availableNotes[i].Tick();
                if (_availableNotes[i].Timer >= timeToDestroy)
                {
                    miss = true;
                    _availableNotes[i].SetInPool();
                    _availableNotes.Remove(_availableNotes[i]);
                }
            }

            if (miss)
            {
                FindObjectOfType<GuitarControlRuler>().DEBUG_MISSES++;
            }
        }
    }
}
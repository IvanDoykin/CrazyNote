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
                if (_registredNotes[i].gameObject.activeSelf)
                {
                    _registredNotes[i].Tick();
                    if (_registredNotes[i].Timer >= timeToRegister)
                    {
                        _availableNotes.Add(_registredNotes[i]);
                        _registredNotes.Remove(_registredNotes[i]);
                    }
                }
            }
        }

        public void TriggerNote(Note note)
        {
            if (_availableNotes.Contains(note))
            {
                note.SetInPool();
                _availableNotes.Remove(note);
            }
        }

        private void TickAvailableNotes()
        {
            bool miss = false;
            for (int i = 0; i < _availableNotes.Count; i++)
            {
                if (_availableNotes[i].gameObject.activeSelf)
                {
                    _availableNotes[i].Tick();
                    if (_availableNotes[i].Timer >= timeToDestroy)
                    {
                        miss = true;
                        var note = _availableNotes[i];
                        note.SetInPool();
                        _availableNotes.Remove(note);
                    }
                }
            }

            if (miss)
            {
                FindObjectOfType<GuitarControlRuler>().DEBUG_MISSES++;
            }
        }
    }
}
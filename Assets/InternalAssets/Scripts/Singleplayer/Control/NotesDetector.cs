using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Game.Singleplayer
{
    public class NotesDetector : MonoBehaviour
    {
        public const float TimeToDestroy = 2.2f;
        public const float TimeToTrigger = 2.0f;
        public const float TimeToRegister = 1.75f;

        private readonly List<Note> _registredNotes = new List<Note>();
        public List<Note> AvailableNotes => _registredNotes.Where(note => note.Timer >= TimeToTrigger).ToList();
        public List<Note> RegistredNotes => _registredNotes;

        private void Awake()
        {
            Note.HasInitialized += RegisterNote;
        }

        private void OnDestroy()
        {
            Note.HasInitialized -= RegisterNote;
        }

        private void RegisterNote(Note note)
        {
            Debug.Log("register note");
            _registredNotes.Add(note);
        }

        public void Tick()
        {
            TickRegistredNotes();
        }

        public Note[] GetRegistredOneTimeNotes(int verticalPosition)
        {
            Note[] notes = new Note[5];
            Debug.Log("Note pos = " + verticalPosition);
            _registredNotes.ToArray().Log();

            for (int i = 0; i < _registredNotes.Count; i++)
            {
                if (_registredNotes[i].VerticalPosition == verticalPosition)
                {
                    notes[_registredNotes[i].HorizontalPosition] = _registredNotes[i];
                }
            }

            return notes;
        }

        public void TriggerNote(Note note)
        {
            if (_registredNotes.Contains(note) && note.Timer >= TimeToTrigger)
            {
                note.Remove(true);
                _registredNotes.Remove(note);
            }
        }

        private void TickRegistredNotes()
        {
            bool miss = false;
            for (int i = 0; i < _registredNotes.Count; i++)
            {
                if (_registredNotes[i].gameObject.activeSelf)
                {
                    _registredNotes[i].Tick();
                    if (_registredNotes[i].Timer >= TimeToDestroy)
                    {
                        miss = true;
                        var note = _registredNotes[i];
                        note.Remove(false);
                        _registredNotes.Remove(note);
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
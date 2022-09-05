using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class NotesHandler : MonoBehaviour
    {
        public const float TimeToDestroy = 2.13f;
        public const float TimeToTrigger = 2.0f;

        public Action<int, bool> NoteHasHit;
        public List<Note> AvailableNotes => RegistredNotes.Where(note => note.Timer >= TimeToTrigger).ToList();
        public List<Note> RegistredNotes { get; } = new List<Note>();

        [SerializeField] private DynamicObjectsFactory _factory;

        private void Start()
        {
            _factory.NoteHasCreated += RegisterNote;
        }

        private void OnDestroy()
        {
            _factory.NoteHasCreated -= RegisterNote;
        }

        private void RegisterNote(Note note)
        {
            Debug.Log("register note");
            note.HasHit += (int horizontalPosition, bool hit) => NoteHasHit?.Invoke(horizontalPosition, hit);
            RegistredNotes.Add(note);
        }

        private void UnregisterNote(Note note)
        {
            note.HasHit -= (int horizontalPosition, bool hit) => NoteHasHit?.Invoke(horizontalPosition, hit);
            RegistredNotes.Remove(note);
        }
        
        public void Tick()
        {
            TickRegistredNotes();
        }

        public Note[] GetRegistredOneTimeNotes(int verticalPosition)
        {
            var notes = new Note[5];
            Debug.Log("Note pos = " + verticalPosition);
            RegistredNotes.ToArray().Log();

            for (var i = 0; i < RegistredNotes.Count; i++)
            {
                if (RegistredNotes[i].VerticalPosition == verticalPosition)
                {
                    notes[RegistredNotes[i].HorizontalPosition] = RegistredNotes[i];
                }
            }

            return notes;
        }

        public void TriggerNote(Note note)
        {
            if (RegistredNotes.Contains(note) && note.Timer >= TimeToTrigger)
            {
                note.Remove(true);
                UnregisterNote(note);
            }
        }

        private void TickRegistredNotes()
        {
            var miss = false;
            for (var i = 0; i < RegistredNotes.Count; i++)
            {
                if (RegistredNotes[i].gameObject.activeSelf)
                {
                    RegistredNotes[i].Tick();
                    if (RegistredNotes[i].Timer >= TimeToDestroy)
                    {
                        miss = true;
                        var note = RegistredNotes[i];
                        note.Remove(false);
                        UnregisterNote(note);
                    }
                }
            }

            if (miss)
            {
                FindObjectOfType<GuitarControl>().DEBUG_MISSES++;
            }
        }
    }
}
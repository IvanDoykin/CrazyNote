using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class NotesDetector : MonoBehaviour
    {
        public const float TimeToDestroy = 2.13f;
        public const float TimeToTrigger = 2.0f;
        public const float TimeToRegister = 1.75f;

        public List<Note> AvailableNotes => RegistredNotes.Where(note => note.Timer >= TimeToTrigger).ToList();
        public List<Note> RegistredNotes { get; } = new List<Note>();

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
            RegistredNotes.Add(note);
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
                RegistredNotes.Remove(note);
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
                        RegistredNotes.Remove(note);
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
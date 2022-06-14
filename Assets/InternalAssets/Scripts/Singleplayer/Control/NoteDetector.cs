using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Singleplayer
{
    public class NoteDetector : MonoBehaviour
    {
        private readonly List<Note> _notes = new List<Note>();

        public Note GetFirstNote()
        {
            if (_notes.Count > 0)
            {
                return _notes[0];
            }
            return null;
        }

        public void CatchFirstNote()
        {
            GetFirstNote().Catch();
        }

        private void OnTriggerEnter(Collider other)
        {
            var note = other.GetComponent<Note>();
            if (note != null)
            {
                _notes.Add(note);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var note = other.GetComponent<Note>();
            if (note != null)
            {
                _notes.Remove(note);
                note.SetInPool();
            }
        }
    }
}
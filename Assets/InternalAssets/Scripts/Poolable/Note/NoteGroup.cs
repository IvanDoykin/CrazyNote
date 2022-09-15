using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class NoteGroup
    {
        public Note[] Notes { get; private set; }
        public int VerticalPosition { get; private set; }

        public float Timer { get; private set; } = 0f;
        
        public NoteGroup(Note[] notes, int verticalPosition)
        {
            Notes = new Note[notes.Length];
            notes.CopyTo(Notes, 0);

            VerticalPosition = verticalPosition;
            
            Debug.Log("Created " + notes.Length + " notes with pos #" + verticalPosition);
        }

        public void Tick()
        {
            Timer += Time.deltaTime;
        }

        public void Trigger(bool hit)
        {
            for (int i = 0; i < Notes.Length; i++)
            {
                Debug.Log("Remove note [" + i + "]");
                Notes[i].Remove(hit);
            }
            Debug.Log("Removed " + Notes.Length + " notes");
        }
        
        public bool IsAllTriggered(bool[] input)
        {
            Debug.Log("Notes count = " + Notes.Length);
            foreach (var note in Notes)
            {
                input.Log();
                if (!input[note.HorizontalPosition])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
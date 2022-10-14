using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        }

        public void SetActive()
        {
            foreach (var note in Notes)
            {
                note.SetActive();
            }
        }

        public void SetInactive()
        {
            foreach (var note in Notes)
            {
                note.SetInactive();
            }
        }

        public void Tick()
        {
            Timer += Time.deltaTime;
        }

        public void Trigger(bool hit)
        {
            for (int i = 0; i < Notes.Length; i++)
            {
                Notes[i].Remove(hit);
            }
        }

        public bool IsAllTriggered(bool[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (Notes.FirstOrDefault(note => note.HorizontalPosition == i) != null && !input[i])
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsAllTriggered(bool[] input, bool[] holdingInput)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (Notes.FirstOrDefault(note => note.HorizontalPosition == i) != null && !input[i] && !holdingInput[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
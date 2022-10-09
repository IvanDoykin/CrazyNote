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
        
        public bool IsAllTriggered(bool[] input, bool[] detectInput)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (Notes.FirstOrDefault(note => note.HorizontalPosition == i) != null != input[i])
                {
                    if (input[i] && !detectInput[i] || !input[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsAllHeld(bool[] holdInput, bool[] detectInput)
        {
            for (int i = 0; i < holdInput.Length; i++)
            {
                if (Notes.FirstOrDefault(note => note.HorizontalPosition == i) != null != holdInput[i])
                {
                    if (holdInput[i] && !detectInput[i] || !holdInput[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Singleplayer
{
    public struct RawInput
    {
        public bool[] JustPressedKeys { get; private set; }
        public bool[] PressedKeys { get; private set; }
        public bool[] ReleasedKeys { get; private set; }

        public RawInput(bool[] justPressedKeys, bool[] pressedNotes, bool[] releasedNotes)
        {
            JustPressedKeys = new bool[justPressedKeys.Length];
            justPressedKeys.CopyTo(JustPressedKeys, 0);

            PressedKeys = new bool[pressedNotes.Length];
            pressedNotes.CopyTo(PressedKeys, 0);

            ReleasedKeys = new bool[releasedNotes.Length];
            releasedNotes.CopyTo(ReleasedKeys, 0);
        }
    }
}
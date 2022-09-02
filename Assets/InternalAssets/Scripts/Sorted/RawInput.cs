namespace InternalAssets.Scripts
{
    public struct RawInput
    {
        public bool[] JustPressedKeys { get; }
        public bool[] PressedKeys { get; }
        public bool[] ReleasedKeys { get; }

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
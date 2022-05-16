using System.Collections.Generic;

namespace Game.MainMenu.ChartParsing
{
    public struct TrackEvent
    {
        public int Position { get; private set; }
        public TypeCode Code { get; private set; }
        public string[] Arguments { get; private set; }

        public TrackEvent(int position, TypeCode code, List<string> arguments)
        {
            Position = position;
            Code = code;

            Arguments = new string[arguments.Count];
            arguments.CopyTo(Arguments);
        }
    }
}

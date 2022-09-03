using System.Collections.Generic;

namespace InternalAssets.Scripts
{
    public struct TrackEvent
    {
        public int Position { get; }
        public TypeCode Code { get; }
        public string[] Arguments { get; }

        public TrackEvent(int position, TypeCode code, List<string> arguments)
        {
            Position = position;
            Code = code;

            Arguments = new string[arguments.Count];
            arguments.CopyTo(Arguments);
        }
    }
}
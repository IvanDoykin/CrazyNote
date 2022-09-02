namespace InternalAssets.Scripts
{
    public struct SongConfigInfo
    {
        public string Name { get; }
        public string Artist { get; }

        public SongConfigInfo(string name, string artist)
        {
            Name = name;
            Artist = artist;
        }
    }
}
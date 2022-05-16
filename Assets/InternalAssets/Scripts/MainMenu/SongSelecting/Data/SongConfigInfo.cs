namespace Game.MainMenu.SongSelecting
{
    public struct SongConfigInfo
    {
        public string Name { get; private set; }
        public string Artist { get; private set; }

        public SongConfigInfo(string name, string artist)
        {
            Name = name;
            Artist = artist;
        }
    }
}
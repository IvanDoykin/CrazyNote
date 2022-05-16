namespace Game.MainMenu.ChartParsing
{
    public class Song
    {
        public string Name { get; private set; }
        public string Artist { get; private set; }
        public int Resolution { get; private set; }

        public Song(string name, string artist, int resolution)
        {
            Name = name;
            Artist = artist;
            Resolution = resolution;
        }
    }
}
namespace InternalAssets.Scripts
{
    public class Song
    {
        public Song(string name, string artist, int resolution)
        {
            Name = name;
            Artist = artist;
            Resolution = resolution;
        }

        public string Name { get; }
        public string Artist { get; }
        public int Resolution { get; }
    }
}
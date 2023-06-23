namespace Spotify
{
    internal class Song
    {
        public string Name { get; private set; }
        public List<Artist> Artists { get; private set; } = new List<Artist>();
        public string Genre { get; private set; }
        public readonly int LengthInSeconds;

        public Song(string name, int lengthInSeconds, string genre, params Artist[] artists)
        {
            this.Name = name;
            this.LengthInSeconds = lengthInSeconds;
            this.Genre = genre;
            this.Artists.AddRange(artists);
        }
    }
}

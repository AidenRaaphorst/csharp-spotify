namespace Spotify
{
    internal class Album
    {
        public string Name { get; private set; }
        public List<Artist> Artists { get; private set; } = new List<Artist>();
        public List<Song> Songs { get; private set; }

        public Album(string name, params Artist[] artists)
        {
            this.Name = name;
            this.Artists.AddRange(artists);
            this.Songs = new List<Song>();
        }

        public void AddArtist(Artist artist)
        {
            this.Artists.Add(artist);
        }

        public void RemoveArtist(Artist artist)
        {
            this.Artists.Remove(artist);
        }

        public void AddSong(Song song)
        {
            this.Songs.Add(song);
        }

        public void RemoveSong(Song song)
        {
            this.Songs.Remove(song);
        }
    }
}

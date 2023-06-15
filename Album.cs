namespace Spotify
{
    internal class Album
    {
        public string Title { get; private set; }
        public List<Artist> Artists { get; private set; }
        public List<Song> Songs { get; private set; }
        public long ReleaseDate { get; private set; }

        public Album(string title)
        {
            this.Title = title;
            this.Artists = new List<Artist>();
            this.Songs = new List<Song>();
            this.ReleaseDate = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }

        public void AddArtist(Artist artist)
        {
            this.Artists.Add(artist);
        }

        public void RemoveArtist(Artist artist)
        {
            this.Artists.Remove(artist);
        }

        public void AddSong(params Song[] songs)
        {
            this.Songs.AddRange(songs);
        }

        public void RemoveSong(params Song[] songs)
        {
            foreach (Song song in songs)
            {
                this.Songs.Remove(song);
            }
        }
    }
}

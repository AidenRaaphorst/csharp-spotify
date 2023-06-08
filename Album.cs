namespace Spotify
{
    internal class Album
    {
        public string Title { get; private set; }
        public List<Artist> Artists { get; private set; }
        public List<Song> Songs { get; private set; }
        public long ReleaseDate { get; private set; }

        public Album(string title, List<Artist> artists, List<Song> songs)
        {
            this.Title = title;
            this.Artists = artists;
            this.Songs = songs;
            this.ReleaseDate = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }

        public Album(string title, params Artist[] artists)
        {
            this.Title = title;
            this.Artists = artists.ToList();
            this.Songs = new List<Song>();
            this.ReleaseDate = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }

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
            foreach (Song song in songs)
            {
                if(!songs.Contains(song))
                {
                    this.Songs.Add(song);
                }
            }
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

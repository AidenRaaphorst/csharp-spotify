namespace Spotify
{
    internal class Artist : User
    {
        public readonly List<Song> Singles;
        public readonly List<Album> Albums;

        public Artist(string name) : base(name)
        {
            this.Singles = new List<Song>();
            this.Albums = new List<Album>();
        }

        public void AddSong(Song song)
        {
            this.Singles.Add(song);
        }

        public void RemoveSong(Song song)
        {
            this.Singles.Remove(song);
        }

        public void AddAlbum(Album album)
        {
            this.Albums.Add(album);
        }

        public void RemoveAlbum(Album album)
        {
            this.Albums.Remove(album);
        }
    }
}

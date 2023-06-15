namespace Spotify
{
    internal class Artist : User
    {
        public readonly List<Song> Songs;
        public readonly List<Album> Albums;

        public Artist(string name) : base(name)
        {
            this.Songs = new List<Song>();
            this.Albums = new List<Album>();
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

        public void AddAlbum(params Album[] albums)
        {
            this.Albums.AddRange(albums);
        }

        public void RemoveAlbum(params Album[] albums)
        {
            foreach (Album album in albums)
            {
                this.Albums.Remove(album);
            }
        }
    }
}

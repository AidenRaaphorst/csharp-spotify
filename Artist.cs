namespace Spotify
{
    internal class Artist : User
    {
        public readonly List<Song> Songs;
        public readonly List<Album> Albums;
        public string? Info;

        public Artist(string name, List<Song> songs, List<Album> albums, string? info) : base(name)
        {
            this.Songs = songs;
            this.Albums = albums;
            this.Info = info;
        }

        public Artist(string name, string? info) : base(name)
        {
            this.Songs = new List<Song>();
            this.Albums = new List<Album>();
            this.Info = info;
        }

        public void AddSong(params Song[] songs)
        {
            foreach (Song song in songs)
            {
                if (!this.Songs.Contains(song))
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

        public void AddAlbum(params Album[] albums)
        {
            foreach (Album album in albums)
            {
                if (!this.Albums.Contains(album))
                {
                    this.Albums.Add(album);
                }
            }
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

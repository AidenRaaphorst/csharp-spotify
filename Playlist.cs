namespace Spotify
{
    internal class Playlist
    {
        public string Name { get; private set; }
        public List<Song> Songs { get; private set; }
        public List<User> Authors { get; private set; }
        
        public Playlist(string name, List<Song> songs, params User[] authors)
        {
            this.Name = name;
            this.Songs = songs;
            this.Authors = authors.ToList();
        }

        public Playlist(string name, params User[] authors)
        {
            this.Name = name;
            this.Songs = new List<Song>();
            this.Authors = authors.ToList();
        }

        public void AddSong(Song song)
        {
            this.Songs.Add(song);
        }

        public void RemoveSong(Song song)
        {
            this.Songs.Remove(song);
        }

        public void AddSongsFromAlbum(Album album)
        {
            this.Songs.AddRange(album.Songs);
        }

        public void RemoveSongsFromAlbum(Album album)
        {
            foreach(Song song in album.Songs)
            {
                this.Songs.Remove(song);
            }
        }

        public void AddSongsFromPlaylist(Playlist playlist)
        {
            this.Songs.AddRange(playlist.Songs);
        }

        public void RemoveSongsFromPlaylist(Playlist playlist)
        {
            foreach (Song song in playlist.Songs)
            {
                this.Songs.Remove(song);
            }
        }

        public void AddAuthor(User author)
        {
            this.Authors.Add(author);
        }

        public void RemoveAuthor(User author)
        {
            this.Authors.Remove(author);
        }
    }
}

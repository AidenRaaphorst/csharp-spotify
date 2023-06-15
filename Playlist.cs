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

        public void AddAuthor(params User[] authors)
        {
            this.Authors.AddRange(authors);
        }

        public void RemoveAuthor(params User[] authors)
        {
            foreach (User author in authors)
            {
                this.Authors.Remove(author);
            }
        }
    }
}

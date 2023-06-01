namespace Spotify
{
    internal class Playlist
    {
        public string Name { get; private set; }
        public List<Song> Songs { get; private set; }
        public List<User> Authors { get; private set; }
        
        public Playlist(string name, List<Song> songs, List<User> authors)
        {
            this.Name = name;
            this.Songs = songs;
            this.Authors = authors;
        }

        public Playlist(string name, List<Song> songs, User author)
        {
            this.Name = name;
            this.Songs = songs;
            this.Authors = new List<User>() { author };
        }

        public void AddSong(params Song[] songs)
        {
            foreach (Song song in songs)
            {
                if(!this.Songs.Contains(song))
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

        public void AddAuthor(params User[] authors)
        {
            foreach (User author in authors)
            {
                if (!this.Authors.Contains(author))
                {
                    this.Authors.Add(author);
                }
            }
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

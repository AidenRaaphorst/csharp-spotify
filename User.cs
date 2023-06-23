namespace Spotify
{
    internal class User
    {
        public string Name { get; private set; }
        public readonly Playlist LikedSongs;
        public readonly List<Playlist> Playlists;
        public readonly List<User> Friends;

        public User(string name)
        {
            this.Name = name;
            this.LikedSongs = new Playlist("Liked Songs", new List<Song>(), this);
            this.Playlists = new List<Playlist>();
            this.Friends = new List<User>();
        }

        public void AddLikedSong(Song song)
        {
            this.LikedSongs.AddSong(song);
        }

        public void RemoveLikedSong(Song song)
        {
            this.LikedSongs.RemoveSong(song);
        }

        public void AddFriend(User friend)
        {
            this.Friends.Add(friend);
        }

        public void RemoveFriend(User friend)
        {
            this.Friends.Remove(friend);
        }

        public void AddPlaylist(Playlist playlist)
        {
            this.Playlists.Add(playlist);
        }

        public void RemovePlaylist(Playlist playlist)
        {
            this.Playlists.Remove(playlist);
        }

        public void ShowFriends(bool showIndex = true)
        {
            for(int i = 0; i < this.Friends.Count; i++)
            {
                Console.WriteLine(showIndex ? $"{i+1}. " : "" + this.Friends[0].Name);
            }
        }
    }
}

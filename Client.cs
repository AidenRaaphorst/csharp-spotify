using System;

namespace Spotify
{
    internal class Client
    {
        public User User { get; private set; }
        public List<Album> Albums = TestData.GetAllAlbums();
        public List<Artist> Artists = TestData.GetAllArtists();
        public List<User> Users = TestData.GetAllUsers();

        public Client()
        {
            TestData.PopulateAllData();
            this.User = TestData.MainUser;
        }

        public void ShowUserPlaylists(bool showIndex = false, bool includeLikedSongs = true)
        {
            if (includeLikedSongs)
            {
                Console.WriteLine(showIndex ? "1. Liked songs" : "Liked songs");

                for (int i = 0; i < this.User.Playlists.Count; i++)
                {
                    Console.WriteLine((showIndex ? $"{i + 2}. " : "") + this.User.Playlists[i].Name);
                }
            }
            else
            {
                for (int i = 0; i < this.User.Playlists.Count; i++)
                {
                    Console.WriteLine((showIndex ? $"{i + 1}. " : "") + this.User.Playlists[i].Name);
                }
            }
        }

        public void ShowAllArtists(bool showIndex = true)
        {
            for (int i = 0; i < this.Artists.Count; i++)
            {
                Console.WriteLine((showIndex ? $"{i + 1}. " : "") + this.Artists[i].Name);
            }
        }

        public void ShowAllAlbums(bool showIndex = true)
        {
            for (int i = 0; i < this.Albums.Count; i++)
            {
                Console.WriteLine((showIndex ? $"{i + 2}. " : "") + this.Albums[i].Name);
            }
        }

        public void ShowUsers(bool showIndex = true)
        {
            for (int i = 0; i < this.Users.Count; i++)
            {
                Console.WriteLine((showIndex ? $"{i + 1}. " : "") + this.Users[i].Name);
            }
        }

        public void ShowPlaylists(List<Playlist> playlists, bool showIndex = true)
        {
            for (int i = 0; i < playlists.Count; i++)
            {
                Console.WriteLine((showIndex ? $"{i + 1}. " : "") + this.User.Playlists[i].Name);
            }
        }

        public void ShowArtists(List<Artist> artists, bool showIndex = true)
        {
            for (int i = 0; i < artists.Count; i++)
            {
                Console.WriteLine((showIndex ? $"{i + 1}. " : "") + artists[i].Name);
            }
        }

        public void ShowAlbums(List<Album> albums, bool showIndex = true)
        {
            for (int i = 0; i < albums.Count; i++)
            {
                Console.WriteLine((showIndex ? $"{i + 1}. " : "") + albums[i].Name);
            }
        }

        public void ShowSongs(List<Song> songs, bool showIndex = true)
        {
            for (int i = 0; i < songs.Count; i++)
            {
                Console.WriteLine((showIndex ? $"{i + 1}. " : "") + songs[i].Name);
            }
        }

        public static void ShowTitle()
        {
            Console.WriteLine("===========");
            Console.WriteLine("  Spotify  ");
            Console.WriteLine("===========\n");
        }

        public void Clear(bool showTitle = true)
        {
            Console.Clear();

            if(showTitle)
            {
                ShowTitle();
            }
        }

        public void PlaySong(Song song)
        {
            bool paused = false;
            string minutes = $"{song.LengthInSeconds / 60}".PadLeft(2, '0');
            string seconds = $"{song.LengthInSeconds % 60}".PadLeft(2, '0');

            List<string> artistNames = new List<string>();
            foreach(Artist artist in song.Artists)
            {
                artistNames.Add(artist.Name);
            }

            for(int i = 0; i < song.LengthInSeconds; i++)
            {
                Console.Clear();

                string minutesSoFar = $"{i / 60}".PadLeft(2, '0');
                string secondsSoFar = $"{i % 60}".PadLeft(2, '0');
                Console.WriteLine($"Playing: {song.Name} - {string.Join(", ", artistNames)}     {minutesSoFar}:{secondsSoFar}/{minutes}:{seconds}");

                Thread.Sleep(1000);
            }
        }

        public void PlayPlaylist(Playlist playlist)
        {
            foreach (Song song in playlist.Songs)
            {
                PlaySong(song);
            }
        }

        public void PlayAlbum(Album album)
        {
            foreach (Song song in album.Songs)
            {
                PlaySong(song);
            }
        }

        public void ArtistsMenu()
        {
            while (true)
            {
                Clear();
                Artist artist = ChooseArtist(this.Artists);

                if (artist == null)
                {
                    return;
                }

                Clear();
                Console.WriteLine($"Artiest: {artist.Name}");

                Console.WriteLine("\nAlbums:");
                if(artist.Albums.Count > 0)
                {
                    ShowAlbums(artist.Albums);
                }
                else
                {
                    Console.WriteLine("-");
                }

                Console.WriteLine("\nSingles:");
                if(artist.Singles.Count > 0)
                {
                    ShowSongs(artist.Singles);
                }
                else
                {
                    Console.WriteLine("-");
                }

                Console.Write("\nTyp 'a' voor albums, 's' voor singles, of '0' om terug te gaan: ");
                string singleAlbumChoice = Console.ReadLine().ToLower();

                switch (singleAlbumChoice)
                {
                    case "0": 
                        return;
                    
                    case "a":
                        Clear();
                        Album album = ChooseAlbum(artist.Albums);

                        if(album == null)
                        {
                            return;
                        }

                        Console.Write("\nAlbum afspelen ('a'), album bekijken ('b'), \nalbum toevoegen aan playlist ('t'), of terug ('0'): ");
                        string albumInput = Console.ReadLine().ToLower();

                        switch (albumInput)
                        {
                            case "0":
                                return;
                            
                            case "a":
                                PlayAlbum(album);
                                break;

                            case "b":
                                Clear();
                                Song song = ChooseSong(album.Songs);

                                if(song == null)
                                {
                                    return;
                                }

                                Console.Write("\nNummer afspelen ('a'), nummer toevoegen aan playlist ('p'): ");
                                string songChoice = Console.ReadLine().ToLower();

                                if (songChoice == "a")
                                {
                                    PlaySong(song);
                                }
                                else
                                {
                                    AddSongToPlaylist(song);
                                }
                                break;

                            case "t":
                                AddAlbumToPlaylist(album);
                                break;
                        }

                        break;

                    case "s":
                        Song single = ChooseSong(artist.Singles);

                        if(single == null)
                        {
                            return;
                        }

                        Console.Write("\nSingle afspelen ('a'), single toevoegen aan playlist ('t'), of terug ('0'): ");
                        string singleInput = Console.ReadLine().ToLower();

                        switch(singleInput)
                        {
                            case "0":
                                return;

                            case "a":
                                PlaySong(single);
                                break;

                            case "t":
                                AddSongToPlaylist(single);
                                break;
                        }
                        break;
                }
            }
        }

        public void UserPlaylistsMenu()
        {
            while (true)
            {
                Clear();
                ShowUserPlaylists(showIndex: true);

                Console.Write("\nKies de playlist door het getal naast de naam de typen, of typ '0' om terug te gaan: ");
                int playlistIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                if (playlistIndex == -1)
                {
                    return;
                }

                Console.Write("Speel een playlist af ('a'), of bekijk playlist ('b'): ");
                string playlistChoice = Console.ReadLine().ToLower();

                if (playlistChoice == "a")
                {
                    PlayPlaylist(playlistIndex == 0 ? this.User.LikedSongs : this.User.Playlists[playlistIndex - 1]);
                }
                else if(playlistChoice == "b")
                {
                    while(true)
                    {
                        Clear();
                        Playlist playlist = playlistIndex == 0 ? this.User.LikedSongs : this.User.Playlists[playlistIndex - 1];
                        Song song = ChooseSong(playlist.Songs);
                        if(song == null)
                        {
                            return;
                        }

                        Console.Write("\nSpeel een nummer af ('a'), verwijder nummer ('v') of typ '0' om terug te gaan: ");
                        string songChoice = Console.ReadLine().ToLower();

                        if (songChoice == "a")
                        {
                            PlaySong(song);
                        }
                        else if (songChoice == "v")
                        {
                            if(playlistIndex == 0)
                            {
                                this.User.LikedSongs.RemoveSong(song);
                            }
                            else
                            {
                                this.User.Playlists[playlistIndex].RemoveSong(song);
                            }
                        }
                    }
                }
            }
        }

        public void FriendsMenu()
        {
            while (true)
            {
                Clear();
                Console.WriteLine("Vrienden");

                User friend = ChooseFriend(this.User.Friends);

                if(friend == null)
                {
                    return;
                }

                Console.Write("Playlists bekijken ('p'), of verwijder vriend ('v'): ");
                string friendChoice = Console.ReadLine().ToLower();

                if(friendChoice == "p")
                {
                    Clear();
                    Playlist playlist = ChoosePlaylist(friend.Playlists);

                    if(playlist == null)
                    {
                        continue;
                    }

                    Console.Write("Playlist afspelen ('a'), of toevoegen aan jouw playlist ('t'): ");
                    string playlistChoice = Console.ReadLine().ToLower();

                    if(playlistChoice == "a")
                    {
                        PlayPlaylist(playlist);
                    }
                    else if(playlistChoice == "t")
                    {
                        AddPlaylistToPlaylist(playlist);
                    }
                }
                else if(friendChoice == "v")
                {
                    this.User.RemoveFriend(friend);
                }
            }
        }

        public void UsersMenu()
        {
            while(true)
            {
                Clear();
                Console.WriteLine("Gebruikers: ");

                List<User> users = this.Users.ToList();
                foreach(User friends in this.User.Friends)
                {
                    users.Remove(friends);
                }

                User user = ChooseUser(users);
                if(user == null)
                {
                    return;
                }

                Console.Write("Toevoegen als vriend ('t'), of terug ('0'): ");
                string userChoice = Console.ReadLine().ToLower();

                if(userChoice == "0")
                {
                    continue;
                }
                else if(userChoice == "t")
                {
                    this.User.AddFriend(user);
                }
            }
        }

        private Song ChooseSong(List<Song> songs)
        {
            ShowSongs(songs);
            Console.Write("\nKies een nummer door het getal naast de naam te typen, of '0' om terug te gaan: ");
            string input = Console.ReadLine();
            if(input == "0"){
                return null;
            }
            int songIndex = Convert.ToInt32(input) - 1;

            return songs[songIndex];
        }

        private Album ChooseAlbum(List<Album> albums)
        {
            ShowAlbums(albums);
            Console.Write("\nKies een album door het getal naast de naam te typen, of '0' om terug te gaan: ");
            string input = Console.ReadLine();
            if(input == "0"){
                return null;
            }
            int albumIndex = Convert.ToInt32(input) - 1;

            return albums[albumIndex];
        }

        private Playlist ChoosePlaylist(List<Playlist> playlists)
        {
            ShowPlaylists(playlists);
            Console.Write("\nKies een playlist door het getal naast de naam te typen, of '0' om terug te gaan: ");
            string input = Console.ReadLine();
            if(input == "0"){
                return null;
            }
            int playlistIndex = Convert.ToInt32(input) - 1;

            return playlists[playlistIndex];
        }

        private Artist ChooseArtist(List<Artist> artists)
        {
            ShowArtists(artists);
            Console.Write("\nKies een artiest door het getal naast de naam te typen, of '0' om terug te gaan: ");
            string input = Console.ReadLine();
            if(input == "0"){
                return null;
            }
            int artistIndex = Convert.ToInt32(input) - 1;

            return artists[artistIndex];
        }

        private User ChooseFriend(List<User> friends)
        {
            for(int i = 0; i < friends.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {friends[i].Name}");
            }

            Console.Write("\nKies een vriend door het getal naast de naam te typen, of '0' om terug te gaan: ");
            string input = Console.ReadLine();
            if (input == "0")
            {
                return null;
            }
            int friendIndex = Convert.ToInt32(input) - 1;

            return friends[friendIndex];
        }

        private User ChooseUser(List<User> users)
        {
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {users[i].Name}");
            }

            Console.Write("\nKies een gebruiker door het getal naast de naam te typen, of '0' om terug te gaan: ");
            string input = Console.ReadLine();
            if (input == "0")
            {
                return null;
            }
            int userIndex = Convert.ToInt32(input) - 1;

            return users[userIndex];
        }

        private void AddSongToPlaylist(Song song)
        {
            ShowUserPlaylists(showIndex: true);

            Console.Write("\nKies een playlist door het getal naast de naam te typen: ");
            int playlistIndex = Convert.ToInt32(Console.ReadLine()) - 1;

            if(playlistIndex == 0)
            {
                this.User.LikedSongs.AddSong(song);
            }
            else
            {
                this.User.Playlists[playlistIndex].AddSong(song);
            }
        }

        private void AddAlbumToPlaylist(Album album)
        {
            ShowUserPlaylists(showIndex: true);

            Console.Write("\nKies een playlist door het getal naast de naam te typen: ");
            int playlistIndex = Convert.ToInt32(Console.ReadLine()) - 1;

            if (playlistIndex == 0)
            {
                this.User.LikedSongs.AddSongsFromAlbum(album);
            }
            else
            {
                this.User.Playlists[playlistIndex].AddSongsFromAlbum(album);
            }
        }

        private void AddPlaylistToPlaylist(Playlist playlist)
        {
            ShowUserPlaylists(showIndex: true);

            Console.Write("\nKies een playlist door het getal naast de naam te typen: ");
            int playlistIndex = Convert.ToInt32(Console.ReadLine()) - 1;

            if (playlistIndex == 0)
            {
                this.User.LikedSongs.AddSongsFromPlaylist(playlist);
            }
            else
            {
                this.User.Playlists[playlistIndex].AddSongsFromPlaylist(playlist);
            }
        }

        private ConsoleKey WaitForKey(params ConsoleKey[] allowedKeys)
        {
            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;

                if (allowedKeys.Contains(key))
                {
                    return key;
                }
            }
        }
    }
}

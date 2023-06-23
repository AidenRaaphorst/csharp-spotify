namespace Spotify
{
    internal static class TestData
    {
        // Artists
        public static Artist Monuments = new Artist("Monuments");

        // Albums
        public static Album TheAmanuensis = new Album("The Amanuensis", Monuments);
        public static Album InStasis = new Album("In Stasis", Monuments);

        // Users
        public static User MainUser = new User("Aiden");
        public static User User1 = new User("Wil Fred");
        public static User User2 = new User("Jan Janssen");
        public static User User3 = new User("Tom Roonen");
        public static User User4 = new User("Chris Laavers");
        public static User User5 = new User("Emma Evers");

        public static List<Artist> GetAllArtists()
        {
            return new List<Artist>
            {
                Monuments,
            };
        }

        public static List<Album> GetAllAlbums()
        {
            return new List<Album>
            {
                TheAmanuensis,
                InStasis,
            };
        }

        public static List<User> GetAllUsers()
        {
            return new List<User>
            {
                User1,
                User2,
                User3,
                User4,
                User5,
            };
        }

        public static void PopulateArtists()
        {
            Monuments.AddAlbum(TheAmanuensis);
            Monuments.AddAlbum(InStasis);
        }

        public static void PopulateAlbums()
        {
            TheAmanuensis.AddSong(new Song("I, The Creator", 233, "Metalcore", Monuments));
            TheAmanuensis.AddSong(new Song("Origin of Escape", 242, "Metalcore", Monuments));
            TheAmanuensis.AddSong(new Song("Atlas", 201, "Metalcore", Monuments));
            TheAmanuensis.AddSong(new Song("Horcrux", 286, "Metalcore", Monuments));
            TheAmanuensis.AddSong(new Song("Garden of Sankhara", 288, "Metalcore", Monuments));
            TheAmanuensis.AddSong(new Song("The Alchemist", 274, "Metalcore", Monuments));
            TheAmanuensis.AddSong(new Song("Quasimodo", 302, "Metalcore", Monuments));
            TheAmanuensis.AddSong(new Song("Saga City", 284, "Metalcore", Monuments));
            TheAmanuensis.AddSong(new Song("Jinn", 247, "Metalcore", Monuments));
            TheAmanuensis.AddSong(new Song("I, The Destroyer", 345, "Metalcore", Monuments));
            TheAmanuensis.AddSong(new Song("Samsara", 310, "Metalcore", Monuments));

            InStasis.AddSong(new Song("No One Will Teach You", 299, "Metalcore", Monuments));
            InStasis.AddSong(new Song("Lavos", 250, "Metalcore", Monuments));
            // Ik moet nog meer nummers toevoegen
        }

        public static void PopulateUsers()
        {
            MainUser.AddPlaylist(new Playlist("Metal goodness", MainUser));
            MainUser.Playlists[0].AddSongsFromAlbum(TheAmanuensis);
            MainUser.Playlists[0].AddSongsFromAlbum(InStasis);
            MainUser.AddLikedSong(TheAmanuensis.Songs[0]);
            MainUser.AddLikedSong(TheAmanuensis.Songs[3]);
            MainUser.AddLikedSong(TheAmanuensis.Songs[5]);
            MainUser.AddLikedSong(InStasis.Songs[1]);
            MainUser.AddFriend(User1);
            MainUser.AddFriend(User2);
            MainUser.AddFriend(User5);

            User1.AddPlaylist(new Playlist("Good Tunes", User1));
            User1.Playlists[0].AddSong(TheAmanuensis.Songs[1]);
            User1.Playlists[0].AddSong(InStasis.Songs[1]);
            User1.LikedSongs.AddSong(TheAmanuensis.Songs[4]);
            User1.Friends.Add(User2);

            User2.AddPlaylist(new Playlist("Da playlist", User2));
            User2.Playlists[0].AddSong(TheAmanuensis.Songs[3]);
            User2.Playlists[0].AddSong(InStasis.Songs[1]);
            User2.LikedSongs.AddSong(TheAmanuensis.Songs[6]);
            User2.Friends.Add(User5);

            User3.AddPlaylist(new Playlist("Wowie", User1));
            User3.Playlists[0].AddSong(TheAmanuensis.Songs[0]);
            User3.Playlists[0].AddSong(InStasis.Songs[0]);
            User3.LikedSongs.AddSong(TheAmanuensis.Songs[2]);

            User4.AddPlaylist(new Playlist("Playlist name", User1));
            User4.Playlists[0].AddSong(TheAmanuensis.Songs[5]);
            User4.Playlists[0].AddSong(InStasis.Songs[1]);
            User4.LikedSongs.AddSong(TheAmanuensis.Songs[4]);

            User5.AddPlaylist(new Playlist("I am out of ideas", User1));
            User5.Playlists[0].AddSong(TheAmanuensis.Songs[9]);
            User5.Playlists[0].AddSong(InStasis.Songs[0]);
            User5.LikedSongs.AddSong(TheAmanuensis.Songs[3]);
        }

        public static void PopulateAllData()
        {
            PopulateArtists();
            PopulateAlbums();
            PopulateUsers();
        }
    }
}

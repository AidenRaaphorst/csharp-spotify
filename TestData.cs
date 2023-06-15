namespace Spotify
{
    internal static class TestData
    {
        public static Artist Monuments = new Artist("Monuments");

        public static Album TheAmanuensis = new Album("The Amanuensis");
        public static Album InStasis = new Album("In Stasis");

        public static User friend1 = new User("Friend 1");

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

        public static void PopulateAllData()
        {
            PopulateAlbums();
            PopulateArtists();
        }

        public static void PopulateArtists()
        {
            Monuments.AddAlbum(TheAmanuensis);
            Monuments.AddAlbum(InStasis);
        }

        public static void PopulateAlbums()
        {
            TheAmanuensis.AddSong(new Song("I, The Creator", 233, "Metalcore", null));
            TheAmanuensis.AddSong(new Song("Origin of Escape", 242, "Metalcore", null));
            TheAmanuensis.AddSong(new Song("Atlas", 201, "Metalcore", null));
            TheAmanuensis.AddSong(new Song("Horcrux", 286, "Metalcore", null));
            TheAmanuensis.AddSong(new Song("Garden of Sankhara", 288, "Metalcore", null));
            TheAmanuensis.AddSong(new Song("The Alchemist", 274, "Metalcore", null));
            TheAmanuensis.AddSong(new Song("Quasimodo", 302, "Metalcore", null));
            TheAmanuensis.AddSong(new Song("Saga City", 284, "Metalcore", null));
            TheAmanuensis.AddSong(new Song("Jinn", 247, "Metalcore", null));
            TheAmanuensis.AddSong(new Song("I, The Destroyer", 345, "Metalcore", null));
            TheAmanuensis.AddSong(new Song("Samsara", 310, "Metalcore", null));

            InStasis.AddSong(new Song("No One Will Teach You", 299, "Metalcore", null));
            InStasis.AddSong(new Song("Lavos", 250, "Metalcore", null));
            // Ik moet nog meer nummers toevoegen
        }

        public static void PopulateFriends()
        {
            
        }
    }
}

namespace Spotify
{
    internal static class TestData
    {
        public static Artist Monuments()
        {
            Artist Monuments = new Artist("Monuments", null);

            Album TheAmanuensis = new Album("The Amanuensis", Monuments);
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

            Monuments.AddAlbum(TheAmanuensis);

            return Monuments;
        }
    }
}

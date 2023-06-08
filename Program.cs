namespace Spotify
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestData.PopulateAllData();
            List<Artist> Artists = TestData.GetAllArtists();
            List<Album> Albums = TestData.GetAllAlbums();
            User user = new User("Gebruiker");

            Clear();
            Console.WriteLine($"Welkom {user.Name}!");

            Console.WriteLine("\nHier zijn je playlists:");
            Console.WriteLine("1. Liked Songs");
            for(int i = 0; i < user.Playlists.Count; i++)
            {
                Console.WriteLine($"{i + 2}. {user.Playlists[i].Name}");
            }

            Console.WriteLine("\nHier zijn wat artiesten:");
            for (int i = 0; i < Artists.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Artists[i].Name}");
            }

            Console.Write("\nTyp 'a' voor artiesten, 'p' voor playlists, 'f' voor vrienden: ");
            ConsoleKey choice1 = WaitForKey(ConsoleKey.A, ConsoleKey.P, ConsoleKey.F);

            if(choice1 == ConsoleKey.A)
            {
                // Go to artists
            }
            else if(choice1 == ConsoleKey.P)
            {
                // Go to playlists
            } else
            {
                // Go to friends
            }
        }

        static void Clear(bool title = true)
        {
            Console.Clear();

            if(title)
            {
                ShowTitle();
            }
        }

        static void ShowTitle()
        {
            Console.WriteLine("=============");
            Console.WriteLine("   Spotify   ");
            Console.WriteLine("=============\n");
        }

        void ShowUsers()
        {

        }

        static ConsoleKey WaitForKey(params ConsoleKey[] allowedKeys)
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
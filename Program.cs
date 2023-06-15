namespace Spotify
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Gebruiker");
            List<Artist> Artists = TestData.GetAllArtists();
            TestData.PopulateAllData();

            Clear();
            Console.WriteLine($"Welkom {user.Name}!");

            Console.WriteLine("\nHier zijn je playlists:");
            Console.WriteLine("1. Liked Songs");
            for(int i = 0; i < user.Playlists.Count; i++)
            {
                Console.WriteLine(user.Playlists[i].Name);
            }

            Console.WriteLine("\nHier zijn wat artiesten:");
            for (int i = 0; i < Artists.Count; i++)
            {
                Console.WriteLine(Artists[i].Name);
            }

            Console.WriteLine("\n1. Artiesten");
            Console.WriteLine("2. Playlists");
            Console.WriteLine("3. Vrienden");
            Console.Write("Maak een keuze: ");
            ConsoleKey choice1 = WaitForKey(ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3);

            if(choice1 == ConsoleKey.D1)
            {
                // Go to artists
                Console.WriteLine("artists");
            }
            else if(choice1 == ConsoleKey.D2)
            {
                Console.WriteLine("playlists");
                // Go to playlists
            } else
            {
                Console.WriteLine("friends");
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
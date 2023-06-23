namespace Spotify
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            bool stop = false;
            while (!stop)
            {
                client.Clear();
                Console.WriteLine("Wat wil je doen?\n");

                Console.WriteLine("1. Artiesten bekijken");
                Console.WriteLine("2. Playlists bekijken");
                Console.WriteLine("3. Vriendenlijst bekijken");
                Console.WriteLine("4. Gebruikers bekijken");
                Console.WriteLine("0. Stoppen");
                Console.Write("\nMaak een keuze: ");
                string choice1 = Console.ReadLine();

                switch (choice1)
                {
                    case "1":
                        client.ArtistsMenu();
                        break;

                    case "2":
                        client.UserPlaylistsMenu();
                        break;

                    case "3":
                        client.FriendsMenu();
                        break;

                    case "4":
                        client.UsersMenu();
                        break;

                    case "0":
                        stop = true;
                        break;
                }
            }
        }
    }
}
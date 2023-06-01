namespace Spotify
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine( Song.ReadSongsFromJson("./songs.json"));

            Clear();
            Console.WriteLine("Welcome to Spotify, select your account or create one");
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
    }
}
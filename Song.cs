using Microsoft.VisualBasic;
using System.Text.Json;

namespace Spotify
{
    internal class Song
    {
        public string Title { get; private set; }
        public List<Artist> Artists { get; private set; }
        public string Genre { get; private set; }
        public readonly int LengthInSeconds;
        public string? Lyrics { get; private set; }
        public long ReleaseDate { get; private set; }
        public long Plays { get; private set; }

        public Song(string title, int lengthInSeconds, string genre, string? lyrics, long plays = 0)
        {
            this.Title = title;
            this.LengthInSeconds = lengthInSeconds;
            this.Artists = new List<Artist>();
            this.Genre = genre;
            this.Lyrics = lyrics;
            this.ReleaseDate = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            this.Plays = plays;
        }

        public void AddArtist(Artist artist)
        {
            this.Artists.Add(artist);
        }

        public void RemoveArtist(Artist artist)
        {
            this.Artists.Remove(artist);
        }

        public void Play()
        {

        }

        public void Pause()
        {

        }

        public void Stop()
        {

        }
    }
}

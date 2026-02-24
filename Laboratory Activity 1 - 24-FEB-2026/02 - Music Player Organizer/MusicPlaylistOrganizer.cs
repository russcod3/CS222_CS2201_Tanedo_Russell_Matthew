using System;

class Song
{
    private string title;
    private string artist;
    private double duration;

    // Default constructor
    public Song() : this("Unknown", "Unknown", 0.0)
    {
    }

    // Constructor with title and artist only
    public Song(string title, string artist) : this(title, artist, 0.0)
    {
    }

    // Full parameterized constructor
    public Song(string title, string artist, double duration)
    {
        this.title = string.IsNullOrWhiteSpace(title) ? "Unknown" : title;
        this.artist = string.IsNullOrWhiteSpace(artist) ? "Unknown" : artist;
        this.duration = duration;
    }

    public double GetDuration()
    {
        return duration;
    }

    public void DisplaySong()
    {
        Console.WriteLine("{0,-20} {1,-17} {2,6:F2}", title, artist, duration);
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Songs to add: ");
        int count;
while (!int.TryParse(Console.ReadLine(), out count) || count < 0)
{
    Console.Write("Invalid input. Enter a valid number: ");
}

        Song[] playlist = new Song[count];

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"\nSong #{i + 1}");

            Console.Write("Title: ");
            string title = Console.ReadLine();

            Console.Write("Artist: ");
            string artist = Console.ReadLine();

            Console.Write("Duration (minutes): ");
            string input = Console.ReadLine();

            double duration;
            bool isValid = double.TryParse(input, out duration);

            if (string.IsNullOrWhiteSpace(title) &&
                string.IsNullOrWhiteSpace(artist) &&
                !isValid)
            {
                playlist[i] = new Song();
            }
            else if (!isValid)
            {
                playlist[i] = new Song(title, artist);
            }
            else
            {
                playlist[i] = new Song(title, artist, duration);
            }
        }

        Console.WriteLine("\n=== || MY PLAYLIST || ===");
        Console.WriteLine("Title                Artist            Time");
        Console.WriteLine("----------------------------------------------");

        double total = 0;

        for (int i = 0; i < playlist.Length; i++)
        {
            playlist[i].DisplaySong();
            total += playlist[i].GetDuration();
        }

        double average = count > 0 ? total / count : 0;

        Console.WriteLine();
        Console.WriteLine($"Total Duration: {total:F2} mins");
        Console.WriteLine($"Average Duration: {average:F2} mins");
    }
}
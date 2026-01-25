using System;
using System.Collections.Generic;

class Program
{
    // Exceeds requirements by letting the user pick (or randomize) from a small
    // scripture library and by surfacing a live progress counter after each round.
    static void Main(string[] args)
    {
        List<Scripture> library = BuildLibrary();
        Scripture scripture = SelectScripture(library);

        RunMemorizer(scripture);
    }

    private static List<Scripture> BuildLibrary()
    {
        return new List<Scripture>
        {
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
                "In all thy ways acknowledge him, and he shall direct thy paths."),
            new Scripture(
                new Reference("John", 14, 27),
                "Peace I leave with you, my peace I give unto you: not as the world giveth, give I unto you. " +
                "Let not your heart be troubled, neither let it be afraid."),
            new Scripture(
                new Reference("2 Timothy", 1, 7),
                "For God hath not given us the spirit of fear; but of power, and of love, and of a sound mind."),
            new Scripture(
                new Reference("Mosiah", 2, 17),
                "When ye are in the service of your fellow beings ye are only in the service of your God."),
            new Scripture(
                new Reference("Alma", 37, 37),
                "Counsel with the Lord in all thy doings, and he will direct thee for good; yea, when thou " +
                "liest down at night lie down unto the Lord, that he may watch over you in your sleep; and when " +
                "thou risest in the morning let thy heart be full of thanks unto God; and if ye do these things " +
                "ye shall be lifted up at the last day.")
        };
    }

    private static Scripture SelectScripture(List<Scripture> library)
    {
        Console.Clear();
        Console.WriteLine("Scripture Memorizer\n");
        Console.WriteLine("Choose a passage to practice (press Enter for a surprise):\n");

        for (int i = 0; i < library.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {library[i].GetReferenceText()}");
        }

        Console.Write("\nSelection: ");
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            return PickRandom(library);
        }

        if (int.TryParse(input, out int selection) && selection >= 1 && selection <= library.Count)
        {
            return library[selection - 1];
        }

        Console.WriteLine("We'll go with a random scripture to keep things interesting.");
        System.Threading.Thread.Sleep(1200);
        return PickRandom(library);
    }

    private static Scripture PickRandom(List<Scripture> library)
    {
        Random random = new Random();
        int index = random.Next(library.Count);
        return library[index];
    }

    private static void RunMemorizer(Scripture scripture)
    {
        const int wordsPerRound = 3;
        bool keepGoing = true;

        while (keepGoing)
        {
            Console.Clear();
            Console.WriteLine("Scripture Memorizer\n");
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine(scripture.GetProgressLine());

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nAll words are hidden—amazing recall! Press Enter to finish or type 'quit'.");
            }
            else
            {
                Console.WriteLine("\nPress Enter to hide more words or type 'quit' to end the session.");
            }

            string? input = Console.ReadLine();

            if (input != null && input.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                keepGoing = false;
                continue;
            }

            if (scripture.IsCompletelyHidden())
            {
                keepGoing = false;
                continue;
            }

            scripture.HideRandomWords(wordsPerRound);
        }
    }
}
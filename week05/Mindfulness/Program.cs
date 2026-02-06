using System;
using System.Collections.Generic;

class Program
{
    // Exceeds requirements by tracking how many times each activity is completed
    // and by cycling through prompts/questions without repeating until reshuffled.
    static void Main(string[] args)
    {
        Dictionary<string, int> activityCounts = new Dictionary<string, int>();
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflection activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");

            string? choice = Console.ReadLine();

            Activity? activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectionActivity(),
                "3" => new ListingActivity(),
                "4" => null,
                _ => null
            };

            if (choice == "4")
            {
                running = false;
                continue;
            }

            if (activity == null)
            {
                Console.WriteLine("\nPlease choose a valid option.");
                Console.Write("Press Enter to continue...");
                Console.ReadLine();
                continue;
            }

            activity.Run();
            string name = activity.GetName();
            if (!activityCounts.ContainsKey(name))
            {
                activityCounts[name] = 0;
            }

            activityCounts[name]++;
            Console.WriteLine();
            Console.WriteLine("Session Summary:");

            foreach (KeyValuePair<string, int> entry in activityCounts)
            {
                Console.WriteLine($"- {entry.Key}: {entry.Value}");
            }

            Console.Write("\nPress Enter to return to the menu...");
            Console.ReadLine();
        }
    }
}
using System;

class Program
{
    // Exceeds requirements by adding a simple level system that celebrates milestones
    // every 1000 points and shows a title next to the score.
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Eternal Quest\n");
            Console.WriteLine($"You have {manager.GetScore()} points. Level {manager.GetLevel()} - {manager.GetLevelTitle()}\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine() ?? string.Empty;
            Console.WriteLine();

            if (choice == "1")
            {
                CreateGoal(manager);
            }
            else if (choice == "2")
            {
                Console.WriteLine("The goals are:");
                string display = manager.GetGoalsDisplay();
                Console.WriteLine(string.IsNullOrWhiteSpace(display) ? "(No goals yet)" : display);
                Pause();
            }
            else if (choice == "3")
            {
                Console.Write("Enter the filename to save: ");
                string filename = Console.ReadLine() ?? string.Empty;
                if (filename.Length > 0)
                {
                    manager.SaveToFile(filename);
                }
                Pause();
            }
            else if (choice == "4")
            {
                Console.Write("Enter the filename to load: ");
                string filename = Console.ReadLine() ?? string.Empty;
                if (filename.Length > 0)
                {
                    manager.LoadFromFile(filename);
                }
                Pause();
            }
            else if (choice == "5")
            {
                RecordGoalEvent(manager);
            }
            else if (choice == "6")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Please enter a valid option.");
                Pause();
            }
        }
    }

    private static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string typeChoice = Console.ReadLine() ?? string.Empty;
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine() ?? string.Empty;
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine() ?? string.Empty;
        int points = ReadInt("What is the amount of points associated with this goal? ");

        if (typeChoice == "1")
        {
            manager.AddGoal(new SimpleGoal(name, description, points, false));
        }
        else if (typeChoice == "2")
        {
            manager.AddGoal(new EternalGoal(name, description, points));
        }
        else if (typeChoice == "3")
        {
            int target = ReadInt("How many times does this goal need to be accomplished for a bonus? ");
            int bonus = ReadInt("What is the bonus for accomplishing it that many times? ");
            manager.AddGoal(new ChecklistGoal(name, description, points, bonus, target, 0));
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
        }

        Pause();
    }

    private static void RecordGoalEvent(GoalManager manager)
    {
        Console.WriteLine("Which goal did you accomplish?");
        string display = manager.GetGoalsDisplay();
        Console.WriteLine(string.IsNullOrWhiteSpace(display) ? "(No goals yet)" : display);

        int index = ReadInt("Enter the number of the goal: ") - 1;
        int beforeLevel = manager.GetLevel();
        manager.RecordEvent(index, out int pointsEarned);

        if (pointsEarned > 0)
        {
            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
        }
        else
        {
            Console.WriteLine("That goal is already complete. No points awarded.");
        }

        int afterLevel = manager.GetLevel();
        if (afterLevel > beforeLevel)
        {
            Console.WriteLine($"\nLevel up! You are now Level {afterLevel} - {manager.GetLevelTitle()}!");
        }

        Pause();
    }

    private static int ReadInt(string prompt)
    {
        Console.Write(prompt);
        string input = Console.ReadLine() ?? string.Empty;
        int value;

        while (!int.TryParse(input, out value) || value < 0)
        {
            Console.Write("Please enter a valid number: ");
            input = Console.ReadLine() ?? string.Empty;
        }

        return value;
    }

    private static void Pause()
    {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}
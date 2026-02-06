using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private readonly List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private int _promptIndex;

    public ListingActivity()
        : base(
            "Listing",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        Shuffle(_prompts);
    }

    protected override void PerformActivity()
    {
        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {GetNextPrompt()} ---");
        Console.WriteLine();
        Console.Write("You may begin in... ");
        ShowCountdown(5);
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        int count = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string? response = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(response))
            {
                count++;
            }
        }

        Console.WriteLine($"\nYou listed {count} items.");
    }

    private string GetNextPrompt()
    {
        if (_promptIndex >= _prompts.Count)
        {
            Shuffle(_prompts);
            _promptIndex = 0;
        }

        string prompt = _prompts[_promptIndex];
        _promptIndex++;
        return prompt;
    }
}

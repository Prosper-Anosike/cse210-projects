using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private readonly List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private readonly List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private int _promptIndex;
    private int _questionIndex;

    public ReflectionActivity()
        : base(
            "Reflection",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        Shuffle(_prompts);
        Shuffle(_questions);
    }

    protected override void PerformActivity()
    {
        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"--- {GetNextPrompt()} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions:");
        Console.WriteLine("You may begin in... ");
        ShowCountdown(5);
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write($"> {GetNextQuestion()} ");
            ShowSpinner(5);
            Console.WriteLine();
        }
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

    private string GetNextQuestion()
    {
        if (_questionIndex >= _questions.Count)
        {
            Shuffle(_questions);
            _questionIndex = 0;
        }

        string question = _questions[_questionIndex];
        _questionIndex++;
        return question;
    }
}

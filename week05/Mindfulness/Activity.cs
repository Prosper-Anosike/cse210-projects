using System;
using System.Collections.Generic;
using System.Threading;

public abstract class Activity
{
    private static readonly Random _random = new Random();
    private string _name;
    private string _description;
    private int _durationSeconds;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public string GetName()
    {
        return _name;
    }

    public void Run()
    {
        DisplayStartMessage();
        PerformActivity();
        DisplayEndMessage();
    }

    protected abstract void PerformActivity();

    protected int GetDuration()
    {
        return _durationSeconds;
    }

    protected void DisplayStartMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.\n");
        Console.WriteLine(_description);
        Console.Write("\nHow long, in seconds, would you like for your session? ");

        string? input = Console.ReadLine();
        while (!int.TryParse(input, out _durationSeconds) || _durationSeconds <= 0)
        {
            Console.Write("Please enter a positive number of seconds: ");
            input = Console.ReadLine();
        }

        Console.WriteLine("\nGet ready...");
        ShowSpinner(3);
    }

    protected void DisplayEndMessage()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner(2);
        Console.WriteLine($"\nYou have completed the {_name} Activity for {_durationSeconds} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] frames = new string[] { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int index = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(frames[index]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            index = (index + 1) % frames.Length;
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    protected static void Shuffle<T>(List<T> items)
    {
        for (int i = items.Count - 1; i > 0; i--)
        {
            int swapIndex = _random.Next(i + 1);
            T temp = items[i];
            items[i] = items[swapIndex];
            items[swapIndex] = temp;
        }
    }
}

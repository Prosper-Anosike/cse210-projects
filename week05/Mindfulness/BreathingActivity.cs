using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void PerformActivity()
    {
        Console.WriteLine();
        int remaining = GetDuration();

        while (remaining > 0)
        {
            int inhale = Math.Min(4, remaining);
            Console.Write("Breathe in... ");
            ShowCountdown(inhale);
            Console.WriteLine();
            remaining -= inhale;

            if (remaining <= 0)
            {
                break;
            }

            int exhale = Math.Min(6, remaining);
            Console.Write("Breathe out... ");
            ShowCountdown(exhale);
            Console.WriteLine();
            remaining -= exhale;
        }
    }
}

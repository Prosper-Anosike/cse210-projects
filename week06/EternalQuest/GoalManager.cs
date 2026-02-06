using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public int GetScore()
    {
        return _score;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int index, out int pointsEarned)
    {
        pointsEarned = 0;
        if (index < 0 || index >= _goals.Count)
        {
            return;
        }

        pointsEarned = _goals[index].RecordEvent();
        _score += pointsEarned;
    }

    public string GetGoalsDisplay()
    {
        List<string> lines = new List<string>();
        for (int i = 0; i < _goals.Count; i++)
        {
            lines.Add($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        return string.Join("\n", lines);
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter output = new StreamWriter(filename))
        {
            output.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                output.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _goals.Clear();

        string[] lines = File.ReadAllLines(filename);
        if (lines.Length == 0)
        {
            _score = 0;
            return;
        }

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            Goal goal = ParseGoal(lines[i]);
            if (goal != null)
            {
                _goals.Add(goal);
            }
        }
    }

    public int GetLevel()
    {
        return (_score / 1000) + 1;
    }

    public string GetLevelTitle()
    {
        int level = GetLevel();
        if (level <= 1)
        {
            return "Novice";
        }
        if (level == 2)
        {
            return "Steady Seeker";
        }
        if (level == 3)
        {
            return "Focused Finisher";
        }
        if (level == 4)
        {
            return "Goal Guardian";
        }

        return "Quest Champion";
    }

    private Goal ParseGoal(string line)
    {
        string[] parts = line.Split('|');
        if (parts.Length == 0)
        {
            return null;
        }

        string type = parts[0];
        if (type == "SimpleGoal" && parts.Length >= 5)
        {
            return new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
        }

        if (type == "EternalGoal" && parts.Length >= 4)
        {
            return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
        }

        if (type == "ChecklistGoal" && parts.Length >= 7)
        {
            return new ChecklistGoal(
                parts[1],
                parts[2],
                int.Parse(parts[3]),
                int.Parse(parts[4]),
                int.Parse(parts[5]),
                int.Parse(parts[6]));
        }

        return null;
    }
}

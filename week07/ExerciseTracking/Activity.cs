using System;

public abstract class Activity
{
    private string _date;
    private int _minutes;

    protected Activity(string date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public string GetDate()
    {
        return _date;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();

    public virtual string GetSummary()
    {
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();
        return $"{_date} {GetType().Name} ({_minutes} min): Distance {distance:0.0} miles, Speed {speed:0.0} mph, Pace: {pace:0.0} min per mile";
    }
}

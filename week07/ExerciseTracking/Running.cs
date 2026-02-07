using System;

public class Running : Activity
{
    private double _distanceMiles;

    public Running(string date, int minutes, double distanceMiles)
        : base(date, minutes)
    {
        _distanceMiles = distanceMiles;
    }

    public override double GetDistance()
    {
        return _distanceMiles;
    }

    public override double GetSpeed()
    {
        return (_distanceMiles / GetMinutes()) * 60.0;
    }

    public override double GetPace()
    {
        return GetMinutes() / _distanceMiles;
    }
}

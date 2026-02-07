using System;

public class Cycling : Activity
{
    private double _speedMph;

    public Cycling(string date, int minutes, double speedMph)
        : base(date, minutes)
    {
        _speedMph = speedMph;
    }

    public override double GetDistance()
    {
        return (_speedMph * GetMinutes()) / 60.0;
    }

    public override double GetSpeed()
    {
        return _speedMph;
    }

    public override double GetPace()
    {
        return 60.0 / _speedMph;
    }
}

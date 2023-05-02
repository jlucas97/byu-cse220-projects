using System;

class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int pTop)
    {
        _top = pTop;
        _bottom = 1;
    }

    public Fraction(int pTop, int pBottom)
    {
        _top = pTop;
        _bottom = pBottom;
    }

    public int Top
    {
        get { return _top; }
        set { _top = value; }
    }

    public int Bottom
    {
        get { return _bottom; }
        set { _bottom = value; }
    }

    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;
    }
}

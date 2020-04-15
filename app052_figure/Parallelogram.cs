using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 class Parallelogram : Rectangle
{
    private double _a = 1.0;
    private double _b = 1.0;
    private double _h = 1.0;
    private double _angle = 1.0;
    public Parallelogram(double a, double b, double sideA, double sideB, double angle) : base(a, b)
    {
        A = sideA;
        B = sideB;
        Angle = angle;
        _h = _a * Math.Asin(_angle);
    }

    public double Angle
    {
        get { return _a; }
        set
        {
            if (value <= 0) { throw new Exception("Величина стороны A должна быть положительным числом и больше 0"); }
            _angle = value;
        }
    }
    public double A
    {
        get { return _a; }
        set
        {
            if (value <= 0) { throw new Exception("Величина стороны A должна быть положительным числом и больше 0"); }
            _a = value;
        }
    }
    public double B
    {
        get { return _b; }
        set
        {
            if (value <= 0) { throw new Exception("Величина стороны B должна быть положительным числом и больше 0"); }
            _b = value;
        }
    }
    public override double Area { get { return _a * _h; } }

    public override double Perimetr { get { return (_a + _b) * 2; } }

}


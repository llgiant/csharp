using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Ellipse : Figure
{
    private double _a = 1;
    private double _b = 1;

    public Ellipse(double a, double b)
    {
        A = a;
        B = b;
    }

    public override double Area { get { return Math.PI * _a * _b; } }
    public override double Perimetr { get { return 4 * ((Math.PI * _a * _b + (_a - _b)) / (_a + _b)); } }
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
}


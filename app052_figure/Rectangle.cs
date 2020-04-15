using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Rectangle : Quadrangle
{
    private double _a = 1.0;
    private double _b = 1.0;
    public Rectangle(double a, double b)
    {
        A = a;
        B = b;
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
    public override double Area { get { return A * B; } }

    public override double Perimetr { get { return (A + B) * 2; } }


}


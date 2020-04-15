using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

sealed class Circle : Ellipse
{
    private double _r = 1;

    public Circle(double a, double b, double radius) : base(a, b) { Radius = radius; }
    public double Radius
    {
        get { return _r; }
        set
        {
            if (value <= 0) { throw new Exception("Радиус должн быть положительным числом и больше 0"); }
            _r = value;
        }
    }

    public override double Area { get { return Math.PI * _r * _r; } }
    public override double Perimetr { get { return 2 * Math.PI * _r; } }

}

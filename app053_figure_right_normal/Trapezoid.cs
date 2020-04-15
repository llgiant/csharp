using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Trapezoid : Quadrangle
{
    private double _a = 1;
    private double _b = 1;
    private double _c = 1;
    private double _d = 1;
    private string _name = "Трапеция";
    private double _h = 1;

    public Trapezoid(double[] sides) : base(sides)
    {
        _a = sides[0];
        _b = sides[1];
        _c = sides[2];
        _d = sides[3];
        _h = Math.Sqrt(_c * _c - ((_a - _b) * (_a - _b) + _c * _c - _d * _d) / 2 * (_a - _b));
    }

    public override double Area { get { return (_a + _b) * _h / 2; } }

}


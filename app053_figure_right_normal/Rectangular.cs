using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Rectangular : Quadrangle
{
    private double _a = 1;
    private double _b = 1;
    public Rectangular(double [] sides) : base(sides) 
    {
        _a = sides[0];
        _b = sides[1];
    }

    public override double Area { get { return _a * _b; } }
}

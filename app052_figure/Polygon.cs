using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class Polygon : Figure
{
    private double[] _sides = new double[] { };
    protected Polygon(double[] sides)
    {
        if (sides == null) { throw new ArgumentNullException("sides"); }
        if (sides.Length < 3) { throw new ArgumentException("Число сторон не может быть меньше трех."); }
        _sides = sides;
    }

    protected double[] Sides { get { return _sides; } }

    public override double Perimetr
    {
        get
        {
            double p = 0;
            foreach (double side in _sides) { p += side; }
            return p;
        }
    }
}
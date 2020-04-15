using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class Polygon : Figure
{
    private double[] _sides = new double[] { };
    protected Polygon(double [] sides)
    {
        //проверочки
        if (sides == null ) { throw new ArgumentNullException("Cторона должна быть больше ноля"); }
        if (sides.Length < 3) { throw new ArgumentNullException("Cторон должнО быть три"); }

        foreach(double side in sides)
        {
            if (side <= 0) { throw new ArgumentNullException("Cторона должна быть больше ноля."); }
        }
        _sides = sides;
    }

    protected Polygon(double side, int countSides)
    {
        //проверочки
        if (countSides < 3) { throw new ArgumentException("Число сторон не может быть меньше трех."); }
        if (side <= 0) { throw new ArgumentException("Cторона должна быть больше ноля."); }
        _sides = new double[countSides];
        for (int i = 0; i < countSides; i++)
        {
            _sides[i] = side;
        }
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
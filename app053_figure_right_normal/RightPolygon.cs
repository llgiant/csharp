using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RightPolygon : Polygon
{
    private double _a = 1;
    private double _h = 1;
    private string _name = "Пятиугольник";
    private double _sideCount = 1;

    public RightPolygon(double side, int sideCount) : base(side, sideCount)
    {
        if (side <= 0) { throw new ArgumentException("Cторона должна быть больше ноля."); }
        if (sideCount < 3) { throw new ArgumentException("Не может быть меньше 3х сторон"); }
        _a = side;
        _h = (Math.Sqrt(3) / 2) * _a;
        _sideCount = sideCount;
    }
    public override double Area { get { return (_a * _h / 2) * _sideCount; } }
}



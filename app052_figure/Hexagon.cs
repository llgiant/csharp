using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

sealed class Hexagon : Polygon
{
    private double _a = 1;
    private double _h = 1;
    private double _b = 1;
    private double _s = 1;
    private string _name = "Шестиугольник";

    public Hexagon(double side)
    {
        if (side <= 0) { throw new Exception("Величина стороны должна быть положительным числом"); }
        _a = side;
        //расчет высоты равностороннего треугольника
        _h = Math.Sqrt(_a * _a - _a * _a / 2);
        //площадь равностороннего треугольника
        _s = _h * _a / 2;
    }

    override public double Area { get { return _s * 5; } }
    override public double Perimetr { get { return _a * 5; } }

}

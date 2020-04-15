using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

sealed class Pentagon : Polygon
{
    private double _a = 1;
    private double _h = 1;
    private double _s = 1;
    private string _name = "Пятиугольник";

    public Pentagon(double  side)
    {
        if (side <= 0) { throw new Exception("Величина стороны A должна быть положительным числом и больше 0"); }
        _a = side;
        //расчет высоты равностороннего треугольника
        _h = Math.Sqrt(_a * _a - _a * _a / 2);
        //площадь равностороннего треугольника
        _s = _h * _a / 2;
    }

    override public double Area { get { return _s * 6; } }
    override public double Perimetr { get { return _a * 6; } }
}




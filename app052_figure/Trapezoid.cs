using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


sealed class Trapezoid : Quadrangle
{
    //a - нижнее основание
    //b - верхнее основание
    //c , d - боковые стороны
    //h - высота трапеции
    private double _a = 1;
    private double _b = 1;
    private double _c = 1;
    private double _d = 1;
    private string _name = "Трапеция";
    private double _h = 1;


    public Trapezoid(double a, double b, double c, double d, string name)
    {
        if (a <= 0 || b <= 0 || c <= 0 || d <= 0) { throw new Exception("Сторона трапеции должна быть положительной"); }
        _a = a;
        _b = b;
        _c = c;
        _d = d;
        Name = name;
        _h = Math.Sqrt(c * c - ((a - b) * (a - b) + c * c - d * d) / 2 * (a - b));
    }

    public override double Area { get { return (_a + _b) * _h / 2; } }

    public override double Perimetr { get { return _a + _b + _c + _d; } }

    public string Name
    {
        get { return _name; }
        set
        {
            if (string.IsNullOrEmpty(value)) { throw new Exception("Название окружности не может быть пустым"); }

            _name = value;
        }
    }
}

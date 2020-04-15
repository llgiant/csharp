using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Triangle : IFigura
{
    private double _a = 1;
    private double _b = 1;
    private double _c = 1;
    private double _h = 1;
    private string _name = "Треуголник";

    public Triangle(double A, double B, double C, string name)
    {

        if (A <= 0) { throw new Exception("Величина стороны A должна быть положительным числом"); }
        _a = A;
        if (_b <= 0) { throw new Exception("Величина стороны B должна быть положительным числом"); }
        _b = B;
        if (_c <= 0) { throw new Exception("Величина основания треугольника C должна быть положительным числом"); }
        _c = C;
        if (_h <= 0) { throw new Exception("Величина высоты h должна быть положительным числом"); }
        _h = 4;
        if (_a + _b <= _c ||
            _a + _c <= _b ||
            _b + _c <= _a) { throw new Exception("С заданными параметрами треуголник не может существовать"); }
            if (string.IsNullOrWhiteSpace(name)) { throw new Exception("Имя не может быть пустым"); }
        _name = name;

    }
    public double Square
    {
        get { return _c * _h * 0.5D; }
    }

    public double Perimetr
    {
        get { return _a + _b + _c; }
    }

    public string Name
    {
        get { return _name; }
        set { if (value != null) { _name = value; } }
    }
}


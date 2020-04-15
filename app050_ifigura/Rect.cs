using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Rect : IFigura
{
    private double _height = 1;
    private double _weight = 1;
    private string _name = "прямоугольник";

    public Rect(double height, double weight, string name)
    {
        if (height <= 0) { throw new Exception("Высота прямоугольника должна быть положительной"); }
        if (weight <= 0) { throw new Exception("Высота прямоугольника должна быть положительной"); }
        _height = height;
        _weight = weight;
        Name = name;
    }

    public double Square { get { return _height * _weight; } }

    public double Perimetr { get { return (_height + _weight) * 2; } }

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

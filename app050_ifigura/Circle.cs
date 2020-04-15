using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Circle : IFigura
{
    private double _radius = 1.0;
    private string _name = "Круг";

    public Circle(double radius, string name)
    {
        if (_radius <= 0) { throw new Exception("Величина радиуса должна быть положительноц"); }
        
        Name = name;
        _radius = radius;
    }

    public double Square { get { return _radius * _radius * 2 * Math.PI; } }

    public double Perimetr { get { return 2 * Math.PI * _radius; } }

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


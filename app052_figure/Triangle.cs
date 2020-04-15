using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

sealed class Triangle : Polygon
{
    public Triangle(double a, double b, double c) : base(new double[] { a, b, c }) { }
    public double sideA { get { return Sides[0]; } set { } }
    public double sideB { get { return Sides[1]; } set { } }
    public double sideC { get { return Sides[2]; } set { } }
    public override double Area { get { return 0; } }
}

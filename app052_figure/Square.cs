using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


sealed class Square : Rectangle
{
    public Square(double side) : base(side, side) { }

    public double Side
    {
        get { return A; }
        set { A = value; B = value; }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app053_figure_right_normal
{
    class Square : RightPolygon
    {
        private static double _a = 1;
        public Square(double a) : base(a, 4)
        {
            if (a <= 0) { throw new ArgumentException("Cторона должна быть больше ноля."); }
            _a = a;
        }
        public override double Area { get { return _a * _a; } }
    }
}

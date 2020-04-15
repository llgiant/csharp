using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Parallelogramm : Quadrangle
    {

    private double _a = 1.0;
    private double _b = 1.0;
    private double _h = 1.0;
    private double _angle = 1.0;
    public Parallelogramm(double [] sides, double angle) : base(sides)
    {      
        _a = sides[0];
        _b = sides[1];
        _angle = angle;
        _h = _a * Math.Asin(_angle);
    }
    
    public override double Area { get { return _a * _h; } }
}



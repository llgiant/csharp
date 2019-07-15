using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Point
{
	#region Переменные
	double _x;
	double _y;
	#endregion

	#region Конструктор
	public Point() { }
	public Point(double x, double y) { X = x; Y = y; }
	#endregion

	#region Свойства
	public double X { get { return _x; } set { _x = value; } }
	public double Y { get { return _y; } set { _y = value; } }
	#endregion
}


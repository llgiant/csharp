using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Size
{
	#region Переменные
	double _width = 1;
	double _height = 1;
	#endregion

	#region Конструктор
	public Size(double width, double height) { Width = width; Height = height; }
	#endregion

	#region Свойства
	public double Width
	{
		get { return _width; }
		set { if (_width > 0) { _width = value; } }
	}

	public double Height
	{
		get { return _height; }
		set { if (_height > 0) { _height = value; } }
	}
	#endregion
}


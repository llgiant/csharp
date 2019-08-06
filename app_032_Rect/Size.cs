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
	public Size() { }
	public Size(double width, double height) { Width = width; Height = height; }
	#endregion

	#region Свойства
	public double Width
	{
		get { return _width; }
		set
		{
			if (value <= 0) { throw new ArgumentException("Значение ширины не должно быть отрицательным числом."); }
			_width = value;
		}
	}

	public double Height
	{
		get { return _height; }
		set
		{
			if (value <= 0) { throw new ArgumentException("Значение высоты не должно быть отрицательным числом."); }
			_height = value;
		}
	}
	#endregion
}


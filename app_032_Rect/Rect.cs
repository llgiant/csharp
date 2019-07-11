using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Rect
{
	#region " Локальные переменные "
	double _width;
	double _height;
	bool _isSquare;
	double _diagonal;
	double _perimetr;
	double _square;
	int _xPos;
	int _yPos;

	#endregion

	#region " Конструкторы "

	#endregion

	#region " Свойства "
	public double Width
	{
		get { return _width; }
		set
		{
			if (_validation(value) != "") { return; }
			_width = value;
		}
	}
	public double Height
	{
		get { return _height; }
		set
		{
			if (_validation(value) != "") { return; }
			_height = value;
		}
	}
	public bool IsSquare
	{
		get { return _isSquare; }
		set
		{
			if (Width == Height) { _isSquare = true; }
			else { _isSquare = false; }
		}
	}

	public double Diagonal
	{
		get { return _diagonal; }
		set
		{

		}

	}
	public double Perimetr
	{
		get { return _perimetr; }
		set { }
	}
	#endregion
	public double Square
	{
		get { return _square; }
		set { }
	}
	public int Xpos
	{
		get { return _xPos; }
		set { }
	}
	public int Ypos
	{
		get { return _yPos; }
		set { }
	}


	#region " Функции "

	private static Rect _relocation(int x, int y)
	{

		return new Rect();
	}

	private static Rect _scale(int width, int height)
	{
		return new Rect();
	}

	private static string _validation(int val)
	{
		if (val <= 0) { return "Значение не может быть меньше либо равно нулю"; }
		return "";
	}
	#endregion




}


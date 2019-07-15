using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Rect
{
	#region " Локальные переменные "
	private Size _size;
	private Point _point;
	#endregion

	#region " Конструкторы "
	private Rect() : this(new Size(1, 1), new Point()) { }
	public Rect(double width, double height) : this(new Size(width, height), new Point()) { }
	public Rect(Size size) : this(size, new Point()) { }
	public Rect(double width, double height, Point point) : this(new Size(width, height), point) { }
	public Rect(double width, double height, double x, double y) : this(new Size(width, height), new Point(x, y)) { }

	public Rect(Size size, Point point)
	{
		Size = size;
		Point = point;
	}
	#endregion

	#region " Свойства "
	public double Width
	{
		get { return _size.Width; }
		set { _size.Width = value; }
	}

	public double Height
	{
		get { return _size.Height; }
		set { _size.Height = value; }
	}

	public Size Size
	{
		get { return _size; }
		set { if (value != null) { _size = value; } }
	}

	public bool IsSquare { get { return _size.Width == _size.Height; } }
	public double Diagonal { get { return Math.Sqrt(_size.Height * _size.Height + _size.Width * _size.Width); } }
	public double Perimetr { get { return (_size.Height + _size.Width) * 2; } }
	public double Square { get { return _size.Height * _size.Width; } }
	public double X { get { return _point.X; } set { _point.X = value; } }
	public double Y { get { return _point.Y; } set { _point.Y = value; } }
	public Point Point
	{
		get { return _point; }
		set { if (value != null) { _point = value; } }
	}


	#endregion

	#region " Функции "
	public Rect MoveX(double deltaX) { return Move(deltaX, 0); }
	public Rect MoveY(double deltaY) { return Move(0, deltaY); }
	public Rect Move(double deltaX, double deltaY) { return new Rect(_size.Width, _size.Height, _point.X + deltaX, _point.Y + deltaY); }
	public Rect Relocation(double x, double y) { return new Rect(Width, Height, x, y); }
	public Rect Scale(double factor)
	{
		Rect newRect = new Rect();
		Size newSize = new Size(_size.Width * factor, _size.Height * factor);
		newRect._size = newSize;
		newRect._point = new Point(_point.X + (newSize.Width - _size.Width) / 2, _point.Y + (newSize.Height - _size.Height) / 2);
		return newRect;
	}

	//public Rect Scale(double factor, double x, double y)
	//{
	//	Rect newRect = new Rect();
	//	newRect.Size.Width = Size.Width * factor;
	//	newRect.Size.Height = newRect.Size.Height * factor;
	//	newRect.Point.X = x + (newRect.Size.Width - Size.Width) / 2;
	//	newRect.Point.Y = y + (newRect.Size.Height - newRect.Size.Height) / 2;
	//	return newRect;
	//}
	#endregion
}


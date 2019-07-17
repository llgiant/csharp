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
	public Point Point
	{
		get { return _point; }
		set { if (value != null) { _point = value; } }
	}
	public bool IsSquare { get { return _size.Width == _size.Height; } }
	public double Diagonal { get { return Math.Sqrt(_size.Height * _size.Height + _size.Width * _size.Width); } }
	public double Perimetr { get { return (_size.Height + _size.Width) * 2; } }
	public double Square { get { return _size.Height * _size.Width; } }
	public double X { get { return _point.X; } set { _point.X = value; } }
	public double Y { get { return _point.Y; } set { _point.Y = value; } }
	public double Top { get { return _point.Y; } set { _point.Y = value; } }
	public double Left { get { return _point.X; } set { _point.X = value; } }
	public double Right
	{
		get { return _point.X + _size.Width; }
		set
		{
			double newW = value - _point.X;
			if (newW > 0) { _size.Width = newW; }
		}
	}
	public double Bottom
	{
		get { return _point.Y + _size.Height; }
		set
		{
			double newH = value - _point.Y;
			if (newH > 0) { _size.Height = newH; }
		}
	}
	#endregion

	#region " Функции "
	public Rect MoveX(double deltaX) { return Move(deltaX, 0); }
	public Rect MoveY(double deltaY) { return Move(0, deltaY); }
	public Rect Move(double deltaX, double deltaY) { return new Rect(_size.Width, _size.Height, _point.X + deltaX, _point.Y + deltaY); }
	public Rect Relocation(double x, double y) { return new Rect(Width, Height, x, y); }
	public Rect Relocation(Point point) { return new Rect(_point.X, _point.Y); }
	public Rect Scale(double factor)
	{
		Rect newRect = new Rect();
		Size newSize = new Size(_size.Width * factor, _size.Height * factor);
		newRect._size = newSize;
		newRect._point = new Point(_point.X + (newSize.Width - _size.Width) / 2, _point.Y + (newSize.Height - _size.Height) / 2);
		return newRect;
	}
	public Rect Scale(double factor, double x, double y)
	{
		Rect newRect = new Rect();
		newRect.Size.Width = Size.Width * factor;
		newRect.Size.Height = newRect.Size.Height * factor;
		newRect.Point.X = x + (newRect.Size.Width - Size.Width) / 2;
		newRect.Point.Y = y + (newRect.Size.Height - newRect.Size.Height) / 2;
		return newRect;
	}
	public bool ContainsPoint(double x, double y)
	{
		if ((x < Left && x > Right) && (y < Top  && y > Bottom)) { return false; }
		return true;
	}
	public bool ContainsPoint(Point point)
	{
		if ((point.X < Left && point.X > Right) && (point.Y < Top && point.Y > Bottom)) { return false; }
		return true;
	}
	public bool ContainsRect(Rect rect)
	{
		//проверка площади прямоугольника если меньше, то
		if(rect.Square > Square) { return false; }

		return true;
	}
	public Rect Union(Rect rect)
	{
		double comX = 1;                 // Общая координата Х
		double comY = 1;                // Общая координата Y
		double comHeight = 1;            // Общая высота
		double comWeight = 1;           // Общая длина
		double X1 = _point.X;           // координата Х - первого прямоугольника
		double Y1 = _point.Y;           // координата Y - первого прямоугольника
		double X2 = rect.X;              // координата Х - второго прямоугольника
		double Y2 = rect.Y;             // координата Y - второго прямоугольника
		double H1 = _size.Height;       // высота первого прямоугольника
		double W1 = _size.Width;        // длина первого прямоугольника
		double H2 = rect.Height;       // высота первого прямоугольника
		double W2 = rect.Width;        // длина первого прямоугольника

		if (X1 == X2 && Y1 == Y2) { return new Rect(_size.Width, _size.Height, X1, Y1); }

		else if (X1 > X2 && Y1 > Y2) { }
		else if (X1 > X2 && Y2 > Y1) { }
		else if (X1 > X2 && Y1 == Y2) { }
		else if (X1 < X2 && Y1 < Y2) { }
		else if (X1 > X2 && Y1 > Y2) { }
		else if (X1 < X2 && Y1 == Y2) { }


		return new Rect();
	}
	public bool IsIntersect(Rect rect)
	{
		bool isContains = false;
		return isContains;
	}
	public Rect IsIntersect(Rect rect)
	{

	}
	#endregion
}


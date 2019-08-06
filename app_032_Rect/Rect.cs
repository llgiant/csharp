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
		set
		{
			if (value == null) { throw new ArgumentNullException("value"); }
			_size = value;
		}
	}
	public Point Point
	{
		get { return _point; }
		set
		{
			if (value == null) { throw new ArgumentNullException("value"); }
			_point = value;
		}
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
	public Rect Relocation(Point point)
	{
		if (point == null) { throw new ArgumentNullException("point"); }
		return new Rect(_size, point);
	}
	public Rect Scale(double factor) { return Scale(factor, (Right - X) / 2, (Bottom - Y) / 2); }
	public Rect Scale(double factor, double x, double y)
	{
		if (factor <= 0) { throw new ArgumentException("Коэффициент масштабирования не может быть нулевым или отрицательным."); }
		Rect newRect = new Rect();
		newRect.Size.Width = Size.Width * factor;
		newRect.Size.Height = newRect.Size.Height * factor;
		newRect.Point.X = x + (newRect.Size.Width - Size.Width) / 2;
		newRect.Point.Y = y + (newRect.Size.Height - newRect.Size.Height) / 2;
		return newRect;
	}
	public bool ContainsPoint(double x, double y) { return ContainsPoint(new Point(x, y)); }

	public bool ContainsPoint(Point point)
	{
		if (point == null) { throw new ArgumentNullException("point"); }
		return point.X > Left && point.X < Right && point.Y > Top && point.Y < Bottom;
	}
	public bool ContainsRect(Rect rect)
	{
		if (rect == null) { throw new ArgumentNullException("rect"); }
		return rect.Left > Left && rect.Right < Right && rect.Top > Top && rect.Bottom < Bottom;
	}
	public Rect Union(Rect rect)
	{
		if (rect == null) { throw new ArgumentNullException("rect"); }
		double comLeft = rect.Left <= Left ? rect.Left : Left;
		double comRight = rect.Right >= Right ? rect.Right : Right;
		double comBottom = rect.Top <= Top ? rect.Top : Top;
		double comTop = rect.Bottom >= Bottom ? rect.Bottom : Bottom;

		return new Rect(comRight - comLeft, comBottom - comTop, comLeft, comTop);
	}
	public bool IsIntersect(Rect rect)
	{
		if (rect == null) { throw new ArgumentNullException("rect"); }
		return
			ContainsPoint(rect.X, rect.Y) ||
			ContainsPoint(rect.X + rect.Width, rect.Y) ||
			ContainsPoint(rect.X, rect.Y + rect.Height) ||
			ContainsPoint(rect.X + rect.Width, rect.Y + rect.Height);
	}

	public Rect Intersected(Rect rect)
	{
		if (rect == null) { throw new ArgumentNullException("rect"); }
		if (!IsIntersect(rect)) { return null; }
		double comLeft = rect.Left <= Left ? rect.Left : Left;
		double comRight = rect.Right >= Right ? rect.Right : Right;
		double comBottom = rect.Top <= Top ? rect.Top : Top;
		double comTop = rect.Bottom >= Bottom ? rect.Bottom : Bottom;
		return new Rect(comRight - comLeft, comBottom - comTop, comLeft, comTop);
	}
	#endregion
}


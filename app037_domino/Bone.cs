using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum Side
{
	none = 0,
	left = 1,
	right = 2
}
class Bone
{
	private int _left = 0;
	private int _right = 0;
	#region Конструкторская
	public Bone(int left, int right)
	{
		if (left < 0 || left > 6) { throw new Exception("Значение должно быть в диапазоне от 0 до 6"); } else { _left = left; }
		if (right < 0 || right > 6) { throw new Exception("Значение должно быть в диапазоне от 0 до 6"); } else { _right = right; }

	}
	#endregion

	#region Свойства
	public int Left { get { return _left; } }
	public int Right { get { return _right; } }
	public int Rank { get {return _left +_right; } }
	#endregion

	#region Функции
	public bool Contains(int number) { return _left == number || _right == number; }
	public string Draw() { return $"[{_left}|{_right}]"; }
	#endregion

	#region Методы
	public void Rotate()
	{
		int safeLeft = _left;
		_left = _right;
		_right = safeLeft;
	}
	#endregion
}


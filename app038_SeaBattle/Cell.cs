using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum CellType
{
	Water = 0,
	Ship = 1,
	Margin = 2,
	Dead = 3
}

class Cell
{
	#region Локальные переменные
	private ShipState _state = ShipState.Normal;
	private CellType _type = CellType.Water;
	private int _index;
	private bool _isDead;
	private char _row = ' ';
	private int _col = -1;
	private string _cellName;
	private List<String> fireCels = new List<string>();
	#endregion

	#region Конструкторы
	public Cell(char row, int col)
	{
		if (row < 97 || row > 106) { throw new ArgumentNullException("Буква строки должна быть в диапозоне a-j"); }
		if (col < 0 || col > 9) { throw new ArgumentNullException("Номер колонки должен быть в диапозоне от 0 до 9"); }
		_row = row; _col = col;
		_cellName = row + " " + col;
	}
	#endregion

	#region Свойства


	public string CellName { get { return _cellName; } }
	public bool IsDead
	{
		get { return _isDead; }
		set { _isDead = value; }
	}
	public CellType Type
	{
		get { return _type; }
		set { _type = value; }
	}
	public int Index { get { return _index; } }
	public char Row { get { return _row; } }
	public int Col { get { return _col; } }
	#endregion

	#region Функции
	#endregion
}


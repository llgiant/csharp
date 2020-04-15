using System;
using System.Collections.Generic;

enum ShipState
{
	Normal = 0,
	Wounded = 1,
	Dead = 2
}
enum ShipOrientation
{
	None = 0,
	Vertical = 1,
	Horizontal = 2
}

class Ship
{
	#region Локальные переменные
	private bool _isDead;
	private ShipState _state;
	private ShipOrientation _orientation;
	private List<Cell> _palubs = null;
	private List<Cell> _margin = null;
	private int _woundCount;
	#endregion

	#region " Конструкторы "
	public Ship(List<Cell> ships, List<Cell> margin, ShipOrientation orientation)
	{
		_orientation = orientation;
		_isDead = false;
		_state = ShipState.Normal;
		if (ships == null) { throw new ArgumentNullException("cells"); }
		if (ships.Count == 0) { throw new ArgumentException("Список ячеек, занимаемых кораблем пуст."); }
		if (ships.Count < 1 || ships.Count > 4) { throw new ArgumentException("Количество палуб дожно быть в пределах от 1 до 4"); }

		foreach (Cell cell in ships) { cell.Type = CellType.Ship; }
		_palubs = ships;

		if (margin == null) { throw new ArgumentNullException("margin"); }
		if (margin.Count < 1) { throw new ArgumentException("Количество ячеек окружения должно быть больше 1-ой."); }

		foreach (Cell cell in margin) { cell.Type = CellType.Margin; }
		_margin = margin;

		if (ships.Count == 1) { _orientation = ShipOrientation.None; }
		else
		{
			if (_orientation == ShipOrientation.None) { throw new ArgumentException("Для кораблей с числом палуб больше 1-й необходимо задать ориентацию"); }
			_orientation = orientation;
		}
	}
	#endregion

	#region Свойства
	public bool IsDead { get { return _isDead; } }
	public List<Cell> Cells { get { return _palubs; } }
	public List<Cell> Margin { get { return _margin; } }
	public ShipOrientation Orientation { get { return _orientation; } }
	public ShipState State { get { return _state; } set { _state = value; } }

	public int WoundCount
	{
		get
		{
			if (_state == ShipState.Dead)
				return _palubs.Count;
			int num = 0;
			foreach (Cell paluba in _palubs)
			{
				if (paluba.IsDead)
					++num;
			}
			return num;
		}
	}
	#endregion
	#region Методы
	public void Kill()
	{
		if (_state == ShipState.Dead)
			return;
		foreach (Cell deck in _palubs)
			deck.IsDead = true;
		foreach (Cell cell in _margin)
			cell.IsDead = true;
		_state = ShipState.Dead;
	}
	#endregion
}


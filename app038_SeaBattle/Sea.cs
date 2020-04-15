using System;
using System.Collections.Generic;


class Sea
{
	#region Переменные
	private static Random rnd = new Random();
	private FireResult _fireResult;
	private Dictionary<string, Cell> _cells = new Dictionary<string, Cell>();
	private List<Ship> _ships = new List<Ship>();
	private Player _player;
	private Ship _lastWoundShip = null;
	#endregion

	#region Конструкторы
	public Sea(Player player)
	{
		if (player.Type == PlayerType.None)
		{
			throw new ArgumentException("Карта может быть создана только для игроков 'Человек' или 'Компьютер'");
		}
		_player = player;

		string cellKey = ""; //координаты ячейки
		for (int row = 97; row < 107; row++)
		{
			for (int column = 0; column < 10; column++)
			{
				cellKey = ((char)row).ToString() + column;//координаты ячейки
				_cells.Add(cellKey, new Cell((char)row, column));
			}
		}

		int decksCount = 0; //кол-во палуб
		int currentCellrow = 0; //коорд. текущей ячейки
		int currentCellcolumn = 0; //коорд. текущей ячейки
		Cell currentCell = null; //текущая ячейка
		ShipOrientation orientation = ShipOrientation.None;
		List<Cell> preShip, preMargin;
		Cell preCell = null;
		int[] paluba = new int[] { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };
		foreach (int countPaluba in paluba)
		{
		shipPositions:
			orientation = ShipOrientation.None;
			preShip = new List<Cell>();
			do
			{
				currentCellrow = rnd.Next(97, 107);
				currentCellcolumn = rnd.Next(0, 10);
				cellKey = (char)currentCellrow + "" + currentCellcolumn;
				preCell = _cells[cellKey];
			} while (preCell.Type != CellType.Water);

			preShip.Add(preCell);

			if (decksCount == 1) { goto addOne; }
			//Меняем рандомно ориентацию корабля
			orientation = (ShipOrientation)rnd.Next(1, 3);
			//Создаем предварительный ряд и колонку следующей клетке (preCell) палубы корабля
			int preRow = preCell.Row, preColumn = preCell.Col;
			for (int decks = 2; decks <= countPaluba; decks++)
			{
				if (orientation == ShipOrientation.Horizontal)
				{
					preColumn += 1;
					if (preColumn > 9) { goto shipPositions; }
				}
				else
				{
					preRow += 1;
					if (preRow > 106) { goto shipPositions; }
				}
				cellKey = (char)preRow + "" + preColumn;

				preCell = _cells[cellKey];
				if (preCell.Type != CellType.Water) { goto shipPositions; }
				preShip.Add(preCell);
			}

		addOne:
			preMargin = new List<Cell>();
			foreach (Cell cell in preShip)
			{
				preColumn = cell.Col - 1;
				if (preColumn >= 0)
				{
					preRow = cell.Row;
					cellKey = (char)preRow + "" + preColumn;
					preCell = _cells[cellKey];
					if (!preShip.Contains(preCell) && !preMargin.Contains(preCell) && preCell.Type != CellType.Ship) { preMargin.Add(preCell); }

					preRow = cell.Row - 1;
					if (preRow > 96)
					{
						cellKey = (char)preRow + "" + preColumn;
						preCell = _cells[cellKey];
						if (!preShip.Contains(preCell) && !preMargin.Contains(preCell) && preCell.Type != CellType.Ship) { preMargin.Add(preCell); }
					}

					preRow = cell.Row + 1;
					if (preRow < 106)
					{
						cellKey = (char)preRow + "" + preColumn;
						preCell = _cells[cellKey];
						if (!preShip.Contains(preCell) && !preMargin.Contains(preCell) && preCell.Type != CellType.Ship) { preMargin.Add(preCell); }
					}
				}

				preColumn = cell.Col;
				preRow = cell.Row - 1;
				if (preRow > 96)
				{
					cellKey = (char)preRow + "" + preColumn;
					preCell = _cells[cellKey];
					if (!preShip.Contains(preCell) && !preMargin.Contains(preCell) && preCell.Type != CellType.Ship) { preMargin.Add(preCell); }
				}

				preRow = cell.Row + 1;
				if (preRow < 107)
				{
					cellKey = (char)preRow + "" + preColumn;
					preCell = _cells[cellKey];
					if (!preShip.Contains(preCell) && !preMargin.Contains(preCell) && preCell.Type != CellType.Ship) { preMargin.Add(preCell); }
				}

				preColumn = cell.Col + 1;
				if (preColumn < 10)
				{
					preRow = cell.Row;
					cellKey = (char)preRow + "" + preColumn;
					preCell = _cells[cellKey];
					if (!preShip.Contains(preCell) && !preMargin.Contains(preCell) && preCell.Type != CellType.Ship) { preMargin.Add(preCell); }

					preRow = cell.Row - 1;
					if (preRow > 96)
					{
						cellKey = (char)preRow + "" + preColumn;
						preCell = _cells[cellKey];
						if (!preShip.Contains(preCell) && !preMargin.Contains(preCell) && preCell.Type != CellType.Ship) { preMargin.Add(preCell); }
					}

					preRow = cell.Row + 1;
					if (preRow < 107)
					{
						cellKey = (char)preRow + "" + preColumn;
						preCell = _cells[cellKey];
						if (!preShip.Contains(preCell) && !preMargin.Contains(preCell) && preCell.Type != CellType.Ship) { preMargin.Add(preCell); }
					}
				}
			}
			_ships.Add(new Ship(preShip, preMargin, orientation));
		}
	}
	#endregion

	#region Свойства
	public Dictionary<string, Cell> Cells { get { return _cells; } }
	public List<Ship> Ships { get { return _ships; } }

	public Ship LastWoundShip
	{
		get { return _lastWoundShip; }
		set { _lastWoundShip = value; }
	}
	#endregion

	#region Функции

	public string Image(Player player, int gamemode)
	{
		string strMap = "";
		strMap += $"           Игрок: {_player.Name}                       \n";
		strMap += "                                            \n";
		strMap += "     0   1   2   3   4   5   6   7   8   9  \n";
		strMap += "   ╋━━━╇━━━╇━━━╇━━━╇━━━╇━━━╇━━━╇━━━╇━━━╇━━━┫\n";

		string letters = "abcdefghij";
		int rowIndex = 1;
		string cellKey = "";
		Cell cell;
		foreach (char letter in letters)
		{
			strMap += " " + letter + " ┃";
			for (int columnIndex = 0; columnIndex < 10; columnIndex++)
			{
				cellKey = letter + "" + columnIndex;
				cell = _cells[cellKey];
				if (cell.Type == CellType.Water || cell.Type == CellType.Margin)
				{
					if (cell.IsDead) { strMap += " ○ "; }
					else { strMap += "   "; }
				}
				else
				{
					if (gamemode == 0)
					{
						if (cell.IsDead) { strMap += " # "; }
						else { strMap += "   "; }
					}
					else if (gamemode == 1)
					{
						if (player.Type == PlayerType.Human)
						{
							if (cell.IsDead) { strMap += " # "; }
							else { strMap += " ■ "; }
						}
						else
						{
							if (cell.IsDead) { strMap += " # "; }
							else { strMap += "   "; }
						}
					}
					else
					{
						if (cell.IsDead) { strMap += " # "; }
						else { strMap += " ■ "; }
					}

				}
				if (columnIndex == 9) { strMap += "┃\n"; }
				else { strMap += "│"; }
			}
			if (rowIndex == 10) { strMap += "   ┻━━━┷━━━┷━━━┷━━━┷━━━┷━━━┷━━━┷━━━┷━━━┷━━━┛\n"; }
			else { strMap += "   ╉───┼───┼───┼───┼───┼───┼───┼───┼───┼───┨\n"; }
			rowIndex++;
		}
		return strMap;
	}

	public FireResult Fire(string coords)
	{
		if (string.IsNullOrWhiteSpace(coords)) { throw new ArgumentNullException("coords"); }

		string normalizeCoords = coords.Trim().ToLower();
		if (normalizeCoords.Length != 2) { throw new ArgumentException("Указаны неверные координаты выстрела!"); }

		string letter = normalizeCoords.Substring(0, 1);
		if (!"abcdefghij".Contains(letter)) { throw new ArgumentException("Указаны неверные координаты выстрела!"); }
		int rowIndex = letter[0] - 97;

		int columnIndex = -1;
		try
		{
			columnIndex = int.Parse(normalizeCoords.Substring(1));
			if (columnIndex < 0 || columnIndex > 9) { throw new Exception(); }
		}
		catch (Exception) { throw new ArgumentException("Указаны неверные координаты выстрела!"); }
		return Fire(_cells[letter + "" + columnIndex]);
	}

	public FireResult Fire(Cell firedCell)
	{
		if (firedCell == null) { throw new ArgumentNullException("firedCell"); }
		if (firedCell.IsDead) { return FireResult.Double; }
		firedCell.IsDead = true;
		if (firedCell.Type == CellType.Ship)
		{
			foreach (Ship ship in _ships)
			{
				if (ship.Cells.Contains(firedCell))
				{
					if (ship.State == ShipState.Dead) { return FireResult.Double; }
					if (ship.WoundCount != ship.Cells.Count) { ship.State = ShipState.Wounded; return FireResult.Wound; }

					ship.Kill();
					return FireResult.Killed;
				}
			}
		}
		return FireResult.Miss;
	}

	#endregion
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Game
{
	#region " Локальные переменные "
	private int _currentPlayer = 0;
	private int _winner = 0;
	private Cell[] cells = new Cell[10];
	#endregion

	#region " Конструкторы "
	public Game()
	{
		for (int index = 1; index < 10; index++) { cells[index] = new Cell(index); }
	}
	#endregion

	#region " Свойства "
	public int CurrentPlayer { get { return _currentPlayer; } }

	public int Winner { get { return _winner; } }

	public int Loser
	{
		get
		{
			if (_winner == 1) { return 2; }
			else if (_winner == 2) { return 1; }
			return 0;
		}
	}

	public bool IsFinal { get { return _winner != 0; } }
	#endregion

	#region " Функции "
	public string _step(string coords)
	{
		if (CurrentPlayer == 0) { _currentPlayer = 1; }
		if (string.IsNullOrEmpty(coords)) { return "Ошибка"; }
		string strData = coords.Trim().ToLower();
		if (strData.Length != 2) { return "Ошибка длины координат"; }
		string Row = strData.Substring(0, 1);
		if (!"abc".Contains(Row)) { return "Ошибка"; }
		string Col = strData.Substring(1);
		if (!"123".Contains(Col)) { return "Ошибка"; }
		int cellIndex = _getIndex(strData);
		if (!cells[cellIndex].IsEmpty) { return "Ошибка"; }
		cells[cellIndex].Value = _currentPlayer == 1 ? "o" : "x";

	}

	private int _getIndex(String coords)
	{
		switch (coords)
		{
			case "a1": return 1;
			case "a2": return 2;
			case "a3": return 3;
			case "b1": return 4;
			case "b2": return 5;
			case "b3": return 6;
			case "c1": return 7;
			case "c2": return 8;
			case "c3": return 9;
			default: return 0;
		}
	}

	private bool _checkFinal()
	{
		if (

			(cells[1].Value == cells[2].Value && cells[1].Value == cells[3].Value && !string.IsNullOrWhiteSpace(cells[1].Value)) ||
			(cells[4].Value == cells[5].Value && cells[4].Value == cells[6].Value && !string.IsNullOrWhiteSpace(cells[4].Value)) ||
			(cells[7].Value == cells[8].Value && cells[7].Value == cells[9].Value && !string.IsNullOrWhiteSpace(cells[7].Value)) ||
			(cells[1].Value == cells[4].Value && cells[1].Value == cells[7].Value && !string.IsNullOrWhiteSpace(cells[1].Value)) ||
			(cells[2].Value == cells[5].Value && cells[2].Value == cells[8].Value && !string.IsNullOrWhiteSpace(cells[2].Value)) ||
			(cells[3].Value == cells[6].Value && cells[3].Value == cells[9].Value && !string.IsNullOrWhiteSpace(cells[3].Value)) ||
			(cells[1].Value == cells[5].Value && cells[1].Value == cells[9].Value && !string.IsNullOrWhiteSpace(cells[1].Value)) ||
			(cells[3].Value == cells[5].Value && cells[3].Value == cells[7].Value && !string.IsNullOrWhiteSpace(cells[3].Value))

			) { return true; }
	}
	#endregion

	#region " Отрисовка "
	public string Draw()
	{
		return
			"    1   2   3  \n" +
			"  ┌───┬───┬───┐\n" +
			" a│ " + cells[1].Value + " │ " + cells[2].Value + " │ " + cells[3].Value + " │\n" +
			"  ├───┼───┼───┤\n" +
			" b│ " + cells[4].Value + " │ " + cells[5].Value + " │ " + cells[6].Value + " │\n" +
			"  ├───┼───┼───┤\n" +
			" c│ " + cells[7].Value + " │ " + cells[8].Value + " │ " + cells[9].Value + " │\n" +
			"  └───┴───┴───┘\n";
	}
	#endregion
}


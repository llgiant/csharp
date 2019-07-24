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
	private bool _isFinal = false;
	private string _fpMark = " ";
	private string _spMark = " ";
	private string _name1 = " ";
	private string _name2 = " ";

	#endregion;

	#region " Конструкторы "

	public Game(Player player1, Player player2)
	{
		for (int index = 1; index < 10; index++) { cells[index] = new Cell(index); }
		Fishka1 = player1.Fishka;
		Fishka2 = player2.Fishka;
		Name1 = player1.Name;
		Name2 = player2.Name;
	}
	#endregion

	#region " Свойства "
	public string Name1
	{
		get { return _name1; }
		set { _name1 = value; }
	}
	public string Name2
	{
		get { return _name2; }
		set { _name2 = value; }
	}
	public string Fishka1
	{
		get { return _fpMark; }
		set { _fpMark = value; }
	}
	public string Fishka2
	{
		get { return _spMark; }
		set { _spMark = value; }
	}
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

	public bool IsFinal { get { return _isFinal; } }
	#endregion

	#region " Функции "
	public string _step(string coords)
	{
		if (CurrentPlayer == 0) { _currentPlayer = 1; }
		if (string.IsNullOrEmpty(coords)) { return "Вы не ввели координаты"; }

		string strCoords = coords.Trim().ToLower();
		if (strCoords.Length != 2) { return "Координаты должны содержать одну букву и одну цифру"; }

		string Row = strCoords.Substring(0, 1);
		if (!"abc".Contains(Row)) { return "Таких координат не существует"; }

		string Col = strCoords.Substring(1);
		if (!"123".Contains(Col)) { return "Таких координат не существует"; }

		int cellIndex = _getIndex(strCoords);
		if (!cells[cellIndex].IsEmpty) { return $"Ячейка {strCoords} уже занята."; }

		cells[cellIndex].Value = _currentPlayer == 1 ? Fishka1 : Fishka2;

		if (_checkFinal()) { _winner = _currentPlayer; _isFinal = true; }
		else
		{
			if (_allEmpty()) { _isFinal = true; }
			else { _currentPlayer = _currentPlayer == 1 ? _currentPlayer = 2 : _currentPlayer = 1; }
		}

		return "";
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

	private bool _allEmpty()
	{
		for (int index = 1; index < cells.Length; index++) { if (cells[index].IsEmpty) { return false; } }
		return true;
	}

	private bool _checkFinal()
	{
		return (cells[1].Value == cells[2].Value && cells[1].Value == cells[3].Value && !cells[1].IsEmpty) ||
			   (cells[4].Value == cells[5].Value && cells[4].Value == cells[6].Value && !cells[4].IsEmpty) ||
			   (cells[7].Value == cells[8].Value && cells[7].Value == cells[9].Value && !cells[7].IsEmpty) ||
			   (cells[1].Value == cells[4].Value && cells[1].Value == cells[7].Value && !cells[1].IsEmpty) ||
			   (cells[2].Value == cells[5].Value && cells[2].Value == cells[8].Value && !cells[2].IsEmpty) ||
			   (cells[3].Value == cells[6].Value && cells[3].Value == cells[9].Value && !cells[3].IsEmpty) ||
			   (cells[1].Value == cells[5].Value && cells[1].Value == cells[9].Value && !cells[1].IsEmpty) ||
			   (cells[3].Value == cells[5].Value && cells[3].Value == cells[7].Value && !cells[3].IsEmpty);
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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum GameMode
{
	Simple = 0,
	Hard = 1
}

class Game
{
	#region " Локальные переменные "
	private Random rnd = new Random();
	private Player _currentPlayer = null; // Поле устанавливает
	private Player _winner = null;
	private Cell[] cells = new Cell[10];
	private bool _isFinal = false;
	private Player _player1 = null;
	private Player _player2 = null;
	private GameMode _gameMode = GameMode.Simple;
	#endregion;

	#region " Конструкторы "

	public Game(Player player1, Player player2) : this(player1, player2, GameMode.Simple)
	{ }

	public Game(Player player1, Player player2, GameMode gameMode)
	{
		for (int index = 1; index < 10; index++) { cells[index] = new Cell(index); }
		_player1 = player1;
		_player2 = player2;
		_currentPlayer = _player1;
		GameMode = gameMode;
	}
	#endregion

	#region " Свойства "
	public GameMode GameMode
	{
		get { return _gameMode; }
		set { _gameMode = value; }
	}

	public Player Player1 { get { return _player1; } }
	public Player Player2 { get { return _player2; } }
	public Player CurrentPlayer { get { return _currentPlayer; } }

	public Player Winner { get { return _winner; } }

	public Player Loser
	{
		get
		{
			if (_winner == Player1) { return Player2; }
			else if (_winner == Player2) { return Player1; }
			return null;
		}
	}

	public bool IsFinal { get { return _isFinal; } }
	#endregion

	#region " Функции "
	public string _step(string coords)
	{
		int cellIndex = 0;
		if (_currentPlayer.Type != PlayerType.Robot)
		{
			if (string.IsNullOrEmpty(coords)) { return "Вы не ввели координаты"; }

			string strCoords = coords.Trim().ToLower();
			if (strCoords.Length != 2) { return "Координаты должны содержать одну букву и одну цифру"; }

			string Row = strCoords.Substring(0, 1);
			if (!"abc".Contains(Row)) { return "Таких координат не существует"; }

			string Col = strCoords.Substring(1);
			if (!"123".Contains(Col)) { return "Таких координат не существует"; }
			cellIndex = _getIndex(strCoords);

			if (!cells[cellIndex].IsEmpty) { return $"Ячейка {strCoords} уже занята."; }
		}
		else
		{
			if (_gameMode == GameMode.Hard)
			{
				//СТРАТЕГИЯ НЗАЩИТЫ

				//Ход в ячейку по горизонтали
				if (cells[1].Value == Player1.Fishka && cells[2].Value == Player1.Fishka && cells[3].IsEmpty) { cellIndex = 3; }
				else if (cells[1].Value == Player1.Fishka && cells[3].Value == Player1.Fishka && cells[2].IsEmpty) { cellIndex = 2; }
				else if (cells[2].Value == Player1.Fishka && cells[3].Value == Player1.Fishka && cells[1].IsEmpty) { cellIndex = 1; }

				else if (cells[4].Value == Player1.Fishka && cells[5].Value == Player1.Fishka && cells[6].IsEmpty) { cellIndex = 6; }
				else if (cells[4].Value == Player1.Fishka && cells[6].Value == Player1.Fishka && cells[5].IsEmpty) { cellIndex = 5; }
				else if (cells[5].Value == Player1.Fishka && cells[6].Value == Player1.Fishka && cells[4].IsEmpty) { cellIndex = 4; }

				else if (cells[7].Value == Player1.Fishka && cells[8].Value == Player1.Fishka && cells[9].IsEmpty) { cellIndex = 9; }
				else if (cells[7].Value == Player1.Fishka && cells[9].Value == Player1.Fishka && cells[8].IsEmpty) { cellIndex = 8; }
				else if (cells[8].Value == Player1.Fishka && cells[9].Value == Player1.Fishka && cells[7].IsEmpty) { cellIndex = 7; }
				//Ход в ячейку по вертикили
				else if (cells[1].Value == Player1.Fishka && cells[4].Value == Player1.Fishka && cells[7].IsEmpty) { cellIndex = 7; }
				else if (cells[1].Value == Player1.Fishka && cells[7].Value == Player1.Fishka && cells[4].IsEmpty) { cellIndex = 4; }
				else if (cells[4].Value == Player1.Fishka && cells[7].Value == Player1.Fishka && cells[1].IsEmpty) { cellIndex = 1; }

				else if (cells[2].Value == Player1.Fishka && cells[5].Value == Player1.Fishka && cells[8].IsEmpty) { cellIndex = 8; }
				else if (cells[2].Value == Player1.Fishka && cells[8].Value == Player1.Fishka && cells[5].IsEmpty) { cellIndex = 5; }
				else if (cells[8].Value == Player1.Fishka && cells[5].Value == Player1.Fishka && cells[2].IsEmpty) { cellIndex = 2; }

				else if (cells[3].Value == Player1.Fishka && cells[6].Value == Player1.Fishka && cells[9].IsEmpty) { cellIndex = 9; }
				else if (cells[3].Value == Player1.Fishka && cells[9].Value == Player1.Fishka && cells[6].IsEmpty) { cellIndex = 6; }
				else if (cells[6].Value == Player1.Fishka && cells[9].Value == Player1.Fishka && cells[3].IsEmpty) { cellIndex = 3; }
				//Ход в ячейку по диагонали
				else if (cells[3].Value == Player1.Fishka && cells[5].Value == Player1.Fishka && cells[7].IsEmpty) { cellIndex = 7; }
				else if (cells[3].Value == Player1.Fishka && cells[7].Value == Player1.Fishka && cells[5].IsEmpty) { cellIndex = 5; }
				else if (cells[5].Value == Player1.Fishka && cells[7].Value == Player1.Fishka && cells[3].IsEmpty) { cellIndex = 3; }

				else if (cells[1].Value == Player1.Fishka && cells[5].Value == Player1.Fishka && cells[9].IsEmpty) { cellIndex = 9; }
				else if (cells[1].Value == Player1.Fishka && cells[9].Value == Player1.Fishka && cells[5].IsEmpty) { cellIndex = 5; }
				else if (cells[5].Value == Player1.Fishka && cells[9].Value == Player1.Fishka && cells[1].IsEmpty) { cellIndex = 1; }

				//стратегия НАПАДЕНИЯ

				else if (cells[1].Value == Player2.Fishka && cells[2].Value == Player2.Fishka && cells[3].IsEmpty) { cellIndex = 3; }
				else if (cells[1].Value == Player2.Fishka && cells[3].Value == Player2.Fishka && cells[2].IsEmpty) { cellIndex = 2; }
				else if (cells[2].Value == Player2.Fishka && cells[3].Value == Player2.Fishka && cells[1].IsEmpty) { cellIndex = 1; }

				else if (cells[4].Value == Player2.Fishka && cells[5].Value == Player2.Fishka && cells[6].IsEmpty) { cellIndex = 6; }
				else if (cells[4].Value == Player2.Fishka && cells[6].Value == Player2.Fishka && cells[5].IsEmpty) { cellIndex = 5; }
				else if (cells[5].Value == Player2.Fishka && cells[6].Value == Player2.Fishka && cells[4].IsEmpty) { cellIndex = 4; }

				else if (cells[7].Value == Player2.Fishka && cells[8].Value == Player2.Fishka && cells[9].IsEmpty) { cellIndex = 9; }
				else if (cells[7].Value == Player2.Fishka && cells[9].Value == Player2.Fishka && cells[8].IsEmpty) { cellIndex = 8; }
				else if (cells[8].Value == Player2.Fishka && cells[9].Value == Player2.Fishka && cells[7].IsEmpty) { cellIndex = 7; }
				//Ход в ячейку по вертикили
				else if (cells[1].Value == Player2.Fishka && cells[4].Value == Player2.Fishka && cells[7].IsEmpty) { cellIndex = 7; }
				else if (cells[1].Value == Player2.Fishka && cells[7].Value == Player2.Fishka && cells[4].IsEmpty) { cellIndex = 4; }
				else if (cells[4].Value == Player2.Fishka && cells[7].Value == Player2.Fishka && cells[1].IsEmpty) { cellIndex = 1; }

				else if (cells[2].Value == Player2.Fishka && cells[5].Value == Player2.Fishka && cells[8].IsEmpty) { cellIndex = 8; }
				else if (cells[2].Value == Player2.Fishka && cells[8].Value == Player2.Fishka && cells[5].IsEmpty) { cellIndex = 5; }
				else if (cells[8].Value == Player2.Fishka && cells[5].Value == Player2.Fishka && cells[2].IsEmpty) { cellIndex = 2; }

				else if (cells[3].Value == Player2.Fishka && cells[6].Value == Player2.Fishka && cells[9].IsEmpty) { cellIndex = 9; }
				else if (cells[3].Value == Player2.Fishka && cells[9].Value == Player2.Fishka && cells[6].IsEmpty) { cellIndex = 6; }
				else if (cells[6].Value == Player2.Fishka && cells[9].Value == Player2.Fishka && cells[3].IsEmpty) { cellIndex = 3; }
				//Ход в ячейку по диагонали
				else if (cells[3].Value == Player2.Fishka && cells[5].Value == Player2.Fishka && cells[7].IsEmpty) { cellIndex = 7; }
				else if (cells[3].Value == Player2.Fishka && cells[7].Value == Player2.Fishka && cells[5].IsEmpty) { cellIndex = 5; }
				else if (cells[5].Value == Player2.Fishka && cells[7].Value == Player2.Fishka && cells[3].IsEmpty) { cellIndex = 3; }

				else if (cells[1].Value == Player2.Fishka && cells[5].Value == Player2.Fishka && cells[9].IsEmpty) { cellIndex = 9; }
				else if (cells[1].Value == Player2.Fishka && cells[9].Value == Player2.Fishka && cells[5].IsEmpty) { cellIndex = 5; }
				else if (cells[5].Value == Player2.Fishka && cells[9].Value == Player2.Fishka && cells[1].IsEmpty) { cellIndex = 1; }
			}
		}

		if (cellIndex == 0) { do { cellIndex = rnd.Next(1, 10); } while (!cells[cellIndex].IsEmpty); }

		cells[cellIndex].Value = _currentPlayer == Player1 ? Player1.Fishka : Player2.Fishka;

		if (_checkFinal()) { _winner = _currentPlayer; _isFinal = true; }
		else
		{
			if (_allEmpty()) { _isFinal = true; }
			else { _currentPlayer = _currentPlayer == Player1 ? _currentPlayer = Player2 : _currentPlayer = Player1; }
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


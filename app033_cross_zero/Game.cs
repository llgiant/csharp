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
	private Cell[] cells;
	private bool _isFinal = false;
	private Player _player1 = null;
	private Player _player2 = null;
	private GameMode _gameMode = GameMode.Simple;
	private int _cellCounts;
	private int _fieldSize;

	#endregion;

	#region " Конструкторы "

	public Game(Player player1, Player player2) : this(player1, player2, GameMode.Simple, 0)
	{ }

	public Game(Player player1, Player player2, GameMode gameMode, int fieldSize)
	{
		if (player1 == null) { throw new ArgumentNullException("player1"); }
		if (player2 == null) { throw new ArgumentNullException("player2"); }
		if (fieldSize < 3 || fieldSize > 10) { throw new ArgumentException("Размерность игрового поля должна быть в пределах от 3 до 10."); }

		int arrayLen = fieldSize * fieldSize + 1;
		cells = new Cell[arrayLen];
		for (int index = 1; index < arrayLen; index++) { cells[index] = new Cell(); }
		_player1 = player1;
		_player2 = player2;
		_currentPlayer = _player1;
		GameMode = gameMode;
		_fieldSize = fieldSize;

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
	public string _step(string coords, int fieldSize)
	{
		int cellIndex = 0;
		string number = "";
		string letters = " abcdefghij".Substring(1, fieldSize);
		if (fieldSize < 10) { number = "12345678910".Substring(0, fieldSize); }
		else { number = "12345678910".Substring(1, fieldSize + 1); }



		if (_currentPlayer.Type != PlayerType.Robot1 && _currentPlayer.Type != PlayerType.Robot2)
		{
			if (string.IsNullOrEmpty(coords)) { return "Вы не ввели координаты"; }
			if (fieldSize < 10)
			{
				string strCoords = coords.Trim().ToLower();
				if (strCoords.Length < 1 && strCoords.Length > 3) { return "Координаты должны содержать одну букву и одну цифру"; }

				string Row = strCoords.Substring(0, 1);
				if (!letters.Contains(Row)) { return "Таких координат не существует"; }

				string Col = strCoords.Substring(1);
				if (!number.Contains(Col)) { return "Таких координат не существует"; }
				cellIndex = _getIndex(strCoords);

				if (!cells[cellIndex].IsEmpty) { return $"Ячейка {strCoords} уже занята."; }
			}

		}
		else
		{
			if (_gameMode == GameMode.Hard)
			{


				#region СТРАТЕГИЯ ЗАЩИТЫ

				int count = 0;
				int countEmpty = 0;
				//ход в ячейку по горизонтали
				for (int col = 1; col <= _fieldSize; col++)
				{
					if (cells[col].Value == Player1.Fishka) { count++; }
					if (cells[col].IsEmpty) { countEmpty++; cellIndex = col; }
					if (countEmpty > 1 || (count < 4 && col == _fieldSize))
					{
						col += _fieldSize;
						_fieldSize += _fieldSize;
						cellIndex = 0;
					}

				}

				//ход в ячейку по вертикали
				int index = 1;
				count = 0;
				countEmpty = 0;
				for (int row = index; row <= _fieldSize * _fieldSize; row += _fieldSize)
				{
					if (cells[row].Value == Player1.Fishka) { count++; }
					if (cells[row].IsEmpty) { countEmpty++; cellIndex = row; }
					if (countEmpty > 1 || (count < 4 && row == _fieldSize))
					{
						index++;
						row += _fieldSize;
						_fieldSize += _fieldSize;
						cellIndex = 0;
					}
				}

				//ход в ячейку по диагонали слева направо
				index = 1;
				count = 0;
				countEmpty = 0;
				for (int diag1 = index; diag1 <= _fieldSize * _fieldSize; diag1 += _fieldSize + 1)
				{
					if (cells[diag1].Value == Player1.Fishka) { count++; }
					if (cells[diag1].IsEmpty) { countEmpty++; cellIndex = diag1; }
					if (countEmpty > 1) { break; }
				}

				//ход в ячейку по диагонали справа налево
				index = _fieldSize;
				count = 0;
				countEmpty = 0;
				for (int diag1 = index; diag1 <= _fieldSize * _fieldSize; diag1 += _fieldSize - 1)
				{
					if (cells[diag1].Value == Player1.Fishka) { count++; }
					if (cells[diag1].IsEmpty) { countEmpty++; cellIndex = diag1; }
					if (countEmpty > 1) { break; }
				}
				#endregion

				#region СТРАТЕГИЯ НАПАДЕНИЯ

				#endregion

			}
		}

		if (cellIndex == 0) { do { cellIndex = rnd.Next(1, _cellCounts + 1); } while (!cells[cellIndex].IsEmpty); }

		cells[cellIndex].Value = _currentPlayer == Player1 ? Player1.Fishka : Player2.Fishka;

		if (_checkFinal()) { _winner = _currentPlayer; _isFinal = true; }
		else
		{
			if (_allEmpty()) { _isFinal = true; }
			else { _currentPlayer = _currentPlayer == Player1 ? _currentPlayer = Player2 : _currentPlayer = Player1; }
		}

		return "";
	}

	private int _getIndex(string coords)
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
		string result = "", part_1 = "", part_2 = "";
		int cellIndex = 0;
		char rowLetter = '0';
		int rowNumber = 0;
		for (int row = 1; row <= _fieldSize; row++)
		{
			rowNumber = (char)(row + 49);
			rowLetter = (char)(row + 96);
			for (int col = 1; col <= _fieldSize; col++)
			{
				cellIndex++;
				if (row == 1)
				{
					part_2 += "│   ";
					if (col == 1) { part_2 = rowLetter + part_2; part_1 += " ┌───"; }
					else
					{
						part_1 += "┬───";
						if (col == _fieldSize)
						{
							part_1 += "┐\n";
							part_2 += "│\n";
						}
					}
				}
				else if (row == _fieldSize)
				{
					part_1 += "│   ";
					if (col == 1)
					{
						part_1 = rowLetter + part_1;
						result += " ├───";
						part_2 += " └───";
					}
					else
					{
						result += "┼───";
						part_2 += "┴───";
						if (col == _fieldSize)
						{
							result += "┤\n";
							part_1 += "│\n";
							part_2 += "┘";
						}
					}
				}
				else
				{
					part_2 += "│   ";
					if (col == 1) { part_2 = rowLetter + part_2; part_1 += " ├───"; }
					else
					{
						part_1 += "┼───";
						if (col == _fieldSize)
						{
							part_1 += "┤\n";
							part_2 += "│\n";
						}
					}
				}
			}
			result += part_1 + part_2;
			part_1 = ""; part_2 = "";
		}
		return result;
	}


	#endregion
}


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
	private int _fieldSize;


	#endregion;

	#region " Конструкторы "
	public Game() : this(new Player(), new Player(), GameMode.Simple, 3)
	{ }

	public Game(Player player1, Player player2) : this(player1, player2, GameMode.Simple, 3)
	{ }

	public Game(Player player1, Player player2, GameMode gameMode, int fieldSize)
	{
		if (player1 == null) { throw new ArgumentNullException("player1"); }
		if (player2 == null) { throw new ArgumentNullException("player2"); }

		_player1 = player1;
		_player2 = player2;
		_currentPlayer = _player1;
		GameMode = gameMode;
		FieldSize = fieldSize;


	}
	#endregion

	#region " Свойства "
	public GameMode GameMode
	{
		get { return _gameMode; }
		set
		{
			if (value < 0 || value > (GameMode)1) { throw new Exception("В игре всего два уровня 0 - легкий и 1 - сложный"); }
			_gameMode = value;
		}
	}
	public int FieldSize
	{
		get { return _fieldSize; }
		set
		{
			if (value < 2 || value > 10) { throw new ArgumentException("Размерность игрового поля должна быть в пределах от 3 до 10."); }

			int arrayLen = value * value + 1;
			cells = new Cell[arrayLen];
			for (int index = 1; index < arrayLen; index++) { cells[index] = new Cell(); }
			_fieldSize = value;
		}
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
		int stepFieldSize = FieldSize;
		int cellIndex = 0;
		string number = "";
		string letters = " abcdefghij".Substring(1, FieldSize);
		if (FieldSize < 10) { number = "12345678910".Substring(0, FieldSize); }
		else { number = "12345678910".Substring(1, FieldSize + 1); }



		if (_currentPlayer.Type != PlayerType.Robot1 && _currentPlayer.Type != PlayerType.Robot2)
		{
			if (string.IsNullOrEmpty(coords)) { throw new Exception("Вы не ввели координаты"); }


			string strCoords = coords.Trim().ToLower();
			if (strCoords.Length < 1 && strCoords.Length > 3) { return "Координаты должны содержать одну букву и число от 1 до 10"; }

			string Col = strCoords.Substring(0, 1);
			if (!letters.Contains(Col)) { return "Таких координат не существует"; }

			string Row = strCoords.Substring(1);
			if (!number.Contains(Row)) { return "Таких координат не существует"; }

			cellIndex = _getIndex(Row, Col);

			if (!cells[cellIndex].IsEmpty) { return $"Ячейка {strCoords} уже занята."; }


		}
		else
		{
			if (_gameMode == GameMode.Hard)
			{
				#region СТРАТЕГИЯ ЗАЩИТЫ И НАПАДЕНИЯ
				/*
								int countEnemyFishka = 0;
								int countEmpty = 0;
								int emptyIndex = 0;
								int countPlayerFishka = 0;
								//ход в ячейку по горизонтали
								   for (int col = 1; col <= stepFieldSize; col++)
								   {
									   //Если ячейка пуста увеличиваем счетчик пустых и и присваиваем индекс пустой переменной emptyIndex
									   if (cells[col].IsEmpty) { countEmpty++; emptyIndex = col; }
									   //Если ячейка не пуста проверяем там крестик или нолик при этом увеличиваем значение переменных на 1
									   else { if (cells[col].Value == _currentPlayer.Fishka) { countPlayerFishka++; } else { countEnemyFishka++; } }

									   if (countPlayerFishka > 0 || countEmpty > 1 || (countEnemyFishka < stepFieldSize - 1 && col == stepFieldSize))
									   {
										   col = stepFieldSize;
										   stepFieldSize += stepFieldSize;
										   countEnemyFishka = 0;
									   }
									   if (countEnemyFishka == stepFieldSize - 1) { cellIndex = emptyIndex; break; }
								   }

								   //ход в ячейку по вертикали
								   int index = 1;
								   if (cellIndex == 0)
								   {

									   countEnemyFishka = 0;
									   countEmpty = 0;
									   for (int row = index; row <= _fieldSize * _fieldSize; row += _fieldSize)
									   {

										   if (cells[row].Value != _currentPlayer.Fishka) { countEnemyFishka++; } else { break; }
										   if (cells[row].IsEmpty) { countEmpty++; cellIndex = row; }
										   if (countEmpty > 1 || (countEnemyFishka < _fieldSize - 1 && row == _fieldSize))
										   {
											   index++;
											   row += _fieldSize;
											   _fieldSize += _fieldSize;
											   cellIndex = 0;
										   }
									   }
								   }
								   */


				#endregion

				int countFilled = 0;
				int countEnemyFilled = 0;
				for (int rc = 1; rc <= _fieldSize; rc++)
				{


					//перебирает ячейки в строке для нападения (победы)
					for (int index = 1; index <= _fieldSize; index++)
					{
						if (cells[index].IsEmpty) { cellIndex = index; }
						else if (cells[index].Value == _currentPlayer.Fishka) { countFilled++; }
						else if (cells[index].Value != _currentPlayer.Fishka) { countEnemyFilled++; }
					}
					if (countEnemyFilled == _fieldSize - 1) { goto makeStep; }
					if (countFilled == _fieldSize - 1) { goto makeStep; }
					countFilled = 0;
					cellIndex = 0;
					countEnemyFilled = 0;

					//перебирает ячейки в колонке для нападения (победы)
					for (int index = rc; index <= (_fieldSize * _fieldSize) - (_fieldSize - rc); index += _fieldSize)
					{
						if (cells[index].IsEmpty) { cellIndex = index; }
						else if (cells[index].Value == _currentPlayer.Fishka) { countFilled++; }
						else if (cells[index].Value != _currentPlayer.Fishka) { countFilled++; }
					}
					if (countFilled == _fieldSize - 1) { goto makeStep; }
					if (countEnemyFilled == _fieldSize - 1) { goto makeStep; }
					countFilled = 0;
					cellIndex = 0;
					countEnemyFilled = 0;
				}

				//ход в ячейку по диагонали слева направо





			}
		}


		makeStep:

		if (cellIndex == 0) { do { cellIndex = rnd.Next(1, _fieldSize * _fieldSize + 1); } while (!cells[cellIndex].IsEmpty); }

		cells[cellIndex].Value = _currentPlayer == Player1 ? Player1.Fishka : Player2.Fishka;

		if (_checkFinal()) { _winner = _currentPlayer; _isFinal = true; }
		else
		{
			if (_allEmpty()) { _isFinal = true; }
			else { _currentPlayer = _currentPlayer == Player1 ? _currentPlayer = Player2 : _currentPlayer = Player1; }
		}

		return "";
	}

	private int _getIndex(string Row, string Col)
	{
		int col = 0;
		int row = int.Parse(Row);

		switch (Col)
		{
			case "a": col = 1; break;
			case "b": col = 2; break;
			case "c": col = 3; break;
			case "d": col = 4; break;
			case "e": col = 5; break;
			case "f": col = 6; break;
			case "g": col = 7; break;
			case "h": col = 8; break;
			case "i": col = 9; break;
			case "j": col = 9; break;
		}

		if (col == 1) { return row; }
		else { return col * FieldSize - FieldSize + row; }

	}

	private bool _allEmpty()
	{
		for (int index = 1; index < cells.Length; index++) { if (cells[index].IsEmpty) { return false; } }
		return true;
	}

	private bool _checkFinal()
	{
		int countPlayerFishka = 1;
		int cellCount = 1;
		int countCol = 1;
		//Проверка по горизонтали
		for (int col = 1; col <= FieldSize * FieldSize; col++)
		{
			if (col + 1 <= FieldSize)
			{
				if (cells[col].Value == cells[col + 1].Value && !cells[col].IsEmpty) { countPlayerFishka++; }
			}
			if (countPlayerFishka == FieldSize) { return true; }
			if (cells[col].IsEmpty || cellCount == FieldSize) { cellCount = 1; col = countCol * FieldSize; countCol++; continue; }
			cellCount++;
		}



		return false;
	}
	#endregion

	#region  Отрисовка 
	public string Draw()
	{
		string result = "", part_1 = "", numbers = "", part_2 = "";
		int cellIndex = 0;
		char rowLetter = '0';
		char rowNumber = '0';
		int cellNumber = 1;
		for (int row = 1; row <= _fieldSize; row++)
		{
			rowNumber = (char)(row + 48);
			rowLetter = (char)(row + 96);
			for (int col = 1; col <= _fieldSize; col++)
			{
				cellIndex++;
				if (row == 1)
				{
					numbers += $"   {col}";
					part_2 += $"│ {cells[cellIndex].Value} ";
					cellNumber++; //номер ячейки
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
					part_1 += $"│ {cells[cellIndex].Value} ";
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
							part_2 += "┘\n";
						}
					}
				}
				else
				{
					part_2 += $"│ {cells[cellIndex].Value} ";
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
		return numbers +"\n"+ result;
	}

	#endregion
}


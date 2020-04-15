using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public enum PlayerType
{
	None = 0,
	Human = 1,
	Robot = 2
}
public enum FireResult
{
	Miss = 0, //Ошибка
	Wound = 1,
	Killed = 2,
	Double = 3,
	GameFinished = 4,
	NullPlayer = 5,
	NotOrderPlayer = 6
}
class Game
{
	public static Random Random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);

	#region Переменные
	private Ship _lastWoundShip = null;
	private List<Cell> _lastWoundedCell = null;
	private Sea _playerOneSea;
	private Sea _playerTwoSea;
	private Player _loser;
	private Player _currentPlayer;
	private Player _player1;
	private Player _player2;
	private Player _winner;
	private bool _isFinal = false;
	private ShipOrientation _orientation = 0;
	int _gameMode;
	private List<Cell> _fireCells = new List<Cell>();
	#endregion;

	#region Конструкторы
	public Game(Player player1, Player player2, int gamemode)
	{
		_player1 = player1 ?? throw new ArgumentNullException("player1");
		_player2 = player2 ?? throw new ArgumentNullException("player2");
		CurrentPlayer = _player1;
		_playerOneSea = new Sea(_player1);
		_playerTwoSea = new Sea(_player2);
		_gameMode = gamemode;
	}
	#endregion

	#region  Свойства
	public int GameMode { get { return _gameMode; } }
	public Player Player1 { get { return _player1; } }
	public Player Player2 { get { return _player2; } }
	public Player CurrentPlayer
	{
		get { return _currentPlayer; }
		set { _currentPlayer = value; }
	}
	public Player Winner { get { return _winner; } }
	public bool IsFinal { get { return _isFinal; } }
	#endregion


	#region Функции
	public string Image()
	{
		string image = "";
		string[] linesPl1 = _playerOneSea.Image(Player1, _gameMode).Split('\n');
		string[] linesPl2 = _playerTwoSea.Image(Player2, _gameMode).Split('\n');

		for (int i = 0; i < linesPl2.Length - 1; i++)
		{
			if (i == 0) { image += linesPl1[i] + linesPl2[i] + "\n"; }
			else { image += linesPl1[i] + "    ║  " + linesPl2[i] + "\n"; }
		}
		return image;
	}
	public FireResult Fire(Player player, string coords)
	{
		//        Sea currentPlayerSea = player == _player1 ? _playerOneSea : _playerTwoSea;
		Sea opponentPlayerSea = player == _player1 ? _playerTwoSea : _playerOneSea;


		if (IsFinal) { return FireResult.GameFinished; }
		if (player.Type == PlayerType.None) { return FireResult.NullPlayer; }
		if (player.Type == PlayerType.None) { player.Type = player.Type; }
		if (player.Type != player.Type) { return FireResult.NotOrderPlayer; }

		FireResult playerFireResult = 0;
		if (player.Type == PlayerType.Human)
		{
			playerFireResult = opponentPlayerSea.Fire(coords);
			goto makeReturn;
		}

		int fireCol = 0;
		char fireRow = ' ';
		Cell fireCell = null;
		string rowLetter = "abcdefghij";
		if (_lastWoundShip.WoundCount == null)
		{
			do
			{
				fireRow = rowLetter[Random.Next(0, 10)];
				fireCol = Random.Next(0, 10);
				fireCell = opponentPlayerSea.Cells[fireRow + "" + fireCol];
			}
			while (fireCell.IsDead);

			playerFireResult = opponentPlayerSea.Fire(fireCell);
			if (playerFireResult == FireResult.Killed)
			{
				_lastWoundShip = null; //однопалубные корабли
				_lastWoundedCell = null;
			}
			else if (playerFireResult == FireResult.Wound)
			{
				_lastWoundedCell.Add(fireCell);

				if (fireCell.Col - 1 > 0) { _fireCells.Add(opponentPlayerSea.Cells[fireCell.Row + "" + (fireCell.Col - 1)]); }
				if (fireCell.Row - 1 > 97) { _fireCells.Add(opponentPlayerSea.Cells[fireCell.Row - 1 + "" + fireCell.Col]); }
				if (fireCell.Col + 1 < 107) { _fireCells.Add(opponentPlayerSea.Cells[fireCell.Row + "" + (fireCell.Col + 1)]); }
				if (fireCell.Row + 1 < 10) { _fireCells.Add(opponentPlayerSea.Cells[fireCell.Row + 1 + "" + fireCell.Col]); }
			}
			foreach (Ship ship in opponentPlayerSea.Ships)
			{
				if (!ship.Cells.Contains(fireCell)) { continue; }
				_lastWoundShip = ship;
			}
			goto makeReturn;
		}



		if (_lastWoundShip.WoundCount > 0)
		{
			if (_lastWoundShip.WoundCount == 1)
			{
				fireCell = _fireCells[Random.Next(0, _fireCells.Count)]; _fireCells.Remove(fireCell);
				playerFireResult = opponentPlayerSea.Fire(fireCell);
				if (playerFireResult == FireResult.Killed)
				{
					_lastWoundShip = null; //однопалубные корабли
					_lastWoundedCell = null;
				}
				else if (playerFireResult == FireResult.Wound)
				{
					_orientation = _lastWoundShip.Orientation;
					if (_lastWoundShip.Orientation == ShipOrientation.Horizontal)
					{

					}
						if (fireCell. _lastWoundedCell[_lastWoundedCell.Count-1])
					_lastWoundedCell.Add(fireCell);
				}
			}
			else
			{

				if (_lastWoundShip.Orientation == ShipOrientation.Horizontal)
				{

					fireRow = _lastWoundedCell[_lastWoundedCell.Count - 1].Row;
					fireCol = Random.Next(0, 2) == 0 ?
						_lastWoundedCell[0].Col - 1 > 0 ? _lastWoundedCell[0].Col - 1 : _lastWoundedCell[_lastWoundedCell.Count - 1].Col + 1 :
					_lastWoundedCell[_lastWoundedCell.Count - 1].Col + 1 < 10 ? _lastWoundedCell[_lastWoundedCell.Count - 1].Col + 1 : _lastWoundedCell[0].Col - 1;

					fireCell = opponentPlayerSea.Cells[fireRow + "" + fireCol];

				}
				else
				{
					fireCol = _lastWoundedCell[_lastWoundedCell.Count - 1].Col;
					int rnd = Random.Next(0, 2);

					if (rnd == 0)
					{
						if (_lastWoundedCell[_lastWoundedCell.Count - 1].Row - 1 > 96)
						{
							fireRow = (char)(_lastWoundedCell[_lastWoundedCell.Count - 1].Row - 1);
						}
						else { fireRow = (char)(_lastWoundedCell[_lastWoundedCell.Count - 1].Row + 1); }

					}
					else
					{

					}

					//fireRow = Random.Next(0, 2) == 0 ?
					//	_lastWoundedCell[_lastWoundedCell.Count - 1].Row - 1 > 96 ? _lastWoundedCell[_lastWoundedCell.Count - 1].Row - 1 : _lastWoundedCell[_lastWoundedCell.Count - 1].Row + 1 :
					//_lastWoundedCell[_lastWoundedCell.Count - 1].Row + 1 < 107 ? _lastWoundedCell[_lastWoundedCell.Count - 1].Row + 1 : _lastWoundedCell[_lastWoundedCell.Count - 1].Row - 1;

					fireCell = opponentPlayerSea.Cells[fireRow + "" + fireCol];
				}
			}

			playerFireResult = opponentPlayerSea.Fire(fireCell);
			if (playerFireResult == FireResult.Wound)
			{


				_orientation = _lastWoundShip.Orientation;




				if (_orientation == ShipOrientation.Horizontal)
				{
					int maxCellCol = 0;
					foreach (Cell woundedCell in _lastWoundedCell)
					{
						if (fireCell.Col > woundedCell.Col) { maxCellCol = fireCell.Col; }


					}

					if (fireCell.Col > _lastWoundedCell[_lastWoundedCell.Count - 1].Col) { _lastWoundedCell.Add(fireCell); }
					else { _lastWoundedCell.Insert(0, fireCell); }
				}
				else
				{
					if (fireCell.Row > _lastWoundedCell[_lastWoundedCell.Count - 1].Row) { _lastWoundedCell.Add(fireCell); }
					else { _lastWoundedCell.Insert(0, fireCell); }
				}
			}



			int prevCol = _lastWoundedCell[_lastWoundedCell.Count - 1].Col;
			char prevRaw = _lastWoundedCell[_lastWoundedCell.Count - 1].Row;
			if (prevCol < fireCell.Col || prevCol > fireCell.Col)
			{
				_orientation = ShipOrientation.Horizontal;
				if (_orientation == ShipOrientation.Horizontal)
				{

				}
			}
			else if (prevRaw < fireCell.Col || prevRaw > fireCell.Col) { _orientation = ShipOrientation.Horizontal; }

		}





		makeFire:
		playerFireResult = opponentPlayerSea.Fire(fireCell);



		makeReturn:
		if (playerFireResult == FireResult.Miss || playerFireResult == FireResult.Double || playerFireResult == FireResult.Killed || playerFireResult == FireResult.Wound)
		{
			if (_currentPlayer.Type == PlayerType.Human)
			{
				if (playerFireResult == FireResult.Miss || playerFireResult == FireResult.Double) { CurrentPlayer = CurrentPlayer == Player1 ? Player2 : Player1; }
			}
			else
			{
				if (playerFireResult == FireResult.Killed) { _lastWoundShip = null; }
				if (playerFireResult == FireResult.Double || playerFireResult == FireResult.Miss) { CurrentPlayer = CurrentPlayer == Player1 ? Player2 : Player1; }
				if (playerFireResult == FireResult.Wound)
				{
					_lastWoundedCell.Add(fireCell);

				}
			}


			int killedCount = 0;
			foreach (Ship ship in _playerOneSea.Ships) { if (ship.State == ShipState.Dead) { killedCount++; } }
			if (killedCount == 10) { _isFinal = true; _winner = Player2; _loser = Player1; _lastWoundShip = null; }
			else
			{
				killedCount = 0;
				foreach (Ship ship in _playerTwoSea.Ships) { if (ship.State == ShipState.Dead) { killedCount++; } }
				if (killedCount == 10) { _isFinal = true; _winner = Player1; _loser = Player2; _lastWoundShip = null; }
				else
				{
					try { _loser.Type = PlayerType.None; }
					catch (Exception e) { }
				}
			}
		}

		return playerFireResult;
	}
	#endregion
}



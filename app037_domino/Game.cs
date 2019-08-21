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

public enum Stopka
{
	Bazzar = 0,
	Player1 = 1,
	Player2 = 2,
	Table = 3
}
class Game
{
	#region " Локальные переменные "
	private Random rnd = new Random();
	private Player _currentPlayer = null; // Поле устанавливает
	private Player _winner = null;
	private bool _isFinal = false;
	private Player _player1 = null;
	private Player _player2 = null;
	private GameMode _gameMode = GameMode.Simple;
	private List<Bone> _nativeList = new List<Bone>()
	{
		new Bone(0,0),
		new Bone(0,1), new Bone(1,1),
		new Bone(0,2), new Bone(1,2), new Bone(2,2),
		new Bone(0,3), new Bone(1,3), new Bone(2,3), new Bone(3,3),
		new Bone(0,4), new Bone(1,4), new Bone(2,4), new Bone(3,4), new Bone(4,4),
		new Bone(0,5), new Bone(1,5), new Bone(2,5), new Bone(3,5), new Bone(4,5), new Bone(5,5),
		new Bone(0,6), new Bone(1,6), new Bone(2,6), new Bone(3,6), new Bone(4,6), new Bone(5,6), new Bone(6,6)
	};
	List<Bone>[] Bones = new List<Bone>[] { new List<Bone>(), new List<Bone>(), new List<Bone>(), new List<Bone>() };
	#endregion;

	//Конструктор принимаеат 3 параметра 1 игрок 2 игрок и режим игры
	#region Конструкторcкая
	public Game() : this(new Player(), new Player(), GameMode.Simple) { }
	public Game(Player player1, Player player2) : this(player1, player2, GameMode.Simple) { }
	public Game(Player player1, Player player2, GameMode gameMode)
	{
		_player1 = player1 ?? throw new ArgumentNullException("player1");
		_player2 = player2 ?? throw new ArgumentNullException("player2");

		if (gameMode < 0 || gameMode > (GameMode)1) { throw new Exception("В игре всего два уровня 0 - легкий и 1 - сложный"); }
		else { _gameMode = gameMode; }

		#region РАЗДАЧА
		Bone addedBone;
		int index;
		Stopka filledStopka;
		Stopka startPlayer = Stopka.Player1;
		int min = 12;
		do
		{
			index = rnd.Next(0, _nativeList.Count);
			addedBone = _nativeList[index];
			_nativeList.RemoveAt(index);
			if (rnd.Next(0, 2) == 1) { addedBone.Rotate(); }

			if (_nativeList.Count > 21) { filledStopka = Stopka.Player1; }
			else if (_nativeList.Count > 14) { filledStopka = Stopka.Player2; }
			else { filledStopka = Stopka.Bazzar; }
			if (!(filledStopka == Stopka.Bazzar) && !addedBone.isDouble && min > addedBone.Rank)
			{
				min = addedBone.Rank;
				startPlayer = filledStopka;
			}
			Bones[(int)filledStopka].Add(addedBone);

		}
		while (_nativeList.Count > 0);
		_currentPlayer = startPlayer == Stopka.Player1 ? _player1 : _player2;
		#endregion
	}



	#endregion

	#region " Свойства "
	public GameMode GameMode { get { return _gameMode; } }
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

	#region

	string part1;
	string part2;
	string result;
	string player;


	for(index = 0; index < Stopka.Bazzar)

	#endregion
}

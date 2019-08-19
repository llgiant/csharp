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
	private bool _isFinal = false;
	private Player _player1 = null;
	private Player _player2 = null;
	private GameMode _gameMode = GameMode.Simple;
	#endregion;

	//Конструктор принимаеат 3 параметра 1 игрок 2 игрок и режим игры
	#region Конструкторcкая
	public Game() : this(new Player(), new Player(), GameMode.Simple) { }
	public Game(Player player1, Player player2) : this(player1, player2, GameMode.Simple) { }
	public Game(Player player1, Player player2, GameMode gameMode)
	{
		_player1 = player1 ?? throw new ArgumentNullException("player1");
		_player2 = player2 ?? throw new ArgumentNullException("player2");
		_currentPlayer = _player1;
		if (gameMode < 0 || gameMode > (GameMode)1) { throw new Exception("В игре всего два уровня 0 - легкий и 1 - сложный"); }
		else { _gameMode = gameMode; }
	#endregion

		#region " Свойства "
	public GameMode GameMode
	{
		get { return _gameMode; }

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
	#endregion}

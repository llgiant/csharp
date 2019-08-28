using System;
using System.Collections.Generic;


public enum GameMode
{
	Simple = 0,
	Hard = 1
}
public enum Stopka
{
	Bazar = 0,
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
	{   new Bone(0,0),
		new Bone(0,1), new Bone(1,1),
		new Bone(0,2), new Bone(1,2), new Bone(2,2),
		new Bone(0,3), new Bone(1,3), new Bone(2,3), new Bone(3,3),
		new Bone(0,4), new Bone(1,4), new Bone(2,4), new Bone(3,4), new Bone(4,4),
		new Bone(0,5), new Bone(1,5), new Bone(2,5), new Bone(3,5), new Bone(4,5), new Bone(5,5),
		new Bone(0,6), new Bone(1,6), new Bone(2,6), new Bone(3,6), new Bone(4,6), new Bone(5,6), new Bone(6,6)
	};
	List<Bone>[] Bones = new List<Bone>[] { new List<Bone>(), new List<Bone>(), new List<Bone>(), new List<Bone>() };
	#endregion;

	//Конструктор принимает 3 параметра 1 игрок 2 игрок и режим игры
	#region Конструкторы
	public Game() : this(new Player(), new Player(), GameMode.Simple) { }
	public Game(Player player1, Player player2) : this(player1, player2, GameMode.Simple) { }
	public Game(Player player1, Player player2, GameMode gameMode)
	{
		_player1 = player1 ?? throw new ArgumentNullException("player1");
		_player2 = player2 ?? throw new ArgumentNullException("player2");
		if (gameMode < 0 || gameMode > (GameMode)1) { throw new Exception("В игре всего два уровня 0 - легкий и 1 - сложный"); } else { _gameMode = gameMode; }

		#region РАЗДАЧА
		Bone addedBone;
		int index;
		Stopka filledStopka;
		Stopka startplayer = Stopka.Player1;
		int min = 100;
		do
		{
			index = rnd.Next(0, _nativeList.Count);
			addedBone = _nativeList[index];
			_nativeList.RemoveAt(index);
			if (rnd.Next(0, 2) == 1) { addedBone.Rotate(); }

			if (_nativeList.Count > 21) { filledStopka = Stopka.Player1; }
			else if (_nativeList.Count > 14) { filledStopka = Stopka.Player2; }
			else { filledStopka = Stopka.Bazar; }
			if (filledStopka != Stopka.Bazar && !addedBone.isDouble && min > addedBone.Rank) { min = addedBone.Rank; startplayer = filledStopka; }
			Bones[(int)filledStopka].Add(addedBone);
		} while (_nativeList.Count > 0);
		_currentPlayer = startplayer == Stopka.Player1 ? _player1 : _player2;
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

	#region "Отрисовка"

	public string Draw()
	{
		string line = "";               //добавление тире 
		string strTabelBones = " ";         //содержимое базара
		string strPlayerBones = " ";        //кости текущего игрока
		string strNumbersPlayerBones = "   ";
		int index = 0;                                                                              //индекс списка
		string opponentName = "";           //имя противника 
		int opponentCount = 0;           //количество костей противника

		List<Bone> bonesTable = Bones[(int)Stopka.Table];
		List<Bone> bonesCurrentPlayer;

		bonesTable.Add(new Bone(1, 2));
		bonesTable.Add(new Bone(2, 0));
		bonesTable.Add(new Bone(6, 4));
		bonesTable.Add(new Bone(5, 2));
		bonesTable.Add(new Bone(3, 0));
		bonesTable.Add(new Bone(2, 4));
		bonesTable.Add(new Bone(2, 0));
		bonesTable.Add(new Bone(6, 4));
		bonesTable.Add(new Bone(5, 2));

		if (_currentPlayer == _player1)
		{
			bonesCurrentPlayer = Bones[(int)Stopka.Player1];
			opponentName = _player2.Name;
			opponentCount = Bones[(int)Stopka.Player2].Count;
		}
		else
		{
			bonesCurrentPlayer = Bones[(int)Stopka.Player2];
			opponentName = _player1.Name;
			opponentCount = Bones[(int)Stopka.Player1].Count;
		}

		bonesCurrentPlayer.Add(new Bone(1, 2));
		bonesCurrentPlayer.Add(new Bone(2, 0));
		bonesCurrentPlayer.Add(new Bone(6, 4));
		bonesCurrentPlayer.Add(new Bone(5, 2));
		bonesCurrentPlayer.Add(new Bone(3, 0));
		bonesCurrentPlayer.Add(new Bone(2, 4));

		int maxBonesCount = bonesTable.Count >= bonesCurrentPlayer.Count ? bonesTable.Count : bonesCurrentPlayer.Count;

		do
		{
			if (bonesTable.Count > 0 && index < bonesTable.Count)
			{
				line += "------";
				strTabelBones += bonesTable[index].Image + " ";
			}
			if (index < 6)
			{
				strPlayerBones += bonesCurrentPlayer[index].Image + " ";
				strNumbersPlayerBones += (index + 1) + "     ";
			}
			index++;
		}
		while (index < maxBonesCount);

		return
			$"Костей на Базаре: {Bones[(int)Stopka.Bazar].Count}\n" +
			$"Костей у игрока {opponentName}: {opponentCount}\n" +
			line + "-\n" +
			strTabelBones + "\n" +
			line + "-\n" +
			strPlayerBones + "\n" +
			strNumbersPlayerBones;
	}
	#endregion

	#region " Функции "
	public string _step(string bone)
	{
		List<Bone> bonesTable = Bones[(int)Stopka.Table];
		List<Bone> bonesCurrentPlayer = null; ;
		string Sides = "lr";
		string tableSide = "";
		int boneNumber = 0;

		//валидация хода
		if (_currentPlayer.Type != PlayerType.Robot1 && _currentPlayer.Type != PlayerType.Robot2)
		{
			if (string.IsNullOrEmpty(bone)) { throw new Exception("Вы не ввели координаты"); }

			string strCoords = bone.Trim().ToLower();
			if (strCoords.Length < 1 && strCoords.Length > 2) { return "Координаты должны содержать одну букву и одно число "; }

			boneNumber = int.Parse(strCoords.Substring(0, 1));
			tableSide = strCoords.Substring(1);
			if (_currentPlayer == _player1)
			{
				bonesCurrentPlayer = Bones[(int)Stopka.Player1];
				if (bonesCurrentPlayer.Count < boneNumber) { return "Такой кости нет в стопке игрока"; }
			}
			else
			{
				bonesCurrentPlayer = Bones[(int)Stopka.Player2];
				if (bonesCurrentPlayer.Count < boneNumber) { return "Такой кости нет в стопке игрока"; }
			}
			if (!tableSide.Contains(Sides)) { return "Такой стороны не существует"; }
		}

		else
		{
			if (_gameMode == GameMode.Hard)
			{

			}
		makeStep:
			if ()
			{
				if (tableSide == "l") { bonesTable.Insert(0, bonesCurrentPlayer[boneNumber - 1]); }
				else { bonesTable.Add(bonesCurrentPlayer[boneNumber - 1]); }
				bonesCurrentPlayer.RemoveAt(boneNumber - 1);
			}



		}
		return "";
		#endregion
	}
	#region Взять с базара
	public Bone _take()
	{
		int index = rnd.Next(0, Bones[(int)Stopka.Bazar].Count);
		Bone taken = Bones[(int)Stopka.Bazar][index];
		Bones[(int)Stopka.Bazar].RemoveAt(index);
		return taken;
	}
	#endregion
}

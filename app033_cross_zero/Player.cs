using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public enum PlayerType
{
	Human = 0,
	Robot = 1
}
class Player
{
	#region " Локальные переменные "
	private string _name = " ";
	private PlayerType _playerType = PlayerType.Human;
	private string _fishka = "0";
	#endregion

	#region " Конструкторы "
	public Player() : this("") { }
	public Player(String name) : this(name, PlayerType.Human) { }
	public Player(String name, PlayerType PlayerType) : this(name, PlayerType.Human, "o") { }

	public Player(String name, PlayerType playerType, string fishka)
	{
		_name = name;
		Type = playerType;
		Fishka = fishka;
	}
	#endregion

	#region " Свойства "
	public PlayerType Type
	{
		get {return _playerType; }
		set { _playerType = value; }
	}
	public string Name
	{
		get { return _name; }
	}
	public string Fishka
	{
		get { return _fishka; }
		set
		{
			if (!"xo".Contains(value)) { return; }
			_fishka = value;
		}
	}
	
	#endregion

	#region " Функции "
	public string _chekName(String n)
	{
		if (string.IsNullOrWhiteSpace(n))
		{
			return " ";
		}

		return "";
	}
	#endregion
}
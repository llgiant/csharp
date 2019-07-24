using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Player
{
	#region " Локальные переменные "
	private string _name = " ";
	private bool _isRobot = false;
	private string _fishka = "0";
	#endregion

	#region " Конструкторы "
	public Player() : this("") { }
	public Player(String name) : this(name, false) { }
	public Player(String name, bool isRobot) : this(name, isRobot, "o") { }

	public Player(String name, bool isRobot, string fishka)
	{
		_name = name;
		_isRobot = isRobot;
		Fishka = fishka;
	}
	#endregion

	#region " Свойства "
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
	public bool IsRobot
	{
		get { return _isRobot; }
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public enum PlayerType
{
	Human = 0,
	Robot1 = 1
}
class Player
{
	#region " Локальные переменные "
	private string _name = " ";
	private PlayerType _playerType = PlayerType.Human;
	#endregion

	#region " Конструкторы "
	public Player() { }

	public Player(String name, PlayerType playerType)
	{
		Name = name;
		Type = playerType;
	}
	#endregion

	#region " Свойства "
	public PlayerType Type
	{
		get { return _playerType; }
		set
		{
			if (value > (PlayerType)2 || value < 0) { throw new Exception("В игре всего 3 типа игрока"); }
			_playerType = value;
		}
	}
	public string Name
	{

		get { return _name; }
		set
		{
			if (string.IsNullOrEmpty(value)) { throw new Exception("Имя не может быть пустым"); }
			_name = _normalize(value);
		}
	}
	

	#endregion

	#region Функции
	private static string _normalize(string name)
	{
		name = name.ToLower().Trim().Replace(" ", "");

		string[] split = name.Split(new Char[] { '-' });
		string partName = "";
		for (int index = 0; index < split.Length; index++)
		{
			partName = split[index];
			split[index] = char.ToUpper(partName[0]) + partName.Substring(1);
		}
		return string.Join("-", split);
	}
	#endregion

}
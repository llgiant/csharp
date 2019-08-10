using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public enum PlayerType
{
    Human = 0,
    Robot1 = 1,
    Robot2 = 2
}
class Player
{
    #region " Локальные переменные "
    private string _name = " ";
    private PlayerType _playerType = PlayerType.Human;
    private string _fishka = "0";
    #endregion

    #region " Конструкторы "
    public Player() : this("Робот") { }
    public Player(String name) : this(name, PlayerType.Human) { }
    public Player(String name, PlayerType PlayerType) : this(name, PlayerType.Human, "o") { }

    public Player(String name, PlayerType playerType, string fishka)
    {
        Name = name;
        Type = playerType;
        Fishka = fishka;
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
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
    private string _fishka = "о";
    #endregion

    #region " Конструкторы "
    public Player() : this("Null", PlayerType.Human, "o") { }

    public Player(string name, PlayerType playerType, string fishka)
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
            if (value > (PlayerType)1 || value < 0) { throw new Exception("В игре всего 3 типа игрока"); }
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
            _fishka = value.ToLower();
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

    #region Сериализация
    public static Player Deserialize(string strData)
    {
        //проверки strData
        if (string.IsNullOrEmpty(strData)) { throw new ArgumentException("Данные игры отсутствуют"); }

        string[] strArrayData = strData.Split(new char[] { '|' });

        //проверки strArrayData
        if (strArrayData == null || strArrayData.Length != 3) { throw new Exception("Данные не верные или повреждены"); }

        return new Player(strArrayData[0], (PlayerType)int.Parse(strArrayData[1]), strArrayData[2]);
    }
    public string Serialize() { return string.Join("|", new string[] { _name, _playerType == PlayerType.Human ? "0" : "1", _fishka }); }
    #endregion
}
using System;
using System.IO;

class Cell
{
    #region " Локальные переменные "
    private string _value = " ";
    #endregion

    #region " Конструкторы "
    public Cell() { }
    #endregion

    #region Свойства
    public bool IsEmpty { get { return _value == " "; } }
    public string Value
    {
        get { return _value; }
        set
        {
            if (string.IsNullOrEmpty(value)) { throw new Exception("Значение клетки не может быть пустым"); }
            if (!" xo".Contains(value)) { throw new Exception("Клетка должна принимать значение \" \" или \"о\" или \"х\" "); }
            _value = value;
        }
    }
    #endregion

    #region Функции
    public void Clear() { _value = " "; }
    #endregion

    #region Сериализация
    public static Cell Deserialize(string strData) { return new Cell() { Value = strData }; }
    public string Serialize() { return _value; }
    #endregion
}


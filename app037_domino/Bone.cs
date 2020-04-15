using System;
using System.Collections.Generic;
using System.IO;

class Bone : ISerialize
{
    private int _left = 0;
    private int _right = 0;
    #region Конструкторская
    public Bone() { }
    public Bone(int left, int right)
    {
        Left = left;
        Right = right;
    }
    #endregion

    #region Свойства
    public int Left
    {
        get { return _left; }
        set
        {
            if (value < 0 || value > 6) { throw new Exception("Значение должно быть в диапазоне от 0 до 6"); } else { _left = value; }
            if (value < 0 || value > 6) { throw new Exception("Значение должно быть в диапазоне от 0 до 6"); } else { _right = value; }
        }
    }
    public int Right
    {
        get { return _right; }
        set
        {
            if (value < 0 || value > 6) { throw new Exception("Значение должно быть в диапазоне от 0 до 6"); } else { _right = value; }
        }
    }
    public int Rank { get { return _left + _right; } }
    public bool isDouble { get { return _left == _right; } }
    public string Image { get { return $"[{_left}|{_right}]"; } }
    #endregion

    #region Функции
    public bool Contains(int number) { return _left == number || _right == number; }


    #endregion

    #region Методы
    public void Rotate()
    {
        int safeLeft = _left;
        _left = _right;
        _right = safeLeft;
    }
    #endregion

    #region Сериализация
    public object Deserialize(BinaryReader binaryReader)
    {
        Bone bone = new Bone();
        bone.Left = binaryReader.ReadInt32();
        bone.Right = binaryReader.ReadInt32();
        object obj = bone;
        return obj;
    }
    public void Serialize(BinaryWriter binaryWriter)
    {
        binaryWriter.Write(_left);
        binaryWriter.Write(_right);
        
    }
    #endregion
}


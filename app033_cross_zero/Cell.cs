using System;

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
	public string Value { get { return _value; } set { _value = value; } }
	#endregion

	#region Функции
	public void Clear() { _value = " "; }

	#endregion
}


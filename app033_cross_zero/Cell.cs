using System;

class Cell
{
	#region " Локальные переменные "
	private string _name = "";
	private string _value = " ";
	#endregion

	#region " Конструкторы "
	public Cell(int index)
	{
		switch (index)
		{
			case 1: _name = "a1"; break;
			case 2: _name = "a2"; break;
			case 3: _name = "a3"; break;

			case 4: _name = "b1"; break;
			case 5: _name = "b2"; break;
			case 6: _name = "b3"; break;

			case 7: _name = "c1"; break;
			case 8: _name = "c2"; break;
			case 9: _name = "c3"; break;
		}
	}
	#endregion

	#region Свойства
	public string Name { get { return _name; } }
	public bool IsEmpty { get { return _value == " "; } }
	public string Value { get { return _value; } set { _value = value; } }
	#endregion

	#region Функции
	public void Clear() { _value = " "; }
	#endregion
}


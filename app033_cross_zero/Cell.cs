using System;

class Cell
{
	#region " Локальные переменные "
	private string _name = "";
	private string _value = " ";
	string _strLetter = " abcdefghijklmnopqrstuvwxyz";

	#endregion

	#region " Конструкторы "
	public Cell(int index, int fieldSize)
	{
		//Передаается индекс например если поле 5 на 5 то передается индекс от 1 до 25
		//и поле должно заполлняться по индексу 
		//1 - а1, 2 - a2, 3 - a3, 4 - a4,  5 - a5 - 1-й ряд
		//6 - b1, 7 - b2, 8 - b3, 9 - b4, 10 - b5 - 2-й ряд
		//11 -c1, 12 - c2, 13 - c3, 14 - c4, 15 - c5 - 3й 



		//получаем ряд

		string row = "";
		int column = 0;

		if (index <= fieldSize) { row = index + ""; column = 1; }
		else if (index > fieldSize)
		{
			column = index % fieldSize > 0 ? index / fieldSize + 1 : index / fieldSize;

			row = index % fieldSize > 0 ? index % fieldSize + "" : fieldSize + "";
		}
		else
		{
			throw new ArgumentException("Индекс ячейки должен принимать значения от 1 до 9.");
		}
		_name = _strLetter[column] + row;
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


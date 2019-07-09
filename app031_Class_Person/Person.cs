using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Person
{
	#region "Локальные переменные"
	private string _firstName;
	private string _lastName;
	private int _oldYears;
	private bool _isMale;
	#endregion

	#region "Свойства переменных"
	public string FirstName
	{
		get { return _firstName; }
		set
		{
			if (_validation(value) == "Строка прошла валидацию")
			{
				value = _normalize(value);
				_firstName = value;
			}
		}
	}

	public string LastName
	{
		get { return _lastName; }
		set
		{
			if (_validation(value) == "Строка прошла валидацию")
			{
				value = _normalize(value);
				_lastName = value;
			}

		}
	}

	public int OldYears
	{
		get { return _oldYears; }
		set
		{
			if (value > 0 && value < 150)
			{
				_oldYears = value;
			}
		}
	}

	public bool IsMale
	{
		get { return _isMale; }
		set { _isMale = value; }
	}

	public string FullName { get { return (_firstName + " " + _lastName).Trim(); } }
	#endregion

	#region "Функции"
	private static string _validation(string name)
	{
		int count = 0; // счетчик дефисоф
		if (string.IsNullOrWhiteSpace(name)) { return "Строка не прошла валидацию"; }

		foreach (char letter in name)
		{
			if (!char.IsLetter(letter))
			{
				if (letter == '-' && count < 1) { count++; continue; }
				else if (char.IsWhiteSpace(letter)) { continue; }
				else { return "Строка не прошла валидацию"; }
			}
		}
		return "Строка прошла валидацию";
	}

	private static string _normalize(string name)
	{
		int count = 0;          //Счетчик начала слова
		char predSym = ' ';     // Предыдущая буква
		char sledSym = ' ';
		String modName = "";
		String newName = "";
		int index = 0;          // Индекс строкового массива newName

		if (name.Contains(' '))
		{
			foreach (char letter in name) { if (letter == ' ') { continue; } else { modName += letter; } }
		}

		foreach (char letter in modName)
		{
			if (index + 1 != modName.Length) { sledSym = modName[index + 1]; }

			if (char.IsLetter(letter))
			{
				count++;
				if (count == 1) { newName += char.ToUpper(letter); }
				else { newName += char.ToLower(letter); }
			}
			else if (letter == '-' && char.IsLetter(predSym) && char.IsLetter(sledSym))
			{
				newName += letter;
				count = 0;
			}
			predSym = letter;
			index++;

		}

		for (index = 0; index < name.Length; index++)
		{

		}
		return newName;
	}
	#endregion


}


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
			if (!string.IsNullOrWhiteSpace(value))
			{
				_firstName = value;
			}
		}
	}

	public string LastName
	{
		get { return _lastName; }
		set { _lastName = value; }
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

	public string FullName { get { return (_firstName + " " + _lastName).Trim() + _oldYears + "лет"; } }

	#endregion

	#region "Функции"
	public static string Validation(string name)
	{
		int count = 0;
		if (string.IsNullOrWhiteSpace(name)) { return "Имя не задано или состоит только из пробелов"; }

		foreach (char letter in name)
		{
			if (!char.IsLetter(letter))
			{
				if (letter == '-') { continue; count++ }
				else { return "Имя должно содержать только буквы"; }
			}
		}
		return "";
	}

	public static string Normalize(string name)
	{
		char predSym = ' ';
		char sledSym = ' ';
		String newName = "";



		for (int i = 0; i < name.Length; i++)
		{
			if (i + 1 != name.Length) { sledSym = name[i + 1]; }
			if (char.IsWhiteSpace(name[i]) || name[0] == '-') { continue; } //проверка на пробелы и на тире в первом символе
			if ((char.IsLetter(name[i]) && predSym == ' ') || char.IsLetter(name[i]) && predSym == '-')
			{

				newName += char.ToUpper(name[i]);
			}
			else
			{
				if (!char.IsLetter(sledSym)) { newName += ' '; continue; }
				newName += char.ToLower(name[i]);
			}

			predSym = name[i];
		}



		return newName;
	}

	#endregion


}


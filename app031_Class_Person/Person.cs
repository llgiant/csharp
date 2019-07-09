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

	#region "Свойства"
	public string FirstName
	{
		get { return _firstName; }
		set
		{
			if (_validation(value) == "")
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
			if (_validation(value) == "")
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
		if (string.IsNullOrWhiteSpace(name)) { return " "; }

		foreach (char letter in name)
		{
			if (!char.IsLetter(letter))
			{
				if (letter == '-' && count < 1) { count++; continue; }
				else if (char.IsWhiteSpace(letter)) { continue; }
				else { return "Ошибка в имени/фамилии, введены не буквы"; }
			}
		}
		return string.Empty;
	}

	private static string _normalize(string name)
	{
		name = name.Trim().ToLower().Replace(" ", "");

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


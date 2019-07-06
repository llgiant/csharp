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

	public string FullName { get { return (_firstName + " " + _lastName).Trim(); } }
	#endregion



}


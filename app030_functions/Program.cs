using System;

class Program
{
	static Random rnd = new Random();

	static void Main()
	{
		Console.InputEncoding = System.Text.Encoding.UTF8;
		Console.OutputEncoding = System.Text.Encoding.UTF8;
		Console.WriteLine("========================================================================");
		Console.WriteLine("Функции");
		Console.WriteLine("========================================================================");
		Console.WriteLine();
		appBegin:


		appExit:
		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Выйти из программы [y/n]?");
		if (Console.ReadLine().Trim().ToLower() == "n" ) { goto appBegin; }
	}

	public static string Validation(string name)
	{

		if (string.IsNullOrWhiteSpace(name)) { return "Имя не задано или состоит только из пробелов"; }

		foreach (char letter in name)
		{
			if (!char.IsLetter(letter))
			{
				if (letter == '-') { continue; }
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
			if(i + 1 != name.Length) { sledSym = name[i + 1]; }
			if (char.IsWhiteSpace(name[i]) || name[0] == '-') { continue; } //проверка на пробелы и на тире в первом символе
			if ((char.IsLetter(name[i]) && predSym == ' ') || char.IsLetter(name[i]) && predSym == '-')
			{
				
					newName += char.ToUpper(name[i]);
			}
			else {
				if (!char.IsLetter(sledSym)) { newName += ' '; continue; }
				newName += char.ToLower(name[i]);
			}

			predSym = name[i];
		}



		return newName;
	}




}

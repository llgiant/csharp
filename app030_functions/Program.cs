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

		//Пустота
		// Пробелы
		// буквы

		appExit:
		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Выйти из программы [y/n]?");
		string eq = Console.ReadLine();
		if (eq == "n" || eq == "N") { goto appBegin; }
	}

	public static string Validation(string name)
	{
		if (string.IsNullOrWhiteSpace(name)) { return "Имя не задано или состоит только из пробелов"; }
		foreach (char symbol in name) { if (!char.IsLetter(symbol)) { return "Имя должно состоять только из букв"; } }

		return "";
	}

	public static string Normalize(string name)
	{






		return name;
	}
}

using System;

class Program
{
	static Random rnd = new Random();

	static void Main()
	{
		Console.InputEncoding = System.Text.Encoding.UTF8;
		Console.OutputEncoding = System.Text.Encoding.UTF8;
		Console.WriteLine("========================================================================");
		Console.WriteLine("Проверка введенных данных в свойствах класса Person");
		Console.WriteLine("========================================================================");
		Console.WriteLine();
		appBegin:

		Console.WriteLine("\nВведите свое имя:");
		Person user = new Person();
		user.FirstName = Console.ReadLine();

		Console.WriteLine("\nВведите свою фамилию:");
		user.LastName = Console.ReadLine();

		//Console.WriteLine("\nСколько вам лет?:");
		//user.OldYears = int.Parse(Console.ReadLine());

		//Console.WriteLine("\nВведите пол: \"m\", если вы мужчина и \"f\", если вы женщина:");
		//user.IsMale = Console.ReadLine().Trim().ToLower() == "m" ? user.IsMale = true : user.IsMale = false;

		Console.WriteLine("\nПолное имя: " + user.FullName);

		appExit:
		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Выйти из программы [y/n]?");
		if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }

	}
}

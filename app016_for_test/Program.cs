using System;

class Program
{
	static void Main()
	{
		Console.WriteLine("========================================================================");
		Console.WriteLine("Последовательно запросите у пользователя два целых числа от 1 до 20 каждое,\nНайдите их произведение, при этом не не используя операцию умножения.");
		Console.WriteLine("========================================================================");
		Console.WriteLine();
		appBegin:
		Console.WriteLine("Введите первое целое число от 1 до 20:");
		insertNumber1:
		int number1 = int.Parse(Console.ReadLine());

		if (number1 < 1)
		{
			Console.WriteLine("Вы ввели число меньше 1, попробуйте еще раз");
			goto insertNumber1;
		}
		else if (number1 > 20)
		{
			Console.WriteLine("Вы ввели число больше 20, попробуйте еще раз");
			goto insertNumber1;
		}

		Console.WriteLine("Введите второе целое число:");
		insertNumber2:
		int number2 = int.Parse(Console.ReadLine());
		if (number2 < 1)
		{
			Console.WriteLine("Вы ввели число меньше 1, попробуйте еще раз");
			goto insertNumber2;
		}
		else if (number2 > 20)
		{
			Console.WriteLine("Вы ввели число больше 20, попробуйте еще раз");
			goto insertNumber2;
		}
		int multiplication = 0;

		for (int i = 0; i < number1; i++)
		{
			multiplication += number2;
		}

		Console.WriteLine($"произведение чисел {number1} и {number2} = {multiplication}");

		

		appExit:
		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Выйти из программы [y/n]?");
		string eq = Console.ReadLine();
		if (eq == "n" || eq == "N") { goto appBegin; }
	}
}

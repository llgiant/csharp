using System;

class Program
{
	static Random rnd = new Random();

	static void Main()
	{
		Console.WriteLine("========================================================================");
		Console.WriteLine("Два двузначных числа, записанных одно за другим, образуют четырёхзначное число, которое делится на их произведение.Вывести на консоль эти числа.");
		Console.WriteLine("========================================================================");
		Console.WriteLine();
		appBegin:

		string strbigNumber = "";
		int bigNumber = 0;
		int mult = 0;

		for (int num1 = 10; num1 < 100; num1++)
		{
			for (int num2 = 10; num2 < 100; num2++)
			{
				bigNumber = num1 * 100 + num2;
				mult = num1 * num2;
				if (bigNumber % mult == 0)
				{
					strbigNumber += $"{num1} {num2}";
					if (num1 < 99)
					{
						strbigNumber += ", ";
					}
				}
			}
		}





		Console.WriteLine($"четырёхзначное число, которое делится на произведение двух двузначных: ");
		Console.WriteLine(strbigNumber);

		appExit:
		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Выйти из программы [y/n]?");
		string eq = Console.ReadLine();
		if (eq == "n" || eq == "N") { goto appBegin; }
	}
}

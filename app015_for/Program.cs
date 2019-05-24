using System;

class Program
{
	static void Main()
	{
		Console.WriteLine("========================================================================");
		Console.WriteLine("Что будет делать программа?");
		Console.WriteLine("========================================================================");
		Console.WriteLine();


		Console.WriteLine("Введите число больше нуля, но меньше 1001:");
		inputNumber:
		int number = int.Parse(Console.ReadLine());
		if (number < 0)
		{
			Console.WriteLine("Число должно быть больше нуля.\nПовторите:");
			goto inputNumber;
		}
		else if (number > 1000)
		{
			Console.WriteLine("Число должно быть меньше 1000.\nПовторите:");
			goto inputNumber;
		}

		if (number < 2) { Console.WriteLine("Число ни простое ни составное"); }
		else if (number == 2) { Console.WriteLine("Число простое"); }
		else if (number % 2 == 0) { Console.WriteLine("Число составное"); }
		else
		{
			bool isSimple = false;
			for (int div = 3; div < number; div++)
			{
				if (number % div == 0)
				{
					isSimple = false;
					break;
				}
				isSimple = true;
			}
			Console.WriteLine("Число " + (isSimple ? "простое" : "составное"));
		}

		appExit:
		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Выйти из программы [y/n]?");
		string eq = Console.ReadLine();
		if (eq == "n" || eq == "N") { goto inputNumber; }
	}
}

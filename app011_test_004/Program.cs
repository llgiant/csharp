using System;

class Program
{
	static Random rnd = new Random();
	static void Main()
	{
		Console.WriteLine("========================================================================");
		Console.WriteLine("Игра, угадай число!");
		Console.WriteLine("========================================================================");
		Console.WriteLine();

		appBegin:
		int number = rnd.Next(1, 101);
		Console.WriteLine("Привет, я загадал число от 1 до 100. Попрбуй угдать, у вас 10 попыток.\nТвой вариант:");
		int count = 0;
		int lastChance = 10;

		inputNumber:
		int variant = int.Parse(Console.ReadLine());
		lastChance--;
		if (variant < 1)
		{
			Console.WriteLine("\nЧисло должно быть больше 1\nПовторите:");
			goto inputNumber;
		}
		else if (variant > 100)
		{
			Console.WriteLine("\nЧисло должно быть меньше 100\nПовторите:");
			goto inputNumber;
		}

		count++;
		if (variant == number)
		{
			Console.WriteLine("\nМолодец!!! Ты угадал число!!!");
			Console.WriteLine($"На это тебе потребовалось {count} попыток");
			goto appExit;
		}

		if (count < 10)
		{
			Console.Write($"\nЯ загадал число {(variant > number ? "меньше" : "больше")} {variant}, у вас осталось {lastChance} попыток, еще вариант:");
			goto inputNumber;
		}
		else
		{
			Console.WriteLine();
			Console.WriteLine($"Я загадал число {number}, но к соожалению вы использовали все свои попытки!");
		}

		appExit:

		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Выйти из программы [y/n]?");
		string eq = Console.ReadLine();
		if (eq == "n" || eq == "N") { goto appBegin; }
	}

}


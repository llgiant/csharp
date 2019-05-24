using System;

class Program
{
	static void Main()
	{
		Console.WriteLine("========================================================================");
		Console.WriteLine("Что будет делать программа?");
		Console.WriteLine("========================================================================");
		Console.WriteLine();
		appBegin:

		Console.WriteLine("Введите первое целое число:");
		int number1 = int.Parse(Console.ReadLine());
		Console.WriteLine();

		Console.WriteLine("Введите второе целое число:");
		int number2 = int.Parse(Console.ReadLine());
		Console.WriteLine();

		Console.WriteLine("Выбирете тип операции:");
		Console.WriteLine("1) Сложение");
		Console.WriteLine("2) Вычитание");
		Console.WriteLine("3) Умножение");
		Console.WriteLine("4) Деление");
		Console.WriteLine("5) Остаток от дедления");
		Console.WriteLine("6) Среднее арифметическое");
		Console.WriteLine("7) Максимум");
		Console.WriteLine("8) Минимум");

		inputOperation:
		int number3 = int.Parse(Console.ReadLine());

		switch (number3)
		{
			case 1:
				Console.WriteLine($"\"Операция сложения\":\n{number1} + {number2} = {number1 + number2}");
				break;
			case 2:
				Console.WriteLine($"\"Операция вычитания\":\n{number1} - {number2} = {number1 - number2}");
				break;
			case 3:
				Console.WriteLine($"\"Операция умножения\":\n{number1} * {number2} = {number1 * number2}");
				break;
			case 4:
				Console.WriteLine($"\"Операция деления\":\n{number1} / {number2} = {(double)number1 / number2}");
				break;
			case 5:
				Console.WriteLine($"\"Операция остаток от деления\":\n{number1} % {number2} = {number1 % number2}");
				break;
			case 6:
				Console.WriteLine($"\"Операция среднее арифметическое\":\n({number1} + {number2}) / 2 = {(number1 + number2) / 2}");
				break;
			case 7:
				Console.WriteLine($"\"Операция максимум\":\n{(number1 > number2 ? number1 : number2)}");
				break;
			case 8:
				Console.WriteLine($"\"Операция минимум\":\n{(number1 < number2 ? number1 : number2)}");
				break;

			default:
				Console.WriteLine($"Такой операции нет в списке, выбирете операцию из списка: ");
				goto inputOperation;
		}




		appExit:
		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Выйти из программы [y/n]?");
		string eq = Console.ReadLine();
		if (eq == "n" || eq == "N") { goto appBegin; }
	}
}

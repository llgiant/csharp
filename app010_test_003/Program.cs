using System;

class Program
{
	static void Main()
	{
		Console.WriteLine("========================================================================");
		Console.WriteLine("Мини калькулятор");
		Console.WriteLine("========================================================================");
		Console.WriteLine();


		Console.WriteLine("Введите первое число больше нуля:");
		inputNumber:
		int number1 = int.Parse(Console.ReadLine());
		if (number1 <= 0)
		{
			Console.WriteLine("Ваше число не соответствует условию.\nВведите число большее нуля:");
			goto inputNumber;
		}

		Console.WriteLine();
		Console.WriteLine("Введите второе число больше нуля:");
		inputNumber2:
		int number2 = int.Parse(Console.ReadLine());
		if (number2 <= 0)
		{
			Console.WriteLine("Ваше число не соответствует условию.\nВведите число большее нуля:");
			goto inputNumber2;
		}
		Console.WriteLine();

		Console.WriteLine("Какую операцию выполнить?");
		Console.WriteLine("a) Сложение");
		Console.WriteLine("b) Вычитание");
		Console.WriteLine("c) Умножение");
		Console.WriteLine("d) Деление");
		Console.WriteLine("e) Остаток от деления");
		Console.WriteLine("f) Максимум");
		Console.WriteLine("g) Минимум");
		Console.WriteLine("h) Среднее арифметическое");
		inputOperation:
		string operation = Console.ReadLine();
		if (operation == "a" || operation == "A")
		{
			Console.WriteLine("Операция сложения");
			Console.WriteLine($"{number1} + {number2} = {number1 + number2}");
		}
		else if (operation == "b" || operation == "B")
		{
			Console.WriteLine("Операция вычитания");
			Console.WriteLine($"{number1} - {number2} = {number1 - number2}");
		}
		else if (operation == "c" || operation == "C")
		{
			Console.WriteLine("Операция умножения");
			Console.WriteLine($"{number1} * {number2} = {number1 * number2}");
		}
		else if (operation == "d" || operation == "D")
		{
			Console.WriteLine("Операция деления");
			Console.WriteLine($"{number1} / {number2} = {number1 / number2}");
		}
		else if (operation == "e" || operation == "E")
		{
			Console.WriteLine("Операция остаток от деления");
			Console.WriteLine($"{number1} % {number2} = {number1 % number2}");
		}
		else if (operation == "f" || operation == "F")
		{
			if (number1 > number2)
			{
				Console.WriteLine("Операция найти максимум");
				Console.WriteLine($"{number1} > {number2} = {number1}");
			}
			else
			{
				Console.WriteLine("Операция найти максимум");
				Console.WriteLine($"{number1} < {number2} = {number2}");
			}

		}
		else if (operation == "g" || operation == "G")
		{
			if (number1 < number2)
			{
				Console.WriteLine("Операция найти минимум");
				Console.WriteLine($"{number1} < {number2} = {number1}");
			}
			else
			{
				Console.WriteLine("Операция найти минимум");
				Console.WriteLine($"{number1} > {number2} = {number2}");
			}
		}
		else if (operation == "h" || operation == "H")
		{
			Console.WriteLine("Операция найти среднее арифметическое");
			Console.WriteLine($"({number1} + {number2}) / 2 = {(number1 * number2) / 2}");
		}
		else
		{
			Console.WriteLine("Указанной операции не существует.\nПовторите ввод");
			goto inputOperation;
		}

		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Выйти из программы [y/n]?");
		string eq = Console.ReadLine();
		if (eq == "n" || eq == "N") { goto inputOperation; }
	}
}

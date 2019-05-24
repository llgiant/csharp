using System;

class Program
{
	static void Main()
	{
		Console.WriteLine("========================================================================");
		Console.WriteLine("Простейшие элементарные арифметические операции");
		Console.WriteLine("========================================================================");
		Console.WriteLine();

		Console.WriteLine("Введите первое целое число:");
		int number1 = int.Parse(Console.ReadLine());
		Console.WriteLine();

		Console.WriteLine("Введите второе целое число:");
		int number2 = int.Parse(Console.ReadLine());
		Console.WriteLine();

		Console.WriteLine("Операция сложения:");
		Console.WriteLine($"{number1} + {number2} = {number1 + number2}");
		Console.WriteLine();

		Console.WriteLine("Операция вычитания:");
		Console.WriteLine($"{number1} - {number2} = {number1 - number2}");
		Console.WriteLine();

		Console.WriteLine("Операция умножения:");
		Console.WriteLine($"{number1} * {number2} = {number1 * number2}");
		Console.WriteLine();

		Console.WriteLine("Операция деления");
		Console.WriteLine($"{number1} / {number2} = {(double)number1 / number2}");
		Console.WriteLine();

		Console.WriteLine("Остаток от делания");
		Console.WriteLine($"{number1} % {number2} = {number1 % number2}");

		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Для выхода из программы нажмите любую клавишу...");
		Console.ReadKey();
	}
}

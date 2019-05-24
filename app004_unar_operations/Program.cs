using System;

class Program
{
	static void Main()
	{
		Console.WriteLine("========================================================================");
		Console.WriteLine("Унарные арифметические операции");
		Console.WriteLine("========================================================================");
		Console.WriteLine();

		Console.WriteLine("Введите любое целое число: ");
		int N1 = int.Parse(Console.ReadLine());
		Console.WriteLine();

		Console.WriteLine("Введите любое целое число: ");
		int N2 = int.Parse(Console.ReadLine());
		Console.WriteLine();

		int prevolution = N1;

		Console.WriteLine("1) Инкремент: ");
		N1++;
		Console.WriteLine($"{prevolution}++ => {N1}");
		prevolution = N1;

		Console.WriteLine("2) Дикремент: ");
		N1--;
		Console.WriteLine($"{prevolution}-- => {N1} ");
		prevolution = N1;

		Console.WriteLine("3) Унарное сложение: ");
		N1 += N2;
		Console.WriteLine($"{prevolution} += {N2} => {N1} ");
		prevolution = N1;

		Console.WriteLine("4) Унарное вычитание: ");
		N1 -= N2;
		Console.WriteLine($"{prevolution} -= {N2} => {N1} ");
		prevolution = N1;

		Console.WriteLine("5) Унарное умножение");
		N1 *= N2;
		Console.WriteLine($"{prevolution} *= {N2} => {N1}");
		prevolution = N1;

		Console.WriteLine("6) Унарное деление");
		N1 /= N2;
		Console.WriteLine($"{prevolution} /= {N2} => {N1} ");
		prevolution = N1;

		Console.WriteLine("7) Унарное присвоение остатка от деления");
		N1 %= N2;
		Console.WriteLine($"{prevolution} %= {N2} => {N1}");

		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Для выхода из программы нажмите любую клавишу...");
		Console.ReadKey();
	}
}

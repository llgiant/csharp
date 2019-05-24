using System;

class Program
{
	static void Main()
	{
		Console.WriteLine("========================================================================");
		Console.WriteLine("Условные конструкции:");
		Console.WriteLine("========================================================================");
		Console.WriteLine();

		Console.WriteLine("Введите число большее нуля:");
		int number = int.Parse(Console.ReadLine());
		if (number > 0)
		{ Console.WriteLine("Ваше число соответствует условию"); }
		else
		{ Console.WriteLine("Ваше число не соответствует условию"); }
		Console.WriteLine();

		Console.WriteLine("Введите число от 10 до 50:");
		number = int.Parse(Console.ReadLine());
		if (number < 10 || number > 50)
		{ Console.WriteLine("Ваше число не соответствует условию"); }
		else
		{ Console.WriteLine("Ваше число соответствует условию"); }
		Console.WriteLine();

		Console.WriteLine("Введите число от 20 до 100 но не 50:");
		number = int.Parse(Console.ReadLine());
		if (number < 20)
		{
			Console.WriteLine("Число не может быть меньше 20");
		}
		else if (number > 200)
		{
			Console.WriteLine("Число не может быть больше 100");
		}
		else if (number == 50)
		{
			Console.WriteLine("Число не может быть равно 50");
		}
		else
		{
			Console.WriteLine("Ваше число соответствует условию");
		}
		Console.WriteLine();

		Console.WriteLine("Введите число больше 10:");
		inputNumber:
		number = int.Parse(Console.ReadLine());
		if (number < 10)
		{
			Console.WriteLine("Ваше число не соответствует условию.\nПопробуйте снова:");
			goto inputNumber;
		}



		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Для выхода из программы нажмите любую клавишу...");
		Console.ReadKey();
	}
}

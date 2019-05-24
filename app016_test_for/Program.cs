using System;

class Program
{
	static void Main()
	{
		Console.WriteLine("========================================================================");
		Console.WriteLine("Последовательно запросите у пользователя два числа: S (денежная сумма) и N (число лет от 2 до 50).\nГрамотно оформите решение задачи: в СберКассу на трёхпроцентный вклад положили S рублей.\nКакой станет сумма вклада через N лет ? ");
		Console.WriteLine("========================================================================");
		Console.WriteLine();
		appBegin:

		double summ = 0;

		Console.WriteLine("Введите сумму денежного вклада в рублях:");
		insertNumber1:
		double number1 = double.Parse(Console.ReadLine());

		if (number1 <= 0)
		{
			Console.WriteLine($"Денежная сумма доложна быть больше {number1}, попробуйте еще раз");
			goto insertNumber1;
		}
		Console.WriteLine();
		Console.WriteLine("Введите срок вклада от 2х до 50ти лет:");
		insertNumber2:
		int number2 = int.Parse(Console.ReadLine());
		if (number2 < 2)
		{
			Console.WriteLine("Вы ввели число меньше 2, попробуйте еще раз");
			goto insertNumber2;
		}
		else if (number2 > 50)
		{
			Console.WriteLine("Вы ввели число больше 50, попробуйте еще раз");
			goto insertNumber2;
		}

		for (int i = 0; i < number2; i++)
		{
			summ += number1 * 0.03;
		}
		Console.WriteLine();
		Console.WriteLine($"Через {number2} лет сумма вклада станет {summ + number1} рублей");


		appExit:
		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Выйти из программы [y/n]?");
		string eq = Console.ReadLine();
		if (eq == "n" || eq == "N") { goto appBegin; }
	}
}

using System;

class Program
{
	static Random rnd = new Random();

	static void Main()
	{
		Console.WriteLine("========================================================================");
		Console.WriteLine("Решение задач на цикл While");
		Console.WriteLine("========================================================================");
		Console.WriteLine();
		appBegin:

		//Переменные для задания №1 - Через запятую члены арифметической прогресси, в которой а = 1, s = 3, a(n) < 100
		int a = 1;
		int s = 3;
		string strArifmProg = "";
		int countRound = 0;

		//Переменные для задания №2 - Через запятую числа, чьи факториалы меньше максимумма типа данных int
		int factorial = 1;
		string strFactorial = "";
		int factorialNumber = 1;

		//Переменные для задания №3 - Через запятую последовательность чисел таких, что каждое число является суммой двух предыдущих чисел, 
		//при этом последний член последовательности не больше 500, а первые два это числа 1,2
		int firstNumber = 1;
		int secondNumber = 2;
		int lastNumber = 0;
		string strLastNumber = "1, 2, ";

		//Переменные для задания №4
		//Последовательность чисел таких, что сумма двух соседних чисел не превышает 100, а первое число 1, a, b, c, d, e, f....
		//числа не должны повторяться и их суммы тоже.
		int number = 1;
		int summ = 0;
		string strNumber = "";

		//Задание №1
		//Через запятую члены арифметической прогресси, в которой а = 1, s = 3, a(n) < 100
		while (a < 100)
		{
			if (countRound > 0) { strArifmProg += ", "; }
			strArifmProg += a;
			a += s;
			countRound++;
		}
		countRound = 0;

		//Задание №2 
		//Через запятую числа, чьи факториалы меньше максимумма типа данных int
		//(вывод)Факториал 1 = 1; Факториал 2 = 2; Факториал 3 = 6 итд
		//факториал 1 = 1 * 1 = 1
		//			1 = 1 * 2 =  2
		//			3 = 1 * 2 * 3 =6
		//			4 = 1 * 2 * 3 * 4 = 24
		//			5 = 1 * 2 * 3 * 4 * 5 = 120
		//			6 = 1 * 2 * 3 * 4 * 5 * 6 = 720		
		while (true)
		{
			factorialNumber *= factorial;
			if (factorialNumber < 0) break;
			if (countRound > 0) { strFactorial += "; "; }
			strFactorial += $"!{factorial} = {factorialNumber}";
			factorial++;
			countRound++;
		}
		countRound = 0;

		//Задание №3	Через запятую последовательность чисел таких, что каждое число является суммой двух предыдущих чисел, 
		//при этом последний член последовательности не больше 500, а первые два это числа 1,2
		while (true)
		{
			lastNumber = firstNumber + secondNumber;
			firstNumber = secondNumber;
			secondNumber = lastNumber;
			if (lastNumber >= 500) { break; }
			if (countRound > 0) { strLastNumber += ", "; }
			strLastNumber += lastNumber;
			countRound++;
		}
		countRound = 0;


		//Задание №4	Последовательность чисел таких, что сумма двух соседних чисел не превышает 100, а первое число 1, a, b, c, d, e, f ....
		//числа не должны повторяться и их суммы тоже.

		while (summ < 100)
		{
			summ = 0;

			if (countRound > 0)
			{
				strNumber += ", ";

			}
			strNumber += number;
			summ += (number - 1) + (number + 1);
			number++;
			countRound++;
		}

		//Вывод Задания №1 
		//Через запятую члены арифметической прогресси, в которой а = 1, s = 3, a(n) < 100
		Console.WriteLine("Члены арифметической прогресси от 1 до 100 с шагом 3:");
		Console.WriteLine(strArifmProg);
		Console.WriteLine();

		//Вывод Задания №2	
		//Через запятую числа, чьи факториалы меньше максимумма типа данных int
		Console.WriteLine("Факториал меньше максимумма типа данных int:");
		Console.WriteLine(strFactorial);
		Console.WriteLine();

		//Вывод Задания №3	
		//Через запятую последовательность чисел, где каждое число является суммой двух предыдущих чисел не больше 500
		Console.WriteLine("суммой двух предыдущих чисел:");
		Console.WriteLine(strLastNumber);
		Console.WriteLine();

		//Вывод Задания №4	Последовательность чисел таких, что сумма двух соседних чисел не превышает 100, а первое число 1, a, b, c, d, e, f ....
		//числа не должны повторяться и их суммы тоже.
		Console.WriteLine("Сумма двух соседних чисел не превышает 100:");
		Console.WriteLine(strNumber);
		Console.WriteLine();

		appExit:
		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Выйти из программы [y/n]?");
		string eq = Console.ReadLine();
		if (eq == "n" || eq == "N") { goto appBegin; }
	}
}




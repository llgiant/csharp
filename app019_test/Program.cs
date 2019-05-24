using System;

class Program
{
	static Random rnd = new Random();

	static void Main()
	{
		Console.WriteLine("========================================================================");
		Console.WriteLine("");
		Console.WriteLine("========================================================================");
		Console.WriteLine();
		appBegin:



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




		Console.WriteLine("Введите целое число от 1 до 500:");
		insertNumber3:
		int number3 = int.Parse(Console.ReadLine());

		if (number3 < 1)
		{
			Console.WriteLine($"Вы ввели число {number1}, которое меньше 1 попробуйте еще раз");
			goto insertNumber3;
		}
		else if (number3 > 500)
		{
			Console.WriteLine($"Вы ввели число {number1}, которое больше 500 попробуйте еще раз");
			goto insertNumber3;
		}









		string strNotDevide235 = "";



		double summ = 0;

		string strCount = "";


		int intSumm = 0;


		string strCount46 = "";

		int proizvedenie13 = 1;

		int intSumm200 = 0;



		for (int i = number3; i < 500; i++)
		{
			if (i % 2 != 0 && i % 3 != 0 || i % 5 != 0)
			{
				strNotDevide235 += i;
				if (i < 500 - 1)
				{
					strNotDevide235 += ", ";
				}
			}
		}

		for (int i = 0; i < number2; i++)
		{
			summ += number1 * 0.03;
		}

		for (int i = 35; i < 87; i++)
		{
			if (i % 7 == 1 || i % 7 == 2 || i % 7 == 5)
			{
				strCount += i;
				if (i <= 85)
				{
					strCount += ", ";
				}
			}
		}

		for (int i = 1; i < 50; i++)
		{
			if (i % 5 == 0 || i % 7 == 0)
			{
				intSumm += i;
			}
		}

		for (int i = 10; i < 100; i++)
		{
			if (i % 4 == 0 && i % 6 != 0)
			{
				strCount46 += i;

				if (i < 92)
				{
					strCount46 += ", ";
				}
			}
		}

		for (int i = 10; i < 100; i++)
		{
			if (i % 13 == 0 && i % 2 != 0)
			{
				proizvedenie13 *= i;

			}
		}


		for (int i = 100; i < 200; i++)
		{
			if (i % 17 == 0)
			{
				intSumm200 += i;


			}
		}


		//Задание №10
		//Два двузначных числа, записанных одно за другим, образуют четырёхзначное число, которое делится на их произведение.
		//Вывести на консоль эти числа.
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




		/*
			   Задание №11
			   Есть два двузначных числа А и В.
			   Из этих чисел составили 2 четырехзначных числа:
			   первое число -путем написания сначала числа А, затем В;
			   второе - сначала записали число В, затем А.
			   Найдите эти числа А и В если известно, что первое четырехзначное число нацело делится на 99, а второе на 49. 
		*/

		int fourDigitAb = 0;
		int fourDigitBa = 0;
		int countDigit = 0;
		string strDigit = "";



		for (int numA = 10; numA < 100; numA++)
		{
			for (int numB = 10; numB < 100; numB++)
			{
				fourDigitAb = numA * 100 + numB;
				fourDigitBa = numB * 100 + numA;

				if (fourDigitAb % 99 == 0 && fourDigitBa % 49 == 0)
				{
					if (countDigit > 0) { strDigit += ", "; }
					strDigit += $"[{numA} {numB}] ";
					countDigit++;
				}
			}
		}


		Console.WriteLine($"Через {number2} лет сумма вклада станет {summ + number1} рублей");
		Console.WriteLine();

		Console.WriteLine($"Числа при делении на 7 дают остаток 1, 2 или 5: \n{strCount}");
		Console.WriteLine();

		Console.WriteLine($"Cуммуа чисел(от 1 до 50), которые делятся на 5 или на 7: {intSumm}");
		Console.WriteLine();

		Console.WriteLine($"Двузначные числа, которые делятся на 4, но не делятся на 6: ");
		Console.WriteLine(strCount46);
		Console.WriteLine();

		Console.WriteLine($"произведения двузначных нечетных чисел кратных 13: { proizvedenie13}");
		Console.WriteLine();

		Console.WriteLine($"Cумма чисел от 100 до 200 кратных 17.: { intSumm200}");
		Console.WriteLine();

		Console.WriteLine($"Числа не превосходящие N и не делящиеся ни на одно из чисел 2, 3, 5:\n{ strNotDevide235}");
		Console.WriteLine();

		//вывод задачи №10
		Console.WriteLine($"четырёхзначное число, которое делится на произведение двух двузначных: ");
		Console.WriteLine(strbigNumber);

		//вывод задачи №11
		Console.WriteLine($"Найдите числа А и В если известно, что первое четырехзначное число AB нацело делится на 99, а второе BA на 49 \n{strDigit}");
		Console.WriteLine();




		appExit:
		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Выйти из программы [y/n]?");
		string eq = Console.ReadLine();
		if (eq == "n" || eq == "N") { goto appBegin; }
	}
}

using System;

class Program
{
	static void Main()
	{

		Console.WriteLine("========================================================================");
		Console.WriteLine("Даны целые числа от 20 до 50.\nВывести на консоль(через запятую) те из них, которые делятся на 3, но не делятся на 5.");
		Console.WriteLine("========================================================================");
		Console.WriteLine();
		appBegin:

		string strCount = "";
		int countNumbers = 0;

		for (int i = 20; i < 50; i++)
		{
			if (i % 3 == 0 && i % 5 != 0)
			{
				if (countNumbers > 0) { strCount += ", "; }
				strCount += i;
				countNumbers++;
			}
		}
		Console.WriteLine(strCount);


		appExit:
		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Выйти из программы [y/n]?");
		string eq = Console.ReadLine();
		if (eq == "n" || eq == "N") { goto appBegin; }
	}
}

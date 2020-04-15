using System;
class Program
{
	static Random rnd = new Random();
	static void Main()
	{
		Console.InputEncoding = System.Text.Encoding.UTF8;
		Console.OutputEncoding = System.Text.Encoding.UTF8;
		Console.WriteLine("========================================================================");
		Console.WriteLine("Игра палочки!\nИгроки ходят по очереди, вводят от 1 до 3 букв палочки над которыми надо убрать.\nПроигрывает тот, кто уберет последнюю палочку.");
		Console.WriteLine("========================================================================");
		appBegin:


		appExit:
		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Сыграть еще раз? [y/n]?");
		string eq = Console.ReadLine();
		if (eq == "y" || eq == "Y") { goto appBegin; }
	}
}

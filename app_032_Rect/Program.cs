using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
	static void Main()
	{
		Console.InputEncoding = System.Text.Encoding.UTF8;
		Console.OutputEncoding = System.Text.Encoding.UTF8;
		Console.WriteLine("========================================================================");
		Console.WriteLine("Прямоуголником");
		Console.WriteLine("========================================================================");
		Console.WriteLine();
		appBegin:

		Console.WriteLine("Введите ширину прямоугольника:");
		double width = double.Parse(Console.ReadLine());

		Console.WriteLine("Введите высоту прямоугольника:");
		double height = double.Parse(Console.ReadLine());

		Console.WriteLine("Введите \"X\" координату:");
		double xPos = int.Parse(Console.ReadLine());

		Console.WriteLine("Введите \"Y\" координату:");
		double yPos = int.Parse(Console.ReadLine());

		appExit:
		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Выйти из программы [y/n]?");
		if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }

	}
}

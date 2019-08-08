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
		Console.WriteLine("Прямоугольник");
		Console.WriteLine("========================================================================");
		Console.WriteLine();
		appBegin:

		Size size = new Size();

		Console.WriteLine("Введите ширину прямоугольника:");
		inputWidth:
		try
		{
			size.Width = double.Parse(Console.ReadLine());
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
			Console.WriteLine("Повторите:");
			goto inputWidth;
		}


		Console.WriteLine("Введите высоту прямоугольника:");
		inputHeight:
		try
		{
			size.Height = double.Parse(Console.ReadLine());
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
			Console.WriteLine("Повторите:");
			goto inputHeight;
		}

		Point point = new Point();
		Console.WriteLine("Введите \"X\" координату:");
		inputX:
		try
		{
			point.X = int.Parse(Console.ReadLine());
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
			Console.WriteLine("Повторите:");
			goto inputX;
		}
		Console.WriteLine("Введите \"Y\" координату:");
		inputY:
		try
		{
			point.Y = int.Parse(Console.ReadLine());
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
			Console.WriteLine("Повторите:");
			goto inputY;
		}


		appExit:
		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Выйти из программы [y/n]?");
		if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }

	}
}

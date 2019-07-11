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
		Console.WriteLine("Проверка введенных данных в свойствах класса Person");
		Console.WriteLine("========================================================================");
		Console.WriteLine();
		appBegin:



		appExit:
		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Выйти из программы [y/n]?");
		if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }

	}
}

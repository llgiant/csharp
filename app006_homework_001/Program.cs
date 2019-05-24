using System;

class Program
{
	static void Main()
	{
		Console.WriteLine("========================================================================");
		Console.WriteLine("Вычисление числа по заданному номеру столбца и строки и наоборот");
		Console.WriteLine("========================================================================");
		Console.WriteLine();

		Console.WriteLine("Введите количество столбцов: ");
		int columnCount = int.Parse(Console.ReadLine());
		Console.WriteLine();

		Console.WriteLine("Введите количество строк: ");
		int rowCount = int.Parse(Console.ReadLine());
		Console.WriteLine();

		Console.WriteLine("Введите номер столбца: ");
		int column = int.Parse(Console.ReadLine());
		Console.WriteLine();

		Console.WriteLine("Введите номер строки: ");
		int row = int.Parse(Console.ReadLine());
		Console.WriteLine();
		int result = columnCount * row - (columnCount - column);
		Console.WriteLine($"Результат: {result}");
		Console.WriteLine();

		Console.WriteLine("Введите целое число: ");
		result = int.Parse(Console.ReadLine());
		Console.WriteLine();

		Console.WriteLine($"Столбец: {result % columnCount}");
		Console.WriteLine($"Строка: {result / columnCount + 1}");


		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Для выхода из программы нажмите любую клавишу...");
		Console.ReadKey();
	}
}

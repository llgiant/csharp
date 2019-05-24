using System;

class Program
{
	static void Main()
	{
		Console.WriteLine("========================================================================");
		Console.WriteLine("Логические операторы");
		Console.WriteLine("========================================================================");
		Console.WriteLine();

		Console.WriteLine("Введите любое целое число: ");
		int N1 = int.Parse(Console.ReadLine());
		Console.WriteLine();

		Console.WriteLine("Введите любое целое число: ");
		int N2 = int.Parse(Console.ReadLine());
		Console.WriteLine();

		Console.WriteLine($"1) {N1} > {N2} - {N1 > N2} ");
		Console.WriteLine($"2) {N1} >= {N2} - {N1 >= N2}");
		Console.WriteLine($"3) {N1} < {N2} - {N1 < N2}");
		Console.WriteLine($"4) {N1} <= {N2} - {N1 <= N2}");
		Console.WriteLine($"5) {N1} == {N2} - {N1 == N2}");
		Console.WriteLine($"6) {N1} != {N2} - {N1 != N2}");


		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Для выхода из программы нажмите любую клавишу...");
		Console.ReadKey();
	}
}

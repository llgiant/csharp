using System;

class Program
{
	static void Main()
	{
		Console.WriteLine("========================================================================");
		Console.WriteLine("Что будет делать программа?");
		Console.WriteLine("========================================================================");
		Console.WriteLine();


		Console.WriteLine("Введите первое целое число:"); 
		int N1 = int.Parse(Console.ReadLine());
		Console.WriteLine();

		Console.WriteLine("Введите второе целое число:");
		int N2 = int.Parse(Console.ReadLine());
		Console.WriteLine();

		Console.WriteLine("Введите третье целое число:");
		int N3 = int.Parse(Console.ReadLine());
		Console.WriteLine();

		Console.WriteLine("Введите третье целое число:");
		int N4 = int.Parse(Console.ReadLine());
		Console.WriteLine();


		N1++;
		Console.WriteLine($"1) {N2} + {N1} - ({N3} - {N4}) = {N2 + N1 - (N3 - N4)} ");
		N2 %= 3; N3 += 2;
		Console.WriteLine($"2) ({N3} + 1) * {N1} - {N2} = {(N3 + 1) * N1 - N2} ");
		Console.WriteLine($"3) ({N4} * {N3}) - ({N2} * {N1}) = {(N4 * N3) - (N2 * N1)}");
		N4--; N3++; N2 /= 5;
		Console.WriteLine($"4) ({N3} + {N1}) * ({N2} + 5) = {(N3 + N1) * (N2 + 5)}");
		N2 *= (N1 - N3);
		Console.WriteLine($"5) {N3} / ({N2} + 1 + {N1}) = {(double)N3 / (N2 + 1 + N1)}");
		Console.WriteLine("----------------------------------------");
		Console.WriteLine($" N1 => {N1}; N2 => {N2}; N3 => {N3}; N4 => {N4} ");


		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Для выхода из программы нажмите любую клавишу...");
		Console.ReadKey();
	}
}

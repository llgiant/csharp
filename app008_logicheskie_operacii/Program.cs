using System;

class Program
{
	static void Main()
	{
		Console.WriteLine("========================================================================");
		Console.WriteLine("Что будет делать программа?");
		Console.WriteLine("========================================================================");
		Console.WriteLine();

		Console.WriteLine("Введите любое целое число: ");
		int N1 = int.Parse(Console.ReadLine());
		Console.WriteLine();

		Console.WriteLine("Введите любое целое число: ");
		int N2 = int.Parse(Console.ReadLine());
		Console.WriteLine();

		Console.WriteLine("Введите любое целое число: ");
		int N3 = int.Parse(Console.ReadLine());
		Console.WriteLine();

		Console.WriteLine("Введите любое целое число: ");
		int N4 = int.Parse(Console.ReadLine());
		Console.WriteLine();

		Console.WriteLine($"1) ({N1} > {N2}) && ({N1} >= {N3}) - {(N1 > N2) && (N1 >= N3)}");
		Console.WriteLine($"2) ({N2} + 3) > 7 && ({N3} % 2) < 10 - {(N2 + 3) > 7 && (N3 % 2) < 10}");
		Console.WriteLine($"3) !(({N3} + {N4}) != 8) || (({N1} + {N4}) != ({N4} - 5)) - {!((N3 + N4) != 8) || ((N1 + N4) != (N4 - 5))}");
		Console.WriteLine($"4) {N4} < 7 + ({N1} + {N3} * 5) && ({N2} > {N1}) && ({N3} -1) % 2 - {N4 < 7 + N1 + (N3 * 5) && (N2 > N1) && (N3 - 1) % 2 == 0}");
		Console.WriteLine($"5) ({N3} - {N4} - {N1}) < 10 || (({N2} % 3 < 10) && ({N3} * 0.2 < 5)) - {(N3 - N4 - N1) < 10 || ((N2 % 3 < 10) && (N3 * 0.2 < 5))}");
		Console.WriteLine($"6) (({N1} * 2) <= 40) || ({N4} + ({N1} * 3) > 50) || ({N2} - {N3} > 10) - {((N1 * 2) <= 40) || (N4 + (N1 * 3) > 50) || (N2 - N3 > 10)}");
		Console.WriteLine($"7) ({N2} / {N1}) > 1 || !(({N3} / {N4}) <= 1) || ({N3} > 0 && {N1} > 1) - {(N2 / N1) > 1 || !((N3 / N4) <= 1) || (N3 > 0 && N1 > 1)}");
		Console.WriteLine($"8) ({N3} + ({N2} - 10)) > 10 && ({N4} != ({N1} * 5)) || (({N2} + 5) % 2 >= 1) - {(N3 + (N2 - 10)) > 10 && (N4 != (N1 * 5)) || ((N2 + 5) % 2 >= 1)} ");
		Console.WriteLine($"9) ((20 - {N1}) > 5) && !((10 - {N2}) > 0 || (10 - {N3}) >= 0) - {((20 - N1) > 5) && !((10 - N2) > 0 || (10 - N3) >= 0)}");
		Console.WriteLine($"10) ({N1} + {N2} + {N3}) > 40 || ({N2} + {N3} + {N4}) > 40 || (10 != ({N1} - {N2} * 3)) - {(N1 + N2 + N3) > 40 || (N2 + N3 + N4) > 40 || (10 != (N1 - N2 * 3))}");

		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Для выхода из программы нажмите любую клавишу...");
		Console.ReadKey();
	}
}

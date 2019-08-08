using System;

class Program
{
	static void Main()
	{
		Console.WriteLine("========================================================================");
		Console.WriteLine("Что будет делать программа?");
		Console.WriteLine("========================================================================");
		Console.WriteLine();
		Console.WriteLine(Draw(12));
		{
			//Console.WriteLine("Введите первое целое число:");
			//int N1 = int.Parse(Console.ReadLine());
			//Console.WriteLine();

			//Console.WriteLine("Введите второе целое число:");
			//int N2 = int.Parse(Console.ReadLine());
			//Console.WriteLine();

			//Console.WriteLine("Введите третье целое число:");
			//int N3 = int.Parse(Console.ReadLine());
			//Console.WriteLine();

			//Console.WriteLine($"1) ({N1} + {N2}) / {N3} = {(N1 + N2) / N2}");
			//Console.WriteLine($"2) {N1} - {N3} + 10 * {N2} = {N1 - N3 + 10 * N2}");
			//Console.WriteLine($"3) ({N2} + {N1}) - ({N1} * {N3}) = {N2 + N1 - (N1 * N3)}");
			//Console.WriteLine($"4) {N3} * 2 + ({N2} - {N1}) = {N3 * 2 - (N2 - N1)}");
			//Console.WriteLine($"5) ({N1} / {N2}) + {N3} * 0.5 = {(N1 / (double)N2) + (N3 * 0.5)}");
			//Console.WriteLine($"6) ({N2} % 2 ) * ({N3} % 3) = {(N2 % 2) * (N3 % 3)}");
			//Console.WriteLine($"7) ({N1} * {N2}) + {N3} - (12 - {N1}) = {(N1 * N2) + N3 - (12 - N1)}");
			//Console.WriteLine($"8) { N3} - {N2} - {N1} - (30 % {N2}) ={N3 - N2 - N1 - (30 % N2)} ");
			//Console.WriteLine($"9) ({N1} * ({N3 % 2})) + {N2} * {N1} = {N1 * (N3 % 2) + N2 * N1}");
			//Console.WriteLine($"10) ({N2} % 4) / ({N2} + {N3} * 2) = {(N2 % 4) / (N2 + N3 * 2)} ");
			//Console.WriteLine($"11) {N3} * 3 + {N2} * 2 + ({N1} - 10) = {N3 * 3 + N2 * 2 + (N1 - 10)}");
			//Console.WriteLine($"12) ({N3} - {N1}) / ({N2} - ({N1} % 2)) = {(N3 - N1) / (N2 - (N1 % 2))}");
			//Console.WriteLine($"13) {N1} + ({N2} * ({N1} - 8)) % 2 = {N1 + (N2 * (N1 - 8)) % 2} ");
			//Console.WriteLine($"14) ({N2} * {N1} / {N3}) + 15 = {(N2 * N1 / N3) + 15}");
			//Console.WriteLine($"15) ({N3} - {N2} * ({N1} - {N2}) * {N2}) = {(N3 - N2 * (N1 - N2) * N2)}");
			//Console.WriteLine($"16) ((10 - {N1}) % 4) + ((20 - {N2}) % {N3}) = { ((10 - N1) % 4) + ((20 - N2) % N3)}");
			//Console.WriteLine($"17) ({N2} / 2) + ({N1} / 3) + ({N3} * 10) = {(N2 / 2) + (N1 / 3) + (N3 * 10)}");
			//Console.WriteLine($"18) ({N3} - ([{N2} * 4) / {N1})) + 18.3 = {(N3 - ((N2 * 4) / N1)) + 18.3}");
			//Console.WriteLine($"19) {N1} + {N2} + {N3} + 36.6 = {N1 + N2 + N3 + 36.6} ");
			//Console.WriteLine($"20) 4.5 * ({N1} + {N2}) - {N3} / ({N2} * 2) = {4.5 * (N1 + N2) - N3 / (N2 * 2)}");
		}

		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Для выхода из программы нажмите любую клавишу...");
		Console.ReadKey();
	}
	public static string Draw(int fieldSize)
	{
		string field = "";
		fieldSize += 7;
		for (int col = 1; col <= fieldSize; col++)
		{
			for (int row = 1; row <= fieldSize; row++)
			{
				if (col == 1)
				{
					if (row == 1) { field += "┌"; }

					else if (row % 2 == 0) { field += "───"; }
					else if (row % 2 > 0 && row != fieldSize) { field += "┬"; }
					else if (row == fieldSize) { field += "┐\n"; }

				}
				else if (col % 2 == 0)
				{
					if (row == 1) { field += "│"; }

					else if (row % 2 == 0) { field += "   "; }
					else if (row % 2 > 0 && row != fieldSize) { field += "│"; }
					else if (row == fieldSize) { field += "│\n"; }
	}
				else if (col % 2 > 0 && col != fieldSize)
				{
					if (row == 1) { field += "├"; }

					else if (row % 2 == 0) { field += "───"; }
					else if (row % 2 > 0 && row != fieldSize) { field += "┼"; }
					else if (row == fieldSize) { field += "┤\n"; }
				}
				else if (col % 2 > 0 && col == fieldSize)
				{
					if (row == 1) { field += "└"; }

					else if (row % 2 == 0) { field += "───"; }
					else if (row % 2 > 0 && row != fieldSize) { field += "┴"; }
					else if (row == fieldSize) { field += "┘\n"; }
				}
			}

		}

		return field;
	}
}

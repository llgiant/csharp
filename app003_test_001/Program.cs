using System;

class Program
{
	static void Main()
	{

		Console.WriteLine("========================================================================");
		Console.WriteLine("Что будет делать программа?");
		Console.WriteLine("========================================================================");
		Console.WriteLine();
		Console.WriteLine(Draw(10));
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
		string numbers = "";
		if (fieldSize < 10) { numbers = "12345678910".Substring(0, fieldSize); }
		else {  numbers = "12345678910".Substring(0, fieldSize + 1); }
		string Row = "a10".Substring(0, 1);
		if (!letters.Contains(Row)) { return "Таких координат не существует"; }

		string Col = strCoords.Substring(1);
		if (!number.Contains(Col)) { return "Таких координат не существует"; }
		string result = "", part_1 = "", part_2 = "";
		int cellIndex = 0;
		char rowLetter = '0';
		char rowNumber = '0';
		string letters = " abcdefghij";
		int length = letters.Length;
		
		
		for (int row = 1; row <= fieldSize; row++)
		{
			rowNumber = (char)(row + 48);
			rowLetter = (char)(row + 96);
			for (int col = 1; col <= fieldSize; col++)
			{
				cellIndex++;
				if (row == 1)
				{
					part_2 += "│   ";
					if (col == 1) { part_2 = rowLetter + part_2; part_1 += " ┌───"; }
					else
					{
						part_1 += "┬───";
						if (col == fieldSize)
						{
							part_1 += "┐\n";
							part_2 += "│\n";
						}
					}
				}
				else if (row == fieldSize)
				{
					part_1 += "│   ";
					if (col == 1)
					{
						part_1 = rowLetter + part_1;
						result += " ├───";
						part_2 += " └───";
					}
					else
					{
						result += "┼───";
						part_2 += "┴───";
						if (col == fieldSize)
						{
							result += "┤\n";
							part_1 += "│\n";
							part_2 += "┘";
						}
					}
				}
				else
				{
					part_2 += "│   ";
					if (col == 1) { part_2 = rowLetter + part_2; part_1 += " ├───"; }
					else
					{
						part_1 += "┼───";
						if (col == fieldSize)
						{
							part_1 += "┤\n";
							part_2 += "│\n";
						}
					}
				}
			}
			result += part_1 + part_2;
			part_1 = ""; part_2 = "";
		}
		return result;
	}
}

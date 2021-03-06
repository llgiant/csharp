﻿using System;

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
		Console.WriteLine();
		appBegin:

		bool[] palki = new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true };
		string letters = "";
		string normalize = "";
		int ostatok = 20;
		bool stepIsFirstPlayer = true;
		int removed = 0;

		while (true)
		{
			foreach (bool P in palki) { Console.Write(P ? "| " : "  "); }
			Console.WriteLine();
			for (int i = 0; i < 20; i++) { Console.Write((char)(i + 97) + " "); }
			Console.WriteLine();
			Console.WriteLine($"Ходит {(stepIsFirstPlayer ? "первый игрок" : "второй игрок")}!");
			inputLetters:
			normalize = "";
			letters = Console.ReadLine().Trim().ToLower();
			if (string.IsNullOrWhiteSpace(letters))
			{
				Console.WriteLine("Укажите буквы 1-3 палочек:");
				goto inputLetters;
			}
			else if (letters.Length > 3)
			{
				Console.WriteLine("Можно выбрать не более трех палочек.\nПовторите:");
				goto inputLetters;
			}

			foreach (char L in letters)
			{
				if (!"abcdefghijklmnopqrst".Contains(L.ToString()))
				{
					Console.WriteLine($"Палочки с именем '{L}' нет в игре.\nПовторите:");
					goto inputLetters;
				}
				if (normalize.Contains(L.ToString()))
				{
					Console.WriteLine($"Палочка с именем '{L}' уже указана.\nПовторите:");
					goto inputLetters;
				}
				normalize += L;
			}

			foreach (char L in normalize)
			{
				if (!palki[L - 97])
				{
					Console.WriteLine($"Палочка с именем '{L}' уже убрана.\nПовторите:");
					goto inputLetters;
				}
			}
			foreach (char L in normalize) { palki[L - 97] = false; ostatok--; }


			if (ostatok == 0)
			{
				//Конец игры, объявить победителя и програвшего
				Console.WriteLine($"Ходов не осталоь! Пбедил {(stepIsFirstPlayer ? "Второй игрок" : "Первый игрок")}!");
				break;
			}

			stepIsFirstPlayer = !stepIsFirstPlayer;
		}
		appExit:
		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Выйти из программы [y/n]?");
		string eq = Console.ReadLine();
		if (eq == "n" || eq == "N") { goto appBegin; }
	}
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Program
{
	static Random rnd = new Random();

	static void Main()
	{
		#region ШАПКА
		Console.InputEncoding = System.Text.Encoding.UTF8;
		Console.OutputEncoding = System.Text.Encoding.UTF8;
		Console.WriteLine("========================================================================");
		Console.WriteLine("Игра \"Крестики-нолики\"");
		Console.WriteLine("========================================================================");
		Console.WriteLine();
		appBegin:
		#endregion

		List<Bone> bazar = new List<Bone>();
		List<Bone> field = new List<Bone>();
		List<Bone> player1 = new List<Bone>();
		List<Bone> player2 = new List<Bone>();

		//Заполнение базара
		for (int left = 0; left <= 6; left++)
		{
			for (int right = left; right <= 6; right++)
			{
				bazar.Add(new Bone(left, right));
			}
		}




		#region Футер
		Console.WriteLine("========================================================================");
		Console.WriteLine("Игра окончена.");
		//if (game.Winner == null) { Console.WriteLine("Ничья!"); }
		//else { Console.WriteLine($"Победил {game.Winner.Name}"); }

		appExit:
		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Выйти из программы [y/n]?");
		if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }
		#endregion
	}
}

using System;

class Program
{
	static Random rnd = new Random();

	static void Main()
	{
		Console.InputEncoding = System.Text.Encoding.UTF8;
		Console.OutputEncoding = System.Text.Encoding.UTF8;
		Console.WriteLine("========================================================================");
		Console.WriteLine("Моорской бой!");
		Console.WriteLine("========================================================================");
		Console.WriteLine();
		appBegin:


		#region Перменные            
		Player player1 = new Player("Компьютер1", (PlayerType)2);
		Player player2 = new Player("Компьютер", (PlayerType)2);
		FireResult fireResult = FireResult.Miss;
		int gameMode = 0;
		#endregion

		#region Выбор игры 
		Console.WriteLine($"Выберите против кого вы будете играть:\n0-человек против человека\n1-человек против робота" +
			$"\n2-робот против робота");
		inputOpp:
		try
		{
			gameMode = int.Parse(Console.ReadLine());
			if (gameMode == 0) { player1.Type = (PlayerType)1; player2.Type = (PlayerType)1; }
			else if (gameMode == 1) { player1.Type = (PlayerType)1; }
			else { player2.Name = "Компьютер2"; }
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
			Console.WriteLine("Повторите:");
			goto inputOpp;
		}
		Game game = new Game(player1, player2, gameMode);
		#endregion

		#region Ввод имен пользователей
		if (player1.Type == PlayerType.Human)
		{
			Console.WriteLine($"Введите имя первого игрока:");
			inputName1:
			try
			{
				player1.Name = Console.ReadLine();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				Console.WriteLine("Повторите:");
				goto inputName1;
			}
		}
		if (player2.Type == PlayerType.Human)
		{
			{
				Console.WriteLine($"Введите имя второго игрока:");
				inputName2:
				try
				{
					player2.Name = Console.ReadLine();
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					Console.WriteLine("Повторите:");
					goto inputName2;
				}
			}
		}
		#endregion

		#region ХОД ИГРЫ
		Console.WriteLine(game.Image());
		while (!game.IsFinal)
		{
			Console.WriteLine();
			string coords;
			if (game.CurrentPlayer.Type == PlayerType.Human)
			{
				Console.WriteLine($"Ходит {game.CurrentPlayer.Name}. Введите координаты ячейки:");
				coords = Console.ReadLine();
			}
			else
			{
				Console.WriteLine($"Ходит {game.CurrentPlayer.Name}:");
				coords = null;
				Console.ReadKey();
			}
			try { fireResult = game.Fire(game.CurrentPlayer, coords); }
			catch (Exception e)
			{
			}


			switch (fireResult)
			{
				case FireResult.Wound:
					Console.WriteLine("Ранен");
					break;
				case FireResult.Killed:
					Console.WriteLine("Убит");
					break;
				case FireResult.Double:
					Console.WriteLine("Ячейка уже бита");
					break;
				default:
					Console.WriteLine("Промах");
					break;
			}
			Console.WriteLine();
			Console.WriteLine(game.Image());
		}

		Console.ReadKey();
		#endregion

		#region Финиш
		Console.WriteLine("========================================================================");
		Console.WriteLine("Игра окончена.");
		if (game.Winner == null) { Console.WriteLine("Ничья!"); }
		else { Console.WriteLine($"Победил {game.Winner.Name}"); }
		#endregion
		appExit:
		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Выйти из программы [y/n]?");
		if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }

	}



}

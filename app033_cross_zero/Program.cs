using System;

class Program
{
	static Random rnd = new Random();

	static void Main()
	{
		Console.InputEncoding = System.Text.Encoding.UTF8;
		Console.OutputEncoding = System.Text.Encoding.UTF8;
		Console.WriteLine("========================================================================");
		Console.WriteLine("Игра \"Крестики-нолики\"");
		Console.WriteLine("========================================================================");
		Console.WriteLine();

		Console.WriteLine($"Выбирите размерность поля от 3 до 10:");
		inputCellMod:
		

		appBegin:

		Player player1 = new Player();
		Player player2 = new Player();

		player1.Name = "Робот№1";         //имя первого игрока по умолчанию
		player2.Name = "Робот№2";         //имя второго игрока по умолчанию
		int gameMode = 0;                    // Вид игры, 0 - легкая(по умолчанию), 1 - сложная	
		player1.Type = 0;
		player2.Type = 0;

		#region Выбор игры
		Console.WriteLine($"Выбирите против кого вы будете играть:\n0-человек против человека\n1-человек против робота\n2-робота№1 против робот№2");
		inputOpp:
		try
		{
			player2.Type = (PlayerType)int.Parse(Console.ReadLine());
		}
		catch(Exception e)
		{
			Console.WriteLine(e.Message);
			Console.WriteLine("Повторите:");
			goto inputOpp;
		}

		if (player2.Type ==(PlayerType) 2) { player1.Type = player2.Type; }
		#endregion

		#region Выбор сложности игры		
		if (player2.Type != PlayerType.Human)
		{
			Console.WriteLine($"Выбирите сложность игры:\n0-Легко\n1-Тяжело");
			inputLevel: gameMode = int.Parse(Console.ReadLine());
			if (gameMode < 0 || gameMode > 1) { Console.WriteLine("Такой сложности игры нет, повторите!"); goto inputLevel; }
		}
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
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
				Console.WriteLine("Повторите:");
				goto inputName1;
			}
		}
		if (player2.Type == PlayerType.Human) {
			{
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
		#region Выбор первого игрока "х" или "о"
		int fishka = rnd.Next(0, 2);
		 player1.Fishka = fishka == 0 ? "o" : "x";
		player2.Fishka = "x".Contains(player1.Fishka) ? "o" : "x";
		Console.WriteLine($"{player1.Name} ходит {player1.Fishka}");
		Console.WriteLine($"{player2.Name} ходит {player2.Fishka}");
		#endregion


		Game game = new Game(player1, player2, (GameMode)gameMode,10);
		

		string stepCoords = ""; //координаты введенные игроком
		string strError = "";   //сообщение об ошибке введенных не корректно координат

		//Действие игры, ходы игроков
		do
		{
			Console.Write(game.Draw());
			Console.Write($"Ходит {game.CurrentPlayer.Name}.");
			inputStep:
			if (game.CurrentPlayer.Type != PlayerType.Robot1 && game.CurrentPlayer.Type != PlayerType.Robot2)
			{
				Console.WriteLine($"Веведите координаты ячейки:");
				stepCoords = Console.ReadLine();
			}
			else
			{
				Console.WriteLine();
				stepCoords = "";
				Console.ReadKey();
			}

			strError = game._step(stepCoords);

			// проверка введенных координат
			if (strError.Length > 0)
			{
				Console.WriteLine(strError + ".\nПовторите:");
				goto inputStep;
			}

		} while (!game.IsFinal);
		Console.Write(game.Draw());

		Console.WriteLine("========================================================================");
		Console.WriteLine("Игра окончена.");
		if (game.Winner == null) { Console.WriteLine("Ничья!"); }
		else { Console.WriteLine($"Победил {game.Winner.Name}"); }

		appExit:
		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Выйти из программы [y/n]?");
		if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }
	}
}

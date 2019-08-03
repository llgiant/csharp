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
		appBegin:

		string strName1 = "";          //имя первого игрока
		string strName2 = "Компьютер"; //имя второго игрока по умолчанию
		int gameMode = 0;

		#region Выбор игры
		Console.WriteLine($"Выбирите против кого вы будете играть:\n0-против человека\n1-против компьютера");
		inputOpp: int playerType = int.Parse(Console.ReadLine());
		if (playerType < 0 || playerType > 1) { Console.WriteLine("Такой игры нет, повторите!"); goto inputOpp; }
		#endregion

		#region Выбор сложности игры		
		if (playerType == 1)
		{
			Console.WriteLine($"Выбирите сложность игры:\n0-Легко\n1-Тяжело");
			inputLevel: gameMode = int.Parse(Console.ReadLine());
			if (gameMode < 0 || gameMode > 1) { Console.WriteLine("Такой сложности игры нет, повторите!"); goto inputLevel; }
		}
		#endregion

		#region Ввод имен пользователей
		Console.WriteLine($"Введите имя первого игрока:");
		inputName1: strName1 = Console.ReadLine();
		if (string.IsNullOrWhiteSpace(strName1)) { Console.WriteLine("Поле имя не может быть пустым, повторите ввод!"); goto inputName1; }
		if (playerType == 0)
		{
			Console.WriteLine($"Введите имя второго игрока:");
			inputName2: strName2 = Console.ReadLine();
			if (string.IsNullOrWhiteSpace(strName2)) { Console.WriteLine("Поле имя не может быть пустым, повторите ввод!"); goto inputName2; }
		}
		#endregion

		#region Выбор первого игрока "х" или "о"
		Console.WriteLine("Выбирите чем будет ходить {0}: \"x\" или \"o\"", strName1);
		inputFishka: string strFishka1 = (Console.ReadLine());
		string strFishka2 = " ";
		if (!"xo".Contains(strFishka1))
		{
			Console.WriteLine($"Выбирете \"х\" либо \"o\"");
			goto inputFishka;
		}
		if (strFishka1 == "o") { strFishka2 = "x"; }
		else if (strFishka1 == "х") { strFishka2 = "o"; }
		#endregion

		string stepCoords = "";
		Player player1 = new Player(strName1, PlayerType.Human, strFishka1);
		Player player2 = new Player(strName2, (PlayerType)playerType, strFishka2);
		Game game = new Game(player1, player2, (GameMode)gameMode);
		string strError = "";
		do
		{
			Console.Write(game.Draw());
			Console.Write($"Ходит {game.CurrentPlayer.Name}.");
			inputStep:
			if (game.CurrentPlayer.Type != PlayerType.Robot)
			{
				Console.WriteLine($"Веведите координаты ячейки:");
				stepCoords = Console.ReadLine();
			}
			else
			{
				Console.WriteLine();
				stepCoords = "";
			}

			strError = game._step(stepCoords);
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

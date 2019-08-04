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

		string strName1 = "Робот#1";         //имя первого игрока по умолчанию
		string strName2 = "Робот#2";         //имя второго игрока по умолчанию
		int gameMode = 0;                    // Вид игры, 0 - легкая(по умолчанию), 1 - сложная
		int playerTwoType = 0;               //Тип игрока1, 0 - Human(по умолчанию), 1 - робот1, 2 - робот2
		int playerOneType = 0;               //Тип игрока2, Hunan(по умолчанию), 1 - робот1, 2 - робот2

		#region Выбор игры
		Console.WriteLine($"Выбирите против кого вы будете играть:\n0-человек против человека\n1-человек против робота\n2-робот#1 против робот#2");
		inputOpp: playerTwoType = int.Parse(Console.ReadLine());
		if (playerTwoType < 0 || playerTwoType > 2) { Console.WriteLine("Такой игры нет, повторите!"); goto inputOpp; }
		if (playerTwoType == 2) { playerOneType = playerTwoType; }
		#endregion

		#region Выбор сложности игры		
		if (playerTwoType > 0)
		{
			Console.WriteLine($"Выбирите сложность игры:\n0-Легко\n1-Тяжело");
			inputLevel: gameMode = int.Parse(Console.ReadLine());
			if (gameMode < 0 || gameMode > 1) { Console.WriteLine("Такой сложности игры нет, повторите!"); goto inputLevel; }
		}
		#endregion

		#region Ввод имен пользователей
		if (playerTwoType == 0)
		{
			Console.WriteLine($"Введите имя первого игрока:");
			inputName1: strName1 = Console.ReadLine();
			if (string.IsNullOrWhiteSpace(strName1)) { Console.WriteLine("Поле имя не может быть пустым, повторите ввод!"); goto inputName1; }

			{
				Console.WriteLine($"Введите имя второго игрока:");
				inputName2: strName2 = Console.ReadLine();
				if (string.IsNullOrWhiteSpace(strName2)) { Console.WriteLine("Поле имя не может быть пустым, повторите ввод!"); goto inputName2; }
			}
			#endregion
		}

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



		Player player1 = new Player(strName1, (PlayerType)playerOneType, strFishka1);
		Player player2 = new Player(strName2, (PlayerType)playerTwoType, strFishka2);
		Game game = new Game(player1, player2, (GameMode)gameMode);

		string stepCoords = ""; //координаты введенные человеком
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

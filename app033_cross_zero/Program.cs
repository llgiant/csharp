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

		#region Выбор игры
		bool isRobot;
		Console.WriteLine($"Выбирите против кого вы будете играть:\n1-против человека\n2-против компьютера");
		inputOpp: int opponentChoose = int.Parse(Console.ReadLine());
		if (opponentChoose == 2) { isRobot = true; }
		else if(opponentChoose == 1) { isRobot = false; }
		else { Console.WriteLine("Такой игры нет, повторите!"); goto inputOpp; }
		#endregion

		#region Ввод имен пользователей
		Console.WriteLine($"Введите имя первого игрока:");
		string name = Console.ReadLine();
		if()
		#endregion

		#region Выбор первого игрока "х" или "о"
		Console.WriteLine($"Выбирите чем будет ходить первый игрок: \"x\" или \"o\"");
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

		Game game = new Game();

		 string checkFishka(String strName)
		{
			if (string.IsNullOrWhiteSpace(strName)) { return "Поле имя не может быть пустым"; }
			if () { }
			return "";
		}

		do
		{
			Console.Write(game.Draw());
			Console.WriteLine($"Ход {(game.CurrentPlayer < 2 ? "первого" : "второго")} игрока. Веведите координаты ячейки:");
			inputStep: string strError = game._step(Console.ReadLine());
			if (strError.Length > 0)
			{
				Console.WriteLine(strError + ".\nПовторите:");
				goto inputStep;
			}
		} while (!game.IsFinal);
		Console.Write(game.Draw());

		Console.WriteLine("========================================================================");
		Console.WriteLine("Игра окончена.");
		if (game.Winner == 0) { Console.WriteLine("Ничья!"); }
		else { Console.WriteLine($"Победил {(game.Winner == 1 ? "первый" : "второй")} игрок"); }

		appExit:
		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Выйти из программы [y/n]?");
		if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }
	}
}

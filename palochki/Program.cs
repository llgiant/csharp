using System;
class Program
{
	static Random rnd = new Random();
	static void Main()
	{
		Console.InputEncoding = System.Text.Encoding.UTF8;
		Console.OutputEncoding = System.Text.Encoding.UTF8;
		Console.WriteLine("========================================================================");
		Console.WriteLine("Игра палочки");
		Console.WriteLine("========================================================================");
		Console.WriteLine();
		Console.WriteLine("Игроки ходят по очереди, вводят от 1 до 3 букв палочки над которыми надо убрать.\nПроигрывает тот, кто последний уберет последнюю палочку или 3 палочки.\nУспехов ВАМ!!!\n");
		appBegin:
		char[] palochki = new char[] { '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|' };
		char[] letters = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't' };
		string inputCheckStr = "";
		bool isFirstPlayerTurn = true;
		bool gameWithComp = false;
		int coutStick = 0;
		string userStepStr = "";
		int number = 0;
		char compInput = ' ';
		Console.WriteLine("Выбирете игру:\n1 - играть против человека");
		Console.WriteLine("2 - играть против машины");
		int chooseGame = int.Parse(Console.ReadLine());
		if (chooseGame > 2 || chooseGame < 1) //Выбор игры против компьютера и человека
		{
			Console.WriteLine($"Такой игры нет в списке");
			goto appBegin;
		}
		if (chooseGame == 2) { gameWithComp = true; }

		nextRound:
		foreach (char letter in palochki) { Console.Write(letter + " "); }
		Console.WriteLine();
		foreach (char letter in letters) { Console.Write(letter + " "); }
		Console.WriteLine();
		inputUser:
		userStepStr = "";
		if (isFirstPlayerTurn)
		{
			Console.WriteLine("Ход первого игрока");
			userStepStr = Console.ReadLine();
		}
		else if (!isFirstPlayerTurn && !gameWithComp)
		{
			Console.WriteLine("Ход второго игрока");
			userStepStr = Console.ReadLine();
		}
		else if (!isFirstPlayerTurn && gameWithComp)
		{
			Console.WriteLine("Ход компьютера:");
			number = rnd.Next(1, 3);

			for (int index = 0; index < number; index++)
			{
				while (true)
				{
					compInput = Convert.ToChar(rnd.Next(97, 116)); //Проверка вводились ли символы ранее
					if (!inputCheckStr.Contains(compInput + "")) { break; }
				}
				userStepStr += compInput + "";
			}
			Console.WriteLine(userStepStr);
		}

		if (!string.IsNullOrWhiteSpace(userStepStr) && userStepStr.Length < 4) //Проверяем валидацию ввода не больше 3х букв
		{
			char[] userStep = userStepStr.ToCharArray();

			foreach (char letter in userStep)
			{
				if (inputCheckStr.Contains(letter + "")) //Проверка вводились ли символы ранее
				{
					Console.WriteLine("Одна или несколько букв уже использовались, повторите ход");
					goto inputUser;
				}
				if ((int)letter < 97 || (int)letter > 116) //Проверка введены ли символы в диапазоне от a - t
				{
					Console.WriteLine("Одна или несколько букв не верные, повторите ход");
					goto inputUser;
				}
				if (!char.IsLetter(letter))
				{
					Console.WriteLine("Вы ввели не букву");
					goto inputUser;
				}
			}
			if (userStep.Length == 2) //Проверка не совпадают ли какие-либо из 2х введенных символов
			{
				if (userStep[0] == userStep[1])
				{
					Console.WriteLine("Есть одинаковые буквы, повторите ход");
					goto inputUser;
				}
			}
			else if (userStep.Length == 3) //Проверка не совпадают ли какие-либо из 3х введенных символов
			{
				if (userStep[0] == userStep[1] || userStep[0] == userStep[2] || userStep[1] == userStep[2])
				{
					Console.WriteLine("Есть одинаковые буквы, повторите ход");
					goto inputUser;
				}
			}
			foreach (char letter in userStep)
			{
				coutStick++;
				for (int index = 0; index < letters.Length; index++)
				{
					if (letters[index] == letter)
					{
						inputCheckStr += letter;
						palochki[index] = ' ';
						break;
					}
				}
			}
			if (coutStick == palochki.Length)
			{
				if (isFirstPlayerTurn && !gameWithComp)
				{
					Console.WriteLine("Ходов не осталоь! Пбедил второй игрок!");
					goto appExit;
				}
				else if (!isFirstPlayerTurn && !gameWithComp)
				{
					Console.WriteLine("Ходов не осталоь! Пбедил первый игрок!");
					goto appExit;
				}
				else if (!isFirstPlayerTurn && !gameWithComp)
				{
					Console.WriteLine("Ходов не осталоь! Пбедил компьютер!");
					goto appExit;
				}
			}
			isFirstPlayerTurn = !isFirstPlayerTurn;
			goto nextRound;
		}
		else
		{
			Console.WriteLine("Вы ввели больше 3х букв или строка ввода пуста, повторите ход");
			goto nextRound;
		}
		appExit:
		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Выйти из программы [y/n]?");
		string eq = Console.ReadLine();
		if (eq == "n" || eq == "N") { goto appBegin; }
	}
}

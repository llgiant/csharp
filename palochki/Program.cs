using System;
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
		appBegin:
		char[] palochki = new char[] { '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|' };
		//char[] palochki = new char[] { '|', '|', '|', '|' };
		//char[] letters = new char[] { 'a', 'b', 'c', 'd' };
		char[] letters = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't' };
		string inputCheckStr = "";
		bool isFirstPlayerTurn = true;
		bool gameWithComp = false;
		int countStick = 0;
		string userStepStr = "";
		int number = 0;
		char compInput = ' ';
		Console.WriteLine("Выбирете игру:\n1 - играть против человека\n2 - играть против машины");
		inputChooseGame:
		int chooseGame = int.Parse(Console.ReadLine()); //Выбор игры против компьютера или человека
		if (chooseGame < 1 || chooseGame > 2)
		{
			Console.WriteLine($"Такой игры нет в списке");
			goto inputChooseGame;
		}
		gameWithComp = (chooseGame == 2);
		foreach (char letter in palochki) { Console.Write(letter + " "); } //Распечатываем палки
		Console.WriteLine();
		foreach (char letter in letters) { Console.Write(letter + " "); } //Распечатываем буквы
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
			number = rnd.Next(1, 4);
			for (int index = 0; index < number; index++)
			{
				while (true)
				{
					compInput = Convert.ToChar(rnd.Next(97, 117)); //Проверка вводились ли символы ранее
					if (!inputCheckStr.Contains(compInput + "")) { break; }
				}
				userStepStr += compInput + "";
			}
			Console.WriteLine(userStepStr);
		}

		if (!string.IsNullOrWhiteSpace(userStepStr) && userStepStr.Length < 4) //Проверяем валидацию ввода не больше 3х букв
		{
			char[] userStepArr = userStepStr.ToCharArray();
			foreach (char letter in userStepArr)
			{
				if (inputCheckStr.Contains(letter + "")) //Проверка вводились ли символы ранее
				{
					Console.WriteLine("Буква уже использовалась, повторите ход");
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

			if (userStepArr.Length == 2) //Проверка не совпадают ли какие-либо из 2х введенных символов
			{
				if (userStepArr[0] == userStepArr[1])
				{
					Console.WriteLine("Есть одинаковые буквы, повторите ход");
					goto inputUser;
				}
			}
			else if (userStepArr.Length == 3) //Проверка не совпадают ли какие-либо из 3х введенных символов
			{
				if (userStepArr[0] == userStepArr[1] || userStepArr[0] == userStepArr[2] || userStepArr[1] == userStepArr[2])
				{
					Console.WriteLine("Есть одинаковые буквы, повторите ход");
					goto inputUser;
				}
			}

			foreach (char letter in userStepArr)
			{
				countStick++; //Счтаю палочки
				for (int index = 0; index < letters.Length; index++)
				{
					if (letters[index] == letter)
					{
						inputCheckStr += letter; // Добавляю новую букву в словарь для проверки сл ввода
						palochki[index] = ' '; // Удаляем палочки
						break;
					}
				}
			}

			foreach (char letter in palochki) { Console.Write(letter + " "); } //Распечатываем палки
			Console.WriteLine();
			foreach (char letter in letters) { Console.Write(letter + " "); } //Распечатываем буквы
			Console.WriteLine();

			if (countStick == letters.Length) //Проверка на победителя
			{

				if (isFirstPlayerTurn && !gameWithComp)
				{
					Console.WriteLine("Ходов не осталоь! Пбедил второй игрок!");
					goto appExit;
				}
				else if ((!isFirstPlayerTurn && gameWithComp) || (!isFirstPlayerTurn && !gameWithComp))
				{
					Console.WriteLine("Ходов не осталоь! Пбедил первый игрок!");
					goto appExit;
				}
				else if (isFirstPlayerTurn && gameWithComp)
				{
					Console.WriteLine("Ходов не осталоь! Пбедил компьютер!");
					goto appExit;
				}
			}
			isFirstPlayerTurn = !isFirstPlayerTurn;
			goto inputUser;
		}
		else
		{
			Console.WriteLine("Вы ввели больше 3х букв или строка ввода пуста, повторите ход");
			goto inputUser;
		}
		appExit:
		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Сыграть еще раз? [y/n]?");
		string eq = Console.ReadLine();
		if (eq == "y" || eq == "Y") { goto appBegin; }
	}
}

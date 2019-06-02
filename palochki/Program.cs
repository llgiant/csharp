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
		appBegin:
		char[] palochki = new char[] { '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|' };
		char[] letters = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't' };

		char[] inputCheck = new char[20];
		bool isFirstPlayerTurn = true;

		Console.WriteLine("Выбирете игру:\n1 - играть против человека");
		Console.WriteLine("2 - играть против машины");
		int chooseGame = int.Parse(Console.ReadLine());
		if (chooseGame > 2 || chooseGame < 1) //Выбор игры против компьютера и человека
		{
			Console.WriteLine($"Такой игры нет в списке");
			goto appBegin;
		}
		string userStepStr = "";


		if (chooseGame == 1) //Игра против человека
		{
			nextRoundHuman:
			foreach (char letter in palochki) { Console.Write(letter + " "); }
			Console.WriteLine();
			foreach (char letter in letters) { Console.Write(letter + " "); }
			Console.WriteLine();
			if (isFirstPlayerTurn) { Console.WriteLine("Ход первого игрока"); } else { Console.WriteLine("Ход второго игрока"); }
			inputUser:
			userStepStr = Console.ReadLine().ToLower();
			if (!string.IsNullOrWhiteSpace(userStepStr) && userStepStr.Length < 4) //Проверяем валидацию ввода 
			{
				char[] userStep = userStepStr.ToCharArray();
				foreach (char letter in userStep)
				{
					if(char.GetNumericValue(letter) < 97 || char.GetNumericValue(letter) > 116) {
						Console.WriteLine("Одна или несколько букв не верные, повторите ход");
						goto inputUser;
					}
					if (!char.IsLetter(letter))
					{
						Console.WriteLine("Вы ввели не букву");
						goto inputUser;
					}
				}
				if (userStep.Length == 2)
				{
					if (userStep[0] == userStep[1])
					{
						Console.WriteLine("Есть одинаковые буквы, повторите ход");
						goto inputUser;
					}
				}
				else if (userStep.Length == 3)
				{
					if (userStep[0] == userStep[1] || userStep[0] == userStep[2] || userStep[1] == userStep[2])
					{
						Console.WriteLine("Есть одинаковые буквы, повторите ход");
						goto inputUser;
					}
				}




			}
			else
			{
				Console.WriteLine("Вы ввели больше 3х букв или строка ввода пуста, повторите ход");
				goto inputUser;
			}








		}
		else  //Игра против компьютера
		{


			foreach (char letter in palochki) { Console.Write(letter + " "); }
			Console.WriteLine();
			foreach (char letter in letters) { Console.Write(letter + " "); }






		}

		appExit:
		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Выйти из программы [y/n]?");
		string eq = Console.ReadLine();
		if (eq == "n" || eq == "N") { goto appBegin; }
	}
}

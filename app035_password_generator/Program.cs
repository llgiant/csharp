using System;

class Program
{
	static Random rnd = new Random();

	static void Main()
	{
		Console.InputEncoding = System.Text.Encoding.UTF8;
		Console.OutputEncoding = System.Text.Encoding.UTF8;
		Console.WriteLine("========================================================================");
		Console.WriteLine("Генерировать случайный пароль");
		Console.WriteLine("========================================================================");
		Console.WriteLine();
		appBegin:

		//1. Длина от 9 - 18 символов (задает пользователь)
		//2. Минимум 3 строчные буквы (1 категория)
		//3. Минимум 2 заглавные буквы(2 категория)
		//4. Минимум 1 цифра (3 категории)
		//5. Минимум 1 не буквенный и не числовой символ (4 категгория) !@#$%^&*()[]{}
		//6. Рядом не могут сторять два символа одной категории
		//7. Символы одной категории не могут повторяться

		int passLen = 0;     // Длина пароля
		char symbol = ' ';   // Символ в определенной категории
		string strPass = ""; // Сгенерированный пароль		
		int countCat1 = 3;   // Счетчик первой категории
		int countCat2 = 2;   // Счетчик второй категории
		int countCat3 = 1;   // Счетчик третьей категории
		int countCat4 = 1;   // Счетчик четвертой категории					
		int prevCat = 0;     // Предыдущая Категория 
		int cat = 0;         // Категория от 1 до 4
		string strCat = "";  // Символы категории


		string[] catArray = new string[]{"", "abcdefghijklmnopqrstuvwxyz", "ABCDEFGHIJKLMNOPQRSTUVWXYZ", //Массив категории
			 "1234567890", "!@#$%^&*()[]{}?" };


		Console.WriteLine("Введите длину пароля от 9 до 18 символов:");
		inputLen: passLen = int.Parse(Console.ReadLine());
		if (passLen < 9 || passLen > 18)
		{
			Console.WriteLine("Длина пароля должна быть от 9 до 18 символов, повторите:"); goto inputLen;
		}

		do
		{
			newCat: cat = rnd.Next(1, 3);
			if (cat == prevCat) { goto newCat; }

			if (strPass.Length < 7)
			{
				if(countCat1 == 0) { }
												
			}
			else { cat = rnd.Next(1, catArray.Length); }

			strCat = catArray[cat];
			symbol = strCat[rnd.Next(1, catArray.Length + 1)];

			if (cat == 1 && cat != prevCat)
			{
				
				countCat1--;
			}
			else if (cat == 2 && cat != prevCat) { countCat2--; }
			else if (cat == 3 && cat != prevCat) { countCat3--; }
			else if (cat == 4 && cat != prevCat) { countCat4--; }
			strPass += symbol;
			catArray[cat] = catArray[cat].Replace(symbol + "", string.Empty);
			prevCat = cat;
		}
		while (strPass.Length < passLen);

		Console.WriteLine(strPass);

		appExit:
		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Выйти из программы [y/n]?");
		if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }
	}
}

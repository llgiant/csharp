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

		Console.WriteLine("Введите длину пароля от 9 до 18 символов:");
		inputLen: int passLen = int.Parse(Console.ReadLine());  // Запрос длины пароля
		if (passLen < 9 || passLen > 18)
		{
			Console.WriteLine("Длина пароля должна быть от 9 до 18 символов, повторите:"); goto inputLen;
		}
		again:
		string[] catArray = new string[]
		{
			"",
			"abcdefghijklmnopqrstuvwxyz",
			"ABCDEFGHIJKLMNOPQRSTUVWXYZ", //Массив категорий
			 "1234567890",
			"!@#$%^&*()[]{}?"
		};
		char symbol = ' ';   // Символ в определенной категории
		string strPass = ""; // Сгенерированный пароль		
		int countCat1 = 3;   // Счетчик первой категории
		int countCat2 = 2;   // Счетчик второй категории
		int countCat3 = 1;   // Счетчик третьей категории
		int countCat4 = 1;   // Счетчик четвертой категории					
		int prevCat1 = 0;     // Предыдущая Категория 
		int prevCat2 = 0;     // Предпредыдущая Категория 

		int cat = 0;         // Категория от 1 до 4
		string strCat = "";  // Символы категории
		do
		{
			newCat: cat = rnd.Next(1, catArray.Length);
			if (cat == prevCat1) { goto newCat; }

			if (strPass.Length < 7)
			{
				if (prevCat1 == cat || prevCat2 == cat) { goto again; }
				if
				(
					(cat == 1 && countCat1 == 0) ||
					(cat == 2 && countCat2 == 0) ||
					(cat == 3 && countCat3 == 0) ||
					(cat == 4 && countCat4 == 0)
				)
				{ goto newCat; }

				if (cat == 1) { countCat1--; }
				else if (cat == 2) { countCat2--; }
				else if (cat == 3) { countCat3--; }
				else if (cat == 4) { countCat4--; }
			}
			strCat = catArray[cat];
			symbol = strCat[rnd.Next(1, catArray.Length + 1)];

			strPass += symbol;
			catArray[cat] = catArray[cat].Replace(symbol + "", string.Empty);
			prevCat2 = prevCat1;
			prevCat1 = cat;
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

using System;

class Program
{
	static Random rnd = new Random();


	static void Main()
	{
		Console.InputEncoding = System.Text.Encoding.UTF8;
		Console.OutputEncoding = System.Text.Encoding.UTF8;
		Console.WriteLine("========================================================================");
		Console.WriteLine("Программа будет считать разрядность числа");
		Console.WriteLine("========================================================================");
		Console.WriteLine();
		appBegin:
		long number = 0;
		Console.WriteLine("Введите число больше одного и меньше миллиарда");
		inputUser:
		string text = Console.ReadLine();

		if (!string.IsNullOrWhiteSpace(text))
		{
			foreach (char symbol in text)
			{
				if (!char.IsDigit(symbol))
				{
					Console.WriteLine("Вы ввели не цифру! Повторите ввод.");
					goto inputUser;
				}
			}

			number = long.Parse(text);
			if (number < 1)
			{
				Console.WriteLine("Введите число болше ноля:");
				goto inputUser;
			}
			else if (number > 999999999)
			{
				Console.WriteLine("Введите число меньше миллиарда:");
				goto inputUser;
			}
		}
		else
		{
			Console.WriteLine("Введите только цыфры.");
			goto inputUser;
		}

		char razr = ' ';
		string strNumber = "";
		int count = 0;

		String[] edinici = { "ноль", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять", "десять", "одинадцать",
		"двенадцать","тринадцать","четырнадцать", "пятнадцать","шестнадцать","семнадцать","восемнадцать", "девятнадцать"};
		String[] desatki = { "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемьдесят", "девяносто" };
		String[] sotni = { "сто", "двести", "триста", "четыреста", "пятсот", "шестьсот", "семьсот", "восемьсот", "девятьсот" };
		String[] tisyachi = { "одина тысяча", "две тысячи", "три тысячи", "четыре тысячи", "пять тысяч", "шесть тысяч", "семь тысяч", "восемь тысяч", "девять тысяч" };
		Console.WriteLine($"Разрядов: {edinici[text.Length]}");
		for (int index = text.Length - 1; index >= 0; index--)
		{

			razr = text[index];
			string toStr = text[index] + "";
			switch (count)
			{
				case 0:
					Console.WriteLine($"Единиц: {razr}");
					
					break;
				case 1:
					Console.WriteLine($"Десятков: {razr}");
					break;
				case 2:
					Console.WriteLine($"Сотен: {razr}");
					break;
				case 3:
					Console.WriteLine($"Тысяч: {razr}");
					break;
				case 4:
					Console.WriteLine($"Десятков Тысяч: {razr}");
					break;
				case 5:
					Console.WriteLine($"Сотен Тысяч: {razr}");
					break;
				case 6:
					Console.WriteLine($"Миллионов: {razr}");
					break;
				case 7:
					Console.WriteLine($"Десятков Миллионов: {razr}");
					break;
				case 8:
					Console.WriteLine($"Сотен Миллионов: {razr}");
					break;
			}
			count++;
		}

		Console.WriteLine("========================================================================");
		string strNumber = "34568765";
		string[] rankName = new string[] { "Единиц", "Десятков", "Сотен", "Тысяч", "Десятков тысяч", "Сотен тысяч", "Миллионов", "Десятков миллионов", "Сотен миллионов" };
		int rank = 0;
		for (int index = strNumber.Length - 1; index >= 0; index--)
		{
			Console.WriteLine(rankName[rank] + ": " + strNumber[index]);
			rank++;
		}

		appExit:
		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Выйти из программы [y/n]?");
		string eq = Console.ReadLine();
		if (eq == "n" || eq == "N") { goto appBegin; }
	}
}

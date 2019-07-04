using System;

class Program
{
	static Random rnd = new Random();

	static void Main()
	{
		Console.InputEncoding = System.Text.Encoding.UTF8;
		Console.OutputEncoding = System.Text.Encoding.UTF8;

		Console.WriteLine("========================================================================");
		Console.WriteLine("Проверка строк и символов");
		Console.WriteLine("========================================================================");
		Console.WriteLine();
		appBegin:

		//Попросить вввести текст не меньше 5 но не больше 15, сохранить в переменную
		//перебрать все символы и дать справку о тексте.:
		/*
		  1) Общее количество символов
		  2) количество согласных и гласных
		  3) количество пробелов
		  4) Колич запятых
		  5) Перевернутый текст (зеркальный)
		*/

		Console.WriteLine("Введите текст:");
		inputText:
		string text = "Многие думают, что Lorem Ipsum - взятый с потолка псевдо-латинский набор слов,\n" +
			"но это не совсем так. Его корни уходят в один фрагмент классической латыни 45 года н.э.,\n" +
			"то есть более двух тысячелетий назад. Ричард МакКлинток, профессор латыни из колледжа\n" +
			"Hampden-Sydney, штат Вирджиния, взял одно из самых странных слов в Lorem Ipsum, \"consectetur\",\n" +
			"и занялся его поисками в классической латинской литературе. В результате он нашёл неоспоримый\n" +
			"первоисточник Lorem Ipsum в разделах 1.10.32 и 1.10.33 книги \"de Finibus Bonorum et Malorum\"\n" +
			"(\"О пределах добра и зла\"), написанной Цицероном в 45 году н.э. Этот трактат по теории этики\n" +
			"был очень популярен в эпоху Возрождения. Первая строка Lorem Ipsum, \"Lorem ipsum dolor sit amet.\",\n" +
			"происходит от одной из строк в разделе 1.10.32 Классический текст Lorem Ipsum, используемый с XVI века,\n" +
			"приведён ниже. Также даны разделы 1.10.32 и 1.10.33 \"de Finibus Bonorum et Malorum\" Цицерона и их\n" +
			"английский перевод, сделанный H. Rackham, 1914 год.";
		Console.WriteLine(text);

		//if (string.IsNullOrWhiteSpace(text))
		//{
		//	Console.WriteLine("Строка не должна быть пустая введите текст еще раз:");
		//	goto inputText;
		//}
		//else if (text.Length < 5)
		//{
		//	Console.WriteLine("Строка не должна быть короче 5 символов:");
		//	goto inputText;
		//}
		//else if (text.Length > 50)
		//{
		//	Console.WriteLine("Строка не должна быть длинее 50 символов:");
		//	goto inputText;
		//}

		int iterator = 0;
		string glasnie = "";
		string soglasnie = "";
		int countGlasnie = 0;
		int countSoglasnie = 0;
		int countSpace = 0;
		int countComma = 0;
		string reverseText = "";
		string changedText = "";
		//string changedReversedText = "";

		Console.WriteLine($"Общее количество символов: {text.Length}");
		Console.WriteLine();

		foreach (char letter in text)
		{
			// Заменить все пробелы короткие на знак '_'

			// Заменить все запятые на '@'

			// после каждой точки поставить еще две

			// Перед каждым числом поставить знак 'параграфа'

			// Вывести отформатированный текст в зеркальной форме




			reverseText += text[text.Length - 1 - iterator];
			//changedReversedText += changedText[changedText.Length - 1 - iterator];
			switch (letter)
			{
				case 'a':
				case 'A':
				case 'e':
				case 'E':
				case 'i':
				case 'I':
				case 'o':
				case 'O':
				case 'u':
				case 'U':
				case 'y':
				case 'Y':
				case 'а':
				case 'А':
				case 'е':
				case 'Е':
				case 'ё':
				case 'Ё':
				case 'и':
				case 'И':
				case 'й':
				case 'Й':
				case 'о':
				case 'О':
				case 'у':
				case 'У':
				case 'ы':
				case 'Ы':
				case 'э':
				case 'Э':
				case 'ю':
				case 'Ю':
				case 'я':
				case 'Я':
					if (iterator > 0) { glasnie += ", "; }
					glasnie += letter;
					countGlasnie++;
					break;

				case 'b':
				case 'B':
				case 'c':
				case 'C':
				case 'd':
				case 'D':
				case 'f':
				case 'F':
				case 'g':
				case 'G':
				case 'h':
				case 'H':
				case 'j':
				case 'J':
				case 'k':
				case 'K':
				case 'l':
				case 'L':
				case 'm':
				case 'M':
				case 'n':
				case 'N':
				case 'p':
				case 'P':
				case 'q':
				case 'Q':
				case 'r':
				case 'R':
				case 's':
				case 'S':
				case 't':
				case 'T':
				case 'v':
				case 'V':
				case 'w':
				case 'W':
				case 'x':
				case 'X':
				case 'z':
				case 'Z':
				case 'б':
				case 'Б':
				case 'в':
				case 'В':
				case 'г':
				case 'Г':
				case 'д':
				case 'Д':
				case 'ж':
				case 'Ж':
				case 'з':
				case 'З':
				case 'к':
				case 'К':
				case 'л':
				case 'Л':
				case 'м':
				case 'М':
				case 'н':
				case 'Н':
				case 'п':
				case 'П':
				case 'р':
				case 'Р':
				case 'с':
				case 'С':
				case 'т':
				case 'Т':
				case 'ф':
				case 'Ф':
				case 'х':
				case 'Х':
				case 'ц':
				case 'Ц':
				case 'Ч':
				case 'ч':
				case 'ш':
				case 'Ш':
				case 'щ':
				case 'Щ':
				case 'ъ':
				case 'Ъ':
				case 'ь':
				case 'Ь':
					if (iterator > 0) { soglasnie += ", "; }
					soglasnie += letter;
					countSoglasnie++;
					break;
				case ' ':
					countSpace++;
					changedText += '_';
					break;
				case ',':
					countComma++;
					changedText += '&';
					break;
				case '.':
					changedText += "...";
					break;
				case '0':
				case '1':
				case '2':
				case '3':
				case '4':
				case '5':
				case '6':
				case '7':
				case '8':
				case '9':
					changedText += "§" + letter;
					break;
				default:
					changedText += letter;
					break;
			}
			iterator++;
		}



		Console.Write($"1) Общее количество символов: {iterator}");
		Console.WriteLine();

		Console.Write($"2) количество согласных: {countSoglasnie}");
		Console.WriteLine();

		Console.Write($"2) количество гласных: {countGlasnie}");
		Console.WriteLine();

		Console.Write($"3) количество пробелов: {countSpace}");
		Console.WriteLine();

		Console.Write($"4) Количество запятых: {countComma}");
		Console.WriteLine();

		Console.WriteLine($"5) Перевернутый текст(зеркальный):");
		Console.WriteLine(reverseText);


		Console.WriteLine();
		Console.WriteLine("1) Заменить все пробелы на знак '_'\n2) Заменить все запятые на '@'\n3) После каждой точки поставить еще две\n4) Перед каждым числом поставить знак'§'\n5) Вывести отформатированный текст в зеркальной форме");
		Console.WriteLine();
		Console.WriteLine(changedText);
		Console.WriteLine();
		Console.WriteLine();
		//Console.WriteLine(changedReversedText);
		appExit:
		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Выйти из программы [y/n]?");
		string eq = Console.ReadLine();
		if (eq == "n" || eq == "N") { goto appBegin; }
	}
}

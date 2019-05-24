using System;

class Program
{
	static Random rnd = new Random();

	static void Main()
	{
		Console.InputEncoding = System.Text.Encoding.UTF8;
		Console.OutputEncoding = System.Text.Encoding.UTF8;
		Console.WriteLine("========================================================================");
		Console.WriteLine("Программа будет работать с текстом?");
		Console.WriteLine("========================================================================");
		Console.WriteLine();
		appBegin:

		string text = "многие думают, что Lorem Ipsum - взятый с потолка псевдо-латинский набор слов,\n" +
			"но это не совсем так! Его корни уходят в один фрагмент классической латыни 45 года н.э.,\n" +
			"то есть более двух тысячелетий назад. Ричард МакКлинток, профессор латыни из колледжа\n" +
			"Hampden-Sydney, штат Вирджиния, взял одно из самых странных слов в Lorem Ipsum, \"consectetur\",\n" +
			"и занялся его поисками в классической латинской литературе. В результате он нашёл неоспоримый\n" +
			"первоисточник Lorem Ipsum в разделах 1.10.32 и 1.10.33 книги \"de Finibus Bonorum et Malorum\"\n" +
			"(\"О пределах добра и зла\"), написанной Цицероном в 45 году н.э. Этот трактат по теории этики\n" +
			"был очень популярен в эпоху Возрождения! Первая строка Lorem Ipsum, \"Lorem ipsum dolor sit amet.\",\n" +
			"происходит от одной из строк в разделе 1.10.32 Классический текст Lorem Ipsum, используемый с XVI века,\n" +
			"приведён ниже. Также даны разделы 1.10.32 и 1.10.33 \"de Finibus Bonorum et Malorum\" Цицерона и их\n" +
			"английский перевод, сделанный H. Rackham, 1914 год. Есть много вариантов Lorem Ipsum, но большинство\n" +
			"из них имеет не всегда приемлемые модификации, например, юмористические вставки или слова, которые даже\n" +
			"отдалённо не напоминают латынь. Если вам нужен Lorem Ipsum для серьёзного проекта, вы наверняка не хотите\n" +
			"какой-нибудь шутки, скрытой в середине абзаца! Также все другие известные генераторы Lorem Ipsum\n" +
			"используют один и тот же текст, который они просто повторяют, пока не достигнут нужный объём.\n" +
			"Это делает предлагаемый здесь генератор единственным настоящим Lorem Ipsum генератором. Он использует\n" +
			"словарь из более чем 200 латинских слов, а также набор моделей предложений. В результате сгенерированный\n" +
			"Lorem Ipsum выглядит правдоподобно, не имеет повторяющихся абзацей или \"невозможных\" слов.";

		Console.WriteLine("Оригинальный текст:");
		Console.WriteLine(text);
		Console.WriteLine("========================================================================");

		//1) Прочередовать регистры букв+
		//2) Заменить короткие пробелы на '_'+
		//3) Подсчитать количество слов
		//4) Подсчитать количество восклицательных предложений+
		//5) Заменить все знаки пунктуации (кроме точек) на ''+
		//6) Найти сумму всех чисел в тексте

		int countWords = 0;
		string modText = "";
		int summ = 0;
		int countSentance = 0;
		bool isUpper = false;
		string charAdded = "";

		foreach (char letter in text)
		{
			if (char.IsLetter(letter))//Чередуем регистры букв
			{
				charAdded = (isUpper ? char.ToUpper(letter) : char.ToLower(letter)).ToString();
				isUpper = !isUpper;
			}
			else if (char.IsDigit(letter))// Находим сумму цифр
			{
				charAdded = letter.ToString();
				summ += int.Parse(letter.ToString());
			}
			else if (char.IsPunctuation(letter))
			{
				// Подсчет восклицательных предложений
				if (letter == '!') { countSentance++; }
				charAdded = letter.ToString() != "." ? "" : letter.ToString();
			}
			else if (char.IsWhiteSpace(letter))// Находим сумму цифр
			{
				//Увеличиваем счетчик слов
				countWords++;

				// Заменяем короткие пробелы на '_' и считаем слова
				charAdded = (letter == ' ' ? '_' : letter).ToString();
			}
			else
			{ charAdded = letter.ToString(); }

			modText += charAdded;
		}

		Console.WriteLine();
		Console.WriteLine("Модифицированый текст:");
		Console.WriteLine(modText);
		Console.WriteLine("========================================================================");

		Console.WriteLine($"Количество слов в тексте: {countWords}");
		Console.WriteLine($"Количество восклицательных предложений: { countSentance}");
		Console.WriteLine($"Сумма всех цифр в тексте: { summ}");
		Console.WriteLine();

		modText = "";
		char predSymbol = ' ';




		// 1) проверкка символа с предыдущего *a
		// 2) проверка символа следующего	  a*
		// 3) проверка символа 

		char current = ' ';
		for (int index = 0; index < text.Length; index++)
		{
			current = text[index];
			if (char.IsLetter(current) &&
				(index == 0 || index == text.Length - 1) ||
				(index - 1 >= 0 &&
				index + 1 < text.Length &&
				(!char.IsLetter(text[index - 1]) || !char.IsLetter(text[index + 1]))))
			{ current = char.ToUpper(current); }
			modText += current;
		}

	//for (int i = 0; i < text.Length; i++)
	//{
	//	if (char.IsLetter(text[i]))
	//	{
	//		if (i == 0 || i == text.Length)
	//		{
	//			modText += char.ToUpper(text[i]);
	//		}
	//		else if (char.IsWhiteSpace(text[i - 1]) || char.IsPunctuation(text[i - 1]))
	//		{
	//			modText += char.ToUpper(text[i]);
	//		}
	//		else if (char.IsWhiteSpace(text[i + 1]))
	//		{
	//			modText += char.ToUpper(text[i]);
	//		}
	//		else if (char.IsPunctuation(text[i + 1]) && text[i] != '-')
	//		{
	//			modText += char.ToUpper(text[i]);
	//		}
	//		else
	//		{
	//			modText += text[i];
	//		}

	//	}
	//	else
	//	{
	//		modText += text[i];
	//	}}




	Console.WriteLine("========================================================================");
		Console.WriteLine("Модифицированый текст 2:");
		Console.WriteLine(modText);
		Console.WriteLine("========================================================================");

		appExit:
		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Выйти из программы [y/n]?");
		string eq = Console.ReadLine();
		if (eq == "n" || eq == "N") { goto appBegin; }
	}
}

using System;

class Program
{
	static Random rnd = new Random();

	static void Main()
	{
		//Console.InputEncoding = System.Text.Encoding.UTF8;
		Console.OutputEncoding = System.Text.Encoding.UTF8;
		Console.WriteLine("========================================================================");
		Console.WriteLine("Упражнение на строковые функции");
		Console.WriteLine("========================================================================");
		Console.WriteLine();
		appBegin:
		//Задание №1
		/*
		 *1) Запроcить у пользователя искомое слово(фразу)
		 *2) Запросить направление поиска
		 *3) Запросить учет регистра (испольозуя toUpper или toLower)
		 *4) Dsdtcnb на экран результат поиска:
		 *  - количество найденных вхождений
		 *  - позиции вхождений(через заапятую)
		 *  - текст, в котором перед каждым вхождением стоит знак |
		 Задание №2
		 * 1) Выписать через запятую все слова начинающиеся на букау "Р"
		 * 2) Выписать через запятую все слова оканчивающиеся на букау "а"
		 * 3) Выписать через запятую все с буквами "п" и "о"
		 * 4) Посчитать среднюю длину слов в тексте
		 * 5) Выписать через запятую количество симолоа между символами "Lorem"
		 * 6) Выписсать построчно все предлоожения из текста.
		 */

		string text = "Lorem Ipsum - это текст-\"рыба\", часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной \"рыбой\" для текстов на латинице с начала XVI века. В то время некий безымянный печатник создал большую коллекцию размеров и форм шрифтов, используя Lorem Ipsum для распечатки образцов. Lorem Ipsum не только успешно пережил без заметных изменений пять веков, но и перешагнул в электронный дизайн. Его популяризации в новое время послужили публикация листов Letraset с образцами Lorem Ipsum в 60-х годах и, в более недавнее время, программы электронной вёрстки типа Aldus PageMaker, в шаблонах которых используется Lorem Ipsum. Многие думают, что Lorem Ipsum - взятый с потолка псевдо-латинский набор слов, но это не совсем так. Его корни уходят в один фрагмент классической латыни 45 года н.э., то есть более двух тысячелетий назад. Ричард МакКлинток, профессор латыни из колледжа Hampden-Sydney, штат Вирджиния, взял одно из самых странных слов в Lorem Ipsum, \"consectetur\", и занялся его поисками в классической латинской литературе. В результате он нашёл неоспоримый первоисточник Lorem Ipsum. Есть много вариантов Lorem Ipsum, но большинство из них имеет не всегда приемлемые модификации, например, юмористические вставки или слова, которые даже отдалённо не напоминают латынь. Если вам нужен Lorem Ipsum для серьёзного проекта, вы наверняка не хотите какой-нибудь шутки, скрытой в середине абзаца. Также все другие известные генераторы Lorem Ipsum используют один и тот же текст, который они просто повторяют, пока не достигнут нужный объём. Это делает предлагаемый здесь генератор единственным настоящим Lorem Ipsum генератором. Он использует словарь из более чем 200 латинских слов, а также набор моделей предложений. В результате сгенерированный Lorem Ipsum выглядит правдоподобно, не имеет повторяющихся абзацей или \"невозможных\" слов.";

		Console.WriteLine(text);
		Console.WriteLine("========================================================================");

		bool regSerch = false;
		int carret = 0;
		int carretP = 0;
		int carreta = 0;
		int countEntry = 0;
		string strEntries = "";
		string modText = "";
		string startsWithP = "";
		string endsWithA = "";

		int start = 0;

		Console.WriteLine("Введите искомый текст:");
		string word = Console.ReadLine();
		if (!string.IsNullOrWhiteSpace(word))
		{
			Console.WriteLine("Нажмите \"Y\" чтобы учитывать регистр");
			string reg = Console.ReadLine();
			if (reg == "y" || reg == "Y") { regSerch = true; }
			Console.WriteLine("Нажмите 1 чтобы начать поиск с начала текста\nНажмите 2 чтобы начать поиск с конца текста");
			inputOperation:
			int searchDir = int.Parse(Console.ReadLine());
			if (regSerch) { text = text.ToLower(); }// Учитывать регистр
			if (searchDir == 1) //поиск текста с начала
			{
				{
					/*
					while (carretP > -1) //Все слова начинающиеся на букву "Р"
					{
						carretP = text.IndexOf("Р", carretP);
						if (carretP > -1 && text[carretP - 1] == ' ')
						{
							startsWithP += carretP;
							if (countEntry > 0) { startsWithP += ", "; }
							carretP += 1;
						}
					}

					while (carreta > -1) //Все слова оканчивающиеся на букву "a"
					{
						carreta = text.IndexOf("Р", carreta);
						if (carreta > -1 && text[carreta - 1] == ' ')
						{
							endsWithA += carreta;
							if (countEntry > 0) { endsWithA += ", "; }
							carreta += 1;
						}
					}*/
				}
				countEntry = 0;
				while (carret > -1)
				{
					carret = text.IndexOf(word, carret);
					if (carret > -1)
					{
						if (countEntry > 0) { strEntries += ", "; }
						strEntries += carret;
						countEntry++;
						if (carret != 0) { modText += text.Substring(start, carret - start) + "|"; } else { modText += "|"; }
						start = carret;
						carret += word.Length;
						//Console.Write(modText); modText +=
					}
					else { break; }
				}
			}
			else if (searchDir == 2) //поиск текста с конца
			{
				carret = text.Length - 1;
				while (carret > -1)
				{
					start = text.Length - 1;
					carret = text.LastIndexOf(word, carret);
					if (carret > -1)
					{
						if (countEntry > 0) { strEntries += ", "; }
						strEntries += carret;
						countEntry++;

						modText = "|" + text.Substring(carret, text.Length - carret);

						start = carret;
						carret -= 1;
					}
					else { break; }
				}
			}
			else
			{
				Console.WriteLine("Попробуйте выбрать операцию еще раз:");
				goto inputOperation;
			}

			modText += text.Substring(start, text.Length - start);

		}
		Console.WriteLine($"Количество вхождений:{ countEntry}"); // Вывод количества вхождений 
		Console.WriteLine($"Вхождения {strEntries}"); // Вывод вхождений через запятую
		Console.WriteLine("========================================================================");
		Console.WriteLine("Модифицированный текст:");
		Console.WriteLine(modText); // Вывод измененного текста
		Console.WriteLine();
		

		appExit:
		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Выйти из программы [y/n]?");
		string eq = Console.ReadLine();
		if (eq == "n" || eq == "N") { goto appBegin; }
	}
}


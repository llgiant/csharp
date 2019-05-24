using System;

class Program
{
	static Random rnd = new Random();

	static void Main()
	{
		Console.InputEncoding = System.Text.Encoding.UTF8;
		Console.OutputEncoding = System.Text.Encoding.UTF8;
		Console.WriteLine("========================================================================");
		Console.WriteLine("Что будет делать программа?");
		Console.WriteLine("========================================================================");
		Console.WriteLine();



		appBegin:
		//Задание №1
		/*
         Задание №2
         * 1) Выписать через запятую все слова начинающиеся на букау "р"
         * 2) Выписать через запятую все слова оканчивающиеся на букау "а"
         * 3) Выписать через запятую все слова с буквами "п" и "о"
         * 4) Посчитать среднюю длину слов в тексте
         * 5) Выписать через запятую количество симолоа между символами "Lorem"
         * 6) Выписсать построчно все предлоожения из текста.
         */
		string text = "рLorem Ipsum \"р\" - это текст-\"рыба\", часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной \"рыбой\" для текстов на латинице с начала XVI века. В то время некий безымянный печатник создал большую коллекцию размеров и форм шрифтов, используя Lorem Ipsum для распечатки образцов. Lorem Ipsum не только успешно пережил без заметных изменений пять веков, но и перешагнул в электронный дизайн. Его популяризации в новое время послужили публикация листов Letraset с образцами Lorem Ipsum в 60-х годах и, в более недавнее время, программы электронной вёрстки типа Aldus PageMaker, в шаблонах которых используется Lorem Ipsum. Многие думают, что Lorem Ipsum - взятый с потолка псевдо-латинский набор слов, но это не совсем так. Его корни уходят в один фрагмент классической латыни 45 года н.э., то есть более двух тысячелетий назад. Ричард МакКлинток, профессор латыни из колледжа Hampden-Sydney, штат Вирджиния, взял одно из самых странных слов в Lorem Ipsum, \"consectetur\", и занялся его поисками в классической латинской литературе. В результате он нашёл неоспоримый первоисточник Lorem Ipsum. Есть много вариантов Lorem Ipsum, но большинство из них имеет не всегда приемлемые модификации, например, юмористические вставки или слова, которые даже отдалённо не напоминают латынь. Если вам нужен Lorem Ipsum для серьёзного проекта, вы наверняка не хотите какой-нибудь шутки, скрытой в середине абзаца. Также все другие известные генераторы Lorem Ipsum используют один и тот же текст, который они просто повторяют, пока не достигнут нужный объём. Это делает предлагаемый здесь генератор единственным настоящим Lorem Ipsum генератором. Он использует словарь из более чем 200 латинских слов, а также набор моделей предложений. В результате сгенерированный Lorem Ipsum выглядит правдоподобно, не имеет повторяющихся абзацей или \"невозможных\" слов.р";
		string startsWithP = "";
		string endsWithA = "";

		string toLowerText = text.ToLower();
		int carret = 0;
		string word = "";
		int indexEndWord = 0;
		Console.WriteLine(text);
		Console.WriteLine("========================================================================");
		while (true)
		{
			carret = toLowerText.IndexOf("р", carret);
			if (carret < 0) { break; }


			if (carret > 0 && char.IsLetter(toLowerText[carret - 1]) && carret <= text.Length) { carret++; }
			else
			{
				for (int index = carret + 1; index < toLowerText.Length; index++)
				{
					if (!char.IsLetter(toLowerText[index]))
					{
						indexEndWord = index;
						break;
					}
					else (indexEndWord == text.Length - 1) { word = text[indexEndWord] + ""};
				}

				word = text.Substring(carret, indexEndWord - carret);
				if (startsWithP.Length > 0) { startsWithP += ", "; }
				startsWithP += word;
				carret += word.Length;
			}
		}
		if (carret >= text.Length) { break; }
	





Console.WriteLine($"Cлова начинающиеся на букау \"Р\": { startsWithP}");// Выписать через запятую все слова начинающиеся на букау "Р"
		Console.WriteLine($"Cлова заканчивающиеся на букау \"а\"{endsWithA}");


		appExit:
		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Выйти из программы [y/n]?");
		string eq = Console.ReadLine();
		if (eq == "n" || eq == "N") { goto appBegin; }
	}
}

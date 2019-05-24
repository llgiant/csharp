using System;

class Program
{

	static void Main()
	{
		Console.InputEncoding = System.Text.Encoding.UTF8;
		Console.OutputEncoding = System.Text.Encoding.UTF8;
		Console.WriteLine("========================================================================");
		Console.WriteLine("Поиск вхождений подстроки в строку");
		Console.WriteLine("========================================================================");
		Console.WriteLine();
		appBegin:

		string text = "Lorem Ipsum - это текст-\"рыба\", часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной \"рыбой\" для текстов на латинице с начала XVI века. В то время некий безымянный печатник создал большую коллекцию размеров и форм шрифтов, используя Lorem Ipsum для распечатки образцов. Lorem Ipsum не только успешно пережил без заметных изменений пять веков, но и перешагнул в электронный дизайн. Его популяризации в новое время послужили публикация листов Letraset с образцами Lorem Ipsum в 60-х годах и, в более недавнее время, программы электронной вёрстки типа Aldus PageMaker, в шаблонах которых используется Lorem Ipsum. Многие думают, что Lorem Ipsum - взятый с потолка псевдо-латинский набор слов, но это не совсем так. Его корни уходят в один фрагмент классической латыни 45 года н.э., то есть более двух тысячелетий назад. Ричард МакКлинток, профессор латыни из колледжа Hampden-Sydney, штат Вирджиния, взял одно из самых странных слов в Lorem Ipsum, \"consectetur\", и занялся его поисками в классической латинской литературе. В результате он нашёл неоспоримый первоисточник Lorem Ipsum. Есть много вариантов Lorem Ipsum, но большинство из них имеет не всегда приемлемые модификации, например, юмористические вставки или слова, которые даже отдалённо не напоминают латынь. Если вам нужен Lorem Ipsum для серьёзного проекта, вы наверняка не хотите какой-нибудь шутки, скрытой в середине абзаца. Также все другие известные генераторы Lorem Ipsum используют один и тот же текст, который они просто повторяют, пока не достигнут нужный объём. Это делает предлагаемый здесь генератор единственным настоящим Lorem Ipsum генератором. Он использует словарь из более чем 200 латинских слов, а также набор моделей предложений. В результате сгенерированный Lorem Ipsum выглядит правдоподобно, не имеет повторяющихся абзацей или \"невозможных\" слов.";

		Console.WriteLine(text);
		Console.WriteLine("========================================================================");

		// найти сколько раз и через запятую выписать индексы вхождения слова "Lorem" в этот текст
		//int count = 0;
		//string strIndex = "";
		//string modText = text;
		//while (count < text.Length)
		//{
		//	if (count > 0)
		//	{ strIndex += ", "; }
		//	strIndex += modText.IndexOf(word, count);
		//	count += text.IndexOf(word, count) + 1;
		//	if (text.IndexOf("Lorem", count) < 0)
		//	{
		//		break;
		//	}
		//}


		int caret = 0;
		int countEntry = 0;
		string strEntries = "";
		string word = "Lorem";
		string modText = "";


		//int caret = 0;
		//int caret = text.Length - 1;
		//while (caret > -1)
		//{
		//	caret = text.IndexOf(word, caret);
		//	if (caret > -1)
		//	{
		//		if (countEntry > 0)
		//		{ strEntries += ","; }
		//		strEntries += caret;
		//		countEntry++;
		//		caret += word.Length;
		//	}
		//	else { break; }
		//}

		//while (caret > -1)
		//{
		//	caret = text.LastIndexOf(word, caret);
		//	if (caret > -1)
		//	{
		//		if (countEntry > 0)
		//		{ strEntries += ", "; }
		//		strEntries += caret;
		//		countEntry++;
		//		caret -= 1;
		//	}
		//	else { break; }
		//}


		Console.WriteLine(strEntries);

		appExit:
		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Выйти из программы [y/n]?");
		string eq = Console.ReadLine();
		if (eq == "n" || eq == "N") { goto appBegin; }
	}
}

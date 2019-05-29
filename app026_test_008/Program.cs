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
         * 5) Выписать через запятую количество символов между словами "Lorem"
         * 6) Выписсать построчно все предлоожения из текста.
         */
        string text = "Lorem Ipsum - это текст-\"рыба\", часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной \"рыбой\" для текстов на латинице с начала XVI века. В то время некий безымянный печатник создал большую коллекцию размеров и форм шрифтов, используя Lorem Ipsum для распечатки образцов. Lorem Ipsum не только успешно пережил без заметных изменений пять веков, но и перешагнул в электронный дизайн. Его популяризации в новое время послужили публикация листов Letraset с образцами Lorem Ipsum в 60-х годах и, в более недавнее время, программы электронной вёрстки типа Aldus PageMaker, в шаблонах которых используется Lorem Ipsum.Многие думают, что Lorem Ipsum - взятый с потолка псевдо-латинский набор слов, но это не совсем так. Его корни уходят в один фрагмент классической латыни 45 года н.э., то есть более двух тысячелетий назад. Ричард МакКлинток, профессор латыни из колледжа Hampden-Sydney. Есть много вариантов Lorem Ipsum, но большинство из них имеет не всегда приемлемые модификации, например, юмористические вставки или слова, которые даже отдалённо не напоминают латынь. Если вам нужен Lorem Ipsum для серьёзного проекта, вы наверняка не хотите какой-нибудь шутки, скрытой в середине абзаца. Также все другие известные генераторы Lorem Ipsum используют один и тот же текст, который они просто повторяют, пока не достигнут нужный объём. Это делает предлагаемый здесь генератор единственным настоящим Lorem Ipsum генератором.";
        //string startsWithP = "";
        string endsWithA = "";
        string startsWithP = "";

        string toLowerText = text.ToLower();
        int carret = 0;
        string word = "";
        int indexEndWord = 0;
        Console.WriteLine(text);
        Console.WriteLine("========================================================================");

        // |р...... |р .|р. ...|р

        while (true) // 1) Выписать через запятую все слова начинающиеся на букау "р"
        {

            carret = toLowerText.IndexOf("р", carret); // положение каретки
            if (carret < 0) { break; }
            if (carret == text.Length - 1) { break; }

            if (carret > 0 && char.IsLetter(toLowerText[carret - 1]) && carret <= text.Length) { carret++; }
            else
            {
                for (int index = carret + 1; index < text.Length; index++)
                {
                    if (!char.IsLetter(toLowerText[index]))
                    {
                        indexEndWord = index;
                        break;
                    }
                }
                word = text.Substring(carret, indexEndWord - carret); // формирование слова
                if (startsWithP.Length > 0) { startsWithP += ", "; }
                startsWithP += word;
                carret += word.Length;
            }
        }

        carret = 0;
        int indexStartWord = 0;

        while (true)
        {
            carret = toLowerText.IndexOf("а", carret); // положение каретки
            if (carret < 0 || carret == text.Length - 1) { break; }
            if (carret > 0 && char.IsLetter(toLowerText[carret + 1]) && carret <= text.Length) { carret++; }
            else
            {
                for (int index = carret - 1; index > 0; index--)
                {
                    if (!char.IsLetter(toLowerText[index]))
                    {
                        indexStartWord = index;
                        break;
                    }
                }
                word = text.Substring(indexStartWord + 1, carret - indexStartWord); // формирование слова
                if (endsWithA.Length > 0) { endsWithA += ", "; }
                endsWithA += word;
                carret += word.Length;
            }

        }

        carret = 0;
        string containsPO = "";
        int predSymbol = carret - 1;
        int sledSymbol = carret + 1;
        int startIndex = 0;
        int endIndex = 0;
        word = "";

        while (true)
        {
            carret = toLowerText.IndexOf("п", carret); // положение каретки
            if (carret == -1) { break; }
            predSymbol = carret - 1;
            sledSymbol = carret + 1;
            if (carret == 0 || !char.IsLetter(text[predSymbol]))
            {
                if (carret == text.Length - 1 || char.IsLetter(text[sledSymbol]))
                {
                    for (int index = carret + 1; index < text.Length; index++)
                    {
                        if (!char.IsLetter(text[index]))
                        {

                            word = toLowerText.Substring(carret, index - carret);
                            if (word.Contains("о"))
                            {
                                if (containsPO.Length > 0) { containsPO += ", "; }
                                containsPO += word;
                            }
                            carret += word.Length;
                            break;
                        }
                    }
                }
                else
                {
                    if (carret == text.Length - 1) { break; }
                    else { carret += 1; }

                }
            }
            else
            {
                if (char.IsLetter(text[sledSymbol])) // если буква Р находится в середине слова и до и после есть буквы

                {
                    for (int index = carret + 1; index < text.Length; index++)
                    {
                        if (!char.IsLetter(text[index]))
                        {
                            endIndex = index;
                            break;
                        }
                    }
                    for (int index = carret - 1; index > 0; index--)
                    {
                        if (!char.IsLetter(text[index]))
                        {
                            startIndex = index + 1;
                            break;
                        }
                    }
                    word = toLowerText.Substring(startIndex, endIndex - startIndex);
                    if (word.Contains("о"))
                    {
                        if (containsPO.Length > 0) { containsPO += ", "; }
                        containsPO += word;
                    }
                    carret += word.Length;
                }
                else   // если буква Р находится в конце слова и после нет букв
                {
                    for (int index = carret - 1; index > 0; index--)
                    {
                        if (!char.IsLetter(text[index]))
                        {
                            startIndex = index;
                            break;
                        }

                    }
                    word = toLowerText.Substring(startIndex, carret - startIndex);

                    if (word.Contains("о"))
                    {
                        if (containsPO.Length > 0) { containsPO += ", "; }
                        containsPO += word;
                    }
                    carret += word.Length;
                }

            }
        }

        {
            /*
            carret = 0;
            String wordsWithPO = "";
            int carretP = 0;
            int carretO = 0;
            bool inOneWord = true;
            indexStartWord = 0;
            indexEndWord = 0;
            word = "";
            int indexLeft = 0;
            int indexRight = 0;

            while (true) // 3) Выписать через запятую все слова с буквами "п" и "о"
            {
                if (carretP < 0 || carretO < 0) { break; }
                if (carretO > text.Length || carretP > text.Length) { break; }
                carretP = toLowerText.IndexOf("п", carretP); // положение каретки "п"
                carretO = toLowerText.IndexOf("о", carretO); // положение каретки "о"
                notInOneWord:
                inOneWord = true;
                if (carretO == text.Length - 1 || carretP == text.Length - 1) { break; }
                if (carretO > carretP)
                {
                    for (int index = carretP + 1; index < carretO; index++) // смотрим если найденные буквы в оодинаковых
                    {
                        if (!char.IsLetter(toLowerText[index])) // если находим далее не букву, то искомые символы не в одном слове
                        {
                            inOneWord = false;
                            break;
                        }
                    }
                    if (!inOneWord)
                    {
                        carretP = toLowerText.IndexOf("п", carretP + 1); // если буквы не в одном слове ищем букву с меньшим индексом далее
                        goto notInOneWord;
                    }
                    else
                    {
                        if (carretP == 0 || !char.IsLetter(text[carretP - 1])) { break; }
                        else
                        {
                            for (indexLeft = carretP - 1; indexLeft > 0; indexLeft--)
                            {
                                if (!char.IsLetter(toLowerText[indexLeft]))
                                {
                                    indexStartWord = indexLeft + 1;
                                    break;
                                }
                            }
                            for (indexRight = carretP + 1; indexRight <= text.Length; indexRight++)
                            {
                                if (indexRight == text.Length || !char.IsLetter(toLowerText[indexRight]))
                                {
                                    indexEndWord = indexRight;

                                    break;
                                }
                            }
                            word = text.Substring(indexStartWord, indexEndWord - indexStartWord); // формирование слова
                            if (wordsWithPO.Length > 0) { wordsWithPO += ", "; }
                            wordsWithPO += word;
                            carretO = indexRight + 1;
                            carretP = carretO;


                        }
                    }
                }

                else
                {
                    for (int index = carretO + 1; index < carretP; index++) // смотрим если найденные буквы в оодинаковых
                    {
                        if (!char.IsLetter(toLowerText[index])) // если находим далее не букву, то искомые символы не в одном слове
                        {
                            inOneWord = false;
                            break;
                        }
                    }
                    if (!inOneWord)
                    {
                        carretO = toLowerText.IndexOf("о", carretO + 1); // если буквы не в одном слове ищем букву с меньшим индексом далее
                        goto notInOneWord;
                    }
                    else
                    {
                        if (carretO == 0 || !char.IsLetter(text[carretO - 1])) { break; }
                        else
                        {
                            for (indexLeft = carretO - 1; indexLeft > 0; indexLeft--)
                            {
                                if (!char.IsLetter(toLowerText[indexLeft]))
                                {
                                    indexStartWord = indexLeft;
                                    break;
                                }
                            }
                            for (indexRight = carretO + 1; indexRight < text.Length; indexRight++)
                            {
                                if (!char.IsLetter(toLowerText[indexRight]))
                                {
                                    indexEndWord = indexRight;
                                    break;
                                }
                            }
                            word = text.Substring(indexStartWord, indexEndWord - indexStartWord + 1); // формирование слова
                            if (wordsWithPO.Length > 0) { wordsWithPO += ", "; }
                            wordsWithPO += word;
                            carretP = indexRight + 1;
                            carretO = carretP;
                        }
                    }



                }
            }
            Console.WriteLine($"Cлова с буквами \"п\" и \"о\": { wordsWithPO}");
            */
        }

        Console.WriteLine($"Cлова начинающиеся на букау \"Р\": { startsWithP}");
        Console.WriteLine($"Cлова оканчивающиеся на букву \"а\": { endsWithA}");
        Console.WriteLine($"Cлова с буквами \"п\" и \"о\": {containsPO}");

    appExit:
        Console.WriteLine();
        Console.WriteLine("========================================================================");
        Console.WriteLine("Выйти из программы [y/n]?");
        string eq = Console.ReadLine();
        if (eq == "n" || eq == "N") { goto appBegin; }

    }


}





//carret = toLowerText.IndexOf("р", carret);
//if (carret < 0) { break; }
//if (carret > 0 && char.IsLetter(toLowerText[carret - 1]) && carret <= text.Length) { carret++; }
//else
//{
//	for (int index = carret + 1; index < toLowerText.Length; index++)
//	{
//		if (!char.IsLetter(toLowerText[index]))
//		{
//			indexEndWord = index;
//			break;
//		}
//		//else (indexEndWord == text.Length - 1) { word = text[indexEndWord] + ""};
//	}

//	word = text.Substring(carret, indexEndWord - carret);
//	if (startsWithP.Length > 0) { startsWithP += ", "; }
//	startsWithP += word;
//	carret += word.Length;
//}
//if (carret >= text.Length) { break; }








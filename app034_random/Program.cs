using System;

class Program
{

	static void Main()
	{
		Console.InputEncoding = System.Text.Encoding.UTF8;
		Console.OutputEncoding = System.Text.Encoding.UTF8;
		Console.WriteLine("========================================================================");
		Console.WriteLine("Генерация случайных чисел");
		Console.WriteLine("========================================================================");
		Console.WriteLine();
		appBegin:

		string rndNum = "";
		Console.WriteLine("Введите первое целое число \"а\" от 0 до 50");
		inputA: int a = int.Parse(Console.ReadLine());
		if (a < 0 || a > 50) { Console.WriteLine("Число \"а\" должно быть в диапахзоне от 0 до 50"); goto inputA; }

		Console.WriteLine("Введите первое целое число \"а\" от 60 до 100");
		inputB: int b = int.Parse(Console.ReadLine());
		if (b < 60 || b > 100) { Console.WriteLine("Число \"а\" должно быть в диапахзоне от 60 до 100"); goto inputB; }

		Random rnd = new Random();

		for (int i = 0; i < 20; i++)
		{
			if (rndNum.Length > 0) { rndNum += ", "; }
			rndNum += rnd.Next(a, b + 1);
		}

		Console.WriteLine("Случайные числа между [{0} и {1}):\n{2}", a, b, rndNum);

		rndNum = "";
		int[] array = new int[rnd.Next(10, 21)];
		for (int index = 0; index < array.Length; index++)
		{
			array[index] = rnd.Next(a, b + 1);
			if (rndNum.Length > 0) { rndNum += ", "; }
			rndNum += array[index];
		}
		Console.WriteLine("\nМассив случайной длины [{0}] в cлучайные числа в нем между [{1} и {2}):\n{3}", array.Length, a, b, rndNum);

		string listWords = "";
		string letter = "";
		string word = "";
		int wordLen = 0;
		int wordsCount = 0;

		do
		{
			wordLen = rnd.Next(4, 11);
			again:
			letter = ((char)rnd.Next(97, 123)).ToString();
			if (word.Length > 0 && word.Contains(letter)) { goto again; }
			word += letter;
			if (word.Length != wordLen) { goto again; }
			if (listWords.Contains(word)) { word = ""; goto again; }
			if (listWords.Length > 0) { listWords += ", "; }
			listWords += word;
			word = "";
			wordsCount++;
		} while (wordsCount < 21);


		Console.WriteLine($"\n20 случайных слов:\n{listWords}");





		appExit:
		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Выйти из программы [y/n]?");
		if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }
	}
}

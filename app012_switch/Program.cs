using System;

class Program
{
	static void Main()
	{
		Console.WriteLine("========================================================================");
		Console.WriteLine("Конструкция выборки Switch");
		Console.WriteLine("========================================================================");
		Console.WriteLine();


		appBegin:
		Console.WriteLine(" Введите букву кирилического или латинского алфавита: ");

		string letter = Console.ReadLine();

		switch (letter)
		{
			case "a":
			case "A":
			case "b":
			case "B":
			case "c":
			case "C":
			case "d":
			case "D":
			case "e":
			case "E":
			case "f":
			case "F":
			case "g":
			case "G":
			case "h":
			case "H":
			case "i":
			case "I":
			case "j":
			case "J":
			case "k":
			case "K":
			case "l":
			case "L":
			case "m":
			case "M":
			case "n":
			case "N":
			case "o":
			case "O":
			case "p":
			case "P":
			case "q":
			case "Q":
			case "r":
			case "R":
			case "s":
			case "S":
			case "t":
			case "T":
			case "u":
			case "U":
			case "v":
			case "V":
			case "w":
			case "W":
			case "x":
			case "X":
			case "y":
			case "Y":
			case "z":
			case "Z":
				Console.WriteLine();
				Console.WriteLine($"\t{letter} - буква кирилического латинского алфавита.");
				break;

			case "а":
			case "А":
			case "б":
			case "Б":
			case "в":
			case "В":
			case "г":
			case "Г":
			case "д":
			case "Д":
			case "е":
			case "Е":
			case "ё":
			case "Ё":
			case "ж":
			case "Ж":
			case "з":
			case "З":
			case "и":
			case "И":
			case "й":
			case "Й":
			case "к":
			case "К":
			case "л":
			case "Л":
			case "м":
			case "М":
			case "н":
			case "Н":
			case "о":
			case "О":
			case "п":
			case "П":
			case "р":
			case "Р":
			case "с":
			case "С":
			case "т":
			case "Т":
			case "у":
			case "У":
			case "ф":
			case "Ф":
			case "х":
			case "Х":
			case "ц":
			case "Ц":
			case "Ч":
			case "ч":
			case "ш":
			case "Ш":
			case "щ":
			case "Щ":
			case "ъ":
			case "Ъ":
			case "ы":
			case "Ы":
			case "ь":
			case "Ь":
			case "э":
			case "Э":
			case "ю":
			case "Ю":
			case "я":
			case "Я":
				Console.WriteLine();
				Console.WriteLine($"\t{letter} - буква кирилического алфавита.");
				break;
			default:
				Console.WriteLine($"\t{letter} - не является буквой алфавита.");
				goto appBegin;
		}


		goto appExit;

		appExit:
		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Выйти из программы [y/n]?");
		string eq = Console.ReadLine();
		if (eq == "n" || eq == "N") { goto appBegin; }
	}
}

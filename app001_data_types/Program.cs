using System;

class Program
{
	static void Main()
	{
		Console.WriteLine("========================================================================");
		Console.WriteLine("Примитивные типы данных");
		Console.WriteLine("========================================================================");
		Console.WriteLine();

		Console.WriteLine("Тип: byte");
		Console.WriteLine("Память: 1 байт");
		Console.WriteLine("Max: " + byte.MaxValue);
		Console.WriteLine("Min: " + byte.MinValue);
		Console.WriteLine("Пример: 0");
		Console.WriteLine("----------------");

		Console.WriteLine("Тип: sbyte");
		Console.WriteLine("Память: 1байт");
		Console.WriteLine("Max: " + sbyte.MaxValue);
		Console.WriteLine("Min: " + sbyte.MinValue);
		Console.WriteLine("Пример: -120");
		Console.WriteLine("----------------");

		Console.WriteLine("Тип: short");
		Console.WriteLine("Память: 2 байта");
		Console.WriteLine("Max: " + short.MaxValue);
		Console.WriteLine("Min: " + short.MinValue);
		Console.WriteLine("Пример: 31234");
		Console.WriteLine("----------------");

		Console.WriteLine("Тип: ushort");
		Console.WriteLine("Память: 2 байт");
		Console.WriteLine("Max: " + ushort.MaxValue);
		Console.WriteLine("Min: " + ushort.MinValue);
		Console.WriteLine("Пример: 6000");
		Console.WriteLine("----------------");

		Console.WriteLine("Тип: int");
		Console.WriteLine("Память: 4 байт");
		Console.WriteLine("Max: " + int.MaxValue);
		Console.WriteLine("Min: " + int.MinValue);
		Console.WriteLine("Пример: 231111");
		Console.WriteLine("----------------");

		Console.WriteLine("Тип: uint");
		Console.WriteLine("Память: 4 байт");
		Console.WriteLine("Max: " + uint.MaxValue);
		Console.WriteLine("Min: " + uint.MinValue);
		Console.WriteLine("Пример: -12345");
		Console.WriteLine("----------------");

		Console.WriteLine("Тип: long");
		Console.WriteLine("Память: 8 байт ");
		Console.WriteLine("Max: " + long.MaxValue);
		Console.WriteLine("Min" + long.MinValue);
		Console.WriteLine("Пример: 9223372036854775806");
		Console.WriteLine("---------------------------");

		Console.WriteLine("Тип:ulong");
		Console.WriteLine("Память: 8 байт");
		Console.WriteLine("Max: " + ulong.MaxValue);
		Console.WriteLine("Min: " + ulong.MinValue);
		Console.WriteLine("Пример: 18446744073709551615");
		Console.WriteLine("----------------------------");

		Console.WriteLine("Тип: float");
		Console.WriteLine("Память: 4 байт");
		Console.WriteLine("Max: " + float.MaxValue);
		Console.WriteLine("Min: " + float.MinValue);
		Console.WriteLine("Пример: 3.40");

		Console.WriteLine("Тип: double");
		Console.WriteLine("память: 8 байт");
		Console.WriteLine("max: " + double.MaxValue);
		Console.WriteLine("Min: " + double.MinValue);
		Console.WriteLine("Пример: -1,79769313486232E+308");

		Console.WriteLine("Тип: decimal");
		Console.WriteLine("Память: 16 байт");
		Console.WriteLine("Max: " + decimal.MaxValue);
		Console.WriteLine("Min: " + decimal.MinValue);
		Console.WriteLine("Пример:  79228162514264337593543950335");

		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Для выхода из программы нажмите любую клавишу...");
		Console.ReadKey();
	}
}

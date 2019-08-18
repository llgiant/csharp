using System;
using System.Collections.Generic;
using System.Linq;

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
		//Создайте целочисленный массив intArray, с такими элементами:
		//0, 5, 13, -11, 9, -9, 5, -8, -7, -1, 15, 12, 13, -6, 2, 15, -2, -10, -14, -9, -5, 8, -10, 14, 8
		//Выполните последовательно с этим массивом ряд операций:

		//+Поменяйте местами первый и максимальй элементы.
		//+Поменяйте местами максимальный и минимальный элементы.
		//+Удвойте значения всех нечетных элементов.
		//+Разделите на 2 значения всех четных элементов.
		//Замените элементы кратные 7 на сумму всех элементов кратных 7.
		//Расположите элементы со 2 - го по 6 - ой(включительно) по возрастанию.
		//Расположите элементы с 8 - го по 13 - ый(включительно) по убыванию.
		//После выполнения каждой операции выведите на консоль через запятую все элементы массива.

		List<int> list = new List<int>();
		List<int> sortedList = new List<int>();
		int[] intArray = new int[] { 0, 5, 13, -11, 9, -9, 5, -8, -7, -1, 15, 12, 13, -6, 2, 15, -2, -10, -14, -9, -5, 8, -10, 14, 8 };

		int summDiv7 = 0;
		foreach (int number in intArray)
		{
			list.Add(number);
			if (number % 7 == 0) { summDiv7 += number; }
		}
		sortedList.InsertRange(0, list);                                    //Копирование одного листа в другой
		sortedList.Sort();                                                  //Сортировка листа
		int indexOfMax = list.IndexOf(sortedList[sortedList.Count - 1]);    //Нахожу индекс максимального элемента
		int maxNumber = list[indexOfMax];                                   //нахожу элемент с максимальным числом
		int indexOfMin = list.IndexOf(sortedList[0]);                       //Нахожу индекс минимального элемента
		int minNumber = list[indexOfMin];                                   //нахожу элемент с минимальным числом

		//Поменяйте местами первый и максимальй элементы.
		Console.WriteLine($"Стартовый массив:\n{ToString(list)}\n");
		list.RemoveAt(indexOfMax);
		list.Insert(indexOfMax, list[0]);
		list.RemoveAt(list[0]);
		list.Insert(0, maxNumber);
		Console.WriteLine($"Поменяйте местами первый и максимальй элементы:\n{ToString(list)}\n");

		//Поменяйте местами максимальный и минимальный элементы.
		list.RemoveAt(0);
		list.Insert(0, minNumber);
		list.RemoveAt(indexOfMin);
		list.Insert(indexOfMin, maxNumber);
		Console.WriteLine($"Поменяйте местами максимальный и минимальный элементы:\n{ToString(list)}\n");

		//Удвойте значения всех нечетных элементов или Разделите на 2 значения всех четных элементов.
		Console.WriteLine($"Поменяйте местами максимальный и минимальный элементы:\n{IterateThroughList(list)}\n");

		//Замените элементы кратные 7 на сумму всех элементов кратных 7.
		Console.WriteLine($"Поменяйте местами максимальный и минимальный элементы:\n{IterateThroughList(list, summDiv7)}\n");

		Compr sc = new Compr();
		//Расположите элементы со 2 - го по 6 - ой(включительно) по возрастанию.
		list.Sort(2, 4, sc);
		Console.WriteLine($"Поменяйте местами максимальный и минимальный элементы:\n{list.Sort(2, 4, sortedList)}\n");


		appExit:
		Console.WriteLine();
		Console.WriteLine("========================================================================");
		Console.WriteLine("Выйти из программы [y/n]?");
		if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }
	}
	#region Методы
	//Метод который проставляет запятую
	public static string ToString(List<int> list)
	{
		string strList = "";
		int index = 0;
		while (index < list.Count)
		{
			if (strList.Length > 0) { strList += ", "; }
			strList += list[index];
			index++;
		}
		return strList;
	}
	//Метод который удваивает значения нечетных и делит на два значения четных
	public static string IterateThroughList(List<int> list)
	{

		int index = 0;
		while (index < list.Count)
		{
			if (list[index] % 2 != 0) { list[index] *= 2; }
			else { list[index] /= 2; }

			index++;
		}
		return ToString(list);

	}
	//Метод который заменяет элементы кратные семи на сумму всех элементов кратных семи
	public static string IterateThroughList(List<int> list, int summDiv7)
	{
		int index = 0;
		while (index < list.Count)
		{
			if (list[index] != 0) { if (list[index] % 7 == 0) { list[index] = summDiv7; } }

		}
		return ToString(list);
	}
	#endregion

	class Compr : IComparer<string>
	{
		public int Compare(string x, string y)
		{
			if (x == null || y == null)
			{
				return 0;
			}

			// "CompareTo()" method 
			return x.CompareTo(y);

		}
	}
}

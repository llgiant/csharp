﻿using System;

class Program
{

    static Random rnd = new Random();
    static void Main()
    {
        Console.WriteLine("========================================================================");
        Console.WriteLine("Итерация массива");
        Console.WriteLine("========================================================================");
        Console.WriteLine();
    appBegin:
        //Найти самое большое и самое маленькое значение массива 
        int len = rnd.Next(10, 21);
        int[] intArray = new int[len]; for (int i = 0; i < len; i++) { intArray[i] = rnd.Next(-10, 11); }

        string strElements = "";

        int countPositive = 0;
        string strPositive = "";

        int countNegative = 0;
        string strNegative = "";

        int summElements = 0;
        string strSumm = "";
        string strEl = "";

        int summMod3 = 0;
        string strSummMod3 = "";
        string strElSummMod3 = "";

        int max = intArray[0];
        int min = intArray[0];

        string strSrArifm = "";
        double agvElements = 0.0D;
        int index = 0;

        int summMod5 = 0;
        string strSummMod5 = "";

        int subtrnMod5 = 0;
        string strSubtrnMod5 = "";
        int countSubtrnMod5 = 0;

        int simNumber = 0;
        int countSimNumber = 0;
        string strSimNumber = "";

        int even = 0;
        string strEven = "";
        int countEven = 0;
        string strEvenEl = "";

        int odd = 0;
        string strOdd = "";
        int countOdd = 0;
        string strOddEl = "";

        int minNumLess0 = 0;
        string strMinNumLess0


        foreach (int element in intArray)
        {
            //Вывод на экран всех элементов
            strElements += element;
            if (index < intArray.Length - 1)
            {
                strElements += ", ";
            }

            if (element > 0)
            {
                countPositive++;
                strPositive += element;
                if (index < intArray.Length - 1)
                {
                    strPositive += ", ";
                }
            }
            else if (element < 0)
            {
                countNegative++;
                strNegative += element;
                if (index < intArray.Length - 1)
                {
                    strNegative += ", ";
                }
            }

            // Вычисляю сумму эелементов и среднее арифметическое коллекции
            summElements += element;
            strEl = element < 0 ? "(" + element + ")" : element + "";
            strSumm += strEl;
            if (index < intArray.Length - 1)
            {
                strSumm += " + ";
            }
            else
            {
                agvElements = (double)summElements / intArray.Length;
                strSrArifm = $"({strSumm}) / {intArray.Length} = {agvElements}";
                strSumm += " = " + summElements;
            }

            if (element % 3 == 0)
            {
                summMod3 += element;
                strElSummMod3 = element < 0 ? "(" + element + ")" : element + "";
                strSummMod3 += strElSummMod3;
                if (index < intArray.Length - 1)
                {
                    strSummMod3 += " + ";
                }
                else
                {
                    strSummMod3 += " = " + summMod3;
                }
            }


            //Сумма чисел кратных 5 и > 0 ??????????????????????
            if (element > 0 && element % 5 == 0)
            {
                summMod5 += element;
                strSummMod5 += element;
                if (index < intArray.Length - 1)
                {
                    strSummMod5 += " + ";
                }
            }
            else if (index == intArray.Length - 1)
            {
                strSummMod5 += " = " + summMod5;
            }

            //Разность чисел кратных 5 ???????????????????????????
            if (element % 5 == 0)
            {
                subtrnMod5 = countSubtrnMod5 == 0 ? element : subtrnMod5 - element;

                strSubtrnMod5 = element < 0 ? "(" + element + ")" : element + "";
                strSubtrnMod5 += strSubtrnMod5;
                if (index < intArray.Length - 1)
                {
                    strSubtrnMod5 += ", ";
                }
                else
                {
                    strSubtrnMod5 += " = " + subtrnMod5;

                    if (index < intArray.Length - 1)
                    {
                        strSummMod3 += ", ";
                    }
                }
            }
            //Количество одинаковых чисел???????????????????????




            //четные
            if(element % 2 == 0)
            {
                countEven++;
                strEven += element;
                if (index < intArray.Length - 1)
                {
                    strEven += ", ";
                }

            }   //нечетные
            else if(element % 2 > 0)
            {
                countOdd++;
                strOdd += element;
                if (index < intArray.Length - 1)
                {
                    strOdd += ", ";
                }
            }


            //Максимальное число < 0
            if (element > 0)
            {
                strPositive += element;
                if (index < intArray.Length - 1)
                {
                    strPositive += ", ";
                }
            }
            else if (element < 0)
            {
                countNegative++;
                strNegative += element;
                if (index < intArray.Length - 1)
                {
                    strNegative += ", ";
                }
            }
            //минимальное число > 0

            //общее количество различающихся чисел



            if (element > max) { max = element; } //Находит максимальное значение в коллекции
            if (element < min) { min = element; } //Находит минимальное значение в коллекции
            index++;
        }

        Console.WriteLine("Элементы массива:");
        Console.WriteLine(strElements);
        Console.WriteLine();

        Console.WriteLine($"Количество положительных чисел в коллекции: {countPositive}");
        Console.WriteLine(strPositive);
        Console.WriteLine();

        Console.WriteLine($"Количество отрицателные чисел в коллекции: {countNegative}");
        Console.WriteLine(strNegative);
        Console.WriteLine();

        Console.WriteLine($"Сумма всех чисел в коллекции: {summElements}");
        Console.WriteLine(strSumm);
        Console.WriteLine();

        Console.WriteLine($"Среднее арифметическое: {agvElements}");
        Console.WriteLine(strSrArifm);
        Console.WriteLine();

        Console.WriteLine($"Сумма всех чисел в коллекции кратных 3: {summMod3}");
        Console.WriteLine(strSummMod3);
        Console.WriteLine();

        Console.WriteLine($"Сумма всех чисел в коллекции кратных 5, но больше нуля: {summMod5}");
        Console.WriteLine(strSummMod5);
        Console.WriteLine();

        Console.WriteLine($"Разность всех чисел в коллекции кратных пяти: {subtrnMod5}");
        Console.WriteLine(strSubtrnMod5);
        Console.WriteLine();

        Console.WriteLine($"Количество четных элементов в коллекции: {countEven}");
        Console.WriteLine(strEven);
        Console.WriteLine();

        Console.WriteLine($"Количество нечетных элементов в коллекции: {countOdd}");
        Console.WriteLine(strOdd);
        Console.WriteLine();

    appExit:
        Console.WriteLine();
        Console.WriteLine("========================================================================");
        Console.WriteLine("Выйти из программы [y/n]?");
        string eq = Console.ReadLine();
        if (eq == "n" || eq == "N") { goto appBegin; }
    }

}





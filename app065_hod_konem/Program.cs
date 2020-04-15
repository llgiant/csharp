using System;
using System.Collections.Generic;

class Program
{
    static Random rnd = new Random();

    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("========================================================================");
        Console.WriteLine("Ход Конем");
        Console.WriteLine("========================================================================");
        Console.WriteLine();
        int row = 0;
        int column = 0;
    appBegin:
        Console.WriteLine("Введите координату точки:");
        Console.WriteLine("введите номер ряда от 1 до 10");
    UserInputRow:
        row = int.Parse(Console.ReadLine());
        if (row < 1 || row > 10)
        {
            Console.WriteLine("Число ряда должно быть от 1 до 10:");
            goto UserInputRow;
        }

        Console.WriteLine("введите номер колонки от 1 до 10");
    UserInputColumn:
        column = int.Parse(Console.ReadLine());
        if (column < 1 || column > 10)
        {
            Console.WriteLine("Число колонки должно быть от 1 до 10:");
            goto UserInputColumn;
        }
        DateTime start = DateTime.Now;
        Board b = new Board();
        Cell cell = b.Cells[column + row.ToString()];
        cell.IsEmpty = false;
         b.CheckCells(cell);
        DateTime end = DateTime.Now;
        TimeSpan span = end - start;
        Console.WriteLine($"{span.TotalMinutes}");
        int index = 1;
        foreach (Cell Cell in b.UsedCells)
        {
            Console.WriteLine($"{index}) Row: {Cell.Row} Column: {Cell.Col}");
            index++;
        }

    appExit:
        Console.WriteLine();
        Console.WriteLine("========================================================================");
        Console.WriteLine("Выйти из программы [y/n]?");
        if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }
    }
}

/*
Создать консольное приложение, которое рассчитает и выведет на экран количество
комбинаций удачного прохода Коня по шахматной доске размером 10×10 клеток,
при следующих условиях:
 · конь может начать движение с любой клетки
 · конь ходит по правилам буквы "Г"
 · конь может посетить одну клетку лишь один раз
 · конь должен посетить все 100 клеток доски
 */

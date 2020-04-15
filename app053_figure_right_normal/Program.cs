using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
        RightPentagon pent = new RightPentagon(5);
        Console.WriteLine($"Площадь правильного пятиугольника = {pent.Area}\n" +
            $"Периметр правильного пятиуголника = {pent.Perimetr}");


        appExit:
        Console.WriteLine();
        Console.WriteLine("========================================================================");
        Console.WriteLine("Выйти из программы [y/n]?");
        if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }
    }
}
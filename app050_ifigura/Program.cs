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
        Console.WriteLine("Что будет делать программа?");
        Console.WriteLine("========================================================================");
        Console.WriteLine();
        appBegin:


        Circle circle = new Circle(2, "Кружище");
        Rect rect = new Rect(2, 4, "Прямоугольнище");
        Trapezoid trap = new Trapezoid(4, 6, 3, 2, "Трапезойдище");
        Triangle tria = new Triangle(6, 8, 10, "Треуголничег");

        List<IFigura> figures = new List<IFigura>() { rect, circle, trap, tria };

        foreach (IFigura fig in figures)
        {
            Console.WriteLine($"" +
                $"Название: {fig.Name}\nПлощадь: { fig.Square}\nПериметр: { fig.Perimetr}\n");
        }

        appExit:
        Console.WriteLine();
        Console.WriteLine("========================================================================");
        Console.WriteLine("Выйти из программы [y/n]?");
        if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }
    }
}

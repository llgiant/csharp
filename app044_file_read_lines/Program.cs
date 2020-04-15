using System;
using System.IO;

class Program
{
    static Random rnd = new Random();

    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("========================================================================");
        Console.WriteLine("Запись текстовых файлов");
        Console.WriteLine("========================================================================");
        Console.WriteLine();
        appBegin:

        Console.WriteLine("Введите путь к файлу");
        string path = Console.ReadLine().Trim().ToLower();
        if (string.IsNullOrEmpty(path)) { Console.WriteLine("Файл не существует"); goto appBegin; }
        if (!path.EndsWith(".txt")) { Console.WriteLine("Расширение файла должно быть .txt"); goto appBegin; }
        if (!File.Exists(path)) { Console.WriteLine("такого файла не существует введите путь к существующему файлу"); goto appBegin; }

        string[] nestedLines;
        try { nestedLines = File.ReadAllLines(path, System.Text.Encoding.UTF8); }
        catch (Exception e) { Console.WriteLine(e.ToString()); goto appBegin; }
        Console.WriteLine();
        if (nestedLines == null || nestedLines.Length == 0) { Console.WriteLine("Файл пуст"); }
        else
        {
            foreach (string line in nestedLines)
            {
                if (line.Length > 0) { Console.WriteLine(nestedLines); }
                else { Console.WriteLine(); }
            }

        }

        appExit:
        Console.WriteLine();
        Console.WriteLine("========================================================================");
        Console.WriteLine("Выйти из программы [y/n]?");
        if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }
    }
}

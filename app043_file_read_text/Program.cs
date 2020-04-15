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
        Console.WriteLine("Чтение текстовых файлов");
        Console.WriteLine("========================================================================");
        Console.WriteLine();
        appBegin:

        Console.WriteLine("Введите путь к файлу");
        string path =  Console.ReadLine().Trim().ToLower() ;
        if (string.IsNullOrEmpty(path)) { Console.WriteLine("Файл не существует"); goto appBegin; }
        if (!path.EndsWith(".txt")) { Console.WriteLine("Расширение файла должно быть .txt"); goto appBegin; }
        if (!File.Exists(path)) { Console.WriteLine("такого файла не существует введите путь к существующему файлу"); goto appBegin; }

        string nestedText = "";
        try { nestedText = File.ReadAllText(path); }
        catch (Exception e) { Console.WriteLine(e.ToString()); goto appBegin; }
        Console.WriteLine();
        if (string.IsNullOrEmpty(nestedText)) { Console.WriteLine("Файл пуст"); }
        else { Console.WriteLine(nestedText); }

        appExit:
        Console.WriteLine();
        Console.WriteLine("========================================================================");
        Console.WriteLine("Выйти из программы [y/n]?");
        if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }
    }
}

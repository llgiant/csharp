using System;
using System.IO;

class Program
{
    static Random rnd = new Random();

    static void Main()
    {
        //Console.InputEncoding = System.Text.Encoding;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("========================================================================");
        Console.WriteLine("Запись текстовых файлов");
        Console.WriteLine("========================================================================");
        Console.WriteLine();
        appBegin:

        inputText:
        Console.WriteLine("Введите любой текст:");
        string text = Console.ReadLine().Trim();
        if (string.IsNullOrEmpty(text)) { Console.WriteLine("Текст не может быть пустым!"); goto inputText; };

        inputPath:
        Console.WriteLine("Введите путь к файлу");
        string path = Console.ReadLine().Trim().ToLower();
        if (!File.Exists(path)) { Console.WriteLine("такого файла не существует введите путь к существующему файлу"); goto inputPath; }
        if (string.IsNullOrEmpty(path)) { Console.WriteLine("Файл не существует"); goto inputPath; }
        else
        {
            choice:
            Console.WriteLine("Можно ли записать текст в файл [y/n] или отмена?");
            string choice = Console.ReadLine().Trim().ToLower();
            if (string.IsNullOrEmpty(choice)) { goto choice; }
            if (choice == "y")
            {
                File.WriteAllText(path, text, System.Text.Encoding.UTF8);
                Console.WriteLine($"Текст успешно сохранен в файл \"{path}\"");
            }
            else if (choice == "n") { Console.WriteLine("введите путь к другому файлу"); goto inputPath; }
            else if (choice == "отмена") { goto appEnd; }
            else { goto choice; }

        }
        appExit:
        Console.WriteLine();
        Console.WriteLine("========================================================================");
        Console.WriteLine("Выйти из программы [y/n]?");
        if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }
        appEnd:;
    }
}

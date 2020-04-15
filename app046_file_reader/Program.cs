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
        Console.WriteLine("Файловые потоки для чтения");
        Console.WriteLine("========================================================================");
        Console.WriteLine();
        appBegin:

        using (FileStream fileStream = File.OpenRead(@"C:\Users\llgiant\OneDrive\Dev\v3.log"))
        {
            byte[] fileData = new byte[fileStream.Length];
            fileStream.Read(fileData, 0, (int)fileStream.Length);
        }

        appExit:
        Console.WriteLine();
        Console.WriteLine("========================================================================");
        Console.WriteLine("Выйти из программы [y/n]?");
        if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }
    }
}

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
        Console.WriteLine("Файловые потоки для записи");
        Console.WriteLine("========================================================================");
        Console.WriteLine();
        appBegin:

        byte[] fileData = new byte[] { 199, 20, 106, 47, 32, 1, 254, 220, 13, 10 };

        using (FileStream fileStream = File.OpenWrite(@"C:\Users\llgiant\OneDrive\Dev\v3.log"))
        {
            fileStream.Write(fileData, 0, 10);
        }

        appExit:
        Console.WriteLine();
        Console.WriteLine("========================================================================");
        Console.WriteLine("Выйти из программы [y/n]?");
        if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }
    }
}

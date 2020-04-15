using System;
using System.IO;

public class Program
{
    static Random rnd = new Random();

    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("========================================================================");
        Console.WriteLine("Бинарная сериализация");
        Console.WriteLine("========================================================================");
        Console.WriteLine();
        appBegin:

        using (FileStream fileStream = File.OpenRead(@"C:\Users\llgiant\OneDrive\Dev\tilek.person"))
        {
            using (BinaryReader binaryReader = new BinaryReader(fileStream))
            {
                string FirstName = binaryReader.ReadString();
                string LastName = binaryReader.ReadString();
                int OldYears = binaryReader.ReadInt32();
                bool IsMale = binaryReader.ReadBoolean();
                char ClassLetter = binaryReader.ReadChar();
            }
        }

        appExit:
        Console.WriteLine();
        Console.WriteLine("========================================================================");
        Console.WriteLine("Выйти из программы [y/n]?");
        if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }
    }
}

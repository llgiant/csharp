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

        Person Tilek = new Person()
        {
            FirstName = "Тилек",
            LastName = "Сабитов",
            OldYears = 27,
            IsMale = true,
            ClassLetter = 'v'
        };

        using (FileStream fileStream = File.OpenWrite(@"C:\Users\llgiant\OneDrive\Dev\tilek.person"))
        {
            using(BinaryWriter binaryWriter = new BinaryWriter(fileStream))
            {
                binaryWriter.Write(Tilek.FirstName);
                binaryWriter.Write(Tilek.LastName);
                binaryWriter.Write(Tilek.OldYears);
                binaryWriter.Write(Tilek.IsMale);
                binaryWriter.Write(Tilek.ClassLetter);
            }
        }

        appExit:
        Console.WriteLine();
        Console.WriteLine("========================================================================");
        Console.WriteLine("Выйти из программы [y/n]?");
        if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }
    }
}

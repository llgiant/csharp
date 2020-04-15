using System;
using System.Media;

class Program
{
    static Random rnd = new Random();

    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("========================================================================");
        Console.WriteLine("проигрыватель wav SoundPlayer");
        Console.WriteLine("========================================================================");
        Console.WriteLine();
    appBegin:
        
        SoundPlayer sp = new SoundPlayer();
        sp.SoundLocation = @"C:\Users\Operator\Desktop\123.wav";
        sp.Load();
        sp.St;

    appExit:;
        Console.WriteLine();
        Console.WriteLine("========================================================================");
        Console.WriteLine("Выйти из программы [y/n]?");
        if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }
    }
}

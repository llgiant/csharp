using System;
class Program
{
    static Random rnd = new Random();
    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("========================================================================");
        Console.WriteLine("Игра палочки");
        Console.WriteLine("========================================================================");
        Console.WriteLine();
    appBegin:
        char[] palochki = new char[] { '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|' };
        char[] input = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't' };
        char[] inputCheck = new char[20];

        Console.WriteLine("Выбирете игру:\n1 - играть против человека");
        Console.WriteLine("2 - играть против машины");
        int chooseGame = int.Parse(Console.ReadLine());

        if (chooseGame > 2 || chooseGame < 1) //Выбор игры против компьютера и человека
        {
            Console.WriteLine($"Такой игры нет в списке");
            goto appBegin;
        }


        if (chooseGame == 1) //Игра против человека
        {
            foreach (char letter in palochki) { Console.Write(letter + " "); }
            Console.WriteLine();
            foreach (char letter in input) { Console.Write(letter + " "); }



        }
        else  //Игра против компьютера
        {




        }

    appExit:
        Console.WriteLine();
        Console.WriteLine("========================================================================");
        Console.WriteLine("Выйти из программы [y/n]?");
        string eq = Console.ReadLine();
        if (eq == "n" || eq == "N") { goto appBegin; }
    }
}

using System;

class Program
{
    static Random rnd = new Random();

    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("========================================================================");
        Console.WriteLine("Пьяница");
        Console.WriteLine("========================================================================");
        Console.WriteLine();
        appBegin:


        Game game = new Game();
        Player takePlayer = Player.None;
        #region ХОД ИГРЫ

        do
        {
            do
            {
                Console.WriteLine("Ввод:");
                if (Console.ReadLine().Trim().ToLower() == "q") { goto appBegin; }
                takePlayer = game.Step();
            } while (takePlayer == Player.None && game.Winner == Player.None); ;
            Console.WriteLine(game.Draw());

        } while (!game.IsFinal);

        Console.WriteLine("Игрок " + (game.Winner == Player.Left ? "слева" : "справа") + " победил");
        #endregion


        appExit:
        Console.WriteLine("========================================================================");
        Console.WriteLine("Повторить игру [y/n]?");
        if (Console.ReadLine().Trim().ToLower() == "y") { goto appBegin; }

    }



}

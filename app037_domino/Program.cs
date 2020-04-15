using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
class Program
{
    static Random rnd = new Random();

    static void Main()
    {
        #region ШАПКА
        //Console.InputEncoding = System.Text.Encoding.UTF8;
        //Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("========================================================================");
        Console.WriteLine("Игра \"ДОМИНО\"");
        Console.WriteLine("========================================================================");
        Console.WriteLine();
        appBegin:
        #endregion

        #region Объекты класса Player,Game             
        Player player1 = new Player();
        Player player2 = new Player();
        player1.Name = "Робот1";             //имя первого игрока по умолчанию
        player2.Name = "Робот2";            //имя второго игрока по умолчанию
        player1.Type = 0;
        player2.Type = 0;
        Game game = new Game(player1, player2);
        #endregion

        //Ввести путь к файлу с сохраненной игрой
        loadGame:
        Console.WriteLine("Загрузить ранее сохраненную игру? [y/n]?");
        if (Console.ReadLine().Trim().ToLower() == "y")
        {
            Console.WriteLine("Введите путь к файлу с сохраненной игрой: ");
            string path = Console.ReadLine().ToLower();
            //проверка пути файла-----------------------
            try
            {
                game = Game.Load(path);
            }
            catch (Exception e) { Console.WriteLine(e.Message); goto loadGame; }
        }
        else
        {


            #region Выбор игрока 
            Console.WriteLine($"Выберите против кого вы будете играть:\n0-человек против человека\n1-человек против робота" +
                $"\n2-робот против робота");
            inputOpp:
            try
            {
                player2.Type = (PlayerType)int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Повторите:");
                goto inputOpp;
            }

            if (player2.Type == (PlayerType)2) { player1.Type = (PlayerType)1; player2.Type = (PlayerType)1; }
            #endregion

            #region Ввод имен пользователей
            if (player1.Type == PlayerType.Human)
            {
                Console.WriteLine($"Введите имя первого игрока:");
                inputName1:
                try
                {
                    player1.Name = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Повторите:");
                    goto inputName1;
                }
            }
            if (player2.Type == PlayerType.Human)
            {
                {
                    Console.WriteLine($"Введите имя второго игрока:");
                    inputName2:
                    try
                    {
                        player2.Name = Console.ReadLine();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Повторите:");
                        goto inputName2;
                    }
                }
            }
            #endregion
        }
        #region ХОД ИГРЫ
        string stepBone;       // номер кости выбранной игроком
        string strError = "";  //сообщение об ошибке
        do
        {
            startLoadedGame:
            Console.WriteLine("========================================================================");
            Console.WriteLine(game.Draw());
            Console.WriteLine("========================================================================");
            inputStep:
            Console.Write($"Ходит {game.CurrentPlayer.Name}.");
            if (game.CurrentPlayer.Type != PlayerType.Robot)
            {
                Console.WriteLine();
                stepBone = Console.ReadLine();

                if (stepBone == "save")
                {
                    saveGame:
                    try
                    {
                        Console.WriteLine("Введите путь к файлу для сохранения игры: ");
                        game.Save(Console.ReadLine());
                        Console.WriteLine("Игра сохранена успешно!");
                        goto inputStep;
                    }
                    catch (Exception e) { Console.WriteLine(e.Message); goto saveGame; }
                }
                else if (stepBone == "load")
                {
                    inputPath:
                    try
                    {

                        Console.WriteLine("Введите путь к файлу для загрузки сохраненной игры: ");
                        Game.Load(Console.ReadLine());
                        Console.WriteLine("Игра загружена успешно!");
                        goto startLoadedGame;
                    }
                    catch (Exception e) { Console.WriteLine(e.Message); goto inputPath; }
                }
            }
            else
            {
                Console.WriteLine();
                stepBone = "";
                Console.ReadKey();
            }
            strError = game._step(stepBone);// проверка введенной кости
            if (strError.Length > 0)
            {
                Console.WriteLine(strError + ".\nВаш ход:");
                goto inputStep;
            }

        } while (!game.IsFinal);
        #endregion

        #region Финиш
        Console.WriteLine("========================================================================");
        Console.WriteLine("Игра окончена.");
        if (game.Winner == null) { Console.WriteLine("Ничья!"); }
        else { Console.WriteLine($"Победил {game.Winner.Name}"); }

        appExit:
        Console.WriteLine();
        Console.WriteLine("========================================================================");
        Console.WriteLine("Выйти из программы [y/n]?");
        if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }
        #endregion
    }
}

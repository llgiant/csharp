﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Program
{
    static Random rnd = new Random();

    static void Main()
    {
        #region ШАПКА
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("========================================================================");
        Console.WriteLine("Игра \"ДОМИНО\"");
        Console.WriteLine("========================================================================");
        Console.WriteLine();
    appBegin:
        #endregion

        #region РАЗДАЧА
        List<Bone> bazar = new List<Bone>();
        List<Bone> field = new List<Bone>();
        List<Bone> playerOne = new List<Bone>();
        List<Bone> playerTwo = new List<Bone>();

        while (field.Count < 28)
        {
            int left = rnd.Next(0, 7);
            int right = rnd.Next(0, 7);
            if (!field.Contains(new Bone(left, right)))
            {
                if (playerOne.Count < 6) { playerOne.Add(new Bone(left, right)); }
                else if (playerTwo.Count < 6) { playerTwo.Add(new Bone(left, right)); }
                else { bazar.Add(new Bone(left, right)); }
                field.Add(new Bone(left, right));
            }
        }
        field.Clear();
        #endregion

        #region Объекты класса Player,Game             
        Player player1 = new Player();
        Player player2 = new Player();
        Game game = new Game(player1, player2);
        #endregion

        #region Поля класса
        playerOne.Name = "Робот№1";             //имя первого игрока по умолчанию
        playerTwo.Name = "Робот№2";            //имя второго игрока по умолчанию
        int gameMode = 0;                    // Вид игры, 0 - легкая(по умолчанию), 1 - сложная	
        playerOne.Type = 0;
        playerTwo.Type = 0;
        #endregion

        #region Выбор сложности игры		
        if (playerTwo.Type != PlayerType.Human)
        {
            Console.WriteLine($"Выбирите сложность игры:\n0-Легко\n1-Тяжело");
        inputLevel:
            try
            {
                game.GameMode = (GameMode)int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Повторите:");
                goto inputLevel;
            }
        }
        #endregion

        #region ХОД ИГРЫ
        string stepBone; // номер кости выбранной игроком
        string strError = "";  //сообщение об ошибке
        do
        {
            Console.Write(Bone.Draw());
            Console.Write($"Ходит {game.CurrentPlayer.Name}.");
        inputStep:
            if (game.CurrentPlayer.Type != PlayerType.Robot1 && game.CurrentPlayer.Type != PlayerType.Robot2)
            {
                Console.WriteLine($"Выбирите кость от 1 до 6:");
                stepBone = Console.ReadLine();


            }
            else
            {
                Console.WriteLine();
                stepBone = "";
                Console.ReadKey();
            }

            strError = game._step(stepCoords);

            // проверка введенных координат
            if (strError.Length > 0)
            {
                Console.WriteLine(strError + ".\nПовторите:");
                goto inputStep;
            }

        } while (!game.IsFinal);
        Console.Write(game.Draw());
        #endregion

        #region Футер
        Console.WriteLine("========================================================================");
        Console.WriteLine("Игра окончена.");
    //if (game.Winner == null) { Console.WriteLine("Ничья!"); }
    //else { Console.WriteLine($"Победил {game.Winner.Name}"); }

    appExit:
        Console.WriteLine();
        Console.WriteLine("========================================================================");
        Console.WriteLine("Выйти из программы [y/n]?");
        if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }
        #endregion
    }
}

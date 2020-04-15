using System;
using System.IO;

class Program
{
    static Random rnd = new Random();

    static void Main()
    {
        #region ШАПКА
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("========================================================================");
        Console.WriteLine("Игра \"Крестики-нолики\"");
        Console.WriteLine("========================================================================");
        Console.WriteLine();
        #endregion

        appBegin:
        #region Объекты класса Player, Cell, Game             
        Cell cell = new Cell();
        Player player1 = new Player();
        Player player2 = new Player();
        Game game = new Game(player1, player2);
        string gameData;
        #endregion

        #region Поля класса
        player1.Name = "Робот№1";         //имя первого игрока по умолчанию
        player2.Name = "Робот№2";         //имя второго игрока по умолчанию 
        player1.Type = 0;
        player2.Type = 0;
        #endregion

        //Ввести путь к файлу с сохраненной игрой
        loadGame:
        Console.WriteLine("Загрузить ранее сохраненную игру? [y/n]?");
        if (Console.ReadLine().Trim().ToLower() == "y")
        {
            Console.WriteLine("Введите путь к сохраненной игре: ");
            try
            {
                game = Game.Load(Console.ReadLine());
            }
            catch (Exception e) { Console.WriteLine(e.Message); goto loadGame; }
        }
        else
        {

            #region Выбор размерности игры
            Console.WriteLine($"Выберите размерность поля от 3 до 8:");
            inputcellMode:
            try { game.FieldSize = int.Parse(Console.ReadLine()); }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Повторите:");
                goto inputcellMode;
            }
            Console.WriteLine($"Выберите против кого вы будете играть:\n0-человек против человека\n1-человек против робота\n2-робот№1 против робот№2");
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

            if (player2.Type == (PlayerType)2) { player1.Type = player2.Type; }
            #endregion

            #region Выбор сложности игры		
            if (player2.Type != PlayerType.Human)
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

            #region Выбор первого игрока "х" или "о"
            int fishka = rnd.Next(0, 2);
            player1.Fishka = fishka == 0 ? "o" : "x";
            player2.Fishka = "x".Contains(player1.Fishka) ? "o" : "x";
            Console.WriteLine($"{player1.Name} ходит \"{player1.Fishka}\" ");
            Console.WriteLine($"{player2.Name} ходит \"{player2.Fishka}\"");
            #endregion
        }
        string stepCoords = ""; //координаты введенные игроком
        string strError = "";   //сообщение об ошибке введенных не корректно координат

        //Действие игры, ходы игроков
        do
        {
            Console.Write(game.Draw());
            Console.Write($"Ходит {game.CurrentPlayer.Name}.\n");
            inputStep:
            if (game.CurrentPlayer.Type != PlayerType.Robot)
            {
                saveGame:
                Console.WriteLine("Введите коородинату || Cохраните игру - \"save\" || Загрузите игру? - \"load\" ");
                stepCoords = Console.ReadLine();
                if (stepCoords == "save")
                {
                    Console.WriteLine("Введите путь к файлу для сохранения игры:");
                    try
                    {
                        game.Save(Console.ReadLine());
                        Console.WriteLine("Игра сохранена успешно!");
                        goto inputStep;
                    }
                    catch (Exception e) { Console.WriteLine(e.Message); goto saveGame; }
                }
                else if (stepCoords == "load")
                {
                    Console.WriteLine("Введите путь к сохраненной игре:");
                    try
                    {
                        //временный объект game
                        Game preGame = Game.Load(Console.ReadLine());

                        Console.WriteLine("Игра загружена успешно!");
                        goto inputStep;
                    }
                    catch (Exception e) { Console.WriteLine(e.Message); goto loadGame; }
                }
            }
            else
            {
                Console.WriteLine();
                stepCoords = "";
            }

            strError = game.Step(stepCoords);

            // проверка введенных координат
            if (strError.Length > 0)
            {
                Console.WriteLine(strError + ".\nПовторите:");
                goto inputStep;
            }

        } while (!game.IsFinal);
        Console.Write(game.Draw());

        Console.WriteLine("========================================================================");
        Console.WriteLine("Игра окончена.");
        if (game.Winner == null) { Console.WriteLine("Ничья!"); }
        else { Console.WriteLine($"Победил {game.Winner.Name}"); }

        appExit:
        Console.WriteLine();
        Console.WriteLine("========================================================================");
        Console.WriteLine("Выйти из программы [y/n]?");
        if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }
    }
}

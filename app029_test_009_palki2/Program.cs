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
        Console.WriteLine("Игра палочки!\nИгроки ходят по очереди, вводят от 1 до 3 букв палочки над которыми надо убрать.\nПроигрывает тот, кто уберет последнюю палочку.");
        Console.WriteLine("========================================================================");
        Console.WriteLine();
        appBegin:

        bool[] palki = new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true };
        string userInput = "";
        string normalize = "";
        int ostatok = 20;
        bool stepIsHuman = true;
        int removed = 0;        
        string path;
        string gameData;

        Console.WriteLine("Загрузить сохраненную игру? [y/n]?");
        if (Console.ReadLine().Trim().ToLower() == "y")
        {
            Console.WriteLine("Введите путь к файлу с сохраненной игрой");
            path = Console.ReadLine().Trim().ToLower();
            if (string.IsNullOrEmpty(path)) { Console.WriteLine($"Файл \"{path}\" не существует"); goto appBegin; }
            if (!path.EndsWith(".palki")) { Console.WriteLine("Расширение файла должно быть .palki"); goto appBegin; }
            if (!File.Exists(path)) { Console.WriteLine("Такого файла не существует"); goto appBegin; }

            try { gameData = File.ReadAllText(path, System.Text.Encoding.UTF8); }
            catch (Exception e) { Console.WriteLine(e); goto appBegin; }
            Console.WriteLine();
            if (string.IsNullOrWhiteSpace(gameData) || gameData.Length < 1 || gameData.Length > 20) { Console.WriteLine("Сохраненной игры нет, игра начнётся с начала.\n"); }
            else
            {
                try
                {
                    int index = 0;
                    do { palki[index] = gameData[index] == '0' ? false : true; index++; }
                    while (index < 20);
                }
                catch
                {
                    Console.WriteLine("Данные повреждены, загрузите другой файл");
                }
            }
        }

        while (true)
        {
            foreach (bool P in palki) { Console.Write(P ? "| " : "  "); }
            Console.WriteLine();
            for (int i = 0; i < 20; i++) { Console.Write((char)(i + 97) + " "); }
            Console.WriteLine();

            if (stepIsHuman) //Ход польозователя
            {
                inputUser:
                Console.WriteLine("\nВаш ход || \"save\" - cохранить игру: || \"exit\" выход из игры");             
                normalize = "";
                userInput = Console.ReadLine().Trim().ToLower();
                if (userInput == "save")
                {
                    loadSavedFile:
                    Console.WriteLine("Введите путь к файлу для сохранения игры");
                    path = Console.ReadLine().Trim().ToLower();
                    if (string.IsNullOrEmpty(path)) { Console.WriteLine($"Файл \"{path}\" не существует"); goto loadSavedFile; }
                    if (!path.EndsWith(".palki")) { Console.WriteLine("Расширение файла должно быть .palki"); goto loadSavedFile; }
                    if (!File.Exists(path)) { Console.WriteLine("Такого файла не существует введите путь к существующему файлу"); goto loadSavedFile; }

                    gameData = "";
                    for (int i = 0; i < palki.Length; i++)
                    {
                        gameData += palki[i] ? "1" : "0";
                    }
                    File.WriteAllText(path, gameData, System.Text.Encoding.UTF8);
                    goto inputUser;
                }
                else if (userInput == "exit") {goto appExit; }
                    

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("Укажите буквы 1-3 палочек:");
                    goto inputUser;
                }
                else if (userInput.Length > 3)
                {
                    Console.WriteLine("Можно выбрать не более трех палочек.\nПовторите:");
                    goto inputUser;
                }

                foreach (char L in userInput)
                {
                    if (!"abcdefghijklmnopqrst".Contains(L.ToString()))
                    {
                        Console.WriteLine($"Палочки с именем '{L}' нет в игре.\nПовторите:");
                        goto inputUser;
                    }
                    if (normalize.Contains(L.ToString()))
                    {
                        Console.WriteLine($"Палочка с именем '{L}' уже указана.\nПовторите:");
                        goto inputUser;
                    }
                    normalize += L;
                }

                foreach (char L in normalize)
                {
                    if (!palki[L - 97])
                    {
                        Console.WriteLine($"Палочка с именем '{L}' уже убрана.\nПовторите:");
                        goto inputUser;
                    }
                }
                foreach (char L in normalize) { palki[L - 97] = false; ostatok--; }
            }
            else //Ход компьютера
            {
                Console.WriteLine("\nХод компьютера:");
                removed = ostatok > 4 ? (ostatok % 4) - 1 : ostatok - 1;
                if (removed < 1) { removed = 1; }

                for (int i = 0; i < palki.Length; i++)
                {
                    if (palki[i])
                    {
                        palki[i] = false;
                        ostatok--;
                        removed--;
                        Console.Write((char)(i + 97));
                    }
                    if (removed == 0) { break; }
                }
                Console.WriteLine();
            }
            if (ostatok == 0)
            {
                //Конец игры, объявить победителя и проигравшего
                Console.WriteLine($"Ходов не осталоь! Пбедил {(stepIsHuman ? "компьютер" : "человек")}!");
                break;
            }

            stepIsHuman = !stepIsHuman;
        }
        appExit:
        Console.WriteLine();
        Console.WriteLine("========================================================================");
        Console.WriteLine("Выйти из программы [y/n]?");
        string eq = Console.ReadLine();
        if (eq == "n" || eq == "N") { goto appBegin; }
    }
}

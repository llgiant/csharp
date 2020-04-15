using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static Random rnd = new Random();
    static object locker = new object();

    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("========================================================================");
        Console.WriteLine("Работа с потоками");
        Console.WriteLine("========================================================================");
        Console.WriteLine();
        appBegin:

        Dictionary<string, int> Params = new Dictionary<string, int>()
        {
            { "listNumber", 1 },
            { "wordCount", 30000}
        };
        Thread generatorThread1 = new Thread(wordGenerator);
        generatorThread1.IsBackground = true;
        generatorThread1.Priority = ThreadPriority.Highest;
        generatorThread1.Start(Params);

        Params = new Dictionary<string, int>()
        {
            { "listNumber", 2 },
            { "wordCount", 50000}
        };
        Thread generatorThread2 = new Thread(wordGenerator);
        generatorThread2.IsBackground = true;
        generatorThread2.Priority = ThreadPriority.Highest;
        generatorThread2.Start(Params);

        Params = new Dictionary<string, int>()
        {
            { "listNumber", 3 },
            { "wordCount", 20000}
        };
        Thread generatorThread3 = new Thread(wordGenerator);
        generatorThread3.IsBackground = true;
        generatorThread3.Priority = ThreadPriority.Highest;
        generatorThread3.Start(Params);

        //List<string> list = new List<string>();
        //list = wordGenerator(30000, 1);

        appExit:
        Console.WriteLine();
        Console.WriteLine("========================================================================");
        Console.WriteLine("Выйти из программы [y/n]?");
        if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }
    }


    public static void wordGenerator(object inParams)
    {
        Dictionary<string, int> Params = (Dictionary<string, int>)inParams;
        int listNumber = Params["listNumber"];
        int wordCount = Params["wordCount"];

        Console.WriteLine(Thread.CurrentThread.Name + "Поток № " + listNumber + " запущен");

        List<string> list = new List<string>();
        string word = "";
        int wordLength = 0;

        while (list.Count < wordCount)
        {
            word = "";
            lock (locker)
            {
                wordLength = rnd.Next(8, 16);
            }

            while (word.Length < wordLength)
            {
                lock (locker)
                {
                    word += (char)rnd.Next(97, 123);
                }
            }

            if (!list.Contains(word))
            {
                list.Add(word);
                if (list.Count % 3000 == 0)
                {
                    Console.WriteLine(listNumber + " - progress - " + list.Count);
                }
            }
        }
        Console.WriteLine(Thread.CurrentThread.Name + "Поток № " + listNumber + " остановлен");
        //return list;
    }
}
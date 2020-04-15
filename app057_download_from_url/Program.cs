using System;
using System.Net;

class Program
{
    static Random rnd = new Random();

    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("========================================================================");
        Console.WriteLine("Загрузка данных из URL?");
        Console.WriteLine("========================================================================");
        Console.WriteLine();
        appBegin:

        Console.WriteLine("Введите адрес для скачивания файла:");
        string urlPath = Console.ReadLine().Trim().ToLower();


        string fileName = @"C:\Users\llgiant\OneDrive\Dev\downloadedFile.html";


        using (WebClient client = new WebClient())
        {
            try { client.DownloadFile(urlPath, fileName); }
            catch (Exception e)
            {
                Console.WriteLine("Введенный адрес неверен попробейте снова.");
                goto appBegin;
            }
        }


        appExit:
        Console.WriteLine();
        Console.WriteLine("========================================================================");
        Console.WriteLine("Выйти из программы [y/n]?");
        if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }
    }
}

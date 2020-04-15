using System;
using System.IO;
using System.Net;

class Program
{
    static Random rnd = new Random();

    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("========================================================================");
        Console.WriteLine("Что будет делать программа?");
        Console.WriteLine("========================================================================");
        Console.WriteLine();
        byte[] Buffer = null;


    userInput:
        //Console.WriteLine("Введите адрес URL страницы");
        WebClient client = new WebClient();
        //проверка ввода
        try

        {
            Buffer = client.DownloadData("https://www.lamoda.ru/");
        }
        catch (Exception) { Console.WriteLine("Ошибка ввода, повторите:"); goto userInput; }
        string[] page = System.Text.Encoding.UTF8.GetString(Buffer).Split('\n');
        string path = @"C:\Users\llgiant\Desktop\123.txt";

        //File.WriteAllLines(path, page, System.Text.Encoding.UTF8);
        string url = "https://www.lamoda.ru/lp/safe_delivery";
        //using (var webClient = new WebClient())
        //{
        //    // Выполняем запрос по адресу и получаем ответ в виде строки
        //    File.WriteAllText(path, webClient.DownloadString(url), System.Text.Encoding.UTF8);
        //}

        HttpWebResponse response = (HttpWebResponse)WebRequest.Create(url).GetResponse();
        Console.WriteLine(response.StatusCode);



        appExit:
        Console.WriteLine();
        Console.WriteLine("========================================================================");
        Console.WriteLine("Выйти из программы [y/n]?");
        if (Console.ReadLine().Trim().ToLower() == "n") { goto userInput; }
    }
}


/*
 1. Парсинг ссылок на web-страницах

Создать консольное приложение, которое запрашивает у пользователья url-адрес
какой-либо web-страницы. Программа скачивает файл страницы и выполняет поиск
всех вхождений ссылок (теги <a>). URL-адрес каждой ссылки находится в атрибуте
href, который есть (или нет) у ссылок. После, программа выводит на консоль
список найденных у ссылок адресов с результатом проверки: какой код отдан при
запросе по адресу ссылки. При этом учитывать относительные пути ссылок.
При запросе кода ответа сервер должен "думать", что запрос выполнет браузер.
 */

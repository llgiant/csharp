using System;
using System.IO;
using System.Net;
using System.Threading;

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
        string ahref = "<a href=\"/";
        Uri URL = null;
    userInput:
        Console.WriteLine("Введите адрес URL страницы");
        string UserInput = Console.ReadLine();
        //проверка ввода
        try { URL = new Uri(UserInput); }
        catch (Exception) { Console.WriteLine("Ошибка ввода, повторите:"); goto userInput; }

        WebClient client = new WebClient();

        string host = URL.Host;
        //проверка ввода
        try { Buffer = client.DownloadData(URL.AbsoluteUri); }
        catch (Exception) { Console.WriteLine("Ошибка ввода, повторите:"); goto userInput; }

        string[] page = System.Text.Encoding.UTF8.GetString(Buffer).Split('\n');

        int caret = -1;
        int startHref = 0;
        int index = 0;
        while (index < page.Length)
        {
            caret = page[index].IndexOf(ahref);
            if (caret < 0) { goto EndLoop; }
            startHref = caret + 10;// <a href=" - 9 символов
            caret = page[index].IndexOf('"', startHref);
            if (caret < 0) { goto EndLoop; }
            string path = URL.AbsoluteUri + page[index].Substring(startHref, caret - startHref);
            caret = -1;
            Thread HttpResponseThread = new Thread(HttpResponse);
            HttpResponseThread.IsBackground = false;
            HttpResponseThread.Start(path);
        EndLoop:;
            index++;
        }
        Console.ReadKey();
    }
    private static void HttpResponse(object path)
    {
        string _path = (string)path;
        HttpWebResponse response = null;
        // Create a request for the URL. 		
        WebRequest request = WebRequest.Create(_path);
        // Get the response.
        try { response = (HttpWebResponse)request.GetResponse(); }
        catch (Exception) { }
        // Display the status
        string responseCode = response == null ? "Not Found" : response.StatusCode.ToString();
        Console.WriteLine($"URL: {_path}\nResponse statuscode: {responseCode}");
        if (response == null) { return; }
        response.Close();
    }
}

//string path = @"C:\Users\llgiant\Desktop\123.txt";  URL.AbsoluteUri + path = "https://milomoor.ru/delivery.html"

////File.WriteAllLines(path, page, System.Text.Encoding.UTF8);
//string url = "https://www.lamoda.ru/lp/safe_delivery";
//using (var webClient = new WebClient())
//{
//    // Выполняем запрос по адресу и получаем ответ в виде строки
//    File.WriteAllText(path, webClient.DownloadString(url), System.Text.Encoding.UTF8);
//}
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

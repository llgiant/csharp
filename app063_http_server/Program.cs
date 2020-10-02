using System;
using System.Net;
using System.IO;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;

class Program
{
    public static string RootDirectory = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\www";
    public static string canonicalUrl = "";
    public static List<Template> RoutesTemplates;

    static void Main()
    {
        //Console.InputEncoding = System.Text.Encoding.UTF8;
        //Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("========================================================================");
        Console.WriteLine("Web server test.com");
        Console.WriteLine("========================================================================");
        Console.WriteLine();
    appBegin:

        //Заполнение спист=ка шаблонов url
        RoutesTemplates = FillTemplates();

    startServer:
        try
        {
            Thread httpListenerThread = new Thread(StartListening);
            httpListenerThread.IsBackground = true;
            httpListenerThread.Start();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            goto startServer;
        }

        if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }
    }

    public static void StartListening()
    {
        HttpListener httpListener = new HttpListener();
        httpListener.Prefixes.Add("http://www.test.com/");
        httpListener.Prefixes.Add("http://test.com/");
        httpListener.Start();
        Console.WriteLine($"{GetDate()}:Сервер запущен!");

        while (httpListener.IsListening)
        {
            HttpListenerContext httpContext = httpListener.GetContext();
            Thread httpListenerContextThread = new Thread(Welcome);
            httpListenerContextThread.IsBackground = true;
            httpListenerContextThread.Start(httpContext);
        }
    }

    //Welcome выясняет кто будет обрабатывать запрос
    public static void Welcome(object listener)
    {
        HttpListenerContext httpContext = (HttpListenerContext)listener;
        BaseHandler Handler = null;

        //Канонизация адреса
        try { canonicalUrl = CanonizeUrl(httpContext.Request.Url); }
        catch (Exception)
        {
            //если не правильный адрес 400 обработчик
            Handler = new StatusCodeHandler_400();
            goto RunHandler;
        }

        if (httpContext.Request.Url.ToString() != canonicalUrl)
        {
            //если не канонический адрес 301 обработчик на конанический
            Handler = new StatusCodeHandler_301(canonicalUrl);
            goto RunHandler;
        }

        Dictionary<string, string> fieldsDictionary;
        //перебор шаблонов, поиск обработчика
        foreach (Template template in RoutesTemplates)
        {
            try
            {
                fieldsDictionary = template.Match(httpContext.Request.Url);
                if (fieldsDictionary == null) { continue; }
                Handler = template.Handler;
                break;
            }
            catch (Exception) { Handler = new StatusCodeHandler_400(); goto RunHandler; }

        }

    RunHandler:
        if (Handler == null) { Handler = new StatusCodeHandler_404(); }
        try
        {
            Handler.Proccess(httpContext);
        }
        catch (Exception e)
        {

        }
    }

    public static string CanonizeUrl(Uri url)
    {
        string str = url.AbsoluteUri;
        //разрешенные символы в строке
        string allSigns = "abcdefghijklmnopqrstuvwxyz0123456789/-.:_";
        //string port = "";
        string localPath = "";
        string protocol;
        string query = string.Empty;
        string host = "";

        //отделение части параметров от основной строки
        int caret = str.IndexOf('?', 0);
        if (caret > 0)
        {
            //обрезаем параметры от основной строки
            query = str.Substring(caret, str.Length - caret);

            //основная строка без параметров
            str = str.Substring(0, caret).ToLower();
        }

        //проверка строки на недопустимые символы
        foreach (var item in str.ToCharArray())
        {
            if (!allSigns.Contains(item.ToString()))
            {
                throw new Exception($"Symbol \"{item.ToString()}\" is not allowed in the sting");
            }
        }

        //поиск протокола
        caret = str.IndexOf(':', 0);
        if (caret > 3 && caret < 6)
        {
            protocol = str.Substring(0, caret + 3);
            if (protocol != "http://" && protocol != "https://") { throw new Exception("protocol ERROR"); }
            str = str.Replace(protocol, "");

            //Символ в строке для сравнения со следующим
            char symbol = ' ';
            //Следующим символ в строке для сравнения с предыдущим 
            char nextSymbol = ' ';
            int index = 0;

            while (index < str.Length)
            {
                symbol = str[index];
                //  проверка: символы из OtherPunctuation не должны повторяться либо идти друг за другом иначе ошибка
                if (index + 1 < str.Length)
                {
                    nextSymbol = str[index + 1];
                    if (char.GetUnicodeCategory(symbol).Equals(UnicodeCategory.OtherPunctuation))
                    {
                        if ("/-.".Contains(nextSymbol.ToString())) { throw new Exception($"symbol \"{nextSymbol}\" can't go after \"{symbol}\" "); }
                    }
                }
                index++;
            }
        }
        else { throw new Exception("protocol ERROR"); }

        //если
        caret = str.IndexOf('/', 0);
        if (caret > 0)
        {
            string strTempHost = str.Substring(0, caret);
            localPath = str.Length - caret < 2 ? "" : str.Replace(strTempHost, "");
            if (localPath.Length > 10 && localPath.Contains("index.html")) { localPath = localPath.Replace("/index.html", ""); }
            str = strTempHost;
        }

        //обрезка порта
        caret = str.IndexOf(':', 0);

        if (caret > 0) { host = str.Substring(0, caret); }
        else { host = str; }
        //обрезка www
        if (host.Substring(0, 4) == "www.") { host = host.Substring(4, host.Length - 4); }

        return protocol + host + (localPath.Length == 0 ? "/" : localPath) + query;
    }

    public static string GetDate()
    {
        return DateTime.UtcNow.ToString("[HH:mm:ss dd-MM-yyyy]");
    }
    public static List<Template> FillTemplates()
    {
        List<Template> templates = new List<Template>();
        object staticHandler = Activator.CreateInstance(typeof(StaticHandler));


        //templates.Add(new Template("/portfolio/work-{workid}.html", new Dictionary<string, validateProc> { { "workid", Template.validate_workID } }, staticHandler));

        templates.Add(new Template("/", null, staticHandler));

        templates.Add(
            new Template("/{imageFileName}.{extension}", new Dictionary<string, validateProc>{
                { "imageFileName",  Template.validate_imageFileName },
                { "extension",  Template.validate_extension }
                                                                                                 }, staticHandler));

        templates.Add(
           new Template("/style/{stylepath}.css",
           new Dictionary<string, validateProc>
              {
                            { "stylepath",  Template.validate_stylePath }
                 }, staticHandler));
        templates.Add(
           new Template("/api/{apinumbers}",
           new Dictionary<string, validateProc>
              {
                            { "apinumbers",  Template.validate_apinumbers }
                 }, staticHandler));


        templates.Add(
           new Template("/js/{scriptPath}.js",
           new Dictionary<string, validateProc>
              {
                            { "scriptPath",  Template.validate_scriptPath }
                 }, staticHandler));

        templates.Add(
            new Template("/images/{imageFileName}.{extension}",
            new Dictionary<string, validateProc>
            {
                { "imageFileName",  Template.validate_imageFileName },
                { "extension",  Template.validate_extension }
               }, staticHandler));

        //templates.Add(
        //   new Template("/video/{imageFileName}.{extension}",
        //   new Dictionary<string, validateProc>
        //   {
        //        { "imageFileName",  Template.validate_imageFileName },
        //        { "extension",  Template.validate_videoextension }
        //      }, staticHandler));

        //templates.Add(new Template("/main.html", null, staticHandler));
        //templates.Add(new Template("/about.html", null, staticHandler));
        //templates.Add(new Template("/portfolio.html", null, staticHandler));
        //templates.Add(new Template("/blog.html", null, staticHandler));

        //templates.Add(
        //   new Template("/blog/post/{postid}.html",
        //   new Dictionary<string, validateProc>
        //    {
        //        { "postid",  Template.validate_postID }
        //    }, staticHandler));

        //templates.Add(
        //   new Template("/{filepath}.txt",
        //   new Dictionary<string, validateProc>
        //   {
        //            { "filepath",  Template.validate_filePath }
        //      }, staticHandler));

        //templates.Add(
        //   new Template("/user/avatar/{userid}.jpg",
        //   new Dictionary<string, validateProc>
        //    {
        //        { "userid",  Template.validate_userID }
        //    }, staticHandler));

        //templates.Add(
        //   new Template("/promo-{promoid}.html",
        //   new Dictionary<string, validateProc>
        //    {
        //        { "promoid",  Template.validate_promoID }
        //}, staticHandler));

        //templates.Add(
        //   new Template("/blog/year-{year}.html",
        //   new Dictionary<string, validateProc>
        //      {
        //                    { "year",  Template.validate_year }
        //         }, staticHandler));

        //templates.Add(
        //    new Template("/blog/year-{year}/month-{month}/list.html",
        //    new Dictionary<string, validateProc>
        //    {
        //                    { "year",  Template.validate_year },
        //                    { "month",  Template.validate_month }
        //    }, staticHandler));

        //templates.Add(
        //   new Template("/blog/tag-{tagname}.html",
        //   new Dictionary<string, validateProc>
        //      {
        //                    { "tagname",  Template.validate_tagName }
        //         }, staticHandler));

        //templates.Add(
        //  new Template("/orders.html", null, staticHandler));

        //templates.Add(
        //   new Template("/orders/{date}.html?sort={sort}&view={view}",
        //   new Dictionary<string, validateProc>
        //   {
        //        { "date",  Template.validate_date },
        //        { "sort",  Template.validate_sort },
        //        { "view",  Template.validate_view }
        //   }, staticHandler));

        //templates.Add(
        //   new Template("/chat/{chatID}/user-1-{user1ID}/user-2-{user2ID}.html",
        //   new Dictionary<string, validateProc>
        //   {
        //        { "chatID",  Template.validate_chatID },
        //        { "user1ID",  Template.validate_userID },
        //        { "user2ID",  Template.validate_userID }
        //   }, staticHandler));

        //templates.Add(
        //   new Template("/app/{scriptPath}.js",
        //   new Dictionary<string, validateProc>
        //      {
        //                    { "scriptPath",  Template.validate_scriptPath }
        //         }, staticHandler));

        //templates.Add(
        //   new Template("/app/style/{stylePath}.css",
        //   new Dictionary<string, validateProc>
        //      {
        //                    { "stylePath",  Template.validate_stylePath }
        //         }, staticHandler));

        //templates.Add(
        //    new Template("/app/style/images/{imageFileName}.{extension}",
        //    new Dictionary<string, validateProc>
        //    {
        //        { "imageFileName",  Template.validate_imageFileName },
        //        { "extension",  Template.validate_extension }
        //       }, staticHandler));

        return templates;
    }
}



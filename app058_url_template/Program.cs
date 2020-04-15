using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("========================================================================");
        Console.WriteLine("Что будет делать программа?");
        Console.WriteLine("========================================================================");
        Console.WriteLine();
        appBegin:
        Dictionary<string, string> filler = new Dictionary<string, string>();
        List<Template> templates = new List<Template>();

        templates = FillTemplates();

        string canonUrl = CanonizeUrl(new Uri("https://www.wildberries.kg/"));

        foreach (Template template in templates)
        {
            Console.WriteLine(template.Pattern);
            try { filler = template.Match(new Uri(canonUrl)); }
            catch (Exception) { }
            if (filler == null) { Console.WriteLine("Do NOT FIT"); Console.WriteLine(); }
            else
            {
                if (filler.Count > 0)
                {
                    foreach (var item in filler)
                    {
                        Console.WriteLine("{0} - заполнитель шаблона; {1}  - заполнитель из URL", item.Key, item.Value);
                    }

                }
                else { Console.WriteLine("Данный шаблон совпадает с путем запроса без заполнителя"); }
                Console.WriteLine();
            }
        }

        appExit:
        Console.WriteLine();
        Console.WriteLine("========================================================================");
        Console.WriteLine("Выйти из программы [y/n]?");
        if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }
    }
    /*
/main.html
/about.html
/portfolio.html
/portfolio/work-{workId}.html
/blog.html
/blog/post/{postID}.html
/{filePath}.txt
/user/avatar/{userID}.jpg
/promo-{promoID}.html
/blog/year-{year}.html
/blog/year-{year}/month-{month}/list.html
/blog/tag-{tagName}.html
/orders.html
/orders/{date}.html?sort={sort}&view={view}
/chat/{chatID}/user-1-{user1ID}/user-2-{user2ID}.html
/app/{scriptPath}.js
/app/style/{scriptPath}.css
/app/style/images/{ imageFileName } . {  extension  }
{литерал}{заполнитель} { } {заполнитель} 
*/
    //канонизация адреса
    //протокол http://
    //имя домена test.com/
    //если придет http://www.test.com/ - > http://test.com/
    //если придет htt://www.test.com/index.html или http://test.com/index.html -> обрезать до http://test.com/
    //если пришел номер порта его вырезать до слеша каждый раз
    //в пути используются только латинские буквы - как проверка если есть не латинский символ
    //нижний регистр строк адреса до параметров
    public static string CanonizeUrl(Uri url)
    {
        //string str = url.OriginalString;
        //    string str = "https://support.microsoft.com:8080/ru-ru/hub/4338813/windows-help?os=windows-10";
        string str = url.AbsoluteUri;
        //string str = "https://www.test.com:2335";
        //разрешенные символы в строке
        string allSigns = "abcdefghijklmnopqrstuvwxyz0123456789/-.:";
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
            string strTempHost = str.Substring(0, caret + 1);
            localPath = str.Length - caret < 2 ? "" : str.Replace(strTempHost, "");
            if (localPath.Length > 10 && localPath.Contains("index.html")) { localPath = localPath.Replace("/index.html", ""); }
            str = strTempHost;
        }

        //обрезка порта
        caret = str.IndexOf(':', 0);

        if (caret > 0) { host = str.Substring(0, caret) + "/"; }
        else { host = str; }
        //обрезка www
        if (host.Substring(0, 4) == "www.") { host = host.Substring(4, host.Length - 4); }

        return protocol + host + localPath + query; ;
    }
    public static List<Template> FillTemplates()
    {
        List<Template> templates = new List<Template>();

        //templates.Add(
        //   new Template("/portfolio/work-{workid}.html",
        //   new Dictionary<string, validateProc>
        //    {
        //        { "workid",  Template.validate_workID }
        //    }));

        //templates.Add(new Template("/main.html", null));
        templates.Add(new Template("/", null));
        //templates.Add(new Template("/about.html", null));
        //templates.Add(new Template("/portfolio.html", null));
        //templates.Add(new Template("/blog.html", null));

        //templates.Add(
        //   new Template("/blog/post/{postid}.html",
        //   new Dictionary<string, validateProc>
        //    {
        //        { "postid",  Template.validate_postID }
        //    }));

        //templates.Add(
        //   new Template("/{filepath}.txt",
        //   new Dictionary<string, validateProc>
        //   {
        //            { "filepath",  Template.validate_filePath }
        //      }));

        //templates.Add(
        //   new Template("/user/avatar/{userid}.jpg",
        //   new Dictionary<string, validateProc>
        //    {
        //        { "userid",  Template.validate_userID }
        //    }));

        //templates.Add(
        //   new Template("/promo-{promoid}.html",
        //   new Dictionary<string, validateProc>
        //    {
        //        { "promoid",  Template.validate_promoID }
        //}));

        //templates.Add(
        //   new Template("/blog/year-{year}.html",
        //   new Dictionary<string, validateProc>
        //      {
        //                    { "year",  Template.validate_year }
        //         }));

        //templates.Add(
        //    new Template("/blog/year-{year}/month-{month}/list.html",
        //    new Dictionary<string, validateProc>
        //    {
        //                    { "year",  Template.validate_year },
        //                    { "month",  Template.validate_month }
        //    }));

        //templates.Add(
        //   new Template("/blog/tag-{tagname}.html",
        //   new Dictionary<string, validateProc>
        //      {
        //                    { "tagname",  Template.validate_tagName }
        //         }));

        //templates.Add(
        //  new Template("/orders.html", null));

        //templates.Add(
        //   new Template("/orders/{date}.html?sort={sort}&view={view}",
        //   new Dictionary<string, validateProc>
        //   {
        //        { "date",  Template.validate_date },
        //        { "sort",  Template.validate_sort },
        //        { "view",  Template.validate_view }
        //   }));

        //templates.Add(
        //   new Template("/chat/{chatID}/user-1-{user1ID}/user-2-{user2ID}.html",
        //   new Dictionary<string, validateProc>
        //   {
        //        { "chatID",  Template.validate_chatID },
        //        { "user1ID",  Template.validate_userID },
        //        { "user2ID",  Template.validate_userID }
        //   }));

        //templates.Add(
        //   new Template("/app/{scriptPath}.js",
        //   new Dictionary<string, validateProc>
        //      {
        //                    { "scriptPath",  Template.validate_scriptPath }
        //         }));

        //templates.Add(
        //   new Template("/app/style/{stylePath}.css",
        //   new Dictionary<string, validateProc>
        //      {
        //                    { "stylePath",  Template.validate_scriptPath }
        //         }));

        //templates.Add(
        //    new Template("/app/style/images/{imageFileName}.{extension}",
        //    new Dictionary<string, validateProc>
        //    {
        //        { "imageFileName",  Template.validate_imageFileName },
        //        { "extension",  Template.validate_extension }
        //       }));

        return templates;
    }
}



//если нужно будет извлеч порт
//int temp = 0;
//port = str.Substring(caret + 1, str.Length - caret - 2);
//if (port.Length > 5) { throw new Exception("ошибка порта, длина не больше 5 цифр"); }
//try { temp = int.Parse(port); }
//catch (Exception) { throw new Exception("ошибка, порт должен быть числом"); }
////Проверка порта на соответствие протокола
//if (temp != 0)
//{
//    if ((protocol == "https" && temp != 433) || (protocol == "https" && (temp != 80 || temp != 8080))) { throw new Exception($"Protocol \"{protocol}\" can't have that port: \"{temp}\" "); }
//    port = temp == 80 || temp == 8080 || temp == 443 ? "" : ':' + temp.ToString();
//}
////конвертируем строку в чилсо для проверки
//host = str.Replace(':' + port, "");
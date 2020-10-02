using System;
using System.Collections.Generic;
public delegate bool validateProc(string value);
class Template
{
    private string _pattern = "";
    List<Pattern> _list = new List<Pattern>();
    Dictionary<string, validateProc> _fieldsValidators;
    private BaseHandler _handler = null;


    public Template(string pattern, Dictionary<string, validateProc> fieldsValidators, object handler)
    {
        _handler = (BaseHandler)handler;
        //проверка pattern
        if (string.IsNullOrEmpty(pattern)) { throw new Exception("Шаблон пуст"); }
        _pattern = pattern.Trim();
        //положение каретки на открывающей скобе
        int caret = 0;
        //начало литерала
        int startLiteral = 0;
        //конец литерала
        int startFiller = 0;

        //парстинг pattern на заполнитель и литерал
        while (caret > -1)
        {
            if (startLiteral + 1 > pattern.Length) { break; }
            caret = _pattern.IndexOf('{', caret);
            if (caret > 0)
            {
                startFiller = caret + 1;
                try { _list.Add(new Literal(_pattern.Substring(startLiteral, caret - startLiteral))); } catch (Exception e) { throw new Exception(e.Message); }
            }
            else if (caret < 0 && startLiteral > 0)
            {
                try { _list.Add(new Literal(_pattern.Substring(startLiteral, _pattern.Length - startLiteral))); } catch (Exception e) { throw new Exception(e.Message); }
            }
            else
            {
                try { _list.Add(new Literal(_pattern)); } catch (Exception e) { throw new Exception(e.Message); }
                break;
            }

            try { caret = _pattern.IndexOf('}', caret); }
            catch (Exception) { continue; }
            if (caret > 0)
            {
                try
                {
                    Filler newFiller = new Filler(_pattern.Substring(startFiller, caret - startFiller));
                    int index = 1;

                    while (index < _list.Count)
                    {
                        if (newFiller.Name == _list[index].Name) { throw new Exception("Имя заполнителя не может повторяться"); }
                        index++;
                    }
                    if (!fieldsValidators.ContainsKey(newFiller.Name)) { throw new Exception(""); }
                    if (fieldsValidators[newFiller.Name] == null) { }

                    _list.Add(newFiller);
                }
                catch (Exception e) { throw new Exception(e.Message); }

                startLiteral = caret + 1;
            }
            else { throw new Exception("Ошибка "); }

            _fieldsValidators = fieldsValidators;

        }
    }


    public BaseHandler Handler { get { return _handler; } }
    public Dictionary<string, string> Match(Uri incomingURL)
    {
        Dictionary<string, string> validatedFillers = new Dictionary<string, string>();
        //путь пришедшего запроса       
        string urlLocalPath = incomingURL.LocalPath;
        //конец предыдущего литерала
        int endPrevLiteral;
        int caret = 0;
        int index = 0;
        // литерал шаблона
        string literal;
        //заполнитель шаблона
        string fillerName = "";
        //заполнитель из URL
        string urlFiller = "";

        do
        {
            //проверяем продолжается ли строка urlLocalPath после совпадения литерала - второй цикл литерал-заполнитель-литерал
            if (caret == urlLocalPath.Length && index > 0) { return validatedFillers; }

            //заполнитель из шаблона
            try { fillerName = _list[index + 1].Name; }
            catch (Exception) { } //index += 2; continue;

            //литерал из шаблона
            try { literal = _list[index].Name; }
            catch (Exception)
            {
                //если литерала нет в шаблоне, считаю оставшуюся часть заполнителем, проверяю и добавляю в словарь
                urlFiller = urlLocalPath.Substring(caret, urlLocalPath.Length - caret);
                if (checkFiller(fillerName, urlFiller)) { validatedFillers.Add(fillerName, urlFiller); }
                else return null;
                return validatedFillers;
            }

            //двигаю каретку на начало литерала
            caret = urlLocalPath.IndexOf(literal, caret);

            //в первом цикле если вход литера не с нуля литерал не совпадает
            if (caret != 0 && index == 0) { return null; } //false

            //конец литерала это положение каретки плюс длина литерала
            endPrevLiteral = caret + literal.Length;

            //ставим каретку в конец литерала с этого момета будем проверять следующий литерал
            caret = endPrevLiteral;

            //проверяем продолжается ли строка urlLocalPath после совпадения литерала
            if (caret == urlLocalPath.Length) { if (_list.Count > index + 1) { return null; } else return validatedFillers; } //true

            index += 2;
            //проверяем второй литерал
            try { literal = _list[index].Name; }
            catch (Exception)
            {
                //если следующего литерала нет в шаблоне, считаю оставшуюся часть заполнителем, проверяю и добавляю в словарь
                urlFiller = urlLocalPath.Substring(caret, urlLocalPath.Length - caret);
                if (checkFiller(fillerName, urlFiller)) { validatedFillers.Add(fillerName, urlFiller); }
                else { return null; }
                return validatedFillers;
            }
            //проверяем есть ли второй литерал
            caret = urlLocalPath.IndexOf(literal, caret);
            if (caret < 0) { return null; }

            // добавляем заполнитель в список
            urlFiller = urlLocalPath.Substring(endPrevLiteral, caret - endPrevLiteral);

            //перехватываю ошибку валидации заполнителя           
            try
            {
                if (_fieldsValidators.ContainsKey(fillerName) && _fieldsValidators[fillerName](urlFiller))
                { validatedFillers.Add(fillerName, urlFiller); }
                else { return null; }
            }
            catch (Exception) { throw new Exception(); } //

            //конец литерала это положение каретки плюс длина литерала
            //endPrevLiteral = caret + literal.Length;

            //ставим каретку в конец литерала с этого момета будем проверять следующий литерал
            //caret = endPrevLiteral;
            //index += 2;

        } while (index <= _list.Count);

        return validatedFillers;
    }

    public bool checkFiller(string fillerName, string filler)
    {
        try
        {
            foreach (KeyValuePair<string, validateProc> element in _fieldsValidators)
            {
                if (element.Key == fillerName) { return element.Value.Invoke(filler); }
            }
        }
        catch (Exception) { }

        return false;
    }

    public string Pattern { get { return _pattern; } }
    public static bool validate_workID(string value)
    {
        //workID - целое число, длина 9 знаков, не может начинаться с нуля       
        if (string.IsNullOrEmpty(value) || value.Length != 9 || value[0] == '0') { throw new Exception("Не соответствующий формат у заполнителя"); }
        try { int number = int.Parse(value); } catch (Exception) { throw new Exception("Не соответствующий формат у заполнителя"); }
        return true;
    }
    public static bool validate_favicon(string value)
    {
        //workID - целое число, длина 9 знаков, не может начинаться с нуля       
        if (string.IsNullOrEmpty(value) || value.Length != 9 || value[0] == '0') { throw new Exception("Не соответствующий формат у заполнителя"); }
        try { int number = int.Parse(value); } catch (Exception) { throw new Exception("Не соответствующий формат у заполнителя"); }
        return true;
    }

    internal static bool validate_apinumbers(string value)
    {
        //workID - целое число, длина 9 знаков, не может начинаться с нуля       
        if (string.IsNullOrEmpty(value) || value.Length != 9) { throw new Exception("Не соответствующий формат у заполнителя"); }
        try { int number = int.Parse(value); } catch (Exception) { throw new Exception("Не соответствующий формат у заполнителя"); }
        return true;
    }

    public static bool validate_filePath(string value)
    {
        //filePath - только буквы, цифры, _, - / . (без пар, символы не могут быть рядом)
        if (string.IsNullOrEmpty(value)) { return false; }
        string _value = value.Trim().ToLower();
        string allSigns = "abcdefghijklmnopqrstuvwxyz0123456789/-_=.";
        char symbol;
        char nextSymbol;
        int index = 0;
        while (index < _value.Length)
        {
            symbol = _value[index];
            if (!allSigns.Contains(symbol.ToString())) { throw new Exception("Не соответствующий формат у заполнителя"); }
            if (index + 1 < _value.Length)
            {
                nextSymbol = _value[index + 1];
                if (!char.IsLetterOrDigit(symbol))
                {
                    if ("/-_=.".Contains(nextSymbol.ToString())) { throw new Exception("Не соответствующий формат у заполнителя"); }
                }
            }
            index++;
        }
        return true;
    }
    public static bool validate_postID(string value)
    {
        //postID - только число, 5 знаков, не может начинаться с нуля
        if (string.IsNullOrEmpty(value) || value.Length < 5 || value.Length > 5 || value[0] == '0') { throw new Exception("Не соответствующий формат у заполнителя"); }
        try { int number = int.Parse(value); } catch (Exception) { throw new Exception("Не соответствующий формат у заполнителя"); }
        return true;
    }
    public static bool validate_userID(string value)
    {
        // userID - целом числом, длина 9 знаков, всегда начинается на 1
        if (string.IsNullOrEmpty(value) || value.Length != 9 || value[0] != '1') { throw new Exception("Не соответствующий формат у заполнителя"); }
        try { int number = int.Parse(value); } catch (Exception) { throw new Exception("Не соответствующий формат у заполнителя"); }
        return true;
    }
    public static bool validate_promoID(string value)
    {
        //promoID - только число, 9 знков, не может начинаться с нуля
        if (string.IsNullOrEmpty(value) || value.Length != 9 || value[0] == '0') { throw new Exception("Не соответствующий формат у заполнителя"); }
        try { int number = int.Parse(value); } catch (Exception) { throw new Exception("Не соответствующий формат у заполнителя"); }
        return true;
    }
    public static bool validate_year(string value)
    {
        //year - только число, 4 знака, не больше текущего года
        int number;
        if (string.IsNullOrEmpty(value) || value.Length != 4) { throw new Exception("Не соответствующий формат у заполнителя"); }
        try { number = int.Parse(value); } catch (Exception) { throw new Exception("Не соответствующий формат у заполнителя"); }
        if (number > DateTime.Now.Year) { return false; }
        return true;
    }
    public static bool validate_month(string value)
    {
        // month - только число, 2 знака (от 01 до 12)
        int number;
        if (string.IsNullOrEmpty(value) || value.Length != 2) { throw new Exception("Не соответствующий формат у заполнителя"); }
        try { number = int.Parse(value); } catch (Exception) { throw new Exception("Не соответствующий формат у заполнителя"); }
        if (number < 1 || number > 12) { return false; }
        return true;
    }
    public static bool validate_tagName(string value)
    {
        //tagName - только буквы и знак - (не может быть в начале, без пары), длина не более 150 знаков
        string _value = value.Trim().ToLower();
        string allSigns = "abcdefghijklmnopqrstuvwxyz-";
        char symbol = ' ';
        char nextSymbol = ' ';
        int index = 0;
        if (string.IsNullOrEmpty(value) || value.Length > 150 || !allSigns.Contains(symbol.ToString()) || _value[0] == '-') { throw new Exception("Не соответствующий формат у заполнителя"); }

        while (index < _value.Length)
        {
            symbol = _value[index];
            if (index + 1 < _value.Length)
            {
                nextSymbol = _value[index + 1];
                if (!char.IsLetterOrDigit(symbol))
                {
                    if ("-".Contains(nextSymbol.ToString())) { throw new Exception("Не соответствующий формат у заполнителя"); }
                }
            }
            index++;
        }
        return true;
    }
    public static bool validate_extension(string value)
    {
        //extension->только буквы, от 3 до 5 символов
        string _value = value.ToLower().Trim();
        if (string.IsNullOrEmpty(value) || _value.Length < 3 || _value.Length > 5) { throw new Exception("Не соответствующий формат у заполнителя"); }
        foreach (char letter in _value) { if (!char.IsLetter(letter)) { throw new Exception("Не соответствующий формат у заполнителя"); } }
        return true;
    }
    public static bool validate_videoextension(string value)
    {
        //extension->только буквы, от 3 до 5 символов
        string _value = value.ToLower().Trim();
        if (string.IsNullOrEmpty(value) || _value.Length < 3 || _value.Length > 5) { throw new Exception("Не соответствующий формат у заполнителя"); }
        foreach (char letter in _value) { if (!char.IsLetter(letter)&& !char.IsDigit(letter)) { throw new Exception("Не соответствующий формат у заполнителя"); } }
        return true;
    }
    public static bool validate_imageFileName(string value)
    {
        //imageFileName - только буквы и цифры, _- / . (без пар, символы не могут быть рядом)
        int index = 0;
        char symbol = ' ';
        if (string.IsNullOrEmpty(value)) { throw new Exception("Не соответствующий формат у заполнителя"); }
        value = value.ToLower().Trim();
        string allSymbols = "abcdefghijklmnopqrstuvwxyz0123456789_-/.";
        while (index < value.Length)
        {
            symbol = value[index];
            if (!allSymbols.Contains(symbol.ToString())) { throw new Exception("Не соответствующий формат у заполнителя"); }
            if (index + 1 < value.Length)
            {
                if ("_-/.".Contains(symbol.ToString()) && "_-/.".Contains(value[index + 1].ToString())) { { throw new Exception("Не соответствующий формат у заполнителя"); } }              
            }
            index++;
        }
        return true;
    }
    public static bool validate_scriptPath(string value)
    {
        //scriptPath - только буквы, цифры, _, - / . (без пар, символы не могут быть рядом)
        int index = 0;
        char symbol = ' ';
        if (string.IsNullOrEmpty(value)) { throw new Exception("Не соответствующий формат у заполнителя"); }
        value = value.ToLower().Trim();
        string allSymbols = "abcdefghijklmnopqrstuvwxyz0123456789_-/.";
        string letter = "";
        while (index < value.Length)
        {
            letter = value[index].ToString();
            if (!allSymbols.Contains(letter)) { throw new Exception("Не соответствующий формат у заполнителя"); }
            symbol = value[index];
            if (index + 1 < value.Length)
            {
                if ("_-/.".Contains(symbol.ToString()) && "_-/.".Contains(value[index + 1].ToString())) { { throw new Exception("Не соответствующий формат у заполнителя"); } }

            }
            index++;
        }
        return true;
    }
    public static bool validate_stylePath(string value)
    {
        //scriptPath - только буквы, цифры, _, - / . (без пар, символы не могут быть рядом)
        int index = 0;
        char symbol;
        if (string.IsNullOrEmpty(value)) { throw new Exception("Не соответствующий формат у заполнителя"); }
        value = value.ToLower().Trim();
        string allSigns = "abcdefghijklmnopqrstuvwxyz0123456789_-/.";
        while (index < value.Length)
        {
            symbol = value[index];
            if (!allSigns.Contains(symbol.ToString())) { throw new Exception("Не соответствующий формат у заполнителя"); }
            if (index + 1 < value.Length)
            {
                if ("_-/.".Contains(symbol.ToString()) && "_-/.".Contains(value[index + 1].ToString())) { { throw new Exception("Не соответствующий формат у заполнителя"); } }
                index++;
            }
        }
        return true;
    }
    public static bool validate_chatID(string value)
    {
        // chatID - только число, длина 18 знаков, не может начинаться с нуля
        if (string.IsNullOrEmpty(value) || value.Length < 18 || value.Length > 18 || value[0] == '0') { throw new Exception("Не соответствующий формат у заполнителя"); }
        try { long number = long.Parse(value); } catch (Exception) { throw new Exception("Не соответствующий формат у заполнителя"); };
        return true;
    }
    public static bool validate_view(string value)
    {
        //view - только число 1 или 2
        if (string.IsNullOrEmpty(value) || value.Length != 1 || value[0] != '1' || value[0] != '2') { throw new Exception("Не соответствующий формат у заполнителя"); }
        return true;
    }
    public static bool validate_sort(string value)
    {
        //sort - только "az" или "za"
        string az = "az";
        string za = "za";
        if (az.Equals(value) || za.Equals(value)) { return true; }
        else { throw new Exception("Не соответствующий формат у заполнителя"); }
    }
    public static bool validate_date(string value)
    {
        //date - в формате YYYY/MM/DD
        int year, month, day;
        if (string.IsNullOrEmpty(value) || value.Length < 10 || value.Length > 10 || value[4] != '/' || value[7] != '/') { throw new Exception("Не соответствующий формат у заполнителя"); }
        DateTime date = new DateTime();
        try
        {
            year = int.Parse(value.Substring(0, 4));
            month = int.Parse(value.Substring(5, 2));
            day = int.Parse(value.Substring(8, 2));
            date = new DateTime(year, month, day);
        }
        catch (Exception) { throw new Exception("Не соответствующий формат у заполнителя"); }
        if (date > DateTime.Now) { throw new Exception("Не соответствующий формат у заполнителя"); }
        return true;
    }
}

/*
    /main.html
    /about.html
    /portfolio.html
    /portfolio/work-{workID}.html
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
    /app/style/{stylePath}.css
    /app/style/images/{imageFileName}.{extension}   
 */

/* Правила для заполнителей:
 workID - целое число, длина 9 знаков, не может начинаться с нуля 
 filePath - только буквы, цифры, _, - / . (без пар, символы не могут быть рядом)
 postID - только число, 5 знаков, не может начинаться с нуля
 userID - целом числом, длина 9 знаков, всегда начинается на 1
 promoID - только число, 9 знков, не может начинаться с нуля
 year - только число, 4 знака, не больше текущего года
 month - только число, 2 знака (от 01 до 12)
 tagName - только буквы и знак - (не может быть в начале, без пары), длина не более 150 знаков
 date - в формате YYYY/MM/DD
 sort - только "az" или "za"
 view - только число 1 или 2
 chatID - только число, длина 18 знаков, не может начинаться с нуля
 scriptPath -> аналогично filePath
 imageFileName -> filePath
 extension -> только буквы, от 3 до 5 символов
 */

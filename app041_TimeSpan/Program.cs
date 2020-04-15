using System;

class Program
{
    static Random rnd = new Random();

    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("========================================================================");
        Console.WriteLine("Дружественное представление промежутка времени?");
        Console.WriteLine("========================================================================");
        Console.WriteLine();
        appBegin:
        Console.WriteLine($"Задание №2");
        Console.WriteLine($"Введите любую дату и время не большую текущей:");
        DateTime now = DateTime.Now;
        
        inputDay:
        Console.WriteLine("Введите число от 1 до 31. Это будет число месяца");        
        int day = int.Parse(Console.ReadLine());
        if (day < 1 || day > 31) { Console.WriteLine("Введите число от 1 до 31. Количество дней в месяце не больше 31 и не меньше 1"); goto inputDay; }
        inputMonth:
        Console.WriteLine("Введите число от 1 до 12. Это будет месяц:");
        int month = int.Parse(Console.ReadLine());
        if (month < 1 || month > 12) { Console.WriteLine("Введите число от 1 до 12. Количество дней в году не больше 12 и не меньше 1"); goto inputMonth; }
        inputYear:
        Console.WriteLine("Введите число не меньше 2010 и не больше 2019. Это будет год:");
        int year = int.Parse(Console.ReadLine());
        if (year < 2009 || year > 2019) { Console.WriteLine("Введите число от 2009 до номера нынешнего года."); goto inputYear; }


        Console.WriteLine("Введите число от 1 до 24. Это будут часы:");
        int hour = int.Parse(Console.ReadLine());
        if (hour < 0 || hour > 24) { Console.WriteLine("Введите число от 0 до 24. Количество часов в сутках не больше 24 и не меньше 0"); }


        Console.WriteLine("Введите число от 1 до 60. Это будут минуты:");
        int minute = int.Parse(Console.ReadLine());
        if (minute < 0 || minute > 60) { Console.WriteLine("Введите число от 0 до 60. Количество минут в часе не больше 60 и не меньше 0"); }

        Console.WriteLine("Введите число от 1 до 60. Это будут секунды:");
        int second = int.Parse(Console.ReadLine());
        if (second < 0 || second > 60) { Console.WriteLine("Введите число от 0 до 60. Количество секунд в минуте не больше 60 и не меньше 0"); }

        DateTime inputdateTime = new DateTime(year, month, day, hour, minute, second);

        if (inputdateTime.CompareTo(now) > 0) { Console.WriteLine("Введенная дата должна быть меньше чем текущая дата"); goto inputDay; }
        TimeSpan inputdateTimeinticks = new TimeSpan(inputdateTime.Ticks);

        TimeSpan nowticks = new TimeSpan(now.Ticks);
        TimeSpan timeSpan = nowticks - inputdateTimeinticks;

        Console.WriteLine($"Введенная вами дата и время: {inputdateTime}");

        Console.WriteLine($"Текущая дата и время: {now}");

        Console.WriteLine("Введенная вами дата и время были: ");
        if (timeSpan.TotalSeconds > 0 && timeSpan.TotalSeconds < 15) { Console.WriteLine("только что. "); }
        else if (timeSpan.TotalSeconds > 15 && timeSpan.TotalSeconds < 60) { Console.WriteLine("минуту назад."); }
        else if (timeSpan.TotalMinutes > 1 && timeSpan.TotalMinutes < 1.5) { Console.WriteLine("чуть более минуты назад."); }
        else if (timeSpan.TotalMinutes > 1.5 && timeSpan.TotalMinutes < 2.5) { Console.WriteLine("пару минут назад."); }
        else if(timeSpan.TotalMinutes > 2.5 && timeSpan.TotalMinutes < 3.5) { Console.WriteLine("три минуты назад."); }
        else if (timeSpan.TotalMinutes > 3.5 && timeSpan.TotalMinutes < 4.5) { Console.WriteLine("четыре минуты назад."); }
        else if (timeSpan.TotalMinutes > 4.5 && timeSpan.TotalMinutes < 5.9) { Console.WriteLine("5 минут назад."); }
        else if (timeSpan.TotalMinutes > 5.9 && timeSpan.TotalMinutes < 6.9) { Console.WriteLine("шесть минут назад."); }
        else if (timeSpan.TotalMinutes > 6.9 && timeSpan.TotalMinutes < 7.9) { Console.WriteLine("семь минут назад."); }
        else if (timeSpan.TotalMinutes > 7.9 && timeSpan.TotalMinutes < 8.9) { Console.WriteLine("восемь минут назад."); }
        else if (timeSpan.TotalMinutes > 8.9 && timeSpan.TotalMinutes < 10) { Console.WriteLine("девять минут назад."); }
        else if (timeSpan.TotalMinutes > 10 && timeSpan.TotalMinutes < 11) { Console.WriteLine("десять минут назад."); }
        else if (timeSpan.TotalMinutes > 11 && timeSpan.TotalMinutes < 13.5) { Console.WriteLine("чуть больше десяти минут назад."); }
        else if (timeSpan.TotalMinutes > 13.5 && timeSpan.TotalMinutes < 14.5) { Console.WriteLine("больше десяти минут назад."); }
        else if (timeSpan.TotalMinutes > 13.5 && timeSpan.TotalMinutes < 14.5) { Console.WriteLine("четырнадцать минут назад."); }
        else if (timeSpan.TotalMinutes > 14.5 && timeSpan.TotalMinutes < 15.5) { Console.WriteLine("четверть часа назад."); }
        else if (timeSpan.TotalMinutes > 15.5 && timeSpan.TotalMinutes < 16.5) { Console.WriteLine("чуть больше четверти часа назад."); }
        else if (timeSpan.TotalMinutes > 16.5 && timeSpan.TotalMinutes < 18.5) { Console.WriteLine("больше четверти часа назад."); }
        else if (timeSpan.TotalMinutes > 18.5 && timeSpan.TotalMinutes < 19.5) { Console.WriteLine("почти треть часа назад."); }
        else if (timeSpan.TotalMinutes > 19.5 && timeSpan.TotalMinutes < 20.5) { Console.WriteLine("двадцать минут назад."); }
        else if (timeSpan.TotalMinutes > 20.5 && timeSpan.TotalMinutes < 24.5) { Console.WriteLine("больше двадцать минут назад."); }
        else if (timeSpan.TotalMinutes > 24.5 && timeSpan.TotalMinutes < 25.5) { Console.WriteLine("двадцать пять минут назад."); }
        else if (timeSpan.TotalMinutes > 25.5 && timeSpan.TotalMinutes < 29.5) { Console.WriteLine("почти пол часа назад."); }
        else if (timeSpan.TotalMinutes > 29.5 && timeSpan.TotalMinutes < 35.5) { Console.WriteLine("пол часа назад."); }
        else if (timeSpan.TotalMinutes > 35.5 && timeSpan.TotalMinutes < 55) { Console.WriteLine($"{Math.Truncate(timeSpan.TotalMinutes)} минут назад."); }    
        else if (timeSpan.TotalMinutes > 55 && timeSpan.TotalMinutes < 65) { Console.WriteLine("час назад."); }
        else if (timeSpan.TotalHours > 1.05 && timeSpan.TotalHours < 1.30) { Console.WriteLine("полтора часа назад."); }
        else if (timeSpan.TotalHours > 1.30 && timeSpan.TotalHours < 2) { Console.WriteLine("два часа назад."); }
        else if (timeSpan.TotalHours > 2 && timeSpan.TotalHours < 6) { Console.WriteLine($"{Math.Truncate(timeSpan.TotalHours)} часов назад."); }
        else if (timeSpan.TotalHours > 6 && timeSpan.TotalHours < 24) { Console.WriteLine($"{Math.Truncate(timeSpan.TotalHours)} часов  и {Math.Truncate(timeSpan.TotalMinutes)} назад."); }
        else if (timeSpan.Days >= 1 && timeSpan.Days < 2) { Console.WriteLine($"сутки назад."); }
        else if (timeSpan.Days == 2) { Console.WriteLine($"2ое суток назад."); }
        else if (timeSpan.Days >= 2 && timeSpan.Days < 5) { Console.WriteLine($"больше 2х суток назад."); }
        else if (timeSpan.Days == 5) { Console.WriteLine($"5 суток назад."); }
        else if (timeSpan.Days >= 5 && timeSpan.Days < 10) { Console.WriteLine($"больше 5и суток назад."); }
        else if (timeSpan.Days == 10) { Console.WriteLine($"10 дней назад."); }
        else if (timeSpan.Days >= 10 && timeSpan.Days < 31) { Console.WriteLine($"больше 10 дней назад."); }
        else if (timeSpan.Days == 30 || timeSpan.Days == 31) { Console.WriteLine($"месяц назад."); }
        else if (timeSpan.Days > 30 && timeSpan.Days <= 60) { Console.WriteLine($"больше месяца назад."); }
        else if (timeSpan.Days == 60) { Console.WriteLine($" 2 месяца назад."); }
        else if (timeSpan.Days > 2 * 30 && timeSpan.Days < 6 * 30) { Console.WriteLine($" больше 2 месяцев назад."); }
        else if (timeSpan.Days == 6 * 30) { Console.WriteLine($"полгода назад."); }
        else if (timeSpan.Days > 6 * 30 && timeSpan.Days < 12 * 30) { Console.WriteLine($" больше полугода назад."); }
        else if (timeSpan.Days == 12 * 30) { Console.WriteLine($"год назад."); }
        else if (timeSpan.Days > 12 * 30 && timeSpan.Days < 24 * 30) { Console.WriteLine($" больше года назад."); }
        else if (timeSpan.Days == 24 * 30) { Console.WriteLine($"2 года назад."); }
        else if (timeSpan.Days > 2 * 12 * 30 && timeSpan.Days < 5 * 12 * 30) { Console.WriteLine($" больше 2 лет назад."); }
        else if (timeSpan.Days == 5 * 12 * 30) { Console.WriteLine($"5 лет назад."); }
        else if (timeSpan.Days > 5 * 12 * 30) { Console.WriteLine($"больше 5 лет назад."); }


        appExit:
        Console.WriteLine();
        Console.WriteLine("========================================================================");
        Console.WriteLine("Выйти из программы [y/n]?");
        if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }
    }
}


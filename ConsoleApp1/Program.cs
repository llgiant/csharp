using System;

class Program
{
    static Random rnd = new Random();

    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("========================================================================");
        Console.WriteLine("Работа с Датой");
        Console.WriteLine("========================================================================");
        Console.WriteLine();
        appBegin:

        //Console.WriteLine("Введите день своего рожденья");
        //int day = int.Parse(Console.ReadLine());
        //Console.WriteLine("Введите месяц своего рожденья");
        //int month = int.Parse(Console.ReadLine());
        //Console.WriteLine("Введите год своего рожденья");
        //int year = int.Parse(Console.ReadLine());

        //DateTime birthDate = new DateTime(year, month, day);
        DateTime userbirthDate = new DateTime(1980, 03, 22);
        DateTime myBirthdate = new DateTime(1987, 12, 26);
        TimeSpan period = DateTime.Now - userbirthDate;
        DateTime dt = new DateTime(1, 1, 1);


        Console.WriteLine($"1) Названиеа дня недели:{userbirthDate.DayOfWeek}");

        if (userbirthDate.Year % 4 == 0 && userbirthDate.Year % 100 != 0 || userbirthDate.Year % 400 == 0)
        { Console.WriteLine($"2) Вы родлись в высокосном году"); }
        else { Console.WriteLine($"2) Год не высокосный"); }
        Console.WriteLine($"3) Сколько прошло лет с момента рождения: {DateTime.Now.Year - userbirthDate.Year}");
        Console.WriteLine($"4) С момента рождения прошло минут: {period.TotalMinutes} ");
        DateTime pastTime = userbirthDate.AddYears(5).AddMonths(6).AddDays(3).AddHours(15).AddMinutes(40).AddSeconds(25);
        Console.WriteLine($"5) Дата через 5 лет 6 месяцев 3 дня 15:40:25: {pastTime} ");

        TimeSpan span = DateTime.Now - pastTime;
        int year = span.Days / 365;
        int month = (span.Days % 365) / 30;
        int days = (span.Days % 365) % 30;
        Console.WriteLine($"6) Время прошедшее после предыдущей даты до настоящего времени: {year} лет, {month} месяц, {days} день");

        string strCentury = userbirthDate.Year.ToString();
        strCentury = strCentury.Substring(0, 2);
        int intCentury = int.Parse(strCentury) * 100;
        DateTime startCentury = new DateTime(intCentury, 1, 1);

        int totalMonth = (userbirthDate.Month + userbirthDate.Year * 12) - (startCentury.Month + startCentury.Year * 12);
        Console.WriteLine($"7) Месяцы прошедшие с начала века до текщей даты: {totalMonth}");

        span = userbirthDate - myBirthdate;
        year = Math.Abs(span.Days / 365);
        month = Math.Abs(span.Days % 365) / 30;
        days = Math.Abs(span.Days % 365) % 30;
        if (userbirthDate.CompareTo(myBirthdate) > 0) { Console.WriteLine($"8) Пользователь младше вас: {year} лет, {month} месяц, {days} день"); }
        else { Console.WriteLine($"8) Пользователь старше вас на: {year} лет, {month} месяц, {days} день"); }

        DateTime date = DateTime.Now.AddYears(25).AddMonths(3).AddDays(18);
        string weekDay = "";
        switch (date.DayOfWeek)
        {
            case 0:
                weekDay = "Воскресенье";
                break;
            case (DayOfWeek)1:
                weekDay = "Понедельник";
                break;
            case (DayOfWeek)2:
                weekDay = "Вторник";
                break;
            case (DayOfWeek)3:
                weekDay = "Среда";
                break;
            case (DayOfWeek)4:
                weekDay = "Четверг";
                break;
            case (DayOfWeek)5:
                weekDay = "Пятница";
                break;
            case (DayOfWeek)6:
                weekDay = "Суббота";
                break;
        }

        if ((date.Year % 4 == 0 && date.Year % 100 != 0 || date.Year % 400 == 0) && date.Month == 2)
        {
            Console.WriteLine($"9) День недели - {weekDay} в високосном месяце");
        }
        else { Console.WriteLine($"9) День недели - {weekDay} не в високосном месяце"); }
        Console.WriteLine($"10) в {date.Year} году пользователю будет {date.Year - userbirthDate.Year} лет");

        appExit:
        Console.WriteLine();
        Console.WriteLine("========================================================================");
        Console.WriteLine("Выйти из программы [y/n]?");
        if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }
    }
}
using System;

class Program
{
    static Random rnd = new Random();

    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("========================================================================");
        Console.WriteLine("Генерировать случайный пароль");
        Console.WriteLine("========================================================================");
        Console.WriteLine();
    appBegin:

        //1.Длина от 9 - 18 символов (задает пользователь)
        //2.Минимум 3 строчные буквы (1 категория)
        //3.Минимум 2 заглавные буквы(2 категория)
        //4.Минимум 1 цифра (3 категории)
        //5.Минимум 1 не буквенный и не числовой символ (4 категгория)
        //6.Рядом не могут сторять два символа одной категории
        //7.Символы одной категории не могут повторяться
        //!@#$%^&*()[]{} - символы 4й категории

        string symbol = "";
        string strPass = "";
        int passLen = 0;
        int countCat1 = 3;
        int countCat2 = 2;
        int countCat3 = 1;
        int countCat4 = 1;
        int prevCat = 0;
        int cat = 0;
        string cat4 = "!@#$%^&*()[]{}?";

        Console.WriteLine("Введите длину пароля от 9 до 18 символов");
    inputLen: passLen = int.Parse(Console.ReadLine());
        if (passLen < 9 || passLen > 18)
        {
            Console.WriteLine("Длина пароля должна быть от 9 до 18 символов, повторите:"); goto inputLen;
        }

        do
        {
        inputCat: if (countCat1 < 3 || countCat2 < 2) { cat = rnd.Next(1, 3); }
            cat = rnd.Next(1, 5);
            switch (cat)
            {
                case 1:
                    if (prevCat == cat) { goto case 2; }
                    symbol = ((char)rnd.Next(97, 123)).ToString();
                    prevCat = 1;
                    countCat1++;
                    break;
                case 2:
                    if (prevCat == cat) { goto case 3; }
                    symbol = ((char)rnd.Next(65, 91)).ToString();
                    prevCat = 2;
                    countCat2++;
                    break;
                case 3:
                    if (prevCat == cat) { goto case 4; }
                    symbol = ((char)rnd.Next(48, 58)).ToString();
                    prevCat = 3;
                    countCat3++;
                    break;
                case 4:
                    if (prevCat == cat) { goto inputCat; }
                    symbol = cat4[(rnd.Next(0, cat4.Length + 1))] + "";
                    prevCat = 4;
                    countCat4++;
                    break;
            }

            if (strPass.Length > 0 && strPass.Contains(symbol)) { goto inputCat; }
            strPass += symbol;



        }
        while (strPass.Length < passLen);

        Console.WriteLine(strPass);

    appExit:
        Console.WriteLine();
        Console.WriteLine("========================================================================");
        Console.WriteLine("Выйти из программы [y/n]?");
        if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }
    }
}

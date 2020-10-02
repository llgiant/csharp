using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;

class Test
{
    static void Main(string[] args)
    {
        double I = MathLib.E;// Ошибка, значение константы нельзя изменить
        MathLib.addNum();

        Console.WriteLine(MathLib.result);
        Console.ReadKey();
    }

}
class MathLib
{
    public const double PI = 3.141;
    public const double E = 2.81;
    public const double result;
    public static void addNum()
    {
        result = PI + E;
    }
}



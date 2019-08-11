using System;

class Program
{
    static void Main()
    {

        Console.WriteLine("========================================================================");
        Console.WriteLine("Что будет делать программа?");
        Console.WriteLine("========================================================================");
        Console.WriteLine();

        int fieldSize = 5;
        int cellAmount = fieldSize * fieldSize;
        string prevFishka = "";

        for (int col = 1; col <= cellAmount; col++)
        {

            if (cells[col].Value == prevFishka) { countPlayerFishka++; }
            if (countPlayerFishka == FieldSize) { return true; }
            prevFishka = cells[col].Value;


            if (cellCount == FieldSize) { cellCount = 0; prevFishka = ""; continue; }
            cellCount++;
            prevFishka = cells[col].Value;
        }

        Console.WriteLine();
        Console.WriteLine("========================================================================");
        Console.WriteLine("Для выхода из программы нажмите любую клавишу...");
        Console.ReadKey();

        

    }
}

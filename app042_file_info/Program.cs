using System.IO;
using System;

class Program
{
    static Random rnd = new Random();

    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("========================================================================");
        Console.WriteLine("Информация о файле?");
        Console.WriteLine("========================================================================");
        Console.WriteLine();
        appBegin:

        //Ввести путь к любому файлу
        //Вывести всю информацию о файле с помощью объекта fileinfo 
        // c:\s3.txt

        Console.WriteLine("Введите путь к файлу");
        Console.ReadLine();
        //string path = Console.ReadLine();
        FileInfo fileInfo = new FileInfo(@"C:\Users\llgiant\OneDrive\Разработка\v3.log");
        //FileInfo fileInfo = new FileInfo($@"{path}");
        if (!fileInfo.Exists) { Console.WriteLine("такого файла не существует"); goto appBegin; }

        Console.WriteLine($"Полный путь к файлу:               {fileInfo.FullName}");
        Console.WriteLine($"Имя файла:                         {fileInfo.Name}");
        Console.WriteLine($"Дата и время создания файла:       {fileInfo.CreationTime}");
        Console.WriteLine($"Размер файла в байтах:             {fileInfo.Length}");
        Console.WriteLine($"Директория каталога Directory:     {fileInfo.Directory} ");
        Console.WriteLine($"Директория каталога DirectoryName: {fileInfo.DirectoryName}");
        Console.WriteLine($"Расширение файла:                  {fileInfo.Extension}");
        Console.WriteLine($"Файл только для чтения:            {(fileInfo.IsReadOnly ? "Да" : "Нет")}"); ;
        Console.WriteLine($"Дата создания файла:               {fileInfo.CreationTime}");
        Console.WriteLine($"Последний раз обращались к файлу:  {fileInfo.LastAccessTime}");
        Console.WriteLine($"Последний раз изменили файл:       {fileInfo.LastWriteTime}");






        appExit:
        Console.WriteLine();
        Console.WriteLine("========================================================================");
        Console.WriteLine("Выйти из программы [y/n]?");
        if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }
    }
}

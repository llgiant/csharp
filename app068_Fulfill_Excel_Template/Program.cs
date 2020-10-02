using app068_Fulfill_Excel_Template;
using System;
using System.Data.SqlClient;


class Program
{
    //Connextrion string - Data Source изменяемый параметр
    readonly static string str = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BankDB;";

    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("========================================================================");
        Console.WriteLine("Наполнение Excel документа по шаблону");
        Console.WriteLine("========================================================================");
        Console.WriteLine();

        Excel excel = new Excel();

    UserInput:       
        Console.WriteLine("Ведите ИНН номер клиента");

        //Ввод пользователем ИНН номера 
        string clientNumber = Console.ReadLine();

        //проверка на присутствие не циферных символов
        if (!CheckInput(clientNumber) || string.IsNullOrEmpty(clientNumber))
        {
            Console.WriteLine("Введите только цифры");
            goto UserInput;
        }

        //SQL Строка запроса
        string qs = $"SELECT ID,Name,BirthDate,PhoneNumber,Address,SocialNumber FROM Clients WHERE SocialNumber = '{clientNumber}'";

        Client client;

        try
        {
            client = CreateCommand(qs, str);
            if (client.Name == null && client.PhoneNumber == null)
            {
                Console.WriteLine($"ИНН номер \"{clientNumber}\" не найден. Повторите ввод");
                goto UserInput;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("Повторите ввод");
            goto UserInput;
        }

        try
        {
            //Запись данных в шаблон
            excel.WriteDataToFile(client);

            //Сохранение данных в файл в папку в проекте Result
            excel.SaveAs();
            Console.WriteLine("\nДокумент успешно сохранен!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            goto UserInput;
        }
        
        Console.WriteLine();
        Console.WriteLine("========================================================================");
        Console.WriteLine("Продолжить поиск по ИНН [y/n]?");
        if (Console.ReadLine().Trim().ToLower() == "y") { goto UserInput; }
    }

    //Получение данных из БД
    private static Client CreateCommand(string queryString, string connectionString)
    {
        Client client = new Client();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand(queryString, connection))
            //Чтение данных из бд и запись их в объект сlient
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    client.ID = reader.GetInt32(0);
                    client.Name = reader.GetString(1);
                    client.Birthdate = reader.GetDateTime(2);
                    client.PhoneNumber = reader.GetString(3);
                    client.Address = reader.GetString(4);
                    client.SocialNumber = reader.GetString(5);
                }
            }
        }
        return client;
    }
    //Проверка ИНН номера 
    private static bool CheckInput(string userInput)
    {
        foreach (char symbol in userInput)
        {
            if (!char.IsDigit(symbol))
            {
                return false;
            }
        }
        return true;
    }
}

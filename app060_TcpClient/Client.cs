using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;


class Client
{
    static Random rnd = new Random();
    private static string _name = "";
    public static TcpClient client = new TcpClient();
    public static List<Message> messages = new List<Message>();
    static void Main()
    {
        tcpConnect:
        try
        {
            //client.Connect("10.10.10.20", 13000);
            client.Connect("192.168.0.88", 13000);
        }
        catch (SocketException)
        {
            Console.WriteLine("Сервер не отвечает, попробуйте позже!");
            goto tcpConnect;
        }
        NetworkStream stream = client.GetStream();
        BinaryReader br = new BinaryReader(stream);
        BinaryWriter bw = new BinaryWriter(stream);
        stream.ReadTimeout = 1000;
        Console.WriteLine("Поздравляем! Вы успешно подключились к серверу.\nДля начала чата введите свой Ник:");

        InputName:
        //Внутренняя проверка Ника на пустоту
        _name = Console.ReadLine();
        if (string.IsNullOrEmpty(_name) || (_name.Length < 4 && _name.Length > 9))
        {
            Console.WriteLine($"Ошибка в Нике! Длина Никнейма длжна быть от 5 до 8 букв. Повторите ввод: ");
            goto InputName;
        }

        //Отправка имени пользователя для регистрации на сервере
        try { bw.Write(_name); }
        catch (Exception e)
        {
            Console.WriteLine($"{e.ToString()} ");
            goto tcpConnect;
        }

        //получение обратной связи сервера на отправленный ранее Никнейм
        string erMessage = "";
        try { erMessage = br.ReadString(); }
        catch (Exception e)
        {
            Console.WriteLine($"{e.ToString()} ");
        }
        if (erMessage.Length > 0) { Console.WriteLine(erMessage); goto InputName; }

        //получение истории чата за последние 10 минут от сервера 
        Message message = new Message();
        int index = 0;
        try
        {
            int length = br.ReadInt32();
            while (index < length)
            {
                //диссериализация объектов сообщения за последние 10 минут
                message = Message.Deserialize(br);
                //добавляем сообщение в список messages
                messages.Add(message);
                //Вывод на экран всего чата
                Console.WriteLine(message.Print());
                index++;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.ToString()} ");
        }


        while (true) //отправка и получение сообщений
        {
            InputMessage:
            Console.WriteLine("Введите свое сообщение: ");
            string strMessage = $"{_name}:" + Console.ReadLine();

            //сохранение чата в файл или выход 
            if (strMessage.Trim().ToLower() == "save") { }
            else if (strMessage.Trim().ToLower() == "exit") { break; }
            message = new Message(strMessage, DateTime.Now);

            //Отправка сообщения

            try { message.Serialize(bw); }
            catch (IOException e)
            {
                Exception innerException = e.InnerException;
                if (innerException != null)
                {
                    SocketException socketException = (SocketException)innerException;
                    switch (socketException.SocketErrorCode)
                    {
                        case SocketError.TimedOut: continue;
                        case SocketError.ConnectionReset: throw new Exception();
                    }
                }
            }



            //Получаем сообщение от участников чата
            try { message = Message.Deserialize(br); }
            catch (IOException e)
            {
                Exception innerException = e.InnerException;
                if (innerException != null)
                {
                    SocketException socketException = (SocketException)innerException;
                    switch (socketException.SocketErrorCode)
                    {
                        case SocketError.TimedOut: continue;
                    }
                }
            }
            messages.Add(message);
            Console.WriteLine(message.Print());
        }

        appExit:
        Console.WriteLine();
        Console.WriteLine("========================================================================");
        Console.WriteLine("Выйти из программы [y/n]?");
        if (Console.ReadLine().Trim().ToLower() == "n") { goto tcpConnect; }
    }
}








/*
 1) Чат в подсети 10.10.10.Х
 2) В чате не более 5 клиентов
 3) Обмен только текстом
 4) У каждого клиента свое имя(ник) уникально
 5) Клиент бездействует не более 5 минут system.timer
 6) Время отпрвки сообщения
 7) Вход в чат по нику
 8) Отпрака сообщения клавишей ENTER
 9) Длина сообщения не более 8096 байт
10) Формат представления чата:
[HH:mm:ss DD-MM-YY] Ник:
Текстовое сообщение
-------------------
Возможность сохранить в текстовый файл историю чата в рамках текущей сессии
При входе в чат выводить все сообщения от всех клиентов за последние 10 минут. -  клас message - список messages system.timer считает время
Все клиенты получают сообщения о входе или выходе их чата какого-либо клиента
Реализовать возможность отправить приватное сообщение конкретному клиенту чата
[Ник]>...... текст сообщения
Возможность запускать несколько сессий чата(консолей) на одной машине.
В качестве приглашения использовать IP-адрес, который введет клиент(пользователь)

 */



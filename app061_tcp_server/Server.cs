using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class MyTcpListener
{
    const int PORT = 13000; // порт для прослушивания подключений
    public static List<Client> clients = new List<Client>();
    public static List<Message> messages = new List<Message>();

    public static void Main()
    {
        startServer:
        try
        {
            Thread ListenerThread = new Thread(ListenerProc);
            ListenerThread.IsBackground = false;
            ListenerThread.Priority = ThreadPriority.Highest;
            ListenerThread.Start();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            goto startServer;
        }
    }

    public static void ListenerProc()
    {
        TcpListener server = null;
        IPAddress localAddr = IPAddress.Parse("10.10.10.20");
        //IPAddress localAddr = IPAddress.Parse("192.168.0.88");
        server = new TcpListener(localAddr, PORT);

        // запуск слушателя
        server.Start();
        Console.WriteLine("Сервер запущен");

        // получаем входящее подключение   
        Console.WriteLine("Ожидание подключения клиентов...");

        //Создаю поток для работы с подключившимся клиентом по TCP
        Thread clientThread = null;

        TcpClient client = null;

        while (true)
        {
            clientThread = new Thread(welcome);
            client = server.AcceptTcpClient();
            clientThread.IsBackground = true;
            clientThread.Start(client);
        }
    }

    //Проверка ника, получение и отправка сообщений
    public static void welcome(object inParam)
    {
        TcpClient client = (TcpClient)inParam;
        Console.WriteLine($"Входящее соединение от {client.Client.RemoteEndPoint.ToString()}");
        NetworkStream clientStream = client.GetStream();
        BinaryWriter bw = new BinaryWriter(clientStream);
        BinaryReader br = new BinaryReader(clientStream);

        string name = "";
        getName:
        //Получение и проверка Ника подключившегося клиента

        try { name = br.ReadString(); }
        catch (Exception e)
        {
            Exception innerException = e.InnerException;
            if (innerException != null)
            {
                SocketException socketException = (SocketException)innerException;
                switch (socketException.SocketErrorCode)
                {
                    case SocketError.ConnectionReset:
                        Console.WriteLine($"Cоединение c {client.Client.RemoteEndPoint.ToString()} разорвано! ");
                        return;
                }
            }
        }

        //Проверка совпадает ли ник с уже существующими в списке 
        if (clients.Count != 0)
        {
            lock (client)
            {
                foreach (Client chatClient in clients)
                {
                    if (chatClient.Name == name)
                    {
                        try
                        {
                            //Передаем сообщение клиенту что ник занят
                            bw.Write("Ник уже используется в чате другим пользователем!\nВведите другой Ник:");
                            goto getName;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Cоединение c {client.Client.RemoteEndPoint.ToString()} разорвано! ");
                            return;
                        }
                    }
                }
            }
        }

        //Передаем сообщение клиенту, что ник свободен
        try { bw.Write(""); } catch (Exception) { Console.WriteLine($"Cоединение c {client.Client.RemoteEndPoint.ToString()} разорвано! ");  return; }
        Client justlogedInClient = new Client(name, client, clientStream);
        lock (clients) { clients.Add(justlogedInClient); }

        #region История Чата
        /*
        //Сбоираем подключившемуся пользователю историю чата за последние 10 минут
        //int index = 0;
        //DateTime now = DateTime.UtcNow - TimeSpan.FromMinutes(10);
        //List<Message> msgHistory = new List<Message>();
        //if (messages.Count > 0)
        //{
        //    //счетчик для считывания байтов в потоке BinaryReader на стороне клиента
        //    int count = 0;
        //    while (index < messages.Count)
        //    {
        //        if (messages[index].Time < now) { break; }
        //        if (string.IsNullOrEmpty(messages[index].Recepient) || messages[index].Recepient == name)
        //        {
        //            msgHistory.Add(messages[index]);
        //            count++;
        //        }
        //        index++;
        //    }
        //}

        //Отправляем новому пользователю историю чата за последние 10 минут
        // отправляем длину массива
        try { bw.Write(msgHistory.Count); }
        catch (Exception e) { Console.WriteLine(e.ToString()); }
        try //отправляем сообщения        
        {
            foreach (Message msge in msgHistory) { msge.Serialize(bw); }
        }
        catch (Exception e)
        {
            Exception innerException = e.InnerException;
            if (innerException != null)
            {
                SocketException socketException = (SocketException)innerException;
                switch (socketException.SocketErrorCode)
                {
                    case SocketError.ConnectionReset:
                        string disconnectedClientNotification = $"Cоединение c {justlogedInClient.Name} [{justlogedInClient.ClientTcp.Client.RemoteEndPoint.ToString()}] разорвано!";
                        Console.WriteLine($"{DateTime.UtcNow.ToString("[HH:mm:ss dd-MM-yyyy]")} Server:{disconnectedClientNotification}");
                        //Сообщение о тольк-что присоединившемся участника чата
                        Message logOutMsg = new Message();
                        logOutMsg.Time = DateTime.UtcNow;
                        logOutMsg.Sender = "Admin";
                        logOutMsg.Body = $"{name} присоединился к чату! Добро пожаловать!";
                        lock (locker) { messages.Add(logOutMsg); }

                        //уведомление всех пользователей о присоединении участника к чату 
                        sendAllMessage(logOutMsg, justlogedInClient);
                        goto StartServer;
                }
            }
        }
        */
        #endregion

        //Сообщение о тольк-что присоединившемся участнике чата
        Message msg = new Message();
        msg.Time = DateTime.UtcNow;
        msg.Sender = "Admin";
        msg.Body = $"{name} присоединился к чату! Добро пожаловать!";
        lock (clients)
        {
            //запись уведомления о присоединении участника чата в messages
            messages.Add(msg);
            //уведомление всех пользователей о присоединении участника к чату         
            sendMessage(msg, justlogedInClient);
        }
        //поток в котором клиент получает сообщения
        Thread getMessages = new Thread(getMessage);
        getMessages.IsBackground = true;
        getMessages.Start(justlogedInClient);
    }

    public static void getMessage(object inParam)
    {

        Client client = (Client)inParam;
        Message message = new Message();
        BinaryReader br = new BinaryReader(client.ClientStream);

        //получение сообщения от клиента
        while (true)
        {
            try { message = Message.Deserialize(br); }
            catch (Exception e)
            {
                Exception innerException = e.InnerException;
                if (innerException != null)
                {
                    SocketException socketException = (SocketException)innerException;
                    switch (socketException.SocketErrorCode)
                    {
                        case SocketError.TimedOut: continue;
                        case SocketError.ConnectionReset:
                            message.Time = DateTime.UtcNow;
                            message.Sender = "Admin";
                            message.Body = $"Cоединение c {client.Name} разорвано!";
                            lock (clients)
                            {
                                messages.Add(message);
                                clients.Remove(client);
                                sendMessage(message, client);
                            }
                            Console.WriteLine($"{DateTime.UtcNow.ToString("[HH:mm:ss dd-MM-yyyy]")} Cоединение c [{client.ClientTcp.Client.RemoteEndPoint.ToString()}] разорвано!");
                            goto CloseThread;
                            //throw new Exception($"{DateTime.UtcNow.ToString("[HH:mm:ss dd-MM-yyyy]")} Cоединение c {client.Name} [{client.ClientTcp.Client.RemoteEndPoint.ToString()}] разорвано!");
                    }
                }
            }
            //Console.WriteLine($"From:{message.Sender}:{(message.IsPrivate ? "To:" + message.Recepient + ">" : "ToAll:")}{message.Body}");
            //отправка сообщения клиенту или всем клиентам
            lock (clients)
            {
                messages.Add(message);
                sendMessage(message, client);
            }
        }
        CloseThread:;
    }

    // трансляция сообщения подключенным клиентам
    public static void sendMessage(Message msg, Client client)
    {
        //есть ли ресипиент в списке клиентов
        bool containsName = false;

        if (msg.IsPrivate)
        {
            foreach (Client chatClient in clients)
            {
                //проверка совпадает ли имя в списке с именем получателя сообщения
                if (chatClient.Name == msg.Recepient && chatClient != client) { containsName = true; }
            }
        }

        foreach (Client chatClient in clients)
        {
            BinaryWriter bw = new BinaryWriter(chatClient.ClientStream);
            if (chatClient != client)
            {
                //если приватное сообщение и содержит имя отправка личного сообщения частному получателю
                if (msg.IsPrivate && containsName)
                {
                    if (msg.Recepient == chatClient.Name)
                    {
                        try { msg.Serialize(bw); }
                        catch (Exception) { continue; }

                    }
                }
                else { try { msg.Serialize(bw); } catch (Exception) { continue; }; }
            }
        }
    }
}

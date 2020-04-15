using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


class Client
{
    //записываются 
    private List<Message> _privateMessages = new List<Message>();
    private string _name;
    private TcpClient _client = null;
    private NetworkStream _clientStream = null;
    public Client() { }
    public Client(string name, TcpClient tcpClient, NetworkStream clienNetworktStream)
    {
        _name = name;
        _client = tcpClient;
        _clientStream = clienNetworktStream;
    }
    public string Name { get { return _name; } set { _name = value; } }
    public TcpClient ClientTcp { get { return _client; } }
    public NetworkStream ClientStream { get { return _clientStream; } }
}






using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Message
{
    private DateTime _date;
    private string _sender = "";
    private string _body = "";
    private string _recipient = null;
    private bool _isPrivate = false;

    public Message() { }
    public Message(string message, DateTime date)
    {
        _date = date;
        int caret = message.IndexOf(':', 0);
        //Выясняем отправителя сообщения
        _sender = message.Substring(0, caret);

        //Выясняем получателя личного сообщения
        int senderCaret = caret + 1;
        caret = message.IndexOf('>', senderCaret);

        //Если учитывать что ник не меньше 5 и не больше 8 символов  
        if (caret - senderCaret > 4 && caret - senderCaret < 9)
        {
            _body = message.Substring(caret + 1, message.Length - caret - 1);
            _recipient = message.Substring(senderCaret, caret - senderCaret);
            _isPrivate = true;
        }
        else
        {
            _body = message.Substring(senderCaret, message.Length - senderCaret);
        }
    }
    private Message(BinaryReader br)
    {
        _date = DateTime.FromBinary(br.ReadInt64()).ToLocalTime(); ;
        _sender = br.ReadString();
        _recipient = br.ReadString();
        _body = br.ReadString();
        _isPrivate = br.ReadBoolean();
    }

    public DateTime Time { get { return _date; } set { _date = value; } }
    public string Sender { get { return _sender; } set { _sender = value; } }
    public string Body { get { return _body; } set { _body = value; } }
    public string Recepient { get { return _recipient; } set { _recipient = value; } }
    public bool IsPrivate { get { return _isPrivate; } }

    public static Message Deserialize(BinaryReader br) { return new Message(br); }

    public void Serialize(BinaryWriter bw)
    {
        bw.Write(_date.ToBinary());
        bw.Write(_sender);
        bw.Write(string.IsNullOrEmpty(_recipient) ? char.ConvertFromUtf32(0) : _recipient);
        bw.Write(_body);
        bw.Write(_isPrivate);
    }

}

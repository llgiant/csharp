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
    private string _recipient = "";
    private bool _isPrivateMessage = false;
    public Message() { }
    public Message(string message, DateTime date)
    {
        _date = date;
        int caret = message.IndexOf(':', 0);
        //Выясняем отправителя сообщения
        _sender = message.Substring(0, caret - 1);

        //Выясняем получателя личного сообщения
        int senderCaret = caret + 1;
        caret = message.IndexOf('>', senderCaret);

        //Если учитывать что ник не меньше 5 и не больше 8 символов  
        if (caret > 4 && caret < 9)
        {
            _body = message.Substring(caret, message.Length - caret - 1);
            _recipient = message.Substring(senderCaret, caret - senderCaret);
            _isPrivateMessage = true;
        }
        else
        {
            _body = message.Substring(senderCaret, message.Length - senderCaret - 1);
        }
    }

    private Message(BinaryReader br)
    {
        _date = DateTime.FromBinary(br.ReadInt64()).ToLocalTime();
        _sender = br.ReadString();
        _recipient = br.ReadString();
        _body = br.ReadString();
        _isPrivateMessage = br.ReadBoolean();
    }
    public string Print()
    {
        string date = _date.ToString("[HH:mm:ss dd-MM-yyyy]");
        string recepient = string.IsNullOrEmpty(_recipient) ? "" : _recipient + ">";
        return $"{date} {_sender}: {recepient} {_body}";
    }
    public DateTime Time { get { return _date; } }
    public string Sender { get { return _sender; } }
    public string Body { get { return _body; } }
    public string Recepient { get { return _recipient; } }
    public bool IsPrivate { get { return _isPrivateMessage; } }

    public static Message Deserialize(BinaryReader br) { return new Message(br); }

    public void Serialize(BinaryWriter bw)
    {
        bw.Write(_date.ToBinary());
        bw.Write(_sender);
        bw.Write(string.IsNullOrEmpty(_recipient) ? char.ConvertFromUtf32(0) : _recipient);
        bw.Write(_body);
        bw.Write(_isPrivateMessage);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Account : Human
{
    private string _login = string.Empty;
    private string _password = string.Empty;
    private DateTime _dateRegistry = DateTime.Now;

    public string Login { get; set; }
    public string Password { get; set; }
    public override DateTime DateRegistry { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}

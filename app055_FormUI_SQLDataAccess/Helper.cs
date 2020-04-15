using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Helper
{
    public static string CnnVal(string name)
    {
        var variable = ConfigurationManager.ConnectionStrings[name].ConnectionString;
        return variable;
    }
}

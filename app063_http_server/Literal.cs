using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Literal : Pattern
{
    public Literal(string literal)
    {
        if (string.IsNullOrEmpty(literal)) { throw new Exception("Ошибка, строка литерала пуста"); }
        string _literal = literal.Trim().ToLower();
        string allSigns = "abcdefghijklmnopqrstuvwxyz0123456789/-_=&?#.";
        int countQustSign = 0;
        int countSharpSign = 0;
        char symbol = ' ';
        char nextSymbol = ' ';
        int index = 0;

        
        while (index < _literal.Length)
        {
            symbol = _literal[index];
            if (!allSigns.Contains(symbol)) { throw new Exception($"Литерала не может содержать символ: \'{symbol.ToString()}\' "); }
            if (index + 1 < _literal.Length)
            {
                nextSymbol = _literal[index + 1];
                if (!char.IsLetterOrDigit(symbol))
                {
                    if ("/-_= &?#".Contains(nextSymbol))
                    {
                        throw new Exception($"Следом не может идти символ: \'{nextSymbol.ToString()}\'");
                    }
                    else if (symbol == '?' || symbol == '#')
                    {
                        if (symbol == '?') { countQustSign++; }
                        if (symbol == '#') { countSharpSign++; }
                        if (countQustSign > 1 || countSharpSign > 1) { throw new Exception($"В Литерале не может содержаться больше одного символа: \'{symbol.ToString()}\' "); }
                    }
                }
            }
            index++;
        }
        _name = _literal;
    }
}


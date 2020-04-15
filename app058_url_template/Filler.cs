using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Filler : Pattern
{
    public Filler(string filler)
    {
        if (string.IsNullOrEmpty(filler)) { throw new Exception("Ошибка, строка заполнителя пуста"); }
        string _filler = filler.ToLower();
        string allSigns = "abcdefghijklmnopqrstuvwxyz0123456789-_";
        char symbol = ' ';
        char nextSymbol = ' ';
        int index = 0;



        while (index < _filler.Length)
        {
            symbol = _filler[index];
            if (!allSigns.Contains(symbol)) { throw new Exception($"Ошибка, заполнитель не может содержать символ: \'{symbol.ToString()}\'"); }

            if (index + 1 < _filler.Length)
            {
                nextSymbol = _filler[index + 1];
                if (!char.IsLetter(symbol))
                {
                    if (index == 0)
                    {
                        throw new Exception($"Cимвол \'{symbol.ToString()}\' не может быть первым в заполнителе.");
                    }
                    else if (symbol == '-' || symbol == '_')
                    {
                        if (index == _filler.Length) { throw new Exception($"Cимвол \'{symbol.ToString()}\' не может быть последним."); }
                        if ("-_".Contains(_filler[index + 1])) { throw new Exception($"Следом не может идти символ: \'{nextSymbol.ToString()}\'"); }
                    }
                }
            }
            index++;
        }
        _name = filler;
    }
}


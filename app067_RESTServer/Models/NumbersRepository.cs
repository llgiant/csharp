using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app067_RESTServer.Models
{
    public class NumbersRepository  //INumbersRepository
    {
        private List<Number> _numbers;
        public NumbersRepository()
        {
            _numbers = new List<Number>()
            {
                new Number{Id = 0 },
                new Number{Id = 1 },
                new Number{Id = 2 }
            };
        }

        public string Add(int id)
        {
            Number number = _numbers.FirstOrDefault(n => n.Id == id);
            if (number != null)
            {
                return $"Число \"{id}\" уже имеется в списке";
            }
            number = new Number() { Id = id };
            _numbers.Add(number);
            return $"Число \"{id}\" добавлено в список";
        }

        public IEnumerable<int> GetAllNumbers()
        {
            return _numbers.ToList().Select(x => x.Id);
        }

        public string GetNumber(int id)
        {
            Number number = _numbers.FirstOrDefault(n => n.Id == id);
            if (number == null) { return $"Числа \"{id}\" нет в списке"; }
            return _numbers.FindIndex(c => c.Id == id).ToString(); 
        }

    }
}

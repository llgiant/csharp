using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app067_RESTServer.Models
{
    public class NumbersSetRepository : INumbersRepository
    {
        private HashSet<Number> _numbers;

        public NumbersSetRepository()
        {
            _numbers = new HashSet<Number>(){};
        }

        public Number Add(Number num)
        {
            var number = _numbers.FirstOrDefault(n => n.Id == num.Id);
            if (number == null) { _numbers.Add(num); return num; }
            throw new Exception($"Число {num.Id} уже есть в списке"); 
        }

        public Number GetNumber(int id)
        {
            var number = _numbers.FirstOrDefault(n => n.Id == id);
            if (number == null) { throw new Exception($"Числа {id} нет в списке"); }
            return number;
        }

        public Number Delete(int id)
        {
            var number = _numbers.FirstOrDefault(n => n.Id == id);
            if (number != null)
            {
                _numbers.Remove(number);
                return number;
            }
            throw new Exception($"Числа {id} нет в списке");
        }

        public IEnumerable<int> GetAllNumbers()
        {
            return _numbers.ToList().Select(x => x.Id);
        }

    }
}

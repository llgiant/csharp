using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app067_RESTServer.Models
{
    public interface INumbersRepository
    {
        IEnumerable<int> GetAllNumbers();
        Number GetNumber(int id);
        Number Add(Number id);
        Number Delete(int id);               
    }
}

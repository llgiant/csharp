using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app055_FormUI_SQLDataAccess
{
    class Person
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string FullInfo { get { return $"{LastName} {FirstName} {SecondName} {PhoneNumber}"; } }

    }
}

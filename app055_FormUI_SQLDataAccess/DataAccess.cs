using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace app055_FormUI_SQLDataAccess
{
    class DataAccess
    {
        public List<Person> GetPeople(string lastName)
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                //var output = connection.Query<Person>($"select * from Members where LastName ='{ lastName }'").ToList();
                var output = connection.Query<Person>("dbo.People_GetByLastName @LastNAme",new { lastName = lastName}).ToList();

                return output;
            }
        }

        internal void InsertPerson(string firstName, string lastName, string secondName, string gender, string phoneNumber)
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                // Person newPerson = new Person { FirstName = firstName, LastName = lastName, SecondName = secondName, Gender = gender, PhoneNumber = phoneNumber}; 
                List<Person> people = new List<Person>();
                people.Add(new Person { FirstName = firstName, LastName = lastName, SecondName = secondName, Gender = gender, PhoneNumber = phoneNumber });
                connection.Execute("dbo.People_Insert @FirstName, @LastName, @SecondName, @Gender, @PhoneNumber", people);
            }
        }
    }
}

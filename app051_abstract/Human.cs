using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Gender
{
    None = 0,
    Male = 1,
    Female = 2,
    Trans = 3
}

abstract class Human
{
    private string _firstName = string.Empty;
    private string _lastName = string.Empty;
    private string _middleName = string.Empty;
    private Gender _gender = Gender.None;

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    protected Gender Gender { get; set; }
    abstract public DateTime DateRegistry { get; set; }
}

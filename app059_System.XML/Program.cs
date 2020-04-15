using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

class User
{
    public string Name { get; set; }
    public string Company { get; set; }
    public int Age { get; set; }

}
class Program
{
    static Random rnd = new Random();

    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("========================================================================");
        Console.WriteLine("Работа с XML");
        Console.WriteLine("========================================================================");
        Console.WriteLine();
        appBegin:

        
        List<User> users = new List<User>();

        XmlDocument xDoc = new XmlDocument();
        xDoc.Load(@"C:\Users\Operator\OneDrive\Dev\Files\users.xml");
        // получим корневой элемент
        XmlElement xRoot = xDoc.DocumentElement;
        //Обоход всех узлов в корневом элементе
        foreach (XmlNode xnode in xRoot)
        {
            User user = new User();
            // получаем атрибут name
            if (xnode.Attributes.Count > 0)
            {
                XmlNode attr = xnode.Attributes.GetNamedItem("name");
                if (attr != null) user.Name = attr.Value;
            }

            foreach (XmlNode childnode in xnode.ChildNodes)
            {
                if (childnode.Name == "company") user.Company = childnode.InnerText;
                if (childnode.Name == "age") user.Age = int.Parse(childnode.InnerText);
            }
            users.Add(user);
        }

        // создаем новый элемент user
        XmlElement userElem = xDoc.CreateElement("user");
        // создаем атрибут name
        XmlAttribute nameAttr = xDoc.CreateAttribute("name");
        // создаем элементы company и age
        XmlElement companyElem = xDoc.CreateElement("company");
        XmlElement ageElem = xDoc.CreateElement("age");
        // создаем текстовые значения для элементов и атрибута
        XmlText nameText = xDoc.CreateTextNode("Mark Zuckerberg");
        XmlText companyText = xDoc.CreateTextNode("Facebook");
        XmlText ageText = xDoc.CreateTextNode("30");

        //добавляем узлы
        nameAttr.AppendChild(nameText);
        companyElem.AppendChild(companyText);
        ageElem.AppendChild(ageText);
        userElem.Attributes.Append(nameAttr);
        userElem.AppendChild(companyElem);
        userElem.AppendChild(ageElem);
        xRoot.AppendChild(userElem);
        xDoc.Save(@"C:\Users\Operator\OneDrive\Dev\Files\users.xml");

        foreach (User user in users)
        {
            Console.WriteLine($"Name: {user.Name}\nCompany works for: {user.Company}\nAge: {user.Age}");
        }
        appExit:
        Console.WriteLine();
        Console.WriteLine("========================================================================");
        Console.WriteLine("Выйти из программы [y/n]?");
        if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }
    }
}


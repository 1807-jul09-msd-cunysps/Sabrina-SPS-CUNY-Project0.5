using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneAppProject
{
    public class ContactDirectory
    {
        public ContactDirectory() { }
        public void addContact()
        {
            Console.Write("Enter the first name:");
            string fn = Console.ReadLine();
            Console.Write("Enter the last name:");
            string ln = Console.ReadLine();
            Console.Write("Enter the House number:");
            string hNo = Console.ReadLine();
            Console.Write("Enter the Street name:");
            string streetName = Console.ReadLine();
            Console.Write("Enter the city:");
            string city = Console.ReadLine();
            Console.Write("Enter the state(initials only):");
            string state = Console.ReadLine();
            Console.Write("Enter the Country:");
            string ctry = Console.ReadLine();
            Console.Write("Enter the zip code:");
            string zip = Console.ReadLine();
            Console.Write("Enter the area code, if you have one");
            string area = Console.ReadLine();
            Console.Write("Enter the number:");
            string number = Console.ReadLine();

            Country code = Country.US;
            foreach (Country var in Enum.GetValues(typeof(Country)))
            {
                if (var.ToString() == ctry)
                {
                    code = var;
                }
            }

            //change State to string and make it optional because if you are in a country besides the US, you don't have states

            int ctryCode = (int)code;
            Person add = new Person(fn, ln, hNo, streetName, city, code, zip, number, state, area);
            directory.Add(add);
            Console.WriteLine("Contact Added");
        }




        public void deleteContact(string firstName, string lastName)
        {

        }

        public List<Person> directory;

    }
}

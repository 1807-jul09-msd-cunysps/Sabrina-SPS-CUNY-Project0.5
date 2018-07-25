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
        public void MainMenu()
        {
            Console.WriteLine("Welcome to the Your Phone Directory");
            Console.WriteLine("Choose your command from the menu below:");
            Console.WriteLine("1. Read");
            Console.WriteLine("2. Read By Name");
            Console.WriteLine("3. Search by Name");
            Console.WriteLine("4. Add Contact");
            Console.WriteLine("5. Update Existing Contact");
            Console.WriteLine("6. Delete Existing Contact");
            Console.WriteLine("7. Exit Main Menu");
            Console.WriteLine("Enter the number of the command you wish to execute:");
            string command = Console.ReadLine();

            switch (command)
            {
                case "1":
                    Read();
                    break;

                case "2":
                    Console.WriteLine("Enter the first name of the person you wish to read: ");
                    string fn = Console.ReadLine();
                    Console.WriteLine("Enter the last name of the person you wish to read: ");
                    string ln = Console.ReadLine();
                    ReadByName(fn, ln);
                    break;

                case "3":
                    Console.WriteLine("Enter the first name of the person you want to search for:");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Enter the last name of the person you want to search for:");
                    string lastName = Console.ReadLine();
                    break;

                case "4":

                    break;

                case "5":

                    break;

                case "6":

                    break;

                case "7":

                    break;
                default:

                    break;

            }
        }


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
            Console.Write("Enter the Country(initials only):");
            string ctry = Console.ReadLine();
            Console.Write("Enter the zip code:");
            string zip = Console.ReadLine();
            Console.Write("Enter the area code, if you have one:");
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

        public void Read()
        {
            Console.WriteLine("Our Directory:");
            for(var i = 0; i < directory.Count; i++)
            {
                directory[i].displayPerson();
            }
        }

        public void ReadByName(string firstName, string lastName)
        {
            Console.WriteLine($"Directory Search Results for: {firstName} {lastName}");
            for(var i = 0; i < directory.Count; i++)
            {
                if((directory[i].firstName == firstName) && (directory[i].lastName == lastName))
                {
                    directory[i].displayPerson();
                }
            }
        }


        public void deleteContact(string firstName, string lastName)
        {
            for(var i = 0; i < directory.Count; i++)
            {
                if ((directory[i].firstName == firstName) && (directory[i]).lastName == lastName){
                    directory.RemoveAt(i);
                }
            }
            Console.WriteLine("Contact Deleted");
        }

        public Person SearchByName(string firstName, string lastName)
        {
            for(var i = 0; i < directory.Count; i++)
            {
                if((directory[i].firstName == firstName) && (directory[i].lastName == lastName))
                {
                    return directory[i];
                }
            }
            return null;
        }

        public List<Person> directory = new List<Person>();

    }
}

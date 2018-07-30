using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.IO;


namespace PhoneAppProject
{
    
    public class ContactDirectory
    {
        public ContactDirectory() { }
        public void MainMenu()
        {
            string command = "";
            while (command != "7")
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
                command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        Read();
                        continue;

                    case "2":
                        Console.WriteLine("Enter the first name of the person you wish to read: ");
                        string fn = Console.ReadLine();
                        Console.WriteLine("Enter the last name of the person you wish to read: ");
                        string ln = Console.ReadLine();
                        ReadByName(fn, ln);
                        continue;

                    case "3":
                        Console.WriteLine("Enter the first name of the person you want to search for:");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Enter the last name of the person you want to search for:");
                        string lastName = Console.ReadLine();
                        SearchByName(firstName, lastName);
                        continue;

                    case "4":
                        addContact();
                        continue;

                    case "5":
                        Console.WriteLine("Enter the first name of the person you want to update:");
                        string firName = Console.ReadLine();
                        Console.WriteLine("Enter the last name of the person you want to update:");
                        string lasName = Console.ReadLine();
                        update(firName, lasName);
                        continue;

                    case "6":
                        Console.WriteLine("Enter the first name of the person you want to delete:");
                        string fName = Console.ReadLine();
                        Console.WriteLine("Enter the last name of the person you want to delete:");
                        string lName = Console.ReadLine();
                        deleteContact(fName, lName);
                        continue;
                    default:
                        break;

                }
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
            serializeObjectList();
            Console.WriteLine("Contact Added");
        }

        void serializeObjectList()
        {
            string json = JsonConvert.SerializeObject(directory, Formatting.Indented);
            string path = @"C:\Users\sflet\Documents\Revature\PhoneAppProject\Sabrina-SPS-CUNY-Project0.5\PhoneAppProject\PhoneAppProject\Directory.txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(json);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(@"C:\Users\sflet\Documents\Revature\PhoneAppProject\Sabrina-SPS-CUNY-Project0.5\PhoneAppProject\PhoneAppProject\Directory.txt"))
                {
                    sw.WriteLine(json);
                }
            }

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

        public void update(string firstName, string lastName)
        {
            Person contact = SearchByName(firstName, lastName);
            contact.displayPerson();
            Console.WriteLine("What would you like to update?");
            Console.WriteLine("1.The Contact Information(First Name, Last Name, etc)?");
            Console.WriteLine("2.The Address Information?");
            Console.WriteLine("3.The Phone Number?");
            Console.WriteLine("4.Nothing");
            Console.WriteLine("Enter the number for the option you want to update:");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("Enter the new first name of the person you want to update:");
                    string fName = Console.ReadLine();
                    Console.WriteLine("Enter the new last name of the person you want to update:");
                    string lName = Console.ReadLine();
                    contact.firstName = fName;
                    contact.lastName = lName;
                    break;

                case "2":
                    Console.Write("Enter the new House number:");
                    string hNo = Console.ReadLine();
                    Console.Write("Enter the new Street name:");
                    string streetName = Console.ReadLine();
                    Console.Write("Enter the new city:");
                    string city = Console.ReadLine();
                    Console.Write("Enter the new state(initials only):");
                    string state = Console.ReadLine();
                    Console.Write("Enter the new Country(initials only):");
                    string ctry = Console.ReadLine();
                    Console.Write("Enter the new zip code:");
                    string zip = Console.ReadLine();

                    Country code = Country.US;
                    foreach (Country var in Enum.GetValues(typeof(Country)))
                    {
                        if (var.ToString() == ctry)
                        {
                            code = var;
                        }
                    }
                
                    contact.address.houseNum = hNo;
                    contact.address.street = streetName;
                    contact.address.city = city;
                    contact.address.state = state;
                    contact.address.country = code;
                    contact.address.zipcode = zip;

                    break;

                case "3":
                    Console.Write("Enter the area code, if you have one:");
                    string area = Console.ReadLine();
                    Console.Write("Enter the number:");
                    string number = Console.ReadLine();

                    contact.phone.countryCode = (int)contact.address.country;
                    contact.phone.areaCode = area;
                    contact.phone.number = number;
                    break;

                default:
                    break;

                
            }

        }

        public List<Person> directory = new List<Person>();

    }
}

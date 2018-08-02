using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.IO;
using ContactDAL;

namespace PhoneAppProject
{
    
    public class ContactDirectory
    {
        public ContactDirectory() { }
        public void MainMenu()
        {
            List<Person> directory = sqlRequest.LoadIntoCollection();
            string command = "";
            while (command != "7")
            {
                Console.WriteLine("Welcome to the Your Phone Directory \n");
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
                        Person readContact = ReadByName(fn, ln);
                        if (readContact != null)
                        {
                            readContact.displayPerson();
                        }
                        else
                        {
                            Console.WriteLine("No Contact by that name");
                        }
                        continue;

                    case "3":
                        Console.WriteLine("Enter the first name of the person you want to search for:");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Enter the last name of the person you want to search for:");
                        string lastName = Console.ReadLine();
                        Person temp = SearchByName(firstName, lastName);
                        if (temp != null)
                        {
                            temp.displayPerson();
                        }
                        else
                        {
                            Console.WriteLine("No Person by that name in the Directory.");
                        }
                        continue;

                    case "4":
                        addContact();
                        continue;

                    case "5":
                        Console.WriteLine("Enter the first name of the person you want to update:");
                        string firName = Console.ReadLine();
                        Console.WriteLine("Enter the last name of the person you want to update:");
                        string lasName = Console.ReadLine();
                        Person tempSearch = SearchByName(firName, lasName);
                        if(tempSearch != null)
                        {
                            update(tempSearch);
                        }
                        else
                        {
                            Console.WriteLine("Person does not exist");
                        }
                        directory.Clear();
                        directory = sqlRequest.LoadIntoCollection();
                        
                        continue;

                    case "6":
                        Console.WriteLine("Enter the first name of the person you want to delete:");
                        string fName = Console.ReadLine();
                        Console.WriteLine("Enter the last name of the person you want to delete:");
                        string lName = Console.ReadLine();
                        deleteContact(fName, lName);
                        directory.Clear();
                        directory = sqlRequest.LoadIntoCollection();

                        continue;
                    default:
                        break;

                }
            }
        }


        public void addContact()
        {
            List<Person> directory = sqlRequest.LoadIntoCollection();
            Console.Write("Enter the first name:");
            string fn = Console.ReadLine();
            Console.Write("Enter the last name:");
            string ln = Console.ReadLine();
            Person check = SearchByName(fn, ln);
            if (!contactExist(check))
            {
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
                Person add = new Person(fn, ln, hNo, streetName, city, ctry, zip, number, state, area);
                directory.Add(add);
                serializeObjectList();
                sqlRequest.writePersonToDB(add);
                Console.WriteLine("Contact Added");
                directory = sqlRequest.LoadIntoCollection();
            }
            else
            {
                Console.WriteLine("Person already exists.");
            }
            
        }

        void serializeObjectList()
        {
            List<Person> directory = sqlRequest.LoadIntoCollection();
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




        public Person ReadByName(string firstName, string lastName)
        {
            List<Person> directory = sqlRequest.LoadIntoCollection();
            Console.WriteLine($"Directory Search Results for: {firstName} {lastName} \n");
            for(var i = 0; i < directory.Count; i++)
            {
                if((directory[i].firstName == firstName) && (directory[i].lastName == lastName))
                {
                     return directory[i];
                }
            }
            return null;
        }


        public void deleteContact(string firstName, string lastName)
        {
            List<Person> directory = new List<Person>();
            bool result = sqlRequest.deleteContactDB(firstName, lastName);
            Console.WriteLine(result);
            //Console.WriteLine("Contact Deleted");
            
        }

        public Person SearchByName(string firstName, string lastName)
        {
            List<Person> directory = sqlRequest.LoadIntoCollection();
            for (var i = 0; i < directory.Count; i++)
            {
                if((directory[i].firstName == firstName) && (directory[i].lastName == lastName))
                {
                    return directory[i];
                }
            }
            return null;
        }

        public bool contactExist(Person person)
        {
            List<Person> directory = sqlRequest.LoadIntoCollection();
            if (person != null)
            {
                for (var i = 0; i < directory.Count; i++)
                {
                    if (person.Pid == directory[i].Pid)
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }

        public void update(Person person)
        {
           
            person.displayPerson();
            string option = "";
            while(option != "4")
            {
                
                Console.WriteLine("What would you like to update?");
                Console.WriteLine("1.The Contact Information(First Name, Last Name, etc)?");
                Console.WriteLine("2.The Address Information?");
                Console.WriteLine("3.The Phone Number?");
                Console.WriteLine("4.Nothing");
                Console.WriteLine("Enter the number for the option you want to update:");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("Enter the new first name of the person you want to update:");
                        string fName = Console.ReadLine();
                        Console.WriteLine("Enter the new last name of the person you want to update:");
                        string lName = Console.ReadLine();
                        if (fName != "")
                        {
                            person.firstName = fName;
                        }
                        if (lName != "")
                        {
                            person.lastName = lName;
                        }
                        bool resultPerson = sqlRequest.updateDB(person, "Directory");
                        continue;

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
                        
                        if(hNo != "")
                        {
                            person.address.houseNum = hNo;
                        }

                        if (streetName != "")
                        {
                            person.address.street = streetName;
                        }

                        if (city != "")
                        {
                            person.address.city = city;
                        }

                        if ((ctry == "US") && ( state != ""))
                        {
                            person.address.state = state;
                        }

                        if(ctry != "")
                        {
                            person.address.country = ctry;
                        }

                        if (zip != "")
                        {
                            person.address.zipcode = zip;
                        }
                        bool resultAddr = sqlRequest.updateDB(person, "Address");

                        continue;

                    case "3":
                        Console.Write("Enter your country code: ");
                        string country = Console.ReadLine();
                        Console.Write("Enter the area code, if you have one:");
                        string area = Console.ReadLine();
                        Console.Write("Enter the number:");
                        string number = Console.ReadLine();

                        Country code = Country.US;
                        foreach (Country var in Enum.GetValues(typeof(Country)))
                        {
                            if (var.ToString() == country)
                            {
                                code = var;
                            }
                        }

                        if(((int)code).ToString() != "")
                        {
                            person.phone.countryCode = ((int)code).ToString();
                        }

                        if((area != "") && (person.address.country == "US"))
                        {
                            person.phone.areaCode = area;
                        }
                        if(number != "")
                        {
                            person.phone.number = number;
                        }
                        bool resultPH = sqlRequest.updateDB(person, "Phone");


                        continue;

                    default:
                        break;


                }

            }
           

        }

        public void Read()
        {

            List<Person> directory = sqlRequest.LoadIntoCollection();
            Console.WriteLine("Our Directory: \n");
            for (var i = 0; i < directory.Count; i++)
            {
                directory[i].displayPerson();
            }
        }

        SQLFunctions sqlRequest = new SQLFunctions();


    }
}

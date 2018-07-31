using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.IO;
using System.Data;
using System.Data.SqlClient;


namespace PhoneAppProject
{
    
    public class ContactDirectory
    {
        public ContactDirectory() { }
        public void MainMenu()
        {
            string command = "";
            LoadIntoCollection();
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
            Person add = new Person(fn, ln, hNo, streetName, city, ctry, zip, number, state, area);
            directory.Add(add);
            serializeObjectList();
            writePersonToDB(add);
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


                
                    contact.address.houseNum = hNo;
                    contact.address.street = streetName;
                    contact.address.city = city;
                    contact.address.state = state;
                    contact.address.country = ctry;
                    contact.address.zipcode = zip;

                    break;

                case "3":
                    Console.Write("Enter the area code, if you have one:");
                    string area = Console.ReadLine();
                    Console.Write("Enter the number:");
                    string number = Console.ReadLine();

                    Country code = Country.US;
                    foreach (Country var in Enum.GetValues(typeof(Country)))
                    {
                        if (var.ToString() == contact.address.country)
                        {
                            code = var;
                        }
                    }

                    contact.phone.countryCode = ((int)code).ToString();
                    contact.phone.areaCode = area;
                    contact.phone.number = number;
                    break;

                default:
                    break;

                
            }

        }
        //SQL Functions

        public void LoadIntoCollection()
        {
            var log = NLog.LogManager.GetCurrentClassLogger();
            string conStr = "Data Source=sabrina-cuny-sps-rev.database.windows.net;Initial Catalog=PhoneAppDB;Persist Security Info=True;User ID=sabrinaf;Password=Shona2018!";

            string addressSelect = "SELECT * FROM AddressBook";
            string directorySelect = "SELECT * FROM Directory";
            string phoneSelect = "SELECT * FROM Phone";

            using (SqlConnection source = new SqlConnection(conStr))
            {
                source.Open();
                try
                {

                    SqlCommand addressCmd = new SqlCommand(addressSelect, source);
                    SqlCommand directoryCmd = new SqlCommand(directorySelect, source);
                    SqlCommand phoneCmd = new SqlCommand(phoneSelect, source);

                    Dictionary<Int64, Address> addresses = new Dictionary<Int64, Address>();
                    List<Person> people = new List<Person>();
                    Dictionary<Int64, Phone> phones = new Dictionary<Int64, Phone>();


                    var addressExe = addressCmd.ExecuteReader();

                    using (addressExe)
                    {
                        while (addressExe.Read())
                        {
                            Address temp = new Address();
                            try
                            {

                                temp.houseNum = addressExe.GetString(0);
                                temp.street = addressExe.GetString(1);
                                temp.city = addressExe.GetString(2);
                                temp.state = addressExe.GetString(3);
                                temp.country = addressExe.GetString(4);
                                temp.zipcode = addressExe.GetString(5);
                                temp.Pid = addressExe.GetInt64(6);

                                //temp = new Address((long)addressExe.GetValue(0), addressExe.GetString(1), addressExe.GetString(2), addressExe.GetString(3), addressExe.GetString(4), addressExe.GetString(5), addressExe.GetString(6));
                            }
                            catch (Exception ex)
                            {
                                log.Error($"Address cannot be read from the DB, {ex.Message}");
                                Console.WriteLine($"Address cannot be read from the DB, {ex.Message}");
                            }
                            addresses.Add(temp.Pid, temp);
                        }

                    }

                    var directoryExe = directoryCmd.ExecuteReader();

                    using (directoryExe)

                    {
                        while (directoryExe.Read())
                        {
                            Person tempPerson = new Person();
                            try
                            {
                                tempPerson.Pid = directoryExe.GetInt64(0);
                                tempPerson.address = addresses[directoryExe.GetInt64(0)];
                                tempPerson.firstName = directoryExe.GetString(1);
                                tempPerson.lastName = directoryExe.GetString(2);
                            }
                            catch (Exception ex)
                            {
                                log.Error($"Person cannot be read from DB, {ex.Message}");
                                Console.WriteLine($"Person cannot be read from DB, {ex.Message}");
                            }
                            people.Add(tempPerson);

                        }

                    }

                    var phoneExe = phoneCmd.ExecuteReader();

                    using (phoneExe)
                    {
                        while (phoneExe.Read())
                        {
                            Phone burner = new Phone();
                            try
                            {
                                burner.countryCode = phoneExe.GetString(0);
                                burner.areaCode = phoneExe.GetString(1);
                                burner.number = phoneExe.GetString(2);
                                burner.Pid = phoneExe.GetInt64(3);
                            }
                            catch (Exception ex)
                            {
                                log.Error($"Phone cannot be read from DB: {ex.Message}");
                                Console.WriteLine($"Phone cannot be read from DB: {ex.Message} {ex.Data}");
                            }
                            phones.Add(burner.Pid, burner);
                        }
                    }
                    directory.Clear();
                    //Console.WriteLine(people.Count);
                    //Console.WriteLine(phones.Count);
                    //Console.WriteLine(addresses.Count);
                    for (var i = 0; i < people.Count; i++)
                    {
                        Country code = Country.US;
                        foreach (Country var in Enum.GetValues(typeof(Country)))
                        {
                            if (var.ToString() == addresses[people[i].Pid].country)
                            {
                                code = var;
                            }
                        }
                        directory.Add(new Person(people[i].firstName, people[i].lastName, addresses[people[i].Pid].houseNum, addresses[people[i].Pid].street, addresses[people[i].Pid].city, addresses[people[i].Pid].country, addresses[people[i].Pid].zipcode, phones[people[i].Pid].number, addresses[people[i].Pid].state, phones[people[i].Pid].areaCode, people[i].Pid));
                        //Console.WriteLine(people[i].Pid);
                        //Console.WriteLine(addres)
                    }
                }
                catch (SqlException ex)
                {
                    log.Error(ex);
                    Console.WriteLine($"Sql Exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    Console.WriteLine($"End all, catch all:{ex.Message}, {ex.TargetSite}");
                }
                finally
                {
                    source.Close();
                }

            }

        }

        public void deleteContactDB(string fName, string lName)
        {
            Person temp = SearchByName(fName, lName);

            var log = NLog.LogManager.GetCurrentClassLogger();
            string conStr = "Data Source=sabrina-cuny-sps-rev.database.windows.net;Initial Catalog=PhoneAppDB;Persist Security Info=True;User ID=sabrinaf;Password=Shona2018!";

            if(temp != null)
            {
                string deletePhone = $"DELETE FROM Phone WHERE @Person_ID = {temp.Pid}";
                string deleteAddress = $"DELETE FROM AddressBook WHERE @Person_ID = {temp.Pid}";
                string deletePerson = $"DELETE FROM Directory WHERE @Person_ID = {temp.Pid}";
            }
        }


        public void writePersonToDB(Person person)
        {
            var log = NLog.LogManager.GetCurrentClassLogger();
            SqlConnection con = null;
            string conStr = "Data Source=sabrina-cuny-sps-rev.database.windows.net;Initial Catalog=PhoneAppDB;Persist Security Info=True;User ID=sabrinaf;Password=Shona2018!";

            string addressInsert = "INSERT INTO AddressBook Values(@houseNo, @street, @city, @state, @country, @zip, @Person_ID)";
            string personInsert = "INSERT INTO Directory Values(@PersonID, @firstName, @lastName)";
            string phoneInsert = "INSERT INTO Phone Values(@CountryCode, @AreaCode, @Number, @Person_ID)";
            try
            {
                con = new SqlConnection(conStr);
                con.Open();

                SqlCommand addressCmd = new SqlCommand(addressInsert, con);
                SqlCommand personCmd = new SqlCommand(personInsert, con);
                SqlCommand phoneCmd = new SqlCommand(phoneInsert, con);
                Country code = Country.US;
                foreach (Country var in Enum.GetValues(typeof(Country)))
                {
                    if (var.ToString() == person.address.country)
                    {
                        code = var;
                    }
                }

                personCmd.Parameters.Add(new SqlParameter("PersonID", person.Pid));
                personCmd.Parameters.Add(new SqlParameter("firstName", person.firstName));
                personCmd.Parameters.Add(new SqlParameter("lastName", person.lastName));
                personCmd.Parameters.Add(new SqlParameter("Phone", person.phone.getNumber()));

                
                addressCmd.Parameters.Add(new SqlParameter("houseNo", person.address.houseNum));
                addressCmd.Parameters.Add(new SqlParameter("street", person.address.street));
                addressCmd.Parameters.Add(new SqlParameter("city", person.address.city));
                addressCmd.Parameters.Add(new SqlParameter("state", person.address.state));
                addressCmd.Parameters.Add(new SqlParameter("country", person.address.country));
                addressCmd.Parameters.Add(new SqlParameter("zip", person.address.zipcode));
                addressCmd.Parameters.Add(new SqlParameter("Person_ID", person.Pid));

                phoneCmd.Parameters.Add(new SqlParameter("CountryCode", person.phone.countryCode.ToString()));
                phoneCmd.Parameters.Add(new SqlParameter("AreaCode", person.phone.areaCode));
                phoneCmd.Parameters.Add(new SqlParameter("Number", person.phone.number));
                phoneCmd.Parameters.Add(new SqlParameter("Person_ID", person.Pid));


                if (personCmd.ExecuteNonQuery() == 0)
                {
                    throw new Exception($"Person did not insert: {person.Pid}");
                }

                if (addressCmd.ExecuteNonQuery() == 0)
                {
                    throw new Exception($"Address did not insert:{person.address.Pid}");

                }

                if(phoneCmd.ExecuteNonQuery() == 0)
                {
                    throw new Exception($"Phone did not insert: {person.phone.Pid}");
                }



            }
            catch (SqlException ex)
            {
                log.Info(ex.Message);
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                log.Info(ex.Message);
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public List<Person> directory = new List<Person>();

    }
}

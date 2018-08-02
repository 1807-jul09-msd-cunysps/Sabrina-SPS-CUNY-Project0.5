using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ContactDAL
{
    public class SQLFunctions
    {
        public List<Person> LoadIntoCollection()
        {
            var log = NLog.LogManager.GetCurrentClassLogger();
            string conStr = "Data Source=sabrina-cuny-sps-rev.database.windows.net;Initial Catalog=PhoneAppDB;Persist Security Info=True;User ID=sabrinaf;Password=Shona2018!";
            List<Person> directory = new List<Person>();

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
            return directory;

        }

        public bool updateDB(Person person, string table)
        {
            var log = NLog.LogManager.GetCurrentClassLogger();
            string conStr = "Data Source=sabrina-cuny-sps-rev.database.windows.net;Initial Catalog=PhoneAppDB;Persist Security Info=True;User ID=sabrinaf;Password=Shona2018!";

            string updatePhone = "UPDATE Phone SET CountryCode = @CountryCode, AreaCode = @AreaCode, Number = @Number WHERE Person_ID = @Person_ID";
            string updateAddressBook = "UPDATE AddressBook SET houseNo = @houseNo, street = @street, city = @city, state = @state, country = @country, zipcode = @zipcode WHERE Person_ID = @Person_ID";
            string updatePerson = "UPDATE Directory SET firstName = @firstName, lastName = @lastName WHERE PersonID = @PersonID";

            using (SqlConnection source = new SqlConnection(conStr))
            {
                source.Open();
                try
                {
                    SqlCommand updatePhoneCmd = new SqlCommand(updatePhone, source);
                    SqlCommand updateAddressCmd = new SqlCommand(updateAddressBook, source);
                    SqlCommand updatePersonCmd = new SqlCommand(updatePerson, source);

                    updatePhoneCmd.Parameters.Add(new SqlParameter("CountryCode", person.phone.countryCode));
                    updatePhoneCmd.Parameters.Add(new SqlParameter("AreaCode", person.phone.areaCode));
                    updatePhoneCmd.Parameters.Add(new SqlParameter("Number", person.phone.number));
                    updatePhoneCmd.Parameters.Add(new SqlParameter("Person_ID", person.phone.Pid));

                    updateAddressCmd.Parameters.Add(new SqlParameter("houseNo", person.address.houseNum));
                    updateAddressCmd.Parameters.Add(new SqlParameter("street", person.address.street));
                    updateAddressCmd.Parameters.Add(new SqlParameter("city", person.address.city));
                    updateAddressCmd.Parameters.Add(new SqlParameter("state", person.address.state));
                    updateAddressCmd.Parameters.Add(new SqlParameter("country", person.address.country));
                    updateAddressCmd.Parameters.Add(new SqlParameter("zipcode", person.address.zipcode));
                    updateAddressCmd.Parameters.Add(new SqlParameter("Person_ID", person.address.Pid));

                    updatePersonCmd.Parameters.Add(new SqlParameter("firstName", person.firstName));
                    updatePersonCmd.Parameters.Add(new SqlParameter("lastName", person.lastName));
                    updatePersonCmd.Parameters.Add(new SqlParameter("PersonID", person.Pid));

                    switch (table)
                    {
                        case "Phone":
                            if (updatePhoneCmd.ExecuteNonQuery() == 0)
                            {
                                return false;
                            }
                            break;
                        case "Address":
                            if (updateAddressCmd.ExecuteNonQuery() == 0)
                            {
                                return false;
                            }
                            break;
                        case "Directory":
                            if (updatePersonCmd.ExecuteNonQuery() == 0)
                            {
                                return false;
                            }
                            break;
                        default:
                            break;

                    }
                }
                catch (SqlException ex)
                {
                    log.Info(ex.Message);
                }
                catch (Exception ex)
                {
                    log.Info(ex.Message);
                }
                finally
                {
                    source.Close();
                }
            }

            return true;
        }

        public void deleteContact(string firstName, string lastName)
        {
            bool result = deleteContactDB(firstName, lastName);
            Console.WriteLine(result);
            //Console.WriteLine("Contact Deleted");
        }

        public bool deleteContactDB(string fName, string lName)
        {
            Person temp = SearchDB(fName, lName);

            var log = NLog.LogManager.GetCurrentClassLogger();
            string conStr = "Data Source=sabrina-cuny-sps-rev.database.windows.net;Initial Catalog=PhoneAppDB;Persist Security Info=True;User ID=sabrinaf;Password=Shona2018!";

            if (temp != null)
            {
                string deletePhone = "DELETE FROM Phone WHERE Person_ID = @Person_ID";
                string deleteAddress = "DELETE FROM AddressBook WHERE Person_ID = @Person_ID ";
                string deletePerson = "DELETE FROM Directory WHERE PersonID = @PersonID";

                using (SqlConnection source = new SqlConnection(conStr))
                {
                    source.Open();
                    try
                    {
                        SqlCommand deletePhoneCmd = new SqlCommand(deletePhone, source);
                        SqlCommand deleteAddressCmd = new SqlCommand(deleteAddress, source);
                        SqlCommand deletePersonCmd = new SqlCommand(deletePerson, source);

                        deletePhoneCmd.Parameters.Add(new SqlParameter("Person_ID", temp.phone.Pid));
                        deleteAddressCmd.Parameters.Add(new SqlParameter("Person_ID", temp.address.Pid));
                        deletePersonCmd.Parameters.Add(new SqlParameter("PersonID", temp.Pid));

                        if ((deletePhoneCmd.ExecuteNonQuery() == 0))
                        {
                            return false;
                            //throw new Exception($"Person did not delete: {temp.Pid}"); 
                        }

                        if ((deleteAddressCmd.ExecuteNonQuery() == 0))
                        {
                            return false;
                        }

                        if ((deletePersonCmd.ExecuteNonQuery() == 0))
                        {
                            return false;
                        }

                    }
                    catch (SqlException ex)
                    {
                        log.Info(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        log.Info(ex.Message);
                    }
                    finally
                    {
                        source.Close();
                    }
                }
            }
            return true;
        }

        public Person SearchDB(string firstName, string lastName)
        {
            List<Person> people = LoadIntoCollection();
            for (var i = 0; i < people.Count; i++)
            {
                if (people[i].firstName == firstName && people[i].lastName == lastName)
                {
                    return people[i];
                }
            }
            return null;
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

                if (phoneCmd.ExecuteNonQuery() == 0)
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




    }
}

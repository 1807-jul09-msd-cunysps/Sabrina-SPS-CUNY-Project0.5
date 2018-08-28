using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDAL
{
    public enum State
    {
        AL, AK, AZ, AR, CA, CO, CT, DE, FL, GA, HI, ID, IL, IN, IA, KS, KY, LA, ME, MD, MA, MI, MN, MS, MO, MT, NE, NV, NH, NJ, NM, NY, NC, ND, OH, OK, OR, PA, RI, SC, SD, TN, TX, UT, VT, VA, WA, WV, WI, WY
    }
    public enum Country
    {

        AG = 1268,
        AR = 54,
        AW = 297,
        AU = 61,
        BS = 1242,
        BB = 1246,
        BZ = 501,
        BM = 1441,
        VG = 1284,
        CA = 1,
        CU = 53,
        HT = 509,
        IN = 91,
        JM = 1876,
        US = 1,
        UK = 44,
        PK = 92,
    }


    public class Person
    {

        public Person() {
            
        }
        public Person(string firstName, string lastName, string houseNum, string street, string city, string country, string zip, string number, string state = "", string areaCode = "", Int64 Pid = 0)
        {
            /// Initialise the dependant objects
            /// 
            if (Pid == 0)
            {
                this.Pid = DateTime.Now.Ticks;
            }
            else
            {
                this.Pid = Pid;
            }
            Country code = Country.US;
            foreach (Country var in Enum.GetValues(typeof(Country)))
            {
                if (var.ToString() == country)
                {
                    code = var;
                }
            }

            this.firstName = firstName;
            this.lastName = lastName;
            this.address = new Address(Pid, houseNum, street, city, country, zip, state);
            this.phone = new Phone(Pid, (int)code, number, areaCode);
        }

        public Int64 Pid { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Address address { get; set; }
        public Phone phone { get; set; }



        public void displayPerson()
        {

            Console.WriteLine($"First Name: {firstName}");
            Console.WriteLine($"Last Name: {lastName}");
            address.displayAddress();
            phone.displayPhone();

        }

    }
}

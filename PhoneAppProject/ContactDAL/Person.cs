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
        public Person() { }
        public Person(string fn, string ln, string houseNo, string str, string cy, string ctry, string zip, string number, string st = "", string areaCode = "", Int64 pid = 0)
        {
            /// Initialise the dependant objects
            /// 
            if (pid == 0)
            {
                Pid = DateTime.Now.Ticks;
            }
            else
            {
                Pid = pid;
            }
            Country code = Country.US;
            foreach (Country var in Enum.GetValues(typeof(Country)))
            {
                if (var.ToString() == ctry)
                {
                    code = var;
                }
            }

            firstName = fn;
            lastName = ln;
            address = new Address(Pid, houseNo, str, cy, ctry, zip, st);
            phone = new Phone(Pid, (int)code, number, areaCode);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneAppProject
{

    public enum State
    {
        AL, AK, AZ, AR, CA, CO, CT, DE, FL, GA, HI, ID, IL, IN, IA, KS, KY, LA, ME, MD, MA, MI, MN, MS, MO, MT, NE, NV, NH, NJ, NM, NY, NC, ND, OH, OK, OR, PA, RI, SC, SD, TN, TX, UT, VT, VA, WA, WV, WI, WY
    }
    public enum Country
    {

        AntiguaBarbuda = 1268,
        Argentina = 54,
        Aruba = 297,
        Australia = 61,
        Bahamas = 1242,
        Barbados = 1246,
        Belize = 501,
        Bermuda = 1441,
        BritishVirginIslands = 1284,
        Canada = 1,
        Cuba = 53,
        Curacao = 599,
        Haiti = 509,
        India = 91,
        Jamaica = 1876,
        US = 1,
        UK = 44,
        Pakistan = 92,
    }


    public class Person
    {
        public Person(string fn, string ln, string houseNo, string str, string cy, Country ctry, string zip, string number, string st = "", string areaCode = "")
        {
            /// Initialise the dependant objects
            Pid = DateTime.Now.Ticks;
            firstName = fn;
            lastName = ln;
            address = new Address(Pid, houseNo, str, cy, ctry, st, zip);
            phone = new Phone(Pid, ctry, areaCode, number);
        }

        public long Pid { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Address address { get; set; }
        public Phone phone { get; set; }


    }
}



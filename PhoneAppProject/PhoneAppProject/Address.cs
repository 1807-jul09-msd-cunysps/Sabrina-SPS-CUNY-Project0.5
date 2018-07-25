using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneAppProject
{
    public class Address
    {
        public Address(long personalID, string houseAddr, string cty, string st, Country ctry, string zip, string str = "")
        {
            Pid = personalID;
            houseNum = houseAddr;
            street = str;
            city = cty;
            state = st;
            country = ctry;
            zipcode = zip;
        }
        public long Pid { get; set; }
        public string houseNum { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public Country country { get; set; }
        public string zipcode { get; set; }

        public void displayAddress()
        {
            if(state != "")
            {
                Console.WriteLine($"{houseNum} {street} {city}, {state} {country} {zipcode}");
            }
            else
            {
                Console.WriteLine($"{houseNum} {street} {city}, {country} {zipcode}");
            }
            
        }
    }
}

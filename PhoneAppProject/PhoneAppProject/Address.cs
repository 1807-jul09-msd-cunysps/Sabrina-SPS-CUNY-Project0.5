using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PhoneAppProject
{
    public class Address
    {
        public Address()
        {
        }

        public Address(Int64 personalID, string houseAddr, string str, string cty, string ctry, string zip, string st)
        {
            Pid = personalID;
            houseNum = houseAddr;
            street = str;
            city = cty;
            state = st;
            country = ctry;
            zipcode = zip;
        }
        public Int64 Pid { get; set; }
        public string houseNum { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string zipcode { get; set; }

        public void displayAddress()
        {
            if(state != "")
            {
                Console.WriteLine($"Address: {houseNum} {street} {city}, {state} {country} {zipcode}");
            }
            else
            {
                Console.WriteLine($"Address: {houseNum} {street} {city}, {country} {zipcode}");
            }
            
        }
    }
}

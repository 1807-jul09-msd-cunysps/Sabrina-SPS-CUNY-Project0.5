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
            State = st;
            Country = ctry;
            zipcode = zip;
        }
        public long Pid { get; set; }
        public string houseNum { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string State { get; set; }
        public Country Country { get; set; }
        public string zipcode { get; set; }
    }
}

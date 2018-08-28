﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDAL
{
    public class Address
    {
        public Address()
        {
        }

        public Address(Int64 Pid, string houseNum, string street, string city, string country, string zip, string state)
        {
            this.Pid = Pid;
            this.houseNum = houseNum;
            this.street = street;
            this.city = city;
            this.state = state;
            this.country = country;
            this.zip = zip;
        }
        public Int64 Pid { get; set; }
        public string houseNum { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string zip { get; set; }

        public void displayAddress()
        {
            if (state != "")
            {
                Console.WriteLine($"Address: {houseNum} {street} {city}, {state} {country} {zip}");
            }
            else
            {
                Console.WriteLine($"Address: {houseNum} {street} {city}, {country} {zip}");
            }

        }
    }
}

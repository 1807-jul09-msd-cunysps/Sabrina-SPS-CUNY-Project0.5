using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneAppProject
{

    public class Phone
    {
        public Phone() { }
        public Phone(Int64 personID,string num)
        { 

        }
        public Phone(Int64 personID, int ctCode, string num, string area = "")
        {
            Pid = personID;
            countryCode = ctCode.ToString();
            areaCode = area;
            number = num;
        }

        public Int64 Pid { get; set; }
        public string countryCode { get; set; }
        public string areaCode { get; set; }
        public string number { get; set; }
        //public string ext { get; set; }

        public string getNumber()
        {
            if (areaCode == "")
            {
                string temp = $"{countryCode}-{number}";
                return temp;
            }
            else
            {
                string temp = $"{countryCode}-{areaCode}-{number}";
                return temp;

            }

        }
        
        public void displayPhone()
        {
            if (areaCode == "")
            {
                Console.WriteLine($"{countryCode}-{number}");
            }
            else
            {
                Console.WriteLine($"{countryCode}-{areaCode}-{number}");
            }
        }
    }
}

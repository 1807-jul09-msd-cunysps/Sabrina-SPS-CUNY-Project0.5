using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneAppProject
{

    public class Phone
    {
        public Phone(long personID, Country ctCode, string num, string area = "")
        {
            Pid = personID;
            countryCode = (int)ctCode;
            areaCode = area;
            number = num;
        }

        public long Pid { get; set; }
        public int countryCode { get; set; }
        public string areaCode { get; set; }
        public string number { get; set; }
        //public string ext { get; set; }
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

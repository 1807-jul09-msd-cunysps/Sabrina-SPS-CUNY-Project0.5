using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneAppProject;

namespace Program
{
    class Program
    {

        static void Main(string[] args)
        {

            ContactDirectory myphone = new ContactDirectory();
            myphone.MainMenu();


            Console.Read();
        }
    }
}

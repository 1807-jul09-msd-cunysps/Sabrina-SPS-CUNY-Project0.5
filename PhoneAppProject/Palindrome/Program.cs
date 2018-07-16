using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactLibrary;

namespace Program
{
    class Program
    {

        static void Main(string[] args)
        {
            string test1 = "A nut for a jar of tuna";
            Palindrome check = new Palindrome();
            bool palTest = check.palindromeCheckStr(test1);
            bool palNumTest = check.palindromCheckNum(343);
            Console.WriteLine(palTest);
            Console.WriteLine(palNumTest);
            Console.Read();


        }
    }
}

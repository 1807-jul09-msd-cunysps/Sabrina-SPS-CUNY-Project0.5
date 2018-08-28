using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDAL
{
    public class Message
    {
        //public Message() { }

        public Message(string firstName, string lastName, string email, string message)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.message = message;
        }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string message { get; set; }
    }
    
}

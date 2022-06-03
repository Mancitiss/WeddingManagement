using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Account
    {
        public string id;
        public string username;
        public string pw;
        public short priority;

        public Account() { }
        public Account(string username, string id, short priority)
        {
            this.username = username;
            this.id = id;
            this.priority = priority;
        }
    }
}

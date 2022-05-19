using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Account
    {
        internal string username;
        internal string id;
        internal Int16 priority;

        internal Account() { }
        internal Account(string username, string id, Int16 priority)
        {
            this.username = username;
            this.id = id;
            this.priority = priority;
        }
    }
}

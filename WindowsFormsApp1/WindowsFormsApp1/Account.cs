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
        internal string name;
        internal string id;

        internal Account() { }
        internal Account(string username, string name, string id)
        {
            this.username = username;
            this.name = name;
            this.id = id;
        }
    }
}

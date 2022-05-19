using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingManagementServer
{
    internal class Account
    {
        internal string id;
        internal string username;
        internal string pw;
        internal Int16 priority;

        internal Account(string username, string pw, Int16 priority)
        {
            this.username = username;
            this.pw = pw;
            this.priority = priority;
        }

        internal Account(string id, Int16 priority)
        {
            this.id = id;
            this.priority = priority;
        }

        internal Account(string username, string pw)
        {
            this.username = username;
            this.pw = pw;
        }
        
        internal Account() { }
    }
}

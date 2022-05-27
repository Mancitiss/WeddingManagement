using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingManagementServer
{
    public class Account
    {
        public string id;
        public string username;
        public string pw;
        public short priority;

        public Account(string username, string pw, short priority)
        {
            this.id = "";
            this.username = username;
            this.pw = pw;
            this.priority = priority;
        }

        public Account(string id, short priority)
        {
            this.id = id;
            this.priority = priority;
            this.username = "";
            this.pw = "";
        }

        public Account(string username, string pw)
        {
            this.username = username;
            this.pw = pw;
            this.priority = 0;
            this.id = "";
        }
        
        public Account() { }
    }
}

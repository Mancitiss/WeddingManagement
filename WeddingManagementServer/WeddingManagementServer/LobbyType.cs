using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingManagementServer
{
    internal class LobbyType
    {
        internal string id;
        internal string name;
        internal long minTablePrice;

        internal LobbyType(string id, string name, long minTablePrice)
        {
            this.id = id;
            this.name = name;
            this.minTablePrice = minTablePrice;
        }
        
        internal LobbyType() { }
        
        bool isNull()
        {
            return id == null || name == null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingManagementApplication
{
    internal class LobbyTypeData
    {
        public string idLobbyType;
        public string LobbyName;
        public long MinTablePrice;

        public LobbyTypeData(string idLobbyType, string LobbyName, long MinTablePrice)
        {
            this.idLobbyType = idLobbyType;
            this.LobbyName = LobbyName;
            this.MinTablePrice = MinTablePrice;
        }
        
        public LobbyTypeData() { }
    }
}

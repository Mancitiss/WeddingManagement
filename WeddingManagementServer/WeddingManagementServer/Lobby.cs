using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingManagementServer
{
    public class Lobby
    {
        public string idLobby;
        public string idLobbyType;
        public string LobbyName;
        public int MaxTable;
        public bool Status;

        public Lobby(string idLobby, string idLobbyType, string LobbyName, int MaxTable, bool Status)
        {
            this.idLobby = idLobby;
        }

        public Lobby() { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingManagementServer
{
    internal class Lobby
    {
        internal string idLobby;
        internal string idLobbyType;
        internal string LobbyName;
        internal int MaxTable;
        internal bool Status;

        internal Lobby(string idLobby, string idLobbyType, string LobbyName, int MaxTable, bool Status)
        {
            this.idLobby = idLobby;
        }

        internal Lobby() { }
    }
}

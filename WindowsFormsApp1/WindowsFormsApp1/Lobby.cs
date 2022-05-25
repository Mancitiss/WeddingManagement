namespace WindowsFormsApp1
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

        internal bool Equals(Lobby lobby)
        {
            // check if all fields are equal
            return this.idLobby.Equals(lobby.idLobby) &&
                   this.idLobbyType.Equals(lobby.idLobbyType) &&
                   this.LobbyName.Equals(lobby.LobbyName) &&
                   this.MaxTable.Equals(lobby.MaxTable) &&
                   this.Status.Equals(lobby.Status);
        }
    }
}
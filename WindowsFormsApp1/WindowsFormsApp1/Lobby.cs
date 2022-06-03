namespace WindowsFormsApp1
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

        public bool Equals(Lobby lobby)
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
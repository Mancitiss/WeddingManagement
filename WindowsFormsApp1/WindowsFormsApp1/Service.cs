namespace WindowsFormsApp1
{
    internal class Service
    {
        internal string idService;
        internal string ServiceName;
        internal long ServicePrice;
        internal string Note;

        internal Service(string idService, string ServiceName, long ServicePrice, string Note)
        {
            this.idService = idService;
            this.ServiceName = ServiceName;
            this.ServicePrice = ServicePrice;
            this.Note = Note;
        }

        internal Service()
        {
        }

        internal bool Equals(Service other)
        {
            // check if all fields are equal
            return this.idService.Equals(other.idService) &&
                this.ServiceName.Equals(other.ServiceName) &&
                this.ServicePrice.Equals(other.ServicePrice) &&
                this.Note.Equals(other.Note);
        }
    }
}
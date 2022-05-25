namespace WindowsFormsApp1
{
    internal class ServiceDetail
    {
        internal string idWedding;
        internal string idService;
        internal int AmountOfService;
        internal long TotalServicePrice;
        internal string Note;

        internal ServiceDetail(string idWedding, string idService, int amountOfService, long totalServicePrice, string note)
        {
            this.idWedding = idWedding;
            this.idService = idService;
            this.AmountOfService = amountOfService;
            this.TotalServicePrice = totalServicePrice;
            this.Note = note;
        }

        // default constructor
        internal ServiceDetail()
        {
        }

        internal bool Equals(ServiceDetail serviceDetail)
        {
            // check if all of this properties are equal to the other object
            return this.idWedding.Equals(serviceDetail.idWedding) &&
                   this.idService.Equals(serviceDetail.idService) &&
                   this.AmountOfService.Equals(serviceDetail.AmountOfService) &&
                   this.TotalServicePrice.Equals(serviceDetail.TotalServicePrice) &&
                   this.Note.Equals(serviceDetail.Note);
        }
    }
}
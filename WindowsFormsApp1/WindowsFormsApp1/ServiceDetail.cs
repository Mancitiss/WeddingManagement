namespace WindowsFormsApp1
{
    public class ServiceDetail
    {
        public string idWedding;
        public string idService;
        public int AmountOfService;
        public long TotalServicePrice;
        public string Note;

        public ServiceDetail(string idWedding, string idService, int amountOfService, long totalServicePrice, string note)
        {
            this.idWedding = idWedding;
            this.idService = idService;
            this.AmountOfService = amountOfService;
            this.TotalServicePrice = totalServicePrice;
            this.Note = note;
        }

        // default constructor
        public ServiceDetail()
        {
        }

        public bool Equals(ServiceDetail serviceDetail)
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
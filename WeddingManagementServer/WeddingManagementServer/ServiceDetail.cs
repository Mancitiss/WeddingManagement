using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingManagementServer
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
    }
}

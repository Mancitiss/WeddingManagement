using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingManagementServer
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
    }
}

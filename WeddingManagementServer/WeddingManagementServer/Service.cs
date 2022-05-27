using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingManagementServer
{
    public class Service
    {
        public string idService;
        public string ServiceName;
        public long ServicePrice;
        public string Note;

        public Service(string idService, string ServiceName, long ServicePrice, string Note)
        {
            this.idService = idService;
            this.ServiceName = ServiceName;
            this.ServicePrice = ServicePrice;
            this.Note = Note;
        }

        public Service()
        {
        }
    }
}

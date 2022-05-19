using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingManagementServer
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
    }
}

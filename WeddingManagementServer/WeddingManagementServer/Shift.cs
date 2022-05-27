using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingManagementServer
{
    public class Shift
    {
        public string idShift;
        public DateTime Starting;
        public DateTime Ending;

        public Shift() { }
        public Shift(string idShift, DateTime starting, DateTime ending)
        {
            this.idShift = idShift;
            this.Starting = starting;
            this.Ending = ending;
        }
    }
}

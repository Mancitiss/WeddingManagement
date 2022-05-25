using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Shift
    {
        internal string idShift;
        internal DateTime Starting;
        internal DateTime Ending;

        internal Shift() { }
        internal Shift(string idShift, DateTime starting, DateTime ending)
        {
            this.idShift = idShift;
            this.Starting = starting;
            this.Ending = ending;
        }

        // check if all properties are equals
        internal bool Equals(Shift shift)
        {
            return this.idShift.Equals(shift.idShift) &&
                this.Starting.Equals(shift.Starting) &&
                this.Ending.Equals(shift.Ending);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class WeddingInfo
    {
        internal string idWedding;
        internal string idLobby;
        internal string idShift;
        internal DateTime BookingDate;
        internal DateTime WeddingDate;
        internal string PhoneNumber;
        internal string BroomName;
        internal string BrideName;
        internal int AmountOfTable;
        internal int AmountOfContingencyTable;
        internal long TablePrice;
        internal long Deposit;

        internal WeddingInfo(string idWedding, string idLobby, string idShift, DateTime bookingDate, DateTime weddingDate, string phoneNumber, string broomName, string brideName, int amountOfTable, int amountOfContingencyTable, long tablePrice, long deposit)
        {
            this.idWedding = idWedding;
            this.idLobby = idLobby;
            this.idShift = idShift;
            this.BookingDate = bookingDate;
            this.WeddingDate = weddingDate;
            this.PhoneNumber = phoneNumber;
            this.BroomName = broomName;
            this.BrideName = brideName;
            this.AmountOfTable = amountOfTable;
            this.AmountOfContingencyTable = amountOfContingencyTable;
            this.TablePrice = tablePrice;
            this.Deposit = deposit;
        }

        internal WeddingInfo() { }
    }
}

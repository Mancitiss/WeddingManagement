using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class WeddingInfo
    {
        public string idWedding;
        public string idLobby;
        public string idShift;
        public DateTime BookingDate;
        public DateTime WeddingDate;
        public string PhoneNumber;
        public string BroomName;
        public string BrideName;
        public int AmountOfTable;
        public int AmountOfContingencyTable;
        public long TablePrice;
        public long Deposit;

        public WeddingInfo(string idWedding, string idLobby, string idShift, DateTime bookingDate, DateTime weddingDate, string phoneNumber, string broomName, string brideName, int amountOfTable, int amountOfContingencyTable, long tablePrice, long deposit)
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

        public WeddingInfo() { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingManagementServer
{
    public class Bill
    {
        public string idBill;
        public DateTime InvoiceDate;
        public long TablePriceTotal;
        public long ServicePriceTotal;
        public long Total;
        public DateTime PaymentDate;
        public long MoneyLeft;

        public Bill(string idBill, DateTime InvoiceDate, long TablePriceTotal, long ServicePriceTotal, long Total, DateTime PaymentDate, long MoneyLeft)
        {
            this.idBill = idBill;
            this.InvoiceDate = InvoiceDate;
            this.TablePriceTotal = TablePriceTotal;
            this.ServicePriceTotal = ServicePriceTotal;
            this.Total = Total;
            this.PaymentDate = PaymentDate;
            this.MoneyLeft = MoneyLeft;
        }

        // default constructor
        public Bill() { }
    }
}

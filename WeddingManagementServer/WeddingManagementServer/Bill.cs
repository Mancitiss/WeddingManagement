using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingManagementServer
{
    internal class Bill
    {
        internal string idBill;
        internal DateTime InvoiceDate;
        internal long TablePriceTotal;
        internal long ServicePriceTotal;
        internal long Total;
        internal DateTime PaymentDate;
        internal long MoneyLeft;

        internal Bill(string idBill, DateTime InvoiceDate, long TablePriceTotal, long ServicePriceTotal, long Total, DateTime PaymentDate, long MoneyLeft)
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
        internal Bill() { }
    }
}

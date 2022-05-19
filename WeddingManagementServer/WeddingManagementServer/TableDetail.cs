using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingManagementServer
{
    internal class TableDetail
    {
        internal string idWedding;
        internal string idDishes;
        internal int AmountOfDishes;
        internal long TotalDishesPrice;
        internal string Note;

        internal TableDetail(string idWedding, string idDishes, int amountOfDishes, long totalDishesPrice, string note)
        {
            this.idWedding = idWedding;
            this.idDishes = idDishes;
            this.AmountOfDishes = amountOfDishes;
            this.TotalDishesPrice = totalDishesPrice;
            this.Note = note;

        }

        // default
        internal TableDetail()
        {
        }
        
    }
}

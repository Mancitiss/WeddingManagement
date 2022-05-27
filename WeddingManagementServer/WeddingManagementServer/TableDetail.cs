using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingManagementServer
{
    public class TableDetail
    {
        public string idWedding;
        public string idDishes;
        public int AmountOfDishes;
        public long TotalDishesPrice;
        public string Note;

        public TableDetail(string idWedding, string idDishes, int amountOfDishes, long totalDishesPrice, string note)
        {
            this.idWedding = idWedding;
            this.idDishes = idDishes;
            this.AmountOfDishes = amountOfDishes;
            this.TotalDishesPrice = totalDishesPrice;
            this.Note = note;

        }

        // default
        public TableDetail()
        {
        }
        
    }
}

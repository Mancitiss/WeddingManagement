using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingManagementServer
{
    public class Menu
    {
        public string idDishes;
        public string DishesName;
        public long DishesPrice;
        public string Note;

        public Menu(string idDishes, string DishesName, long DishesPrice, string Note)
        {
            this.idDishes = idDishes;
            this.DishesName = DishesName;
            this.DishesPrice = DishesPrice;
            this.Note = Note;
        }

        public Menu()
        {
        }
    }
}

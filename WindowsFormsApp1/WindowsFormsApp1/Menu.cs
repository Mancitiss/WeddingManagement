using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Menu
    {
        internal string idDishes;
        internal string DishesName;
        internal long DishesPrice;
        internal string Note;

        internal Menu(string idDishes, string DishesName, long DishesPrice, string Note)
        {
            this.idDishes = idDishes;
            this.DishesName = DishesName;
            this.DishesPrice = DishesPrice;
            this.Note = Note;
        }

        internal Menu()
        {
        }

        internal bool Equals(Menu menu)
        {
            return this.idDishes.Equals(menu.idDishes) &&
                   this.DishesName.Equals(menu.DishesName) &&
                   this.DishesPrice.Equals(menu.DishesPrice) &&
                   this.Note.Equals(menu.Note);
        }
    }
}

namespace WindowsFormsApp1
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

        internal bool Equals(TableDetail tableDetail)
        {
            // check if all properties are equal
            return this.idWedding == tableDetail.idWedding &&
                   this.idDishes == tableDetail.idDishes &&
                   this.AmountOfDishes == tableDetail.AmountOfDishes &&
                   this.TotalDishesPrice == tableDetail.TotalDishesPrice &&
                   this.Note == tableDetail.Note;
        }
    }
}
namespace WindowsFormsApp1
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

        public bool Equals(TableDetail tableDetail)
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
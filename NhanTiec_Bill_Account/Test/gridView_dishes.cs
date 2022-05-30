using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Test
{
    public partial class gridView_dishes : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        string str = @"Data Source=DESKTOP-FDBVHMB\SQLSERVEREXPRESS;Initial Catalog=WEDDINGMANAGEMENT;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public gridView_dishes()
        {
            InitializeComponent();
            load_data_dishes();
        }

        void load_data_dishes()
        {
            conn = new SqlConnection(str);
            conn.Open();
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT WD.idWedding, Representative, dishesName, AmountOfDishes,TotalDishesPrice, TBD.Note FROM WEDDING_INFOR WD, MENU MN, TABLE_DETAIL TBD WHERE WD.idWedding = TBD.idWedding AND TBD.idDishes = MN.idDishes";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            dataDishes.DataSource = table;
        }
    }
}

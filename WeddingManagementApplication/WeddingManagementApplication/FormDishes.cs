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

namespace WeddingManagementApplication
{
    public partial class FormDishes : Form
    {
        public static string currentTypeId = "";
        DataTable table = new DataTable();
        DataColumn column;
        DataRow row;

        public FormDishes()
        {
            InitializeComponent();
        }
        void load_data_Dishes()
        {
            table = new DataTable();
            // first column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "DishesName";
            column.AutoIncrement = false;
            column.Caption = "Dishes name";
            column.ReadOnly = true;
            column.Unique = false;
            table.Columns.Add(column);

            // second column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "DishesPrice";
            column.AutoIncrement = false;
            column.Caption = "Dishes price";
            column.ReadOnly = true;
            column.Unique = false;
            table.Columns.Add(column);

            // third column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Note";
            column.AutoIncrement = false;
            column.Caption = "Note";
            column.ReadOnly = true;
            column.Unique = false;
            table.Columns.Add(column);

            // forth column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "IdDishes";
            column.AutoIncrement = false;
            column.Caption = "IdDishes";
            column.ReadOnly = true;
            column.Unique = true;
            column.ColumnMapping = MappingType.Hidden;
            table.Columns.Add(column);

            DataColumn[] keys = new DataColumn[1];
            keys[0] = table.Columns["IdDishes"];
            table.PrimaryKey = keys;

            data_gv_dishes.DataSource = table;
            data_gv_dishes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // prevent user from adding new row
            data_gv_dishes.AllowUserToAddRows = false;
            foreach (DataGridViewColumn col in data_gv_dishes.Columns)
            {
                col.HeaderText = table.Columns[col.DataPropertyName].Caption;
            }


            List<DishesData> dishes = new List<DishesData>();
            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM MENU WHERE Available > 0", sql))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dishes.Add(new DishesData(reader["IdDishes"].ToString(), reader["DishesName"].ToString(), Convert.ToInt64(reader["DishesPrice"]), reader["Note"].ToString()));
                        }
                    }
                }
            }
            WeddingClient.listDishes = dishes;
            // add rows to table
            foreach (DishesData dishesData in dishes)
            {
                row = table.NewRow();
                row["IdDishes"] = dishesData.idDishes;
                row["DishesName"] = dishesData.DishesName;
                row["DishesPrice"] = dishesData.DishesPrice;
                row["Note"] = dishesData.Note;
                table.Rows.Add(row);
            }
        }

        private void form_dishes_load(object sender, EventArgs e)
        {
            load_data_Dishes();
        }

        private void data_gv_dishes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= table.Rows.Count)
            {
                currentTypeId = "";
                return;
            }
            // get the row of the cell clicked from dataGridView1
            var rowItem = (DataRowView)data_gv_dishes.Rows[e.RowIndex].DataBoundItem;
            // find the row of the cell clicked in table
            int i = table.Rows.IndexOf(rowItem.Row);
            DataRow row = table.Rows[i];
            tb_dishes_name.Text = row[0].ToString();
            tb_dishes_price.Text = row[1].ToString();
            tb_dishes_note.Text = row[2].ToString();
            //textBox2.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            if (i < WeddingClient.listDishes.Count)
            {
                currentTypeId = WeddingClient.listDishes[i].idDishes;
            }
            else
            {
                currentTypeId = "";
            }
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            // check if current type ID is not empty
            if (currentTypeId == "")
            {
                MessageBox.Show("Please select a type!");
            }
            else
            {
                using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE LOBBY_TYPE SET Available = 0 WHERE IdLobbyType = @IdLobbyType", sql))
                    {
                        cmd.Parameters.AddWithValue("@IdDishes", currentTypeId);
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            // remove from list
                            foreach (LobbyTypeData lobbyType in WeddingClient.listLobbyTypes)
                            {
                                if (lobbyType.idLobbyType == currentTypeId)
                                {
                                    WeddingClient.listLobbyTypes.Remove(lobbyType);
                                    break;
                                }
                            }
                            // remove from table
                            table.Rows.Remove(table.Rows.Find(currentTypeId));
                            MessageBox.Show("Type deleted!");
                        }
                    }
                }
            }
            FormLobbyType.currentTypeId = "";
        }

     

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_add_dishes_Click_1(object sender, EventArgs e)
        {
            if (tb_dishes_name.Text == "" || tb_dishes_price.Text == "")
            {
                MessageBox.Show("Please fill all the fields!");
            }

            else
            {
                using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO MENU (IdDishes, DishesName, DishesPrice,Note, Available) VALUES (@IdDishes, @DishesName, @DishesPrice,@Note,1)", sql))
                    {
                        string newDishesId = "MN" + WeddingClient.GetNewIdFromTable("MN").ToString().PadLeft(19, '0');
                        cmd.Parameters.AddWithValue("@IdDishes", newDishesId);
                        cmd.Parameters.AddWithValue("@DishesName", tb_dishes_name.Text);
                        cmd.Parameters.AddWithValue("@DishesPrice", tb_dishes_price.Text);
                        cmd.Parameters.AddWithValue("@Note", tb_dishes_note.Text);

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            // add to table
                            row = table.NewRow();
                            row["DishesName"] = tb_dishes_name.Text;
                            row["DishesPrice"] = tb_dishes_price.Text;
                            row["Note"] = tb_dishes_note.Text;
                            row["IdDishes"] = newDishesId;
                            table.Rows.Add(row);
                            MessageBox.Show("New dishes added!");
                            // add to list
                            WeddingClient.listDishes.Add(new DishesData(newDishesId, tb_dishes_name.Text, Convert.ToInt64(tb_dishes_price.Text), tb_dishes_note.Text));
                        }
                    }
                }
            }
        }

        private void btn_update_dishes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("abc");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WeddingManagementApplication
{
    public partial class FormLobbyType : Form
    {
        public static string currentTypeId = "";
        DataTable table = new DataTable();
        DataColumn column;
        DataRow row;

        void load_data_LobbyType()
        {
            table = new DataTable();
            // first column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "lobbyTypeName";
            column.AutoIncrement = false;
            column.Caption = "Type";
            column.ReadOnly = true;
            column.Unique = false;
            table.Columns.Add(column);

            // second column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int64");
            column.ColumnName = "MinTablePrice";
            column.AutoIncrement = false;
            column.Caption = "Minimum Table Price";
            column.ReadOnly = true;
            column.Unique = false;
            table.Columns.Add(column);
            
            dataGridView1.DataSource = table;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            List<LobbyTypeData> lobbyTypes = new List<LobbyTypeData>();
            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString)) { 
                sql.Open();
                using(SqlCommand cmd = new SqlCommand("SELECT * FROM LOBBY_TYPE WHERE Available > 0", sql))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lobbyTypes.Add(new LobbyTypeData(reader["IdLobbyType"].ToString(), reader["LobbyName"].ToString(), Convert.ToInt32(reader["MinTablePrice"])));
                        }
                    }
                }
            }
            WeddingClient.listLobbyTypes = lobbyTypes;
            // add rows to table
            foreach (LobbyTypeData lobbyType in lobbyTypes)
            {
                row = table.NewRow();
                row["lobbyTypeName"] = lobbyType.LobbyName;
                row["MinTablePrice"] = lobbyType.MinTablePrice;
                table.Rows.Add(row);
            }
        }
        public FormLobbyType()
        {
            InitializeComponent();
        }

        private void FormLobbyType_Load(object sender, EventArgs e)
        {
            load_data_LobbyType();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            comboBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            //textBox2.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            if (i < WeddingClient.listLobbyTypes.Count)
            {
                currentTypeId = WeddingClient.listLobbyTypes[i].idLobbyType;
            }
            else
            {
                currentTypeId = "";
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || !long.TryParse(textBox1.Text, out long price))
            {
                MessageBox.Show("Please fill all the fields!");
            }
            else
            {
                using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO LOBBY_TYPE (IdLobbyType, LobbyName, MinTablePrice, Available) VALUES (@IdLobbyType, @LobbyName, @MinTablePrice, 1)", sql))
                    {
                        string newTypeId = "LT" + WeddingClient.GetNewIdFromTable("LT").ToString().PadLeft(19, '0');
                        cmd.Parameters.AddWithValue("@IdLobbyType", newTypeId);
                        cmd.Parameters.AddWithValue("@LobbyName", comboBox1.Text);
                        cmd.Parameters.AddWithValue("@MinTablePrice", price);
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            // add to table
                            row = table.NewRow();
                            row["lobbyTypeName"] = comboBox1.Text;
                            row["MinTablePrice"] = price;
                            table.Rows.Add(row);
                            MessageBox.Show("New type added!");
                            // add to list
                            WeddingClient.listLobbyTypes.Add(new LobbyTypeData(newTypeId, comboBox1.Text, price));
                        }
                    }
                }
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
                        cmd.Parameters.AddWithValue("@IdLobbyType", currentTypeId);
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            // remove from list
                            int index = -1;
                            foreach (LobbyTypeData lobbyType in WeddingClient.listLobbyTypes)
                            {
                                if (lobbyType.idLobbyType == currentTypeId)
                                {
                                    // get current index
                                    index = WeddingClient.listLobbyTypes.IndexOf(lobbyType);
                                    WeddingClient.listLobbyTypes.Remove(lobbyType);
                                    break;
                                }
                            }
                            // remove from table
                            if (index < table.Rows.Count && index > 0)
                            {
                                table.Rows.RemoveAt(index);
                            }
                            MessageBox.Show("Type deleted!");
                        }
                    }
                }
            }
            FormLobbyType.currentTypeId = "";
        }
    }
}

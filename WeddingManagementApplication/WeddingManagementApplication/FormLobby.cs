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
    public partial class FormLobby : Form
    {
        DataTable table = new DataTable();
        DataColumn column;
        DataRow row;

        void Load_data_Lobby()
        {
            // create table
            table = new DataTable();
            // first column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "LobbyName";
            column.AutoIncrement = false;
            column.Caption = "Lobby Name";
            column.ReadOnly = true;
            column.Unique = false;
            table.Columns.Add(column);

            // second column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "LobbyType";
            column.AutoIncrement = false;
            column.Caption = "Lobby Type";
            column.ReadOnly = true;
            column.Unique = false;
            table.Columns.Add(column);

            // third column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "MaxTable";
            column.AutoIncrement = false;
            column.Caption = "Max Table";
            column.ReadOnly = true;
            column.Unique = false;
            table.Columns.Add(column);

            // fourth column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Note";
            column.AutoIncrement = false;
            column.Caption = "Note";
            column.ReadOnly = true;
            column.Unique = false;
            table.Columns.Add(column);
            
            dataGridView1.DataSource = table;
            // make dataGridView1 autosize
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // check if weddingclient.listlobbytype is empty
            if (WeddingClient.listLobbyTypes.Count == 0)
            {
                // load data from database
                using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM LOBBY_TYPE WHERE Available > 0", sql))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine(reader["IdLobbyType"].ToString());
                                WeddingClient.listLobbyTypes.Add(new LobbyTypeData(reader["IdLobbyType"].ToString(), reader["LobbyName"].ToString(), Convert.ToInt32(reader["MinTablePrice"])));
                            }
                        }
                    }
                }
            }

            // set combobox data source to listlobbytype
            lobbyTypeCombobox.DataSource = WeddingClient.listLobbyTypes;
            // display lobby name
            lobbyTypeCombobox.DisplayMember = "LobbyName";
            
            // load data from database
            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT LB.IdLobby, LT.LobbyName LobbyType, LB.LobbyName, LB.MaxTable, LB.Note FROM LOBBY LB, LOBBY_TYPE LT WHERE LB.IdLobbyType = LT.IdLobbyType AND LB.Available > 0", sql))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["IdLobby"].ToString());
                            WeddingClient.listLobbies.Add(new LobbyData(reader["IdLobby"].ToString(), reader["LobbyType"].ToString(), reader["LobbyName"].ToString(), Convert.ToInt32(reader["MaxTable"]), reader["Note"].ToString()));
                            // add row to table
                            row = table.NewRow();
                            row["LobbyName"] = reader["LobbyName"].ToString();
                            row["LobbyType"] = reader["LobbyType"].ToString();
                            row["MaxTable"] = Convert.ToInt32(reader["MaxTable"]);
                            row["Note"] = reader["Note"].ToString();
                            table.Rows.Add(row);
                        }
                    }
                }
            }
        }  


        public FormLobby()
        {
            InitializeComponent();
        }
        private Label label2;
        private LinkLabel linkLabel1;
        private GroupBox groupBox1;
        private TextBox maxTableTextBox;
        private ComboBox lobbyTypeCombobox;
        private Button btn_delete;
        private Button btn_add;
        private Panel panel3;
        private Panel panel1;
        private Label label9;
        private TableLayoutPanel tableLayoutPanel1;
        private Label header_lobby;
        

        private void FormLobby_Load(object sender, EventArgs e)
        {
            Load_data_Lobby();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            lobbyTypeCombobox.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            maxTableTextBox.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            nameTextBox.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            noteTextBox.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

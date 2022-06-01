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
using System.Data;

namespace WeddingManagementApplication
{

  


    public partial class FormLobbyType : Form
    {

        SqlCommand cmd;
        SqlConnection connection;
        string str = WeddingManagementApplication.WeddingClient.sqlConnectionString;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void load_data_LobbyType()
        {
            cmd = connection.CreateCommand();

            cmd.CommandText = "SELECT LT.LobbyName, MinTablePrice, available FROM LOBBY_TYPE LT";

            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        public FormLobbyType()
        {
            InitializeComponent();
        }

        private void FormLobbyType_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            load_data_LobbyType();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            comboBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
        }

    }
}

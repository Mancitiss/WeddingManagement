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
    public partial class FormLobby : Form
    {

        SqlCommand cmd;
        SqlConnection connection;
        string str = @"Data Source=DESKTOP-IEL0IE1;Initial Catalog=WEDDINGMANAGEMENT;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void load_data_Lobby()
        {
            cmd = connection.CreateCommand();

            cmd.CommandText = "SELECT LB.LobbyName, MaxTable, available, Note FROM LOBBY LB";

            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }  


        public FormLobby()
        {
            InitializeComponent();
        }
        private Label label2;
        private LinkLabel linkLabel1;
        private GroupBox groupBox1;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Button btn_delete;
        private Button btn_add;
        private Panel panel3;
        private Panel panel1;
        private Label label9;
        private TableLayoutPanel tableLayoutPanel1;
        private Label header_lobby;


        private void FormLobby_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            load_data_Lobby();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            comboBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
        }
    }
}

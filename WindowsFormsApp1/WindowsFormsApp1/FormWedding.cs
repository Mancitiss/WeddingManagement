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

namespace WindowsFormsApp1
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

            cmd.CommandText = "SELECT LT.LobbyName, LB.LobbyName, MaxTable, MinTablePrice, Note FROM LOBBY LB, LOBBY_TYPE LT  WHERE LB.idLobbyType = LT.idLobbyType ";

            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            dataGridViewLobby.DataSource = table;
        }
        public FormLobby()
        {
            InitializeComponent();
        }
        private Label label_idLobby;
        private Label label2;
        private LinkLabel linkLabel1;
        private GroupBox groupBox1;
        private Label label_MinPrice;
        private Label label_MaxTable;
        private Label label_NameLobby;
        private ComboBox comboBox_IDLobbyType;
        private Label label_IDLobbyType;
        private Button button2;
        private Button button1;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private Label label9;
        private DataGridView dataGridViewLobby;
        private TableLayoutPanel tableLayoutPanel1;
        private Label header_lobby;


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridViewLobby.CurrentRow.Index;
            textBox2.Text = dataGridViewLobby.Rows[i].Cells[0].Value.ToString();
            comboBox1.Text = dataGridViewLobby.Rows[i].Cells[1].Value.ToString();
            textBox3.Text = dataGridViewLobby.Rows[i].Cells[2].Value.ToString();
            textBox4.Text = dataGridViewLobby.Rows[i].Cells[3].Value.ToString();
            textBox5.Text = dataGridViewLobby.Rows[i].Cells[4].Value.ToString();
        }
        private void FormLobby_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }
    }
}

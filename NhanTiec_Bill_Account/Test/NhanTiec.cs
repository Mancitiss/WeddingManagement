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
    public partial class NhanTiec : Form
    {

        SqlConnection conn;
        SqlCommand cmd;
        string str = @"Data Source=DESKTOP-FDBVHMB\SQLSERVEREXPRESS;Initial Catalog=WEDDINGMANAGEMENT;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table1 = new DataTable();
        
        public NhanTiec()
        {
            InitializeComponent();
            load_gridView_wedding();
            load_comboBox_shift();
            load_comboBox_lobby();
            load_comboBox_menu();
            load_comboBox_service();
        }

        void load_data_wedding()
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT LobbyName, ShiftName, Representative, PhoneNumber, BookingDate, WeddingDate, BroomName, BrideName, AmountOfTable, " +
                "AmountOfContingencyTable, TablePrice, Deposit FROM LOBBY LB, SHIFT S, WEDDING_INFOR WD WHERE WD.idShift = S.idShift AND WD.idLobby = LB.idLobby ";
            adapter.SelectCommand = cmd;
            table1.Clear();
            adapter.Fill(table1);
            dataWedding.DataSource = table1;
        }

        // đổ dữ liệu từ db lên gridView
        void load_gridView_wedding()
        {
            conn = new SqlConnection(str);
            conn.Open();
            load_data_wedding();
        }

        // đổ dữ liệu từ db lên comboBox shift
        void load_comboBox_shift()
        {
            conn = new SqlConnection(str);
            conn.Open();
            var cmd = new SqlCommand("SELECT ShiftName FROM SHIFT", conn);
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            cbb_shift.DisplayMember = "ShiftName";
            cbb_shift.DataSource = dt;
        }

        // đổ dữ liệu từ db lên comboBox lobby
        void load_comboBox_lobby()
        {
            conn = new SqlConnection(str);
            conn.Open();
            var cmd = new SqlCommand("SELECT LobbyName FROM LOBBY", conn);
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            cbb_lobby.DisplayMember = "LobbyName";
            cbb_lobby.DataSource = dt;
        }

        // đổ dữ liệu từ db lên comboBox menu
        void load_comboBox_menu()
        {
            conn = new SqlConnection(str);
            conn.Open();
            var cmd = new SqlCommand("SELECT DishesName FROM MENU", conn);
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            cbb_dishes.DisplayMember = "DishesName";
            cbb_dishes.DataSource = dt;
        }


        // đổ dữ liệu từ db lên comboBox service
        void load_comboBox_service()
        {
            conn = new SqlConnection(str);
            conn.Open();
            var cmd = new SqlCommand("SELECT ServiceName FROM SERVICE", conn);
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            cbb_service.DisplayMember = "ServiceName";
            cbb_service.DataSource = dt;
        }

                   
           
  
           

        // cái hàm này để khi ấn vô cái dòng dữ liệu thì mấy ô mình nhập hiện lên các dữ liệu của dòng đó
        //private void dataWedding_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    //int i;
        //    //i = dataWedding.CurrentRow.Index;
        //    //tb_representative.Text = dataWedding.Rows[i].Cells[0].Value.ToString();
        //    //tb_phone.Text = dataWedding.Rows[i].Cells[1].Value.ToString();
        //    //date_booking.Text = dataWedding.Rows[i].Cells[2].Value.ToString();
        //    //date_wedding.Text = dataWedding.Rows[i].Cells[3].Value.ToString();
        //    //tb_groom.Text = dataWedding.Rows[i].Cells[4].Value.ToString();
        //    //tb_bride.Text = dataWedding.Rows[i].Cells[5].Value.ToString();
        //    //tb_table.Text = dataWedding.Rows[i].Cells[6].Value.ToString();
        //    //tb_contigency.Text = dataWedding.Rows[i].Cells[7].Value.ToString();
        //    //tb_deposit.Text = dataWedding.Rows[i].Cells[8].Value.ToString();
        //}


        // set sự kiện button xem chi tiết thông tin menu
        private void btn_detail_dishes_Click(object sender, EventArgs e)
        {
            gridView_dishes show = new gridView_dishes();
            show.ShowDialog();

        }

        // sự kiện cho button detail service
        private void btn_detail_service_Click(object sender, EventArgs e)
        {
            gridView_service show = new gridView_service();
            show.ShowDialog();
        }


        // sự kiện cho btn add wedding
        private void btn_add_wedding_Click(object sender, EventArgs e)
        {
            //string idShift;
            //if (cbb_shift.Text == "Trưa")
            //    idShift = "SH0000000000000000001";
            //else if (cbb_shift.Text == "Tối")
            //    idShift = "SH0000000000000000002";
            cmd = conn.CreateCommand();
            // lỗi từ dòng này :vv cái idLobby nhiều quá ko thể làm như Shift dc nên là đứng hình :))
            //cmd.CommandText = "INSERT INTO WEDDING_INFOR VALUES ('WD01', idLobby , '" + cbb_shift + "', '" + date_booking.Text + "', '" + date_wedding.Text + "'," +
            //    "'" + tb_phone.Text + "', '" + tb_groom.Text + "', '" + tb_bride.Text + "', '" + tb_table.Text + "', '" + tb_contigency.Text + "', null, '" + tb_deposit.Text+ "', 1, '" + tb_representative.Text + "')";
            cmd.ExecuteNonQuery();
            load_data_wedding();
            MessageBox.Show("Created new wedding", "CREATE", MessageBoxButtons.OK);
        }

        // set sự kiện cho btn delete wedding
        private void btn_delete_wedding_Click(object sender, EventArgs e)
        {

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

        }

        private void btn_update_Click(object sender, EventArgs e)
        {

        }
    }
}

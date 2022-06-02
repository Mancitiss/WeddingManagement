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
using System.Configuration;

namespace WeddingManagementApplication
{
    public partial class searchWedding : Form
    {
        DataTable table = new DataTable();
        DataTable table1 = new DataTable();

        public searchWedding()
        {
            InitializeComponent();
            load_gridView_wedding();
            load_gridView_bill();
        }
     
        void load_gridView_wedding()
        {
            using (SqlConnection conn = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT IdWedding, WD.IdLobby, WD.IdShift, LobbyName, ShiftName, Representative, PhoneNumber, BookingDate, WeddingDate, GroomName, BrideName, AmountOfTable, " +
                        "AmountOfContingencyTable, TablePrice, Deposit FROM LOBBY LB, SHIFT S, WEDDING_INFOR WD WHERE WD.IdShift = S.IdShift AND WD.IdLobby = LB.IdLobby ";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        table = new DataTable();
                        adapter.Fill(table);
                        dataWedding.DataSource = table;
                    }
                }
            }
        }
        void load_gridView_bill()
        {
            using (SqlConnection conn = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT IdWedding, W.IdShift, IdBill, W.IdLobby, Representative, GroomName, BrideName, PhoneNumber, LobbyName, ShiftName, InvoiceDate, TablePriceTotal, ServicePriceTotal, Total, PaymentDate, MoneyLeft from WEDDING_INFOR W, BILL B, LOBBY LB, SHIFT S WHERE B.IdBill = W.IdWedding AND W.IdLobby = LB.IdLobby AND W.IdShift = S.IdShift";
                    // cmd.CommandText = "SELECT * FROM BILL";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        table1 = new DataTable();
                        adapter.Fill(table1);
                        dataBill.DataSource = table1;
                    }
                }
            }
        }



        private void tb_search_wd_textChange(object sender, EventArgs e)
        {
            if (tb_search_wd.Text == "")
            {
                load_gridView_wedding();
                return;
            }
            if (rBtn_name.Checked)
            {
                Console.WriteLine(tb_search_wd.Text);
                using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
                {
                    string sqlquery = "select Representative, GroomName, BrideName, InvoiceDate, TablePriceTotal, ServicePriceTotal, Total, PaymentDate, MoneyLeft " +
                        "from WEDDING_INFOR W, BILL B where B.IdBill = W.IdWedding and GroomName like @searchWD OR BrideName like @searchWD OR Representative like @searchWD";
                    sql.Open();
                    using (SqlCommand sqlcomm = sql.CreateCommand())
                    {
                        sqlcomm.CommandText = sqlquery;
                        sqlcomm.Parameters.AddWithValue("@searchWD", "%"+tb_search_wd.Text+"%");
                        Console.WriteLine(sqlcomm.ToString());
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcomm))
                        {
                            table = new DataTable();
                            sqlDataAdapter.Fill(table);
                            dataWedding.DataSource = table;
                        }
                    }
                }
            }
            else if (rBtn_date.Checked)
            {
                using (SqlConnection sqlconn = new SqlConnection(WeddingClient.sqlConnectionString))
                {
                    string sqlquery = "select Representative, GroomName, BrideName, InvoiceDate, TablePriceTotal, ServicePriceTotal, Total, PaymentDate, MoneyLeft" +
                        " from WEDDING_INFOR W, BILL B where B.IdBill = W.IdWedding and WeddingDate like @searchWD";
                    sqlconn.Open();
                    using (SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn))
                    {
                        sqlcomm.Parameters.AddWithValue("@searchWD", "%" + tb_search_wd.Text + "%");
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcomm))
                        {
                            table = new DataTable();
                            sqlDataAdapter.Fill(table);
                            dataWedding.DataSource = table;
                        }
                    }
                }
            }
           
        }

        private void tb_search_bill_textChange(object sender, EventArgs e)
        {
            // if text is ""
            if (tb_search_bill.Text == "")
            {
                load_gridView_bill();
                return;
            }
            if (rBtn_name.Checked)
            {
                using (SqlConnection sqlconn = new SqlConnection(WeddingClient.sqlConnectionString))
                {
                    string sqlquery = "select * from WEDDING_INFOR where GroomName like @searchB OR BrideName like @searchB OR Representative like @searchB";
                    sqlconn.Open();
                    using (SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn))
                    {
                        sqlcomm.Parameters.AddWithValue("@searchB", "%" + tb_search_bill.Text + "%");
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcomm))
                        {
                            table1 = new DataTable();
                            sqlDataAdapter.Fill(table1);
                            dataBill.DataSource = table1;
                        }
                    }
                }
            }
            else if (rBtn_date.Checked)
            {
                using (
                SqlConnection sqlconn = new SqlConnection(WeddingClient.sqlConnectionString))
                {
                    string sqlquery = "select * from WEDDING_INFOR where WeddingDate like @searchB";
                    sqlconn.Open();
                    using (SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn))
                    {
                        sqlcomm.Parameters.AddWithValue("@searchB", "%" + tb_search_bill.Text + "%");
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcomm))
                        {
                            table1 = new DataTable();
                            sqlDataAdapter.Fill(table1);
                            dataBill.DataSource = table1;
                        }
                    }
                }
            }
        }

        private void searchWedding_SizeChangedEvent(object sender, EventArgs e)
        {
            // get size of form
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // check if formWidth is divisible by 2
            if (formWidth % 2 == 0)
            {
                // if true, then set formWidth to formWidth - 1
                formWidth -= 1;
                this.ClientSize = new Size(formWidth, formHeight);
                return;
            }
            else
            {
                // set new size of each dataGridView 
                dataWedding.Size = new Size((formWidth - 18 - 39) / 2, dataWedding.Size.Height);
                dataBill.Size = new Size((formWidth - 18 - 39) / 2, dataBill.Size.Height);
                dataBill.Location = new Point(dataWedding.Location.X + dataWedding.Size.Width + 39, dataBill.Location.Y);
            }
        }

        private void searchWedding_ResizeBegin(object sender, EventArgs e)
        {
        }
        
        private void searchWedding_ResizeEnd(object sender, EventArgs e)
        {
        }
    }
}

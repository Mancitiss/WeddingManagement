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
    public partial class gridView_service : Form
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        public gridView_service()
        {
            InitializeComponent();
            load_data_service();
        }
        void load_data_service()
        {
            using(SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString)){
                sql.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT WD.idWedding, Representative, ServiceName, AmountOfService,TotalServicePrice, SVD.Note FROM WEDDING_INFOR WD, SERVICE SV, SERVICE_DETAIL SVD WHERE WD.idWedding = SVD.idWedding AND SVD.idService = SV.idService", sql))
                {
                    adapter.SelectCommand = cmd;
                    table.Clear();
                    adapter.Fill(table);
                    dataService.DataSource = table;
                }
            }
        }
    }
}

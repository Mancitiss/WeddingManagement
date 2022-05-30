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
    public partial class gridView_service : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        string str = @"Data Source=DESKTOP-FDBVHMB\SQLSERVEREXPRESS;Initial Catalog=WEDDINGMANAGEMENT;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();


        public gridView_service()
        {
            InitializeComponent();
            load_data_service();
        }
        void load_data_service()
        {
            conn = new SqlConnection(str);
            conn.Open();
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT WD.idWedding, Representative, ServiceName, AmountOfService,TotalServicePrice, SVD.Note FROM WEDDING_INFOR WD, SERVICE SV, SERVICE_DETAIL SVD WHERE WD.idWedding = SVD.idWedding AND SVD.idService = SV.idService";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            dataService.DataSource = table;
        }
    }
}

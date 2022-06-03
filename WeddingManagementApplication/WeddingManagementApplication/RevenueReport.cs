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
    public partial class RevenueReport : Form
    {
        public static string currentReportId = "";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table1 = new DataTable();
        public RevenueReport()
        {
            InitializeComponent();
            LoadReportData();
        }
        private void LoadReportData()
        {
            //load_data_wedding();
            DataColumn column;
            DataRow row;
            // Create first column and add to the DataTable.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Month";
            column.AutoIncrement = false;
            column.Caption = "Month";
            column.ReadOnly = true;
            column.Unique = false;
            // Add the column to the DataColumnCollection.
            table1.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Year";
            column.AutoIncrement = false;
            column.Caption = "Year";
            column.ReadOnly = false;
            column.Unique = false;
            table1.Columns.Add(column);

            // create third column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Total";
            column.AutoIncrement = false;
            column.Caption = "Total";
            column.ReadOnly = false;
            column.Unique = false;
            table1.Columns.Add(column);
            // create thirteenth column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "idReport";
            column.AutoIncrement = false;
            column.Caption = "idReport";
            column.ReadOnly = false;
            column.Unique = false;
            column.ColumnMapping = MappingType.Hidden;
            table1.Columns.Add(column);
            dataGridViewRReport.DataSource = table1;
            foreach (DataGridViewColumn col in dataGridViewRReport.Columns)
            {
                col.HeaderText = table1.Columns[col.DataPropertyName].Caption;
            }
            dataGridViewRReport.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(dataWedding_RowHeaderMouseClick);
            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand check = new SqlCommand("SELECT * FROM REVENUE_REPORT", sql))
                {
                    using (SqlDataReader reader = check.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DataRow rw = table1.NewRow();
                            rw.ItemArray = new object[] { reader["Month"], reader["Year"], reader["RevenueTotal"], reader["IdReport"] };
                            table1.Rows.Add(rw);
                        }
                    }
                }
            }
        }
        private void dataWedding_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // select weddingID
            currentReportId = table1.Rows[e.RowIndex]["idReport"].ToString();
            Console.WriteLine(NhanTiec.currentWeddingId);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int index = comboBoxMonth.SelectedIndex;
            if(index <0 || textBox1.Text=="")
            {
                MessageBox.Show("Please fill full infor ");
            }
            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand cmd2 = new SqlCommand("SELECT  * FROM REVENUE_REPORT WHERE (Month=@month and Year=@year) ", sql))
                {
                    cmd2.Parameters.AddWithValue("@month", int.Parse(comboBoxMonth.SelectedItem.ToString()));
                    cmd2.Parameters.AddWithValue("@year", int.Parse(textBox1.Text));
                    SqlDataReader dr = cmd2.ExecuteReader();
                    int total = 0;
                    MessageBox.Show(dr.HasRows.ToString());
                    if(dr.HasRows)
                    {
                        String ID = "";
                        while(dr.Read())
                        {
                             ID = dr["IdReport"].ToString();
                            MessageBox.Show(ID);
                        }
                        dr.Close();
                        using (SqlCommand cmd3 = new SqlCommand("select * from REVENUE_REPORT_DT WHERE IdReport =@id", sql))
                        {
                            cmd3.Parameters.AddWithValue("@id", ID);
                            using
                           (SqlDataReader reader = cmd3.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    total += int.Parse(reader["DayRevenue"].ToString());
                                }
                            }    
                            
                        }    
                        using (SqlCommand cmd3 = new SqlCommand("UPDATE REVENUE_REPORT SET RevenueTotal = @total WHERE IdReport =@id", sql))
                        {
                            cmd3.Parameters.AddWithValue("@id", ID);
                            cmd3.Parameters.AddWithValue("@total", total);
                            if (cmd3.ExecuteNonQuery()>0)
                            {
                                DataRow row = table1.NewRow();
                                row.ItemArray = new object[] { int.Parse(comboBoxMonth.SelectedItem.ToString()), int.Parse(textBox1.Text), total, ID };
                                table1.Rows.Add(row);
                                MessageBox.Show("Report Add Successfully");
                            }    
                        }
                    } 
                    else
                    {
                            // complete command for me
                            string newId = "RR" + WeddingClient.GetNewIdFromTable("RR").ToString();
                            using (SqlCommand cmd3 = new SqlCommand("INSERT INTO REVENUE_REPORT (IdReport, Month, year, RevenueTotal) VALUES (@id, @month, @year, @total) ", sql))
                            {
                                cmd3.Parameters.AddWithValue("@id", newId);
                                cmd3.Parameters.AddWithValue("@month", int.Parse(comboBoxMonth.SelectedItem.ToString()));
                                cmd3.Parameters.AddWithValue("@year", int.Parse(textBox1.Text));
                                cmd3.Parameters.AddWithValue("@total", int.Parse(textBoxRTotal.Text));
                                if (cmd3.ExecuteNonQuery() > 0)
                                {
                                    DataRow row = table1.NewRow();
                                    row.ItemArray = new object[] { int.Parse(comboBoxMonth.SelectedItem.ToString()), int.Parse(textBox1.Text), int.Parse(textBoxRTotal.Text), newId };
                                    table1.Rows.Add(row);
                                    MessageBox.Show("Report Add Successfully");
                                }
                                else
                                {
                                    MessageBox.Show("Wedding Add Failed");
                                }
                            }

                        
                    }    
                }
            }    

            
        }

        private void RevenueReport_Load(object sender, EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (currentReportId != null && currentReportId.Length == 21)
            {
                using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
                {
                    sql.Open();
                    // complete command for me
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM REVENUE_REPORT_DT  WHERE IdReport = @id", sql))
                    {
                        cmd.Parameters.AddWithValue("@id", currentReportId);
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            //Load_data_wedding();
                            // delete row in table1
                            //dataWedding.Rows.RemoveAt(dataWedding.CurrentRow.Index);
                            table1.Rows.RemoveAt(dataGridViewRReport.CurrentRow.Index);
                            MessageBox.Show("Report deleted", "SUCCESS", MessageBoxButtons.OK);
                            NhanTiec.currentWeddingId = "";
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM REVENUE_REPORT WHERE IdReport = @id", sql))
                    {
                        cmd.Parameters.AddWithValue("@id", currentReportId);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a wedding to delete", "ERROR", MessageBoxButtons.OK);
            }
        }

        private void img_close_service_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

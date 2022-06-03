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
    public partial class ReportDay : Form
    {
        public static string currentReportId = "";
        public static int currentReportDay = 0;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table1 = new DataTable();
        public ReportDay()
        {
            InitializeComponent();
            ReportLoad();
        }

        private void ReportLoad()
        {
            //load_data_wedding();
            DataColumn column;
            DataRow row;
            // Create first column and add to the DataTable.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Day";
            column.AutoIncrement = false;
            column.Caption = "Day";
            column.ReadOnly = true;
            column.Unique = false;
            // Add the column to the DataColumnCollection.
            table1.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "DayRevenue";
            column.AutoIncrement = false;
            column.Caption = "DayRevenue";
            column.ReadOnly = false;
            column.Unique = false;
            table1.Columns.Add(column);

            // create third column
            //column = new DataColumn();
            //column.DataType = System.Type.GetType("System.Double");
            //column.ColumnName = "Month";
            //column.AutoIncrement = false;
            //column.Caption = "month";
            //column.ReadOnly = false;
            //column.Unique = false;
            //table1.Columns.Add(column);
            // Create second column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "AmountOfWedding";
            column.AutoIncrement = false;
            column.Caption = "AmountOfWedding";
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

            dataGridView1.DataSource = table1;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.HeaderText = table1.Columns[col.DataPropertyName].Caption;
            }
            dataGridView1.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(dataWedding_RowHeaderMouseClick);
            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand check = new SqlCommand("SELECT * FROM REVENUE_REPORT_DT", sql))
                {
                    using (SqlDataReader reader = check.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DataRow rw = table1.NewRow();
                            rw.ItemArray = new object[] { reader["Day"], reader["DayRevenue"], reader["AmoutOfWedding"], reader["IdReport"] };
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
            currentReportDay = int.Parse(table1.Rows[e.RowIndex]["Day"].ToString());
            Console.WriteLine(NhanTiec.currentWeddingId);
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int index = comboBoxDay.SelectedIndex;
            int index2 = comboBoxMonth.SelectedIndex;
            if (index < 0 || index2 < 0)
            {
                MessageBox.Show("Please fill full infor ");
            }
            else
                using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
                {
                    sql.Open();
                    int total = 0;
                    int count = 0;
                    // complete command for me
                    string Id = "";
                    using (SqlCommand cmd2 = new SqlCommand("SELECT * from BILL where (DAY(PaymentDate)=@day and Month(PaymentDate)=@month and Year(PaymentDate)=@year)", sql))
                    {
                        cmd2.Parameters.AddWithValue("@day", int.Parse(comboBoxDay.SelectedItem.ToString()));
                        cmd2.Parameters.AddWithValue("@month", int.Parse(comboBoxMonth.SelectedItem.ToString()));
                        cmd2.Parameters.AddWithValue("@year", int.Parse(textBoxYear.Text));
                        using (SqlDataReader reader = cmd2.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    total += (int)reader["Total"];
                                    count += 1;
                                }
                            }
                        }
                    }
                    using (SqlCommand cmd2 = new SqlCommand("SELECT * from REVENUE_REPORT where (Month =@month)", sql))
                    {
                        cmd2.Parameters.AddWithValue("@month", int.Parse(comboBoxMonth.SelectedItem.ToString()));
                        using (SqlDataReader reader = cmd2.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Id = reader["idReport"].ToString();
                                    using (SqlCommand cmd = new SqlCommand("INSERT into REVENUE_REPORT(IdReport) Values(@id)", sql))
                                    {
                                        cmd.Parameters.AddWithValue("@id", Id);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                            else
                            {
                                Id = "RR" + WeddingClient.GetNewIdFromTable("RR").ToString();
                            }
                        }
                    }
                    using (SqlCommand cmd2 = new SqlCommand("INSERT INTO REVENUE_REPORT (IdReport, Month, year) VALUES (@id, @month, @year) ", sql))
                    {
                        cmd2.Parameters.AddWithValue("@id", Id);
                        cmd2.Parameters.AddWithValue("@month", int.Parse(comboBoxMonth.SelectedItem.ToString()));
                        cmd2.Parameters.AddWithValue("@year", int.Parse(textBoxYear.Text));
                        cmd2.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd2 = new SqlCommand("Insert into  REVENUE_REPORT_DT(IdReport,Day,DayRevenue,AmoutOfWedding) values(@id,@day,@rday,@amout)", sql))
                    {
                        cmd2.Parameters.AddWithValue("@month", int.Parse(comboBoxMonth.SelectedItem.ToString()));
                        cmd2.Parameters.AddWithValue("@day", int.Parse(comboBoxDay.SelectedItem.ToString()));
                        cmd2.Parameters.AddWithValue("@rday", total);
                        cmd2.Parameters.AddWithValue("@id", Id);
                        cmd2.Parameters.AddWithValue("@amout", count);
                        try
                        {
                            if (cmd2.ExecuteNonQuery() > 0)
                            {
                                textBoxAOW.Text = count.ToString();
                                textBoxDayRevenue.Text = total.ToString();
                            }
                        }
                        catch
                        {

                        }
                    }
                    DataRow rw = table1.NewRow();
                    rw.ItemArray = new object[] { int.Parse(comboBoxDay.SelectedItem.ToString()), total, count, Id };
                    table1.Rows.Add(rw);
                }
        }

        private void ReportDay_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e){}
        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void buttonDelete_Click(object sender, EventArgs e)
        //{
        //    if (currentReportId != null && currentReportId.Length == 21)
        //    {
        //        using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
        //        {
        //            sql.Open();
        //            // complete command for me
        //            using (SqlCommand cmd = new SqlCommand("DELETE FROM REVENUE_REPORT_DT  WHERE (IdReport = @id and Day =@day)", sql))
        //            {
        //                cmd.Parameters.AddWithValue("@id", currentReportId);
        //                cmd.Parameters.AddWithValue("@day", currentReportDay);
        //                MessageBox.Show(currentReportDay.ToString());
        //                if (cmd.ExecuteNonQuery() > 0)
        //                {
        //                    //Load_data_wedding();
        //                    // delete row in table1
        //                    //dataWedding.Rows.RemoveAt(dataWedding.CurrentRow.Index);
        //                    table1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
        //                    MessageBox.Show("Report deleted", "SUCCESS", MessageBoxButtons.OK);
        //                    NhanTiec.currentWeddingId = "";
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please select a wedding to delete", "ERROR", MessageBoxButtons.OK);
        //    }
        //}
    }
}

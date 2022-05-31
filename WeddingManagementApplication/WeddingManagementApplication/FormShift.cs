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
    public partial class FormShift : Form
    {
        public FormShift()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(this.tbEnd.Text ==""||this.tbName.Text ==""||this.tbStart.Text =="")
            {
                MessageBox.Show("Vui lòng điền đủ thông tin");
            }    
            else
            {
                Shift s =new Shift();
                s._lbName=this.tbName.Text;
                s._lbStart=this.tbStart.Text;
                s._lbEnd=this.tbEnd.Text;
                s._lbStatus = this.rbtA.Checked ? "Trống" : "Đầy";
                int state = this.rbtA.Checked ? 1 : 0;
                using (var sql = new SqlConnection(WeddingClient.sqlConnectionString))
                {
                    sql.Open();
                    // add menu to database
                    // if success add menu to list
                    using (SqlCommand command = new SqlCommand("insert into Shift  values (@idShift, @available, @Name, @Start,@End)", sql))
                    {
                        command.Parameters.AddWithValue("@idShift", "SH" + WeddingClient.GetNewIdFromTable("SH").ToString().PadLeft(19, '0'));
                        command.Parameters.AddWithValue("@available", state);
                        command.Parameters.AddWithValue("@Name", s._lbName);
                        command.Parameters.AddWithValue("@Start", s._lbStart);
                        command.Parameters.AddWithValue("@End", s._lbEnd);
                        if (command.ExecuteNonQuery() > 0)
                        {
                            this.flowLayoutPanel1.Controls.Add(s);
                        }
                        else
                        {
                        }
                    }
                }
            }    
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

        }

        private void FormShift_Load(object sender, EventArgs e)
        {
            
            using (var sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand command = new SqlCommand("select * from Shift where Available > 0", sql))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Shift shift = new Shift();
                            //MessageBox.Show("alo");
                            shift._lbName = reader["name"].ToString();
                            shift._lbStart = reader["Starting"].ToString();
                            shift._lbEnd = reader["Ending"].ToString();
                            shift._lbStatus= reader["available"].ToString();
                            this.flowLayoutPanel1.Controls.Add(shift);
                        }
                    }
                }
            }
        }
    }
}

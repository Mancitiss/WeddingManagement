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
                        string id = "SH" + WeddingClient.GetNewIdFromTable("SH").ToString().PadLeft(19, '0');
                        s._id = id;
                        command.Parameters.AddWithValue("@idShift",id );
                        command.Parameters.AddWithValue("@available", state);
                        command.Parameters.AddWithValue("@Name", s._lbName);
                        command.Parameters.AddWithValue("@Start", s._lbStart);
                        command.Parameters.AddWithValue("@End", s._lbEnd);
                        if (command.ExecuteNonQuery() > 0)
                        {
                            this.flowLayoutPanel1.Controls.Add(s);
                            tbEnd.Text = "";
                            tbName.Text = "";
                            tbStart.Text = "";
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
            int count = 0;
            Shift selectedShift = new Shift();
            Shift pre = new Shift();
            foreach (var s in this.flowLayoutPanel1.Controls)
            {
                selectedShift = s as Shift;
                if (selectedShift != null)
                {
                    
                    if (selectedShift._btnCheck == true)
                    {
                        pre = selectedShift;
                        count++;
                    }    
                }
                if (count > 1)
                {
                    MessageBox.Show("Chỉ xóa 1 đối tượng");
                    break;
                }    
            }
            if (count == 1)
            {
                using (var sql = new SqlConnection(WeddingClient.sqlConnectionString))
                {
                    sql.Open();
                    using (SqlCommand command = new SqlCommand("delete from Shift where IdShift=@id", sql))
                    {
                        command.Parameters.AddWithValue("@id", pre._id);
                        if (command.ExecuteNonQuery() > 0)
                        {
                            foreach (var s in this.flowLayoutPanel1.Controls)
                            {
                                if ((s as Shift)._id == pre._id)
                                {
                                    this.flowLayoutPanel1.Controls.Remove(s as Control);
                                    MessageBox.Show("Xóa thành công");
                                    break;
                                }
                            }
                        }
                    }
                }
            }
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
                            shift._lbName = reader["ShiftName"].ToString();
                            shift._lbStart = reader["Starting"].ToString();
                            shift._lbEnd = reader["Ending"].ToString();
                            shift._lbStatus= reader["available"].ToString()=="1"?"Trống" :"Đã được đặt";
                            shift._id = reader["IdShift"].ToString();
                            this.flowLayoutPanel1.Controls.Add(shift);
                        }
                    }
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.tbEnd.Text == "" || this.tbName.Text == "" || this.tbStart.Text == "")
            {
                MessageBox.Show("Vui lòng điền đủ thông tin");
            }
            else
            {
                int count = 0;
                Shift selectedShift = new Shift();
                Shift pre = new Shift();
                foreach (var s in this.flowLayoutPanel1.Controls)
                {
                    selectedShift = s as Shift;
                    if (selectedShift != null)
                    {

                        if (selectedShift._btnCheck == true)
                        {
                            pre = selectedShift;
                            count++;
                        }
                    }
                    if (count > 1)
                    {
                        MessageBox.Show("Chỉ xóa 1 đối tượng");
                        break;
                    }
                }
                if (count == 1)
                {
                    using (var sql = new SqlConnection(WeddingClient.sqlConnectionString))
                    {
                        sql.Open();
                        using (SqlCommand command = new SqlCommand("update Shift Set Available=@avl,ShiftName=@name,Starting=@start,Ending=@end where IdShift=@id", sql))
                        {
                            command.Parameters.AddWithValue("@id", pre._id);
                            command.Parameters.AddWithValue("@start", tbStart.Text);
                            command.Parameters.AddWithValue("@end", tbEnd.Text);
                            command.Parameters.AddWithValue("@avl", this.rbtA.Checked ? 1 : 0);
                            command.Parameters.AddWithValue("@name", tbName.Text);
                            if (command.ExecuteNonQuery() > 0)
                            {
                                this.flowLayoutPanel1.Controls.Clear();
                                    using (SqlCommand command1 = new SqlCommand("select * from Shift where Available > 0", sql))
                                    {
                                        using (SqlDataReader reader = command1.ExecuteReader())
                                        {
                                            while (reader.Read())
                                            {
                                                Shift shift = new Shift();
                                                //MessageBox.Show("alo");
                                                shift._lbName = reader["ShiftName"].ToString();
                                                shift._lbStart = reader["Starting"].ToString();
                                                shift._lbEnd = reader["Ending"].ToString();
                                                shift._lbStatus = reader["available"].ToString() == "1" ? "Trống" : "Đã được đặt";
                                                shift._id = reader["IdShift"].ToString();
                                                this.flowLayoutPanel1.Controls.Add(shift);
                                            }
                                        }
                                    }
                                MessageBox.Show("Cập nhật thành công");
                            }
                        }
                    }
                }
            }
        }
        Point lastPoint = new Point();
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
                lastPoint = new Point(e.X, e.Y);

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
    }
}

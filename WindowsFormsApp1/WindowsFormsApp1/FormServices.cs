using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormServices : Form
    {
        public FormServices()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(tbDetail.Text =="" || tbName.Text =="" || tbDetail.Text=="")
            {
                MessageBox.Show("Nội dung bị thiếu");
            }    
            else
            {
                Services s = new Services();
                s._tbName = tbName.Text;
                s._tbDetail = tbDetail.Text;
                s._tbPrice = tbPrice.Text;
                Service service = new Service();
                service.idService = "";
                service.ServicePrice = int.Parse(s._tbPrice);
                service.ServiceName = s._tbName;
                service.Note = s._tbDetail;
                this.flowLayoutPanel1.Controls.Add(s);
                tbDetail.Text = "";
                tbName.Text = "";
                tbPrice.Text = "";
            }    
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}

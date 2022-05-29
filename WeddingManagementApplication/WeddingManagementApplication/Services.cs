using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeddingManagementApplication
{ 
    public partial class Services : UserControl
    {
        public Services()
        {
            InitializeComponent();
        }
        public string _tbName
        {
            get { return this.tbName.Text; }
            set { this.tbName.Text = value; }
        }
        public string _tbPrice
        {
            get { return this.tbPrice.Text; }
            set { this.tbPrice.Text = value; }
        }
        public string _tbDetail
        {
            get { return this.tbDetail.Text; }
            set { this.tbDetail.Text = value; }
        }
        private void Services_Click(object sender, EventArgs e)
        {
            if (button1.Visible == true)
            {
                button1.Visible = false;
            }
            else
            {
                button1.Visible = true;
            }
        }
    }
}

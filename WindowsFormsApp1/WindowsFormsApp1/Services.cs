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
    public partial class Services : UserControl
    {
        public Services()
        {
            InitializeComponent();
        }

        private void Services_Click(object sender, EventArgs e)
        {
            if(button1.Visible==true)
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

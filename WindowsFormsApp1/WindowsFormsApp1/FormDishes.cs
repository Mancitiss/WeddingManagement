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
    public partial class FormDishes : Form
    {
        public FormDishes()
        {
            InitializeComponent();
        }

        private void btnCMenu_Click(object sender, EventArgs e)
        {
            Form tempMenu = new FormMenu();
            tempMenu.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

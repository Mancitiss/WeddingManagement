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
    public partial class FormHome : Form
    {
        private Form curChildForm;
        public FormHome()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.panelNavigate.Top = this.btnHome.Top;
        }

        private void btnWedding_Click(object sender, EventArgs e)
        {
            this.panelNavigate.Top=this.btnWedding.Top;
            openChildForm(new FormBooking());
            
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.panelNavigate.Top = this.btnMenu.Top;
            openChildForm(new FormDishes());
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            this.panelNavigate.Top = this.btnService.Top;
            openChildForm(new FormServices());
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            this.panelNavigate.Top = this.btnReport.Top;
        }

        private void btnLobby_Click(object sender, EventArgs e)
        {
            this.panelNavigate.Top = this.btnLobby.Top;
            openChildForm(new FormLobby());
        }
        private void openChildForm (Form childForm)
        {
            if (childForm == null) ;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            this.curChildForm = childForm;
            this.MainForm.Controls.Add(this.curChildForm);
            this.MainForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

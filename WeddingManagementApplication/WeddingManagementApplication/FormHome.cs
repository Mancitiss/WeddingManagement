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
    public partial class FormHome : Form
    {
        private Form curChildForm;

        public Form GetCurrentChildForm()
        {
            return curChildForm;
        }
        public FormHome()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.panelNavigate.Top = this.btnHome.Top;
            this.searchDropDown1.Visible = false;
        }

        private void btnWedding_Click(object sender, EventArgs e)
        {

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.searchDropDown1.Visible = false;
            this.lobbyDropDown1.Visible = false;
            this.panelNavigate.Top = this.btnMenu.Top;
            FormDishes frm = new FormDishes();
            frm.ShowDialog();
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            this.searchDropDown1.Visible = false;
            this.panelNavigate.Top = this.btnService.Top;
            FormServices frm = new FormServices();
            frm.ShowDialog();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            this.searchDropDown1.Visible = false;
            this.panelNavigate.Top = this.btnReport.Top;
            this.reportDropDown1.Visible = !this.reportDropDown1.Visible;

        }

        private void btnLobby_Click(object sender, EventArgs e)
        {
            this.panelNavigate.Top = this.btnLobby.Top;
            this.lobbyDropDown1.Visible = !this.lobbyDropDown1.Visible;
        }
        private void openChildForm(Form childForm)
        {
            if (childForm == null) return;
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
            // close the app completely
            Application.Exit();
        }

        private void btnShift_Click(object sender, EventArgs e)
        {
            this.searchDropDown1.Visible = false;
            this.panelNavigate.Top = this.btnWedding.Top;
            FormMenu frm = new FormMenu();
            frm.ShowDialog();
        }

        private void btnSearch_MouseHover(object sender, EventArgs e)
        {
            this.searchDropDown1.Visible = true;
            this.lobbyDropDown1.Visible = false;
            this.reportDropDown1.Visible = false;
        }

        private void MainForm_MouseHover(object sender, EventArgs e)
        {
            this.searchDropDown1.Visible=false;
            this.lobbyDropDown1.Visible = false;
            this.reportDropDown1.Visible = false;
        }

        private void btnLobby_MouseHover(object sender, EventArgs e)
        {
            this.searchDropDown1.Visible = false;
            this.lobbyDropDown1.Visible = true;
            this.reportDropDown1.Visible = false;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            this.searchDropDown1.Visible = false;
            this.lobbyDropDown1.Visible = false;
            FormMenu frm = new FormMenu();
            frm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.searchDropDown1.Visible = false;
            this.lobbyDropDown1.Visible = false;
            FormLogin frm = new FormLogin();
            frm.Show();
            this.Close();
        }

        private void btnMenu_MouseHover(object sender, EventArgs e)
        {
            this.searchDropDown1.Visible = false;
            this.lobbyDropDown1.Visible = false;
            this.reportDropDown1.Visible = false;
        }

        private void btnService_MouseHover(object sender, EventArgs e)
        {
            this.searchDropDown1.Visible = false;
            this.lobbyDropDown1.Visible = false;
            this.reportDropDown1.Visible = false;
        }

        private void btnWedding_Click_1(object sender, EventArgs e)
        {
            this.searchDropDown1.Visible = false;
            this.panelNavigate.Top = this.btnWedding.Top;
            NhanTiec frm = new NhanTiec();
            frm.ShowDialog();
        }

        private void btnReport_MouseHover(object sender, EventArgs e)
        {
            this.searchDropDown1.Visible = false;
            this.lobbyDropDown1.Visible = false;
            this.reportDropDown1.Visible = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.searchDropDown1.Visible = !this.searchDropDown1.Visible;
            this.lobbyDropDown1.Visible = false;
            this.reportDropDown1.Visible = false;
        }

        private void btnHome_MouseHover(object sender, EventArgs e)
        {
            this.searchDropDown1.Visible = false;
            this.lobbyDropDown1.Visible = false;
            this.reportDropDown1.Visible = false;
        }

        private void btnLogout_MouseHover(object sender, EventArgs e)
        {
            this.searchDropDown1.Visible = false;
            this.lobbyDropDown1.Visible = false;
            this.reportDropDown1.Visible = false;
            
        }

        private void btnWedding_MouseHover(object sender, EventArgs e)
        {
            this.searchDropDown1.Visible = false;
            this.lobbyDropDown1.Visible = false;
            this.reportDropDown1.Visible = false;
        }

        private void btnSettings_MouseHover(object sender, EventArgs e)
        {
            this.searchDropDown1.Visible = false;
            this.lobbyDropDown1.Visible = false;
            this.reportDropDown1.Visible = false;
        }

        private void lobbyDropDown1_Load(object sender, EventArgs e)
        {
        }
    }
}

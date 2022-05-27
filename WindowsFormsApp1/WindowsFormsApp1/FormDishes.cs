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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(this.textBox1.Text == "" || this.textBox2.Text == "" || this.tbImage.Text == "")
            {
                MessageBox.Show("Vui lòng điền đủ thông tin");
            }
            else
            {
                WeddingClient.Add_Dishes(this.textBox1.Text,this.textBox2.Text,this.tbImage.Text);
            }    
            
        }

        private void FormDishes_Load(object sender, EventArgs e)
        {
            foreach (Menu m in WeddingClient.Get_Dishes())
            {
                Dishes d = new Dishes();

                d._btnClick = false;
                d._imgPath = m.Note;
                d._lbNameText = m.DishesName;
                d._lbPriceText = m.DishesPrice.ToString();
                this.flowLayoutPanel1.Controls.Add(d);
             }
        }
    

        private void btnUpFile_Click(object sender, EventArgs e)
        {
           
            var t = new System.Threading.Thread((System.Threading.ThreadStart)(() => {
                OpenFileDialog dlg = new OpenFileDialog(); 
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.tbImage.Text = dlg.FileName;
                }
            }));

            t.SetApartmentState(System.Threading.ApartmentState.STA);
            t.Start();
            t.Join();
        }
    }
}

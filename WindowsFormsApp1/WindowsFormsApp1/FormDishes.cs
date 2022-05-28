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
        internal delegate void AddMenu(List<Menu> menus);
        internal AddMenu AddMenuDelegate;
        public FormDishes()
        {
            InitializeComponent();
            AddMenuDelegate = new AddMenu(AddDishes);
            WeddingClient.Queue_command(Encoding.Unicode.GetBytes("0024"));
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
            if(this.textBox1.Text == "" || this.textBox2.Text == "" )
            {
                MessageBox.Show("Vui lòng điền đủ thông tin");
            }
            else
            {
                Dishes d= new Dishes();
                d._lbNameText=this.textBox1.Text;
                d._lbPriceText=this.textBox2.Text;
                Menu m = new Menu();
                m.idDishes = "";
                m.DishesName = d._lbNameText;
                m.DishesPrice = int.Parse(d._lbPriceText);
                WeddingClient.Queue_command(Encoding.Unicode.GetBytes("0124" + Tools.data_with_byte(Jil.JSON.Serialize<Menu>(m))));
                //this.AddDishes(d); don't add from here
            }    
            
        }

        private void FormDishes_Load(object sender, EventArgs e)
        {
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
        internal void AddDishes(List<Menu> menus)
        {
            foreach (Menu m in menus)
            {
                Dishes d = new Dishes();
                MessageBox.Show(m.DishesName);
                d._btnClick = false;
                //d._imgPath = m.Note;
                d._lbNameText = m.DishesName;
                d._lbPriceText = m.DishesPrice.ToString();
                this.flowLayoutPanel1.Controls.Add(d);
            }
        }
    }
}

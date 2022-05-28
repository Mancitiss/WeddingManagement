using System;
using System.Collections.Concurrent;
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
        public static ConcurrentDictionary<string, Dishes> dishes = new ConcurrentDictionary<string, Dishes>();
        public static ConcurrentDictionary<string, byte> selectedDishesIDs = new System.Collections.Concurrent.ConcurrentDictionary<string, byte>();

        internal delegate void AddMenu(List<Menu> menus);
        internal AddMenu AddMenuDelegate;

        internal delegate void AddOneMenu(Menu menu);
        internal AddOneMenu AddOneMenuDelegate;
        internal delegate void RemoveOneMenu(Menu menu);
        internal RemoveOneMenu RemoveOneMenuDelegate;
        internal delegate void UpdateOneMenu(Menu menu);
        internal UpdateOneMenu UpdateOneMenuDelegate;

        public FormDishes()
        {
            dishes = new ConcurrentDictionary<string, Dishes>();
            selectedDishesIDs = new ConcurrentDictionary<string, byte>();
            InitializeComponent();
            AddMenuDelegate = new AddMenu(AddDishes);
            AddOneMenuDelegate = new AddOneMenu(AddOneDishes);
            UpdateOneMenuDelegate = new UpdateOneMenu(UpdateOneDishes);
            RemoveOneMenuDelegate = new RemoveOneMenu(RemoveOneDishes);
        }

        private void UpdateOneDishes(Menu menu)
        {
            dishes[menu.idDishes].menu = menu;
            dishes[menu.idDishes].id = menu.idDishes;
            dishes[menu.idDishes]._lbNameText = menu.DishesName;
            dishes[menu.idDishes]._lbPriceText = menu.DishesPrice.ToString();
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(this.textBox1.Text == "" || this.textBox2.Text == "" )
            {
                MessageBox.Show("Vui lòng điền đủ thông tin");
            }
            else
            {
                Menu m = new Menu();
                m.idDishes = "";
                m.DishesName = this.textBox1.Text;
                m.DishesPrice = int.Parse(this.textBox2.Text);
                WeddingClient.Queue_command(Encoding.Unicode.GetBytes("0124" + Tools.data_with_byte(Jil.JSON.Serialize<Menu>(m))));
                //this.AddDishes(d); don't add from here
            }    
            
        }

        private void FormDishes_Load(object sender, EventArgs e)
        {
            WeddingClient.Queue_command(Encoding.Unicode.GetBytes("0024"));
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
        private void AddDishes(List<Menu> menus)
        {
            foreach (Menu m in menus)
            {
                Dishes d = new Dishes(m); 
                if (!dishes.ContainsKey(m.idDishes))
                {
                    this.flowLayoutPanel1.Controls.Add(d);
                }
                FormDishes.dishes.AddOrUpdate(d.id, d, (key, oldValue) => d);
            }
        }
        private void AddOneDishes(Menu menu)
        {
            Dishes d = new Dishes(menu); 
            if (!dishes.ContainsKey(menu.idDishes))
            {
                this.flowLayoutPanel1.Controls.Add(d);
            }
            FormDishes.dishes.AddOrUpdate(d.id, d, (key, oldValue) => d);
            Console.WriteLine(d.id);
            Console.WriteLine(d.menu.idDishes);
        }
        
        private void RemoveOneDishes(Menu menu)
        {
            Dishes d;
            if(FormDishes.dishes.TryGetValue(menu.idDishes, out d))
            {
                this.flowLayoutPanel1.Controls.Remove(d);
                FormDishes.dishes.TryRemove(menu.idDishes, out Dishes _);
            }
        }
        
        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (string id in FormDishes.selectedDishesIDs.Keys)
            {
                Dishes d;
                if (FormDishes.dishes.TryGetValue(id, out d))
                {
                    d.id = "-" + d.id;
                    Console.WriteLine(d.id);
                    d.menu.idDishes = "-" + d.menu.idDishes;
                    WeddingClient.Queue_command(Encoding.Unicode.GetBytes("0124" + Tools.data_with_byte(Jil.JSON.Serialize<Menu>(d.menu))));
                }
            }
            selectedDishesIDs.Clear();
        }  
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace WindowsFormsApp1
{
    public partial class Dishes : UserControl
    {
        public Dishes()
        {
            InitializeComponent();
        }
        public string _lbNameText
        {
            get { return this.lbName.Text; }

            set { this.lbName.Text = value; }
        }
        public string _lbPriceText
        {
            get { return this.lbCost.Text; }

            set { this.lbCost.Text = value; }
        }

        public bool _btnClick
        {
            get { return this.btnClick.Visible; }
            set { this.btnClick.Visible = value; }
        }

        public string _imgPath
        {
            get
            {
                return this.BackgroundImage.ToString();
            }
            set
            {
                this.BackgroundImage = Image.FromFile(value);
            }
        }
        private void Dishes_Click(object sender, EventArgs e)
        {
            if(this.btnClick.Visible==true)
            {
                this.btnClick.Visible=false;
            }    
            else
            {
                this.btnClick.Visible=true;
                this.BorderStyle = BorderStyle.FixedSingle;
            }    
        }
    }
}

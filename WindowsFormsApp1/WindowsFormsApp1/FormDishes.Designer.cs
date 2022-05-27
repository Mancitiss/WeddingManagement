namespace WindowsFormsApp1
{
    partial class FormDishes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCMenu = new System.Windows.Forms.Button();
            this.lbImage = new System.Windows.Forms.Label();
            this.tbImage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbDishesPrice = new System.Windows.Forms.Label();
            this.lbNameDishes = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnUpFile = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnUpFile);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.btnCMenu);
            this.panel2.Controls.Add(this.lbImage);
            this.panel2.Controls.Add(this.tbImage);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lbDishesPrice);
            this.panel2.Controls.Add(this.lbNameDishes);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.btnRemove);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(816, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(337, 654);
            this.panel2.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(116, 493);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(117, 46);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCMenu
            // 
            this.btnCMenu.Location = new System.Drawing.Point(116, 441);
            this.btnCMenu.Name = "btnCMenu";
            this.btnCMenu.Size = new System.Drawing.Size(117, 46);
            this.btnCMenu.TabIndex = 10;
            this.btnCMenu.Text = "Tạo Menu";
            this.btnCMenu.UseVisualStyleBackColor = true;
            this.btnCMenu.Click += new System.EventHandler(this.btnCMenu_Click);
            // 
            // lbImage
            // 
            this.lbImage.AutoSize = true;
            this.lbImage.Location = new System.Drawing.Point(13, 239);
            this.lbImage.Name = "lbImage";
            this.lbImage.Size = new System.Drawing.Size(30, 16);
            this.lbImage.TabIndex = 9;
            this.lbImage.Text = "Ảnh";
            // 
            // tbImage
            // 
            this.tbImage.Location = new System.Drawing.Point(90, 233);
            this.tbImage.Name = "tbImage";
            this.tbImage.Size = new System.Drawing.Size(198, 22);
            this.tbImage.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 278);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Danh sách";
            // 
            // lbDishesPrice
            // 
            this.lbDishesPrice.AutoSize = true;
            this.lbDishesPrice.Location = new System.Drawing.Point(13, 188);
            this.lbDishesPrice.Name = "lbDishesPrice";
            this.lbDishesPrice.Size = new System.Drawing.Size(28, 16);
            this.lbDishesPrice.TabIndex = 6;
            this.lbDishesPrice.Text = "Giá";
            // 
            // lbNameDishes
            // 
            this.lbNameDishes.AutoSize = true;
            this.lbNameDishes.Location = new System.Drawing.Point(13, 118);
            this.lbNameDishes.Name = "lbNameDishes";
            this.lbNameDishes.Size = new System.Drawing.Size(60, 16);
            this.lbNameDishes.TabIndex = 5;
            this.lbNameDishes.Text = "Tên món";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(90, 275);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(196, 24);
            this.comboBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(89, 185);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(198, 22);
            this.textBox2.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(89, 118);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(198, 22);
            this.textBox1.TabIndex = 2;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(116, 389);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(117, 46);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "Xóa";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(116, 337);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(117, 46);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(816, 654);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnUpFile
            // 
            this.btnUpFile.Location = new System.Drawing.Point(294, 227);
            this.btnUpFile.Name = "btnUpFile";
            this.btnUpFile.Size = new System.Drawing.Size(37, 34);
            this.btnUpFile.TabIndex = 12;
            this.btnUpFile.Text = "...";
            this.btnUpFile.UseVisualStyleBackColor = true;
            this.btnUpFile.Click += new System.EventHandler(this.btnUpFile_Click);
            // 
            // FormDishes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 654);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1153, 654);
            this.MinimumSize = new System.Drawing.Size(1153, 654);
            this.Name = "FormDishes";
            this.Text = "FormDishes";
            this.Load += new System.EventHandler(this.FormDishes_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbDishesPrice;
        private System.Windows.Forms.Label lbNameDishes;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lbImage;
        private System.Windows.Forms.TextBox tbImage;
        private System.Windows.Forms.Button btnCMenu;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnUpFile;
    }
}
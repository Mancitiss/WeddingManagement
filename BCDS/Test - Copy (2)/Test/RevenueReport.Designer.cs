
namespace Test
{
    partial class RevenueReport
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RevenueReport));
            this.labelWDRestaurant = new System.Windows.Forms.Label();
            this.labelRReport = new System.Windows.Forms.Label();
            this.panelAll = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelRTotal = new System.Windows.Forms.Label();
            this.labelMonth = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idReport = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Month = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RevenueTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.panelBin = new System.Windows.Forms.Panel();
            this.labelPlus = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelWDRestaurant
            // 
            this.labelWDRestaurant.AutoSize = true;
            this.labelWDRestaurant.Font = new System.Drawing.Font("SVN-Hollie Script Pro", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelWDRestaurant.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.labelWDRestaurant.Location = new System.Drawing.Point(579, 2);
            this.labelWDRestaurant.Name = "labelWDRestaurant";
            this.labelWDRestaurant.Size = new System.Drawing.Size(237, 35);
            this.labelWDRestaurant.TabIndex = 0;
            this.labelWDRestaurant.Text = "Wedding Restaurant HALTT";
            // 
            // labelRReport
            // 
            this.labelRReport.AutoSize = true;
            this.labelRReport.Font = new System.Drawing.Font("SFU Futura", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelRReport.ForeColor = System.Drawing.Color.Firebrick;
            this.labelRReport.Location = new System.Drawing.Point(186, 26);
            this.labelRReport.Name = "labelRReport";
            this.labelRReport.Size = new System.Drawing.Size(427, 67);
            this.labelRReport.TabIndex = 1;
            this.labelRReport.Text = "REVENUE REPORT";
            this.labelRReport.Click += new System.EventHandler(this.label1_Click);
            // 
            // panelAll
            // 
            this.panelAll.Controls.Add(this.textBox2);
            this.panelAll.Controls.Add(this.textBox1);
            this.panelAll.Controls.Add(this.labelRTotal);
            this.panelAll.Controls.Add(this.labelMonth);
            this.panelAll.Location = new System.Drawing.Point(12, 99);
            this.panelAll.Name = "panelAll";
            this.panelAll.Size = new System.Drawing.Size(776, 86);
            this.panelAll.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(386, 50);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(125, 27);
            this.textBox2.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(386, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 27);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // labelRTotal
            // 
            this.labelRTotal.AutoSize = true;
            this.labelRTotal.Font = new System.Drawing.Font("UTM Facebook K&T", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelRTotal.Location = new System.Drawing.Point(137, 49);
            this.labelRTotal.Name = "labelRTotal";
            this.labelRTotal.Size = new System.Drawing.Size(158, 28);
            this.labelRTotal.TabIndex = 1;
            this.labelRTotal.Text = "Revenue Total:";
            // 
            // labelMonth
            // 
            this.labelMonth.AutoSize = true;
            this.labelMonth.Font = new System.Drawing.Font("UTM Facebook K&T", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelMonth.Location = new System.Drawing.Point(212, 4);
            this.labelMonth.Name = "labelMonth";
            this.labelMonth.Size = new System.Drawing.Size(83, 28);
            this.labelMonth.TabIndex = 0;
            this.labelMonth.Text = "Month:";
            this.labelMonth.Click += new System.EventHandler(this.labelMonth_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idReport,
            this.Month,
            this.Year,
            this.RevenueTotal});
            this.dataGridView1.Location = new System.Drawing.Point(12, 205);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(739, 188);
            this.dataGridView1.TabIndex = 3;
            // 
            // idReport
            // 
            this.idReport.DataPropertyName = "idReport";
            this.idReport.HeaderText = "id Report";
            this.idReport.MinimumWidth = 6;
            this.idReport.Name = "idReport";
            this.idReport.Width = 150;
            // 
            // Month
            // 
            this.Month.DataPropertyName = "Month";
            this.Month.HeaderText = "Month";
            this.Month.MinimumWidth = 6;
            this.Month.Name = "Month";
            this.Month.Width = 150;
            // 
            // Year
            // 
            this.Year.DataPropertyName = "Year";
            this.Year.HeaderText = "Year";
            this.Year.MinimumWidth = 6;
            this.Year.Name = "Year";
            this.Year.Width = 150;
            // 
            // RevenueTotal
            // 
            this.RevenueTotal.DataPropertyName = "RevenueTotal";
            this.RevenueTotal.HeaderText = "Revenue Total";
            this.RevenueTotal.MinimumWidth = 6;
            this.RevenueTotal.Name = "RevenueTotal";
            this.RevenueTotal.Width = 230;
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Red;
            this.buttonExit.Font = new System.Drawing.Font("UTM Facebook K&T", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonExit.Location = new System.Drawing.Point(694, 409);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(94, 29);
            this.buttonExit.TabIndex = 4;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.Yellow;
            this.buttonSave.Font = new System.Drawing.Font("UTM Facebook K&T", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSave.Location = new System.Drawing.Point(577, 409);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(94, 29);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            // 
            // panelBin
            // 
            this.panelBin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelBin.BackgroundImage")));
            this.panelBin.Location = new System.Drawing.Point(757, 233);
            this.panelBin.Name = "panelBin";
            this.panelBin.Size = new System.Drawing.Size(31, 34);
            this.panelBin.TabIndex = 6;
            // 
            // labelPlus
            // 
            this.labelPlus.AutoSize = true;
            this.labelPlus.Font = new System.Drawing.Font("SFU Futura", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPlus.ForeColor = System.Drawing.Color.DarkOrange;
            this.labelPlus.Location = new System.Drawing.Point(745, 250);
            this.labelPlus.Name = "labelPlus";
            this.labelPlus.Size = new System.Drawing.Size(62, 70);
            this.labelPlus.TabIndex = 7;
            this.labelPlus.Text = "+";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Location = new System.Drawing.Point(757, 323);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(31, 34);
            this.panel1.TabIndex = 7;
            // 
            // RevenueReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(819, 453);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panelBin);
            this.Controls.Add(this.labelPlus);
            this.Controls.Add(this.labelWDRestaurant);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.panelAll);
            this.Controls.Add(this.labelRReport);
            this.Name = "RevenueReport";
            this.Text = "Revenue Report";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelAll.ResumeLayout(false);
            this.panelAll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWDRestaurant;
        private System.Windows.Forms.Label labelRReport;
        private System.Windows.Forms.Panel panelAll;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelRTotal;
        private System.Windows.Forms.Label labelMonth;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Panel panelBin;
        private System.Windows.Forms.Label labelPlus;
        private System.Windows.Forms.DataGridViewComboBoxColumn idReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn Month;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn RevenueTotal;
        private System.Windows.Forms.Panel panel1;
    }
}


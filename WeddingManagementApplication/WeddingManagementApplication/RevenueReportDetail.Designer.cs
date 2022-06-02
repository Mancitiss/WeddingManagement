namespace WeddingManagementApplication
{
    partial class RevenueReportDetail
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
            this.labelWDRestaurant = new System.Windows.Forms.Label();
            this.labelRReport = new System.Windows.Forms.Label();
            this.panelAll = new System.Windows.Forms.Panel();
            this.comboBoxDay = new System.Windows.Forms.ComboBox();
            this.textBoxAOW = new System.Windows.Forms.TextBox();
            this.textBoxRatio = new System.Windows.Forms.TextBox();
            this.labelAOW = new System.Windows.Forms.Label();
            this.labelRatio = new System.Windows.Forms.Label();
            this.textBoxDayRevenue = new System.Windows.Forms.TextBox();
            this.labelDayRevenue = new System.Windows.Forms.Label();
            this.labelDay = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.panelAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelWDRestaurant
            // 
            this.labelWDRestaurant.AutoSize = true;
            this.labelWDRestaurant.Font = new System.Drawing.Font("SVN-Hollie Script Pro", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelWDRestaurant.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.labelWDRestaurant.Location = new System.Drawing.Point(676, 2);
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
            this.labelRReport.Location = new System.Drawing.Point(96, 26);
            this.labelRReport.Name = "labelRReport";
            this.labelRReport.Size = new System.Drawing.Size(581, 64);
            this.labelRReport.TabIndex = 1;
            this.labelRReport.Text = "REVENUE REPORT DETAIL";
            this.labelRReport.Click += new System.EventHandler(this.label1_Click);
            // 
            // panelAll
            // 
            this.panelAll.Controls.Add(this.comboBoxDay);
            this.panelAll.Controls.Add(this.textBoxAOW);
            this.panelAll.Controls.Add(this.textBoxRatio);
            this.panelAll.Controls.Add(this.labelAOW);
            this.panelAll.Controls.Add(this.labelRatio);
            this.panelAll.Controls.Add(this.textBoxDayRevenue);
            this.panelAll.Controls.Add(this.labelDayRevenue);
            this.panelAll.Controls.Add(this.labelDay);
            this.panelAll.Location = new System.Drawing.Point(12, 99);
            this.panelAll.Name = "panelAll";
            this.panelAll.Size = new System.Drawing.Size(891, 86);
            this.panelAll.TabIndex = 2;
            // 
            // comboBoxDay
            // 
            this.comboBoxDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDay.FormattingEnabled = true;
            this.comboBoxDay.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.comboBoxDay.Location = new System.Drawing.Point(208, 3);
            this.comboBoxDay.Name = "comboBoxDay";
            this.comboBoxDay.Size = new System.Drawing.Size(125, 28);
            this.comboBoxDay.TabIndex = 8;
            this.comboBoxDay.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBoxAOW
            // 
            this.textBoxAOW.Location = new System.Drawing.Point(745, 46);
            this.textBoxAOW.Name = "textBoxAOW";
            this.textBoxAOW.ReadOnly = true;
            this.textBoxAOW.Size = new System.Drawing.Size(125, 27);
            this.textBoxAOW.TabIndex = 7;
            // 
            // textBoxRatio
            // 
            this.textBoxRatio.Location = new System.Drawing.Point(745, 4);
            this.textBoxRatio.Name = "textBoxRatio";
            this.textBoxRatio.ReadOnly = true;
            this.textBoxRatio.Size = new System.Drawing.Size(125, 27);
            this.textBoxRatio.TabIndex = 6;
            // 
            // labelAOW
            // 
            this.labelAOW.AutoSize = true;
            this.labelAOW.Font = new System.Drawing.Font("UTM Facebook K&T", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelAOW.Location = new System.Drawing.Point(480, 46);
            this.labelAOW.Name = "labelAOW";
            this.labelAOW.Size = new System.Drawing.Size(217, 28);
            this.labelAOW.TabIndex = 5;
            this.labelAOW.Text = "Amount Of Wedding:";
            // 
            // labelRatio
            // 
            this.labelRatio.AutoSize = true;
            this.labelRatio.Font = new System.Drawing.Font("UTM Facebook K&T", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelRatio.Location = new System.Drawing.Point(627, 5);
            this.labelRatio.Name = "labelRatio";
            this.labelRatio.Size = new System.Drawing.Size(70, 28);
            this.labelRatio.TabIndex = 4;
            this.labelRatio.Text = "Ratio:";
            // 
            // textBoxDayRevenue
            // 
            this.textBoxDayRevenue.Location = new System.Drawing.Point(208, 46);
            this.textBoxDayRevenue.Name = "textBoxDayRevenue";
            this.textBoxDayRevenue.ReadOnly = true;
            this.textBoxDayRevenue.Size = new System.Drawing.Size(125, 27);
            this.textBoxDayRevenue.TabIndex = 3;
            // 
            // labelDayRevenue
            // 
            this.labelDayRevenue.AutoSize = true;
            this.labelDayRevenue.Font = new System.Drawing.Font("UTM Facebook K&T", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDayRevenue.Location = new System.Drawing.Point(12, 46);
            this.labelDayRevenue.Name = "labelDayRevenue";
            this.labelDayRevenue.Size = new System.Drawing.Size(144, 28);
            this.labelDayRevenue.TabIndex = 1;
            this.labelDayRevenue.Text = "Day Revenue:";
            // 
            // labelDay
            // 
            this.labelDay.AutoSize = true;
            this.labelDay.Font = new System.Drawing.Font("UTM Facebook K&T", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDay.Location = new System.Drawing.Point(12, 4);
            this.labelDay.Name = "labelDay";
            this.labelDay.Size = new System.Drawing.Size(54, 28);
            this.labelDay.TabIndex = 0;
            this.labelDay.Text = "Day:";
            this.labelDay.Click += new System.EventHandler(this.labelMonth_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 205);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(739, 188);
            this.dataGridView1.TabIndex = 3;
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Red;
            this.buttonExit.Font = new System.Drawing.Font("UTM Facebook K&T", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonExit.Location = new System.Drawing.Point(760, 412);
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
            this.buttonSave.Location = new System.Drawing.Point(648, 412);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(94, 29);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.Silver;
            this.buttonDelete.Font = new System.Drawing.Font("UTM Facebook K&T", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonDelete.Location = new System.Drawing.Point(757, 238);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(71, 29);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = false;
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.Silver;
            this.buttonAdd.Font = new System.Drawing.Font("UTM Facebook K&T", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAdd.Location = new System.Drawing.Point(757, 289);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(71, 29);
            this.buttonAdd.TabIndex = 7;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = false;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.Silver;
            this.buttonUpdate.Font = new System.Drawing.Font("UTM Facebook K&T", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonUpdate.Location = new System.Drawing.Point(757, 342);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(71, 30);
            this.buttonUpdate.TabIndex = 8;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            // 
            // RevenueReportDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(916, 453);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelWDRestaurant);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.panelAll);
            this.Controls.Add(this.labelRReport);
            this.Name = "RevenueReportDetail";
            this.Text = "Revenue Report Detail";
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
        private System.Windows.Forms.Label labelDayRevenue;
        private System.Windows.Forms.Label labelDay;
        private System.Windows.Forms.TextBox textBoxDayRevenue;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.TextBox textBoxAOW;
        private System.Windows.Forms.TextBox textBoxRatio;
        private System.Windows.Forms.Label labelAOW;
        private System.Windows.Forms.Label labelRatio;
        private System.Windows.Forms.ComboBox comboBoxDay;
    }
}
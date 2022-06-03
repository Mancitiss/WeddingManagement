namespace WeddingManagementApplication
{
    partial class ReportDay
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
            this.labelRReport = new System.Windows.Forms.Label();
            this.panelAll = new System.Windows.Forms.Panel();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.labelmonth = new System.Windows.Forms.Label();
            this.textBoxAOW = new System.Windows.Forms.TextBox();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.labelAOW = new System.Windows.Forms.Label();
            this.labelYear = new System.Windows.Forms.Label();
            this.textBoxDayRevenue = new System.Windows.Forms.TextBox();
            this.comboBoxDay = new System.Windows.Forms.ComboBox();
            this.labelDayRevenue = new System.Windows.Forms.Label();
            this.labelDay = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.labelWDRestaurant = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.panelAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelRReport
            // 
            this.labelRReport.AutoSize = true;
            this.labelRReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold);
            this.labelRReport.ForeColor = System.Drawing.Color.Firebrick;
            this.labelRReport.Location = new System.Drawing.Point(145, 57);
            this.labelRReport.Name = "labelRReport";
            this.labelRReport.Size = new System.Drawing.Size(604, 51);
            this.labelRReport.TabIndex = 2;
            this.labelRReport.Text = "REVENUE REPORT DETAIL";
            // 
            // panelAll
            // 
            this.panelAll.Controls.Add(this.comboBoxMonth);
            this.panelAll.Controls.Add(this.labelmonth);
            this.panelAll.Controls.Add(this.textBoxAOW);
            this.panelAll.Controls.Add(this.textBoxYear);
            this.panelAll.Controls.Add(this.labelAOW);
            this.panelAll.Controls.Add(this.labelYear);
            this.panelAll.Controls.Add(this.textBoxDayRevenue);
            this.panelAll.Controls.Add(this.comboBoxDay);
            this.panelAll.Controls.Add(this.labelDayRevenue);
            this.panelAll.Controls.Add(this.labelDay);
            this.panelAll.Location = new System.Drawing.Point(24, 120);
            this.panelAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelAll.Name = "panelAll";
            this.panelAll.Size = new System.Drawing.Size(762, 94);
            this.panelAll.TabIndex = 3;
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.Items.AddRange(new object[] {
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
            "12"});
            this.comboBoxMonth.Location = new System.Drawing.Point(407, 2);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(112, 28);
            this.comboBoxMonth.TabIndex = 10;
            // 
            // labelmonth
            // 
            this.labelmonth.AutoSize = true;
            this.labelmonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.labelmonth.Location = new System.Drawing.Point(322, 3);
            this.labelmonth.Name = "labelmonth";
            this.labelmonth.Size = new System.Drawing.Size(79, 29);
            this.labelmonth.TabIndex = 9;
            this.labelmonth.Text = "Month";
            // 
            // textBoxAOW
            // 
            this.textBoxAOW.Location = new System.Drawing.Point(615, 52);
            this.textBoxAOW.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxAOW.Name = "textBoxAOW";
            this.textBoxAOW.Size = new System.Drawing.Size(110, 27);
            this.textBoxAOW.TabIndex = 7;
            // 
            // textBoxYear
            // 
            this.textBoxYear.Location = new System.Drawing.Point(616, 2);
            this.textBoxYear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.Size = new System.Drawing.Size(110, 27);
            this.textBoxYear.TabIndex = 6;
            // 
            // labelAOW
            // 
            this.labelAOW.AutoSize = true;
            this.labelAOW.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.labelAOW.Location = new System.Drawing.Point(363, 52);
            this.labelAOW.Name = "labelAOW";
            this.labelAOW.Size = new System.Drawing.Size(234, 29);
            this.labelAOW.TabIndex = 5;
            this.labelAOW.Text = "Amount Of Wedding:";
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.labelYear.Location = new System.Drawing.Point(544, 1);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(64, 29);
            this.labelYear.TabIndex = 4;
            this.labelYear.Text = "Year";
            // 
            // textBoxDayRevenue
            // 
            this.textBoxDayRevenue.Location = new System.Drawing.Point(182, 50);
            this.textBoxDayRevenue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxDayRevenue.Name = "textBoxDayRevenue";
            this.textBoxDayRevenue.Size = new System.Drawing.Size(110, 27);
            this.textBoxDayRevenue.TabIndex = 3;
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
            this.comboBoxDay.Location = new System.Drawing.Point(182, 2);
            this.comboBoxDay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxDay.Name = "comboBoxDay";
            this.comboBoxDay.Size = new System.Drawing.Size(110, 28);
            this.comboBoxDay.TabIndex = 8;
            // 
            // labelDayRevenue
            // 
            this.labelDayRevenue.AutoSize = true;
            this.labelDayRevenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.labelDayRevenue.Location = new System.Drawing.Point(10, 50);
            this.labelDayRevenue.Name = "labelDayRevenue";
            this.labelDayRevenue.Size = new System.Drawing.Size(162, 29);
            this.labelDayRevenue.TabIndex = 1;
            this.labelDayRevenue.Text = "Day Revenue:";
            // 
            // labelDay
            // 
            this.labelDay.AutoSize = true;
            this.labelDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.labelDay.Location = new System.Drawing.Point(10, 3);
            this.labelDay.Name = "labelDay";
            this.labelDay.Size = new System.Drawing.Size(60, 29);
            this.labelDay.TabIndex = 0;
            this.labelDay.Text = "Day:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 234);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(665, 141);
            this.dataGridView1.TabIndex = 4;
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.White;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonAdd.Location = new System.Drawing.Point(708, 234);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(78, 38);
            this.buttonAdd.TabIndex = 8;
            this.buttonAdd.Text = "ADD";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // labelWDRestaurant
            // 
            this.labelWDRestaurant.AutoSize = true;
            this.labelWDRestaurant.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic);
            this.labelWDRestaurant.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.labelWDRestaurant.Location = new System.Drawing.Point(512, 9);
            this.labelWDRestaurant.Name = "labelWDRestaurant";
            this.labelWDRestaurant.Size = new System.Drawing.Size(314, 29);
            this.labelWDRestaurant.TabIndex = 1;
            this.labelWDRestaurant.Text = "Wedding Restaurant HALTT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(840, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(832, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 20);
            this.label6.TabIndex = 72;
            this.label6.Text = "X";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.White;
            this.btn_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btn_delete.Location = new System.Drawing.Point(708, 337);
            this.btn_delete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(78, 38);
            this.btn_delete.TabIndex = 73;
            this.btn_delete.Text = "DELETE";
            this.btn_delete.UseVisualStyleBackColor = false;
            // 
            // btn_update
            // 
            this.btn_update.BackColor = System.Drawing.Color.White;
            this.btn_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btn_update.Location = new System.Drawing.Point(708, 287);
            this.btn_update.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(78, 38);
            this.btn_update.TabIndex = 74;
            this.btn_update.Text = "UPDATE";
            this.btn_update.UseVisualStyleBackColor = false;
            // 
            // ReportDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 375);
            this.Controls.Add(this.label1);
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(862, 385);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelWDRestaurant);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panelAll);
            this.Controls.Add(this.labelRReport);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximumSize = new System.Drawing.Size(862, 385);
            this.Name = "ReportDay";
            this.Text = "ReportDay";
            this.Load += new System.EventHandler(this.ReportDay_Load);
            this.panelAll.ResumeLayout(false);
            this.panelAll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRReport;
        private System.Windows.Forms.Panel panelAll;
        private System.Windows.Forms.TextBox textBoxAOW;
        private System.Windows.Forms.TextBox textBoxYear;
        private System.Windows.Forms.Label labelAOW;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.TextBox textBoxDayRevenue;
        private System.Windows.Forms.ComboBox comboBoxDay;
        private System.Windows.Forms.Label labelDayRevenue;
        private System.Windows.Forms.Label labelDay;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label labelWDRestaurant;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.Label labelmonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_update;
    }
}
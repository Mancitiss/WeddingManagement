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
            this.labelDay = new System.Windows.Forms.Label();
            this.labelDayRevenue = new System.Windows.Forms.Label();
            this.comboBoxDay = new System.Windows.Forms.ComboBox();
            this.textBoxDayRevenue = new System.Windows.Forms.TextBox();
            this.labelRatio = new System.Windows.Forms.Label();
            this.labelAOW = new System.Windows.Forms.Label();
            this.textBoxRatio = new System.Windows.Forms.TextBox();
            this.textBoxAOW = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.ButtonUpdate = new System.Windows.Forms.Button();
            this.ButtonSAVE = new System.Windows.Forms.Button();
            this.buttonEXIT = new System.Windows.Forms.Button();
            this.labelWDRestaurant = new System.Windows.Forms.Label();
            this.panelAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelRReport
            // 
            this.labelRReport.AutoSize = true;
            this.labelRReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold);
            this.labelRReport.ForeColor = System.Drawing.Color.Firebrick;
            this.labelRReport.Location = new System.Drawing.Point(149, 42);
            this.labelRReport.Name = "labelRReport";
            this.labelRReport.Size = new System.Drawing.Size(487, 39);
            this.labelRReport.TabIndex = 2;
            this.labelRReport.Text = "REVENUE REPORT DETAIL";
            // 
            // panelAll
            // 
            this.panelAll.Controls.Add(this.textBoxAOW);
            this.panelAll.Controls.Add(this.textBoxRatio);
            this.panelAll.Controls.Add(this.labelAOW);
            this.panelAll.Controls.Add(this.labelRatio);
            this.panelAll.Controls.Add(this.textBoxDayRevenue);
            this.panelAll.Controls.Add(this.comboBoxDay);
            this.panelAll.Controls.Add(this.labelDayRevenue);
            this.panelAll.Controls.Add(this.labelDay);
            this.panelAll.Location = new System.Drawing.Point(10, 102);
            this.panelAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelAll.Name = "panelAll";
            this.panelAll.Size = new System.Drawing.Size(780, 64);
            this.panelAll.TabIndex = 3;
            // 
            // labelDay
            // 
            this.labelDay.AutoSize = true;
            this.labelDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.labelDay.Location = new System.Drawing.Point(10, 3);
            this.labelDay.Name = "labelDay";
            this.labelDay.Size = new System.Drawing.Size(47, 24);
            this.labelDay.TabIndex = 0;
            this.labelDay.Text = "Day:";
            // 
            // labelDayRevenue
            // 
            this.labelDayRevenue.AutoSize = true;
            this.labelDayRevenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.labelDayRevenue.Location = new System.Drawing.Point(10, 34);
            this.labelDayRevenue.Name = "labelDayRevenue";
            this.labelDayRevenue.Size = new System.Drawing.Size(129, 24);
            this.labelDayRevenue.TabIndex = 1;
            this.labelDayRevenue.Text = "Day Revenue:";
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
            this.comboBoxDay.Size = new System.Drawing.Size(110, 23);
            this.comboBoxDay.TabIndex = 8;
            // 
            // textBoxDayRevenue
            // 
            this.textBoxDayRevenue.Location = new System.Drawing.Point(182, 34);
            this.textBoxDayRevenue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxDayRevenue.Name = "textBoxDayRevenue";
            this.textBoxDayRevenue.Size = new System.Drawing.Size(110, 23);
            this.textBoxDayRevenue.TabIndex = 3;
            // 
            // labelRatio
            // 
            this.labelRatio.AutoSize = true;
            this.labelRatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.labelRatio.Location = new System.Drawing.Point(549, 4);
            this.labelRatio.Name = "labelRatio";
            this.labelRatio.Size = new System.Drawing.Size(57, 24);
            this.labelRatio.TabIndex = 4;
            this.labelRatio.Text = "Ratio:";
            // 
            // labelAOW
            // 
            this.labelAOW.AutoSize = true;
            this.labelAOW.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.labelAOW.Location = new System.Drawing.Point(420, 34);
            this.labelAOW.Name = "labelAOW";
            this.labelAOW.Size = new System.Drawing.Size(187, 24);
            this.labelAOW.TabIndex = 5;
            this.labelAOW.Text = "Amount Of Wedding:";
            // 
            // textBoxRatio
            // 
            this.textBoxRatio.Location = new System.Drawing.Point(652, 3);
            this.textBoxRatio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxRatio.Name = "textBoxRatio";
            this.textBoxRatio.Size = new System.Drawing.Size(110, 23);
            this.textBoxRatio.TabIndex = 6;
            // 
            // textBoxAOW
            // 
            this.textBoxAOW.Location = new System.Drawing.Point(652, 34);
            this.textBoxAOW.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxAOW.Name = "textBoxAOW";
            this.textBoxAOW.Size = new System.Drawing.Size(110, 23);
            this.textBoxAOW.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 181);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(665, 141);
            this.dataGridView1.TabIndex = 4;
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.Silver;
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonDelete.Location = new System.Drawing.Point(685, 200);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(62, 25);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = false;
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.Silver;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonAdd.Location = new System.Drawing.Point(685, 235);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(62, 25);
            this.buttonAdd.TabIndex = 8;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = false;
            // 
            // ButtonUpdate
            // 
            this.ButtonUpdate.BackColor = System.Drawing.Color.Silver;
            this.ButtonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ButtonUpdate.Location = new System.Drawing.Point(685, 274);
            this.ButtonUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonUpdate.Name = "ButtonUpdate";
            this.ButtonUpdate.Size = new System.Drawing.Size(62, 25);
            this.ButtonUpdate.TabIndex = 9;
            this.ButtonUpdate.Text = "Update";
            this.ButtonUpdate.UseVisualStyleBackColor = false;
            // 
            // ButtonSAVE
            // 
            this.ButtonSAVE.BackColor = System.Drawing.Color.Yellow;
            this.ButtonSAVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.ButtonSAVE.Location = new System.Drawing.Point(593, 337);
            this.ButtonSAVE.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonSAVE.Name = "ButtonSAVE";
            this.ButtonSAVE.Size = new System.Drawing.Size(82, 25);
            this.ButtonSAVE.TabIndex = 10;
            this.ButtonSAVE.Text = "SAVE";
            this.ButtonSAVE.UseVisualStyleBackColor = false;
            // 
            // buttonEXIT
            // 
            this.buttonEXIT.BackColor = System.Drawing.Color.Red;
            this.buttonEXIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.buttonEXIT.Location = new System.Drawing.Point(711, 337);
            this.buttonEXIT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEXIT.Name = "buttonEXIT";
            this.buttonEXIT.Size = new System.Drawing.Size(82, 25);
            this.buttonEXIT.TabIndex = 11;
            this.buttonEXIT.Text = "EXIT";
            this.buttonEXIT.UseVisualStyleBackColor = false;
            // 
            // labelWDRestaurant
            // 
            this.labelWDRestaurant.AutoSize = true;
            this.labelWDRestaurant.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic);
            this.labelWDRestaurant.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.labelWDRestaurant.Location = new System.Drawing.Point(616, 0);
            this.labelWDRestaurant.Name = "labelWDRestaurant";
            this.labelWDRestaurant.Size = new System.Drawing.Size(247, 24);
            this.labelWDRestaurant.TabIndex = 1;
            this.labelWDRestaurant.Text = "Wedding Restaurant HALTT";
            // 
            // ReportDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 368);
            this.Controls.Add(this.labelWDRestaurant);
            this.Controls.Add(this.buttonEXIT);
            this.Controls.Add(this.ButtonSAVE);
            this.Controls.Add(this.ButtonUpdate);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panelAll);
            this.Controls.Add(this.labelRReport);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ReportDay";
            this.Text = "ReportDay";
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
        private System.Windows.Forms.TextBox textBoxRatio;
        private System.Windows.Forms.Label labelAOW;
        private System.Windows.Forms.Label labelRatio;
        private System.Windows.Forms.TextBox textBoxDayRevenue;
        private System.Windows.Forms.ComboBox comboBoxDay;
        private System.Windows.Forms.Label labelDayRevenue;
        private System.Windows.Forms.Label labelDay;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button ButtonUpdate;
        private System.Windows.Forms.Button ButtonSAVE;
        private System.Windows.Forms.Button buttonEXIT;
        private System.Windows.Forms.Label labelWDRestaurant;
    }
}
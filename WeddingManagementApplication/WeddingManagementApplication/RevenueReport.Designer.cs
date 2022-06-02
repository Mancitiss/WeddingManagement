namespace WeddingManagementApplication
{
    partial class RevenueReport
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
            this.panel4khung = new System.Windows.Forms.Panel();
            this.labelMonth = new System.Windows.Forms.Label();
            this.labelRTotal = new System.Windows.Forms.Label();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.textBoxRTotal = new System.Windows.Forms.TextBox();
            this.labelYear = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBoxMadeBy = new System.Windows.Forms.ComboBox();
            this.labelMadeBy = new System.Windows.Forms.Label();
            this.dataGridViewRReport = new System.Windows.Forms.DataGridView();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel4khung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRReport)).BeginInit();
            this.SuspendLayout();
            // 
            // labelRReport
            // 
            this.labelRReport.AutoSize = true;
            this.labelRReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold);
            this.labelRReport.ForeColor = System.Drawing.Color.Firebrick;
            this.labelRReport.Location = new System.Drawing.Point(216, 28);
            this.labelRReport.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRReport.Name = "labelRReport";
            this.labelRReport.Size = new System.Drawing.Size(351, 39);
            this.labelRReport.TabIndex = 0;
            this.labelRReport.Text = "REVENUE REPORT";
            // 
            // panel4khung
            // 
            this.panel4khung.Controls.Add(this.labelMadeBy);
            this.panel4khung.Controls.Add(this.comboBoxMadeBy);
            this.panel4khung.Controls.Add(this.textBox1);
            this.panel4khung.Controls.Add(this.labelYear);
            this.panel4khung.Controls.Add(this.textBoxRTotal);
            this.panel4khung.Controls.Add(this.comboBoxMonth);
            this.panel4khung.Controls.Add(this.labelRTotal);
            this.panel4khung.Controls.Add(this.labelMonth);
            this.panel4khung.Location = new System.Drawing.Point(34, 74);
            this.panel4khung.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4khung.Name = "panel4khung";
            this.panel4khung.Size = new System.Drawing.Size(679, 64);
            this.panel4khung.TabIndex = 2;
            // 
            // labelMonth
            // 
            this.labelMonth.AutoSize = true;
            this.labelMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.labelMonth.Location = new System.Drawing.Point(68, 2);
            this.labelMonth.Name = "labelMonth";
            this.labelMonth.Size = new System.Drawing.Size(68, 24);
            this.labelMonth.TabIndex = 0;
            this.labelMonth.Text = "Month:";
            // 
            // labelRTotal
            // 
            this.labelRTotal.AutoSize = true;
            this.labelRTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.labelRTotal.Location = new System.Drawing.Point(3, 37);
            this.labelRTotal.Name = "labelRTotal";
            this.labelRTotal.Size = new System.Drawing.Size(138, 24);
            this.labelRTotal.TabIndex = 1;
            this.labelRTotal.Text = "Revenue Total:";
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMonth.DropDownWidth = 133;
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.Items.AddRange(new object[] {
            "Jan",
            "Feb",
            "Mar",
            "Apr",
            "May",
            "Jun ",
            "Jul",
            "Aug",
            "Sep",
            "Oct",
            "Nov",
            "Dec"});
            this.comboBoxMonth.Location = new System.Drawing.Point(189, 2);
            this.comboBoxMonth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(133, 23);
            this.comboBoxMonth.TabIndex = 6;
            // 
            // textBoxRTotal
            // 
            this.textBoxRTotal.Location = new System.Drawing.Point(189, 37);
            this.textBoxRTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxRTotal.Name = "textBoxRTotal";
            this.textBoxRTotal.Size = new System.Drawing.Size(133, 23);
            this.textBoxRTotal.TabIndex = 3;
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.labelYear.Location = new System.Drawing.Point(427, 2);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(54, 24);
            this.labelYear.TabIndex = 4;
            this.labelYear.Text = "Year:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(544, 2);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(133, 23);
            this.textBox1.TabIndex = 7;
            // 
            // comboBoxMadeBy
            // 
            this.comboBoxMadeBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxMadeBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxMadeBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMadeBy.DropDownWidth = 133;
            this.comboBoxMadeBy.FormattingEnabled = true;
            this.comboBoxMadeBy.Items.AddRange(new object[] {
            "Jan",
            "Feb",
            "Mar",
            "Apr",
            "May",
            "Jun ",
            "Jul",
            "Aug",
            "Sep",
            "Oct",
            "Nov",
            "Dec"});
            this.comboBoxMadeBy.Location = new System.Drawing.Point(543, 37);
            this.comboBoxMadeBy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxMadeBy.Name = "comboBoxMadeBy";
            this.comboBoxMadeBy.Size = new System.Drawing.Size(133, 23);
            this.comboBoxMadeBy.TabIndex = 8;
            // 
            // labelMadeBy
            // 
            this.labelMadeBy.AutoSize = true;
            this.labelMadeBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.labelMadeBy.Location = new System.Drawing.Point(394, 37);
            this.labelMadeBy.Name = "labelMadeBy";
            this.labelMadeBy.Size = new System.Drawing.Size(88, 24);
            this.labelMadeBy.TabIndex = 8;
            this.labelMadeBy.Text = "Made by:";
            // 
            // dataGridViewRReport
            // 
            this.dataGridViewRReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRReport.Location = new System.Drawing.Point(10, 154);
            this.dataGridViewRReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewRReport.Name = "dataGridViewRReport";
            this.dataGridViewRReport.RowHeadersWidth = 51;
            this.dataGridViewRReport.Size = new System.Drawing.Size(647, 141);
            this.dataGridViewRReport.TabIndex = 3;
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.DarkGray;
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonDelete.Location = new System.Drawing.Point(682, 175);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(61, 25);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkGray;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button1.Location = new System.Drawing.Point(683, 210);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 25);
            this.button1.TabIndex = 7;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkGray;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button2.Location = new System.Drawing.Point(682, 246);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 25);
            this.button2.TabIndex = 8;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.Yellow;
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.buttonSave.Location = new System.Drawing.Point(573, 309);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(82, 25);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "SAVE";
            this.buttonSave.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Red;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.button3.Location = new System.Drawing.Point(682, 309);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(82, 25);
            this.button3.TabIndex = 10;
            this.button3.Text = "EXIT";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // RevenueReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(821, 340);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.dataGridViewRReport);
            this.Controls.Add(this.panel4khung);
            this.Controls.Add(this.labelRReport);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "RevenueReport";
            this.Text = "RevenueReport";
            this.panel4khung.ResumeLayout(false);
            this.panel4khung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRReport;
        private System.Windows.Forms.Panel panel4khung;
        private System.Windows.Forms.Label labelMadeBy;
        private System.Windows.Forms.ComboBox comboBoxMadeBy;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.TextBox textBoxRTotal;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.Label labelRTotal;
        private System.Windows.Forms.Label labelMonth;
        private System.Windows.Forms.DataGridView dataGridViewRReport;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button button3;
    }
}
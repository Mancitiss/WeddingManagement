using System.Threading;
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelYear = new System.Windows.Forms.Label();
            this.textBoxRTotal = new System.Windows.Forms.TextBox();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.labelRTotal = new System.Windows.Forms.Label();
            this.labelMonth = new System.Windows.Forms.Label();
            this.dataGridViewRReport = new System.Windows.Forms.DataGridView();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.labelWDRestaurant = new System.Windows.Forms.Label();
            this.img_close_service = new System.Windows.Forms.Label();
            this.btn_update = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRReport)).BeginInit();
            this.SuspendLayout();
            // 
            // labelRReport
            // 
            this.labelRReport.AutoSize = true;
            this.labelRReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold);
            this.labelRReport.ForeColor = System.Drawing.Color.Firebrick;
            this.labelRReport.Location = new System.Drawing.Point(189, 49);
            this.labelRReport.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRReport.Name = "labelRReport";
            this.labelRReport.Size = new System.Drawing.Size(435, 51);
            this.labelRReport.TabIndex = 0;
            this.labelRReport.Text = "REVENUE REPORT";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(332, 120);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(133, 27);
            this.textBox1.TabIndex = 7;
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.labelYear.Location = new System.Drawing.Point(256, 120);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(70, 29);
            this.labelYear.TabIndex = 4;
            this.labelYear.Text = "Year:";
            // 
            // textBoxRTotal
            // 
            this.textBoxRTotal.Location = new System.Drawing.Point(667, 118);
            this.textBoxRTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxRTotal.Name = "textBoxRTotal";
            this.textBoxRTotal.ReadOnly = true;
            this.textBoxRTotal.Size = new System.Drawing.Size(133, 27);
            this.textBoxRTotal.TabIndex = 3;
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMonth.DropDownWidth = 133;
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
            this.comboBoxMonth.Location = new System.Drawing.Point(103, 120);
            this.comboBoxMonth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(133, 28);
            this.comboBoxMonth.TabIndex = 6;
            // 
            // labelRTotal
            // 
            this.labelRTotal.AutoSize = true;
            this.labelRTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.labelRTotal.Location = new System.Drawing.Point(481, 118);
            this.labelRTotal.Name = "labelRTotal";
            this.labelRTotal.Size = new System.Drawing.Size(176, 29);
            this.labelRTotal.TabIndex = 1;
            this.labelRTotal.Text = "Revenue Total:";
            // 
            // labelMonth
            // 
            this.labelMonth.AutoSize = true;
            this.labelMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.labelMonth.Location = new System.Drawing.Point(12, 120);
            this.labelMonth.Name = "labelMonth";
            this.labelMonth.Size = new System.Drawing.Size(85, 29);
            this.labelMonth.TabIndex = 0;
            this.labelMonth.Text = "Month:";
            // 
            // dataGridViewRReport
            // 
            this.dataGridViewRReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRReport.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dataGridViewRReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRReport.Location = new System.Drawing.Point(17, 172);
            this.dataGridViewRReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewRReport.Name = "dataGridViewRReport";
            this.dataGridViewRReport.RowHeadersWidth = 51;
            this.dataGridViewRReport.Size = new System.Drawing.Size(647, 207);
            this.dataGridViewRReport.TabIndex = 3;
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.Transparent;
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonDelete.Location = new System.Drawing.Point(692, 312);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(80, 35);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "DELETE";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button1.Location = new System.Drawing.Point(692, 206);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 35);
            this.button1.TabIndex = 7;
            this.button1.Text = "ADD";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelWDRestaurant
            // 
            this.labelWDRestaurant.AutoSize = true;
            this.labelWDRestaurant.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic);
            this.labelWDRestaurant.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.labelWDRestaurant.Location = new System.Drawing.Point(471, 9);
            this.labelWDRestaurant.Name = "labelWDRestaurant";
            this.labelWDRestaurant.Size = new System.Drawing.Size(314, 29);
            this.labelWDRestaurant.TabIndex = 1;
            this.labelWDRestaurant.Text = "Wedding Restaurant HALTT";
            // 
            // img_close_service
            // 
            this.img_close_service.AutoSize = true;
            this.img_close_service.Location = new System.Drawing.Point(791, 9);
            this.img_close_service.Name = "img_close_service";
            this.img_close_service.Size = new System.Drawing.Size(18, 20);
            this.img_close_service.TabIndex = 88;
            this.img_close_service.Text = "X";
            this.img_close_service.Click += new System.EventHandler(this.img_close_service_Click);
            // 
            // btn_update
            // 
            this.btn_update.BackColor = System.Drawing.Color.Transparent;
            this.btn_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btn_update.Location = new System.Drawing.Point(692, 260);
            this.btn_update.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(80, 35);
            this.btn_update.TabIndex = 89;
            this.btn_update.Text = "UPDATE";
            this.btn_update.UseVisualStyleBackColor = false;
            // 
            // RevenueReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(821, 390);
            this.Controls.Add(this.textBoxRTotal);
            this.Controls.Add(this.labelRTotal);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBoxMonth);
            this.Controls.Add(this.labelYear);
            this.Controls.Add(this.labelMonth);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.img_close_service);
            this.Controls.Add(this.labelWDRestaurant);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.dataGridViewRReport);
            this.Controls.Add(this.labelRReport);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximumSize = new System.Drawing.Size(821, 390);
            this.Name = "RevenueReport";
            this.Text = "RevenueReport";
            this.Load += new System.EventHandler(this.RevenueReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRReport;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.TextBox textBoxRTotal;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.Label labelRTotal;
        private System.Windows.Forms.Label labelMonth;
        private System.Windows.Forms.DataGridView dataGridViewRReport;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelWDRestaurant;
        private System.Windows.Forms.Label img_close_service;
        private System.Windows.Forms.Button btn_update;
    }
}
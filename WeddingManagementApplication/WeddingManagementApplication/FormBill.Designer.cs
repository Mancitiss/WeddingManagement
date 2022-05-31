
namespace WeddingManagementApplication
{
    partial class FormBill
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
            this.label_tittle_bill = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label_invoice_date = new System.Windows.Forms.Label();
            this.label_service_price = new System.Windows.Forms.Label();
            this.label_money_left = new System.Windows.Forms.Label();
            this.label_payment_date = new System.Windows.Forms.Label();
            this.label_total = new System.Windows.Forms.Label();
            this.label_table_total_price = new System.Windows.Forms.Label();
            this.label_rule_fl = new System.Windows.Forms.Label();
            this.label_penalty_rate = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.customBorderTextBox5 = new WeddingManagementApplication.CustomeBorderTextbox();
            this.tb_lobby_price = new WeddingManagementApplication.CustomeBorderTextbox();
            this.customBorderTextBox3 = new WeddingManagementApplication.CustomeBorderTextbox();
            this.customBorderTextBox2 = new WeddingManagementApplication.CustomeBorderTextbox();
            this.customBorderTextBox1 = new WeddingManagementApplication.CustomeBorderTextbox();
            this.btn_save = new System.Windows.Forms.Button();
            this.rBtn_yes = new System.Windows.Forms.RadioButton();
            this.rBtn_no = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_representative = new WeddingManagementApplication.CustomeBorderTextbox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbb_staff = new System.Windows.Forms.ComboBox();
            this.tb_phone = new WeddingManagementApplication.CustomeBorderTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_detail = new System.Windows.Forms.Button();
            this.tb_total = new WeddingManagementApplication.CustomeBorderTextbox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label_tittle_bill
            // 
            this.label_tittle_bill.AutoSize = true;
            this.label_tittle_bill.Font = new System.Drawing.Font("Segoe Print", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tittle_bill.ForeColor = System.Drawing.Color.Crimson;
            this.label_tittle_bill.Location = new System.Drawing.Point(446, 0);
            this.label_tittle_bill.Margin = new System.Windows.Forms.Padding(0);
            this.label_tittle_bill.Name = "label_tittle_bill";
            this.label_tittle_bill.Size = new System.Drawing.Size(104, 54);
            this.label_tittle_bill.TabIndex = 19;
            this.label_tittle_bill.Text = "BILL ";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(750, 41);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(113, 22);
            this.dateTimePicker1.TabIndex = 21;
            // 
            // label_invoice_date
            // 
            this.label_invoice_date.AutoSize = true;
            this.label_invoice_date.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_invoice_date.ForeColor = System.Drawing.Color.Crimson;
            this.label_invoice_date.Location = new System.Drawing.Point(623, 40);
            this.label_invoice_date.Name = "label_invoice_date";
            this.label_invoice_date.Size = new System.Drawing.Size(112, 23);
            this.label_invoice_date.TabIndex = 22;
            this.label_invoice_date.Text = "Invoice date:";
            // 
            // label_service_price
            // 
            this.label_service_price.AutoSize = true;
            this.label_service_price.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_service_price.ForeColor = System.Drawing.Color.Crimson;
            this.label_service_price.Location = new System.Drawing.Point(10, 73);
            this.label_service_price.Name = "label_service_price";
            this.label_service_price.Size = new System.Drawing.Size(161, 23);
            this.label_service_price.TabIndex = 28;
            this.label_service_price.Text = "Service total price:";
            // 
            // label_money_left
            // 
            this.label_money_left.AutoSize = true;
            this.label_money_left.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_money_left.ForeColor = System.Drawing.Color.Crimson;
            this.label_money_left.Location = new System.Drawing.Point(318, 113);
            this.label_money_left.Name = "label_money_left";
            this.label_money_left.Size = new System.Drawing.Size(102, 23);
            this.label_money_left.TabIndex = 29;
            this.label_money_left.Text = "Money left:";
            // 
            // label_payment_date
            // 
            this.label_payment_date.AutoSize = true;
            this.label_payment_date.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_payment_date.ForeColor = System.Drawing.Color.Crimson;
            this.label_payment_date.Location = new System.Drawing.Point(318, 73);
            this.label_payment_date.Name = "label_payment_date";
            this.label_payment_date.Size = new System.Drawing.Size(126, 23);
            this.label_payment_date.TabIndex = 30;
            this.label_payment_date.Text = "Payment date:";
            // 
            // label_total
            // 
            this.label_total.AutoSize = true;
            this.label_total.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_total.ForeColor = System.Drawing.Color.Crimson;
            this.label_total.Location = new System.Drawing.Point(11, 113);
            this.label_total.Name = "label_total";
            this.label_total.Size = new System.Drawing.Size(103, 23);
            this.label_total.TabIndex = 31;
            this.label_total.Text = "Lobby rent:";
            // 
            // label_table_total_price
            // 
            this.label_table_total_price.AutoSize = true;
            this.label_table_total_price.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_table_total_price.ForeColor = System.Drawing.Color.Crimson;
            this.label_table_total_price.Location = new System.Drawing.Point(10, 33);
            this.label_table_total_price.Name = "label_table_total_price";
            this.label_table_total_price.Size = new System.Drawing.Size(146, 23);
            this.label_table_total_price.TabIndex = 32;
            this.label_table_total_price.Text = "Table Total Price:";
            // 
            // label_rule_fl
            // 
            this.label_rule_fl.AutoSize = true;
            this.label_rule_fl.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_rule_fl.ForeColor = System.Drawing.Color.Crimson;
            this.label_rule_fl.Location = new System.Drawing.Point(763, 281);
            this.label_rule_fl.Name = "label_rule_fl";
            this.label_rule_fl.Size = new System.Drawing.Size(134, 23);
            this.label_rule_fl.TabIndex = 35;
            this.label_rule_fl.Text = "Rules following";
            // 
            // label_penalty_rate
            // 
            this.label_penalty_rate.AutoSize = true;
            this.label_penalty_rate.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_penalty_rate.ForeColor = System.Drawing.Color.Crimson;
            this.label_penalty_rate.Location = new System.Drawing.Point(743, 243);
            this.label_penalty_rate.Name = "label_penalty_rate";
            this.label_penalty_rate.Size = new System.Drawing.Size(110, 23);
            this.label_penalty_rate.TabIndex = 36;
            this.label_penalty_rate.Text = "Penalty rate:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(452, 76);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(121, 22);
            this.dateTimePicker2.TabIndex = 35;
            // 
            // customBorderTextBox5
            // 
            this.customBorderTextBox5.Location = new System.Drawing.Point(173, 76);
            this.customBorderTextBox5.Name = "customBorderTextBox5";
            this.customBorderTextBox5.ReadOnly = true;
            this.customBorderTextBox5.Size = new System.Drawing.Size(126, 22);
            this.customBorderTextBox5.TabIndex = 27;
            // 
            // tb_lobby_price
            // 
            this.tb_lobby_price.Location = new System.Drawing.Point(173, 115);
            this.tb_lobby_price.Name = "tb_lobby_price";
            this.tb_lobby_price.ReadOnly = true;
            this.tb_lobby_price.Size = new System.Drawing.Size(126, 22);
            this.tb_lobby_price.TabIndex = 33;
            // 
            // customBorderTextBox3
            // 
            this.customBorderTextBox3.Location = new System.Drawing.Point(452, 115);
            this.customBorderTextBox3.Name = "customBorderTextBox3";
            this.customBorderTextBox3.ReadOnly = true;
            this.customBorderTextBox3.Size = new System.Drawing.Size(121, 22);
            this.customBorderTextBox3.TabIndex = 25;
            // 
            // customBorderTextBox2
            // 
            this.customBorderTextBox2.Location = new System.Drawing.Point(173, 35);
            this.customBorderTextBox2.Name = "customBorderTextBox2";
            this.customBorderTextBox2.ReadOnly = true;
            this.customBorderTextBox2.Size = new System.Drawing.Size(126, 22);
            this.customBorderTextBox2.TabIndex = 24;
            // 
            // customBorderTextBox1
            // 
            this.customBorderTextBox1.Location = new System.Drawing.Point(862, 243);
            this.customBorderTextBox1.Name = "customBorderTextBox1";
            this.customBorderTextBox1.ReadOnly = true;
            this.customBorderTextBox1.Size = new System.Drawing.Size(72, 22);
            this.customBorderTextBox1.TabIndex = 23;
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_save.Location = new System.Drawing.Point(710, 336);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(245, 39);
            this.btn_save.TabIndex = 57;
            this.btn_save.Text = "SAVE INVOICE";
            this.btn_save.UseVisualStyleBackColor = false;
            // 
            // rBtn_yes
            // 
            this.rBtn_yes.AutoSize = true;
            this.rBtn_yes.Location = new System.Drawing.Point(772, 309);
            this.rBtn_yes.Name = "rBtn_yes";
            this.rBtn_yes.Size = new System.Drawing.Size(53, 21);
            this.rBtn_yes.TabIndex = 37;
            this.rBtn_yes.TabStop = true;
            this.rBtn_yes.Text = "Yes";
            this.rBtn_yes.UseVisualStyleBackColor = true;
            // 
            // rBtn_no
            // 
            this.rBtn_no.AutoSize = true;
            this.rBtn_no.Location = new System.Drawing.Point(843, 309);
            this.rBtn_no.Name = "rBtn_no";
            this.rBtn_no.Size = new System.Drawing.Size(47, 21);
            this.rBtn_no.TabIndex = 38;
            this.rBtn_no.TabStop = true;
            this.rBtn_no.Text = "No";
            this.rBtn_no.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_representative);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbb_staff);
            this.groupBox1.Controls.Add(this.tb_phone);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 159);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information";
            // 
            // tb_representative
            // 
            this.tb_representative.Location = new System.Drawing.Point(148, 75);
            this.tb_representative.Name = "tb_representative";
            this.tb_representative.ReadOnly = true;
            this.tb_representative.Size = new System.Drawing.Size(181, 22);
            this.tb_representative.TabIndex = 51;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Crimson;
            this.label3.Location = new System.Drawing.Point(13, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 23);
            this.label3.TabIndex = 50;
            this.label3.Text = "Representative";
            // 
            // cbb_staff
            // 
            this.cbb_staff.FormattingEnabled = true;
            this.cbb_staff.Location = new System.Drawing.Point(107, 34);
            this.cbb_staff.Name = "cbb_staff";
            this.cbb_staff.Size = new System.Drawing.Size(222, 24);
            this.cbb_staff.TabIndex = 49;
            // 
            // tb_phone
            // 
            this.tb_phone.Location = new System.Drawing.Point(148, 118);
            this.tb_phone.Name = "tb_phone";
            this.tb_phone.ReadOnly = true;
            this.tb_phone.Size = new System.Drawing.Size(181, 22);
            this.tb_phone.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(13, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 23);
            this.label2.TabIndex = 47;
            this.label2.Text = "Phone number:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(16, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 23);
            this.label1.TabIndex = 46;
            this.label1.Text = "Made by:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_total);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.customBorderTextBox5);
            this.groupBox2.Controls.Add(this.label_service_price);
            this.groupBox2.Controls.Add(this.label_table_total_price);
            this.groupBox2.Controls.Add(this.customBorderTextBox2);
            this.groupBox2.Controls.Add(this.tb_lobby_price);
            this.groupBox2.Controls.Add(this.label_total);
            this.groupBox2.Controls.Add(this.label_payment_date);
            this.groupBox2.Controls.Add(this.label_money_left);
            this.groupBox2.Controls.Add(this.dateTimePicker2);
            this.groupBox2.Controls.Add(this.customBorderTextBox3);
            this.groupBox2.Location = new System.Drawing.Point(362, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(593, 159);
            this.groupBox2.TabIndex = 61;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Payment";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Location = new System.Drawing.Point(12, 239);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(337, 187);
            this.groupBox3.TabIndex = 62;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dishes";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(331, 160);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView2);
            this.groupBox4.Location = new System.Drawing.Point(362, 239);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(337, 187);
            this.groupBox4.TabIndex = 63;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Service";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 21);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(331, 160);
            this.dataGridView2.TabIndex = 0;
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_exit.Location = new System.Drawing.Point(842, 381);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(85, 39);
            this.btn_exit.TabIndex = 64;
            this.btn_exit.Text = "EXIT";
            this.btn_exit.UseVisualStyleBackColor = false;
            // 
            // btn_detail
            // 
            this.btn_detail.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_detail.Location = new System.Drawing.Point(751, 381);
            this.btn_detail.Name = "btn_detail";
            this.btn_detail.Size = new System.Drawing.Size(85, 39);
            this.btn_detail.TabIndex = 65;
            this.btn_detail.Text = "DETAIL";
            this.btn_detail.UseVisualStyleBackColor = false;
            // 
            // tb_total
            // 
            this.tb_total.Location = new System.Drawing.Point(452, 37);
            this.tb_total.Name = "tb_total";
            this.tb_total.ReadOnly = true;
            this.tb_total.Size = new System.Drawing.Size(121, 22);
            this.tb_total.TabIndex = 66;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Crimson;
            this.label4.Location = new System.Drawing.Point(318, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 23);
            this.label4.TabIndex = 67;
            this.label4.Text = "Total:";
            // 
            // FormBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(204)))), ((int)(((byte)(176)))));
            this.ClientSize = new System.Drawing.Size(974, 441);
            this.Controls.Add(this.btn_detail);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.customBorderTextBox1);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label_tittle_bill);
            this.Controls.Add(this.label_invoice_date);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label_penalty_rate);
            this.Controls.Add(this.rBtn_no);
            this.Controls.Add(this.rBtn_yes);
            this.Controls.Add(this.label_rule_fl);
            this.Name = "FormBill";
            this.Text = "Bill";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_tittle_bill;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label_invoice_date;
        private CustomeBorderTextbox customBorderTextBox1;
        private CustomeBorderTextbox customBorderTextBox2;
        private CustomeBorderTextbox customBorderTextBox3;
        private CustomeBorderTextbox customBorderTextBox5;
        private System.Windows.Forms.Label label_service_price;
        private System.Windows.Forms.Label label_money_left;
        private System.Windows.Forms.Label label_payment_date;
        private System.Windows.Forms.Label label_total;
        private System.Windows.Forms.Label label_table_total_price;
        private CustomeBorderTextbox tb_lobby_price;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label_rule_fl;
        private System.Windows.Forms.Label label_penalty_rate;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.RadioButton rBtn_no;
        private System.Windows.Forms.RadioButton rBtn_yes;
        private System.Windows.Forms.GroupBox groupBox1;
        private CustomeBorderTextbox tb_representative;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbb_staff;
        private CustomeBorderTextbox tb_phone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_detail;
        private CustomeBorderTextbox tb_total;
        private System.Windows.Forms.Label label4;
    }
}
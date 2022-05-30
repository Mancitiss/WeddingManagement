
namespace Test
{
    partial class Bill
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_rule_fl = new System.Windows.Forms.Label();
            this.checkBox_no = new System.Windows.Forms.CheckBox();
            this.checkBox_yes = new System.Windows.Forms.CheckBox();
            this.label_penalty_rate = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.customBorderTextBox5 = new Test.CustomBorderTextBox();
            this.customBorderTextBox6 = new Test.CustomBorderTextBox();
            this.customBorderTextBox3 = new Test.CustomBorderTextBox();
            this.customBorderTextBox2 = new Test.CustomBorderTextBox();
            this.customBorderTextBox1 = new Test.CustomBorderTextBox();
            this.btn_delete_bill = new System.Windows.Forms.Button();
            this.btn_update_bill = new System.Windows.Forms.Button();
            this.btn_add_bill = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_tittle_bill
            // 
            this.label_tittle_bill.AutoSize = true;
            this.label_tittle_bill.Font = new System.Drawing.Font("Segoe Print", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tittle_bill.ForeColor = System.Drawing.Color.Crimson;
            this.label_tittle_bill.Location = new System.Drawing.Point(351, 9);
            this.label_tittle_bill.Margin = new System.Windows.Forms.Padding(0);
            this.label_tittle_bill.Name = "label_tittle_bill";
            this.label_tittle_bill.Size = new System.Drawing.Size(104, 54);
            this.label_tittle_bill.TabIndex = 19;
            this.label_tittle_bill.Text = "BILL ";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(637, 14);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(113, 22);
            this.dateTimePicker1.TabIndex = 21;
            // 
            // label_invoice_date
            // 
            this.label_invoice_date.AutoSize = true;
            this.label_invoice_date.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_invoice_date.ForeColor = System.Drawing.Color.Crimson;
            this.label_invoice_date.Location = new System.Drawing.Point(510, 13);
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
            this.label_service_price.Location = new System.Drawing.Point(9, 97);
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
            this.label_money_left.Location = new System.Drawing.Point(331, 97);
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
            this.label_payment_date.Location = new System.Drawing.Point(331, 57);
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
            this.label_total.Location = new System.Drawing.Point(9, 137);
            this.label_total.Name = "label_total";
            this.label_total.Size = new System.Drawing.Size(54, 23);
            this.label_total.TabIndex = 31;
            this.label_total.Text = "Total:";
            // 
            // label_table_total_price
            // 
            this.label_table_total_price.AutoSize = true;
            this.label_table_total_price.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_table_total_price.ForeColor = System.Drawing.Color.Crimson;
            this.label_table_total_price.Location = new System.Drawing.Point(9, 57);
            this.label_table_total_price.Name = "label_table_total_price";
            this.label_table_total_price.Size = new System.Drawing.Size(146, 23);
            this.label_table_total_price.TabIndex = 32;
            this.label_table_total_price.Text = "Table Total Price:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label_rule_fl);
            this.panel1.Controls.Add(this.label_invoice_date);
            this.panel1.Controls.Add(this.checkBox_no);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.checkBox_yes);
            this.panel1.Controls.Add(this.label_penalty_rate);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.customBorderTextBox5);
            this.panel1.Controls.Add(this.label_service_price);
            this.panel1.Controls.Add(this.label_money_left);
            this.panel1.Controls.Add(this.label_payment_date);
            this.panel1.Controls.Add(this.label_total);
            this.panel1.Controls.Add(this.label_table_total_price);
            this.panel1.Controls.Add(this.customBorderTextBox6);
            this.panel1.Controls.Add(this.customBorderTextBox3);
            this.panel1.Controls.Add(this.customBorderTextBox2);
            this.panel1.Controls.Add(this.customBorderTextBox1);
            this.panel1.Location = new System.Drawing.Point(12, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(767, 190);
            this.panel1.TabIndex = 34;
            // 
            // label_rule_fl
            // 
            this.label_rule_fl.AutoSize = true;
            this.label_rule_fl.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_rule_fl.ForeColor = System.Drawing.Color.Crimson;
            this.label_rule_fl.Location = new System.Drawing.Point(626, 112);
            this.label_rule_fl.Name = "label_rule_fl";
            this.label_rule_fl.Size = new System.Drawing.Size(134, 23);
            this.label_rule_fl.TabIndex = 35;
            this.label_rule_fl.Text = "Rules following";
            // 
            // checkBox_no
            // 
            this.checkBox_no.AutoSize = true;
            this.checkBox_no.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_no.ForeColor = System.Drawing.Color.Crimson;
            this.checkBox_no.Location = new System.Drawing.Point(694, 138);
            this.checkBox_no.Name = "checkBox_no";
            this.checkBox_no.Size = new System.Drawing.Size(56, 27);
            this.checkBox_no.TabIndex = 37;
            this.checkBox_no.Text = "No";
            this.checkBox_no.UseVisualStyleBackColor = true;
            // 
            // checkBox_yes
            // 
            this.checkBox_yes.AutoSize = true;
            this.checkBox_yes.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_yes.ForeColor = System.Drawing.Color.Crimson;
            this.checkBox_yes.Location = new System.Drawing.Point(630, 138);
            this.checkBox_yes.Name = "checkBox_yes";
            this.checkBox_yes.Size = new System.Drawing.Size(58, 27);
            this.checkBox_yes.TabIndex = 35;
            this.checkBox_yes.Text = "Yes";
            this.checkBox_yes.UseVisualStyleBackColor = true;
            // 
            // label_penalty_rate
            // 
            this.label_penalty_rate.AutoSize = true;
            this.label_penalty_rate.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_penalty_rate.ForeColor = System.Drawing.Color.Crimson;
            this.label_penalty_rate.Location = new System.Drawing.Point(331, 135);
            this.label_penalty_rate.Name = "label_penalty_rate";
            this.label_penalty_rate.Size = new System.Drawing.Size(110, 23);
            this.label_penalty_rate.TabIndex = 36;
            this.label_penalty_rate.Text = "Penalty rate:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(474, 55);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(121, 22);
            this.dateTimePicker2.TabIndex = 35;
            // 
            // customBorderTextBox5
            // 
            this.customBorderTextBox5.Location = new System.Drawing.Point(199, 99);
            this.customBorderTextBox5.Name = "customBorderTextBox5";
            this.customBorderTextBox5.ReadOnly = true;
            this.customBorderTextBox5.Size = new System.Drawing.Size(126, 22);
            this.customBorderTextBox5.TabIndex = 27;
            // 
            // customBorderTextBox6
            // 
            this.customBorderTextBox6.Location = new System.Drawing.Point(199, 137);
            this.customBorderTextBox6.Name = "customBorderTextBox6";
            this.customBorderTextBox6.ReadOnly = true;
            this.customBorderTextBox6.Size = new System.Drawing.Size(126, 22);
            this.customBorderTextBox6.TabIndex = 33;
            // 
            // customBorderTextBox3
            // 
            this.customBorderTextBox3.Location = new System.Drawing.Point(474, 99);
            this.customBorderTextBox3.Name = "customBorderTextBox3";
            this.customBorderTextBox3.ReadOnly = true;
            this.customBorderTextBox3.Size = new System.Drawing.Size(121, 22);
            this.customBorderTextBox3.TabIndex = 25;
            // 
            // customBorderTextBox2
            // 
            this.customBorderTextBox2.Location = new System.Drawing.Point(199, 57);
            this.customBorderTextBox2.Name = "customBorderTextBox2";
            this.customBorderTextBox2.ReadOnly = true;
            this.customBorderTextBox2.Size = new System.Drawing.Size(126, 22);
            this.customBorderTextBox2.TabIndex = 24;
            // 
            // customBorderTextBox1
            // 
            this.customBorderTextBox1.Location = new System.Drawing.Point(474, 138);
            this.customBorderTextBox1.Name = "customBorderTextBox1";
            this.customBorderTextBox1.ReadOnly = true;
            this.customBorderTextBox1.Size = new System.Drawing.Size(121, 22);
            this.customBorderTextBox1.TabIndex = 23;
            // 
            // btn_delete_bill
            // 
            this.btn_delete_bill.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_delete_bill.Location = new System.Drawing.Point(697, 262);
            this.btn_delete_bill.Name = "btn_delete_bill";
            this.btn_delete_bill.Size = new System.Drawing.Size(85, 39);
            this.btn_delete_bill.TabIndex = 59;
            this.btn_delete_bill.Text = "DELETE";
            this.btn_delete_bill.UseVisualStyleBackColor = false;
            // 
            // btn_update_bill
            // 
            this.btn_update_bill.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_update_bill.Location = new System.Drawing.Point(606, 262);
            this.btn_update_bill.Name = "btn_update_bill";
            this.btn_update_bill.Size = new System.Drawing.Size(85, 39);
            this.btn_update_bill.TabIndex = 58;
            this.btn_update_bill.Text = "UPDATE";
            this.btn_update_bill.UseVisualStyleBackColor = false;
            // 
            // btn_add_bill
            // 
            this.btn_add_bill.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_add_bill.Location = new System.Drawing.Point(515, 262);
            this.btn_add_bill.Name = "btn_add_bill";
            this.btn_add_bill.Size = new System.Drawing.Size(85, 39);
            this.btn_add_bill.TabIndex = 57;
            this.btn_add_bill.Text = "ADD";
            this.btn_add_bill.UseVisualStyleBackColor = false;
            // 
            // Bill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(204)))), ((int)(((byte)(176)))));
            this.ClientSize = new System.Drawing.Size(792, 312);
            this.Controls.Add(this.btn_delete_bill);
            this.Controls.Add(this.btn_update_bill);
            this.Controls.Add(this.btn_add_bill);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label_tittle_bill);
            this.Name = "Bill";
            this.Text = "Bill";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_tittle_bill;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label_invoice_date;
        private CustomBorderTextBox customBorderTextBox1;
        private CustomBorderTextBox customBorderTextBox2;
        private CustomBorderTextBox customBorderTextBox3;
        private CustomBorderTextBox customBorderTextBox5;
        private System.Windows.Forms.Label label_service_price;
        private System.Windows.Forms.Label label_money_left;
        private System.Windows.Forms.Label label_payment_date;
        private System.Windows.Forms.Label label_total;
        private System.Windows.Forms.Label label_table_total_price;
        private CustomBorderTextBox customBorderTextBox6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label_rule_fl;
        private System.Windows.Forms.CheckBox checkBox_no;
        private System.Windows.Forms.CheckBox checkBox_yes;
        private System.Windows.Forms.Label label_penalty_rate;
        private System.Windows.Forms.Button btn_delete_bill;
        private System.Windows.Forms.Button btn_update_bill;
        private System.Windows.Forms.Button btn_add_bill;
    }
}
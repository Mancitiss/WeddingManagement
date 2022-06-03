
namespace WeddingManagementApplication
{
    partial class FormAccount
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
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_search_dishes = new WeddingManagementApplication.CustomeBorderTextbox();
            this.btn_delete_dishes = new System.Windows.Forms.Button();
            this.btn_add_dishes = new System.Windows.Forms.Button();
            this.btn_update_dishes = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.Label();
            this.tb_dishes_note = new WeddingManagementApplication.CustomeBorderTextbox();
            this.Password = new System.Windows.Forms.Label();
            this.tb_dishes_price = new WeddingManagementApplication.CustomeBorderTextbox();
            this.username = new System.Windows.Forms.Label();
            this.tb_dishes_name = new WeddingManagementApplication.CustomeBorderTextbox();
            this.label = new System.Windows.Forms.Label();
            this.data_gv_dishes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.customeBorderTextbox1 = new WeddingManagementApplication.CustomeBorderTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbb_level = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.data_gv_dishes)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(754, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "X";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Crimson;
            this.label4.Location = new System.Drawing.Point(581, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 23);
            this.label4.TabIndex = 90;
            this.label4.Text = "Search";
            // 
            // tb_search_dishes
            // 
            this.tb_search_dishes.Location = new System.Drawing.Point(504, 48);
            this.tb_search_dishes.Name = "tb_search_dishes";
            this.tb_search_dishes.Size = new System.Drawing.Size(238, 22);
            this.tb_search_dishes.TabIndex = 89;
            // 
            // btn_delete_dishes
            // 
            this.btn_delete_dishes.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_delete_dishes.Location = new System.Drawing.Point(676, 385);
            this.btn_delete_dishes.Name = "btn_delete_dishes";
            this.btn_delete_dishes.Size = new System.Drawing.Size(85, 39);
            this.btn_delete_dishes.TabIndex = 88;
            this.btn_delete_dishes.Text = "DELETE";
            this.btn_delete_dishes.UseVisualStyleBackColor = false;
            // 
            // btn_add_dishes
            // 
            this.btn_add_dishes.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_add_dishes.Location = new System.Drawing.Point(494, 385);
            this.btn_add_dishes.Name = "btn_add_dishes";
            this.btn_add_dishes.Size = new System.Drawing.Size(85, 39);
            this.btn_add_dishes.TabIndex = 87;
            this.btn_add_dishes.Text = "ADD";
            this.btn_add_dishes.UseVisualStyleBackColor = false;
            // 
            // btn_update_dishes
            // 
            this.btn_update_dishes.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_update_dishes.Location = new System.Drawing.Point(585, 385);
            this.btn_update_dishes.Name = "btn_update_dishes";
            this.btn_update_dishes.Size = new System.Drawing.Size(85, 39);
            this.btn_update_dishes.TabIndex = 86;
            this.btn_update_dishes.Text = "UPDATE";
            this.btn_update_dishes.UseVisualStyleBackColor = false;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.ForeColor = System.Drawing.Color.Crimson;
            this.name.Location = new System.Drawing.Point(522, 209);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(57, 23);
            this.name.TabIndex = 85;
            this.name.Text = "Name";
            // 
            // tb_dishes_note
            // 
            this.tb_dishes_note.Location = new System.Drawing.Point(523, 235);
            this.tb_dishes_note.Name = "tb_dishes_note";
            this.tb_dishes_note.Size = new System.Drawing.Size(205, 22);
            this.tb_dishes_note.TabIndex = 84;
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.ForeColor = System.Drawing.Color.Crimson;
            this.Password.Location = new System.Drawing.Point(519, 151);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(85, 23);
            this.Password.TabIndex = 83;
            this.Password.Text = "Password";
            // 
            // tb_dishes_price
            // 
            this.tb_dishes_price.Location = new System.Drawing.Point(522, 177);
            this.tb_dishes_price.Name = "tb_dishes_price";
            this.tb_dishes_price.ReadOnly = true;
            this.tb_dishes_price.Size = new System.Drawing.Size(205, 22);
            this.tb_dishes_price.TabIndex = 82;
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.ForeColor = System.Drawing.Color.Crimson;
            this.username.Location = new System.Drawing.Point(522, 88);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(89, 23);
            this.username.TabIndex = 81;
            this.username.Text = "Username";
            // 
            // tb_dishes_name
            // 
            this.tb_dishes_name.Location = new System.Drawing.Point(522, 114);
            this.tb_dishes_name.Name = "tb_dishes_name";
            this.tb_dishes_name.Size = new System.Drawing.Size(205, 22);
            this.tb_dishes_name.TabIndex = 80;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Segoe Print", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.Crimson;
            this.label.Location = new System.Drawing.Point(146, 5);
            this.label.Margin = new System.Windows.Forms.Padding(0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(179, 54);
            this.label.TabIndex = 79;
            this.label.Text = "ACCOUNT";
            // 
            // data_gv_dishes
            // 
            this.data_gv_dishes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_gv_dishes.Location = new System.Drawing.Point(6, 62);
            this.data_gv_dishes.Name = "data_gv_dishes";
            this.data_gv_dishes.RowHeadersWidth = 51;
            this.data_gv_dishes.RowTemplate.Height = 24;
            this.data_gv_dishes.Size = new System.Drawing.Size(454, 372);
            this.data_gv_dishes.TabIndex = 78;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(521, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 23);
            this.label1.TabIndex = 92;
            this.label1.Text = "Identification";
            // 
            // customeBorderTextbox1
            // 
            this.customeBorderTextbox1.Location = new System.Drawing.Point(522, 293);
            this.customeBorderTextbox1.Name = "customeBorderTextbox1";
            this.customeBorderTextbox1.Size = new System.Drawing.Size(205, 22);
            this.customeBorderTextbox1.TabIndex = 91;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(524, 333);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 23);
            this.label2.TabIndex = 94;
            this.label2.Text = "Level";
            // 
            // cbb_level
            // 
            this.cbb_level.FormattingEnabled = true;
            this.cbb_level.Items.AddRange(new object[] {
            "Director",
            "Manager",
            "Staff"});
            this.cbb_level.Location = new System.Drawing.Point(585, 335);
            this.cbb_level.Name = "cbb_level";
            this.cbb_level.Size = new System.Drawing.Size(143, 24);
            this.cbb_level.TabIndex = 95;
            // 
            // FormAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(204)))), ((int)(((byte)(176)))));
            this.ClientSize = new System.Drawing.Size(783, 450);
            this.Controls.Add(this.cbb_level);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.customeBorderTextbox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_search_dishes);
            this.Controls.Add(this.btn_delete_dishes);
            this.Controls.Add(this.btn_add_dishes);
            this.Controls.Add(this.btn_update_dishes);
            this.Controls.Add(this.name);
            this.Controls.Add(this.tb_dishes_note);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.tb_dishes_price);
            this.Controls.Add(this.username);
            this.Controls.Add(this.tb_dishes_name);
            this.Controls.Add(this.label);
            this.Controls.Add(this.data_gv_dishes);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(783, 450);
            this.Name = "FormAccount";
            this.Text = "FormAccount";
            ((System.ComponentModel.ISupportInitialize)(this.data_gv_dishes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private CustomeBorderTextbox tb_search_dishes;
        private System.Windows.Forms.Button btn_delete_dishes;
        private System.Windows.Forms.Button btn_add_dishes;
        private System.Windows.Forms.Button btn_update_dishes;
        private System.Windows.Forms.Label name;
        private CustomeBorderTextbox tb_dishes_note;
        private System.Windows.Forms.Label Password;
        private CustomeBorderTextbox tb_dishes_price;
        private System.Windows.Forms.Label username;
        private CustomeBorderTextbox tb_dishes_name;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.DataGridView data_gv_dishes;
        private System.Windows.Forms.Label label1;
        private CustomeBorderTextbox customeBorderTextbox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbb_level;
    }
}
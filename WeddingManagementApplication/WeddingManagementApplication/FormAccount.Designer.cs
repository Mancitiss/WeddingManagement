
using System;
using System.Windows.Forms;

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
            this.tb_search = new WeddingManagementApplication.CustomeBorderTextbox();
            this.btn_delete_account = new System.Windows.Forms.Button();
            this.btn_add_account = new System.Windows.Forms.Button();
            this.btn_update_account = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.Label();
            this.tb_name = new WeddingManagementApplication.CustomeBorderTextbox();
            this.Password = new System.Windows.Forms.Label();
            this.tb_password = new WeddingManagementApplication.CustomeBorderTextbox();
            this.username = new System.Windows.Forms.Label();
            this.tb_username = new WeddingManagementApplication.CustomeBorderTextbox();
            this.label = new System.Windows.Forms.Label();
            this.gv_act = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_iden = new WeddingManagementApplication.CustomeBorderTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbb_level = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gv_act)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(566, 7);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "X";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Crimson;
            this.label4.Location = new System.Drawing.Point(436, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 19);
            this.label4.TabIndex = 90;
            this.label4.Text = "Search";
            // 
            // tb_search
            // 
            this.tb_search.Location = new System.Drawing.Point(378, 39);
            this.tb_search.Margin = new System.Windows.Forms.Padding(2);
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(180, 20);
            this.tb_search.TabIndex = 8;
            // 
            // btn_delete_account
            // 
            this.btn_delete_account.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_delete_account.Location = new System.Drawing.Point(507, 313);
            this.btn_delete_account.Margin = new System.Windows.Forms.Padding(2);
            this.btn_delete_account.Name = "btn_delete_account";
            this.btn_delete_account.Size = new System.Drawing.Size(64, 32);
            this.btn_delete_account.TabIndex = 7;
            this.btn_delete_account.Text = "DELETE";
            this.btn_delete_account.UseVisualStyleBackColor = false;
            this.btn_delete_account.Click += new System.EventHandler(this.btn_delete_account_Click);
            // 
            // btn_add_account
            // 
            this.btn_add_account.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_add_account.Location = new System.Drawing.Point(370, 313);
            this.btn_add_account.Margin = new System.Windows.Forms.Padding(2);
            this.btn_add_account.Name = "btn_add_account";
            this.btn_add_account.Size = new System.Drawing.Size(64, 32);
            this.btn_add_account.TabIndex = 5;
            this.btn_add_account.Text = "ADD";
            this.btn_add_account.UseVisualStyleBackColor = false;
            this.btn_add_account.Click += new System.EventHandler(this.btn_add_account_Click);
            // 
            // btn_update_account
            // 
            this.btn_update_account.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_update_account.Location = new System.Drawing.Point(439, 313);
            this.btn_update_account.Margin = new System.Windows.Forms.Padding(2);
            this.btn_update_account.Name = "btn_update_account";
            this.btn_update_account.Size = new System.Drawing.Size(64, 32);
            this.btn_update_account.TabIndex = 6;
            this.btn_update_account.Text = "UPDATE";
            this.btn_update_account.UseVisualStyleBackColor = false;
            this.btn_update_account.Click += new System.EventHandler(this.btn_update_account_Click);
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.ForeColor = System.Drawing.Color.Crimson;
            this.name.Location = new System.Drawing.Point(392, 170);
            this.name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(49, 19);
            this.name.TabIndex = 85;
            this.name.Text = "Name";
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(392, 191);
            this.tb_name.Margin = new System.Windows.Forms.Padding(2);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(155, 20);
            this.tb_name.TabIndex = 2;
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.ForeColor = System.Drawing.Color.Crimson;
            this.Password.Location = new System.Drawing.Point(389, 123);
            this.Password.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(73, 19);
            this.Password.TabIndex = 83;
            this.Password.Text = "Password";
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(392, 144);
            this.tb_password.Margin = new System.Windows.Forms.Padding(2);
            this.tb_password.Name = "tb_password";
            this.tb_password.PasswordChar = '*';
            this.tb_password.Size = new System.Drawing.Size(155, 20);
            this.tb_password.TabIndex = 1;
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.ForeColor = System.Drawing.Color.Crimson;
            this.username.Location = new System.Drawing.Point(392, 72);
            this.username.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(76, 19);
            this.username.TabIndex = 81;
            this.username.Text = "Username";
            // 
            // tb_username
            // 
            this.tb_username.Location = new System.Drawing.Point(392, 93);
            this.tb_username.Margin = new System.Windows.Forms.Padding(2);
            this.tb_username.Name = "tb_username";
            this.tb_username.Size = new System.Drawing.Size(155, 20);
            this.tb_username.TabIndex = 0;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Segoe Print", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.Crimson;
            this.label.Location = new System.Drawing.Point(110, 4);
            this.label.Margin = new System.Windows.Forms.Padding(0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(145, 43);
            this.label.TabIndex = 79;
            this.label.Text = "ACCOUNT";
            // 
            // gv_act
            // 
            this.gv_act.AllowUserToAddRows = false;
            this.gv_act.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_act.Location = new System.Drawing.Point(4, 50);
            this.gv_act.Margin = new System.Windows.Forms.Padding(2);
            this.gv_act.Name = "gv_act";
            this.gv_act.ReadOnly = true;
            this.gv_act.RowHeadersWidth = 51;
            this.gv_act.RowTemplate.Height = 24;
            this.gv_act.Size = new System.Drawing.Size(340, 302);
            this.gv_act.TabIndex = 78;
            this.gv_act.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_act_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(391, 217);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 19);
            this.label1.TabIndex = 92;
            this.label1.Text = "Identification";
            // 
            // tb_iden
            // 
            this.tb_iden.Location = new System.Drawing.Point(392, 238);
            this.tb_iden.Margin = new System.Windows.Forms.Padding(2);
            this.tb_iden.Name = "tb_iden";
            this.tb_iden.Size = new System.Drawing.Size(155, 20);
            this.tb_iden.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(393, 271);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 19);
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
            this.cbb_level.Location = new System.Drawing.Point(439, 272);
            this.cbb_level.Margin = new System.Windows.Forms.Padding(2);
            this.cbb_level.Name = "cbb_level";
            this.cbb_level.Size = new System.Drawing.Size(108, 21);
            this.cbb_level.TabIndex = 4;
            // 
            // FormAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(204)))), ((int)(((byte)(176)))));
            this.ClientSize = new System.Drawing.Size(587, 366);
            this.Controls.Add(this.cbb_level);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_iden);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_search);
            this.Controls.Add(this.btn_delete_account);
            this.Controls.Add(this.btn_add_account);
            this.Controls.Add(this.btn_update_account);
            this.Controls.Add(this.name);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.tb_username);
            this.Controls.Add(this.label);
            this.Controls.Add(this.gv_act);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            this.MaximumSize = new System.Drawing.Size(783, 450);

            this.Margin = new System.Windows.Forms.Padding(2);

            this.Name = "FormAccount";
            this.Text = "FormAccount";
            ((System.ComponentModel.ISupportInitialize)(this.gv_act)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private CustomeBorderTextbox tb_search;
        private System.Windows.Forms.Button btn_delete_account;
        private System.Windows.Forms.Button btn_add_account;
        private System.Windows.Forms.Button btn_update_account;
        private System.Windows.Forms.Label name;
        private CustomeBorderTextbox tb_name;
        private System.Windows.Forms.Label Password;
        private CustomeBorderTextbox tb_password;
        private System.Windows.Forms.Label username;
        private CustomeBorderTextbox tb_username;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.DataGridView gv_act;
        private System.Windows.Forms.Label label1;
        private CustomeBorderTextbox tb_iden;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbb_level;
    }
}
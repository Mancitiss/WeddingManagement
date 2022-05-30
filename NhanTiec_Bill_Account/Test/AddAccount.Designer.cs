
namespace Test
{
    partial class Form1
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
            this.label_user = new System.Windows.Forms.Label();
            this.label_sdt = new System.Windows.Forms.Label();
            this.label_create_acc = new System.Windows.Forms.Label();
            this.checkedListBox_level = new System.Windows.Forms.CheckedListBox();
            this.label_cccd = new System.Windows.Forms.Label();
            this.label_level = new System.Windows.Forms.Label();
            this.tb_iden = new Test.CustomBorderTextBox();
            this.tb_pass = new Test.CustomBorderTextBox();
            this.tb_user = new Test.CustomBorderTextBox();
            this.SuspendLayout();
            // 
            // label_user
            // 
            this.label_user.AutoSize = true;
            this.label_user.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_user.ForeColor = System.Drawing.Color.Crimson;
            this.label_user.Location = new System.Drawing.Point(36, 90);
            this.label_user.Name = "label_user";
            this.label_user.Size = new System.Drawing.Size(91, 23);
            this.label_user.TabIndex = 3;
            this.label_user.Text = "Username:";
            // 
            // label_sdt
            // 
            this.label_sdt.AutoSize = true;
            this.label_sdt.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_sdt.ForeColor = System.Drawing.Color.Crimson;
            this.label_sdt.Location = new System.Drawing.Point(36, 136);
            this.label_sdt.Name = "label_sdt";
            this.label_sdt.Size = new System.Drawing.Size(129, 23);
            this.label_sdt.TabIndex = 4;
            this.label_sdt.Text = "Phone number:";
            // 
            // label_create_acc
            // 
            this.label_create_acc.AutoSize = true;
            this.label_create_acc.Font = new System.Drawing.Font("Segoe Print", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_create_acc.ForeColor = System.Drawing.Color.Crimson;
            this.label_create_acc.Location = new System.Drawing.Point(29, 7);
            this.label_create_acc.Margin = new System.Windows.Forms.Padding(0);
            this.label_create_acc.Name = "label_create_acc";
            this.label_create_acc.Size = new System.Drawing.Size(333, 43);
            this.label_create_acc.TabIndex = 5;
            this.label_create_acc.Text = "CREATE USER ACCOUNT";
            // 
            // checkedListBox_level
            // 
            this.checkedListBox_level.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(204)))), ((int)(((byte)(176)))));
            this.checkedListBox_level.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox_level.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox_level.ForeColor = System.Drawing.Color.Crimson;
            this.checkedListBox_level.FormattingEnabled = true;
            this.checkedListBox_level.Items.AddRange(new object[] {
            "Nhân viên",
            "Quản lý",
            "Giám đốc"});
            this.checkedListBox_level.Location = new System.Drawing.Point(171, 222);
            this.checkedListBox_level.Name = "checkedListBox_level";
            this.checkedListBox_level.Size = new System.Drawing.Size(120, 66);
            this.checkedListBox_level.TabIndex = 6;
            // 
            // label_cccd
            // 
            this.label_cccd.AutoSize = true;
            this.label_cccd.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_cccd.ForeColor = System.Drawing.Color.Crimson;
            this.label_cccd.Location = new System.Drawing.Point(36, 180);
            this.label_cccd.Name = "label_cccd";
            this.label_cccd.Size = new System.Drawing.Size(115, 23);
            this.label_cccd.TabIndex = 8;
            this.label_cccd.Text = "Identification:";
            // 
            // label_level
            // 
            this.label_level.AutoSize = true;
            this.label_level.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_level.ForeColor = System.Drawing.Color.Crimson;
            this.label_level.Location = new System.Drawing.Point(36, 222);
            this.label_level.Name = "label_level";
            this.label_level.Size = new System.Drawing.Size(53, 23);
            this.label_level.TabIndex = 9;
            this.label_level.Text = "Level:";
            // 
            // tb_iden
            // 
            this.tb_iden.Location = new System.Drawing.Point(171, 180);
            this.tb_iden.Name = "tb_iden";
            this.tb_iden.Size = new System.Drawing.Size(171, 22);
            this.tb_iden.TabIndex = 12;
            // 
            // tb_pass
            // 
            this.tb_pass.Location = new System.Drawing.Point(171, 136);
            this.tb_pass.Name = "tb_pass";
            this.tb_pass.Size = new System.Drawing.Size(171, 22);
            this.tb_pass.TabIndex = 11;
            // 
            // tb_user
            // 
            this.tb_user.Location = new System.Drawing.Point(171, 90);
            this.tb_user.Name = "tb_user";
            this.tb_user.Size = new System.Drawing.Size(171, 22);
            this.tb_user.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(204)))), ((int)(((byte)(176)))));
            this.ClientSize = new System.Drawing.Size(402, 298);
            this.Controls.Add(this.tb_iden);
            this.Controls.Add(this.tb_pass);
            this.Controls.Add(this.tb_user);
            this.Controls.Add(this.label_level);
            this.Controls.Add(this.label_cccd);
            this.Controls.Add(this.checkedListBox_level);
            this.Controls.Add(this.label_create_acc);
            this.Controls.Add(this.label_sdt);
            this.Controls.Add(this.label_user);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_user;
        private System.Windows.Forms.Label label_sdt;
        private System.Windows.Forms.Label label_create_acc;
        private System.Windows.Forms.CheckedListBox checkedListBox_level;
        private System.Windows.Forms.Label label_cccd;
        private System.Windows.Forms.Label label_level;
        private CustomBorderTextBox tb_user;
        private CustomBorderTextBox tb_pass;
        private CustomBorderTextBox tb_iden;
    }
}


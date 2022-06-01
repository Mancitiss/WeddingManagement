﻿namespace WeddingManagementApplication
{
    partial class Dishes
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbName = new System.Windows.Forms.Label();
            this.lbCost = new System.Windows.Forms.Label();
            this.btnClick = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(101)))));
            this.lbName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbName.Location = new System.Drawing.Point(3, 2);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(103, 23);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Gà nướng";
            // 
            // lbCost
            // 
            this.lbCost.AutoEllipsis = true;
            this.lbCost.AutoSize = true;
            this.lbCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(101)))));
            this.lbCost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbCost.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCost.ForeColor = System.Drawing.SystemColors.Control;
            this.lbCost.Location = new System.Drawing.Point(1, 203);
            this.lbCost.Name = "lbCost";
            this.lbCost.Size = new System.Drawing.Size(51, 27);
            this.lbCost.TabIndex = 1;
            this.lbCost.Text = "30$";
            this.lbCost.Click += new System.EventHandler(this.lbCost_Click);
            // 
            // btnClick
            // 
            this.btnClick.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClick.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClick.ForeColor = System.Drawing.Color.White;
            this.btnClick.Location = new System.Drawing.Point(163, 188);
            this.btnClick.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClick.Name = "btnClick";
            this.btnClick.Size = new System.Drawing.Size(53, 42);
            this.btnClick.TabIndex = 2;
            this.btnClick.UseVisualStyleBackColor = true;
            this.btnClick.Visible = false;
            // 
            // Dishes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btnClick);
            this.Controls.Add(this.lbCost);
            this.Controls.Add(this.lbName);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Dishes";
            this.Size = new System.Drawing.Size(216, 230);
            this.Click += new System.EventHandler(this.Dishes_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbCost;
        private System.Windows.Forms.Button btnClick;
    }
}

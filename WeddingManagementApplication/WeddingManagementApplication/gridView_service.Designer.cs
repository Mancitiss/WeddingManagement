
namespace WeddingManagementApplication
{
    partial class gridView_service
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
            this.dataService = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataService)).BeginInit();
            this.SuspendLayout();
            // 
            // dataService
            // 
            this.dataService.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(204)))), ((int)(((byte)(176)))));
            this.dataService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataService.Location = new System.Drawing.Point(-6, 0);
            this.dataService.Name = "dataService";
            this.dataService.RowHeadersWidth = 51;
            this.dataService.RowTemplate.Height = 24;
            this.dataService.Size = new System.Drawing.Size(692, 307);
            this.dataService.TabIndex = 0;
            // 
            // gridView_service
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 307);
            this.Controls.Add(this.dataService);
            this.Name = "gridView_service";
            this.Text = "gridView_service";
            ((System.ComponentModel.ISupportInitialize)(this.dataService)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataService;
    }
}
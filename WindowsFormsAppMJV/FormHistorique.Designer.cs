namespace WindowsFormsAppMJV
{
    partial class FormHistorique
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
            this.dataGridViewHistorique = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistorique)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewHistorique
            // 
            this.dataGridViewHistorique.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHistorique.Location = new System.Drawing.Point(156, 85);
            this.dataGridViewHistorique.Name = "dataGridViewHistorique";
            this.dataGridViewHistorique.RowHeadersWidth = 51;
            this.dataGridViewHistorique.RowTemplate.Height = 24;
            this.dataGridViewHistorique.Size = new System.Drawing.Size(560, 292);
            this.dataGridViewHistorique.TabIndex = 0;
            this.dataGridViewHistorique.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // FormHistorique
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewHistorique);
            this.Name = "FormHistorique";
            this.Text = "HistoriqueInterventions";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistorique)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewHistorique;
    }
}
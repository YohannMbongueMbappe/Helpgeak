namespace WindowsFormsAppMJV
{
    partial class FormInterventionsTechnicien
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
            this.comboBoxTechnicien = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBoxTechnicien
            // 
            this.comboBoxTechnicien.FormattingEnabled = true;
            this.comboBoxTechnicien.Location = new System.Drawing.Point(325, 160);
            this.comboBoxTechnicien.Name = "comboBoxTechnicien";
            this.comboBoxTechnicien.Size = new System.Drawing.Size(288, 24);
            this.comboBoxTechnicien.TabIndex = 0;
            // 
            // FormInterventionsTechnicien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBoxTechnicien);
            this.Name = "FormInterventionsTechnicien";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.FormInterventionsTechnicien_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxTechnicien;
    }
}
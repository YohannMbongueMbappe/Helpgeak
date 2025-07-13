namespace WindowsFormsAppMJV
{
    partial class FormPrince
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonCreation = new System.Windows.Forms.Button();
            this.comboBoxMatos = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerInstall = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.paramétrageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matérielToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxTechnicien = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonCreation);
            this.groupBox1.Controls.Add(this.comboBoxMatos);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxComment);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePickerInstall);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(22, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(940, 251);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Créer une intervention";
            // 
            // buttonCreation
            // 
            this.buttonCreation.Location = new System.Drawing.Point(579, 191);
            this.buttonCreation.Name = "buttonCreation";
            this.buttonCreation.Size = new System.Drawing.Size(325, 33);
            this.buttonCreation.TabIndex = 7;
            this.buttonCreation.Text = "Créer une intervention";
            this.buttonCreation.UseVisualStyleBackColor = true;
            this.buttonCreation.Click += new System.EventHandler(this.buttonCreation_Click);
            // 
            // comboBoxMatos
            // 
            this.comboBoxMatos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMatos.FormattingEnabled = true;
            this.comboBoxMatos.Location = new System.Drawing.Point(190, 191);
            this.comboBoxMatos.Name = "comboBoxMatos";
            this.comboBoxMatos.Size = new System.Drawing.Size(357, 33);
            this.comboBoxMatos.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Matériel";
            // 
            // textBoxComment
            // 
            this.textBoxComment.Location = new System.Drawing.Point(190, 95);
            this.textBoxComment.Multiline = true;
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.Size = new System.Drawing.Size(714, 73);
            this.textBoxComment.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Commentaires";
            // 
            // dateTimePickerInstall
            // 
            this.dateTimePickerInstall.Location = new System.Drawing.Point(190, 41);
            this.dateTimePickerInstall.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerInstall.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerInstall.Name = "dateTimePickerInstall";
            this.dateTimePickerInstall.Size = new System.Drawing.Size(357, 30);
            this.dateTimePickerInstall.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date :";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paramétrageToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(974, 30);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // paramétrageToolStripMenuItem
            // 
            this.paramétrageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.matérielToolStripMenuItem,
            this.typesToolStripMenuItem,
            this.clientsToolStripMenuItem});
            this.paramétrageToolStripMenuItem.Name = "paramétrageToolStripMenuItem";
            this.paramétrageToolStripMenuItem.Size = new System.Drawing.Size(107, 24);
            this.paramétrageToolStripMenuItem.Text = "Paramétrage";
            // 
            // matérielToolStripMenuItem
            // 
            this.matérielToolStripMenuItem.Name = "matérielToolStripMenuItem";
            this.matérielToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.M)));
            this.matérielToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.matérielToolStripMenuItem.Text = "Matériel ...";
            this.matérielToolStripMenuItem.Click += new System.EventHandler(this.matérielToolStripMenuItem_Click);
            // 
            // typesToolStripMenuItem
            // 
            this.typesToolStripMenuItem.Name = "typesToolStripMenuItem";
            this.typesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.T)));
            this.typesToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.typesToolStripMenuItem.Text = "Types ...";
            this.typesToolStripMenuItem.Click += new System.EventHandler(this.typesToolStripMenuItem_Click);
            // 
            // clientsToolStripMenuItem
            // 
            this.clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
            this.clientsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.clientsToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.clientsToolStripMenuItem.Text = "Clients ...";
            this.clientsToolStripMenuItem.Click += new System.EventHandler(this.clientsToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(234, 372);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(325, 33);
            this.button1.TabIndex = 8;
            this.button1.Text = "Historique des interventions";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxTechnicien
            // 
            this.comboBoxTechnicien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTechnicien.FormattingEnabled = true;
            this.comboBoxTechnicien.Location = new System.Drawing.Point(202, 293);
            this.comboBoxTechnicien.Name = "comboBoxTechnicien";
            this.comboBoxTechnicien.Size = new System.Drawing.Size(357, 24);
            this.comboBoxTechnicien.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 301);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Technicien";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // FormPrince
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 513);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxTechnicien);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPrince";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MJV";
            this.Load += new System.EventHandler(this.FormPrince_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonCreation;
        private System.Windows.Forms.ComboBox comboBoxMatos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerInstall;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem paramétrageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matérielToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem typesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientsToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxTechnicien;
        private System.Windows.Forms.Label label3;
    }
}


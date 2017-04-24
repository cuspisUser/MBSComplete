namespace DosMigration
{
    partial class FormDosMigracija
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDosMigracija));
            this.menuStripDosMigracija = new System.Windows.Forms.MenuStrip();
            this.migracijaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripDosMigracija = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewDosMigracija = new System.Windows.Forms.DataGridView();
            this.menuStripDosMigracija.SuspendLayout();
            this.statusStripDosMigracija.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDosMigracija)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripDosMigracija
            // 
            this.menuStripDosMigracija.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.migracijaToolStripMenuItem});
            this.menuStripDosMigracija.Location = new System.Drawing.Point(0, 0);
            this.menuStripDosMigracija.Name = "menuStripDosMigracija";
            this.menuStripDosMigracija.Size = new System.Drawing.Size(803, 24);
            this.menuStripDosMigracija.TabIndex = 0;
            this.menuStripDosMigracija.Text = "menuStrip1";
            // 
            // migracijaToolStripMenuItem
            // 
            this.migracijaToolStripMenuItem.Enabled = false;
            this.migracijaToolStripMenuItem.Name = "migracijaToolStripMenuItem";
            this.migracijaToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.migracijaToolStripMenuItem.Text = "Migracija";
            this.migracijaToolStripMenuItem.Click += new System.EventHandler(this.migracijaToolStripMenuItem_Click);
            // 
            // statusStripDosMigracija
            // 
            this.statusStripDosMigracija.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusLabel1});
            this.statusStripDosMigracija.Location = new System.Drawing.Point(0, 284);
            this.statusStripDosMigracija.Name = "statusStripDosMigracija";
            this.statusStripDosMigracija.Size = new System.Drawing.Size(803, 22);
            this.statusStripDosMigracija.TabIndex = 2;
            this.statusStripDosMigracija.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewDosMigracija);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(803, 260);
            this.panel1.TabIndex = 3;
            // 
            // dataGridViewDosMigracija
            // 
            this.dataGridViewDosMigracija.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDosMigracija.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDosMigracija.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewDosMigracija.Name = "dataGridViewDosMigracija";
            this.dataGridViewDosMigracija.Size = new System.Drawing.Size(803, 260);
            this.dataGridViewDosMigracija.TabIndex = 0;
            // 
            // FormDosMigracija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 306);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStripDosMigracija);
            this.Controls.Add(this.menuStripDosMigracija);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripDosMigracija;
            this.Name = "FormDosMigracija";
            this.Text = "MIPSED DOS Migracija";
            this.menuStripDosMigracija.ResumeLayout(false);
            this.menuStripDosMigracija.PerformLayout();
            this.statusStripDosMigracija.ResumeLayout(false);
            this.statusStripDosMigracija.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDosMigracija)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripDosMigracija;
        private System.Windows.Forms.ToolStripMenuItem migracijaToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStripDosMigracija;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewDosMigracija;

    }
}


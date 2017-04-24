namespace ServisModule.ServisModule.Margine
{
    partial class frmMargine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMargine));
            this.txtGore = new System.Windows.Forms.TextBox();
            this.lblTop = new System.Windows.Forms.Label();
            this.lblBottom = new System.Windows.Forms.Label();
            this.txtDole = new System.Windows.Forms.TextBox();
            this.lblLeft = new System.Windows.Forms.Label();
            this.txtLeft = new System.Windows.Forms.TextBox();
            this.lbldesna = new System.Windows.Forms.Label();
            this.txtRight = new System.Windows.Forms.TextBox();
            this.tspPlanNabave = new System.Windows.Forms.ToolStrip();
            this.tsbPlanNabaveSpremiZatvori = new System.Windows.Forms.ToolStripButton();
            this.tsbPlanNabaveOdustani = new System.Windows.Forms.ToolStripButton();
            this.tspPlanNabave.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtGore
            // 
            this.txtGore.Location = new System.Drawing.Point(68, 35);
            this.txtGore.Name = "txtGore";
            this.txtGore.Size = new System.Drawing.Size(116, 20);
            this.txtGore.TabIndex = 0;
            // 
            // lblTop
            // 
            this.lblTop.AutoSize = true;
            this.lblTop.Location = new System.Drawing.Point(21, 38);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(41, 13);
            this.lblTop.TabIndex = 1;
            this.lblTop.Text = "Gornja:";
            // 
            // lblBottom
            // 
            this.lblBottom.AutoSize = true;
            this.lblBottom.Location = new System.Drawing.Point(21, 75);
            this.lblBottom.Name = "lblBottom";
            this.lblBottom.Size = new System.Drawing.Size(38, 13);
            this.lblBottom.TabIndex = 3;
            this.lblBottom.Text = "Donja:";
            // 
            // txtDole
            // 
            this.txtDole.Location = new System.Drawing.Point(68, 72);
            this.txtDole.Name = "txtDole";
            this.txtDole.Size = new System.Drawing.Size(116, 20);
            this.txtDole.TabIndex = 2;
            // 
            // lblLeft
            // 
            this.lblLeft.AutoSize = true;
            this.lblLeft.Location = new System.Drawing.Point(21, 112);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(38, 13);
            this.lblLeft.TabIndex = 5;
            this.lblLeft.Text = "Lijeva:";
            // 
            // txtLeft
            // 
            this.txtLeft.Location = new System.Drawing.Point(68, 109);
            this.txtLeft.Name = "txtLeft";
            this.txtLeft.Size = new System.Drawing.Size(116, 20);
            this.txtLeft.TabIndex = 4;
            // 
            // lbldesna
            // 
            this.lbldesna.AutoSize = true;
            this.lbldesna.Location = new System.Drawing.Point(21, 149);
            this.lbldesna.Name = "lbldesna";
            this.lbldesna.Size = new System.Drawing.Size(41, 13);
            this.lbldesna.TabIndex = 7;
            this.lbldesna.Text = "Desna:";
            // 
            // txtRight
            // 
            this.txtRight.Location = new System.Drawing.Point(68, 146);
            this.txtRight.Name = "txtRight";
            this.txtRight.Size = new System.Drawing.Size(116, 20);
            this.txtRight.TabIndex = 6;
            // 
            // tspPlanNabave
            // 
            this.tspPlanNabave.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPlanNabaveSpremiZatvori,
            this.tsbPlanNabaveOdustani});
            this.tspPlanNabave.Location = new System.Drawing.Point(0, 0);
            this.tspPlanNabave.Name = "tspPlanNabave";
            this.tspPlanNabave.Size = new System.Drawing.Size(240, 25);
            this.tspPlanNabave.TabIndex = 21;
            this.tspPlanNabave.Text = "toolStrip1";
            // 
            // tsbPlanNabaveSpremiZatvori
            // 
            this.tsbPlanNabaveSpremiZatvori.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbPlanNabaveSpremiZatvori.Image = ((System.Drawing.Image)(resources.GetObject("tsbPlanNabaveSpremiZatvori.Image")));
            this.tsbPlanNabaveSpremiZatvori.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPlanNabaveSpremiZatvori.Name = "tsbPlanNabaveSpremiZatvori";
            this.tsbPlanNabaveSpremiZatvori.Size = new System.Drawing.Size(92, 22);
            this.tsbPlanNabaveSpremiZatvori.Text = "Spremi i zatvori";
            this.tsbPlanNabaveSpremiZatvori.Click += new System.EventHandler(this.tsbPlanNabaveSpremiZatvori_Click);
            // 
            // tsbPlanNabaveOdustani
            // 
            this.tsbPlanNabaveOdustani.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbPlanNabaveOdustani.Image = ((System.Drawing.Image)(resources.GetObject("tsbPlanNabaveOdustani.Image")));
            this.tsbPlanNabaveOdustani.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPlanNabaveOdustani.Name = "tsbPlanNabaveOdustani";
            this.tsbPlanNabaveOdustani.Size = new System.Drawing.Size(103, 22);
            this.tsbPlanNabaveOdustani.Text = "Odustani i zatvori";
            this.tsbPlanNabaveOdustani.Click += new System.EventHandler(this.tsbPlanNabaveOdustani_Click);
            // 
            // frmMargine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 193);
            this.ControlBox = false;
            this.Controls.Add(this.tspPlanNabave);
            this.Controls.Add(this.lbldesna);
            this.Controls.Add(this.txtRight);
            this.Controls.Add(this.lblLeft);
            this.Controls.Add(this.txtLeft);
            this.Controls.Add(this.lblBottom);
            this.Controls.Add(this.txtDole);
            this.Controls.Add(this.lblTop);
            this.Controls.Add(this.txtGore);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMargine";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Podešavanje margina";
            this.tspPlanNabave.ResumeLayout(false);
            this.tspPlanNabave.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.TextBox txtGore;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.Label lblBottom;
        private System.Windows.Forms.TextBox txtDole;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.TextBox txtLeft;
        private System.Windows.Forms.Label lbldesna;
        private System.Windows.Forms.TextBox txtRight;
        private System.Windows.Forms.ToolStrip tspPlanNabave;
        private System.Windows.Forms.ToolStripButton tsbPlanNabaveSpremiZatvori;
        private System.Windows.Forms.ToolStripButton tsbPlanNabaveOdustani;

    }
}
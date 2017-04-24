namespace JavnaNabava.UI.Nabava
{
    partial class PlanNabveIspis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlanNabveIspis));
            this.tspNarudzbenica = new System.Windows.Forms.ToolStrip();
            this.tsbNarudzbenicaSpremiZatvori = new System.Windows.Forms.ToolStripButton();
            this.tsbNarudzbenicaOdustani = new System.Windows.Forms.ToolStripButton();
            this.udtDatumIspisa = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.lblCPVOznaka = new System.Windows.Forms.Label();
            this.tspNarudzbenica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udtDatumIspisa)).BeginInit();
            this.SuspendLayout();
            // 
            // tspNarudzbenica
            // 
            this.tspNarudzbenica.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNarudzbenicaSpremiZatvori,
            this.tsbNarudzbenicaOdustani});
            this.tspNarudzbenica.Location = new System.Drawing.Point(0, 0);
            this.tspNarudzbenica.Name = "tspNarudzbenica";
            this.tspNarudzbenica.Size = new System.Drawing.Size(315, 25);
            this.tspNarudzbenica.TabIndex = 20;
            this.tspNarudzbenica.Text = "toolStrip1";
            // 
            // tsbNarudzbenicaSpremiZatvori
            // 
            this.tsbNarudzbenicaSpremiZatvori.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbNarudzbenicaSpremiZatvori.Image = ((System.Drawing.Image)(resources.GetObject("tsbNarudzbenicaSpremiZatvori.Image")));
            this.tsbNarudzbenicaSpremiZatvori.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNarudzbenicaSpremiZatvori.Name = "tsbNarudzbenicaSpremiZatvori";
            this.tsbNarudzbenicaSpremiZatvori.Size = new System.Drawing.Size(107, 22);
            this.tsbNarudzbenicaSpremiZatvori.Text = "Ispis plana nabave";
            this.tsbNarudzbenicaSpremiZatvori.Click += new System.EventHandler(this.tsbNarudzbenicaSpremiZatvori_Click);
            // 
            // tsbNarudzbenicaOdustani
            // 
            this.tsbNarudzbenicaOdustani.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbNarudzbenicaOdustani.Image = ((System.Drawing.Image)(resources.GetObject("tsbNarudzbenicaOdustani.Image")));
            this.tsbNarudzbenicaOdustani.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNarudzbenicaOdustani.Name = "tsbNarudzbenicaOdustani";
            this.tsbNarudzbenicaOdustani.Size = new System.Drawing.Size(103, 22);
            this.tsbNarudzbenicaOdustani.Text = "Odustani i zatvori";
            this.tsbNarudzbenicaOdustani.Click += new System.EventHandler(this.tsbNarudzbenicaOdustani_Click);
            // 
            // udtDatumIspisa
            // 
            this.udtDatumIspisa.Location = new System.Drawing.Point(13, 61);
            this.udtDatumIspisa.Name = "udtDatumIspisa";
            this.udtDatumIspisa.Size = new System.Drawing.Size(242, 21);
            this.udtDatumIspisa.TabIndex = 67;
            // 
            // lblCPVOznaka
            // 
            this.lblCPVOznaka.AutoSize = true;
            this.lblCPVOznaka.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCPVOznaka.Location = new System.Drawing.Point(13, 40);
            this.lblCPVOznaka.Name = "lblCPVOznaka";
            this.lblCPVOznaka.Size = new System.Drawing.Size(208, 13);
            this.lblCPVOznaka.TabIndex = 68;
            this.lblCPVOznaka.Text = "Odaberite datum za ispis na planu nabave:";
            // 
            // PlanNabveIspis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCPVOznaka);
            this.Controls.Add(this.udtDatumIspisa);
            this.Controls.Add(this.tspNarudzbenica);
            this.Name = "PlanNabveIspis";
            this.Size = new System.Drawing.Size(315, 184);
            this.tspNarudzbenica.ResumeLayout(false);
            this.tspNarudzbenica.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udtDatumIspisa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tspNarudzbenica;
        private System.Windows.Forms.ToolStripButton tsbNarudzbenicaSpremiZatvori;
        private System.Windows.Forms.ToolStripButton tsbNarudzbenicaOdustani;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtDatumIspisa;
        private System.Windows.Forms.Label lblCPVOznaka;


    }
}

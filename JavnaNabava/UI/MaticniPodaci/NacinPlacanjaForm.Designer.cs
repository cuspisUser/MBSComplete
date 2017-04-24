namespace JavnaNabava.UI.MaticniPodaci
{
    partial class uscNacinPlacanjaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uscNacinPlacanjaForm));
            this.tlpVrsteNabave = new System.Windows.Forms.TableLayoutPanel();
            this.lblValidationMessages = new System.Windows.Forms.Label();
            this.lblNaziv = new System.Windows.Forms.Label();
            this.uteNaziv = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.tspNacinPlacanja = new System.Windows.Forms.ToolStrip();
            this.tsbNacinPlacanjaSpremiNovi = new System.Windows.Forms.ToolStripButton();
            this.tsbNacinPlacanjaSpremiZatvori = new System.Windows.Forms.ToolStripButton();
            this.tsbNacinPlacanjaOdustani = new System.Windows.Forms.ToolStripButton();
            this.tlpVrsteNabave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uteNaziv)).BeginInit();
            this.tspNacinPlacanja.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpVrsteNabave
            // 
            this.tlpVrsteNabave.AutoSize = true;
            this.tlpVrsteNabave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpVrsteNabave.ColumnCount = 2;
            this.tlpVrsteNabave.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpVrsteNabave.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 346F));
            this.tlpVrsteNabave.Controls.Add(this.lblValidationMessages, 0, 0);
            this.tlpVrsteNabave.Controls.Add(this.lblNaziv, 0, 1);
            this.tlpVrsteNabave.Controls.Add(this.uteNaziv, 1, 1);
            this.tlpVrsteNabave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpVrsteNabave.Location = new System.Drawing.Point(0, 25);
            this.tlpVrsteNabave.Name = "tlpVrsteNabave";
            this.tlpVrsteNabave.Padding = new System.Windows.Forms.Padding(5);
            this.tlpVrsteNabave.RowCount = 3;
            this.tlpVrsteNabave.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpVrsteNabave.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpVrsteNabave.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tlpVrsteNabave.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tlpVrsteNabave.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tlpVrsteNabave.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tlpVrsteNabave.Size = new System.Drawing.Size(405, 120);
            this.tlpVrsteNabave.TabIndex = 21;
            // 
            // lblValidationMessages
            // 
            this.lblValidationMessages.AutoSize = true;
            this.lblValidationMessages.ForeColor = System.Drawing.Color.Red;
            this.lblValidationMessages.Location = new System.Drawing.Point(8, 5);
            this.lblValidationMessages.Name = "lblValidationMessages";
            this.lblValidationMessages.Padding = new System.Windows.Forms.Padding(0, 2, 0, 5);
            this.lblValidationMessages.Size = new System.Drawing.Size(0, 20);
            this.lblValidationMessages.TabIndex = 18;
            // 
            // lblNaziv
            // 
            this.lblNaziv.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNaziv.Location = new System.Drawing.Point(8, 32);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.Size = new System.Drawing.Size(43, 13);
            this.lblNaziv.TabIndex = 20;
            this.lblNaziv.Text = "Naziv:";
            // 
            // uteNaziv
            // 
            this.uteNaziv.Location = new System.Drawing.Point(57, 28);
            this.uteNaziv.MaxLength = 20;
            this.uteNaziv.Name = "uteNaziv";
            this.uteNaziv.Size = new System.Drawing.Size(220, 21);
            this.uteNaziv.TabIndex = 21;
            // 
            // tspNacinPlacanja
            // 
            this.tspNacinPlacanja.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNacinPlacanjaSpremiNovi,
            this.tsbNacinPlacanjaSpremiZatvori,
            this.tsbNacinPlacanjaOdustani});
            this.tspNacinPlacanja.Location = new System.Drawing.Point(0, 0);
            this.tspNacinPlacanja.Name = "tspNacinPlacanja";
            this.tspNacinPlacanja.Size = new System.Drawing.Size(405, 25);
            this.tspNacinPlacanja.TabIndex = 20;
            this.tspNacinPlacanja.Text = "toolStrip1";
            // 
            // tsbNacinPlacanjaSpremiNovi
            // 
            this.tsbNacinPlacanjaSpremiNovi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbNacinPlacanjaSpremiNovi.Image = ((System.Drawing.Image)(resources.GetObject("tsbNacinPlacanjaSpremiNovi.Image")));
            this.tsbNacinPlacanjaSpremiNovi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNacinPlacanjaSpremiNovi.Name = "tsbNacinPlacanjaSpremiNovi";
            this.tsbNacinPlacanjaSpremiNovi.Size = new System.Drawing.Size(80, 22);
            this.tsbNacinPlacanjaSpremiNovi.Text = "Spremi i novi";
            this.tsbNacinPlacanjaSpremiNovi.Click += new System.EventHandler(this.tsbNacinPlacanjaSpremiNovi_Click);
            // 
            // tsbNacinPlacanjaSpremiZatvori
            // 
            this.tsbNacinPlacanjaSpremiZatvori.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbNacinPlacanjaSpremiZatvori.Image = ((System.Drawing.Image)(resources.GetObject("tsbNacinPlacanjaSpremiZatvori.Image")));
            this.tsbNacinPlacanjaSpremiZatvori.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNacinPlacanjaSpremiZatvori.Name = "tsbNacinPlacanjaSpremiZatvori";
            this.tsbNacinPlacanjaSpremiZatvori.Size = new System.Drawing.Size(92, 22);
            this.tsbNacinPlacanjaSpremiZatvori.Text = "Spremi i zatvori";
            this.tsbNacinPlacanjaSpremiZatvori.Click += new System.EventHandler(this.tsbNacinPlacanjaSpremiZatvori_Click);
            // 
            // tsbNacinPlacanjaOdustani
            // 
            this.tsbNacinPlacanjaOdustani.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbNacinPlacanjaOdustani.Image = ((System.Drawing.Image)(resources.GetObject("tsbNacinPlacanjaOdustani.Image")));
            this.tsbNacinPlacanjaOdustani.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNacinPlacanjaOdustani.Name = "tsbNacinPlacanjaOdustani";
            this.tsbNacinPlacanjaOdustani.Size = new System.Drawing.Size(103, 22);
            this.tsbNacinPlacanjaOdustani.Text = "Odustani i zatvori";
            this.tsbNacinPlacanjaOdustani.Click += new System.EventHandler(this.tsbNacinPlacanjaOdustani_Click);
            // 
            // uscNacinPlacanjaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpVrsteNabave);
            this.Controls.Add(this.tspNacinPlacanja);
            this.Name = "uscNacinPlacanjaForm";
            this.Size = new System.Drawing.Size(405, 145);
            this.Load += new System.EventHandler(this.uscNacinPlacanjaForm_Load);
            this.tlpVrsteNabave.ResumeLayout(false);
            this.tlpVrsteNabave.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uteNaziv)).EndInit();
            this.tspNacinPlacanja.ResumeLayout(false);
            this.tspNacinPlacanja.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpVrsteNabave;
        private System.Windows.Forms.Label lblValidationMessages;
        private System.Windows.Forms.ToolStrip tspNacinPlacanja;
        private System.Windows.Forms.ToolStripButton tsbNacinPlacanjaSpremiNovi;
        private System.Windows.Forms.ToolStripButton tsbNacinPlacanjaSpremiZatvori;
        private System.Windows.Forms.ToolStripButton tsbNacinPlacanjaOdustani;
        private System.Windows.Forms.Label lblNaziv;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteNaziv;


    }
}

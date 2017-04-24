namespace JavnaNabava.UI.Nabava
{
    partial class NarudzbenicaProizvodForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NarudzbenicaProizvodForm));
            this.tspNarudzbenica = new System.Windows.Forms.ToolStrip();
            this.tsbNarudzbenicaSpremiNovi = new System.Windows.Forms.ToolStripButton();
            this.tsbNarudzbenicaSpremiZatvori = new System.Windows.Forms.ToolStripButton();
            this.tsbNarudzbenicaOdustani = new System.Windows.Forms.ToolStripButton();
            this.lblValidationMessages = new System.Windows.Forms.Label();
            this.ucbProizvod = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblKonto = new System.Windows.Forms.Label();
            this.lblKolicina = new System.Windows.Forms.Label();
            this.uneKolicina = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.lblJedinicaMjere = new System.Windows.Forms.Label();
            this.tspNarudzbenica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucbProizvod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneKolicina)).BeginInit();
            this.SuspendLayout();
            // 
            // tspNarudzbenica
            // 
            this.tspNarudzbenica.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNarudzbenicaSpremiNovi,
            this.tsbNarudzbenicaSpremiZatvori,
            this.tsbNarudzbenicaOdustani});
            this.tspNarudzbenica.Location = new System.Drawing.Point(0, 0);
            this.tspNarudzbenica.Name = "tspNarudzbenica";
            this.tspNarudzbenica.Size = new System.Drawing.Size(517, 25);
            this.tspNarudzbenica.TabIndex = 20;
            this.tspNarudzbenica.Text = "toolStrip1";
            // 
            // tsbNarudzbenicaSpremiNovi
            // 
            this.tsbNarudzbenicaSpremiNovi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbNarudzbenicaSpremiNovi.Image = ((System.Drawing.Image)(resources.GetObject("tsbNarudzbenicaSpremiNovi.Image")));
            this.tsbNarudzbenicaSpremiNovi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNarudzbenicaSpremiNovi.Name = "tsbNarudzbenicaSpremiNovi";
            this.tsbNarudzbenicaSpremiNovi.Size = new System.Drawing.Size(80, 22);
            this.tsbNarudzbenicaSpremiNovi.Text = "Spremi i novi";
            this.tsbNarudzbenicaSpremiNovi.Click += new System.EventHandler(this.tsbNarudzbenicaSpremiNovi_Click);
            // 
            // tsbNarudzbenicaSpremiZatvori
            // 
            this.tsbNarudzbenicaSpremiZatvori.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbNarudzbenicaSpremiZatvori.Image = ((System.Drawing.Image)(resources.GetObject("tsbNarudzbenicaSpremiZatvori.Image")));
            this.tsbNarudzbenicaSpremiZatvori.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNarudzbenicaSpremiZatvori.Name = "tsbNarudzbenicaSpremiZatvori";
            this.tsbNarudzbenicaSpremiZatvori.Size = new System.Drawing.Size(92, 22);
            this.tsbNarudzbenicaSpremiZatvori.Text = "Spremi i zatvori";
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
            // lblValidationMessages
            // 
            this.lblValidationMessages.AutoSize = true;
            this.lblValidationMessages.ForeColor = System.Drawing.Color.Red;
            this.lblValidationMessages.Location = new System.Drawing.Point(3, 25);
            this.lblValidationMessages.Name = "lblValidationMessages";
            this.lblValidationMessages.Padding = new System.Windows.Forms.Padding(0, 2, 0, 5);
            this.lblValidationMessages.Size = new System.Drawing.Size(0, 20);
            this.lblValidationMessages.TabIndex = 21;
            // 
            // ucbProizvod
            // 
            this.ucbProizvod.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.ucbProizvod.DisplayMember = "Naziv";
            this.ucbProizvod.Location = new System.Drawing.Point(97, 52);
            this.ucbProizvod.MaxDropDownItems = 20;
            this.ucbProizvod.Name = "ucbProizvod";
            this.ucbProizvod.Size = new System.Drawing.Size(364, 21);
            this.ucbProizvod.TabIndex = 50;
            this.ucbProizvod.ValueMember = "ID";
            this.ucbProizvod.ValueChanged += new System.EventHandler(this.ucbProizvod_ValueChanged);
            // 
            // lblKonto
            // 
            this.lblKonto.AutoSize = true;
            this.lblKonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKonto.Location = new System.Drawing.Point(32, 56);
            this.lblKonto.Name = "lblKonto";
            this.lblKonto.Size = new System.Drawing.Size(60, 13);
            this.lblKonto.TabIndex = 57;
            this.lblKonto.Text = "Proizvod:";
            // 
            // lblKolicina
            // 
            this.lblKolicina.AutoSize = true;
            this.lblKolicina.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKolicina.Location = new System.Drawing.Point(36, 114);
            this.lblKolicina.Name = "lblKolicina";
            this.lblKolicina.Size = new System.Drawing.Size(56, 13);
            this.lblKolicina.TabIndex = 59;
            this.lblKolicina.Text = "Količina:";
            // 
            // uneKolicina
            // 
            this.uneKolicina.Location = new System.Drawing.Point(96, 110);
            this.uneKolicina.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.uneKolicina.MaximumSize = new System.Drawing.Size(9999, 0);
            this.uneKolicina.MaxValue = 9999999D;
            this.uneKolicina.MinValue = 0D;
            this.uneKolicina.Name = "uneKolicina";
            this.uneKolicina.Nullable = true;
            this.uneKolicina.NullText = " ";
            this.uneKolicina.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.uneKolicina.PromptChar = ' ';
            this.uneKolicina.Size = new System.Drawing.Size(365, 21);
            this.uneKolicina.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(0, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "Jedinica mjere:";
            // 
            // lblJedinicaMjere
            // 
            this.lblJedinicaMjere.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJedinicaMjere.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblJedinicaMjere.Location = new System.Drawing.Point(96, 80);
            this.lblJedinicaMjere.Name = "lblJedinicaMjere";
            this.lblJedinicaMjere.Size = new System.Drawing.Size(365, 21);
            this.lblJedinicaMjere.TabIndex = 61;
            // 
            // NarudzbenicaProizvodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblJedinicaMjere);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uneKolicina);
            this.Controls.Add(this.lblKolicina);
            this.Controls.Add(this.lblKonto);
            this.Controls.Add(this.ucbProizvod);
            this.Controls.Add(this.lblValidationMessages);
            this.Controls.Add(this.tspNarudzbenica);
            this.Name = "NarudzbenicaProizvodForm";
            this.Size = new System.Drawing.Size(517, 187);
            this.Load += new System.EventHandler(this.NarudzbenicaProizvodForm_Load);
            this.tspNarudzbenica.ResumeLayout(false);
            this.tspNarudzbenica.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucbProizvod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneKolicina)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tspNarudzbenica;
        private System.Windows.Forms.ToolStripButton tsbNarudzbenicaSpremiNovi;
        private System.Windows.Forms.ToolStripButton tsbNarudzbenicaSpremiZatvori;
        private System.Windows.Forms.ToolStripButton tsbNarudzbenicaOdustani;
        private System.Windows.Forms.Label lblValidationMessages;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ucbProizvod;
        private System.Windows.Forms.Label lblKonto;
        private System.Windows.Forms.Label lblKolicina;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneKolicina;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblJedinicaMjere;


    }
}

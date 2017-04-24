namespace Materijalno.UI.Dokumenti
{
    partial class UnosMeduskladisniceOdredivanjeKolicineForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnosMeduskladisniceOdredivanjeKolicineForm));
            this.tspForm = new System.Windows.Forms.ToolStrip();
            this.tsbSpremiNovi = new System.Windows.Forms.ToolStripButton();
            this.tsbSpremiZatvori = new System.Windows.Forms.ToolStripButton();
            this.tsbOdustani = new System.Windows.Forms.ToolStripButton();
            this.tlpForm = new System.Windows.Forms.TableLayoutPanel();
            this.uneUlaznaCijena = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label3 = new System.Windows.Forms.Label();
            this.lblName1 = new System.Windows.Forms.Label();
            this.lblName3 = new System.Windows.Forms.Label();
            this.uneIzlaznaCijena = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.uceProizvod = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStanje = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.uneKolicina = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.lblValidationMessages = new System.Windows.Forms.Label();
            this.tspForm.SuspendLayout();
            this.tlpForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uneUlaznaCijena)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneIzlaznaCijena)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceProizvod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneKolicina)).BeginInit();
            this.SuspendLayout();
            // 
            // tspForm
            // 
            this.tspForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSpremiNovi,
            this.tsbSpremiZatvori,
            this.tsbOdustani});
            this.tspForm.Location = new System.Drawing.Point(0, 0);
            this.tspForm.Name = "tspForm";
            this.tspForm.Size = new System.Drawing.Size(382, 25);
            this.tspForm.TabIndex = 20;
            this.tspForm.Text = "toolStrip1";
            // 
            // tsbSpremiNovi
            // 
            this.tsbSpremiNovi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSpremiNovi.Image = ((System.Drawing.Image)(resources.GetObject("tsbSpremiNovi.Image")));
            this.tsbSpremiNovi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSpremiNovi.Name = "tsbSpremiNovi";
            this.tsbSpremiNovi.Size = new System.Drawing.Size(80, 22);
            this.tsbSpremiNovi.Text = "Spremi i novi";
            this.tsbSpremiNovi.Click += new System.EventHandler(this.tsbSpremiNovi_Click);
            // 
            // tsbSpremiZatvori
            // 
            this.tsbSpremiZatvori.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSpremiZatvori.Image = ((System.Drawing.Image)(resources.GetObject("tsbSpremiZatvori.Image")));
            this.tsbSpremiZatvori.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSpremiZatvori.Name = "tsbSpremiZatvori";
            this.tsbSpremiZatvori.Size = new System.Drawing.Size(92, 22);
            this.tsbSpremiZatvori.Text = "Spremi i zatvori";
            this.tsbSpremiZatvori.Click += new System.EventHandler(this.tsbSpremiZatvori_Click);
            // 
            // tsbOdustani
            // 
            this.tsbOdustani.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbOdustani.Image = ((System.Drawing.Image)(resources.GetObject("tsbOdustani.Image")));
            this.tsbOdustani.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOdustani.Name = "tsbOdustani";
            this.tsbOdustani.Size = new System.Drawing.Size(103, 22);
            this.tsbOdustani.Text = "Odustani i zatvori";
            this.tsbOdustani.Click += new System.EventHandler(this.tsbOdustani_Click);
            // 
            // tlpForm
            // 
            this.tlpForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpForm.ColumnCount = 2;
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 346F));
            this.tlpForm.Controls.Add(this.uneUlaznaCijena, 1, 2);
            this.tlpForm.Controls.Add(this.label3, 0, 2);
            this.tlpForm.Controls.Add(this.lblName1, 0, 0);
            this.tlpForm.Controls.Add(this.lblName3, 0, 1);
            this.tlpForm.Controls.Add(this.uneIzlaznaCijena, 1, 1);
            this.tlpForm.Controls.Add(this.uceProizvod, 1, 0);
            this.tlpForm.Controls.Add(this.label1, 0, 4);
            this.tlpForm.Controls.Add(this.lblStanje, 1, 4);
            this.tlpForm.Controls.Add(this.label2, 0, 3);
            this.tlpForm.Controls.Add(this.uneKolicina, 1, 3);
            this.tlpForm.Location = new System.Drawing.Point(3, 49);
            this.tlpForm.Name = "tlpForm";
            this.tlpForm.Padding = new System.Windows.Forms.Padding(5);
            this.tlpForm.RowCount = 5;
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpForm.Size = new System.Drawing.Size(376, 176);
            this.tlpForm.TabIndex = 70;
            // 
            // uneUlaznaCijena
            // 
            this.uneUlaznaCijena.Location = new System.Drawing.Point(113, 63);
            this.uneUlaznaCijena.MaskInput = "{LOC}-nnnnnnnn.nnnn";
            this.uneUlaznaCijena.MaximumSize = new System.Drawing.Size(9999, 0);
            this.uneUlaznaCijena.MaxValue = 9999999999D;
            this.uneUlaznaCijena.MinValue = 0D;
            this.uneUlaznaCijena.Name = "uneUlaznaCijena";
            this.uneUlaznaCijena.Nullable = true;
            this.uneUlaznaCijena.NullText = " ";
            this.uneUlaznaCijena.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.uneUlaznaCijena.PromptChar = ' ';
            this.uneUlaznaCijena.Size = new System.Drawing.Size(220, 21);
            this.uneUlaznaCijena.TabIndex = 87;
            this.uneUlaznaCijena.BeforeEnterEditMode += new System.ComponentModel.CancelEventHandler(this.uneUlaznaCijena_BeforeEnterEditMode);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(8, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 88;
            this.label3.Text = "Ulazna Cijena:";
            // 
            // lblName1
            // 
            this.lblName1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName1.AutoSize = true;
            this.lblName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblName1.Location = new System.Drawing.Point(8, 13);
            this.lblName1.Name = "lblName1";
            this.lblName1.Size = new System.Drawing.Size(60, 13);
            this.lblName1.TabIndex = 19;
            this.lblName1.Text = "Proizvod:";
            // 
            // lblName3
            // 
            this.lblName3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName3.AutoSize = true;
            this.lblName3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblName3.Location = new System.Drawing.Point(8, 40);
            this.lblName3.Name = "lblName3";
            this.lblName3.Size = new System.Drawing.Size(90, 13);
            this.lblName3.TabIndex = 70;
            this.lblName3.Text = "Izlazna Cijena:";
            // 
            // uneIzlaznaCijena
            // 
            this.uneIzlaznaCijena.Location = new System.Drawing.Point(113, 37);
            this.uneIzlaznaCijena.MaskInput = "{LOC}-nnnnnnnn.nnnn";
            this.uneIzlaznaCijena.MaximumSize = new System.Drawing.Size(9999, 0);
            this.uneIzlaznaCijena.MaxValue = 9999999999D;
            this.uneIzlaznaCijena.MinValue = 0D;
            this.uneIzlaznaCijena.Name = "uneIzlaznaCijena";
            this.uneIzlaznaCijena.Nullable = true;
            this.uneIzlaznaCijena.NullText = " ";
            this.uneIzlaznaCijena.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.uneIzlaznaCijena.PromptChar = ' ';
            this.uneIzlaznaCijena.Size = new System.Drawing.Size(220, 21);
            this.uneIzlaznaCijena.TabIndex = 86;
            this.uneIzlaznaCijena.BeforeEnterEditMode += new System.ComponentModel.CancelEventHandler(this.uneIzlaznaCijena_BeforeEnterEditMode);
            // 
            // uceProizvod
            // 
            this.uceProizvod.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.uceProizvod.DisplayMember = "Naziv";
            this.uceProizvod.Location = new System.Drawing.Point(113, 8);
            this.uceProizvod.MaxDropDownItems = 20;
            this.uceProizvod.Name = "uceProizvod";
            this.uceProizvod.Size = new System.Drawing.Size(220, 21);
            this.uceProizvod.TabIndex = 85;
            this.uceProizvod.ValueMember = "ID";
            this.uceProizvod.ValueChanged += new System.EventHandler(this.uceProizvod_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 87;
            this.label1.Text = "Stanje na skladištu:";
            // 
            // lblStanje
            // 
            this.lblStanje.AutoSize = true;
            this.lblStanje.Location = new System.Drawing.Point(113, 119);
            this.lblStanje.Name = "lblStanje";
            this.lblStanje.Size = new System.Drawing.Size(0, 13);
            this.lblStanje.TabIndex = 86;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(8, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 75;
            this.label2.Text = "Količina:";
            // 
            // uneKolicina
            // 
            this.uneKolicina.Location = new System.Drawing.Point(113, 89);
            this.uneKolicina.MaskInput = "{LOC}-nnnnnnnn.nnnn";
            this.uneKolicina.MaximumSize = new System.Drawing.Size(9999, 0);
            this.uneKolicina.MaxValue = 9999999999D;
            this.uneKolicina.MinValue = 0D;
            this.uneKolicina.Name = "uneKolicina";
            this.uneKolicina.Nullable = true;
            this.uneKolicina.NullText = " ";
            this.uneKolicina.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.uneKolicina.PromptChar = ' ';
            this.uneKolicina.Size = new System.Drawing.Size(220, 21);
            this.uneKolicina.TabIndex = 88;
            this.uneKolicina.BeforeEnterEditMode += new System.ComponentModel.CancelEventHandler(this.uneKolicina_BeforeEnterEditMode);
            // 
            // lblValidationMessages
            // 
            this.lblValidationMessages.AutoSize = true;
            this.lblValidationMessages.ForeColor = System.Drawing.Color.Red;
            this.lblValidationMessages.Location = new System.Drawing.Point(6, 25);
            this.lblValidationMessages.Name = "lblValidationMessages";
            this.lblValidationMessages.Padding = new System.Windows.Forms.Padding(0, 2, 0, 5);
            this.lblValidationMessages.Size = new System.Drawing.Size(0, 20);
            this.lblValidationMessages.TabIndex = 71;
            // 
            // UnosMeduskladisniceOdredivanjeKolicineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblValidationMessages);
            this.Controls.Add(this.tlpForm);
            this.Controls.Add(this.tspForm);
            this.Name = "UnosMeduskladisniceOdredivanjeKolicineForm";
            this.Size = new System.Drawing.Size(382, 228);
            this.Load += new System.EventHandler(this.Form_Load);
            this.tspForm.ResumeLayout(false);
            this.tspForm.PerformLayout();
            this.tlpForm.ResumeLayout(false);
            this.tlpForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uneUlaznaCijena)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneIzlaznaCijena)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceProizvod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneKolicina)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tspForm;
        private System.Windows.Forms.ToolStripButton tsbSpremiNovi;
        private System.Windows.Forms.ToolStripButton tsbSpremiZatvori;
        private System.Windows.Forms.ToolStripButton tsbOdustani;
        private System.Windows.Forms.TableLayoutPanel tlpForm;
        private System.Windows.Forms.Label lblName1;
        private System.Windows.Forms.Label lblName3;
        private System.Windows.Forms.Label label2;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneIzlaznaCijena;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneKolicina;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceProizvod;
        private System.Windows.Forms.Label lblValidationMessages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStanje;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneUlaznaCijena;
        private System.Windows.Forms.Label label3;


    }
}

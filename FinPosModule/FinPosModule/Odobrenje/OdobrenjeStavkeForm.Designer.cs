namespace FinPosModule
{
    partial class OdobrenjeStavkeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OdobrenjeStavkeForm));
            this.tspForm = new System.Windows.Forms.ToolStrip();
            this.tsbSpremiZatvori = new System.Windows.Forms.ToolStripButton();
            this.tsbSpremiNovi = new System.Windows.Forms.ToolStripButton();
            this.tsbOdustani = new System.Windows.Forms.ToolStripButton();
            this.lblValidationMessages = new System.Windows.Forms.Label();
            this.tlpForm = new System.Windows.Forms.TableLayoutPanel();
            this.ucePorez = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblName1 = new System.Windows.Forms.Label();
            this.lblName3 = new System.Windows.Forms.Label();
            this.uneCijenaNeto = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.uceProizvod = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label2 = new System.Windows.Forms.Label();
            this.uneKolicina = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.uneRabat = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.uneCijenaPDV = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStanje = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tspForm.SuspendLayout();
            this.tlpForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucePorez)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneCijenaNeto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceProizvod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneKolicina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneRabat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneCijenaPDV)).BeginInit();
            this.SuspendLayout();
            // 
            // tspForm
            // 
            this.tspForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSpremiZatvori,
            this.tsbSpremiNovi,
            this.tsbOdustani});
            this.tspForm.Location = new System.Drawing.Point(0, 0);
            this.tspForm.Name = "tspForm";
            this.tspForm.Size = new System.Drawing.Size(386, 25);
            this.tspForm.TabIndex = 20;
            this.tspForm.Text = "toolStrip1";
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
            // lblValidationMessages
            // 
            this.lblValidationMessages.AutoSize = true;
            this.lblValidationMessages.ForeColor = System.Drawing.Color.Red;
            this.lblValidationMessages.Location = new System.Drawing.Point(11, 25);
            this.lblValidationMessages.Name = "lblValidationMessages";
            this.lblValidationMessages.Padding = new System.Windows.Forms.Padding(0, 2, 0, 5);
            this.lblValidationMessages.Size = new System.Drawing.Size(0, 20);
            this.lblValidationMessages.TabIndex = 67;
            // 
            // tlpForm
            // 
            this.tlpForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpForm.ColumnCount = 2;
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 346F));
            this.tlpForm.Controls.Add(this.ucePorez, 1, 1);
            this.tlpForm.Controls.Add(this.lblName1, 0, 0);
            this.tlpForm.Controls.Add(this.lblName3, 0, 2);
            this.tlpForm.Controls.Add(this.uneCijenaNeto, 1, 2);
            this.tlpForm.Controls.Add(this.uceProizvod, 1, 0);
            this.tlpForm.Controls.Add(this.label2, 0, 1);
            this.tlpForm.Controls.Add(this.uneKolicina, 1, 5);
            this.tlpForm.Controls.Add(this.uneRabat, 1, 4);
            this.tlpForm.Controls.Add(this.uneCijenaPDV, 1, 3);
            this.tlpForm.Controls.Add(this.label3, 0, 5);
            this.tlpForm.Controls.Add(this.label1, 0, 4);
            this.tlpForm.Controls.Add(this.lblStanje, 0, 6);
            this.tlpForm.Controls.Add(this.label4, 0, 3);
            this.tlpForm.Location = new System.Drawing.Point(3, 49);
            this.tlpForm.Name = "tlpForm";
            this.tlpForm.Padding = new System.Windows.Forms.Padding(5);
            this.tlpForm.RowCount = 7;
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpForm.Size = new System.Drawing.Size(354, 187);
            this.tlpForm.TabIndex = 70;
            // 
            // ucePorez
            // 
            this.ucePorez.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.ucePorez.DisplayMember = "Naziv";
            this.ucePorez.Location = new System.Drawing.Point(91, 37);
            this.ucePorez.MaxDropDownItems = 20;
            this.ucePorez.Name = "ucePorez";
            this.ucePorez.Size = new System.Drawing.Size(217, 21);
            this.ucePorez.TabIndex = 94;
            this.ucePorez.ValueMember = "ID";
            this.ucePorez.ValueChanged += new System.EventHandler(this.ucePorez_ValueChanged);
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
            this.lblName3.Location = new System.Drawing.Point(8, 66);
            this.lblName3.Name = "lblName3";
            this.lblName3.Size = new System.Drawing.Size(77, 13);
            this.lblName3.TabIndex = 70;
            this.lblName3.Text = "Cijena Neto:";
            // 
            // uneCijenaNeto
            // 
            this.uneCijenaNeto.Location = new System.Drawing.Point(91, 63);
            this.uneCijenaNeto.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.uneCijenaNeto.MaximumSize = new System.Drawing.Size(9999, 0);
            this.uneCijenaNeto.MaxValue = 9999999999D;
            this.uneCijenaNeto.MinValue = -9999999999D;
            this.uneCijenaNeto.Name = "uneCijenaNeto";
            this.uneCijenaNeto.Nullable = true;
            this.uneCijenaNeto.NullText = " ";
            this.uneCijenaNeto.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.uneCijenaNeto.PromptChar = ' ';
            this.uneCijenaNeto.Size = new System.Drawing.Size(220, 21);
            this.uneCijenaNeto.TabIndex = 82;
            this.uneCijenaNeto.ValueChanged += new System.EventHandler(this.uneCijenaNeto_ValueChanged);
            // 
            // uceProizvod
            // 
            this.uceProizvod.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.uceProizvod.DisplayMember = "Naziv";
            this.uceProizvod.Location = new System.Drawing.Point(91, 8);
            this.uceProizvod.MaxDropDownItems = 20;
            this.uceProizvod.Name = "uceProizvod";
            this.uceProizvod.Size = new System.Drawing.Size(217, 21);
            this.uceProizvod.TabIndex = 86;
            this.uceProizvod.ValueMember = "ID";
            this.uceProizvod.ValueChanged += new System.EventHandler(this.uceProizvod_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(8, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 75;
            this.label2.Text = "Porez:";
            // 
            // uneKolicina
            // 
            this.uneKolicina.Location = new System.Drawing.Point(91, 139);
            this.uneKolicina.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.uneKolicina.MaximumSize = new System.Drawing.Size(9999, 0);
            this.uneKolicina.MaxValue = 9999999999D;
            this.uneKolicina.MinValue = 0D;
            this.uneKolicina.Name = "uneKolicina";
            this.uneKolicina.Nullable = true;
            this.uneKolicina.NullText = " ";
            this.uneKolicina.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.uneKolicina.PromptChar = ' ';
            this.uneKolicina.Size = new System.Drawing.Size(220, 21);
            this.uneKolicina.TabIndex = 91;
            this.uneKolicina.ValueChanged += new System.EventHandler(this.uneKolicina_ValueChanged);
            // 
            // uneRabat
            // 
            this.uneRabat.Location = new System.Drawing.Point(91, 113);
            this.uneRabat.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.uneRabat.MaximumSize = new System.Drawing.Size(9999, 0);
            this.uneRabat.MaxValue = 100D;
            this.uneRabat.MinValue = 0D;
            this.uneRabat.Name = "uneRabat";
            this.uneRabat.Nullable = true;
            this.uneRabat.NullText = " ";
            this.uneRabat.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.uneRabat.PromptChar = ' ';
            this.uneRabat.Size = new System.Drawing.Size(220, 21);
            this.uneRabat.TabIndex = 89;
            this.uneRabat.ValueChanged += new System.EventHandler(this.uneRabat_ValueChanged);
            // 
            // uneCijenaPDV
            // 
            this.uneCijenaPDV.Location = new System.Drawing.Point(91, 88);
            this.uneCijenaPDV.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.uneCijenaPDV.MaximumSize = new System.Drawing.Size(9999, 0);
            this.uneCijenaPDV.MaxValue = 9999999999D;
            this.uneCijenaPDV.MinValue = -9999999D;
            this.uneCijenaPDV.Name = "uneCijenaPDV";
            this.uneCijenaPDV.Nullable = true;
            this.uneCijenaPDV.NullText = " ";
            this.uneCijenaPDV.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.uneCijenaPDV.PromptChar = ' ';
            this.uneCijenaPDV.Size = new System.Drawing.Size(220, 21);
            this.uneCijenaPDV.TabIndex = 93;
            this.uneCijenaPDV.ValueChanged += new System.EventHandler(this.uneCijenaPDV_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(8, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 90;
            this.label3.Text = "Količina:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(8, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 87;
            this.label1.Text = "Rabat:";
            // 
            // lblStanje
            // 
            this.lblStanje.AutoSize = true;
            this.lblStanje.Location = new System.Drawing.Point(8, 162);
            this.lblStanje.Name = "lblStanje";
            this.lblStanje.Size = new System.Drawing.Size(0, 13);
            this.lblStanje.TabIndex = 88;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(8, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 92;
            this.label4.Text = "Cijena PDV:";
            // 
            // OdobrenjeStavkeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpForm);
            this.Controls.Add(this.lblValidationMessages);
            this.Controls.Add(this.tspForm);
            this.Name = "OdobrenjeStavkeForm";
            this.Size = new System.Drawing.Size(386, 268);
            this.Load += new System.EventHandler(this.FormLoad);
            this.tspForm.ResumeLayout(false);
            this.tspForm.PerformLayout();
            this.tlpForm.ResumeLayout(false);
            this.tlpForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucePorez)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneCijenaNeto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceProizvod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneKolicina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneRabat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneCijenaPDV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tspForm;
        private System.Windows.Forms.ToolStripButton tsbSpremiZatvori;
        private System.Windows.Forms.ToolStripButton tsbOdustani;
        private System.Windows.Forms.Label lblValidationMessages;
        private System.Windows.Forms.TableLayoutPanel tlpForm;
        private System.Windows.Forms.Label lblName1;
        private System.Windows.Forms.Label lblName3;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneCijenaNeto;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceProizvod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStanje;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneRabat;
        private System.Windows.Forms.Label label3;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneKolicina;
        private System.Windows.Forms.Label label4;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneCijenaPDV;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ucePorez;
        private System.Windows.Forms.ToolStripButton tsbSpremiNovi;


    }
}

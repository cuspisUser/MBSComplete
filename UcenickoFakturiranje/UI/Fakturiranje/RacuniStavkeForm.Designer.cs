namespace UcenickoFakturiranje.UI.Fakturiranje
{
    partial class RacuniStavkeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RacuniStavkeForm));
            this.tspForm = new System.Windows.Forms.ToolStrip();
            this.tsbSpremiZatvori = new System.Windows.Forms.ToolStripButton();
            this.tsbOdustani = new System.Windows.Forms.ToolStripButton();
            this.lblValidationMessages = new System.Windows.Forms.Label();
            this.tlpForm = new System.Windows.Forms.TableLayoutPanel();
            this.uneUkupnaCijena = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.uneStopa = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label4 = new System.Windows.Forms.Label();
            this.lblName1 = new System.Windows.Forms.Label();
            this.uceProizvod = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.uteNazivProizvod = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblName3 = new System.Windows.Forms.Label();
            this.uneCijena = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label3 = new System.Windows.Forms.Label();
            this.uneRabat = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label2 = new System.Windows.Forms.Label();
            this.uneKolicina = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label5 = new System.Windows.Forms.Label();
            this.tspForm.SuspendLayout();
            this.tlpForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uneUkupnaCijena)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneStopa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceProizvod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteNazivProizvod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneCijena)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneRabat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneKolicina)).BeginInit();
            this.SuspendLayout();
            // 
            // tspForm
            // 
            this.tspForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSpremiZatvori,
            this.tsbOdustani});
            this.tspForm.Location = new System.Drawing.Point(0, 0);
            this.tspForm.Name = "tspForm";
            this.tspForm.Size = new System.Drawing.Size(399, 25);
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
            this.tlpForm.Controls.Add(this.uneUkupnaCijena, 1, 6);
            this.tlpForm.Controls.Add(this.uneStopa, 1, 5);
            this.tlpForm.Controls.Add(this.label4, 0, 5);
            this.tlpForm.Controls.Add(this.lblName1, 0, 0);
            this.tlpForm.Controls.Add(this.uceProizvod, 1, 0);
            this.tlpForm.Controls.Add(this.label1, 0, 1);
            this.tlpForm.Controls.Add(this.uteNazivProizvod, 1, 1);
            this.tlpForm.Controls.Add(this.lblName3, 0, 2);
            this.tlpForm.Controls.Add(this.uneCijena, 1, 2);
            this.tlpForm.Controls.Add(this.label3, 0, 3);
            this.tlpForm.Controls.Add(this.uneRabat, 1, 3);
            this.tlpForm.Controls.Add(this.label2, 0, 4);
            this.tlpForm.Controls.Add(this.uneKolicina, 1, 4);
            this.tlpForm.Controls.Add(this.label5, 0, 6);
            this.tlpForm.Location = new System.Drawing.Point(3, 49);
            this.tlpForm.Name = "tlpForm";
            this.tlpForm.Padding = new System.Windows.Forms.Padding(5);
            this.tlpForm.RowCount = 8;
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpForm.Size = new System.Drawing.Size(366, 242);
            this.tlpForm.TabIndex = 70;
            // 
            // uneUkupnaCijena
            // 
            this.uneUkupnaCijena.Location = new System.Drawing.Point(100, 191);
            this.uneUkupnaCijena.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.uneUkupnaCijena.MaximumSize = new System.Drawing.Size(9999, 0);
            this.uneUkupnaCijena.MaxValue = 9999999999D;
            this.uneUkupnaCijena.MinValue = 0D;
            this.uneUkupnaCijena.Name = "uneUkupnaCijena";
            this.uneUkupnaCijena.Nullable = true;
            this.uneUkupnaCijena.NullText = " ";
            this.uneUkupnaCijena.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.uneUkupnaCijena.PromptChar = ' ';
            this.uneUkupnaCijena.ReadOnly = true;
            this.uneUkupnaCijena.Size = new System.Drawing.Size(220, 21);
            this.uneUkupnaCijena.TabIndex = 94;
            // 
            // uneStopa
            // 
            this.uneStopa.Location = new System.Drawing.Point(100, 163);
            this.uneStopa.MaskInput = "{LOC}-nnnnnnnn.nnnn";
            this.uneStopa.MaximumSize = new System.Drawing.Size(9999, 0);
            this.uneStopa.MaxValue = 100D;
            this.uneStopa.MinValue = 0D;
            this.uneStopa.Name = "uneStopa";
            this.uneStopa.Nullable = true;
            this.uneStopa.NullText = " ";
            this.uneStopa.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.uneStopa.PromptChar = ' ';
            this.uneStopa.Size = new System.Drawing.Size(220, 21);
            this.uneStopa.TabIndex = 92;
            this.uneStopa.ValueChanged += new System.EventHandler(this.uneStopa_ValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(8, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 91;
            this.label4.Text = "PDV stopa:";
            // 
            // lblName1
            // 
            this.lblName1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName1.AutoSize = true;
            this.lblName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblName1.Location = new System.Drawing.Point(8, 12);
            this.lblName1.Name = "lblName1";
            this.lblName1.Size = new System.Drawing.Size(60, 13);
            this.lblName1.TabIndex = 19;
            this.lblName1.Text = "Proizvod:";
            // 
            // uceProizvod
            // 
            this.uceProizvod.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.uceProizvod.DisplayMember = "Naziv";
            this.uceProizvod.Location = new System.Drawing.Point(100, 8);
            this.uceProizvod.MaxDropDownItems = 20;
            this.uceProizvod.Name = "uceProizvod";
            this.uceProizvod.Size = new System.Drawing.Size(220, 21);
            this.uceProizvod.TabIndex = 86;
            this.uceProizvod.ValueMember = "ID";
            this.uceProizvod.ValueChanged += new System.EventHandler(this.uceProizvod_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(8, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 87;
            this.label1.Text = "Naziv proizvoda:";
            // 
            // uteNazivProizvod
            // 
            this.uteNazivProizvod.Location = new System.Drawing.Point(100, 36);
            this.uteNazivProizvod.MaxLength = 200;
            this.uteNazivProizvod.Multiline = true;
            this.uteNazivProizvod.Name = "uteNazivProizvod";
            this.uteNazivProizvod.Size = new System.Drawing.Size(220, 42);
            this.uteNazivProizvod.TabIndex = 88;
            // 
            // lblName3
            // 
            this.lblName3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName3.AutoSize = true;
            this.lblName3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblName3.Location = new System.Drawing.Point(8, 87);
            this.lblName3.Name = "lblName3";
            this.lblName3.Size = new System.Drawing.Size(46, 13);
            this.lblName3.TabIndex = 70;
            this.lblName3.Text = "Cijena:";
            // 
            // uneCijena
            // 
            this.uneCijena.Location = new System.Drawing.Point(100, 84);
            this.uneCijena.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.uneCijena.MaximumSize = new System.Drawing.Size(9999, 0);
            this.uneCijena.MaxValue = 9999999999D;
            this.uneCijena.MinValue = 0D;
            this.uneCijena.Name = "uneCijena";
            this.uneCijena.Nullable = true;
            this.uneCijena.NullText = " ";
            this.uneCijena.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.uneCijena.PromptChar = ' ';
            this.uneCijena.Size = new System.Drawing.Size(220, 21);
            this.uneCijena.TabIndex = 82;
            this.uneCijena.ValueChanged += new System.EventHandler(this.uneCijena_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(8, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 89;
            this.label3.Text = "Rabat:";
            // 
            // uneRabat
            // 
            this.uneRabat.Location = new System.Drawing.Point(100, 110);
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
            this.uneRabat.TabIndex = 90;
            this.uneRabat.ValueChanged += new System.EventHandler(this.uneRabat_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(8, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 75;
            this.label2.Text = "Količina:";
            // 
            // uneKolicina
            // 
            this.uneKolicina.Location = new System.Drawing.Point(100, 136);
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
            this.uneKolicina.TabIndex = 83;
            this.uneKolicina.ValueChanged += new System.EventHandler(this.uneKolicina_ValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(8, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 93;
            this.label5.Text = "Ukupna cijena:";
            // 
            // RacuniStavkeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpForm);
            this.Controls.Add(this.lblValidationMessages);
            this.Controls.Add(this.tspForm);
            this.Name = "RacuniStavkeForm";
            this.Size = new System.Drawing.Size(399, 324);
            this.Load += new System.EventHandler(this.FormLoad);
            this.tspForm.ResumeLayout(false);
            this.tspForm.PerformLayout();
            this.tlpForm.ResumeLayout(false);
            this.tlpForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uneUkupnaCijena)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneStopa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceProizvod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteNazivProizvod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneCijena)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneRabat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneKolicina)).EndInit();
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
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneCijena;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceProizvod;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneKolicina;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneStopa;
        private System.Windows.Forms.Label label4;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteNazivProizvod;
        private System.Windows.Forms.Label label3;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneRabat;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneUkupnaCijena;
        private System.Windows.Forms.Label label5;


    }
}

namespace Materijalno.UI.Dokumenti
{
    partial class ProizvodForm
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
            this.tspForm = new System.Windows.Forms.ToolStrip();
            this.tsbSpremiZatvori = new System.Windows.Forms.ToolStripButton();
            this.tsbSpremiNovi = new System.Windows.Forms.ToolStripButton();
            this.tsbOdustani = new System.Windows.Forms.ToolStripButton();
            this.lblValidationMessages = new System.Windows.Forms.Label();
            this.lblName2 = new System.Windows.Forms.Label();
            this.uteSifra = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.uteNaziv = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.uneCijena = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.uceJedinicaMjere = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label3 = new System.Windows.Forms.Label();
            this.uneCijenaPDV = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label6 = new System.Windows.Forms.Label();
            this.ucePorez = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStopaPoreza = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.uceGrupa = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label7 = new System.Windows.Forms.Label();
            this.tspForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uteSifra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteNaziv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneCijena)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceJedinicaMjere)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneCijenaPDV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucePorez)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceGrupa)).BeginInit();
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
            this.tspForm.Size = new System.Drawing.Size(449, 25);
            this.tspForm.TabIndex = 20;
            this.tspForm.Text = "toolStrip1";
            // 
            // tsbSpremiZatvori
            // 
            this.tsbSpremiZatvori.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSpremiZatvori.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSpremiZatvori.Name = "tsbSpremiZatvori";
            this.tsbSpremiZatvori.Size = new System.Drawing.Size(92, 22);
            this.tsbSpremiZatvori.Text = "Spremi i zatvori";
            this.tsbSpremiZatvori.Click += new System.EventHandler(this.tsbSpremiZatvori_Click);
            // 
            // tsbSpremiNovi
            // 
            this.tsbSpremiNovi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSpremiNovi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSpremiNovi.Name = "tsbSpremiNovi";
            this.tsbSpremiNovi.Size = new System.Drawing.Size(80, 22);
            this.tsbSpremiNovi.Text = "Spremi i novi";
            this.tsbSpremiNovi.Click += new System.EventHandler(this.tsbSpremiNovi_Click);
            // 
            // tsbOdustani
            // 
            this.tsbOdustani.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbOdustani.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOdustani.Name = "tsbOdustani";
            this.tsbOdustani.Size = new System.Drawing.Size(105, 22);
            this.tsbOdustani.Text = "Odustani i Zatvori";
            this.tsbOdustani.Click += new System.EventHandler(this.tsbOdustani_Click);
            // 
            // lblValidationMessages
            // 
            this.lblValidationMessages.AutoSize = true;
            this.lblValidationMessages.ForeColor = System.Drawing.Color.Red;
            this.lblValidationMessages.Location = new System.Drawing.Point(8, 25);
            this.lblValidationMessages.Name = "lblValidationMessages";
            this.lblValidationMessages.Padding = new System.Windows.Forms.Padding(0, 2, 0, 5);
            this.lblValidationMessages.Size = new System.Drawing.Size(0, 20);
            this.lblValidationMessages.TabIndex = 67;
            // 
            // lblName2
            // 
            this.lblName2.AutoSize = true;
            this.lblName2.Location = new System.Drawing.Point(4, 53);
            this.lblName2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName2.Name = "lblName2";
            this.lblName2.Size = new System.Drawing.Size(68, 13);
            this.lblName2.TabIndex = 74;
            this.lblName2.Text = "Šif. proizvod:";
            // 
            // uteSifra
            // 
            this.uteSifra.Location = new System.Drawing.Point(100, 49);
            this.uteSifra.MaxLength = 50;
            this.uteSifra.Name = "uteSifra";
            this.uteSifra.Size = new System.Drawing.Size(79, 21);
            this.uteSifra.TabIndex = 93;
            // 
            // uteNaziv
            // 
            this.uteNaziv.Location = new System.Drawing.Point(100, 76);
            this.uteNaziv.MaxLength = 50;
            this.uteNaziv.Multiline = true;
            this.uteNaziv.Name = "uteNaziv";
            this.uteNaziv.Size = new System.Drawing.Size(293, 60);
            this.uteNaziv.TabIndex = 95;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 80);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 94;
            this.label1.Text = "Proizvod:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 196);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 96;
            this.label2.Text = "Osnovica:";
            // 
            // uneCijena
            // 
            this.uneCijena.Location = new System.Drawing.Point(100, 192);
            this.uneCijena.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.uneCijena.MaximumSize = new System.Drawing.Size(9999, 0);
            this.uneCijena.MaxValue = 9999999999D;
            this.uneCijena.MinValue = 0D;
            this.uneCijena.Name = "uneCijena";
            this.uneCijena.Nullable = true;
            this.uneCijena.NullText = " ";
            this.uneCijena.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.uneCijena.PromptChar = ' ';
            this.uneCijena.Size = new System.Drawing.Size(134, 21);
            this.uneCijena.TabIndex = 97;
            this.uneCijena.ValueChanged += new System.EventHandler(this.uneCijena_ValueChanged);
            // 
            // uceJedinicaMjere
            // 
            this.uceJedinicaMjere.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.uceJedinicaMjere.DisplayMember = "Naziv";
            this.uceJedinicaMjere.Location = new System.Drawing.Point(100, 219);
            this.uceJedinicaMjere.MaxDropDownItems = 20;
            this.uceJedinicaMjere.Name = "uceJedinicaMjere";
            this.uceJedinicaMjere.Size = new System.Drawing.Size(293, 21);
            this.uceJedinicaMjere.TabIndex = 98;
            this.uceJedinicaMjere.ValueMember = "ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 223);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 99;
            this.label3.Text = "Šifra jed. mjere:";
            // 
            // uneCijenaPDV
            // 
            this.uneCijenaPDV.Location = new System.Drawing.Point(100, 246);
            this.uneCijenaPDV.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.uneCijenaPDV.MaximumSize = new System.Drawing.Size(9999, 0);
            this.uneCijenaPDV.MaxValue = 9999999999D;
            this.uneCijenaPDV.MinValue = 0D;
            this.uneCijenaPDV.Name = "uneCijenaPDV";
            this.uneCijenaPDV.Nullable = true;
            this.uneCijenaPDV.NullText = " ";
            this.uneCijenaPDV.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.uneCijenaPDV.PromptChar = ' ';
            this.uneCijenaPDV.Size = new System.Drawing.Size(134, 21);
            this.uneCijenaPDV.TabIndex = 105;
            this.uneCijenaPDV.ValueChanged += new System.EventHandler(this.uneCijenaPDV_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 250);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 104;
            this.label6.Text = "Cijena sa PDV-om:";
            // 
            // ucePorez
            // 
            this.ucePorez.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.ucePorez.DisplayMember = "Naziv";
            this.ucePorez.Location = new System.Drawing.Point(100, 143);
            this.ucePorez.MaxDropDownItems = 20;
            this.ucePorez.Name = "ucePorez";
            this.ucePorez.Size = new System.Drawing.Size(293, 21);
            this.ucePorez.TabIndex = 106;
            this.ucePorez.ValueMember = "ID";
            this.ucePorez.ValueChanged += new System.EventHandler(this.ucePorez_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 147);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 107;
            this.label4.Text = "Porez:";
            // 
            // lblStopaPoreza
            // 
            this.lblStopaPoreza.AutoSize = true;
            this.lblStopaPoreza.Location = new System.Drawing.Point(100, 172);
            this.lblStopaPoreza.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStopaPoreza.Name = "lblStopaPoreza";
            this.lblStopaPoreza.Size = new System.Drawing.Size(0, 13);
            this.lblStopaPoreza.TabIndex = 109;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 172);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 108;
            this.label5.Text = "Porezna stopa:";
            // 
            // uceGrupa
            // 
            this.uceGrupa.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.uceGrupa.DisplayMember = "Naziv";
            this.uceGrupa.Location = new System.Drawing.Point(100, 273);
            this.uceGrupa.MaxDropDownItems = 20;
            this.uceGrupa.Name = "uceGrupa";
            this.uceGrupa.Size = new System.Drawing.Size(293, 21);
            this.uceGrupa.TabIndex = 110;
            this.uceGrupa.ValueMember = "ID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 277);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 111;
            this.label7.Text = "Grupa proizvoda:";
            // 
            // ProizvodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uceGrupa);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblStopaPoreza);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ucePorez);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.uneCijenaPDV);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.uceJedinicaMjere);
            this.Controls.Add(this.uneCijena);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uteNaziv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uteSifra);
            this.Controls.Add(this.lblName2);
            this.Controls.Add(this.lblValidationMessages);
            this.Controls.Add(this.tspForm);
            this.Controls.Add(this.label3);
            this.Name = "ProizvodForm";
            this.Size = new System.Drawing.Size(449, 347);
            this.Load += new System.EventHandler(this.Form_Load);
            this.tspForm.ResumeLayout(false);
            this.tspForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uteSifra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteNaziv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneCijena)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceJedinicaMjere)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneCijenaPDV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucePorez)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceGrupa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tspForm;
        private System.Windows.Forms.ToolStripButton tsbSpremiZatvori;
        private System.Windows.Forms.ToolStripButton tsbOdustani;
        private System.Windows.Forms.Label lblValidationMessages;
        private System.Windows.Forms.Label lblName2;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteSifra;
        private System.Windows.Forms.ToolStripButton tsbSpremiNovi;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteNaziv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneCijena;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceJedinicaMjere;
        private System.Windows.Forms.Label label3;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneCijenaPDV;
        private System.Windows.Forms.Label label6;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ucePorez;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblStopaPoreza;
        private System.Windows.Forms.Label label5;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceGrupa;
        private System.Windows.Forms.Label label7;


    }
}

namespace Materijalno.UI.Dokumenti
{
    partial class PrimkaStavkeUnosForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrimkaStavkeUnosForm));
            this.lblValidationMessages = new System.Windows.Forms.Label();
            this.tspNarudzbenica = new System.Windows.Forms.ToolStrip();
            this.tsbSpremiZatvori = new System.Windows.Forms.ToolStripButton();
            this.tsbSpremiNovi = new System.Windows.Forms.ToolStripButton();
            this.tsbOdustani = new System.Windows.Forms.ToolStripButton();
            this.tlpForm = new System.Windows.Forms.TableLayoutPanel();
            this.lblName1 = new System.Windows.Forms.Label();
            this.lblName2 = new System.Windows.Forms.Label();
            this.lblJedinica = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbProizvod = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uneNetoPlusNeMoze = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.lblName3 = new System.Windows.Forms.Label();
            this.uneNetoCijena = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uneKolicina = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.lblName4 = new System.Windows.Forms.Label();
            this.ucePorez = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.btnAmbalaza = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnKalkulacija = new System.Windows.Forms.Button();
            this.uneUkupno = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.tspNarudzbenica.SuspendLayout();
            this.tlpForm.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneNetoPlusNeMoze)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneNetoCijena)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneKolicina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucePorez)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uneUkupno)).BeginInit();
            this.SuspendLayout();
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
            // tspNarudzbenica
            // 
            this.tspNarudzbenica.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSpremiZatvori,
            this.tsbSpremiNovi,
            this.tsbOdustani});
            this.tspNarudzbenica.Location = new System.Drawing.Point(0, 0);
            this.tspNarudzbenica.Name = "tspNarudzbenica";
            this.tspNarudzbenica.Size = new System.Drawing.Size(455, 25);
            this.tspNarudzbenica.TabIndex = 68;
            this.tspNarudzbenica.Text = "toolStrip1";
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
            this.tlpForm.Controls.Add(this.lblName1, 0, 0);
            this.tlpForm.Controls.Add(this.lblName2, 0, 1);
            this.tlpForm.Controls.Add(this.lblJedinica, 1, 1);
            this.tlpForm.Controls.Add(this.panel1, 1, 0);
            this.tlpForm.Controls.Add(this.label2, 0, 6);
            this.tlpForm.Controls.Add(this.uneNetoPlusNeMoze, 1, 6);
            this.tlpForm.Controls.Add(this.lblName3, 0, 5);
            this.tlpForm.Controls.Add(this.uneNetoCijena, 1, 5);
            this.tlpForm.Controls.Add(this.label3, 0, 4);
            this.tlpForm.Controls.Add(this.label1, 0, 3);
            this.tlpForm.Controls.Add(this.uneKolicina, 1, 3);
            this.tlpForm.Controls.Add(this.lblName4, 0, 2);
            this.tlpForm.Controls.Add(this.ucePorez, 1, 2);
            this.tlpForm.Controls.Add(this.btnAmbalaza, 1, 7);
            this.tlpForm.Controls.Add(this.panel2, 1, 4);
            this.tlpForm.Location = new System.Drawing.Point(0, 48);
            this.tlpForm.Name = "tlpForm";
            this.tlpForm.Padding = new System.Windows.Forms.Padding(5);
            this.tlpForm.RowCount = 9;
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpForm.Size = new System.Drawing.Size(441, 283);
            this.tlpForm.TabIndex = 69;
            // 
            // lblName1
            // 
            this.lblName1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName1.AutoSize = true;
            this.lblName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblName1.Location = new System.Drawing.Point(8, 14);
            this.lblName1.Name = "lblName1";
            this.lblName1.Size = new System.Drawing.Size(60, 13);
            this.lblName1.TabIndex = 19;
            this.lblName1.Text = "Proizvod:";
            // 
            // lblName2
            // 
            this.lblName2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName2.AutoSize = true;
            this.lblName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblName2.Location = new System.Drawing.Point(8, 41);
            this.lblName2.Name = "lblName2";
            this.lblName2.Size = new System.Drawing.Size(97, 13);
            this.lblName2.TabIndex = 21;
            this.lblName2.Text = "Mjerna jedinica:";
            // 
            // lblJedinica
            // 
            this.lblJedinica.Location = new System.Drawing.Point(166, 36);
            this.lblJedinica.Name = "lblJedinica";
            this.lblJedinica.Size = new System.Drawing.Size(220, 23);
            this.lblJedinica.TabIndex = 84;
            this.lblJedinica.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbProizvod);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(166, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 23);
            this.panel1.TabIndex = 100;
            // 
            // cmbProizvod
            // 
            this.cmbProizvod.FormattingEnabled = true;
            this.cmbProizvod.Location = new System.Drawing.Point(0, 2);
            this.cmbProizvod.Name = "cmbProizvod";
            this.cmbProizvod.Size = new System.Drawing.Size(216, 21);
            this.cmbProizvod.TabIndex = 76;
            this.cmbProizvod.SelectedValueChanged += new System.EventHandler(this.cmbProizvod_SelectedValueChanged);
            this.cmbProizvod.TextChanged += new System.EventHandler(this.cmbProizvod_TextChanged);
            this.cmbProizvod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbProizvod_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(227, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 20);
            this.pictureBox1.TabIndex = 75;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(8, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 13);
            this.label2.TabIndex = 75;
            this.label2.Text = "Neto + ne može se odbiti:";
            // 
            // uneNetoPlusNeMoze
            // 
            this.uneNetoPlusNeMoze.Location = new System.Drawing.Point(166, 179);
            this.uneNetoPlusNeMoze.MaskInput = "{LOC}-nnnnnnnn.nnnn";
            this.uneNetoPlusNeMoze.MaximumSize = new System.Drawing.Size(9999, 0);
            this.uneNetoPlusNeMoze.MaxValue = 99999999D;
            this.uneNetoPlusNeMoze.MinValue = 0D;
            this.uneNetoPlusNeMoze.Name = "uneNetoPlusNeMoze";
            this.uneNetoPlusNeMoze.Nullable = true;
            this.uneNetoPlusNeMoze.NullText = " ";
            this.uneNetoPlusNeMoze.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.uneNetoPlusNeMoze.PromptChar = ' ';
            this.uneNetoPlusNeMoze.Size = new System.Drawing.Size(220, 21);
            this.uneNetoPlusNeMoze.TabIndex = 106;
            this.uneNetoPlusNeMoze.ValueChanged += new System.EventHandler(this.uneCijenaPDV_ValueChanged);
            this.uneNetoPlusNeMoze.BeforeEnterEditMode += new System.ComponentModel.CancelEventHandler(this.uneNetoPlusNeMoze_BeforeEnterEditMode);
            // 
            // lblName3
            // 
            this.lblName3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName3.AutoSize = true;
            this.lblName3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblName3.Location = new System.Drawing.Point(8, 156);
            this.lblName3.Name = "lblName3";
            this.lblName3.Size = new System.Drawing.Size(38, 13);
            this.lblName3.TabIndex = 70;
            this.lblName3.Text = "Neto:";
            // 
            // uneNetoCijena
            // 
            this.uneNetoCijena.Location = new System.Drawing.Point(166, 152);
            this.uneNetoCijena.MaskInput = "{LOC}-nnnnnnnn.nnnn";
            this.uneNetoCijena.MaximumSize = new System.Drawing.Size(9999, 0);
            this.uneNetoCijena.MaxValue = 99999999D;
            this.uneNetoCijena.MinValue = 0D;
            this.uneNetoCijena.Name = "uneNetoCijena";
            this.uneNetoCijena.Nullable = true;
            this.uneNetoCijena.NullText = " ";
            this.uneNetoCijena.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.uneNetoCijena.PromptChar = ' ';
            this.uneNetoCijena.Size = new System.Drawing.Size(220, 21);
            this.uneNetoCijena.TabIndex = 105;
            this.uneNetoCijena.ValueChanged += new System.EventHandler(this.uneNabavnaCijena_ValueChanged);
            this.uneNetoCijena.BeforeEnterEditMode += new System.ComponentModel.CancelEventHandler(this.uneNetoCijena_BeforeEnterEditMode);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(8, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 27);
            this.label3.TabIndex = 108;
            this.label3.Text = "Ukupna nabavna vrijednost stavke URA-e:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(8, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 88;
            this.label1.Text = "Količina:";
            // 
            // uneKolicina
            // 
            this.uneKolicina.Location = new System.Drawing.Point(166, 92);
            this.uneKolicina.MaskInput = "{LOC}-nnnnnnnn.nnnn";
            this.uneKolicina.MaximumSize = new System.Drawing.Size(9999, 0);
            this.uneKolicina.MaxValue = 99999999D;
            this.uneKolicina.MinValue = -99999999D;
            this.uneKolicina.Name = "uneKolicina";
            this.uneKolicina.Nullable = true;
            this.uneKolicina.NullText = " ";
            this.uneKolicina.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.uneKolicina.PromptChar = ' ';
            this.uneKolicina.Size = new System.Drawing.Size(220, 21);
            this.uneKolicina.TabIndex = 102;
            this.uneKolicina.ValueChanged += new System.EventHandler(this.uneKolicina_ValueChanged);
            this.uneKolicina.BeforeEnterEditMode += new System.ComponentModel.CancelEventHandler(this.uneKolicina_BeforeEnterEditMode);
            // 
            // lblName4
            // 
            this.lblName4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName4.AutoSize = true;
            this.lblName4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblName4.Location = new System.Drawing.Point(8, 68);
            this.lblName4.Name = "lblName4";
            this.lblName4.Size = new System.Drawing.Size(92, 13);
            this.lblName4.TabIndex = 71;
            this.lblName4.Text = "Porezna stopa:";
            // 
            // ucePorez
            // 
            this.ucePorez.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.ucePorez.DisplayMember = "Naziv";
            this.ucePorez.Location = new System.Drawing.Point(166, 63);
            this.ucePorez.MaxDropDownItems = 20;
            this.ucePorez.Name = "ucePorez";
            this.ucePorez.Size = new System.Drawing.Size(220, 21);
            this.ucePorez.TabIndex = 101;
            this.ucePorez.ValueMember = "ID";
            this.ucePorez.ValueChanged += new System.EventHandler(this.ucePorez_ValueChanged);
            // 
            // btnAmbalaza
            // 
            this.btnAmbalaza.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAmbalaza.Location = new System.Drawing.Point(165, 206);
            this.btnAmbalaza.Margin = new System.Windows.Forms.Padding(2);
            this.btnAmbalaza.Name = "btnAmbalaza";
            this.btnAmbalaza.Size = new System.Drawing.Size(66, 24);
            this.btnAmbalaza.TabIndex = 109;
            this.btnAmbalaza.Text = "Ambalaža";
            this.btnAmbalaza.UseVisualStyleBackColor = true;
            this.btnAmbalaza.Click += new System.EventHandler(this.btnAmbalaza_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnKalkulacija);
            this.panel2.Controls.Add(this.uneUkupno);
            this.panel2.Location = new System.Drawing.Point(166, 117);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(270, 27);
            this.panel2.TabIndex = 103;
            // 
            // btnKalkulacija
            // 
            this.btnKalkulacija.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKalkulacija.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnKalkulacija.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnKalkulacija.Location = new System.Drawing.Point(225, 2);
            this.btnKalkulacija.Margin = new System.Windows.Forms.Padding(2);
            this.btnKalkulacija.Name = "btnKalkulacija";
            this.btnKalkulacija.Size = new System.Drawing.Size(21, 21);
            this.btnKalkulacija.TabIndex = 107;
            this.btnKalkulacija.Text = "C";
            this.btnKalkulacija.UseVisualStyleBackColor = true;
            this.btnKalkulacija.Click += new System.EventHandler(this.btnKalkulacija_Click);
            // 
            // uneUkupno
            // 
            this.uneUkupno.Location = new System.Drawing.Point(0, 2);
            this.uneUkupno.MaskInput = "{LOC}-nnnnnnnn.nnnn";
            this.uneUkupno.MaximumSize = new System.Drawing.Size(9999, 0);
            this.uneUkupno.MaxValue = 99999999D;
            this.uneUkupno.MinValue = 0D;
            this.uneUkupno.Name = "uneUkupno";
            this.uneUkupno.Nullable = true;
            this.uneUkupno.NullText = " ";
            this.uneUkupno.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.uneUkupno.PromptChar = ' ';
            this.uneUkupno.Size = new System.Drawing.Size(220, 21);
            this.uneUkupno.TabIndex = 104;
            this.uneUkupno.ValueChanged += new System.EventHandler(this.uneUkupno_ValueChanged);
            this.uneUkupno.BeforeEnterEditMode += new System.ComponentModel.CancelEventHandler(this.uneUkupno_BeforeEnterEditMode);
            // 
            // PrimkaStavkeUnosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpForm);
            this.Controls.Add(this.tspNarudzbenica);
            this.Controls.Add(this.lblValidationMessages);
            this.Name = "PrimkaStavkeUnosForm";
            this.Size = new System.Drawing.Size(455, 334);
            this.Load += new System.EventHandler(this.FormLoad);
            this.tspNarudzbenica.ResumeLayout(false);
            this.tspNarudzbenica.PerformLayout();
            this.tlpForm.ResumeLayout(false);
            this.tlpForm.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneNetoPlusNeMoze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneNetoCijena)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneKolicina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucePorez)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uneUkupno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblValidationMessages;
        private System.Windows.Forms.ToolStrip tspNarudzbenica;
        private System.Windows.Forms.ToolStripButton tsbSpremiNovi;
        private System.Windows.Forms.ToolStripButton tsbSpremiZatvori;
        private System.Windows.Forms.ToolStripButton tsbOdustani;
        private System.Windows.Forms.TableLayoutPanel tlpForm;
        private System.Windows.Forms.Label lblName1;
        private System.Windows.Forms.Label lblName2;
        private System.Windows.Forms.Label lblName3;
        private System.Windows.Forms.Label lblName4;
        private System.Windows.Forms.Label label2;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneNetoCijena;
        private System.Windows.Forms.Label lblJedinica;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneKolicina;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneNetoPlusNeMoze;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ucePorez;
        private System.Windows.Forms.Label label3;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneUkupno;
        private System.Windows.Forms.Button btnAmbalaza;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnKalkulacija;
        private System.Windows.Forms.ComboBox cmbProizvod;


    }
}

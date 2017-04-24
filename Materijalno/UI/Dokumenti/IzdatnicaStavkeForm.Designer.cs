namespace Materijalno.UI.Dokumenti
{
    partial class IzdatnicaStavkeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IzdatnicaStavkeForm));
            this.tspForm = new System.Windows.Forms.ToolStrip();
            this.tsbSpremiZatvori = new System.Windows.Forms.ToolStripButton();
            this.tsbOdustani = new System.Windows.Forms.ToolStripButton();
            this.lblValidationMessages = new System.Windows.Forms.Label();
            this.tlpForm = new System.Windows.Forms.TableLayoutPanel();
            this.lblStanje = new System.Windows.Forms.Label();
            this.lblName1 = new System.Windows.Forms.Label();
            this.lblName3 = new System.Windows.Forms.Label();
            this.uneNabavnaCijena = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.uneKolicina = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uceStavka = new System.Windows.Forms.ComboBox();
            this.tspForm.SuspendLayout();
            this.tlpForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uneNabavnaCijena)).BeginInit();
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
            this.tspForm.Size = new System.Drawing.Size(434, 25);
            this.tspForm.TabIndex = 88;
            this.tspForm.TabStop = true;
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
            this.tlpForm.Controls.Add(this.lblStanje, 1, 3);
            this.tlpForm.Controls.Add(this.lblName1, 0, 0);
            this.tlpForm.Controls.Add(this.lblName3, 0, 2);
            this.tlpForm.Controls.Add(this.uneNabavnaCijena, 1, 2);
            this.tlpForm.Controls.Add(this.uneKolicina, 1, 1);
            this.tlpForm.Controls.Add(this.label2, 0, 1);
            this.tlpForm.Controls.Add(this.label1, 0, 3);
            this.tlpForm.Controls.Add(this.uceStavka, 1, 0);
            this.tlpForm.Location = new System.Drawing.Point(3, 59);
            this.tlpForm.Name = "tlpForm";
            this.tlpForm.Padding = new System.Windows.Forms.Padding(5);
            this.tlpForm.RowCount = 4;
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpForm.Size = new System.Drawing.Size(420, 152);
            this.tlpForm.TabIndex = 70;
            // 
            // lblStanje
            // 
            this.lblStanje.AutoSize = true;
            this.lblStanje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblStanje.Location = new System.Drawing.Point(136, 91);
            this.lblStanje.Name = "lblStanje";
            this.lblStanje.Size = new System.Drawing.Size(0, 13);
            this.lblStanje.TabIndex = 88;
            // 
            // lblName1
            // 
            this.lblName1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName1.AutoSize = true;
            this.lblName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblName1.Location = new System.Drawing.Point(8, 13);
            this.lblName1.Name = "lblName1";
            this.lblName1.Size = new System.Drawing.Size(122, 13);
            this.lblName1.TabIndex = 19;
            this.lblName1.Text = "Stavka sa skladišta:";
            // 
            // lblName3
            // 
            this.lblName3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName3.AutoSize = true;
            this.lblName3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblName3.Location = new System.Drawing.Point(8, 69);
            this.lblName3.Name = "lblName3";
            this.lblName3.Size = new System.Drawing.Size(100, 13);
            this.lblName3.TabIndex = 70;
            this.lblName3.Text = "Nabavna cijena:";
            // 
            // uneNabavnaCijena
            // 
            this.uneNabavnaCijena.Location = new System.Drawing.Point(136, 63);
            this.uneNabavnaCijena.MaskInput = "{LOC}-nnnnnnnn.nnnn";
            this.uneNabavnaCijena.MaximumSize = new System.Drawing.Size(9999, 0);
            this.uneNabavnaCijena.MaxValue = 99999999D;
            this.uneNabavnaCijena.MinValue = 0D;
            this.uneNabavnaCijena.Name = "uneNabavnaCijena";
            this.uneNabavnaCijena.Nullable = true;
            this.uneNabavnaCijena.NullText = " ";
            this.uneNabavnaCijena.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.uneNabavnaCijena.PromptChar = ' ';
            this.uneNabavnaCijena.Size = new System.Drawing.Size(220, 21);
            this.uneNabavnaCijena.TabIndex = 88;
            this.uneNabavnaCijena.TabStop = false;
            this.uneNabavnaCijena.BeforeEnterEditMode += new System.ComponentModel.CancelEventHandler(this.uneNabavnaCijena_BeforeEnterEditMode);
            // 
            // uneKolicina
            // 
            this.uneKolicina.Location = new System.Drawing.Point(136, 37);
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
            this.uneKolicina.TabIndex = 87;
            this.uneKolicina.BeforeEnterEditMode += new System.ComponentModel.CancelEventHandler(this.uneKolicina_BeforeEnterEditMode);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(8, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 75;
            this.label2.Text = "Količina:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(8, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 87;
            this.label1.Text = "Stanje na skladištu:";
            // 
            // uceStavka
            // 
            this.uceStavka.FormattingEnabled = true;
            this.uceStavka.Location = new System.Drawing.Point(136, 8);
            this.uceStavka.Name = "uceStavka";
            this.uceStavka.Size = new System.Drawing.Size(220, 21);
            this.uceStavka.TabIndex = 86;
            this.uceStavka.SelectedValueChanged += new System.EventHandler(this.uceStavka_SelectedValueChanged);
            this.uceStavka.TextChanged += new System.EventHandler(this.uceStavka_TextChanged);
            this.uceStavka.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uceStavka_KeyPress);
            this.uceStavka.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uceStavka_KeyUp);
            // 
            // IzdatnicaStavkeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpForm);
            this.Controls.Add(this.lblValidationMessages);
            this.Controls.Add(this.tspForm);
            this.Name = "IzdatnicaStavkeForm";
            this.Size = new System.Drawing.Size(434, 224);
            this.Load += new System.EventHandler(this.FormLoad);
            this.tspForm.ResumeLayout(false);
            this.tspForm.PerformLayout();
            this.tlpForm.ResumeLayout(false);
            this.tlpForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uneNabavnaCijena)).EndInit();
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
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneNabavnaCijena;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneKolicina;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStanje;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox uceStavka;


    }
}

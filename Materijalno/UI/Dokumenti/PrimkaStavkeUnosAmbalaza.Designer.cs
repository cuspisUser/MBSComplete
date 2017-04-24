namespace Materijalno.UI.Dokumenti
{
    partial class PrimkaStavkeUnosAmbalaza
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
            this.lblValidationMessages = new System.Windows.Forms.Label();
            this.tspNarudzbenica = new System.Windows.Forms.ToolStrip();
            this.tsbSpremiZatvori = new System.Windows.Forms.ToolStripButton();
            this.tsbOdustani = new System.Windows.Forms.ToolStripButton();
            this.uceMjernaJedinica = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.uneKolicina = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.lblName3 = new System.Windows.Forms.Label();
            this.uneJedinicnaVrijednost = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label2 = new System.Windows.Forms.Label();
            this.lblJedinica = new System.Windows.Forms.Label();
            this.lblName2 = new System.Windows.Forms.Label();
            this.tlpForm = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.uneKolicinaPrenesena = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.tspNarudzbenica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceMjernaJedinica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneKolicina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneJedinicnaVrijednost)).BeginInit();
            this.tlpForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uneKolicinaPrenesena)).BeginInit();
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
            this.tsbOdustani});
            this.tspNarudzbenica.Location = new System.Drawing.Point(0, 0);
            this.tspNarudzbenica.Name = "tspNarudzbenica";
            this.tspNarudzbenica.Size = new System.Drawing.Size(435, 25);
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
            // tsbOdustani
            // 
            this.tsbOdustani.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbOdustani.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOdustani.Name = "tsbOdustani";
            this.tsbOdustani.Size = new System.Drawing.Size(103, 22);
            this.tsbOdustani.Text = "Odustani i zatvori";
            this.tsbOdustani.Click += new System.EventHandler(this.tsbOdustani_Click);
            // 
            // uceMjernaJedinica
            // 
            this.uceMjernaJedinica.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.uceMjernaJedinica.DisplayMember = "Naziv";
            this.uceMjernaJedinica.Location = new System.Drawing.Point(138, 63);
            this.uceMjernaJedinica.MaxDropDownItems = 20;
            this.uceMjernaJedinica.Name = "uceMjernaJedinica";
            this.uceMjernaJedinica.Size = new System.Drawing.Size(220, 21);
            this.uceMjernaJedinica.TabIndex = 2;
            this.uceMjernaJedinica.ValueMember = "ID";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(8, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 88;
            this.label1.Text = "Količina:";
            // 
            // uneKolicina
            // 
            this.uneKolicina.Location = new System.Drawing.Point(138, 92);
            this.uneKolicina.MaskInput = "{LOC}-nnnnnnnn.nnnn";
            this.uneKolicina.MaximumSize = new System.Drawing.Size(9999, 0);
            this.uneKolicina.MaxValue = 99999999D;
            this.uneKolicina.MinValue = 0D;
            this.uneKolicina.Name = "uneKolicina";
            this.uneKolicina.Nullable = true;
            this.uneKolicina.NullText = " ";
            this.uneKolicina.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.uneKolicina.PromptChar = ' ';
            this.uneKolicina.Size = new System.Drawing.Size(220, 21);
            this.uneKolicina.TabIndex = 4;
            this.uneKolicina.ValueChanged += new System.EventHandler(this.uneKolicina_ValueChanged);
            // 
            // lblName3
            // 
            this.lblName3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName3.AutoSize = true;
            this.lblName3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblName3.Location = new System.Drawing.Point(8, 95);
            this.lblName3.Name = "lblName3";
            this.lblName3.Size = new System.Drawing.Size(56, 13);
            this.lblName3.TabIndex = 70;
            this.lblName3.Text = "Količina:";
            // 
            // uneJedinicnaVrijednost
            // 
            this.uneJedinicnaVrijednost.Enabled = false;
            this.uneJedinicnaVrijednost.Location = new System.Drawing.Point(138, 117);
            this.uneJedinicnaVrijednost.MaskInput = "{LOC}-nnnnnnnn.nnnn";
            this.uneJedinicnaVrijednost.MaximumSize = new System.Drawing.Size(9999, 0);
            this.uneJedinicnaVrijednost.MaxValue = 99999999D;
            this.uneJedinicnaVrijednost.MinValue = 0D;
            this.uneJedinicnaVrijednost.Name = "uneJedinicnaVrijednost";
            this.uneJedinicnaVrijednost.Nullable = true;
            this.uneJedinicnaVrijednost.NullText = " ";
            this.uneJedinicnaVrijednost.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.uneJedinicnaVrijednost.PromptChar = ' ';
            this.uneJedinicnaVrijednost.ReadOnly = true;
            this.uneJedinicnaVrijednost.Size = new System.Drawing.Size(220, 21);
            this.uneJedinicnaVrijednost.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(8, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 75;
            this.label2.Text = "Jedinična vrijednost:";
            // 
            // lblJedinica
            // 
            this.lblJedinica.Location = new System.Drawing.Point(138, 5);
            this.lblJedinica.Name = "lblJedinica";
            this.lblJedinica.Size = new System.Drawing.Size(220, 23);
            this.lblJedinica.TabIndex = 84;
            this.lblJedinica.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblName2
            // 
            this.lblName2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName2.AutoSize = true;
            this.lblName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblName2.Location = new System.Drawing.Point(8, 11);
            this.lblName2.Name = "lblName2";
            this.lblName2.Size = new System.Drawing.Size(97, 13);
            this.lblName2.TabIndex = 21;
            this.lblName2.Text = "Mjerna jedinica:";
            // 
            // tlpForm
            // 
            this.tlpForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpForm.ColumnCount = 2;
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 346F));
            this.tlpForm.Controls.Add(this.uceMjernaJedinica, 1, 2);
            this.tlpForm.Controls.Add(this.lblName2, 0, 0);
            this.tlpForm.Controls.Add(this.lblJedinica, 1, 0);
            this.tlpForm.Controls.Add(this.label1, 0, 1);
            this.tlpForm.Controls.Add(this.label4, 0, 2);
            this.tlpForm.Controls.Add(this.lblName3, 0, 3);
            this.tlpForm.Controls.Add(this.uneKolicina, 1, 3);
            this.tlpForm.Controls.Add(this.label2, 0, 4);
            this.tlpForm.Controls.Add(this.uneJedinicnaVrijednost, 1, 4);
            this.tlpForm.Controls.Add(this.uneKolicinaPrenesena, 1, 1);
            this.tlpForm.Location = new System.Drawing.Point(0, 48);
            this.tlpForm.Name = "tlpForm";
            this.tlpForm.Padding = new System.Windows.Forms.Padding(5);
            this.tlpForm.RowCount = 6;
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpForm.Size = new System.Drawing.Size(426, 196);
            this.tlpForm.TabIndex = 69;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(8, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 110;
            this.label4.Text = "Mjerna jedinica:";
            // 
            // uneKolicinaPrenesena
            // 
            this.uneKolicinaPrenesena.Enabled = false;
            this.uneKolicinaPrenesena.Location = new System.Drawing.Point(138, 33);
            this.uneKolicinaPrenesena.MaskInput = "{LOC}-nnnnnnnn.nnnn";
            this.uneKolicinaPrenesena.MaximumSize = new System.Drawing.Size(9999, 0);
            this.uneKolicinaPrenesena.MaxValue = 99999999D;
            this.uneKolicinaPrenesena.MinValue = 0D;
            this.uneKolicinaPrenesena.Name = "uneKolicinaPrenesena";
            this.uneKolicinaPrenesena.Nullable = true;
            this.uneKolicinaPrenesena.NullText = " ";
            this.uneKolicinaPrenesena.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.uneKolicinaPrenesena.PromptChar = ' ';
            this.uneKolicinaPrenesena.ReadOnly = true;
            this.uneKolicinaPrenesena.Size = new System.Drawing.Size(220, 21);
            this.uneKolicinaPrenesena.TabIndex = 111;
            // 
            // PrimkaStavkeUnosAmbalaza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpForm);
            this.Controls.Add(this.tspNarudzbenica);
            this.Controls.Add(this.lblValidationMessages);
            this.Name = "PrimkaStavkeUnosAmbalaza";
            this.Size = new System.Drawing.Size(435, 249);
            this.Load += new System.EventHandler(this.FormLoad);
            this.tspNarudzbenica.ResumeLayout(false);
            this.tspNarudzbenica.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceMjernaJedinica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneKolicina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneJedinicnaVrijednost)).EndInit();
            this.tlpForm.ResumeLayout(false);
            this.tlpForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uneKolicinaPrenesena)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblValidationMessages;
        private System.Windows.Forms.ToolStrip tspNarudzbenica;
        private System.Windows.Forms.ToolStripButton tsbSpremiZatvori;
        private System.Windows.Forms.ToolStripButton tsbOdustani;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceMjernaJedinica;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneKolicina;
        private System.Windows.Forms.Label lblName3;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneJedinicnaVrijednost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblJedinica;
        private System.Windows.Forms.Label lblName2;
        private System.Windows.Forms.TableLayoutPanel tlpForm;
        private System.Windows.Forms.Label label4;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneKolicinaPrenesena;


    }
}

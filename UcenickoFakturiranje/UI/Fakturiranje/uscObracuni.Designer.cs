namespace UcenickoFakturiranje.UI.Fakturiranje
{
    partial class uscObracuni
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
            this.lblObracunMjesec = new System.Windows.Forms.Label();
            this.lblObracuniGodina = new System.Windows.Forms.Label();
            this.lblObracunKolicina = new System.Windows.Forms.Label();
            this.lblObracuniValutaPlacanja = new System.Windows.Forms.Label();
            this.lblObracunNaziv = new System.Windows.Forms.Label();
            this.btnObracunKreni = new System.Windows.Forms.Button();
            this.uteObracunNaziv = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.udtObracunValutaPlacanja = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.uneObracunKolicina = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.uneObracuniGodina = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.lblValidationMessages = new System.Windows.Forms.Label();
            this.uneObracuniMjesec = new UcenickoFakturiranje.Controls.TextBoxNumericInteger();
            this.btnObracunOdustani = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.uteObracunNaziv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtObracunValutaPlacanja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneObracunKolicina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneObracuniGodina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneObracuniMjesec)).BeginInit();
            this.SuspendLayout();
            // 
            // lblObracunMjesec
            // 
            this.lblObracunMjesec.Location = new System.Drawing.Point(4, 24);
            this.lblObracunMjesec.Name = "lblObracunMjesec";
            this.lblObracunMjesec.Size = new System.Drawing.Size(90, 23);
            this.lblObracunMjesec.TabIndex = 0;
            this.lblObracunMjesec.Text = "Za mjesec:";
            this.lblObracunMjesec.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblObracuniGodina
            // 
            this.lblObracuniGodina.Location = new System.Drawing.Point(230, 24);
            this.lblObracuniGodina.Name = "lblObracuniGodina";
            this.lblObracuniGodina.Size = new System.Drawing.Size(112, 23);
            this.lblObracuniGodina.TabIndex = 1;
            this.lblObracuniGodina.Text = "Za godinu:";
            this.lblObracuniGodina.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblObracunKolicina
            // 
            this.lblObracunKolicina.Location = new System.Drawing.Point(230, 66);
            this.lblObracunKolicina.Name = "lblObracunKolicina";
            this.lblObracunKolicina.Size = new System.Drawing.Size(112, 23);
            this.lblObracunKolicina.TabIndex = 3;
            this.lblObracunKolicina.Text = "Količina za obračun:";
            this.lblObracunKolicina.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblObracuniValutaPlacanja
            // 
            this.lblObracuniValutaPlacanja.Location = new System.Drawing.Point(4, 66);
            this.lblObracuniValutaPlacanja.Name = "lblObracuniValutaPlacanja";
            this.lblObracuniValutaPlacanja.Size = new System.Drawing.Size(90, 23);
            this.lblObracuniValutaPlacanja.TabIndex = 2;
            this.lblObracuniValutaPlacanja.Text = "Valuta plaćanja:";
            this.lblObracuniValutaPlacanja.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblObracunNaziv
            // 
            this.lblObracunNaziv.Location = new System.Drawing.Point(4, 103);
            this.lblObracunNaziv.Name = "lblObracunNaziv";
            this.lblObracunNaziv.Size = new System.Drawing.Size(90, 23);
            this.lblObracunNaziv.TabIndex = 4;
            this.lblObracunNaziv.Text = "Naziv obračuna:";
            this.lblObracunNaziv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnObracunKreni
            // 
            this.btnObracunKreni.Location = new System.Drawing.Point(318, 134);
            this.btnObracunKreni.Name = "btnObracunKreni";
            this.btnObracunKreni.Size = new System.Drawing.Size(137, 25);
            this.btnObracunKreni.TabIndex = 6;
            this.btnObracunKreni.Text = "Kreni s obračunom";
            this.btnObracunKreni.UseVisualStyleBackColor = true;
            this.btnObracunKreni.Click += new System.EventHandler(this.btnObracunKreni_Click);
            // 
            // uteObracunNaziv
            // 
            this.uteObracunNaziv.Location = new System.Drawing.Point(95, 104);
            this.uteObracunNaziv.MaxLength = 50;
            this.uteObracunNaziv.Name = "uteObracunNaziv";
            this.uteObracunNaziv.Size = new System.Drawing.Size(379, 21);
            this.uteObracunNaziv.TabIndex = 5;
            // 
            // udtObracunValutaPlacanja
            // 
            this.udtObracunValutaPlacanja.Location = new System.Drawing.Point(95, 67);
            this.udtObracunValutaPlacanja.MaxDate = new System.DateTime(2500, 12, 31, 0, 0, 0, 0);
            this.udtObracunValutaPlacanja.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.udtObracunValutaPlacanja.Name = "udtObracunValutaPlacanja";
            this.udtObracunValutaPlacanja.Size = new System.Drawing.Size(130, 21);
            this.udtObracunValutaPlacanja.TabIndex = 3;
            // 
            // uneObracunKolicina
            // 
            this.uneObracunKolicina.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.uneObracunKolicina.Location = new System.Drawing.Point(344, 66);
            this.uneObracunKolicina.MaskInput = "{LOC}-nnnnnnnnnn";
            this.uneObracunKolicina.MinValue = 0D;
            this.uneObracunKolicina.Name = "uneObracunKolicina";
            this.uneObracunKolicina.Nullable = true;
            this.uneObracunKolicina.NullText = " ";
            this.uneObracunKolicina.PromptChar = ' ';
            this.uneObracunKolicina.Size = new System.Drawing.Size(130, 21);
            this.uneObracunKolicina.TabIndex = 4;
            this.uneObracunKolicina.Value = null;
            // 
            // uneObracuniGodina
            // 
            this.uneObracuniGodina.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.uneObracuniGodina.Location = new System.Drawing.Point(344, 26);
            this.uneObracuniGodina.MaskInput = "{LOC}-nnnnnnnnnn";
            this.uneObracuniGodina.MaxValue = 2500D;
            this.uneObracuniGodina.MinValue = 2000D;
            this.uneObracuniGodina.Name = "uneObracuniGodina";
            this.uneObracuniGodina.Nullable = true;
            this.uneObracuniGodina.NullText = " ";
            this.uneObracuniGodina.PromptChar = ' ';
            this.uneObracuniGodina.Size = new System.Drawing.Size(130, 21);
            this.uneObracuniGodina.TabIndex = 2;
            this.uneObracuniGodina.Value = null;
            // 
            // lblValidationMessages
            // 
            this.lblValidationMessages.AutoSize = true;
            this.lblValidationMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblValidationMessages.ForeColor = System.Drawing.Color.Red;
            this.lblValidationMessages.Location = new System.Drawing.Point(3, 3);
            this.lblValidationMessages.Name = "lblValidationMessages";
            this.lblValidationMessages.Padding = new System.Windows.Forms.Padding(0, 2, 0, 5);
            this.lblValidationMessages.Size = new System.Drawing.Size(0, 20);
            this.lblValidationMessages.TabIndex = 112;
            // 
            // uneObracuniMjesec
            // 
            this.uneObracuniMjesec.Location = new System.Drawing.Point(95, 25);
            this.uneObracuniMjesec.MaxLength = 2;
            this.uneObracuniMjesec.Name = "uneObracuniMjesec";
            this.uneObracuniMjesec.Size = new System.Drawing.Size(130, 21);
            this.uneObracuniMjesec.TabIndex = 1;
            // 
            // btnObracunOdustani
            // 
            this.btnObracunOdustani.Location = new System.Drawing.Point(27, 134);
            this.btnObracunOdustani.Name = "btnObracunOdustani";
            this.btnObracunOdustani.Size = new System.Drawing.Size(120, 25);
            this.btnObracunOdustani.TabIndex = 7;
            this.btnObracunOdustani.Text = "Odustani";
            this.btnObracunOdustani.UseVisualStyleBackColor = true;
            this.btnObracunOdustani.Click += new System.EventHandler(this.btnObracunOdustani_Click);
            // 
            // uscObracuni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uneObracuniMjesec);
            this.Controls.Add(this.lblValidationMessages);
            this.Controls.Add(this.uneObracuniGodina);
            this.Controls.Add(this.uneObracunKolicina);
            this.Controls.Add(this.udtObracunValutaPlacanja);
            this.Controls.Add(this.uteObracunNaziv);
            this.Controls.Add(this.btnObracunOdustani);
            this.Controls.Add(this.btnObracunKreni);
            this.Controls.Add(this.lblObracunNaziv);
            this.Controls.Add(this.lblObracunKolicina);
            this.Controls.Add(this.lblObracuniValutaPlacanja);
            this.Controls.Add(this.lblObracuniGodina);
            this.Controls.Add(this.lblObracunMjesec);
            this.Name = "uscObracuni";
            this.Size = new System.Drawing.Size(495, 202);
            this.Load += new System.EventHandler(this.uscObracuni_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uteObracunNaziv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtObracunValutaPlacanja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneObracunKolicina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneObracuniGodina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneObracuniMjesec)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblObracunMjesec;
        private System.Windows.Forms.Label lblObracuniGodina;
        private System.Windows.Forms.Label lblObracunKolicina;
        private System.Windows.Forms.Label lblObracuniValutaPlacanja;
        private System.Windows.Forms.Label lblObracunNaziv;
        private System.Windows.Forms.Button btnObracunKreni;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteObracunNaziv;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtObracunValutaPlacanja;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneObracuniGodina;
        private System.Windows.Forms.Label lblValidationMessages;
        public Infragistics.Win.UltraWinEditors.UltraNumericEditor uneObracunKolicina;
        private Controls.TextBoxNumericInteger uneObracuniMjesec;
        private System.Windows.Forms.Button btnObracunOdustani;

    }
}

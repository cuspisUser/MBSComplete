namespace JOPPD
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
            this.lblValidationMessages = new System.Windows.Forms.Label();
            this.lblDatumNaloga = new System.Windows.Forms.Label();
            this.lblImePrezime = new System.Windows.Forms.Label();
            this.lblDrugiTroskovi = new System.Windows.Forms.Label();
            this.uneGodina = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.uneMjesec = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtNazivObracuna = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblVrstaObracuna = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbkRoditelj = new System.Windows.Forms.CheckBox();
            this.cbkUcenici = new System.Windows.Forms.CheckBox();
            this.cbkOstalo = new System.Windows.Forms.CheckBox();
            this.btnKreni = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.cbkUF = new System.Windows.Forms.CheckBox();
            this.cbkPraksa = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.uneGodina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneMjesec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNazivObracuna)).BeginInit();
            this.SuspendLayout();
            // 
            // lblValidationMessages
            // 
            this.lblValidationMessages.AutoSize = true;
            this.lblValidationMessages.ForeColor = System.Drawing.Color.Red;
            this.lblValidationMessages.Location = new System.Drawing.Point(3, 3);
            this.lblValidationMessages.Name = "lblValidationMessages";
            this.lblValidationMessages.Padding = new System.Windows.Forms.Padding(0, 2, 0, 5);
            this.lblValidationMessages.Size = new System.Drawing.Size(0, 20);
            this.lblValidationMessages.TabIndex = 18;
            // 
            // lblDatumNaloga
            // 
            this.lblDatumNaloga.AutoSize = true;
            this.lblDatumNaloga.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDatumNaloga.Location = new System.Drawing.Point(43, 71);
            this.lblDatumNaloga.Name = "lblDatumNaloga";
            this.lblDatumNaloga.Size = new System.Drawing.Size(69, 13);
            this.lblDatumNaloga.TabIndex = 27;
            this.lblDatumNaloga.Text = "Za mjesec:";
            // 
            // lblImePrezime
            // 
            this.lblImePrezime.AutoSize = true;
            this.lblImePrezime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblImePrezime.Location = new System.Drawing.Point(30, 36);
            this.lblImePrezime.Name = "lblImePrezime";
            this.lblImePrezime.Size = new System.Drawing.Size(82, 13);
            this.lblImePrezime.TabIndex = 26;
            this.lblImePrezime.Text = "Vrsta obračuna:";
            // 
            // lblDrugiTroskovi
            // 
            this.lblDrugiTroskovi.AutoSize = true;
            this.lblDrugiTroskovi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDrugiTroskovi.Location = new System.Drawing.Point(287, 71);
            this.lblDrugiTroskovi.Name = "lblDrugiTroskovi";
            this.lblDrugiTroskovi.Size = new System.Drawing.Size(68, 13);
            this.lblDrugiTroskovi.TabIndex = 32;
            this.lblDrugiTroskovi.Text = "Za godinu:";
            // 
            // uneGodina
            // 
            this.uneGodina.Location = new System.Drawing.Point(365, 67);
            this.uneGodina.MaskInput = "{LOC}-nnnnnnnnnn";
            this.uneGodina.MaximumSize = new System.Drawing.Size(9999, 0);
            this.uneGodina.MaxValue = 3000D;
            this.uneGodina.MinValue = 2014;
            this.uneGodina.Name = "uneGodina";
            this.uneGodina.Nullable = true;
            this.uneGodina.NullText = " ";
            this.uneGodina.PromptChar = ' ';
            this.uneGodina.Size = new System.Drawing.Size(148, 21);
            this.uneGodina.TabIndex = 2;
            this.uneGodina.Value = null;
            // 
            // uneMjesec
            // 
            this.uneMjesec.Location = new System.Drawing.Point(118, 67);
            this.uneMjesec.MaskInput = "{LOC}-nnnnnnnnnn";
            this.uneMjesec.MaximumSize = new System.Drawing.Size(9999, 0);
            this.uneMjesec.MaxValue = 12;
            this.uneMjesec.MinValue = 1;
            this.uneMjesec.Name = "uneMjesec";
            this.uneMjesec.Nullable = true;
            this.uneMjesec.NullText = " ";
            this.uneMjesec.PromptChar = ' ';
            this.uneMjesec.Size = new System.Drawing.Size(148, 21);
            this.uneMjesec.TabIndex = 1;
            this.uneMjesec.Value = null;
            // 
            // txtNazivObracuna
            // 
            this.txtNazivObracuna.Location = new System.Drawing.Point(118, 141);
            this.txtNazivObracuna.MaxLength = 100;
            this.txtNazivObracuna.Name = "txtNazivObracuna";
            this.txtNazivObracuna.Size = new System.Drawing.Size(395, 21);
            this.txtNazivObracuna.TabIndex = 6;
            // 
            // lblVrstaObracuna
            // 
            this.lblVrstaObracuna.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVrstaObracuna.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblVrstaObracuna.Location = new System.Drawing.Point(118, 32);
            this.lblVrstaObracuna.Name = "lblVrstaObracuna";
            this.lblVrstaObracuna.Size = new System.Drawing.Size(395, 21);
            this.lblVrstaObracuna.TabIndex = 20;
            this.lblVrstaObracuna.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 127;
            this.label2.Text = "Naziv obračuna:";
            // 
            // cbkRoditelj
            // 
            this.cbkRoditelj.AutoSize = true;
            this.cbkRoditelj.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbkRoditelj.Location = new System.Drawing.Point(118, 102);
            this.cbkRoditelj.Name = "cbkRoditelj";
            this.cbkRoditelj.Size = new System.Drawing.Size(66, 17);
            this.cbkRoditelj.TabIndex = 3;
            this.cbkRoditelj.Text = "Roditelji:";
            this.cbkRoditelj.UseVisualStyleBackColor = true;
            // 
            // cbkUcenici
            // 
            this.cbkUcenici.AutoSize = true;
            this.cbkUcenici.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbkUcenici.Location = new System.Drawing.Point(289, 102);
            this.cbkUcenici.Name = "cbkUcenici";
            this.cbkUcenici.Size = new System.Drawing.Size(65, 17);
            this.cbkUcenici.TabIndex = 4;
            this.cbkUcenici.Text = "Učenici:";
            this.cbkUcenici.UseVisualStyleBackColor = true;
            this.cbkUcenici.CheckedChanged += new System.EventHandler(this.cbkUcenici_CheckedChanged);
            // 
            // cbkOstalo
            // 
            this.cbkOstalo.AutoSize = true;
            this.cbkOstalo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbkOstalo.Location = new System.Drawing.Point(454, 102);
            this.cbkOstalo.Name = "cbkOstalo";
            this.cbkOstalo.Size = new System.Drawing.Size(59, 17);
            this.cbkOstalo.TabIndex = 5;
            this.cbkOstalo.Text = "Ostalo:";
            this.cbkOstalo.UseVisualStyleBackColor = true;
            // 
            // btnKreni
            // 
            this.btnKreni.Location = new System.Drawing.Point(397, 170);
            this.btnKreni.Name = "btnKreni";
            this.btnKreni.Size = new System.Drawing.Size(119, 23);
            this.btnKreni.TabIndex = 8;
            this.btnKreni.Text = "Kreni";
            this.btnKreni.UseVisualStyleBackColor = true;
            this.btnKreni.Click += new System.EventHandler(this.btnKreni_Click);
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(118, 170);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(75, 23);
            this.btnOdustani.TabIndex = 7;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // cbkUF
            // 
            this.cbkUF.AutoSize = true;
            this.cbkUF.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbkUF.Location = new System.Drawing.Point(273, 122);
            this.cbkUF.Name = "cbkUF";
            this.cbkUF.Size = new System.Drawing.Size(43, 17);
            this.cbkUF.TabIndex = 128;
            this.cbkUF.Text = "UF:";
            this.cbkUF.UseVisualStyleBackColor = true;
            this.cbkUF.Visible = false;
            // 
            // cbkPraksa
            // 
            this.cbkPraksa.AutoSize = true;
            this.cbkPraksa.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbkPraksa.Location = new System.Drawing.Point(323, 122);
            this.cbkPraksa.Name = "cbkPraksa";
            this.cbkPraksa.Size = new System.Drawing.Size(62, 17);
            this.cbkPraksa.TabIndex = 129;
            this.cbkPraksa.Text = "Praksa:";
            this.cbkPraksa.UseVisualStyleBackColor = true;
            this.cbkPraksa.Visible = false;
            // 
            // uscObracuni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbkPraksa);
            this.Controls.Add(this.cbkUF);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.btnKreni);
            this.Controls.Add(this.cbkOstalo);
            this.Controls.Add(this.cbkUcenici);
            this.Controls.Add(this.cbkRoditelj);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblVrstaObracuna);
            this.Controls.Add(this.txtNazivObracuna);
            this.Controls.Add(this.uneMjesec);
            this.Controls.Add(this.uneGodina);
            this.Controls.Add(this.lblDrugiTroskovi);
            this.Controls.Add(this.lblDatumNaloga);
            this.Controls.Add(this.lblImePrezime);
            this.Controls.Add(this.lblValidationMessages);
            this.Name = "uscObracuni";
            this.Size = new System.Drawing.Size(569, 257);
            this.Load += new System.EventHandler(this.uscObracuni_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uneGodina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneMjesec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNazivObracuna)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblValidationMessages;
        private System.Windows.Forms.Label lblDatumNaloga;
        private System.Windows.Forms.Label lblImePrezime;
        private System.Windows.Forms.Label lblDrugiTroskovi;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneGodina;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneMjesec;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtNazivObracuna;
        private System.Windows.Forms.Label lblVrstaObracuna;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbkRoditelj;
        private System.Windows.Forms.CheckBox cbkUcenici;
        private System.Windows.Forms.CheckBox cbkOstalo;
        private System.Windows.Forms.Button btnKreni;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.CheckBox cbkUF;
        private System.Windows.Forms.CheckBox cbkPraksa;

    }
}

namespace Materijalno.UI.Izvjestaji
{
    partial class frmStanjeDokumenti
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.btnIspis = new System.Windows.Forms.Button();
            this.udtDatumOd = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.udtDatumDo = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.cbSkladiste = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMjestoTroska = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbrIzdatnica = new System.Windows.Forms.RadioButton();
            this.rbrPrimka = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.udtDatumOd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtDatumDo)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(4, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Datum do:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(4, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Datum od:";
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(84, 165);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(75, 23);
            this.btnOdustani.TabIndex = 6;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // btnIspis
            // 
            this.btnIspis.Location = new System.Drawing.Point(239, 165);
            this.btnIspis.Name = "btnIspis";
            this.btnIspis.Size = new System.Drawing.Size(75, 23);
            this.btnIspis.TabIndex = 7;
            this.btnIspis.Text = "Ispiši";
            this.btnIspis.UseVisualStyleBackColor = true;
            this.btnIspis.Click += new System.EventHandler(this.btnIspis_Click);
            // 
            // udtDatumOd
            // 
            this.udtDatumOd.Location = new System.Drawing.Point(84, 11);
            this.udtDatumOd.MaskInput = "{date}";
            this.udtDatumOd.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.udtDatumOd.Name = "udtDatumOd";
            this.udtDatumOd.Size = new System.Drawing.Size(230, 21);
            this.udtDatumOd.TabIndex = 0;
            this.udtDatumOd.Value = null;
            // 
            // udtDatumDo
            // 
            this.udtDatumDo.Location = new System.Drawing.Point(84, 37);
            this.udtDatumDo.MaskInput = "{date}";
            this.udtDatumDo.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.udtDatumDo.Name = "udtDatumDo";
            this.udtDatumDo.Size = new System.Drawing.Size(230, 21);
            this.udtDatumDo.TabIndex = 1;
            this.udtDatumDo.Value = null;
            // 
            // cbSkladiste
            // 
            this.cbSkladiste.DropDownHeight = 200;
            this.cbSkladiste.DropDownWidth = 300;
            this.cbSkladiste.FormattingEnabled = true;
            this.cbSkladiste.IntegralHeight = false;
            this.cbSkladiste.Location = new System.Drawing.Point(84, 64);
            this.cbSkladiste.Name = "cbSkladiste";
            this.cbSkladiste.Size = new System.Drawing.Size(230, 21);
            this.cbSkladiste.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Skladište:";
            // 
            // cbMjestoTroska
            // 
            this.cbMjestoTroska.FormattingEnabled = true;
            this.cbMjestoTroska.Location = new System.Drawing.Point(84, 91);
            this.cbMjestoTroska.Name = "cbMjestoTroska";
            this.cbMjestoTroska.Size = new System.Drawing.Size(230, 21);
            this.cbMjestoTroska.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Mjesto troška:";
            // 
            // rbrIzdatnica
            // 
            this.rbrIzdatnica.AutoSize = true;
            this.rbrIzdatnica.Location = new System.Drawing.Point(158, 131);
            this.rbrIzdatnica.Name = "rbrIzdatnica";
            this.rbrIzdatnica.Size = new System.Drawing.Size(68, 17);
            this.rbrIzdatnica.TabIndex = 5;
            this.rbrIzdatnica.TabStop = true;
            this.rbrIzdatnica.Text = "Izdatnice";
            this.rbrIzdatnica.UseVisualStyleBackColor = true;
            // 
            // rbrPrimka
            // 
            this.rbrPrimka.AutoSize = true;
            this.rbrPrimka.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbrPrimka.Location = new System.Drawing.Point(81, 131);
            this.rbrPrimka.Name = "rbrPrimka";
            this.rbrPrimka.Size = new System.Drawing.Size(57, 17);
            this.rbrPrimka.TabIndex = 4;
            this.rbrPrimka.TabStop = true;
            this.rbrPrimka.Text = "Primke";
            this.rbrPrimka.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbrPrimka.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(4, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 26);
            this.label5.TabIndex = 21;
            this.label5.Text = "Vrsta dokumenta:";
            // 
            // frmStanjeDokumenti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 216);
            this.ControlBox = false;
            this.Controls.Add(this.rbrIzdatnica);
            this.Controls.Add(this.rbrPrimka);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbMjestoTroska);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSkladiste);
            this.Controls.Add(this.udtDatumDo);
            this.Controls.Add(this.udtDatumOd);
            this.Controls.Add(this.btnIspis);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmStanjeDokumenti";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stanje  dokumenata";
            ((System.ComponentModel.ISupportInitialize)(this.udtDatumOd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtDatumDo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.Button btnIspis;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtDatumOd;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtDatumDo;
        private System.Windows.Forms.ComboBox cbSkladiste;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMjestoTroska;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbrIzdatnica;
        private System.Windows.Forms.RadioButton rbrPrimka;
        private System.Windows.Forms.Label label5;
    }
}
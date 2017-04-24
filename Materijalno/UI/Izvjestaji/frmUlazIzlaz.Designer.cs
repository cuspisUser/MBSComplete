namespace Materijalno.UI.Izvjestaji
{
    partial class frmUlazIzlaz
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
            this.cmbSkladiste = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rbrPrimka = new System.Windows.Forms.RadioButton();
            this.rbrIzdatnica = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.udtDatumOd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtDatumDo)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(4, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Datum do:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(4, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Datum od:";
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(78, 165);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(75, 23);
            this.btnOdustani.TabIndex = 9;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // btnIspis
            // 
            this.btnIspis.Location = new System.Drawing.Point(233, 165);
            this.btnIspis.Name = "btnIspis";
            this.btnIspis.Size = new System.Drawing.Size(75, 23);
            this.btnIspis.TabIndex = 10;
            this.btnIspis.Text = "Ispiši";
            this.btnIspis.UseVisualStyleBackColor = true;
            this.btnIspis.Click += new System.EventHandler(this.btnIspis_Click);
            // 
            // udtDatumOd
            // 
            this.udtDatumOd.Location = new System.Drawing.Point(78, 34);
            this.udtDatumOd.MaskInput = "{date}";
            this.udtDatumOd.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.udtDatumOd.Name = "udtDatumOd";
            this.udtDatumOd.Size = new System.Drawing.Size(230, 21);
            this.udtDatumOd.TabIndex = 14;
            this.udtDatumOd.Value = null;
            // 
            // udtDatumDo
            // 
            this.udtDatumDo.Location = new System.Drawing.Point(78, 60);
            this.udtDatumDo.MaskInput = "{date}";
            this.udtDatumDo.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.udtDatumDo.Name = "udtDatumDo";
            this.udtDatumDo.Size = new System.Drawing.Size(230, 21);
            this.udtDatumDo.TabIndex = 15;
            this.udtDatumDo.Value = null;
            // 
            // cmbSkladiste
            // 
            this.cmbSkladiste.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbSkladiste.FormattingEnabled = true;
            this.cmbSkladiste.Location = new System.Drawing.Point(78, 7);
            this.cmbSkladiste.Name = "cmbSkladiste";
            this.cmbSkladiste.Size = new System.Drawing.Size(230, 21);
            this.cmbSkladiste.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Skladište:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 26);
            this.label2.TabIndex = 18;
            this.label2.Text = "Vrsta dokumenta:";
            // 
            // rbrPrimka
            // 
            this.rbrPrimka.AutoSize = true;
            this.rbrPrimka.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbrPrimka.Location = new System.Drawing.Point(78, 104);
            this.rbrPrimka.Name = "rbrPrimka";
            this.rbrPrimka.Size = new System.Drawing.Size(57, 17);
            this.rbrPrimka.TabIndex = 19;
            this.rbrPrimka.TabStop = true;
            this.rbrPrimka.Text = "Primke";
            this.rbrPrimka.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbrPrimka.UseVisualStyleBackColor = true;
            // 
            // rbrIzdatnica
            // 
            this.rbrIzdatnica.AutoSize = true;
            this.rbrIzdatnica.Location = new System.Drawing.Point(155, 104);
            this.rbrIzdatnica.Name = "rbrIzdatnica";
            this.rbrIzdatnica.Size = new System.Drawing.Size(68, 17);
            this.rbrIzdatnica.TabIndex = 20;
            this.rbrIzdatnica.TabStop = true;
            this.rbrIzdatnica.Text = "Izdatnice";
            this.rbrIzdatnica.UseVisualStyleBackColor = true;
            // 
            // frmUlazIzlaz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 200);
            this.ControlBox = false;
            this.Controls.Add(this.rbrIzdatnica);
            this.Controls.Add(this.rbrPrimka);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbSkladiste);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.udtDatumDo);
            this.Controls.Add(this.udtDatumOd);
            this.Controls.Add(this.btnIspis);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmUlazIzlaz";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ulaz i izlaz po grupama";
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
        private System.Windows.Forms.ComboBox cmbSkladiste;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbrPrimka;
        private System.Windows.Forms.RadioButton rbrIzdatnica;
    }
}
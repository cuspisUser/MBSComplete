namespace Materijalno.UI.Izvjestaji
{
    partial class frmKarticeArtikala
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
            this.label4 = new System.Windows.Forms.Label();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.btnIspis = new System.Windows.Forms.Button();
            this.cmbProizvod = new System.Windows.Forms.ComboBox();
            this.cmbSkladiste = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tcDatum = new System.Windows.Forms.TabControl();
            this.tcRazdoblje = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.udtRazdobljeDatumDo = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label3 = new System.Windows.Forms.Label();
            this.udtRazdobljeDatumOd = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.tcNaDan = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.udtNaDan = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.tcDatum.SuspendLayout();
            this.tcRazdoblje.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udtRazdobljeDatumDo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtRazdobljeDatumOd)).BeginInit();
            this.tcNaDan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udtNaDan)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(4, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Proizvod:";
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(86, 155);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(75, 23);
            this.btnOdustani.TabIndex = 9;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // btnIspis
            // 
            this.btnIspis.Location = new System.Drawing.Point(241, 155);
            this.btnIspis.Name = "btnIspis";
            this.btnIspis.Size = new System.Drawing.Size(75, 23);
            this.btnIspis.TabIndex = 10;
            this.btnIspis.Text = "Ispiši";
            this.btnIspis.UseVisualStyleBackColor = true;
            this.btnIspis.Click += new System.EventHandler(this.btnIspis_Click);
            // 
            // cmbProizvod
            // 
            this.cmbProizvod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbProizvod.FormattingEnabled = true;
            this.cmbProizvod.Location = new System.Drawing.Point(86, 3);
            this.cmbProizvod.Name = "cmbProizvod";
            this.cmbProizvod.Size = new System.Drawing.Size(230, 21);
            this.cmbProizvod.TabIndex = 11;
            this.cmbProizvod.TextChanged += new System.EventHandler(this.cmbProizvod_TextChanged);
            this.cmbProizvod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbProizvod_KeyPress);
            // 
            // cmbSkladiste
            // 
            this.cmbSkladiste.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbSkladiste.FormattingEnabled = true;
            this.cmbSkladiste.Location = new System.Drawing.Point(86, 30);
            this.cmbSkladiste.Name = "cmbSkladiste";
            this.cmbSkladiste.Size = new System.Drawing.Size(230, 21);
            this.cmbSkladiste.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Skladište:";
            // 
            // tcDatum
            // 
            this.tcDatum.Controls.Add(this.tcRazdoblje);
            this.tcDatum.Controls.Add(this.tcNaDan);
            this.tcDatum.Location = new System.Drawing.Point(7, 57);
            this.tcDatum.Name = "tcDatum";
            this.tcDatum.SelectedIndex = 0;
            this.tcDatum.Size = new System.Drawing.Size(319, 95);
            this.tcDatum.TabIndex = 14;
            // 
            // tcRazdoblje
            // 
            this.tcRazdoblje.BackColor = System.Drawing.SystemColors.Control;
            this.tcRazdoblje.Controls.Add(this.label5);
            this.tcRazdoblje.Controls.Add(this.udtRazdobljeDatumDo);
            this.tcRazdoblje.Controls.Add(this.label3);
            this.tcRazdoblje.Controls.Add(this.udtRazdobljeDatumOd);
            this.tcRazdoblje.Location = new System.Drawing.Point(4, 22);
            this.tcRazdoblje.Name = "tcRazdoblje";
            this.tcRazdoblje.Padding = new System.Windows.Forms.Padding(3);
            this.tcRazdoblje.Size = new System.Drawing.Size(311, 69);
            this.tcRazdoblje.TabIndex = 0;
            this.tcRazdoblje.Text = "Za razdoblje";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(4, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Datum do:";
            // 
            // udtRazdobljeDatumDo
            // 
            this.udtRazdobljeDatumDo.Location = new System.Drawing.Point(77, 39);
            this.udtRazdobljeDatumDo.MaskInput = "{date}";
            this.udtRazdobljeDatumDo.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.udtRazdobljeDatumDo.Name = "udtRazdobljeDatumDo";
            this.udtRazdobljeDatumDo.Size = new System.Drawing.Size(230, 21);
            this.udtRazdobljeDatumDo.TabIndex = 19;
            this.udtRazdobljeDatumDo.Value = null;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(4, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Datum od:";
            // 
            // udtRazdobljeDatumOd
            // 
            this.udtRazdobljeDatumOd.Location = new System.Drawing.Point(77, 9);
            this.udtRazdobljeDatumOd.MaskInput = "{date}";
            this.udtRazdobljeDatumOd.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.udtRazdobljeDatumOd.Name = "udtRazdobljeDatumOd";
            this.udtRazdobljeDatumOd.Size = new System.Drawing.Size(230, 21);
            this.udtRazdobljeDatumOd.TabIndex = 17;
            this.udtRazdobljeDatumOd.Value = null;
            // 
            // tcNaDan
            // 
            this.tcNaDan.BackColor = System.Drawing.SystemColors.Control;
            this.tcNaDan.Controls.Add(this.label2);
            this.tcNaDan.Controls.Add(this.udtNaDan);
            this.tcNaDan.Location = new System.Drawing.Point(4, 22);
            this.tcNaDan.Name = "tcNaDan";
            this.tcNaDan.Padding = new System.Windows.Forms.Padding(3);
            this.tcNaDan.Size = new System.Drawing.Size(311, 69);
            this.tcNaDan.TabIndex = 1;
            this.tcNaDan.Text = "Na dan";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(2, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Na dan:";
            // 
            // udtNaDan
            // 
            this.udtNaDan.Location = new System.Drawing.Point(75, 23);
            this.udtNaDan.MaskInput = "{date}";
            this.udtNaDan.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.udtNaDan.Name = "udtNaDan";
            this.udtNaDan.Size = new System.Drawing.Size(230, 21);
            this.udtNaDan.TabIndex = 15;
            this.udtNaDan.Value = null;
            // 
            // frmKarticeArtikala
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 208);
            this.ControlBox = false;
            this.Controls.Add(this.tcDatum);
            this.Controls.Add(this.cmbSkladiste);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbProizvod);
            this.Controls.Add(this.btnIspis);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmKarticeArtikala";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kartica artikla";
            this.tcDatum.ResumeLayout(false);
            this.tcRazdoblje.ResumeLayout(false);
            this.tcRazdoblje.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udtRazdobljeDatumDo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtRazdobljeDatumOd)).EndInit();
            this.tcNaDan.ResumeLayout(false);
            this.tcNaDan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udtNaDan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.Button btnIspis;
        private System.Windows.Forms.ComboBox cmbProizvod;
        private System.Windows.Forms.ComboBox cmbSkladiste;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tcDatum;
        private System.Windows.Forms.TabPage tcRazdoblje;
        private System.Windows.Forms.TabPage tcNaDan;
        private System.Windows.Forms.Label label5;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtRazdobljeDatumDo;
        private System.Windows.Forms.Label label3;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtRazdobljeDatumOd;
        private System.Windows.Forms.Label label2;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtNaDan;
    }
}
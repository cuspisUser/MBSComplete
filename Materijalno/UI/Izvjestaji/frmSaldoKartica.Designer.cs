namespace Materijalno.UI.Izvjestaji
{
    partial class frmSaldoKartica
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbSkladiste = new System.Windows.Forms.ComboBox();
            this.udtDatumDo = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.udtDatumOd = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnIspis = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.udtDatumDo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtDatumOd)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Skladište:";
            // 
            // cbSkladiste
            // 
            this.cbSkladiste.DropDownHeight = 200;
            this.cbSkladiste.DropDownWidth = 300;
            this.cbSkladiste.FormattingEnabled = true;
            this.cbSkladiste.IntegralHeight = false;
            this.cbSkladiste.Location = new System.Drawing.Point(88, 65);
            this.cbSkladiste.Name = "cbSkladiste";
            this.cbSkladiste.Size = new System.Drawing.Size(230, 21);
            this.cbSkladiste.TabIndex = 20;
            // 
            // udtDatumDo
            // 
            this.udtDatumDo.Location = new System.Drawing.Point(88, 38);
            this.udtDatumDo.MaskInput = "{date}";
            this.udtDatumDo.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.udtDatumDo.Name = "udtDatumDo";
            this.udtDatumDo.Size = new System.Drawing.Size(230, 21);
            this.udtDatumDo.TabIndex = 19;
            this.udtDatumDo.Value = null;
            // 
            // udtDatumOd
            // 
            this.udtDatumOd.Location = new System.Drawing.Point(88, 12);
            this.udtDatumOd.MaskInput = "{date}";
            this.udtDatumOd.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.udtDatumOd.Name = "udtDatumOd";
            this.udtDatumOd.Size = new System.Drawing.Size(230, 21);
            this.udtDatumOd.TabIndex = 18;
            this.udtDatumOd.Value = null;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Datum od:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Datum do:";
            // 
            // btnIspis
            // 
            this.btnIspis.Location = new System.Drawing.Point(243, 106);
            this.btnIspis.Name = "btnIspis";
            this.btnIspis.Size = new System.Drawing.Size(75, 23);
            this.btnIspis.TabIndex = 25;
            this.btnIspis.Text = "Ispiši";
            this.btnIspis.UseVisualStyleBackColor = true;
            this.btnIspis.Click += new System.EventHandler(this.btnIspis_Click);
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(88, 106);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(75, 23);
            this.btnOdustani.TabIndex = 24;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // frmSaldoKartica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 141);
            this.Controls.Add(this.btnIspis);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSkladiste);
            this.Controls.Add(this.udtDatumDo);
            this.Controls.Add(this.udtDatumOd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "frmSaldoKartica";
            this.Text = "Saldo kartica";
            ((System.ComponentModel.ISupportInitialize)(this.udtDatumDo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtDatumOd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSkladiste;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtDatumDo;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtDatumOd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnIspis;
        private System.Windows.Forms.Button btnOdustani;
    }
}
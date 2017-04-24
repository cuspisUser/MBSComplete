namespace Materijalno.UI.Izvjestaji
{
    partial class frmInventurnaLista
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
            this.tcDatum = new System.Windows.Forms.TabControl();
            this.tcNaDan = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.udtNaDan = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.cmbSkladiste = new System.Windows.Forms.ComboBox();
            this.btnIspis = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.ckbKolicina = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tcDatum.SuspendLayout();
            this.tcNaDan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udtNaDan)).BeginInit();
            this.SuspendLayout();
            // 
            // tcDatum
            // 
            this.tcDatum.Controls.Add(this.tcNaDan);
            this.tcDatum.Location = new System.Drawing.Point(8, 94);
            this.tcDatum.Name = "tcDatum";
            this.tcDatum.SelectedIndex = 0;
            this.tcDatum.Size = new System.Drawing.Size(319, 78);
            this.tcDatum.TabIndex = 3;
            // 
            // tcNaDan
            // 
            this.tcNaDan.BackColor = System.Drawing.SystemColors.Control;
            this.tcNaDan.Controls.Add(this.label2);
            this.tcNaDan.Controls.Add(this.udtNaDan);
            this.tcNaDan.Location = new System.Drawing.Point(4, 22);
            this.tcNaDan.Name = "tcNaDan";
            this.tcNaDan.Padding = new System.Windows.Forms.Padding(3);
            this.tcNaDan.Size = new System.Drawing.Size(311, 52);
            this.tcNaDan.TabIndex = 1;
            this.tcNaDan.Text = "Na dan";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(2, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Na dan:";
            // 
            // udtNaDan
            // 
            this.udtNaDan.Location = new System.Drawing.Point(75, 15);
            this.udtNaDan.MaskInput = "{date}";
            this.udtNaDan.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.udtNaDan.Name = "udtNaDan";
            this.udtNaDan.Size = new System.Drawing.Size(230, 21);
            this.udtNaDan.TabIndex = 15;
            this.udtNaDan.Value = null;
            // 
            // cmbSkladiste
            // 
            this.cmbSkladiste.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbSkladiste.FormattingEnabled = true;
            this.cmbSkladiste.Location = new System.Drawing.Point(102, 8);
            this.cmbSkladiste.Name = "cmbSkladiste";
            this.cmbSkladiste.Size = new System.Drawing.Size(230, 21);
            this.cmbSkladiste.TabIndex = 0;
            // 
            // btnIspis
            // 
            this.btnIspis.Location = new System.Drawing.Point(244, 178);
            this.btnIspis.Name = "btnIspis";
            this.btnIspis.Size = new System.Drawing.Size(75, 23);
            this.btnIspis.TabIndex = 20;
            this.btnIspis.Text = "Ispiši";
            this.btnIspis.UseVisualStyleBackColor = true;
            this.btnIspis.Click += new System.EventHandler(this.btnIspis_Click);
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(89, 178);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(75, 23);
            this.btnOdustani.TabIndex = 19;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(10, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Skladište:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Sortiranje:";
            // 
            // cmbSort
            // 
            this.cmbSort.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbSort.FormattingEnabled = true;
            this.cmbSort.Items.AddRange(new object[] {
            "po šifri artikla",
            "po nazivu artikla",
            "po količini"});
            this.cmbSort.Location = new System.Drawing.Point(102, 35);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(230, 21);
            this.cmbSort.TabIndex = 1;
            // 
            // ckbKolicina
            // 
            this.ckbKolicina.AutoSize = true;
            this.ckbKolicina.Location = new System.Drawing.Point(102, 64);
            this.ckbKolicina.Name = "ckbKolicina";
            this.ckbKolicina.Size = new System.Drawing.Size(15, 14);
            this.ckbKolicina.TabIndex = 2;
            this.ckbKolicina.UseVisualStyleBackColor = true;
            this.ckbKolicina.CheckedChanged += new System.EventHandler(this.ckbKolicina_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Prikazati količinu:";
            // 
            // frmInventurnaLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 217);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ckbKolicina);
            this.Controls.Add(this.tcDatum);
            this.Controls.Add(this.cmbSkladiste);
            this.Controls.Add(this.btnIspis);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.cmbSort);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "frmInventurnaLista";
            this.Text = "Inventurna lista";
            this.Load += new System.EventHandler(this.frmInventurnaLista_Load);
            this.tcDatum.ResumeLayout(false);
            this.tcNaDan.ResumeLayout(false);
            this.tcNaDan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udtNaDan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcDatum;
        private System.Windows.Forms.TabPage tcNaDan;
        private System.Windows.Forms.Label label2;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtNaDan;
        private System.Windows.Forms.ComboBox cmbSkladiste;
        private System.Windows.Forms.Button btnIspis;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.CheckBox ckbKolicina;
        private System.Windows.Forms.Label label1;
    }
}
namespace Materijalno.UI.Izvjestaji
{
    partial class frmStanjeSkladista
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
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.btnIspis = new System.Windows.Forms.Button();
            this.cmbSkladiste = new System.Windows.Forms.ComboBox();
            this.tcDatum = new System.Windows.Forms.TabControl();
            this.tcNaDan = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.udtNaDan = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.tcDatum.SuspendLayout();
            this.tcNaDan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udtNaDan)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(4, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sortiranje:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(4, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Skladište:";
            // 
            // cmbSort
            // 
            this.cmbSort.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbSort.FormattingEnabled = true;
            this.cmbSort.Items.AddRange(new object[] {
            "po šifri artikla",
            "po nazivu artikla",
            "po količini"});
            this.cmbSort.Location = new System.Drawing.Point(83, 38);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(230, 21);
            this.cmbSort.TabIndex = 6;
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(83, 146);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(75, 23);
            this.btnOdustani.TabIndex = 9;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // btnIspis
            // 
            this.btnIspis.Location = new System.Drawing.Point(238, 146);
            this.btnIspis.Name = "btnIspis";
            this.btnIspis.Size = new System.Drawing.Size(75, 23);
            this.btnIspis.TabIndex = 10;
            this.btnIspis.Text = "Ispiši";
            this.btnIspis.UseVisualStyleBackColor = true;
            this.btnIspis.Click += new System.EventHandler(this.btnIspis_Click);
            // 
            // cmbSkladiste
            // 
            this.cmbSkladiste.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbSkladiste.FormattingEnabled = true;
            this.cmbSkladiste.Location = new System.Drawing.Point(83, 12);
            this.cmbSkladiste.Name = "cmbSkladiste";
            this.cmbSkladiste.Size = new System.Drawing.Size(230, 21);
            this.cmbSkladiste.TabIndex = 11;
            // 
            // tcDatum
            // 
            this.tcDatum.Controls.Add(this.tcNaDan);
            this.tcDatum.Location = new System.Drawing.Point(2, 62);
            this.tcDatum.Name = "tcDatum";
            this.tcDatum.SelectedIndex = 0;
            this.tcDatum.Size = new System.Drawing.Size(319, 78);
            this.tcDatum.TabIndex = 15;
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
            // frmStanjeSkladista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 192);
            this.ControlBox = false;
            this.Controls.Add(this.tcDatum);
            this.Controls.Add(this.cmbSkladiste);
            this.Controls.Add(this.btnIspis);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.cmbSort);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmStanjeSkladista";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stanje skladišta";
            this.tcDatum.ResumeLayout(false);
            this.tcNaDan.ResumeLayout(false);
            this.tcNaDan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udtNaDan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.Button btnIspis;
        private System.Windows.Forms.ComboBox cmbSkladiste;
        private System.Windows.Forms.TabControl tcDatum;
        private System.Windows.Forms.TabPage tcNaDan;
        private System.Windows.Forms.Label label2;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtNaDan;
    }
}
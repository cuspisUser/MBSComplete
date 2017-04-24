namespace UcenickoFakturiranje.UI.MaticniPodaci
{
    partial class SkolskaGodinaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkolskaGodinaForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripButtonSpremi = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButtonSpremiZatvori = new System.Windows.Forms.ToolStripButton();
            this.btnSkolskaGodinaZatvori = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DateTimePickerDatumZavrsetka = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblValidationMessages = new System.Windows.Forms.Label();
            this.TextBoxNaziv = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.DateTimePickerDatumPocetka = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.CheckBoxAktivnost = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DateTimePickerDatumZavrsetka)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxNaziv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateTimePickerDatumPocetka)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButtonSpremi,
            this.ToolStripButtonSpremiZatvori,
            this.btnSkolskaGodinaZatvori});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(548, 25);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ToolStripButtonSpremi
            // 
            this.ToolStripButtonSpremi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripButtonSpremi.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButtonSpremi.Image")));
            this.ToolStripButtonSpremi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonSpremi.Name = "ToolStripButtonSpremi";
            this.ToolStripButtonSpremi.Size = new System.Drawing.Size(80, 22);
            this.ToolStripButtonSpremi.Text = "Spremi i novi";
            this.ToolStripButtonSpremi.Click += new System.EventHandler(this.ToolStripButtonSpremi_Click);
            // 
            // ToolStripButtonSpremiZatvori
            // 
            this.ToolStripButtonSpremiZatvori.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripButtonSpremiZatvori.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButtonSpremiZatvori.Image")));
            this.ToolStripButtonSpremiZatvori.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonSpremiZatvori.Name = "ToolStripButtonSpremiZatvori";
            this.ToolStripButtonSpremiZatvori.Size = new System.Drawing.Size(92, 22);
            this.ToolStripButtonSpremiZatvori.Text = "Spremi i zatvori";
            this.ToolStripButtonSpremiZatvori.Click += new System.EventHandler(this.ToolStripButtonSpremiZatvori_Click);
            // 
            // btnSkolskaGodinaZatvori
            // 
            this.btnSkolskaGodinaZatvori.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSkolskaGodinaZatvori.Image = ((System.Drawing.Image)(resources.GetObject("btnSkolskaGodinaZatvori.Image")));
            this.btnSkolskaGodinaZatvori.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSkolskaGodinaZatvori.Name = "btnSkolskaGodinaZatvori";
            this.btnSkolskaGodinaZatvori.Size = new System.Drawing.Size(103, 22);
            this.btnSkolskaGodinaZatvori.Text = "Odustani i zatvori";
            this.btnSkolskaGodinaZatvori.Click += new System.EventHandler(this.btnSkolskaGodinaZatvori_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.DateTimePickerDatumZavrsetka, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblValidationMessages, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TextBoxNaziv, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.DateTimePickerDatumPocetka, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.CheckBoxAktivnost, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(548, 192);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // DateTimePickerDatumZavrsetka
            // 
            this.DateTimePickerDatumZavrsetka.Location = new System.Drawing.Point(120, 82);
            this.DateTimePickerDatumZavrsetka.Name = "DateTimePickerDatumZavrsetka";
            this.DateTimePickerDatumZavrsetka.Size = new System.Drawing.Size(89, 21);
            this.DateTimePickerDatumZavrsetka.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(8, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Datum završetka:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(8, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Aktivna ŠK.GOD:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(8, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Datum početka";
            // 
            // lblValidationMessages
            // 
            this.lblValidationMessages.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblValidationMessages, 2);
            this.lblValidationMessages.ForeColor = System.Drawing.Color.Red;
            this.lblValidationMessages.Location = new System.Drawing.Point(8, 5);
            this.lblValidationMessages.Name = "lblValidationMessages";
            this.lblValidationMessages.Padding = new System.Windows.Forms.Padding(0, 2, 0, 5);
            this.lblValidationMessages.Size = new System.Drawing.Size(0, 20);
            this.lblValidationMessages.TabIndex = 18;
            // 
            // TextBoxNaziv
            // 
            this.TextBoxNaziv.Location = new System.Drawing.Point(120, 28);
            this.TextBoxNaziv.MaxLength = 50;
            this.TextBoxNaziv.Name = "TextBoxNaziv";
            this.TextBoxNaziv.Size = new System.Drawing.Size(400, 21);
            this.TextBoxNaziv.TabIndex = 1;
            // 
            // DateTimePickerDatumPocetka
            // 
            this.DateTimePickerDatumPocetka.Location = new System.Drawing.Point(120, 55);
            this.DateTimePickerDatumPocetka.Name = "DateTimePickerDatumPocetka";
            this.DateTimePickerDatumPocetka.Size = new System.Drawing.Size(89, 21);
            this.DateTimePickerDatumPocetka.TabIndex = 2;
            // 
            // CheckBoxAktivnost
            // 
            this.CheckBoxAktivnost.Location = new System.Drawing.Point(120, 109);
            this.CheckBoxAktivnost.Name = "CheckBoxAktivnost";
            this.CheckBoxAktivnost.Size = new System.Drawing.Size(22, 20);
            this.CheckBoxAktivnost.TabIndex = 4;
            // 
            // SkolskaGodinaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "SkolskaGodinaForm";
            this.Size = new System.Drawing.Size(548, 217);
            this.Load += new System.EventHandler(this.SkolskaGodinaForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DateTimePickerDatumZavrsetka)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxNaziv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateTimePickerDatumPocetka)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ToolStripButtonSpremi;
        private System.Windows.Forms.ToolStripButton ToolStripButtonSpremiZatvori;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblValidationMessages;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor TextBoxNaziv;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor DateTimePickerDatumZavrsetka;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor DateTimePickerDatumPocetka;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor CheckBoxAktivnost;
        private System.Windows.Forms.ToolStripButton btnSkolskaGodinaZatvori;

    }
}

namespace UcenickoFakturiranje.UI.Fakturiranje
{
    partial class uscShemaKontiranje
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uscShemaKontiranje));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripButtonSpremi = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButtonSpremiZatvori = new System.Windows.Forms.ToolStripButton();
            this.btnCjenikOdustani = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblKonto = new System.Windows.Forms.Label();
            this.lblValidationMessages = new System.Windows.Forms.Label();
            this.uceStranaKnjizenja = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.uceKonto = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.uceVrstaIznosa = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lbCijena = new System.Windows.Forms.Label();
            this.lblStranaKnjizenja = new System.Windows.Forms.Label();
            this.lblVrstaIznosa = new System.Windows.Forms.Label();
            this.lblSifraMT = new System.Windows.Forms.Label();
            this.lblSifraOJ = new System.Windows.Forms.Label();
            this.uceSifraMT = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.uceSifraOJ = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceStranaKnjizenja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceKonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceVrstaIznosa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceSifraMT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceSifraOJ)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButtonSpremi,
            this.ToolStripButtonSpremiZatvori,
            this.btnCjenikOdustani});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(558, 25);
            this.toolStrip1.TabIndex = 23;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ToolStripButtonSpremi
            // 
            this.ToolStripButtonSpremi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripButtonSpremi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonSpremi.Name = "ToolStripButtonSpremi";
            this.ToolStripButtonSpremi.Size = new System.Drawing.Size(80, 22);
            this.ToolStripButtonSpremi.Text = "Spremi i novi";
            this.ToolStripButtonSpremi.Click += new System.EventHandler(this.ToolStripButtonSpremi_Click);
            // 
            // ToolStripButtonSpremiZatvori
            // 
            this.ToolStripButtonSpremiZatvori.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripButtonSpremiZatvori.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonSpremiZatvori.Name = "ToolStripButtonSpremiZatvori";
            this.ToolStripButtonSpremiZatvori.Size = new System.Drawing.Size(92, 22);
            this.ToolStripButtonSpremiZatvori.Text = "Spremi i zatvori";
            this.ToolStripButtonSpremiZatvori.Click += new System.EventHandler(this.ToolStripButtonSpremiZatvori_Click);
            // 
            // btnCjenikOdustani
            // 
            this.btnCjenikOdustani.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCjenikOdustani.Image = ((System.Drawing.Image)(resources.GetObject("btnCjenikOdustani.Image")));
            this.btnCjenikOdustani.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCjenikOdustani.Name = "btnCjenikOdustani";
            this.btnCjenikOdustani.Size = new System.Drawing.Size(103, 22);
            this.btnCjenikOdustani.Text = "Odustani i zatvori";
            this.btnCjenikOdustani.Click += new System.EventHandler(this.btnCjenikOdustani_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblKonto, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblValidationMessages, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.uceStranaKnjizenja, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.uceKonto, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.uceVrstaIznosa, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbCijena, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.lblStranaKnjizenja, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblVrstaIznosa, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblSifraMT, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblSifraOJ, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.uceSifraMT, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.uceSifraOJ, 1, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(558, 222);
            this.tableLayoutPanel1.TabIndex = 24;
            // 
            // lblKonto
            // 
            this.lblKonto.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblKonto.AutoSize = true;
            this.lblKonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKonto.Location = new System.Drawing.Point(8, 32);
            this.lblKonto.Name = "lblKonto";
            this.lblKonto.Size = new System.Drawing.Size(44, 13);
            this.lblKonto.TabIndex = 0;
            this.lblKonto.Text = "Konto:";
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
            // uceStranaKnjizenja
            // 
            this.uceStranaKnjizenja.DisplayMember = "NAZIVSTRANEKNJIZENJA";
            this.uceStranaKnjizenja.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.uceStranaKnjizenja.Location = new System.Drawing.Point(116, 55);
            this.uceStranaKnjizenja.MaxDropDownItems = 20;
            this.uceStranaKnjizenja.Name = "uceStranaKnjizenja";
            this.uceStranaKnjizenja.Size = new System.Drawing.Size(243, 21);
            this.uceStranaKnjizenja.TabIndex = 2;
            this.uceStranaKnjizenja.ValueMember = "IDSTRANEKNJIZENJA";
            // 
            // uceKonto
            // 
            this.uceKonto.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.uceKonto.DisplayMember = "NAZIVKONTO";
            this.uceKonto.Location = new System.Drawing.Point(116, 28);
            this.uceKonto.MaxDropDownItems = 20;
            this.uceKonto.Name = "uceKonto";
            this.uceKonto.Size = new System.Drawing.Size(426, 21);
            this.uceKonto.TabIndex = 1;
            this.uceKonto.ValueMember = "IDKONTO";
            // 
            // uceVrstaIznosa
            // 
            this.uceVrstaIznosa.DisplayMember = "IRAVRSTAIZNOSANAZIV";
            this.uceVrstaIznosa.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.uceVrstaIznosa.Location = new System.Drawing.Point(116, 82);
            this.uceVrstaIznosa.MaxDropDownItems = 20;
            this.uceVrstaIznosa.Name = "uceVrstaIznosa";
            this.uceVrstaIznosa.Size = new System.Drawing.Size(243, 21);
            this.uceVrstaIznosa.TabIndex = 4;
            this.uceVrstaIznosa.ValueMember = "IDIRAVRSTAIZNOSA";
            // 
            // lbCijena
            // 
            this.lbCijena.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbCijena.AutoSize = true;
            this.lbCijena.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbCijena.Location = new System.Drawing.Point(333, 178);
            this.lbCijena.Name = "lbCijena";
            this.lbCijena.Size = new System.Drawing.Size(0, 20);
            this.lbCijena.TabIndex = 32;
            // 
            // lblStranaKnjizenja
            // 
            this.lblStranaKnjizenja.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStranaKnjizenja.AutoSize = true;
            this.lblStranaKnjizenja.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblStranaKnjizenja.Location = new System.Drawing.Point(8, 59);
            this.lblStranaKnjizenja.Name = "lblStranaKnjizenja";
            this.lblStranaKnjizenja.Size = new System.Drawing.Size(102, 13);
            this.lblStranaKnjizenja.TabIndex = 35;
            this.lblStranaKnjizenja.Text = "Strana knjiženja:";
            // 
            // lblVrstaIznosa
            // 
            this.lblVrstaIznosa.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblVrstaIznosa.AutoSize = true;
            this.lblVrstaIznosa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblVrstaIznosa.Location = new System.Drawing.Point(8, 86);
            this.lblVrstaIznosa.Name = "lblVrstaIznosa";
            this.lblVrstaIznosa.Size = new System.Drawing.Size(80, 13);
            this.lblVrstaIznosa.TabIndex = 36;
            this.lblVrstaIznosa.Text = "Vrsta iznosa:";
            // 
            // lblSifraMT
            // 
            this.lblSifraMT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSifraMT.AutoSize = true;
            this.lblSifraMT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSifraMT.Location = new System.Drawing.Point(8, 113);
            this.lblSifraMT.Name = "lblSifraMT";
            this.lblSifraMT.Size = new System.Drawing.Size(59, 13);
            this.lblSifraMT.TabIndex = 37;
            this.lblSifraMT.Text = "Šifra MT:";
            // 
            // lblSifraOJ
            // 
            this.lblSifraOJ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSifraOJ.AutoSize = true;
            this.lblSifraOJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSifraOJ.Location = new System.Drawing.Point(8, 139);
            this.lblSifraOJ.Name = "lblSifraOJ";
            this.lblSifraOJ.Size = new System.Drawing.Size(56, 13);
            this.lblSifraOJ.TabIndex = 38;
            this.lblSifraOJ.Text = "Šifra OJ:";
            // 
            // uceSifraMT
            // 
            this.uceSifraMT.DisplayMember = "NAZIVMJESTOTROSKA";
            this.uceSifraMT.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.uceSifraMT.Location = new System.Drawing.Point(116, 109);
            this.uceSifraMT.MaxDropDownItems = 20;
            this.uceSifraMT.Name = "uceSifraMT";
            this.uceSifraMT.Size = new System.Drawing.Size(426, 21);
            this.uceSifraMT.TabIndex = 39;
            this.uceSifraMT.ValueMember = "IDMJESTOTROSKA";
            // 
            // uceSifraOJ
            // 
            this.uceSifraOJ.DisplayMember = "NAZIVORGJED";
            this.uceSifraOJ.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.uceSifraOJ.Location = new System.Drawing.Point(116, 136);
            this.uceSifraOJ.MaxDropDownItems = 20;
            this.uceSifraOJ.Name = "uceSifraOJ";
            this.uceSifraOJ.Size = new System.Drawing.Size(426, 21);
            this.uceSifraOJ.TabIndex = 40;
            this.uceSifraOJ.ValueMember = "IDORGJED";
            // 
            // uscShemaKontiranje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "uscShemaKontiranje";
            this.Size = new System.Drawing.Size(558, 247);
            this.Load += new System.EventHandler(this.uscShemaKontiranje_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceStranaKnjizenja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceKonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceVrstaIznosa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceSifraMT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceSifraOJ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ToolStripButtonSpremi;
        private System.Windows.Forms.ToolStripButton ToolStripButtonSpremiZatvori;
        private System.Windows.Forms.ToolStripButton btnCjenikOdustani;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblKonto;
        private System.Windows.Forms.Label lblValidationMessages;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceStranaKnjizenja;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceKonto;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceVrstaIznosa;
        private System.Windows.Forms.Label lbCijena;
        private System.Windows.Forms.Label lblStranaKnjizenja;
        private System.Windows.Forms.Label lblVrstaIznosa;
        private System.Windows.Forms.Label lblSifraMT;
        private System.Windows.Forms.Label lblSifraOJ;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceSifraMT;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceSifraOJ;
    }
}

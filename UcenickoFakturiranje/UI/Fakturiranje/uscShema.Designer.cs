namespace UcenickoFakturiranje.UI.Fakturiranje
{
    partial class uscShema
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uscShema));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            this.label1 = new System.Windows.Forms.Label();
            this.lblValidationMessages = new System.Windows.Forms.Label();
            this.txtNaziv = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripButtonSpremiZatvori = new System.Windows.Forms.ToolStripButton();
            this.btnOdjeljenjaZatvori = new System.Windows.Forms.ToolStripButton();
            this.lblDokumnet = new System.Windows.Forms.Label();
            this.ucbDokumentiShema = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ugdShema = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.llbDodajShemu = new System.Windows.Forms.LinkLabel();
            this.llbIzmjeniShemu = new System.Windows.Forms.LinkLabel();
            this.lblObrisiShemu = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.txtNaziv)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucbDokumentiShema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugdShema)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(5, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv:";
            // 
            // lblValidationMessages
            // 
            this.lblValidationMessages.AutoSize = true;
            this.lblValidationMessages.ForeColor = System.Drawing.Color.Red;
            this.lblValidationMessages.Location = new System.Drawing.Point(5, 21);
            this.lblValidationMessages.Name = "lblValidationMessages";
            this.lblValidationMessages.Padding = new System.Windows.Forms.Padding(0, 2, 0, 5);
            this.lblValidationMessages.Size = new System.Drawing.Size(0, 20);
            this.lblValidationMessages.TabIndex = 18;
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(76, 44);
            this.txtNaziv.MaxLength = 20;
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(328, 21);
            this.txtNaziv.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButtonSpremiZatvori,
            this.btnOdjeljenjaZatvori});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(610, 25);
            this.toolStrip1.TabIndex = 22;
            this.toolStrip1.Text = "toolStrip1";
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
            // btnOdjeljenjaZatvori
            // 
            this.btnOdjeljenjaZatvori.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOdjeljenjaZatvori.Image = ((System.Drawing.Image)(resources.GetObject("btnOdjeljenjaZatvori.Image")));
            this.btnOdjeljenjaZatvori.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOdjeljenjaZatvori.Name = "btnOdjeljenjaZatvori";
            this.btnOdjeljenjaZatvori.Size = new System.Drawing.Size(103, 22);
            this.btnOdjeljenjaZatvori.Text = "Odustani i zatvori";
            this.btnOdjeljenjaZatvori.Click += new System.EventHandler(this.btnOdjeljenjaZatvori_Click);
            // 
            // lblDokumnet
            // 
            this.lblDokumnet.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDokumnet.AutoSize = true;
            this.lblDokumnet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDokumnet.Location = new System.Drawing.Point(5, 75);
            this.lblDokumnet.Name = "lblDokumnet";
            this.lblDokumnet.Size = new System.Drawing.Size(68, 13);
            this.lblDokumnet.TabIndex = 19;
            this.lblDokumnet.Text = "Dokument:";
            // 
            // ucbDokumentiShema
            // 
            this.ucbDokumentiShema.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.ucbDokumentiShema.DisplayMember = "NAZIVDOKUMENT";
            this.ucbDokumentiShema.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ucbDokumentiShema.Location = new System.Drawing.Point(76, 71);
            this.ucbDokumentiShema.MaxDropDownItems = 20;
            this.ucbDokumentiShema.Name = "ucbDokumentiShema";
            this.ucbDokumentiShema.Size = new System.Drawing.Size(328, 21);
            this.ucbDokumentiShema.TabIndex = 20;
            this.ucbDokumentiShema.ValueMember = "IDDOKUMENT";
            // 
            // ugdShema
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ugdShema.DisplayLayout.Appearance = appearance1;
            this.ugdShema.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugdShema.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.ugdShema.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugdShema.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.ugdShema.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance3.BackColor2 = System.Drawing.SystemColors.Control;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugdShema.DisplayLayout.GroupByBox.PromptAppearance = appearance3;
            this.ugdShema.DisplayLayout.MaxColScrollRegions = 1;
            this.ugdShema.DisplayLayout.MaxRowScrollRegions = 1;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            appearance9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ugdShema.DisplayLayout.Override.ActiveCellAppearance = appearance9;
            appearance5.BackColor = System.Drawing.SystemColors.Highlight;
            appearance5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ugdShema.DisplayLayout.Override.ActiveRowAppearance = appearance5;
            this.ugdShema.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ugdShema.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            this.ugdShema.DisplayLayout.Override.CardAreaAppearance = appearance12;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ugdShema.DisplayLayout.Override.CellAppearance = appearance8;
            this.ugdShema.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ugdShema.DisplayLayout.Override.CellPadding = 0;
            appearance6.BackColor = System.Drawing.SystemColors.Control;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.ugdShema.DisplayLayout.Override.GroupByRowAppearance = appearance6;
            appearance7.TextHAlignAsString = "Left";
            this.ugdShema.DisplayLayout.Override.HeaderAppearance = appearance7;
            this.ugdShema.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ugdShema.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance10.BackColor = System.Drawing.SystemColors.Window;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            this.ugdShema.DisplayLayout.Override.RowAppearance = appearance10;
            this.ugdShema.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ugdShema.DisplayLayout.Override.TemplateAddRowAppearance = appearance11;
            this.ugdShema.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ugdShema.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ugdShema.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ugdShema.Location = new System.Drawing.Point(3, 98);
            this.ugdShema.Name = "ugdShema";
            this.ugdShema.Size = new System.Drawing.Size(591, 219);
            this.ugdShema.TabIndex = 23;
            this.ugdShema.Text = "ultraGrid1";
            this.ugdShema.DoubleClick += new System.EventHandler(this.ugdShema_DoubleClick);
            // 
            // llbDodajShemu
            // 
            this.llbDodajShemu.AutoSize = true;
            this.llbDodajShemu.Location = new System.Drawing.Point(15, 322);
            this.llbDodajShemu.Name = "llbDodajShemu";
            this.llbDodajShemu.Size = new System.Drawing.Size(120, 13);
            this.llbDodajShemu.TabIndex = 24;
            this.llbDodajShemu.TabStop = true;
            this.llbDodajShemu.Text = "Dodaj Shemu kontiranja";
            this.llbDodajShemu.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbDodajShemu_LinkClicked);
            // 
            // llbIzmjeniShemu
            // 
            this.llbIzmjeniShemu.AutoSize = true;
            this.llbIzmjeniShemu.Location = new System.Drawing.Point(248, 322);
            this.llbIzmjeniShemu.Name = "llbIzmjeniShemu";
            this.llbIzmjeniShemu.Size = new System.Drawing.Size(124, 13);
            this.llbIzmjeniShemu.TabIndex = 25;
            this.llbIzmjeniShemu.TabStop = true;
            this.llbIzmjeniShemu.Text = "Izmjeni Shemu kontiranja";
            this.llbIzmjeniShemu.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbIzmjeniShemu_LinkClicked);
            // 
            // lblObrisiShemu
            // 
            this.lblObrisiShemu.AutoSize = true;
            this.lblObrisiShemu.Location = new System.Drawing.Point(466, 322);
            this.lblObrisiShemu.Name = "lblObrisiShemu";
            this.lblObrisiShemu.Size = new System.Drawing.Size(118, 13);
            this.lblObrisiShemu.TabIndex = 26;
            this.lblObrisiShemu.TabStop = true;
            this.lblObrisiShemu.Text = "Obriši Shemu kontiranja";
            this.lblObrisiShemu.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblObrisiShemu_LinkClicked);
            // 
            // uscShema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblObrisiShemu);
            this.Controls.Add(this.llbIzmjeniShemu);
            this.Controls.Add(this.llbDodajShemu);
            this.Controls.Add(this.ugdShema);
            this.Controls.Add(this.lblDokumnet);
            this.Controls.Add(this.txtNaziv);
            this.Controls.Add(this.ucbDokumentiShema);
            this.Controls.Add(this.lblValidationMessages);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "uscShema";
            this.Size = new System.Drawing.Size(610, 424);
            this.Load += new System.EventHandler(this.uscShema_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtNaziv)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucbDokumentiShema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugdShema)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtNaziv;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ToolStripButtonSpremiZatvori;
        private System.Windows.Forms.ToolStripButton btnOdjeljenjaZatvori;
        private System.Windows.Forms.Label lblDokumnet;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ucbDokumentiShema;
        public Infragistics.Win.UltraWinGrid.UltraGrid ugdShema;
        private System.Windows.Forms.LinkLabel llbDodajShemu;
        private System.Windows.Forms.LinkLabel llbIzmjeniShemu;
        private System.Windows.Forms.LinkLabel lblObrisiShemu;
        private System.Windows.Forms.Label lblValidationMessages;

    }
}

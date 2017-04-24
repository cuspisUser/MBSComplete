namespace Materijalno.UI.Dokumenti
{
    partial class IzdatnicaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IzdatnicaForm));
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            this.tspForm = new System.Windows.Forms.ToolStrip();
            this.tsbSpremiZatvori = new System.Windows.Forms.ToolStripButton();
            this.tsbOdustani = new System.Windows.Forms.ToolStripButton();
            this.gbxStavke = new System.Windows.Forms.GroupBox();
            this.ugdIzdatnicaStavke = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.btnUrediStavku = new System.Windows.Forms.Button();
            this.btnBrisiStavku = new System.Windows.Forms.Button();
            this.btnNovaStavka = new System.Windows.Forms.Button();
            this.gbxMaticni = new System.Windows.Forms.GroupBox();
            this.cmbMjestoTroska = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comDokument = new System.Windows.Forms.ComboBox();
            this.uceSkladiste = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.udtDatumNastajanja = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.uteNapomena = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.uteSifra = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblName5 = new System.Windows.Forms.Label();
            this.lblName4 = new System.Windows.Forms.Label();
            this.lblName3 = new System.Windows.Forms.Label();
            this.lblName2 = new System.Windows.Forms.Label();
            this.lblName1 = new System.Windows.Forms.Label();
            this.lblValidationMessages = new System.Windows.Forms.Label();
            this.tspForm.SuspendLayout();
            this.gbxStavke.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugdIzdatnicaStavke)).BeginInit();
            this.gbxMaticni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceSkladiste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtDatumNastajanja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteNapomena)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteSifra)).BeginInit();
            this.SuspendLayout();
            // 
            // tspForm
            // 
            this.tspForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSpremiZatvori,
            this.tsbOdustani});
            this.tspForm.Location = new System.Drawing.Point(0, 0);
            this.tspForm.Name = "tspForm";
            this.tspForm.Size = new System.Drawing.Size(745, 25);
            this.tspForm.TabIndex = 20;
            this.tspForm.Text = "toolStrip1";
            // 
            // tsbSpremiZatvori
            // 
            this.tsbSpremiZatvori.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSpremiZatvori.Image = ((System.Drawing.Image)(resources.GetObject("tsbSpremiZatvori.Image")));
            this.tsbSpremiZatvori.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSpremiZatvori.Name = "tsbSpremiZatvori";
            this.tsbSpremiZatvori.Size = new System.Drawing.Size(92, 22);
            this.tsbSpremiZatvori.Text = "Spremi i zatvori";
            this.tsbSpremiZatvori.Click += new System.EventHandler(this.tsbSpremiZatvori_Click);
            // 
            // tsbOdustani
            // 
            this.tsbOdustani.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbOdustani.Image = ((System.Drawing.Image)(resources.GetObject("tsbOdustani.Image")));
            this.tsbOdustani.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOdustani.Name = "tsbOdustani";
            this.tsbOdustani.Size = new System.Drawing.Size(103, 22);
            this.tsbOdustani.Text = "Odustani i zatvori";
            this.tsbOdustani.Click += new System.EventHandler(this.tsbOdustani_Click);
            // 
            // gbxStavke
            // 
            this.gbxStavke.Controls.Add(this.ugdIzdatnicaStavke);
            this.gbxStavke.Location = new System.Drawing.Point(6, 222);
            this.gbxStavke.Margin = new System.Windows.Forms.Padding(2);
            this.gbxStavke.Name = "gbxStavke";
            this.gbxStavke.Padding = new System.Windows.Forms.Padding(2);
            this.gbxStavke.Size = new System.Drawing.Size(678, 332);
            this.gbxStavke.TabIndex = 78;
            this.gbxStavke.TabStop = false;
            this.gbxStavke.Text = "Stavke izdatnice";
            // 
            // ugdIzdatnicaStavke
            // 
            appearance37.BackColor = System.Drawing.SystemColors.Window;
            appearance37.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ugdIzdatnicaStavke.DisplayLayout.Appearance = appearance37;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1});
            this.ugdIzdatnicaStavke.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ugdIzdatnicaStavke.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugdIzdatnicaStavke.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance38.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance38.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance38.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance38.BorderColor = System.Drawing.SystemColors.Window;
            this.ugdIzdatnicaStavke.DisplayLayout.GroupByBox.Appearance = appearance38;
            appearance39.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugdIzdatnicaStavke.DisplayLayout.GroupByBox.BandLabelAppearance = appearance39;
            this.ugdIzdatnicaStavke.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance40.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance40.BackColor2 = System.Drawing.SystemColors.Control;
            appearance40.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance40.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugdIzdatnicaStavke.DisplayLayout.GroupByBox.PromptAppearance = appearance40;
            this.ugdIzdatnicaStavke.DisplayLayout.MaxColScrollRegions = 1;
            this.ugdIzdatnicaStavke.DisplayLayout.MaxRowScrollRegions = 1;
            appearance41.BackColor = System.Drawing.SystemColors.Window;
            appearance41.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ugdIzdatnicaStavke.DisplayLayout.Override.ActiveCellAppearance = appearance41;
            appearance42.BackColor = System.Drawing.SystemColors.Highlight;
            appearance42.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ugdIzdatnicaStavke.DisplayLayout.Override.ActiveRowAppearance = appearance42;
            this.ugdIzdatnicaStavke.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ugdIzdatnicaStavke.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance43.BackColor = System.Drawing.SystemColors.Window;
            this.ugdIzdatnicaStavke.DisplayLayout.Override.CardAreaAppearance = appearance43;
            appearance44.BorderColor = System.Drawing.Color.Silver;
            appearance44.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ugdIzdatnicaStavke.DisplayLayout.Override.CellAppearance = appearance44;
            this.ugdIzdatnicaStavke.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ugdIzdatnicaStavke.DisplayLayout.Override.CellPadding = 0;
            appearance45.BackColor = System.Drawing.SystemColors.Control;
            appearance45.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance45.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance45.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance45.BorderColor = System.Drawing.SystemColors.Window;
            this.ugdIzdatnicaStavke.DisplayLayout.Override.GroupByRowAppearance = appearance45;
            appearance46.TextHAlignAsString = "Left";
            this.ugdIzdatnicaStavke.DisplayLayout.Override.HeaderAppearance = appearance46;
            this.ugdIzdatnicaStavke.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ugdIzdatnicaStavke.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance47.BackColor = System.Drawing.SystemColors.Window;
            appearance47.BorderColor = System.Drawing.Color.Silver;
            this.ugdIzdatnicaStavke.DisplayLayout.Override.RowAppearance = appearance47;
            this.ugdIzdatnicaStavke.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance48.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ugdIzdatnicaStavke.DisplayLayout.Override.TemplateAddRowAppearance = appearance48;
            this.ugdIzdatnicaStavke.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ugdIzdatnicaStavke.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ugdIzdatnicaStavke.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ugdIzdatnicaStavke.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ugdIzdatnicaStavke.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ugdIzdatnicaStavke.Location = new System.Drawing.Point(2, 15);
            this.ugdIzdatnicaStavke.Name = "ugdIzdatnicaStavke";
            this.ugdIzdatnicaStavke.Size = new System.Drawing.Size(674, 315);
            this.ugdIzdatnicaStavke.TabIndex = 4;
            this.ugdIzdatnicaStavke.Text = "ultraGrid1";
            // 
            // btnUrediStavku
            // 
            this.btnUrediStavku.Enabled = false;
            this.btnUrediStavku.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUrediStavku.Location = new System.Drawing.Point(88, 191);
            this.btnUrediStavku.Margin = new System.Windows.Forms.Padding(2);
            this.btnUrediStavku.Name = "btnUrediStavku";
            this.btnUrediStavku.Size = new System.Drawing.Size(98, 24);
            this.btnUrediStavku.TabIndex = 74;
            this.btnUrediStavku.Text = "Uredi stavku";
            this.btnUrediStavku.UseVisualStyleBackColor = true;
            this.btnUrediStavku.Click += new System.EventHandler(this.btnUrediStavku_Click);
            // 
            // btnBrisiStavku
            // 
            this.btnBrisiStavku.Enabled = false;
            this.btnBrisiStavku.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBrisiStavku.Location = new System.Drawing.Point(190, 191);
            this.btnBrisiStavku.Margin = new System.Windows.Forms.Padding(2);
            this.btnBrisiStavku.Name = "btnBrisiStavku";
            this.btnBrisiStavku.Size = new System.Drawing.Size(136, 24);
            this.btnBrisiStavku.TabIndex = 75;
            this.btnBrisiStavku.Text = "Briši označene stavke";
            this.btnBrisiStavku.UseVisualStyleBackColor = true;
            this.btnBrisiStavku.Click += new System.EventHandler(this.btnBrisiStavku_Click);
            // 
            // btnNovaStavka
            // 
            this.btnNovaStavka.Location = new System.Drawing.Point(6, 191);
            this.btnNovaStavka.Margin = new System.Windows.Forms.Padding(2);
            this.btnNovaStavka.Name = "btnNovaStavka";
            this.btnNovaStavka.Size = new System.Drawing.Size(78, 24);
            this.btnNovaStavka.TabIndex = 73;
            this.btnNovaStavka.Text = "Nova stavka";
            this.btnNovaStavka.UseVisualStyleBackColor = true;
            this.btnNovaStavka.Click += new System.EventHandler(this.btnNovaStavka_Click);
            // 
            // gbxMaticni
            // 
            this.gbxMaticni.Controls.Add(this.cmbMjestoTroska);
            this.gbxMaticni.Controls.Add(this.label1);
            this.gbxMaticni.Controls.Add(this.comDokument);
            this.gbxMaticni.Controls.Add(this.uceSkladiste);
            this.gbxMaticni.Controls.Add(this.udtDatumNastajanja);
            this.gbxMaticni.Controls.Add(this.uteNapomena);
            this.gbxMaticni.Controls.Add(this.uteSifra);
            this.gbxMaticni.Controls.Add(this.lblName5);
            this.gbxMaticni.Controls.Add(this.lblName4);
            this.gbxMaticni.Controls.Add(this.lblName3);
            this.gbxMaticni.Controls.Add(this.lblName2);
            this.gbxMaticni.Controls.Add(this.lblName1);
            this.gbxMaticni.Location = new System.Drawing.Point(6, 50);
            this.gbxMaticni.Margin = new System.Windows.Forms.Padding(2);
            this.gbxMaticni.Name = "gbxMaticni";
            this.gbxMaticni.Padding = new System.Windows.Forms.Padding(2);
            this.gbxMaticni.Size = new System.Drawing.Size(678, 137);
            this.gbxMaticni.TabIndex = 77;
            this.gbxMaticni.TabStop = false;
            this.gbxMaticni.Text = "Osnovni podaci";
            // 
            // cmbMjestoTroska
            // 
            this.cmbMjestoTroska.DisplayMember = "Naziv";
            this.cmbMjestoTroska.FormattingEnabled = true;
            this.cmbMjestoTroska.Location = new System.Drawing.Point(443, 19);
            this.cmbMjestoTroska.Name = "cmbMjestoTroska";
            this.cmbMjestoTroska.Size = new System.Drawing.Size(224, 21);
            this.cmbMjestoTroska.TabIndex = 16;
            this.cmbMjestoTroska.ValueMember = "ID";
            this.cmbMjestoTroska.TextChanged += new System.EventHandler(this.cmbMjestoTroska_TextChanged);
            this.cmbMjestoTroska.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbMjestoTroska_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(354, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Mjesto troška:";
            // 
            // comDokument
            // 
            this.comDokument.DisplayMember = "Naziv";
            this.comDokument.FormattingEnabled = true;
            this.comDokument.Location = new System.Drawing.Point(123, 47);
            this.comDokument.Name = "comDokument";
            this.comDokument.Size = new System.Drawing.Size(224, 21);
            this.comDokument.TabIndex = 11;
            this.comDokument.ValueMember = "ID";
            this.comDokument.TextChanged += new System.EventHandler(this.uceDokument_TextChanged);
            this.comDokument.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uceDokument_KeyPress);
            // 
            // uceSkladiste
            // 
            this.uceSkladiste.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.uceSkladiste.DisplayMember = "Naziv";
            this.uceSkladiste.Location = new System.Drawing.Point(123, 71);
            this.uceSkladiste.MaxDropDownItems = 20;
            this.uceSkladiste.Name = "uceSkladiste";
            this.uceSkladiste.Size = new System.Drawing.Size(224, 21);
            this.uceSkladiste.TabIndex = 12;
            this.uceSkladiste.ValueMember = "ID";
            this.uceSkladiste.ValueChanged += new System.EventHandler(this.uceSkladiste_ValueChanged);
            // 
            // udtDatumNastajanja
            // 
            this.udtDatumNastajanja.Location = new System.Drawing.Point(123, 103);
            this.udtDatumNastajanja.MaskInput = "{date}";
            this.udtDatumNastajanja.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.udtDatumNastajanja.Name = "udtDatumNastajanja";
            this.udtDatumNastajanja.Size = new System.Drawing.Size(224, 21);
            this.udtDatumNastajanja.TabIndex = 13;
            this.udtDatumNastajanja.Value = null;
            this.udtDatumNastajanja.ValueChanged += new System.EventHandler(this.udtDatumNastajanja_ValueChanged);
            // 
            // uteNapomena
            // 
            this.uteNapomena.Location = new System.Drawing.Point(443, 46);
            this.uteNapomena.MaxLength = 50;
            this.uteNapomena.Multiline = true;
            this.uteNapomena.Name = "uteNapomena";
            this.uteNapomena.Size = new System.Drawing.Size(224, 78);
            this.uteNapomena.TabIndex = 14;
            // 
            // uteSifra
            // 
            this.uteSifra.Enabled = false;
            this.uteSifra.Location = new System.Drawing.Point(123, 19);
            this.uteSifra.MaxLength = 50;
            this.uteSifra.Name = "uteSifra";
            this.uteSifra.Size = new System.Drawing.Size(224, 21);
            this.uteSifra.TabIndex = 10;
            // 
            // lblName5
            // 
            this.lblName5.AutoSize = true;
            this.lblName5.Location = new System.Drawing.Point(354, 49);
            this.lblName5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName5.Name = "lblName5";
            this.lblName5.Size = new System.Drawing.Size(62, 13);
            this.lblName5.TabIndex = 7;
            this.lblName5.Text = "Napomena:";
            // 
            // lblName4
            // 
            this.lblName4.AutoSize = true;
            this.lblName4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblName4.Location = new System.Drawing.Point(5, 75);
            this.lblName4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName4.Name = "lblName4";
            this.lblName4.Size = new System.Drawing.Size(63, 13);
            this.lblName4.TabIndex = 6;
            this.lblName4.Text = "Skladište:";
            // 
            // lblName3
            // 
            this.lblName3.AutoSize = true;
            this.lblName3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblName3.Location = new System.Drawing.Point(5, 50);
            this.lblName3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName3.Name = "lblName3";
            this.lblName3.Size = new System.Drawing.Size(68, 13);
            this.lblName3.TabIndex = 4;
            this.lblName3.Text = "Dokument:";
            // 
            // lblName2
            // 
            this.lblName2.AutoSize = true;
            this.lblName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblName2.Location = new System.Drawing.Point(5, 107);
            this.lblName2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName2.Name = "lblName2";
            this.lblName2.Size = new System.Drawing.Size(109, 13);
            this.lblName2.TabIndex = 2;
            this.lblName2.Text = "Datum nastajanja:";
            // 
            // lblName1
            // 
            this.lblName1.AutoSize = true;
            this.lblName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblName1.Location = new System.Drawing.Point(5, 23);
            this.lblName1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName1.Name = "lblName1";
            this.lblName1.Size = new System.Drawing.Size(37, 13);
            this.lblName1.TabIndex = 0;
            this.lblName1.Text = "Šifra:";
            // 
            // lblValidationMessages
            // 
            this.lblValidationMessages.AutoSize = true;
            this.lblValidationMessages.ForeColor = System.Drawing.Color.Red;
            this.lblValidationMessages.Location = new System.Drawing.Point(11, 25);
            this.lblValidationMessages.Name = "lblValidationMessages";
            this.lblValidationMessages.Padding = new System.Windows.Forms.Padding(0, 2, 0, 5);
            this.lblValidationMessages.Size = new System.Drawing.Size(0, 20);
            this.lblValidationMessages.TabIndex = 76;
            // 
            // IzdatnicaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbxStavke);
            this.Controls.Add(this.btnUrediStavku);
            this.Controls.Add(this.btnBrisiStavku);
            this.Controls.Add(this.btnNovaStavka);
            this.Controls.Add(this.gbxMaticni);
            this.Controls.Add(this.lblValidationMessages);
            this.Controls.Add(this.tspForm);
            this.Name = "IzdatnicaForm";
            this.Size = new System.Drawing.Size(745, 591);
            this.Load += new System.EventHandler(this.FormLoad);
            this.tspForm.ResumeLayout(false);
            this.tspForm.PerformLayout();
            this.gbxStavke.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugdIzdatnicaStavke)).EndInit();
            this.gbxMaticni.ResumeLayout(false);
            this.gbxMaticni.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceSkladiste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtDatumNastajanja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteNapomena)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteSifra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tspForm;
        private System.Windows.Forms.ToolStripButton tsbSpremiZatvori;
        private System.Windows.Forms.ToolStripButton tsbOdustani;
        private System.Windows.Forms.GroupBox gbxStavke;
        private Infragistics.Win.UltraWinGrid.UltraGrid ugdIzdatnicaStavke;
        private System.Windows.Forms.Button btnUrediStavku;
        private System.Windows.Forms.Button btnBrisiStavku;
        private System.Windows.Forms.Button btnNovaStavka;
        private System.Windows.Forms.GroupBox gbxMaticni;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtDatumNastajanja;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteNapomena;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteSifra;
        private System.Windows.Forms.Label lblName5;
        private System.Windows.Forms.Label lblName4;
        private System.Windows.Forms.Label lblName3;
        private System.Windows.Forms.Label lblName2;
        private System.Windows.Forms.Label lblName1;
        private System.Windows.Forms.Label lblValidationMessages;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceSkladiste;
        private System.Windows.Forms.ComboBox comDokument;
        private System.Windows.Forms.ComboBox cmbMjestoTroska;
        private System.Windows.Forms.Label label1;


    }
}

namespace UcenickoFakturiranje.UI.Fakturiranje
{
    partial class RacunForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RacunForm));
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
            this.ugdStavke = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.btnUrediStavku = new System.Windows.Forms.Button();
            this.btnBrisiStavku = new System.Windows.Forms.Button();
            this.btnNovaStavka = new System.Windows.Forms.Button();
            this.gbxMaticni = new System.Windows.Forms.GroupBox();
            this.utePoziv = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label2 = new System.Windows.Forms.Label();
            this.uteModel = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.udtValuta = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.ucePartner = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.udtDatum = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
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
            ((System.ComponentModel.ISupportInitialize)(this.ugdStavke)).BeginInit();
            this.gbxMaticni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.utePoziv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtValuta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucePartner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtDatum)).BeginInit();
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
            this.tspForm.Size = new System.Drawing.Size(717, 25);
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
            this.gbxStavke.Controls.Add(this.ugdStavke);
            this.gbxStavke.Location = new System.Drawing.Point(6, 218);
            this.gbxStavke.Margin = new System.Windows.Forms.Padding(2);
            this.gbxStavke.Name = "gbxStavke";
            this.gbxStavke.Padding = new System.Windows.Forms.Padding(2);
            this.gbxStavke.Size = new System.Drawing.Size(654, 332);
            this.gbxStavke.TabIndex = 78;
            this.gbxStavke.TabStop = false;
            this.gbxStavke.Text = "Stavke računa";
            // 
            // ugdStavke
            // 
            appearance37.BackColor = System.Drawing.SystemColors.Window;
            appearance37.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ugdStavke.DisplayLayout.Appearance = appearance37;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1});
            this.ugdStavke.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ugdStavke.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugdStavke.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance38.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance38.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance38.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance38.BorderColor = System.Drawing.SystemColors.Window;
            this.ugdStavke.DisplayLayout.GroupByBox.Appearance = appearance38;
            appearance39.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugdStavke.DisplayLayout.GroupByBox.BandLabelAppearance = appearance39;
            this.ugdStavke.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance40.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance40.BackColor2 = System.Drawing.SystemColors.Control;
            appearance40.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance40.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugdStavke.DisplayLayout.GroupByBox.PromptAppearance = appearance40;
            this.ugdStavke.DisplayLayout.MaxColScrollRegions = 1;
            this.ugdStavke.DisplayLayout.MaxRowScrollRegions = 1;
            appearance41.BackColor = System.Drawing.SystemColors.Window;
            appearance41.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ugdStavke.DisplayLayout.Override.ActiveCellAppearance = appearance41;
            appearance42.BackColor = System.Drawing.SystemColors.Highlight;
            appearance42.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ugdStavke.DisplayLayout.Override.ActiveRowAppearance = appearance42;
            this.ugdStavke.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ugdStavke.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance43.BackColor = System.Drawing.SystemColors.Window;
            this.ugdStavke.DisplayLayout.Override.CardAreaAppearance = appearance43;
            appearance44.BorderColor = System.Drawing.Color.Silver;
            appearance44.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ugdStavke.DisplayLayout.Override.CellAppearance = appearance44;
            this.ugdStavke.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ugdStavke.DisplayLayout.Override.CellPadding = 0;
            appearance45.BackColor = System.Drawing.SystemColors.Control;
            appearance45.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance45.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance45.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance45.BorderColor = System.Drawing.SystemColors.Window;
            this.ugdStavke.DisplayLayout.Override.GroupByRowAppearance = appearance45;
            appearance46.TextHAlignAsString = "Left";
            this.ugdStavke.DisplayLayout.Override.HeaderAppearance = appearance46;
            this.ugdStavke.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ugdStavke.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance47.BackColor = System.Drawing.SystemColors.Window;
            appearance47.BorderColor = System.Drawing.Color.Silver;
            this.ugdStavke.DisplayLayout.Override.RowAppearance = appearance47;
            this.ugdStavke.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance48.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ugdStavke.DisplayLayout.Override.TemplateAddRowAppearance = appearance48;
            this.ugdStavke.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ugdStavke.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ugdStavke.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ugdStavke.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ugdStavke.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ugdStavke.Location = new System.Drawing.Point(2, 15);
            this.ugdStavke.Name = "ugdStavke";
            this.ugdStavke.Size = new System.Drawing.Size(650, 315);
            this.ugdStavke.TabIndex = 4;
            this.ugdStavke.Text = "ultraGrid1";
            // 
            // btnUrediStavku
            // 
            this.btnUrediStavku.Enabled = false;
            this.btnUrediStavku.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUrediStavku.Location = new System.Drawing.Point(88, 188);
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
            this.btnBrisiStavku.Location = new System.Drawing.Point(190, 188);
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
            this.btnNovaStavka.Location = new System.Drawing.Point(8, 188);
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
            this.gbxMaticni.Controls.Add(this.utePoziv);
            this.gbxMaticni.Controls.Add(this.label2);
            this.gbxMaticni.Controls.Add(this.uteModel);
            this.gbxMaticni.Controls.Add(this.label1);
            this.gbxMaticni.Controls.Add(this.udtValuta);
            this.gbxMaticni.Controls.Add(this.ucePartner);
            this.gbxMaticni.Controls.Add(this.udtDatum);
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
            this.gbxMaticni.Size = new System.Drawing.Size(676, 134);
            this.gbxMaticni.TabIndex = 77;
            this.gbxMaticni.TabStop = false;
            this.gbxMaticni.Text = "Osnovni podaci";
            // 
            // utePoziv
            // 
            this.utePoziv.Location = new System.Drawing.Point(414, 98);
            this.utePoziv.MaxLength = 22;
            this.utePoziv.Name = "utePoziv";
            this.utePoziv.Size = new System.Drawing.Size(240, 21);
            this.utePoziv.TabIndex = 92;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(327, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 91;
            this.label2.Text = "Poziv na broj:";
            // 
            // uteModel
            // 
            this.uteModel.Location = new System.Drawing.Point(65, 98);
            this.uteModel.MaxLength = 2;
            this.uteModel.Name = "uteModel";
            this.uteModel.Size = new System.Drawing.Size(68, 21);
            this.uteModel.TabIndex = 90;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(5, 102);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 89;
            this.label1.Text = "Model:";
            // 
            // udtValuta
            // 
            this.udtValuta.Location = new System.Drawing.Point(65, 71);
            this.udtValuta.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.udtValuta.Name = "udtValuta";
            this.udtValuta.Size = new System.Drawing.Size(255, 21);
            this.udtValuta.TabIndex = 88;
            this.udtValuta.Value = null;
            // 
            // ucePartner
            // 
            this.ucePartner.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.ucePartner.DisplayMember = "Naziv";
            this.ucePartner.Location = new System.Drawing.Point(65, 44);
            this.ucePartner.MaxDropDownItems = 20;
            this.ucePartner.Name = "ucePartner";
            this.ucePartner.Size = new System.Drawing.Size(255, 21);
            this.ucePartner.TabIndex = 87;
            this.ucePartner.ValueMember = "ID";
            // 
            // udtDatum
            // 
            this.udtDatum.Location = new System.Drawing.Point(414, 19);
            this.udtDatum.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.udtDatum.Name = "udtDatum";
            this.udtDatum.Size = new System.Drawing.Size(240, 21);
            this.udtDatum.TabIndex = 11;
            this.udtDatum.Value = null;
            // 
            // uteNapomena
            // 
            this.uteNapomena.Location = new System.Drawing.Point(414, 46);
            this.uteNapomena.MaxLength = 200;
            this.uteNapomena.Multiline = true;
            this.uteNapomena.Name = "uteNapomena";
            this.uteNapomena.Size = new System.Drawing.Size(240, 46);
            this.uteNapomena.TabIndex = 14;
            // 
            // uteSifra
            // 
            this.uteSifra.Location = new System.Drawing.Point(65, 19);
            this.uteSifra.MaxLength = 50;
            this.uteSifra.Name = "uteSifra";
            this.uteSifra.ReadOnly = true;
            this.uteSifra.Size = new System.Drawing.Size(255, 21);
            this.uteSifra.TabIndex = 10;
            // 
            // lblName5
            // 
            this.lblName5.AutoSize = true;
            this.lblName5.Location = new System.Drawing.Point(327, 50);
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
            this.lblName4.Size = new System.Drawing.Size(47, 13);
            this.lblName4.TabIndex = 6;
            this.lblName4.Text = "Valuta:";
            // 
            // lblName3
            // 
            this.lblName3.AutoSize = true;
            this.lblName3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblName3.Location = new System.Drawing.Point(5, 50);
            this.lblName3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName3.Name = "lblName3";
            this.lblName3.Size = new System.Drawing.Size(52, 13);
            this.lblName3.TabIndex = 4;
            this.lblName3.Text = "Partner:";
            // 
            // lblName2
            // 
            this.lblName2.AutoSize = true;
            this.lblName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblName2.Location = new System.Drawing.Point(327, 23);
            this.lblName2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName2.Name = "lblName2";
            this.lblName2.Size = new System.Drawing.Size(47, 13);
            this.lblName2.TabIndex = 2;
            this.lblName2.Text = "Datum:";
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
            // RacunForm
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
            this.Name = "RacunForm";
            this.Size = new System.Drawing.Size(717, 594);
            this.Load += new System.EventHandler(this.FormLoad);
            this.tspForm.ResumeLayout(false);
            this.tspForm.PerformLayout();
            this.gbxStavke.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugdStavke)).EndInit();
            this.gbxMaticni.ResumeLayout(false);
            this.gbxMaticni.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.utePoziv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtValuta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucePartner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtDatum)).EndInit();
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
        private Infragistics.Win.UltraWinGrid.UltraGrid ugdStavke;
        private System.Windows.Forms.Button btnUrediStavku;
        private System.Windows.Forms.Button btnBrisiStavku;
        private System.Windows.Forms.Button btnNovaStavka;
        private System.Windows.Forms.GroupBox gbxMaticni;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtDatum;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteNapomena;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteSifra;
        private System.Windows.Forms.Label lblName5;
        private System.Windows.Forms.Label lblName4;
        private System.Windows.Forms.Label lblName3;
        private System.Windows.Forms.Label lblName2;
        private System.Windows.Forms.Label lblName1;
        private System.Windows.Forms.Label lblValidationMessages;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ucePartner;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtValuta;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor utePoziv;
        private System.Windows.Forms.Label label2;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteModel;
        private System.Windows.Forms.Label label1;


    }
}

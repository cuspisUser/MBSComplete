namespace FinPosModule
{
    partial class OdobrenjeFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OdobrenjeFrm));
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
            this.gbxOsnovni = new System.Windows.Forms.GroupBox();
            this.uteNapomena = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ucePartner = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.uteSifra = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.uceGodina = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.udtDatumIzdavanja = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.lblName6 = new System.Windows.Forms.Label();
            this.lblName5 = new System.Windows.Forms.Label();
            this.lblName2 = new System.Windows.Forms.Label();
            this.lblName1 = new System.Windows.Forms.Label();
            this.tspForm = new System.Windows.Forms.ToolStrip();
            this.tsbSpremiZatvori = new System.Windows.Forms.ToolStripButton();
            this.tsbSpremiNovi = new System.Windows.Forms.ToolStripButton();
            this.tsbOdustani = new System.Windows.Forms.ToolStripButton();
            this.gbxStavke = new System.Windows.Forms.GroupBox();
            this.ugdOdobrenjeStavke = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.btnUrediStavku = new System.Windows.Forms.Button();
            this.btnBrisiStavku = new System.Windows.Forms.Button();
            this.btnNovaStavka = new System.Windows.Forms.Button();
            this.lblValidationMessages = new System.Windows.Forms.Label();
            this.gbxOsnovni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uteNapomena)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucePartner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteSifra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceGodina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtDatumIzdavanja)).BeginInit();
            this.tspForm.SuspendLayout();
            this.gbxStavke.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugdOdobrenjeStavke)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxOsnovni
            // 
            this.gbxOsnovni.Controls.Add(this.uteNapomena);
            this.gbxOsnovni.Controls.Add(this.ucePartner);
            this.gbxOsnovni.Controls.Add(this.uteSifra);
            this.gbxOsnovni.Controls.Add(this.label1);
            this.gbxOsnovni.Controls.Add(this.uceGodina);
            this.gbxOsnovni.Controls.Add(this.udtDatumIzdavanja);
            this.gbxOsnovni.Controls.Add(this.lblName6);
            this.gbxOsnovni.Controls.Add(this.lblName5);
            this.gbxOsnovni.Controls.Add(this.lblName2);
            this.gbxOsnovni.Controls.Add(this.lblName1);
            this.gbxOsnovni.Location = new System.Drawing.Point(5, 48);
            this.gbxOsnovni.Margin = new System.Windows.Forms.Padding(2);
            this.gbxOsnovni.Name = "gbxOsnovni";
            this.gbxOsnovni.Padding = new System.Windows.Forms.Padding(2);
            this.gbxOsnovni.Size = new System.Drawing.Size(672, 114);
            this.gbxOsnovni.TabIndex = 29;
            this.gbxOsnovni.TabStop = false;
            this.gbxOsnovni.Text = "Odobrenje";
            // 
            // uteNapomena
            // 
            this.uteNapomena.Location = new System.Drawing.Point(411, 47);
            this.uteNapomena.MaxLength = 50;
            this.uteNapomena.Multiline = true;
            this.uteNapomena.Name = "uteNapomena";
            this.uteNapomena.Size = new System.Drawing.Size(238, 48);
            this.uteNapomena.TabIndex = 86;
            // 
            // ucePartner
            // 
            this.ucePartner.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.ucePartner.DisplayMember = "Naziv";
            this.ucePartner.Location = new System.Drawing.Point(58, 74);
            this.ucePartner.MaxDropDownItems = 20;
            this.ucePartner.Name = "ucePartner";
            this.ucePartner.Size = new System.Drawing.Size(244, 21);
            this.ucePartner.TabIndex = 85;
            this.ucePartner.ValueMember = "ID";
            // 
            // uteSifra
            // 
            this.uteSifra.Location = new System.Drawing.Point(58, 20);
            this.uteSifra.MaxLength = 50;
            this.uteSifra.Name = "uteSifra";
            this.uteSifra.Size = new System.Drawing.Size(125, 21);
            this.uteSifra.TabIndex = 84;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 83;
            this.label1.Text = "Godina:";
            // 
            // uceGodina
            // 
            this.uceGodina.DisplayMember = "Naziv";
            this.uceGodina.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.uceGodina.Location = new System.Drawing.Point(58, 47);
            this.uceGodina.MaxDropDownItems = 20;
            this.uceGodina.Name = "uceGodina";
            this.uceGodina.Size = new System.Drawing.Size(125, 21);
            this.uceGodina.TabIndex = 73;
            this.uceGodina.ValueMember = "ID";
            // 
            // udtDatumIzdavanja
            // 
            this.udtDatumIzdavanja.Location = new System.Drawing.Point(411, 20);
            this.udtDatumIzdavanja.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.udtDatumIzdavanja.Name = "udtDatumIzdavanja";
            this.udtDatumIzdavanja.Size = new System.Drawing.Size(238, 21);
            this.udtDatumIzdavanja.TabIndex = 70;
            this.udtDatumIzdavanja.Value = null;
            // 
            // lblName6
            // 
            this.lblName6.AutoSize = true;
            this.lblName6.Location = new System.Drawing.Point(344, 51);
            this.lblName6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName6.Name = "lblName6";
            this.lblName6.Size = new System.Drawing.Size(62, 13);
            this.lblName6.TabIndex = 11;
            this.lblName6.Text = "Napomena:";
            // 
            // lblName5
            // 
            this.lblName5.AutoSize = true;
            this.lblName5.Location = new System.Drawing.Point(317, 24);
            this.lblName5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName5.Name = "lblName5";
            this.lblName5.Size = new System.Drawing.Size(89, 13);
            this.lblName5.TabIndex = 6;
            this.lblName5.Text = "Datum izdavanja:";
            // 
            // lblName2
            // 
            this.lblName2.AutoSize = true;
            this.lblName2.Location = new System.Drawing.Point(4, 78);
            this.lblName2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName2.Name = "lblName2";
            this.lblName2.Size = new System.Drawing.Size(44, 13);
            this.lblName2.TabIndex = 2;
            this.lblName2.Text = "Partner:";
            // 
            // lblName1
            // 
            this.lblName1.AutoSize = true;
            this.lblName1.Location = new System.Drawing.Point(17, 24);
            this.lblName1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName1.Name = "lblName1";
            this.lblName1.Size = new System.Drawing.Size(31, 13);
            this.lblName1.TabIndex = 0;
            this.lblName1.Text = "Šifra:";
            // 
            // tspForm
            // 
            this.tspForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSpremiZatvori,
            this.tsbSpremiNovi,
            this.tsbOdustani});
            this.tspForm.Location = new System.Drawing.Point(0, 0);
            this.tspForm.Name = "tspForm";
            this.tspForm.Size = new System.Drawing.Size(697, 25);
            this.tspForm.TabIndex = 28;
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
            // tsbSpremiNovi
            // 
            this.tsbSpremiNovi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSpremiNovi.Image = ((System.Drawing.Image)(resources.GetObject("tsbSpremiNovi.Image")));
            this.tsbSpremiNovi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSpremiNovi.Name = "tsbSpremiNovi";
            this.tsbSpremiNovi.Size = new System.Drawing.Size(80, 22);
            this.tsbSpremiNovi.Text = "Spremi i novi";
            this.tsbSpremiNovi.Click += new System.EventHandler(this.tsbSpremiNovi_Click);
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
            this.gbxStavke.Controls.Add(this.ugdOdobrenjeStavke);
            this.gbxStavke.Location = new System.Drawing.Point(8, 195);
            this.gbxStavke.Margin = new System.Windows.Forms.Padding(2);
            this.gbxStavke.Name = "gbxStavke";
            this.gbxStavke.Padding = new System.Windows.Forms.Padding(2);
            this.gbxStavke.Size = new System.Drawing.Size(671, 303);
            this.gbxStavke.TabIndex = 73;
            this.gbxStavke.TabStop = false;
            this.gbxStavke.Text = "Odobrenje stavke";
            // 
            // ugdOdobrenjeStavke
            // 
            appearance37.BackColor = System.Drawing.SystemColors.Window;
            appearance37.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ugdOdobrenjeStavke.DisplayLayout.Appearance = appearance37;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1});
            this.ugdOdobrenjeStavke.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ugdOdobrenjeStavke.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugdOdobrenjeStavke.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance38.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance38.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance38.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance38.BorderColor = System.Drawing.SystemColors.Window;
            this.ugdOdobrenjeStavke.DisplayLayout.GroupByBox.Appearance = appearance38;
            appearance39.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugdOdobrenjeStavke.DisplayLayout.GroupByBox.BandLabelAppearance = appearance39;
            this.ugdOdobrenjeStavke.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance40.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance40.BackColor2 = System.Drawing.SystemColors.Control;
            appearance40.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance40.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugdOdobrenjeStavke.DisplayLayout.GroupByBox.PromptAppearance = appearance40;
            this.ugdOdobrenjeStavke.DisplayLayout.MaxColScrollRegions = 1;
            this.ugdOdobrenjeStavke.DisplayLayout.MaxRowScrollRegions = 1;
            appearance41.BackColor = System.Drawing.SystemColors.Window;
            appearance41.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ugdOdobrenjeStavke.DisplayLayout.Override.ActiveCellAppearance = appearance41;
            appearance42.BackColor = System.Drawing.SystemColors.Highlight;
            appearance42.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ugdOdobrenjeStavke.DisplayLayout.Override.ActiveRowAppearance = appearance42;
            this.ugdOdobrenjeStavke.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ugdOdobrenjeStavke.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance43.BackColor = System.Drawing.SystemColors.Window;
            this.ugdOdobrenjeStavke.DisplayLayout.Override.CardAreaAppearance = appearance43;
            appearance44.BorderColor = System.Drawing.Color.Silver;
            appearance44.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ugdOdobrenjeStavke.DisplayLayout.Override.CellAppearance = appearance44;
            this.ugdOdobrenjeStavke.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ugdOdobrenjeStavke.DisplayLayout.Override.CellPadding = 0;
            appearance45.BackColor = System.Drawing.SystemColors.Control;
            appearance45.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance45.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance45.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance45.BorderColor = System.Drawing.SystemColors.Window;
            this.ugdOdobrenjeStavke.DisplayLayout.Override.GroupByRowAppearance = appearance45;
            appearance46.TextHAlignAsString = "Left";
            this.ugdOdobrenjeStavke.DisplayLayout.Override.HeaderAppearance = appearance46;
            this.ugdOdobrenjeStavke.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ugdOdobrenjeStavke.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance47.BackColor = System.Drawing.SystemColors.Window;
            appearance47.BorderColor = System.Drawing.Color.Silver;
            this.ugdOdobrenjeStavke.DisplayLayout.Override.RowAppearance = appearance47;
            this.ugdOdobrenjeStavke.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance48.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ugdOdobrenjeStavke.DisplayLayout.Override.TemplateAddRowAppearance = appearance48;
            this.ugdOdobrenjeStavke.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ugdOdobrenjeStavke.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ugdOdobrenjeStavke.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ugdOdobrenjeStavke.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ugdOdobrenjeStavke.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ugdOdobrenjeStavke.Location = new System.Drawing.Point(2, 15);
            this.ugdOdobrenjeStavke.Name = "ugdOdobrenjeStavke";
            this.ugdOdobrenjeStavke.Size = new System.Drawing.Size(667, 286);
            this.ugdOdobrenjeStavke.TabIndex = 4;
            this.ugdOdobrenjeStavke.Text = "ultraGrid1";
            // 
            // btnUrediStavku
            // 
            this.btnUrediStavku.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUrediStavku.Location = new System.Drawing.Point(90, 166);
            this.btnUrediStavku.Margin = new System.Windows.Forms.Padding(2);
            this.btnUrediStavku.Name = "btnUrediStavku";
            this.btnUrediStavku.Size = new System.Drawing.Size(98, 24);
            this.btnUrediStavku.TabIndex = 75;
            this.btnUrediStavku.Text = "Uredi stavku";
            this.btnUrediStavku.UseVisualStyleBackColor = true;
            this.btnUrediStavku.Click += new System.EventHandler(this.btnUrediStavku_Click);
            // 
            // btnBrisiStavku
            // 
            this.btnBrisiStavku.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBrisiStavku.Location = new System.Drawing.Point(192, 166);
            this.btnBrisiStavku.Margin = new System.Windows.Forms.Padding(2);
            this.btnBrisiStavku.Name = "btnBrisiStavku";
            this.btnBrisiStavku.Size = new System.Drawing.Size(136, 24);
            this.btnBrisiStavku.TabIndex = 76;
            this.btnBrisiStavku.Text = "Briši označene stavke";
            this.btnBrisiStavku.UseVisualStyleBackColor = true;
            this.btnBrisiStavku.Click += new System.EventHandler(this.btnBrisiStavku_Click);
            // 
            // btnNovaStavka
            // 
            this.btnNovaStavka.Location = new System.Drawing.Point(8, 166);
            this.btnNovaStavka.Margin = new System.Windows.Forms.Padding(2);
            this.btnNovaStavka.Name = "btnNovaStavka";
            this.btnNovaStavka.Size = new System.Drawing.Size(78, 24);
            this.btnNovaStavka.TabIndex = 74;
            this.btnNovaStavka.Text = "Nova stavka";
            this.btnNovaStavka.UseVisualStyleBackColor = true;
            this.btnNovaStavka.Click += new System.EventHandler(this.btnNovaStavka_Click);
            // 
            // lblValidationMessages
            // 
            this.lblValidationMessages.AutoSize = true;
            this.lblValidationMessages.ForeColor = System.Drawing.Color.Red;
            this.lblValidationMessages.Location = new System.Drawing.Point(9, 26);
            this.lblValidationMessages.Name = "lblValidationMessages";
            this.lblValidationMessages.Padding = new System.Windows.Forms.Padding(0, 2, 0, 5);
            this.lblValidationMessages.Size = new System.Drawing.Size(0, 20);
            this.lblValidationMessages.TabIndex = 77;
            // 
            // OdobrenjeFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblValidationMessages);
            this.Controls.Add(this.btnUrediStavku);
            this.Controls.Add(this.btnBrisiStavku);
            this.Controls.Add(this.btnNovaStavka);
            this.Controls.Add(this.gbxStavke);
            this.Controls.Add(this.gbxOsnovni);
            this.Controls.Add(this.tspForm);
            this.Name = "OdobrenjeFrm";
            this.Size = new System.Drawing.Size(697, 521);
            this.Load += new System.EventHandler(this.FormLoad);
            this.gbxOsnovni.ResumeLayout(false);
            this.gbxOsnovni.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uteNapomena)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucePartner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteSifra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceGodina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtDatumIzdavanja)).EndInit();
            this.tspForm.ResumeLayout(false);
            this.tspForm.PerformLayout();
            this.gbxStavke.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugdOdobrenjeStavke)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxOsnovni;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteSifra;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceGodina;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtDatumIzdavanja;
        private System.Windows.Forms.Label lblName5;
        private System.Windows.Forms.Label lblName2;
        private System.Windows.Forms.Label lblName1;
        private System.Windows.Forms.ToolStrip tspForm;
        private System.Windows.Forms.ToolStripButton tsbSpremiZatvori;
        private System.Windows.Forms.ToolStripButton tsbOdustani;
        private System.Windows.Forms.GroupBox gbxStavke;
        private Infragistics.Win.UltraWinGrid.UltraGrid ugdOdobrenjeStavke;
        private System.Windows.Forms.Button btnUrediStavku;
        private System.Windows.Forms.Button btnBrisiStavku;
        private System.Windows.Forms.Button btnNovaStavka;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteNapomena;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ucePartner;
        private System.Windows.Forms.Label lblName6;
        private System.Windows.Forms.Label lblValidationMessages;
        private System.Windows.Forms.ToolStripButton tsbSpremiNovi;
    }
}

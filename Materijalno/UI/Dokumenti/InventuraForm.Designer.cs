namespace Materijalno.UI.Dokumenti
{
    partial class InventuraForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventuraForm));
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
            this.gbxMaticni = new System.Windows.Forms.GroupBox();
            this.uceSkladiste = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.udtDatumInventure = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.lblName2 = new System.Windows.Forms.Label();
            this.lblName1 = new System.Windows.Forms.Label();
            this.lblValidationMessages = new System.Windows.Forms.Label();
            this.tspForm = new System.Windows.Forms.ToolStrip();
            this.tsbSpremiZatvori = new System.Windows.Forms.ToolStripButton();
            this.tsbOdustaniZatvori = new System.Windows.Forms.ToolStripButton();
            this.gbxStavke = new System.Windows.Forms.GroupBox();
            this.ugdInventuraStavke = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.btnUrediStavku = new System.Windows.Forms.Button();
            this.btnBrisiStavku = new System.Windows.Forms.Button();
            this.btnNovaStavka = new System.Windows.Forms.Button();
            this.gbxMaticni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceSkladiste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtDatumInventure)).BeginInit();
            this.tspForm.SuspendLayout();
            this.gbxStavke.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugdInventuraStavke)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxMaticni
            // 
            this.gbxMaticni.Controls.Add(this.uceSkladiste);
            this.gbxMaticni.Controls.Add(this.udtDatumInventure);
            this.gbxMaticni.Controls.Add(this.lblName2);
            this.gbxMaticni.Controls.Add(this.lblName1);
            this.gbxMaticni.Location = new System.Drawing.Point(6, 60);
            this.gbxMaticni.Margin = new System.Windows.Forms.Padding(2);
            this.gbxMaticni.Name = "gbxMaticni";
            this.gbxMaticni.Padding = new System.Windows.Forms.Padding(2);
            this.gbxMaticni.Size = new System.Drawing.Size(678, 52);
            this.gbxMaticni.TabIndex = 84;
            this.gbxMaticni.TabStop = false;
            this.gbxMaticni.Text = "Osnovni podaci";
            // 
            // uceSkladiste
            // 
            this.uceSkladiste.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.uceSkladiste.DisplayMember = "Naziv";
            this.uceSkladiste.Location = new System.Drawing.Point(73, 19);
            this.uceSkladiste.MaxDropDownItems = 20;
            this.uceSkladiste.Name = "uceSkladiste";
            this.uceSkladiste.Size = new System.Drawing.Size(224, 21);
            this.uceSkladiste.TabIndex = 91;
            this.uceSkladiste.ValueMember = "ID";
            // 
            // udtDatumInventure
            // 
            this.udtDatumInventure.Location = new System.Drawing.Point(428, 19);
            this.udtDatumInventure.MaskInput = "{date}";
            this.udtDatumInventure.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.udtDatumInventure.Name = "udtDatumInventure";
            this.udtDatumInventure.Size = new System.Drawing.Size(224, 21);
            this.udtDatumInventure.TabIndex = 13;
            this.udtDatumInventure.Value = null;
            // 
            // lblName2
            // 
            this.lblName2.AutoSize = true;
            this.lblName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblName2.Location = new System.Drawing.Point(310, 23);
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
            this.lblName1.Size = new System.Drawing.Size(63, 13);
            this.lblName1.TabIndex = 0;
            this.lblName1.Text = "Skladište:";
            // 
            // lblValidationMessages
            // 
            this.lblValidationMessages.AutoSize = true;
            this.lblValidationMessages.ForeColor = System.Drawing.Color.Red;
            this.lblValidationMessages.Location = new System.Drawing.Point(11, 29);
            this.lblValidationMessages.Name = "lblValidationMessages";
            this.lblValidationMessages.Padding = new System.Windows.Forms.Padding(0, 2, 0, 5);
            this.lblValidationMessages.Size = new System.Drawing.Size(0, 20);
            this.lblValidationMessages.TabIndex = 83;
            // 
            // tspForm
            // 
            this.tspForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSpremiZatvori,
            this.tsbOdustaniZatvori});
            this.tspForm.Location = new System.Drawing.Point(0, 0);
            this.tspForm.Name = "tspForm";
            this.tspForm.Size = new System.Drawing.Size(692, 25);
            this.tspForm.TabIndex = 79;
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
            // tsbOdustaniZatvori
            // 
            this.tsbOdustaniZatvori.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbOdustaniZatvori.Image = ((System.Drawing.Image)(resources.GetObject("tsbOdustaniZatvori.Image")));
            this.tsbOdustaniZatvori.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOdustaniZatvori.Name = "tsbOdustaniZatvori";
            this.tsbOdustaniZatvori.Size = new System.Drawing.Size(103, 22);
            this.tsbOdustaniZatvori.Text = "Odustani i zatvori";
            this.tsbOdustaniZatvori.Click += new System.EventHandler(this.tsbOdustani_Click);
            // 
            // gbxStavke
            // 
            this.gbxStavke.Controls.Add(this.ugdInventuraStavke);
            this.gbxStavke.Location = new System.Drawing.Point(6, 149);
            this.gbxStavke.Margin = new System.Windows.Forms.Padding(2);
            this.gbxStavke.Name = "gbxStavke";
            this.gbxStavke.Padding = new System.Windows.Forms.Padding(2);
            this.gbxStavke.Size = new System.Drawing.Size(678, 321);
            this.gbxStavke.TabIndex = 90;
            this.gbxStavke.TabStop = false;
            this.gbxStavke.Text = "Stavke izdatnice";
            // 
            // ugdInventuraStavke
            // 
            appearance37.BackColor = System.Drawing.SystemColors.Window;
            appearance37.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ugdInventuraStavke.DisplayLayout.Appearance = appearance37;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1});
            this.ugdInventuraStavke.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ugdInventuraStavke.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugdInventuraStavke.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance38.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance38.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance38.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance38.BorderColor = System.Drawing.SystemColors.Window;
            this.ugdInventuraStavke.DisplayLayout.GroupByBox.Appearance = appearance38;
            appearance39.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugdInventuraStavke.DisplayLayout.GroupByBox.BandLabelAppearance = appearance39;
            this.ugdInventuraStavke.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance40.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance40.BackColor2 = System.Drawing.SystemColors.Control;
            appearance40.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance40.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugdInventuraStavke.DisplayLayout.GroupByBox.PromptAppearance = appearance40;
            this.ugdInventuraStavke.DisplayLayout.MaxColScrollRegions = 1;
            this.ugdInventuraStavke.DisplayLayout.MaxRowScrollRegions = 1;
            appearance41.BackColor = System.Drawing.SystemColors.Window;
            appearance41.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ugdInventuraStavke.DisplayLayout.Override.ActiveCellAppearance = appearance41;
            appearance42.BackColor = System.Drawing.SystemColors.Highlight;
            appearance42.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ugdInventuraStavke.DisplayLayout.Override.ActiveRowAppearance = appearance42;
            this.ugdInventuraStavke.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ugdInventuraStavke.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance43.BackColor = System.Drawing.SystemColors.Window;
            this.ugdInventuraStavke.DisplayLayout.Override.CardAreaAppearance = appearance43;
            appearance44.BorderColor = System.Drawing.Color.Silver;
            appearance44.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ugdInventuraStavke.DisplayLayout.Override.CellAppearance = appearance44;
            this.ugdInventuraStavke.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ugdInventuraStavke.DisplayLayout.Override.CellPadding = 0;
            appearance45.BackColor = System.Drawing.SystemColors.Control;
            appearance45.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance45.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance45.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance45.BorderColor = System.Drawing.SystemColors.Window;
            this.ugdInventuraStavke.DisplayLayout.Override.GroupByRowAppearance = appearance45;
            appearance46.TextHAlignAsString = "Left";
            this.ugdInventuraStavke.DisplayLayout.Override.HeaderAppearance = appearance46;
            this.ugdInventuraStavke.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ugdInventuraStavke.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance47.BackColor = System.Drawing.SystemColors.Window;
            appearance47.BorderColor = System.Drawing.Color.Silver;
            this.ugdInventuraStavke.DisplayLayout.Override.RowAppearance = appearance47;
            this.ugdInventuraStavke.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance48.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ugdInventuraStavke.DisplayLayout.Override.TemplateAddRowAppearance = appearance48;
            this.ugdInventuraStavke.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ugdInventuraStavke.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ugdInventuraStavke.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ugdInventuraStavke.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ugdInventuraStavke.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ugdInventuraStavke.Location = new System.Drawing.Point(2, 15);
            this.ugdInventuraStavke.Name = "ugdInventuraStavke";
            this.ugdInventuraStavke.Size = new System.Drawing.Size(674, 304);
            this.ugdInventuraStavke.TabIndex = 4;
            this.ugdInventuraStavke.Text = "ultraGrid1";
            // 
            // btnUrediStavku
            // 
            this.btnUrediStavku.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUrediStavku.Location = new System.Drawing.Point(88, 118);
            this.btnUrediStavku.Margin = new System.Windows.Forms.Padding(2);
            this.btnUrediStavku.Name = "btnUrediStavku";
            this.btnUrediStavku.Size = new System.Drawing.Size(98, 24);
            this.btnUrediStavku.TabIndex = 88;
            this.btnUrediStavku.Text = "Uredi stavku";
            this.btnUrediStavku.UseVisualStyleBackColor = true;
            this.btnUrediStavku.Click += new System.EventHandler(this.btnUrediStavku_Click);
            // 
            // btnBrisiStavku
            // 
            this.btnBrisiStavku.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBrisiStavku.Location = new System.Drawing.Point(190, 118);
            this.btnBrisiStavku.Margin = new System.Windows.Forms.Padding(2);
            this.btnBrisiStavku.Name = "btnBrisiStavku";
            this.btnBrisiStavku.Size = new System.Drawing.Size(136, 24);
            this.btnBrisiStavku.TabIndex = 89;
            this.btnBrisiStavku.Text = "Briši označene stavke";
            this.btnBrisiStavku.UseVisualStyleBackColor = true;
            this.btnBrisiStavku.Click += new System.EventHandler(this.btnBrisiStavku_Click_1);
            // 
            // btnNovaStavka
            // 
            this.btnNovaStavka.Location = new System.Drawing.Point(6, 118);
            this.btnNovaStavka.Margin = new System.Windows.Forms.Padding(2);
            this.btnNovaStavka.Name = "btnNovaStavka";
            this.btnNovaStavka.Size = new System.Drawing.Size(78, 24);
            this.btnNovaStavka.TabIndex = 87;
            this.btnNovaStavka.Text = "Nova stavka";
            this.btnNovaStavka.UseVisualStyleBackColor = true;
            this.btnNovaStavka.Click += new System.EventHandler(this.btnNovaStavka_Click);
            // 
            // InventuraForm
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
            this.Name = "InventuraForm";
            this.Size = new System.Drawing.Size(692, 531);
            this.Load += new System.EventHandler(this.FormLoad);
            this.gbxMaticni.ResumeLayout(false);
            this.gbxMaticni.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceSkladiste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtDatumInventure)).EndInit();
            this.tspForm.ResumeLayout(false);
            this.tspForm.PerformLayout();
            this.gbxStavke.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugdInventuraStavke)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxMaticni;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtDatumInventure;
        private System.Windows.Forms.Label lblName2;
        private System.Windows.Forms.Label lblName1;
        private System.Windows.Forms.Label lblValidationMessages;
        private System.Windows.Forms.ToolStrip tspForm;
        private System.Windows.Forms.ToolStripButton tsbSpremiZatvori;
        private System.Windows.Forms.ToolStripButton tsbOdustaniZatvori;
        private System.Windows.Forms.GroupBox gbxStavke;
        private Infragistics.Win.UltraWinGrid.UltraGrid ugdInventuraStavke;
        private System.Windows.Forms.Button btnUrediStavku;
        private System.Windows.Forms.Button btnBrisiStavku;
        private System.Windows.Forms.Button btnNovaStavka;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceSkladiste;

    }
}

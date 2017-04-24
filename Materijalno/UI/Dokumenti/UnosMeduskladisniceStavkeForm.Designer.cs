namespace Materijalno.UI.Dokumenti
{
    partial class UnosMeduskladisniceStavkeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnosMeduskladisniceStavkeForm));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            this.tspForm = new System.Windows.Forms.ToolStrip();
            this.tsbSpremiZatvori = new System.Windows.Forms.ToolStripButton();
            this.tsbOdustani = new System.Windows.Forms.ToolStripButton();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.lblValidationMessages = new System.Windows.Forms.Label();
            this.lblName1 = new System.Windows.Forms.Label();
            this.btnUrediStavku = new System.Windows.Forms.Button();
            this.btnNovaStavka = new System.Windows.Forms.Button();
            this.lblName4 = new System.Windows.Forms.Label();
            this.btnBrisiStavku = new System.Windows.Forms.Button();
            this.lblName3 = new System.Windows.Forms.Label();
            this.ucbUlaznoSkladiste = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.uteBrojDokumenta = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.udtDatum = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.ucbIzlaznoSkladiste = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblName2 = new System.Windows.Forms.Label();
            this.ugdMeduskladisnicaStavke = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.tspForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucbUlaznoSkladiste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteBrojDokumenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucbIzlaznoSkladiste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugdMeduskladisnicaStavke)).BeginInit();
            this.SuspendLayout();
            // 
            // tspForm
            // 
            this.tspForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSpremiZatvori,
            this.tsbOdustani});
            this.tspForm.Location = new System.Drawing.Point(0, 0);
            this.tspForm.Name = "tspForm";
            this.tspForm.Size = new System.Drawing.Size(672, 25);
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
            // spcMain
            // 
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.IsSplitterFixed = true;
            this.spcMain.Location = new System.Drawing.Point(0, 25);
            this.spcMain.Name = "spcMain";
            this.spcMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.lblValidationMessages);
            this.spcMain.Panel1.Controls.Add(this.lblName1);
            this.spcMain.Panel1.Controls.Add(this.btnUrediStavku);
            this.spcMain.Panel1.Controls.Add(this.btnNovaStavka);
            this.spcMain.Panel1.Controls.Add(this.lblName4);
            this.spcMain.Panel1.Controls.Add(this.btnBrisiStavku);
            this.spcMain.Panel1.Controls.Add(this.lblName3);
            this.spcMain.Panel1.Controls.Add(this.ucbUlaznoSkladiste);
            this.spcMain.Panel1.Controls.Add(this.uteBrojDokumenta);
            this.spcMain.Panel1.Controls.Add(this.udtDatum);
            this.spcMain.Panel1.Controls.Add(this.ucbIzlaznoSkladiste);
            this.spcMain.Panel1.Controls.Add(this.lblName2);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.ugdMeduskladisnicaStavke);
            this.spcMain.Size = new System.Drawing.Size(672, 501);
            this.spcMain.SplitterDistance = 107;
            this.spcMain.TabIndex = 22;
            // 
            // lblValidationMessages
            // 
            this.lblValidationMessages.AutoSize = true;
            this.lblValidationMessages.ForeColor = System.Drawing.Color.Red;
            this.lblValidationMessages.Location = new System.Drawing.Point(3, 3);
            this.lblValidationMessages.Name = "lblValidationMessages";
            this.lblValidationMessages.Padding = new System.Windows.Forms.Padding(0, 2, 0, 5);
            this.lblValidationMessages.Size = new System.Drawing.Size(0, 20);
            this.lblValidationMessages.TabIndex = 18;
            // 
            // lblName1
            // 
            this.lblName1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName1.AutoSize = true;
            this.lblName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblName1.Location = new System.Drawing.Point(10, 31);
            this.lblName1.Name = "lblName1";
            this.lblName1.Size = new System.Drawing.Size(101, 13);
            this.lblName1.TabIndex = 19;
            this.lblName1.Text = "Broj Dokumenta:";
            // 
            // btnUrediStavku
            // 
            this.btnUrediStavku.Enabled = false;
            this.btnUrediStavku.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUrediStavku.Location = new System.Drawing.Point(120, 79);
            this.btnUrediStavku.Margin = new System.Windows.Forms.Padding(2);
            this.btnUrediStavku.Name = "btnUrediStavku";
            this.btnUrediStavku.Size = new System.Drawing.Size(98, 22);
            this.btnUrediStavku.TabIndex = 76;
            this.btnUrediStavku.Text = "Uredi stavku";
            this.btnUrediStavku.UseVisualStyleBackColor = true;
            this.btnUrediStavku.Click += new System.EventHandler(this.btnUrediStavku_Click);
            // 
            // btnNovaStavka
            // 
            this.btnNovaStavka.Location = new System.Drawing.Point(13, 79);
            this.btnNovaStavka.Margin = new System.Windows.Forms.Padding(2);
            this.btnNovaStavka.Name = "btnNovaStavka";
            this.btnNovaStavka.Size = new System.Drawing.Size(78, 22);
            this.btnNovaStavka.TabIndex = 75;
            this.btnNovaStavka.Text = "Nova stavka";
            this.btnNovaStavka.UseVisualStyleBackColor = true;
            this.btnNovaStavka.Click += new System.EventHandler(this.btnNovaStavka_Click);
            // 
            // lblName4
            // 
            this.lblName4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName4.AutoSize = true;
            this.lblName4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblName4.Location = new System.Drawing.Point(343, 59);
            this.lblName4.Name = "lblName4";
            this.lblName4.Size = new System.Drawing.Size(104, 13);
            this.lblName4.TabIndex = 71;
            this.lblName4.Text = "Ulazno skladište:";
            // 
            // btnBrisiStavku
            // 
            this.btnBrisiStavku.Enabled = false;
            this.btnBrisiStavku.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBrisiStavku.Location = new System.Drawing.Point(242, 79);
            this.btnBrisiStavku.Margin = new System.Windows.Forms.Padding(2);
            this.btnBrisiStavku.Name = "btnBrisiStavku";
            this.btnBrisiStavku.Size = new System.Drawing.Size(136, 22);
            this.btnBrisiStavku.TabIndex = 77;
            this.btnBrisiStavku.Text = "Briši označene stavke";
            this.btnBrisiStavku.UseVisualStyleBackColor = true;
            this.btnBrisiStavku.Click += new System.EventHandler(this.btnBrisiStavku_Click);
            // 
            // lblName3
            // 
            this.lblName3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName3.AutoSize = true;
            this.lblName3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblName3.Location = new System.Drawing.Point(10, 59);
            this.lblName3.Name = "lblName3";
            this.lblName3.Size = new System.Drawing.Size(105, 13);
            this.lblName3.TabIndex = 74;
            this.lblName3.Text = "Izlazno skladište:";
            // 
            // ucbUlaznoSkladiste
            // 
            this.ucbUlaznoSkladiste.DisplayMember = "Naziv";
            this.ucbUlaznoSkladiste.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ucbUlaznoSkladiste.Location = new System.Drawing.Point(452, 53);
            this.ucbUlaznoSkladiste.MaxDropDownItems = 20;
            this.ucbUlaznoSkladiste.Name = "ucbUlaznoSkladiste";
            this.ucbUlaznoSkladiste.Size = new System.Drawing.Size(200, 21);
            this.ucbUlaznoSkladiste.TabIndex = 74;
            this.ucbUlaznoSkladiste.ValueMember = "ID";
            // 
            // uteBrojDokumenta
            // 
            this.uteBrojDokumenta.Location = new System.Drawing.Point(120, 29);
            this.uteBrojDokumenta.MaxLength = 50;
            this.uteBrojDokumenta.Name = "uteBrojDokumenta";
            this.uteBrojDokumenta.ReadOnly = true;
            this.uteBrojDokumenta.Size = new System.Drawing.Size(200, 21);
            this.uteBrojDokumenta.TabIndex = 20;
            // 
            // udtDatum
            // 
            this.udtDatum.Location = new System.Drawing.Point(452, 29);
            this.udtDatum.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.udtDatum.Name = "udtDatum";
            this.udtDatum.Size = new System.Drawing.Size(200, 21);
            this.udtDatum.TabIndex = 73;
            this.udtDatum.Value = null;
            // 
            // ucbIzlaznoSkladiste
            // 
            this.ucbIzlaznoSkladiste.DisplayMember = "Naziv";
            this.ucbIzlaznoSkladiste.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ucbIzlaznoSkladiste.Location = new System.Drawing.Point(120, 53);
            this.ucbIzlaznoSkladiste.MaxDropDownItems = 20;
            this.ucbIzlaznoSkladiste.Name = "ucbIzlaznoSkladiste";
            this.ucbIzlaznoSkladiste.Size = new System.Drawing.Size(200, 21);
            this.ucbIzlaznoSkladiste.TabIndex = 72;
            this.ucbIzlaznoSkladiste.ValueMember = "ID";
            // 
            // lblName2
            // 
            this.lblName2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName2.AutoSize = true;
            this.lblName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblName2.Location = new System.Drawing.Point(343, 29);
            this.lblName2.Name = "lblName2";
            this.lblName2.Size = new System.Drawing.Size(47, 13);
            this.lblName2.TabIndex = 21;
            this.lblName2.Text = "Datum:";
            // 
            // ugdMeduskladisnicaStavke
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ugdMeduskladisnicaStavke.DisplayLayout.Appearance = appearance1;
            this.ugdMeduskladisnicaStavke.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugdMeduskladisnicaStavke.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.ugdMeduskladisnicaStavke.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugdMeduskladisnicaStavke.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.ugdMeduskladisnicaStavke.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugdMeduskladisnicaStavke.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.ugdMeduskladisnicaStavke.DisplayLayout.MaxColScrollRegions = 1;
            this.ugdMeduskladisnicaStavke.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ugdMeduskladisnicaStavke.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ugdMeduskladisnicaStavke.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.ugdMeduskladisnicaStavke.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ugdMeduskladisnicaStavke.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.ugdMeduskladisnicaStavke.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ugdMeduskladisnicaStavke.DisplayLayout.Override.CellAppearance = appearance8;
            this.ugdMeduskladisnicaStavke.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ugdMeduskladisnicaStavke.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.ugdMeduskladisnicaStavke.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.ugdMeduskladisnicaStavke.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.ugdMeduskladisnicaStavke.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ugdMeduskladisnicaStavke.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.ugdMeduskladisnicaStavke.DisplayLayout.Override.RowAppearance = appearance11;
            this.ugdMeduskladisnicaStavke.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ugdMeduskladisnicaStavke.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.ugdMeduskladisnicaStavke.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ugdMeduskladisnicaStavke.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ugdMeduskladisnicaStavke.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ugdMeduskladisnicaStavke.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ugdMeduskladisnicaStavke.Location = new System.Drawing.Point(0, 0);
            this.ugdMeduskladisnicaStavke.Name = "ugdMeduskladisnicaStavke";
            this.ugdMeduskladisnicaStavke.Size = new System.Drawing.Size(672, 390);
            this.ugdMeduskladisnicaStavke.TabIndex = 72;
            this.ugdMeduskladisnicaStavke.Text = "ultraGrid1";
            // 
            // UnosMeduskladisniceStavkeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spcMain);
            this.Controls.Add(this.tspForm);
            this.Name = "UnosMeduskladisniceStavkeForm";
            this.Size = new System.Drawing.Size(672, 526);
            this.Load += new System.EventHandler(this.Form_Load);
            this.tspForm.ResumeLayout(false);
            this.tspForm.PerformLayout();
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel1.PerformLayout();
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ucbUlaznoSkladiste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteBrojDokumenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucbIzlaznoSkladiste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugdMeduskladisnicaStavke)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tspForm;
        private System.Windows.Forms.ToolStripButton tsbSpremiZatvori;
        private System.Windows.Forms.ToolStripButton tsbOdustani;
        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.Label lblValidationMessages;
        private System.Windows.Forms.Label lblName1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteBrojDokumenta;
        private System.Windows.Forms.Label lblName2;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtDatum;
        private System.Windows.Forms.Label lblName3;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ucbIzlaznoSkladiste;
        private System.Windows.Forms.Label lblName4;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ucbUlaznoSkladiste;
        private System.Windows.Forms.Button btnNovaStavka;
        private Infragistics.Win.UltraWinGrid.UltraGrid ugdMeduskladisnicaStavke;
        private System.Windows.Forms.Button btnUrediStavku;
        private System.Windows.Forms.Button btnBrisiStavku;


    }
}

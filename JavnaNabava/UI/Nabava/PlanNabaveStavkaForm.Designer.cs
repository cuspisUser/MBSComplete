namespace JavnaNabava.UI.Nabava
{
    partial class PlanNabaveStavkaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlanNabaveStavkaForm));
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
            this.tspNarudzbenica = new System.Windows.Forms.ToolStrip();
            this.tsbNarudzbenicaSpremiNovi = new System.Windows.Forms.ToolStripButton();
            this.tsbNarudzbenicaSpremiZatvori = new System.Windows.Forms.ToolStripButton();
            this.tsbNarudzbenicaOdustani = new System.Windows.Forms.ToolStripButton();
            this.lblValidationMessages = new System.Windows.Forms.Label();
            this.ucbKonto = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblKonto = new System.Windows.Forms.Label();
            this.ucbPoreznaStopa = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.lblPoreznaStopa = new System.Windows.Forms.Label();
            this.lblBezPDVa = new System.Windows.Forms.Label();
            this.lblSaPDVom = new System.Windows.Forms.Label();
            this.uneBezPDVa = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.uneSaPDVom = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.lblVrstaNabave = new System.Windows.Forms.Label();
            this.ucbVrstaNabave = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblOpis = new System.Windows.Forms.Label();
            this.txtOpisStavke = new System.Windows.Forms.TextBox();
            this.tspNarudzbenica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucbKonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucbPoreznaStopa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneBezPDVa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneSaPDVom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucbVrstaNabave)).BeginInit();
            this.SuspendLayout();
            // 
            // tspNarudzbenica
            // 
            this.tspNarudzbenica.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNarudzbenicaSpremiNovi,
            this.tsbNarudzbenicaSpremiZatvori,
            this.tsbNarudzbenicaOdustani});
            this.tspNarudzbenica.Location = new System.Drawing.Point(0, 0);
            this.tspNarudzbenica.Name = "tspNarudzbenica";
            this.tspNarudzbenica.Size = new System.Drawing.Size(573, 25);
            this.tspNarudzbenica.TabIndex = 20;
            this.tspNarudzbenica.Text = "toolStrip1";
            // 
            // tsbNarudzbenicaSpremiNovi
            // 
            this.tsbNarudzbenicaSpremiNovi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbNarudzbenicaSpremiNovi.Image = ((System.Drawing.Image)(resources.GetObject("tsbNarudzbenicaSpremiNovi.Image")));
            this.tsbNarudzbenicaSpremiNovi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNarudzbenicaSpremiNovi.Name = "tsbNarudzbenicaSpremiNovi";
            this.tsbNarudzbenicaSpremiNovi.Size = new System.Drawing.Size(80, 22);
            this.tsbNarudzbenicaSpremiNovi.Text = "Spremi i novi";
            this.tsbNarudzbenicaSpremiNovi.Click += new System.EventHandler(this.tsbNarudzbenicaSpremiNovi_Click);
            // 
            // tsbNarudzbenicaSpremiZatvori
            // 
            this.tsbNarudzbenicaSpremiZatvori.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbNarudzbenicaSpremiZatvori.Image = ((System.Drawing.Image)(resources.GetObject("tsbNarudzbenicaSpremiZatvori.Image")));
            this.tsbNarudzbenicaSpremiZatvori.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNarudzbenicaSpremiZatvori.Name = "tsbNarudzbenicaSpremiZatvori";
            this.tsbNarudzbenicaSpremiZatvori.Size = new System.Drawing.Size(92, 22);
            this.tsbNarudzbenicaSpremiZatvori.Text = "Spremi i zatvori";
            this.tsbNarudzbenicaSpremiZatvori.Click += new System.EventHandler(this.tsbNarudzbenicaSpremiZatvori_Click);
            // 
            // tsbNarudzbenicaOdustani
            // 
            this.tsbNarudzbenicaOdustani.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbNarudzbenicaOdustani.Image = ((System.Drawing.Image)(resources.GetObject("tsbNarudzbenicaOdustani.Image")));
            this.tsbNarudzbenicaOdustani.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNarudzbenicaOdustani.Name = "tsbNarudzbenicaOdustani";
            this.tsbNarudzbenicaOdustani.Size = new System.Drawing.Size(103, 22);
            this.tsbNarudzbenicaOdustani.Text = "Odustani i zatvori";
            this.tsbNarudzbenicaOdustani.Click += new System.EventHandler(this.tsbNarudzbenicaOdustani_Click);
            // 
            // lblValidationMessages
            // 
            this.lblValidationMessages.AutoSize = true;
            this.lblValidationMessages.ForeColor = System.Drawing.Color.Red;
            this.lblValidationMessages.Location = new System.Drawing.Point(3, 25);
            this.lblValidationMessages.Name = "lblValidationMessages";
            this.lblValidationMessages.Padding = new System.Windows.Forms.Padding(0, 2, 0, 5);
            this.lblValidationMessages.Size = new System.Drawing.Size(0, 20);
            this.lblValidationMessages.TabIndex = 21;
            // 
            // ucbKonto
            // 
            this.ucbKonto.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.ucbKonto.DisplayMember = "Naziv";
            this.ucbKonto.Location = new System.Drawing.Point(116, 50);
            this.ucbKonto.MaxDropDownItems = 20;
            this.ucbKonto.Name = "ucbKonto";
            this.ucbKonto.Size = new System.Drawing.Size(415, 21);
            this.ucbKonto.TabIndex = 58;
            this.ucbKonto.ValueMember = "ID";
            // 
            // lblKonto
            // 
            this.lblKonto.AutoSize = true;
            this.lblKonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKonto.Location = new System.Drawing.Point(3, 58);
            this.lblKonto.Name = "lblKonto";
            this.lblKonto.Size = new System.Drawing.Size(44, 13);
            this.lblKonto.TabIndex = 57;
            this.lblKonto.Text = "Konto:";
            // 
            // ucbPoreznaStopa
            // 
            this.ucbPoreznaStopa.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ucbPoreznaStopa.DisplayLayout.Appearance = appearance1;
            this.ucbPoreznaStopa.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.ucbPoreznaStopa.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.ucbPoreznaStopa.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.ucbPoreznaStopa.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ucbPoreznaStopa.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.ucbPoreznaStopa.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance3.BackColor2 = System.Drawing.SystemColors.Control;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ucbPoreznaStopa.DisplayLayout.GroupByBox.PromptAppearance = appearance3;
            this.ucbPoreznaStopa.DisplayLayout.MaxColScrollRegions = 1;
            this.ucbPoreznaStopa.DisplayLayout.MaxRowScrollRegions = 1;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            appearance9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ucbPoreznaStopa.DisplayLayout.Override.ActiveCellAppearance = appearance9;
            appearance5.BackColor = System.Drawing.SystemColors.Highlight;
            appearance5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ucbPoreznaStopa.DisplayLayout.Override.ActiveRowAppearance = appearance5;
            this.ucbPoreznaStopa.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ucbPoreznaStopa.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            this.ucbPoreznaStopa.DisplayLayout.Override.CardAreaAppearance = appearance12;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ucbPoreznaStopa.DisplayLayout.Override.CellAppearance = appearance8;
            this.ucbPoreznaStopa.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ucbPoreznaStopa.DisplayLayout.Override.CellPadding = 0;
            appearance6.BackColor = System.Drawing.SystemColors.Control;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.ucbPoreznaStopa.DisplayLayout.Override.GroupByRowAppearance = appearance6;
            appearance7.TextHAlignAsString = "Left";
            this.ucbPoreznaStopa.DisplayLayout.Override.HeaderAppearance = appearance7;
            this.ucbPoreznaStopa.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ucbPoreznaStopa.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance10.BackColor = System.Drawing.SystemColors.Window;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            this.ucbPoreznaStopa.DisplayLayout.Override.RowAppearance = appearance10;
            this.ucbPoreznaStopa.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ucbPoreznaStopa.DisplayLayout.Override.TemplateAddRowAppearance = appearance11;
            this.ucbPoreznaStopa.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ucbPoreznaStopa.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ucbPoreznaStopa.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ucbPoreznaStopa.DisplayMember = "Naziv";
            this.ucbPoreznaStopa.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.ucbPoreznaStopa.Location = new System.Drawing.Point(116, 80);
            this.ucbPoreznaStopa.Name = "ucbPoreznaStopa";
            this.ucbPoreznaStopa.Size = new System.Drawing.Size(415, 22);
            this.ucbPoreznaStopa.TabIndex = 79;
            this.ucbPoreznaStopa.ValueMember = "ID";
            this.ucbPoreznaStopa.ValueChanged += new System.EventHandler(this.ucbPoreznaStopa_ValueChanged);
            // 
            // lblPoreznaStopa
            // 
            this.lblPoreznaStopa.AutoSize = true;
            this.lblPoreznaStopa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPoreznaStopa.Location = new System.Drawing.Point(3, 89);
            this.lblPoreznaStopa.Name = "lblPoreznaStopa";
            this.lblPoreznaStopa.Size = new System.Drawing.Size(92, 13);
            this.lblPoreznaStopa.TabIndex = 74;
            this.lblPoreznaStopa.Text = "Porezna stopa:";
            // 
            // lblBezPDVa
            // 
            this.lblBezPDVa.AutoSize = true;
            this.lblBezPDVa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblBezPDVa.Location = new System.Drawing.Point(3, 118);
            this.lblBezPDVa.Name = "lblBezPDVa";
            this.lblBezPDVa.Size = new System.Drawing.Size(105, 13);
            this.lblBezPDVa.TabIndex = 75;
            this.lblBezPDVa.Text = "Iznos bez PDV-a:";
            // 
            // lblSaPDVom
            // 
            this.lblSaPDVom.AutoSize = true;
            this.lblSaPDVom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSaPDVom.Location = new System.Drawing.Point(3, 147);
            this.lblSaPDVom.Name = "lblSaPDVom";
            this.lblSaPDVom.Size = new System.Drawing.Size(107, 13);
            this.lblSaPDVom.TabIndex = 76;
            this.lblSaPDVom.Text = "Iznos sa PDV-om:";
            // 
            // uneBezPDVa
            // 
            this.uneBezPDVa.Location = new System.Drawing.Point(116, 110);
            this.uneBezPDVa.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.uneBezPDVa.MaximumSize = new System.Drawing.Size(9999, 0);
            this.uneBezPDVa.MaxValue = 9999999999D;
            this.uneBezPDVa.MinValue = 0D;
            this.uneBezPDVa.Name = "uneBezPDVa";
            this.uneBezPDVa.Nullable = true;
            this.uneBezPDVa.NullText = " ";
            this.uneBezPDVa.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.uneBezPDVa.PromptChar = ' ';
            this.uneBezPDVa.Size = new System.Drawing.Size(415, 21);
            this.uneBezPDVa.TabIndex = 77;
            this.uneBezPDVa.ValueChanged += new System.EventHandler(this.uneBezPDVa_ValueChanged);
            // 
            // uneSaPDVom
            // 
            this.uneSaPDVom.Location = new System.Drawing.Point(116, 139);
            this.uneSaPDVom.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.uneSaPDVom.MaximumSize = new System.Drawing.Size(9999, 0);
            this.uneSaPDVom.MaxValue = 9999999999D;
            this.uneSaPDVom.MinValue = 0D;
            this.uneSaPDVom.Name = "uneSaPDVom";
            this.uneSaPDVom.Nullable = true;
            this.uneSaPDVom.NullText = " ";
            this.uneSaPDVom.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.uneSaPDVom.PromptChar = ' ';
            this.uneSaPDVom.ReadOnly = true;
            this.uneSaPDVom.Size = new System.Drawing.Size(415, 21);
            this.uneSaPDVom.TabIndex = 78;
            // 
            // lblVrstaNabave
            // 
            this.lblVrstaNabave.AutoSize = true;
            this.lblVrstaNabave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblVrstaNabave.Location = new System.Drawing.Point(3, 177);
            this.lblVrstaNabave.Name = "lblVrstaNabave";
            this.lblVrstaNabave.Size = new System.Drawing.Size(86, 13);
            this.lblVrstaNabave.TabIndex = 80;
            this.lblVrstaNabave.Text = "Vrsta nabave:";
            // 
            // ucbVrstaNabave
            // 
            this.ucbVrstaNabave.DisplayMember = "Naziv";
            this.ucbVrstaNabave.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ucbVrstaNabave.Location = new System.Drawing.Point(116, 169);
            this.ucbVrstaNabave.MaxDropDownItems = 20;
            this.ucbVrstaNabave.Name = "ucbVrstaNabave";
            this.ucbVrstaNabave.Size = new System.Drawing.Size(415, 21);
            this.ucbVrstaNabave.TabIndex = 81;
            this.ucbVrstaNabave.ValueMember = "ID";
            // 
            // lblOpis
            // 
            this.lblOpis.AutoSize = true;
            this.lblOpis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblOpis.Location = new System.Drawing.Point(3, 204);
            this.lblOpis.Name = "lblOpis";
            this.lblOpis.Size = new System.Drawing.Size(66, 13);
            this.lblOpis.TabIndex = 82;
            this.lblOpis.Text = "Opis stavke:";
            // 
            // txtOpisStavke
            // 
            this.txtOpisStavke.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOpisStavke.Location = new System.Drawing.Point(116, 201);
            this.txtOpisStavke.MaxLength = 1000;
            this.txtOpisStavke.Multiline = true;
            this.txtOpisStavke.Name = "txtOpisStavke";
            this.txtOpisStavke.Size = new System.Drawing.Size(415, 70);
            this.txtOpisStavke.TabIndex = 83;
            // 
            // PlanNabaveStavkaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtOpisStavke);
            this.Controls.Add(this.lblOpis);
            this.Controls.Add(this.lblVrstaNabave);
            this.Controls.Add(this.ucbVrstaNabave);
            this.Controls.Add(this.ucbPoreznaStopa);
            this.Controls.Add(this.lblPoreznaStopa);
            this.Controls.Add(this.lblBezPDVa);
            this.Controls.Add(this.lblSaPDVom);
            this.Controls.Add(this.uneBezPDVa);
            this.Controls.Add(this.uneSaPDVom);
            this.Controls.Add(this.lblKonto);
            this.Controls.Add(this.ucbKonto);
            this.Controls.Add(this.lblValidationMessages);
            this.Controls.Add(this.tspNarudzbenica);
            this.Name = "PlanNabaveStavkaForm";
            this.Size = new System.Drawing.Size(573, 328);
            this.Load += new System.EventHandler(this.PlanNabaveStavkaForm_Load);
            this.tspNarudzbenica.ResumeLayout(false);
            this.tspNarudzbenica.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucbKonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucbPoreznaStopa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneBezPDVa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneSaPDVom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucbVrstaNabave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tspNarudzbenica;
        private System.Windows.Forms.ToolStripButton tsbNarudzbenicaSpremiNovi;
        private System.Windows.Forms.ToolStripButton tsbNarudzbenicaSpremiZatvori;
        private System.Windows.Forms.ToolStripButton tsbNarudzbenicaOdustani;
        private System.Windows.Forms.Label lblValidationMessages;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ucbKonto;
        private System.Windows.Forms.Label lblKonto;
        private Infragistics.Win.UltraWinGrid.UltraCombo ucbPoreznaStopa;
        private System.Windows.Forms.Label lblPoreznaStopa;
        private System.Windows.Forms.Label lblBezPDVa;
        private System.Windows.Forms.Label lblSaPDVom;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneBezPDVa;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneSaPDVom;
        private System.Windows.Forms.Label lblVrstaNabave;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ucbVrstaNabave;
        private System.Windows.Forms.Label lblOpis;
        private System.Windows.Forms.TextBox txtOpisStavke;


    }
}

namespace UcenickoFakturiranje.UI.MaticniPodaci
{
    partial class SkolskaGodinaFormPregled
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Naziv", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DatumPocetka", 1);
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DatumZavrsetka", 2);
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Aktivnost", 3);
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID", 4);
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            this.UltraGridSkolskeGodine = new Infragistics.Win.UltraWinGrid.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGridSkolskeGodine)).BeginInit();
            this.SuspendLayout();
            // 
            // ugrSkolskeGodine
            // 
            appearance4.BackColor = System.Drawing.SystemColors.Window;
            appearance4.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.UltraGridSkolskeGodine.DisplayLayout.Appearance = appearance4;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.VisiblePosition = 1;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance5.TextHAlignAsString = "Right";
            ultraGridColumn2.CellAppearance = appearance5;
            ultraGridColumn2.DataType = typeof(System.DateTime);
            ultraGridColumn2.Format = "dd.MM.yyyy.";
            ultraGridColumn2.Header.Caption = "Datum početka";
            ultraGridColumn2.Header.VisiblePosition = 2;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance6.TextHAlignAsString = "Right";
            ultraGridColumn3.CellAppearance = appearance6;
            ultraGridColumn3.DataType = typeof(System.DateTime);
            ultraGridColumn3.Format = "dd.MM.yyyy.";
            ultraGridColumn3.Header.Caption = "Datum završetka";
            ultraGridColumn3.Header.VisiblePosition = 3;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance7.TextHAlignAsString = "Center";
            ultraGridColumn4.CellAppearance = appearance7;
            ultraGridColumn4.DataType = typeof(bool);
            ultraGridColumn4.Header.VisiblePosition = 4;
            ultraGridColumn5.DataType = typeof(int);
            ultraGridColumn5.Header.VisiblePosition = 0;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5});
            this.UltraGridSkolskeGodine.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.UltraGridSkolskeGodine.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.UltraGridSkolskeGodine.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance8.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance8.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance8.BorderColor = System.Drawing.SystemColors.Window;
            this.UltraGridSkolskeGodine.DisplayLayout.GroupByBox.Appearance = appearance8;
            appearance9.ForeColor = System.Drawing.SystemColors.GrayText;
            this.UltraGridSkolskeGodine.DisplayLayout.GroupByBox.BandLabelAppearance = appearance9;
            this.UltraGridSkolskeGodine.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance10.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance10.BackColor2 = System.Drawing.SystemColors.Control;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance10.ForeColor = System.Drawing.SystemColors.GrayText;
            this.UltraGridSkolskeGodine.DisplayLayout.GroupByBox.PromptAppearance = appearance10;
            this.UltraGridSkolskeGodine.DisplayLayout.MaxColScrollRegions = 1;
            this.UltraGridSkolskeGodine.DisplayLayout.MaxRowScrollRegions = 1;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.UltraGridSkolskeGodine.DisplayLayout.Override.ActiveCellAppearance = appearance11;
            appearance12.BackColor = System.Drawing.SystemColors.Highlight;
            appearance12.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.UltraGridSkolskeGodine.DisplayLayout.Override.ActiveRowAppearance = appearance12;
            this.UltraGridSkolskeGodine.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.UltraGridSkolskeGodine.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance25.BackColor = System.Drawing.SystemColors.Window;
            this.UltraGridSkolskeGodine.DisplayLayout.Override.CardAreaAppearance = appearance25;
            appearance26.BorderColor = System.Drawing.Color.Silver;
            appearance26.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.UltraGridSkolskeGodine.DisplayLayout.Override.CellAppearance = appearance26;
            this.UltraGridSkolskeGodine.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.UltraGridSkolskeGodine.DisplayLayout.Override.CellPadding = 0;
            appearance27.BackColor = System.Drawing.SystemColors.Control;
            appearance27.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance27.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance27.BorderColor = System.Drawing.SystemColors.Window;
            this.UltraGridSkolskeGodine.DisplayLayout.Override.GroupByRowAppearance = appearance27;
            appearance28.TextHAlignAsString = "Left";
            this.UltraGridSkolskeGodine.DisplayLayout.Override.HeaderAppearance = appearance28;
            this.UltraGridSkolskeGodine.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.UltraGridSkolskeGodine.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance29.BackColor = System.Drawing.SystemColors.Window;
            appearance29.BorderColor = System.Drawing.Color.Silver;
            this.UltraGridSkolskeGodine.DisplayLayout.Override.RowAppearance = appearance29;
            this.UltraGridSkolskeGodine.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance30.BackColor = System.Drawing.SystemColors.ControlLight;
            this.UltraGridSkolskeGodine.DisplayLayout.Override.TemplateAddRowAppearance = appearance30;
            this.UltraGridSkolskeGodine.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.UltraGridSkolskeGodine.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.UltraGridSkolskeGodine.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.UltraGridSkolskeGodine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraGridSkolskeGodine.Location = new System.Drawing.Point(0, 0);
            this.UltraGridSkolskeGodine.Name = "ugrSkolskeGodine";
            this.UltraGridSkolskeGodine.Size = new System.Drawing.Size(1080, 741);
            this.UltraGridSkolskeGodine.TabIndex = 0;
            this.UltraGridSkolskeGodine.Text = "ultraGrid1";
            this.UltraGridSkolskeGodine.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.UltraGridSkolskeGodine_DoubleClickRow);
            // 
            // SkolskaGodinaFormPregled
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UltraGridSkolskeGodine);
            this.Name = "SkolskaGodinaFormPregled";
            this.Size = new System.Drawing.Size(1080, 741);
            this.Load += new System.EventHandler(this.SkolskaGodinaFormPregled_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGridSkolskeGodine)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid UltraGridSkolskeGodine;
    }
}

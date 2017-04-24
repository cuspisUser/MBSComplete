namespace UcenickoFakturiranje.UI.MaticniPodaci
{
    partial class RazredFormPregled
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
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Naziv", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID", 1);
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            this.UltraGridRazredi = new Infragistics.Win.UltraWinGrid.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGridRazredi)).BeginInit();
            this.SuspendLayout();
            // 
            // UltraGridRazredi
            // 
            appearance25.BackColor = System.Drawing.SystemColors.Window;
            appearance25.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.UltraGridRazredi.DisplayLayout.Appearance = appearance25;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.VisiblePosition = 1;
            ultraGridColumn2.DataType = typeof(int);
            ultraGridColumn2.Header.VisiblePosition = 0;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2});
            this.UltraGridRazredi.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.UltraGridRazredi.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.UltraGridRazredi.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance26.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance26.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance26.BorderColor = System.Drawing.SystemColors.Window;
            this.UltraGridRazredi.DisplayLayout.GroupByBox.Appearance = appearance26;
            appearance27.ForeColor = System.Drawing.SystemColors.GrayText;
            this.UltraGridRazredi.DisplayLayout.GroupByBox.BandLabelAppearance = appearance27;
            this.UltraGridRazredi.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance28.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance28.BackColor2 = System.Drawing.SystemColors.Control;
            appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance28.ForeColor = System.Drawing.SystemColors.GrayText;
            this.UltraGridRazredi.DisplayLayout.GroupByBox.PromptAppearance = appearance28;
            this.UltraGridRazredi.DisplayLayout.MaxColScrollRegions = 1;
            this.UltraGridRazredi.DisplayLayout.MaxRowScrollRegions = 1;
            appearance29.BackColor = System.Drawing.SystemColors.Window;
            appearance29.ForeColor = System.Drawing.SystemColors.ControlText;
            this.UltraGridRazredi.DisplayLayout.Override.ActiveCellAppearance = appearance29;
            appearance30.BackColor = System.Drawing.SystemColors.Highlight;
            appearance30.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.UltraGridRazredi.DisplayLayout.Override.ActiveRowAppearance = appearance30;
            this.UltraGridRazredi.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.UltraGridRazredi.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance31.BackColor = System.Drawing.SystemColors.Window;
            this.UltraGridRazredi.DisplayLayout.Override.CardAreaAppearance = appearance31;
            appearance32.BorderColor = System.Drawing.Color.Silver;
            appearance32.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.UltraGridRazredi.DisplayLayout.Override.CellAppearance = appearance32;
            this.UltraGridRazredi.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.UltraGridRazredi.DisplayLayout.Override.CellPadding = 0;
            appearance33.BackColor = System.Drawing.SystemColors.Control;
            appearance33.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance33.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance33.BorderColor = System.Drawing.SystemColors.Window;
            this.UltraGridRazredi.DisplayLayout.Override.GroupByRowAppearance = appearance33;
            appearance34.TextHAlignAsString = "Left";
            this.UltraGridRazredi.DisplayLayout.Override.HeaderAppearance = appearance34;
            this.UltraGridRazredi.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.UltraGridRazredi.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance35.BackColor = System.Drawing.SystemColors.Window;
            appearance35.BorderColor = System.Drawing.Color.Silver;
            this.UltraGridRazredi.DisplayLayout.Override.RowAppearance = appearance35;
            this.UltraGridRazredi.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance36.BackColor = System.Drawing.SystemColors.ControlLight;
            this.UltraGridRazredi.DisplayLayout.Override.TemplateAddRowAppearance = appearance36;
            this.UltraGridRazredi.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.UltraGridRazredi.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.UltraGridRazredi.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.UltraGridRazredi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraGridRazredi.Location = new System.Drawing.Point(0, 0);
            this.UltraGridRazredi.Name = "UltraGridRazredi";
            this.UltraGridRazredi.Size = new System.Drawing.Size(1191, 706);
            this.UltraGridRazredi.TabIndex = 0;
            this.UltraGridRazredi.Text = "ultraGrid1";
            this.UltraGridRazredi.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.UltraGridRazredi_DoubleClickRow);
            // 
            // RazredFormPregled
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UltraGridRazredi);
            this.Name = "RazredFormPregled";
            this.Size = new System.Drawing.Size(1191, 706);
            this.Load += new System.EventHandler(this.RazredFormPregled_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGridRazredi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid UltraGridRazredi;
    }
}

namespace UcenickoFakturiranje.UI.SkolskeGodineRazrednaOdjeljenja
{
    partial class UstanovaSkolskaGodinaRazrednoOdjeljenjeFormPregled
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
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UstanovaSkolskaGodina", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RazredOdjeljenje", 1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Voditelj", 2);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BrojUcenika", 3);
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja = new Infragistics.Win.UltraWinGrid.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja)).BeginInit();
            this.SuspendLayout();
            // 
            // UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja
            // 
            appearance13.BackColor = System.Drawing.SystemColors.Window;
            appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.DisplayLayout.Appearance = appearance13;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.Header.Caption = "Ustanova / školska godina";
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn3.Header.Caption = "Razredno odjeljenje";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn4.Header.VisiblePosition = 3;
            appearance1.TextHAlignAsString = "Center";
            ultraGridColumn5.CellAppearance = appearance1;
            ultraGridColumn5.DataType = typeof(int);
            ultraGridColumn5.Header.Caption = "Broj učenika";
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5});
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance14.BorderColor = System.Drawing.SystemColors.Window;
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.DisplayLayout.GroupByBox.Appearance = appearance14;
            appearance15.ForeColor = System.Drawing.SystemColors.GrayText;
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.DisplayLayout.GroupByBox.BandLabelAppearance = appearance15;
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance16.BackColor2 = System.Drawing.SystemColors.Control;
            appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance16.ForeColor = System.Drawing.SystemColors.GrayText;
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.DisplayLayout.GroupByBox.PromptAppearance = appearance16;
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.DisplayLayout.MaxColScrollRegions = 1;
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.DisplayLayout.MaxRowScrollRegions = 1;
            appearance17.BackColor = System.Drawing.SystemColors.Window;
            appearance17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.DisplayLayout.Override.ActiveCellAppearance = appearance17;
            appearance18.BackColor = System.Drawing.SystemColors.Highlight;
            appearance18.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.DisplayLayout.Override.ActiveRowAppearance = appearance18;
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance19.BackColor = System.Drawing.SystemColors.Window;
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.DisplayLayout.Override.CardAreaAppearance = appearance19;
            appearance20.BorderColor = System.Drawing.Color.Silver;
            appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.DisplayLayout.Override.CellAppearance = appearance20;
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.DisplayLayout.Override.CellPadding = 0;
            appearance21.BackColor = System.Drawing.SystemColors.Control;
            appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance21.BorderColor = System.Drawing.SystemColors.Window;
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.DisplayLayout.Override.GroupByRowAppearance = appearance21;
            appearance22.TextHAlignAsString = "Left";
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.DisplayLayout.Override.HeaderAppearance = appearance22;
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance23.BackColor = System.Drawing.SystemColors.Window;
            appearance23.BorderColor = System.Drawing.Color.Silver;
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.DisplayLayout.Override.RowAppearance = appearance23;
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance24.BackColor = System.Drawing.SystemColors.ControlLight;
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.DisplayLayout.Override.TemplateAddRowAppearance = appearance24;
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.Location = new System.Drawing.Point(0, 0);
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.Name = "UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja";
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.Size = new System.Drawing.Size(1085, 598);
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.TabIndex = 0;
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.Text = "ultraGrid1";
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja_DoubleClickRow);
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.Enter += new System.EventHandler(this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja_Enter);
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.MouseHover += new System.EventHandler(this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja_MouseHover);
            // 
            // UstanovaSkolskaGodinaRazrednoOdjeljenjeFormPregled
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja);
            this.Name = "UstanovaSkolskaGodinaRazrednoOdjeljenjeFormPregled";
            this.Size = new System.Drawing.Size(1085, 598);
            this.Load += new System.EventHandler(this.UstanovaSkolskaGodinaRazrednoOdjeljenjeFormPregled_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Infragistics.Win.UltraWinGrid.UltraGrid UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja;

    }
}

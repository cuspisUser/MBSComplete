namespace UcenickoFakturiranje.UI.ProizvodiCjeniciOlaksice
{
    partial class OlaksiceFormPregled
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("UF_Olaksica", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Naziv");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OlaksicaPostotak");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OlaksicaIznos");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UF_CjenikStavka");
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
            this.UltraOlaksice = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.uFOlaksicaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.UltraOlaksice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uFOlaksicaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // UltraOlaksice
            // 
            this.UltraOlaksice.DataSource = this.uFOlaksicaBindingSource;
            appearance37.BackColor = System.Drawing.SystemColors.Window;
            appearance37.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.UltraOlaksice.DisplayLayout.Appearance = appearance37;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Width = 43;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Width = 541;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.Header.Caption = "Postotak olakšice";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Width = 139;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.Header.Caption = "Iznos olakšice";
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Width = 90;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6});
            this.UltraOlaksice.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.UltraOlaksice.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.UltraOlaksice.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance38.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance38.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance38.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance38.BorderColor = System.Drawing.SystemColors.Window;
            this.UltraOlaksice.DisplayLayout.GroupByBox.Appearance = appearance38;
            appearance39.ForeColor = System.Drawing.SystemColors.GrayText;
            this.UltraOlaksice.DisplayLayout.GroupByBox.BandLabelAppearance = appearance39;
            this.UltraOlaksice.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance40.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance40.BackColor2 = System.Drawing.SystemColors.Control;
            appearance40.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance40.ForeColor = System.Drawing.SystemColors.GrayText;
            this.UltraOlaksice.DisplayLayout.GroupByBox.PromptAppearance = appearance40;
            this.UltraOlaksice.DisplayLayout.MaxColScrollRegions = 1;
            this.UltraOlaksice.DisplayLayout.MaxRowScrollRegions = 1;
            appearance41.BackColor = System.Drawing.SystemColors.Window;
            appearance41.ForeColor = System.Drawing.SystemColors.ControlText;
            this.UltraOlaksice.DisplayLayout.Override.ActiveCellAppearance = appearance41;
            appearance42.BackColor = System.Drawing.SystemColors.Highlight;
            appearance42.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.UltraOlaksice.DisplayLayout.Override.ActiveRowAppearance = appearance42;
            this.UltraOlaksice.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.UltraOlaksice.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance43.BackColor = System.Drawing.SystemColors.Window;
            this.UltraOlaksice.DisplayLayout.Override.CardAreaAppearance = appearance43;
            appearance44.BorderColor = System.Drawing.Color.Silver;
            appearance44.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.UltraOlaksice.DisplayLayout.Override.CellAppearance = appearance44;
            this.UltraOlaksice.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.UltraOlaksice.DisplayLayout.Override.CellPadding = 0;
            this.UltraOlaksice.DisplayLayout.Override.ExpansionIndicator = Infragistics.Win.UltraWinGrid.ShowExpansionIndicator.CheckOnDisplay;
            appearance45.BackColor = System.Drawing.SystemColors.Control;
            appearance45.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance45.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance45.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance45.BorderColor = System.Drawing.SystemColors.Window;
            this.UltraOlaksice.DisplayLayout.Override.GroupByRowAppearance = appearance45;
            appearance46.TextHAlignAsString = "Left";
            this.UltraOlaksice.DisplayLayout.Override.HeaderAppearance = appearance46;
            this.UltraOlaksice.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.UltraOlaksice.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance47.BackColor = System.Drawing.SystemColors.Window;
            appearance47.BorderColor = System.Drawing.Color.Silver;
            this.UltraOlaksice.DisplayLayout.Override.RowAppearance = appearance47;
            this.UltraOlaksice.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance48.BackColor = System.Drawing.SystemColors.ControlLight;
            this.UltraOlaksice.DisplayLayout.Override.TemplateAddRowAppearance = appearance48;
            this.UltraOlaksice.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.UltraOlaksice.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.UltraOlaksice.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.UltraOlaksice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraOlaksice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraOlaksice.Location = new System.Drawing.Point(0, 0);
            this.UltraOlaksice.Name = "UltraOlaksice";
            this.UltraOlaksice.Size = new System.Drawing.Size(1026, 516);
            this.UltraOlaksice.TabIndex = 1;
            this.UltraOlaksice.Text = "ultraGrid1";
            this.UltraOlaksice.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.UltraGridProizvodi_DoubleClickRow);
            // 
            // uFOlaksicaBindingSource
            // 
            this.uFOlaksicaBindingSource.DataSource = typeof(Mipsed7.DataAccessLayer.EntityFramework.UF_Olaksica);
            // 
            // OlaksiceFormPregled
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UltraOlaksice);
            this.Name = "OlaksiceFormPregled";
            this.Size = new System.Drawing.Size(1026, 516);
            this.Load += new System.EventHandler(this.OlaksiceFormPregled_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UltraOlaksice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uFOlaksicaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid UltraOlaksice;
        private System.Windows.Forms.BindingSource uFOlaksicaBindingSource;
    }
}

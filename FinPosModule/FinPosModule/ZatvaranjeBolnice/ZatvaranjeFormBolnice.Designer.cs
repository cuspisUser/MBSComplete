namespace FinPosModule.ZatvaranjeBolnice
{
    partial class ZatvaranjeFormBolniceSmartPart
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
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.spMain = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.ucePartner = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.spParent = new System.Windows.Forms.SplitContainer();
            this.ugdRacuni = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ugdIzvodi = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spMain)).BeginInit();
            this.spMain.Panel1.SuspendLayout();
            this.spMain.Panel2.SuspendLayout();
            this.spMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucePartner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spParent)).BeginInit();
            this.spParent.Panel1.SuspendLayout();
            this.spParent.Panel2.SuspendLayout();
            this.spParent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugdRacuni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugdIzvodi)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.spMain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1145, 619);
            this.panel1.TabIndex = 0;
            // 
            // spMain
            // 
            this.spMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spMain.Location = new System.Drawing.Point(0, 0);
            this.spMain.Name = "spMain";
            this.spMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spMain.Panel1
            // 
            this.spMain.Panel1.Controls.Add(this.label2);
            this.spMain.Panel1.Controls.Add(this.ucePartner);
            // 
            // spMain.Panel2
            // 
            this.spMain.Panel2.Controls.Add(this.spParent);
            this.spMain.Size = new System.Drawing.Size(1145, 619);
            this.spMain.SplitterDistance = 85;
            this.spMain.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 13);
            this.label2.TabIndex = 118;
            this.label2.Text = "Partner za kojeg se radi zatvaranje:";
            // 
            // ucePartner
            // 
            this.ucePartner.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ucePartner.DisplayMember = "Naziv";
            this.ucePartner.Location = new System.Drawing.Point(17, 36);
            this.ucePartner.Name = "ucePartner";
            this.ucePartner.Size = new System.Drawing.Size(467, 22);
            this.ucePartner.TabIndex = 117;
            this.ucePartner.UseAppStyling = false;
            this.ucePartner.ValueMember = "ID";
            this.ucePartner.ValueChanged += new System.EventHandler(this.ucePartner_ValueChanged);
            // 
            // spParent
            // 
            this.spParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spParent.Location = new System.Drawing.Point(0, 0);
            this.spParent.Name = "spParent";
            this.spParent.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spParent.Panel1
            // 
            this.spParent.Panel1.Controls.Add(this.ugdRacuni);
            // 
            // spParent.Panel2
            // 
            this.spParent.Panel2.Controls.Add(this.ugdIzvodi);
            this.spParent.Size = new System.Drawing.Size(1145, 530);
            this.spParent.SplitterDistance = 282;
            this.spParent.TabIndex = 0;
            // 
            // ugdRacuni
            // 
            appearance31.BackColor = System.Drawing.SystemColors.Window;
            appearance31.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ugdRacuni.DisplayLayout.Appearance = appearance31;
            this.ugdRacuni.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugdRacuni.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance35.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance35.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance35.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance35.BorderColor = System.Drawing.SystemColors.Window;
            this.ugdRacuni.DisplayLayout.GroupByBox.Appearance = appearance35;
            appearance36.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugdRacuni.DisplayLayout.GroupByBox.BandLabelAppearance = appearance36;
            this.ugdRacuni.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance37.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance37.BackColor2 = System.Drawing.SystemColors.Control;
            appearance37.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance37.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugdRacuni.DisplayLayout.GroupByBox.PromptAppearance = appearance37;
            this.ugdRacuni.DisplayLayout.MaxColScrollRegions = 1;
            this.ugdRacuni.DisplayLayout.MaxRowScrollRegions = 1;
            appearance38.BackColor = System.Drawing.SystemColors.Window;
            appearance38.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ugdRacuni.DisplayLayout.Override.ActiveCellAppearance = appearance38;
            appearance39.BackColor = System.Drawing.SystemColors.Highlight;
            appearance39.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ugdRacuni.DisplayLayout.Override.ActiveRowAppearance = appearance39;
            this.ugdRacuni.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ugdRacuni.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance40.BackColor = System.Drawing.SystemColors.Window;
            this.ugdRacuni.DisplayLayout.Override.CardAreaAppearance = appearance40;
            appearance41.BorderColor = System.Drawing.Color.Silver;
            appearance41.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ugdRacuni.DisplayLayout.Override.CellAppearance = appearance41;
            this.ugdRacuni.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ugdRacuni.DisplayLayout.Override.CellPadding = 0;
            appearance42.BackColor = System.Drawing.SystemColors.Control;
            appearance42.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance42.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance42.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance42.BorderColor = System.Drawing.SystemColors.Window;
            this.ugdRacuni.DisplayLayout.Override.GroupByRowAppearance = appearance42;
            appearance43.TextHAlignAsString = "Left";
            this.ugdRacuni.DisplayLayout.Override.HeaderAppearance = appearance43;
            this.ugdRacuni.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ugdRacuni.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance44.BackColor = System.Drawing.SystemColors.Window;
            appearance44.BorderColor = System.Drawing.Color.Silver;
            this.ugdRacuni.DisplayLayout.Override.RowAppearance = appearance44;
            this.ugdRacuni.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance45.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ugdRacuni.DisplayLayout.Override.TemplateAddRowAppearance = appearance45;
            this.ugdRacuni.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ugdRacuni.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ugdRacuni.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ugdRacuni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ugdRacuni.Location = new System.Drawing.Point(0, 0);
            this.ugdRacuni.Name = "ugdRacuni";
            this.ugdRacuni.Size = new System.Drawing.Size(1145, 282);
            this.ugdRacuni.TabIndex = 1;
            this.ugdRacuni.Text = "ultraGrid1";
            this.ugdRacuni.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.ugdRacuni_BeforeRowsDeleted);
            // 
            // ugdIzvodi
            // 
            appearance4.BackColor = System.Drawing.SystemColors.Window;
            appearance4.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ugdIzvodi.DisplayLayout.Appearance = appearance4;
            this.ugdIzvodi.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugdIzvodi.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance8.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance8.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance8.BorderColor = System.Drawing.SystemColors.Window;
            this.ugdIzvodi.DisplayLayout.GroupByBox.Appearance = appearance8;
            appearance9.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugdIzvodi.DisplayLayout.GroupByBox.BandLabelAppearance = appearance9;
            this.ugdIzvodi.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance10.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance10.BackColor2 = System.Drawing.SystemColors.Control;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance10.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugdIzvodi.DisplayLayout.GroupByBox.PromptAppearance = appearance10;
            this.ugdIzvodi.DisplayLayout.MaxColScrollRegions = 1;
            this.ugdIzvodi.DisplayLayout.MaxRowScrollRegions = 1;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ugdIzvodi.DisplayLayout.Override.ActiveCellAppearance = appearance11;
            appearance12.BackColor = System.Drawing.SystemColors.Highlight;
            appearance12.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ugdIzvodi.DisplayLayout.Override.ActiveRowAppearance = appearance12;
            this.ugdIzvodi.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ugdIzvodi.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance25.BackColor = System.Drawing.SystemColors.Window;
            this.ugdIzvodi.DisplayLayout.Override.CardAreaAppearance = appearance25;
            appearance26.BorderColor = System.Drawing.Color.Silver;
            appearance26.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ugdIzvodi.DisplayLayout.Override.CellAppearance = appearance26;
            this.ugdIzvodi.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ugdIzvodi.DisplayLayout.Override.CellPadding = 0;
            appearance27.BackColor = System.Drawing.SystemColors.Control;
            appearance27.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance27.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance27.BorderColor = System.Drawing.SystemColors.Window;
            this.ugdIzvodi.DisplayLayout.Override.GroupByRowAppearance = appearance27;
            appearance28.TextHAlignAsString = "Left";
            this.ugdIzvodi.DisplayLayout.Override.HeaderAppearance = appearance28;
            this.ugdIzvodi.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ugdIzvodi.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance29.BackColor = System.Drawing.SystemColors.Window;
            appearance29.BorderColor = System.Drawing.Color.Silver;
            this.ugdIzvodi.DisplayLayout.Override.RowAppearance = appearance29;
            this.ugdIzvodi.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance30.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ugdIzvodi.DisplayLayout.Override.TemplateAddRowAppearance = appearance30;
            this.ugdIzvodi.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ugdIzvodi.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ugdIzvodi.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ugdIzvodi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ugdIzvodi.Location = new System.Drawing.Point(0, 0);
            this.ugdIzvodi.Name = "ugdIzvodi";
            this.ugdIzvodi.Size = new System.Drawing.Size(1145, 244);
            this.ugdIzvodi.TabIndex = 1;
            this.ugdIzvodi.Text = "ultraGrid1";
            this.ugdIzvodi.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.ugdIzvodi_BeforeRowsDeleted);
            // 
            // ZatvaranjeFormBolniceSmartPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ZatvaranjeFormBolniceSmartPart";
            this.Size = new System.Drawing.Size(1145, 619);
            this.panel1.ResumeLayout(false);
            this.spMain.Panel1.ResumeLayout(false);
            this.spMain.Panel1.PerformLayout();
            this.spMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spMain)).EndInit();
            this.spMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ucePartner)).EndInit();
            this.spParent.Panel1.ResumeLayout(false);
            this.spParent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spParent)).EndInit();
            this.spParent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugdRacuni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugdIzvodi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer spMain;
        private System.Windows.Forms.SplitContainer spParent;
        private Infragistics.Win.UltraWinGrid.UltraGrid ugdRacuni;
        private Infragistics.Win.UltraWinGrid.UltraGrid ugdIzvodi;
        private Infragistics.Win.UltraWinGrid.UltraCombo ucePartner;
        private System.Windows.Forms.Label label2;

    }
}

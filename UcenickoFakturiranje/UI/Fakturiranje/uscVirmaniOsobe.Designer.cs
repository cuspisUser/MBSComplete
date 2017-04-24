namespace UcenickoFakturiranje.UI.Fakturiranje
{
    partial class uscVirmaniOsobe
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
            this.lblName1 = new System.Windows.Forms.Label();
            this.btnVirmani = new System.Windows.Forms.Button();
            this.btnObracunOdustani = new System.Windows.Forms.Button();
            this.lblObracun = new System.Windows.Forms.Label();
            this.ugdUcenici = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.ucbUstanova = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.ugdUcenici)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucbUstanova)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName1
            // 
            this.lblName1.Location = new System.Drawing.Point(-3, 0);
            this.lblName1.Name = "lblName1";
            this.lblName1.Size = new System.Drawing.Size(57, 23);
            this.lblName1.TabIndex = 0;
            this.lblName1.Text = "Obračun:";
            this.lblName1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnVirmani
            // 
            this.btnVirmani.Location = new System.Drawing.Point(263, 447);
            this.btnVirmani.Name = "btnVirmani";
            this.btnVirmani.Size = new System.Drawing.Size(69, 25);
            this.btnVirmani.TabIndex = 6;
            this.btnVirmani.Text = "Virmani";
            this.btnVirmani.UseVisualStyleBackColor = true;
            this.btnVirmani.Click += new System.EventHandler(this.btnVirmani_Click);
            // 
            // btnObracunOdustani
            // 
            this.btnObracunOdustani.Location = new System.Drawing.Point(9, 447);
            this.btnObracunOdustani.Name = "btnObracunOdustani";
            this.btnObracunOdustani.Size = new System.Drawing.Size(69, 25);
            this.btnObracunOdustani.TabIndex = 7;
            this.btnObracunOdustani.Text = "Odustani";
            this.btnObracunOdustani.UseVisualStyleBackColor = true;
            this.btnObracunOdustani.Click += new System.EventHandler(this.btnObracunOdustani_Click);
            // 
            // lblObracun
            // 
            this.lblObracun.Location = new System.Drawing.Point(55, 0);
            this.lblObracun.Name = "lblObracun";
            this.lblObracun.Size = new System.Drawing.Size(207, 23);
            this.lblObracun.TabIndex = 8;
            this.lblObracun.Text = "Obračun:";
            this.lblObracun.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ugdUcenici
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ugdUcenici.DisplayLayout.Appearance = appearance1;
            this.ugdUcenici.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugdUcenici.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.ugdUcenici.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugdUcenici.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.ugdUcenici.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance3.BackColor2 = System.Drawing.SystemColors.Control;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugdUcenici.DisplayLayout.GroupByBox.PromptAppearance = appearance3;
            this.ugdUcenici.DisplayLayout.MaxColScrollRegions = 1;
            this.ugdUcenici.DisplayLayout.MaxRowScrollRegions = 1;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            appearance9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ugdUcenici.DisplayLayout.Override.ActiveCellAppearance = appearance9;
            appearance5.BackColor = System.Drawing.SystemColors.Highlight;
            appearance5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ugdUcenici.DisplayLayout.Override.ActiveRowAppearance = appearance5;
            this.ugdUcenici.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ugdUcenici.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            this.ugdUcenici.DisplayLayout.Override.CardAreaAppearance = appearance12;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ugdUcenici.DisplayLayout.Override.CellAppearance = appearance8;
            this.ugdUcenici.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ugdUcenici.DisplayLayout.Override.CellPadding = 0;
            appearance6.BackColor = System.Drawing.SystemColors.Control;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.ugdUcenici.DisplayLayout.Override.GroupByRowAppearance = appearance6;
            appearance7.TextHAlignAsString = "Left";
            this.ugdUcenici.DisplayLayout.Override.HeaderAppearance = appearance7;
            this.ugdUcenici.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ugdUcenici.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance10.BackColor = System.Drawing.SystemColors.Window;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            this.ugdUcenici.DisplayLayout.Override.RowAppearance = appearance10;
            this.ugdUcenici.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ugdUcenici.DisplayLayout.Override.TemplateAddRowAppearance = appearance11;
            this.ugdUcenici.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ugdUcenici.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ugdUcenici.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ugdUcenici.Location = new System.Drawing.Point(6, 89);
            this.ugdUcenici.Name = "ugdUcenici";
            this.ugdUcenici.Size = new System.Drawing.Size(326, 352);
            this.ugdUcenici.TabIndex = 9;
            this.ugdUcenici.Text = "ultraGrid1";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ustanova:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucbUstanova
            // 
            this.ucbUstanova.DisplayMember = "Naziv";
            this.ucbUstanova.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ucbUstanova.Location = new System.Drawing.Point(6, 62);
            this.ucbUstanova.MaxDropDownItems = 20;
            this.ucbUstanova.Name = "ucbUstanova";
            this.ucbUstanova.Size = new System.Drawing.Size(326, 21);
            this.ucbUstanova.TabIndex = 109;
            this.ucbUstanova.ValueMember = "ID";
            // 
            // uscVirmaniOsobe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucbUstanova);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ugdUcenici);
            this.Controls.Add(this.lblObracun);
            this.Controls.Add(this.btnObracunOdustani);
            this.Controls.Add(this.btnVirmani);
            this.Controls.Add(this.lblName1);
            this.Name = "uscVirmaniOsobe";
            this.Size = new System.Drawing.Size(377, 529);
            ((System.ComponentModel.ISupportInitialize)(this.ugdUcenici)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucbUstanova)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName1;
        private System.Windows.Forms.Button btnVirmani;
        private System.Windows.Forms.Button btnObracunOdustani;
        private System.Windows.Forms.Label lblObracun;
        public Infragistics.Win.UltraWinGrid.UltraGrid ugdUcenici;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ucbUstanova;

    }
}

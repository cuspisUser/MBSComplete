namespace DDModule.NetAdvantage.SmartParts
{
    partial class frmDNR
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDNR));
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.uneGodina = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.uneDoMjeseca = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.uneOdMjeseca = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.ugdOsobe = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.btnIspis = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.uneGodina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneDoMjeseca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneOdMjeseca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugdOsobe)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // uneGodina
            // 
            resources.ApplyResources(this.uneGodina, "uneGodina");
            this.uneGodina.MaskInput = "{LOC}-nnnnnnnnnn";
            this.uneGodina.MaxValue = 2500D;
            this.uneGodina.MinValue = 2000D;
            this.uneGodina.Name = "uneGodina";
            this.uneGodina.Nullable = true;
            this.uneGodina.NullText = " ";
            this.uneGodina.PromptChar = ' ';
            this.uneGodina.Value = null;
            // 
            // uneDoMjeseca
            // 
            resources.ApplyResources(this.uneDoMjeseca, "uneDoMjeseca");
            this.uneDoMjeseca.MaskInput = "{LOC}-nnnn";
            this.uneDoMjeseca.MaxValue = 12;
            this.uneDoMjeseca.MinValue = 1;
            this.uneDoMjeseca.Name = "uneDoMjeseca";
            this.uneDoMjeseca.Nullable = true;
            this.uneDoMjeseca.NullText = " ";
            this.uneDoMjeseca.PromptChar = ' ';
            this.uneDoMjeseca.Value = null;
            // 
            // uneOdMjeseca
            // 
            resources.ApplyResources(this.uneOdMjeseca, "uneOdMjeseca");
            this.uneOdMjeseca.MaskInput = "{LOC}-nnnn";
            this.uneOdMjeseca.MaxValue = 12;
            this.uneOdMjeseca.MinValue = 1;
            this.uneOdMjeseca.Name = "uneOdMjeseca";
            this.uneOdMjeseca.Nullable = true;
            this.uneOdMjeseca.NullText = " ";
            this.uneOdMjeseca.PromptChar = ' ';
            this.uneOdMjeseca.Value = null;
            // 
            // ugdOsobe
            // 
            appearance25.BackColor = System.Drawing.SystemColors.Window;
            appearance25.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            resources.ApplyResources(appearance25.FontData, "appearance25.FontData");
            resources.ApplyResources(appearance25, "appearance25");
            appearance25.ForceApplyResources = "FontData|";
            this.ugdOsobe.DisplayLayout.Appearance = appearance25;
            this.ugdOsobe.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugdOsobe.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance26.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance26.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance26.BorderColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(appearance26.FontData, "appearance26.FontData");
            resources.ApplyResources(appearance26, "appearance26");
            appearance26.ForceApplyResources = "FontData|";
            this.ugdOsobe.DisplayLayout.GroupByBox.Appearance = appearance26;
            appearance28.ForeColor = System.Drawing.SystemColors.GrayText;
            resources.ApplyResources(appearance28.FontData, "appearance28.FontData");
            resources.ApplyResources(appearance28, "appearance28");
            appearance28.ForceApplyResources = "FontData|";
            this.ugdOsobe.DisplayLayout.GroupByBox.BandLabelAppearance = appearance28;
            this.ugdOsobe.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance27.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance27.BackColor2 = System.Drawing.SystemColors.Control;
            appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance27.ForeColor = System.Drawing.SystemColors.GrayText;
            resources.ApplyResources(appearance27.FontData, "appearance27.FontData");
            resources.ApplyResources(appearance27, "appearance27");
            appearance27.ForceApplyResources = "FontData|";
            this.ugdOsobe.DisplayLayout.GroupByBox.PromptAppearance = appearance27;
            this.ugdOsobe.DisplayLayout.MaxColScrollRegions = 1;
            this.ugdOsobe.DisplayLayout.MaxRowScrollRegions = 1;
            appearance33.BackColor = System.Drawing.SystemColors.Window;
            appearance33.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(appearance33.FontData, "appearance33.FontData");
            resources.ApplyResources(appearance33, "appearance33");
            appearance33.ForceApplyResources = "FontData|";
            this.ugdOsobe.DisplayLayout.Override.ActiveCellAppearance = appearance33;
            appearance29.BackColor = System.Drawing.SystemColors.Highlight;
            appearance29.ForeColor = System.Drawing.SystemColors.HighlightText;
            resources.ApplyResources(appearance29.FontData, "appearance29.FontData");
            resources.ApplyResources(appearance29, "appearance29");
            appearance29.ForceApplyResources = "FontData|";
            this.ugdOsobe.DisplayLayout.Override.ActiveRowAppearance = appearance29;
            this.ugdOsobe.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ugdOsobe.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance36.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(appearance36.FontData, "appearance36.FontData");
            resources.ApplyResources(appearance36, "appearance36");
            appearance36.ForceApplyResources = "FontData|";
            this.ugdOsobe.DisplayLayout.Override.CardAreaAppearance = appearance36;
            appearance32.BorderColor = System.Drawing.Color.Silver;
            appearance32.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            resources.ApplyResources(appearance32.FontData, "appearance32.FontData");
            resources.ApplyResources(appearance32, "appearance32");
            appearance32.ForceApplyResources = "FontData|";
            this.ugdOsobe.DisplayLayout.Override.CellAppearance = appearance32;
            this.ugdOsobe.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ugdOsobe.DisplayLayout.Override.CellPadding = 0;
            appearance30.BackColor = System.Drawing.SystemColors.Control;
            appearance30.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance30.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance30.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance30.BorderColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(appearance30.FontData, "appearance30.FontData");
            resources.ApplyResources(appearance30, "appearance30");
            appearance30.ForceApplyResources = "FontData|";
            this.ugdOsobe.DisplayLayout.Override.GroupByRowAppearance = appearance30;
            resources.ApplyResources(appearance31, "appearance31");
            resources.ApplyResources(appearance31.FontData, "appearance31.FontData");
            appearance31.ForceApplyResources = "FontData|";
            this.ugdOsobe.DisplayLayout.Override.HeaderAppearance = appearance31;
            this.ugdOsobe.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ugdOsobe.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance34.BackColor = System.Drawing.SystemColors.Window;
            appearance34.BorderColor = System.Drawing.Color.Silver;
            resources.ApplyResources(appearance34.FontData, "appearance34.FontData");
            resources.ApplyResources(appearance34, "appearance34");
            appearance34.ForceApplyResources = "FontData|";
            this.ugdOsobe.DisplayLayout.Override.RowAppearance = appearance34;
            this.ugdOsobe.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance35.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(appearance35.FontData, "appearance35.FontData");
            resources.ApplyResources(appearance35, "appearance35");
            appearance35.ForceApplyResources = "FontData|";
            this.ugdOsobe.DisplayLayout.Override.TemplateAddRowAppearance = appearance35;
            this.ugdOsobe.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.Both;
            this.ugdOsobe.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ugdOsobe.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            resources.ApplyResources(this.ugdOsobe, "ugdOsobe");
            this.ugdOsobe.Name = "ugdOsobe";
            this.ugdOsobe.TabStop = false;
            // 
            // btnOdustani
            // 
            resources.ApplyResources(this.btnOdustani, "btnOdustani");
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // btnIspis
            // 
            resources.ApplyResources(this.btnIspis, "btnIspis");
            this.btnIspis.Name = "btnIspis";
            this.btnIspis.UseVisualStyleBackColor = true;
            this.btnIspis.Click += new System.EventHandler(this.btnIspis_Click);
            // 
            // frmDNR
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.btnIspis);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.ugdOsobe);
            this.Controls.Add(this.uneOdMjeseca);
            this.Controls.Add(this.uneDoMjeseca);
            this.Controls.Add(this.uneGodina);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmDNR";
            this.Load += new System.EventHandler(this.frmDNR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uneGodina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneDoMjeseca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneOdMjeseca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugdOsobe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneGodina;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneDoMjeseca;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneOdMjeseca;
        private Infragistics.Win.UltraWinGrid.UltraGrid ugdOsobe;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.Button btnIspis;
    }
}
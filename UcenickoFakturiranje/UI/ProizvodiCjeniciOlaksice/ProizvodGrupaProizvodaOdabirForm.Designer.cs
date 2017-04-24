namespace UcenickoFakturiranje.UI.ProizvodiCjeniciOlaksice
{
    partial class ProizvodGrupaProizvodaOdabirForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProizvodGrupaProizvodaOdabirForm));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SEL");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Naziv");
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnProizvodiOznaciSve = new System.Windows.Forms.ToolStripButton();
            this.btnProizvodiOdznaciSve = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButtonOdaberi = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButtonOdustani = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.UltraGridPodProizvodi = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGridPodProizvodi)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnProizvodiOznaciSve,
            this.btnProizvodiOdznaciSve,
            this.ToolStripButtonOdaberi,
            this.ToolStripButtonOdustani});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(773, 25);
            this.toolStrip1.TabIndex = 22;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnProizvodiOznaciSve
            // 
            this.btnProizvodiOznaciSve.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnProizvodiOznaciSve.Image = ((System.Drawing.Image)(resources.GetObject("btnProizvodiOznaciSve.Image")));
            this.btnProizvodiOznaciSve.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProizvodiOznaciSve.Name = "btnProizvodiOznaciSve";
            this.btnProizvodiOznaciSve.Size = new System.Drawing.Size(67, 22);
            this.btnProizvodiOznaciSve.Text = "Označi sve";
            this.btnProizvodiOznaciSve.Click += new System.EventHandler(this.btnProizvodiOznaciSve_Click);
            // 
            // btnProizvodiOdznaciSve
            // 
            this.btnProizvodiOdznaciSve.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnProizvodiOdznaciSve.Image = ((System.Drawing.Image)(resources.GetObject("btnProizvodiOdznaciSve.Image")));
            this.btnProizvodiOdznaciSve.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProizvodiOdznaciSve.Name = "btnProizvodiOdznaciSve";
            this.btnProizvodiOdznaciSve.Size = new System.Drawing.Size(74, 22);
            this.btnProizvodiOdznaciSve.Text = "Odznači sve";
            this.btnProizvodiOdznaciSve.Click += new System.EventHandler(this.btnProizvodiOdznaciSve_Click);
            // 
            // ToolStripButtonOdaberi
            // 
            this.ToolStripButtonOdaberi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripButtonOdaberi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonOdaberi.Name = "ToolStripButtonOdaberi";
            this.ToolStripButtonOdaberi.Size = new System.Drawing.Size(86, 22);
            this.ToolStripButtonOdaberi.Text = "Dodaj i zatvori";
            this.ToolStripButtonOdaberi.Click += new System.EventHandler(this.ToolStripButtonSpremi_Click);
            // 
            // ToolStripButtonOdustani
            // 
            this.ToolStripButtonOdustani.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripButtonOdustani.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonOdustani.Name = "ToolStripButtonOdustani";
            this.ToolStripButtonOdustani.Size = new System.Drawing.Size(103, 22);
            this.ToolStripButtonOdustani.Text = "Odustani i zatvori";
            this.ToolStripButtonOdustani.Click += new System.EventHandler(this.ToolStripButtonSpremiZatvori_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.UltraGridPodProizvodi, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(773, 540);
            this.tableLayoutPanel1.TabIndex = 23;
            // 
            // UltraGridPodProizvodi
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.UltraGridPodProizvodi.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            ultraGridColumn1.Width = 64;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 50;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Width = 262;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3});
            this.UltraGridPodProizvodi.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.UltraGridPodProizvodi.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.UltraGridPodProizvodi.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.UltraGridPodProizvodi.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.UltraGridPodProizvodi.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.UltraGridPodProizvodi.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.UltraGridPodProizvodi.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.UltraGridPodProizvodi.DisplayLayout.MaxColScrollRegions = 1;
            this.UltraGridPodProizvodi.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.UltraGridPodProizvodi.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.UltraGridPodProizvodi.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.UltraGridPodProizvodi.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.UltraGridPodProizvodi.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.UltraGridPodProizvodi.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.UltraGridPodProizvodi.DisplayLayout.Override.CellAppearance = appearance8;
            this.UltraGridPodProizvodi.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.UltraGridPodProizvodi.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.UltraGridPodProizvodi.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.UltraGridPodProizvodi.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.UltraGridPodProizvodi.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.UltraGridPodProizvodi.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.UltraGridPodProizvodi.DisplayLayout.Override.RowAppearance = appearance11;
            this.UltraGridPodProizvodi.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.UltraGridPodProizvodi.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.UltraGridPodProizvodi.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.UltraGridPodProizvodi.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.UltraGridPodProizvodi.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.UltraGridPodProizvodi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraGridPodProizvodi.Location = new System.Drawing.Point(8, 8);
            this.UltraGridPodProizvodi.Name = "UltraGridPodProizvodi";
            this.UltraGridPodProizvodi.Size = new System.Drawing.Size(757, 524);
            this.UltraGridPodProizvodi.TabIndex = 31;
            this.UltraGridPodProizvodi.Text = "ultraGrid1";
            this.UltraGridPodProizvodi.ClickCell += new Infragistics.Win.UltraWinGrid.ClickCellEventHandler(this.UltraGridPodProizvodi_ClickCell);
            // 
            // ProizvodGrupaProizvodaOdabirForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ProizvodGrupaProizvodaOdabirForm";
            this.Size = new System.Drawing.Size(773, 565);
            this.Load += new System.EventHandler(this.ProizvodGrupaProizvodaOdabirForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGridPodProizvodi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ToolStripButtonOdaberi;
        private System.Windows.Forms.ToolStripButton ToolStripButtonOdustani;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Infragistics.Win.UltraWinGrid.UltraGrid UltraGridPodProizvodi;
        private System.Windows.Forms.ToolStripButton btnProizvodiOznaciSve;
        private System.Windows.Forms.ToolStripButton btnProizvodiOdznaciSve;
    }
}

namespace NetAdvantage.SmartParts
{
    using Infragistics.Win;
    using Infragistics.Win.UltraWinGrid;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using NetAdvantage.Controls;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class s_od_rekap_doprinosUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with s_od_rekap_doprinos";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with s_od_rekap_doprinos";
        private s_od_rekap_doprinosDataGrid userControlDataGrids_od_rekap_doprinos;

        public s_od_rekap_doprinosUserDataGrid()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void Fill()
        {
            this.DataGrid.Fill();
        }

        private void InitializeComponent()
        {
            this.userControlDataGrids_od_rekap_doprinos = new s_od_rekap_doprinosDataGrid();
            ((ISupportInitialize) this.userControlDataGrids_od_rekap_doprinos).BeginInit();
            UltraGridBand band = new UltraGridBand("s_od_rekap_doprinos", -1);
            UltraGridColumn column = new UltraGridColumn("IZNOS");
            UltraGridColumn column3 = new UltraGridColumn("SIFRA");
            UltraGridColumn column4 = new UltraGridColumn("vrsta");
            UltraGridColumn column2 = new UltraGridColumn("NAZIVDOPRINOS");
            UltraGridColumn column5 = new UltraGridColumn("vrstasifra");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.s_od_rekap_doprinosIZNOSDescription;
            column.Width = 0x66;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column.PromptChar = ' ';
            column.Format = "F2";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.s_od_rekap_doprinosSIFRADescription;
            column3.Width = 0x33;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnn";
            column3.PromptChar = ' ';
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.s_od_rekap_doprinosvrstaDescription;
            column4.Width = 0x128;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.s_od_rekap_doprinosNAZIVDOPRINOSDescription;
            column2.Width = 0x128;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.s_od_rekap_doprinosvrstasifraDescription;
            column5.Width = 0x55;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnnn";
            column5.PromptChar = ' ';
            column5.Format = "";
            column5.CellAppearance = appearance5;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 1;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 2;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 3;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 4;
            this.userControlDataGrids_od_rekap_doprinos.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGrids_od_rekap_doprinos.Location = point;
            this.userControlDataGrids_od_rekap_doprinos.Name = "userControlDataGrids_od_rekap_doprinos";
            this.userControlDataGrids_od_rekap_doprinos.Tag = "s_od_rekap_doprinos";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGrids_od_rekap_doprinos.Size = size;
            this.userControlDataGrids_od_rekap_doprinos.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGrids_od_rekap_doprinos.Dock = DockStyle.Fill;
            this.userControlDataGrids_od_rekap_doprinos.FillAtStartup = false;
            this.userControlDataGrids_od_rekap_doprinos.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGrids_od_rekap_doprinos.InitializeRow += new InitializeRowEventHandler(this.s_od_rekap_doprinosUserDataGrid_InitializeRow);
            this.userControlDataGrids_od_rekap_doprinos.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGrids_od_rekap_doprinos });
            this.Name = "s_od_rekap_doprinosUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.s_od_rekap_doprinosUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGrids_od_rekap_doprinos).EndInit();
            this.ResumeLayout(false);
        }

        private void s_od_rekap_doprinosUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void s_od_rekap_doprinosUserDataGrid_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode && this.FillAtStartup)
            {
                this.DataGrid.Fill();
            }
        }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.DataView[this.DataGrid.CurrentRowIndex].Row;
            }
        }

        [Browsable(false)]
        public virtual s_od_rekap_doprinosDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGrids_od_rekap_doprinos;
            }
            set
            {
                this.userControlDataGrids_od_rekap_doprinos = value;
            }
        }

        [Browsable(false), Category("Deklarit Work With ")]
        public virtual System.Data.DataView DataView
        {
            get
            {
                return this.DataGrid.DataView;
            }
        }

        public string Description
        {
            get
            {
                return this.m_Description;
            }
            set
            {
                this.m_Description = value;
            }
        }

        [DefaultValue(true), Category("Deklarit Work With "), Description("True= Fill at Startup. False= Not Fill")]
        public virtual bool FillAtStartup
        {
            get
            {
                return this.m_FillAtStartup;
            }
            set
            {
                this.m_FillAtStartup = value;
            }
        }

        [Category("Deklarit Work With "), DefaultValue(true)]
        public virtual bool FillByPage
        {
            get
            {
                return this.DataGrid.FillByPage;
            }
            set
            {
                this.DataGrid.FillByPage = value;
            }
        }

        string Microsoft.Practices.CompositeUI.SmartParts.ISmartPartInfo.Description
        {
            get
            {
                return this.m_Description;
            }
            set
            {
                this.m_Description = value;
            }
        }

        string Microsoft.Practices.CompositeUI.SmartParts.ISmartPartInfo.Title
        {
            get
            {
                return this.m_Title;
            }
            set
            {
                this.m_Title = value;
            }
        }

        [DefaultValue(60), Category("Deklarit Work With ")]
        public virtual int PageSize
        {
            get
            {
                return this.DataGrid.PageSize;
            }
            set
            {
                this.DataGrid.PageSize = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string Parameteridobracun
        {
            get
            {
                return this.DataGrid.Parameteridobracun;
            }
            set
            {
                this.DataGrid.Parameteridobracun = value;
            }
        }

        public string Title
        {
            get
            {
                return this.m_Title;
            }
            set
            {
                this.m_Title = value;
            }
        }
    }
}


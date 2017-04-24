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

    public class PROVIDER_BRUTOUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with PROVIDER_BRUTO";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with PROVIDER_BRUTO";
        private PROVIDER_BRUTODataGrid userControlDataGridPROVIDER_BRUTO;

        public PROVIDER_BRUTOUserDataGrid()
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
            this.userControlDataGridPROVIDER_BRUTO = new PROVIDER_BRUTODataGrid();
            ((ISupportInitialize) this.userControlDataGridPROVIDER_BRUTO).BeginInit();
            UltraGridBand band = new UltraGridBand("ELEMENT", -1);
            UltraGridColumn column2 = new UltraGridColumn("IDELEMENT");
            UltraGridColumn column4 = new UltraGridColumn("NAZIVELEMENT");
            UltraGridColumn column3 = new UltraGridColumn("IDVRSTAELEMENTA");
            UltraGridColumn column5 = new UltraGridColumn("POSTOTAK");
            UltraGridColumn column = new UltraGridColumn("EL");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.PROVIDER_BRUTOIDELEMENTDescription;
            column2.Width = 0x70;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnnnnn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.PROVIDER_BRUTONAZIVELEMENTDescription;
            column4.Width = 0x128;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.PROVIDER_BRUTOIDVRSTAELEMENTADescription;
            column3.Width = 0x99;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnn";
            column3.PromptChar = ' ';
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.PROVIDER_BRUTOPOSTOTAKDescription;
            column5.Width = 0x4b;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnn.nn";
            column5.PromptChar = ' ';
            column5.Format = "F2";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.PROVIDER_BRUTOELDescription;
            column.Width = 0x128;
            column.Format = "";
            column.CellAppearance = appearance;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 0;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 1;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 2;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 3;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 4;
            this.userControlDataGridPROVIDER_BRUTO.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridPROVIDER_BRUTO.Location = point;
            this.userControlDataGridPROVIDER_BRUTO.Name = "userControlDataGridPROVIDER_BRUTO";
            this.userControlDataGridPROVIDER_BRUTO.Tag = "ELEMENT";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridPROVIDER_BRUTO.Size = size;
            this.userControlDataGridPROVIDER_BRUTO.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridPROVIDER_BRUTO.Dock = DockStyle.Fill;
            this.userControlDataGridPROVIDER_BRUTO.FillAtStartup = false;
            this.userControlDataGridPROVIDER_BRUTO.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridPROVIDER_BRUTO.InitializeRow += new InitializeRowEventHandler(this.PROVIDER_BRUTOUserDataGrid_InitializeRow);
            this.userControlDataGridPROVIDER_BRUTO.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridPROVIDER_BRUTO });
            this.Name = "PROVIDER_BRUTOUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.PROVIDER_BRUTOUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridPROVIDER_BRUTO).EndInit();
            this.ResumeLayout(false);
        }

        private void PROVIDER_BRUTOUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void PROVIDER_BRUTOUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual PROVIDER_BRUTODataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridPROVIDER_BRUTO;
            }
            set
            {
                this.userControlDataGridPROVIDER_BRUTO = value;
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

        [Description("True= Fill at Startup. False= Not Fill"), DefaultValue(true), Category("Deklarit Work With ")]
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

        [DefaultValue(true), Category("Deklarit Work With ")]
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


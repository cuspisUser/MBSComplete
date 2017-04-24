namespace NetAdvantage.SmartParts
{
    using Deklarit.Controls;
    using Infragistics.Win;
    using Infragistics.Win.UltraWinGrid;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using NetAdvantage.Controls;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class OSNOVAOSIGURANJAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with R-Sm - Osnove osiguranja";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with R-Sm - Osnove osiguranja";
        private OSNOVAOSIGURANJADataGrid userControlDataGridOSNOVAOSIGURANJA;

        public OSNOVAOSIGURANJAUserDataGrid()
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
            this.userControlDataGridOSNOVAOSIGURANJA = new OSNOVAOSIGURANJADataGrid();
            ((ISupportInitialize) this.userControlDataGridOSNOVAOSIGURANJA).BeginInit();
            UltraGridBand band = new UltraGridBand("OSNOVAOSIGURANJA", -1);
            UltraGridColumn column = new UltraGridColumn("IDOSNOVAOSIGURANJA");
            UltraGridColumn column2 = new UltraGridColumn("NAZIVOSNOVAOSIGURANJA");
            UltraGridColumn column3 = new UltraGridColumn("RAZDOBLJESESMIJEPREKLAPATI");
            UltraGridColumn column4 = new UltraGridColumn("ZAMOOIDOSNOVAOSIGURANJA");
            UltraGridColumn column5 = new UltraGridColumn("ZAMOONAZIVOSNOVAOSIGURANJA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.OSNOVAOSIGURANJAIDOSNOVAOSIGURANJADescription;
            column.Width = 0xb1;
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.OSNOVAOSIGURANJANAZIVOSNOVAOSIGURANJADescription;
            column2.Width = 0x128;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.OSNOVAOSIGURANJARAZDOBLJESESMIJEPREKLAPATIDescription;
            column3.Width = 0xdb;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.OSNOVAOSIGURANJAZAMOOIDOSNOVAOSIGURANJADescription;
            column4.Width = 0x128;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.OSNOVAOSIGURANJAZAMOONAZIVOSNOVAOSIGURANJADescription;
            column5.Width = 0x128;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 2;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 3;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 4;
            this.userControlDataGridOSNOVAOSIGURANJA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridOSNOVAOSIGURANJA.Location = point;
            this.userControlDataGridOSNOVAOSIGURANJA.Name = "userControlDataGridOSNOVAOSIGURANJA";
            this.userControlDataGridOSNOVAOSIGURANJA.Tag = "OSNOVAOSIGURANJA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridOSNOVAOSIGURANJA.Size = size;
            this.userControlDataGridOSNOVAOSIGURANJA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridOSNOVAOSIGURANJA.Dock = DockStyle.Fill;
            this.userControlDataGridOSNOVAOSIGURANJA.FillAtStartup = false;
            this.userControlDataGridOSNOVAOSIGURANJA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridOSNOVAOSIGURANJA.InitializeRow += new InitializeRowEventHandler(this.OSNOVAOSIGURANJAUserDataGrid_InitializeRow);
            this.userControlDataGridOSNOVAOSIGURANJA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridOSNOVAOSIGURANJA });
            this.Name = "OSNOVAOSIGURANJAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.OSNOVAOSIGURANJAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridOSNOVAOSIGURANJA).EndInit();
            this.ResumeLayout(false);
        }

        private void OSNOVAOSIGURANJAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void OSNOVAOSIGURANJAUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual OSNOVAOSIGURANJADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridOSNOVAOSIGURANJA;
            }
            set
            {
                this.userControlDataGridOSNOVAOSIGURANJA = value;
            }
        }

        [Category("Deklarit Work With "), Browsable(false)]
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

        [Category("Deklarit Work With ")]
        public virtual string FillByZAMOOIDOSNOVAOSIGURANJAZAMOOIDOSNOVAOSIGURANJA
        {
            get
            {
                return this.DataGrid.FillByZAMOOIDOSNOVAOSIGURANJAZAMOOIDOSNOVAOSIGURANJA;
            }
            set
            {
                this.DataGrid.FillByZAMOOIDOSNOVAOSIGURANJAZAMOOIDOSNOVAOSIGURANJA = value;
            }
        }

        [TypeConverter(typeof(DeklaritDataGrid.FillMethodsConverter)), Category("Deklarit Work With "), DefaultValue("Fill")]
        public virtual string FillMethod
        {
            get
            {
                return this.DataGrid.FillMethod;
            }
            set
            {
                this.DataGrid.FillMethod = value;
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


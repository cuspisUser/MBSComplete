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

    public class POSTANSKIBROJEVIUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with POSTANSKIBROJEVI";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with POSTANSKIBROJEVI";
        private POSTANSKIBROJEVIDataGrid userControlDataGridPOSTANSKIBROJEVI;

        public POSTANSKIBROJEVIUserDataGrid()
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
            this.userControlDataGridPOSTANSKIBROJEVI = new POSTANSKIBROJEVIDataGrid();
            ((ISupportInitialize) this.userControlDataGridPOSTANSKIBROJEVI).BeginInit();
            UltraGridBand band = new UltraGridBand("POSTANSKIBROJEVI", -1);
            UltraGridColumn column2 = new UltraGridColumn("POSTANSKIBROJ");
            UltraGridColumn column = new UltraGridColumn("NAZIVPOSTE");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.POSTANSKIBROJEVIPOSTANSKIBROJDescription;
            column2.Width = 0x72;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.POSTANSKIBROJEVINAZIVPOSTEDescription;
            column.Width = 0x128;
            column.Format = "";
            column.CellAppearance = appearance;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 0;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 1;
            this.userControlDataGridPOSTANSKIBROJEVI.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridPOSTANSKIBROJEVI.Location = point;
            this.userControlDataGridPOSTANSKIBROJEVI.Name = "userControlDataGridPOSTANSKIBROJEVI";
            this.userControlDataGridPOSTANSKIBROJEVI.Tag = "POSTANSKIBROJEVI";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridPOSTANSKIBROJEVI.Size = size;
            this.userControlDataGridPOSTANSKIBROJEVI.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridPOSTANSKIBROJEVI.Dock = DockStyle.Fill;
            this.userControlDataGridPOSTANSKIBROJEVI.FillAtStartup = false;
            this.userControlDataGridPOSTANSKIBROJEVI.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridPOSTANSKIBROJEVI.InitializeRow += new InitializeRowEventHandler(this.POSTANSKIBROJEVIUserDataGrid_InitializeRow);
            this.userControlDataGridPOSTANSKIBROJEVI.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridPOSTANSKIBROJEVI });
            this.Name = "POSTANSKIBROJEVIUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.POSTANSKIBROJEVIUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridPOSTANSKIBROJEVI).EndInit();
            this.ResumeLayout(false);
        }

        private void POSTANSKIBROJEVIUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void POSTANSKIBROJEVIUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual POSTANSKIBROJEVIDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridPOSTANSKIBROJEVI;
            }
            set
            {
                this.userControlDataGridPOSTANSKIBROJEVI = value;
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

        [DefaultValue(true), Description("True= Fill at Startup. False= Not Fill"), Category("Deklarit Work With ")]
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

        [TypeConverter(typeof(DeklaritDataGrid.FillMethodsConverter)), DefaultValue("Fill"), Category("Deklarit Work With ")]
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

        [Category("Deklarit Work With "), DefaultValue(60)]
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


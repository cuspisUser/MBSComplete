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

    public class RSVRSTEOBVEZNIKAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with R-Sm - Vrste obveznika";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with R-Sm - Vrste obveznika";
        private RSVRSTEOBVEZNIKADataGrid userControlDataGridRSVRSTEOBVEZNIKA;

        public RSVRSTEOBVEZNIKAUserDataGrid()
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
            this.userControlDataGridRSVRSTEOBVEZNIKA = new RSVRSTEOBVEZNIKADataGrid();
            ((ISupportInitialize) this.userControlDataGridRSVRSTEOBVEZNIKA).BeginInit();
            UltraGridBand band = new UltraGridBand("RSVRSTEOBVEZNIKA", -1);
            UltraGridColumn column = new UltraGridColumn("IDRSVRSTEOBVEZNIKA");
            UltraGridColumn column2 = new UltraGridColumn("NAZIVRSVRSTEOBVEZNIKA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.RSVRSTEOBVEZNIKAIDRSVRSTEOBVEZNIKADescription;
            column.Width = 0xa3;
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.RSVRSTEOBVEZNIKANAZIVRSVRSTEOBVEZNIKADescription;
            column2.Width = 0x128;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            this.userControlDataGridRSVRSTEOBVEZNIKA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridRSVRSTEOBVEZNIKA.Location = point;
            this.userControlDataGridRSVRSTEOBVEZNIKA.Name = "userControlDataGridRSVRSTEOBVEZNIKA";
            this.userControlDataGridRSVRSTEOBVEZNIKA.Tag = "RSVRSTEOBVEZNIKA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridRSVRSTEOBVEZNIKA.Size = size;
            this.userControlDataGridRSVRSTEOBVEZNIKA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridRSVRSTEOBVEZNIKA.Dock = DockStyle.Fill;
            this.userControlDataGridRSVRSTEOBVEZNIKA.FillAtStartup = false;
            this.userControlDataGridRSVRSTEOBVEZNIKA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridRSVRSTEOBVEZNIKA.InitializeRow += new InitializeRowEventHandler(this.RSVRSTEOBVEZNIKAUserDataGrid_InitializeRow);
            this.userControlDataGridRSVRSTEOBVEZNIKA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridRSVRSTEOBVEZNIKA });
            this.Name = "RSVRSTEOBVEZNIKAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.RSVRSTEOBVEZNIKAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridRSVRSTEOBVEZNIKA).EndInit();
            this.ResumeLayout(false);
        }

        private void RSVRSTEOBVEZNIKAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void RSVRSTEOBVEZNIKAUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual RSVRSTEOBVEZNIKADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridRSVRSTEOBVEZNIKA;
            }
            set
            {
                this.userControlDataGridRSVRSTEOBVEZNIKA = value;
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

        [Category("Deklarit Work With "), TypeConverter(typeof(DeklaritDataGrid.FillMethodsConverter)), DefaultValue("Fill")]
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


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

    public class DDVRSTEIZNOSAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with DD-Vrste iznosa";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with DD-Vrste iznosa";
        private DDVRSTEIZNOSADataGrid userControlDataGridDDVRSTEIZNOSA;

        public DDVRSTEIZNOSAUserDataGrid()
        {
            this.InitializeComponent();
        }

        private void DDVRSTEIZNOSAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void DDVRSTEIZNOSAUserDataGrid_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode && this.FillAtStartup)
            {
                this.DataGrid.Fill();
            }
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
            this.userControlDataGridDDVRSTEIZNOSA = new DDVRSTEIZNOSADataGrid();
            ((ISupportInitialize) this.userControlDataGridDDVRSTEIZNOSA).BeginInit();
            UltraGridBand band = new UltraGridBand("DDVRSTEIZNOSA", -1);
            UltraGridColumn column = new UltraGridColumn("IDDDVRSTEIZNOSA");
            UltraGridColumn column2 = new UltraGridColumn("NAZIVDDVRSTEIZNOSA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.DDVRSTEIZNOSAIDDDVRSTEIZNOSADescription;
            column.Width = 0x33;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.DDVRSTEIZNOSANAZIVDDVRSTEIZNOSADescription;
            column2.Width = 0x128;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            this.userControlDataGridDDVRSTEIZNOSA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridDDVRSTEIZNOSA.Location = point;
            this.userControlDataGridDDVRSTEIZNOSA.Name = "userControlDataGridDDVRSTEIZNOSA";
            this.userControlDataGridDDVRSTEIZNOSA.Tag = "DDVRSTEIZNOSA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridDDVRSTEIZNOSA.Size = size;
            this.userControlDataGridDDVRSTEIZNOSA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridDDVRSTEIZNOSA.Dock = DockStyle.Fill;
            this.userControlDataGridDDVRSTEIZNOSA.FillAtStartup = false;
            this.userControlDataGridDDVRSTEIZNOSA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridDDVRSTEIZNOSA.InitializeRow += new InitializeRowEventHandler(this.DDVRSTEIZNOSAUserDataGrid_InitializeRow);
            this.userControlDataGridDDVRSTEIZNOSA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridDDVRSTEIZNOSA });
            this.Name = "DDVRSTEIZNOSAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.DDVRSTEIZNOSAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridDDVRSTEIZNOSA).EndInit();
            this.ResumeLayout(false);
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
        public virtual DDVRSTEIZNOSADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridDDVRSTEIZNOSA;
            }
            set
            {
                this.userControlDataGridDDVRSTEIZNOSA = value;
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


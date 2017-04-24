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

    public class DDVRSTEPOSLAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Vrste posla";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Vrste posla";
        private DDVRSTEPOSLADataGrid userControlDataGridDDVRSTEPOSLA;

        public DDVRSTEPOSLAUserDataGrid()
        {
            this.InitializeComponent();
        }

        private void DDVRSTEPOSLAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void DDVRSTEPOSLAUserDataGrid_Load(object sender, EventArgs e)
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
            this.userControlDataGridDDVRSTEPOSLA = new DDVRSTEPOSLADataGrid();
            ((ISupportInitialize) this.userControlDataGridDDVRSTEPOSLA).BeginInit();
            UltraGridBand band = new UltraGridBand("DDVRSTEPOSLA", -1);
            UltraGridColumn column = new UltraGridColumn("DDIDVRSTAPOSLA");
            UltraGridColumn column2 = new UltraGridColumn("DDNAZIVVRSTAPOSLA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.DDVRSTEPOSLADDIDVRSTAPOSLADescription;
            column.Width = 0x33;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.DDVRSTEPOSLADDNAZIVVRSTAPOSLADescription;
            column2.Width = 0x128;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            this.userControlDataGridDDVRSTEPOSLA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridDDVRSTEPOSLA.Location = point;
            this.userControlDataGridDDVRSTEPOSLA.Name = "userControlDataGridDDVRSTEPOSLA";
            this.userControlDataGridDDVRSTEPOSLA.Tag = "DDVRSTEPOSLA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridDDVRSTEPOSLA.Size = size;
            this.userControlDataGridDDVRSTEPOSLA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridDDVRSTEPOSLA.Dock = DockStyle.Fill;
            this.userControlDataGridDDVRSTEPOSLA.FillAtStartup = false;
            this.userControlDataGridDDVRSTEPOSLA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridDDVRSTEPOSLA.InitializeRow += new InitializeRowEventHandler(this.DDVRSTEPOSLAUserDataGrid_InitializeRow);
            this.userControlDataGridDDVRSTEPOSLA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridDDVRSTEPOSLA });
            this.Name = "DDVRSTEPOSLAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.DDVRSTEPOSLAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridDDVRSTEPOSLA).EndInit();
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
        public virtual DDVRSTEPOSLADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridDDVRSTEPOSLA;
            }
            set
            {
                this.userControlDataGridDDVRSTEPOSLA = value;
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

        [DefaultValue("Fill"), Category("Deklarit Work With "), TypeConverter(typeof(DeklaritDataGrid.FillMethodsConverter))]
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


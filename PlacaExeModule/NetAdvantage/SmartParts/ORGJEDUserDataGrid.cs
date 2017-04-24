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

    public class ORGJEDUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Organizacijske jedinice";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Organizacijske jedinice";
        private ORGJEDDataGrid userControlDataGridORGJED;

        public ORGJEDUserDataGrid()
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
            this.userControlDataGridORGJED = new ORGJEDDataGrid();
            ((ISupportInitialize) this.userControlDataGridORGJED).BeginInit();
            UltraGridBand band = new UltraGridBand("ORGJED", -1);
            UltraGridColumn column = new UltraGridColumn("IDORGJED");
            UltraGridColumn column2 = new UltraGridColumn("NAZIVORGJED");
            UltraGridColumn column3 = new UltraGridColumn("oj");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.ORGJEDIDORGJEDDescription;
            column.Width = 0x48;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.ORGJEDNAZIVORGJEDDescription;
            column2.Width = 0x128;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.ORGJEDojDescription;
            column3.Width = 0x128;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 2;
            this.userControlDataGridORGJED.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridORGJED.Location = point;
            this.userControlDataGridORGJED.Name = "userControlDataGridORGJED";
            this.userControlDataGridORGJED.Tag = "ORGJED";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridORGJED.Size = size;
            this.userControlDataGridORGJED.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridORGJED.Dock = DockStyle.Fill;
            this.userControlDataGridORGJED.FillAtStartup = false;
            this.userControlDataGridORGJED.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridORGJED.InitializeRow += new InitializeRowEventHandler(this.ORGJEDUserDataGrid_InitializeRow);
            this.userControlDataGridORGJED.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridORGJED });
            this.Name = "ORGJEDUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.ORGJEDUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridORGJED).EndInit();
            this.ResumeLayout(false);
        }

        private void ORGJEDUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void ORGJEDUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual ORGJEDDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridORGJED;
            }
            set
            {
                this.userControlDataGridORGJED = value;
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

        [Category("Deklarit Work With "), Description("True= Fill at Startup. False= Not Fill"), DefaultValue(true)]
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


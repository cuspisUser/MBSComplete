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

    public class IRAVRSTAIZNOSAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Vrste iznosa IRA";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Vrste iznosa IRA";
        private IRAVRSTAIZNOSADataGrid userControlDataGridIRAVRSTAIZNOSA;

        public IRAVRSTAIZNOSAUserDataGrid()
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
            this.userControlDataGridIRAVRSTAIZNOSA = new IRAVRSTAIZNOSADataGrid();
            ((ISupportInitialize) this.userControlDataGridIRAVRSTAIZNOSA).BeginInit();
            UltraGridBand band = new UltraGridBand("IRAVRSTAIZNOSA", -1);
            UltraGridColumn column = new UltraGridColumn("IDIRAVRSTAIZNOSA");
            UltraGridColumn column2 = new UltraGridColumn("IRAVRSTAIZNOSANAZIV");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.IRAVRSTAIZNOSAIDIRAVRSTAIZNOSADescription;
            column.Width = 0x7e;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.IRAVRSTAIZNOSAIRAVRSTAIZNOSANAZIVDescription;
            column2.Width = 0xe2;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            this.userControlDataGridIRAVRSTAIZNOSA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridIRAVRSTAIZNOSA.Location = point;
            this.userControlDataGridIRAVRSTAIZNOSA.Name = "userControlDataGridIRAVRSTAIZNOSA";
            this.userControlDataGridIRAVRSTAIZNOSA.Tag = "IRAVRSTAIZNOSA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridIRAVRSTAIZNOSA.Size = size;
            this.userControlDataGridIRAVRSTAIZNOSA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridIRAVRSTAIZNOSA.Dock = DockStyle.Fill;
            this.userControlDataGridIRAVRSTAIZNOSA.FillAtStartup = false;
            this.userControlDataGridIRAVRSTAIZNOSA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridIRAVRSTAIZNOSA.InitializeRow += new InitializeRowEventHandler(this.IRAVRSTAIZNOSAUserDataGrid_InitializeRow);
            this.userControlDataGridIRAVRSTAIZNOSA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridIRAVRSTAIZNOSA });
            this.Name = "IRAVRSTAIZNOSAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.IRAVRSTAIZNOSAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridIRAVRSTAIZNOSA).EndInit();
            this.ResumeLayout(false);
        }

        private void IRAVRSTAIZNOSAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void IRAVRSTAIZNOSAUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual IRAVRSTAIZNOSADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridIRAVRSTAIZNOSA;
            }
            set
            {
                this.userControlDataGridIRAVRSTAIZNOSA = value;
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


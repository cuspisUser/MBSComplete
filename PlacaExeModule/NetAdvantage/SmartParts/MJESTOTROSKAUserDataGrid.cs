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

    public class MJESTOTROSKAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with MJESTOTROSKA";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with MJESTOTROSKA";
        private MJESTOTROSKADataGrid userControlDataGridMJESTOTROSKA;

        public MJESTOTROSKAUserDataGrid()
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
            this.userControlDataGridMJESTOTROSKA = new MJESTOTROSKADataGrid();
            ((ISupportInitialize) this.userControlDataGridMJESTOTROSKA).BeginInit();
            UltraGridBand band = new UltraGridBand("MJESTOTROSKA", -1);
            UltraGridColumn column = new UltraGridColumn("IDMJESTOTROSKA");
            UltraGridColumn column3 = new UltraGridColumn("NAZIVMJESTOTROSKA");
            UltraGridColumn column2 = new UltraGridColumn("mt");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.MJESTOTROSKAIDMJESTOTROSKADescription;
            column.Width = 0x48;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.MJESTOTROSKANAZIVMJESTOTROSKADescription;
            column3.Width = 0x128;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.MJESTOTROSKAmtDescription;
            column2.Width = 0x128;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 1;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 2;
            this.userControlDataGridMJESTOTROSKA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridMJESTOTROSKA.Location = point;
            this.userControlDataGridMJESTOTROSKA.Name = "userControlDataGridMJESTOTROSKA";
            this.userControlDataGridMJESTOTROSKA.Tag = "MJESTOTROSKA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridMJESTOTROSKA.Size = size;
            this.userControlDataGridMJESTOTROSKA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridMJESTOTROSKA.Dock = DockStyle.Fill;
            this.userControlDataGridMJESTOTROSKA.FillAtStartup = false;
            this.userControlDataGridMJESTOTROSKA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridMJESTOTROSKA.InitializeRow += new InitializeRowEventHandler(this.MJESTOTROSKAUserDataGrid_InitializeRow);
            this.userControlDataGridMJESTOTROSKA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridMJESTOTROSKA });
            this.Name = "MJESTOTROSKAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.MJESTOTROSKAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridMJESTOTROSKA).EndInit();
            this.ResumeLayout(false);
        }

        private void MJESTOTROSKAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void MJESTOTROSKAUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual MJESTOTROSKADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridMJESTOTROSKA;
            }
            set
            {
                this.userControlDataGridMJESTOTROSKA = value;
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


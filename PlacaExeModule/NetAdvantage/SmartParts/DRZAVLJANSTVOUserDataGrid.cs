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

    public class DRZAVLJANSTVOUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Državljanstvo";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Državljanstvo";
        private DRZAVLJANSTVODataGrid userControlDataGridDRZAVLJANSTVO;

        public DRZAVLJANSTVOUserDataGrid()
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

        private void DRZAVLJANSTVOUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void DRZAVLJANSTVOUserDataGrid_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode && this.FillAtStartup)
            {
                this.DataGrid.Fill();
            }
        }

        public void Fill()
        {
            this.DataGrid.Fill();
        }

        private void InitializeComponent()
        {
            this.userControlDataGridDRZAVLJANSTVO = new DRZAVLJANSTVODataGrid();
            ((ISupportInitialize) this.userControlDataGridDRZAVLJANSTVO).BeginInit();
            UltraGridBand band = new UltraGridBand("DRZAVLJANSTVO", -1);
            UltraGridColumn column = new UltraGridColumn("IDDRZAVLJANSTVO");
            UltraGridColumn column2 = new UltraGridColumn("NAZIVDRZAVLJANSTVO");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.DRZAVLJANSTVOIDDRZAVLJANSTVODescription;
            column.Width = 0x33;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.DRZAVLJANSTVONAZIVDRZAVLJANSTVODescription;
            column2.Width = 0x128;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            this.userControlDataGridDRZAVLJANSTVO.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridDRZAVLJANSTVO.Location = point;
            this.userControlDataGridDRZAVLJANSTVO.Name = "userControlDataGridDRZAVLJANSTVO";
            this.userControlDataGridDRZAVLJANSTVO.Tag = "DRZAVLJANSTVO";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridDRZAVLJANSTVO.Size = size;
            this.userControlDataGridDRZAVLJANSTVO.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridDRZAVLJANSTVO.Dock = DockStyle.Fill;
            this.userControlDataGridDRZAVLJANSTVO.FillAtStartup = false;
            this.userControlDataGridDRZAVLJANSTVO.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridDRZAVLJANSTVO.InitializeRow += new InitializeRowEventHandler(this.DRZAVLJANSTVOUserDataGrid_InitializeRow);
            this.userControlDataGridDRZAVLJANSTVO.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridDRZAVLJANSTVO });
            this.Name = "DRZAVLJANSTVOUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.DRZAVLJANSTVOUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridDRZAVLJANSTVO).EndInit();
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
        public virtual DRZAVLJANSTVODataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridDRZAVLJANSTVO;
            }
            set
            {
                this.userControlDataGridDRZAVLJANSTVO = value;
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

        [Category("Deklarit Work With "), DefaultValue(true), Description("True= Fill at Startup. False= Not Fill")]
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

        [DefaultValue("Fill"), TypeConverter(typeof(DeklaritDataGrid.FillMethodsConverter)), Category("Deklarit Work With ")]
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


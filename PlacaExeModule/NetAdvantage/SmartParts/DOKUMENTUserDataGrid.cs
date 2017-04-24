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

    public class DOKUMENTUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with DOKUMENT";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with DOKUMENT";
        private DOKUMENTDataGrid userControlDataGridDOKUMENT;

        public DOKUMENTUserDataGrid()
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

        private void DOKUMENTUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void DOKUMENTUserDataGrid_Load(object sender, EventArgs e)
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
            this.userControlDataGridDOKUMENT = new DOKUMENTDataGrid();
            ((ISupportInitialize) this.userControlDataGridDOKUMENT).BeginInit();
            UltraGridBand band = new UltraGridBand("DOKUMENT", -1);
            UltraGridColumn column = new UltraGridColumn("IDDOKUMENT");
            UltraGridColumn column3 = new UltraGridColumn("NAZIVDOKUMENT");
            UltraGridColumn column2 = new UltraGridColumn("IDTIPDOKUMENTA");
            UltraGridColumn column4 = new UltraGridColumn("NAZIVTIPDOKUMENTA");
            UltraGridColumn column5 = new UltraGridColumn("PS");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.DOKUMENTIDDOKUMENTDescription;
            column.Width = 0x48;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.DOKUMENTNAZIVDOKUMENTDescription;
            column3.Width = 0x128;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.DOKUMENTIDTIPDOKUMENTADescription;
            column2.Width = 0x70;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.DOKUMENTNAZIVTIPDOKUMENTADescription;
            column4.Width = 0x128;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.DOKUMENTPSDescription;
            column5.Width = 30;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 1;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 2;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 3;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 4;
            this.userControlDataGridDOKUMENT.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridDOKUMENT.Location = point;
            this.userControlDataGridDOKUMENT.Name = "userControlDataGridDOKUMENT";
            this.userControlDataGridDOKUMENT.Tag = "DOKUMENT";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridDOKUMENT.Size = size;
            this.userControlDataGridDOKUMENT.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridDOKUMENT.Dock = DockStyle.Fill;
            this.userControlDataGridDOKUMENT.FillAtStartup = false;
            this.userControlDataGridDOKUMENT.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridDOKUMENT.InitializeRow += new InitializeRowEventHandler(this.DOKUMENTUserDataGrid_InitializeRow);
            this.userControlDataGridDOKUMENT.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridDOKUMENT });
            this.Name = "DOKUMENTUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.DOKUMENTUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridDOKUMENT).EndInit();
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
        public virtual DOKUMENTDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridDOKUMENT;
            }
            set
            {
                this.userControlDataGridDOKUMENT = value;
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

        [Description("True= Fill at Startup. False= Not Fill"), Category("Deklarit Work With "), DefaultValue(true)]
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

        [Category("Deklarit Work With ")]
        public virtual int FillByIDTIPDOKUMENTAIDTIPDOKUMENTA
        {
            get
            {
                return this.DataGrid.FillByIDTIPDOKUMENTAIDTIPDOKUMENTA;
            }
            set
            {
                this.DataGrid.FillByIDTIPDOKUMENTAIDTIPDOKUMENTA = value;
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


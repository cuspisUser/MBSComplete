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

    public class SMJENEUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with SMJENE";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with SMJENE";
        private SMJENEDataGrid userControlDataGridSMJENE;

        public SMJENEUserDataGrid()
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
            this.userControlDataGridSMJENE = new SMJENEDataGrid();
            ((ISupportInitialize) this.userControlDataGridSMJENE).BeginInit();
            UltraGridBand band = new UltraGridBand("SMJENE", -1);
            UltraGridColumn column = new UltraGridColumn("IDSMJENE");
            UltraGridColumn column2 = new UltraGridColumn("OPISSMJENE");
            UltraGridColumn column3 = new UltraGridColumn("POCETAK");
            UltraGridColumn column4 = new UltraGridColumn("ZAVRSETAK");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.SMJENEIDSMJENEDescription;
            column.Width = 0x33;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.SMJENEOPISSMJENEDescription;
            column2.Width = 0x128;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.SMJENEPOCETAKDescription;
            column3.Width = 100;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.SMJENEZAVRSETAKDescription;
            column4.Width = 0x72;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 2;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 3;
            this.userControlDataGridSMJENE.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridSMJENE.Location = point;
            this.userControlDataGridSMJENE.Name = "userControlDataGridSMJENE";
            this.userControlDataGridSMJENE.Tag = "SMJENE";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridSMJENE.Size = size;
            this.userControlDataGridSMJENE.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridSMJENE.Dock = DockStyle.Fill;
            this.userControlDataGridSMJENE.FillAtStartup = false;
            this.userControlDataGridSMJENE.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridSMJENE.InitializeRow += new InitializeRowEventHandler(this.SMJENEUserDataGrid_InitializeRow);
            this.userControlDataGridSMJENE.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridSMJENE });
            this.Name = "SMJENEUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.SMJENEUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridSMJENE).EndInit();
            this.ResumeLayout(false);
        }

        private void SMJENEUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void SMJENEUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual SMJENEDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridSMJENE;
            }
            set
            {
                this.userControlDataGridSMJENE = value;
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


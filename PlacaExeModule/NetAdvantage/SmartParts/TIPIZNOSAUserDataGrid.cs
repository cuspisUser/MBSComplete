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

    public class TIPIZNOSAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Pregled uplatnih raeuna doprinosa";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Pregled uplatnih raeuna doprinosa";
        private TIPIZNOSADataGrid userControlDataGridTIPIZNOSA;

        public TIPIZNOSAUserDataGrid()
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
            this.userControlDataGridTIPIZNOSA = new TIPIZNOSADataGrid();
            ((ISupportInitialize) this.userControlDataGridTIPIZNOSA).BeginInit();
            UltraGridBand band = new UltraGridBand("TIPIZNOSA", -1);
            UltraGridColumn column = new UltraGridColumn("IDTIPAIZNOSA");
            UltraGridColumn column3 = new UltraGridColumn("OPISTIPAIZNOSA");
            UltraGridColumn column4 = new UltraGridColumn("OZNAKATIPAIZNOSA");
            UltraGridColumn column6 = new UltraGridColumn("VBDITIPAIZNOSA");
            UltraGridColumn column7 = new UltraGridColumn("ZIROTIPAIZNOSA");
            UltraGridColumn column2 = new UltraGridColumn("MOTIPAIZNOSA");
            UltraGridColumn column5 = new UltraGridColumn("POTIPAIZNOSA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.TIPIZNOSAIDTIPAIZNOSADescription;
            column.Width = 0x33;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.TIPIZNOSAOPISTIPAIZNOSADescription;
            column3.Width = 0x128;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.TIPIZNOSAOZNAKATIPAIZNOSADescription;
            column4.Width = 0x56;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.TIPIZNOSAVBDITIPAIZNOSADescription;
            column6.Width = 0x41;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.TIPIZNOSAZIROTIPAIZNOSADescription;
            column7.Width = 0x80;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.TIPIZNOSAMOTIPAIZNOSADescription;
            column2.Width = 0x79;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.TIPIZNOSAPOTIPAIZNOSADescription;
            column5.Width = 0xb1;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 1;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 2;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 3;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 4;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 5;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 6;
            this.userControlDataGridTIPIZNOSA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridTIPIZNOSA.Location = point;
            this.userControlDataGridTIPIZNOSA.Name = "userControlDataGridTIPIZNOSA";
            this.userControlDataGridTIPIZNOSA.Tag = "TIPIZNOSA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridTIPIZNOSA.Size = size;
            this.userControlDataGridTIPIZNOSA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridTIPIZNOSA.Dock = DockStyle.Fill;
            this.userControlDataGridTIPIZNOSA.FillAtStartup = false;
            this.userControlDataGridTIPIZNOSA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridTIPIZNOSA.InitializeRow += new InitializeRowEventHandler(this.TIPIZNOSAUserDataGrid_InitializeRow);
            this.userControlDataGridTIPIZNOSA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridTIPIZNOSA });
            this.Name = "TIPIZNOSAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.TIPIZNOSAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridTIPIZNOSA).EndInit();
            this.ResumeLayout(false);
        }

        private void TIPIZNOSAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void TIPIZNOSAUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual TIPIZNOSADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridTIPIZNOSA;
            }
            set
            {
                this.userControlDataGridTIPIZNOSA = value;
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


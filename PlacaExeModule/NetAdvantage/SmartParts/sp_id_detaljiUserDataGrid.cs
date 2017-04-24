namespace NetAdvantage.SmartParts
{
    using Infragistics.Win;
    using Infragistics.Win.UltraWinGrid;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using NetAdvantage.Controls;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class sp_id_detaljiUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with sp_id_detalji";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with sp_id_detalji";
        private sp_id_detaljiDataGrid userControlDataGridsp_id_detalji;

        public sp_id_detaljiUserDataGrid()
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
            this.userControlDataGridsp_id_detalji = new sp_id_detaljiDataGrid();
            ((ISupportInitialize) this.userControlDataGridsp_id_detalji).BeginInit();
            UltraGridBand band = new UltraGridBand("sp_id_detalji", -1);
            UltraGridColumn column = new UltraGridColumn("ididobrasca");
            UltraGridColumn column7 = new UltraGridColumn("REDNIBROJ");
            UltraGridColumn column2 = new UltraGridColumn("IDOPCINE");
            UltraGridColumn column3 = new UltraGridColumn("NAZIVOPCINE");
            UltraGridColumn column4 = new UltraGridColumn("obracunaniporez");
            UltraGridColumn column5 = new UltraGridColumn("obracunaniprirez");
            UltraGridColumn column6 = new UltraGridColumn("obracunanoukupno");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.sp_id_detaljiididobrascaDescription;
            column.Width = 0x5c;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.sp_id_detaljiREDNIBROJDescription;
            column7.Width = 0x4f;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.sp_id_detaljiIDOPCINEDescription;
            column2.Width = 100;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.sp_id_detaljiNAZIVOPCINEDescription;
            column3.Width = 0x128;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.sp_id_detaljiobracunaniporezDescription;
            column4.Width = 0x7b;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column4.PromptChar = ' ';
            column4.Format = "F2";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.sp_id_detaljiobracunaniprirezDescription;
            column5.Width = 0x81;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column5.PromptChar = ' ';
            column5.Format = "F2";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.sp_id_detaljiobracunanoukupnoDescription;
            column6.Width = 0x81;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column6.PromptChar = ' ';
            column6.Format = "F2";
            column6.CellAppearance = appearance6;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 1;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 2;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 3;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 4;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 5;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 6;
            this.userControlDataGridsp_id_detalji.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridsp_id_detalji.Location = point;
            this.userControlDataGridsp_id_detalji.Name = "userControlDataGridsp_id_detalji";
            this.userControlDataGridsp_id_detalji.Tag = "sp_id_detalji";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridsp_id_detalji.Size = size;
            this.userControlDataGridsp_id_detalji.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridsp_id_detalji.Dock = DockStyle.Fill;
            this.userControlDataGridsp_id_detalji.FillAtStartup = false;
            this.userControlDataGridsp_id_detalji.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridsp_id_detalji.InitializeRow += new InitializeRowEventHandler(this.sp_id_detaljiUserDataGrid_InitializeRow);
            this.userControlDataGridsp_id_detalji.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridsp_id_detalji });
            this.Name = "sp_id_detaljiUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.sp_id_detaljiUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridsp_id_detalji).EndInit();
            this.ResumeLayout(false);
        }

        private void sp_id_detaljiUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void sp_id_detaljiUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual sp_id_detaljiDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridsp_id_detalji;
            }
            set
            {
                this.userControlDataGridsp_id_detalji = value;
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

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string ParametergodinaISPLATE
        {
            get
            {
                return this.DataGrid.ParametergodinaISPLATE;
            }
            set
            {
                this.DataGrid.ParametergodinaISPLATE = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string Parameteridobracun
        {
            get
            {
                return this.DataGrid.Parameteridobracun;
            }
            set
            {
                this.DataGrid.Parameteridobracun = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string ParametermjeseCISPLATE
        {
            get
            {
                return this.DataGrid.ParametermjeseCISPLATE;
            }
            set
            {
                this.DataGrid.ParametermjeseCISPLATE = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual short ParameterVOLONTERI
        {
            get
            {
                return this.DataGrid.ParameterVOLONTERI;
            }
            set
            {
                this.DataGrid.ParameterVOLONTERI = value;
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


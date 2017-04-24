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

    public class S_OD_REKAP_POREZUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with S_OD_REKAP_POREZ";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with S_OD_REKAP_POREZ";
        private S_OD_REKAP_POREZDataGrid userControlDataGridS_OD_REKAP_POREZ;

        public S_OD_REKAP_POREZUserDataGrid()
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
            this.userControlDataGridS_OD_REKAP_POREZ = new S_OD_REKAP_POREZDataGrid();
            ((ISupportInitialize) this.userControlDataGridS_OD_REKAP_POREZ).BeginInit();
            UltraGridBand band = new UltraGridBand("S_OD_REKAP_POREZ", -1);
            UltraGridColumn column5 = new UltraGridColumn("SIFRA");
            UltraGridColumn column6 = new UltraGridColumn("SIFRAOPCINESTANOVANJA");
            UltraGridColumn column = new UltraGridColumn("NAZIVOPCINE");
            UltraGridColumn column2 = new UltraGridColumn("OBRACUNATO");
            UltraGridColumn column7 = new UltraGridColumn("STOPA");
            UltraGridColumn column3 = new UltraGridColumn("OSNOVICa");
            UltraGridColumn column4 = new UltraGridColumn("POREZOPIS");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.S_OD_REKAP_POREZSIFRADescription;
            column5.Width = 0x33;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnnn";
            column5.PromptChar = ' ';
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.S_OD_REKAP_POREZSIFRAOPCINESTANOVANJADescription;
            column6.Width = 100;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.S_OD_REKAP_POREZNAZIVOPCINEDescription;
            column.Width = 0x128;
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.S_OD_REKAP_POREZOBRACUNATODescription;
            column2.Width = 0x66;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column2.PromptChar = ' ';
            column2.Format = "F2";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.S_OD_REKAP_POREZSTOPADescription;
            column7.Width = 0x37;
            appearance7.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnn.nn";
            column7.PromptChar = ' ';
            column7.Format = "F2";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.S_OD_REKAP_POREZOSNOVICaDescription;
            column3.Width = 0x66;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnnn.nn";
            column3.PromptChar = ' ';
            column3.Format = "F2";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.S_OD_REKAP_POREZPOREZOPISDescription;
            column4.Width = 0x128;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 0;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 1;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 2;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 3;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 4;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 5;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 6;
            this.userControlDataGridS_OD_REKAP_POREZ.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_OD_REKAP_POREZ.Location = point;
            this.userControlDataGridS_OD_REKAP_POREZ.Name = "userControlDataGridS_OD_REKAP_POREZ";
            this.userControlDataGridS_OD_REKAP_POREZ.Tag = "S_OD_REKAP_POREZ";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridS_OD_REKAP_POREZ.Size = size;
            this.userControlDataGridS_OD_REKAP_POREZ.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridS_OD_REKAP_POREZ.Dock = DockStyle.Fill;
            this.userControlDataGridS_OD_REKAP_POREZ.FillAtStartup = false;
            this.userControlDataGridS_OD_REKAP_POREZ.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridS_OD_REKAP_POREZ.InitializeRow += new InitializeRowEventHandler(this.S_OD_REKAP_POREZUserDataGrid_InitializeRow);
            this.userControlDataGridS_OD_REKAP_POREZ.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridS_OD_REKAP_POREZ });
            this.Name = "S_OD_REKAP_POREZUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.S_OD_REKAP_POREZUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridS_OD_REKAP_POREZ).EndInit();
            this.ResumeLayout(false);
        }

        private void S_OD_REKAP_POREZUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void S_OD_REKAP_POREZUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual S_OD_REKAP_POREZDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridS_OD_REKAP_POREZ;
            }
            set
            {
                this.userControlDataGridS_OD_REKAP_POREZ = value;
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

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string ParameterIDOBRACUN
        {
            get
            {
                return this.DataGrid.ParameterIDOBRACUN;
            }
            set
            {
                this.DataGrid.ParameterIDOBRACUN = value;
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


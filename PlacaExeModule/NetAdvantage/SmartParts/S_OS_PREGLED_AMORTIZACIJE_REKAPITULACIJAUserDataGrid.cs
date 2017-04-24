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

    public class S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA";
        private S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataGrid userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA;

        public S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJAUserDataGrid()
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
            this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA = new S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataGrid();
            ((ISupportInitialize) this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA).BeginInit();
            UltraGridBand band = new UltraGridBand("S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA", -1);
            UltraGridColumn column10 = new UltraGridColumn("OSOPIS");
            UltraGridColumn column = new UltraGridColumn("IDOSDOKUMENT");
            UltraGridColumn column8 = new UltraGridColumn("OSBROJDOKUMENTA");
            UltraGridColumn column9 = new UltraGridColumn("OSKOLICINA");
            UltraGridColumn column12 = new UltraGridColumn("OSSTOPA");
            UltraGridColumn column11 = new UltraGridColumn("OSOSNOVICA");
            UltraGridColumn column2 = new UltraGridColumn("ISPRAVAK");
            UltraGridColumn column3 = new UltraGridColumn("ISPRAVAKPRETHODNIH");
            UltraGridColumn column6 = new UltraGridColumn("KTONABAVKEIDKONTO");
            UltraGridColumn column4 = new UltraGridColumn("KTOISPRAVKAIDKONTO");
            UltraGridColumn column5 = new UltraGridColumn("KTOIZVORAIDKONTO");
            UltraGridColumn column7 = new UltraGridColumn("NAZIVKONTO");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJAOSOPISDescription;
            column10.Width = 0x128;
            column10.Format = "";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJAIDOSDOKUMENTDescription;
            column.Width = 0x63;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJAOSBROJDOKUMENTADescription;
            column8.Width = 0x77;
            appearance8.TextHAlign = HAlign.Right;
            column8.MaskInput = "{LOC}-nnnnn";
            column8.PromptChar = ' ';
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJAOSKOLICINADescription;
            column9.Width = 0x66;
            appearance9.TextHAlign = HAlign.Right;
            column9.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column9.PromptChar = ' ';
            column9.Format = "F2";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJAOSSTOPADescription;
            column12.Width = 0x45;
            appearance12.TextHAlign = HAlign.Right;
            column12.MaskInput = "{LOC}-nnn.nn";
            column12.PromptChar = ' ';
            column12.Format = "F2";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJAOSOSNOVICADescription;
            column11.Width = 0x66;
            appearance11.TextHAlign = HAlign.Right;
            column11.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column11.PromptChar = ' ';
            column11.Format = "F2";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJAISPRAVAKDescription;
            column2.Width = 0x66;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column2.PromptChar = ' ';
            column2.Format = "F2";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJAISPRAVAKPRETHODNIHDescription;
            column3.Width = 0x8f;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column3.PromptChar = ' ';
            column3.Format = "F2";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJAKTONABAVKEIDKONTODescription;
            column6.Width = 0x72;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJAKTOISPRAVKAIDKONTODescription;
            column4.Width = 0x72;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJAKTOIZVORAIDKONTODescription;
            column5.Width = 0x72;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJANAZIVKONTODescription;
            column7.Width = 0x128;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 0;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 1;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 2;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 3;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 4;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 5;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 6;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 7;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 8;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 9;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 10;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 11;
            this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.Location = point;
            this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.Name = "userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA";
            this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.Tag = "S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.Size = size;
            this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.Dock = DockStyle.Fill;
            this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.FillAtStartup = false;
            this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.InitializeRow += new InitializeRowEventHandler(this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJAUserDataGrid_InitializeRow);
            this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA });
            this.Name = "S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA).EndInit();
            this.ResumeLayout(false);
        }

        private void S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJAUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA;
            }
            set
            {
                this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA = value;
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
        public virtual int Parameterbrojdok
        {
            get
            {
                return this.DataGrid.Parameterbrojdok;
            }
            set
            {
                this.DataGrid.Parameterbrojdok = value;
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


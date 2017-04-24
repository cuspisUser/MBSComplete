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

    public class S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA";
        private S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataGrid userControlDataGridS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA;

        public S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMAUserDataGrid()
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
            this.userControlDataGridS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA = new S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataGrid();
            ((ISupportInitialize) this.userControlDataGridS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA).BeginInit();
            UltraGridBand band = new UltraGridBand("S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA", -1);
            UltraGridColumn column8 = new UltraGridColumn("PREZIME");
            UltraGridColumn column2 = new UltraGridColumn("IME");
            UltraGridColumn column9 = new UltraGridColumn("SIFRAOPCINESTANOVANJA");
            UltraGridColumn column5 = new UltraGridColumn("NAZIVOPCINE");
            UltraGridColumn column3 = new UltraGridColumn("KOREKCIJAPOREZA");
            UltraGridColumn column4 = new UltraGridColumn("KOREKCIJAPRIREZ");
            UltraGridColumn column6 = new UltraGridColumn("ORIGINALPOREZ");
            UltraGridColumn column7 = new UltraGridColumn("ORIGINALPRIREZ");
            UltraGridColumn column = new UltraGridColumn("IDRADNIK");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMAPREZIMEDescription;
            column8.Width = 0x128;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMAIMEDescription;
            column2.Width = 0x128;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASIFRAOPCINESTANOVANJADescription;
            column9.Width = 100;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMANAZIVOPCINEDescription;
            column5.Width = 0x128;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMAKOREKCIJAPOREZADescription;
            column3.Width = 0x7b;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column3.PromptChar = ' ';
            column3.Format = "F2";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMAKOREKCIJAPRIREZDescription;
            column4.Width = 0x7b;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column4.PromptChar = ' ';
            column4.Format = "F2";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMAORIGINALPOREZDescription;
            column6.Width = 0x6d;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column6.PromptChar = ' ';
            column6.Format = "F2";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMAORIGINALPRIREZDescription;
            column7.Width = 0x74;
            appearance7.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column7.PromptChar = ' ';
            column7.Format = "F2";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMAIDRADNIKDescription;
            column.Width = 0x69;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 2;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 3;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 4;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 5;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 6;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 7;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 8;
            this.userControlDataGridS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.Location = point;
            this.userControlDataGridS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.Name = "userControlDataGridS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA";
            this.userControlDataGridS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.Tag = "S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.Size = size;
            this.userControlDataGridS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.Dock = DockStyle.Fill;
            this.userControlDataGridS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.FillAtStartup = false;
            this.userControlDataGridS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.InitializeRow += new InitializeRowEventHandler(this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMAUserDataGrid_InitializeRow);
            this.userControlDataGridS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA });
            this.Name = "S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA).EndInit();
            this.ResumeLayout(false);
        }

        private void S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMAUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA;
            }
            set
            {
                this.userControlDataGridS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA = value;
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

        [DefaultValue(true), Description("True= Fill at Startup. False= Not Fill"), Category("Deklarit Work With ")]
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


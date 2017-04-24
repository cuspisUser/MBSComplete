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

    public class S_PLACA_KONACNI_REKAPOPCINEUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with S_PLACA_KONACNI_REKAPOPCINE";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with S_PLACA_KONACNI_REKAPOPCINE";
        private S_PLACA_KONACNI_REKAPOPCINEDataGrid userControlDataGridS_PLACA_KONACNI_REKAPOPCINE;

        public S_PLACA_KONACNI_REKAPOPCINEUserDataGrid()
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
            this.userControlDataGridS_PLACA_KONACNI_REKAPOPCINE = new S_PLACA_KONACNI_REKAPOPCINEDataGrid();
            ((ISupportInitialize) this.userControlDataGridS_PLACA_KONACNI_REKAPOPCINE).BeginInit();
            UltraGridBand band = new UltraGridBand("S_PLACA_KONACNI_REKAPOPCINE", -1);
            UltraGridColumn column11 = new UltraGridColumn("PRIREZPOREZNA");
            UltraGridColumn column8 = new UltraGridColumn("POREZPOREZNA");
            UltraGridColumn column13 = new UltraGridColumn("SIFRAOPCINESTANOVANJA");
            UltraGridColumn column10 = new UltraGridColumn("PREZIME");
            UltraGridColumn column = new UltraGridColumn("IME");
            UltraGridColumn column14 = new UltraGridColumn("ulica");
            UltraGridColumn column3 = new UltraGridColumn("mjesto");
            UltraGridColumn column2 = new UltraGridColumn("kucnibroj");
            UltraGridColumn column7 = new UltraGridColumn("OIB");
            UltraGridColumn column4 = new UltraGridColumn("NAZIVOPCINE");
            UltraGridColumn column5 = new UltraGridColumn("OBRACUNATIPRIREZ");
            UltraGridColumn column6 = new UltraGridColumn("OBRACUNATOPOREZ");
            UltraGridColumn column9 = new UltraGridColumn("POREZUKUPNOKOREKCIJA");
            UltraGridColumn column12 = new UltraGridColumn("PRIREZUKUPNOKOREKCIJA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.S_PLACA_KONACNI_REKAPOPCINEPRIREZPOREZNADescription;
            column11.Width = 0x6d;
            appearance11.TextHAlign = HAlign.Right;
            column11.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column11.PromptChar = ' ';
            column11.Format = "F2";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.S_PLACA_KONACNI_REKAPOPCINEPOREZPOREZNADescription;
            column8.Width = 0x66;
            appearance8.TextHAlign = HAlign.Right;
            column8.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column8.PromptChar = ' ';
            column8.Format = "F2";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.S_PLACA_KONACNI_REKAPOPCINESIFRAOPCINESTANOVANJADescription;
            column13.Width = 100;
            column13.Format = "";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.S_PLACA_KONACNI_REKAPOPCINEPREZIMEDescription;
            column10.Width = 0x128;
            column10.Format = "";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.S_PLACA_KONACNI_REKAPOPCINEIMEDescription;
            column.Width = 0x128;
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.S_PLACA_KONACNI_REKAPOPCINEulicaDescription;
            column14.Width = 0x128;
            column14.Format = "";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.S_PLACA_KONACNI_REKAPOPCINEmjestoDescription;
            column3.Width = 0x128;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.S_PLACA_KONACNI_REKAPOPCINEkucnibrojDescription;
            column2.Width = 0x56;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.S_PLACA_KONACNI_REKAPOPCINEOIBDescription;
            column7.Width = 0x5d;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.S_PLACA_KONACNI_REKAPOPCINENAZIVOPCINEDescription;
            column4.Width = 0x128;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.S_PLACA_KONACNI_REKAPOPCINEOBRACUNATIPRIREZDescription;
            column5.Width = 0x81;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column5.PromptChar = ' ';
            column5.Format = "F2";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.S_PLACA_KONACNI_REKAPOPCINEOBRACUNATOPOREZDescription;
            column6.Width = 0x7b;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column6.PromptChar = ' ';
            column6.Format = "F2";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.S_PLACA_KONACNI_REKAPOPCINEPOREZUKUPNOKOREKCIJADescription;
            column9.Width = 0x9c;
            appearance9.TextHAlign = HAlign.Right;
            column9.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column9.PromptChar = ' ';
            column9.Format = "F2";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.S_PLACA_KONACNI_REKAPOPCINEPRIREZUKUPNOKOREKCIJADescription;
            column12.Width = 0xa3;
            appearance12.TextHAlign = HAlign.Right;
            column12.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column12.PromptChar = ' ';
            column12.Format = "F2";
            column12.CellAppearance = appearance12;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 0;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 1;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 2;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 3;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 4;
            band.Columns.Add(column14);
            column14.Header.VisiblePosition = 5;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 6;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 7;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 8;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 9;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 10;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 11;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 12;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 13;
            this.userControlDataGridS_PLACA_KONACNI_REKAPOPCINE.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_PLACA_KONACNI_REKAPOPCINE.Location = point;
            this.userControlDataGridS_PLACA_KONACNI_REKAPOPCINE.Name = "userControlDataGridS_PLACA_KONACNI_REKAPOPCINE";
            this.userControlDataGridS_PLACA_KONACNI_REKAPOPCINE.Tag = "S_PLACA_KONACNI_REKAPOPCINE";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridS_PLACA_KONACNI_REKAPOPCINE.Size = size;
            this.userControlDataGridS_PLACA_KONACNI_REKAPOPCINE.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridS_PLACA_KONACNI_REKAPOPCINE.Dock = DockStyle.Fill;
            this.userControlDataGridS_PLACA_KONACNI_REKAPOPCINE.FillAtStartup = false;
            this.userControlDataGridS_PLACA_KONACNI_REKAPOPCINE.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridS_PLACA_KONACNI_REKAPOPCINE.InitializeRow += new InitializeRowEventHandler(this.S_PLACA_KONACNI_REKAPOPCINEUserDataGrid_InitializeRow);
            this.userControlDataGridS_PLACA_KONACNI_REKAPOPCINE.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridS_PLACA_KONACNI_REKAPOPCINE });
            this.Name = "S_PLACA_KONACNI_REKAPOPCINEUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.S_PLACA_KONACNI_REKAPOPCINEUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridS_PLACA_KONACNI_REKAPOPCINE).EndInit();
            this.ResumeLayout(false);
        }

        private void S_PLACA_KONACNI_REKAPOPCINEUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void S_PLACA_KONACNI_REKAPOPCINEUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual S_PLACA_KONACNI_REKAPOPCINEDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridS_PLACA_KONACNI_REKAPOPCINE;
            }
            set
            {
                this.userControlDataGridS_PLACA_KONACNI_REKAPOPCINE = value;
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


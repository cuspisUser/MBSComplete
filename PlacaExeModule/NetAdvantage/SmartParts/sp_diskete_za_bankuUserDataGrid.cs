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

    public class sp_diskete_za_bankuUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with sp_diskete_za_banku";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with sp_diskete_za_banku";
        private sp_diskete_za_bankuDataGrid userControlDataGridsp_diskete_za_banku;

        public sp_diskete_za_bankuUserDataGrid()
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
            this.userControlDataGridsp_diskete_za_banku = new sp_diskete_za_bankuDataGrid();
            ((ISupportInitialize) this.userControlDataGridsp_diskete_za_banku).BeginInit();
            UltraGridBand band = new UltraGridBand("sp_diskete_za_banku", -1);
            UltraGridColumn column = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column6 = new UltraGridColumn("PREZIME");
            UltraGridColumn column2 = new UltraGridColumn("IME");
            UltraGridColumn column3 = new UltraGridColumn("JMBG");
            UltraGridColumn column8 = new UltraGridColumn("TEKUCI");
            UltraGridColumn column7 = new UltraGridColumn("SIFRAOPISAPLACANJANETO");
            UltraGridColumn column5 = new UltraGridColumn("OPISPLACANJANETO");
            UltraGridColumn column10 = new UltraGridColumn("VBDIBANKE");
            UltraGridColumn column11 = new UltraGridColumn("ZRNBANKE");
            UltraGridColumn column9 = new UltraGridColumn("UKUPNOZAISPLATU");
            UltraGridColumn column4 = new UltraGridColumn("NAZIVBANKE1");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.sp_diskete_za_bankuIDRADNIKDescription;
            column.Width = 0x69;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.sp_diskete_za_bankuPREZIMEDescription;
            column6.Width = 0x128;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.sp_diskete_za_bankuIMEDescription;
            column2.Width = 0x128;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.sp_diskete_za_bankuJMBGDescription;
            column3.Width = 0x6b;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.sp_diskete_za_bankuTEKUCIDescription;
            column8.Width = 100;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.sp_diskete_za_bankuSIFRAOPISAPLACANJANETODescription;
            column7.Width = 0x121;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.sp_diskete_za_bankuOPISPLACANJANETODescription;
            column5.Width = 0x10c;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.sp_diskete_za_bankuVBDIBANKEDescription;
            column10.Width = 170;
            column10.Format = "";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.sp_diskete_za_bankuZRNBANKEDescription;
            column11.Width = 170;
            column11.Format = "";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.sp_diskete_za_bankuUKUPNOZAISPLATUDescription;
            column9.Width = 0x7b;
            appearance9.TextHAlign = HAlign.Right;
            column9.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column9.PromptChar = ' ';
            column9.Format = "F2";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.sp_diskete_za_bankuNAZIVBANKE1Description;
            column4.Width = 0x9c;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 1;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 2;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 3;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 4;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 5;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 6;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 7;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 8;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 9;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 10;
            this.userControlDataGridsp_diskete_za_banku.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridsp_diskete_za_banku.Location = point;
            this.userControlDataGridsp_diskete_za_banku.Name = "userControlDataGridsp_diskete_za_banku";
            this.userControlDataGridsp_diskete_za_banku.Tag = "sp_diskete_za_banku";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridsp_diskete_za_banku.Size = size;
            this.userControlDataGridsp_diskete_za_banku.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridsp_diskete_za_banku.Dock = DockStyle.Fill;
            this.userControlDataGridsp_diskete_za_banku.FillAtStartup = false;
            this.userControlDataGridsp_diskete_za_banku.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridsp_diskete_za_banku.InitializeRow += new InitializeRowEventHandler(this.sp_diskete_za_bankuUserDataGrid_InitializeRow);
            this.userControlDataGridsp_diskete_za_banku.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridsp_diskete_za_banku });
            this.Name = "sp_diskete_za_bankuUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.sp_diskete_za_bankuUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridsp_diskete_za_banku).EndInit();
            this.ResumeLayout(false);
        }

        private void sp_diskete_za_bankuUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void sp_diskete_za_bankuUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual sp_diskete_za_bankuDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridsp_diskete_za_banku;
            }
            set
            {
                this.userControlDataGridsp_diskete_za_banku = value;
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
        public virtual string Parametervbdibanke
        {
            get
            {
                return this.DataGrid.Parametervbdibanke;
            }
            set
            {
                this.DataGrid.Parametervbdibanke = value;
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


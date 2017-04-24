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

    public class S_OD_REKAP_ISPLATAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with S_OD_REKAP_ISPLATA";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with S_OD_REKAP_ISPLATA";
        private S_OD_REKAP_ISPLATADataGrid userControlDataGridS_OD_REKAP_ISPLATA;

        public S_OD_REKAP_ISPLATAUserDataGrid()
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
            this.userControlDataGridS_OD_REKAP_ISPLATA = new S_OD_REKAP_ISPLATADataGrid();
            ((ISupportInitialize) this.userControlDataGridS_OD_REKAP_ISPLATA).BeginInit();
            UltraGridBand band = new UltraGridBand("S_OD_REKAP_ISPLATA", -1);
            UltraGridColumn column2 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column7 = new UltraGridColumn("PREZIME");
            UltraGridColumn column3 = new UltraGridColumn("IME");
            UltraGridColumn column4 = new UltraGridColumn("JMBG");
            UltraGridColumn column8 = new UltraGridColumn("TEKUCI");
            UltraGridColumn column11 = new UltraGridColumn("ZBIRNINETO");
            UltraGridColumn column10 = new UltraGridColumn("VBDIBANKE");
            UltraGridColumn column12 = new UltraGridColumn("ZRNBANKE");
            UltraGridColumn column = new UltraGridColumn("IDBANKE");
            UltraGridColumn column5 = new UltraGridColumn("NAZIVBANKE1");
            UltraGridColumn column6 = new UltraGridColumn("NAZIVBANKE2");
            UltraGridColumn column9 = new UltraGridColumn("UKUPNOZAISPLATU");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.S_OD_REKAP_ISPLATAIDRADNIKDescription;
            column2.Width = 0x69;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnnnnn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.S_OD_REKAP_ISPLATAPREZIMEDescription;
            column7.Width = 0x128;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.S_OD_REKAP_ISPLATAIMEDescription;
            column3.Width = 0x128;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.S_OD_REKAP_ISPLATAJMBGDescription;
            column4.Width = 0x6b;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.S_OD_REKAP_ISPLATATEKUCIDescription;
            column8.Width = 100;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.S_OD_REKAP_ISPLATAZBIRNINETODescription;
            column11.Width = 170;
            column11.Format = "";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.S_OD_REKAP_ISPLATAVBDIBANKEDescription;
            column10.Width = 170;
            column10.Format = "";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.S_OD_REKAP_ISPLATAZRNBANKEDescription;
            column12.Width = 170;
            column12.Format = "";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.S_OD_REKAP_ISPLATAIDBANKEDescription;
            column.Width = 0x5c;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.S_OD_REKAP_ISPLATANAZIVBANKE1Description;
            column5.Width = 0x9c;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.S_OD_REKAP_ISPLATANAZIVBANKE2Description;
            column6.Width = 0x9c;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.S_OD_REKAP_ISPLATAUKUPNOZAISPLATUDescription;
            column9.Width = 0x7b;
            appearance9.TextHAlign = HAlign.Right;
            column9.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column9.PromptChar = ' ';
            column9.Format = "F2";
            column9.CellAppearance = appearance9;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 0;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 1;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 2;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 3;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 4;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 5;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 6;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 7;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 8;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 9;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 10;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 11;
            this.userControlDataGridS_OD_REKAP_ISPLATA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_OD_REKAP_ISPLATA.Location = point;
            this.userControlDataGridS_OD_REKAP_ISPLATA.Name = "userControlDataGridS_OD_REKAP_ISPLATA";
            this.userControlDataGridS_OD_REKAP_ISPLATA.Tag = "S_OD_REKAP_ISPLATA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridS_OD_REKAP_ISPLATA.Size = size;
            this.userControlDataGridS_OD_REKAP_ISPLATA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridS_OD_REKAP_ISPLATA.Dock = DockStyle.Fill;
            this.userControlDataGridS_OD_REKAP_ISPLATA.FillAtStartup = false;
            this.userControlDataGridS_OD_REKAP_ISPLATA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridS_OD_REKAP_ISPLATA.InitializeRow += new InitializeRowEventHandler(this.S_OD_REKAP_ISPLATAUserDataGrid_InitializeRow);
            this.userControlDataGridS_OD_REKAP_ISPLATA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridS_OD_REKAP_ISPLATA });
            this.Name = "S_OD_REKAP_ISPLATAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.S_OD_REKAP_ISPLATAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridS_OD_REKAP_ISPLATA).EndInit();
            this.ResumeLayout(false);
        }

        private void S_OD_REKAP_ISPLATAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void S_OD_REKAP_ISPLATAUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual S_OD_REKAP_ISPLATADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridS_OD_REKAP_ISPLATA;
            }
            set
            {
                this.userControlDataGridS_OD_REKAP_ISPLATA = value;
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


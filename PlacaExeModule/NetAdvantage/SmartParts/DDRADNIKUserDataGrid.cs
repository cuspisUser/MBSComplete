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

    public class DDRADNIKUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Primatelji DD";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Primatelji DD";
        private DDRADNIKDataGrid userControlDataGridDDRADNIK;

        public DDRADNIKUserDataGrid()
        {
            this.InitializeComponent();
        }

        private void DDRADNIKUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void DDRADNIKUserDataGrid_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode && this.FillAtStartup)
            {
                this.DataGrid.Fill();
            }
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
            this.userControlDataGridDDRADNIK = new DDRADNIKDataGrid();
            ((ISupportInitialize) this.userControlDataGridDDRADNIK).BeginInit();
            UltraGridBand band = new UltraGridBand("DDRADNIK", -1);
            UltraGridColumn column3 = new UltraGridColumn("DDIDRADNIK");
            UltraGridColumn column5 = new UltraGridColumn("DDJMBG");
            UltraGridColumn column9 = new UltraGridColumn("DDOIB");
            UltraGridColumn column13 = new UltraGridColumn("DDPREZIME");
            UltraGridColumn column4 = new UltraGridColumn("DDIME");
            UltraGridColumn column = new UltraGridColumn("DDADRESA");
            UltraGridColumn column6 = new UltraGridColumn("DDKUCNIBROJ");
            UltraGridColumn column7 = new UltraGridColumn("DDMJESTO");
            UltraGridColumn column16 = new UltraGridColumn("DDZRN");
            UltraGridColumn column17 = new UltraGridColumn("IDBANKE");
            UltraGridColumn column18 = new UltraGridColumn("NAZIVBANKE1");
            UltraGridColumn column19 = new UltraGridColumn("NAZIVBANKE2");
            UltraGridColumn column20 = new UltraGridColumn("NAZIVBANKE3");
            UltraGridColumn column28 = new UltraGridColumn("VBDIBANKE");
            UltraGridColumn column29 = new UltraGridColumn("ZRNBANKE");
            UltraGridColumn column21 = new UltraGridColumn("OPCINARADAIDOPCINE");
            UltraGridColumn column22 = new UltraGridColumn("OPCINARADANAZIVOPCINE");
            UltraGridColumn column23 = new UltraGridColumn("OPCINASTANOVANJAIDOPCINE");
            UltraGridColumn column24 = new UltraGridColumn("OPCINASTANOVANJANAZIVOPCINE");
            UltraGridColumn column25 = new UltraGridColumn("OPCINASTANOVANJAPRIREZ");
            UltraGridColumn column26 = new UltraGridColumn("OPCINASTANOVANJAVBDIOPCINA");
            UltraGridColumn column27 = new UltraGridColumn("OPCINASTANOVANJAZRNOPCINA");
            UltraGridColumn column14 = new UltraGridColumn("DDSIFRAOPISAPLACANJANETO");
            UltraGridColumn column10 = new UltraGridColumn("DDOPISPLACANJANETO");
            UltraGridColumn column12 = new UltraGridColumn("DDPDVOBVEZNIK");
            UltraGridColumn column2 = new UltraGridColumn("DDDRUGISTUP");
            UltraGridColumn column15 = new UltraGridColumn("DDZBIRNINETO");
            UltraGridColumn column8 = new UltraGridColumn("DDMO");
            UltraGridColumn column11 = new UltraGridColumn("DDPBO");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.DDRADNIKDDIDRADNIKDescription;
            column3.Width = 0x33;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnn";
            column3.PromptChar = ' ';
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.DDRADNIKDDJMBGDescription;
            column5.Width = 0x6b;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.DDRADNIKDDOIBDescription;
            column9.Width = 0x5d;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.DDRADNIKDDPREZIMEDescription;
            column13.Width = 0x128;
            column13.Format = "";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.DDRADNIKDDIMEDescription;
            column4.Width = 0x128;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.DDRADNIKDDADRESADescription;
            column.Width = 0x128;
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.DDRADNIKDDKUCNIBROJDescription;
            column6.Width = 0x56;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.DDRADNIKDDMJESTODescription;
            column7.Width = 0x128;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.DDRADNIKDDZRNDescription;
            column16.Width = 0x56;
            column16.Format = "";
            column16.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.NoEdit;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.DDRADNIKIDBANKEDescription;
            column17.Width = 0x4e;
            appearance17.TextHAlign = HAlign.Right;
            column17.MaskInput = "{LOC}-nnnnn";
            column17.PromptChar = ' ';
            column17.Format = "";
            column17.CellAppearance = appearance17;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column18.CellActivation = Activation.NoEdit;
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.DDRADNIKNAZIVBANKE1Description;
            column18.Width = 0x9c;
            column18.Format = "";
            column18.CellAppearance = appearance18;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column19.CellActivation = Activation.NoEdit;
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.DDRADNIKNAZIVBANKE2Description;
            column19.Width = 0x9c;
            column19.Format = "";
            column19.CellAppearance = appearance19;
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            column20.CellActivation = Activation.NoEdit;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.DDRADNIKNAZIVBANKE3Description;
            column20.Width = 0x9c;
            column20.Format = "";
            column20.CellAppearance = appearance20;
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            column28.CellActivation = Activation.NoEdit;
            column28.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column28.Header.Caption = StringResources.DDRADNIKVBDIBANKEDescription;
            column28.Width = 170;
            column28.Format = "";
            column28.CellAppearance = appearance28;
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            column29.CellActivation = Activation.NoEdit;
            column29.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column29.Header.Caption = StringResources.DDRADNIKZRNBANKEDescription;
            column29.Width = 170;
            column29.Format = "";
            column29.CellAppearance = appearance29;
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            column21.CellActivation = Activation.NoEdit;
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.DDRADNIKOPCINARADAIDOPCINEDescription;
            column21.Width = 0x87;
            column21.Format = "";
            column21.CellAppearance = appearance21;
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            column22.CellActivation = Activation.NoEdit;
            column22.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column22.Header.Caption = StringResources.DDRADNIKOPCINARADANAZIVOPCINEDescription;
            column22.Width = 0x128;
            column22.Format = "";
            column22.CellAppearance = appearance22;
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            column23.CellActivation = Activation.NoEdit;
            column23.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column23.Header.Caption = StringResources.DDRADNIKOPCINASTANOVANJAIDOPCINEDescription;
            column23.Width = 0xb1;
            column23.Format = "";
            column23.CellAppearance = appearance23;
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            column24.CellActivation = Activation.NoEdit;
            column24.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column24.Header.Caption = StringResources.DDRADNIKOPCINASTANOVANJANAZIVOPCINEDescription;
            column24.Width = 0x128;
            column24.Format = "";
            column24.CellAppearance = appearance24;
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            column25.CellActivation = Activation.NoEdit;
            column25.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column25.Header.Caption = StringResources.DDRADNIKOPCINASTANOVANJAPRIREZDescription;
            column25.Width = 0xb7;
            appearance25.TextHAlign = HAlign.Right;
            column25.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column25.PromptChar = ' ';
            column25.Format = "F2";
            column25.CellAppearance = appearance25;
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            column26.CellActivation = Activation.NoEdit;
            column26.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column26.Header.Caption = StringResources.DDRADNIKOPCINASTANOVANJAVBDIOPCINADescription;
            column26.Width = 0xfe;
            column26.Format = "";
            column26.CellAppearance = appearance26;
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            column27.CellActivation = Activation.NoEdit;
            column27.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column27.Header.Caption = StringResources.DDRADNIKOPCINASTANOVANJAZRNOPCINADescription;
            column27.Width = 0xfe;
            column27.Format = "";
            column27.CellAppearance = appearance27;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.DDRADNIKDDSIFRAOPISAPLACANJANETODescription;
            column14.Width = 0x9c;
            column14.Format = "";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.DDRADNIKDDOPISPLACANJANETODescription;
            column10.Width = 0x10c;
            column10.Format = "";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.DDRADNIKDDPDVOBVEZNIKDescription;
            column12.Width = 0x72;
            column12.Format = "";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.DDRADNIKDDDRUGISTUPDescription;
            column2.Width = 0x4f;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.DDRADNIKDDZBIRNINETODescription;
            column15.Width = 0x5d;
            column15.Format = "";
            column15.CellAppearance = appearance15;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.DDRADNIKDDMODescription;
            column8.Width = 0x11a;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.DDRADNIKDDPBODescription;
            column11.Width = 0x128;
            column11.Format = "";
            column11.CellAppearance = appearance11;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 0;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 1;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 2;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 3;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 4;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 5;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 6;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 7;
            band.Columns.Add(column16);
            column16.Header.VisiblePosition = 8;
            band.Columns.Add(column17);
            column17.Header.VisiblePosition = 9;
            band.Columns.Add(column18);
            column18.Header.VisiblePosition = 10;
            band.Columns.Add(column19);
            column19.Header.VisiblePosition = 11;
            band.Columns.Add(column20);
            column20.Header.VisiblePosition = 12;
            band.Columns.Add(column28);
            column28.Header.VisiblePosition = 13;
            band.Columns.Add(column29);
            column29.Header.VisiblePosition = 14;
            band.Columns.Add(column21);
            column21.Header.VisiblePosition = 15;
            band.Columns.Add(column22);
            column22.Header.VisiblePosition = 0x10;
            band.Columns.Add(column23);
            column23.Header.VisiblePosition = 0x11;
            band.Columns.Add(column24);
            column24.Header.VisiblePosition = 0x12;
            band.Columns.Add(column25);
            column25.Header.VisiblePosition = 0x13;
            band.Columns.Add(column26);
            column26.Header.VisiblePosition = 20;
            band.Columns.Add(column27);
            column27.Header.VisiblePosition = 0x15;
            band.Columns.Add(column14);
            column14.Header.VisiblePosition = 0x16;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 0x17;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 0x18;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 0x19;
            band.Columns.Add(column15);
            column15.Header.VisiblePosition = 0x1a;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 0x1b;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 0x1c;
            this.userControlDataGridDDRADNIK.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridDDRADNIK.Location = point;
            this.userControlDataGridDDRADNIK.Name = "userControlDataGridDDRADNIK";
            this.userControlDataGridDDRADNIK.Tag = "DDRADNIK";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridDDRADNIK.Size = size;
            this.userControlDataGridDDRADNIK.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridDDRADNIK.Dock = DockStyle.Fill;
            this.userControlDataGridDDRADNIK.FillAtStartup = false;
            this.userControlDataGridDDRADNIK.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridDDRADNIK.InitializeRow += new InitializeRowEventHandler(this.DDRADNIKUserDataGrid_InitializeRow);
            this.userControlDataGridDDRADNIK.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridDDRADNIK });
            this.Name = "DDRADNIKUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.DDRADNIKUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridDDRADNIK).EndInit();
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
        public virtual DDRADNIKDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridDDRADNIK;
            }
            set
            {
                this.userControlDataGridDDRADNIK = value;
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

        [Category("Deklarit Work With ")]
        public virtual int FillByIDBANKEIDBANKE
        {
            get
            {
                return this.DataGrid.FillByIDBANKEIDBANKE;
            }
            set
            {
                this.DataGrid.FillByIDBANKEIDBANKE = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual string FillByOPCINARADAIDOPCINEOPCINARADAIDOPCINE
        {
            get
            {
                return this.DataGrid.FillByOPCINARADAIDOPCINEOPCINARADAIDOPCINE;
            }
            set
            {
                this.DataGrid.FillByOPCINARADAIDOPCINEOPCINARADAIDOPCINE = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual string FillByOPCINASTANOVANJAIDOPCINEOPCINASTANOVANJAIDOPCINE
        {
            get
            {
                return this.DataGrid.FillByOPCINASTANOVANJAIDOPCINEOPCINASTANOVANJAIDOPCINE;
            }
            set
            {
                this.DataGrid.FillByOPCINASTANOVANJAIDOPCINEOPCINASTANOVANJAIDOPCINE = value;
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

        [DefaultValue("Fill"), TypeConverter(typeof(DeklaritDataGrid.FillMethodsConverter)), Category("Deklarit Work With ")]
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


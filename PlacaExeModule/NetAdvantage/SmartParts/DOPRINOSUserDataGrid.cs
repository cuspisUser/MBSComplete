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

    public class DOPRINOSUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Doprinosi";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Doprinosi";
        private DOPRINOSDataGrid userControlDataGridDOPRINOS;

        public DOPRINOSUserDataGrid()
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

        private void DOPRINOSUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void DOPRINOSUserDataGrid_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode && this.FillAtStartup)
            {
                this.DataGrid.Fill();
            }
        }

        public void Fill()
        {
            this.DataGrid.Fill();
        }

        private void InitializeComponent()
        {
            this.userControlDataGridDOPRINOS = new DOPRINOSDataGrid();
            ((ISupportInitialize) this.userControlDataGridDOPRINOS).BeginInit();
            UltraGridBand band = new UltraGridBand("DOPRINOS", -1);
            UltraGridColumn column = new UltraGridColumn("IDDOPRINOS");
            UltraGridColumn column7 = new UltraGridColumn("NAZIVDOPRINOS");
            UltraGridColumn column2 = new UltraGridColumn("IDVRSTADOPRINOS");
            UltraGridColumn column8 = new UltraGridColumn("NAZIVVRSTADOPRINOS");
            UltraGridColumn column15 = new UltraGridColumn("STOPA");
            UltraGridColumn column5 = new UltraGridColumn("MODOPRINOS");
            UltraGridColumn column10 = new UltraGridColumn("PODOPRINOS");
            UltraGridColumn column6 = new UltraGridColumn("MZDOPRINOS");
            UltraGridColumn column13 = new UltraGridColumn("PZDOPRINOS");
            UltraGridColumn column11 = new UltraGridColumn("PRIMATELJDOPRINOS1");
            UltraGridColumn column12 = new UltraGridColumn("PRIMATELJDOPRINOS2");
            UltraGridColumn column14 = new UltraGridColumn("SIFRAOPISAPLACANJADOPRINOS");
            UltraGridColumn column9 = new UltraGridColumn("OPISPLACANJADOPRINOS");
            UltraGridColumn column16 = new UltraGridColumn("VBDIDOPRINOS");
            UltraGridColumn column17 = new UltraGridColumn("ZRNDOPRINOS");
            UltraGridColumn column4 = new UltraGridColumn("MINDOPRINOS");
            UltraGridColumn column3 = new UltraGridColumn("MAXDOPRINOS");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.DOPRINOSIDDOPRINOSDescription;
            column.Width = 0x77;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.DOPRINOSNAZIVDOPRINOSDescription;
            column7.Width = 0x128;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.DOPRINOSIDVRSTADOPRINOSDescription;
            column2.Width = 0x9f;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.DOPRINOSNAZIVVRSTADOPRINOSDescription;
            column8.Width = 0x128;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.DOPRINOSSTOPADescription;
            column15.Width = 0x37;
            appearance15.TextHAlign = HAlign.Right;
            column15.MaskInput = "{LOC}-nnn.nn";
            column15.PromptChar = ' ';
            column15.Format = "F2";
            column15.CellAppearance = appearance15;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.DOPRINOSMODOPRINOSDescription;
            column5.Width = 0xbf;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.DOPRINOSPODOPRINOSDescription;
            column10.Width = 0xbf;
            column10.Format = "";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.DOPRINOSMZDOPRINOSDescription;
            column6.Width = 0xbf;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.DOPRINOSPZDOPRINOSDescription;
            column13.Width = 0xbf;
            column13.Format = "";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.DOPRINOSPRIMATELJDOPRINOS1Description;
            column11.Width = 0x9c;
            column11.Format = "";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.DOPRINOSPRIMATELJDOPRINOS2Description;
            column12.Width = 0xb1;
            column12.Format = "";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.DOPRINOSSIFRAOPISAPLACANJADOPRINOSDescription;
            column14.Width = 0xe2;
            column14.Format = "";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.DOPRINOSOPISPLACANJADOPRINOSDescription;
            column9.Width = 0x10c;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.DOPRINOSVBDIDOPRINOSDescription;
            column16.Width = 0x41;
            column16.Format = "";
            column16.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.NoEdit;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.DOPRINOSZRNDOPRINOSDescription;
            column17.Width = 0x56;
            column17.Format = "";
            column17.CellAppearance = appearance17;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.DOPRINOSMINDOPRINOSDescription;
            column4.Width = 0xfb;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column4.PromptChar = ' ';
            column4.Format = "F2";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.DOPRINOSMAXDOPRINOSDescription;
            column3.Width = 0x102;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column3.PromptChar = ' ';
            column3.Format = "F2";
            column3.CellAppearance = appearance3;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 1;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 2;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 3;
            band.Columns.Add(column15);
            column15.Header.VisiblePosition = 4;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 5;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 6;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 7;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 8;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 9;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 10;
            band.Columns.Add(column14);
            column14.Header.VisiblePosition = 11;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 12;
            band.Columns.Add(column16);
            column16.Header.VisiblePosition = 13;
            band.Columns.Add(column17);
            column17.Header.VisiblePosition = 14;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 15;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 0x10;
            this.userControlDataGridDOPRINOS.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridDOPRINOS.Location = point;
            this.userControlDataGridDOPRINOS.Name = "userControlDataGridDOPRINOS";
            this.userControlDataGridDOPRINOS.Tag = "DOPRINOS";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridDOPRINOS.Size = size;
            this.userControlDataGridDOPRINOS.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridDOPRINOS.Dock = DockStyle.Fill;
            this.userControlDataGridDOPRINOS.FillAtStartup = false;
            this.userControlDataGridDOPRINOS.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridDOPRINOS.InitializeRow += new InitializeRowEventHandler(this.DOPRINOSUserDataGrid_InitializeRow);
            this.userControlDataGridDOPRINOS.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridDOPRINOS });
            this.Name = "DOPRINOSUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.DOPRINOSUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridDOPRINOS).EndInit();
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
        public virtual DOPRINOSDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridDOPRINOS;
            }
            set
            {
                this.userControlDataGridDOPRINOS = value;
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
        public virtual int FillByIDVRSTADOPRINOSIDVRSTADOPRINOS
        {
            get
            {
                return this.DataGrid.FillByIDVRSTADOPRINOSIDVRSTADOPRINOS;
            }
            set
            {
                this.DataGrid.FillByIDVRSTADOPRINOSIDVRSTADOPRINOS = value;
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

        [Category("Deklarit Work With "), DefaultValue("Fill"), TypeConverter(typeof(DeklaritDataGrid.FillMethodsConverter))]
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


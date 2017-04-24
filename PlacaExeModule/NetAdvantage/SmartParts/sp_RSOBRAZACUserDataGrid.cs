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

    public class sp_RSOBRAZACUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with sp_RSOBRAZAC";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with sp_RSOBRAZAC";
        private sp_RSOBRAZACDataGrid userControlDataGridsp_RSOBRAZAC;

        public sp_RSOBRAZACUserDataGrid()
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
            this.userControlDataGridsp_RSOBRAZAC = new sp_RSOBRAZACDataGrid();
            ((ISupportInitialize) this.userControlDataGridsp_RSOBRAZAC).BeginInit();
            UltraGridBand band = new UltraGridBand("sp_RSOBRAZAC", -1);
            UltraGridColumn column17 = new UltraGridColumn("REDNIBROJ");
            UltraGridColumn column5 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column16 = new UltraGridColumn("PREZIMEIIME");
            UltraGridColumn column9 = new UltraGridColumn("MBGOSIGURANIKA");
            UltraGridColumn column18 = new UltraGridColumn("SIFRAGRADARADA");
            UltraGridColumn column14 = new UltraGridColumn("OO");
            UltraGridColumn column = new UltraGridColumn("B");
            UltraGridColumn column12 = new UltraGridColumn("OD");
            UltraGridColumn column2 = new UltraGridColumn("DOO");
            UltraGridColumn column7 = new UltraGridColumn("IZNOSOBRACUNANEPLACERSMB");
            UltraGridColumn column8 = new UltraGridColumn("IZNOSOSNOVICEZADOPRINOSERSMB");
            UltraGridColumn column3 = new UltraGridColumn("IDDOPRINOSMIO1");
            UltraGridColumn column19 = new UltraGridColumn("STOPAMIO1");
            UltraGridColumn column10 = new UltraGridColumn("MIO1RSMB");
            UltraGridColumn column4 = new UltraGridColumn("IDDOPRINOSMIO2");
            UltraGridColumn column20 = new UltraGridColumn("STOPAMIO2");
            UltraGridColumn column11 = new UltraGridColumn("MIO2RSMB");
            UltraGridColumn column15 = new UltraGridColumn("POREZIPRIREZ");
            UltraGridColumn column6 = new UltraGridColumn("IZNOSISPLACENEPLACERSMB");
            UltraGridColumn column13 = new UltraGridColumn("OIB");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.NoEdit;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.sp_RSOBRAZACREDNIBROJDescription;
            column17.Width = 0x4f;
            column17.Format = "";
            column17.CellAppearance = appearance17;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.sp_RSOBRAZACIDRADNIKDescription;
            column5.Width = 0x69;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnnnnnn";
            column5.PromptChar = ' ';
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.sp_RSOBRAZACPREZIMEIIMEDescription;
            column16.Width = 0x128;
            column16.Format = "";
            column16.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.sp_RSOBRAZACMBGOSIGURANIKADescription;
            column9.Width = 0x72;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column18.CellActivation = Activation.NoEdit;
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.sp_RSOBRAZACSIFRAGRADARADADescription;
            column18.Width = 0x72;
            column18.Format = "";
            column18.CellAppearance = appearance18;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.sp_RSOBRAZACOODescription;
            column14.Width = 30;
            column14.Format = "";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.sp_RSOBRAZACBDescription;
            column.Width = 0x17;
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.sp_RSOBRAZACODDescription;
            column12.Width = 30;
            column12.Format = "";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.sp_RSOBRAZACDOODescription;
            column2.Width = 0x25;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.sp_RSOBRAZACIZNOSOBRACUNANEPLACERSMBDescription;
            column7.Width = 0xb7;
            appearance7.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column7.PromptChar = ' ';
            column7.Format = "F2";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.sp_RSOBRAZACIZNOSOSNOVICEZADOPRINOSERSMBDescription;
            column8.Width = 210;
            appearance8.TextHAlign = HAlign.Right;
            column8.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column8.PromptChar = ' ';
            column8.Format = "F2";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.sp_RSOBRAZACIDDOPRINOSMIO1Description;
            column3.Width = 0x77;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnn";
            column3.PromptChar = ' ';
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column19.CellActivation = Activation.NoEdit;
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.sp_RSOBRAZACSTOPAMIO1Description;
            column19.Width = 0x59;
            appearance19.TextHAlign = HAlign.Right;
            column19.MaskInput = "{LOC}-nnn.nn";
            column19.PromptChar = ' ';
            column19.Format = "F2";
            column19.CellAppearance = appearance19;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.sp_RSOBRAZACMIO1RSMBDescription;
            column10.Width = 0x66;
            appearance10.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column10.PromptChar = ' ';
            column10.Format = "F2";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.sp_RSOBRAZACIDDOPRINOSMIO2Description;
            column4.Width = 0x77;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnn";
            column4.PromptChar = ' ';
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            column20.CellActivation = Activation.NoEdit;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.sp_RSOBRAZACSTOPAMIO2Description;
            column20.Width = 0x59;
            appearance20.TextHAlign = HAlign.Right;
            column20.MaskInput = "{LOC}-nnn.nn";
            column20.PromptChar = ' ';
            column20.Format = "F2";
            column20.CellAppearance = appearance20;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.sp_RSOBRAZACMIO2RSMBDescription;
            column11.Width = 0x66;
            appearance11.TextHAlign = HAlign.Right;
            column11.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column11.PromptChar = ' ';
            column11.Format = "F2";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.sp_RSOBRAZACPOREZIPRIREZDescription;
            column15.Width = 0x74;
            appearance15.TextHAlign = HAlign.Right;
            column15.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column15.PromptChar = ' ';
            column15.Format = "F2";
            column15.CellAppearance = appearance15;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.sp_RSOBRAZACIZNOSISPLACENEPLACERSMBDescription;
            column6.Width = 0xb1;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column6.PromptChar = ' ';
            column6.Format = "F2";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.sp_RSOBRAZACOIBDescription;
            column13.Width = 0x5d;
            column13.Format = "";
            column13.CellAppearance = appearance13;
            band.Columns.Add(column17);
            column17.Header.VisiblePosition = 0;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 1;
            band.Columns.Add(column16);
            column16.Header.VisiblePosition = 2;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 3;
            band.Columns.Add(column18);
            column18.Header.VisiblePosition = 4;
            band.Columns.Add(column14);
            column14.Header.VisiblePosition = 5;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 6;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 7;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 8;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 9;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 10;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 11;
            band.Columns.Add(column19);
            column19.Header.VisiblePosition = 12;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 13;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 14;
            band.Columns.Add(column20);
            column20.Header.VisiblePosition = 15;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 0x10;
            band.Columns.Add(column15);
            column15.Header.VisiblePosition = 0x11;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 0x12;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 0x13;
            this.userControlDataGridsp_RSOBRAZAC.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridsp_RSOBRAZAC.Location = point;
            this.userControlDataGridsp_RSOBRAZAC.Name = "userControlDataGridsp_RSOBRAZAC";
            this.userControlDataGridsp_RSOBRAZAC.Tag = "sp_RSOBRAZAC";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridsp_RSOBRAZAC.Size = size;
            this.userControlDataGridsp_RSOBRAZAC.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridsp_RSOBRAZAC.Dock = DockStyle.Fill;
            this.userControlDataGridsp_RSOBRAZAC.FillAtStartup = false;
            this.userControlDataGridsp_RSOBRAZAC.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridsp_RSOBRAZAC.InitializeRow += new InitializeRowEventHandler(this.sp_RSOBRAZACUserDataGrid_InitializeRow);
            this.userControlDataGridsp_RSOBRAZAC.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridsp_RSOBRAZAC });
            this.Name = "sp_RSOBRAZACUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.sp_RSOBRAZACUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridsp_RSOBRAZAC).EndInit();
            this.ResumeLayout(false);
        }

        private void sp_RSOBRAZACUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void sp_RSOBRAZACUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual sp_RSOBRAZACDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridsp_RSOBRAZAC;
            }
            set
            {
                this.userControlDataGridsp_RSOBRAZAC = value;
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
        public virtual short Parameterdd
        {
            get
            {
                return this.DataGrid.Parameterdd;
            }
            set
            {
                this.DataGrid.Parameterdd = value;
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


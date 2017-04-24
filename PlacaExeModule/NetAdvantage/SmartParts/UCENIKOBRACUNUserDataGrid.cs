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

    public class UCENIKOBRACUNUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with UCENIKOBRACUN";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with UCENIKOBRACUN";
        private UCENIKOBRACUNDataGrid userControlDataGridUCENIKOBRACUN;

        public UCENIKOBRACUNUserDataGrid()
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
            this.userControlDataGridUCENIKOBRACUN = new UCENIKOBRACUNDataGrid();
            ((ISupportInitialize) this.userControlDataGridUCENIKOBRACUN).BeginInit();
            UltraGridBand band = new UltraGridBand("UCENIKOBRACUN", -1);
            UltraGridColumn column13 = new UltraGridColumn("UCOBRMJESEC");
            UltraGridColumn column12 = new UltraGridColumn("UCOBRGODINA");
            UltraGridColumn column14 = new UltraGridColumn("UCOBROPIS");
            UltraGridColumn column2 = new UltraGridColumn("OSNOVICAPODANU");
            UltraGridColumn column = new UltraGridColumn("AKTIVANZARSM");
            UltraGridBand band2 = new UltraGridBand("UCENIKOBRACUN_UCENIKOBRACUNUCENIKOBRACUNDETAIL", 0);
            UltraGridColumn column11 = new UltraGridColumn("UCOBRMJESEC");
            UltraGridColumn column10 = new UltraGridColumn("UCOBRGODINA");
            UltraGridColumn column4 = new UltraGridColumn("IDUCENIK");
            UltraGridColumn column8 = new UltraGridColumn("PREZIMEUCENIK");
            UltraGridColumn column5 = new UltraGridColumn("IMEUCENIK");
            UltraGridColumn column3 = new UltraGridColumn("BROJDANAPRAKSE");
            UltraGridColumn column6 = new UltraGridColumn("OBRACUNOSNOVICEPRAKSA");
            UltraGridColumn column9 = new UltraGridColumn("RAZRED");
            UltraGridColumn column7 = new UltraGridColumn("ODJELJENJE");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.UCENIKOBRACUNUCOBRMJESECDescription;
            column13.Width = 0x3a;
            appearance13.TextHAlign = HAlign.Right;
            column13.MaskInput = "{LOC}-nnnnn";
            column13.PromptChar = ' ';
            column13.Format = "";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.UCENIKOBRACUNUCOBRGODINADescription;
            column12.Width = 0x3a;
            appearance12.TextHAlign = HAlign.Right;
            column12.MaskInput = "{LOC}-nnnnn";
            column12.PromptChar = ' ';
            column12.Format = "";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.UCENIKOBRACUNUCOBROPISDescription;
            column14.Width = 0x128;
            column14.Format = "";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.UCENIKOBRACUNOSNOVICAPODANUDescription;
            column2.Width = 0xc5;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column2.PromptChar = ' ';
            column2.Format = "F2";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.UCENIKOBRACUNAKTIVANZARSMDescription;
            column.Width = 100;
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.UCENIKOBRACUNUCOBRMJESECDescription;
            column11.Width = 0x3a;
            appearance11.TextHAlign = HAlign.Right;
            column11.MaskInput = "{LOC}-nnnnn";
            column11.PromptChar = ' ';
            column11.Format = "";
            column11.CellAppearance = appearance11;
            column11.Hidden = true;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.UCENIKOBRACUNUCOBRGODINADescription;
            column10.Width = 0x3a;
            appearance10.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnnnn";
            column10.PromptChar = ' ';
            column10.Format = "";
            column10.CellAppearance = appearance10;
            column10.Hidden = true;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.UCENIKOBRACUNIDUCENIKDescription;
            column4.Width = 0x41;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnn";
            column4.PromptChar = ' ';
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.UCENIKOBRACUNPREZIMEUCENIKDescription;
            column8.Width = 0x128;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.UCENIKOBRACUNIMEUCENIKDescription;
            column5.Width = 0x128;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.UCENIKOBRACUNBROJDANAPRAKSEDescription;
            column3.Width = 0x7e;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnn";
            column3.PromptChar = ' ';
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.UCENIKOBRACUNOBRACUNOSNOVICEPRAKSADescription;
            column6.Width = 0x123;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column6.PromptChar = ' ';
            column6.Format = "F2";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.UCENIKOBRACUNRAZREDDescription;
            column9.Width = 0x3a;
            appearance9.TextHAlign = HAlign.Right;
            column9.MaskInput = "{LOC}-nnnnn";
            column9.PromptChar = ' ';
            column9.Format = "";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.UCENIKOBRACUNODJELJENJEDescription;
            column7.Width = 0x56;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            band2.Columns.Add(column11);
            column11.Header.VisiblePosition = 0;
            band2.Columns.Add(column10);
            column10.Header.VisiblePosition = 1;
            band2.Columns.Add(column4);
            column4.Header.VisiblePosition = 2;
            band2.Columns.Add(column8);
            column8.Header.VisiblePosition = 3;
            band2.Columns.Add(column5);
            column5.Header.VisiblePosition = 4;
            band2.Columns.Add(column3);
            column3.Header.VisiblePosition = 5;
            band2.Columns.Add(column6);
            column6.Header.VisiblePosition = 6;
            band2.Columns.Add(column9);
            column9.Header.VisiblePosition = 7;
            band2.Columns.Add(column7);
            column7.Header.VisiblePosition = 8;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 0;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 1;
            band.Columns.Add(column14);
            column14.Header.VisiblePosition = 2;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 3;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 4;
            this.userControlDataGridUCENIKOBRACUN.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridUCENIKOBRACUN.Location = point;
            this.userControlDataGridUCENIKOBRACUN.Name = "userControlDataGridUCENIKOBRACUN";
            this.userControlDataGridUCENIKOBRACUN.Tag = "UCENIKOBRACUN";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridUCENIKOBRACUN.Size = size;
            this.userControlDataGridUCENIKOBRACUN.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridUCENIKOBRACUN.Dock = DockStyle.Fill;
            this.userControlDataGridUCENIKOBRACUN.FillAtStartup = false;
            this.userControlDataGridUCENIKOBRACUN.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridUCENIKOBRACUN.InitializeRow += new InitializeRowEventHandler(this.UCENIKOBRACUNUserDataGrid_InitializeRow);
            this.userControlDataGridUCENIKOBRACUN.DisplayLayout.BandsSerializer.Add(band);
            this.userControlDataGridUCENIKOBRACUN.DisplayLayout.BandsSerializer.Add(band2);
            this.Controls.AddRange(new Control[] { this.userControlDataGridUCENIKOBRACUN });
            this.Name = "UCENIKOBRACUNUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.UCENIKOBRACUNUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridUCENIKOBRACUN).EndInit();
            this.ResumeLayout(false);
        }

        private void UCENIKOBRACUNUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void UCENIKOBRACUNUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual UCENIKOBRACUNDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridUCENIKOBRACUN;
            }
            set
            {
                this.userControlDataGridUCENIKOBRACUN = value;
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

        [Category("Deklarit Work With ")]
        public virtual int FillByUCOBRMJESECUCOBRMJESEC
        {
            get
            {
                return this.DataGrid.FillByUCOBRMJESECUCOBRMJESEC;
            }
            set
            {
                this.DataGrid.FillByUCOBRMJESECUCOBRMJESEC = value;
            }
        }

        [Category("Deklarit Work With "), TypeConverter(typeof(DeklaritDataGrid.FillMethodsConverter)), DefaultValue("Fill")]
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


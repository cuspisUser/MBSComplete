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

    public class S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI";
        private S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIDataGrid userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI;

        public S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIUserDataGrid()
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
            this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI = new S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIDataGrid();
            ((ISupportInitialize) this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI).BeginInit();
            UltraGridBand band = new UltraGridBand("S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI", -1);
            UltraGridColumn column10 = new UltraGridColumn("OPISLOKACIJE");
            UltraGridColumn column12 = new UltraGridColumn("STANJE");
            UltraGridColumn column = new UltraGridColumn("IDLOKACIJE");
            UltraGridColumn column2 = new UltraGridColumn("IDOSVRSTA");
            UltraGridColumn column5 = new UltraGridColumn("KTOISPRAVKAIDKONTO");
            UltraGridColumn column6 = new UltraGridColumn("KTOIZVORAIDKONTO");
            UltraGridColumn column7 = new UltraGridColumn("KTONABAVKEIDKONTO");
            UltraGridColumn column9 = new UltraGridColumn("NAZIVOS");
            UltraGridColumn column3 = new UltraGridColumn("INVBROJ");
            UltraGridColumn column8 = new UltraGridColumn("NABAVNA");
            UltraGridColumn column4 = new UltraGridColumn("ISPRAVAK");
            UltraGridColumn column11 = new UltraGridColumn("SADASNJA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIOPISLOKACIJEDescription;
            column10.Width = 0x128;
            column10.Format = "";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJISTANJEDescription;
            column12.Width = 0x66;
            appearance12.TextHAlign = HAlign.Right;
            column12.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column12.PromptChar = ' ';
            column12.Format = "F2";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIIDLOKACIJEDescription;
            column.Width = 0x48;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIIDOSVRSTADescription;
            column2.Width = 0x4e;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIKTOISPRAVKAIDKONTODescription;
            column5.Width = 0x72;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIKTOIZVORAIDKONTODescription;
            column6.Width = 0x72;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIKTONABAVKEIDKONTODescription;
            column7.Width = 0x72;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJINAZIVOSDescription;
            column9.Width = 0x128;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIINVBROJDescription;
            column3.Width = 0x77;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnnnnnnnnn";
            column3.PromptChar = ' ';
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJINABAVNADescription;
            column8.Width = 0x66;
            appearance8.TextHAlign = HAlign.Right;
            column8.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column8.PromptChar = ' ';
            column8.Format = "F2";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIISPRAVAKDescription;
            column4.Width = 0x66;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column4.PromptChar = ' ';
            column4.Format = "F2";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJISADASNJADescription;
            column11.Width = 0x66;
            appearance11.TextHAlign = HAlign.Right;
            column11.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column11.PromptChar = ' ';
            column11.Format = "F2";
            column11.CellAppearance = appearance11;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 0;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 1;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 2;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 3;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 4;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 5;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 6;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 7;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 8;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 9;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 10;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 11;
            this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.Location = point;
            this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.Name = "userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI";
            this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.Tag = "S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.Size = size;
            this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.Dock = DockStyle.Fill;
            this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.FillAtStartup = false;
            this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.InitializeRow += new InitializeRowEventHandler(this.S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIUserDataGrid_InitializeRow);
            this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI });
            this.Name = "S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI).EndInit();
            this.ResumeLayout(false);
        }

        private void S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI;
            }
            set
            {
                this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI = value;
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
        public virtual DateTime ParameterDATUM
        {
            get
            {
                return this.DataGrid.ParameterDATUM;
            }
            set
            {
                this.DataGrid.ParameterDATUM = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string ParameterSORT
        {
            get
            {
                return this.DataGrid.ParameterSORT;
            }
            set
            {
                this.DataGrid.ParameterSORT = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual int ParameterVRSTA
        {
            get
            {
                return this.DataGrid.ParameterVRSTA;
            }
            set
            {
                this.DataGrid.ParameterVRSTA = value;
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


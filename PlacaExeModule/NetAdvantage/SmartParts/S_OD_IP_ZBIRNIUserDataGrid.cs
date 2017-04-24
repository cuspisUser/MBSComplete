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

    public class S_OD_IP_ZBIRNIUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with S_OD_IP_ZBIRNI";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with S_OD_IP_ZBIRNI";
        private S_OD_IP_ZBIRNIDataGrid userControlDataGridS_OD_IP_ZBIRNI;

        public S_OD_IP_ZBIRNIUserDataGrid()
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
            this.userControlDataGridS_OD_IP_ZBIRNI = new S_OD_IP_ZBIRNIDataGrid();
            ((ISupportInitialize) this.userControlDataGridS_OD_IP_ZBIRNI).BeginInit();
            UltraGridBand band = new UltraGridBand("S_OD_IP_ZBIRNI", -1);
            UltraGridColumn column10 = new UltraGridColumn("ukupnobruto");
            UltraGridColumn column11 = new UltraGridColumn("ukupnodoprinosi");
            UltraGridColumn column12 = new UltraGridColumn("ukupnoolaksice");
            UltraGridColumn column = new UltraGridColumn("dohodak");
            UltraGridColumn column13 = new UltraGridColumn("UKUPNOOO");
            UltraGridColumn column7 = new UltraGridColumn("poreznaosnovica");
            UltraGridColumn column8 = new UltraGridColumn("POREZPRIREZ");
            UltraGridColumn column3 = new UltraGridColumn("netoisplata");
            UltraGridColumn column4 = new UltraGridColumn("netoplaca");
            UltraGridColumn column6 = new UltraGridColumn("POREZKRIZNI");
            UltraGridColumn column9 = new UltraGridColumn("PREZIME");
            UltraGridColumn column2 = new UltraGridColumn("IME");
            UltraGridColumn column5 = new UltraGridColumn("OIB");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.S_OD_IP_ZBIRNIukupnobrutoDescription;
            column10.Width = 0x66;
            appearance10.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column10.PromptChar = ' ';
            column10.Format = "F2";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.S_OD_IP_ZBIRNIukupnodoprinosiDescription;
            column11.Width = 0x7b;
            appearance11.TextHAlign = HAlign.Right;
            column11.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column11.PromptChar = ' ';
            column11.Format = "F2";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.S_OD_IP_ZBIRNIukupnoolaksiceDescription;
            column12.Width = 0x74;
            appearance12.TextHAlign = HAlign.Right;
            column12.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column12.PromptChar = ' ';
            column12.Format = "F2";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.S_OD_IP_ZBIRNIdohodakDescription;
            column.Width = 0x66;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column.PromptChar = ' ';
            column.Format = "F2";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.S_OD_IP_ZBIRNIUKUPNOOODescription;
            column13.Width = 0x66;
            appearance13.TextHAlign = HAlign.Right;
            column13.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column13.PromptChar = ' ';
            column13.Format = "F2";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.S_OD_IP_ZBIRNIporeznaosnovicaDescription;
            column7.Width = 0x7b;
            appearance7.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column7.PromptChar = ' ';
            column7.Format = "F2";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.S_OD_IP_ZBIRNIPOREZPRIREZDescription;
            column8.Width = 0x66;
            appearance8.TextHAlign = HAlign.Right;
            column8.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column8.PromptChar = ' ';
            column8.Format = "F2";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.S_OD_IP_ZBIRNInetoisplataDescription;
            column3.Width = 0x66;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column3.PromptChar = ' ';
            column3.Format = "F2";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.S_OD_IP_ZBIRNInetoplacaDescription;
            column4.Width = 0x66;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column4.PromptChar = ' ';
            column4.Format = "F2";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.S_OD_IP_ZBIRNIPOREZKRIZNIDescription;
            column6.Width = 0x66;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column6.PromptChar = ' ';
            column6.Format = "F2";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.S_OD_IP_ZBIRNIPREZIMEDescription;
            column9.Width = 0x128;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.S_OD_IP_ZBIRNIIMEDescription;
            column2.Width = 0x128;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.S_OD_IP_ZBIRNIOIBDescription;
            column5.Width = 0x5d;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 0;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 1;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 2;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 3;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 4;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 5;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 6;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 7;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 8;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 9;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 10;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 11;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 12;
            this.userControlDataGridS_OD_IP_ZBIRNI.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_OD_IP_ZBIRNI.Location = point;
            this.userControlDataGridS_OD_IP_ZBIRNI.Name = "userControlDataGridS_OD_IP_ZBIRNI";
            this.userControlDataGridS_OD_IP_ZBIRNI.Tag = "S_OD_IP_ZBIRNI";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridS_OD_IP_ZBIRNI.Size = size;
            this.userControlDataGridS_OD_IP_ZBIRNI.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridS_OD_IP_ZBIRNI.Dock = DockStyle.Fill;
            this.userControlDataGridS_OD_IP_ZBIRNI.FillAtStartup = false;
            this.userControlDataGridS_OD_IP_ZBIRNI.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridS_OD_IP_ZBIRNI.InitializeRow += new InitializeRowEventHandler(this.S_OD_IP_ZBIRNIUserDataGrid_InitializeRow);
            this.userControlDataGridS_OD_IP_ZBIRNI.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridS_OD_IP_ZBIRNI });
            this.Name = "S_OD_IP_ZBIRNIUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.S_OD_IP_ZBIRNIUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridS_OD_IP_ZBIRNI).EndInit();
            this.ResumeLayout(false);
        }

        private void S_OD_IP_ZBIRNIUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void S_OD_IP_ZBIRNIUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual S_OD_IP_ZBIRNIDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridS_OD_IP_ZBIRNI;
            }
            set
            {
                this.userControlDataGridS_OD_IP_ZBIRNI = value;
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
        public virtual string ParameterGODINA
        {
            get
            {
                return this.DataGrid.ParameterGODINA;
            }
            set
            {
                this.DataGrid.ParameterGODINA = value;
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


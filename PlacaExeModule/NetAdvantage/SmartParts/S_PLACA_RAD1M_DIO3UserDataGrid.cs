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

    public class S_PLACA_RAD1M_DIO3UserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with S_PLACA_RAD1M_DIO3";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with S_PLACA_RAD1M_DIO3";
        private S_PLACA_RAD1M_DIO3DataGrid userControlDataGridS_PLACA_RAD1M_DIO3;

        public S_PLACA_RAD1M_DIO3UserDataGrid()
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
            this.userControlDataGridS_PLACA_RAD1M_DIO3 = new S_PLACA_RAD1M_DIO3DataGrid();
            ((ISupportInitialize) this.userControlDataGridS_PLACA_RAD1M_DIO3).BeginInit();
            UltraGridBand band = new UltraGridBand("S_PLACA_RAD1M_DIO3", -1);
            UltraGridColumn column5 = new UltraGridColumn("prekovremeni");
            UltraGridColumn column2 = new UltraGridColumn("BOLOVANJEDO42DANA");
            UltraGridColumn column3 = new UltraGridColumn("GODISNJI");
            UltraGridColumn column = new UltraGridColumn("BLAGDANINERADNI");
            UltraGridColumn column4 = new UltraGridColumn("PLACENIANEIZVRSENI");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.S_PLACA_RAD1M_DIO3prekovremeniDescription;
            column5.Width = 0x66;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column5.PromptChar = ' ';
            column5.Format = "F2";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.S_PLACA_RAD1M_DIO3BOLOVANJEDO42DANADescription;
            column2.Width = 150;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column2.PromptChar = ' ';
            column2.Format = "F2";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.S_PLACA_RAD1M_DIO3GODISNJIDescription;
            column3.Width = 0x66;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column3.PromptChar = ' ';
            column3.Format = "F2";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.S_PLACA_RAD1M_DIO3BLAGDANINERADNIDescription;
            column.Width = 0x7b;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column.PromptChar = ' ';
            column.Format = "F2";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.S_PLACA_RAD1M_DIO3PLACENIANEIZVRSENIDescription;
            column4.Width = 0x8f;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column4.PromptChar = ' ';
            column4.Format = "F2";
            column4.CellAppearance = appearance4;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 2;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 3;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 4;
            this.userControlDataGridS_PLACA_RAD1M_DIO3.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_PLACA_RAD1M_DIO3.Location = point;
            this.userControlDataGridS_PLACA_RAD1M_DIO3.Name = "userControlDataGridS_PLACA_RAD1M_DIO3";
            this.userControlDataGridS_PLACA_RAD1M_DIO3.Tag = "S_PLACA_RAD1M_DIO3";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridS_PLACA_RAD1M_DIO3.Size = size;
            this.userControlDataGridS_PLACA_RAD1M_DIO3.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridS_PLACA_RAD1M_DIO3.Dock = DockStyle.Fill;
            this.userControlDataGridS_PLACA_RAD1M_DIO3.FillAtStartup = false;
            this.userControlDataGridS_PLACA_RAD1M_DIO3.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridS_PLACA_RAD1M_DIO3.InitializeRow += new InitializeRowEventHandler(this.S_PLACA_RAD1M_DIO3UserDataGrid_InitializeRow);
            this.userControlDataGridS_PLACA_RAD1M_DIO3.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridS_PLACA_RAD1M_DIO3 });
            this.Name = "S_PLACA_RAD1M_DIO3UserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.S_PLACA_RAD1M_DIO3UserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridS_PLACA_RAD1M_DIO3).EndInit();
            this.ResumeLayout(false);
        }

        private void S_PLACA_RAD1M_DIO3UserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void S_PLACA_RAD1M_DIO3UserDataGrid_Load(object sender, EventArgs e)
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
        public virtual S_PLACA_RAD1M_DIO3DataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridS_PLACA_RAD1M_DIO3;
            }
            set
            {
                this.userControlDataGridS_PLACA_RAD1M_DIO3 = value;
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
        public virtual string ParameterGODINAISPLATE
        {
            get
            {
                return this.DataGrid.ParameterGODINAISPLATE;
            }
            set
            {
                this.DataGrid.ParameterGODINAISPLATE = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string ParameterMJESECISPLATE
        {
            get
            {
                return this.DataGrid.ParameterMJESECISPLATE;
            }
            set
            {
                this.DataGrid.ParameterMJESECISPLATE = value;
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


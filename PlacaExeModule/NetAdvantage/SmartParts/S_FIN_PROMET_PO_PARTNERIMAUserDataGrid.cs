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

    public class S_FIN_PROMET_PO_PARTNERIMAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with S_FIN_PROMET_PO_PARTNERIMA";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with S_FIN_PROMET_PO_PARTNERIMA";
        private S_FIN_PROMET_PO_PARTNERIMADataGrid userControlDataGridS_FIN_PROMET_PO_PARTNERIMA;

        public S_FIN_PROMET_PO_PARTNERIMAUserDataGrid()
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
            this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA = new S_FIN_PROMET_PO_PARTNERIMADataGrid();
            ((ISupportInitialize) this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA).BeginInit();
            UltraGridBand band = new UltraGridBand("S_FIN_PROMET_PO_PARTNERIMA", -1);
            UltraGridColumn column3 = new UltraGridColumn("IDPARTNER");
            UltraGridColumn column2 = new UltraGridColumn("duguje");
            UltraGridColumn column6 = new UltraGridColumn("POTRAZUJE");
            UltraGridColumn column4 = new UltraGridColumn("NAZIV");
            UltraGridColumn column = new UltraGridColumn("AKTIVNOST");
            UltraGridColumn column5 = new UltraGridColumn("PARTNERMJESTO");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.S_FIN_PROMET_PO_PARTNERIMAIDPARTNERDescription;
            column3.Width = 0x70;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnnnnnn";
            column3.PromptChar = ' ';
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.S_FIN_PROMET_PO_PARTNERIMAdugujeDescription;
            column2.Width = 0x66;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column2.PromptChar = ' ';
            column2.Format = "F2";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.S_FIN_PROMET_PO_PARTNERIMAPOTRAZUJEDescription;
            column6.Width = 0x66;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column6.PromptChar = ' ';
            column6.Format = "F2";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.S_FIN_PROMET_PO_PARTNERIMANAZIVDescription;
            column4.Width = 0x128;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.S_FIN_PROMET_PO_PARTNERIMAAKTIVNOSTDescription;
            column.Width = 0x4e;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-n";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.S_FIN_PROMET_PO_PARTNERIMAPARTNERMJESTODescription;
            column5.Width = 0x128;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 2;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 3;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 4;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 5;
            this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.Location = point;
            this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.Name = "userControlDataGridS_FIN_PROMET_PO_PARTNERIMA";
            this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.Tag = "S_FIN_PROMET_PO_PARTNERIMA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.Size = size;
            this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.Dock = DockStyle.Fill;
            this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.FillAtStartup = false;
            this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.InitializeRow += new InitializeRowEventHandler(this.S_FIN_PROMET_PO_PARTNERIMAUserDataGrid_InitializeRow);
            this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA });
            this.Name = "S_FIN_PROMET_PO_PARTNERIMAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.S_FIN_PROMET_PO_PARTNERIMAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA).EndInit();
            this.ResumeLayout(false);
        }

        private void S_FIN_PROMET_PO_PARTNERIMAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void S_FIN_PROMET_PO_PARTNERIMAUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual S_FIN_PROMET_PO_PARTNERIMADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA;
            }
            set
            {
                this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA = value;
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
        public virtual string ParameterDODATNIUVJET
        {
            get
            {
                return this.DataGrid.ParameterDODATNIUVJET;
            }
            set
            {
                this.DataGrid.ParameterDODATNIUVJET = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual int ParameterDOPARTNERA
        {
            get
            {
                return this.DataGrid.ParameterDOPARTNERA;
            }
            set
            {
                this.DataGrid.ParameterDOPARTNERA = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual int ParameterIDAKTIVNOST
        {
            get
            {
                return this.DataGrid.ParameterIDAKTIVNOST;
            }
            set
            {
                this.DataGrid.ParameterIDAKTIVNOST = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual int ParameterMT
        {
            get
            {
                return this.DataGrid.ParameterMT;
            }
            set
            {
                this.DataGrid.ParameterMT = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual int ParameterODPARTNERA
        {
            get
            {
                return this.DataGrid.ParameterODPARTNERA;
            }
            set
            {
                this.DataGrid.ParameterODPARTNERA = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual int ParameterORG
        {
            get
            {
                return this.DataGrid.ParameterORG;
            }
            set
            {
                this.DataGrid.ParameterORG = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string ParameterPOCETNIKONTO
        {
            get
            {
                return this.DataGrid.ParameterPOCETNIKONTO;
            }
            set
            {
                this.DataGrid.ParameterPOCETNIKONTO = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual DateTime ParameterRAZDOBLJEDO
        {
            get
            {
                return this.DataGrid.ParameterRAZDOBLJEDO;
            }
            set
            {
                this.DataGrid.ParameterRAZDOBLJEDO = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual DateTime ParameterRAZDOBLJEOD
        {
            get
            {
                return this.DataGrid.ParameterRAZDOBLJEOD;
            }
            set
            {
                this.DataGrid.ParameterRAZDOBLJEOD = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string ParameterZAVRSNIKONTO
        {
            get
            {
                return this.DataGrid.ParameterZAVRSNIKONTO;
            }
            set
            {
                this.DataGrid.ParameterZAVRSNIKONTO = value;
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


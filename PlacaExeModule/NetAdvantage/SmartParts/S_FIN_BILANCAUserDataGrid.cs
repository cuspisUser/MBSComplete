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

    public class S_FIN_BILANCAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with S_FIN_BILANCA";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with S_FIN_BILANCA";
        private S_FIN_BILANCADataGrid userControlDataGridS_FIN_BILANCA;

        public S_FIN_BILANCAUserDataGrid()
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
            this.userControlDataGridS_FIN_BILANCA = new S_FIN_BILANCADataGrid();
            ((ISupportInitialize) this.userControlDataGridS_FIN_BILANCA).BeginInit();
            UltraGridBand band = new UltraGridBand("S_FIN_BILANCA", -1);
            UltraGridColumn column = new UltraGridColumn("duguje");
            UltraGridColumn column6 = new UltraGridColumn("POTRAZUJE");
            UltraGridColumn column2 = new UltraGridColumn("konto");
            UltraGridColumn column4 = new UltraGridColumn("POCETNODUGUJE");
            UltraGridColumn column5 = new UltraGridColumn("POCETNOPOTRAZUJE");
            UltraGridColumn column3 = new UltraGridColumn("NAZIV");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.S_FIN_BILANCAdugujeDescription;
            column.Width = 0x66;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column.PromptChar = ' ';
            column.Format = "F2";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.S_FIN_BILANCAPOTRAZUJEDescription;
            column6.Width = 0x66;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column6.PromptChar = ' ';
            column6.Format = "F2";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.S_FIN_BILANCAkontoDescription;
            column2.Width = 0x79;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.S_FIN_BILANCAPOCETNODUGUJEDescription;
            column4.Width = 0x6d;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column4.PromptChar = ' ';
            column4.Format = "F2";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.S_FIN_BILANCAPOCETNOPOTRAZUJEDescription;
            column5.Width = 0x81;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column5.PromptChar = ' ';
            column5.Format = "F2";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.S_FIN_BILANCANAZIVDescription;
            column3.Width = 0x128;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 1;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 2;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 3;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 4;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 5;
            this.userControlDataGridS_FIN_BILANCA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_FIN_BILANCA.Location = point;
            this.userControlDataGridS_FIN_BILANCA.Name = "userControlDataGridS_FIN_BILANCA";
            this.userControlDataGridS_FIN_BILANCA.Tag = "S_FIN_BILANCA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridS_FIN_BILANCA.Size = size;
            this.userControlDataGridS_FIN_BILANCA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridS_FIN_BILANCA.Dock = DockStyle.Fill;
            this.userControlDataGridS_FIN_BILANCA.FillAtStartup = false;
            this.userControlDataGridS_FIN_BILANCA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridS_FIN_BILANCA.InitializeRow += new InitializeRowEventHandler(this.S_FIN_BILANCAUserDataGrid_InitializeRow);
            this.userControlDataGridS_FIN_BILANCA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridS_FIN_BILANCA });
            this.Name = "S_FIN_BILANCAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.S_FIN_BILANCAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridS_FIN_BILANCA).EndInit();
            this.ResumeLayout(false);
        }

        private void S_FIN_BILANCAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void S_FIN_BILANCAUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual S_FIN_BILANCADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridS_FIN_BILANCA;
            }
            set
            {
                this.userControlDataGridS_FIN_BILANCA = value;
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

        [Description("True= Fill at Startup. False= Not Fill"), Category("Deklarit Work With "), DefaultValue(true)]
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
        public virtual short ParameterANA
        {
            get
            {
                return this.DataGrid.ParameterANA;
            }
            set
            {
                this.DataGrid.ParameterANA = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string ParameterDOK
        {
            get
            {
                return this.DataGrid.ParameterDOK;
            }
            set
            {
                this.DataGrid.ParameterDOK = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string ParameterKLASA
        {
            get
            {
                return this.DataGrid.ParameterKLASA;
            }
            set
            {
                this.DataGrid.ParameterKLASA = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string ParameterMT
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
        public virtual string ParameterORG
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
        public virtual short ParameterSKR
        {
            get
            {
                return this.DataGrid.ParameterSKR;
            }
            set
            {
                this.DataGrid.ParameterSKR = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual short ParameterVRSTABILANCE
        {
            get
            {
                return this.DataGrid.ParameterVRSTABILANCE;
            }
            set
            {
                this.DataGrid.ParameterVRSTABILANCE = value;
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


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

    public class S_PLACA_RAD1GUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with S_PLACA_RAD1G";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with S_PLACA_RAD1G";
        private S_PLACA_RAD1GDataGrid userControlDataGridS_PLACA_RAD1G;

        public S_PLACA_RAD1GUserDataGrid()
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
            this.userControlDataGridS_PLACA_RAD1G = new S_PLACA_RAD1GDataGrid();
            ((ISupportInitialize) this.userControlDataGridS_PLACA_RAD1G).BeginInit();
            UltraGridBand band = new UltraGridBand("S_PLACA_RAD1G", -1);
            UltraGridColumn column = new UltraGridColumn("BROJRADNIKA");
            UltraGridColumn column2 = new UltraGridColumn("BROJRADNIKAZENA");
            UltraGridColumn column3 = new UltraGridColumn("GODINASTAROSTI");
            UltraGridColumn column4 = new UltraGridColumn("RADNOVRIJEME");
            UltraGridColumn column6 = new UltraGridColumn("VRSTARADNOGODNOSA");
            UltraGridColumn column5 = new UltraGridColumn("SPREMA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.S_PLACA_RAD1GBROJRADNIKADescription;
            column.Width = 0x81;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column.PromptChar = ' ';
            column.Format = "F2";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.S_PLACA_RAD1GBROJRADNIKAZENADescription;
            column2.Width = 0x7b;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column2.PromptChar = ' ';
            column2.Format = "F2";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.S_PLACA_RAD1GGODINASTAROSTIDescription;
            column3.Width = 0x74;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column3.PromptChar = ' ';
            column3.Format = "F2";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.S_PLACA_RAD1GRADNOVRIJEMEDescription;
            column4.Width = 100;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.S_PLACA_RAD1GVRSTARADNOGODNOSADescription;
            column6.Width = 0x87;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.S_PLACA_RAD1GSPREMADescription;
            column5.Width = 0x3a;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 2;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 3;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 4;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 5;
            this.userControlDataGridS_PLACA_RAD1G.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_PLACA_RAD1G.Location = point;
            this.userControlDataGridS_PLACA_RAD1G.Name = "userControlDataGridS_PLACA_RAD1G";
            this.userControlDataGridS_PLACA_RAD1G.Tag = "S_PLACA_RAD1G";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridS_PLACA_RAD1G.Size = size;
            this.userControlDataGridS_PLACA_RAD1G.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridS_PLACA_RAD1G.Dock = DockStyle.Fill;
            this.userControlDataGridS_PLACA_RAD1G.FillAtStartup = false;
            this.userControlDataGridS_PLACA_RAD1G.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridS_PLACA_RAD1G.InitializeRow += new InitializeRowEventHandler(this.S_PLACA_RAD1GUserDataGrid_InitializeRow);
            this.userControlDataGridS_PLACA_RAD1G.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridS_PLACA_RAD1G });
            this.Name = "S_PLACA_RAD1GUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.S_PLACA_RAD1GUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridS_PLACA_RAD1G).EndInit();
            this.ResumeLayout(false);
        }

        private void S_PLACA_RAD1GUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void S_PLACA_RAD1GUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual S_PLACA_RAD1GDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridS_PLACA_RAD1G;
            }
            set
            {
                this.userControlDataGridS_PLACA_RAD1G = value;
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

        [Category("Deklarit Work With "), Description("True= Fill at Startup. False= Not Fill"), DefaultValue(true)]
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
        public virtual DateTime ParameterDATUMNAKOJIRACUNAMSTAROST
        {
            get
            {
                return this.DataGrid.ParameterDATUMNAKOJIRACUNAMSTAROST;
            }
            set
            {
                this.DataGrid.ParameterDATUMNAKOJIRACUNAMSTAROST = value;
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

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string ParameterMJESECODLASKA
        {
            get
            {
                return this.DataGrid.ParameterMJESECODLASKA;
            }
            set
            {
                this.DataGrid.ParameterMJESECODLASKA = value;
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


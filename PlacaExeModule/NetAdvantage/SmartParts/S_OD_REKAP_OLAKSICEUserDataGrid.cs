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

    public class S_OD_REKAP_OLAKSICEUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with S_OD_REKAP_OLAKSICE";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with S_OD_REKAP_OLAKSICE";
        private S_OD_REKAP_OLAKSICEDataGrid userControlDataGridS_OD_REKAP_OLAKSICE;

        public S_OD_REKAP_OLAKSICEUserDataGrid()
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
            this.userControlDataGridS_OD_REKAP_OLAKSICE = new S_OD_REKAP_OLAKSICEDataGrid();
            ((ISupportInitialize) this.userControlDataGridS_OD_REKAP_OLAKSICE).BeginInit();
            UltraGridBand band = new UltraGridBand("S_OD_REKAP_OLAKSICE", -1);
            UltraGridColumn column8 = new UltraGridColumn("MOOLAKSICA");
            UltraGridColumn column13 = new UltraGridColumn("POOLAKSICA");
            UltraGridColumn column2 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column14 = new UltraGridColumn("PREZIME");
            UltraGridColumn column4 = new UltraGridColumn("IME");
            UltraGridColumn column7 = new UltraGridColumn("JMBG");
            UltraGridColumn column = new UltraGridColumn("IDOLAKSICE");
            UltraGridColumn column12 = new UltraGridColumn("OBRACUNATAOLAKSICA");
            UltraGridColumn column10 = new UltraGridColumn("NAZIVOLAKSICE");
            UltraGridColumn column9 = new UltraGridColumn("NAZIVGRUPEOLAKSICA");
            UltraGridColumn column5 = new UltraGridColumn("IZNOSOLAKSICE");
            UltraGridColumn column3 = new UltraGridColumn("IDTIPOLAKSICE");
            UltraGridColumn column11 = new UltraGridColumn("NAZIVTIPOLAKSICE");
            UltraGridColumn column15 = new UltraGridColumn("PRIMATELJOLAKSICA1");
            UltraGridColumn column16 = new UltraGridColumn("PRIMATELJOLAKSICA2");
            UltraGridColumn column6 = new UltraGridColumn("IZNOSPOREZNOPRIZNATEOLAKSICE");
            UltraGridColumn column17 = new UltraGridColumn("ZADPOJEDINACNIPOZIV");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.S_OD_REKAP_OLAKSICEMOOLAKSICADescription;
            column8.Width = 0xb8;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.S_OD_REKAP_OLAKSICEPOOLAKSICADescription;
            column13.Width = 240;
            column13.Format = "";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.S_OD_REKAP_OLAKSICEIDRADNIKDescription;
            column2.Width = 0x69;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnnnnn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.S_OD_REKAP_OLAKSICEPREZIMEDescription;
            column14.Width = 0x128;
            column14.Format = "";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.S_OD_REKAP_OLAKSICEIMEDescription;
            column4.Width = 0x128;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.S_OD_REKAP_OLAKSICEJMBGDescription;
            column7.Width = 0x6b;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.S_OD_REKAP_OLAKSICEIDOLAKSICEDescription;
            column.Width = 0x70;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.S_OD_REKAP_OLAKSICEOBRACUNATAOLAKSICADescription;
            column12.Width = 0x8f;
            appearance12.TextHAlign = HAlign.Right;
            column12.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column12.PromptChar = ' ';
            column12.Format = "F2";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.S_OD_REKAP_OLAKSICENAZIVOLAKSICEDescription;
            column10.Width = 0x128;
            column10.Format = "";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.S_OD_REKAP_OLAKSICENAZIVGRUPEOLAKSICADescription;
            column9.Width = 0x128;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.S_OD_REKAP_OLAKSICEIZNOSOLAKSICEDescription;
            column5.Width = 0x74;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column5.PromptChar = ' ';
            column5.Format = "F2";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.S_OD_REKAP_OLAKSICEIDTIPOLAKSICEDescription;
            column3.Width = 0x63;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnn";
            column3.PromptChar = ' ';
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.S_OD_REKAP_OLAKSICENAZIVTIPOLAKSICEDescription;
            column11.Width = 0x128;
            column11.Format = "";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.S_OD_REKAP_OLAKSICEPRIMATELJOLAKSICA1Description;
            column15.Width = 170;
            column15.Format = "";
            column15.CellAppearance = appearance15;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.S_OD_REKAP_OLAKSICEPRIMATELJOLAKSICA2Description;
            column16.Width = 170;
            column16.Format = "";
            column16.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.S_OD_REKAP_OLAKSICEIZNOSPOREZNOPRIZNATEOLAKSICEDescription;
            column6.Width = 210;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column6.PromptChar = ' ';
            column6.Format = "F2";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.NoEdit;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.S_OD_REKAP_OLAKSICEZADPOJEDINACNIPOZIVDescription;
            column17.Width = 0x95;
            column17.Format = "";
            column17.CellAppearance = appearance17;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 0;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 1;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 2;
            band.Columns.Add(column14);
            column14.Header.VisiblePosition = 3;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 4;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 5;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 6;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 7;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 8;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 9;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 10;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 11;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 12;
            band.Columns.Add(column15);
            column15.Header.VisiblePosition = 13;
            band.Columns.Add(column16);
            column16.Header.VisiblePosition = 14;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 15;
            band.Columns.Add(column17);
            column17.Header.VisiblePosition = 0x10;
            this.userControlDataGridS_OD_REKAP_OLAKSICE.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_OD_REKAP_OLAKSICE.Location = point;
            this.userControlDataGridS_OD_REKAP_OLAKSICE.Name = "userControlDataGridS_OD_REKAP_OLAKSICE";
            this.userControlDataGridS_OD_REKAP_OLAKSICE.Tag = "S_OD_REKAP_OLAKSICE";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridS_OD_REKAP_OLAKSICE.Size = size;
            this.userControlDataGridS_OD_REKAP_OLAKSICE.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridS_OD_REKAP_OLAKSICE.Dock = DockStyle.Fill;
            this.userControlDataGridS_OD_REKAP_OLAKSICE.FillAtStartup = false;
            this.userControlDataGridS_OD_REKAP_OLAKSICE.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridS_OD_REKAP_OLAKSICE.InitializeRow += new InitializeRowEventHandler(this.S_OD_REKAP_OLAKSICEUserDataGrid_InitializeRow);
            this.userControlDataGridS_OD_REKAP_OLAKSICE.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridS_OD_REKAP_OLAKSICE });
            this.Name = "S_OD_REKAP_OLAKSICEUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.S_OD_REKAP_OLAKSICEUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridS_OD_REKAP_OLAKSICE).EndInit();
            this.ResumeLayout(false);
        }

        private void S_OD_REKAP_OLAKSICEUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void S_OD_REKAP_OLAKSICEUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual S_OD_REKAP_OLAKSICEDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridS_OD_REKAP_OLAKSICE;
            }
            set
            {
                this.userControlDataGridS_OD_REKAP_OLAKSICE = value;
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


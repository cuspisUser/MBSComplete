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

    public class S_OD_REKAP_KREDITNEUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with S_OD_REKAP_KREDITNE";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with S_OD_REKAP_KREDITNE";
        private S_OD_REKAP_KREDITNEDataGrid userControlDataGridS_OD_REKAP_KREDITNE;

        public S_OD_REKAP_KREDITNEUserDataGrid()
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
            this.userControlDataGridS_OD_REKAP_KREDITNE = new S_OD_REKAP_KREDITNEDataGrid();
            ((ISupportInitialize) this.userControlDataGridS_OD_REKAP_KREDITNE).BeginInit();
            UltraGridBand band = new UltraGridBand("S_OD_REKAP_KREDITNE", -1);
            UltraGridColumn column7 = new UltraGridColumn("OBRACUNATO");
            UltraGridColumn column6 = new UltraGridColumn("NAZIVKREDITOR");
            UltraGridColumn column = new UltraGridColumn("IDKREDITOR");
            UltraGridColumn column9 = new UltraGridColumn("PRIMATELJKREDITOR1");
            UltraGridColumn column10 = new UltraGridColumn("PRIMATELJKREDITOR2");
            UltraGridColumn column8 = new UltraGridColumn("PREZIME");
            UltraGridColumn column3 = new UltraGridColumn("IME");
            UltraGridColumn column4 = new UltraGridColumn("JMBG");
            UltraGridColumn column2 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column5 = new UltraGridColumn("MODELPOZIV");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.S_OD_REKAP_KREDITNEOBRACUNATODescription;
            column7.Width = 0x66;
            appearance7.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column7.PromptChar = ' ';
            column7.Format = "F2";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.S_OD_REKAP_KREDITNENAZIVKREDITORDescription;
            column6.Width = 0x9c;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.S_OD_REKAP_KREDITNEIDKREDITORDescription;
            column.Width = 0x55;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.S_OD_REKAP_KREDITNEPRIMATELJKREDITOR1Description;
            column9.Width = 0x9c;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.S_OD_REKAP_KREDITNEPRIMATELJKREDITOR2Description;
            column10.Width = 0x9c;
            column10.Format = "";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.S_OD_REKAP_KREDITNEPREZIMEDescription;
            column8.Width = 0x128;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.S_OD_REKAP_KREDITNEIMEDescription;
            column3.Width = 0x128;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.S_OD_REKAP_KREDITNEJMBGDescription;
            column4.Width = 0x6b;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.S_OD_REKAP_KREDITNEIDRADNIKDescription;
            column2.Width = 0x69;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnnnnn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.S_OD_REKAP_KREDITNEMODELPOZIVDescription;
            column5.Width = 0xbf;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 0;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 1;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 2;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 3;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 4;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 5;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 6;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 7;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 8;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 9;
            this.userControlDataGridS_OD_REKAP_KREDITNE.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_OD_REKAP_KREDITNE.Location = point;
            this.userControlDataGridS_OD_REKAP_KREDITNE.Name = "userControlDataGridS_OD_REKAP_KREDITNE";
            this.userControlDataGridS_OD_REKAP_KREDITNE.Tag = "S_OD_REKAP_KREDITNE";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridS_OD_REKAP_KREDITNE.Size = size;
            this.userControlDataGridS_OD_REKAP_KREDITNE.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridS_OD_REKAP_KREDITNE.Dock = DockStyle.Fill;
            this.userControlDataGridS_OD_REKAP_KREDITNE.FillAtStartup = false;
            this.userControlDataGridS_OD_REKAP_KREDITNE.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridS_OD_REKAP_KREDITNE.InitializeRow += new InitializeRowEventHandler(this.S_OD_REKAP_KREDITNEUserDataGrid_InitializeRow);
            this.userControlDataGridS_OD_REKAP_KREDITNE.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridS_OD_REKAP_KREDITNE });
            this.Name = "S_OD_REKAP_KREDITNEUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.S_OD_REKAP_KREDITNEUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridS_OD_REKAP_KREDITNE).EndInit();
            this.ResumeLayout(false);
        }

        private void S_OD_REKAP_KREDITNEUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void S_OD_REKAP_KREDITNEUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual S_OD_REKAP_KREDITNEDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridS_OD_REKAP_KREDITNE;
            }
            set
            {
                this.userControlDataGridS_OD_REKAP_KREDITNE = value;
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


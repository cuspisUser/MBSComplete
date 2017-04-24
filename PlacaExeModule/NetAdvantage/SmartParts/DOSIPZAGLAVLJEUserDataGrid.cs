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

    public class DOSIPZAGLAVLJEUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with DOSIPZAGLAVLJE";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with DOSIPZAGLAVLJE";
        private DOSIPZAGLAVLJEDataGrid userControlDataGridDOSIPZAGLAVLJE;

        public DOSIPZAGLAVLJEUserDataGrid()
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

        private void DOSIPZAGLAVLJEUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void DOSIPZAGLAVLJEUserDataGrid_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode && this.FillAtStartup)
            {
                this.DataGrid.Fill();
            }
        }

        public void Fill()
        {
            this.DataGrid.Fill();
        }

        private void InitializeComponent()
        {
            this.userControlDataGridDOSIPZAGLAVLJE = new DOSIPZAGLAVLJEDataGrid();
            ((ISupportInitialize) this.userControlDataGridDOSIPZAGLAVLJE).BeginInit();
            UltraGridBand band = new UltraGridBand("DOSIPZAGLAVLJE", -1);
            UltraGridColumn column = new UltraGridColumn("DOSIPIDENT");
            UltraGridColumn column4 = new UltraGridColumn("DOSJMBG");
            UltraGridColumn column2 = new UltraGridColumn("DOSISPLATAUGODINI");
            UltraGridColumn column3 = new UltraGridColumn("DOSISPLATAZAGODINU");
            UltraGridColumn column5 = new UltraGridColumn("DOSOZNACEN");
            UltraGridBand band2 = new UltraGridBand("DOSIPZAGLAVLJE_DOSIPZAGLAVLJELevel1", 0);
            UltraGridColumn column8 = new UltraGridColumn("DOSIPIDENT");
            UltraGridColumn column9 = new UltraGridColumn("DOSJMBG");
            UltraGridColumn column10 = new UltraGridColumn("DOSMJESECISPLATE");
            UltraGridColumn column7 = new UltraGridColumn("DOSIDOPCINESTANOVANJA");
            UltraGridColumn column13 = new UltraGridColumn("DOSUKUPNOBRUTO");
            UltraGridColumn column14 = new UltraGridColumn("DOSUKUPNODOPRINOSI");
            UltraGridColumn column16 = new UltraGridColumn("DOSUKUPNOOLAKSICE");
            UltraGridColumn column6 = new UltraGridColumn("DOSDOHODAK");
            UltraGridColumn column17 = new UltraGridColumn("DOSUKUPNOOO");
            UltraGridColumn column11 = new UltraGridColumn("DOSPOREZNAOSNOVICA");
            UltraGridColumn column18 = new UltraGridColumn("DOSUKUPNOPOREZIPRIREZ");
            UltraGridColumn column15 = new UltraGridColumn("DOSUKUPNONETOISPLATA");
            UltraGridColumn column12 = new UltraGridColumn("DOSPOSEBANPOREZ");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.DOSIPZAGLAVLJEDOSIPIDENTDescription;
            column.Width = 0x56;
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.DOSIPZAGLAVLJEDOSJMBGDescription;
            column4.Width = 0x6b;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.DOSIPZAGLAVLJEDOSISPLATAUGODINIDescription;
            column2.Width = 0x87;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.DOSIPZAGLAVLJEDOSISPLATAZAGODINUDescription;
            column3.Width = 0x8e;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.DOSIPZAGLAVLJEDOSOZNACENDescription;
            column5.Width = 0x56;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.DOSIPZAGLAVLJEDOSIPIDENTDescription;
            column8.Width = 0x56;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            column8.Hidden = true;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.DOSIPZAGLAVLJEDOSJMBGDescription;
            column9.Width = 0x6b;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            column9.Hidden = true;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.DOSIPZAGLAVLJEDOSMJESECISPLATEDescription;
            column10.Width = 0x80;
            column10.Format = "";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.DOSIPZAGLAVLJEDOSIDOPCINESTANOVANJADescription;
            column7.Width = 0xa3;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.DOSIPZAGLAVLJEDOSUKUPNOBRUTODescription;
            column13.Width = 0x74;
            appearance13.TextHAlign = HAlign.Right;
            column13.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column13.PromptChar = ' ';
            column13.Format = "F2";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.DOSIPZAGLAVLJEDOSUKUPNODOPRINOSIDescription;
            column14.Width = 0x8f;
            appearance14.TextHAlign = HAlign.Right;
            column14.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column14.PromptChar = ' ';
            column14.Format = "F2";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.DOSIPZAGLAVLJEDOSUKUPNOOLAKSICEDescription;
            column16.Width = 0x88;
            appearance16.TextHAlign = HAlign.Right;
            column16.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column16.PromptChar = ' ';
            column16.Format = "F2";
            column16.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.DOSIPZAGLAVLJEDOSDOHODAKDescription;
            column6.Width = 0x66;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column6.PromptChar = ' ';
            column6.Format = "F2";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.NoEdit;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.DOSIPZAGLAVLJEDOSUKUPNOOODescription;
            column17.Width = 0x66;
            appearance17.TextHAlign = HAlign.Right;
            column17.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column17.PromptChar = ' ';
            column17.Format = "F2";
            column17.CellAppearance = appearance17;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.DOSIPZAGLAVLJEDOSPOREZNAOSNOVICADescription;
            column11.Width = 0x8f;
            appearance11.TextHAlign = HAlign.Right;
            column11.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column11.PromptChar = ' ';
            column11.Format = "F2";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column18.CellActivation = Activation.NoEdit;
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.DOSIPZAGLAVLJEDOSUKUPNOPOREZIPRIREZDescription;
            column18.Width = 0xa3;
            appearance18.TextHAlign = HAlign.Right;
            column18.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column18.PromptChar = ' ';
            column18.Format = "F2";
            column18.CellAppearance = appearance18;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.DOSIPZAGLAVLJEDOSUKUPNONETOISPLATADescription;
            column15.Width = 0x9c;
            appearance15.TextHAlign = HAlign.Right;
            column15.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column15.PromptChar = ' ';
            column15.Format = "F2";
            column15.CellAppearance = appearance15;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.DOSIPZAGLAVLJEDOSPOSEBANPOREZDescription;
            column12.Width = 0x7b;
            appearance12.TextHAlign = HAlign.Right;
            column12.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column12.PromptChar = ' ';
            column12.Format = "F2";
            column12.CellAppearance = appearance12;
            band2.Columns.Add(column8);
            column8.Header.VisiblePosition = 0;
            band2.Columns.Add(column9);
            column9.Header.VisiblePosition = 1;
            band2.Columns.Add(column10);
            column10.Header.VisiblePosition = 2;
            band2.Columns.Add(column7);
            column7.Header.VisiblePosition = 3;
            band2.Columns.Add(column13);
            column13.Header.VisiblePosition = 4;
            band2.Columns.Add(column14);
            column14.Header.VisiblePosition = 5;
            band2.Columns.Add(column16);
            column16.Header.VisiblePosition = 6;
            band2.Columns.Add(column6);
            column6.Header.VisiblePosition = 7;
            band2.Columns.Add(column17);
            column17.Header.VisiblePosition = 8;
            band2.Columns.Add(column11);
            column11.Header.VisiblePosition = 9;
            band2.Columns.Add(column18);
            column18.Header.VisiblePosition = 10;
            band2.Columns.Add(column15);
            column15.Header.VisiblePosition = 11;
            band2.Columns.Add(column12);
            column12.Header.VisiblePosition = 12;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 1;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 2;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 3;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 4;
            this.userControlDataGridDOSIPZAGLAVLJE.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridDOSIPZAGLAVLJE.Location = point;
            this.userControlDataGridDOSIPZAGLAVLJE.Name = "userControlDataGridDOSIPZAGLAVLJE";
            this.userControlDataGridDOSIPZAGLAVLJE.Tag = "DOSIPZAGLAVLJE";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridDOSIPZAGLAVLJE.Size = size;
            this.userControlDataGridDOSIPZAGLAVLJE.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridDOSIPZAGLAVLJE.Dock = DockStyle.Fill;
            this.userControlDataGridDOSIPZAGLAVLJE.FillAtStartup = false;
            this.userControlDataGridDOSIPZAGLAVLJE.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridDOSIPZAGLAVLJE.InitializeRow += new InitializeRowEventHandler(this.DOSIPZAGLAVLJEUserDataGrid_InitializeRow);
            this.userControlDataGridDOSIPZAGLAVLJE.DisplayLayout.BandsSerializer.Add(band);
            this.userControlDataGridDOSIPZAGLAVLJE.DisplayLayout.BandsSerializer.Add(band2);
            this.Controls.AddRange(new Control[] { this.userControlDataGridDOSIPZAGLAVLJE });
            this.Name = "DOSIPZAGLAVLJEUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.DOSIPZAGLAVLJEUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridDOSIPZAGLAVLJE).EndInit();
            this.ResumeLayout(false);
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
        public virtual DOSIPZAGLAVLJEDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridDOSIPZAGLAVLJE;
            }
            set
            {
                this.userControlDataGridDOSIPZAGLAVLJE = value;
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

        [Category("Deklarit Work With ")]
        public virtual string FillByDOSIPIDENTDOSIPIDENT
        {
            get
            {
                return this.DataGrid.FillByDOSIPIDENTDOSIPIDENT;
            }
            set
            {
                this.DataGrid.FillByDOSIPIDENTDOSIPIDENT = value;
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

        [Category("Deklarit Work With "), DefaultValue("Fill"), TypeConverter(typeof(DeklaritDataGrid.FillMethodsConverter))]
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


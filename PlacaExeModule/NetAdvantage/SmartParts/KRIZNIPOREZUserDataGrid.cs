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

    public class KRIZNIPOREZUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with KRIZNIPOREZ";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with KRIZNIPOREZ";
        private KRIZNIPOREZDataGrid userControlDataGridKRIZNIPOREZ;

        public KRIZNIPOREZUserDataGrid()
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
            this.userControlDataGridKRIZNIPOREZ = new KRIZNIPOREZDataGrid();
            ((ISupportInitialize) this.userControlDataGridKRIZNIPOREZ).BeginInit();
            UltraGridBand band = new UltraGridBand("KRIZNIPOREZ", -1);
            UltraGridColumn column = new UltraGridColumn("IDKRIZNIPOREZ");
            UltraGridColumn column7 = new UltraGridColumn("NAZIVKRIZNIPOREZ");
            UltraGridColumn column4 = new UltraGridColumn("KRIZNISTOPA");
            UltraGridColumn column3 = new UltraGridColumn("KRIZNIOD");
            UltraGridColumn column2 = new UltraGridColumn("KRIZNIDO");
            UltraGridColumn column5 = new UltraGridColumn("MOKRIZNI");
            UltraGridColumn column9 = new UltraGridColumn("POKRIZNI");
            UltraGridColumn column6 = new UltraGridColumn("MZKRIZNI");
            UltraGridColumn column13 = new UltraGridColumn("PZKRIZNI");
            UltraGridColumn column10 = new UltraGridColumn("PRIMATELJKRIZNI1");
            UltraGridColumn column11 = new UltraGridColumn("PRIMATELJKRIZNI2");
            UltraGridColumn column12 = new UltraGridColumn("PRIMATELJKRIZNI3");
            UltraGridColumn column14 = new UltraGridColumn("SIFRAOPISAPLACANJAKRIZNI");
            UltraGridColumn column8 = new UltraGridColumn("OPISPLACANJAKRIZNI");
            UltraGridColumn column15 = new UltraGridColumn("VBDIKRIZNI");
            UltraGridColumn column16 = new UltraGridColumn("ZRNKRIZNI");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.KRIZNIPOREZIDKRIZNIPOREZDescription;
            column.Width = 0x69;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.KRIZNIPOREZNAZIVKRIZNIPOREZDescription;
            column7.Width = 0x128;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.KRIZNIPOREZKRIZNISTOPADescription;
            column4.Width = 0x37;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnn.nn";
            column4.PromptChar = ' ';
            column4.Format = "F2";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.KRIZNIPOREZKRIZNIODDescription;
            column3.Width = 0x66;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column3.PromptChar = ' ';
            column3.Format = "F2";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.KRIZNIPOREZKRIZNIDODescription;
            column2.Width = 0x66;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column2.PromptChar = ' ';
            column2.Format = "F2";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.KRIZNIPOREZMOKRIZNIDescription;
            column5.Width = 0x79;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.KRIZNIPOREZPOKRIZNIDescription;
            column9.Width = 0xb1;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.KRIZNIPOREZMZKRIZNIDescription;
            column6.Width = 0x79;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.KRIZNIPOREZPZKRIZNIDescription;
            column13.Width = 0xb1;
            column13.Format = "";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.KRIZNIPOREZPRIMATELJKRIZNI1Description;
            column10.Width = 0x9c;
            column10.Format = "";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.KRIZNIPOREZPRIMATELJKRIZNI2Description;
            column11.Width = 0x9c;
            column11.Format = "";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.KRIZNIPOREZPRIMATELJKRIZNI3Description;
            column12.Width = 0x9c;
            column12.Format = "";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.KRIZNIPOREZSIFRAOPISAPLACANJAKRIZNIDescription;
            column14.Width = 0x9c;
            column14.Format = "";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.KRIZNIPOREZOPISPLACANJAKRIZNIDescription;
            column8.Width = 0x10c;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.KRIZNIPOREZVBDIKRIZNIDescription;
            column15.Width = 0x41;
            column15.Format = "";
            column15.CellAppearance = appearance15;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.KRIZNIPOREZZRNKRIZNIDescription;
            column16.Width = 0x56;
            column16.Format = "";
            column16.CellAppearance = appearance16;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 1;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 2;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 3;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 4;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 5;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 6;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 7;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 8;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 9;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 10;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 11;
            band.Columns.Add(column14);
            column14.Header.VisiblePosition = 12;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 13;
            band.Columns.Add(column15);
            column15.Header.VisiblePosition = 14;
            band.Columns.Add(column16);
            column16.Header.VisiblePosition = 15;
            this.userControlDataGridKRIZNIPOREZ.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridKRIZNIPOREZ.Location = point;
            this.userControlDataGridKRIZNIPOREZ.Name = "userControlDataGridKRIZNIPOREZ";
            this.userControlDataGridKRIZNIPOREZ.Tag = "KRIZNIPOREZ";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridKRIZNIPOREZ.Size = size;
            this.userControlDataGridKRIZNIPOREZ.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridKRIZNIPOREZ.Dock = DockStyle.Fill;
            this.userControlDataGridKRIZNIPOREZ.FillAtStartup = false;
            this.userControlDataGridKRIZNIPOREZ.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridKRIZNIPOREZ.InitializeRow += new InitializeRowEventHandler(this.KRIZNIPOREZUserDataGrid_InitializeRow);
            this.userControlDataGridKRIZNIPOREZ.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridKRIZNIPOREZ });
            this.Name = "KRIZNIPOREZUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.KRIZNIPOREZUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridKRIZNIPOREZ).EndInit();
            this.ResumeLayout(false);
        }

        private void KRIZNIPOREZUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void KRIZNIPOREZUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual KRIZNIPOREZDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridKRIZNIPOREZ;
            }
            set
            {
                this.userControlDataGridKRIZNIPOREZ = value;
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

        [DefaultValue("Fill"), Category("Deklarit Work With "), TypeConverter(typeof(DeklaritDataGrid.FillMethodsConverter))]
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


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

    public class PregledRadnikaSvihUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with PregledRadnikaSvih";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with PregledRadnikaSvih";
        private PregledRadnikaSvihDataGrid userControlDataGridPregledRadnikaSvih;

        public PregledRadnikaSvihUserDataGrid()
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
            this.userControlDataGridPregledRadnikaSvih = new PregledRadnikaSvihDataGrid();
            ((ISupportInitialize) this.userControlDataGridPregledRadnikaSvih).BeginInit();
            UltraGridBand band = new UltraGridBand("RADNIK", -1);
            UltraGridColumn column3 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column5 = new UltraGridColumn("JMBG");
            UltraGridColumn column8 = new UltraGridColumn("PREZIME");
            UltraGridColumn column4 = new UltraGridColumn("IME");
            UltraGridColumn column = new UltraGridColumn("AKTIVAN");
            UltraGridColumn column7 = new UltraGridColumn("OPCINASTANOVANJAIDOPCINE");
            UltraGridColumn column2 = new UltraGridColumn("IDORGDIO");
            UltraGridColumn column6 = new UltraGridColumn("OIB");
            UltraGridColumn column9 = new UltraGridColumn("UKUPNIFAKTOR");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.PregledRadnikaSvihIDRADNIKDescription;
            column3.Width = 0x69;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnnnnn";
            column3.PromptChar = ' ';
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.PregledRadnikaSvihJMBGDescription;
            column5.Width = 0x6b;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.PregledRadnikaSvihPREZIMEDescription;
            column8.Width = 0x128;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.PregledRadnikaSvihIMEDescription;
            column4.Width = 0x128;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.PregledRadnikaSvihAKTIVANDescription;
            column.Width = 0x41;
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.PregledRadnikaSvihOPCINASTANOVANJAIDOPCINEDescription;
            column7.Width = 0xb1;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.PregledRadnikaSvihIDORGDIODescription;
            column2.Width = 0xd5;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.PregledRadnikaSvihOIBDescription;
            column6.Width = 0x5d;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.PregledRadnikaSvihUKUPNIFAKTORDescription;
            column9.Width = 0x66;
            appearance9.TextHAlign = HAlign.Right;
            column9.MaskInput = "{LOC}-nnn.nn";
            column9.PromptChar = ' ';
            column9.Format = "F2";
            column9.CellAppearance = appearance9;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 0;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 1;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 2;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 3;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 4;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 5;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 6;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 7;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 8;
            this.userControlDataGridPregledRadnikaSvih.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridPregledRadnikaSvih.Location = point;
            this.userControlDataGridPregledRadnikaSvih.Name = "userControlDataGridPregledRadnikaSvih";
            this.userControlDataGridPregledRadnikaSvih.Tag = "RADNIK";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridPregledRadnikaSvih.Size = size;
            this.userControlDataGridPregledRadnikaSvih.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridPregledRadnikaSvih.Dock = DockStyle.Fill;
            this.userControlDataGridPregledRadnikaSvih.FillAtStartup = false;
            this.userControlDataGridPregledRadnikaSvih.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridPregledRadnikaSvih.InitializeRow += new InitializeRowEventHandler(this.PregledRadnikaSvihUserDataGrid_InitializeRow);
            this.userControlDataGridPregledRadnikaSvih.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridPregledRadnikaSvih });
            this.Name = "PregledRadnikaSvihUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.PregledRadnikaSvihUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridPregledRadnikaSvih).EndInit();
            this.ResumeLayout(false);
        }

        private void PregledRadnikaSvihUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void PregledRadnikaSvihUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual PregledRadnikaSvihDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridPregledRadnikaSvih;
            }
            set
            {
                this.userControlDataGridPregledRadnikaSvih = value;
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


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

    public class trazi_proizvodUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with trazi_proizvod";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with trazi_proizvod";
        private trazi_proizvodDataGrid userControlDataGridtrazi_proizvod;

        public trazi_proizvodUserDataGrid()
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
            this.userControlDataGridtrazi_proizvod = new trazi_proizvodDataGrid();
            ((ISupportInitialize) this.userControlDataGridtrazi_proizvod).BeginInit();
            UltraGridBand band = new UltraGridBand("PROIZVOD", -1);
            UltraGridColumn column5 = new UltraGridColumn("IDPROIZVOD");
            UltraGridColumn column7 = new UltraGridColumn("NAZIVPROIZVOD");
            UltraGridColumn column = new UltraGridColumn("CIJENA");
            UltraGridColumn column2 = new UltraGridColumn("FINPOREZIDPOREZ");
            UltraGridColumn column3 = new UltraGridColumn("FINPOREZSTOPA");
            UltraGridColumn column4 = new UltraGridColumn("IDJEDINICAMJERE");
            UltraGridColumn column6 = new UltraGridColumn("NAZIVJEDINICAMJERE");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.trazi_proizvodIDPROIZVODDescription;
            column5.Width = 0x55;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnnn";
            column5.PromptChar = ' ';
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.trazi_proizvodNAZIVPROIZVODDescription;
            column7.Width = 0x128;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.trazi_proizvodCIJENADescription;
            column.Width = 0x52;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn.nnnn";
            column.PromptChar = ' ';
            column.Format = "F4";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.trazi_proizvodFINPOREZIDPOREZDescription;
            column2.Width = 0x77;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.trazi_proizvodFINPOREZSTOPADescription;
            column3.Width = 0x6d;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnn.nn";
            column3.PromptChar = ' ';
            column3.Format = "F2";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.trazi_proizvodIDJEDINICAMJEREDescription;
            column4.Width = 0x77;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnn";
            column4.PromptChar = ' ';
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.trazi_proizvodNAZIVJEDINICAMJEREDescription;
            column6.Width = 0x128;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 0;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 1;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 2;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 3;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 4;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 5;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 6;
            this.userControlDataGridtrazi_proizvod.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridtrazi_proizvod.Location = point;
            this.userControlDataGridtrazi_proizvod.Name = "userControlDataGridtrazi_proizvod";
            this.userControlDataGridtrazi_proizvod.Tag = "PROIZVOD";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridtrazi_proizvod.Size = size;
            this.userControlDataGridtrazi_proizvod.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridtrazi_proizvod.Dock = DockStyle.Fill;
            this.userControlDataGridtrazi_proizvod.FillAtStartup = false;
            this.userControlDataGridtrazi_proizvod.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridtrazi_proizvod.InitializeRow += new InitializeRowEventHandler(this.trazi_proizvodUserDataGrid_InitializeRow);
            this.userControlDataGridtrazi_proizvod.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridtrazi_proizvod });
            this.Name = "trazi_proizvodUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.trazi_proizvodUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridtrazi_proizvod).EndInit();
            this.ResumeLayout(false);
        }

        private void trazi_proizvodUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void trazi_proizvodUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual trazi_proizvodDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridtrazi_proizvod;
            }
            set
            {
                this.userControlDataGridtrazi_proizvod = value;
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
        public virtual string Parameternazivproizvod
        {
            get
            {
                return this.DataGrid.Parameternazivproizvod;
            }
            set
            {
                this.DataGrid.Parameternazivproizvod = value;
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


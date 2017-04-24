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

    public class PregledRadnikaUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with PregledRadnika";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with PregledRadnika";
        private PregledRadnikaDataGrid userControlDataGridPregledRadnika;

        public PregledRadnikaUserDataGrid()
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
            this.userControlDataGridPregledRadnika = new PregledRadnikaDataGrid();
            ((ISupportInitialize) this.userControlDataGridPregledRadnika).BeginInit();
            UltraGridBand band = new UltraGridBand("RADNIK", -1);
            UltraGridColumn column2 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column4 = new UltraGridColumn("JMBG");
            UltraGridColumn column6 = new UltraGridColumn("PREZIME");
            UltraGridColumn column3 = new UltraGridColumn("IME");
            UltraGridColumn column = new UltraGridColumn("AKTIVAN");
            UltraGridColumn column5 = new UltraGridColumn("OPCINASTANOVANJAIDOPCINE");
            UltraGridColumn column7 = new UltraGridColumn("SPOJENOPREZIME");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.PregledRadnikaIDRADNIKDescription;
            column2.Width = 0x69;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnnnnn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.PregledRadnikaJMBGDescription;
            column4.Width = 0x6b;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.PregledRadnikaPREZIMEDescription;
            column6.Width = 0x128;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.PregledRadnikaIMEDescription;
            column3.Width = 0x128;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.PregledRadnikaAKTIVANDescription;
            column.Width = 0x41;
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.PregledRadnikaOPCINASTANOVANJAIDOPCINEDescription;
            column5.Width = 0xb1;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.PregledRadnikaSPOJENOPREZIMEDescription;
            column7.Width = 0x128;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 0;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 1;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 2;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 3;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 4;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 5;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 6;
            this.userControlDataGridPregledRadnika.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridPregledRadnika.Location = point;
            this.userControlDataGridPregledRadnika.Name = "userControlDataGridPregledRadnika";
            this.userControlDataGridPregledRadnika.Tag = "RADNIK";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridPregledRadnika.Size = size;
            this.userControlDataGridPregledRadnika.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridPregledRadnika.Dock = DockStyle.Fill;
            this.userControlDataGridPregledRadnika.FillAtStartup = false;
            this.userControlDataGridPregledRadnika.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridPregledRadnika.InitializeRow += new InitializeRowEventHandler(this.PregledRadnikaUserDataGrid_InitializeRow);
            this.userControlDataGridPregledRadnika.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridPregledRadnika });
            this.Name = "PregledRadnikaUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.PregledRadnikaUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridPregledRadnika).EndInit();
            this.ResumeLayout(false);
        }

        private void PregledRadnikaUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void PregledRadnikaUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual PregledRadnikaDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridPregledRadnika;
            }
            set
            {
                this.userControlDataGridPregledRadnika = value;
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


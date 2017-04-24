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

    public class S_OS_STANJE_LOKACIJAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with S_OS_STANJE_LOKACIJA";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with S_OS_STANJE_LOKACIJA";
        private S_OS_STANJE_LOKACIJADataGrid userControlDataGridS_OS_STANJE_LOKACIJA;

        public S_OS_STANJE_LOKACIJAUserDataGrid()
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
            this.userControlDataGridS_OS_STANJE_LOKACIJA = new S_OS_STANJE_LOKACIJADataGrid();
            ((ISupportInitialize) this.userControlDataGridS_OS_STANJE_LOKACIJA).BeginInit();
            UltraGridBand band = new UltraGridBand("S_OS_STANJE_LOKACIJA", -1);
            UltraGridColumn column = new UltraGridColumn("IDLOKACIJE");
            UltraGridColumn column2 = new UltraGridColumn("INVBROJ");
            UltraGridColumn column6 = new UltraGridColumn("ULAZ");
            UltraGridColumn column3 = new UltraGridColumn("IZLAZ");
            UltraGridColumn column5 = new UltraGridColumn("STANJE");
            UltraGridColumn column4 = new UltraGridColumn("OPISLOKACIJE");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.S_OS_STANJE_LOKACIJAIDLOKACIJEDescription;
            column.Width = 0x48;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.S_OS_STANJE_LOKACIJAINVBROJDescription;
            column2.Width = 0x63;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnnnnnnnnn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.S_OS_STANJE_LOKACIJAULAZDescription;
            column6.Width = 0x66;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column6.PromptChar = ' ';
            column6.Format = "F2";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.S_OS_STANJE_LOKACIJAIZLAZDescription;
            column3.Width = 0x66;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column3.PromptChar = ' ';
            column3.Format = "F2";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.S_OS_STANJE_LOKACIJASTANJEDescription;
            column5.Width = 0x66;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column5.PromptChar = ' ';
            column5.Format = "F2";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.S_OS_STANJE_LOKACIJAOPISLOKACIJEDescription;
            column4.Width = 0x128;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 2;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 3;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 4;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 5;
            this.userControlDataGridS_OS_STANJE_LOKACIJA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_OS_STANJE_LOKACIJA.Location = point;
            this.userControlDataGridS_OS_STANJE_LOKACIJA.Name = "userControlDataGridS_OS_STANJE_LOKACIJA";
            this.userControlDataGridS_OS_STANJE_LOKACIJA.Tag = "S_OS_STANJE_LOKACIJA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridS_OS_STANJE_LOKACIJA.Size = size;
            this.userControlDataGridS_OS_STANJE_LOKACIJA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridS_OS_STANJE_LOKACIJA.Dock = DockStyle.Fill;
            this.userControlDataGridS_OS_STANJE_LOKACIJA.FillAtStartup = false;
            this.userControlDataGridS_OS_STANJE_LOKACIJA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridS_OS_STANJE_LOKACIJA.InitializeRow += new InitializeRowEventHandler(this.S_OS_STANJE_LOKACIJAUserDataGrid_InitializeRow);
            this.userControlDataGridS_OS_STANJE_LOKACIJA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridS_OS_STANJE_LOKACIJA });
            this.Name = "S_OS_STANJE_LOKACIJAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.S_OS_STANJE_LOKACIJAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridS_OS_STANJE_LOKACIJA).EndInit();
            this.ResumeLayout(false);
        }

        private void S_OS_STANJE_LOKACIJAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void S_OS_STANJE_LOKACIJAUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual S_OS_STANJE_LOKACIJADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridS_OS_STANJE_LOKACIJA;
            }
            set
            {
                this.userControlDataGridS_OS_STANJE_LOKACIJA = value;
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
        public virtual long Parameterinvbroj
        {
            get
            {
                return this.DataGrid.Parameterinvbroj;
            }
            set
            {
                this.DataGrid.Parameterinvbroj = value;
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


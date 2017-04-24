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

    public class ZATVARANJAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with ZATVARANJA";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with ZATVARANJA";
        private ZATVARANJADataGrid userControlDataGridZATVARANJA;

        public ZATVARANJAUserDataGrid()
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
            this.userControlDataGridZATVARANJA = new ZATVARANJADataGrid();
            ((ISupportInitialize) this.userControlDataGridZATVARANJA).BeginInit();
            UltraGridBand band = new UltraGridBand("ZATVARANJA", -1);
            UltraGridColumn column = new UltraGridColumn("GK1IDGKSTAVKA");
            UltraGridColumn column2 = new UltraGridColumn("GK2IDGKSTAVKA");
            UltraGridColumn column3 = new UltraGridColumn("ZATVARANJAIZNOS");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.ZATVARANJAGK1IDGKSTAVKADescription;
            column.Width = 0x55;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.ZATVARANJAGK2IDGKSTAVKADescription;
            column2.Width = 0x55;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.ZATVARANJAZATVARANJAIZNOSDescription;
            column3.Width = 0x7b;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column3.PromptChar = ' ';
            column3.Format = "F2";
            column3.CellAppearance = appearance3;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 2;
            this.userControlDataGridZATVARANJA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridZATVARANJA.Location = point;
            this.userControlDataGridZATVARANJA.Name = "userControlDataGridZATVARANJA";
            this.userControlDataGridZATVARANJA.Tag = "ZATVARANJA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridZATVARANJA.Size = size;
            this.userControlDataGridZATVARANJA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridZATVARANJA.Dock = DockStyle.Fill;
            this.userControlDataGridZATVARANJA.FillAtStartup = false;
            this.userControlDataGridZATVARANJA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridZATVARANJA.InitializeRow += new InitializeRowEventHandler(this.ZATVARANJAUserDataGrid_InitializeRow);
            this.userControlDataGridZATVARANJA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridZATVARANJA });
            this.Name = "ZATVARANJAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.ZATVARANJAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridZATVARANJA).EndInit();
            this.ResumeLayout(false);
        }

        private void ZATVARANJAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void ZATVARANJAUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual ZATVARANJADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridZATVARANJA;
            }
            set
            {
                this.userControlDataGridZATVARANJA = value;
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

        [Description("True= Fill at Startup. False= Not Fill"), DefaultValue(true), Category("Deklarit Work With ")]
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
        public virtual int FillByGK1IDGKSTAVKAGK1IDGKSTAVKA
        {
            get
            {
                return this.DataGrid.FillByGK1IDGKSTAVKAGK1IDGKSTAVKA;
            }
            set
            {
                this.DataGrid.FillByGK1IDGKSTAVKAGK1IDGKSTAVKA = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByGK2IDGKSTAVKAGK2IDGKSTAVKA
        {
            get
            {
                return this.DataGrid.FillByGK2IDGKSTAVKAGK2IDGKSTAVKA;
            }
            set
            {
                this.DataGrid.FillByGK2IDGKSTAVKAGK2IDGKSTAVKA = value;
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

        [DefaultValue("Fill"), TypeConverter(typeof(DeklaritDataGrid.FillMethodsConverter)), Category("Deklarit Work With ")]
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


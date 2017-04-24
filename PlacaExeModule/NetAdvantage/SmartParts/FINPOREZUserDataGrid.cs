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

    public class FINPOREZUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with FINPOREZ";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with FINPOREZ";
        private FINPOREZDataGrid userControlDataGridFINPOREZ;

        public FINPOREZUserDataGrid()
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

        private void FINPOREZUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void FINPOREZUserDataGrid_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode && this.FillAtStartup)
            {
                this.DataGrid.Fill();
            }
        }

        private void InitializeComponent()
        {
            this.userControlDataGridFINPOREZ = new FINPOREZDataGrid();
            ((ISupportInitialize) this.userControlDataGridFINPOREZ).BeginInit();
            UltraGridBand band = new UltraGridBand("FINPOREZ", -1);
            UltraGridColumn column = new UltraGridColumn("FINPOREZIDPOREZ");
            UltraGridColumn column2 = new UltraGridColumn("FINPOREZNAZIVPOREZ");
            UltraGridColumn column3 = new UltraGridColumn("FINPOREZSTOPA");
            UltraGridColumn column4 = new UltraGridColumn("OSNOVICAUKNIZIIRA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.FINPOREZFINPOREZIDPOREZDescription;
            column.Width = 0x33;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.FINPOREZFINPOREZNAZIVPOREZDescription;
            column2.Width = 0xe2;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.FINPOREZFINPOREZSTOPADescription;
            column3.Width = 0x37;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnn.nn";
            column3.PromptChar = ' ';
            column3.Format = "F2";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.FINPOREZOSNOVICAUKNIZIIRADescription;
            column4.Width = 0xa6;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnn";
            column4.PromptChar = ' ';
            column4.Format = "";
            column4.CellAppearance = appearance4;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 2;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 3;
            this.userControlDataGridFINPOREZ.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridFINPOREZ.Location = point;
            this.userControlDataGridFINPOREZ.Name = "userControlDataGridFINPOREZ";
            this.userControlDataGridFINPOREZ.Tag = "FINPOREZ";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridFINPOREZ.Size = size;
            this.userControlDataGridFINPOREZ.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridFINPOREZ.Dock = DockStyle.Fill;
            this.userControlDataGridFINPOREZ.FillAtStartup = false;
            this.userControlDataGridFINPOREZ.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridFINPOREZ.InitializeRow += new InitializeRowEventHandler(this.FINPOREZUserDataGrid_InitializeRow);
            this.userControlDataGridFINPOREZ.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridFINPOREZ });
            this.Name = "FINPOREZUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.FINPOREZUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridFINPOREZ).EndInit();
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
        public virtual FINPOREZDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridFINPOREZ;
            }
            set
            {
                this.userControlDataGridFINPOREZ = value;
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


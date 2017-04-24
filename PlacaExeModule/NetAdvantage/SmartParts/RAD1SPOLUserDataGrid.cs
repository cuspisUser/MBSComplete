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

    public class RAD1SPOLUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with RAD1SPOL";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with RAD1SPOL";
        private RAD1SPOLDataGrid userControlDataGridRAD1SPOL;

        public RAD1SPOLUserDataGrid()
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
            this.userControlDataGridRAD1SPOL = new RAD1SPOLDataGrid();
            ((ISupportInitialize) this.userControlDataGridRAD1SPOL).BeginInit();
            UltraGridBand band = new UltraGridBand("RAD1SPOL", -1);
            UltraGridColumn column = new UltraGridColumn("RAD1SPOLID");
            UltraGridColumn column2 = new UltraGridColumn("RAD1SPOLNAZIV");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.RAD1SPOLRAD1SPOLIDDescription;
            column.Width = 0x5c;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.RAD1SPOLRAD1SPOLNAZIVDescription;
            column2.Width = 0x9c;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            this.userControlDataGridRAD1SPOL.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridRAD1SPOL.Location = point;
            this.userControlDataGridRAD1SPOL.Name = "userControlDataGridRAD1SPOL";
            this.userControlDataGridRAD1SPOL.Tag = "RAD1SPOL";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridRAD1SPOL.Size = size;
            this.userControlDataGridRAD1SPOL.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridRAD1SPOL.Dock = DockStyle.Fill;
            this.userControlDataGridRAD1SPOL.FillAtStartup = false;
            this.userControlDataGridRAD1SPOL.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridRAD1SPOL.InitializeRow += new InitializeRowEventHandler(this.RAD1SPOLUserDataGrid_InitializeRow);
            this.userControlDataGridRAD1SPOL.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridRAD1SPOL });
            this.Name = "RAD1SPOLUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.RAD1SPOLUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridRAD1SPOL).EndInit();
            this.ResumeLayout(false);
        }

        private void RAD1SPOLUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void RAD1SPOLUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual RAD1SPOLDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridRAD1SPOL;
            }
            set
            {
                this.userControlDataGridRAD1SPOL = value;
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

        [TypeConverter(typeof(DeklaritDataGrid.FillMethodsConverter)), DefaultValue("Fill"), Category("Deklarit Work With ")]
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


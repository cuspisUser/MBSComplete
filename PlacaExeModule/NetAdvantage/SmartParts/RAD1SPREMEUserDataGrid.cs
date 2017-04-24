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

    public class RAD1SPREMEUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with RAD1SPREME";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with RAD1SPREME";
        private RAD1SPREMEDataGrid userControlDataGridRAD1SPREME;

        public RAD1SPREMEUserDataGrid()
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
            this.userControlDataGridRAD1SPREME = new RAD1SPREMEDataGrid();
            ((ISupportInitialize) this.userControlDataGridRAD1SPREME).BeginInit();
            UltraGridBand band = new UltraGridBand("RAD1SPREME", -1);
            UltraGridColumn column = new UltraGridColumn("RAD1IDSPREME");
            UltraGridColumn column2 = new UltraGridColumn("RAD1NAZIVSPREME");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.RAD1SPREMERAD1IDSPREMEDescription;
            column.Width = 0x69;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.RAD1SPREMERAD1NAZIVSPREMEDescription;
            column2.Width = 0x128;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            this.userControlDataGridRAD1SPREME.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridRAD1SPREME.Location = point;
            this.userControlDataGridRAD1SPREME.Name = "userControlDataGridRAD1SPREME";
            this.userControlDataGridRAD1SPREME.Tag = "RAD1SPREME";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridRAD1SPREME.Size = size;
            this.userControlDataGridRAD1SPREME.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridRAD1SPREME.Dock = DockStyle.Fill;
            this.userControlDataGridRAD1SPREME.FillAtStartup = false;
            this.userControlDataGridRAD1SPREME.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridRAD1SPREME.InitializeRow += new InitializeRowEventHandler(this.RAD1SPREMEUserDataGrid_InitializeRow);
            this.userControlDataGridRAD1SPREME.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridRAD1SPREME });
            this.Name = "RAD1SPREMEUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.RAD1SPREMEUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridRAD1SPREME).EndInit();
            this.ResumeLayout(false);
        }

        private void RAD1SPREMEUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void RAD1SPREMEUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual RAD1SPREMEDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridRAD1SPREME;
            }
            set
            {
                this.userControlDataGridRAD1SPREME = value;
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

        [TypeConverter(typeof(DeklaritDataGrid.FillMethodsConverter)), Category("Deklarit Work With "), DefaultValue("Fill")]
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


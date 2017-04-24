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

    public class VERZIJAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with VERZIJA";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with VERZIJA";
        private VERZIJADataGrid userControlDataGridVERZIJA;

        public VERZIJAUserDataGrid()
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
            this.userControlDataGridVERZIJA = new VERZIJADataGrid();
            ((ISupportInitialize) this.userControlDataGridVERZIJA).BeginInit();
            UltraGridBand band = new UltraGridBand("VERZIJA", -1);
            UltraGridColumn column = new UltraGridColumn("IDVERZIJA");
            UltraGridColumn column2 = new UltraGridColumn("VERZIJA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.VERZIJAIDVERZIJADescription;
            column.Width = 0x4e;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.VERZIJAVERZIJADescription;
            column2.Width = 0x9c;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            this.userControlDataGridVERZIJA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridVERZIJA.Location = point;
            this.userControlDataGridVERZIJA.Name = "userControlDataGridVERZIJA";
            this.userControlDataGridVERZIJA.Tag = "VERZIJA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridVERZIJA.Size = size;
            this.userControlDataGridVERZIJA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridVERZIJA.Dock = DockStyle.Fill;
            this.userControlDataGridVERZIJA.FillAtStartup = false;
            this.userControlDataGridVERZIJA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridVERZIJA.InitializeRow += new InitializeRowEventHandler(this.VERZIJAUserDataGrid_InitializeRow);
            this.userControlDataGridVERZIJA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridVERZIJA });
            this.Name = "VERZIJAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.VERZIJAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridVERZIJA).EndInit();
            this.ResumeLayout(false);
        }

        private void VERZIJAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void VERZIJAUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual VERZIJADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridVERZIJA;
            }
            set
            {
                this.userControlDataGridVERZIJA = value;
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


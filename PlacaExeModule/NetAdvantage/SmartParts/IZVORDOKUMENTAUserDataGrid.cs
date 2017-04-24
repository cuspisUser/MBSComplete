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

    public class IZVORDOKUMENTAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with IZVORDOKUMENTA";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with IZVORDOKUMENTA";
        private IZVORDOKUMENTADataGrid userControlDataGridIZVORDOKUMENTA;

        public IZVORDOKUMENTAUserDataGrid()
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
            this.userControlDataGridIZVORDOKUMENTA = new IZVORDOKUMENTADataGrid();
            ((ISupportInitialize) this.userControlDataGridIZVORDOKUMENTA).BeginInit();
            UltraGridBand band = new UltraGridBand("IZVORDOKUMENTA", -1);
            UltraGridColumn column2 = new UltraGridColumn("SIFRAIZVORA");
            UltraGridColumn column = new UltraGridColumn("NAZIVIZVORA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.IZVORDOKUMENTASIFRAIZVORADescription;
            column2.Width = 0x5d;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.IZVORDOKUMENTANAZIVIZVORADescription;
            column.Width = 0x9c;
            column.Format = "";
            column.CellAppearance = appearance;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 0;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 1;
            this.userControlDataGridIZVORDOKUMENTA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridIZVORDOKUMENTA.Location = point;
            this.userControlDataGridIZVORDOKUMENTA.Name = "userControlDataGridIZVORDOKUMENTA";
            this.userControlDataGridIZVORDOKUMENTA.Tag = "IZVORDOKUMENTA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridIZVORDOKUMENTA.Size = size;
            this.userControlDataGridIZVORDOKUMENTA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridIZVORDOKUMENTA.Dock = DockStyle.Fill;
            this.userControlDataGridIZVORDOKUMENTA.FillAtStartup = false;
            this.userControlDataGridIZVORDOKUMENTA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridIZVORDOKUMENTA.InitializeRow += new InitializeRowEventHandler(this.IZVORDOKUMENTAUserDataGrid_InitializeRow);
            this.userControlDataGridIZVORDOKUMENTA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridIZVORDOKUMENTA });
            this.Name = "IZVORDOKUMENTAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.IZVORDOKUMENTAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridIZVORDOKUMENTA).EndInit();
            this.ResumeLayout(false);
        }

        private void IZVORDOKUMENTAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void IZVORDOKUMENTAUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual IZVORDOKUMENTADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridIZVORDOKUMENTA;
            }
            set
            {
                this.userControlDataGridIZVORDOKUMENTA = value;
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


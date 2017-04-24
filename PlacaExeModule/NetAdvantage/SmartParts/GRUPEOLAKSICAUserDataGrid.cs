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

    public class GRUPEOLAKSICAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Grupe olakšica";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Grupe olakšica";
        private GRUPEOLAKSICADataGrid userControlDataGridGRUPEOLAKSICA;

        public GRUPEOLAKSICAUserDataGrid()
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

        private void GRUPEOLAKSICAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void GRUPEOLAKSICAUserDataGrid_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode && this.FillAtStartup)
            {
                this.DataGrid.Fill();
            }
        }

        private void InitializeComponent()
        {
            this.userControlDataGridGRUPEOLAKSICA = new GRUPEOLAKSICADataGrid();
            ((ISupportInitialize) this.userControlDataGridGRUPEOLAKSICA).BeginInit();
            UltraGridBand band = new UltraGridBand("GRUPEOLAKSICA", -1);
            UltraGridColumn column = new UltraGridColumn("IDGRUPEOLAKSICA");
            UltraGridColumn column3 = new UltraGridColumn("NAZIVGRUPEOLAKSICA");
            UltraGridColumn column2 = new UltraGridColumn("MAXIMALNIIZNOSGRUPE");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.GRUPEOLAKSICAIDGRUPEOLAKSICADescription;
            column.Width = 0x99;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.GRUPEOLAKSICANAZIVGRUPEOLAKSICADescription;
            column3.Width = 0x128;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.GRUPEOLAKSICAMAXIMALNIIZNOSGRUPEDescription;
            column2.Width = 210;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column2.PromptChar = ' ';
            column2.Format = "F2";
            column2.CellAppearance = appearance2;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 1;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 2;
            this.userControlDataGridGRUPEOLAKSICA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridGRUPEOLAKSICA.Location = point;
            this.userControlDataGridGRUPEOLAKSICA.Name = "userControlDataGridGRUPEOLAKSICA";
            this.userControlDataGridGRUPEOLAKSICA.Tag = "GRUPEOLAKSICA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridGRUPEOLAKSICA.Size = size;
            this.userControlDataGridGRUPEOLAKSICA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridGRUPEOLAKSICA.Dock = DockStyle.Fill;
            this.userControlDataGridGRUPEOLAKSICA.FillAtStartup = false;
            this.userControlDataGridGRUPEOLAKSICA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridGRUPEOLAKSICA.InitializeRow += new InitializeRowEventHandler(this.GRUPEOLAKSICAUserDataGrid_InitializeRow);
            this.userControlDataGridGRUPEOLAKSICA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridGRUPEOLAKSICA });
            this.Name = "GRUPEOLAKSICAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.GRUPEOLAKSICAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridGRUPEOLAKSICA).EndInit();
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
        public virtual GRUPEOLAKSICADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridGRUPEOLAKSICA;
            }
            set
            {
                this.userControlDataGridGRUPEOLAKSICA = value;
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

        [DefaultValue(true), Description("True= Fill at Startup. False= Not Fill"), Category("Deklarit Work With ")]
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


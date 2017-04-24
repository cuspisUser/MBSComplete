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

    public class KREDITORUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Kreditori";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Kreditori";
        private KREDITORDataGrid userControlDataGridKREDITOR;

        public KREDITORUserDataGrid()
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
            this.userControlDataGridKREDITOR = new KREDITORDataGrid();
            ((ISupportInitialize) this.userControlDataGridKREDITOR).BeginInit();
            UltraGridBand band = new UltraGridBand("KREDITOR", -1);
            UltraGridColumn column = new UltraGridColumn("IDKREDITOR");
            UltraGridColumn column2 = new UltraGridColumn("NAZIVKREDITOR");
            UltraGridColumn column6 = new UltraGridColumn("VBDIKREDITOR");
            UltraGridColumn column7 = new UltraGridColumn("ZRNKREDITOR");
            UltraGridColumn column3 = new UltraGridColumn("PRIMATELJKREDITOR1");
            UltraGridColumn column4 = new UltraGridColumn("PRIMATELJKREDITOR2");
            UltraGridColumn column5 = new UltraGridColumn("PRIMATELJKREDITOR3");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.KREDITORIDKREDITORDescription;
            column.Width = 0x77;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.KREDITORNAZIVKREDITORDescription;
            column2.Width = 0x9c;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.KREDITORVBDIKREDITORDescription;
            column6.Width = 0x72;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.KREDITORZRNKREDITORDescription;
            column7.Width = 0x6b;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.KREDITORPRIMATELJKREDITOR1Description;
            column3.Width = 170;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.KREDITORPRIMATELJKREDITOR2Description;
            column4.Width = 170;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.KREDITORPRIMATELJKREDITOR3Description;
            column5.Width = 170;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 2;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 3;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 4;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 5;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 6;
            this.userControlDataGridKREDITOR.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridKREDITOR.Location = point;
            this.userControlDataGridKREDITOR.Name = "userControlDataGridKREDITOR";
            this.userControlDataGridKREDITOR.Tag = "KREDITOR";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridKREDITOR.Size = size;
            this.userControlDataGridKREDITOR.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridKREDITOR.Dock = DockStyle.Fill;
            this.userControlDataGridKREDITOR.FillAtStartup = false;
            this.userControlDataGridKREDITOR.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridKREDITOR.InitializeRow += new InitializeRowEventHandler(this.KREDITORUserDataGrid_InitializeRow);
            this.userControlDataGridKREDITOR.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridKREDITOR });
            this.Name = "KREDITORUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.KREDITORUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridKREDITOR).EndInit();
            this.ResumeLayout(false);
        }

        private void KREDITORUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void KREDITORUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual KREDITORDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridKREDITOR;
            }
            set
            {
                this.userControlDataGridKREDITOR = value;
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


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

    public class OPCINAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Opaine";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Opaine";
        private OPCINADataGrid userControlDataGridOPCINA;

        public OPCINAUserDataGrid()
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
            this.userControlDataGridOPCINA = new OPCINADataGrid();
            ((ISupportInitialize) this.userControlDataGridOPCINA).BeginInit();
            UltraGridBand band = new UltraGridBand("OPCINA", -1);
            UltraGridColumn column = new UltraGridColumn("IDOPCINE");
            UltraGridColumn column2 = new UltraGridColumn("NAZIVOPCINE");
            UltraGridColumn column3 = new UltraGridColumn("PRIREZ");
            UltraGridColumn column4 = new UltraGridColumn("VBDIOPCINA");
            UltraGridColumn column5 = new UltraGridColumn("ZRNOPCINA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.OPCINAIDOPCINEDescription;
            column.Width = 100;
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.OPCINANAZIVOPCINEDescription;
            column2.Width = 0x128;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.OPCINAPRIREZDescription;
            column3.Width = 0x6d;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column3.PromptChar = ' ';
            column3.Format = "F2";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.OPCINAVBDIOPCINADescription;
            column4.Width = 0xb1;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.OPCINAZRNOPCINADescription;
            column5.Width = 0xb1;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 2;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 3;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 4;
            this.userControlDataGridOPCINA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridOPCINA.Location = point;
            this.userControlDataGridOPCINA.Name = "userControlDataGridOPCINA";
            this.userControlDataGridOPCINA.Tag = "OPCINA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridOPCINA.Size = size;
            this.userControlDataGridOPCINA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridOPCINA.Dock = DockStyle.Fill;
            this.userControlDataGridOPCINA.FillAtStartup = false;
            this.userControlDataGridOPCINA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridOPCINA.InitializeRow += new InitializeRowEventHandler(this.OPCINAUserDataGrid_InitializeRow);
            this.userControlDataGridOPCINA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridOPCINA });
            this.Name = "OPCINAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.OPCINAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridOPCINA).EndInit();
            this.ResumeLayout(false);
        }

        private void OPCINAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void OPCINAUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual OPCINADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridOPCINA;
            }
            set
            {
                this.userControlDataGridOPCINA = value;
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


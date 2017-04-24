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

    public class BENEFICIRANIUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Beneficirani radni staž";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Beneficirani radni staž";
        private BENEFICIRANIDataGrid userControlDataGridBENEFICIRANI;

        public BENEFICIRANIUserDataGrid()
        {
            this.InitializeComponent();
        }

        private void BENEFICIRANIUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void BENEFICIRANIUserDataGrid_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode && this.FillAtStartup)
            {
                this.DataGrid.Fill();
            }
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
            this.userControlDataGridBENEFICIRANI = new BENEFICIRANIDataGrid();
            ((ISupportInitialize) this.userControlDataGridBENEFICIRANI).BeginInit();
            UltraGridBand band = new UltraGridBand("BENEFICIRANI", -1);
            UltraGridColumn column2 = new UltraGridColumn("IDBENEFICIRANI");
            UltraGridColumn column3 = new UltraGridColumn("NAZIVBENEFICIRANI");
            UltraGridColumn column = new UltraGridColumn("BROJPRIZNATIHMJESECI");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.BENEFICIRANIIDBENEFICIRANIDescription;
            column2.Width = 240;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.BENEFICIRANINAZIVBENEFICIRANIDescription;
            column3.Width = 0x128;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.BENEFICIRANIBROJPRIZNATIHMJESECIDescription;
            column.Width = 0x120;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 0;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 1;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 2;
            this.userControlDataGridBENEFICIRANI.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridBENEFICIRANI.Location = point;
            this.userControlDataGridBENEFICIRANI.Name = "userControlDataGridBENEFICIRANI";
            this.userControlDataGridBENEFICIRANI.Tag = "BENEFICIRANI";
            this.userControlDataGridBENEFICIRANI.Size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridBENEFICIRANI.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridBENEFICIRANI.Dock = DockStyle.Fill;
            this.userControlDataGridBENEFICIRANI.FillAtStartup = false;
            this.userControlDataGridBENEFICIRANI.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridBENEFICIRANI.InitializeRow += new InitializeRowEventHandler(this.BENEFICIRANIUserDataGrid_InitializeRow);
            this.userControlDataGridBENEFICIRANI.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridBENEFICIRANI });
            this.Name = "BENEFICIRANIUserDataGrid";
            this.Size = new System.Drawing.Size(0x200, 0x144);
            this.Load += new EventHandler(this.BENEFICIRANIUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridBENEFICIRANI).EndInit();
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
        public virtual BENEFICIRANIDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridBENEFICIRANI;
            }
            set
            {
                this.userControlDataGridBENEFICIRANI = value;
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


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

    public class RADNOVRIJEMEUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with RADNOVRIJEME";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with RADNOVRIJEME";
        private RADNOVRIJEMEDataGrid userControlDataGridRADNOVRIJEME;

        public RADNOVRIJEMEUserDataGrid()
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
            this.userControlDataGridRADNOVRIJEME = new RADNOVRIJEMEDataGrid();
            ((ISupportInitialize) this.userControlDataGridRADNOVRIJEME).BeginInit();
            UltraGridBand band = new UltraGridBand("RADNOVRIJEME", -1);
            UltraGridColumn column = new UltraGridColumn("IDRADNOVRIJEME");
            UltraGridColumn column2 = new UltraGridColumn("NAZIVRADNOVRIJEME");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.RADNOVRIJEMEIDRADNOVRIJEMEDescription;
            column.Width = 0x70;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.RADNOVRIJEMENAZIVRADNOVRIJEMEDescription;
            column2.Width = 0x128;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            this.userControlDataGridRADNOVRIJEME.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridRADNOVRIJEME.Location = point;
            this.userControlDataGridRADNOVRIJEME.Name = "userControlDataGridRADNOVRIJEME";
            this.userControlDataGridRADNOVRIJEME.Tag = "RADNOVRIJEME";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridRADNOVRIJEME.Size = size;
            this.userControlDataGridRADNOVRIJEME.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridRADNOVRIJEME.Dock = DockStyle.Fill;
            this.userControlDataGridRADNOVRIJEME.FillAtStartup = false;
            this.userControlDataGridRADNOVRIJEME.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridRADNOVRIJEME.InitializeRow += new InitializeRowEventHandler(this.RADNOVRIJEMEUserDataGrid_InitializeRow);
            this.userControlDataGridRADNOVRIJEME.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridRADNOVRIJEME });
            this.Name = "RADNOVRIJEMEUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.RADNOVRIJEMEUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridRADNOVRIJEME).EndInit();
            this.ResumeLayout(false);
        }

        private void RADNOVRIJEMEUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void RADNOVRIJEMEUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual RADNOVRIJEMEDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridRADNOVRIJEME;
            }
            set
            {
                this.userControlDataGridRADNOVRIJEME = value;
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


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

    public class PLVRSTEIZNOSAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with PLVRSTEIZNOSA";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with PLVRSTEIZNOSA";
        private PLVRSTEIZNOSADataGrid userControlDataGridPLVRSTEIZNOSA;

        public PLVRSTEIZNOSAUserDataGrid()
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
            this.userControlDataGridPLVRSTEIZNOSA = new PLVRSTEIZNOSADataGrid();
            ((ISupportInitialize) this.userControlDataGridPLVRSTEIZNOSA).BeginInit();
            UltraGridBand band = new UltraGridBand("PLVRSTEIZNOSA", -1);
            UltraGridColumn column = new UltraGridColumn("IDPLVRSTEIZNOSA");
            UltraGridColumn column2 = new UltraGridColumn("NAZIVPLVRSTEIZNOSA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.PLVRSTEIZNOSAIDPLVRSTEIZNOSADescription;
            column.Width = 0x33;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.PLVRSTEIZNOSANAZIVPLVRSTEIZNOSADescription;
            column2.Width = 0x128;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            this.userControlDataGridPLVRSTEIZNOSA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridPLVRSTEIZNOSA.Location = point;
            this.userControlDataGridPLVRSTEIZNOSA.Name = "userControlDataGridPLVRSTEIZNOSA";
            this.userControlDataGridPLVRSTEIZNOSA.Tag = "PLVRSTEIZNOSA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridPLVRSTEIZNOSA.Size = size;
            this.userControlDataGridPLVRSTEIZNOSA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridPLVRSTEIZNOSA.Dock = DockStyle.Fill;
            this.userControlDataGridPLVRSTEIZNOSA.FillAtStartup = false;
            this.userControlDataGridPLVRSTEIZNOSA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridPLVRSTEIZNOSA.InitializeRow += new InitializeRowEventHandler(this.PLVRSTEIZNOSAUserDataGrid_InitializeRow);
            this.userControlDataGridPLVRSTEIZNOSA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridPLVRSTEIZNOSA });
            this.Name = "PLVRSTEIZNOSAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.PLVRSTEIZNOSAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridPLVRSTEIZNOSA).EndInit();
            this.ResumeLayout(false);
        }

        private void PLVRSTEIZNOSAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void PLVRSTEIZNOSAUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual PLVRSTEIZNOSADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridPLVRSTEIZNOSA;
            }
            set
            {
                this.userControlDataGridPLVRSTEIZNOSA = value;
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


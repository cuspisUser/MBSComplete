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

    public class VRSTAOBUSTAVEUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Vrste obustava";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Vrste obustava";
        private VRSTAOBUSTAVEDataGrid userControlDataGridVRSTAOBUSTAVE;

        public VRSTAOBUSTAVEUserDataGrid()
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
            this.userControlDataGridVRSTAOBUSTAVE = new VRSTAOBUSTAVEDataGrid();
            ((ISupportInitialize) this.userControlDataGridVRSTAOBUSTAVE).BeginInit();
            UltraGridBand band = new UltraGridBand("VRSTEOBUSTAVA", -1);
            UltraGridColumn column2 = new UltraGridColumn("VRSTAOBUSTAVE");
            UltraGridColumn column = new UltraGridColumn("NAZIVVRSTAOBUSTAVE");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.VRSTAOBUSTAVEVRSTAOBUSTAVEDescription;
            column2.Width = 0x33;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.VRSTAOBUSTAVENAZIVVRSTAOBUSTAVEDescription;
            column.Width = 0x128;
            column.Format = "";
            column.CellAppearance = appearance;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 0;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 1;
            this.userControlDataGridVRSTAOBUSTAVE.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridVRSTAOBUSTAVE.Location = point;
            this.userControlDataGridVRSTAOBUSTAVE.Name = "userControlDataGridVRSTAOBUSTAVE";
            this.userControlDataGridVRSTAOBUSTAVE.Tag = "VRSTEOBUSTAVA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridVRSTAOBUSTAVE.Size = size;
            this.userControlDataGridVRSTAOBUSTAVE.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridVRSTAOBUSTAVE.Dock = DockStyle.Fill;
            this.userControlDataGridVRSTAOBUSTAVE.FillAtStartup = false;
            this.userControlDataGridVRSTAOBUSTAVE.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridVRSTAOBUSTAVE.InitializeRow += new InitializeRowEventHandler(this.VRSTAOBUSTAVEUserDataGrid_InitializeRow);
            this.userControlDataGridVRSTAOBUSTAVE.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridVRSTAOBUSTAVE });
            this.Name = "VRSTAOBUSTAVEUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.VRSTAOBUSTAVEUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridVRSTAOBUSTAVE).EndInit();
            this.ResumeLayout(false);
        }

        private void VRSTAOBUSTAVEUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void VRSTAOBUSTAVEUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual VRSTAOBUSTAVEDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridVRSTAOBUSTAVE;
            }
            set
            {
                this.userControlDataGridVRSTAOBUSTAVE = value;
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


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

    public class VRSTAELEMENTUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Vrste elementa";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Vrste elementa";
        private VRSTAELEMENTDataGrid userControlDataGridVRSTAELEMENT;

        public VRSTAELEMENTUserDataGrid()
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
            this.userControlDataGridVRSTAELEMENT = new VRSTAELEMENTDataGrid();
            ((ISupportInitialize) this.userControlDataGridVRSTAELEMENT).BeginInit();
            UltraGridBand band = new UltraGridBand("VRSTAELEMENT", -1);
            UltraGridColumn column = new UltraGridColumn("IDVRSTAELEMENTA");
            UltraGridColumn column2 = new UltraGridColumn("NAZIVVRSTAELEMENT");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.VRSTAELEMENTIDVRSTAELEMENTADescription;
            column.Width = 0x99;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.VRSTAELEMENTNAZIVVRSTAELEMENTDescription;
            column2.Width = 0xbf;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            this.userControlDataGridVRSTAELEMENT.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridVRSTAELEMENT.Location = point;
            this.userControlDataGridVRSTAELEMENT.Name = "userControlDataGridVRSTAELEMENT";
            this.userControlDataGridVRSTAELEMENT.Tag = "VRSTAELEMENT";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridVRSTAELEMENT.Size = size;
            this.userControlDataGridVRSTAELEMENT.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridVRSTAELEMENT.Dock = DockStyle.Fill;
            this.userControlDataGridVRSTAELEMENT.FillAtStartup = false;
            this.userControlDataGridVRSTAELEMENT.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridVRSTAELEMENT.InitializeRow += new InitializeRowEventHandler(this.VRSTAELEMENTUserDataGrid_InitializeRow);
            this.userControlDataGridVRSTAELEMENT.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridVRSTAELEMENT });
            this.Name = "VRSTAELEMENTUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.VRSTAELEMENTUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridVRSTAELEMENT).EndInit();
            this.ResumeLayout(false);
        }

        private void VRSTAELEMENTUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void VRSTAELEMENTUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual VRSTAELEMENTDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridVRSTAELEMENT;
            }
            set
            {
                this.userControlDataGridVRSTAELEMENT = value;
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

        [TypeConverter(typeof(DeklaritDataGrid.FillMethodsConverter)), DefaultValue("Fill"), Category("Deklarit Work With ")]
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


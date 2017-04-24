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

    public class UGOVORORADUUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Vrste ugovora o radu";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Vrste ugovora o radu";
        private UGOVORORADUDataGrid userControlDataGridUGOVORORADU;

        public UGOVORORADUUserDataGrid()
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
            this.userControlDataGridUGOVORORADU = new UGOVORORADUDataGrid();
            ((ISupportInitialize) this.userControlDataGridUGOVORORADU).BeginInit();
            UltraGridBand band = new UltraGridBand("UGOVORORADU", -1);
            UltraGridColumn column = new UltraGridColumn("IDUGOVORORADU");
            UltraGridColumn column2 = new UltraGridColumn("NAZIVUGOVORORADU");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.UGOVORORADUIDUGOVORORADUDescription;
            column.Width = 0x33;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.UGOVORORADUNAZIVUGOVORORADUDescription;
            column2.Width = 0x9c;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            this.userControlDataGridUGOVORORADU.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridUGOVORORADU.Location = point;
            this.userControlDataGridUGOVORORADU.Name = "userControlDataGridUGOVORORADU";
            this.userControlDataGridUGOVORORADU.Tag = "UGOVORORADU";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridUGOVORORADU.Size = size;
            this.userControlDataGridUGOVORORADU.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridUGOVORORADU.Dock = DockStyle.Fill;
            this.userControlDataGridUGOVORORADU.FillAtStartup = false;
            this.userControlDataGridUGOVORORADU.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridUGOVORORADU.InitializeRow += new InitializeRowEventHandler(this.UGOVORORADUUserDataGrid_InitializeRow);
            this.userControlDataGridUGOVORORADU.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridUGOVORORADU });
            this.Name = "UGOVORORADUUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.UGOVORORADUUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridUGOVORORADU).EndInit();
            this.ResumeLayout(false);
        }

        private void UGOVORORADUUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void UGOVORORADUUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual UGOVORORADUDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridUGOVORORADU;
            }
            set
            {
                this.userControlDataGridUGOVORORADU = value;
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


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

    public class DDIZDATAKUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Izdaci";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Izdaci";
        private DDIZDATAKDataGrid userControlDataGridDDIZDATAK;

        public DDIZDATAKUserDataGrid()
        {
            this.InitializeComponent();
        }

        private void DDIZDATAKUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void DDIZDATAKUserDataGrid_Load(object sender, EventArgs e)
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
            this.userControlDataGridDDIZDATAK = new DDIZDATAKDataGrid();
            ((ISupportInitialize) this.userControlDataGridDDIZDATAK).BeginInit();
            UltraGridBand band = new UltraGridBand("DDIZDATAK", -1);
            UltraGridColumn column = new UltraGridColumn("DDIDIZDATAK");
            UltraGridColumn column2 = new UltraGridColumn("DDNAZIVIZDATKA");
            UltraGridColumn column3 = new UltraGridColumn("DDPOSTOTAKIZDATKA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.DDIZDATAKDDIDIZDATAKDescription;
            column.Width = 0x69;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.DDIZDATAKDDNAZIVIZDATKADescription;
            column2.Width = 0x128;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.DDIZDATAKDDPOSTOTAKIZDATKADescription;
            column3.Width = 0x81;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnn.nn";
            column3.PromptChar = ' ';
            column3.Format = "F2";
            column3.CellAppearance = appearance3;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 2;
            this.userControlDataGridDDIZDATAK.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridDDIZDATAK.Location = point;
            this.userControlDataGridDDIZDATAK.Name = "userControlDataGridDDIZDATAK";
            this.userControlDataGridDDIZDATAK.Tag = "DDIZDATAK";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridDDIZDATAK.Size = size;
            this.userControlDataGridDDIZDATAK.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridDDIZDATAK.Dock = DockStyle.Fill;
            this.userControlDataGridDDIZDATAK.FillAtStartup = false;
            this.userControlDataGridDDIZDATAK.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridDDIZDATAK.InitializeRow += new InitializeRowEventHandler(this.DDIZDATAKUserDataGrid_InitializeRow);
            this.userControlDataGridDDIZDATAK.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridDDIZDATAK });
            this.Name = "DDIZDATAKUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.DDIZDATAKUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridDDIZDATAK).EndInit();
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
        public virtual DDIZDATAKDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridDDIZDATAK;
            }
            set
            {
                this.userControlDataGridDDIZDATAK = value;
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

        [Category("Deklarit Work With "), TypeConverter(typeof(DeklaritDataGrid.FillMethodsConverter)), DefaultValue("Fill")]
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


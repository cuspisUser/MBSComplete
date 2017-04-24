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

    public class OSOBNIODBITAKUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Faktori osobnog odbitka";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Faktori osobnog odbitka";
        private OSOBNIODBITAKDataGrid userControlDataGridOSOBNIODBITAK;

        public OSOBNIODBITAKUserDataGrid()
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
            this.userControlDataGridOSOBNIODBITAK = new OSOBNIODBITAKDataGrid();
            ((ISupportInitialize) this.userControlDataGridOSOBNIODBITAK).BeginInit();
            UltraGridBand band = new UltraGridBand("OSOBNIODBITAK", -1);
            UltraGridColumn column2 = new UltraGridColumn("IDOSOBNIODBITAK");
            UltraGridColumn column3 = new UltraGridColumn("NAZIVOSOBNIODBITAK");
            UltraGridColumn column = new UltraGridColumn("FAKTOROSOBNOGODBITKA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.OSOBNIODBITAKIDOSOBNIODBITAKDescription;
            column2.Width = 0x9f;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.OSOBNIODBITAKNAZIVOSOBNIODBITAKDescription;
            column3.Width = 0x128;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.OSOBNIODBITAKFAKTOROSOBNOGODBITKADescription;
            column.Width = 170;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnn.nn";
            column.PromptChar = ' ';
            column.Format = "F2";
            column.CellAppearance = appearance;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 0;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 1;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 2;
            this.userControlDataGridOSOBNIODBITAK.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridOSOBNIODBITAK.Location = point;
            this.userControlDataGridOSOBNIODBITAK.Name = "userControlDataGridOSOBNIODBITAK";
            this.userControlDataGridOSOBNIODBITAK.Tag = "OSOBNIODBITAK";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridOSOBNIODBITAK.Size = size;
            this.userControlDataGridOSOBNIODBITAK.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridOSOBNIODBITAK.Dock = DockStyle.Fill;
            this.userControlDataGridOSOBNIODBITAK.FillAtStartup = false;
            this.userControlDataGridOSOBNIODBITAK.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridOSOBNIODBITAK.InitializeRow += new InitializeRowEventHandler(this.OSOBNIODBITAKUserDataGrid_InitializeRow);
            this.userControlDataGridOSOBNIODBITAK.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridOSOBNIODBITAK });
            this.Name = "OSOBNIODBITAKUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.OSOBNIODBITAKUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridOSOBNIODBITAK).EndInit();
            this.ResumeLayout(false);
        }

        private void OSOBNIODBITAKUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void OSOBNIODBITAKUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual OSOBNIODBITAKDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridOSOBNIODBITAK;
            }
            set
            {
                this.userControlDataGridOSOBNIODBITAK = value;
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


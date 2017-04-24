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

    public class AKTIVNOSTUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Aktivnosti konta";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Aktivnosti konta";
        private AKTIVNOSTDataGrid userControlDataGridAKTIVNOST;

        public AKTIVNOSTUserDataGrid()
        {
            this.InitializeComponent();
        }

        private void AKTIVNOSTUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void AKTIVNOSTUserDataGrid_Load(object sender, EventArgs e)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AKTIVNOSTUserDataGrid));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("AKTIVNOST", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAKTIVNOST");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVAKTIVNOST");
            this.userControlDataGridAKTIVNOST = new NetAdvantage.Controls.AKTIVNOSTDataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.userControlDataGridAKTIVNOST)).BeginInit();
            this.SuspendLayout();
            // 
            // userControlDataGridAKTIVNOST
            // 
            appearance1.TextHAlignAsString = "Left";
            this.userControlDataGridAKTIVNOST.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance4.TextHAlignAsString = "Right";
            ultraGridColumn1.CellAppearance = appearance4;
            ultraGridColumn1.Format = "";
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.MaskInput = "{LOC}-nnnnnn";
            ultraGridColumn1.PromptChar = ' ';
            ultraGridColumn1.Width = 126;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Format = "";
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 296;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2});
            this.userControlDataGridAKTIVNOST.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.userControlDataGridAKTIVNOST.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.userControlDataGridAKTIVNOST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlDataGridAKTIVNOST.FillAtStartup = false;
            this.userControlDataGridAKTIVNOST.FillByPage = false;
            this.userControlDataGridAKTIVNOST.Location = new System.Drawing.Point(0, 0);
            this.userControlDataGridAKTIVNOST.Name = "userControlDataGridAKTIVNOST";
            this.userControlDataGridAKTIVNOST.Size = new System.Drawing.Size(512, 324);
            this.userControlDataGridAKTIVNOST.TabIndex = 0;
            this.userControlDataGridAKTIVNOST.Tag = "AKTIVNOST";
            this.userControlDataGridAKTIVNOST.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.AKTIVNOSTUserDataGrid_InitializeRow);
            // 
            // AKTIVNOSTUserDataGrid
            // 
            this.Controls.Add(this.userControlDataGridAKTIVNOST);
            this.Name = "AKTIVNOSTUserDataGrid";
            this.Size = new System.Drawing.Size(512, 324);
            this.Load += new System.EventHandler(this.AKTIVNOSTUserDataGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userControlDataGridAKTIVNOST)).EndInit();
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
        public virtual AKTIVNOSTDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridAKTIVNOST;
            }
            set
            {
                this.userControlDataGridAKTIVNOST = value;
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

        [DefaultValue(true), Category("Deklarit Work With "), Description("True= Fill at Startup. False= Not Fill")]
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


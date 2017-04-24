namespace NetAdvantage.SmartParts
{
    using Infragistics.Win;
    using Infragistics.Win.UltraWinGrid;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using NetAdvantage.Controls;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class S_FIN_PARTNERI_SA_OTVORENIMAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with S_FIN_PARTNERI_SA_OTVORENIMA";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with S_FIN_PARTNERI_SA_OTVORENIMA";
        private S_FIN_PARTNERI_SA_OTVORENIMADataGrid userControlDataGridS_FIN_PARTNERI_SA_OTVORENIMA;

        public S_FIN_PARTNERI_SA_OTVORENIMAUserDataGrid()
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
            this.userControlDataGridS_FIN_PARTNERI_SA_OTVORENIMA = new S_FIN_PARTNERI_SA_OTVORENIMADataGrid();
            ((ISupportInitialize) this.userControlDataGridS_FIN_PARTNERI_SA_OTVORENIMA).BeginInit();
            UltraGridBand band = new UltraGridBand("S_FIN_PARTNERI_SA_OTVORENIMA", -1);
            UltraGridColumn column = new UltraGridColumn("IDPARTNER");
            UltraGridColumn column2 = new UltraGridColumn("NAZIVPARTNER");
            UltraGridColumn column3 = new UltraGridColumn("PARTNERMJESTO");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.S_FIN_PARTNERI_SA_OTVORENIMAIDPARTNERDescription;
            column.Width = 0x70;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.S_FIN_PARTNERI_SA_OTVORENIMANAZIVPARTNERDescription;
            column2.Width = 0x128;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.S_FIN_PARTNERI_SA_OTVORENIMAPARTNERMJESTODescription;
            column3.Width = 0x128;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 2;
            this.userControlDataGridS_FIN_PARTNERI_SA_OTVORENIMA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_FIN_PARTNERI_SA_OTVORENIMA.Location = point;
            this.userControlDataGridS_FIN_PARTNERI_SA_OTVORENIMA.Name = "userControlDataGridS_FIN_PARTNERI_SA_OTVORENIMA";
            this.userControlDataGridS_FIN_PARTNERI_SA_OTVORENIMA.Tag = "S_FIN_PARTNERI_SA_OTVORENIMA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridS_FIN_PARTNERI_SA_OTVORENIMA.Size = size;
            this.userControlDataGridS_FIN_PARTNERI_SA_OTVORENIMA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridS_FIN_PARTNERI_SA_OTVORENIMA.Dock = DockStyle.Fill;
            this.userControlDataGridS_FIN_PARTNERI_SA_OTVORENIMA.FillAtStartup = false;
            this.userControlDataGridS_FIN_PARTNERI_SA_OTVORENIMA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridS_FIN_PARTNERI_SA_OTVORENIMA.InitializeRow += new InitializeRowEventHandler(this.S_FIN_PARTNERI_SA_OTVORENIMAUserDataGrid_InitializeRow);
            this.userControlDataGridS_FIN_PARTNERI_SA_OTVORENIMA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridS_FIN_PARTNERI_SA_OTVORENIMA });
            this.Name = "S_FIN_PARTNERI_SA_OTVORENIMAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.S_FIN_PARTNERI_SA_OTVORENIMAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridS_FIN_PARTNERI_SA_OTVORENIMA).EndInit();
            this.ResumeLayout(false);
        }

        private void S_FIN_PARTNERI_SA_OTVORENIMAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void S_FIN_PARTNERI_SA_OTVORENIMAUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual S_FIN_PARTNERI_SA_OTVORENIMADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridS_FIN_PARTNERI_SA_OTVORENIMA;
            }
            set
            {
                this.userControlDataGridS_FIN_PARTNERI_SA_OTVORENIMA = value;
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

        [Category("DeKlarit Data Provider Parameters")]
        public virtual int Parametergodina
        {
            get
            {
                return this.DataGrid.Parametergodina;
            }
            set
            {
                this.DataGrid.Parametergodina = value;
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


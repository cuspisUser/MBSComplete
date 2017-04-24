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

    public class S_OD_KONACNI_POREZ_PO_OPCINAMAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with S_OD_KONACNI_POREZ_PO_OPCINAMA";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with S_OD_KONACNI_POREZ_PO_OPCINAMA";
        private S_OD_KONACNI_POREZ_PO_OPCINAMADataGrid userControlDataGridS_OD_KONACNI_POREZ_PO_OPCINAMA;

        public S_OD_KONACNI_POREZ_PO_OPCINAMAUserDataGrid()
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
            this.userControlDataGridS_OD_KONACNI_POREZ_PO_OPCINAMA = new S_OD_KONACNI_POREZ_PO_OPCINAMADataGrid();
            ((ISupportInitialize) this.userControlDataGridS_OD_KONACNI_POREZ_PO_OPCINAMA).BeginInit();
            UltraGridBand band = new UltraGridBand("S_OD_KONACNI_POREZ_PO_OPCINAMA", -1);
            UltraGridColumn column4 = new UltraGridColumn("SIFRAOPCINESTANOVANJA");
            UltraGridColumn column = new UltraGridColumn("NAZIVOPCINE");
            UltraGridColumn column2 = new UltraGridColumn("OBRACUNATOPOREZ");
            UltraGridColumn column3 = new UltraGridColumn("OBRACUNATOPRIREZ");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.S_OD_KONACNI_POREZ_PO_OPCINAMASIFRAOPCINESTANOVANJADescription;
            column4.Width = 100;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.S_OD_KONACNI_POREZ_PO_OPCINAMANAZIVOPCINEDescription;
            column.Width = 0x128;
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.S_OD_KONACNI_POREZ_PO_OPCINAMAOBRACUNATOPOREZDescription;
            column2.Width = 0x7b;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column2.PromptChar = ' ';
            column2.Format = "F2";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.S_OD_KONACNI_POREZ_PO_OPCINAMAOBRACUNATOPRIREZDescription;
            column3.Width = 0x81;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column3.PromptChar = ' ';
            column3.Format = "F2";
            column3.CellAppearance = appearance3;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 0;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 1;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 2;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 3;
            this.userControlDataGridS_OD_KONACNI_POREZ_PO_OPCINAMA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_OD_KONACNI_POREZ_PO_OPCINAMA.Location = point;
            this.userControlDataGridS_OD_KONACNI_POREZ_PO_OPCINAMA.Name = "userControlDataGridS_OD_KONACNI_POREZ_PO_OPCINAMA";
            this.userControlDataGridS_OD_KONACNI_POREZ_PO_OPCINAMA.Tag = "S_OD_KONACNI_POREZ_PO_OPCINAMA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridS_OD_KONACNI_POREZ_PO_OPCINAMA.Size = size;
            this.userControlDataGridS_OD_KONACNI_POREZ_PO_OPCINAMA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridS_OD_KONACNI_POREZ_PO_OPCINAMA.Dock = DockStyle.Fill;
            this.userControlDataGridS_OD_KONACNI_POREZ_PO_OPCINAMA.FillAtStartup = false;
            this.userControlDataGridS_OD_KONACNI_POREZ_PO_OPCINAMA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridS_OD_KONACNI_POREZ_PO_OPCINAMA.InitializeRow += new InitializeRowEventHandler(this.S_OD_KONACNI_POREZ_PO_OPCINAMAUserDataGrid_InitializeRow);
            this.userControlDataGridS_OD_KONACNI_POREZ_PO_OPCINAMA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridS_OD_KONACNI_POREZ_PO_OPCINAMA });
            this.Name = "S_OD_KONACNI_POREZ_PO_OPCINAMAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.S_OD_KONACNI_POREZ_PO_OPCINAMAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridS_OD_KONACNI_POREZ_PO_OPCINAMA).EndInit();
            this.ResumeLayout(false);
        }

        private void S_OD_KONACNI_POREZ_PO_OPCINAMAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void S_OD_KONACNI_POREZ_PO_OPCINAMAUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual S_OD_KONACNI_POREZ_PO_OPCINAMADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridS_OD_KONACNI_POREZ_PO_OPCINAMA;
            }
            set
            {
                this.userControlDataGridS_OD_KONACNI_POREZ_PO_OPCINAMA = value;
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

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string Parameteridobracun
        {
            get
            {
                return this.DataGrid.Parameteridobracun;
            }
            set
            {
                this.DataGrid.Parameteridobracun = value;
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


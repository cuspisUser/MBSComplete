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

    public class trazi_partneraUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with trazi_partnera";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with trazi_partnera";
        private trazi_partneraDataGrid userControlDataGridtrazi_partnera;

        public trazi_partneraUserDataGrid()
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
            this.userControlDataGridtrazi_partnera = new trazi_partneraDataGrid();
            ((ISupportInitialize) this.userControlDataGridtrazi_partnera).BeginInit();
            UltraGridBand band = new UltraGridBand("PARTNER", -1);
            UltraGridColumn column = new UltraGridColumn("IDPARTNER");
            UltraGridColumn column3 = new UltraGridColumn("NAZIVPARTNER");
            UltraGridColumn column5 = new UltraGridColumn("PARTNERMJESTO");
            UltraGridColumn column4 = new UltraGridColumn("PARTNEREMAIL");
            UltraGridColumn column7 = new UltraGridColumn("PARTNERULICA");
            UltraGridColumn column2 = new UltraGridColumn("MB");
            UltraGridColumn column6 = new UltraGridColumn("PARTNEROIB");
            UltraGridColumn column8 = new UltraGridColumn("PT");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.trazi_partneraIDPARTNERDescription;
            column.Width = 0x70;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.trazi_partneraNAZIVPARTNERDescription;
            column3.Width = 0x128;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.trazi_partneraPARTNERMJESTODescription;
            column5.Width = 0x128;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            column5.Hidden = true;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.trazi_partneraPARTNEREMAILDescription;
            column4.Width = 0x128;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            column4.Hidden = true;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.trazi_partneraPARTNERULICADescription;
            column7.Width = 0x128;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            column7.Hidden = true;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.trazi_partneraMBDescription;
            column2.Width = 0x6b;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            column2.Hidden = true;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.trazi_partneraPARTNEROIBDescription;
            column6.Width = 0x5d;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            column6.Hidden = true;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.trazi_partneraPTDescription;
            column8.Width = 0x128;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            column8.Hidden = true;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 1;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 2;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 3;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 4;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 5;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 6;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 7;
            this.userControlDataGridtrazi_partnera.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridtrazi_partnera.Location = point;
            this.userControlDataGridtrazi_partnera.Name = "userControlDataGridtrazi_partnera";
            this.userControlDataGridtrazi_partnera.Tag = "PARTNER";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridtrazi_partnera.Size = size;
            this.userControlDataGridtrazi_partnera.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridtrazi_partnera.Dock = DockStyle.Fill;
            this.userControlDataGridtrazi_partnera.FillAtStartup = false;
            this.userControlDataGridtrazi_partnera.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridtrazi_partnera.InitializeRow += new InitializeRowEventHandler(this.trazi_partneraUserDataGrid_InitializeRow);
            this.userControlDataGridtrazi_partnera.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridtrazi_partnera });
            this.Name = "trazi_partneraUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.trazi_partneraUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridtrazi_partnera).EndInit();
            this.ResumeLayout(false);
        }

        private void trazi_partneraUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void trazi_partneraUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual trazi_partneraDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridtrazi_partnera;
            }
            set
            {
                this.userControlDataGridtrazi_partnera = value;
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
        public virtual string ParameterNAZIVPARTNER
        {
            get
            {
                return this.DataGrid.ParameterNAZIVPARTNER;
            }
            set
            {
                this.DataGrid.ParameterNAZIVPARTNER = value;
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


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

    public class BANKEUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Banke";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Banke";
        private BANKEDataGrid userControlDataGridBANKE;

        public BANKEUserDataGrid()
        {
            this.InitializeComponent();
        }

        private void BANKEUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void BANKEUserDataGrid_Load(object sender, EventArgs e)
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
            this.userControlDataGridBANKE = new BANKEDataGrid();
            ((ISupportInitialize) this.userControlDataGridBANKE).BeginInit();
            UltraGridBand band = new UltraGridBand("BANKE", -1);
            UltraGridColumn column = new UltraGridColumn("IDBANKE");
            UltraGridColumn column4 = new UltraGridColumn("NAZIVBANKE1");
            UltraGridColumn column5 = new UltraGridColumn("NAZIVBANKE2");
            UltraGridColumn column6 = new UltraGridColumn("NAZIVBANKE3");
            UltraGridColumn column2 = new UltraGridColumn("MOBANKA");
            UltraGridColumn column8 = new UltraGridColumn("POBANKA");
            UltraGridColumn column3 = new UltraGridColumn("MZBANKA");
            UltraGridColumn column9 = new UltraGridColumn("PZBANKA");
            UltraGridColumn column10 = new UltraGridColumn("SIFRAOPISPLACANJABANKE");
            UltraGridColumn column7 = new UltraGridColumn("OPISPLACANJABANKE");
            UltraGridColumn column11 = new UltraGridColumn("VBDIBANKE");
            UltraGridColumn column12 = new UltraGridColumn("ZRNBANKE");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.BANKEIDBANKEDescription;
            column.Width = 0x5c;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.BANKENAZIVBANKE1Description;
            column4.Width = 0x9c;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.BANKENAZIVBANKE2Description;
            column5.Width = 0x9c;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.BANKENAZIVBANKE3Description;
            column6.Width = 0x9c;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.BANKEMOBANKADescription;
            column2.Width = 0x79;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.BANKEPOBANKADescription;
            column8.Width = 0xb1;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.BANKEMZBANKADescription;
            column3.Width = 0x79;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.BANKEPZBANKADescription;
            column9.Width = 0xb1;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.BANKESIFRAOPISPLACANJABANKEDescription;
            column10.Width = 0x9c;
            column10.Format = "";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.BANKEOPISPLACANJABANKEDescription;
            column7.Width = 0x10c;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.BANKEVBDIBANKEDescription;
            column11.Width = 0x41;
            column11.Format = "";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.BANKEZRNBANKEDescription;
            column12.Width = 0x56;
            column12.Format = "";
            column12.CellAppearance = appearance12;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 1;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 2;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 3;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 4;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 5;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 6;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 7;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 8;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 9;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 10;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 11;
            this.userControlDataGridBANKE.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridBANKE.Location = point;
            this.userControlDataGridBANKE.Name = "userControlDataGridBANKE";
            this.userControlDataGridBANKE.Tag = "BANKE";
            this.userControlDataGridBANKE.Size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridBANKE.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridBANKE.Dock = DockStyle.Fill;
            this.userControlDataGridBANKE.FillAtStartup = false;
            this.userControlDataGridBANKE.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridBANKE.InitializeRow += new InitializeRowEventHandler(this.BANKEUserDataGrid_InitializeRow);
            this.userControlDataGridBANKE.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridBANKE });
            this.Name = "BANKEUserDataGrid";
            this.Size = new System.Drawing.Size(0x200, 0x144);
            this.Load += new EventHandler(this.BANKEUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridBANKE).EndInit();
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
        public virtual BANKEDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridBANKE;
            }
            set
            {
                this.userControlDataGridBANKE = value;
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


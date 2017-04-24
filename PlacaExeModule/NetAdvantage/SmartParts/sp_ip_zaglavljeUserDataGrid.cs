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

    public class sp_ip_zaglavljeUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with sp_ip_zaglavlje";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with sp_ip_zaglavlje";
        private sp_ip_zaglavljeDataGrid userControlDataGridsp_ip_zaglavlje;

        public sp_ip_zaglavljeUserDataGrid()
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
            this.userControlDataGridsp_ip_zaglavlje = new sp_ip_zaglavljeDataGrid();
            ((ISupportInitialize) this.userControlDataGridsp_ip_zaglavlje).BeginInit();
            UltraGridBand band = new UltraGridBand("sp_ip_zaglavlje", -1);
            UltraGridColumn column8 = new UltraGridColumn("OZNACEN");
            UltraGridColumn column2 = new UltraGridColumn("IDIPIDENT");
            UltraGridColumn column6 = new UltraGridColumn("JMBG");
            UltraGridColumn column9 = new UltraGridColumn("PREZIME");
            UltraGridColumn column3 = new UltraGridColumn("IME");
            UltraGridColumn column = new UltraGridColumn("ADRESA");
            UltraGridColumn column4 = new UltraGridColumn("isplataugodini");
            UltraGridColumn column5 = new UltraGridColumn("isplatazagodinu");
            UltraGridColumn column7 = new UltraGridColumn("OIB");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.sp_ip_zaglavljeOZNACENDescription;
            column8.Width = 0x41;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.sp_ip_zaglavljeIDIPIDENTDescription;
            column2.Width = 0x4e;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.sp_ip_zaglavljeJMBGDescription;
            column6.Width = 0x6b;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.sp_ip_zaglavljePREZIMEDescription;
            column9.Width = 0x128;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.sp_ip_zaglavljeIMEDescription;
            column3.Width = 0x128;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.sp_ip_zaglavljeADRESADescription;
            column.Width = 0x128;
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.sp_ip_zaglavljeisplataugodiniDescription;
            column4.Width = 0x72;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.sp_ip_zaglavljeisplatazagodinuDescription;
            column5.Width = 0x79;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.sp_ip_zaglavljeOIBDescription;
            column7.Width = 0x5d;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 2;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 3;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 4;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 5;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 6;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 7;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 8;
            this.userControlDataGridsp_ip_zaglavlje.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridsp_ip_zaglavlje.Location = point;
            this.userControlDataGridsp_ip_zaglavlje.Name = "userControlDataGridsp_ip_zaglavlje";
            this.userControlDataGridsp_ip_zaglavlje.Tag = "sp_ip_zaglavlje";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridsp_ip_zaglavlje.Size = size;
            this.userControlDataGridsp_ip_zaglavlje.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridsp_ip_zaglavlje.Dock = DockStyle.Fill;
            this.userControlDataGridsp_ip_zaglavlje.FillAtStartup = false;
            this.userControlDataGridsp_ip_zaglavlje.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridsp_ip_zaglavlje.InitializeRow += new InitializeRowEventHandler(this.sp_ip_zaglavljeUserDataGrid_InitializeRow);
            this.userControlDataGridsp_ip_zaglavlje.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridsp_ip_zaglavlje });
            this.Name = "sp_ip_zaglavljeUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.sp_ip_zaglavljeUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridsp_ip_zaglavlje).EndInit();
            this.ResumeLayout(false);
        }

        private void sp_ip_zaglavljeUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void sp_ip_zaglavljeUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual sp_ip_zaglavljeDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridsp_ip_zaglavlje;
            }
            set
            {
                this.userControlDataGridsp_ip_zaglavlje = value;
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
        public virtual string Parametergodina
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


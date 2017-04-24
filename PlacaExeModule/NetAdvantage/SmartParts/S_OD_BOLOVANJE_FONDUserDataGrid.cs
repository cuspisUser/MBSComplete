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

    public class S_OD_BOLOVANJE_FONDUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with S_OD_BOLOVANJE_FOND";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with S_OD_BOLOVANJE_FOND";
        private S_OD_BOLOVANJE_FONDDataGrid userControlDataGridS_OD_BOLOVANJE_FOND;

        public S_OD_BOLOVANJE_FONDUserDataGrid()
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
            this.userControlDataGridS_OD_BOLOVANJE_FOND = new S_OD_BOLOVANJE_FONDDataGrid();
            ((ISupportInitialize) this.userControlDataGridS_OD_BOLOVANJE_FOND).BeginInit();
            UltraGridBand band = new UltraGridBand("S_OD_BOLOVANJE_FOND", -1);
            UltraGridColumn column4 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column14 = new UltraGridColumn("PREZIME");
            UltraGridColumn column5 = new UltraGridColumn("IME");
            UltraGridColumn column6 = new UltraGridColumn("JMBG");
            UltraGridColumn column11 = new UltraGridColumn("MJESECOBRACUNA");
            UltraGridColumn column3 = new UltraGridColumn("GODINAOBRACUNA");
            UltraGridColumn column7 = new UltraGridColumn("KOLONA4");
            UltraGridColumn column8 = new UltraGridColumn("KOLONA5");
            UltraGridColumn column9 = new UltraGridColumn("KOLONA6");
            UltraGridColumn column10 = new UltraGridColumn("KOLONA8");
            UltraGridColumn column15 = new UltraGridColumn("SATIUKUPNO");
            UltraGridColumn column16 = new UltraGridColumn("ukupnobruto");
            UltraGridColumn column12 = new UltraGridColumn("netoplaca");
            UltraGridColumn column2 = new UltraGridColumn("FONDMJESECA");
            UltraGridColumn column13 = new UltraGridColumn("OIB");
            UltraGridColumn column = new UltraGridColumn("BROJZDRAVSTVENOG");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.S_OD_BOLOVANJE_FONDIDRADNIKDescription;
            column4.Width = 0x69;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnnnnn";
            column4.PromptChar = ' ';
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.S_OD_BOLOVANJE_FONDPREZIMEDescription;
            column14.Width = 0x128;
            column14.Format = "";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.S_OD_BOLOVANJE_FONDIMEDescription;
            column5.Width = 0x128;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.S_OD_BOLOVANJE_FONDJMBGDescription;
            column6.Width = 0x6b;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.S_OD_BOLOVANJE_FONDMJESECOBRACUNADescription;
            column11.Width = 0x79;
            column11.Format = "";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.S_OD_BOLOVANJE_FONDGODINAOBRACUNADescription;
            column3.Width = 0x79;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.S_OD_BOLOVANJE_FONDKOLONA4Description;
            column7.Width = 0x66;
            appearance7.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column7.PromptChar = ' ';
            column7.Format = "F2";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.S_OD_BOLOVANJE_FONDKOLONA5Description;
            column8.Width = 0x66;
            appearance8.TextHAlign = HAlign.Right;
            column8.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column8.PromptChar = ' ';
            column8.Format = "F2";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.S_OD_BOLOVANJE_FONDKOLONA6Description;
            column9.Width = 0x66;
            appearance9.TextHAlign = HAlign.Right;
            column9.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column9.PromptChar = ' ';
            column9.Format = "F2";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.S_OD_BOLOVANJE_FONDKOLONA8Description;
            column10.Width = 0x66;
            appearance10.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column10.PromptChar = ' ';
            column10.Format = "F2";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.S_OD_BOLOVANJE_FONDSATIUKUPNODescription;
            column15.Width = 0x66;
            appearance15.TextHAlign = HAlign.Right;
            column15.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column15.PromptChar = ' ';
            column15.Format = "F2";
            column15.CellAppearance = appearance15;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.S_OD_BOLOVANJE_FONDukupnobrutoDescription;
            column16.Width = 0x66;
            appearance16.TextHAlign = HAlign.Right;
            column16.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column16.PromptChar = ' ';
            column16.Format = "F2";
            column16.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.S_OD_BOLOVANJE_FONDnetoplacaDescription;
            column12.Width = 0x66;
            appearance12.TextHAlign = HAlign.Right;
            column12.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column12.PromptChar = ' ';
            column12.Format = "F2";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.S_OD_BOLOVANJE_FONDFONDMJESECADescription;
            column2.Width = 0x84;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.S_OD_BOLOVANJE_FONDOIBDescription;
            column13.Width = 0x5d;
            column13.Format = "";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.S_OD_BOLOVANJE_FONDBROJZDRAVSTVENOGDescription;
            column.Width = 0x128;
            column.Format = "";
            column.CellAppearance = appearance;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 0;
            band.Columns.Add(column14);
            column14.Header.VisiblePosition = 1;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 2;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 3;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 4;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 5;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 6;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 7;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 8;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 9;
            band.Columns.Add(column15);
            column15.Header.VisiblePosition = 10;
            band.Columns.Add(column16);
            column16.Header.VisiblePosition = 11;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 12;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 13;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 14;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 15;
            this.userControlDataGridS_OD_BOLOVANJE_FOND.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_OD_BOLOVANJE_FOND.Location = point;
            this.userControlDataGridS_OD_BOLOVANJE_FOND.Name = "userControlDataGridS_OD_BOLOVANJE_FOND";
            this.userControlDataGridS_OD_BOLOVANJE_FOND.Tag = "S_OD_BOLOVANJE_FOND";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridS_OD_BOLOVANJE_FOND.Size = size;
            this.userControlDataGridS_OD_BOLOVANJE_FOND.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridS_OD_BOLOVANJE_FOND.Dock = DockStyle.Fill;
            this.userControlDataGridS_OD_BOLOVANJE_FOND.FillAtStartup = false;
            this.userControlDataGridS_OD_BOLOVANJE_FOND.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridS_OD_BOLOVANJE_FOND.InitializeRow += new InitializeRowEventHandler(this.S_OD_BOLOVANJE_FONDUserDataGrid_InitializeRow);
            this.userControlDataGridS_OD_BOLOVANJE_FOND.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridS_OD_BOLOVANJE_FOND });
            this.Name = "S_OD_BOLOVANJE_FONDUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.S_OD_BOLOVANJE_FONDUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridS_OD_BOLOVANJE_FOND).EndInit();
            this.ResumeLayout(false);
        }

        private void S_OD_BOLOVANJE_FONDUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void S_OD_BOLOVANJE_FONDUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual S_OD_BOLOVANJE_FONDDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridS_OD_BOLOVANJE_FOND;
            }
            set
            {
                this.userControlDataGridS_OD_BOLOVANJE_FOND = value;
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
        public virtual string ParameterDOOO
        {
            get
            {
                return this.DataGrid.ParameterDOOO;
            }
            set
            {
                this.DataGrid.ParameterDOOO = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual int Parameteridradnik
        {
            get
            {
                return this.DataGrid.Parameteridradnik;
            }
            set
            {
                this.DataGrid.Parameteridradnik = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string ParameterODD
        {
            get
            {
                return this.DataGrid.ParameterODD;
            }
            set
            {
                this.DataGrid.ParameterODD = value;
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


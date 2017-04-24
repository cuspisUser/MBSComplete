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

    public class PRPLACEUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Priprema plaae";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Priprema plaae";
        private PRPLACEDataGrid userControlDataGridPRPLACE;

        public PRPLACEUserDataGrid()
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
            this.userControlDataGridPRPLACE = new PRPLACEDataGrid();
            ((ISupportInitialize) this.userControlDataGridPRPLACE).BeginInit();
            UltraGridBand band = new UltraGridBand("PRPLACE", -1);
            UltraGridColumn column24 = new UltraGridColumn("PRPLACEZAMJESEC");
            UltraGridColumn column19 = new UltraGridColumn("PRPLACEID");
            UltraGridColumn column23 = new UltraGridColumn("PRPLACEZAGODINU");
            UltraGridColumn column20 = new UltraGridColumn("PRPLACEOPIS");
            UltraGridColumn column21 = new UltraGridColumn("PRPLACEOSNOVICA");
            UltraGridColumn column22 = new UltraGridColumn("PRPLACEPROSJECNISATI");
            UltraGridBand band2 = new UltraGridBand("PRPLACE_PRPLACEPRPLACEELEMENTI", 0);
            UltraGridColumn column6 = new UltraGridColumn("PRPLACEZAMJESEC");
            UltraGridColumn column4 = new UltraGridColumn("PRPLACEID");
            UltraGridColumn column5 = new UltraGridColumn("PRPLACEZAGODINU");
            UltraGridColumn column = new UltraGridColumn("IDELEMENT");
            UltraGridColumn column2 = new UltraGridColumn("NAZIVELEMENT");
            UltraGridColumn column3 = new UltraGridColumn("POSTOTAK");
            UltraGridBand band3 = new UltraGridBand("PRPLACEPRPLACEELEMENTI_PRPLACEPRPLACEELEMENTIRADNIK", 1);
            UltraGridColumn column17 = new UltraGridColumn("PRPLACEZAMJESEC");
            UltraGridColumn column11 = new UltraGridColumn("PRPLACEID");
            UltraGridColumn column16 = new UltraGridColumn("PRPLACEZAGODINU");
            UltraGridColumn column7 = new UltraGridColumn("IDELEMENT");
            UltraGridColumn column8 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column10 = new UltraGridColumn("PREZIME");
            UltraGridColumn column9 = new UltraGridColumn("IME");
            UltraGridColumn column14 = new UltraGridColumn("PRPLACESATI");
            UltraGridColumn column15 = new UltraGridColumn("PRPLACESATNICA");
            UltraGridColumn column13 = new UltraGridColumn("PRPLACEPOSTOTAK");
            UltraGridColumn column12 = new UltraGridColumn("PRPLACEIZNOS");
            UltraGridColumn column18 = new UltraGridColumn("SPOJENOPREZIME");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            column24.CellActivation = Activation.NoEdit;
            column24.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column24.Header.Caption = StringResources.PRPLACEPRPLACEZAMJESECDescription;
            column24.Width = 0x4e;
            appearance24.TextHAlign = HAlign.Right;
            column24.MaskInput = "{LOC}-nn";
            column24.PromptChar = ' ';
            column24.Format = "";
            column24.CellAppearance = appearance24;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column19.CellActivation = Activation.NoEdit;
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.PRPLACEPRPLACEIDDescription;
            column19.Width = 0xcf;
            appearance19.TextHAlign = HAlign.Right;
            column19.MaskInput = "{LOC}-nnnnn";
            column19.PromptChar = ' ';
            column19.Format = "";
            column19.CellAppearance = appearance19;
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            column23.CellActivation = Activation.NoEdit;
            column23.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column23.Header.Caption = StringResources.PRPLACEPRPLACEZAGODINUDescription;
            column23.Width = 0x4e;
            appearance23.TextHAlign = HAlign.Right;
            column23.MaskInput = "{LOC}-nnnn";
            column23.PromptChar = ' ';
            column23.Format = "";
            column23.CellAppearance = appearance23;
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            column20.CellActivation = Activation.NoEdit;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.PRPLACEPRPLACEOPISDescription;
            column20.Width = 0x128;
            column20.Format = "";
            column20.CellAppearance = appearance20;
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            column21.CellActivation = Activation.NoEdit;
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.PRPLACEPRPLACEOSNOVICADescription;
            column21.Width = 0x66;
            appearance21.TextHAlign = HAlign.Right;
            column21.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column21.PromptChar = ' ';
            column21.Format = "F2";
            column21.CellAppearance = appearance21;
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            column22.CellActivation = Activation.NoEdit;
            column22.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column22.Header.Caption = StringResources.PRPLACEPRPLACEPROSJECNISATIDescription;
            column22.Width = 150;
            appearance22.TextHAlign = HAlign.Right;
            column22.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column22.PromptChar = ' ';
            column22.Format = "F2";
            column22.CellAppearance = appearance22;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.PRPLACEPRPLACEZAMJESECDescription;
            column6.Width = 0x4e;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nn";
            column6.PromptChar = ' ';
            column6.Format = "";
            column6.CellAppearance = appearance6;
            column6.Hidden = true;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.PRPLACEPRPLACEIDDescription;
            column4.Width = 0xcf;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnn";
            column4.PromptChar = ' ';
            column4.Format = "";
            column4.CellAppearance = appearance4;
            column4.Hidden = true;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.PRPLACEPRPLACEZAGODINUDescription;
            column5.Width = 0x4e;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnn";
            column5.PromptChar = ' ';
            column5.Format = "";
            column5.CellAppearance = appearance5;
            column5.Hidden = true;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.PRPLACEIDELEMENTDescription;
            column.Width = 0x70;
            column.Format = "";
            column.CellAppearance = appearance;
            column.Hidden = true;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.PRPLACENAZIVELEMENTDescription;
            column2.Width = 0x128;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            column2.Hidden = true;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.PRPLACEPOSTOTAKDescription;
            column3.Width = 0x4b;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnn.nn";
            column3.PromptChar = ' ';
            column3.Format = "F2";
            column3.CellAppearance = appearance3;
            column3.Hidden = true;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.NoEdit;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.PRPLACEPRPLACEZAMJESECDescription;
            column17.Width = 0x4e;
            appearance17.TextHAlign = HAlign.Right;
            column17.MaskInput = "{LOC}-nn";
            column17.PromptChar = ' ';
            column17.Format = "";
            column17.CellAppearance = appearance17;
            column17.Hidden = true;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.PRPLACEPRPLACEIDDescription;
            column11.Width = 0xcf;
            appearance11.TextHAlign = HAlign.Right;
            column11.MaskInput = "{LOC}-nnnnn";
            column11.PromptChar = ' ';
            column11.Format = "";
            column11.CellAppearance = appearance11;
            column11.Hidden = true;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.PRPLACEPRPLACEZAGODINUDescription;
            column16.Width = 0x4e;
            appearance16.TextHAlign = HAlign.Right;
            column16.MaskInput = "{LOC}-nnnn";
            column16.PromptChar = ' ';
            column16.Format = "";
            column16.CellAppearance = appearance16;
            column16.Hidden = true;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.PRPLACEIDELEMENTDescription;
            column7.Width = 0x70;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            column7.Hidden = true;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.PRPLACEIDRADNIKDescription;
            column8.Width = 0x55;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            column8.Hidden = true;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.PRPLACEPREZIMEDescription;
            column10.Width = 0x128;
            column10.Format = "";
            column10.CellAppearance = appearance10;
            column10.Hidden = true;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.PRPLACEIMEDescription;
            column9.Width = 0x128;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            column9.Hidden = true;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.PRPLACEPRPLACESATIDescription;
            column14.Width = 0x37;
            appearance14.TextHAlign = HAlign.Right;
            column14.MaskInput = "{LOC}-nnn.nn";
            column14.PromptChar = ' ';
            column14.Format = "F2";
            column14.CellAppearance = appearance14;
            column14.Hidden = true;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.PRPLACEPRPLACESATNICADescription;
            column15.Width = 0x45;
            appearance15.TextHAlign = HAlign.Right;
            column15.MaskInput = "{LOC}-nnn.nn";
            column15.PromptChar = ' ';
            column15.Format = "F2";
            column15.CellAppearance = appearance15;
            column15.Hidden = true;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.PRPLACEPRPLACEPOSTOTAKDescription;
            column13.Width = 0x4b;
            appearance13.TextHAlign = HAlign.Right;
            column13.MaskInput = "{LOC}-nnn.nn";
            column13.PromptChar = ' ';
            column13.Format = "F2";
            column13.CellAppearance = appearance13;
            column13.Hidden = true;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.PRPLACEPRPLACEIZNOSDescription;
            column12.Width = 0x66;
            appearance12.TextHAlign = HAlign.Right;
            column12.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column12.PromptChar = ' ';
            column12.Format = "F2";
            column12.CellAppearance = appearance12;
            column12.Hidden = true;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column18.CellActivation = Activation.NoEdit;
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.PRPLACESPOJENOPREZIMEDescription;
            column18.Width = 0x128;
            column18.Format = "";
            column18.CellAppearance = appearance18;
            column18.Hidden = true;
            band3.Columns.Add(column17);
            column17.Header.VisiblePosition = 0;
            band3.Columns.Add(column16);
            column16.Header.VisiblePosition = 1;
            band3.Columns.Add(column11);
            column11.Header.VisiblePosition = 2;
            band3.Columns.Add(column7);
            column7.Header.VisiblePosition = 3;
            band3.Columns.Add(column8);
            column8.Header.VisiblePosition = 4;
            band3.Columns.Add(column10);
            column10.Header.VisiblePosition = 5;
            band3.Columns.Add(column9);
            column9.Header.VisiblePosition = 6;
            band3.Columns.Add(column14);
            column14.Header.VisiblePosition = 7;
            band3.Columns.Add(column15);
            column15.Header.VisiblePosition = 8;
            band3.Columns.Add(column13);
            column13.Header.VisiblePosition = 9;
            band3.Columns.Add(column12);
            column12.Header.VisiblePosition = 10;
            band3.Columns.Add(column18);
            column18.Header.VisiblePosition = 11;
            band3.Hidden = true;
            band2.Columns.Add(column6);
            column6.Header.VisiblePosition = 0;
            band2.Columns.Add(column5);
            column5.Header.VisiblePosition = 1;
            band2.Columns.Add(column4);
            column4.Header.VisiblePosition = 2;
            band2.Columns.Add(column);
            column.Header.VisiblePosition = 3;
            band2.Columns.Add(column2);
            column2.Header.VisiblePosition = 4;
            band2.Columns.Add(column3);
            column3.Header.VisiblePosition = 5;
            band2.Hidden = true;
            band.Columns.Add(column24);
            column24.Header.VisiblePosition = 0;
            band.Columns.Add(column23);
            column23.Header.VisiblePosition = 1;
            band.Columns.Add(column20);
            column20.Header.VisiblePosition = 2;
            band.Columns.Add(column21);
            column21.Header.VisiblePosition = 3;
            band.Columns.Add(column22);
            column22.Header.VisiblePosition = 4;
            band.Columns.Add(column19);
            column19.Header.VisiblePosition = 5;
            this.userControlDataGridPRPLACE.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridPRPLACE.Location = point;
            this.userControlDataGridPRPLACE.Name = "userControlDataGridPRPLACE";
            this.userControlDataGridPRPLACE.Tag = "PRPLACE";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridPRPLACE.Size = size;
            this.userControlDataGridPRPLACE.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridPRPLACE.Dock = DockStyle.Fill;
            this.userControlDataGridPRPLACE.FillAtStartup = false;
            this.userControlDataGridPRPLACE.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridPRPLACE.InitializeRow += new InitializeRowEventHandler(this.PRPLACEUserDataGrid_InitializeRow);
            this.userControlDataGridPRPLACE.DisplayLayout.BandsSerializer.Add(band);
            this.userControlDataGridPRPLACE.DisplayLayout.BandsSerializer.Add(band2);
            this.userControlDataGridPRPLACE.DisplayLayout.BandsSerializer.Add(band3);
            this.Controls.AddRange(new Control[] { this.userControlDataGridPRPLACE });
            this.Name = "PRPLACEUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.PRPLACEUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridPRPLACE).EndInit();
            this.ResumeLayout(false);
        }

        private void PRPLACEUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void PRPLACEUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual PRPLACEDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridPRPLACE;
            }
            set
            {
                this.userControlDataGridPRPLACE = value;
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

        [DefaultValue(true), Description("True= Fill at Startup. False= Not Fill"), Category("Deklarit Work With ")]
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

        [Category("Deklarit Work With ")]
        public virtual int FillByPRPLACEIDPRPLACEID
        {
            get
            {
                return this.DataGrid.FillByPRPLACEIDPRPLACEID;
            }
            set
            {
                this.DataGrid.FillByPRPLACEIDPRPLACEID = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByPRPLACEIDPRPLACEZAMJESECPRPLACEID
        {
            get
            {
                return this.DataGrid.FillByPRPLACEIDPRPLACEZAMJESECPRPLACEID;
            }
            set
            {
                this.DataGrid.FillByPRPLACEIDPRPLACEZAMJESECPRPLACEID = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual short FillByPRPLACEIDPRPLACEZAMJESECPRPLACEZAMJESEC
        {
            get
            {
                return this.DataGrid.FillByPRPLACEIDPRPLACEZAMJESECPRPLACEZAMJESEC;
            }
            set
            {
                this.DataGrid.FillByPRPLACEIDPRPLACEZAMJESECPRPLACEZAMJESEC = value;
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


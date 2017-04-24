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

    public class RSMAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with RSMA";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with RSMA";
        private RSMADataGrid userControlDataGridRSMA;

        public RSMAUserDataGrid()
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
            this.userControlDataGridRSMA = new RSMADataGrid();
            ((ISupportInitialize) this.userControlDataGridRSMA).BeginInit();
            UltraGridBand band = new UltraGridBand("RSMA", -1);
            UltraGridColumn column20 = new UltraGridColumn("IDENTIFIKATOROBRASCA");
            UltraGridColumn column21 = new UltraGridColumn("IDOBRACUN");
            UltraGridColumn column28 = new UltraGridColumn("MBOBVEZNIKA");
            UltraGridColumn column27 = new UltraGridColumn("MBGOBVEZNIKA");
            UltraGridColumn column33 = new UltraGridColumn("NAZIVOBVEZNIKA");
            UltraGridColumn column16 = new UltraGridColumn("ADRESA");
            UltraGridColumn column23 = new UltraGridColumn("IDRSVRSTEOBVEZNIKA");
            UltraGridColumn column35 = new UltraGridColumn("NAZIVRSVRSTEOBVEZNIKA");
            UltraGridColumn column22 = new UltraGridColumn("IDRSVRSTEOBRACUNA");
            UltraGridColumn column34 = new UltraGridColumn("NAZIVRSVRSTEOBRACUNA");
            UltraGridColumn column32 = new UltraGridColumn("mjesecoBRACUNArsm");
            UltraGridColumn column19 = new UltraGridColumn("godinaobracunarsm");
            UltraGridColumn column17 = new UltraGridColumn("BROJOSIGURANIKA");
            UltraGridColumn column25 = new UltraGridColumn("IZNOSOBRACUNANEPLACE");
            UltraGridColumn column26 = new UltraGridColumn("IZNOSOSNOVICEZADOPRINOSE");
            UltraGridColumn column29 = new UltraGridColumn("MIO1");
            UltraGridColumn column30 = new UltraGridColumn("MIO2");
            UltraGridColumn column24 = new UltraGridColumn("IZNOSISPLACENEPLACE");
            UltraGridColumn column31 = new UltraGridColumn("mjesecisplatersm");
            UltraGridColumn column18 = new UltraGridColumn("godinaisplatersm");
            UltraGridBand band2 = new UltraGridBand("RSMA_RSMA1", 0);
            UltraGridColumn column4 = new UltraGridColumn("IDENTIFIKATOROBRASCA");
            UltraGridColumn column3 = new UltraGridColumn("ID");
            UltraGridColumn column14 = new UltraGridColumn("REDNIBROJ");
            UltraGridColumn column13 = new UltraGridColumn("PREZIMEIIME");
            UltraGridColumn column8 = new UltraGridColumn("MBGOSIGURANIKA");
            UltraGridColumn column15 = new UltraGridColumn("SIFRAGRADARADA");
            UltraGridColumn column12 = new UltraGridColumn("OO");
            UltraGridColumn column = new UltraGridColumn("B");
            UltraGridColumn column11 = new UltraGridColumn("OD");
            UltraGridColumn column2 = new UltraGridColumn("DOO");
            UltraGridColumn column6 = new UltraGridColumn("IZNOSOBRACUNANEPLACERSMB");
            UltraGridColumn column7 = new UltraGridColumn("IZNOSOSNOVICEZADOPRINOSERSMB");
            UltraGridColumn column9 = new UltraGridColumn("MIO1RSMB");
            UltraGridColumn column10 = new UltraGridColumn("MIO2RSMB");
            UltraGridColumn column5 = new UltraGridColumn("IZNOSISPLACENEPLACERSMB");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            column20.CellActivation = Activation.NoEdit;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.RSMAIDENTIFIKATOROBRASCADescription;
            column20.Width = 0x9c;
            column20.Format = "";
            column20.CellAppearance = appearance20;
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            column21.CellActivation = Activation.NoEdit;
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.RSMAIDOBRACUNDescription;
            column21.Width = 0x5d;
            column21.Format = "";
            column21.CellAppearance = appearance21;
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            column28.CellActivation = Activation.NoEdit;
            column28.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column28.Header.Caption = StringResources.RSMAMBOBVEZNIKADescription;
            column28.Width = 0x6b;
            column28.Format = "";
            column28.CellAppearance = appearance28;
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            column27.CellActivation = Activation.NoEdit;
            column27.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column27.Header.Caption = StringResources.RSMAMBGOBVEZNIKADescription;
            column27.Width = 0x6b;
            column27.Format = "";
            column27.CellAppearance = appearance27;
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            column33.CellActivation = Activation.NoEdit;
            column33.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column33.Header.Caption = StringResources.RSMANAZIVOBVEZNIKADescription;
            column33.Width = 0x128;
            column33.Format = "";
            column33.CellAppearance = appearance33;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.RSMAADRESADescription;
            column16.Width = 0x128;
            column16.Format = "";
            column16.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            column23.CellActivation = Activation.NoEdit;
            column23.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column23.Header.Caption = StringResources.RSMAIDRSVRSTEOBVEZNIKADescription;
            column23.Width = 0xa3;
            column23.Format = "";
            column23.CellAppearance = appearance23;
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            column35.CellActivation = Activation.NoEdit;
            column35.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column35.Header.Caption = StringResources.RSMANAZIVRSVRSTEOBVEZNIKADescription;
            column35.Width = 0x128;
            column35.Format = "";
            column35.CellAppearance = appearance35;
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            column22.CellActivation = Activation.NoEdit;
            column22.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column22.Header.Caption = StringResources.RSMAIDRSVRSTEOBRACUNADescription;
            column22.Width = 0x9c;
            column22.Format = "";
            column22.CellAppearance = appearance22;
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            column34.CellActivation = Activation.NoEdit;
            column34.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column34.Header.Caption = StringResources.RSMANAZIVRSVRSTEOBRACUNADescription;
            column34.Width = 0x128;
            column34.Format = "";
            column34.CellAppearance = appearance34;
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            column32.CellActivation = Activation.NoEdit;
            column32.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column32.Header.Caption = StringResources.RSMAmjesecoBRACUNArsmDescription;
            column32.Width = 0x95;
            column32.Format = "";
            column32.CellAppearance = appearance32;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column19.CellActivation = Activation.NoEdit;
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.RSMAgodinaobracunarsmDescription;
            column19.Width = 0x87;
            column19.Format = "";
            column19.CellAppearance = appearance19;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.NoEdit;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.RSMABROJOSIGURANIKADescription;
            column17.Width = 0x79;
            column17.Format = "";
            column17.CellAppearance = appearance17;
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            column25.CellActivation = Activation.NoEdit;
            column25.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column25.Header.Caption = StringResources.RSMAIZNOSOBRACUNANEPLACEDescription;
            column25.Width = 0x9c;
            appearance25.TextHAlign = HAlign.Right;
            column25.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column25.PromptChar = ' ';
            column25.Format = "F2";
            column25.CellAppearance = appearance25;
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            column26.CellActivation = Activation.NoEdit;
            column26.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column26.Header.Caption = StringResources.RSMAIZNOSOSNOVICEZADOPRINOSEDescription;
            column26.Width = 0xb7;
            appearance26.TextHAlign = HAlign.Right;
            column26.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column26.PromptChar = ' ';
            column26.Format = "F2";
            column26.CellAppearance = appearance26;
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            column29.CellActivation = Activation.NoEdit;
            column29.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column29.Header.Caption = StringResources.RSMAMIO1Description;
            column29.Width = 0x66;
            appearance29.TextHAlign = HAlign.Right;
            column29.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column29.PromptChar = ' ';
            column29.Format = "F2";
            column29.CellAppearance = appearance29;
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            column30.CellActivation = Activation.NoEdit;
            column30.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column30.Header.Caption = StringResources.RSMAMIO2Description;
            column30.Width = 0x66;
            appearance30.TextHAlign = HAlign.Right;
            column30.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column30.PromptChar = ' ';
            column30.Format = "F2";
            column30.CellAppearance = appearance30;
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            column24.CellActivation = Activation.NoEdit;
            column24.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column24.Header.Caption = StringResources.RSMAIZNOSISPLACENEPLACEDescription;
            column24.Width = 150;
            appearance24.TextHAlign = HAlign.Right;
            column24.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column24.PromptChar = ' ';
            column24.Format = "F2";
            column24.CellAppearance = appearance24;
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            column31.CellActivation = Activation.NoEdit;
            column31.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column31.Header.Caption = StringResources.RSMAmjesecisplatersmDescription;
            column31.Width = 0x80;
            column31.Format = "";
            column31.CellAppearance = appearance31;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column18.CellActivation = Activation.NoEdit;
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.RSMAgodinaisplatersmDescription;
            column18.Width = 0x80;
            column18.Format = "";
            column18.CellAppearance = appearance18;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.RSMAIDENTIFIKATOROBRASCADescription;
            column4.Width = 0x9c;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            column4.Hidden = true;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.RSMAIDDescription;
            column3.Width = 0x33;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnn";
            column3.PromptChar = ' ';
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.RSMAREDNIBROJDescription;
            column14.Width = 0x4f;
            column14.Format = "";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.RSMAPREZIMEIIMEDescription;
            column13.Width = 0x128;
            column13.Format = "";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.RSMAMBGOSIGURANIKADescription;
            column8.Width = 0x72;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.RSMASIFRAGRADARADADescription;
            column15.Width = 0x72;
            column15.Format = "";
            column15.CellAppearance = appearance15;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.RSMAOODescription;
            column12.Width = 30;
            column12.Format = "";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.RSMABDescription;
            column.Width = 0x17;
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.RSMAODDescription;
            column11.Width = 30;
            column11.Format = "";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.RSMADOODescription;
            column2.Width = 0x25;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.RSMAIZNOSOBRACUNANEPLACERSMBDescription;
            column6.Width = 0xb7;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column6.PromptChar = ' ';
            column6.Format = "F2";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.RSMAIZNOSOSNOVICEZADOPRINOSERSMBDescription;
            column7.Width = 210;
            appearance7.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column7.PromptChar = ' ';
            column7.Format = "F2";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.RSMAMIO1RSMBDescription;
            column9.Width = 0x66;
            appearance9.TextHAlign = HAlign.Right;
            column9.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column9.PromptChar = ' ';
            column9.Format = "F2";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.RSMAMIO2RSMBDescription;
            column10.Width = 0x66;
            appearance10.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column10.PromptChar = ' ';
            column10.Format = "F2";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.RSMAIZNOSISPLACENEPLACERSMBDescription;
            column5.Width = 0xb1;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column5.PromptChar = ' ';
            column5.Format = "F2";
            column5.CellAppearance = appearance5;
            band2.Columns.Add(column4);
            column4.Header.VisiblePosition = 0;
            band2.Columns.Add(column3);
            column3.Header.VisiblePosition = 1;
            band2.Columns.Add(column14);
            column14.Header.VisiblePosition = 2;
            band2.Columns.Add(column13);
            column13.Header.VisiblePosition = 3;
            band2.Columns.Add(column8);
            column8.Header.VisiblePosition = 4;
            band2.Columns.Add(column15);
            column15.Header.VisiblePosition = 5;
            band2.Columns.Add(column12);
            column12.Header.VisiblePosition = 6;
            band2.Columns.Add(column);
            column.Header.VisiblePosition = 7;
            band2.Columns.Add(column11);
            column11.Header.VisiblePosition = 8;
            band2.Columns.Add(column2);
            column2.Header.VisiblePosition = 9;
            band2.Columns.Add(column6);
            column6.Header.VisiblePosition = 10;
            band2.Columns.Add(column7);
            column7.Header.VisiblePosition = 11;
            band2.Columns.Add(column9);
            column9.Header.VisiblePosition = 12;
            band2.Columns.Add(column10);
            column10.Header.VisiblePosition = 13;
            band2.Columns.Add(column5);
            column5.Header.VisiblePosition = 14;
            band.Columns.Add(column20);
            column20.Header.VisiblePosition = 0;
            band.Columns.Add(column21);
            column21.Header.VisiblePosition = 1;
            band.Columns.Add(column28);
            column28.Header.VisiblePosition = 2;
            band.Columns.Add(column27);
            column27.Header.VisiblePosition = 3;
            band.Columns.Add(column33);
            column33.Header.VisiblePosition = 4;
            band.Columns.Add(column16);
            column16.Header.VisiblePosition = 5;
            band.Columns.Add(column23);
            column23.Header.VisiblePosition = 6;
            band.Columns.Add(column35);
            column35.Header.VisiblePosition = 7;
            band.Columns.Add(column22);
            column22.Header.VisiblePosition = 8;
            band.Columns.Add(column34);
            column34.Header.VisiblePosition = 9;
            band.Columns.Add(column32);
            column32.Header.VisiblePosition = 10;
            band.Columns.Add(column19);
            column19.Header.VisiblePosition = 11;
            band.Columns.Add(column17);
            column17.Header.VisiblePosition = 12;
            band.Columns.Add(column25);
            column25.Header.VisiblePosition = 13;
            band.Columns.Add(column26);
            column26.Header.VisiblePosition = 14;
            band.Columns.Add(column29);
            column29.Header.VisiblePosition = 15;
            band.Columns.Add(column30);
            column30.Header.VisiblePosition = 0x10;
            band.Columns.Add(column24);
            column24.Header.VisiblePosition = 0x11;
            band.Columns.Add(column31);
            column31.Header.VisiblePosition = 0x12;
            band.Columns.Add(column18);
            column18.Header.VisiblePosition = 0x13;
            this.userControlDataGridRSMA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridRSMA.Location = point;
            this.userControlDataGridRSMA.Name = "userControlDataGridRSMA";
            this.userControlDataGridRSMA.Tag = "RSMA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridRSMA.Size = size;
            this.userControlDataGridRSMA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridRSMA.Dock = DockStyle.Fill;
            this.userControlDataGridRSMA.FillAtStartup = false;
            this.userControlDataGridRSMA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridRSMA.InitializeRow += new InitializeRowEventHandler(this.RSMAUserDataGrid_InitializeRow);
            this.userControlDataGridRSMA.DisplayLayout.BandsSerializer.Add(band);
            this.userControlDataGridRSMA.DisplayLayout.BandsSerializer.Add(band2);
            this.Controls.AddRange(new Control[] { this.userControlDataGridRSMA });
            this.Name = "RSMAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.RSMAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridRSMA).EndInit();
            this.ResumeLayout(false);
        }

        private void RSMAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void RSMAUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual RSMADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridRSMA;
            }
            set
            {
                this.userControlDataGridRSMA = value;
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

        [Category("Deklarit Work With ")]
        public virtual string FillByIDOBRACUNIDOBRACUN
        {
            get
            {
                return this.DataGrid.FillByIDOBRACUNIDOBRACUN;
            }
            set
            {
                this.DataGrid.FillByIDOBRACUNIDOBRACUN = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual string FillByIDRSVRSTEOBRACUNAIDRSVRSTEOBRACUNA
        {
            get
            {
                return this.DataGrid.FillByIDRSVRSTEOBRACUNAIDRSVRSTEOBRACUNA;
            }
            set
            {
                this.DataGrid.FillByIDRSVRSTEOBRACUNAIDRSVRSTEOBRACUNA = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual string FillByIDRSVRSTEOBVEZNIKAIDRSVRSTEOBVEZNIKA
        {
            get
            {
                return this.DataGrid.FillByIDRSVRSTEOBVEZNIKAIDRSVRSTEOBVEZNIKA;
            }
            set
            {
                this.DataGrid.FillByIDRSVRSTEOBVEZNIKAIDRSVRSTEOBVEZNIKA = value;
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

        [Category("Deklarit Work With "), DefaultValue("Fill"), TypeConverter(typeof(DeklaritDataGrid.FillMethodsConverter))]
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


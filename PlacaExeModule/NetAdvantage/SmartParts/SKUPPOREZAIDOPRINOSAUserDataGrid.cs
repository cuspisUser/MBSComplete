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

    public class SKUPPOREZAIDOPRINOSAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Skupine poreza i doprinosa";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Skupine poreza i doprinosa";
        private SKUPPOREZAIDOPRINOSADataGrid userControlDataGridSKUPPOREZAIDOPRINOSA;

        public SKUPPOREZAIDOPRINOSAUserDataGrid()
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
            this.userControlDataGridSKUPPOREZAIDOPRINOSA = new SKUPPOREZAIDOPRINOSADataGrid();
            ((ISupportInitialize) this.userControlDataGridSKUPPOREZAIDOPRINOSA).BeginInit();
            UltraGridBand band = new UltraGridBand("SKUPPOREZAIDOPRINOSA", -1);
            UltraGridColumn column32 = new UltraGridColumn("IDSKUPPOREZAIDOPRINOSA");
            UltraGridColumn column33 = new UltraGridColumn("NAZIVSKUPPOREZAIDOPRINOSA");
            UltraGridBand band2 = new UltraGridBand("SKUPPOREZAIDOPRINOSA_SKUPPOREZAIDOPRINOSA1", 0);
            UltraGridColumn column2 = new UltraGridColumn("IDSKUPPOREZAIDOPRINOSA");
            UltraGridColumn column = new UltraGridColumn("IDPOREZ");
            UltraGridColumn column5 = new UltraGridColumn("NAZIVPOREZ");
            UltraGridColumn column8 = new UltraGridColumn("POREZMJESECNO");
            UltraGridColumn column13 = new UltraGridColumn("STOPAPOREZA");
            UltraGridColumn column3 = new UltraGridColumn("MOPOREZ");
            UltraGridColumn column7 = new UltraGridColumn("POPOREZ");
            UltraGridColumn column4 = new UltraGridColumn("MZPOREZ");
            UltraGridColumn column11 = new UltraGridColumn("PZPOREZ");
            UltraGridColumn column9 = new UltraGridColumn("PRIMATELJPOREZ1");
            UltraGridColumn column10 = new UltraGridColumn("PRIMATELJPOREZ2");
            UltraGridColumn column12 = new UltraGridColumn("SIFRAOPISAPLACANJAPOREZ");
            UltraGridColumn column6 = new UltraGridColumn("OPISPLACANJAPOREZ");
            UltraGridBand band3 = new UltraGridBand("SKUPPOREZAIDOPRINOSA_SKUPPOREZAIDOPRINOSA2", 0);
            UltraGridColumn column15 = new UltraGridColumn("IDSKUPPOREZAIDOPRINOSA");
            UltraGridColumn column14 = new UltraGridColumn("IDDOPRINOS");
            UltraGridColumn column21 = new UltraGridColumn("NAZIVDOPRINOS");
            UltraGridColumn column16 = new UltraGridColumn("IDVRSTADOPRINOS");
            UltraGridColumn column22 = new UltraGridColumn("NAZIVVRSTADOPRINOS");
            UltraGridColumn column19 = new UltraGridColumn("MODOPRINOS");
            UltraGridColumn column24 = new UltraGridColumn("PODOPRINOS");
            UltraGridColumn column20 = new UltraGridColumn("MZDOPRINOS");
            UltraGridColumn column27 = new UltraGridColumn("PZDOPRINOS");
            UltraGridColumn column25 = new UltraGridColumn("PRIMATELJDOPRINOS1");
            UltraGridColumn column26 = new UltraGridColumn("PRIMATELJDOPRINOS2");
            UltraGridColumn column28 = new UltraGridColumn("SIFRAOPISAPLACANJADOPRINOS");
            UltraGridColumn column23 = new UltraGridColumn("OPISPLACANJADOPRINOS");
            UltraGridColumn column30 = new UltraGridColumn("VBDIDOPRINOS");
            UltraGridColumn column31 = new UltraGridColumn("ZRNDOPRINOS");
            UltraGridColumn column18 = new UltraGridColumn("MINDOPRINOS");
            UltraGridColumn column17 = new UltraGridColumn("MAXDOPRINOS");
            UltraGridColumn column29 = new UltraGridColumn("STOPA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            column32.CellActivation = Activation.NoEdit;
            column32.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column32.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAIDSKUPPOREZAIDOPRINOSADescription;
            column32.Width = 0xea;
            appearance32.TextHAlign = HAlign.Right;
            column32.MaskInput = "{LOC}-nnnnn";
            column32.PromptChar = ' ';
            column32.Format = "";
            column32.CellAppearance = appearance32;
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            column33.CellActivation = Activation.NoEdit;
            column33.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column33.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSANAZIVSKUPPOREZAIDOPRINOSADescription;
            column33.Width = 0x128;
            column33.Format = "";
            column33.CellAppearance = appearance33;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAIDSKUPPOREZAIDOPRINOSADescription;
            column2.Width = 0xea;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            column2.Hidden = true;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAIDPOREZDescription;
            column.Width = 0x63;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSANAZIVPOREZDescription;
            column5.Width = 0x128;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAPOREZMJESECNODescription;
            column8.Width = 0xd9;
            appearance8.TextHAlign = HAlign.Right;
            column8.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column8.PromptChar = ' ';
            column8.Format = "F2";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSASTOPAPOREZADescription;
            column13.Width = 0x66;
            appearance13.TextHAlign = HAlign.Right;
            column13.MaskInput = "{LOC}-nn.nn";
            column13.PromptChar = ' ';
            column13.Format = "F2";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAMOPOREZDescription;
            column3.Width = 170;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAPOPOREZDescription;
            column7.Width = 0xe2;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAMZPOREZDescription;
            column4.Width = 170;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAPZPOREZDescription;
            column11.Width = 0xe2;
            column11.Format = "";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAPRIMATELJPOREZ1Description;
            column9.Width = 0x9c;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAPRIMATELJPOREZ2Description;
            column10.Width = 0x9c;
            column10.Format = "";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSASIFRAOPISAPLACANJAPOREZDescription;
            column12.Width = 0xcd;
            column12.Format = "";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAOPISPLACANJAPOREZDescription;
            column6.Width = 0x10c;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            band2.Columns.Add(column2);
            column2.Header.VisiblePosition = 0;
            band2.Columns.Add(column);
            column.Header.VisiblePosition = 1;
            band2.Columns.Add(column5);
            column5.Header.VisiblePosition = 2;
            band2.Columns.Add(column8);
            column8.Header.VisiblePosition = 3;
            band2.Columns.Add(column13);
            column13.Header.VisiblePosition = 4;
            band2.Columns.Add(column3);
            column3.Header.VisiblePosition = 5;
            band2.Columns.Add(column7);
            column7.Header.VisiblePosition = 6;
            band2.Columns.Add(column4);
            column4.Header.VisiblePosition = 7;
            band2.Columns.Add(column11);
            column11.Header.VisiblePosition = 8;
            band2.Columns.Add(column9);
            column9.Header.VisiblePosition = 9;
            band2.Columns.Add(column10);
            column10.Header.VisiblePosition = 10;
            band2.Columns.Add(column12);
            column12.Header.VisiblePosition = 11;
            band2.Columns.Add(column6);
            column6.Header.VisiblePosition = 12;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAIDSKUPPOREZAIDOPRINOSADescription;
            column15.Width = 0xea;
            appearance15.TextHAlign = HAlign.Right;
            column15.MaskInput = "{LOC}-nnnnn";
            column15.PromptChar = ' ';
            column15.Format = "";
            column15.CellAppearance = appearance15;
            column15.Hidden = true;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAIDDOPRINOSDescription;
            column14.Width = 0x77;
            appearance14.TextHAlign = HAlign.Right;
            column14.MaskInput = "{LOC}-nnnnnnnn";
            column14.PromptChar = ' ';
            column14.Format = "";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            column21.CellActivation = Activation.NoEdit;
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSANAZIVDOPRINOSDescription;
            column21.Width = 0x128;
            column21.Format = "";
            column21.CellAppearance = appearance21;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAIDVRSTADOPRINOSDescription;
            column16.Width = 0x9f;
            appearance16.TextHAlign = HAlign.Right;
            column16.MaskInput = "{LOC}-nnnnn";
            column16.PromptChar = ' ';
            column16.Format = "";
            column16.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            column22.CellActivation = Activation.NoEdit;
            column22.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column22.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSANAZIVVRSTADOPRINOSDescription;
            column22.Width = 0x128;
            column22.Format = "";
            column22.CellAppearance = appearance22;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column19.CellActivation = Activation.NoEdit;
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAMODOPRINOSDescription;
            column19.Width = 0xbf;
            column19.Format = "";
            column19.CellAppearance = appearance19;
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            column24.CellActivation = Activation.NoEdit;
            column24.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column24.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAPODOPRINOSDescription;
            column24.Width = 0xbf;
            column24.Format = "";
            column24.CellAppearance = appearance24;
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            column20.CellActivation = Activation.NoEdit;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAMZDOPRINOSDescription;
            column20.Width = 0xbf;
            column20.Format = "";
            column20.CellAppearance = appearance20;
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            column27.CellActivation = Activation.NoEdit;
            column27.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column27.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAPZDOPRINOSDescription;
            column27.Width = 0xbf;
            column27.Format = "";
            column27.CellAppearance = appearance27;
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            column25.CellActivation = Activation.NoEdit;
            column25.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column25.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAPRIMATELJDOPRINOS1Description;
            column25.Width = 0x9c;
            column25.Format = "";
            column25.CellAppearance = appearance25;
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            column26.CellActivation = Activation.NoEdit;
            column26.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column26.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAPRIMATELJDOPRINOS2Description;
            column26.Width = 0xb1;
            column26.Format = "";
            column26.CellAppearance = appearance26;
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            column28.CellActivation = Activation.NoEdit;
            column28.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column28.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSASIFRAOPISAPLACANJADOPRINOSDescription;
            column28.Width = 0xe2;
            column28.Format = "";
            column28.CellAppearance = appearance28;
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            column23.CellActivation = Activation.NoEdit;
            column23.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column23.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAOPISPLACANJADOPRINOSDescription;
            column23.Width = 0x10c;
            column23.Format = "";
            column23.CellAppearance = appearance23;
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            column30.CellActivation = Activation.NoEdit;
            column30.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column30.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAVBDIDOPRINOSDescription;
            column30.Width = 0x80;
            column30.Format = "";
            column30.CellAppearance = appearance30;
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            column31.CellActivation = Activation.NoEdit;
            column31.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column31.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAZRNDOPRINOSDescription;
            column31.Width = 170;
            column31.Format = "";
            column31.CellAppearance = appearance31;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column18.CellActivation = Activation.NoEdit;
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAMINDOPRINOSDescription;
            column18.Width = 0x11d;
            appearance18.TextHAlign = HAlign.Right;
            column18.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column18.PromptChar = ' ';
            column18.Format = "F2";
            column18.CellAppearance = appearance18;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.NoEdit;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAMAXDOPRINOSDescription;
            column17.Width = 0x123;
            appearance17.TextHAlign = HAlign.Right;
            column17.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column17.PromptChar = ' ';
            column17.Format = "F2";
            column17.CellAppearance = appearance17;
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            column29.CellActivation = Activation.NoEdit;
            column29.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column29.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSASTOPADescription;
            column29.Width = 0x37;
            appearance29.TextHAlign = HAlign.Right;
            column29.MaskInput = "{LOC}-nnn.nn";
            column29.PromptChar = ' ';
            column29.Format = "F2";
            column29.CellAppearance = appearance29;
            band3.Columns.Add(column15);
            column15.Header.VisiblePosition = 0;
            band3.Columns.Add(column14);
            column14.Header.VisiblePosition = 1;
            band3.Columns.Add(column21);
            column21.Header.VisiblePosition = 2;
            band3.Columns.Add(column16);
            column16.Header.VisiblePosition = 3;
            band3.Columns.Add(column22);
            column22.Header.VisiblePosition = 4;
            band3.Columns.Add(column19);
            column19.Header.VisiblePosition = 5;
            band3.Columns.Add(column24);
            column24.Header.VisiblePosition = 6;
            band3.Columns.Add(column20);
            column20.Header.VisiblePosition = 7;
            band3.Columns.Add(column27);
            column27.Header.VisiblePosition = 8;
            band3.Columns.Add(column25);
            column25.Header.VisiblePosition = 9;
            band3.Columns.Add(column26);
            column26.Header.VisiblePosition = 10;
            band3.Columns.Add(column28);
            column28.Header.VisiblePosition = 11;
            band3.Columns.Add(column23);
            column23.Header.VisiblePosition = 12;
            band3.Columns.Add(column30);
            column30.Header.VisiblePosition = 13;
            band3.Columns.Add(column31);
            column31.Header.VisiblePosition = 14;
            band3.Columns.Add(column18);
            column18.Header.VisiblePosition = 15;
            band3.Columns.Add(column17);
            column17.Header.VisiblePosition = 0x10;
            band3.Columns.Add(column29);
            column29.Header.VisiblePosition = 0x11;
            band.Columns.Add(column32);
            column32.Header.VisiblePosition = 0;
            band.Columns.Add(column33);
            column33.Header.VisiblePosition = 1;
            this.userControlDataGridSKUPPOREZAIDOPRINOSA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridSKUPPOREZAIDOPRINOSA.Location = point;
            this.userControlDataGridSKUPPOREZAIDOPRINOSA.Name = "userControlDataGridSKUPPOREZAIDOPRINOSA";
            this.userControlDataGridSKUPPOREZAIDOPRINOSA.Tag = "SKUPPOREZAIDOPRINOSA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridSKUPPOREZAIDOPRINOSA.Size = size;
            this.userControlDataGridSKUPPOREZAIDOPRINOSA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridSKUPPOREZAIDOPRINOSA.Dock = DockStyle.Fill;
            this.userControlDataGridSKUPPOREZAIDOPRINOSA.FillAtStartup = false;
            this.userControlDataGridSKUPPOREZAIDOPRINOSA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridSKUPPOREZAIDOPRINOSA.InitializeRow += new InitializeRowEventHandler(this.SKUPPOREZAIDOPRINOSAUserDataGrid_InitializeRow);
            this.userControlDataGridSKUPPOREZAIDOPRINOSA.DisplayLayout.BandsSerializer.Add(band);
            this.userControlDataGridSKUPPOREZAIDOPRINOSA.DisplayLayout.BandsSerializer.Add(band2);
            this.userControlDataGridSKUPPOREZAIDOPRINOSA.DisplayLayout.BandsSerializer.Add(band3);
            this.Controls.AddRange(new Control[] { this.userControlDataGridSKUPPOREZAIDOPRINOSA });
            this.Name = "SKUPPOREZAIDOPRINOSAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.SKUPPOREZAIDOPRINOSAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridSKUPPOREZAIDOPRINOSA).EndInit();
            this.ResumeLayout(false);
        }

        private void SKUPPOREZAIDOPRINOSAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void SKUPPOREZAIDOPRINOSAUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual SKUPPOREZAIDOPRINOSADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridSKUPPOREZAIDOPRINOSA;
            }
            set
            {
                this.userControlDataGridSKUPPOREZAIDOPRINOSA = value;
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


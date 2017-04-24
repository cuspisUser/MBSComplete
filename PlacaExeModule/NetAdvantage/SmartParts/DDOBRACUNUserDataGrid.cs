namespace NetAdvantage.SmartParts
{
    using Deklarit.Controls;
    using Infragistics.Win;
    using Infragistics.Win.UltraWinGrid;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using NetAdvantage.Controls;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class DDOBRACUNUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with DDOBRACUN";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with DDOBRACUN";
        private DDOBRACUNDataGrid userControlDataGridDDOBRACUN;

        public DDOBRACUNUserDataGrid()
        {
            this.InitializeComponent();
        }

        private static void CreateValueList(UltraGrid dataGrid1, string valueListName, System.Data.DataView dataList, string Id, string Name)
        {
            ValueList list = null;
            if (dataGrid1.DisplayLayout.ValueLists.Exists(valueListName) && (dataGrid1.DisplayLayout.ValueLists[valueListName].ValueListItems.Count != dataList.Count))
            {
                dataGrid1.DisplayLayout.ValueLists.Remove(valueListName);
                list = dataGrid1.DisplayLayout.ValueLists.Add(valueListName);
            }
            if (!dataGrid1.DisplayLayout.ValueLists.Exists(valueListName))
            {
                list = dataGrid1.DisplayLayout.ValueLists.Add(valueListName);
            }
            if (list != null)
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = dataList.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataRowView current = (DataRowView) enumerator.Current;
                        DataRow row = current.Row;
                        ValueListItem item = new ValueListItem {
                            DataValue = RuntimeHelpers.GetObjectValue(row[Id]),
                            DisplayText = row[Name].ToString()
                        };
                        list.ValueListItems.Add(item);
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                list.Tag = dataList;
            }
        }

        private void DDOBRACUNUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void DDOBRACUNUserDataGrid_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.SetComboBoxColumnProperties(true);
                if (this.FillAtStartup)
                {
                    this.DataGrid.Fill();
                }
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
            this.SetComboBoxColumnProperties(false);
            this.DataGrid.Fill();
        }

        private void InitializeComponent()
        {
            this.userControlDataGridDDOBRACUN = new DDOBRACUNDataGrid();
            ((ISupportInitialize) this.userControlDataGridDDOBRACUN).BeginInit();
            UltraGridBand band = new UltraGridBand("DDOBRACUN", -1);
            UltraGridColumn column2 = new UltraGridColumn("DDOBRACUNIDOBRACUN");
            UltraGridColumn column3 = new UltraGridColumn("DDOPISOBRACUN");
            UltraGridColumn column = new UltraGridColumn("DDDATUMOBRACUNA");
            UltraGridColumn column5 = new UltraGridColumn("DDZAKLJUCAN");
            UltraGridColumn column4 = new UltraGridColumn("DDRSM");
            UltraGridBand band2 = new UltraGridBand("DDOBRACUN_DDOBRACUNRadnici", 0);
            UltraGridColumn column33 = new UltraGridColumn("DDOBRACUNIDOBRACUN");
            UltraGridColumn column7 = new UltraGridColumn("DDIDRADNIK");
            UltraGridColumn column36 = new UltraGridColumn("DDPREZIME");
            UltraGridColumn column8 = new UltraGridColumn("DDIME");
            UltraGridColumn column59 = new UltraGridColumn("IDKATEGORIJA");
            UltraGridColumn column70 = new UltraGridColumn("NAZIVKATEGORIJA");
            UltraGridColumn column32 = new UltraGridColumn("DDOBRACUNATIPRIREZ");
            UltraGridColumn column31 = new UltraGridColumn("DDOBRACUNATIPDV");
            UltraGridColumn column71 = new UltraGridColumn("OPCINARADAIDOPCINE");
            UltraGridColumn column72 = new UltraGridColumn("OPCINARADANAZIVOPCINE");
            UltraGridColumn column73 = new UltraGridColumn("OPCINASTANOVANJAIDOPCINE");
            UltraGridColumn column74 = new UltraGridColumn("OPCINASTANOVANJANAZIVOPCINE");
            UltraGridColumn column75 = new UltraGridColumn("OPCINASTANOVANJAPRIREZ");
            UltraGridColumn column76 = new UltraGridColumn("OPCINASTANOVANJAVBDIOPCINA");
            UltraGridColumn column77 = new UltraGridColumn("OPCINASTANOVANJAZRNOPCINA");
            UltraGridColumn column58 = new UltraGridColumn("IDBANKE");
            UltraGridColumn column67 = new UltraGridColumn("NAZIVBANKE1");
            UltraGridColumn column68 = new UltraGridColumn("NAZIVBANKE2");
            UltraGridColumn column69 = new UltraGridColumn("NAZIVBANKE3");
            UltraGridColumn column94 = new UltraGridColumn("VBDIBANKE");
            UltraGridColumn column102 = new UltraGridColumn("ZRNBANKE");
            UltraGridColumn column35 = new UltraGridColumn("DDPDVOBVEZNIK");
            UltraGridColumn column6 = new UltraGridColumn("DDDRUGISTUP");
            UltraGridColumn column37 = new UltraGridColumn("DDSIFRAOPCINESTANOVANJA");
            UltraGridColumn column60 = new UltraGridColumn("IDKOLONAIDD");
            UltraGridColumn column34 = new UltraGridColumn("DDOIB");
            UltraGridColumn column38 = new UltraGridColumn("DDZRN");
            UltraGridBand band7 = new UltraGridBand("DDOBRACUNRadnici_DDOBRACUNRadniciVrstePosla", 1);
            UltraGridColumn column99 = new UltraGridColumn("DDOBRACUNIDOBRACUN");
            UltraGridColumn column95 = new UltraGridColumn("DDIDRADNIK");
            UltraGridColumn column96 = new UltraGridColumn("DDIDVRSTAPOSLA");
            UltraGridColumn column98 = new UltraGridColumn("DDNAZIVVRSTAPOSLA");
            UltraGridColumn column100 = new UltraGridColumn("DDSATI");
            UltraGridColumn column101 = new UltraGridColumn("DDSATNICA");
            UltraGridColumn column97 = new UltraGridColumn("DDIZNOS");
            UltraGridBand band5 = new UltraGridBand("DDOBRACUNRadnici_DDOBRACUNRadniciIzdaci", 1);
            UltraGridColumn column65 = new UltraGridColumn("DDOBRACUNIDOBRACUN");
            UltraGridColumn column62 = new UltraGridColumn("DDIDRADNIK");
            UltraGridColumn column61 = new UltraGridColumn("DDIDIZDATAK");
            UltraGridColumn column63 = new UltraGridColumn("DDNAZIVIZDATKA");
            UltraGridColumn column66 = new UltraGridColumn("DDPOSTOTAKIZDATKA");
            UltraGridColumn column64 = new UltraGridColumn("DDOBRACUNATIIZDATAK");
            UltraGridBand band4 = new UltraGridBand("DDOBRACUNRadnici_DDOBRACUNRadniciDoprinosi", 1);
            UltraGridColumn column41 = new UltraGridColumn("DDOBRACUNIDOBRACUN");
            UltraGridColumn column39 = new UltraGridColumn("DDIDRADNIK");
            UltraGridColumn column43 = new UltraGridColumn("IDDOPRINOS");
            UltraGridColumn column47 = new UltraGridColumn("NAZIVDOPRINOS");
            UltraGridColumn column44 = new UltraGridColumn("IDVRSTADOPRINOS");
            UltraGridColumn column48 = new UltraGridColumn("NAZIVVRSTADOPRINOS");
            UltraGridColumn column45 = new UltraGridColumn("MODOPRINOS");
            UltraGridColumn column50 = new UltraGridColumn("PODOPRINOS");
            UltraGridColumn column46 = new UltraGridColumn("MZDOPRINOS");
            UltraGridColumn column53 = new UltraGridColumn("PZDOPRINOS");
            UltraGridColumn column51 = new UltraGridColumn("PRIMATELJDOPRINOS1");
            UltraGridColumn column52 = new UltraGridColumn("PRIMATELJDOPRINOS2");
            UltraGridColumn column54 = new UltraGridColumn("SIFRAOPISAPLACANJADOPRINOS");
            UltraGridColumn column49 = new UltraGridColumn("OPISPLACANJADOPRINOS");
            UltraGridColumn column56 = new UltraGridColumn("VBDIDOPRINOS");
            UltraGridColumn column57 = new UltraGridColumn("ZRNDOPRINOS");
            UltraGridColumn column55 = new UltraGridColumn("STOPA");
            UltraGridColumn column40 = new UltraGridColumn("DDOBRACUNATIDOPRINOS");
            UltraGridColumn column42 = new UltraGridColumn("DDOSNOVICADOPRINOS");
            UltraGridBand band6 = new UltraGridBand("DDOBRACUNRadnici_DDOBRACUNRadniciPorezi", 1);
            UltraGridColumn column81 = new UltraGridColumn("DDOBRACUNIDOBRACUN");
            UltraGridColumn column78 = new UltraGridColumn("DDIDRADNIK");
            UltraGridColumn column84 = new UltraGridColumn("IDPOREZ");
            UltraGridColumn column86 = new UltraGridColumn("NAZIVPOREZ");
            UltraGridColumn column88 = new UltraGridColumn("POREZMJESECNO");
            UltraGridColumn column93 = new UltraGridColumn("STOPAPOREZA");
            UltraGridColumn column83 = new UltraGridColumn("DDPOPOREZ");
            UltraGridColumn column79 = new UltraGridColumn("DDMOPOREZ");
            UltraGridColumn column85 = new UltraGridColumn("MZPOREZ");
            UltraGridColumn column91 = new UltraGridColumn("PZPOREZ");
            UltraGridColumn column89 = new UltraGridColumn("PRIMATELJPOREZ1");
            UltraGridColumn column90 = new UltraGridColumn("PRIMATELJPOREZ2");
            UltraGridColumn column92 = new UltraGridColumn("SIFRAOPISAPLACANJAPOREZ");
            UltraGridColumn column87 = new UltraGridColumn("OPISPLACANJAPOREZ");
            UltraGridColumn column80 = new UltraGridColumn("DDOBRACUNATIPOREZ");
            UltraGridColumn column82 = new UltraGridColumn("DDOSNOVICAPOREZ");
            UltraGridBand band3 = new UltraGridBand("DDOBRACUNRadnici_DDOBRACUNRadniciDDKrizniPorez", 1);
            UltraGridColumn column10 = new UltraGridColumn("DDOBRACUNIDOBRACUN");
            UltraGridColumn column9 = new UltraGridColumn("DDIDRADNIK");
            UltraGridColumn column17 = new UltraGridColumn("IDKRIZNIPOREZ");
            UltraGridColumn column21 = new UltraGridColumn("NAZIVKRIZNIPOREZ");
            UltraGridColumn column18 = new UltraGridColumn("KRIZNISTOPA");
            UltraGridColumn column19 = new UltraGridColumn("MOKRIZNI");
            UltraGridColumn column23 = new UltraGridColumn("POKRIZNI");
            UltraGridColumn column20 = new UltraGridColumn("MZKRIZNI");
            UltraGridColumn column27 = new UltraGridColumn("PZKRIZNI");
            UltraGridColumn column24 = new UltraGridColumn("PRIMATELJKRIZNI1");
            UltraGridColumn column25 = new UltraGridColumn("PRIMATELJKRIZNI2");
            UltraGridColumn column26 = new UltraGridColumn("PRIMATELJKRIZNI3");
            UltraGridColumn column28 = new UltraGridColumn("SIFRAOPISAPLACANJAKRIZNI");
            UltraGridColumn column22 = new UltraGridColumn("OPISPLACANJAKRIZNI");
            UltraGridColumn column29 = new UltraGridColumn("VBDIKRIZNI");
            UltraGridColumn column30 = new UltraGridColumn("ZRNKRIZNI");
            UltraGridColumn column11 = new UltraGridColumn("DDOSNOVICAKRIZNI");
            UltraGridColumn column14 = new UltraGridColumn("DDPOREZKRIZNI");
            UltraGridColumn column12 = new UltraGridColumn("DDOSNOVICAPRETHODNA");
            UltraGridColumn column13 = new UltraGridColumn("DDOSNOVICAUKUPNA");
            UltraGridColumn column15 = new UltraGridColumn("DDPOREZPRETHODNI");
            UltraGridColumn column16 = new UltraGridColumn("DDPOREZUKUPNO");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.DDOBRACUNDDOBRACUNIDOBRACUNDescription;
            column2.Width = 0x72;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.DDOBRACUNDDOPISOBRACUNDescription;
            column3.Width = 0x128;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.DDOBRACUNDDDATUMOBRACUNADescription;
            column.Width = 0x72;
            column.MinValue = DateTime.MinValue;
            column.MaxValue = DateTime.MaxValue;
            column.Format = "d";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.DDOBRACUNDDZAKLJUCANDescription;
            column5.Width = 0x5d;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.DDOBRACUNDDRSMDescription;
            column4.Width = 0x33;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            column33.CellActivation = Activation.NoEdit;
            column33.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column33.Header.Caption = StringResources.DDOBRACUNDDOBRACUNIDOBRACUNDescription;
            column33.Width = 0x72;
            column33.Format = "";
            column33.CellAppearance = appearance33;
            column33.Hidden = true;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.DDOBRACUNDDIDRADNIKDescription;
            column7.Width = 0x33;
            appearance7.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnnnn";
            column7.PromptChar = ' ';
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            column36.CellActivation = Activation.NoEdit;
            column36.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column36.Header.Caption = StringResources.DDOBRACUNDDPREZIMEDescription;
            column36.Width = 0x128;
            column36.Format = "";
            column36.CellAppearance = appearance36;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.DDOBRACUNDDIMEDescription;
            column8.Width = 0x128;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            column59.CellActivation = Activation.NoEdit;
            column59.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column59.Header.Caption = StringResources.DDOBRACUNIDKATEGORIJADescription;
            column59.Width = 0x63;
            appearance59.TextHAlign = HAlign.Right;
            column59.MaskInput = "{LOC}-nnnnn";
            column59.PromptChar = ' ';
            column59.Format = "";
            column59.CellAppearance = appearance59;
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            column70.CellActivation = Activation.NoEdit;
            column70.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column70.Header.Caption = StringResources.DDOBRACUNNAZIVKATEGORIJADescription;
            column70.Width = 0x128;
            column70.Format = "";
            column70.CellAppearance = appearance70;
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            column32.CellActivation = Activation.NoEdit;
            column32.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column32.Header.Caption = StringResources.DDOBRACUNDDOBRACUNATIPRIREZDescription;
            column32.Width = 0x8f;
            appearance32.TextHAlign = HAlign.Right;
            column32.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column32.PromptChar = ' ';
            column32.Format = "F2";
            column32.CellAppearance = appearance32;
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            column31.CellActivation = Activation.NoEdit;
            column31.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column31.Header.Caption = StringResources.DDOBRACUNDDOBRACUNATIPDVDescription;
            column31.Width = 0x7b;
            appearance31.TextHAlign = HAlign.Right;
            column31.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column31.PromptChar = ' ';
            column31.Format = "F2";
            column31.CellAppearance = appearance31;
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            column71.CellActivation = Activation.NoEdit;
            column71.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column71.Header.Caption = StringResources.DDOBRACUNOPCINARADAIDOPCINEDescription;
            column71.Width = 0x87;
            column71.Format = "";
            column71.CellAppearance = appearance71;
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            column72.CellActivation = Activation.NoEdit;
            column72.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column72.Header.Caption = StringResources.DDOBRACUNOPCINARADANAZIVOPCINEDescription;
            column72.Width = 0x128;
            column72.Format = "";
            column72.CellAppearance = appearance72;
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            column73.CellActivation = Activation.NoEdit;
            column73.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column73.Header.Caption = StringResources.DDOBRACUNOPCINASTANOVANJAIDOPCINEDescription;
            column73.Width = 0xb1;
            column73.Format = "";
            column73.CellAppearance = appearance73;
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            column74.CellActivation = Activation.NoEdit;
            column74.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column74.Header.Caption = StringResources.DDOBRACUNOPCINASTANOVANJANAZIVOPCINEDescription;
            column74.Width = 0x128;
            column74.Format = "";
            column74.CellAppearance = appearance74;
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            column75.CellActivation = Activation.NoEdit;
            column75.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column75.Header.Caption = StringResources.DDOBRACUNOPCINASTANOVANJAPRIREZDescription;
            column75.Width = 0xb7;
            appearance75.TextHAlign = HAlign.Right;
            column75.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column75.PromptChar = ' ';
            column75.Format = "F2";
            column75.CellAppearance = appearance75;
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            column76.CellActivation = Activation.NoEdit;
            column76.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column76.Header.Caption = StringResources.DDOBRACUNOPCINASTANOVANJAVBDIOPCINADescription;
            column76.Width = 0xfe;
            column76.Format = "";
            column76.CellAppearance = appearance76;
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            column77.CellActivation = Activation.NoEdit;
            column77.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column77.Header.Caption = StringResources.DDOBRACUNOPCINASTANOVANJAZRNOPCINADescription;
            column77.Width = 0xfe;
            column77.Format = "";
            column77.CellAppearance = appearance77;
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            column58.CellActivation = Activation.NoEdit;
            column58.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column58.Header.Caption = StringResources.DDOBRACUNIDBANKEDescription;
            column58.Width = 0x5c;
            appearance58.TextHAlign = HAlign.Right;
            column58.MaskInput = "{LOC}-nnnnn";
            column58.PromptChar = ' ';
            column58.Format = "";
            column58.CellAppearance = appearance58;
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            column67.CellActivation = Activation.NoEdit;
            column67.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column67.Header.Caption = StringResources.DDOBRACUNNAZIVBANKE1Description;
            column67.Width = 0x9c;
            column67.Format = "";
            column67.CellAppearance = appearance67;
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            column68.CellActivation = Activation.NoEdit;
            column68.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column68.Header.Caption = StringResources.DDOBRACUNNAZIVBANKE2Description;
            column68.Width = 0x9c;
            column68.Format = "";
            column68.CellAppearance = appearance68;
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            column69.CellActivation = Activation.NoEdit;
            column69.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column69.Header.Caption = StringResources.DDOBRACUNNAZIVBANKE3Description;
            column69.Width = 0x9c;
            column69.Format = "";
            column69.CellAppearance = appearance69;
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            column94.CellActivation = Activation.NoEdit;
            column94.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column94.Header.Caption = StringResources.DDOBRACUNVBDIBANKEDescription;
            column94.Width = 170;
            column94.Format = "";
            column94.CellAppearance = appearance94;
            Infragistics.Win.Appearance appearance102 = new Infragistics.Win.Appearance();
            column102.CellActivation = Activation.NoEdit;
            column102.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column102.Header.Caption = StringResources.DDOBRACUNZRNBANKEDescription;
            column102.Width = 170;
            column102.Format = "";
            column102.CellAppearance = appearance102;
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            column35.CellActivation = Activation.NoEdit;
            column35.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column35.Header.Caption = StringResources.DDOBRACUNDDPDVOBVEZNIKDescription;
            column35.Width = 0x6b;
            column35.Format = "";
            column35.CellAppearance = appearance35;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.DDOBRACUNDDDRUGISTUPDescription;
            column6.Width = 0x5d;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            column37.CellActivation = Activation.NoEdit;
            column37.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column37.Header.Caption = StringResources.DDOBRACUNDDSIFRAOPCINESTANOVANJADescription;
            column37.Width = 0xb1;
            column37.Format = "";
            column37.CellAppearance = appearance37;
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            column60.CellActivation = Activation.NoEdit;
            column60.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column60.Header.Caption = StringResources.DDOBRACUNIDKOLONAIDDDescription;
            column60.Width = 0x8b;
            appearance60.TextHAlign = HAlign.Right;
            column60.MaskInput = "{LOC}-nnnnn";
            column60.PromptChar = ' ';
            column60.Format = "";
            column60.CellAppearance = appearance60;
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            column34.CellActivation = Activation.NoEdit;
            column34.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column34.Header.Caption = StringResources.DDOBRACUNDDOIBDescription;
            column34.Width = 0x5d;
            column34.Format = "";
            column34.CellAppearance = appearance34;
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            column38.CellActivation = Activation.NoEdit;
            column38.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column38.Header.Caption = StringResources.DDOBRACUNDDZRNDescription;
            column38.Width = 0x56;
            column38.Format = "";
            column38.CellAppearance = appearance38;
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            column99.CellActivation = Activation.NoEdit;
            column99.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column99.Header.Caption = StringResources.DDOBRACUNDDOBRACUNIDOBRACUNDescription;
            column99.Width = 0x72;
            column99.Format = "";
            column99.CellAppearance = appearance99;
            column99.Hidden = true;
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            column95.CellActivation = Activation.NoEdit;
            column95.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column95.Header.Caption = StringResources.DDOBRACUNDDIDRADNIKDescription;
            column95.Width = 0x33;
            appearance95.TextHAlign = HAlign.Right;
            column95.MaskInput = "{LOC}-nnnnn";
            column95.PromptChar = ' ';
            column95.Format = "";
            column95.CellAppearance = appearance95;
            column95.Hidden = true;
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            column96.CellActivation = Activation.NoEdit;
            column96.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column96.Header.Caption = StringResources.DDOBRACUNDDIDVRSTAPOSLADescription;
            column96.Width = 0x33;
            appearance96.TextHAlign = HAlign.Right;
            column96.MaskInput = "{LOC}-nnnnn";
            column96.PromptChar = ' ';
            column96.Format = "";
            column96.CellAppearance = appearance96;
            Infragistics.Win.Appearance appearance98 = new Infragistics.Win.Appearance();
            column98.CellActivation = Activation.NoEdit;
            column98.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column98.Header.Caption = StringResources.DDOBRACUNDDNAZIVVRSTAPOSLADescription;
            column98.Width = 0x128;
            column98.Format = "";
            column98.CellAppearance = appearance98;
            Infragistics.Win.Appearance appearance100 = new Infragistics.Win.Appearance();
            column100.CellActivation = Activation.NoEdit;
            column100.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column100.Header.Caption = StringResources.DDOBRACUNDDSATIDescription;
            column100.Width = 0x3e;
            appearance100.TextHAlign = HAlign.Right;
            column100.MaskInput = "{LOC}-nnn.nn";
            column100.PromptChar = ' ';
            column100.Format = "F2";
            column100.CellAppearance = appearance100;
            Infragistics.Win.Appearance appearance101 = new Infragistics.Win.Appearance();
            column101.CellActivation = Activation.NoEdit;
            column101.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column101.Header.Caption = StringResources.DDOBRACUNDDSATNICADescription;
            column101.Width = 0x66;
            appearance101.TextHAlign = HAlign.Right;
            column101.MaskInput = "{LOC}-nnnn.nnnnnnnn";
            column101.PromptChar = ' ';
            column101.Format = "F8";
            column101.CellAppearance = appearance101;
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            column97.CellActivation = Activation.NoEdit;
            column97.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column97.Header.Caption = StringResources.DDOBRACUNDDIZNOSDescription;
            column97.Width = 0x66;
            appearance97.TextHAlign = HAlign.Right;
            column97.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column97.PromptChar = ' ';
            column97.Format = "F2";
            column97.CellAppearance = appearance97;
            band7.Columns.Add(column99);
            column99.Header.VisiblePosition = 0;
            band7.Columns.Add(column95);
            column95.Header.VisiblePosition = 1;
            band7.Columns.Add(column96);
            column96.Header.VisiblePosition = 2;
            band7.Columns.Add(column98);
            column98.Header.VisiblePosition = 3;
            band7.Columns.Add(column100);
            column100.Header.VisiblePosition = 4;
            band7.Columns.Add(column101);
            column101.Header.VisiblePosition = 5;
            band7.Columns.Add(column97);
            column97.Header.VisiblePosition = 6;
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            column65.CellActivation = Activation.NoEdit;
            column65.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column65.Header.Caption = StringResources.DDOBRACUNDDOBRACUNIDOBRACUNDescription;
            column65.Width = 0x72;
            column65.Format = "";
            column65.CellAppearance = appearance65;
            column65.Hidden = true;
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            column62.CellActivation = Activation.NoEdit;
            column62.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column62.Header.Caption = StringResources.DDOBRACUNDDIDRADNIKDescription;
            column62.Width = 0x33;
            appearance62.TextHAlign = HAlign.Right;
            column62.MaskInput = "{LOC}-nnnnn";
            column62.PromptChar = ' ';
            column62.Format = "";
            column62.CellAppearance = appearance62;
            column62.Hidden = true;
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            column61.CellActivation = Activation.NoEdit;
            column61.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column61.Header.Caption = StringResources.DDOBRACUNDDIDIZDATAKDescription;
            column61.Width = 0x5c;
            appearance61.TextHAlign = HAlign.Right;
            column61.MaskInput = "{LOC}-nnnnn";
            column61.PromptChar = ' ';
            column61.Format = "";
            column61.CellAppearance = appearance61;
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            column63.CellActivation = Activation.NoEdit;
            column63.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column63.Header.Caption = StringResources.DDOBRACUNDDNAZIVIZDATKADescription;
            column63.Width = 0x128;
            column63.Format = "";
            column63.CellAppearance = appearance63;
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            column66.CellActivation = Activation.NoEdit;
            column66.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column66.Header.Caption = StringResources.DDOBRACUNDDPOSTOTAKIZDATKADescription;
            column66.Width = 0x88;
            appearance66.TextHAlign = HAlign.Right;
            column66.MaskInput = "{LOC}-nnn.nn";
            column66.PromptChar = ' ';
            column66.Format = "F2";
            column66.CellAppearance = appearance66;
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            column64.CellActivation = Activation.NoEdit;
            column64.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column64.Header.Caption = StringResources.DDOBRACUNDDOBRACUNATIIZDATAKDescription;
            column64.Width = 150;
            appearance64.TextHAlign = HAlign.Right;
            column64.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column64.PromptChar = ' ';
            column64.Format = "F2";
            column64.CellAppearance = appearance64;
            band5.Columns.Add(column65);
            column65.Header.VisiblePosition = 0;
            band5.Columns.Add(column62);
            column62.Header.VisiblePosition = 1;
            band5.Columns.Add(column61);
            column61.Header.VisiblePosition = 2;
            band5.Columns.Add(column63);
            column63.Header.VisiblePosition = 3;
            band5.Columns.Add(column66);
            column66.Header.VisiblePosition = 4;
            band5.Columns.Add(column64);
            column64.Header.VisiblePosition = 5;
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            column41.CellActivation = Activation.NoEdit;
            column41.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column41.Header.Caption = StringResources.DDOBRACUNDDOBRACUNIDOBRACUNDescription;
            column41.Width = 0x72;
            column41.Format = "";
            column41.CellAppearance = appearance41;
            column41.Hidden = true;
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            column39.CellActivation = Activation.NoEdit;
            column39.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column39.Header.Caption = StringResources.DDOBRACUNDDIDRADNIKDescription;
            column39.Width = 0x33;
            appearance39.TextHAlign = HAlign.Right;
            column39.MaskInput = "{LOC}-nnnnn";
            column39.PromptChar = ' ';
            column39.Format = "";
            column39.CellAppearance = appearance39;
            column39.Hidden = true;
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            column43.CellActivation = Activation.NoEdit;
            column43.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column43.Header.Caption = StringResources.DDOBRACUNIDDOPRINOSDescription;
            column43.Width = 0x77;
            appearance43.TextHAlign = HAlign.Right;
            column43.MaskInput = "{LOC}-nnnnnnnn";
            column43.PromptChar = ' ';
            column43.Format = "";
            column43.CellAppearance = appearance43;
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            column47.CellActivation = Activation.NoEdit;
            column47.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column47.Header.Caption = StringResources.DDOBRACUNNAZIVDOPRINOSDescription;
            column47.Width = 0x128;
            column47.Format = "";
            column47.CellAppearance = appearance47;
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            column44.CellActivation = Activation.NoEdit;
            column44.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column44.Header.Caption = StringResources.DDOBRACUNIDVRSTADOPRINOSDescription;
            column44.Width = 0x9f;
            appearance44.TextHAlign = HAlign.Right;
            column44.MaskInput = "{LOC}-nnnnn";
            column44.PromptChar = ' ';
            column44.Format = "";
            column44.CellAppearance = appearance44;
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            column48.CellActivation = Activation.NoEdit;
            column48.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column48.Header.Caption = StringResources.DDOBRACUNNAZIVVRSTADOPRINOSDescription;
            column48.Width = 0x128;
            column48.Format = "";
            column48.CellAppearance = appearance48;
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            column45.CellActivation = Activation.NoEdit;
            column45.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column45.Header.Caption = StringResources.DDOBRACUNMODOPRINOSDescription;
            column45.Width = 0xbf;
            column45.Format = "";
            column45.CellAppearance = appearance45;
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            column50.CellActivation = Activation.NoEdit;
            column50.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column50.Header.Caption = StringResources.DDOBRACUNPODOPRINOSDescription;
            column50.Width = 0xbf;
            column50.Format = "";
            column50.CellAppearance = appearance50;
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            column46.CellActivation = Activation.NoEdit;
            column46.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column46.Header.Caption = StringResources.DDOBRACUNMZDOPRINOSDescription;
            column46.Width = 0xbf;
            column46.Format = "";
            column46.CellAppearance = appearance46;
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            column53.CellActivation = Activation.NoEdit;
            column53.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column53.Header.Caption = StringResources.DDOBRACUNPZDOPRINOSDescription;
            column53.Width = 0xbf;
            column53.Format = "";
            column53.CellAppearance = appearance53;
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            column51.CellActivation = Activation.NoEdit;
            column51.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column51.Header.Caption = StringResources.DDOBRACUNPRIMATELJDOPRINOS1Description;
            column51.Width = 0x9c;
            column51.Format = "";
            column51.CellAppearance = appearance51;
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            column52.CellActivation = Activation.NoEdit;
            column52.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column52.Header.Caption = StringResources.DDOBRACUNPRIMATELJDOPRINOS2Description;
            column52.Width = 0xb1;
            column52.Format = "";
            column52.CellAppearance = appearance52;
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            column54.CellActivation = Activation.NoEdit;
            column54.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column54.Header.Caption = StringResources.DDOBRACUNSIFRAOPISAPLACANJADOPRINOSDescription;
            column54.Width = 0xe2;
            column54.Format = "";
            column54.CellAppearance = appearance54;
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            column49.CellActivation = Activation.NoEdit;
            column49.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column49.Header.Caption = StringResources.DDOBRACUNOPISPLACANJADOPRINOSDescription;
            column49.Width = 0x10c;
            column49.Format = "";
            column49.CellAppearance = appearance49;
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            column56.CellActivation = Activation.NoEdit;
            column56.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column56.Header.Caption = StringResources.DDOBRACUNVBDIDOPRINOSDescription;
            column56.Width = 0x80;
            column56.Format = "";
            column56.CellAppearance = appearance56;
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            column57.CellActivation = Activation.NoEdit;
            column57.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column57.Header.Caption = StringResources.DDOBRACUNZRNDOPRINOSDescription;
            column57.Width = 170;
            column57.Format = "";
            column57.CellAppearance = appearance57;
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            column55.CellActivation = Activation.NoEdit;
            column55.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column55.Header.Caption = StringResources.DDOBRACUNSTOPADescription;
            column55.Width = 0x37;
            appearance55.TextHAlign = HAlign.Right;
            column55.MaskInput = "{LOC}-nnn.nn";
            column55.PromptChar = ' ';
            column55.Format = "F2";
            column55.CellAppearance = appearance55;
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            column40.CellActivation = Activation.NoEdit;
            column40.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column40.Header.Caption = StringResources.DDOBRACUNDDOBRACUNATIDOPRINOSDescription;
            column40.Width = 0x9c;
            appearance40.TextHAlign = HAlign.Right;
            column40.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column40.PromptChar = ' ';
            column40.Format = "F2";
            column40.CellAppearance = appearance40;
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            column42.CellActivation = Activation.NoEdit;
            column42.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column42.Header.Caption = StringResources.DDOBRACUNDDOSNOVICADOPRINOSDescription;
            column42.Width = 0x8f;
            appearance42.TextHAlign = HAlign.Right;
            column42.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column42.PromptChar = ' ';
            column42.Format = "F2";
            column42.CellAppearance = appearance42;
            band4.Columns.Add(column41);
            column41.Header.VisiblePosition = 0;
            band4.Columns.Add(column39);
            column39.Header.VisiblePosition = 1;
            band4.Columns.Add(column43);
            column43.Header.VisiblePosition = 2;
            band4.Columns.Add(column47);
            column47.Header.VisiblePosition = 3;
            band4.Columns.Add(column44);
            column44.Header.VisiblePosition = 4;
            band4.Columns.Add(column48);
            column48.Header.VisiblePosition = 5;
            band4.Columns.Add(column45);
            column45.Header.VisiblePosition = 6;
            band4.Columns.Add(column50);
            column50.Header.VisiblePosition = 7;
            band4.Columns.Add(column46);
            column46.Header.VisiblePosition = 8;
            band4.Columns.Add(column53);
            column53.Header.VisiblePosition = 9;
            band4.Columns.Add(column51);
            column51.Header.VisiblePosition = 10;
            band4.Columns.Add(column52);
            column52.Header.VisiblePosition = 11;
            band4.Columns.Add(column54);
            column54.Header.VisiblePosition = 12;
            band4.Columns.Add(column49);
            column49.Header.VisiblePosition = 13;
            band4.Columns.Add(column56);
            column56.Header.VisiblePosition = 14;
            band4.Columns.Add(column57);
            column57.Header.VisiblePosition = 15;
            band4.Columns.Add(column55);
            column55.Header.VisiblePosition = 0x10;
            band4.Columns.Add(column40);
            column40.Header.VisiblePosition = 0x11;
            band4.Columns.Add(column42);
            column42.Header.VisiblePosition = 0x12;
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            column81.CellActivation = Activation.NoEdit;
            column81.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column81.Header.Caption = StringResources.DDOBRACUNDDOBRACUNIDOBRACUNDescription;
            column81.Width = 0x72;
            column81.Format = "";
            column81.CellAppearance = appearance81;
            column81.Hidden = true;
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            column78.CellActivation = Activation.NoEdit;
            column78.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column78.Header.Caption = StringResources.DDOBRACUNDDIDRADNIKDescription;
            column78.Width = 0x33;
            appearance78.TextHAlign = HAlign.Right;
            column78.MaskInput = "{LOC}-nnnnn";
            column78.PromptChar = ' ';
            column78.Format = "";
            column78.CellAppearance = appearance78;
            column78.Hidden = true;
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            column84.CellActivation = Activation.NoEdit;
            column84.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column84.Header.Caption = StringResources.DDOBRACUNIDPOREZDescription;
            column84.Width = 0x63;
            appearance84.TextHAlign = HAlign.Right;
            column84.MaskInput = "{LOC}-nnnnn";
            column84.PromptChar = ' ';
            column84.Format = "";
            column84.CellAppearance = appearance84;
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            column86.CellActivation = Activation.NoEdit;
            column86.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column86.Header.Caption = StringResources.DDOBRACUNNAZIVPOREZDescription;
            column86.Width = 0x128;
            column86.Format = "";
            column86.CellAppearance = appearance86;
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            column88.CellActivation = Activation.NoEdit;
            column88.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column88.Header.Caption = StringResources.DDOBRACUNPOREZMJESECNODescription;
            column88.Width = 0xd9;
            appearance88.TextHAlign = HAlign.Right;
            column88.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column88.PromptChar = ' ';
            column88.Format = "F2";
            column88.CellAppearance = appearance88;
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            column93.CellActivation = Activation.NoEdit;
            column93.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column93.Header.Caption = StringResources.DDOBRACUNSTOPAPOREZADescription;
            column93.Width = 0x66;
            appearance93.TextHAlign = HAlign.Right;
            column93.MaskInput = "{LOC}-nn.nn";
            column93.PromptChar = ' ';
            column93.Format = "F2";
            column93.CellAppearance = appearance93;
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            column83.CellActivation = Activation.NoEdit;
            column83.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column83.Header.Caption = StringResources.DDOBRACUNDDPOPOREZDescription;
            column83.Width = 170;
            column83.Format = "";
            column83.CellAppearance = appearance83;
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            column79.CellActivation = Activation.NoEdit;
            column79.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column79.Header.Caption = StringResources.DDOBRACUNDDMOPOREZDescription;
            column79.Width = 0x4f;
            column79.Format = "";
            column79.CellAppearance = appearance79;
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            column85.CellActivation = Activation.NoEdit;
            column85.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column85.Header.Caption = StringResources.DDOBRACUNMZPOREZDescription;
            column85.Width = 170;
            column85.Format = "";
            column85.CellAppearance = appearance85;
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            column91.CellActivation = Activation.NoEdit;
            column91.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column91.Header.Caption = StringResources.DDOBRACUNPZPOREZDescription;
            column91.Width = 0xe2;
            column91.Format = "";
            column91.CellAppearance = appearance91;
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            column89.CellActivation = Activation.NoEdit;
            column89.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column89.Header.Caption = StringResources.DDOBRACUNPRIMATELJPOREZ1Description;
            column89.Width = 0x9c;
            column89.Format = "";
            column89.CellAppearance = appearance89;
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            column90.CellActivation = Activation.NoEdit;
            column90.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column90.Header.Caption = StringResources.DDOBRACUNPRIMATELJPOREZ2Description;
            column90.Width = 0x9c;
            column90.Format = "";
            column90.CellAppearance = appearance90;
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            column92.CellActivation = Activation.NoEdit;
            column92.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column92.Header.Caption = StringResources.DDOBRACUNSIFRAOPISAPLACANJAPOREZDescription;
            column92.Width = 0xcd;
            column92.Format = "";
            column92.CellAppearance = appearance92;
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            column87.CellActivation = Activation.NoEdit;
            column87.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column87.Header.Caption = StringResources.DDOBRACUNOPISPLACANJAPOREZDescription;
            column87.Width = 0x10c;
            column87.Format = "";
            column87.CellAppearance = appearance87;
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            column80.CellActivation = Activation.NoEdit;
            column80.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column80.Header.Caption = StringResources.DDOBRACUNDDOBRACUNATIPOREZDescription;
            column80.Width = 0x88;
            appearance80.TextHAlign = HAlign.Right;
            column80.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column80.PromptChar = ' ';
            column80.Format = "F2";
            column80.CellAppearance = appearance80;
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            column82.CellActivation = Activation.NoEdit;
            column82.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column82.Header.Caption = StringResources.DDOBRACUNDDOSNOVICAPOREZDescription;
            column82.Width = 0x7b;
            appearance82.TextHAlign = HAlign.Right;
            column82.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column82.PromptChar = ' ';
            column82.Format = "F2";
            column82.CellAppearance = appearance82;
            band6.Columns.Add(column81);
            column81.Header.VisiblePosition = 0;
            band6.Columns.Add(column78);
            column78.Header.VisiblePosition = 1;
            band6.Columns.Add(column84);
            column84.Header.VisiblePosition = 2;
            band6.Columns.Add(column86);
            column86.Header.VisiblePosition = 3;
            band6.Columns.Add(column88);
            column88.Header.VisiblePosition = 4;
            band6.Columns.Add(column93);
            column93.Header.VisiblePosition = 5;
            band6.Columns.Add(column83);
            column83.Header.VisiblePosition = 6;
            band6.Columns.Add(column79);
            column79.Header.VisiblePosition = 7;
            band6.Columns.Add(column85);
            column85.Header.VisiblePosition = 8;
            band6.Columns.Add(column91);
            column91.Header.VisiblePosition = 9;
            band6.Columns.Add(column89);
            column89.Header.VisiblePosition = 10;
            band6.Columns.Add(column90);
            column90.Header.VisiblePosition = 11;
            band6.Columns.Add(column92);
            column92.Header.VisiblePosition = 12;
            band6.Columns.Add(column87);
            column87.Header.VisiblePosition = 13;
            band6.Columns.Add(column80);
            column80.Header.VisiblePosition = 14;
            band6.Columns.Add(column82);
            column82.Header.VisiblePosition = 15;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.DDOBRACUNDDOBRACUNIDOBRACUNDescription;
            column10.Width = 0x72;
            column10.Format = "";
            column10.CellAppearance = appearance10;
            column10.Hidden = true;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.DDOBRACUNDDIDRADNIKDescription;
            column9.Width = 0x33;
            appearance9.TextHAlign = HAlign.Right;
            column9.MaskInput = "{LOC}-nnnnn";
            column9.PromptChar = ' ';
            column9.Format = "";
            column9.CellAppearance = appearance9;
            column9.Hidden = true;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.NoEdit;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.DDOBRACUNIDKRIZNIPOREZDescription;
            column17.Width = 0x69;
            appearance17.TextHAlign = HAlign.Right;
            column17.MaskInput = "{LOC}-nnnnn";
            column17.PromptChar = ' ';
            column17.Format = "";
            column17.CellAppearance = appearance17;
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            column21.CellActivation = Activation.NoEdit;
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.DDOBRACUNNAZIVKRIZNIPOREZDescription;
            column21.Width = 0x128;
            column21.Format = "";
            column21.CellAppearance = appearance21;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column18.CellActivation = Activation.NoEdit;
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.DDOBRACUNKRIZNISTOPADescription;
            column18.Width = 0x60;
            appearance18.TextHAlign = HAlign.Right;
            column18.MaskInput = "{LOC}-nnn.nn";
            column18.PromptChar = ' ';
            column18.Format = "F2";
            column18.CellAppearance = appearance18;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column19.CellActivation = Activation.NoEdit;
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.DDOBRACUNMOKRIZNIDescription;
            column19.Width = 0x48;
            column19.Format = "";
            column19.CellAppearance = appearance19;
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            column23.CellActivation = Activation.NoEdit;
            column23.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column23.Header.Caption = StringResources.DDOBRACUNPOKRIZNIDescription;
            column23.Width = 170;
            column23.Format = "";
            column23.CellAppearance = appearance23;
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            column20.CellActivation = Activation.NoEdit;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.DDOBRACUNMZKRIZNIDescription;
            column20.Width = 0x48;
            column20.Format = "";
            column20.CellAppearance = appearance20;
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            column27.CellActivation = Activation.NoEdit;
            column27.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column27.Header.Caption = StringResources.DDOBRACUNPZKRIZNIDescription;
            column27.Width = 170;
            column27.Format = "";
            column27.CellAppearance = appearance27;
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            column24.CellActivation = Activation.NoEdit;
            column24.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column24.Header.Caption = StringResources.DDOBRACUNPRIMATELJKRIZNI1Description;
            column24.Width = 0x9c;
            column24.Format = "";
            column24.CellAppearance = appearance24;
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            column25.CellActivation = Activation.NoEdit;
            column25.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column25.Header.Caption = StringResources.DDOBRACUNPRIMATELJKRIZNI2Description;
            column25.Width = 0x9c;
            column25.Format = "";
            column25.CellAppearance = appearance25;
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            column26.CellActivation = Activation.NoEdit;
            column26.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column26.Header.Caption = StringResources.DDOBRACUNPRIMATELJKRIZNI3Description;
            column26.Width = 0x9c;
            column26.Format = "";
            column26.CellAppearance = appearance26;
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            column28.CellActivation = Activation.NoEdit;
            column28.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column28.Header.Caption = StringResources.DDOBRACUNSIFRAOPISAPLACANJAKRIZNIDescription;
            column28.Width = 0xb8;
            column28.Format = "";
            column28.CellAppearance = appearance28;
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            column22.CellActivation = Activation.NoEdit;
            column22.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column22.Header.Caption = StringResources.DDOBRACUNOPISPLACANJAKRIZNIDescription;
            column22.Width = 0x10c;
            column22.Format = "";
            column22.CellAppearance = appearance22;
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            column29.CellActivation = Activation.NoEdit;
            column29.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column29.Header.Caption = StringResources.DDOBRACUNVBDIKRIZNIDescription;
            column29.Width = 0x56;
            column29.Format = "";
            column29.CellAppearance = appearance29;
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            column30.CellActivation = Activation.NoEdit;
            column30.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column30.Header.Caption = StringResources.DDOBRACUNZRNKRIZNIDescription;
            column30.Width = 0x56;
            column30.Format = "";
            column30.CellAppearance = appearance30;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.DDOBRACUNDDOSNOVICAKRIZNIDescription;
            column11.Width = 0x81;
            appearance11.TextHAlign = HAlign.Right;
            column11.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column11.PromptChar = ' ';
            column11.Format = "F2";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.DDOBRACUNDDPOREZKRIZNIDescription;
            column14.Width = 0x6d;
            appearance14.TextHAlign = HAlign.Right;
            column14.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column14.PromptChar = ' ';
            column14.Format = "F2";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.DDOBRACUNDDOSNOVICAPRETHODNADescription;
            column12.Width = 150;
            appearance12.TextHAlign = HAlign.Right;
            column12.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column12.PromptChar = ' ';
            column12.Format = "F2";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.DDOBRACUNDDOSNOVICAUKUPNADescription;
            column13.Width = 0x81;
            appearance13.TextHAlign = HAlign.Right;
            column13.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column13.PromptChar = ' ';
            column13.Format = "F2";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.DDOBRACUNDDPOREZPRETHODNIDescription;
            column15.Width = 0x81;
            appearance15.TextHAlign = HAlign.Right;
            column15.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column15.PromptChar = ' ';
            column15.Format = "F2";
            column15.CellAppearance = appearance15;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.DDOBRACUNDDPOREZUKUPNODescription;
            column16.Width = 0x6d;
            appearance16.TextHAlign = HAlign.Right;
            column16.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column16.PromptChar = ' ';
            column16.Format = "F2";
            column16.CellAppearance = appearance16;
            band3.Columns.Add(column10);
            column10.Header.VisiblePosition = 0;
            band3.Columns.Add(column9);
            column9.Header.VisiblePosition = 1;
            band3.Columns.Add(column17);
            column17.Header.VisiblePosition = 2;
            band3.Columns.Add(column21);
            column21.Header.VisiblePosition = 3;
            band3.Columns.Add(column18);
            column18.Header.VisiblePosition = 4;
            band3.Columns.Add(column19);
            column19.Header.VisiblePosition = 5;
            band3.Columns.Add(column23);
            column23.Header.VisiblePosition = 6;
            band3.Columns.Add(column20);
            column20.Header.VisiblePosition = 7;
            band3.Columns.Add(column27);
            column27.Header.VisiblePosition = 8;
            band3.Columns.Add(column24);
            column24.Header.VisiblePosition = 9;
            band3.Columns.Add(column25);
            column25.Header.VisiblePosition = 10;
            band3.Columns.Add(column26);
            column26.Header.VisiblePosition = 11;
            band3.Columns.Add(column28);
            column28.Header.VisiblePosition = 12;
            band3.Columns.Add(column22);
            column22.Header.VisiblePosition = 13;
            band3.Columns.Add(column29);
            column29.Header.VisiblePosition = 14;
            band3.Columns.Add(column30);
            column30.Header.VisiblePosition = 15;
            band3.Columns.Add(column11);
            column11.Header.VisiblePosition = 0x10;
            band3.Columns.Add(column14);
            column14.Header.VisiblePosition = 0x11;
            band3.Columns.Add(column12);
            column12.Header.VisiblePosition = 0x12;
            band3.Columns.Add(column13);
            column13.Header.VisiblePosition = 0x13;
            band3.Columns.Add(column15);
            column15.Header.VisiblePosition = 20;
            band3.Columns.Add(column16);
            column16.Header.VisiblePosition = 0x15;
            band2.Columns.Add(column33);
            column33.Header.VisiblePosition = 0;
            band2.Columns.Add(column7);
            column7.Header.VisiblePosition = 1;
            band2.Columns.Add(column36);
            column36.Header.VisiblePosition = 2;
            band2.Columns.Add(column8);
            column8.Header.VisiblePosition = 3;
            band2.Columns.Add(column59);
            column59.Header.VisiblePosition = 4;
            band2.Columns.Add(column70);
            column70.Header.VisiblePosition = 5;
            band2.Columns.Add(column32);
            column32.Header.VisiblePosition = 6;
            band2.Columns.Add(column31);
            column31.Header.VisiblePosition = 7;
            band2.Columns.Add(column71);
            column71.Header.VisiblePosition = 8;
            band2.Columns.Add(column72);
            column72.Header.VisiblePosition = 9;
            band2.Columns.Add(column73);
            column73.Header.VisiblePosition = 10;
            band2.Columns.Add(column74);
            column74.Header.VisiblePosition = 11;
            band2.Columns.Add(column75);
            column75.Header.VisiblePosition = 12;
            band2.Columns.Add(column76);
            column76.Header.VisiblePosition = 13;
            band2.Columns.Add(column77);
            column77.Header.VisiblePosition = 14;
            band2.Columns.Add(column58);
            column58.Header.VisiblePosition = 15;
            band2.Columns.Add(column67);
            column67.Header.VisiblePosition = 0x10;
            band2.Columns.Add(column68);
            column68.Header.VisiblePosition = 0x11;
            band2.Columns.Add(column69);
            column69.Header.VisiblePosition = 0x12;
            band2.Columns.Add(column94);
            column94.Header.VisiblePosition = 0x13;
            band2.Columns.Add(column102);
            column102.Header.VisiblePosition = 20;
            band2.Columns.Add(column35);
            column35.Header.VisiblePosition = 0x15;
            band2.Columns.Add(column6);
            column6.Header.VisiblePosition = 0x16;
            band2.Columns.Add(column37);
            column37.Header.VisiblePosition = 0x17;
            band2.Columns.Add(column60);
            column60.Header.VisiblePosition = 0x18;
            band2.Columns.Add(column34);
            column34.Header.VisiblePosition = 0x19;
            band2.Columns.Add(column38);
            column38.Header.VisiblePosition = 0x1a;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 0;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 1;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 2;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 3;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 4;
            this.userControlDataGridDDOBRACUN.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridDDOBRACUN.Location = point;
            this.userControlDataGridDDOBRACUN.Name = "userControlDataGridDDOBRACUN";
            this.userControlDataGridDDOBRACUN.Tag = "DDOBRACUN";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridDDOBRACUN.Size = size;
            this.userControlDataGridDDOBRACUN.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridDDOBRACUN.Dock = DockStyle.Fill;
            this.userControlDataGridDDOBRACUN.FillAtStartup = false;
            this.userControlDataGridDDOBRACUN.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridDDOBRACUN.InitializeRow += new InitializeRowEventHandler(this.DDOBRACUNUserDataGrid_InitializeRow);
            this.userControlDataGridDDOBRACUN.DisplayLayout.BandsSerializer.Add(band);
            this.userControlDataGridDDOBRACUN.DisplayLayout.BandsSerializer.Add(band2);
            this.userControlDataGridDDOBRACUN.DisplayLayout.BandsSerializer.Add(band7);
            this.userControlDataGridDDOBRACUN.DisplayLayout.BandsSerializer.Add(band5);
            this.userControlDataGridDDOBRACUN.DisplayLayout.BandsSerializer.Add(band4);
            this.userControlDataGridDDOBRACUN.DisplayLayout.BandsSerializer.Add(band6);
            this.userControlDataGridDDOBRACUN.DisplayLayout.BandsSerializer.Add(band3);
            this.Controls.AddRange(new Control[] { this.userControlDataGridDDOBRACUN });
            this.Name = "DDOBRACUNUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.DDOBRACUNUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridDDOBRACUN).EndInit();
            this.ResumeLayout(false);
        }

        private void SetComboBoxColumnProperties(bool setColumnsWidth)
        {
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
        public virtual DDOBRACUNDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridDDOBRACUN;
            }
            set
            {
                this.userControlDataGridDDOBRACUN = value;
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

        [DefaultValue("Fill"), TypeConverter(typeof(DeklaritDataGrid.FillMethodsConverter)), Category("Deklarit Work With ")]
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


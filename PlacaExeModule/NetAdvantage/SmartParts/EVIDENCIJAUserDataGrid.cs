namespace NetAdvantage.SmartParts
{
    using Deklarit.Controls;
    using Infragistics.Win;
    using Infragistics.Win.UltraWinGrid;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using NetAdvantage.Controls;
    using Placa;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class EVIDENCIJAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with EVIDENCIJA";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with EVIDENCIJA";
        private EVIDENCIJADataGrid userControlDataGridEVIDENCIJA;

        public EVIDENCIJAUserDataGrid()
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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void EVIDENCIJAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void EVIDENCIJAUserDataGrid_Load(object sender, EventArgs e)
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

        public void Fill()
        {
            this.SetComboBoxColumnProperties(false);
            this.DataGrid.Fill();
        }

        private void InitializeComponent()
        {
            this.userControlDataGridEVIDENCIJA = new EVIDENCIJADataGrid();
            ((ISupportInitialize) this.userControlDataGridEVIDENCIJA).BeginInit();
            UltraGridBand band = new UltraGridBand("EVIDENCIJA", -1);
            UltraGridColumn column3 = new UltraGridColumn("MJESEC");
            UltraGridColumn column2 = new UltraGridColumn("IDGODINE");
            UltraGridColumn column = new UltraGridColumn("BROJEVIDENCIJE");
            UltraGridColumn column4 = new UltraGridColumn("OPISEVIDENCIJE");
            UltraGridBand band2 = new UltraGridBand("EVIDENCIJA_EVIDENCIJARADNICI", 0);
            UltraGridColumn column10 = new UltraGridColumn("MJESEC");
            UltraGridColumn column7 = new UltraGridColumn("IDGODINE");
            UltraGridColumn column6 = new UltraGridColumn("BROJEVIDENCIJE");
            UltraGridColumn column8 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column11 = new UltraGridColumn("PREZIME");
            UltraGridColumn column9 = new UltraGridColumn("IME");
            UltraGridColumn column53 = new UltraGridColumn("TJEDNIFONDSATI");
            UltraGridColumn column5 = new UltraGridColumn("AKTIVAN");
            UltraGridBand band3 = new UltraGridBand("EVIDENCIJARADNICI_EVIDENCIJARADNICISATI", 1);
            UltraGridColumn column26 = new UltraGridColumn("MJESEC");
            UltraGridColumn column22 = new UltraGridColumn("IDGODINE");
            UltraGridColumn column15 = new UltraGridColumn("BROJEVIDENCIJE");
            UltraGridColumn column23 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column16 = new UltraGridColumn("DAN");
            UltraGridColumn column43 = new UltraGridColumn("PRVASMJENAIDSMJENE");
            UltraGridColumn column44 = new UltraGridColumn("PRVASMJENAOPISSMJENE");
            UltraGridColumn column45 = new UltraGridColumn("PRVASMJENAPOCETAK");
            UltraGridColumn column46 = new UltraGridColumn("PRVASMJENAZAVRSETAK");
            UltraGridColumn column17 = new UltraGridColumn("DRUGASMJENAIDSMJENE");
            UltraGridColumn column18 = new UltraGridColumn("DRUGASMJENAOPISSMJENE");
            UltraGridColumn column19 = new UltraGridColumn("DRUGASMJENAPOCETAK");
            UltraGridColumn column20 = new UltraGridColumn("DRUGASMJENAZAVRSETAK");
            UltraGridColumn column48 = new UltraGridColumn("RR");
            UltraGridColumn column37 = new UltraGridColumn("ODTOGASMJENSKI");
            UltraGridColumn column32 = new UltraGridColumn("ODTOGADVOKRATNI");
            UltraGridColumn column34 = new UltraGridColumn("ODTOGAPOSEBNI1");
            UltraGridColumn column35 = new UltraGridColumn("ODTOGAPOSEBNI2");
            UltraGridColumn column36 = new UltraGridColumn("ODTOGAPOSEBNI3");
            UltraGridColumn column33 = new UltraGridColumn("ODTOGAKOMBINACIJA");
            UltraGridColumn column38 = new UltraGridColumn("ODTOGASPECIJALNA");
            UltraGridColumn column24 = new UltraGridColumn("IZNADNORME");
            UltraGridColumn column40 = new UltraGridColumn("PR");
            UltraGridColumn column49 = new UltraGridColumn("SP");
            UltraGridColumn column21 = new UltraGridColumn("GO");
            UltraGridColumn column14 = new UltraGridColumn("BOP");
            UltraGridColumn column13 = new UltraGridColumn("BOF");
            UltraGridColumn column47 = new UltraGridColumn("RD");
            UltraGridColumn column39 = new UltraGridColumn("PD");
            UltraGridColumn column31 = new UltraGridColumn("NPD");
            UltraGridColumn column12 = new UltraGridColumn("BLG");
            UltraGridColumn column52 = new UltraGridColumn("ZAS");
            UltraGridColumn column42 = new UltraGridColumn("PRV");
            UltraGridColumn column51 = new UltraGridColumn("TR");
            UltraGridColumn column41 = new UltraGridColumn("PRI");
            UltraGridColumn column28 = new UltraGridColumn("NEN");
            UltraGridColumn column29 = new UltraGridColumn("NENNEODOBRENA");
            UltraGridColumn column50 = new UltraGridColumn("STR");
            UltraGridColumn column25 = new UltraGridColumn("LOC");
            UltraGridColumn column27 = new UltraGridColumn("NED");
            UltraGridColumn column30 = new UltraGridColumn("NOC");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.EVIDENCIJAMJESECDescription;
            column3.Width = 0x3a;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnn";
            column3.PromptChar = ' ';
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.EVIDENCIJAIDGODINEDescription;
            column2.Width = 0x3a;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.EVIDENCIJABROJEVIDENCIJEDescription;
            column.Width = 0x77;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.EVIDENCIJAOPISEVIDENCIJEDescription;
            column4.Width = 0x128;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.EVIDENCIJAMJESECDescription;
            column10.Width = 0x3a;
            appearance10.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnnnn";
            column10.PromptChar = ' ';
            column10.Format = "";
            column10.CellAppearance = appearance10;
            column10.Hidden = true;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.EVIDENCIJAIDGODINEDescription;
            column7.Width = 0x3a;
            appearance7.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnnn";
            column7.PromptChar = ' ';
            column7.Format = "";
            column7.CellAppearance = appearance7;
            column7.Hidden = true;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.EVIDENCIJABROJEVIDENCIJEDescription;
            column6.Width = 0x77;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnn";
            column6.PromptChar = ' ';
            column6.Format = "";
            column6.CellAppearance = appearance6;
            column6.Hidden = true;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.EVIDENCIJAIDRADNIKDescription;
            column8.Width = 0x69;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.EVIDENCIJAPREZIMEDescription;
            column11.Width = 0x128;
            column11.Format = "";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.EVIDENCIJAIMEDescription;
            column9.Width = 0x128;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            column53.CellActivation = Activation.NoEdit;
            column53.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column53.Header.Caption = StringResources.EVIDENCIJATJEDNIFONDSATIDescription;
            column53.Width = 0xd9;
            appearance53.TextHAlign = HAlign.Right;
            column53.MaskInput = "{LOC}-nnn.nn";
            column53.PromptChar = ' ';
            column53.Format = "F2";
            column53.CellAppearance = appearance53;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.EVIDENCIJAAKTIVANDescription;
            column5.Width = 0x41;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            column26.CellActivation = Activation.NoEdit;
            column26.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column26.Header.Caption = StringResources.EVIDENCIJAMJESECDescription;
            column26.Width = 0x3a;
            appearance26.TextHAlign = HAlign.Right;
            column26.MaskInput = "{LOC}-nnnnn";
            column26.PromptChar = ' ';
            column26.Format = "";
            column26.CellAppearance = appearance26;
            column26.Hidden = true;
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            column22.CellActivation = Activation.NoEdit;
            column22.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column22.Header.Caption = StringResources.EVIDENCIJAIDGODINEDescription;
            column22.Width = 0x3a;
            appearance22.TextHAlign = HAlign.Right;
            column22.MaskInput = "{LOC}-nnnn";
            column22.PromptChar = ' ';
            column22.Format = "";
            column22.CellAppearance = appearance22;
            column22.Hidden = true;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.EVIDENCIJABROJEVIDENCIJEDescription;
            column15.Width = 0x77;
            appearance15.TextHAlign = HAlign.Right;
            column15.MaskInput = "{LOC}-nnnnn";
            column15.PromptChar = ' ';
            column15.Format = "";
            column15.CellAppearance = appearance15;
            column15.Hidden = true;
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            column23.CellActivation = Activation.NoEdit;
            column23.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column23.Header.Caption = StringResources.EVIDENCIJAIDRADNIKDescription;
            column23.Width = 0x69;
            column23.Format = "";
            column23.CellAppearance = appearance23;
            column23.Hidden = true;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.EVIDENCIJADANDescription;
            column16.Width = 0x33;
            appearance16.TextHAlign = HAlign.Right;
            column16.MaskInput = "{LOC}-nnnnn";
            column16.PromptChar = ' ';
            column16.Format = "";
            column16.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            column43.CellActivation = Activation.NoEdit;
            column43.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column43.Header.Caption = StringResources.EVIDENCIJAPRVASMJENAIDSMJENEDescription;
            column43.Width = 0x48;
            appearance42.TextHAlign = HAlign.Right;
            column43.MaskInput = "{LOC}-nnnnn";
            column43.PromptChar = ' ';
            column43.Format = "";
            column43.CellAppearance = appearance42;
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            column44.CellActivation = Activation.NoEdit;
            column44.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column44.Header.Caption = StringResources.EVIDENCIJAPRVASMJENAOPISSMJENEDescription;
            column44.Width = 0x128;
            column44.Format = "";
            column44.CellAppearance = appearance43;
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            column45.CellActivation = Activation.NoEdit;
            column45.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column45.Header.Caption = StringResources.EVIDENCIJAPRVASMJENAPOCETAKDescription;
            column45.Width = 0x41;
            column45.Format = "";
            column45.CellAppearance = appearance44;
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            column46.CellActivation = Activation.NoEdit;
            column46.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column46.Header.Caption = StringResources.EVIDENCIJAPRVASMJENAZAVRSETAKDescription;
            column46.Width = 0x4f;
            column46.Format = "";
            column46.CellAppearance = appearance45;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.NoEdit;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.EVIDENCIJADRUGASMJENAIDSMJENEDescription;
            column17.Width = 0x48;
            appearance17.TextHAlign = HAlign.Right;
            column17.MaskInput = "{LOC}-nnnnn";
            column17.PromptChar = ' ';
            column17.Format = "";
            column17.CellAppearance = appearance17;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column18.CellActivation = Activation.NoEdit;
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.EVIDENCIJADRUGASMJENAOPISSMJENEDescription;
            column18.Width = 0x128;
            column18.Format = "";
            column18.CellAppearance = appearance18;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column19.CellActivation = Activation.NoEdit;
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.EVIDENCIJADRUGASMJENAPOCETAKDescription;
            column19.Width = 0x41;
            column19.Format = "";
            column19.CellAppearance = appearance19;
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            column20.CellActivation = Activation.NoEdit;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.EVIDENCIJADRUGASMJENAZAVRSETAKDescription;
            column20.Width = 0x4f;
            column20.Format = "";
            column20.CellAppearance = appearance20;
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            column48.CellActivation = Activation.NoEdit;
            column48.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column48.Header.Caption = StringResources.EVIDENCIJARRDescription;
            column48.Width = 0x60;
            appearance48.TextHAlign = HAlign.Right;
            column48.MaskInput = "{LOC}-nnn.nn";
            column48.PromptChar = ' ';
            column48.Format = "F2";
            column48.CellAppearance = appearance48;
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            column37.CellActivation = Activation.NoEdit;
            column37.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column37.Header.Caption = StringResources.EVIDENCIJAODTOGASMJENSKIDescription;
            column37.Width = 0x4b;
            appearance37.TextHAlign = HAlign.Right;
            column37.MaskInput = "{LOC}-nnn.nn";
            column37.PromptChar = ' ';
            column37.Format = "F2";
            column37.CellAppearance = appearance37;
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            column32.CellActivation = Activation.NoEdit;
            column32.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column32.Header.Caption = StringResources.EVIDENCIJAODTOGADVOKRATNIDescription;
            column32.Width = 0x52;
            appearance32.TextHAlign = HAlign.Right;
            column32.MaskInput = "{LOC}-nnn.nn";
            column32.PromptChar = ' ';
            column32.Format = "F2";
            column32.CellAppearance = appearance32;
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            column34.CellActivation = Activation.NoEdit;
            column34.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column34.Header.Caption = StringResources.EVIDENCIJAODTOGAPOSEBNI1Description;
            column34.Width = 0x59;
            appearance34.TextHAlign = HAlign.Right;
            column34.MaskInput = "{LOC}-nnn.nn";
            column34.PromptChar = ' ';
            column34.Format = "F2";
            column34.CellAppearance = appearance34;
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            column35.CellActivation = Activation.NoEdit;
            column35.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column35.Header.Caption = StringResources.EVIDENCIJAODTOGAPOSEBNI2Description;
            column35.Width = 0x60;
            appearance35.TextHAlign = HAlign.Right;
            column35.MaskInput = "{LOC}-nnn.nn";
            column35.PromptChar = ' ';
            column35.Format = "F2";
            column35.CellAppearance = appearance35;
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            column36.CellActivation = Activation.NoEdit;
            column36.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column36.Header.Caption = StringResources.EVIDENCIJAODTOGAPOSEBNI3Description;
            column36.Width = 0x60;
            appearance36.TextHAlign = HAlign.Right;
            column36.MaskInput = "{LOC}-nnn.nn";
            column36.PromptChar = ' ';
            column36.Format = "F2";
            column36.CellAppearance = appearance36;
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            column33.CellActivation = Activation.NoEdit;
            column33.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column33.Header.Caption = StringResources.EVIDENCIJAODTOGAKOMBINACIJADescription;
            column33.Width = 0x60;
            appearance33.TextHAlign = HAlign.Right;
            column33.MaskInput = "{LOC}-nnn.nn";
            column33.PromptChar = ' ';
            column33.Format = "F2";
            column33.CellAppearance = appearance33;
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            column38.CellActivation = Activation.NoEdit;
            column38.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column38.Header.Caption = StringResources.EVIDENCIJAODTOGASPECIJALNADescription;
            column38.Width = 0xa3;
            appearance38.TextHAlign = HAlign.Right;
            column38.MaskInput = "{LOC}-nnn.nn";
            column38.PromptChar = ' ';
            column38.Format = "F2";
            column38.CellAppearance = appearance38;
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            column24.CellActivation = Activation.NoEdit;
            column24.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column24.Header.Caption = StringResources.EVIDENCIJAIZNADNORMEDescription;
            column24.Width = 0x7b;
            appearance24.TextHAlign = HAlign.Right;
            column24.MaskInput = "{LOC}-nnn.nn";
            column24.PromptChar = ' ';
            column24.Format = "F2";
            column24.CellAppearance = appearance24;
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            column40.CellActivation = Activation.NoEdit;
            column40.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column40.Header.Caption = StringResources.EVIDENCIJAPRDescription;
            column40.Width = 0x37;
            appearance40.TextHAlign = HAlign.Right;
            column40.MaskInput = "{LOC}-nnn.nn";
            column40.PromptChar = ' ';
            column40.Format = "F2";
            column40.CellAppearance = appearance40;
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            column49.CellActivation = Activation.NoEdit;
            column49.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column49.Header.Caption = StringResources.EVIDENCIJASPDescription;
            column49.Width = 0x37;
            appearance49.TextHAlign = HAlign.Right;
            column49.MaskInput = "{LOC}-nnn.nn";
            column49.PromptChar = ' ';
            column49.Format = "F2";
            column49.CellAppearance = appearance49;
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            column21.CellActivation = Activation.NoEdit;
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.EVIDENCIJAGODescription;
            column21.Width = 0x37;
            appearance21.TextHAlign = HAlign.Right;
            column21.MaskInput = "{LOC}-nnn.nn";
            column21.PromptChar = ' ';
            column21.Format = "F2";
            column21.CellAppearance = appearance21;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.EVIDENCIJABOPDescription;
            column14.Width = 0x37;
            appearance14.TextHAlign = HAlign.Right;
            column14.MaskInput = "{LOC}-nnn.nn";
            column14.PromptChar = ' ';
            column14.Format = "F2";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.EVIDENCIJABOFDescription;
            column13.Width = 0x37;
            appearance13.TextHAlign = HAlign.Right;
            column13.MaskInput = "{LOC}-nnn.nn";
            column13.PromptChar = ' ';
            column13.Format = "F2";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            column47.CellActivation = Activation.NoEdit;
            column47.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column47.Header.Caption = StringResources.EVIDENCIJARDDescription;
            column47.Width = 0x37;
            appearance47.TextHAlign = HAlign.Right;
            column47.MaskInput = "{LOC}-nnn.nn";
            column47.PromptChar = ' ';
            column47.Format = "F2";
            column47.CellAppearance = appearance47;
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            column39.CellActivation = Activation.NoEdit;
            column39.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column39.Header.Caption = StringResources.EVIDENCIJAPDDescription;
            column39.Width = 0x37;
            appearance39.TextHAlign = HAlign.Right;
            column39.MaskInput = "{LOC}-nnn.nn";
            column39.PromptChar = ' ';
            column39.Format = "F2";
            column39.CellAppearance = appearance39;
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            column31.CellActivation = Activation.NoEdit;
            column31.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column31.Header.Caption = StringResources.EVIDENCIJANPDDescription;
            column31.Width = 0x37;
            appearance31.TextHAlign = HAlign.Right;
            column31.MaskInput = "{LOC}-nnn.nn";
            column31.PromptChar = ' ';
            column31.Format = "F2";
            column31.CellAppearance = appearance31;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.EVIDENCIJABLGDescription;
            column12.Width = 0x37;
            appearance12.TextHAlign = HAlign.Right;
            column12.MaskInput = "{LOC}-nnn.nn";
            column12.PromptChar = ' ';
            column12.Format = "F2";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            column52.CellActivation = Activation.NoEdit;
            column52.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column52.Header.Caption = StringResources.EVIDENCIJAZASDescription;
            column52.Width = 0x37;
            appearance52.TextHAlign = HAlign.Right;
            column52.MaskInput = "{LOC}-nnn.nn";
            column52.PromptChar = ' ';
            column52.Format = "F2";
            column52.CellAppearance = appearance52;
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            column42.CellActivation = Activation.NoEdit;
            column42.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column42.Header.Caption = StringResources.EVIDENCIJAPRVDescription;
            column42.Width = 0x37;
            appearance46.TextHAlign = HAlign.Right;
            column42.MaskInput = "{LOC}-nnn.nn";
            column42.PromptChar = ' ';
            column42.Format = "F2";
            column42.CellAppearance = appearance46;
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            column51.CellActivation = Activation.NoEdit;
            column51.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column51.Header.Caption = StringResources.EVIDENCIJATRDescription;
            column51.Width = 0x37;
            appearance51.TextHAlign = HAlign.Right;
            column51.MaskInput = "{LOC}-nnn.nn";
            column51.PromptChar = ' ';
            column51.Format = "F2";
            column51.CellAppearance = appearance51;
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            column41.CellActivation = Activation.NoEdit;
            column41.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column41.Header.Caption = StringResources.EVIDENCIJAPRIDescription;
            column41.Width = 0x37;
            appearance41.TextHAlign = HAlign.Right;
            column41.MaskInput = "{LOC}-nnn.nn";
            column41.PromptChar = ' ';
            column41.Format = "F2";
            column41.CellAppearance = appearance41;
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            column28.CellActivation = Activation.NoEdit;
            column28.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column28.Header.Caption = StringResources.EVIDENCIJANENDescription;
            column28.Width = 0x9c;
            appearance28.TextHAlign = HAlign.Right;
            column28.MaskInput = "{LOC}-nnn.nn";
            column28.PromptChar = ' ';
            column28.Format = "F2";
            column28.CellAppearance = appearance28;
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            column29.CellActivation = Activation.NoEdit;
            column29.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column29.Header.Caption = StringResources.EVIDENCIJANENNEODOBRENADescription;
            column29.Width = 170;
            appearance29.TextHAlign = HAlign.Right;
            column29.MaskInput = "{LOC}-nnn.nn";
            column29.PromptChar = ' ';
            column29.Format = "F2";
            column29.CellAppearance = appearance29;
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            column50.CellActivation = Activation.NoEdit;
            column50.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column50.Header.Caption = StringResources.EVIDENCIJASTRDescription;
            column50.Width = 0x37;
            appearance50.TextHAlign = HAlign.Right;
            column50.MaskInput = "{LOC}-nnn.nn";
            column50.PromptChar = ' ';
            column50.Format = "F2";
            column50.CellAppearance = appearance50;
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            column25.CellActivation = Activation.NoEdit;
            column25.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column25.Header.Caption = StringResources.EVIDENCIJALOCDescription;
            column25.Width = 0x37;
            appearance25.TextHAlign = HAlign.Right;
            column25.MaskInput = "{LOC}-nnn.nn";
            column25.PromptChar = ' ';
            column25.Format = "F2";
            column25.CellAppearance = appearance25;
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            column27.CellActivation = Activation.NoEdit;
            column27.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column27.Header.Caption = StringResources.EVIDENCIJANEDDescription;
            column27.Width = 0x37;
            appearance27.TextHAlign = HAlign.Right;
            column27.MaskInput = "{LOC}-nnn.nn";
            column27.PromptChar = ' ';
            column27.Format = "F2";
            column27.CellAppearance = appearance27;
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            column30.CellActivation = Activation.NoEdit;
            column30.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column30.Header.Caption = StringResources.EVIDENCIJANOCDescription;
            column30.Width = 0x37;
            appearance30.TextHAlign = HAlign.Right;
            column30.MaskInput = "{LOC}-nnn.nn";
            column30.PromptChar = ' ';
            column30.Format = "F2";
            column30.CellAppearance = appearance30;
            band3.Columns.Add(column26);
            column26.Header.VisiblePosition = 0;
            band3.Columns.Add(column22);
            column22.Header.VisiblePosition = 1;
            band3.Columns.Add(column15);
            column15.Header.VisiblePosition = 2;
            band3.Columns.Add(column23);
            column23.Header.VisiblePosition = 3;
            band3.Columns.Add(column16);
            column16.Header.VisiblePosition = 4;
            band3.Columns.Add(column43);
            column43.Header.VisiblePosition = 5;
            band3.Columns.Add(column44);
            column44.Header.VisiblePosition = 6;
            band3.Columns.Add(column45);
            column45.Header.VisiblePosition = 7;
            band3.Columns.Add(column46);
            column46.Header.VisiblePosition = 8;
            band3.Columns.Add(column17);
            column17.Header.VisiblePosition = 9;
            band3.Columns.Add(column18);
            column18.Header.VisiblePosition = 10;
            band3.Columns.Add(column19);
            column19.Header.VisiblePosition = 11;
            band3.Columns.Add(column20);
            column20.Header.VisiblePosition = 12;
            band3.Columns.Add(column48);
            column48.Header.VisiblePosition = 13;
            band3.Columns.Add(column37);
            column37.Header.VisiblePosition = 14;
            band3.Columns.Add(column32);
            column32.Header.VisiblePosition = 15;
            band3.Columns.Add(column34);
            column34.Header.VisiblePosition = 0x10;
            band3.Columns.Add(column35);
            column35.Header.VisiblePosition = 0x11;
            band3.Columns.Add(column36);
            column36.Header.VisiblePosition = 0x12;
            band3.Columns.Add(column33);
            column33.Header.VisiblePosition = 0x13;
            band3.Columns.Add(column38);
            column38.Header.VisiblePosition = 20;
            band3.Columns.Add(column24);
            column24.Header.VisiblePosition = 0x15;
            band3.Columns.Add(column40);
            column40.Header.VisiblePosition = 0x16;
            band3.Columns.Add(column49);
            column49.Header.VisiblePosition = 0x17;
            band3.Columns.Add(column21);
            column21.Header.VisiblePosition = 0x18;
            band3.Columns.Add(column14);
            column14.Header.VisiblePosition = 0x19;
            band3.Columns.Add(column13);
            column13.Header.VisiblePosition = 0x1a;
            band3.Columns.Add(column47);
            column47.Header.VisiblePosition = 0x1b;
            band3.Columns.Add(column39);
            column39.Header.VisiblePosition = 0x1c;
            band3.Columns.Add(column31);
            column31.Header.VisiblePosition = 0x1d;
            band3.Columns.Add(column12);
            column12.Header.VisiblePosition = 30;
            band3.Columns.Add(column52);
            column52.Header.VisiblePosition = 0x1f;
            band3.Columns.Add(column42);
            column42.Header.VisiblePosition = 0x20;
            band3.Columns.Add(column51);
            column51.Header.VisiblePosition = 0x21;
            band3.Columns.Add(column41);
            column41.Header.VisiblePosition = 0x22;
            band3.Columns.Add(column28);
            column28.Header.VisiblePosition = 0x23;
            band3.Columns.Add(column29);
            column29.Header.VisiblePosition = 0x24;
            band3.Columns.Add(column50);
            column50.Header.VisiblePosition = 0x25;
            band3.Columns.Add(column25);
            column25.Header.VisiblePosition = 0x26;
            band3.Columns.Add(column27);
            column27.Header.VisiblePosition = 0x27;
            band3.Columns.Add(column30);
            column30.Header.VisiblePosition = 40;
            band2.Columns.Add(column10);
            column10.Header.VisiblePosition = 0;
            band2.Columns.Add(column7);
            column7.Header.VisiblePosition = 1;
            band2.Columns.Add(column6);
            column6.Header.VisiblePosition = 2;
            band2.Columns.Add(column8);
            column8.Header.VisiblePosition = 3;
            band2.Columns.Add(column11);
            column11.Header.VisiblePosition = 4;
            band2.Columns.Add(column9);
            column9.Header.VisiblePosition = 5;
            band2.Columns.Add(column53);
            column53.Header.VisiblePosition = 6;
            band2.Columns.Add(column5);
            column5.Header.VisiblePosition = 7;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 2;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 3;
            this.userControlDataGridEVIDENCIJA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridEVIDENCIJA.Location = point;
            this.userControlDataGridEVIDENCIJA.Name = "userControlDataGridEVIDENCIJA";
            this.userControlDataGridEVIDENCIJA.Tag = "EVIDENCIJA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridEVIDENCIJA.Size = size;
            this.userControlDataGridEVIDENCIJA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridEVIDENCIJA.Dock = DockStyle.Fill;
            this.userControlDataGridEVIDENCIJA.FillAtStartup = false;
            this.userControlDataGridEVIDENCIJA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridEVIDENCIJA.InitializeRow += new InitializeRowEventHandler(this.EVIDENCIJAUserDataGrid_InitializeRow);
            this.userControlDataGridEVIDENCIJA.DisplayLayout.BandsSerializer.Add(band);
            this.userControlDataGridEVIDENCIJA.DisplayLayout.BandsSerializer.Add(band2);
            this.userControlDataGridEVIDENCIJA.DisplayLayout.BandsSerializer.Add(band3);
            this.Controls.AddRange(new Control[] { this.userControlDataGridEVIDENCIJA });
            this.Name = "EVIDENCIJAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.EVIDENCIJAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridEVIDENCIJA).EndInit();
            this.ResumeLayout(false);
        }

        private void SetComboBoxColumnProperties(bool setColumnsWidth)
        {
            if (DataAdapterFactory.Provider == null)
            {
                DataAdapterFactory.Provider = new SimpleDataAdapterFactory();
            }
            PregledRadnikaComboBox box = new PregledRadnikaComboBox();
            box.Fill();
            System.Data.DataView defaultView = box.DataSet.Tables["RADNIK"].DefaultView;
            defaultView.Sort = "SPOJENOPREZIME";
            CreateValueList(this.DataGrid, "RADNIKIDRADNIK", defaultView, "IDRADNIK", "SPOJENOPREZIME");
            UltraGridColumn column = this.DataGrid.DisplayLayout.Bands["EVIDENCIJA_EVIDENCIJARADNICI"].Columns["IDRADNIK"];
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column.ValueList = this.DataGrid.DisplayLayout.ValueLists["RADNIKIDRADNIK"];
            if (setColumnsWidth)
            {
                column.Width = 370;
            }
            PregledRadnikaComboBox box2 = new PregledRadnikaComboBox();
            box2.Fill();
            System.Data.DataView dataList = box2.DataSet.Tables["RADNIK"].DefaultView;
            dataList.Sort = "SPOJENOPREZIME";
            CreateValueList(this.DataGrid, "RADNIKIDRADNIK", dataList, "IDRADNIK", "SPOJENOPREZIME");
            UltraGridColumn column2 = this.DataGrid.DisplayLayout.Bands["EVIDENCIJARADNICI_EVIDENCIJARADNICISATI"].Columns["IDRADNIK"];
            column2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column2.ValueList = this.DataGrid.DisplayLayout.ValueLists["RADNIKIDRADNIK"];
            if (setColumnsWidth)
            {
                column2.Width = 370;
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
        public virtual EVIDENCIJADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridEVIDENCIJA;
            }
            set
            {
                this.userControlDataGridEVIDENCIJA = value;
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

        [Category("Deklarit Work With "), DefaultValue(true), Description("True= Fill at Startup. False= Not Fill")]
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
        public virtual short FillByIDGODINEIDGODINE
        {
            get
            {
                return this.DataGrid.FillByIDGODINEIDGODINE;
            }
            set
            {
                this.DataGrid.FillByIDGODINEIDGODINE = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual short FillByMJESECIDGODINEIDGODINE
        {
            get
            {
                return this.DataGrid.FillByMJESECIDGODINEIDGODINE;
            }
            set
            {
                this.DataGrid.FillByMJESECIDGODINEIDGODINE = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByMJESECIDGODINEMJESEC
        {
            get
            {
                return this.DataGrid.FillByMJESECIDGODINEMJESEC;
            }
            set
            {
                this.DataGrid.FillByMJESECIDGODINEMJESEC = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByMJESECMJESEC
        {
            get
            {
                return this.DataGrid.FillByMJESECMJESEC;
            }
            set
            {
                this.DataGrid.FillByMJESECMJESEC = value;
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


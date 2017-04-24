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

    public class RACUNUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Izlazni računi";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Izlazni računi";
        private RACUNDataGrid userControlDataGridRACUN;

        public RACUNUserDataGrid()
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

        public void Fill()
        {
            this.SetComboBoxColumnProperties(false);
            this.DataGrid.Fill();
        }

        private void InitializeComponent()
        {
            this.userControlDataGridRACUN = new RACUNDataGrid();
            ((ISupportInitialize) this.userControlDataGridRACUN).BeginInit();
            UltraGridBand band = new UltraGridBand("RACUN", -1);
            UltraGridColumn column4 = new UltraGridColumn("IDRACUN");
            UltraGridColumn column14 = new UltraGridColumn("RACUNGODINAIDGODINE");
            UltraGridColumn column3 = new UltraGridColumn("IDPARTNER");
            UltraGridColumn column8 = new UltraGridColumn("NAZIVPARTNER");
            UltraGridColumn column5 = new UltraGridColumn("MB");
            UltraGridColumn column10 = new UltraGridColumn("PARTNERMJESTO");
            UltraGridColumn column12 = new UltraGridColumn("PARTNERULICA");
            UltraGridColumn column9 = new UltraGridColumn("PARTNEREMAIL");
            UltraGridColumn column2 = new UltraGridColumn("DATUM");
            UltraGridColumn column41 = new UltraGridColumn("VALUTA");
            UltraGridColumn column36 = new UltraGridColumn("RAZDOBLJEOD");
            UltraGridColumn column35 = new UltraGridColumn("RAZDOBLJEDO");
            UltraGridColumn column6 = new UltraGridColumn("MODEL");
            UltraGridColumn column13 = new UltraGridColumn("POZIV");
            UltraGridColumn column37 = new UltraGridColumn("SLOVIMA");
            UltraGridColumn column7 = new UltraGridColumn("NAPOMENA");
            UltraGridColumn column39 = new UltraGridColumn("UKUPNOOSNOVICA");
            UltraGridColumn column40 = new UltraGridColumn("UKUPNOPDV");
            UltraGridColumn column38 = new UltraGridColumn("SVEUKUPNO");
            UltraGridColumn column = new UltraGridColumn("BROJRACUNA");
            UltraGridColumn column11 = new UltraGridColumn("PARTNEROIB");
            UltraGridColumn column42 = new UltraGridColumn("ZAPREDUJAM");
            UltraGridBand band2 = new UltraGridBand("RACUN_RACUNRacunStavke", 0);
            UltraGridColumn column22 = new UltraGridColumn("IDRACUN");
            UltraGridColumn column34 = new UltraGridColumn("RACUNGODINAIDGODINE");
            UltraGridColumn column15 = new UltraGridColumn("BROJSTAVKE");
            UltraGridColumn column21 = new UltraGridColumn("IDPROIZVOD");
            UltraGridColumn column29 = new UltraGridColumn("NAZIVPROIZVOD");
            UltraGridColumn column30 = new UltraGridColumn("NAZIVPROIZVODRACUN");
            UltraGridColumn column16 = new UltraGridColumn("CIJENA");
            UltraGridColumn column17 = new UltraGridColumn("CIJENARACUN");
            UltraGridColumn column33 = new UltraGridColumn("RABAT");
            UltraGridColumn column27 = new UltraGridColumn("KOLICINA");
            UltraGridColumn column19 = new UltraGridColumn("FINPOREZSTOPARACUN");
            UltraGridColumn column18 = new UltraGridColumn("FINPOREZSTOPA");
            UltraGridColumn column26 = new UltraGridColumn("IZNOSRACUN");
            UltraGridColumn column25 = new UltraGridColumn("IZNOSRABATA");
            UltraGridColumn column23 = new UltraGridColumn("IZNOSMINUSRABAT");
            UltraGridColumn column32 = new UltraGridColumn("PDV");
            UltraGridColumn column24 = new UltraGridColumn("IZNOSPLUSPDV");
            UltraGridColumn column20 = new UltraGridColumn("IDJEDINICAMJERE");
            UltraGridColumn column28 = new UltraGridColumn("NAZIVJEDINICAMJERE");
            UltraGridColumn column31 = new UltraGridColumn("OSNOVICAUKNIZIIRA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.RACUNIDRACUNDescription;
            column4.Width = 0x3a;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnnn";
            column4.PromptChar = ' ';
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.RACUNRACUNGODINAIDGODINEDescription;
            column14.Width = 0x48;
            appearance14.TextHAlign = HAlign.Right;
            column14.MaskInput = "{LOC}-nnnn";
            column14.PromptChar = ' ';
            column14.Format = "";
            column14.CellAppearance = appearance14;
            column14.Hidden = true;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.RACUNIDPARTNERDescription;
            column3.Width = 0x69;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.RACUNNAZIVPARTNERDescription;
            column8.Width = 0x128;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.RACUNMBDescription;
            column5.Width = 0x6b;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.RACUNPARTNERMJESTODescription;
            column10.Width = 0x128;
            column10.Format = "";
            column10.CellAppearance = appearance10;
            column10.Hidden = true;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.RACUNPARTNERULICADescription;
            column12.Width = 0x128;
            column12.Format = "";
            column12.CellAppearance = appearance12;
            column12.Hidden = true;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.RACUNPARTNEREMAILDescription;
            column9.Width = 0x128;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            column9.Hidden = true;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.RACUNDATUMDescription;
            column2.Width = 100;
            column2.MinValue = DateTime.MinValue;
            column2.MaxValue = DateTime.MaxValue;
            column2.Format = "d";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            column41.CellActivation = Activation.NoEdit;
            column41.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column41.Header.Caption = StringResources.RACUNVALUTADescription;
            column41.Width = 100;
            column41.MinValue = DateTime.MinValue;
            column41.MaxValue = DateTime.MaxValue;
            column41.Format = "d";
            column41.CellAppearance = appearance41;
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            column36.CellActivation = Activation.NoEdit;
            column36.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column36.Header.Caption = StringResources.RACUNRAZDOBLJEODDescription;
            column36.Width = 100;
            column36.MinValue = DateTime.MinValue;
            column36.MaxValue = DateTime.MaxValue;
            column36.Format = "d";
            column36.CellAppearance = appearance36;
            column36.Hidden = true;
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            column35.CellActivation = Activation.NoEdit;
            column35.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column35.Header.Caption = StringResources.RACUNRAZDOBLJEDODescription;
            column35.Width = 100;
            column35.MinValue = DateTime.MinValue;
            column35.MaxValue = DateTime.MaxValue;
            column35.Format = "d";
            column35.CellAppearance = appearance35;
            column35.Hidden = true;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.RACUNMODELDescription;
            column6.Width = 0x33;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            column6.Hidden = true;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.RACUNPOZIVDescription;
            column13.Width = 0xa3;
            column13.Format = "";
            column13.CellAppearance = appearance13;
            column13.Hidden = true;
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            column37.CellActivation = Activation.NoEdit;
            column37.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column37.Header.Caption = StringResources.RACUNSLOVIMADescription;
            column37.Width = 0x128;
            column37.Format = "";
            column37.CellAppearance = appearance37;
            column37.Hidden = true;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.RACUNNAPOMENADescription;
            column7.Width = 0x128;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            column7.Hidden = true;
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            column39.CellActivation = Activation.NoEdit;
            column39.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column39.Header.Caption = StringResources.RACUNUKUPNOOSNOVICADescription;
            column39.Width = 0x66;
            appearance39.TextHAlign = HAlign.Right;
            column39.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column39.PromptChar = ' ';
            column39.Format = "F2";
            column39.CellAppearance = appearance39;
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            column40.CellActivation = Activation.NoEdit;
            column40.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column40.Header.Caption = StringResources.RACUNUKUPNOPDVDescription;
            column40.Width = 0x66;
            appearance40.TextHAlign = HAlign.Right;
            column40.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column40.PromptChar = ' ';
            column40.Format = "F2";
            column40.CellAppearance = appearance40;
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            column38.CellActivation = Activation.NoEdit;
            column38.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column38.Header.Caption = StringResources.RACUNSVEUKUPNODescription;
            column38.Width = 0x66;
            appearance38.TextHAlign = HAlign.Right;
            column38.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column38.PromptChar = ' ';
            column38.Format = "F2";
            column38.CellAppearance = appearance38;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.RACUNBROJRACUNADescription;
            column.Width = 0x56;
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.RACUNPARTNEROIBDescription;
            column11.Width = 0x5d;
            column11.Format = "";
            column11.CellAppearance = appearance11;
            column11.Hidden = true;
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            column42.CellActivation = Activation.NoEdit;
            column42.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column42.Header.Caption = StringResources.RACUNZAPREDUJAMDescription;
            column42.Width = 0x72;
            column42.Format = "";
            column42.CellAppearance = appearance42;
            column42.Hidden = true;
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            column22.CellActivation = Activation.NoEdit;
            column22.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column22.Header.Caption = StringResources.RACUNIDRACUNDescription;
            column22.Width = 0x3a;
            appearance22.TextHAlign = HAlign.Right;
            column22.MaskInput = "{LOC}-nnnnnn";
            column22.PromptChar = ' ';
            column22.Format = "";
            column22.CellAppearance = appearance22;
            column22.Hidden = true;
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            column34.CellActivation = Activation.NoEdit;
            column34.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column34.Header.Caption = StringResources.RACUNRACUNGODINAIDGODINEDescription;
            column34.Width = 0x48;
            appearance34.TextHAlign = HAlign.Right;
            column34.MaskInput = "{LOC}-nnnn";
            column34.PromptChar = ' ';
            column34.Format = "";
            column34.CellAppearance = appearance34;
            column34.Hidden = true;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.RACUNBROJSTAVKEDescription;
            column15.Width = 0x3a;
            appearance15.TextHAlign = HAlign.Right;
            column15.MaskInput = "{LOC}-nnnnnn";
            column15.PromptChar = ' ';
            column15.Format = "";
            column15.CellAppearance = appearance15;
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            column21.CellActivation = Activation.NoEdit;
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.RACUNIDPROIZVODDescription;
            column21.Width = 0x48;
            column21.Format = "";
            column21.CellAppearance = appearance21;
            column21.Hidden = true;
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            column29.CellActivation = Activation.NoEdit;
            column29.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column29.Header.Caption = StringResources.RACUNNAZIVPROIZVODDescription;
            column29.Width = 0x128;
            column29.Format = "";
            column29.CellAppearance = appearance29;
            column29.Hidden = true;
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            column30.CellActivation = Activation.NoEdit;
            column30.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column30.Header.Caption = StringResources.RACUNNAZIVPROIZVODRACUNDescription;
            column30.Width = 0x128;
            column30.Format = "";
            column30.CellAppearance = appearance30;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.RACUNCIJENADescription;
            column16.Width = 0x52;
            appearance16.TextHAlign = HAlign.Right;
            column16.MaskInput = "{LOC}-nnnnn.nnnn";
            column16.PromptChar = ' ';
            column16.Format = "F4";
            column16.CellAppearance = appearance16;
            column16.Hidden = true;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.NoEdit;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.RACUNCIJENARACUNDescription;
            column17.Width = 0x52;
            appearance17.TextHAlign = HAlign.Right;
            column17.MaskInput = "{LOC}-nnnnn.nnnn";
            column17.PromptChar = ' ';
            column17.Format = "F4";
            column17.CellAppearance = appearance17;
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            column33.CellActivation = Activation.NoEdit;
            column33.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column33.Header.Caption = StringResources.RACUNRABATDescription;
            column33.Width = 0x45;
            appearance33.TextHAlign = HAlign.Right;
            column33.MaskInput = "{LOC}-nnn.nn";
            column33.PromptChar = ' ';
            column33.Format = "F2";
            column33.CellAppearance = appearance33;
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            column27.CellActivation = Activation.NoEdit;
            column27.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column27.Header.Caption = StringResources.RACUNKOLICINADescription;
            column27.Width = 0x66;
            appearance27.TextHAlign = HAlign.Right;
            column27.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column27.PromptChar = ' ';
            column27.Format = "F2";
            column27.CellAppearance = appearance27;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column19.CellActivation = Activation.NoEdit;
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.RACUNFINPOREZSTOPARACUNDescription;
            column19.Width = 0x8f;
            appearance19.TextHAlign = HAlign.Right;
            column19.MaskInput = "{LOC}-nnn.nn";
            column19.PromptChar = ' ';
            column19.Format = "F2";
            column19.CellAppearance = appearance19;
            column19.Hidden = true;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column18.CellActivation = Activation.NoEdit;
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.RACUNFINPOREZSTOPADescription;
            column18.Width = 0x6d;
            appearance18.TextHAlign = HAlign.Right;
            column18.MaskInput = "{LOC}-nnn.nn";
            column18.PromptChar = ' ';
            column18.Format = "F2";
            column18.CellAppearance = appearance18;
            column18.Hidden = true;
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            column26.CellActivation = Activation.NoEdit;
            column26.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column26.Header.Caption = StringResources.RACUNIZNOSRACUNDescription;
            column26.Width = 0x66;
            appearance26.TextHAlign = HAlign.Right;
            column26.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column26.PromptChar = ' ';
            column26.Format = "F2";
            column26.CellAppearance = appearance26;
            column26.Hidden = true;
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            column25.CellActivation = Activation.NoEdit;
            column25.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column25.Header.Caption = StringResources.RACUNIZNOSRABATADescription;
            column25.Width = 0x66;
            appearance25.TextHAlign = HAlign.Right;
            column25.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column25.PromptChar = ' ';
            column25.Format = "F2";
            column25.CellAppearance = appearance25;
            column25.Hidden = true;
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            column23.CellActivation = Activation.NoEdit;
            column23.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column23.Header.Caption = StringResources.RACUNIZNOSMINUSRABATDescription;
            column23.Width = 0x81;
            appearance23.TextHAlign = HAlign.Right;
            column23.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column23.PromptChar = ' ';
            column23.Format = "F2";
            column23.CellAppearance = appearance23;
            column23.Hidden = true;
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            column32.CellActivation = Activation.NoEdit;
            column32.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column32.Header.Caption = StringResources.RACUNPDVDescription;
            column32.Width = 0x66;
            appearance32.TextHAlign = HAlign.Right;
            column32.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column32.PromptChar = ' ';
            column32.Format = "F2";
            column32.CellAppearance = appearance32;
            column32.Hidden = true;
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            column24.CellActivation = Activation.NoEdit;
            column24.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column24.Header.Caption = StringResources.RACUNIZNOSPLUSPDVDescription;
            column24.Width = 0x7b;
            appearance24.TextHAlign = HAlign.Right;
            column24.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column24.PromptChar = ' ';
            column24.Format = "F2";
            column24.CellAppearance = appearance24;
            column24.Hidden = true;
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            column20.CellActivation = Activation.NoEdit;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.RACUNIDJEDINICAMJEREDescription;
            column20.Width = 0x69;
            appearance20.TextHAlign = HAlign.Right;
            column20.MaskInput = "{LOC}-nnnnn";
            column20.PromptChar = ' ';
            column20.Format = "";
            column20.CellAppearance = appearance20;
            column20.Hidden = true;
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            column28.CellActivation = Activation.NoEdit;
            column28.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column28.Header.Caption = StringResources.RACUNNAZIVJEDINICAMJEREDescription;
            column28.Width = 0x128;
            column28.Format = "";
            column28.CellAppearance = appearance28;
            column28.Hidden = true;
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            column31.CellActivation = Activation.NoEdit;
            column31.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column31.Header.Caption = StringResources.RACUNOSNOVICAUKNIZIIRADescription;
            column31.Width = 0x84;
            appearance31.TextHAlign = HAlign.Right;
            column31.MaskInput = "{LOC}-nnnnn";
            column31.PromptChar = ' ';
            column31.Format = "";
            column31.CellAppearance = appearance31;
            column31.Hidden = true;
            band2.Columns.Add(column22);
            column22.Header.VisiblePosition = 0;
            band2.Columns.Add(column15);
            column15.Header.VisiblePosition = 1;
            band2.Columns.Add(column30);
            column30.Header.VisiblePosition = 2;
            band2.Columns.Add(column17);
            column17.Header.VisiblePosition = 3;
            band2.Columns.Add(column33);
            column33.Header.VisiblePosition = 4;
            band2.Columns.Add(column27);
            column27.Header.VisiblePosition = 5;
            band2.Columns.Add(column34);
            column34.Header.VisiblePosition = 6;
            band2.Columns.Add(column21);
            column21.Header.VisiblePosition = 7;
            band2.Columns.Add(column29);
            column29.Header.VisiblePosition = 8;
            band2.Columns.Add(column16);
            column16.Header.VisiblePosition = 9;
            band2.Columns.Add(column19);
            column19.Header.VisiblePosition = 10;
            band2.Columns.Add(column18);
            column18.Header.VisiblePosition = 11;
            band2.Columns.Add(column26);
            column26.Header.VisiblePosition = 12;
            band2.Columns.Add(column25);
            column25.Header.VisiblePosition = 13;
            band2.Columns.Add(column23);
            column23.Header.VisiblePosition = 14;
            band2.Columns.Add(column32);
            column32.Header.VisiblePosition = 15;
            band2.Columns.Add(column24);
            column24.Header.VisiblePosition = 0x10;
            band2.Columns.Add(column20);
            column20.Header.VisiblePosition = 0x11;
            band2.Columns.Add(column28);
            column28.Header.VisiblePosition = 0x12;
            band2.Columns.Add(column31);
            column31.Header.VisiblePosition = 0x13;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 1;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 2;
            band.Columns.Add(column38);
            column38.Header.VisiblePosition = 3;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 4;
            band.Columns.Add(column41);
            column41.Header.VisiblePosition = 5;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 6;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 7;
            band.Columns.Add(column39);
            column39.Header.VisiblePosition = 8;
            band.Columns.Add(column40);
            column40.Header.VisiblePosition = 9;
            band.Columns.Add(column14);
            column14.Header.VisiblePosition = 10;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 11;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 12;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 13;
            band.Columns.Add(column36);
            column36.Header.VisiblePosition = 14;
            band.Columns.Add(column35);
            column35.Header.VisiblePosition = 15;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 0x10;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 0x11;
            band.Columns.Add(column37);
            column37.Header.VisiblePosition = 0x12;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 0x13;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 20;
            band.Columns.Add(column42);
            column42.Header.VisiblePosition = 0x15;
            this.userControlDataGridRACUN.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridRACUN.Location = point;
            this.userControlDataGridRACUN.Name = "userControlDataGridRACUN";
            this.userControlDataGridRACUN.Tag = "RACUN";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridRACUN.Size = size;
            this.userControlDataGridRACUN.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridRACUN.Dock = DockStyle.Fill;
            this.userControlDataGridRACUN.FillAtStartup = false;
            this.userControlDataGridRACUN.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridRACUN.InitializeRow += new InitializeRowEventHandler(this.RACUNUserDataGrid_InitializeRow);
            this.userControlDataGridRACUN.DisplayLayout.BandsSerializer.Add(band);
            this.userControlDataGridRACUN.DisplayLayout.BandsSerializer.Add(band2);
            this.Controls.AddRange(new Control[] { this.userControlDataGridRACUN });
            this.Name = "RACUNUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.RACUNUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridRACUN).EndInit();
            this.ResumeLayout(false);
        }

        private void RACUNUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void RACUNUserDataGrid_Load(object sender, EventArgs e)
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

        private void SetComboBoxColumnProperties(bool setColumnsWidth)
        {
            if (DataAdapterFactory.Provider == null)
            {
                DataAdapterFactory.Provider = new SimpleDataAdapterFactory();
            }
            DataSet dataSet = new PARTNERDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetPARTNERDataAdapter().Fill(dataSet);
            }
            System.Data.DataView dataList = new System.Data.DataView(dataSet.Tables["PARTNER"]) {
                Sort = "PT"
            };
            CreateValueList(this.DataGrid, "PARTNERIDPARTNER", dataList, "IDPARTNER", "PT");
            UltraGridColumn column = this.DataGrid.DisplayLayout.Bands["RACUN"].Columns["IDPARTNER"];
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column.ValueList = this.DataGrid.DisplayLayout.ValueLists["PARTNERIDPARTNER"];
            if (setColumnsWidth)
            {
                column.Width = 370;
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
        public virtual RACUNDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridRACUN;
            }
            set
            {
                this.userControlDataGridRACUN = value;
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

        [Category("Deklarit Work With ")]
        public virtual int FillByIDPARTNERIDPARTNER
        {
            get
            {
                return this.DataGrid.FillByIDPARTNERIDPARTNER;
            }
            set
            {
                this.DataGrid.FillByIDPARTNERIDPARTNER = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByIDRACUNIDRACUN
        {
            get
            {
                return this.DataGrid.FillByIDRACUNIDRACUN;
            }
            set
            {
                this.DataGrid.FillByIDRACUNIDRACUN = value;
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

        [Category("Deklarit Work With ")]
        public virtual short FillByRACUNGODINAIDGODINERACUNGODINAIDGODINE
        {
            get
            {
                return this.DataGrid.FillByRACUNGODINAIDGODINERACUNGODINAIDGODINE;
            }
            set
            {
                this.DataGrid.FillByRACUNGODINAIDGODINERACUNGODINAIDGODINE = value;
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


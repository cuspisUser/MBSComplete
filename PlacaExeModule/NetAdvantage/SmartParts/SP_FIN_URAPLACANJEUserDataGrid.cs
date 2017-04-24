namespace NetAdvantage.SmartParts
{
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

    public class SP_FIN_URAPLACANJEUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with SP_FIN_URAPLACANJE";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with SP_FIN_URAPLACANJE";
        private SP_FIN_URAPLACANJEDataGrid userControlDataGridSP_FIN_URAPLACANJE;

        public SP_FIN_URAPLACANJEUserDataGrid()
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
            this.userControlDataGridSP_FIN_URAPLACANJE = new SP_FIN_URAPLACANJEDataGrid();
            ((ISupportInitialize) this.userControlDataGridSP_FIN_URAPLACANJE).BeginInit();
            UltraGridBand band = new UltraGridBand("SP_FIN_URAPLACANJE", -1);
            UltraGridColumn column32 = new UltraGridColumn("ZATVARANJE_IZNOS");
            UltraGridColumn column31 = new UltraGridColumn("ZATVARANJE_DATUM");
            UltraGridColumn column20 = new UltraGridColumn("URABROJ");
            UltraGridColumn column = new UltraGridColumn("IDTIPURA");
            UltraGridColumn column21 = new UltraGridColumn("URABROJRACUNADOBAVLJACA");
            UltraGridColumn column27 = new UltraGridColumn("urapartnerIDPARTNER");
            UltraGridColumn column26 = new UltraGridColumn("URANAPOMENA");
            UltraGridColumn column30 = new UltraGridColumn("URAVALUTA");
            UltraGridColumn column29 = new UltraGridColumn("URAUKUPNO");
            UltraGridColumn column22 = new UltraGridColumn("URADATUM");
            UltraGridColumn column24 = new UltraGridColumn("URAGODIDGODINE");
            UltraGridColumn column3 = new UltraGridColumn("NAZIVPARTNER");
            UltraGridColumn column2 = new UltraGridColumn("MB");
            UltraGridColumn column23 = new UltraGridColumn("URADOKIDDOKUMENT");
            UltraGridColumn column11 = new UltraGridColumn("PARTNEROIB");
            UltraGridColumn column19 = new UltraGridColumn("Status");
            UltraGridColumn column25 = new UltraGridColumn("URAMODEL");
            UltraGridColumn column28 = new UltraGridColumn("URAPOZIVNABROJ");
            UltraGridColumn column4 = new UltraGridColumn("OSNOVICA0");
            UltraGridColumn column5 = new UltraGridColumn("OSNOVICA10");
            UltraGridColumn column7 = new UltraGridColumn("OSNOVICA22");
            UltraGridColumn column9 = new UltraGridColumn("OSNOVICA23");
            UltraGridColumn column12 = new UltraGridColumn("PDV10DA");
            UltraGridColumn column13 = new UltraGridColumn("PDV10NE");
            UltraGridColumn column14 = new UltraGridColumn("PDV22DA");
            UltraGridColumn column15 = new UltraGridColumn("PDV22NE");
            UltraGridColumn column16 = new UltraGridColumn("PDV23DA");
            UltraGridColumn column17 = new UltraGridColumn("PDV23NE");
            UltraGridColumn column6 = new UltraGridColumn("OSNOVICA10NE");
            UltraGridColumn column10 = new UltraGridColumn("OSNOVICA23NE");
            UltraGridColumn column8 = new UltraGridColumn("OSNOVICA22NE");
            UltraGridColumn column18 = new UltraGridColumn("R2");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            column32.CellActivation = Activation.NoEdit;
            column32.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column32.Header.Caption = StringResources.SP_FIN_URAPLACANJEZATVARANJE_IZNOSDescription;
            column32.Width = 0x88;
            appearance32.TextHAlign = HAlign.Right;
            column32.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column32.PromptChar = ' ';
            column32.Format = "F2";
            column32.CellAppearance = appearance32;
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            column31.CellActivation = Activation.NoEdit;
            column31.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column31.Header.Caption = StringResources.SP_FIN_URAPLACANJEZATVARANJE_DATUMDescription;
            column31.Width = 0x87;
            column31.MinValue = DateTime.MinValue;
            column31.MaxValue = DateTime.MaxValue;
            column31.Format = "d";
            column31.CellAppearance = appearance31;
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            column20.CellActivation = Activation.NoEdit;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.SP_FIN_URAPLACANJEURABROJDescription;
            column20.Width = 0x41;
            appearance20.TextHAlign = HAlign.Right;
            column20.MaskInput = "{LOC}-nnnnn";
            column20.PromptChar = ' ';
            column20.Format = "";
            column20.CellAppearance = appearance20;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.SP_FIN_URAPLACANJEIDTIPURADescription;
            column.Width = 0x48;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            column21.CellActivation = Activation.NoEdit;
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.SP_FIN_URAPLACANJEURABROJRACUNADOBAVLJACADescription;
            column21.Width = 0x128;
            column21.Format = "";
            column21.CellAppearance = appearance21;
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            column27.CellActivation = Activation.NoEdit;
            column27.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column27.Header.Caption = StringResources.SP_FIN_URAPLACANJEurapartnerIDPARTNERDescription;
            column27.Width = 0x4e;
            appearance27.TextHAlign = HAlign.Right;
            column27.MaskInput = "{LOC}-nnnnnnnnn";
            column27.PromptChar = ' ';
            column27.Format = "";
            column27.CellAppearance = appearance27;
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            column26.CellActivation = Activation.NoEdit;
            column26.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column26.Header.Caption = StringResources.SP_FIN_URAPLACANJEURANAPOMENADescription;
            column26.Width = 0x128;
            column26.Format = "";
            column26.CellAppearance = appearance26;
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            column30.CellActivation = Activation.NoEdit;
            column30.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column30.Header.Caption = StringResources.SP_FIN_URAPLACANJEURAVALUTADescription;
            column30.Width = 100;
            column30.MinValue = DateTime.MinValue;
            column30.MaxValue = DateTime.MaxValue;
            column30.Format = "d";
            column30.CellAppearance = appearance30;
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            column29.CellActivation = Activation.NoEdit;
            column29.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column29.Header.Caption = StringResources.SP_FIN_URAPLACANJEURAUKUPNODescription;
            column29.Width = 0x66;
            appearance29.TextHAlign = HAlign.Right;
            column29.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column29.PromptChar = ' ';
            column29.Format = "F2";
            column29.CellAppearance = appearance29;
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            column22.CellActivation = Activation.NoEdit;
            column22.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column22.Header.Caption = StringResources.SP_FIN_URAPLACANJEURADATUMDescription;
            column22.Width = 100;
            column22.MinValue = DateTime.MinValue;
            column22.MaxValue = DateTime.MaxValue;
            column22.Format = "d";
            column22.CellAppearance = appearance22;
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            column24.CellActivation = Activation.NoEdit;
            column24.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column24.Header.Caption = StringResources.SP_FIN_URAPLACANJEURAGODIDGODINEDescription;
            column24.Width = 0x48;
            appearance24.TextHAlign = HAlign.Right;
            column24.MaskInput = "{LOC}-nnnn";
            column24.PromptChar = ' ';
            column24.Format = "";
            column24.CellAppearance = appearance24;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.SP_FIN_URAPLACANJENAZIVPARTNERDescription;
            column3.Width = 0x128;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.SP_FIN_URAPLACANJEMBDescription;
            column2.Width = 0x6b;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            column23.CellActivation = Activation.NoEdit;
            column23.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column23.Header.Caption = StringResources.SP_FIN_URAPLACANJEURADOKIDDOKUMENTDescription;
            column23.Width = 0x55;
            appearance23.TextHAlign = HAlign.Right;
            column23.MaskInput = "{LOC}-nnnnnnnn";
            column23.PromptChar = ' ';
            column23.Format = "";
            column23.CellAppearance = appearance23;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.SP_FIN_URAPLACANJEPARTNEROIBDescription;
            column11.Width = 0x5d;
            column11.Format = "";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column19.CellActivation = Activation.NoEdit;
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.SP_FIN_URAPLACANJEStatusDescription;
            column19.Width = 0x79;
            column19.Format = "";
            column19.CellAppearance = appearance19;
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            column25.CellActivation = Activation.NoEdit;
            column25.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column25.Header.Caption = StringResources.SP_FIN_URAPLACANJEURAMODELDescription;
            column25.Width = 0x48;
            column25.Format = "";
            column25.CellAppearance = appearance25;
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            column28.CellActivation = Activation.NoEdit;
            column28.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column28.Header.Caption = StringResources.SP_FIN_URAPLACANJEURAPOZIVNABROJDescription;
            column28.Width = 170;
            column28.Format = "";
            column28.CellAppearance = appearance28;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.SP_FIN_URAPLACANJEOSNOVICA0Description;
            column4.Width = 0x66;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column4.PromptChar = ' ';
            column4.Format = "F2";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.SP_FIN_URAPLACANJEOSNOVICA10Description;
            column5.Width = 0x66;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column5.PromptChar = ' ';
            column5.Format = "F2";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.SP_FIN_URAPLACANJEOSNOVICA22Description;
            column7.Width = 0x66;
            appearance7.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column7.PromptChar = ' ';
            column7.Format = "F2";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.SP_FIN_URAPLACANJEOSNOVICA23Description;
            column9.Width = 0x66;
            appearance9.TextHAlign = HAlign.Right;
            column9.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column9.PromptChar = ' ';
            column9.Format = "F2";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.SP_FIN_URAPLACANJEPDV10DADescription;
            column12.Width = 0x66;
            appearance12.TextHAlign = HAlign.Right;
            column12.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column12.PromptChar = ' ';
            column12.Format = "F2";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.SP_FIN_URAPLACANJEPDV10NEDescription;
            column13.Width = 0x66;
            appearance13.TextHAlign = HAlign.Right;
            column13.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column13.PromptChar = ' ';
            column13.Format = "F2";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.SP_FIN_URAPLACANJEPDV22DADescription;
            column14.Width = 0x66;
            appearance14.TextHAlign = HAlign.Right;
            column14.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column14.PromptChar = ' ';
            column14.Format = "F2";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.SP_FIN_URAPLACANJEPDV22NEDescription;
            column15.Width = 0x66;
            appearance15.TextHAlign = HAlign.Right;
            column15.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column15.PromptChar = ' ';
            column15.Format = "F2";
            column15.CellAppearance = appearance15;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.SP_FIN_URAPLACANJEPDV23DADescription;
            column16.Width = 0x66;
            appearance16.TextHAlign = HAlign.Right;
            column16.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column16.PromptChar = ' ';
            column16.Format = "F2";
            column16.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.NoEdit;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.SP_FIN_URAPLACANJEPDV23NEDescription;
            column17.Width = 0x66;
            appearance17.TextHAlign = HAlign.Right;
            column17.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column17.PromptChar = ' ';
            column17.Format = "F2";
            column17.CellAppearance = appearance17;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.SP_FIN_URAPLACANJEOSNOVICA10NEDescription;
            column6.Width = 0x74;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column6.PromptChar = ' ';
            column6.Format = "F2";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.SP_FIN_URAPLACANJEOSNOVICA23NEDescription;
            column10.Width = 0x74;
            appearance10.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column10.PromptChar = ' ';
            column10.Format = "F2";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.SP_FIN_URAPLACANJEOSNOVICA22NEDescription;
            column8.Width = 0x74;
            appearance8.TextHAlign = HAlign.Right;
            column8.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column8.PromptChar = ' ';
            column8.Format = "F2";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column18.CellActivation = Activation.NoEdit;
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.SP_FIN_URAPLACANJER2Description;
            column18.Width = 30;
            column18.Format = "";
            column18.CellAppearance = appearance18;
            band.Columns.Add(column32);
            column32.Header.VisiblePosition = 0;
            band.Columns.Add(column31);
            column31.Header.VisiblePosition = 1;
            band.Columns.Add(column20);
            column20.Header.VisiblePosition = 2;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 3;
            band.Columns.Add(column21);
            column21.Header.VisiblePosition = 4;
            band.Columns.Add(column27);
            column27.Header.VisiblePosition = 5;
            band.Columns.Add(column26);
            column26.Header.VisiblePosition = 6;
            band.Columns.Add(column30);
            column30.Header.VisiblePosition = 7;
            band.Columns.Add(column29);
            column29.Header.VisiblePosition = 8;
            band.Columns.Add(column22);
            column22.Header.VisiblePosition = 9;
            band.Columns.Add(column24);
            column24.Header.VisiblePosition = 10;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 11;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 12;
            band.Columns.Add(column23);
            column23.Header.VisiblePosition = 13;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 14;
            band.Columns.Add(column19);
            column19.Header.VisiblePosition = 15;
            band.Columns.Add(column25);
            column25.Header.VisiblePosition = 0x10;
            band.Columns.Add(column28);
            column28.Header.VisiblePosition = 0x11;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 0x12;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 0x13;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 20;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 0x15;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 0x16;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 0x17;
            band.Columns.Add(column14);
            column14.Header.VisiblePosition = 0x18;
            band.Columns.Add(column15);
            column15.Header.VisiblePosition = 0x19;
            band.Columns.Add(column16);
            column16.Header.VisiblePosition = 0x1a;
            band.Columns.Add(column17);
            column17.Header.VisiblePosition = 0x1b;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 0x1c;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 0x1d;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 30;
            band.Columns.Add(column18);
            column18.Header.VisiblePosition = 0x1f;
            this.userControlDataGridSP_FIN_URAPLACANJE.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridSP_FIN_URAPLACANJE.Location = point;
            this.userControlDataGridSP_FIN_URAPLACANJE.Name = "userControlDataGridSP_FIN_URAPLACANJE";
            this.userControlDataGridSP_FIN_URAPLACANJE.Tag = "SP_FIN_URAPLACANJE";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridSP_FIN_URAPLACANJE.Size = size;
            this.userControlDataGridSP_FIN_URAPLACANJE.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridSP_FIN_URAPLACANJE.Dock = DockStyle.Fill;
            this.userControlDataGridSP_FIN_URAPLACANJE.FillAtStartup = false;
            this.userControlDataGridSP_FIN_URAPLACANJE.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridSP_FIN_URAPLACANJE.InitializeRow += new InitializeRowEventHandler(this.SP_FIN_URAPLACANJEUserDataGrid_InitializeRow);
            this.userControlDataGridSP_FIN_URAPLACANJE.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridSP_FIN_URAPLACANJE });
            this.Name = "SP_FIN_URAPLACANJEUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.SP_FIN_URAPLACANJEUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridSP_FIN_URAPLACANJE).EndInit();
            this.ResumeLayout(false);
        }

        private void SetComboBoxColumnProperties(bool setColumnsWidth)
        {
        }

        private void SP_FIN_URAPLACANJEUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void SP_FIN_URAPLACANJEUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual SP_FIN_URAPLACANJEDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridSP_FIN_URAPLACANJE;
            }
            set
            {
                this.userControlDataGridSP_FIN_URAPLACANJE = value;
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

        [Category("Deklarit Work With "), Description("True= Fill at Startup. False= Not Fill"), DefaultValue(true)]
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
        public virtual int ParameterIDDOKUMENT
        {
            get
            {
                return this.DataGrid.ParameterIDDOKUMENT;
            }
            set
            {
                this.DataGrid.ParameterIDDOKUMENT = value;
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


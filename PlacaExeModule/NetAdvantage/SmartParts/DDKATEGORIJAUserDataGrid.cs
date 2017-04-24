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

    public class DDKATEGORIJAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Kategorija drugog dohotka";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Kategorija drugog dohotka";
        private DDKATEGORIJADataGrid userControlDataGridDDKATEGORIJA;

        public DDKATEGORIJAUserDataGrid()
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

        private void DDKATEGORIJAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void DDKATEGORIJAUserDataGrid_Load(object sender, EventArgs e)
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
            this.userControlDataGridDDKATEGORIJA = new DDKATEGORIJADataGrid();
            ((ISupportInitialize) this.userControlDataGridDDKATEGORIJA).BeginInit();
            UltraGridBand band = new UltraGridBand("DDKATEGORIJA", -1);
            UltraGridColumn column = new UltraGridColumn("IDKATEGORIJA");
            UltraGridColumn column37 = new UltraGridColumn("NAZIVKATEGORIJA");
            UltraGridColumn column2 = new UltraGridColumn("IDKOLONAIDD");
            UltraGridColumn column38 = new UltraGridColumn("NAZIVKOLONAIDD");
            UltraGridBand band3 = new UltraGridBand("DDKATEGORIJA_DDKATEGORIJALevel1", 0);
            UltraGridColumn column9 = new UltraGridColumn("IDKATEGORIJA");
            UltraGridColumn column10 = new UltraGridColumn("IDPOREZ");
            UltraGridColumn column12 = new UltraGridColumn("NAZIVPOREZ");
            UltraGridColumn column14 = new UltraGridColumn("POREZMJESECNO");
            UltraGridColumn column19 = new UltraGridColumn("STOPAPOREZA");
            UltraGridColumn column7 = new UltraGridColumn("DDMOPOREZ");
            UltraGridColumn column8 = new UltraGridColumn("DDPOPOREZ");
            UltraGridColumn column11 = new UltraGridColumn("MZPOREZ");
            UltraGridColumn column17 = new UltraGridColumn("PZPOREZ");
            UltraGridColumn column15 = new UltraGridColumn("PRIMATELJPOREZ1");
            UltraGridColumn column16 = new UltraGridColumn("PRIMATELJPOREZ2");
            UltraGridColumn column18 = new UltraGridColumn("SIFRAOPISAPLACANJAPOREZ");
            UltraGridColumn column13 = new UltraGridColumn("OPISPLACANJAPOREZ");
            UltraGridBand band4 = new UltraGridBand("DDKATEGORIJA_DDKATEGORIJALevel3", 0);
            UltraGridColumn column22 = new UltraGridColumn("IDKATEGORIJA");
            UltraGridColumn column21 = new UltraGridColumn("IDDOPRINOS");
            UltraGridColumn column26 = new UltraGridColumn("NAZIVDOPRINOS");
            UltraGridColumn column23 = new UltraGridColumn("IDVRSTADOPRINOS");
            UltraGridColumn column27 = new UltraGridColumn("NAZIVVRSTADOPRINOS");
            UltraGridColumn column24 = new UltraGridColumn("MODOPRINOS");
            UltraGridColumn column29 = new UltraGridColumn("PODOPRINOS");
            UltraGridColumn column25 = new UltraGridColumn("MZDOPRINOS");
            UltraGridColumn column32 = new UltraGridColumn("PZDOPRINOS");
            UltraGridColumn column30 = new UltraGridColumn("PRIMATELJDOPRINOS1");
            UltraGridColumn column31 = new UltraGridColumn("PRIMATELJDOPRINOS2");
            UltraGridColumn column33 = new UltraGridColumn("SIFRAOPISAPLACANJADOPRINOS");
            UltraGridColumn column28 = new UltraGridColumn("OPISPLACANJADOPRINOS");
            UltraGridColumn column35 = new UltraGridColumn("VBDIDOPRINOS");
            UltraGridColumn column36 = new UltraGridColumn("ZRNDOPRINOS");
            UltraGridColumn column34 = new UltraGridColumn("STOPA");
            UltraGridColumn column20 = new UltraGridColumn("DOPRINOSDRUGOGSTUPA");
            UltraGridBand band2 = new UltraGridBand("DDKATEGORIJA_DDKATEGORIJAIzdaci", 0);
            UltraGridColumn column6 = new UltraGridColumn("IDKATEGORIJA");
            UltraGridColumn column3 = new UltraGridColumn("DDIDIZDATAK");
            UltraGridColumn column4 = new UltraGridColumn("DDNAZIVIZDATKA");
            UltraGridColumn column5 = new UltraGridColumn("DDPOSTOTAKIZDATKA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.DDKATEGORIJAIDKATEGORIJADescription;
            column.Width = 0x33;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            column37.CellActivation = Activation.NoEdit;
            column37.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column37.Header.Caption = StringResources.DDKATEGORIJANAZIVKATEGORIJADescription;
            column37.Width = 0x128;
            column37.Format = "";
            column37.CellAppearance = appearance37;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.DDKATEGORIJAIDKOLONAIDDDescription;
            column2.Width = 0x8b;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            column38.CellActivation = Activation.NoEdit;
            column38.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column38.Header.Caption = StringResources.DDKATEGORIJANAZIVKOLONAIDDDescription;
            column38.Width = 0x128;
            column38.Format = "";
            column38.CellAppearance = appearance38;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.DDKATEGORIJAIDKATEGORIJADescription;
            column9.Width = 0x33;
            appearance9.TextHAlign = HAlign.Right;
            column9.MaskInput = "{LOC}-nnnnn";
            column9.PromptChar = ' ';
            column9.Format = "";
            column9.CellAppearance = appearance9;
            column9.Hidden = true;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.DDKATEGORIJAIDPOREZDescription;
            column10.Width = 0x63;
            appearance10.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnnnn";
            column10.PromptChar = ' ';
            column10.Format = "";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.DDKATEGORIJANAZIVPOREZDescription;
            column12.Width = 0x128;
            column12.Format = "";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.DDKATEGORIJAPOREZMJESECNODescription;
            column14.Width = 0xd9;
            appearance14.TextHAlign = HAlign.Right;
            column14.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column14.PromptChar = ' ';
            column14.Format = "F2";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column19.CellActivation = Activation.NoEdit;
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.DDKATEGORIJASTOPAPOREZADescription;
            column19.Width = 0x66;
            appearance19.TextHAlign = HAlign.Right;
            column19.MaskInput = "{LOC}-nn.nn";
            column19.PromptChar = ' ';
            column19.Format = "F2";
            column19.CellAppearance = appearance19;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.DDKATEGORIJADDMOPOREZDescription;
            column7.Width = 0x79;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.DDKATEGORIJADDPOPOREZDescription;
            column8.Width = 0xb1;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.DDKATEGORIJAMZPOREZDescription;
            column11.Width = 170;
            column11.Format = "";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.NoEdit;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.DDKATEGORIJAPZPOREZDescription;
            column17.Width = 0xe2;
            column17.Format = "";
            column17.CellAppearance = appearance17;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.DDKATEGORIJAPRIMATELJPOREZ1Description;
            column15.Width = 0x9c;
            column15.Format = "";
            column15.CellAppearance = appearance15;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.DDKATEGORIJAPRIMATELJPOREZ2Description;
            column16.Width = 0x9c;
            column16.Format = "";
            column16.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column18.CellActivation = Activation.NoEdit;
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.DDKATEGORIJASIFRAOPISAPLACANJAPOREZDescription;
            column18.Width = 0xcd;
            column18.Format = "";
            column18.CellAppearance = appearance18;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.DDKATEGORIJAOPISPLACANJAPOREZDescription;
            column13.Width = 0x10c;
            column13.Format = "";
            column13.CellAppearance = appearance13;
            band3.Columns.Add(column9);
            column9.Header.VisiblePosition = 0;
            band3.Columns.Add(column10);
            column10.Header.VisiblePosition = 1;
            band3.Columns.Add(column12);
            column12.Header.VisiblePosition = 2;
            band3.Columns.Add(column14);
            column14.Header.VisiblePosition = 3;
            band3.Columns.Add(column19);
            column19.Header.VisiblePosition = 4;
            band3.Columns.Add(column7);
            column7.Header.VisiblePosition = 5;
            band3.Columns.Add(column8);
            column8.Header.VisiblePosition = 6;
            band3.Columns.Add(column11);
            column11.Header.VisiblePosition = 7;
            band3.Columns.Add(column17);
            column17.Header.VisiblePosition = 8;
            band3.Columns.Add(column15);
            column15.Header.VisiblePosition = 9;
            band3.Columns.Add(column16);
            column16.Header.VisiblePosition = 10;
            band3.Columns.Add(column18);
            column18.Header.VisiblePosition = 11;
            band3.Columns.Add(column13);
            column13.Header.VisiblePosition = 12;
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            column22.CellActivation = Activation.NoEdit;
            column22.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column22.Header.Caption = StringResources.DDKATEGORIJAIDKATEGORIJADescription;
            column22.Width = 0x33;
            appearance22.TextHAlign = HAlign.Right;
            column22.MaskInput = "{LOC}-nnnnn";
            column22.PromptChar = ' ';
            column22.Format = "";
            column22.CellAppearance = appearance22;
            column22.Hidden = true;
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            column21.CellActivation = Activation.NoEdit;
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.DDKATEGORIJAIDDOPRINOSDescription;
            column21.Width = 0x77;
            appearance21.TextHAlign = HAlign.Right;
            column21.MaskInput = "{LOC}-nnnnnnnn";
            column21.PromptChar = ' ';
            column21.Format = "";
            column21.CellAppearance = appearance21;
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            column26.CellActivation = Activation.NoEdit;
            column26.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column26.Header.Caption = StringResources.DDKATEGORIJANAZIVDOPRINOSDescription;
            column26.Width = 0x128;
            column26.Format = "";
            column26.CellAppearance = appearance26;
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            column23.CellActivation = Activation.NoEdit;
            column23.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column23.Header.Caption = StringResources.DDKATEGORIJAIDVRSTADOPRINOSDescription;
            column23.Width = 0x9f;
            appearance23.TextHAlign = HAlign.Right;
            column23.MaskInput = "{LOC}-nnnnn";
            column23.PromptChar = ' ';
            column23.Format = "";
            column23.CellAppearance = appearance23;
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            column27.CellActivation = Activation.NoEdit;
            column27.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column27.Header.Caption = StringResources.DDKATEGORIJANAZIVVRSTADOPRINOSDescription;
            column27.Width = 0x128;
            column27.Format = "";
            column27.CellAppearance = appearance27;
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            column24.CellActivation = Activation.NoEdit;
            column24.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column24.Header.Caption = StringResources.DDKATEGORIJAMODOPRINOSDescription;
            column24.Width = 0xbf;
            column24.Format = "";
            column24.CellAppearance = appearance24;
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            column29.CellActivation = Activation.NoEdit;
            column29.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column29.Header.Caption = StringResources.DDKATEGORIJAPODOPRINOSDescription;
            column29.Width = 0xbf;
            column29.Format = "";
            column29.CellAppearance = appearance29;
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            column25.CellActivation = Activation.NoEdit;
            column25.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column25.Header.Caption = StringResources.DDKATEGORIJAMZDOPRINOSDescription;
            column25.Width = 0xbf;
            column25.Format = "";
            column25.CellAppearance = appearance25;
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            column32.CellActivation = Activation.NoEdit;
            column32.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column32.Header.Caption = StringResources.DDKATEGORIJAPZDOPRINOSDescription;
            column32.Width = 0xbf;
            column32.Format = "";
            column32.CellAppearance = appearance32;
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            column30.CellActivation = Activation.NoEdit;
            column30.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column30.Header.Caption = StringResources.DDKATEGORIJAPRIMATELJDOPRINOS1Description;
            column30.Width = 0x9c;
            column30.Format = "";
            column30.CellAppearance = appearance30;
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            column31.CellActivation = Activation.NoEdit;
            column31.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column31.Header.Caption = StringResources.DDKATEGORIJAPRIMATELJDOPRINOS2Description;
            column31.Width = 0xb1;
            column31.Format = "";
            column31.CellAppearance = appearance31;
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            column33.CellActivation = Activation.NoEdit;
            column33.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column33.Header.Caption = StringResources.DDKATEGORIJASIFRAOPISAPLACANJADOPRINOSDescription;
            column33.Width = 0xe2;
            column33.Format = "";
            column33.CellAppearance = appearance33;
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            column28.CellActivation = Activation.NoEdit;
            column28.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column28.Header.Caption = StringResources.DDKATEGORIJAOPISPLACANJADOPRINOSDescription;
            column28.Width = 0x10c;
            column28.Format = "";
            column28.CellAppearance = appearance28;
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            column35.CellActivation = Activation.NoEdit;
            column35.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column35.Header.Caption = StringResources.DDKATEGORIJAVBDIDOPRINOSDescription;
            column35.Width = 0x80;
            column35.Format = "";
            column35.CellAppearance = appearance35;
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            column36.CellActivation = Activation.NoEdit;
            column36.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column36.Header.Caption = StringResources.DDKATEGORIJAZRNDOPRINOSDescription;
            column36.Width = 170;
            column36.Format = "";
            column36.CellAppearance = appearance36;
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            column34.CellActivation = Activation.NoEdit;
            column34.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column34.Header.Caption = StringResources.DDKATEGORIJASTOPADescription;
            column34.Width = 0x37;
            appearance34.TextHAlign = HAlign.Right;
            column34.MaskInput = "{LOC}-nnn.nn";
            column34.PromptChar = ' ';
            column34.Format = "F2";
            column34.CellAppearance = appearance34;
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            column20.CellActivation = Activation.NoEdit;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.DDKATEGORIJADOPRINOSDRUGOGSTUPADescription;
            column20.Width = 0xcd;
            column20.Format = "";
            column20.CellAppearance = appearance20;
            band4.Columns.Add(column22);
            column22.Header.VisiblePosition = 0;
            band4.Columns.Add(column21);
            column21.Header.VisiblePosition = 1;
            band4.Columns.Add(column26);
            column26.Header.VisiblePosition = 2;
            band4.Columns.Add(column23);
            column23.Header.VisiblePosition = 3;
            band4.Columns.Add(column27);
            column27.Header.VisiblePosition = 4;
            band4.Columns.Add(column24);
            column24.Header.VisiblePosition = 5;
            band4.Columns.Add(column29);
            column29.Header.VisiblePosition = 6;
            band4.Columns.Add(column25);
            column25.Header.VisiblePosition = 7;
            band4.Columns.Add(column32);
            column32.Header.VisiblePosition = 8;
            band4.Columns.Add(column30);
            column30.Header.VisiblePosition = 9;
            band4.Columns.Add(column31);
            column31.Header.VisiblePosition = 10;
            band4.Columns.Add(column33);
            column33.Header.VisiblePosition = 11;
            band4.Columns.Add(column28);
            column28.Header.VisiblePosition = 12;
            band4.Columns.Add(column35);
            column35.Header.VisiblePosition = 13;
            band4.Columns.Add(column36);
            column36.Header.VisiblePosition = 14;
            band4.Columns.Add(column34);
            column34.Header.VisiblePosition = 15;
            band4.Columns.Add(column20);
            column20.Header.VisiblePosition = 0x10;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.DDKATEGORIJAIDKATEGORIJADescription;
            column6.Width = 0x33;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnn";
            column6.PromptChar = ' ';
            column6.Format = "";
            column6.CellAppearance = appearance6;
            column6.Hidden = true;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.DDKATEGORIJADDIDIZDATAKDescription;
            column3.Width = 0x33;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnn";
            column3.PromptChar = ' ';
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.DDKATEGORIJADDNAZIVIZDATKADescription;
            column4.Width = 0x128;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.DDKATEGORIJADDPOSTOTAKIZDATKADescription;
            column5.Width = 0x81;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnn.nn";
            column5.PromptChar = ' ';
            column5.Format = "F2";
            column5.CellAppearance = appearance5;
            band2.Columns.Add(column6);
            column6.Header.VisiblePosition = 0;
            band2.Columns.Add(column3);
            column3.Header.VisiblePosition = 1;
            band2.Columns.Add(column4);
            column4.Header.VisiblePosition = 2;
            band2.Columns.Add(column5);
            column5.Header.VisiblePosition = 3;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column37);
            column37.Header.VisiblePosition = 1;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 2;
            band.Columns.Add(column38);
            column38.Header.VisiblePosition = 3;
            this.userControlDataGridDDKATEGORIJA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridDDKATEGORIJA.Location = point;
            this.userControlDataGridDDKATEGORIJA.Name = "userControlDataGridDDKATEGORIJA";
            this.userControlDataGridDDKATEGORIJA.Tag = "DDKATEGORIJA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridDDKATEGORIJA.Size = size;
            this.userControlDataGridDDKATEGORIJA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridDDKATEGORIJA.Dock = DockStyle.Fill;
            this.userControlDataGridDDKATEGORIJA.FillAtStartup = false;
            this.userControlDataGridDDKATEGORIJA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridDDKATEGORIJA.InitializeRow += new InitializeRowEventHandler(this.DDKATEGORIJAUserDataGrid_InitializeRow);
            this.userControlDataGridDDKATEGORIJA.DisplayLayout.BandsSerializer.Add(band);
            this.userControlDataGridDDKATEGORIJA.DisplayLayout.BandsSerializer.Add(band3);
            this.userControlDataGridDDKATEGORIJA.DisplayLayout.BandsSerializer.Add(band4);
            this.userControlDataGridDDKATEGORIJA.DisplayLayout.BandsSerializer.Add(band2);
            this.Controls.AddRange(new Control[] { this.userControlDataGridDDKATEGORIJA });
            this.Name = "DDKATEGORIJAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.DDKATEGORIJAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridDDKATEGORIJA).EndInit();
            this.ResumeLayout(false);
        }

        private void SetComboBoxColumnProperties(bool setColumnsWidth)
        {
            if (DataAdapterFactory.Provider == null)
            {
                DataAdapterFactory.Provider = new SimpleDataAdapterFactory();
            }
            DataSet dataSet = new DDKOLONAIDDDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetDDKOLONAIDDDataAdapter().Fill(dataSet);
            }
            System.Data.DataView dataList = new System.Data.DataView(dataSet.Tables["DDKOLONAIDD"]) {
                Sort = "NAZIVKOLONAIDD"
            };
            CreateValueList(this.DataGrid, "DDKOLONAIDDIDKOLONAIDD", dataList, "IDKOLONAIDD", "NAZIVKOLONAIDD");
            UltraGridColumn column = this.DataGrid.DisplayLayout.Bands["DDKATEGORIJA"].Columns["IDKOLONAIDD"];
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column.ValueList = this.DataGrid.DisplayLayout.ValueLists["DDKOLONAIDDIDKOLONAIDD"];
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
        public virtual DDKATEGORIJADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridDDKATEGORIJA;
            }
            set
            {
                this.userControlDataGridDDKATEGORIJA = value;
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

        [Category("Deklarit Work With ")]
        public virtual int FillByIDKOLONAIDDIDKOLONAIDD
        {
            get
            {
                return this.DataGrid.FillByIDKOLONAIDDIDKOLONAIDD;
            }
            set
            {
                this.DataGrid.FillByIDKOLONAIDDIDKOLONAIDD = value;
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


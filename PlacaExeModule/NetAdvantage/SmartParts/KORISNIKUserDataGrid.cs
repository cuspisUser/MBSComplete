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

    public class KORISNIKUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Korisnik aplikacije";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Korisnik aplikacije";
        private KORISNIKDataGrid userControlDataGridKORISNIK;

        public KORISNIKUserDataGrid()
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
            this.userControlDataGridKORISNIK = new KORISNIKDataGrid();
            ((ISupportInitialize) this.userControlDataGridKORISNIK).BeginInit();
            UltraGridBand band = new UltraGridBand("KORISNIK", -1);
            UltraGridColumn column6 = new UltraGridColumn("IDKORISNIK");
            UltraGridColumn column14 = new UltraGridColumn("KORISNIK1NAZIV");
            UltraGridColumn column11 = new UltraGridColumn("KORISNIK1ADRESA");
            UltraGridColumn column13 = new UltraGridColumn("KORISNIK1MJESTO");
            UltraGridColumn column16 = new UltraGridColumn("KORISNIKOIB");
            UltraGridColumn column28 = new UltraGridColumn("MBKORISNIK");
            UltraGridColumn column29 = new UltraGridColumn("MBKORISNIKJEDINICA");
            UltraGridColumn column7 = new UltraGridColumn("JMBGKORISNIK");
            UltraGridColumn column9 = new UltraGridColumn("KONTAKTOSOBA");
            UltraGridColumn column10 = new UltraGridColumn("KONTAKTTELEFON");
            UltraGridColumn column8 = new UltraGridColumn("KONTAKTFAX");
            UltraGridColumn column4 = new UltraGridColumn("EMAIL");
            UltraGridColumn column30 = new UltraGridColumn("NADLEZNAPU");
            UltraGridColumn column3 = new UltraGridColumn("BROJCANAOZNAKAPU");
            UltraGridColumn column36 = new UltraGridColumn("STAZUKOEFICIJENTU");
            UltraGridColumn column34 = new UltraGridColumn("RKP");
            UltraGridColumn column33 = new UltraGridColumn("PREZIMEIMEOVLASTENEOSOBE");
            UltraGridColumn column = new UltraGridColumn("ADRESAOVLASTENEOSOBE");
            UltraGridColumn column32 = new UltraGridColumn("OIBOVLASTENEOSOBE");
            UltraGridColumn column2 = new UltraGridColumn("ANALITIKA");
            UltraGridColumn column12 = new UltraGridColumn("KORISNIK1HZZO");
            UltraGridColumn column15 = new UltraGridColumn("KORISNIK1NAZIVZANALJEPNICE");
            UltraGridColumn column5 = new UltraGridColumn("EMAILPOSILJAOCA");
            UltraGridColumn column31 = new UltraGridColumn("NAZIVPOSILJAOCA");
            UltraGridColumn column35 = new UltraGridColumn("SMTPSERVER");
            UltraGridBand band2 = new UltraGridBand("KORISNIK_KORISNIKLevel1", 0);
            UltraGridColumn column17 = new UltraGridColumn("IDKORISNIK");
            UltraGridColumn column18 = new UltraGridColumn("IDZIRO");
            UltraGridColumn column21 = new UltraGridColumn("NAZIVZIRO");
            UltraGridColumn column25 = new UltraGridColumn("ULICAZIRO");
            UltraGridColumn column19 = new UltraGridColumn("MJESTOZIRO");
            UltraGridColumn column26 = new UltraGridColumn("VBDIKORISNIK");
            UltraGridColumn column27 = new UltraGridColumn("ZIROKORISNIK");
            UltraGridColumn column24 = new UltraGridColumn("SIFRAIZVORA");
            UltraGridColumn column20 = new UltraGridColumn("NAZIVIZVORA");
            UltraGridColumn column22 = new UltraGridColumn("POREZIPRIREZZAJEDNICKI");
            UltraGridColumn column23 = new UltraGridColumn("POZIVIZADUZENJA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.KORISNIKIDKORISNIKDescription;
            column6.Width = 0x77;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnn";
            column6.PromptChar = ' ';
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.KORISNIKKORISNIK1NAZIVDescription;
            column14.Width = 0x128;
            column14.Format = "";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.KORISNIKKORISNIK1ADRESADescription;
            column11.Width = 0x128;
            column11.Format = "";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.KORISNIKKORISNIK1MJESTODescription;
            column13.Width = 0x128;
            column13.Format = "";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.KORISNIKKORISNIKOIBDescription;
            column16.Width = 0xd4;
            column16.Format = "";
            column16.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            column28.CellActivation = Activation.NoEdit;
            column28.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column28.Header.Caption = StringResources.KORISNIKMBKORISNIKDescription;
            column28.Width = 170;
            column28.Format = "";
            column28.CellAppearance = appearance28;
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            column29.CellActivation = Activation.NoEdit;
            column29.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column29.Header.Caption = StringResources.KORISNIKMBKORISNIKJEDINICADescription;
            column29.Width = 0x8e;
            column29.Format = "";
            column29.CellAppearance = appearance29;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.KORISNIKJMBGKORISNIKDescription;
            column7.Width = 0x72;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.KORISNIKKONTAKTOSOBADescription;
            column9.Width = 0x128;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.KORISNIKKONTAKTTELEFONDescription;
            column10.Width = 0xe2;
            column10.Format = "";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.KORISNIKKONTAKTFAXDescription;
            column8.Width = 0xe2;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.KORISNIKEMAILDescription;
            column4.Width = 0x128;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            column30.CellActivation = Activation.NoEdit;
            column30.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column30.Header.Caption = StringResources.KORISNIKNADLEZNAPUDescription;
            column30.Width = 0x128;
            column30.Format = "";
            column30.CellAppearance = appearance30;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.KORISNIKBROJCANAOZNAKAPUDescription;
            column3.Width = 0x120;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnn";
            column3.PromptChar = ' ';
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            column36.CellActivation = Activation.NoEdit;
            column36.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column36.Header.Caption = StringResources.KORISNIKSTAZUKOEFICIJENTUDescription;
            column36.Width = 0xcd;
            column36.Format = "";
            column36.CellAppearance = appearance36;
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            column34.CellActivation = Activation.NoEdit;
            column34.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column34.Header.Caption = StringResources.KORISNIKRKPDescription;
            column34.Width = 0xd5;
            appearance34.TextHAlign = HAlign.Right;
            column34.MaskInput = "{LOC}-nnnnn";
            column34.PromptChar = ' ';
            column34.Format = "";
            column34.CellAppearance = appearance34;
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            column33.CellActivation = Activation.NoEdit;
            column33.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column33.Header.Caption = StringResources.KORISNIKPREZIMEIMEOVLASTENEOSOBEDescription;
            column33.Width = 0x128;
            column33.Format = "";
            column33.CellAppearance = appearance33;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.KORISNIKADRESAOVLASTENEOSOBEDescription;
            column.Width = 0x128;
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            column32.CellActivation = Activation.NoEdit;
            column32.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column32.Header.Caption = StringResources.KORISNIKOIBOVLASTENEOSOBEDescription;
            column32.Width = 0x95;
            column32.Format = "";
            column32.CellAppearance = appearance32;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.KORISNIKANALITIKADescription;
            column2.Width = 200;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.KORISNIKKORISNIK1HZZODescription;
            column12.Width = 0xb8;
            column12.Format = "";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.KORISNIKKORISNIK1NAZIVZANALJEPNICEDescription;
            column15.Width = 0x11a;
            column15.Format = "";
            column15.CellAppearance = appearance15;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.KORISNIKEMAILPOSILJAOCADescription;
            column5.Width = 0x128;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            column31.CellActivation = Activation.NoEdit;
            column31.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column31.Header.Caption = StringResources.KORISNIKNAZIVPOSILJAOCADescription;
            column31.Width = 0x128;
            column31.Format = "";
            column31.CellAppearance = appearance31;
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            column35.CellActivation = Activation.NoEdit;
            column35.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column35.Header.Caption = StringResources.KORISNIKSMTPSERVERDescription;
            column35.Width = 0x128;
            column35.Format = "";
            column35.CellAppearance = appearance35;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.NoEdit;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.KORISNIKIDKORISNIKDescription;
            column17.Width = 0x77;
            appearance17.TextHAlign = HAlign.Right;
            column17.MaskInput = "{LOC}-nnnnn";
            column17.PromptChar = ' ';
            column17.Format = "";
            column17.CellAppearance = appearance17;
            column17.Hidden = true;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column18.CellActivation = Activation.NoEdit;
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.KORISNIKIDZIRODescription;
            column18.Width = 0x33;
            appearance18.TextHAlign = HAlign.Right;
            column18.MaskInput = "{LOC}-nnnnn";
            column18.PromptChar = ' ';
            column18.Format = "";
            column18.CellAppearance = appearance18;
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            column21.CellActivation = Activation.NoEdit;
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.KORISNIKNAZIVZIRODescription;
            column21.Width = 0xb8;
            column21.Format = "";
            column21.CellAppearance = appearance21;
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            column25.CellActivation = Activation.NoEdit;
            column25.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column25.Header.Caption = StringResources.KORISNIKULICAZIRODescription;
            column25.Width = 0xb8;
            column25.Format = "";
            column25.CellAppearance = appearance25;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column19.CellActivation = Activation.NoEdit;
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.KORISNIKMJESTOZIRODescription;
            column19.Width = 0xb8;
            column19.Format = "";
            column19.CellAppearance = appearance19;
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            column26.CellActivation = Activation.NoEdit;
            column26.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column26.Header.Caption = StringResources.KORISNIKVBDIKORISNIKDescription;
            column26.Width = 0x56;
            column26.Format = "";
            column26.CellAppearance = appearance26;
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            column27.CellActivation = Activation.NoEdit;
            column27.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column27.Header.Caption = StringResources.KORISNIKZIROKORISNIKDescription;
            column27.Width = 0x56;
            column27.Format = "";
            column27.CellAppearance = appearance27;
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            column24.CellActivation = Activation.NoEdit;
            column24.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column24.Header.Caption = StringResources.KORISNIKSIFRAIZVORADescription;
            column24.Width = 0x4f;
            column24.Format = "";
            column24.CellAppearance = appearance24;
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            column20.CellActivation = Activation.NoEdit;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.KORISNIKNAZIVIZVORADescription;
            column20.Width = 0x9c;
            column20.Format = "";
            column20.CellAppearance = appearance20;
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            column22.CellActivation = Activation.NoEdit;
            column22.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column22.Header.Caption = StringResources.KORISNIKPOREZIPRIREZZAJEDNICKIDescription;
            column22.Width = 0xfe;
            column22.Format = "";
            column22.CellAppearance = appearance22;
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            column23.CellActivation = Activation.NoEdit;
            column23.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column23.Header.Caption = StringResources.KORISNIKPOZIVIZADUZENJADescription;
            column23.Width = 0x113;
            column23.Format = "";
            column23.CellAppearance = appearance23;
            band2.Columns.Add(column17);
            column17.Header.VisiblePosition = 0;
            band2.Columns.Add(column18);
            column18.Header.VisiblePosition = 1;
            band2.Columns.Add(column21);
            column21.Header.VisiblePosition = 2;
            band2.Columns.Add(column25);
            column25.Header.VisiblePosition = 3;
            band2.Columns.Add(column19);
            column19.Header.VisiblePosition = 4;
            band2.Columns.Add(column26);
            column26.Header.VisiblePosition = 5;
            band2.Columns.Add(column27);
            column27.Header.VisiblePosition = 6;
            band2.Columns.Add(column24);
            column24.Header.VisiblePosition = 7;
            band2.Columns.Add(column20);
            column20.Header.VisiblePosition = 8;
            band2.Columns.Add(column22);
            column22.Header.VisiblePosition = 9;
            band2.Columns.Add(column23);
            column23.Header.VisiblePosition = 10;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 0;
            band.Columns.Add(column14);
            column14.Header.VisiblePosition = 1;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 2;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 3;
            band.Columns.Add(column16);
            column16.Header.VisiblePosition = 4;
            band.Columns.Add(column28);
            column28.Header.VisiblePosition = 5;
            band.Columns.Add(column29);
            column29.Header.VisiblePosition = 6;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 7;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 8;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 9;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 10;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 11;
            band.Columns.Add(column30);
            column30.Header.VisiblePosition = 12;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 13;
            band.Columns.Add(column36);
            column36.Header.VisiblePosition = 14;
            band.Columns.Add(column34);
            column34.Header.VisiblePosition = 15;
            band.Columns.Add(column33);
            column33.Header.VisiblePosition = 0x10;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0x11;
            band.Columns.Add(column32);
            column32.Header.VisiblePosition = 0x12;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 0x13;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 20;
            band.Columns.Add(column15);
            column15.Header.VisiblePosition = 0x15;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 0x16;
            band.Columns.Add(column31);
            column31.Header.VisiblePosition = 0x17;
            band.Columns.Add(column35);
            column35.Header.VisiblePosition = 0x18;
            this.userControlDataGridKORISNIK.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridKORISNIK.Location = point;
            this.userControlDataGridKORISNIK.Name = "userControlDataGridKORISNIK";
            this.userControlDataGridKORISNIK.Tag = "KORISNIK";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridKORISNIK.Size = size;
            this.userControlDataGridKORISNIK.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridKORISNIK.Dock = DockStyle.Fill;
            this.userControlDataGridKORISNIK.FillAtStartup = false;
            this.userControlDataGridKORISNIK.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridKORISNIK.InitializeRow += new InitializeRowEventHandler(this.KORISNIKUserDataGrid_InitializeRow);
            this.userControlDataGridKORISNIK.DisplayLayout.BandsSerializer.Add(band);
            this.userControlDataGridKORISNIK.DisplayLayout.BandsSerializer.Add(band2);
            this.Controls.AddRange(new Control[] { this.userControlDataGridKORISNIK });
            this.Name = "KORISNIKUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.KORISNIKUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridKORISNIK).EndInit();
            this.ResumeLayout(false);
        }

        private void KORISNIKUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void KORISNIKUserDataGrid_Load(object sender, EventArgs e)
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
            DataSet dataSet = new IZVORDOKUMENTADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetIZVORDOKUMENTADataAdapter().Fill(dataSet);
            }
            System.Data.DataView dataList = new System.Data.DataView(dataSet.Tables["IZVORDOKUMENTA"]) {
                Sort = "SIFRAIZVORA"
            };
            CreateValueList(this.DataGrid, "IZVORDOKUMENTASIFRAIZVORA", dataList, "SIFRAIZVORA", "SIFRAIZVORA");
            UltraGridColumn column = this.DataGrid.DisplayLayout.Bands["KORISNIK_KORISNIKLevel1"].Columns["SIFRAIZVORA"];
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column.ValueList = this.DataGrid.DisplayLayout.ValueLists["IZVORDOKUMENTASIFRAIZVORA"];
            if (setColumnsWidth)
            {
                column.Width = 0x5b;
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
        public virtual KORISNIKDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridKORISNIK;
            }
            set
            {
                this.userControlDataGridKORISNIK = value;
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


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

    public class BLAGAJNAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with BLAGAJNA";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with BLAGAJNA";
        private BLAGAJNADataGrid userControlDataGridBLAGAJNA;

        public BLAGAJNAUserDataGrid()
        {
            this.InitializeComponent();
        }

        private void BLAGAJNAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void BLAGAJNAUserDataGrid_Load(object sender, EventArgs e)
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
            this.userControlDataGridBLAGAJNA = new BLAGAJNADataGrid();
            ((ISupportInitialize) this.userControlDataGridBLAGAJNA).BeginInit();
            UltraGridBand band = new UltraGridBand("BLAGAJNA", -1);
            UltraGridColumn column = new UltraGridColumn("BLGDOKIDDOKUMENT");
            UltraGridColumn column3 = new UltraGridColumn("NAZIVBLAGAJNA");
            UltraGridColumn column2 = new UltraGridColumn("BLGKONTOIDKONTO");
            UltraGridBand band2 = new UltraGridBand("BLAGAJNA_BLAGAJNAStavkeBlagajne", 0);
            UltraGridColumn column6 = new UltraGridColumn("BLGDOKIDDOKUMENT");
            UltraGridColumn column10 = new UltraGridColumn("IDBLGVRSTEDOK");
            UltraGridColumn column7 = new UltraGridColumn("blggodineIDGODINE");
            UltraGridColumn column11 = new UltraGridColumn("NAZIVVRSTEDOK");
            UltraGridColumn column4 = new UltraGridColumn("BLGBROJDOKUMENTA");
            UltraGridColumn column5 = new UltraGridColumn("BLGDATUMDOKUMENTA");
            UltraGridColumn column9 = new UltraGridColumn("BLGSVRHA");
            UltraGridColumn column8 = new UltraGridColumn("BLGIZNOS");
            UltraGridBand band3 = new UltraGridBand("BLAGAJNAStavkeBlagajne_BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje", 1);
            UltraGridColumn column13 = new UltraGridColumn("BLGDOKIDDOKUMENT");
            UltraGridColumn column22 = new UltraGridColumn("IDBLGVRSTEDOK");
            UltraGridColumn column14 = new UltraGridColumn("blggodineIDGODINE");
            UltraGridColumn column12 = new UltraGridColumn("BLGBROJDOKUMENTA");
            UltraGridColumn column20 = new UltraGridColumn("BLGSTAVKEBLAGAJNEKONTOIDKONTO");
            UltraGridColumn column21 = new UltraGridColumn("BLGSTAVKEBLAGAJNEKONTONAZIVKONTO");
            UltraGridColumn column16 = new UltraGridColumn("BLGMTIDMJESTOTROSKA");
            UltraGridColumn column17 = new UltraGridColumn("BLGMTNAZIVMJESTOTROSKA");
            UltraGridColumn column18 = new UltraGridColumn("BLGORGJEDIDORGJED");
            UltraGridColumn column19 = new UltraGridColumn("BLGORGJEDNAZIVORGJED");
            UltraGridColumn column15 = new UltraGridColumn("BLGIZNOSKONTIRANJA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.BLAGAJNABLGDOKIDDOKUMENTDescription;
            column.Width = 0x92;
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.BLAGAJNANAZIVBLAGAJNADescription;
            column3.Width = 0xe2;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.BLAGAJNABLGKONTOIDKONTODescription;
            column2.Width = 0x72;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.BLAGAJNABLGDOKIDDOKUMENTDescription;
            column6.Width = 0x92;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            column6.Hidden = true;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.BLAGAJNAIDBLGVRSTEDOKDescription;
            column10.Width = 0x7e;
            appearance10.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnnnn";
            column10.PromptChar = ' ';
            column10.Format = "";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.BLAGAJNAblggodineIDGODINEDescription;
            column7.Width = 0x3a;
            appearance7.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnnn";
            column7.PromptChar = ' ';
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.BLAGAJNANAZIVVRSTEDOKDescription;
            column11.Width = 0xe2;
            column11.Format = "";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.BLAGAJNABLGBROJDOKUMENTADescription;
            column4.Width = 0x70;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnnnnn";
            column4.PromptChar = ' ';
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.BLAGAJNABLGDATUMDOKUMENTADescription;
            column5.Width = 100;
            column5.MinValue = DateTime.MinValue;
            column5.MaxValue = DateTime.MaxValue;
            column5.Format = "d";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.BLAGAJNABLGSVRHADescription;
            column9.Width = 0x128;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.BLAGAJNABLGIZNOSDescription;
            column8.Width = 0x66;
            appearance8.TextHAlign = HAlign.Right;
            column8.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column8.PromptChar = ' ';
            column8.Format = "F2";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.BLAGAJNABLGDOKIDDOKUMENTDescription;
            column13.Width = 0x92;
            column13.Format = "";
            column13.CellAppearance = appearance13;
            column13.Hidden = true;
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            column22.CellActivation = Activation.NoEdit;
            column22.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column22.Header.Caption = StringResources.BLAGAJNAIDBLGVRSTEDOKDescription;
            column22.Width = 0x7e;
            appearance22.TextHAlign = HAlign.Right;
            column22.MaskInput = "{LOC}-nnnnn";
            column22.PromptChar = ' ';
            column22.Format = "";
            column22.CellAppearance = appearance22;
            column22.Hidden = true;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.BLAGAJNAblggodineIDGODINEDescription;
            column14.Width = 0x3a;
            appearance14.TextHAlign = HAlign.Right;
            column14.MaskInput = "{LOC}-nnnn";
            column14.PromptChar = ' ';
            column14.Format = "";
            column14.CellAppearance = appearance14;
            column14.Hidden = true;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.BLAGAJNABLGBROJDOKUMENTADescription;
            column12.Width = 0x70;
            appearance12.TextHAlign = HAlign.Right;
            column12.MaskInput = "{LOC}-nnnnnnnn";
            column12.PromptChar = ' ';
            column12.Format = "";
            column12.CellAppearance = appearance12;
            column12.Hidden = true;
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            column20.CellActivation = Activation.NoEdit;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.BLAGAJNABLGSTAVKEBLAGAJNEKONTOIDKONTODescription;
            column20.Width = 0x72;
            column20.Format = "";
            column20.CellAppearance = appearance20;
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            column21.CellActivation = Activation.NoEdit;
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.BLAGAJNABLGSTAVKEBLAGAJNEKONTONAZIVKONTODescription;
            column21.Width = 0x128;
            column21.Format = "";
            column21.CellAppearance = appearance21;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.BLAGAJNABLGMTIDMJESTOTROSKADescription;
            column16.Width = 0x48;
            column16.Format = "";
            column16.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.NoEdit;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.BLAGAJNABLGMTNAZIVMJESTOTROSKADescription;
            column17.Width = 0x128;
            column17.Format = "";
            column17.CellAppearance = appearance17;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column18.CellActivation = Activation.NoEdit;
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.BLAGAJNABLGORGJEDIDORGJEDDescription;
            column18.Width = 0x48;
            column18.Format = "";
            column18.CellAppearance = appearance18;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column19.CellActivation = Activation.NoEdit;
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.BLAGAJNABLGORGJEDNAZIVORGJEDDescription;
            column19.Width = 0x128;
            column19.Format = "";
            column19.CellAppearance = appearance19;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.BLAGAJNABLGIZNOSKONTIRANJADescription;
            column15.Width = 0x81;
            appearance15.TextHAlign = HAlign.Right;
            column15.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column15.PromptChar = ' ';
            column15.Format = "F2";
            column15.CellAppearance = appearance15;
            band3.Columns.Add(column13);
            column13.Header.VisiblePosition = 0;
            band3.Columns.Add(column22);
            column22.Header.VisiblePosition = 1;
            band3.Columns.Add(column14);
            column14.Header.VisiblePosition = 2;
            band3.Columns.Add(column12);
            column12.Header.VisiblePosition = 3;
            band3.Columns.Add(column20);
            column20.Header.VisiblePosition = 4;
            band3.Columns.Add(column21);
            column21.Header.VisiblePosition = 5;
            band3.Columns.Add(column16);
            column16.Header.VisiblePosition = 6;
            band3.Columns.Add(column17);
            column17.Header.VisiblePosition = 7;
            band3.Columns.Add(column18);
            column18.Header.VisiblePosition = 8;
            band3.Columns.Add(column19);
            column19.Header.VisiblePosition = 9;
            band3.Columns.Add(column15);
            column15.Header.VisiblePosition = 10;
            band2.Columns.Add(column6);
            column6.Header.VisiblePosition = 0;
            band2.Columns.Add(column10);
            column10.Header.VisiblePosition = 1;
            band2.Columns.Add(column7);
            column7.Header.VisiblePosition = 2;
            band2.Columns.Add(column11);
            column11.Header.VisiblePosition = 3;
            band2.Columns.Add(column4);
            column4.Header.VisiblePosition = 4;
            band2.Columns.Add(column5);
            column5.Header.VisiblePosition = 5;
            band2.Columns.Add(column9);
            column9.Header.VisiblePosition = 6;
            band2.Columns.Add(column8);
            column8.Header.VisiblePosition = 7;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 1;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 2;
            this.userControlDataGridBLAGAJNA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridBLAGAJNA.Location = point;
            this.userControlDataGridBLAGAJNA.Name = "userControlDataGridBLAGAJNA";
            this.userControlDataGridBLAGAJNA.Tag = "BLAGAJNA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridBLAGAJNA.Size = size;
            this.userControlDataGridBLAGAJNA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridBLAGAJNA.Dock = DockStyle.Fill;
            this.userControlDataGridBLAGAJNA.FillAtStartup = false;
            this.userControlDataGridBLAGAJNA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridBLAGAJNA.InitializeRow += new InitializeRowEventHandler(this.BLAGAJNAUserDataGrid_InitializeRow);
            this.userControlDataGridBLAGAJNA.DisplayLayout.BandsSerializer.Add(band);
            this.userControlDataGridBLAGAJNA.DisplayLayout.BandsSerializer.Add(band2);
            this.userControlDataGridBLAGAJNA.DisplayLayout.BandsSerializer.Add(band3);
            this.Controls.AddRange(new Control[] { this.userControlDataGridBLAGAJNA });
            this.Name = "BLAGAJNAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.BLAGAJNAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridBLAGAJNA).EndInit();
            this.ResumeLayout(false);
        }

        private void SetComboBoxColumnProperties(bool setColumnsWidth)
        {
            if (DataAdapterFactory.Provider == null)
            {
                DataAdapterFactory.Provider = new SimpleDataAdapterFactory();
            }
            DataSet dataSet = new DOKUMENTDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetDOKUMENTDataAdapter().Fill(dataSet);
            }
            System.Data.DataView dataList = new System.Data.DataView(dataSet.Tables["DOKUMENT"]) {
                Sort = "NAZIVDOKUMENT"
            };
            CreateValueList(this.DataGrid, "DOKUMENTBLGDOKIDDOKUMENT", dataList, "IDDOKUMENT", "NAZIVDOKUMENT");
            UltraGridColumn column = this.DataGrid.DisplayLayout.Bands["BLAGAJNA"].Columns["BLGDOKIDDOKUMENT"];
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column.ValueList = this.DataGrid.DisplayLayout.ValueLists["DOKUMENTBLGDOKIDDOKUMENT"];
            if (setColumnsWidth)
            {
                column.Width = 370;
            }
            DataSet set2 = new KONTODataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetKONTODataAdapter().Fill(set2);
            }
            System.Data.DataView view2 = new System.Data.DataView(set2.Tables["KONTO"]) {
                Sort = "KONT"
            };
            CreateValueList(this.DataGrid, "KONTOBLGKONTOIDKONTO", view2, "IDKONTO", "KONT");
            UltraGridColumn column2 = this.DataGrid.DisplayLayout.Bands["BLAGAJNA"].Columns["BLGKONTOIDKONTO"];
            column2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column2.ValueList = this.DataGrid.DisplayLayout.ValueLists["KONTOBLGKONTOIDKONTO"];
            if (setColumnsWidth)
            {
                column2.Width = 370;
            }
            DataSet set3 = new DOKUMENTDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetDOKUMENTDataAdapter().Fill(set3);
            }
            System.Data.DataView view3 = new System.Data.DataView(set3.Tables["DOKUMENT"]) {
                Sort = "NAZIVDOKUMENT"
            };
            CreateValueList(this.DataGrid, "DOKUMENTBLGDOKIDDOKUMENT", view3, "IDDOKUMENT", "NAZIVDOKUMENT");
            UltraGridColumn column3 = this.DataGrid.DisplayLayout.Bands["BLAGAJNA_BLAGAJNAStavkeBlagajne"].Columns["BLGDOKIDDOKUMENT"];
            column3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column3.ValueList = this.DataGrid.DisplayLayout.ValueLists["DOKUMENTBLGDOKIDDOKUMENT"];
            if (setColumnsWidth)
            {
                column3.Width = 370;
            }
            DataSet set4 = new DOKUMENTDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetDOKUMENTDataAdapter().Fill(set4);
            }
            System.Data.DataView view4 = new System.Data.DataView(set4.Tables["DOKUMENT"]) {
                Sort = "NAZIVDOKUMENT"
            };
            CreateValueList(this.DataGrid, "DOKUMENTBLGDOKIDDOKUMENT", view4, "IDDOKUMENT", "NAZIVDOKUMENT");
            UltraGridColumn column4 = this.DataGrid.DisplayLayout.Bands["BLAGAJNAStavkeBlagajne_BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje"].Columns["BLGDOKIDDOKUMENT"];
            column4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column4.ValueList = this.DataGrid.DisplayLayout.ValueLists["DOKUMENTBLGDOKIDDOKUMENT"];
            if (setColumnsWidth)
            {
                column4.Width = 370;
            }
            DataSet set7 = new KONTODataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetKONTODataAdapter().Fill(set7);
            }
            System.Data.DataView view7 = new System.Data.DataView(set7.Tables["KONTO"]) {
                Sort = "KONT"
            };
            CreateValueList(this.DataGrid, "KONTOBLGSTAVKEBLAGAJNEKONTOIDKONTO", view7, "IDKONTO", "KONT");
            UltraGridColumn column7 = this.DataGrid.DisplayLayout.Bands["BLAGAJNAStavkeBlagajne_BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje"].Columns["BLGSTAVKEBLAGAJNEKONTOIDKONTO"];
            column7.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column7.ValueList = this.DataGrid.DisplayLayout.ValueLists["KONTOBLGSTAVKEBLAGAJNEKONTOIDKONTO"];
            if (setColumnsWidth)
            {
                column7.Width = 370;
            }
            DataSet set5 = new MJESTOTROSKADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetMJESTOTROSKADataAdapter().Fill(set5);
            }
            System.Data.DataView view5 = new System.Data.DataView(set5.Tables["MJESTOTROSKA"]) {
                Sort = "mt"
            };
            CreateValueList(this.DataGrid, "MJESTOTROSKABLGMTIDMJESTOTROSKA", view5, "IDMJESTOTROSKA", "mt");
            UltraGridColumn column5 = this.DataGrid.DisplayLayout.Bands["BLAGAJNAStavkeBlagajne_BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje"].Columns["BLGMTIDMJESTOTROSKA"];
            column5.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column5.ValueList = this.DataGrid.DisplayLayout.ValueLists["MJESTOTROSKABLGMTIDMJESTOTROSKA"];
            if (setColumnsWidth)
            {
                column5.Width = 370;
            }
            DataSet set6 = new ORGJEDDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetORGJEDDataAdapter().Fill(set6);
            }
            System.Data.DataView view6 = new System.Data.DataView(set6.Tables["ORGJED"]) {
                Sort = "oj"
            };
            CreateValueList(this.DataGrid, "ORGJEDBLGORGJEDIDORGJED", view6, "IDORGJED", "oj");
            UltraGridColumn column6 = this.DataGrid.DisplayLayout.Bands["BLAGAJNAStavkeBlagajne_BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje"].Columns["BLGORGJEDIDORGJED"];
            column6.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column6.ValueList = this.DataGrid.DisplayLayout.ValueLists["ORGJEDBLGORGJEDIDORGJED"];
            if (setColumnsWidth)
            {
                column6.Width = 370;
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
        public virtual BLAGAJNADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridBLAGAJNA;
            }
            set
            {
                this.userControlDataGridBLAGAJNA = value;
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
        public virtual string FillByBLGKONTOIDKONTOBLGKONTOIDKONTO
        {
            get
            {
                return this.DataGrid.FillByBLGKONTOIDKONTOBLGKONTOIDKONTO;
            }
            set
            {
                this.DataGrid.FillByBLGKONTOIDKONTOBLGKONTOIDKONTO = value;
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


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

    public class SHEMAPLACAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Shema place";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Shema place";
        private SHEMAPLACADataGrid userControlDataGridSHEMAPLACA;

        public SHEMAPLACAUserDataGrid()
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
            this.userControlDataGridSHEMAPLACA = new SHEMAPLACADataGrid();
            ((ISupportInitialize) this.userControlDataGridSHEMAPLACA).BeginInit();
            UltraGridBand band = new UltraGridBand("SHEMAPLACA", -1);
            UltraGridColumn column = new UltraGridColumn("IDSHEMAPLACA");
            UltraGridColumn column2 = new UltraGridColumn("NAZIVSHEMAPLACA");
            UltraGridColumn column23 = new UltraGridColumn("SHEMAPLOJIDORGJED");
            UltraGridBand band2 = new UltraGridBand("SHEMAPLACA_SHEMAPLACASHEMAPLACADOP", 0);
            UltraGridColumn column3 = new UltraGridColumn("IDSHEMAPLACA");
            UltraGridColumn column6 = new UltraGridColumn("SHEMAPLDOPIDDOPRINOS");
            UltraGridColumn column4 = new UltraGridColumn("KONTODOPIDKONTO");
            UltraGridColumn column5 = new UltraGridColumn("MTDOPIDMJESTOTROSKA");
            UltraGridColumn column8 = new UltraGridColumn("STRANEDOPIDSTRANEKNJIZENJA");
            UltraGridColumn column7 = new UltraGridColumn("SHEMAPLDOPNAZIVDOPRINOS");
            UltraGridBand band3 = new UltraGridBand("SHEMAPLACA_SHEMAPLACASHEMAPLACAELEMENT", 0);
            UltraGridColumn column9 = new UltraGridColumn("IDSHEMAPLACA");
            UltraGridColumn column12 = new UltraGridColumn("SHEMAPLELEMENTIDELEMENT");
            UltraGridColumn column10 = new UltraGridColumn("KONTOELEMENTIDKONTO");
            UltraGridColumn column15 = new UltraGridColumn("STRANEELEMENTIDSTRANEKNJIZENJA");
            UltraGridColumn column11 = new UltraGridColumn("MTELEMENTIDMJESTOTROSKA");
            UltraGridColumn column14 = new UltraGridColumn("SHEMAPLELEMENTNAZIVELEMENT");
            UltraGridColumn column13 = new UltraGridColumn("SHEMAPLELEMENTIDVRSTAELEMENTA");
            UltraGridBand band4 = new UltraGridBand("SHEMAPLACA_SHEMAPLACASHEMAPLACASTANDARD", 0);
            UltraGridColumn column17 = new UltraGridColumn("IDSHEMAPLACA");
            UltraGridColumn column21 = new UltraGridColumn("SHEMAPLACASTANDARDID");
            UltraGridColumn column16 = new UltraGridColumn("IDPLVRSTEIZNOSA");
            UltraGridColumn column18 = new UltraGridColumn("KONTOPLACAVRSTAIZNOSAIDKONTO");
            UltraGridColumn column19 = new UltraGridColumn("MTPLACAVRSTAIZNOSAIDMJESTOTROSKA");
            UltraGridColumn column22 = new UltraGridColumn("STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA");
            UltraGridColumn column20 = new UltraGridColumn("NAZIVPLVRSTEIZNOSA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.SHEMAPLACAIDSHEMAPLACADescription;
            column.Width = 0x33;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.SHEMAPLACANAZIVSHEMAPLACADescription;
            column2.Width = 0x128;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            column23.CellActivation = Activation.NoEdit;
            column23.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column23.Header.Caption = StringResources.SHEMAPLACASHEMAPLOJIDORGJEDDescription;
            column23.Width = 0x69;
            column23.Format = "";
            column23.CellAppearance = appearance23;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.SHEMAPLACAIDSHEMAPLACADescription;
            column3.Width = 0x33;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnn";
            column3.PromptChar = ' ';
            column3.Format = "";
            column3.CellAppearance = appearance3;
            column3.Hidden = true;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.SHEMAPLACASHEMAPLDOPIDDOPRINOSDescription;
            column6.Width = 0x77;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnn";
            column6.PromptChar = ' ';
            column6.Format = "";
            column6.CellAppearance = appearance6;
            column6.Hidden = true;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.SHEMAPLACAKONTODOPIDKONTODescription;
            column4.Width = 0x72;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.SHEMAPLACAMTDOPIDMJESTOTROSKADescription;
            column5.Width = 0x69;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.SHEMAPLACASTRANEDOPIDSTRANEKNJIZENJADescription;
            column8.Width = 0x7e;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.SHEMAPLACASHEMAPLDOPNAZIVDOPRINOSDescription;
            column7.Width = 0x128;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            band2.Columns.Add(column3);
            column3.Header.VisiblePosition = 0;
            band2.Columns.Add(column7);
            column7.Header.VisiblePosition = 1;
            band2.Columns.Add(column4);
            column4.Header.VisiblePosition = 2;
            band2.Columns.Add(column5);
            column5.Header.VisiblePosition = 3;
            band2.Columns.Add(column8);
            column8.Header.VisiblePosition = 4;
            band2.Columns.Add(column6);
            column6.Header.VisiblePosition = 5;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.SHEMAPLACAIDSHEMAPLACADescription;
            column9.Width = 0x33;
            appearance9.TextHAlign = HAlign.Right;
            column9.MaskInput = "{LOC}-nnnnn";
            column9.PromptChar = ' ';
            column9.Format = "";
            column9.CellAppearance = appearance9;
            column9.Hidden = true;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.SHEMAPLACASHEMAPLELEMENTIDELEMENTDescription;
            column12.Width = 0x70;
            column12.Format = "";
            column12.CellAppearance = appearance12;
            column12.Hidden = true;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.SHEMAPLACAKONTOELEMENTIDKONTODescription;
            column10.Width = 0x72;
            column10.Format = "";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.SHEMAPLACASTRANEELEMENTIDSTRANEKNJIZENJADescription;
            column15.Width = 0x7e;
            column15.Format = "";
            column15.CellAppearance = appearance15;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.SHEMAPLACAMTELEMENTIDMJESTOTROSKADescription;
            column11.Width = 0x69;
            column11.Format = "";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.SHEMAPLACASHEMAPLELEMENTNAZIVELEMENTDescription;
            column14.Width = 0x128;
            column14.Format = "";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.SHEMAPLACASHEMAPLELEMENTIDVRSTAELEMENTADescription;
            column13.Width = 0x99;
            appearance13.TextHAlign = HAlign.Right;
            column13.MaskInput = "{LOC}-nnnn";
            column13.PromptChar = ' ';
            column13.Format = "";
            column13.CellAppearance = appearance13;
            column13.Hidden = true;
            band3.Columns.Add(column9);
            column9.Header.VisiblePosition = 0;
            band3.Columns.Add(column14);
            column14.Header.VisiblePosition = 1;
            band3.Columns.Add(column10);
            column10.Header.VisiblePosition = 2;
            band3.Columns.Add(column11);
            column11.Header.VisiblePosition = 3;
            band3.Columns.Add(column15);
            column15.Header.VisiblePosition = 4;
            band3.Columns.Add(column12);
            column12.Header.VisiblePosition = 5;
            band3.Columns.Add(column13);
            column13.Header.VisiblePosition = 6;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.NoEdit;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.SHEMAPLACAIDSHEMAPLACADescription;
            column17.Width = 0x33;
            appearance17.TextHAlign = HAlign.Right;
            column17.MaskInput = "{LOC}-nnnnn";
            column17.PromptChar = ' ';
            column17.Format = "";
            column17.CellAppearance = appearance17;
            column17.Hidden = true;
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            column21.CellActivation = Activation.NoEdit;
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.SHEMAPLACASHEMAPLACASTANDARDIDDescription;
            column21.Width = 0x10c;
            column21.Format = "";
            column21.CellAppearance = appearance21;
            column21.Hidden = true;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.SHEMAPLACAIDPLVRSTEIZNOSADescription;
            column16.Width = 0x63;
            column16.Format = "";
            column16.CellAppearance = appearance16;
            column16.Hidden = true;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column18.CellActivation = Activation.NoEdit;
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.SHEMAPLACAKONTOPLACAVRSTAIZNOSAIDKONTODescription;
            column18.Width = 0x72;
            column18.Format = "";
            column18.CellAppearance = appearance18;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column19.CellActivation = Activation.NoEdit;
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.SHEMAPLACAMTPLACAVRSTAIZNOSAIDMJESTOTROSKADescription;
            column19.Width = 0x69;
            column19.Format = "";
            column19.CellAppearance = appearance19;
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            column22.CellActivation = Activation.NoEdit;
            column22.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column22.Header.Caption = StringResources.SHEMAPLACASTRANEVRSTEIZNOSAIDSTRANEKNJIZENJADescription;
            column22.Width = 0x77;
            column22.Format = "";
            column22.CellAppearance = appearance22;
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            column20.CellActivation = Activation.NoEdit;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.SHEMAPLACANAZIVPLVRSTEIZNOSADescription;
            column20.Width = 0x128;
            column20.Format = "";
            column20.CellAppearance = appearance20;
            band4.Columns.Add(column17);
            column17.Header.VisiblePosition = 0;
            band4.Columns.Add(column20);
            column20.Header.VisiblePosition = 1;
            band4.Columns.Add(column18);
            column18.Header.VisiblePosition = 2;
            band4.Columns.Add(column19);
            column19.Header.VisiblePosition = 3;
            band4.Columns.Add(column22);
            column22.Header.VisiblePosition = 4;
            band4.Columns.Add(column21);
            column21.Header.VisiblePosition = 5;
            band4.Columns.Add(column16);
            column16.Header.VisiblePosition = 6;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            band.Columns.Add(column23);
            column23.Header.VisiblePosition = 2;
            this.userControlDataGridSHEMAPLACA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridSHEMAPLACA.Location = point;
            this.userControlDataGridSHEMAPLACA.Name = "userControlDataGridSHEMAPLACA";
            this.userControlDataGridSHEMAPLACA.Tag = "SHEMAPLACA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridSHEMAPLACA.Size = size;
            this.userControlDataGridSHEMAPLACA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridSHEMAPLACA.Dock = DockStyle.Fill;
            this.userControlDataGridSHEMAPLACA.FillAtStartup = false;
            this.userControlDataGridSHEMAPLACA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridSHEMAPLACA.InitializeRow += new InitializeRowEventHandler(this.SHEMAPLACAUserDataGrid_InitializeRow);
            this.userControlDataGridSHEMAPLACA.DisplayLayout.BandsSerializer.Add(band);
            this.userControlDataGridSHEMAPLACA.DisplayLayout.BandsSerializer.Add(band2);
            this.userControlDataGridSHEMAPLACA.DisplayLayout.BandsSerializer.Add(band3);
            this.userControlDataGridSHEMAPLACA.DisplayLayout.BandsSerializer.Add(band4);
            this.Controls.AddRange(new Control[] { this.userControlDataGridSHEMAPLACA });
            this.Name = "SHEMAPLACAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.SHEMAPLACAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridSHEMAPLACA).EndInit();
            this.ResumeLayout(false);
        }

        private void SetComboBoxColumnProperties(bool setColumnsWidth)
        {
            if (DataAdapterFactory.Provider == null)
            {
                DataAdapterFactory.Provider = new SimpleDataAdapterFactory();
            }
            DataSet dataSet = new ORGJEDDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetORGJEDDataAdapter().Fill(dataSet);
            }
            System.Data.DataView dataList = new System.Data.DataView(dataSet.Tables["ORGJED"]) {
                Sort = "oj"
            };
            CreateValueList(this.DataGrid, "ORGJEDSHEMAPLOJIDORGJED", dataList, "IDORGJED", "oj");
            UltraGridColumn column10 = this.DataGrid.DisplayLayout.Bands["SHEMAPLACA"].Columns["SHEMAPLOJIDORGJED"];
            column10.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column10.ValueList = this.DataGrid.DisplayLayout.ValueLists["ORGJEDSHEMAPLOJIDORGJED"];
            if (setColumnsWidth)
            {
                column10.Width = 370;
            }
            DataSet set = new KONTODataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetKONTODataAdapter().Fill(set);
            }
            System.Data.DataView view = new System.Data.DataView(set.Tables["KONTO"]) {
                Sort = "KONT"
            };
            CreateValueList(this.DataGrid, "KONTOKONTODOPIDKONTO", view, "IDKONTO", "KONT");
            UltraGridColumn column = this.DataGrid.DisplayLayout.Bands["SHEMAPLACA_SHEMAPLACASHEMAPLACADOP"].Columns["KONTODOPIDKONTO"];
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column.ValueList = this.DataGrid.DisplayLayout.ValueLists["KONTOKONTODOPIDKONTO"];
            if (setColumnsWidth)
            {
                column.Width = 370;
            }
            DataSet set2 = new MJESTOTROSKADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetMJESTOTROSKADataAdapter().Fill(set2);
            }
            System.Data.DataView view2 = new System.Data.DataView(set2.Tables["MJESTOTROSKA"]) {
                Sort = "mt"
            };
            CreateValueList(this.DataGrid, "MJESTOTROSKAMTDOPIDMJESTOTROSKA", view2, "IDMJESTOTROSKA", "mt");
            UltraGridColumn column2 = this.DataGrid.DisplayLayout.Bands["SHEMAPLACA_SHEMAPLACASHEMAPLACADOP"].Columns["MTDOPIDMJESTOTROSKA"];
            column2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column2.ValueList = this.DataGrid.DisplayLayout.ValueLists["MJESTOTROSKAMTDOPIDMJESTOTROSKA"];
            if (setColumnsWidth)
            {
                column2.Width = 370;
            }
            DataSet set3 = new STRANEKNJIZENJADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetSTRANEKNJIZENJADataAdapter().Fill(set3);
            }
            System.Data.DataView view3 = new System.Data.DataView(set3.Tables["STRANEKNJIZENJA"]) {
                Sort = "NAZIVSTRANEKNJIZENJA"
            };
            CreateValueList(this.DataGrid, "STRANEKNJIZENJASTRANEDOPIDSTRANEKNJIZENJA", view3, "IDSTRANEKNJIZENJA", "NAZIVSTRANEKNJIZENJA");
            UltraGridColumn column3 = this.DataGrid.DisplayLayout.Bands["SHEMAPLACA_SHEMAPLACASHEMAPLACADOP"].Columns["STRANEDOPIDSTRANEKNJIZENJA"];
            column3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column3.ValueList = this.DataGrid.DisplayLayout.ValueLists["STRANEKNJIZENJASTRANEDOPIDSTRANEKNJIZENJA"];
            if (setColumnsWidth)
            {
                column3.Width = 280;
            }
            DataSet set4 = new KONTODataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetKONTODataAdapter().Fill(set4);
            }
            System.Data.DataView view4 = new System.Data.DataView(set4.Tables["KONTO"]) {
                Sort = "KONT"
            };
            CreateValueList(this.DataGrid, "KONTOKONTOELEMENTIDKONTO", view4, "IDKONTO", "KONT");
            UltraGridColumn column4 = this.DataGrid.DisplayLayout.Bands["SHEMAPLACA_SHEMAPLACASHEMAPLACAELEMENT"].Columns["KONTOELEMENTIDKONTO"];
            column4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column4.ValueList = this.DataGrid.DisplayLayout.ValueLists["KONTOKONTOELEMENTIDKONTO"];
            if (setColumnsWidth)
            {
                column4.Width = 370;
            }
            DataSet set6 = new STRANEKNJIZENJADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetSTRANEKNJIZENJADataAdapter().Fill(set6);
            }
            System.Data.DataView view6 = new System.Data.DataView(set6.Tables["STRANEKNJIZENJA"]) {
                Sort = "NAZIVSTRANEKNJIZENJA"
            };
            CreateValueList(this.DataGrid, "STRANEKNJIZENJASTRANEELEMENTIDSTRANEKNJIZENJA", view6, "IDSTRANEKNJIZENJA", "NAZIVSTRANEKNJIZENJA");
            UltraGridColumn column6 = this.DataGrid.DisplayLayout.Bands["SHEMAPLACA_SHEMAPLACASHEMAPLACAELEMENT"].Columns["STRANEELEMENTIDSTRANEKNJIZENJA"];
            column6.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column6.ValueList = this.DataGrid.DisplayLayout.ValueLists["STRANEKNJIZENJASTRANEELEMENTIDSTRANEKNJIZENJA"];
            if (setColumnsWidth)
            {
                column6.Width = 280;
            }
            DataSet set5 = new MJESTOTROSKADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetMJESTOTROSKADataAdapter().Fill(set5);
            }
            System.Data.DataView view5 = new System.Data.DataView(set5.Tables["MJESTOTROSKA"]) {
                Sort = "mt"
            };
            CreateValueList(this.DataGrid, "MJESTOTROSKAMTELEMENTIDMJESTOTROSKA", view5, "IDMJESTOTROSKA", "mt");
            UltraGridColumn column5 = this.DataGrid.DisplayLayout.Bands["SHEMAPLACA_SHEMAPLACASHEMAPLACAELEMENT"].Columns["MTELEMENTIDMJESTOTROSKA"];
            column5.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column5.ValueList = this.DataGrid.DisplayLayout.ValueLists["MJESTOTROSKAMTELEMENTIDMJESTOTROSKA"];
            if (setColumnsWidth)
            {
                column5.Width = 370;
            }
            DataSet set7 = new KONTODataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetKONTODataAdapter().Fill(set7);
            }
            System.Data.DataView view7 = new System.Data.DataView(set7.Tables["KONTO"]) {
                Sort = "KONT"
            };
            CreateValueList(this.DataGrid, "KONTOKONTOPLACAVRSTAIZNOSAIDKONTO", view7, "IDKONTO", "KONT");
            UltraGridColumn column7 = this.DataGrid.DisplayLayout.Bands["SHEMAPLACA_SHEMAPLACASHEMAPLACASTANDARD"].Columns["KONTOPLACAVRSTAIZNOSAIDKONTO"];
            column7.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column7.ValueList = this.DataGrid.DisplayLayout.ValueLists["KONTOKONTOPLACAVRSTAIZNOSAIDKONTO"];
            if (setColumnsWidth)
            {
                column7.Width = 370;
            }
            DataSet set8 = new MJESTOTROSKADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetMJESTOTROSKADataAdapter().Fill(set8);
            }
            System.Data.DataView view8 = new System.Data.DataView(set8.Tables["MJESTOTROSKA"]) {
                Sort = "mt"
            };
            CreateValueList(this.DataGrid, "MJESTOTROSKAMTPLACAVRSTAIZNOSAIDMJESTOTROSKA", view8, "IDMJESTOTROSKA", "mt");
            UltraGridColumn column8 = this.DataGrid.DisplayLayout.Bands["SHEMAPLACA_SHEMAPLACASHEMAPLACASTANDARD"].Columns["MTPLACAVRSTAIZNOSAIDMJESTOTROSKA"];
            column8.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column8.ValueList = this.DataGrid.DisplayLayout.ValueLists["MJESTOTROSKAMTPLACAVRSTAIZNOSAIDMJESTOTROSKA"];
            if (setColumnsWidth)
            {
                column8.Width = 370;
            }
            DataSet set9 = new STRANEKNJIZENJADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetSTRANEKNJIZENJADataAdapter().Fill(set9);
            }
            System.Data.DataView view9 = new System.Data.DataView(set9.Tables["STRANEKNJIZENJA"]) {
                Sort = "NAZIVSTRANEKNJIZENJA"
            };
            CreateValueList(this.DataGrid, "STRANEKNJIZENJASTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA", view9, "IDSTRANEKNJIZENJA", "NAZIVSTRANEKNJIZENJA");
            UltraGridColumn column9 = this.DataGrid.DisplayLayout.Bands["SHEMAPLACA_SHEMAPLACASHEMAPLACASTANDARD"].Columns["STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA"];
            column9.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column9.ValueList = this.DataGrid.DisplayLayout.ValueLists["STRANEKNJIZENJASTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA"];
            if (setColumnsWidth)
            {
                column9.Width = 280;
            }
        }

        private void SHEMAPLACAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void SHEMAPLACAUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual SHEMAPLACADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridSHEMAPLACA;
            }
            set
            {
                this.userControlDataGridSHEMAPLACA = value;
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
        public virtual int FillBySHEMAPLOJIDORGJEDSHEMAPLOJIDORGJED
        {
            get
            {
                return this.DataGrid.FillBySHEMAPLOJIDORGJEDSHEMAPLOJIDORGJED;
            }
            set
            {
                this.DataGrid.FillBySHEMAPLOJIDORGJEDSHEMAPLOJIDORGJED = value;
            }
        }

        [TypeConverter(typeof(DeklaritDataGrid.FillMethodsConverter)), Category("Deklarit Work With "), DefaultValue("Fill")]
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


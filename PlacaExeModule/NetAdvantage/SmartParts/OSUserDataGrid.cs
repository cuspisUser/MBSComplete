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

    public class OSUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with OS";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with OS";
        private OSDataGrid userControlDataGridOS;

        public OSUserDataGrid()
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
            this.userControlDataGridOS = new OSDataGrid();
            ((ISupportInitialize) this.userControlDataGridOS).BeginInit();
            UltraGridBand band = new UltraGridBand("OS", -1);
            UltraGridColumn column6 = new UltraGridColumn("INVBROJ");
            UltraGridColumn column5 = new UltraGridColumn("IDOSVRSTA");
            UltraGridColumn column11 = new UltraGridColumn("NAZIVOS");
            UltraGridColumn column4 = new UltraGridColumn("IDAMSKUPINE");
            UltraGridColumn column9 = new UltraGridColumn("KTONABAVKEIDKONTO");
            UltraGridColumn column7 = new UltraGridColumn("KTOISPRAVKAIDKONTO");
            UltraGridColumn column8 = new UltraGridColumn("KTOIZVORAIDKONTO");
            UltraGridColumn column2 = new UltraGridColumn("DATUMNABAVKE");
            UltraGridColumn column3 = new UltraGridColumn("DATUMUPORABE");
            UltraGridColumn column10 = new UltraGridColumn("NAPOMENAOS");
            UltraGridColumn column12 = new UltraGridColumn("OPISAMSKUPINE");
            UltraGridColumn column = new UltraGridColumn("AMSKUPINASTOPA");
            UltraGridBand band2 = new UltraGridBand("OS_OSTEMELJNICA", 0);
            UltraGridColumn column14 = new UltraGridColumn("INVBROJ");
            UltraGridColumn column13 = new UltraGridColumn("IDOSDOKUMENT");
            UltraGridColumn column16 = new UltraGridColumn("OSBROJDOKUMENTA");
            UltraGridColumn column17 = new UltraGridColumn("OSDATUMDOK");
            UltraGridColumn column19 = new UltraGridColumn("OSKOLICINA");
            UltraGridColumn column23 = new UltraGridColumn("OSSTOPA");
            UltraGridColumn column21 = new UltraGridColumn("OSOSNOVICA");
            UltraGridColumn column18 = new UltraGridColumn("OSDUGUJE");
            UltraGridColumn column22 = new UltraGridColumn("OSPOTRAZUJE");
            UltraGridColumn column24 = new UltraGridColumn("RASHODLOKACIJEIDLOKACIJE");
            UltraGridColumn column20 = new UltraGridColumn("OSOPIS");
            UltraGridColumn column15 = new UltraGridColumn("NAZIVOSDOKUMENT");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.OSINVBROJDescription;
            column6.Width = 0x77;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnnnnnn";
            column6.PromptChar = ' ';
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.OSIDOSVRSTADescription;
            column5.Width = 0x9f;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.OSNAZIVOSDescription;
            column11.Width = 0x128;
            column11.Format = "";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.OSIDAMSKUPINEDescription;
            column4.Width = 0xa6;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.OSKTONABAVKEIDKONTODescription;
            column9.Width = 0x87;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            column9.Hidden = true;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.OSKTOISPRAVKAIDKONTODescription;
            column7.Width = 0x8e;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            column7.Hidden = true;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.OSKTOIZVORAIDKONTODescription;
            column8.Width = 0xb1;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            column8.Hidden = true;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.OSDATUMNABAVKEDescription;
            column2.Width = 0x6b;
            column2.MinValue = DateTime.MinValue;
            column2.MaxValue = DateTime.MaxValue;
            column2.Format = "d";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.OSDATUMUPORABEDescription;
            column3.Width = 0x6b;
            column3.MinValue = DateTime.MinValue;
            column3.MaxValue = DateTime.MaxValue;
            column3.Format = "d";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.OSNAPOMENAOSDescription;
            column10.Width = 0x128;
            column10.Format = "";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.OSOPISAMSKUPINEDescription;
            column12.Width = 0x128;
            column12.Format = "";
            column12.CellAppearance = appearance12;
            column12.Hidden = true;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.OSAMSKUPINASTOPADescription;
            column.Width = 0x74;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnn.nn";
            column.PromptChar = ' ';
            column.Format = "F2";
            column.CellAppearance = appearance;
            column.Hidden = true;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.OSINVBROJDescription;
            column14.Width = 0x77;
            appearance14.TextHAlign = HAlign.Right;
            column14.MaskInput = "{LOC}-nnnnnnnnnnnn";
            column14.PromptChar = ' ';
            column14.Format = "";
            column14.CellAppearance = appearance14;
            column14.Hidden = true;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.OSIDOSDOKUMENTDescription;
            column13.Width = 0x48;
            column13.Format = "";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.OSOSBROJDOKUMENTADescription;
            column16.Width = 0x33;
            appearance16.TextHAlign = HAlign.Right;
            column16.MaskInput = "{LOC}-nnnnn";
            column16.PromptChar = ' ';
            column16.Format = "";
            column16.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.NoEdit;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.OSOSDATUMDOKDescription;
            column17.Width = 100;
            column17.MinValue = DateTime.MinValue;
            column17.MaxValue = DateTime.MaxValue;
            column17.Format = "d";
            column17.CellAppearance = appearance17;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column19.CellActivation = Activation.NoEdit;
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.OSOSKOLICINADescription;
            column19.Width = 0x66;
            appearance19.TextHAlign = HAlign.Right;
            column19.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column19.PromptChar = ' ';
            column19.Format = "F2";
            column19.CellAppearance = appearance19;
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            column23.CellActivation = Activation.NoEdit;
            column23.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column23.Header.Caption = StringResources.OSOSSTOPADescription;
            column23.Width = 0x37;
            appearance23.TextHAlign = HAlign.Right;
            column23.MaskInput = "{LOC}-nnn.nn";
            column23.PromptChar = ' ';
            column23.Format = "F2";
            column23.CellAppearance = appearance23;
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            column21.CellActivation = Activation.NoEdit;
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.OSOSOSNOVICADescription;
            column21.Width = 0x66;
            appearance21.TextHAlign = HAlign.Right;
            column21.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column21.PromptChar = ' ';
            column21.Format = "F2";
            column21.CellAppearance = appearance21;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column18.CellActivation = Activation.NoEdit;
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.OSOSDUGUJEDescription;
            column18.Width = 0x66;
            appearance18.TextHAlign = HAlign.Right;
            column18.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column18.PromptChar = ' ';
            column18.Format = "F2";
            column18.CellAppearance = appearance18;
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            column22.CellActivation = Activation.NoEdit;
            column22.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column22.Header.Caption = StringResources.OSOSPOTRAZUJEDescription;
            column22.Width = 0x66;
            appearance22.TextHAlign = HAlign.Right;
            column22.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column22.PromptChar = ' ';
            column22.Format = "F2";
            column22.CellAppearance = appearance22;
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            column24.CellActivation = Activation.NoEdit;
            column24.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column24.Header.Caption = StringResources.OSRASHODLOKACIJEIDLOKACIJEDescription;
            column24.Width = 0x48;
            column24.Format = "";
            column24.CellAppearance = appearance24;
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            column20.CellActivation = Activation.NoEdit;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.OSOSOPISDescription;
            column20.Width = 0x128;
            column20.Format = "";
            column20.CellAppearance = appearance20;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.OSNAZIVOSDOKUMENTDescription;
            column15.Width = 0xe2;
            column15.Format = "";
            column15.CellAppearance = appearance15;
            column15.Hidden = true;
            band2.Columns.Add(column14);
            column14.Header.VisiblePosition = 0;
            band2.Columns.Add(column13);
            column13.Header.VisiblePosition = 1;
            band2.Columns.Add(column16);
            column16.Header.VisiblePosition = 2;
            band2.Columns.Add(column17);
            column17.Header.VisiblePosition = 3;
            band2.Columns.Add(column19);
            column19.Header.VisiblePosition = 4;
            band2.Columns.Add(column23);
            column23.Header.VisiblePosition = 5;
            band2.Columns.Add(column21);
            column21.Header.VisiblePosition = 6;
            band2.Columns.Add(column18);
            column18.Header.VisiblePosition = 7;
            band2.Columns.Add(column22);
            column22.Header.VisiblePosition = 8;
            band2.Columns.Add(column24);
            column24.Header.VisiblePosition = 9;
            band2.Columns.Add(column20);
            column20.Header.VisiblePosition = 10;
            band2.Columns.Add(column15);
            column15.Header.VisiblePosition = 11;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 0;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 1;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 2;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 3;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 4;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 5;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 6;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 7;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 8;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 9;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 10;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 11;
            this.userControlDataGridOS.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridOS.Location = point;
            this.userControlDataGridOS.Name = "userControlDataGridOS";
            this.userControlDataGridOS.Tag = "OS";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridOS.Size = size;
            this.userControlDataGridOS.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridOS.Dock = DockStyle.Fill;
            this.userControlDataGridOS.FillAtStartup = false;
            this.userControlDataGridOS.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridOS.InitializeRow += new InitializeRowEventHandler(this.OSUserDataGrid_InitializeRow);
            this.userControlDataGridOS.DisplayLayout.BandsSerializer.Add(band);
            this.userControlDataGridOS.DisplayLayout.BandsSerializer.Add(band2);
            this.Controls.AddRange(new Control[] { this.userControlDataGridOS });
            this.Name = "OSUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.OSUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridOS).EndInit();
            this.ResumeLayout(false);
        }

        private void OSUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void OSUserDataGrid_Load(object sender, EventArgs e)
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
            DataSet dataSet = new OSVRSTADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetOSVRSTADataAdapter().Fill(dataSet);
            }
            System.Data.DataView dataList = new System.Data.DataView(dataSet.Tables["OSVRSTA"]) {
                Sort = "OSV"
            };
            CreateValueList(this.DataGrid, "OSVRSTAIDOSVRSTA", dataList, "IDOSVRSTA", "OSV");
            UltraGridColumn column2 = this.DataGrid.DisplayLayout.Bands["OS"].Columns["IDOSVRSTA"];
            column2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column2.ValueList = this.DataGrid.DisplayLayout.ValueLists["OSVRSTAIDOSVRSTA"];
            if (setColumnsWidth)
            {
                column2.Width = 0x145;
            }
            DataSet set = new AMSKUPINEDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetAMSKUPINEDataAdapter().Fill(set);
            }
            System.Data.DataView view = new System.Data.DataView(set.Tables["AMSKUPINE"]) {
                Sort = "AM"
            };
            CreateValueList(this.DataGrid, "AMSKUPINEIDAMSKUPINE", view, "IDAMSKUPINE", "AM");
            UltraGridColumn column = this.DataGrid.DisplayLayout.Bands["OS"].Columns["IDAMSKUPINE"];
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column.ValueList = this.DataGrid.DisplayLayout.ValueLists["AMSKUPINEIDAMSKUPINE"];
            if (setColumnsWidth)
            {
                column.Width = 370;
            }
            DataSet set3 = new OSDOKUMENTDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetOSDOKUMENTDataAdapter().Fill(set3);
            }
            System.Data.DataView view3 = new System.Data.DataView(set3.Tables["OSDOKUMENT"]) {
                Sort = "OSDK"
            };
            CreateValueList(this.DataGrid, "OSDOKUMENTIDOSDOKUMENT", view3, "IDOSDOKUMENT", "OSDK");
            UltraGridColumn column3 = this.DataGrid.DisplayLayout.Bands["OS_OSTEMELJNICA"].Columns["IDOSDOKUMENT"];
            column3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column3.ValueList = this.DataGrid.DisplayLayout.ValueLists["OSDOKUMENTIDOSDOKUMENT"];
            if (setColumnsWidth)
            {
                column3.Width = 370;
            }
            DataSet set4 = new LOKACIJEDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetLOKACIJEDataAdapter().Fill(set4);
            }
            System.Data.DataView view4 = new System.Data.DataView(set4.Tables["LOKACIJE"]) {
                Sort = "LOK"
            };
            CreateValueList(this.DataGrid, "LOKACIJERASHODLOKACIJEIDLOKACIJE", view4, "IDLOKACIJE", "LOK");
            UltraGridColumn column4 = this.DataGrid.DisplayLayout.Bands["OS_OSTEMELJNICA"].Columns["RASHODLOKACIJEIDLOKACIJE"];
            column4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column4.ValueList = this.DataGrid.DisplayLayout.ValueLists["LOKACIJERASHODLOKACIJEIDLOKACIJE"];
            if (setColumnsWidth)
            {
                column4.Width = 370;
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
        public virtual OSDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridOS;
            }
            set
            {
                this.userControlDataGridOS = value;
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

        [Category("Deklarit Work With ")]
        public virtual int FillByIDAMSKUPINEIDAMSKUPINE
        {
            get
            {
                return this.DataGrid.FillByIDAMSKUPINEIDAMSKUPINE;
            }
            set
            {
                this.DataGrid.FillByIDAMSKUPINEIDAMSKUPINE = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByIDOSVRSTAIDOSVRSTA
        {
            get
            {
                return this.DataGrid.FillByIDOSVRSTAIDOSVRSTA;
            }
            set
            {
                this.DataGrid.FillByIDOSVRSTAIDOSVRSTA = value;
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


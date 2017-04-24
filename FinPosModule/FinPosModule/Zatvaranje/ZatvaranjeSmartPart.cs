using Deklarit.Practices.CompositeUI;
using Deklarit.Resources;
using FinPosModule.Otvorene;
using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinGrid;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using mipsed.application.framework;
using Placa;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;


namespace FinPosModule.Zatvaranje
{

    [SmartPart]
    public class ZatvaranjeSmartPart : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private IContainer components;
        private int godina;
        private SmartPartInfoProvider infoProvider;
        private bool m_bDisablePosCHange;
        
        private DateTime pocetni;
        private SmartPartInfo smartPartInfo1;
        private DateTime zavrsni;

        public ZatvaranjeSmartPart()
        {
            base.Load += new EventHandler(this.frmZatvaranjeStavaka_Load);
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(string.Format("Zatvaranje stavaka-saldakonti", "Zatvaranje stavaka"), string.Format(Deklarit.Resources.Resources.WorkWithTitle, "Zatvaranje stavaka"));
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void __CurrencyManager_PositionChanged(object sender, EventArgs e)
        {
            if (!this.m_bDisablePosCHange && (this.__CurrencyManager.Count > 0))
            {
                object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(this.__CurrencyManager.Current, new object[] { "idpartner" }, null));
                this.Ucitaj_Izmjene(Conversions.ToInteger(objectValue));
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

        private void frmZatvaranjeStavaka_Load(object sender, EventArgs e)
        {
            this.pocetni = mipsed.application.framework.Application.Pocetni;
            this.zavrsni = mipsed.application.framework.Application.Zavrsni;
            this.__CurrencyManager = (CurrencyManager) this.BindingContext[this.S_FIN_PARTNERI_SA_OTVORENIMADataSet1, "S_FIN_PARTNERI_SA_OTVORENIMA"];
            this.__CurrencyManager.PositionChanged += new EventHandler(this.__CurrencyManager_PositionChanged);
            this.__CurrencyManager_PositionChanged(null, null);
            this.godina = mipsed.application.framework.Application.ActiveYear;
            new S_FIN_PARTNERI_SA_OTVORENIMADataAdapter().Fill(this.S_FIN_PARTNERI_SA_OTVORENIMADataSet1, this.godina);
            this.UltraGrid1.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            this.m_bDisablePosCHange = false;
            this.DatasetKarticeGroup1.EnforceConstraints = false;
            this.DatasetKarticeGroup2.EnforceConstraints = false;
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            UltraGridBand band = new UltraGridBand("S_FIN_PARTNERI_SA_OTVORENIMA", -1);
            UltraGridColumn column = new UltraGridColumn("IDPARTNER");
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            UltraGridColumn column12 = new UltraGridColumn("NAZIVPARTNER");
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            UltraGridColumn column23 = new UltraGridColumn("PARTNERMJESTO");
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            UltraGridBand band2 = new UltraGridBand("GKSTAVKA", -1);
            UltraGridColumn column34 = new UltraGridColumn("duguje");
            UltraGridColumn column45 = new UltraGridColumn("POTRAZUJE");
            UltraGridColumn column52 = new UltraGridColumn("KONTO");
            UltraGridColumn column53 = new UltraGridColumn("DATUMDVO");
            UltraGridColumn column54 = new UltraGridColumn("DATUMVALUTE");
            UltraGridColumn column55 = new UltraGridColumn("DATUMDOK");
            UltraGridColumn column2 = new UltraGridColumn("SKRACENI");
            UltraGridColumn column3 = new UltraGridColumn("BROJDOK");
            UltraGridColumn column4 = new UltraGridColumn("BROJSTAVKE");
            UltraGridColumn column5 = new UltraGridColumn("opisknjizenja");
            UltraGridColumn column6 = new UltraGridColumn("IDPARTNER");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            UltraGridColumn column7 = new UltraGridColumn("OTVORENO");
            UltraGridColumn column8 = new UltraGridColumn("naziv");
            UltraGridColumn column9 = new UltraGridColumn("ID_DOKUMENT");
            UltraGridColumn column10 = new UltraGridColumn("NAZIVPARTNER");
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            UltraGridColumn column11 = new UltraGridColumn("IDORGJED");
            UltraGridColumn column13 = new UltraGridColumn("IDMJESTOTROSKA");
            UltraGridColumn column14 = new UltraGridColumn("MB");
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            UltraGridColumn column15 = new UltraGridColumn("partnermjesto");
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            UltraGridColumn column16 = new UltraGridColumn("partnerulica", -1, null, 0, SortIndicator.Ascending, false);
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            UltraGridColumn column17 = new UltraGridColumn("IME");
            UltraGridColumn column18 = new UltraGridColumn("IDDJELATNIK");
            UltraGridColumn column19 = new UltraGridColumn("BROJDANA");
            UltraGridColumn column20 = new UltraGridColumn("idgkstavka");
            UltraGridColumn column21 = new UltraGridColumn("ORIGINALNIDOKUMENT");
            UltraGridColumn column22 = new UltraGridColumn("GODINA");
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            UltraGridBand band3 = new UltraGridBand("GKSTAVKA", -1);
            UltraGridColumn column24 = new UltraGridColumn("duguje");
            UltraGridColumn column25 = new UltraGridColumn("POTRAZUJE");
            UltraGridColumn column26 = new UltraGridColumn("KONTO");
            UltraGridColumn column27 = new UltraGridColumn("DATUMDVO");
            UltraGridColumn column28 = new UltraGridColumn("DATUMVALUTE");
            UltraGridColumn column29 = new UltraGridColumn("DATUMDOK");
            UltraGridColumn column30 = new UltraGridColumn("SKRACENI", -1, null, 0, SortIndicator.Ascending, false);
            UltraGridColumn column31 = new UltraGridColumn("BROJDOK");
            UltraGridColumn column32 = new UltraGridColumn("BROJSTAVKE");
            UltraGridColumn column33 = new UltraGridColumn("opisknjizenja");
            UltraGridColumn column35 = new UltraGridColumn("IDPARTNER");
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            UltraGridColumn column36 = new UltraGridColumn("OTVORENO");
            UltraGridColumn column37 = new UltraGridColumn("naziv");
            UltraGridColumn column38 = new UltraGridColumn("ID_DOKUMENT");
            UltraGridColumn column39 = new UltraGridColumn("NAZIVPARTNER");
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            UltraGridColumn column40 = new UltraGridColumn("IDORGJED");
            UltraGridColumn column41 = new UltraGridColumn("IDMJESTOTROSKA");
            UltraGridColumn column42 = new UltraGridColumn("MB");
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            UltraGridColumn column43 = new UltraGridColumn("partnermjesto");
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            UltraGridColumn column44 = new UltraGridColumn("partnerulica");
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            UltraGridColumn column46 = new UltraGridColumn("IME");
            UltraGridColumn column47 = new UltraGridColumn("IDDJELATNIK");
            UltraGridColumn column48 = new UltraGridColumn("BROJDANA");
            UltraGridColumn column49 = new UltraGridColumn("idgkstavka");
            UltraGridColumn column50 = new UltraGridColumn("ORIGINALNIDOKUMENT");
            UltraGridColumn column51 = new UltraGridColumn("GODINA");
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            DockAreaPane pane4 = new DockAreaPane(DockedLocation.DockedTop, new Guid("f64c8934-9c81-41f7-840f-24e421682a0a"));
            DockableControlPane pane = new DockableControlPane(new Guid("0db78542-90ec-4eb5-b4c4-4bf2fae07200"), new Guid("00000000-0000-0000-0000-000000000000"), -1, new Guid("f64c8934-9c81-41f7-840f-24e421682a0a"), -1);
            DockAreaPane pane5 = new DockAreaPane(DockedLocation.DockedTop, new Guid("528d4c1a-7987-4b37-b34f-f5fde8035773"));
            DockableControlPane pane2 = new DockableControlPane(new Guid("9e579f48-8793-4443-9aac-98866ea09369"), new Guid("00000000-0000-0000-0000-000000000000"), -1, new Guid("528d4c1a-7987-4b37-b34f-f5fde8035773"), -1);
            DockAreaPane pane6 = new DockAreaPane(DockedLocation.DockedTop, new Guid("15cae44f-8436-492a-ab07-401b39090ece"));
            DockableControlPane pane3 = new DockableControlPane(new Guid("5a766225-74c9-42df-8033-358ed313fe58"), new Guid("00000000-0000-0000-0000-000000000000"), -1, new Guid("15cae44f-8436-492a-ab07-401b39090ece"), -1);
            this.GroupBox1 = new GroupBox();
            this.UltraGrid1 = new UltraGrid();
            this.S_FIN_PARTNERI_SA_OTVORENIMADataSet1 = new S_FIN_PARTNERI_SA_OTVORENIMADataSet();
            this.UltraGroupBox1 = new UltraGroupBox();
            this.UltraGrid2 = new UltraGrid();
            this.DatasetKarticeGroup1 = new S_FIN_OTVORENE_STAVKEDataSet();
            this.UltraGroupBox2 = new UltraGroupBox();
            this.UltraGrid3 = new UltraGrid();
            this.DatasetKarticeGroup2 = new S_FIN_OTVORENE_STAVKEDataSet();
            this.PartnerDataSet1 = new PARTNERDataSet();
            this.btnIspis = new UltraButton();
            this.ZatvaranjeSmartPart_Fill_Panel = new Panel();
            this.UltraDockManager1 = new UltraDockManager(this.components);
            this._ZatvaranjeSmartPartUnpinnedTabAreaLeft = new UnpinnedTabArea();
            this._ZatvaranjeSmartPartUnpinnedTabAreaRight = new UnpinnedTabArea();
            this._ZatvaranjeSmartPartUnpinnedTabAreaTop = new UnpinnedTabArea();
            this._ZatvaranjeSmartPartUnpinnedTabAreaBottom = new UnpinnedTabArea();
            this._ZatvaranjeSmartPartAutoHideControl = new AutoHideControl();
            this.WindowDockingArea1 = new WindowDockingArea();
            this.DockableWindow1 = new DockableWindow();
            this.WindowDockingArea2 = new WindowDockingArea();
            this.DockableWindow2 = new DockableWindow();
            this.WindowDockingArea3 = new WindowDockingArea();
            this.DockableWindow3 = new DockableWindow();
            this.GroupBox1.SuspendLayout();
            ((ISupportInitialize) this.UltraGrid1).BeginInit();
            this.S_FIN_PARTNERI_SA_OTVORENIMADataSet1.BeginInit();
            ((ISupportInitialize) this.UltraGroupBox1).BeginInit();
            this.UltraGroupBox1.SuspendLayout();
            ((ISupportInitialize) this.UltraGrid2).BeginInit();
            this.DatasetKarticeGroup1.BeginInit();
            ((ISupportInitialize) this.UltraGroupBox2).BeginInit();
            this.UltraGroupBox2.SuspendLayout();
            ((ISupportInitialize) this.UltraGrid3).BeginInit();
            this.DatasetKarticeGroup2.BeginInit();
            this.PartnerDataSet1.BeginInit();
            this.ZatvaranjeSmartPart_Fill_Panel.SuspendLayout();
            ((ISupportInitialize) this.UltraDockManager1).BeginInit();
            this.WindowDockingArea1.SuspendLayout();
            this.DockableWindow1.SuspendLayout();
            this.WindowDockingArea2.SuspendLayout();
            this.DockableWindow2.SuspendLayout();
            this.WindowDockingArea3.SuspendLayout();
            this.DockableWindow3.SuspendLayout();
            this.SuspendLayout();
            this.GroupBox1.Controls.Add(this.UltraGrid1);
            this.GroupBox1.Location = new System.Drawing.Point(0, 20);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(0x4b7, 0xee);
            this.GroupBox1.TabIndex = 0x38;
            this.GroupBox1.TabStop = false;
            this.UltraGrid1.DataMember = "S_FIN_PARTNERI_SA_OTVORENIMA";
            this.UltraGrid1.DataSource = this.S_FIN_PARTNERI_SA_OTVORENIMADataSet1;
            appearance19.BackColor = System.Drawing.SystemColors.Control;
            appearance19.ForeColor = Color.MidnightBlue;
            appearance19.TextHAlignAsString = "Left";
            this.UltraGrid1.DisplayLayout.Appearance = appearance19;
            this.UltraGrid1.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            column.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.CellActivation = Activation.NoEdit;
            appearance.ForeColorDisabled = Color.MidnightBlue;
            appearance.TextHAlignAsString = "Right";
            column.CellAppearance = appearance;
            column.Format = "";
            appearance12.BackColor = Color.MidnightBlue;
            appearance12.ForeColor = Color.WhiteSmoke;
            appearance12.ThemedElementAlpha = Alpha.Transparent;
            column.Header.Appearance = appearance12;
            column.Header.Caption = "Šif.part";
            column.Header.VisiblePosition = 0;
            column.MaskInput = "{LOC}-nnnnnnn";
            column.PromptChar = ' ';
            column.Width = 0x6b;
            column12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.CellActivation = Activation.NoEdit;
            appearance23.ForeColorDisabled = Color.MidnightBlue;
            column12.CellAppearance = appearance23;
            column12.Format = "";
            appearance34.BackColor = Color.MidnightBlue;
            appearance34.ForeColor = Color.WhiteSmoke;
            appearance34.ThemedElementAlpha = Alpha.Transparent;
            column12.Header.Appearance = appearance34;
            column12.Header.Caption = "Partner";
            column12.Header.VisiblePosition = 1;
            column12.Width = 0x1be;
            column23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column23.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column23.CellActivation = Activation.NoEdit;
            appearance42.ForeColorDisabled = Color.MidnightBlue;
            column23.CellAppearance = appearance42;
            column23.Format = "";
            appearance44.BackColor = Color.MidnightBlue;
            appearance44.ForeColor = Color.WhiteSmoke;
            appearance44.ThemedElementAlpha = Alpha.Transparent;
            column23.Header.Appearance = appearance44;
            column23.Header.Caption = "Part. mjesto";
            column23.Header.VisiblePosition = 2;
            column23.Width = 0x275;
            band.Columns.AddRange(new object[] { column, column12, column23 });
            appearance46.FontData.BoldAsString = "True";
            appearance46.FontData.Name = "Tahoma";
            appearance46.FontData.SizeInPoints = 9f;
            appearance46.ForeColor = Color.WhiteSmoke;
            band.Header.Appearance = appearance46;
            appearance47.BackColor = Color.MidnightBlue;
            appearance47.ForeColor = Color.WhiteSmoke;
            band.Override.HeaderAppearance = appearance47;
            appearance2.BackColor = Color.Lavender;
            band.Override.RowAlternateAppearance = appearance2;
            appearance3.BorderColor = Color.DarkGray;
            band.Override.RowAppearance = appearance3;
            appearance4.BackColor = Color.CadetBlue;
            appearance4.ForeColor = Color.WhiteSmoke;
            band.Override.SelectedRowAppearance = appearance4;
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(band);
            this.UltraGrid1.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            appearance37.BackColor = Color.LightSteelBlue;
            appearance37.ForeColor = Color.MidnightBlue;
            appearance37.ThemedElementAlpha = Alpha.Transparent;
            this.UltraGrid1.DisplayLayout.CaptionAppearance = appearance37;
            this.UltraGrid1.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.UltraGrid1.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.UltraGrid1.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.UltraGrid1.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.UltraGrid1.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow;
            this.UltraGrid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.UltraGrid1.Dock = DockStyle.Fill;
            this.UltraGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.UltraGrid1.Location = new System.Drawing.Point(3, 0x10);
            this.UltraGrid1.Name = "UltraGrid1";
            this.UltraGrid1.Size = new System.Drawing.Size(0x4b1, 0xdb);
            this.UltraGrid1.TabIndex = 0x37;
            this.UltraGrid1.UseAppStyling = false;
            this.UltraGrid1.UseOsThemes = DefaultableBoolean.False;
            this.S_FIN_PARTNERI_SA_OTVORENIMADataSet1.DataSetName = "S_FIN_PARTNERI_SA_OTVORENIMADataSet";
            this.UltraGroupBox1.Controls.Add(this.UltraGrid2);
            this.UltraGroupBox1.Dock = DockStyle.Bottom;
            this.UltraGroupBox1.Location = new System.Drawing.Point(0, 20);
            this.UltraGroupBox1.Name = "UltraGroupBox1";
            this.UltraGroupBox1.Size = new System.Drawing.Size(0x4b7, 0xe9);
            this.UltraGroupBox1.TabIndex = 0x39;
            this.UltraGrid2.DataSource = this.DatasetKarticeGroup1.S_FIN_OTVORENE_STAVKE;
            appearance48.BackColor = Color.WhiteSmoke;
            appearance48.ForeColor = Color.MidnightBlue;
            appearance48.TextHAlignAsString = "Left";
            this.UltraGrid2.DisplayLayout.Appearance = appearance48;
            this.UltraGrid2.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            column34.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column34.CellActivation = Activation.NoEdit;
            column34.Format = "#,##0.00";
            column34.Header.Caption = "Duguje";
            column34.Header.VisiblePosition = 5;
            column34.Width = 0x52;
            column45.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column45.CellActivation = Activation.NoEdit;
            column45.Format = "#,##0.00";
            column45.Header.Caption = "Potražuje";
            column45.Header.VisiblePosition = 6;
            column45.Width = 0x61;
            column52.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column52.CellActivation = Activation.NoEdit;
            column52.Header.Caption = "Konto";
            column52.Header.VisiblePosition = 4;
            column52.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(0x60, 0);
            column52.Width = 0x5c;
            column53.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column53.CellActivation = Activation.NoEdit;
            column53.Header.Caption = "dtPocetni";
            column53.Header.VisiblePosition = 8;
            column53.Width = 0x9d;
            column54.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column54.CellActivation = Activation.NoEdit;
            column54.Header.Caption = "dtZavrsni";
            column54.Header.VisiblePosition = 10;
            column54.Width = 0x9f;
            column55.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column55.CellActivation = Activation.NoEdit;
            column55.Header.Caption = "Dat.dok.";
            column55.Header.VisiblePosition = 3;
            column55.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(70, 0);
            column55.Width = 0x55;
            column2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column2.CellActivation = Activation.NoEdit;
            column2.Header.Caption = "Dokument";
            column2.Header.VisiblePosition = 0;
            column2.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(0x40, 0);
            column2.Width = 0x5e;
            column3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column3.CellActivation = Activation.NoEdit;
            column3.Header.Caption = "Broj";
            column3.Header.VisiblePosition = 1;
            column3.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(0x30, 0);
            column3.Width = 0x6c;
            column4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column4.CellActivation = Activation.NoEdit;
            column4.Header.Caption = "Stavka";
            column4.Header.VisiblePosition = 2;
            column4.Hidden = true;
            column4.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(0x2b, 0);
            column4.Width = 0x2c;
            column5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column5.CellActivation = Activation.NoEdit;
            column5.Header.Caption = "Opis";
            column5.Header.VisiblePosition = 12;
            column5.Width = 0xac;
            column6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.CellActivation = Activation.NoEdit;
            appearance5.ForeColorDisabled = Color.MidnightBlue;
            appearance5.TextHAlignAsString = "Right";
            column6.CellAppearance = appearance5;
            column6.Format = "";
            appearance6.BackColor = Color.MidnightBlue;
            appearance6.ForeColor = Color.WhiteSmoke;
            appearance6.ThemedElementAlpha = Alpha.Transparent;
            column6.Header.Appearance = appearance6;
            column6.Header.Caption = "Šif.part";
            column6.Header.VisiblePosition = 13;
            column6.Hidden = true;
            column6.MaskInput = "{LOC}-nnnnnnn";
            column6.PromptChar = ' ';
            column6.Width = 0x23;
            column7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column7.CellActivation = Activation.NoEdit;
            column7.Format = "#,##0.00";
            column7.Header.Caption = "Otv.iznos";
            column7.Header.VisiblePosition = 7;
            column7.Width = 0x88;
            column8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column8.Header.VisiblePosition = 0x10;
            column8.Hidden = true;
            column9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column9.Header.VisiblePosition = 0x11;
            column9.Hidden = true;
            column10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.CellActivation = Activation.NoEdit;
            appearance7.ForeColorDisabled = Color.MidnightBlue;
            column10.CellAppearance = appearance7;
            column10.Format = "";
            appearance8.BackColor = Color.MidnightBlue;
            appearance8.ForeColor = Color.WhiteSmoke;
            appearance8.ThemedElementAlpha = Alpha.Transparent;
            column10.Header.Appearance = appearance8;
            column10.Header.Caption = "Partner";
            column10.Header.VisiblePosition = 14;
            column10.Hidden = true;
            column10.Width = 0x77;
            column11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column11.Header.VisiblePosition = 0x12;
            column11.Hidden = true;
            column13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column13.Header.VisiblePosition = 0x13;
            column13.Hidden = true;
            column14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.CellActivation = Activation.NoEdit;
            appearance9.ForeColorDisabled = Color.MidnightBlue;
            column14.CellAppearance = appearance9;
            column14.Format = "";
            appearance10.BackColor = Color.MidnightBlue;
            appearance10.ForeColor = Color.WhiteSmoke;
            appearance10.ThemedElementAlpha = Alpha.Transparent;
            column14.Header.Appearance = appearance10;
            column14.Header.VisiblePosition = 15;
            column14.Hidden = true;
            column14.Width = 0x62;
            column15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.CellActivation = Activation.NoEdit;
            appearance11.ForeColorDisabled = Color.MidnightBlue;
            column15.CellAppearance = appearance11;
            column15.Format = "";
            appearance13.BackColor = Color.MidnightBlue;
            appearance13.ForeColor = Color.WhiteSmoke;
            appearance13.ThemedElementAlpha = Alpha.Transparent;
            column15.Header.Appearance = appearance13;
            column15.Header.Caption = "Part. mjesto";
            column15.Header.VisiblePosition = 9;
            column15.Hidden = true;
            column15.Width = 0x95;
            column16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.CellActivation = Activation.NoEdit;
            appearance14.ForeColorDisabled = Color.MidnightBlue;
            column16.CellAppearance = appearance14;
            column16.Format = "";
            appearance15.BackColor = Color.MidnightBlue;
            appearance15.ForeColor = Color.WhiteSmoke;
            appearance15.ThemedElementAlpha = Alpha.Transparent;
            column16.Header.Appearance = appearance15;
            column16.Header.Caption = "Part.ulica";
            column16.Header.VisiblePosition = 11;
            column16.Hidden = true;
            column16.Width = 0x99;
            column17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column17.Header.VisiblePosition = 20;
            column17.Hidden = true;
            column18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column18.Header.VisiblePosition = 0x15;
            column18.Hidden = true;
            column19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column19.Header.VisiblePosition = 0x16;
            column19.Hidden = true;
            column20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column20.Header.VisiblePosition = 0x17;
            column20.Hidden = true;
            column21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column21.Header.VisiblePosition = 0x18;
            column21.Hidden = true;
            column21.Width = 0x74;
            column22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column22.Header.VisiblePosition = 0x19;
            column22.Hidden = true;
            column22.Width = 0x4f;
            band2.Columns.AddRange(new object[] { 
                column34, column45, column52, column53, column54, column55, column2, column3, column4, column5, column6, column7, column8, column9, column10, column11, 
                column13, column14, column15, column16, column17, column18, column19, column20, column21, column22
             });
            appearance16.FontData.BoldAsString = "True";
            appearance16.FontData.Name = "Tahoma";
            appearance16.FontData.SizeInPoints = 9f;
            appearance16.ForeColor = Color.WhiteSmoke;
            band2.Header.Appearance = appearance16;
            appearance17.BackColor = Color.MidnightBlue;
            appearance17.ForeColor = Color.WhiteSmoke;
            band2.Override.HeaderAppearance = appearance17;
            appearance20.BackColor = Color.Lavender;
            band2.Override.RowAlternateAppearance = appearance20;
            appearance21.BorderColor = Color.DarkGray;
            band2.Override.RowAppearance = appearance21;
            appearance22.BackColor = Color.CadetBlue;
            appearance22.ForeColor = Color.WhiteSmoke;
            band2.Override.SelectedRowAppearance = appearance22;
            this.UltraGrid2.DisplayLayout.BandsSerializer.Add(band2);
            this.UltraGrid2.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            appearance18.BackColor = Color.LightSteelBlue;
            appearance18.ForeColor = Color.MidnightBlue;
            appearance18.ThemedElementAlpha = Alpha.Transparent;
            this.UltraGrid2.DisplayLayout.CaptionAppearance = appearance18;
            this.UltraGrid2.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.UltraGrid2.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.UltraGrid2.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.UltraGrid2.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.UltraGrid2.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.UltraGrid2.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow;
            this.UltraGrid2.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.UltraGrid2.Dock = DockStyle.Fill;
            this.UltraGrid2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.UltraGrid2.Location = new System.Drawing.Point(3, 0);
            this.UltraGrid2.Name = "UltraGrid2";
            this.UltraGrid2.Size = new System.Drawing.Size(0x4b1, 230);
            this.UltraGrid2.TabIndex = 0x34;
            this.UltraGrid2.UseAppStyling = false;
            this.UltraGrid2.UseOsThemes = DefaultableBoolean.False;
            this.DatasetKarticeGroup1.DataSetName = "KarticePartnera";
            this.DatasetKarticeGroup1.Locale = new CultureInfo("en-US");
            this.DatasetKarticeGroup1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            this.UltraGroupBox2.Controls.Add(this.UltraGrid3);
            this.UltraGroupBox2.Dock = DockStyle.Fill;
            this.UltraGroupBox2.Location = new System.Drawing.Point(0, 20);
            this.UltraGroupBox2.Name = "UltraGroupBox2";
            this.UltraGroupBox2.Size = new System.Drawing.Size(0x4b7, 0xfe);
            this.UltraGroupBox2.TabIndex = 0x3a;
            this.UltraGrid3.DataSource = this.DatasetKarticeGroup2.S_FIN_OTVORENE_STAVKE;
            appearance43.BackColor = Color.WhiteSmoke;
            appearance43.ForeColor = Color.MidnightBlue;
            appearance43.TextHAlignAsString = "Left";
            this.UltraGrid3.DisplayLayout.Appearance = appearance43;
            this.UltraGrid3.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            column24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column24.CellActivation = Activation.NoEdit;
            column24.Format = "#,##0.00";
            column24.Header.Caption = "Duguje";
            column24.Header.VisiblePosition = 5;
            column24.Width = 0x5e;
            column25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column25.CellActivation = Activation.NoEdit;
            column25.Format = "#,##0.00";
            column25.Header.Caption = "Potražuje";
            column25.Header.VisiblePosition = 6;
            column25.Width = 0x4c;
            column26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column26.CellActivation = Activation.NoEdit;
            column26.Header.Caption = "Konto";
            column26.Header.VisiblePosition = 4;
            column26.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(0x60, 0);
            column26.Width = 0x4f;
            column27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column27.CellActivation = Activation.NoEdit;
            column27.Header.Caption = "dtPocetni";
            column27.Header.VisiblePosition = 8;
            column27.Width = 0x8e;
            column28.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column28.CellActivation = Activation.NoEdit;
            column28.Header.Caption = "dtZavrsni";
            column28.Header.VisiblePosition = 10;
            column28.Width = 0x8e;
            column29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column29.CellActivation = Activation.NoEdit;
            column29.Header.Caption = "Dat.dok.";
            column29.Header.VisiblePosition = 3;
            column29.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(70, 0);
            column29.Width = 0x57;
            column30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column30.CellActivation = Activation.NoEdit;
            column30.Header.Caption = "Dokument";
            column30.Header.VisiblePosition = 0;
            column30.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(0x40, 0);
            column30.Width = 230;
            column31.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column31.CellActivation = Activation.NoEdit;
            column31.Header.Caption = "Broj";
            column31.Header.VisiblePosition = 1;
            column31.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(0x30, 0);
            column31.Width = 50;
            column32.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column32.CellActivation = Activation.NoEdit;
            column32.Header.Caption = "Stavka";
            column32.Header.VisiblePosition = 2;
            column32.Hidden = true;
            column32.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(0x2b, 0);
            column32.Width = 0x1d;
            column33.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column33.CellActivation = Activation.NoEdit;
            column33.Header.Caption = "Opis";
            column33.Header.VisiblePosition = 12;
            column33.Width = 0x9c;
            column35.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column35.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column35.CellActivation = Activation.NoEdit;
            appearance24.ForeColorDisabled = Color.MidnightBlue;
            appearance24.TextHAlignAsString = "Right";
            column35.CellAppearance = appearance24;
            column35.Format = "";
            appearance25.BackColor = Color.MidnightBlue;
            appearance25.ForeColor = Color.WhiteSmoke;
            appearance25.ThemedElementAlpha = Alpha.Transparent;
            column35.Header.Appearance = appearance25;
            column35.Header.Caption = "Šif.part";
            column35.Header.VisiblePosition = 13;
            column35.Hidden = true;
            column35.MaskInput = "{LOC}-nnnnnnn";
            column35.PromptChar = ' ';
            column35.Width = 0x164;
            column36.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column36.CellActivation = Activation.NoEdit;
            column36.Format = "#,##0.00";
            column36.Header.Caption = "Otv.iznos";
            column36.Header.VisiblePosition = 7;
            column36.Width = 0x7e;
            column37.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column37.Header.VisiblePosition = 0x10;
            column37.Hidden = true;
            column38.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column38.Header.VisiblePosition = 0x11;
            column38.Hidden = true;
            column39.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column39.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column39.CellActivation = Activation.NoEdit;
            appearance26.ForeColorDisabled = Color.MidnightBlue;
            column39.CellAppearance = appearance26;
            column39.Format = "";
            appearance27.BackColor = Color.MidnightBlue;
            appearance27.ForeColor = Color.WhiteSmoke;
            appearance27.ThemedElementAlpha = Alpha.Transparent;
            column39.Header.Appearance = appearance27;
            column39.Header.Caption = "Partner";
            column39.Header.VisiblePosition = 14;
            column39.Hidden = true;
            column39.Width = 0x95;
            column40.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column40.Header.VisiblePosition = 0x12;
            column40.Hidden = true;
            column41.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column41.Header.VisiblePosition = 0x13;
            column41.Hidden = true;
            column42.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column42.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column42.CellActivation = Activation.NoEdit;
            appearance28.ForeColorDisabled = Color.MidnightBlue;
            column42.CellAppearance = appearance28;
            column42.Format = "";
            appearance29.BackColor = Color.MidnightBlue;
            appearance29.ForeColor = Color.WhiteSmoke;
            appearance29.ThemedElementAlpha = Alpha.Transparent;
            column42.Header.Appearance = appearance29;
            column42.Header.VisiblePosition = 15;
            column42.Hidden = true;
            column42.Width = 0x62;
            column43.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column43.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column43.CellActivation = Activation.NoEdit;
            appearance30.ForeColorDisabled = Color.MidnightBlue;
            column43.CellAppearance = appearance30;
            column43.Format = "";
            appearance31.BackColor = Color.MidnightBlue;
            appearance31.ForeColor = Color.WhiteSmoke;
            appearance31.ThemedElementAlpha = Alpha.Transparent;
            column43.Header.Appearance = appearance31;
            column43.Header.Caption = "Part. mjesto";
            column43.Header.VisiblePosition = 9;
            column43.Hidden = true;
            column43.Width = 0xbc;
            column44.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column44.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column44.CellActivation = Activation.NoEdit;
            appearance32.ForeColorDisabled = Color.MidnightBlue;
            column44.CellAppearance = appearance32;
            column44.Format = "";
            appearance33.BackColor = Color.MidnightBlue;
            appearance33.ForeColor = Color.WhiteSmoke;
            appearance33.ThemedElementAlpha = Alpha.Transparent;
            column44.Header.Appearance = appearance33;
            column44.Header.Caption = "Part.ulica";
            column44.Header.VisiblePosition = 11;
            column44.Hidden = true;
            column44.Width = 0xc2;
            column46.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column46.Header.VisiblePosition = 20;
            column46.Hidden = true;
            column47.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column47.Header.VisiblePosition = 0x15;
            column47.Hidden = true;
            column48.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column48.Header.VisiblePosition = 0x16;
            column48.Hidden = true;
            column49.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column49.Header.VisiblePosition = 0x17;
            column49.Hidden = true;
            column50.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column50.Header.VisiblePosition = 0x18;
            column50.Hidden = true;
            column51.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column51.Header.VisiblePosition = 0x19;
            column51.Hidden = true;
            band3.Columns.AddRange(new object[] { 
                column24, column25, column26, column27, column28, column29, column30, column31, column32, column33, column35, column36, column37, column38, column39, column40, 
                column41, column42, column43, column44, column46, column47, column48, column49, column50, column51
             });
            appearance35.FontData.BoldAsString = "True";
            appearance35.FontData.Name = "Tahoma";
            appearance35.FontData.SizeInPoints = 9f;
            appearance35.ForeColor = Color.WhiteSmoke;
            band3.Header.Appearance = appearance35;
            appearance36.BackColor = Color.MidnightBlue;
            appearance36.ForeColor = Color.WhiteSmoke;
            band3.Override.HeaderAppearance = appearance36;
            appearance39.BackColor = Color.Lavender;
            band3.Override.RowAlternateAppearance = appearance39;
            appearance40.BorderColor = Color.DarkGray;
            band3.Override.RowAppearance = appearance40;
            appearance41.BackColor = Color.CadetBlue;
            appearance41.ForeColor = Color.WhiteSmoke;
            band3.Override.SelectedRowAppearance = appearance41;
            this.UltraGrid3.DisplayLayout.BandsSerializer.Add(band3);
            this.UltraGrid3.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            appearance45.BackColor = Color.LightSteelBlue;
            appearance45.ForeColor = Color.MidnightBlue;
            appearance45.ThemedElementAlpha = Alpha.Transparent;
            this.UltraGrid3.DisplayLayout.CaptionAppearance = appearance45;
            this.UltraGrid3.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.UltraGrid3.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.UltraGrid3.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.UltraGrid3.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.UltraGrid3.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.UltraGrid3.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow;
            this.UltraGrid3.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.UltraGrid3.Dock = DockStyle.Fill;
            this.UltraGrid3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.UltraGrid3.Location = new System.Drawing.Point(3, 0);
            this.UltraGrid3.Name = "UltraGrid3";
            this.UltraGrid3.Size = new System.Drawing.Size(0x4b1, 0xfb);
            this.UltraGrid3.TabIndex = 0x35;
            this.UltraGrid3.UseAppStyling = false;
            this.UltraGrid3.UseOsThemes = DefaultableBoolean.False;
            this.DatasetKarticeGroup2.DataSetName = "KarticePartnera";
            this.DatasetKarticeGroup2.Locale = new CultureInfo("en-US");
            this.DatasetKarticeGroup2.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            this.PartnerDataSet1.DataSetName = "PARTNERDataSet";
            this.PartnerDataSet1.Locale = new CultureInfo("hr-HR");
            appearance38.ImageHAlign = HAlign.Left;
            appearance38.ImageVAlign = VAlign.Middle;
            this.btnIspis.Appearance = appearance38;
            this.btnIspis.Appearance.BackColor = Color.LightSteelBlue;
            this.btnIspis.ButtonStyle = UIElementButtonStyle.Office2003ToolbarButton;
            this.btnIspis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.btnIspis.ImageSize = new System.Drawing.Size(0, 0);
            this.btnIspis.Location = new System.Drawing.Point(0x438, 0x1eb);
            this.btnIspis.Name = "btnIspis";
            this.btnIspis.Padding = new System.Drawing.Size(2, 0);
            this.btnIspis.ShowFocusRect = false;
            this.btnIspis.ShowOutline = false;
            this.btnIspis.Size = new System.Drawing.Size(0x76, 0x1a);
            this.btnIspis.TabIndex = 0x36;
            this.btnIspis.Text = "Poveži stavke";
            this.ZatvaranjeSmartPart_Fill_Panel.Controls.Add(this.btnIspis);
            this.ZatvaranjeSmartPart_Fill_Panel.Cursor = Cursors.Default;
            this.ZatvaranjeSmartPart_Fill_Panel.Dock = DockStyle.Fill;
            this.ZatvaranjeSmartPart_Fill_Panel.Location = new System.Drawing.Point(0, 800);
            this.ZatvaranjeSmartPart_Fill_Panel.Name = "ZatvaranjeSmartPart_Fill_Panel";
            this.ZatvaranjeSmartPart_Fill_Panel.Size = new System.Drawing.Size(0x4b7, 1);
            this.ZatvaranjeSmartPart_Fill_Panel.TabIndex = 0;
            pane4.DockedBefore = new Guid("528d4c1a-7987-4b37-b34f-f5fde8035773");
            pane.Control = this.GroupBox1;
            pane.OriginalControlBounds = new Rectangle(3, 3, 0x4ab, 0x138);
            pane.Size = new System.Drawing.Size(100, 100);
            pane.Text = "Lista partnera sa otvorenim stavkama";
            pane4.Panes.AddRange(new DockablePaneBase[] { pane });
            pane4.Size = new System.Drawing.Size(0x4b7, 0x102);
            pane5.DockedBefore = new Guid("15cae44f-8436-492a-ab07-401b39090ece");
            pane2.Control = this.UltraGroupBox1;
            pane2.OriginalControlBounds = new Rectangle(0x1f, 0x16, 0x1fb, 0xcf);
            pane2.Size = new System.Drawing.Size(100, 100);
            pane2.Text = "Računi i knjižne obavijesti";
            pane5.Panes.AddRange(new DockablePaneBase[] { pane2 });
            pane5.Size = new System.Drawing.Size(0x4b7, 0xfd);
            pane6.ChildPaneStyle = ChildPaneStyle.TabGroup;
            pane3.Control = this.UltraGroupBox2;
            pane3.OriginalControlBounds = new Rectangle(0xce, 0x39, 0x1a0, 110);
            pane3.Size = new System.Drawing.Size(100, 100);
            pane3.Text = "Izvodi ";
            pane6.Panes.AddRange(new DockablePaneBase[] { pane3 });
            pane6.Size = new System.Drawing.Size(0x4b7, 0x112);
            this.UltraDockManager1.DockAreas.AddRange(new DockAreaPane[] { pane4, pane5, pane6 });
            this.UltraDockManager1.HostControl = this;
            this.UltraDockManager1.LayoutStyle = DockAreaLayoutStyle.FillContainer;
            this.UltraDockManager1.UseAppStyling = false;
            this.UltraDockManager1.WindowStyle = WindowStyle.VisualStudio2008;
            this._ZatvaranjeSmartPartUnpinnedTabAreaLeft.Dock = DockStyle.Left;
            this._ZatvaranjeSmartPartUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._ZatvaranjeSmartPartUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._ZatvaranjeSmartPartUnpinnedTabAreaLeft.Name = "_ZatvaranjeSmartPartUnpinnedTabAreaLeft";
            this._ZatvaranjeSmartPartUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            this._ZatvaranjeSmartPartUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 0x321);
            this._ZatvaranjeSmartPartUnpinnedTabAreaLeft.TabIndex = 1;
            this._ZatvaranjeSmartPartUnpinnedTabAreaRight.Dock = DockStyle.Right;
            this._ZatvaranjeSmartPartUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._ZatvaranjeSmartPartUnpinnedTabAreaRight.Location = new System.Drawing.Point(0x4b7, 0);
            this._ZatvaranjeSmartPartUnpinnedTabAreaRight.Name = "_ZatvaranjeSmartPartUnpinnedTabAreaRight";
            this._ZatvaranjeSmartPartUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this._ZatvaranjeSmartPartUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 0x321);
            this._ZatvaranjeSmartPartUnpinnedTabAreaRight.TabIndex = 2;
            this._ZatvaranjeSmartPartUnpinnedTabAreaTop.Dock = DockStyle.Top;
            this._ZatvaranjeSmartPartUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._ZatvaranjeSmartPartUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._ZatvaranjeSmartPartUnpinnedTabAreaTop.Name = "_ZatvaranjeSmartPartUnpinnedTabAreaTop";
            this._ZatvaranjeSmartPartUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this._ZatvaranjeSmartPartUnpinnedTabAreaTop.Size = new System.Drawing.Size(0x4b7, 0);
            this._ZatvaranjeSmartPartUnpinnedTabAreaTop.TabIndex = 3;
            this._ZatvaranjeSmartPartUnpinnedTabAreaBottom.Dock = DockStyle.Bottom;
            this._ZatvaranjeSmartPartUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._ZatvaranjeSmartPartUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 0x321);
            this._ZatvaranjeSmartPartUnpinnedTabAreaBottom.Name = "_ZatvaranjeSmartPartUnpinnedTabAreaBottom";
            this._ZatvaranjeSmartPartUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this._ZatvaranjeSmartPartUnpinnedTabAreaBottom.Size = new System.Drawing.Size(0x4b7, 0);
            this._ZatvaranjeSmartPartUnpinnedTabAreaBottom.TabIndex = 4;
            this._ZatvaranjeSmartPartAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._ZatvaranjeSmartPartAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._ZatvaranjeSmartPartAutoHideControl.Name = "_ZatvaranjeSmartPartAutoHideControl";
            this._ZatvaranjeSmartPartAutoHideControl.Owner = this.UltraDockManager1;
            this._ZatvaranjeSmartPartAutoHideControl.Size = new System.Drawing.Size(0, 0x321);
            this._ZatvaranjeSmartPartAutoHideControl.TabIndex = 5;
            this.WindowDockingArea1.Controls.Add(this.DockableWindow1);
            this.WindowDockingArea1.Dock = DockStyle.Top;
            this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.WindowDockingArea1.Location = new System.Drawing.Point(0, 0);
            this.WindowDockingArea1.Name = "WindowDockingArea1";
            this.WindowDockingArea1.Owner = this.UltraDockManager1;
            this.WindowDockingArea1.Size = new System.Drawing.Size(0x4b7, 0x107);
            this.WindowDockingArea1.TabIndex = 6;
            this.DockableWindow1.Controls.Add(this.GroupBox1);
            this.DockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow1.Name = "DockableWindow1";
            this.DockableWindow1.Owner = this.UltraDockManager1;
            this.DockableWindow1.Size = new System.Drawing.Size(0x4b7, 0x102);
            this.DockableWindow1.TabIndex = 9;
            this.WindowDockingArea2.Controls.Add(this.DockableWindow2);
            this.WindowDockingArea2.Dock = DockStyle.Top;
            this.WindowDockingArea2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.WindowDockingArea2.Location = new System.Drawing.Point(0, 0x107);
            this.WindowDockingArea2.Name = "WindowDockingArea2";
            this.WindowDockingArea2.Owner = this.UltraDockManager1;
            this.WindowDockingArea2.Size = new System.Drawing.Size(0x4b7, 0x102);
            this.WindowDockingArea2.TabIndex = 7;
            this.DockableWindow2.Controls.Add(this.UltraGroupBox1);
            this.DockableWindow2.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow2.Name = "DockableWindow2";
            this.DockableWindow2.Owner = this.UltraDockManager1;
            this.DockableWindow2.Size = new System.Drawing.Size(0x4b7, 0xfd);
            this.DockableWindow2.TabIndex = 10;
            this.WindowDockingArea3.Controls.Add(this.DockableWindow3);
            this.WindowDockingArea3.Dock = DockStyle.Top;
            this.WindowDockingArea3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.WindowDockingArea3.Location = new System.Drawing.Point(0, 0x209);
            this.WindowDockingArea3.Name = "WindowDockingArea3";
            this.WindowDockingArea3.Owner = this.UltraDockManager1;
            this.WindowDockingArea3.Size = new System.Drawing.Size(0x4b7, 0x117);
            this.WindowDockingArea3.TabIndex = 8;
            this.DockableWindow3.Controls.Add(this.UltraGroupBox2);
            this.DockableWindow3.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow3.Name = "DockableWindow3";
            this.DockableWindow3.Owner = this.UltraDockManager1;
            this.DockableWindow3.Size = new System.Drawing.Size(0x4b7, 0x112);
            this.DockableWindow3.TabIndex = 11;
            this.Controls.Add(this._ZatvaranjeSmartPartAutoHideControl);
            this.Controls.Add(this.ZatvaranjeSmartPart_Fill_Panel);
            this.Controls.Add(this.WindowDockingArea3);
            this.Controls.Add(this.WindowDockingArea2);
            this.Controls.Add(this.WindowDockingArea1);
            this.Controls.Add(this._ZatvaranjeSmartPartUnpinnedTabAreaTop);
            this.Controls.Add(this._ZatvaranjeSmartPartUnpinnedTabAreaBottom);
            this.Controls.Add(this._ZatvaranjeSmartPartUnpinnedTabAreaLeft);
            this.Controls.Add(this._ZatvaranjeSmartPartUnpinnedTabAreaRight);
            this.Name = "ZatvaranjeSmartPart";
            this.Size = new System.Drawing.Size(0x4b7, 0x321);


            this.UltraGrid1.InitializeLayout += new InitializeLayoutEventHandler(this.UltraGrid1_InitializeLayout);


            this.GroupBox1.ResumeLayout(false);
            ((ISupportInitialize) this.UltraGrid1).EndInit();
            this.S_FIN_PARTNERI_SA_OTVORENIMADataSet1.EndInit();
            ((ISupportInitialize) this.UltraGroupBox1).EndInit();
            this.UltraGroupBox1.ResumeLayout(false);
            ((ISupportInitialize) this.UltraGrid2).EndInit();
            this.DatasetKarticeGroup1.EndInit();
            ((ISupportInitialize) this.UltraGroupBox2).EndInit();
            this.UltraGroupBox2.ResumeLayout(false);
            ((ISupportInitialize) this.UltraGrid3).EndInit();
            this.DatasetKarticeGroup2.EndInit();
            this.PartnerDataSet1.EndInit();
            this.ZatvaranjeSmartPart_Fill_Panel.ResumeLayout(false);
            ((ISupportInitialize) this.UltraDockManager1).EndInit();
            this.WindowDockingArea1.ResumeLayout(false);
            this.DockableWindow1.ResumeLayout(false);
            this.WindowDockingArea2.ResumeLayout(false);
            this.DockableWindow2.ResumeLayout(false);
            this.WindowDockingArea3.ResumeLayout(false);
            this.DockableWindow3.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        public S_FIN_OTVORENE_STAVKEDataSet OtvoreneDugovneMinus(int IDPARTNER)
        {
            S_FIN_OTVORENE_STAVKEDataSet set2 = new S_FIN_OTVORENE_STAVKEDataSet();
            DateTime pocetni = this.pocetni;
            DateTime zavrsni = this.zavrsni;
            int oRG = -1;
            int mT = -1;
            int dOK = -1;
            int iDAKTIVNOST = -1;
            string pOCETNIKONTO = " ";
            string zAVRSNIKONTO = " ";
            int activeYear = mipsed.application.framework.Application.ActiveYear;
            string dODATNIUVJET = "DMS";
            SqlParameter[] parameterArray = new SqlParameter[12];
            S_FIN_OTVORENE_STAVKEDataSet set = new S_FIN_OTVORENE_STAVKEDataSet();
            try
            {
                new S_FIN_OTVORENE_STAVKEDataAdapter().Fill(this.DatasetKarticeGroup1, oRG, mT, dOK, pocetni, zavrsni, pOCETNIKONTO, zAVRSNIKONTO, iDAKTIVNOST, IDPARTNER, dODATNIUVJET, (short) activeYear);
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
            return set2;
        }

        public S_FIN_OTVORENE_STAVKEDataSet OtvoreneDugovnePlus(int IDPARTNER)
        {
            S_FIN_OTVORENE_STAVKEDataSet set2 = new S_FIN_OTVORENE_STAVKEDataSet();
            DateTime pocetni = this.pocetni;
            DateTime zavrsni = this.zavrsni;
            int oRG = -1;
            int mT = -1;
            int dOK = -1;
            int iDAKTIVNOST = -1;
            string pOCETNIKONTO = " ";
            string zAVRSNIKONTO = " ";
            int activeYear = mipsed.application.framework.Application.ActiveYear;
            string dODATNIUVJET = "DPS";
            SqlParameter[] parameterArray = new SqlParameter[12];
            S_FIN_OTVORENE_STAVKEDataSet set = new S_FIN_OTVORENE_STAVKEDataSet();
            try
            {
                new S_FIN_OTVORENE_STAVKEDataAdapter().Fill(this.DatasetKarticeGroup2, oRG, mT, dOK, pocetni, zavrsni, pOCETNIKONTO, zAVRSNIKONTO, iDAKTIVNOST, IDPARTNER, dODATNIUVJET, (short) activeYear);
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
            return set2;
        }

        public S_FIN_OTVORENE_STAVKEDataSet OtvorenePotrazneMinus(int IDPARTNER)
        {
            S_FIN_OTVORENE_STAVKEDataSet set2 = new S_FIN_OTVORENE_STAVKEDataSet();
            DateTime pocetni = this.pocetni;
            DateTime zavrsni = this.zavrsni;
            int oRG = -1;
            int mT = -1;
            int dOK = -1;
            int iDAKTIVNOST = -1;
            string pOCETNIKONTO = " ";
            string zAVRSNIKONTO = " ";
            int activeYear = mipsed.application.framework.Application.ActiveYear;
            string dODATNIUVJET = "PMS";
            SqlParameter[] parameterArray = new SqlParameter[12];
            S_FIN_OTVORENE_STAVKEDataSet set = new S_FIN_OTVORENE_STAVKEDataSet();
            try
            {
                new S_FIN_OTVORENE_STAVKEDataAdapter().Fill(this.DatasetKarticeGroup2, oRG, mT, dOK, pocetni, zavrsni, pOCETNIKONTO, zAVRSNIKONTO, iDAKTIVNOST, IDPARTNER, dODATNIUVJET, (short) activeYear);
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
            return set2;
        }

        public S_FIN_OTVORENE_STAVKEDataSet OtvorenePotraznePlus(int IDPARTNER)
        {
            S_FIN_OTVORENE_STAVKEDataSet set2 = new S_FIN_OTVORENE_STAVKEDataSet();
            DateTime pocetni = this.pocetni;
            DateTime zavrsni = this.zavrsni;
            int oRG = -1;
            int mT = -1;
            int dOK = -1;
            int iDAKTIVNOST = -1;
            string pOCETNIKONTO = " ";
            string zAVRSNIKONTO = " ";
            int activeYear = mipsed.application.framework.Application.ActiveYear;
            string dODATNIUVJET = "PPS";
            SqlParameter[] parameterArray = new SqlParameter[12];
            S_FIN_OTVORENE_STAVKEDataSet set = new S_FIN_OTVORENE_STAVKEDataSet();
            try
            {
                new S_FIN_OTVORENE_STAVKEDataAdapter().Fill(this.DatasetKarticeGroup1, oRG, mT, dOK, pocetni, zavrsni, pOCETNIKONTO, zAVRSNIKONTO, iDAKTIVNOST, IDPARTNER, dODATNIUVJET, (short) activeYear);
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
            return set2;
        }

        [LocalCommandHandler("PoveziStavke")]
        public void PoveziStavkeHandler(object sender, EventArgs e)
        {
            this.ZatvoriStavke();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!((msg.Msg == 0x100) | (msg.Msg == 260)))
            {
                bool flag = false;
                return flag;
            }
            switch (keyData)
            {
                case Keys.F1:
                    this.UltraGrid2.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
                    this.UltraGrid1.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
                    this.UltraGrid3.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
                    return true;

                case Keys.Return:
                    SendKeys.Send("{TAB}");
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SetSmartPartInfoInformation()
        {
            this.smartPartInfo1.Description = "Zatvaranje stavaka saldakonti";
        }

        public void Ucitaj_Izmjene(int brojpart)
        {
            this.DatasetKarticeGroup1.S_FIN_OTVORENE_STAVKE.Clear();
            this.DatasetKarticeGroup2.S_FIN_OTVORENE_STAVKE.Clear();
            this.OtvorenePotraznePlus(brojpart);
            this.OtvoreneDugovneMinus(brojpart);
            this.OtvorenePotrazneMinus(brojpart);
            this.OtvoreneDugovnePlus(brojpart);
            this.UltraGrid2.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            this.UltraGrid3.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
        }

        private void UltraGrid1_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
        }

        private void UltraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private void UltraTextEditor1_ValueChanged(object sender, EventArgs e)
        {
        }

        public void ZatvoriStavke()
        {
            SqlConnection connection = new SqlConnection();
            if (!((this.BindingContext[this.DatasetKarticeGroup1.S_FIN_OTVORENE_STAVKE].Count == 0) | (this.BindingContext[this.DatasetKarticeGroup2.S_FIN_OTVORENE_STAVKE].Count == 0)))
            {
                DataRowView current = (DataRowView) this.BindingContext[this.DatasetKarticeGroup1.S_FIN_OTVORENE_STAVKE].Current;
                DataRowView view2 = (DataRowView) this.BindingContext[this.DatasetKarticeGroup2.S_FIN_OTVORENE_STAVKE].Current;
                if (Operators.ConditionalCompareObjectEqual(current["KONTO"], view2["KONTO"], false))
                {
                    using (frmIznosZatvaranjaForma forma = new frmIznosZatvaranjaForma())
                    {
                        if (Operators.ConditionalCompareObjectGreater(current["OTVORENO"], view2["otvoreno"], false))
                        {
                            forma.Iznos.MaxValue = RuntimeHelpers.GetObjectValue(view2["otvoreno"]);
                            forma.Iznos.Value = RuntimeHelpers.GetObjectValue(view2["otvoreno"]);
                        }
                        else
                        {
                            forma.Iznos.MaxValue = RuntimeHelpers.GetObjectValue(current["otvoreno"]);
                            forma.Iznos.Value = RuntimeHelpers.GetObjectValue(current["otvoreno"]);
                        }
                        forma.ShowDialog();
                        SqlCommand command2 = new SqlCommand {
                            CommandType = CommandType.Text,
                            Connection = connection,
                            CommandText = "INSERT INTO ZATVARANJA (gk1idgkstavka,gk2idgkstavka,zatvaranjaIZNOS) VALUES (@gk1idgkstavka,@gk2idgkstavka,@zatvaranjaiznos)"
                        };
                        SqlCommand command = command2;
                        connection.ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString;
                        command.Parameters.Add("@zatvaranjaIZNOS", SqlDbType.Money).Value = RuntimeHelpers.GetObjectValue(forma.UneseniIznos);
                        command.Parameters.Add("@gk1idgkstavka", SqlDbType.BigInt).Value = RuntimeHelpers.GetObjectValue(current["IDGKSTAVKA"]);
                        command.Parameters.Add("@gk2idgkstavka", SqlDbType.BigInt).Value = RuntimeHelpers.GetObjectValue(view2["IDGKSTAVKA"]);
                        connection.Open();
                        try
                        {
                            command.ExecuteNonQuery();
                            if ((this.UltraGrid1.ActiveRow != null) & (this.UltraGrid1.ActiveRow.Cells["idpartner"].Value != DBNull.Value))
                            {
                                object objectValue = RuntimeHelpers.GetObjectValue(this.UltraGrid1.ActiveRow.Cells["idpartner"].Value);
                                this.Ucitaj_Izmjene(Conversions.ToInteger(objectValue));
                            }
                        }
                        catch (System.Exception exception1)
                        {
                            throw exception1;
                        }
                    }
                }
                else
                {
                    Interaction.MsgBox("Stavke nije moguće povezati zbog različitog konta!", MsgBoxStyle.Information, "Financijsko poslovanje");
                }
            }
        }

        private CurrencyManager __CurrencyManager;

        private AutoHideControl _ZatvaranjeSmartPartAutoHideControl;

        private UnpinnedTabArea _ZatvaranjeSmartPartUnpinnedTabAreaBottom;

        private UnpinnedTabArea _ZatvaranjeSmartPartUnpinnedTabAreaLeft;

        private UnpinnedTabArea _ZatvaranjeSmartPartUnpinnedTabAreaRight;

        private UnpinnedTabArea _ZatvaranjeSmartPartUnpinnedTabAreaTop;

        private UltraButton btnIspis;

        [CreateNew]
        public Microsoft.Practices.CompositeUI.Controller Controller { get; set; }

        private S_FIN_OTVORENE_STAVKEDataSet DatasetKarticeGroup1;

        private S_FIN_OTVORENE_STAVKEDataSet DatasetKarticeGroup2;

        DataRow Deklarit.Practices.CompositeUI.IFilteredView.FillByRow
        {
            set
            {
            }
        }

        string Deklarit.Practices.CompositeUI.IFilteredView.FillMethod
        {
            set
            {
            }
        }

        DataRow Deklarit.Practices.CompositeUI.IFilteredView.SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        Deklarit.Practices.CompositeUI.WorkWithMode Deklarit.Practices.CompositeUI.IFilteredView.WorkWithMode
        {
            set
            {
            }
        }

        private DockableWindow DockableWindow1;

        private DockableWindow DockableWindow2;

        private DockableWindow DockableWindow3;

        public DataRow FillByRow
        {
            set
            {
            }
        }

        public string FillMethod
        {
            set
            {
            }
        }

        private GroupBox GroupBox1;

        private PARTNERDataSet PartnerDataSet1;

        private S_FIN_PARTNERI_SA_OTVORENIMADataSet S_FIN_PARTNERI_SA_OTVORENIMADataSet1;

        public DataRow SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        private UltraDockManager UltraDockManager1;

        private UltraGrid UltraGrid1;

        private UltraGrid UltraGrid2;

        private UltraGrid UltraGrid3;

        private UltraGroupBox UltraGroupBox1;

        private UltraGroupBox UltraGroupBox2;

        private WindowDockingArea WindowDockingArea1;

        private WindowDockingArea WindowDockingArea2;

        private WindowDockingArea WindowDockingArea3;

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
            }
        }

        private Panel ZatvaranjeSmartPart_Fill_Panel;
    }
}


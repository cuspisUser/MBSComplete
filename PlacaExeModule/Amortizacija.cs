using CrystalDecisions.CrystalReports.Engine;
using Deklarit.Practices.CompositeUI.Workspaces;
using Hlp;
using Infragistics.Win;
using Infragistics.Win.UltraWinCalcManager;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinGrid;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using My.Resources;
using NetAdvantage.Controllers;
using NetAdvantage.WorkItems;
using mipsed.application.framework;
using Placa;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

[SmartPart]
public class Amortizacija : UserControl
{
    private int brojtemeljnice;
    private IContainer components;
    private OSDataAdapter DAOS;
    private DateTime datum;
    private OSDOKUMENTDataAdapter DOK;
    private S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet dsrekap;
    private SmartPartInfoProvider infoProvider;
    private LOKACIJEDataAdapter LOK;
    private object otvorendokument;
    private SmartPartInfo smartPartInfo1;

    public Amortizacija()
    {
        base.Load += new EventHandler(this.UnosTemeljnice_Load);
        this.brojtemeljnice = 0x3db;
        this.datum = DateAndTime.Today;
        this.DAOS = new OSDataAdapter();
        this.DOK = new OSDOKUMENTDataAdapter();
        this.LOK = new LOKACIJEDataAdapter();
        this.otvorendokument = false;
        this.dsrekap = new S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet();
        this.smartPartInfo1 = new SmartPartInfo("Rad sa temeljnicama", "UnosTemeljnice");
        this.infoProvider = new SmartPartInfoProvider();
        this.infoProvider.Items.Add(this.smartPartInfo1);
        this.InitializeComponent();
        this.otvorendokument = false;
    }

    protected override void Dispose(bool disposing)
    {
        try
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
        }
        finally
        {
            base.Dispose(disposing);
        }
    }

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand5 = new Infragistics.Win.UltraWinGrid.UltraGridBand("S_OS_PREGLED_AMORTIZACIJE", -1);
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn35 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVOS");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn36 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSOPIS");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn37 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("INVBROJ", -1, "MT");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn38 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOSDOKUMENT", -1, "PROMJENA");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn39 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSBROJDOKUMENTA");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn40 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSDATUMDOK");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn41 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSKOLICINA");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn42 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSSTOPA");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn43 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSOSNOVICA");
        Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn44 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ISPRAVAK");
        Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn45 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ISPRAVAKPRETHODNIH");
        Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn46 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMUPORABE");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn47 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KTONABAVKEIDKONTO");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn48 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KTOISPRAVKAIDKONTO");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn49 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KTOIZVORAIDKONTO");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn50 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("sadasnja", 0);
        Infragistics.Win.UltraWinGrid.SummarySettings summarySettings1 = new Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, null, "OSOSNOVICA", 8, true, "S_OS_PREGLED_AMORTIZACIJE", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "OSOSNOVICA", 8, true);
        Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
        Infragistics.Win.UltraWinGrid.SummarySettings summarySettings2 = new Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, null, "ISPRAVAKPRETHODNIH", 10, true, "S_OS_PREGLED_AMORTIZACIJE", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "ISPRAVAKPRETHODNIH", 10, true);
        Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
        Infragistics.Win.UltraWinGrid.SummarySettings summarySettings3 = new Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, null, "ISPRAVAK", 9, true, "S_OS_PREGLED_AMORTIZACIJE", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "ISPRAVAK", 9, true);
        Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
        Infragistics.Win.UltraWinGrid.SummarySettings summarySettings4 = new Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, null, "sadasnja", 0, false, "S_OS_PREGLED_AMORTIZACIJE", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "sadasnja", 0, false);
        Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
        Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("OS", -1);
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("INVBROJ");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOSVRSTA");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVOS");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAMSKUPINE");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KTONABAVKEIDKONTO");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KTOISPRAVKAIDKONTO");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KTOIZVORAIDKONTO");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMNABAVKE");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMUPORABE");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAPOMENAOS");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPISAMSKUPINE");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AMSKUPINASTOPA");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OS_OSTEMELJNICA");
        Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand4 = new Infragistics.Win.UltraWinGrid.UltraGridBand("OS_OSTEMELJNICA", 0);
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("INVBROJ");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOSDOKUMENT");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSBROJDOKUMENTA");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSDATUMDOK");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSKOLICINA");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSSTOPA");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSOSNOVICA");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSDUGUJE");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSPOTRAZUJE");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn32 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RASHODLOKACIJEIDLOKACIJE");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn33 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSOPIS");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn34 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVOSDOKUMENT");
        Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
        Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("OSDOKUMENT", -1);
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOSDOKUMENT");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVOSDOKUMENT");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSDK");
        Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
        Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("S_OS_STANJE_LOKACIJA", -1);
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDLOKACIJE");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("INVBROJ");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ULAZ");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IZLAZ");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("STANJE");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPISLOKACIJE");
        Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
        this.OsDataSet1 = new Placa.OSDataSet();
        this.UltraGrid2 = new Infragistics.Win.UltraWinGrid.UltraGrid();
        this.UltraCalcManager1 = new Infragistics.Win.UltraWinCalcManager.UltraCalcManager(this.components);
        this.S_OS_PREGLED_AMORTIZACIJEDataSet1 = new Placa.S_OS_PREGLED_AMORTIZACIJEDataSet();
        this.MT = new Infragistics.Win.UltraWinGrid.UltraDropDown();
        this.PROMJENA = new Infragistics.Win.UltraWinGrid.UltraDropDown();
        this.OsdokumentDataSet1 = new Placa.OSDOKUMENTDataSet();
        this.LOKACIJE = new Infragistics.Win.UltraWinGrid.UltraDropDown();
        this.S_OS_STANJE_LOKACIJADataSet1 = new Placa.S_OS_STANJE_LOKACIJADataSet();
        this.UltraDockManager1 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
        this._UnosTemeljniceUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
        this._UnosTemeljniceUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
        this._UnosTemeljniceUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
        this._UnosTemeljniceUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
        this._UnosTemeljniceAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
        ((System.ComponentModel.ISupportInitialize)(this.OsDataSet1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.UltraGrid2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.UltraCalcManager1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.S_OS_PREGLED_AMORTIZACIJEDataSet1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.MT)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.PROMJENA)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.OsdokumentDataSet1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.LOKACIJE)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.S_OS_STANJE_LOKACIJADataSet1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).BeginInit();
        this.SuspendLayout();
        // 
        // OsDataSet1
        // 
        this.OsDataSet1.DataSetName = "OSDataSet";
        // 
        // UltraGrid2
        // 
        this.UltraGrid2.CalcManager = this.UltraCalcManager1;
        this.UltraGrid2.DataMember = "S_OS_PREGLED_AMORTIZACIJE";
        this.UltraGrid2.DataSource = this.S_OS_PREGLED_AMORTIZACIJEDataSet1;
        ultraGridColumn35.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn35.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        ultraGridColumn35.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
        ultraGridColumn35.Header.Caption = "Osnovno sredstvo";
        ultraGridColumn35.Header.VisiblePosition = 1;
        ultraGridColumn35.Width = 415;
        ultraGridColumn36.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn36.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        ultraGridColumn36.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
        ultraGridColumn36.Header.Caption = "Opis stavke";
        ultraGridColumn36.Header.VisiblePosition = 9;
        ultraGridColumn36.Hidden = true;
        ultraGridColumn36.Width = 302;
        ultraGridColumn37.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn37.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        ultraGridColumn37.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
        ultraGridColumn37.Header.VisiblePosition = 0;
        ultraGridColumn37.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
        ultraGridColumn38.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn38.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        ultraGridColumn38.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
        ultraGridColumn38.Header.VisiblePosition = 10;
        ultraGridColumn38.Hidden = true;
        ultraGridColumn38.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
        ultraGridColumn39.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn39.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        ultraGridColumn39.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
        ultraGridColumn39.Header.VisiblePosition = 11;
        ultraGridColumn39.Hidden = true;
        ultraGridColumn40.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn40.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        ultraGridColumn40.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
        ultraGridColumn40.Header.VisiblePosition = 12;
        ultraGridColumn40.Hidden = true;
        ultraGridColumn41.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn41.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        ultraGridColumn41.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
        ultraGridColumn41.Header.Caption = "Količina";
        ultraGridColumn41.Header.VisiblePosition = 3;
        ultraGridColumn41.MaskInput = "-nnnnnnnnn.nn";
        ultraGridColumn41.Width = 58;
        ultraGridColumn42.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn42.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        ultraGridColumn42.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
        ultraGridColumn42.Header.Caption = "Stopa";
        ultraGridColumn42.Header.VisiblePosition = 2;
        ultraGridColumn42.Width = 51;
        ultraGridColumn43.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn43.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        appearance8.TextHAlignAsString = "Right";
        ultraGridColumn43.CellAppearance = appearance8;
        ultraGridColumn43.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
        ultraGridColumn43.Header.Caption = "Osnovica";
        ultraGridColumn43.Header.VisiblePosition = 4;
        ultraGridColumn43.MaskInput = "{LOC} n,nnn,nnn.nn";
        ultraGridColumn43.Width = 120;
        ultraGridColumn44.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn44.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        appearance9.TextHAlignAsString = "Right";
        ultraGridColumn44.CellAppearance = appearance9;
        ultraGridColumn44.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
        ultraGridColumn44.Header.VisiblePosition = 6;
        ultraGridColumn44.MaskInput = "{LOC} n,nnn,nnn.nn";
        ultraGridColumn44.Width = 97;
        ultraGridColumn45.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn45.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        appearance10.TextHAlignAsString = "Right";
        ultraGridColumn45.CellAppearance = appearance10;
        ultraGridColumn45.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
        ultraGridColumn45.Header.Caption = "Isp.pret.godina";
        ultraGridColumn45.Header.VisiblePosition = 5;
        ultraGridColumn45.MaskInput = "{LOC} n,nnn,nnn.nn";
        ultraGridColumn46.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn46.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        ultraGridColumn46.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
        ultraGridColumn46.Header.Caption = "Dat.uporabe";
        ultraGridColumn46.Header.VisiblePosition = 8;
        ultraGridColumn46.Width = 105;
        ultraGridColumn47.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn47.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        ultraGridColumn47.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
        ultraGridColumn47.Header.VisiblePosition = 13;
        ultraGridColumn47.Hidden = true;
        ultraGridColumn48.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn48.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        ultraGridColumn48.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
        ultraGridColumn48.Header.VisiblePosition = 14;
        ultraGridColumn48.Hidden = true;
        ultraGridColumn49.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn49.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        ultraGridColumn49.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
        ultraGridColumn49.Header.VisiblePosition = 15;
        ultraGridColumn49.Hidden = true;
        ultraGridColumn50.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn50.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        ultraGridColumn50.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
        ultraGridColumn50.Formula = "[OSOSNOVICA] - [ISPRAVAKPRETHODNIH] - [ISPRAVAK]";
        ultraGridColumn50.Header.Caption = "Sadašnja";
        ultraGridColumn50.Header.VisiblePosition = 7;
        ultraGridBand5.Columns.AddRange(new object[] {
            ultraGridColumn35,
            ultraGridColumn36,
            ultraGridColumn37,
            ultraGridColumn38,
            ultraGridColumn39,
            ultraGridColumn40,
            ultraGridColumn41,
            ultraGridColumn42,
            ultraGridColumn43,
            ultraGridColumn44,
            ultraGridColumn45,
            ultraGridColumn46,
            ultraGridColumn47,
            ultraGridColumn48,
            ultraGridColumn49,
            ultraGridColumn50});
        appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(191)))));
        appearance11.FontData.BoldAsString = "True";
        appearance11.TextHAlignAsString = "Right";
        summarySettings1.Appearance = appearance11;
        summarySettings1.DisplayFormat = "{0:#,##0.00}";
        summarySettings1.GroupBySummaryValueAppearance = appearance13;
        summarySettings1.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.TopFixed;
        appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(191)))));
        appearance14.FontData.BoldAsString = "True";
        appearance14.TextHAlignAsString = "Right";
        summarySettings2.Appearance = appearance14;
        summarySettings2.DisplayFormat = "{0:#,##0.00}";
        summarySettings2.GroupBySummaryValueAppearance = appearance15;
        summarySettings2.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.TopFixed;
        appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(191)))));
        appearance16.FontData.BoldAsString = "True";
        appearance16.TextHAlignAsString = "Right";
        summarySettings3.Appearance = appearance16;
        summarySettings3.DisplayFormat = "{0:#,##0.00}";
        summarySettings3.GroupBySummaryValueAppearance = appearance17;
        summarySettings3.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.TopFixed;
        appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(191)))));
        appearance18.FontData.BoldAsString = "True";
        appearance18.TextHAlignAsString = "Right";
        summarySettings4.Appearance = appearance18;
        summarySettings4.DisplayFormat = "{0:#,##0.00}";
        summarySettings4.GroupBySummaryValueAppearance = appearance19;
        summarySettings4.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.TopFixed;
        ultraGridBand5.Summaries.AddRange(new Infragistics.Win.UltraWinGrid.SummarySettings[] {
            summarySettings1,
            summarySettings2,
            summarySettings3,
            summarySettings4});
        ultraGridBand5.SummaryFooterCaption = "UKUPNO:";
        this.UltraGrid2.DisplayLayout.BandsSerializer.Add(ultraGridBand5);
        this.UltraGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.UltraGrid2.Location = new System.Drawing.Point(0, 0);
        this.UltraGrid2.Name = "UltraGrid2";
        this.UltraGrid2.Size = new System.Drawing.Size(1206, 593);
        this.UltraGrid2.TabIndex = 2;
        this.UltraGrid2.Text = "Pregled amortizacije";
        this.UltraGrid2.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.UltraGrid2_InitializeLayout);
        this.UltraGrid2.BeforeCellDeactivate += new System.ComponentModel.CancelEventHandler(this.UltraGrid2_BeforeCellDeactivate);
        this.UltraGrid2.CellDataError += new Infragistics.Win.UltraWinGrid.CellDataErrorEventHandler(this.UltraGrid2_CellDataError);
        // 
        // UltraCalcManager1
        // 
        this.UltraCalcManager1.ContainingControl = this;
        // 
        // S_OS_PREGLED_AMORTIZACIJEDataSet1
        // 
        this.S_OS_PREGLED_AMORTIZACIJEDataSet1.DataSetName = "S_OS_PREGLED_AMORTIZACIJEDataSet";
        // 
        // MT
        // 
        this.MT.CalcManager = this.UltraCalcManager1;
        this.MT.DataMember = "OS";
        this.MT.DataSource = this.OsDataSet1;
        appearance.BackColor = System.Drawing.Color.White;
        this.MT.DisplayLayout.Appearance = appearance;
        ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn10.Header.VisiblePosition = 0;
        ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn11.Header.VisiblePosition = 1;
        ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn12.Header.VisiblePosition = 2;
        ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn13.Header.VisiblePosition = 3;
        ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn14.Header.VisiblePosition = 4;
        ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn15.Header.VisiblePosition = 5;
        ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn16.Header.VisiblePosition = 6;
        ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn17.Header.VisiblePosition = 7;
        ultraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn18.Header.VisiblePosition = 8;
        ultraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn19.Header.VisiblePosition = 9;
        ultraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn20.Header.VisiblePosition = 10;
        ultraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn21.Header.VisiblePosition = 12;
        ultraGridColumn22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn22.Header.VisiblePosition = 11;
        ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn22});
        ultraGridBand3.UseRowLayout = true;
        ultraGridColumn23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn23.Header.VisiblePosition = 0;
        ultraGridColumn24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn24.Header.VisiblePosition = 1;
        ultraGridColumn25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn25.Header.VisiblePosition = 2;
        ultraGridColumn26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn26.Header.VisiblePosition = 3;
        ultraGridColumn27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn27.Header.VisiblePosition = 4;
        ultraGridColumn28.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn28.Header.VisiblePosition = 5;
        ultraGridColumn29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn29.Header.VisiblePosition = 6;
        ultraGridColumn30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn30.Header.VisiblePosition = 7;
        ultraGridColumn31.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn31.Header.VisiblePosition = 8;
        ultraGridColumn32.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn32.Header.VisiblePosition = 9;
        ultraGridColumn33.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn33.Header.VisiblePosition = 10;
        ultraGridColumn34.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn34.Header.VisiblePosition = 11;
        ultraGridBand4.Columns.AddRange(new object[] {
            ultraGridColumn23,
            ultraGridColumn24,
            ultraGridColumn25,
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn28,
            ultraGridColumn29,
            ultraGridColumn30,
            ultraGridColumn31,
            ultraGridColumn32,
            ultraGridColumn33,
            ultraGridColumn34});
        this.MT.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
        this.MT.DisplayLayout.BandsSerializer.Add(ultraGridBand4);
        this.MT.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
        appearance12.BackColor = System.Drawing.Color.Transparent;
        this.MT.DisplayLayout.Override.CardAreaAppearance = appearance12;
        this.MT.DisplayLayout.Override.CellPadding = 3;
        appearance20.TextHAlignAsString = "Left";
        this.MT.DisplayLayout.Override.HeaderAppearance = appearance20;
        appearance21.BorderColor = System.Drawing.Color.LightGray;
        appearance21.TextVAlignAsString = "Middle";
        this.MT.DisplayLayout.Override.RowAppearance = appearance21;
        this.MT.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
        appearance22.BackColor = System.Drawing.Color.LightSteelBlue;
        appearance22.BorderColor = System.Drawing.Color.Black;
        appearance22.ForeColor = System.Drawing.Color.Black;
        this.MT.DisplayLayout.Override.SelectedRowAppearance = appearance22;
        this.MT.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
        this.MT.DisplayMember = "INVBROJ";
        this.MT.Location = new System.Drawing.Point(995, 475);
        this.MT.Name = "MT";
        this.MT.Size = new System.Drawing.Size(117, 80);
        this.MT.TabIndex = 13;
        this.MT.ValueMember = "INVBROJ";
        this.MT.Visible = false;
        // 
        // PROMJENA
        // 
        this.PROMJENA.CalcManager = this.UltraCalcManager1;
        this.PROMJENA.DataMember = "OSDOKUMENT";
        this.PROMJENA.DataSource = this.OsdokumentDataSet1;
        appearance23.BackColor = System.Drawing.Color.White;
        this.PROMJENA.DisplayLayout.Appearance = appearance23;
        ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn7.Header.VisiblePosition = 0;
        ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn8.Header.VisiblePosition = 1;
        ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn9.Header.VisiblePosition = 2;
        ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9});
        this.PROMJENA.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
        this.PROMJENA.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
        appearance24.BackColor = System.Drawing.Color.Transparent;
        this.PROMJENA.DisplayLayout.Override.CardAreaAppearance = appearance24;
        this.PROMJENA.DisplayLayout.Override.CellPadding = 3;
        appearance25.TextHAlignAsString = "Left";
        this.PROMJENA.DisplayLayout.Override.HeaderAppearance = appearance25;
        appearance26.BorderColor = System.Drawing.Color.LightGray;
        appearance26.TextVAlignAsString = "Middle";
        this.PROMJENA.DisplayLayout.Override.RowAppearance = appearance26;
        this.PROMJENA.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
        appearance2.BackColor = System.Drawing.Color.LightSteelBlue;
        appearance2.BorderColor = System.Drawing.Color.Black;
        appearance2.ForeColor = System.Drawing.Color.Black;
        this.PROMJENA.DisplayLayout.Override.SelectedRowAppearance = appearance2;
        this.PROMJENA.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
        this.PROMJENA.Location = new System.Drawing.Point(577, 475);
        this.PROMJENA.Name = "PROMJENA";
        this.PROMJENA.Size = new System.Drawing.Size(117, 80);
        this.PROMJENA.TabIndex = 14;
        this.PROMJENA.ValueMember = "IDOSDOKUMENT";
        this.PROMJENA.Visible = false;
        // 
        // OsdokumentDataSet1
        // 
        this.OsdokumentDataSet1.DataSetName = "OSDOKUMENTDataSet";
        // 
        // LOKACIJE
        // 
        this.LOKACIJE.CalcManager = this.UltraCalcManager1;
        this.LOKACIJE.DataMember = "S_OS_STANJE_LOKACIJA";
        this.LOKACIJE.DataSource = this.S_OS_STANJE_LOKACIJADataSet1;
        appearance3.BackColor = System.Drawing.Color.White;
        this.LOKACIJE.DisplayLayout.Appearance = appearance3;
        ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn1.Header.VisiblePosition = 0;
        ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn2.Header.VisiblePosition = 1;
        ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn3.Header.VisiblePosition = 2;
        ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn4.Header.VisiblePosition = 3;
        ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn5.Header.VisiblePosition = 4;
        ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn6.Header.VisiblePosition = 5;
        ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6});
        this.LOKACIJE.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
        this.LOKACIJE.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
        appearance4.BackColor = System.Drawing.Color.Transparent;
        this.LOKACIJE.DisplayLayout.Override.CardAreaAppearance = appearance4;
        this.LOKACIJE.DisplayLayout.Override.CellPadding = 3;
        appearance5.TextHAlignAsString = "Left";
        this.LOKACIJE.DisplayLayout.Override.HeaderAppearance = appearance5;
        appearance6.BorderColor = System.Drawing.Color.LightGray;
        appearance6.TextVAlignAsString = "Middle";
        this.LOKACIJE.DisplayLayout.Override.RowAppearance = appearance6;
        this.LOKACIJE.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
        appearance7.BackColor = System.Drawing.Color.LightSteelBlue;
        appearance7.BorderColor = System.Drawing.Color.Black;
        appearance7.ForeColor = System.Drawing.Color.Black;
        this.LOKACIJE.DisplayLayout.Override.SelectedRowAppearance = appearance7;
        this.LOKACIJE.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
        this.LOKACIJE.Location = new System.Drawing.Point(790, 456);
        this.LOKACIJE.Name = "LOKACIJE";
        this.LOKACIJE.Size = new System.Drawing.Size(117, 80);
        this.LOKACIJE.TabIndex = 15;
        this.LOKACIJE.ValueMember = "IDLOKACIJE";
        this.LOKACIJE.Visible = false;
        // 
        // S_OS_STANJE_LOKACIJADataSet1
        // 
        this.S_OS_STANJE_LOKACIJADataSet1.DataSetName = "S_OS_STANJE_LOKACIJADataSet";
        // 
        // UltraDockManager1
        // 
        this.UltraDockManager1.HostControl = this;
        // 
        // _UnosTemeljniceUnpinnedTabAreaLeft
        // 
        this._UnosTemeljniceUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
        this._UnosTemeljniceUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        this._UnosTemeljniceUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
        this._UnosTemeljniceUnpinnedTabAreaLeft.Name = "_UnosTemeljniceUnpinnedTabAreaLeft";
        this._UnosTemeljniceUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
        this._UnosTemeljniceUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 593);
        this._UnosTemeljniceUnpinnedTabAreaLeft.TabIndex = 19;
        // 
        // _UnosTemeljniceUnpinnedTabAreaRight
        // 
        this._UnosTemeljniceUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
        this._UnosTemeljniceUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        this._UnosTemeljniceUnpinnedTabAreaRight.Location = new System.Drawing.Point(1206, 0);
        this._UnosTemeljniceUnpinnedTabAreaRight.Name = "_UnosTemeljniceUnpinnedTabAreaRight";
        this._UnosTemeljniceUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
        this._UnosTemeljniceUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 593);
        this._UnosTemeljniceUnpinnedTabAreaRight.TabIndex = 20;
        // 
        // _UnosTemeljniceUnpinnedTabAreaTop
        // 
        this._UnosTemeljniceUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
        this._UnosTemeljniceUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        this._UnosTemeljniceUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
        this._UnosTemeljniceUnpinnedTabAreaTop.Name = "_UnosTemeljniceUnpinnedTabAreaTop";
        this._UnosTemeljniceUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
        this._UnosTemeljniceUnpinnedTabAreaTop.Size = new System.Drawing.Size(1206, 0);
        this._UnosTemeljniceUnpinnedTabAreaTop.TabIndex = 21;
        // 
        // _UnosTemeljniceUnpinnedTabAreaBottom
        // 
        this._UnosTemeljniceUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
        this._UnosTemeljniceUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        this._UnosTemeljniceUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 593);
        this._UnosTemeljniceUnpinnedTabAreaBottom.Name = "_UnosTemeljniceUnpinnedTabAreaBottom";
        this._UnosTemeljniceUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
        this._UnosTemeljniceUnpinnedTabAreaBottom.Size = new System.Drawing.Size(1206, 0);
        this._UnosTemeljniceUnpinnedTabAreaBottom.TabIndex = 22;
        // 
        // _UnosTemeljniceAutoHideControl
        // 
        this._UnosTemeljniceAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        this._UnosTemeljniceAutoHideControl.Location = new System.Drawing.Point(0, 0);
        this._UnosTemeljniceAutoHideControl.Name = "_UnosTemeljniceAutoHideControl";
        this._UnosTemeljniceAutoHideControl.Owner = this.UltraDockManager1;
        this._UnosTemeljniceAutoHideControl.Size = new System.Drawing.Size(0, 0);
        this._UnosTemeljniceAutoHideControl.TabIndex = 23;
        // 
        // Amortizacija
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Controls.Add(this._UnosTemeljniceAutoHideControl);
        this.Controls.Add(this.UltraGrid2);
        this.Controls.Add(this.LOKACIJE);
        this.Controls.Add(this.PROMJENA);
        this.Controls.Add(this.MT);
        this.Controls.Add(this._UnosTemeljniceUnpinnedTabAreaTop);
        this.Controls.Add(this._UnosTemeljniceUnpinnedTabAreaBottom);
        this.Controls.Add(this._UnosTemeljniceUnpinnedTabAreaLeft);
        this.Controls.Add(this._UnosTemeljniceUnpinnedTabAreaRight);
        this.Name = "Amortizacija";
        this.Size = new System.Drawing.Size(1206, 593);
        ((System.ComponentModel.ISupportInitialize)(this.OsDataSet1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.UltraGrid2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.UltraCalcManager1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.S_OS_PREGLED_AMORTIZACIJEDataSet1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.MT)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.PROMJENA)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.OsdokumentDataSet1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.LOKACIJE)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.S_OS_STANJE_LOKACIJADataSet1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).EndInit();
        this.ResumeLayout(false);

    }

    public void Ispis_Amortizacije()
    {
        ReportDocument document = new ReportDocument();
        document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptAmortizacija.rpt");
        document.SetDataSource(this.S_OS_PREGLED_AMORTIZACIJEDataSet1);
        KORISNIKDataSet dataSet = new KORISNIKDataSet();
        new KORISNIKDataAdapter().Fill(dataSet);
        document.SetParameterValue("ustanova", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
        document.SetParameterValue("ustanova2", Operators.AddObject(Operators.AddObject(dataSet.KORISNIK.Rows[0]["KORISNIK1ADRESA"], " "), dataSet.KORISNIK.Rows[0]["KORISNIK1MJESTO"]));
        document.SetParameterValue("tel", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KONTAKTTELEFON"]));
        document.SetParameterValue("fax", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KONTAKTFAX"]));
        document.SetParameterValue("oib", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"]));
        PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
        if (item == null)
        {
            item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
        }
        item.Izvjestaj = document;
        item.Activate();
        item.Show(item.Workspaces["main"]);
    }

    public void Ispis_Amortizacije_Rekapitulacija()
    {
        ReportDocument document = new ReportDocument();
        document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptAmortizacijaRekap.rpt");
        document.SetDataSource(this.dsrekap);
        KORISNIKDataSet dataSet = new KORISNIKDataSet();
        new KORISNIKDataAdapter().Fill(dataSet);
        document.SetParameterValue("ustanova", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
        document.SetParameterValue("ustanova2", Operators.AddObject(Operators.AddObject(dataSet.KORISNIK.Rows[0]["KORISNIK1ADRESA"], " "), dataSet.KORISNIK.Rows[0]["KORISNIK1MJESTO"]));
        document.SetParameterValue("tel", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KONTAKTTELEFON"]));
        document.SetParameterValue("fax", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KONTAKTFAX"]));
        document.SetParameterValue("oib", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"]));
        ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
        PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
        if (item == null)
        {
            item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
        }
        item.Izvjestaj = document;
        item.Activate();
        item.Show(item.Workspaces["main"]);
    }

    [CommandHandler("Ispisi")]
    public void IspisiHandler(object sender, EventArgs e)
    {
        if (Operators.ConditionalCompareObjectEqual(this.otvorendokument, true, false))
        {
            this.Ispis_Amortizacije();
        }
        else
        {
            Interaction.MsgBox("Prije ispisa otvorite željeni dokument", MsgBoxStyle.Information, "OS/SI");
        }
    }

    [CommandHandler("IspisiRekapitulaciju")]
    public void IspisiRekapHandler(object sender, EventArgs e)
    {
        if (Operators.ConditionalCompareObjectEqual(this.otvorendokument, true, false))
        {
            this.Ispis_Amortizacije_Rekapitulacija();
        }
        else
        {
            Interaction.MsgBox("Prije ispisa otvorite željeni dokument", MsgBoxStyle.Information, "OS/SI");
        }
    }

    [CommandHandler("KreirajNovu")]
    public void OtvoriCommandHandler(object sender, EventArgs e)
    {
        if (Operators.ConditionalCompareObjectEqual(this.otvorendokument, true, false))
        {
            Interaction.MsgBox("Zatvorite postojeći dokument!", MsgBoxStyle.OkOnly, null);
        }
        else
        {
            FrmBrojIDatumzAaMORTIZACIJU amortizaciju = new FrmBrojIDatumzAaMORTIZACIJU();
            if ((amortizaciju.ShowDialog() == DialogResult.OK) && (Interaction.MsgBox("Želite li stvarno izraditi novu amortizaciju \r\n za razdoblje: " + Conversions.ToString(amortizaciju.__ODDATUMA) + " - " + Conversions.ToString(amortizaciju.__DODATUMA), MsgBoxStyle.YesNo, "Osnovna sredstva") == MsgBoxResult.Yes))
            {
                SqlCommand command = new SqlCommand();
                SqlConnection connection = new SqlConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[S_OS_IZRADI_AMORTIZACIJU]";
                command.Parameters.AddWithValue("@DATOD", amortizaciju.__ODDATUMA);
                command.Parameters.AddWithValue("@DATDO", amortizaciju.__DODATUMA);
                connection.ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString;
                command.Connection = connection;
                int num = amortizaciju.___broj;
                command.Parameters.AddWithValue("@BROJDOK", num);
                connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (System.Exception exception1)
                {
                    throw exception1;                    
                }
                connection.Close();
                S_OS_PREGLED_AMORTIZACIJEDataAdapter adapter = new S_OS_PREGLED_AMORTIZACIJEDataAdapter();
                this.S_OS_PREGLED_AMORTIZACIJEDataSet1.Clear();
                adapter.Fill(this.S_OS_PREGLED_AMORTIZACIJEDataSet1, num);
                this.otvorendokument = true;
                this.dsrekap.Clear();
                new S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataAdapter().Fill(this.dsrekap, num);
            }
        }
    }

    public void OtvoriPostojecu()
    {
        frmPregledPostojecih postojecih = new frmPregledPostojecih(2);
        if (postojecih.ShowDialog() == DialogResult.OK)
        {
            if (postojecih.__BrojPostojeceg != null)
            {
                S_OS_PREGLED_AMORTIZACIJEDataAdapter adapter = new S_OS_PREGLED_AMORTIZACIJEDataAdapter();
                this.brojtemeljnice = Conversions.ToInteger(postojecih.__BrojPostojeceg);
                this.otvorendokument = true;
                adapter.Fill(this.S_OS_PREGLED_AMORTIZACIJEDataSet1, this.brojtemeljnice);
                this.dsrekap.Clear();
                new S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataAdapter().Fill(this.dsrekap, this.brojtemeljnice);
            }
        }
        else
        {
            this.otvorendokument = false;
            Interaction.MsgBox("Odustali ste od otvaranja temeljnice!", MsgBoxStyle.OkOnly, null);
        }
    }

    [CommandHandler("OtvoriPostojecu")]
    public void OtvoriPostojecuCommandHandler(object sender, EventArgs e)
    {
        if (Operators.ConditionalCompareObjectEqual(this.otvorendokument, true, false))
        {
            Interaction.MsgBox("Zatvorite postojeći dokument!", MsgBoxStyle.OkOnly, null);
        }
    }

    [CommandHandler("OtvoriPostojecu")]
    public void OtvoriPostojecuHandler(object sender, EventArgs e)
    {
        this.OtvoriPostojecu();
    }

    public void Spremi()
    {
        BindingSource bindingSource = this.OSController.OSFormDefinition.GetBindingSource("OS");
        try
        {
            bindingSource.EndEdit();
        }
        catch (System.Exception exception1)
        {
            throw exception1;
            
            //Interaction.MsgBox("Greška, podaci nisu uneseni prema pravilima! ", MsgBoxStyle.OkOnly, null);
            //return;
        }
        this.OSController.Update(this.Parent.Parent);
    }

    public void SpremiPromjene()
    {
        this.BindingContext[this.OsDataSet1, "OSTEMELJNICA"].EndCurrentEdit();
        this.DAOS.Update(this.OsDataSet1);
    }

    private void UltraGrid2_BeforeCellDeactivate(object sender, CancelEventArgs e)
    {
        if ((((UltraGrid) sender).ActiveCell.Column.Key == "INVBROJ") && (((UltraGrid) sender).ActiveCell.Value == DBNull.Value))
        {
            e.Cancel = false;
        }
    }

    private void UltraGrid2_CellDataError(object sender, CellDataErrorEventArgs e)
    {
        if (((UltraGrid) sender).ActiveCell.Column.Key == "INVBROJ")
        {
            Interaction.MsgBox("Nepostojeći inventarni broj", MsgBoxStyle.OkOnly, null);
            e.RaiseErrorEvent = false;
            e.StayInEditMode = true;
            ((UltraGrid) sender).ActiveCell.Value = DBNull.Value;
        }
    }

    private void UltraGrid2_InitializeLayout(object sender, InitializeLayoutEventArgs e)
    {
    }

    private void UnosTemeljnice_Load(object sender, EventArgs e)
    {
        InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
    }

    [CommandHandler("Zatvori")]
    public void ZatvoriCommandHandler(object sender, EventArgs e)
    {
        if (Operators.ConditionalCompareObjectEqual(this.otvorendokument, false, false))
        {
            Interaction.MsgBox("Temeljnica nije otvorena!", MsgBoxStyle.OkOnly, null);
        }
        else
        {
            this.S_OS_PREGLED_AMORTIZACIJEDataSet1.Clear();
            this.otvorendokument = false;
        }
    }

    private AutoHideControl _UnosTemeljniceAutoHideControl;

    private UnpinnedTabArea _UnosTemeljniceUnpinnedTabAreaBottom;

    private UnpinnedTabArea _UnosTemeljniceUnpinnedTabAreaLeft;

    private UnpinnedTabArea _UnosTemeljniceUnpinnedTabAreaRight;

    private UnpinnedTabArea _UnosTemeljniceUnpinnedTabAreaTop;

    [CreateNew]
    public ListaIznosaController Controller { get; set; }

    private UltraDropDown LOKACIJE;

    private UltraDropDown MT;

    [Browsable(false)]
    public NetAdvantage.Controllers.OSController OSController { get; set; }

    private OSDataSet OsDataSet1;

    private OSDOKUMENTDataSet OsdokumentDataSet1;

    private UltraDropDown PROMJENA;

    private S_OS_PREGLED_AMORTIZACIJEDataSet S_OS_PREGLED_AMORTIZACIJEDataSet1;

    private S_OS_STANJE_LOKACIJADataSet S_OS_STANJE_LOKACIJADataSet1;

    private UltraCalcManager UltraCalcManager1;

    private UltraDockManager UltraDockManager1;

    private UltraGrid UltraGrid2;
}


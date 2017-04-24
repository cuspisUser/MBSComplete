using CrystalDecisions.CrystalReports.Engine;
using Deklarit.Practices.CompositeUI.Workspaces;
using Hlp;
using Infragistics.Win;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinGrid;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NetAdvantage.Controllers;
using NetAdvantage.WorkItems;
using Placa;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

[SmartPart]
public class UnosTemeljnice : UserControl
{
    private int brojtemeljnice;
    private IContainer components;
    private OSDataAdapter DAOS;
    private DateTime datum;
    private OSDOKUMENTDataAdapter DOK;
    private SmartPartInfoProvider infoProvider;
    private LOKACIJEDataAdapter LOK;
    private object otvorendokument;
    private SmartPartInfo smartPartInfo1;

    public UnosTemeljnice()
    {
        base.Load += new EventHandler(this.UnosTemeljnice_Load);
        this.brojtemeljnice = 0x3db;
        this.datum = DateAndTime.Today;
        this.DAOS = new OSDataAdapter();
        this.DOK = new OSDOKUMENTDataAdapter();
        this.LOK = new LOKACIJEDataAdapter();
        this.otvorendokument = false;
        this.smartPartInfo1 = new SmartPartInfo("Rad sa temeljnicama", "UnosTemeljnice");
        this.infoProvider = new SmartPartInfoProvider();
        this.infoProvider.Items.Add(this.smartPartInfo1);
        this.InitializeComponent();
        this.otvorendokument = false;
    }

    private void Button1_Click(object sender, EventArgs e)
    {
        if (Operators.ConditionalCompareObjectEqual(this.otvorendokument, false, false))
        {
            Interaction.MsgBox("Kreirajte novi dokument ili otvorite postojeći!", MsgBoxStyle.OkOnly, null);
        }
        else
        {
            this.unos_stavke_rashoda();
            this.SpremiPromjene();
        }
    }

    private void Button2_Click(object sender, EventArgs e)
    {
        if (Operators.ConditionalCompareObjectEqual(this.otvorendokument, false, false))
        {
            Interaction.MsgBox("Kreirajte novi dokument ili otvorite postojeći!", MsgBoxStyle.OkOnly, null);
        }
        else
        {
            this.unos_stavke_povecanja();
            this.SpremiPromjene();
        }
    }

    private void Button3_Click(object sender, EventArgs e)
    {
        if (Operators.ConditionalCompareObjectEqual(this.otvorendokument, false, false))
        {
            Interaction.MsgBox("Kreirajte novi dokument ili otvorite postojeći!", MsgBoxStyle.OkOnly, null);
        }
        else
        {
            Interaction.MsgBox("Ova procedura još nije definirana!", MsgBoxStyle.OkOnly, null);
        }
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

    private void Dodaj_Stavku_Povecanja(int invbroj, decimal iznos)
    {
        this.BindingContext[this.OsDataSet1, "OSTEMELJNICA"].AddNew();
        DataRowView current = (DataRowView) this.BindingContext[this.OsDataSet1, "OSTEMELJNICA"].Current;
        current["OSBROJDOKUMENTA"] = this.brojtemeljnice;
        current["OSDATUMDOK"] = this.datum;
        current["OSSTOPA"] = 0;
        current["OSOSNOVICA"] = 0;
        current["INVBROJ"] = invbroj;
        current["IDOSDOKUMENT"] = 4;
        current["OSKOLICINA"] = 0;
        current["OSOPIS"] = "Povećanje vr.- " + Conversions.ToString(this.brojtemeljnice) + " - " + Conversions.ToString(this.datum);
        current["OSDUGUJE"] = iznos;
        current["OSPOTRAZUJE"] = 0;
        current["RASHODLOKACIJEIDLOKACIJE"] = DBNull.Value;
    }

    private void Dodaj_Stavku_Rashoda(int invbroj, int lok, int kol, decimal dugovna, decimal potrazna)
    {
        this.BindingContext[this.OsDataSet1, "OSTEMELJNICA"].AddNew();
        DataRowView current = (DataRowView) this.BindingContext[this.OsDataSet1, "OSTEMELJNICA"].Current;
        current["OSBROJDOKUMENTA"] = this.brojtemeljnice;
        current["OSDATUMDOK"] = this.datum;
        current["OSSTOPA"] = 0;
        current["OSOSNOVICA"] = 0;
        current["INVBROJ"] = invbroj;
        current["IDOSDOKUMENT"] = 3;
        current["OSKOLICINA"] = kol;
        current["OSOPIS"] = "Rashod-" + Conversions.ToString(this.brojtemeljnice) + " - " + Conversions.ToString(this.datum);
        current["OSDUGUJE"] = dugovna;
        current["OSPOTRAZUJE"] = potrazna;
        current["RASHODLOKACIJEIDLOKACIJE"] = lok;
    }

    private void Dodaj_Stavku_Smanjenja(int invbroj, decimal nabavna, decimal ispravak)
    {
        this.BindingContext[this.OsDataSet1, "OSTEMELJNICA"].AddNew();
        DataRowView current = (DataRowView) this.BindingContext[this.OsDataSet1, "OSTEMELJNICA"].Current;
        current["OSBROJDOKUMENTA"] = this.brojtemeljnice;
        current["OSDATUMDOK"] = this.datum;
        current["OSSTOPA"] = 0;
        current["OSOSNOVICA"] = 0;
        current["INVBROJ"] = invbroj;
        current["IDOSDOKUMENT"] = 5;
        current["OSKOLICINA"] = 0;
        current["OSDUGUJE"] = ispravak;
        current["OSPOTRAZUJE"] = nabavna;
        current["OSOPIS"] = "Smanjenje vr.- " + Conversions.ToString(this.brojtemeljnice) + " - " + Conversions.ToString(this.datum);
        current["RASHODLOKACIJEIDLOKACIJE"] = DBNull.Value;
    }

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("OSTEMELJNICA", -1);
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("INVBROJ", -1, "MT");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOSDOKUMENT", -1, "PROMJENA");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSBROJDOKUMENTA");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSDATUMDOK");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSKOLICINA");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSSTOPA");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSOSNOVICA");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSDUGUJE");
        Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSPOTRAZUJE");
        Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RASHODLOKACIJEIDLOKACIJE");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSOPIS");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVOSDOKUMENT");
        Infragistics.Win.UltraWinGrid.SummarySettings summarySettings1 = new Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, null, "OSDUGUJE", 7, true, "OSTEMELJNICA", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "OSDUGUJE", 7, true);
        Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
        Infragistics.Win.UltraWinGrid.SummarySettings summarySettings2 = new Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, null, "OSPOTRAZUJE", 8, true, "OSTEMELJNICA", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "OSPOTRAZUJE", 8, true);
        Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
        Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("OS", -1);
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("INVBROJ");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOSVRSTA");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVOS");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAMSKUPINE");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KTONABAVKEIDKONTO");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KTOISPRAVKAIDKONTO");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KTOIZVORAIDKONTO");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMNABAVKE");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMUPORABE");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAPOMENAOS");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPISAMSKUPINE");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AMSKUPINASTOPA");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OS_OSTEMELJNICA");
        Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("OS_OSTEMELJNICA", 0);
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("INVBROJ");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOSDOKUMENT");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSBROJDOKUMENTA");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSDATUMDOK");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSKOLICINA");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSSTOPA");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn32 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSOSNOVICA");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn33 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSDUGUJE");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn34 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSPOTRAZUJE");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn35 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RASHODLOKACIJEIDLOKACIJE");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn36 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSOPIS");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn37 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVOSDOKUMENT");
        Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
        Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand4 = new Infragistics.Win.UltraWinGrid.UltraGridBand("OSDOKUMENT", -1);
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn38 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOSDOKUMENT");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn39 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVOSDOKUMENT");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn40 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSDK");
        Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
        Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand5 = new Infragistics.Win.UltraWinGrid.UltraGridBand("S_OS_STANJE_LOKACIJA", -1);
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn41 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDLOKACIJE");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn42 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("INVBROJ");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn43 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ULAZ");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn44 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IZLAZ");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn45 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("STANJE");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn46 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPISLOKACIJE");
        Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
        Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedTop, new System.Guid("af1f5aba-39f1-4309-b7c9-1361af01bdbb"));
        Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("788d396d-e0a5-42dc-a593-51e9a900e694"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("af1f5aba-39f1-4309-b7c9-1361af01bdbb"), -1);
        this.Panel1 = new System.Windows.Forms.Panel();
        this.Button3 = new System.Windows.Forms.Button();
        this.Button1 = new System.Windows.Forms.Button();
        this.Button2 = new System.Windows.Forms.Button();
        this.OsDataSet1 = new Placa.OSDataSet();
        this.UltraGrid2 = new Infragistics.Win.UltraWinGrid.UltraGrid();
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
        this.WindowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
        this.DockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
        this.Panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.OsDataSet1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.UltraGrid2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.MT)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.PROMJENA)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.OsdokumentDataSet1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.LOKACIJE)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.S_OS_STANJE_LOKACIJADataSet1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).BeginInit();
        this.WindowDockingArea1.SuspendLayout();
        this.DockableWindow1.SuspendLayout();
        this.SuspendLayout();
        // 
        // Panel1
        // 
        this.Panel1.Controls.Add(this.Button3);
        this.Panel1.Controls.Add(this.Button1);
        this.Panel1.Controls.Add(this.Button2);
        this.Panel1.Location = new System.Drawing.Point(0, 18);
        this.Panel1.Name = "Panel1";
        this.Panel1.Size = new System.Drawing.Size(1206, 48);
        this.Panel1.TabIndex = 17;
        // 
        // Button3
        // 
        this.Button3.Location = new System.Drawing.Point(235, 15);
        this.Button3.Name = "Button3";
        this.Button3.Size = new System.Drawing.Size(102, 23);
        this.Button3.TabIndex = 17;
        this.Button3.Text = "Smanjenje vr.";
        this.Button3.UseVisualStyleBackColor = true;
        this.Button3.Click += new System.EventHandler(this.Button3_Click);
        // 
        // Button1
        // 
        this.Button1.Location = new System.Drawing.Point(18, 15);
        this.Button1.Name = "Button1";
        this.Button1.Size = new System.Drawing.Size(103, 23);
        this.Button1.TabIndex = 3;
        this.Button1.Text = "Rashod";
        this.Button1.UseVisualStyleBackColor = true;
        this.Button1.Click += new System.EventHandler(this.Button1_Click);
        // 
        // Button2
        // 
        this.Button2.Location = new System.Drawing.Point(127, 15);
        this.Button2.Name = "Button2";
        this.Button2.Size = new System.Drawing.Size(102, 23);
        this.Button2.TabIndex = 16;
        this.Button2.Text = "Povećanje vr.";
        this.Button2.UseVisualStyleBackColor = true;
        this.Button2.Click += new System.EventHandler(this.Button2_Click);
        // 
        // OsDataSet1
        // 
        this.OsDataSet1.DataSetName = "OSDataSet";
        // 
        // UltraGrid2
        // 
        this.UltraGrid2.DataMember = "OSTEMELJNICA";
        this.UltraGrid2.DataSource = this.OsDataSet1;
        ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        ultraGridColumn1.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
        ultraGridColumn1.Header.VisiblePosition = 0;
        ultraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
        ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        ultraGridColumn2.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
        ultraGridColumn2.Header.VisiblePosition = 6;
        ultraGridColumn2.Hidden = true;
        ultraGridColumn2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
        ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        ultraGridColumn3.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
        ultraGridColumn3.Header.VisiblePosition = 7;
        ultraGridColumn3.Hidden = true;
        ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        ultraGridColumn4.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
        ultraGridColumn4.Header.VisiblePosition = 8;
        ultraGridColumn4.Hidden = true;
        ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        ultraGridColumn5.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
        ultraGridColumn5.Header.Caption = "Količina";
        ultraGridColumn5.Header.VisiblePosition = 1;
        ultraGridColumn5.MaskInput = "-nnnnnnnnn.nn";
        ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        ultraGridColumn6.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
        ultraGridColumn6.Header.VisiblePosition = 9;
        ultraGridColumn6.Hidden = true;
        ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        ultraGridColumn7.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
        ultraGridColumn7.Header.VisiblePosition = 10;
        ultraGridColumn7.Hidden = true;
        ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        appearance1.TextHAlignAsString = "Right";
        ultraGridColumn8.CellAppearance = appearance1;
        ultraGridColumn8.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
        ultraGridColumn8.Header.Caption = "Duguje";
        ultraGridColumn8.Header.VisiblePosition = 2;
        ultraGridColumn8.MaskInput = "-nnnnnnnnn.nn";
        ultraGridColumn8.Width = 151;
        ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        appearance22.TextHAlignAsString = "Right";
        ultraGridColumn9.CellAppearance = appearance22;
        ultraGridColumn9.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
        ultraGridColumn9.Header.Caption = "Potražuje";
        ultraGridColumn9.Header.VisiblePosition = 3;
        ultraGridColumn9.MaskInput = "-nnnnnnnnn.nn";
        ultraGridColumn9.Width = 142;
        ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        ultraGridColumn10.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
        ultraGridColumn10.Header.Caption = "Lokacija (kod rashoda)";
        ultraGridColumn10.Header.VisiblePosition = 5;
        ultraGridColumn10.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
        ultraGridColumn10.Width = 310;
        ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        ultraGridColumn11.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
        ultraGridColumn11.Header.Caption = "Opis stavke";
        ultraGridColumn11.Header.VisiblePosition = 4;
        ultraGridColumn11.Width = 302;
        ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn12.Header.VisiblePosition = 11;
        ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12});
        appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
        appearance23.FontData.BoldAsString = "True";
        appearance23.TextHAlignAsString = "Right";
        summarySettings1.Appearance = appearance23;
        summarySettings1.DisplayFormat = "{0:#,##0.00}";
        summarySettings1.GroupBySummaryValueAppearance = appearance24;
        summarySettings1.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.TopFixed;
        appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
        appearance25.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
        appearance25.FontData.BoldAsString = "True";
        appearance25.TextHAlignAsString = "Right";
        summarySettings2.Appearance = appearance25;
        summarySettings2.DisplayFormat = "{0:#,##0.00}";
        summarySettings2.GroupBySummaryValueAppearance = appearance26;
        summarySettings2.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.TopFixed;
        ultraGridBand1.Summaries.AddRange(new Infragistics.Win.UltraWinGrid.SummarySettings[] {
            summarySettings1,
            summarySettings2});
        ultraGridBand1.SummaryFooterCaption = "UKUPNO:";
        this.UltraGrid2.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
        this.UltraGrid2.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
        this.UltraGrid2.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
        this.UltraGrid2.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.True;
        this.UltraGrid2.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
        this.UltraGrid2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
        this.UltraGrid2.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
        this.UltraGrid2.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
        this.UltraGrid2.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
        this.UltraGrid2.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
        this.UltraGrid2.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None;
        this.UltraGrid2.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
        this.UltraGrid2.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
        this.UltraGrid2.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControlOnLastCell;
        this.UltraGrid2.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
        this.UltraGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.UltraGrid2.Location = new System.Drawing.Point(0, 71);
        this.UltraGrid2.Name = "UltraGrid2";
        this.UltraGrid2.Size = new System.Drawing.Size(1206, 522);
        this.UltraGrid2.TabIndex = 2;
        this.UltraGrid2.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.UltraGrid2_InitializeLayout);
        this.UltraGrid2.BeforeCellDeactivate += new System.ComponentModel.CancelEventHandler(this.UltraGrid2_BeforeCellDeactivate);
        this.UltraGrid2.CellDataError += new Infragistics.Win.UltraWinGrid.CellDataErrorEventHandler(this.UltraGrid2_CellDataError);
        // 
        // MT
        // 
        this.MT.DataMember = "OS";
        this.MT.DataSource = this.OsDataSet1;
        appearance.BackColor = System.Drawing.Color.White;
        this.MT.DisplayLayout.Appearance = appearance;
        ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn13.Header.VisiblePosition = 0;
        ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn14.Header.VisiblePosition = 1;
        ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn15.Header.VisiblePosition = 2;
        ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn16.Header.VisiblePosition = 3;
        ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn17.Header.VisiblePosition = 4;
        ultraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn18.Header.VisiblePosition = 5;
        ultraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn19.Header.VisiblePosition = 6;
        ultraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn20.Header.VisiblePosition = 7;
        ultraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn21.Header.VisiblePosition = 8;
        ultraGridColumn22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn22.Header.VisiblePosition = 9;
        ultraGridColumn23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn23.Header.VisiblePosition = 10;
        ultraGridColumn24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn24.Header.VisiblePosition = 12;
        ultraGridColumn25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn25.Header.VisiblePosition = 11;
        ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn22,
            ultraGridColumn23,
            ultraGridColumn24,
            ultraGridColumn25});
        ultraGridBand2.UseRowLayout = true;
        ultraGridColumn26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn26.Header.VisiblePosition = 0;
        ultraGridColumn27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn27.Header.VisiblePosition = 1;
        ultraGridColumn28.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn28.Header.VisiblePosition = 2;
        ultraGridColumn29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn29.Header.VisiblePosition = 3;
        ultraGridColumn30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn30.Header.VisiblePosition = 4;
        ultraGridColumn31.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn31.Header.VisiblePosition = 5;
        ultraGridColumn32.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn32.Header.VisiblePosition = 6;
        ultraGridColumn33.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn33.Header.VisiblePosition = 7;
        ultraGridColumn34.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn34.Header.VisiblePosition = 8;
        ultraGridColumn35.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn35.Header.VisiblePosition = 9;
        ultraGridColumn36.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn36.Header.VisiblePosition = 10;
        ultraGridColumn37.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn37.Header.VisiblePosition = 11;
        ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn28,
            ultraGridColumn29,
            ultraGridColumn30,
            ultraGridColumn31,
            ultraGridColumn32,
            ultraGridColumn33,
            ultraGridColumn34,
            ultraGridColumn35,
            ultraGridColumn36,
            ultraGridColumn37});
        this.MT.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
        this.MT.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
        this.MT.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
        appearance12.BackColor = System.Drawing.Color.Transparent;
        this.MT.DisplayLayout.Override.CardAreaAppearance = appearance12;
        this.MT.DisplayLayout.Override.CellPadding = 3;
        appearance15.TextHAlignAsString = "Left";
        this.MT.DisplayLayout.Override.HeaderAppearance = appearance15;
        appearance16.BorderColor = System.Drawing.Color.LightGray;
        appearance16.TextVAlignAsString = "Middle";
        this.MT.DisplayLayout.Override.RowAppearance = appearance16;
        this.MT.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
        appearance17.BackColor = System.Drawing.Color.LightSteelBlue;
        appearance17.BorderColor = System.Drawing.Color.Black;
        appearance17.ForeColor = System.Drawing.Color.Black;
        this.MT.DisplayLayout.Override.SelectedRowAppearance = appearance17;
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
        this.PROMJENA.DataMember = "OSDOKUMENT";
        this.PROMJENA.DataSource = this.OsdokumentDataSet1;
        appearance18.BackColor = System.Drawing.Color.White;
        this.PROMJENA.DisplayLayout.Appearance = appearance18;
        ultraGridColumn38.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn38.Header.VisiblePosition = 0;
        ultraGridColumn39.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn39.Header.VisiblePosition = 1;
        ultraGridColumn40.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn40.Header.VisiblePosition = 2;
        ultraGridBand4.Columns.AddRange(new object[] {
            ultraGridColumn38,
            ultraGridColumn39,
            ultraGridColumn40});
        this.PROMJENA.DisplayLayout.BandsSerializer.Add(ultraGridBand4);
        this.PROMJENA.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
        appearance19.BackColor = System.Drawing.Color.Transparent;
        this.PROMJENA.DisplayLayout.Override.CardAreaAppearance = appearance19;
        this.PROMJENA.DisplayLayout.Override.CellPadding = 3;
        appearance20.TextHAlignAsString = "Left";
        this.PROMJENA.DisplayLayout.Override.HeaderAppearance = appearance20;
        appearance21.BorderColor = System.Drawing.Color.LightGray;
        appearance21.TextVAlignAsString = "Middle";
        this.PROMJENA.DisplayLayout.Override.RowAppearance = appearance21;
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
        this.LOKACIJE.DataMember = "S_OS_STANJE_LOKACIJA";
        this.LOKACIJE.DataSource = this.S_OS_STANJE_LOKACIJADataSet1;
        appearance3.BackColor = System.Drawing.Color.White;
        this.LOKACIJE.DisplayLayout.Appearance = appearance3;
        ultraGridColumn41.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn41.Header.VisiblePosition = 0;
        ultraGridColumn42.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn42.Header.VisiblePosition = 1;
        ultraGridColumn43.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn43.Header.VisiblePosition = 2;
        ultraGridColumn44.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn44.Header.VisiblePosition = 3;
        ultraGridColumn45.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn45.Header.VisiblePosition = 4;
        ultraGridColumn46.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn46.Header.VisiblePosition = 5;
        ultraGridBand5.Columns.AddRange(new object[] {
            ultraGridColumn41,
            ultraGridColumn42,
            ultraGridColumn43,
            ultraGridColumn44,
            ultraGridColumn45,
            ultraGridColumn46});
        this.LOKACIJE.DisplayLayout.BandsSerializer.Add(ultraGridBand5);
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
        dockableControlPane1.Control = this.Panel1;
        dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(62, 3, 384, 58);
        dockableControlPane1.Size = new System.Drawing.Size(100, 100);
        dockableControlPane1.Text = "Unos temeljnica rashoda, smanjenja i povećanja vrijednosti";
        dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
        dockAreaPane1.Size = new System.Drawing.Size(1206, 66);
        this.UltraDockManager1.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1});
        this.UltraDockManager1.HostControl = this;
        this.UltraDockManager1.UseAppStyling = false;
        this.UltraDockManager1.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2007;
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
        this._UnosTemeljniceAutoHideControl.Size = new System.Drawing.Size(0, 593);
        this._UnosTemeljniceAutoHideControl.TabIndex = 23;
        // 
        // WindowDockingArea1
        // 
        this.WindowDockingArea1.Controls.Add(this.DockableWindow1);
        this.WindowDockingArea1.Dock = System.Windows.Forms.DockStyle.Top;
        this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        this.WindowDockingArea1.Location = new System.Drawing.Point(0, 0);
        this.WindowDockingArea1.Name = "WindowDockingArea1";
        this.WindowDockingArea1.Owner = this.UltraDockManager1;
        this.WindowDockingArea1.Size = new System.Drawing.Size(1206, 71);
        this.WindowDockingArea1.TabIndex = 24;
        // 
        // DockableWindow1
        // 
        this.DockableWindow1.Controls.Add(this.Panel1);
        this.DockableWindow1.Location = new System.Drawing.Point(0, 0);
        this.DockableWindow1.Name = "DockableWindow1";
        this.DockableWindow1.Owner = this.UltraDockManager1;
        this.DockableWindow1.Size = new System.Drawing.Size(1206, 66);
        this.DockableWindow1.TabIndex = 25;
        // 
        // UnosTemeljnice
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Controls.Add(this._UnosTemeljniceAutoHideControl);
        this.Controls.Add(this.UltraGrid2);
        this.Controls.Add(this.LOKACIJE);
        this.Controls.Add(this.PROMJENA);
        this.Controls.Add(this.MT);
        this.Controls.Add(this.WindowDockingArea1);
        this.Controls.Add(this._UnosTemeljniceUnpinnedTabAreaTop);
        this.Controls.Add(this._UnosTemeljniceUnpinnedTabAreaBottom);
        this.Controls.Add(this._UnosTemeljniceUnpinnedTabAreaLeft);
        this.Controls.Add(this._UnosTemeljniceUnpinnedTabAreaRight);
        this.Name = "UnosTemeljnice";
        this.Size = new System.Drawing.Size(1206, 593);
        this.Panel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.OsDataSet1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.UltraGrid2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.MT)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.PROMJENA)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.OsdokumentDataSet1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.LOKACIJE)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.S_OS_STANJE_LOKACIJADataSet1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).EndInit();
        this.WindowDockingArea1.ResumeLayout(false);
        this.DockableWindow1.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    [CommandHandler("IspisTemeljnice")]
    public void IspisTemeljniceHandler(object sender, EventArgs e)
    {
        if (Operators.ConditionalCompareObjectEqual(this.otvorendokument, false, false))
        {
            Interaction.MsgBox("Otvorite dokument", MsgBoxStyle.OkOnly, null);
        }
        else
        {
            ReportDocument document = new ReportDocument();
            document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptOsTemeljnica.rpt");
            document.SetDataSource(this.OsDataSet1);
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
    }

    [CommandHandler("IspisTemeljniceRekap")]
    public void IspisTemeljniceRekapHandler(object sender, EventArgs e)
    {
        if (Operators.ConditionalCompareObjectEqual(this.otvorendokument, false, false))
        {
            Interaction.MsgBox("Otvorite dokument", MsgBoxStyle.OkOnly, null);
        }
        else
        {
            ReportDocument document = new ReportDocument();
            document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptOSTemeljnicaRekap.rpt");
            S_OS_REKAP_TEMELJNICEDataAdapter adapter = new S_OS_REKAP_TEMELJNICEDataAdapter();
            S_OS_REKAP_TEMELJNICEDataSet dataSet = new S_OS_REKAP_TEMELJNICEDataSet();
            adapter.Fill(dataSet, this.brojtemeljnice, Conversions.ToInteger(this.OsDataSet1.OSTEMELJNICA.Rows[0]["IDOSDOKUMENT"]));
            document.SetDataSource(dataSet);
            KORISNIKDataSet set2 = new KORISNIKDataSet();
            new KORISNIKDataAdapter().Fill(set2);
            document.SetParameterValue("ustanova", RuntimeHelpers.GetObjectValue(set2.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
            document.SetParameterValue("ustanova2", Operators.AddObject(Operators.AddObject(set2.KORISNIK.Rows[0]["KORISNIK1ADRESA"], " "), set2.KORISNIK.Rows[0]["KORISNIK1MJESTO"]));
            document.SetParameterValue("tel", RuntimeHelpers.GetObjectValue(set2.KORISNIK.Rows[0]["KONTAKTTELEFON"]));
            document.SetParameterValue("fax", RuntimeHelpers.GetObjectValue(set2.KORISNIK.Rows[0]["KONTAKTFAX"]));
            document.SetParameterValue("oib", RuntimeHelpers.GetObjectValue(set2.KORISNIK.Rows[0]["KORISNIKOIB"]));
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
    }

    public void KreirajNovu(int kojavrsta)
    {
        FrmBrojIDatum datum = new FrmBrojIDatum();
        if (datum.ShowDialog() == DialogResult.OK)
        {
            this.OsDataSet1.Clear();
            this.DAOS.Fill(this.OsDataSet1);
            this.DOK.FillByIDOSDOKUMENT(this.OsdokumentDataSet1, 3);
            this.DOK.FillByIDOSDOKUMENT(this.OsdokumentDataSet1, 4);
            this.DOK.FillByIDOSDOKUMENT(this.OsdokumentDataSet1, 5);
            this.OsDataSet1.OSTEMELJNICA.Clear();
            this.OsDataSet1.OSTEMELJNICA.AcceptChanges();
            this.brojtemeljnice = Conversions.ToInteger(datum.BROJTEMELJNICE.Value);
            this.datum = datum.DATUMTEMELJNICE.Value;
            this.otvorendokument = true;
            if (kojavrsta == 3)
            {
                this.Button1.Enabled = true;
                this.Button2.Enabled = false;
                this.Button3.Enabled = false;
            }
            if (kojavrsta == 4)
            {
                this.Button1.Enabled = false;
                this.Button2.Enabled = true;
                this.Button3.Enabled = false;
            }
            if (kojavrsta == 5)
            {
                this.Button1.Enabled = false;
                this.Button2.Enabled = false;
                this.Button3.Enabled = true;
            }
        }
        else
        {
            this.otvorendokument = false;
            Interaction.MsgBox("Odustali ste od kreiranja temeljnice!", MsgBoxStyle.OkOnly, null);
        }
    }

    [CommandHandler("KreirajPovecanje")]
    public void KreirajNovuPovecanjeHandler(object sender, EventArgs e)
    {
        if (Operators.ConditionalCompareObjectEqual(this.otvorendokument, true, false))
        {
            Interaction.MsgBox("Zatvorite postojeći dokument!", MsgBoxStyle.OkOnly, null);
        }
        else
        {
            this.KreirajNovu(4);
        }
    }

    [CommandHandler("KreirajSmanjenje")]
    public void KreirajNovuSmanjenjeHandler(object sender, EventArgs e)
    {
        if (Operators.ConditionalCompareObjectEqual(this.otvorendokument, true, false))
        {
            Interaction.MsgBox("Zatvorite postojeći dokument!", MsgBoxStyle.OkOnly, null);
        }
        else
        {
            this.KreirajNovu(5);
        }
    }

    [CommandHandler("KreirajRashod")]
    public void OtvoriCommandHandler(object sender, EventArgs e)
    {
        if (Operators.ConditionalCompareObjectEqual(this.otvorendokument, true, false))
        {
            Interaction.MsgBox("Zatvorite postojeći dokument!", MsgBoxStyle.OkOnly, null);
        }
        else
        {
            this.KreirajNovu(3);
        }
    }

    public void OtvoriPostojecu()
    {
        frmPregledPostojecih postojecih = new frmPregledPostojecih(0);
        if (postojecih.ShowDialog() == DialogResult.OK)
        {
            if (postojecih.__BrojPostojeceg != null)
            {
                OSDataSet dataSet = new OSDataSet();
                this.OsDataSet1.OSTEMELJNICA.Clear();
                this.OsDataSet1.OSTEMELJNICA.AcceptChanges();
                this.brojtemeljnice = Conversions.ToInteger(postojecih.__BrojPostojeceg);
                this.otvorendokument = true;
                this.DAOS.Fill(dataSet);
                this.OsDataSet1.Merge(dataSet.OS);
                this.OsDataSet1.Merge(dataSet.OSTEMELJNICA.Select("osbrojdokumenta = " + Conversions.ToString(this.brojtemeljnice)));
                DataView view = new DataView
                {
                    Table = dataSet.OSTEMELJNICA,
                    Sort = "OSBROJDOKUMENTA DESC"
                };
                if (Operators.ConditionalCompareObjectLess(this.brojtemeljnice, view[0]["OSBROJDOKUMENTA"], false))
                {
                    Interaction.MsgBox("Nije zadnji dokument", MsgBoxStyle.OkOnly, null);
                    this.Button1.Enabled = false;
                    this.Button2.Enabled = false;
                    this.Button3.Enabled = false;
                }
                else
                {
                    if (Operators.ConditionalCompareObjectEqual(postojecih.___Vrsta, 3, false))
                    {
                        this.datum = Conversions.ToDate(postojecih.___Datum);
                        this.Button1.Enabled = true;
                        this.Button2.Enabled = false;
                        this.Button3.Enabled = false;
                    }
                    if (Operators.ConditionalCompareObjectEqual(postojecih.___Vrsta, 4, false))
                    {
                        this.datum = Conversions.ToDate(postojecih.___Datum);
                        this.Button1.Enabled = false;
                        this.Button2.Enabled = true;
                        this.Button3.Enabled = false;
                    }
                    if (Operators.ConditionalCompareObjectEqual(postojecih.___Vrsta, 5, false))
                    {
                        this.datum = Conversions.ToDate(postojecih.___Datum);
                        this.Button1.Enabled = false;
                        this.Button2.Enabled = false;
                        this.Button3.Enabled = true;
                    }
                }
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
        else
        {
            this.OtvoriPostojecu();
        }
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

    public void unos_stavke_povecanja()
    {
        frmPregledZaRashod rashod = new frmPregledZaRashod {
            Text = "Odabir sredstva za povećanje vrijednosti"
        };
        rashod.ShowDialog();
        if ((rashod.RedakRashoda != null) & (rashod.DialogResult == DialogResult.OK))
        {
            int num3 = Conversions.ToInteger(rashod.RedakRashoda[0]);
            int invbroj = Conversions.ToInteger(rashod.RedakRashoda[1]);
            S_OS_STANJE_FINANCIJSKODataSet dataSet = new S_OS_STANJE_FINANCIJSKODataSet();
            new S_OS_STANJE_FINANCIJSKODataAdapter().Fill(dataSet, (long) invbroj);
            frmIznosi iznosi = new frmIznosi {
                iznos = { Value = 0 }
            };
            iznosi.ShowDialog();
            if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectGreater(iznosi.iznos.Value, 0, false), iznosi.DialogResult == DialogResult.OK)))
            {
                this.Dodaj_Stavku_Povecanja(invbroj, Conversions.ToDecimal(iznosi.iznos.Value));
            }
        }
    }

    public void unos_stavke_rashoda()
    {
        frmPregledZaRashod rashod = new frmPregledZaRashod {
            Text = "Odabir sredstva za rashod"
        };
        rashod.ShowDialog();
        if ((rashod.RedakRashoda != null) & (rashod.DialogResult == DialogResult.OK))
        {
            int lok = Conversions.ToInteger(rashod.RedakRashoda[0]);
            int invbroj = Conversions.ToInteger(rashod.RedakRashoda[1]);
            int left = Conversions.ToInteger(rashod.RedakRashoda[4]);
            S_OS_STANJE_FINANCIJSKODataSet dataSet = new S_OS_STANJE_FINANCIJSKODataSet();
            new S_OS_STANJE_FINANCIJSKODataAdapter().Fill(dataSet, (long) invbroj);
            if (left == 1)
            {
                this.Dodaj_Stavku_Rashoda(invbroj, lok, 0 - left, Conversions.ToDecimal(dataSet.S_OS_STANJE_FINANCIJSKO.Rows[0]["ispravak"]), Conversions.ToDecimal(dataSet.S_OS_STANJE_FINANCIJSKO.Rows[0]["nabavna"]));
            }
            else
            {
                frmKolicina kolicina = new frmKolicina {
                    kolicina = { MaxValue = RuntimeHelpers.GetObjectValue(dataSet.S_OS_STANJE_FINANCIJSKO.Rows[0]["kolicina"]), Value = RuntimeHelpers.GetObjectValue(dataSet.S_OS_STANJE_FINANCIJSKO.Rows[0]["kolicina"]) }
                };
                kolicina.ShowDialog();
                if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectGreater(kolicina.kolicina.Value, 0, false), kolicina.DialogResult == DialogResult.OK)))
                {
                    left = Conversions.ToInteger(kolicina.kolicina.Value);
                    if (Operators.ConditionalCompareObjectEqual(left, dataSet.S_OS_STANJE_FINANCIJSKO.Rows[0]["kolicina"], false))
                    {
                        this.Dodaj_Stavku_Rashoda(invbroj, lok, 0 - left, Conversions.ToDecimal(dataSet.S_OS_STANJE_FINANCIJSKO.Rows[0]["ispravak"]), Conversions.ToDecimal(dataSet.S_OS_STANJE_FINANCIJSKO.Rows[0]["nabavna"]));
                    }
                    else
                    {
                        decimal num5 = DB.RoundUpDecimale(Operators.DivideObject(dataSet.S_OS_STANJE_FINANCIJSKO.Rows[0]["nabavna"], dataSet.S_OS_STANJE_FINANCIJSKO.Rows[0]["kolicina"]), 2);
                        decimal num4 = DB.RoundUpDecimale(Operators.DivideObject(dataSet.S_OS_STANJE_FINANCIJSKO.Rows[0]["ispravak"], dataSet.S_OS_STANJE_FINANCIJSKO.Rows[0]["kolicina"]), 2);
                        num5 = decimal.Multiply(num5, new decimal(left));
                        num4 = decimal.Multiply(num4, new decimal(left));
                        this.Dodaj_Stavku_Rashoda(invbroj, lok, 0 - left, num4, num5);
                    }
                }
            }
        }
    }

    public void Unos_Stavke_Smanjenja()
    {
        frmPregledZaRashod rashod = new frmPregledZaRashod {
            Text = "Odabir sredstva za smanjenje vrijednosti"
        };
        rashod.ShowDialog();
        if ((rashod.RedakRashoda != null) & (rashod.DialogResult == DialogResult.OK))
        {
            int num3 = Conversions.ToInteger(rashod.RedakRashoda[0]);
            int invbroj = Conversions.ToInteger(rashod.RedakRashoda[1]);
            S_OS_STANJE_FINANCIJSKODataSet dataSet = new S_OS_STANJE_FINANCIJSKODataSet();
            new S_OS_STANJE_FINANCIJSKODataAdapter().Fill(dataSet, (long) invbroj);
            frmIznosiSmanjenje smanjenje = new frmIznosiSmanjenje {
                nabavnasmanjenje = { MaxValue = RuntimeHelpers.GetObjectValue(dataSet.S_OS_STANJE_FINANCIJSKO.Rows[0]["nabavna"]) },
                ISPRAVAKSMANJENJE = { MaxValue = RuntimeHelpers.GetObjectValue(dataSet.S_OS_STANJE_FINANCIJSKO.Rows[0]["ispravak"]) }
            };
            smanjenje.ShowDialog();
            if (Conversions.ToBoolean(Operators.AndObject(Operators.OrObject(Operators.CompareObjectGreater(smanjenje.nabavnasmanjenje.Value, 0, false), Operators.CompareObjectGreater(smanjenje.ISPRAVAKSMANJENJE.Value, 0, false)), smanjenje.DialogResult == DialogResult.OK)))
            {
                decimal nabavna = Conversions.ToDecimal(smanjenje.nabavnasmanjenje.Value);
                decimal ispravak = Conversions.ToDecimal(smanjenje.ISPRAVAKSMANJENJE.Value);
                this.Dodaj_Stavku_Smanjenja(invbroj, nabavna, ispravak);
            }
        }
    }

    private void UnosTemeljnice_Load(object sender, EventArgs e)
    {
        InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
        this.Button1.Enabled = false;
        this.Button2.Enabled = false;
        this.Button3.Enabled = false;
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
            this.OsDataSet1.OSTEMELJNICA.Clear();
            this.OsDataSet1.OSTEMELJNICA.AcceptChanges();
            this.otvorendokument = false;
            this.Button1.Enabled = false;
            this.Button2.Enabled = false;
            this.Button3.Enabled = false;
        }
    }

    private AutoHideControl _UnosTemeljniceAutoHideControl;

    private UnpinnedTabArea _UnosTemeljniceUnpinnedTabAreaBottom;

    private UnpinnedTabArea _UnosTemeljniceUnpinnedTabAreaLeft;

    private UnpinnedTabArea _UnosTemeljniceUnpinnedTabAreaRight;

    private UnpinnedTabArea _UnosTemeljniceUnpinnedTabAreaTop;

    private Button Button1;

    private Button Button2;

    private Button Button3;

    [CreateNew]
    public ListaIznosaController Controller { get; set; }

    private DockableWindow DockableWindow1;

    private UltraDropDown LOKACIJE;

    private UltraDropDown MT;

    private OSDataSet OsDataSet1;

    private OSDOKUMENTDataSet OsdokumentDataSet1;

    private Panel Panel1;

    private UltraDropDown PROMJENA;

    private S_OS_STANJE_LOKACIJADataSet S_OS_STANJE_LOKACIJADataSet1;

    private UltraDockManager UltraDockManager1;

    private UltraGrid UltraGrid2;

    private WindowDockingArea WindowDockingArea1;
}


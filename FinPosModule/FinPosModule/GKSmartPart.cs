using CrystalDecisions.CrystalReports.Engine;
using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.Workspaces;
using Deklarit.Resources;
using FinPosModule.GK;
using FinPosModule.Otvorene;
using Hlp;
using Infragistics.Practices.CompositeUI.WinForms;
using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinCalcManager;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NetAdvantage;
using NetAdvantage.WorkItems;
using mipsed.application.framework;
using Placa;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Collections.Generic;

namespace FinPosModule
{

    [SmartPart]
    public class GKSmartPart : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private IContainer components;
        private GKSTAVKADataAdapter dagk;
        private GKSTAVKADataAdapter daGKSTAVKA;
        private SmartPartInfoProvider infoProvider;
        private DateTime pocetniDatum;
        private object povecavaj;
        private SmartPartInfo smartPartInfo1;
        private UltraExplorerBarWorkspace work;
        private object zaizlaz;
        private DateTime zavrsniDatum;

        public static int pocetna_temeljnica = 0;
        public static int zavrsna_temeljnica = 0;

        public GKSmartPart()
        {
            base.Disposed += new EventHandler(this.GKSmartPart_Disposed);
            base.GotFocus += new EventHandler(this.GKSmartPart_GotFocus);
            base.Leave += new EventHandler(this.GKSmartPart_Leave);
            base.Load += new EventHandler(this.TestSmartPart_Load);
            this.dagk = new GKSTAVKADataAdapter();
            this.daGKSTAVKA = new GKSTAVKADataAdapter();
            this.povecavaj = true;
            //this.unospartnera = false;
            this.zaizlaz = false;
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo("Glavna knjiga", "Glavna knjiga");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);

        }

        private void dvo_EditorButtonClick(object sender, EditorButtonEventArgs e)
        {
            if (this.GkstavkaDataSet1.GKSTAVKA.Rows.Count != 0)
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = this.GkstavkaDataSet1.GKSTAVKA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataRow current = (DataRow) enumerator.Current;
                        current.BeginEdit();
                        current["datumdokumenta"] = RuntimeHelpers.GetObjectValue(this.dteDatumDokumenta.Value);
                        current.EndEdit();
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                this.Spremi_Promjene();
            }
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        private void GKSmartPart_Disposed(object sender, EventArgs e)
        {
        }

        private void GKSmartPart_GotFocus(object sender, EventArgs e)
        {
        }

        private void GKSmartPart_Leave(object sender, EventArgs e)
        {
            UltraDockSmartPartInfo smartPartInfo = new UltraDockSmartPartInfo {
                DefaultPaneStyle = ChildPaneStyle.VerticalSplit,
                Description = Deklarit.Resources.Resources.Tasks
            };
            Size size = new System.Drawing.Size(210, 100);
            smartPartInfo.PreferredSize = size;
            smartPartInfo.Title = Deklarit.Resources.Resources.Tasks;
            smartPartInfo.DefaultLocation = DockedLocation.DockedRight;
            this.Controller.WorkItem.Workspaces["Dock"].Show(this.work, smartPartInfo);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("MJESTOTROSKA", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDMJESTOTROSKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVMJESTOTROSKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("mt");
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ORGJED", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDORGJED");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVORGJED");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn32 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("oj");
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand4 = new Infragistics.Win.UltraWinGrid.UltraGridBand("PARTNER", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn33 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPARTNER", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn34 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVPARTNER");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn35 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MB");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn36 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNERMJESTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn37 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNERULICA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn38 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNEREMAIL");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn39 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNEROIB");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn40 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNERFAX");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn41 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNERTELEFON");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn42 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNERZIRO1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn43 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNERZIRO2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn44 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn45 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNER_PARTNERZADUZENJE");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand5 = new Infragistics.Win.UltraWinGrid.UltraGridBand("PARTNER_PARTNERZADUZENJE", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn46 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPARTNER");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn47 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDZADUZENJE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn48 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPROIZVOD");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn49 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVPROIZVOD");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn50 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CIJENA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn51 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KOLICINAZADUZENJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn52 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CIJENAZADUZENJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn53 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IZNOSZADUZENJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn54 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RABATZADUZENJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn55 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IZNOSRABATAZADUZENJE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn56 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CIJENAZAFAKTURU");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn57 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UGOVORBROJ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn58 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMUGOVORA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn59 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AKTIVNO");
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand6 = new Infragistics.Win.UltraWinGrid.UltraGridBand("KONTO", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn60 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn61 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVKONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn62 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAKTIVNOST");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn63 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVAKTIVNOST");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn64 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KONT");
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton2 = new Infragistics.Win.UltraWinEditors.EditorButton("Uneseni");
            Infragistics.Win.UltraWinEditors.EditorButton editorButton3 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("GKSTAVKA", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGKSTAVKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAKTIVNOST");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMDOKUMENTA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BROJDOKUMENTA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BROJSTAVKE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDDOKUMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVDOKUMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDMJESTOTROSKA", -1, "MT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVMJESTOTROSKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDORGJED", -1, "OJ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVORGJED");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKONTO", -1, "KONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVKONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVAKTIVNOST");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPIS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("duguje");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POTRAZUJE");
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMPRIJAVE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPARTNER", -1, "UltraDropDown1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVPARTNER");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZATVORENIIZNOS");
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GKDATUMVALUTE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("statusgk");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ORIGINALNIDOKUMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GKGODIDGODINE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("saldo", 0);
            Infragistics.Win.UltraWinGrid.SummarySettings summarySettings1 = new Infragistics.Win.UltraWinGrid.SummarySettings("UKUPNODUGUJE", Infragistics.Win.UltraWinGrid.SummaryType.Sum, null, "duguje", 15, true, "GKSTAVKA", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, null, -1, false);
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.SummarySettings summarySettings2 = new Infragistics.Win.UltraWinGrid.SummarySettings("UKUPNOPOTRAZUJE", Infragistics.Win.UltraWinGrid.SummaryType.Sum, null, "POTRAZUJE", 16, true, "GKSTAVKA", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, null, -1, false);
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.SummarySettings summarySettings3 = new Infragistics.Win.UltraWinGrid.SummarySettings("SALDOUKUPNO", Infragistics.Win.UltraWinGrid.SummaryType.Sum, null, "saldo", 0, false, "GKSTAVKA", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "ZATVORENIIZNOS", 20, true);
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedTop, new System.Guid("4721e7f6-c4cd-48fb-91a4-3b0da881a802"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("443653a1-052e-4c35-81fa-749924be86fb"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("4721e7f6-c4cd-48fb-91a4-3b0da881a802"), -1);
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane2 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedTop, new System.Guid("30d2afde-e535-4c6c-818c-48404d8ec380"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane2 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("fc323729-22b2-4453-a013-be19e87f9068"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("30d2afde-e535-4c6c-818c-48404d8ec380"), -1);
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane3 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.Floating, new System.Guid("0c9a1126-070b-43ca-9417-1f16f0893af8"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane3 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("ff2eed19-6758-4226-8aa5-8a2b222c1d56"), new System.Guid("0c9a1126-070b-43ca-9417-1f16f0893af8"), -1, new System.Guid("30d2afde-e535-4c6c-818c-48404d8ec380"), 1);
            this.UltraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.MT = new Infragistics.Win.UltraWinGrid.UltraDropDown();
            this.UltraCalcManager1 = new Infragistics.Win.UltraWinCalcManager.UltraCalcManager(this.components);
            this.MjestotroskaDataSet1 = new Placa.MJESTOTROSKADataSet();
            this.OJ = new Infragistics.Win.UltraWinGrid.UltraDropDown();
            this.OrgjedDataSet1 = new Placa.ORGJEDDataSet();
            this.UltraDropDown1 = new Infragistics.Win.UltraWinGrid.UltraDropDown();
            this.PartnerDataSet1 = new Placa.PARTNERDataSet();
            this.UltraLabel3 = new Infragistics.Win.Misc.UltraLabel();

            this.ulbOpis = new Infragistics.Win.Misc.UltraLabel();
            this.txtOpis = new Infragistics.Win.UltraWinEditors.UltraTextEditor();

            this.UltraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.KONTO = new Infragistics.Win.UltraWinGrid.UltraDropDown();
            this.KontoDataSet1 = new Placa.KONTODataSet();
            this.UltraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.txtNazivDokument = new Infragistics.Win.Misc.UltraLabel();
            this.txtSifrDokumenta = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtBrojDokumenta = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.dteDatumDokumenta = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.ToolBar1 = new System.Windows.Forms.ToolBar();
            this.ToolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.ToolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.ToolBarButton3 = new System.Windows.Forms.ToolBarButton();
            this.ToolBarButton4 = new System.Windows.Forms.ToolBarButton();
            this.ToolBarButton5 = new System.Windows.Forms.ToolBarButton();
            this.ToolBarButton6 = new System.Windows.Forms.ToolBarButton();
            this.ToolBarButton7 = new System.Windows.Forms.ToolBarButton();
            this.ToolBarButton8 = new System.Windows.Forms.ToolBarButton();
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Panel2 = new System.Windows.Forms.Panel();
            this.GkstavkaDataSet1 = new Placa.GKSTAVKADataSet();
            this.ugrdGK = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.UltraGridBagLayoutManager1 = new Infragistics.Win.Misc.UltraGridBagLayoutManager(this.components);
            this.UltraDockManager1 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._GKSmartPartUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._GKSmartPartUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._GKSmartPartUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._GKSmartPartUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._GKSmartPartAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.WindowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.DockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.WindowDockingArea2 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.DockableWindow2 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.DockableWindow3 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.WindowDockingArea4 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).BeginInit();
            this.UltraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraCalcManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MjestotroskaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OJ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrgjedDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDropDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartnerDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KONTO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KontoDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifrDokumenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBrojDokumenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDatumDokumenta)).BeginInit();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GkstavkaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugrdGK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGridBagLayoutManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).BeginInit();
            this.WindowDockingArea1.SuspendLayout();
            this.DockableWindow1.SuspendLayout();
            this.WindowDockingArea2.SuspendLayout();
            this.DockableWindow2.SuspendLayout();
            this.DockableWindow3.SuspendLayout();
            this.WindowDockingArea4.SuspendLayout();
            this.SuspendLayout();
            // 
            // UltraGroupBox1
            // 
            this.UltraGroupBox1.Controls.Add(this.MT);
            this.UltraGroupBox1.Controls.Add(this.OJ);
            this.UltraGroupBox1.Controls.Add(this.UltraDropDown1);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel3);
            this.UltraGroupBox1.Controls.Add(this.ulbOpis);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel2);
            this.UltraGroupBox1.Controls.Add(this.KONTO);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel1);
            this.UltraGroupBox1.Controls.Add(this.txtNazivDokument);
            this.UltraGroupBox1.Controls.Add(this.txtSifrDokumenta);
            this.UltraGroupBox1.Controls.Add(this.txtBrojDokumenta);
            this.UltraGroupBox1.Controls.Add(this.txtOpis);
            this.UltraGroupBox1.Controls.Add(this.dteDatumDokumenta);
            this.UltraGroupBox1.Location = new System.Drawing.Point(0, 18);
            this.UltraGroupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.UltraGroupBox1.Name = "UltraGroupBox1";
            this.UltraGroupBox1.Size = new System.Drawing.Size(1146, 135);
            this.UltraGroupBox1.TabIndex = 99;
            this.UltraGroupBox1.UseAppStyling = false;
            this.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            this.UltraGroupBox1.Click += new System.EventHandler(this.UltraGroupBox1_Click);
            // 
            // MT
            // 
            this.MT.CalcManager = this.UltraCalcManager1;
            this.MT.DataMember = "MJESTOTROSKA";
            this.MT.DataSource = this.MjestotroskaDataSet1;
            appearance20.BackColor = System.Drawing.Color.White;
            this.MT.DisplayLayout.Appearance = appearance20;
            ultraGridColumn27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn27.Header.VisiblePosition = 0;
            ultraGridColumn27.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(136, 0);
            ultraGridColumn28.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn28.Header.VisiblePosition = 1;
            ultraGridColumn28.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(566, 0);
            ultraGridColumn29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn29.Header.VisiblePosition = 2;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn27,
            ultraGridColumn28,
            ultraGridColumn29});
            ultraGridBand2.UseRowLayout = true;
            this.MT.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.MT.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance24.BackColor = System.Drawing.Color.Transparent;
            this.MT.DisplayLayout.Override.CardAreaAppearance = appearance24;
            this.MT.DisplayLayout.Override.CellPadding = 3;
            appearance27.TextHAlignAsString = "Left";
            this.MT.DisplayLayout.Override.HeaderAppearance = appearance27;
            appearance6.BorderColor = System.Drawing.Color.LightGray;
            appearance6.TextVAlignAsString = "Middle";
            this.MT.DisplayLayout.Override.RowAppearance = appearance6;
            this.MT.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance7.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance7.BorderColor = System.Drawing.Color.Black;
            appearance7.ForeColor = System.Drawing.Color.Black;
            this.MT.DisplayLayout.Override.SelectedRowAppearance = appearance7;
            this.MT.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.MT.DisplayMember = "IDMJESTOTROSKA";
            this.MT.DropDownSearchMethod = Infragistics.Win.UltraWinGrid.DropDownSearchMethod.Linear;
            this.MT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MT.Location = new System.Drawing.Point(472, 21);
            this.MT.Name = "MT";
            this.MT.Size = new System.Drawing.Size(107, 80);
            this.MT.TabIndex = 7;
            this.MT.ValueMember = "IDMJESTOTROSKA";
            this.MT.Visible = false;
            // 
            // UltraCalcManager1
            // 
            this.UltraCalcManager1.ContainingControl = this;
            // 
            // MjestotroskaDataSet1
            // 
            this.MjestotroskaDataSet1.DataSetName = "MJESTOTROSKADataSet";
            // 
            // OJ
            // 
            this.OJ.CalcManager = this.UltraCalcManager1;
            this.OJ.DataMember = "ORGJED";
            this.OJ.DataSource = this.OrgjedDataSet1;
            appearance11.BackColor = System.Drawing.Color.White;
            this.OJ.DisplayLayout.Appearance = appearance11;
            ultraGridColumn30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn30.Header.VisiblePosition = 0;
            ultraGridColumn30.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn30.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn30.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(146, 0);
            ultraGridColumn30.RowLayoutColumnInfo.SpanX = 3;
            ultraGridColumn30.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn31.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn31.Header.VisiblePosition = 1;
            ultraGridColumn31.RowLayoutColumnInfo.OriginX = 3;
            ultraGridColumn31.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn31.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(420, 0);
            ultraGridColumn31.RowLayoutColumnInfo.SpanX = 10;
            ultraGridColumn31.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn32.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn32.Header.VisiblePosition = 2;
            ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn30,
            ultraGridColumn31,
            ultraGridColumn32});
            ultraGridBand3.UseRowLayout = true;
            this.OJ.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
            this.OJ.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance12.BackColor = System.Drawing.Color.Transparent;
            this.OJ.DisplayLayout.Override.CardAreaAppearance = appearance12;
            this.OJ.DisplayLayout.Override.CellPadding = 3;
            appearance13.TextHAlignAsString = "Left";
            this.OJ.DisplayLayout.Override.HeaderAppearance = appearance13;
            appearance14.BorderColor = System.Drawing.Color.LightGray;
            appearance14.TextVAlignAsString = "Middle";
            this.OJ.DisplayLayout.Override.RowAppearance = appearance14;
            this.OJ.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance15.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance15.BorderColor = System.Drawing.Color.Black;
            appearance15.ForeColor = System.Drawing.Color.Black;
            this.OJ.DisplayLayout.Override.SelectedRowAppearance = appearance15;
            this.OJ.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.OJ.Location = new System.Drawing.Point(585, 21);
            this.OJ.Name = "OJ";
            this.OJ.Size = new System.Drawing.Size(155, 80);
            this.OJ.TabIndex = 9;
            this.OJ.ValueMember = "IDORGJED";
            this.OJ.Visible = false;
            // 
            // OrgjedDataSet1
            // 
            this.OrgjedDataSet1.DataSetName = "ORGJEDDataSet";
            // 
            // UltraDropDown1
            // 
            this.UltraDropDown1.CalcManager = this.UltraCalcManager1;
            this.UltraDropDown1.DataMember = "PARTNER";
            this.UltraDropDown1.DataSource = this.PartnerDataSet1;
            appearance16.BackColor = System.Drawing.Color.White;
            this.UltraDropDown1.DisplayLayout.Appearance = appearance16;
            ultraGridColumn33.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn33.Header.VisiblePosition = 0;
            ultraGridColumn33.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(55, 0);
            ultraGridColumn34.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn34.Header.VisiblePosition = 1;
            ultraGridColumn34.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(471, 0);
            ultraGridColumn35.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn35.Header.VisiblePosition = 2;
            ultraGridColumn35.Hidden = true;
            ultraGridColumn36.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn36.Header.VisiblePosition = 3;
            ultraGridColumn36.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(208, 0);
            ultraGridColumn37.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn37.Header.VisiblePosition = 4;
            ultraGridColumn37.Hidden = true;
            ultraGridColumn38.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn38.Header.VisiblePosition = 5;
            ultraGridColumn38.Hidden = true;
            ultraGridColumn39.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn39.Header.VisiblePosition = 6;
            ultraGridColumn39.Hidden = true;
            ultraGridColumn40.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn40.Header.VisiblePosition = 7;
            ultraGridColumn41.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn41.Header.VisiblePosition = 8;
            ultraGridColumn42.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn42.Header.VisiblePosition = 9;
            ultraGridColumn43.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn43.Header.VisiblePosition = 10;
            ultraGridColumn44.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn44.Header.VisiblePosition = 11;
            ultraGridColumn45.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn45.Header.VisiblePosition = 12;
            ultraGridBand4.Columns.AddRange(new object[] {
            ultraGridColumn33,
            ultraGridColumn34,
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
            ultraGridColumn45});
            ultraGridBand4.UseRowLayout = true;
            ultraGridColumn46.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn46.Header.VisiblePosition = 0;
            ultraGridColumn47.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn47.Header.VisiblePosition = 1;
            ultraGridColumn48.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn48.Header.VisiblePosition = 2;
            ultraGridColumn49.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn49.Header.VisiblePosition = 3;
            ultraGridColumn50.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn50.Header.VisiblePosition = 4;
            ultraGridColumn51.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn51.Header.VisiblePosition = 5;
            ultraGridColumn52.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn52.Header.VisiblePosition = 6;
            ultraGridColumn53.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn53.Header.VisiblePosition = 7;
            ultraGridColumn54.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn54.Header.VisiblePosition = 8;
            ultraGridColumn55.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn55.Header.VisiblePosition = 9;
            ultraGridColumn56.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn56.Header.VisiblePosition = 10;
            ultraGridColumn57.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn57.Header.VisiblePosition = 11;
            ultraGridColumn58.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn58.Header.VisiblePosition = 12;
            ultraGridColumn59.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn59.Header.VisiblePosition = 13;
            ultraGridBand5.Columns.AddRange(new object[] {
            ultraGridColumn46,
            ultraGridColumn47,
            ultraGridColumn48,
            ultraGridColumn49,
            ultraGridColumn50,
            ultraGridColumn51,
            ultraGridColumn52,
            ultraGridColumn53,
            ultraGridColumn54,
            ultraGridColumn55,
            ultraGridColumn56,
            ultraGridColumn57,
            ultraGridColumn58,
            ultraGridColumn59});
            this.UltraDropDown1.DisplayLayout.BandsSerializer.Add(ultraGridBand4);
            this.UltraDropDown1.DisplayLayout.BandsSerializer.Add(ultraGridBand5);
            this.UltraDropDown1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.UltraDropDown1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.UltraDropDown1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.UltraDropDown1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance17.BackColor = System.Drawing.Color.Transparent;
            this.UltraDropDown1.DisplayLayout.Override.CardAreaAppearance = appearance17;
            this.UltraDropDown1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.UltraDropDown1.DisplayLayout.Override.CellPadding = 3;
            this.UltraDropDown1.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
            appearance18.TextHAlignAsString = "Left";
            this.UltraDropDown1.DisplayLayout.Override.HeaderAppearance = appearance18;
            this.UltraDropDown1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance19.BorderColor = System.Drawing.Color.LightGray;
            appearance19.TextVAlignAsString = "Middle";
            this.UltraDropDown1.DisplayLayout.Override.RowAppearance = appearance19;
            appearance21.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance21.BorderColor = System.Drawing.Color.Black;
            appearance21.ForeColor = System.Drawing.Color.Black;
            this.UltraDropDown1.DisplayLayout.Override.SelectedRowAppearance = appearance21;
            this.UltraDropDown1.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraDropDown1.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraDropDown1.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.UltraDropDown1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.UltraDropDown1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.UltraDropDown1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.UltraDropDown1.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.UltraDropDown1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.UltraDropDown1.DisplayMember = "NAZIVPARTNER";
            this.UltraDropDown1.Location = new System.Drawing.Point(746, 21);
            this.UltraDropDown1.Name = "UltraDropDown1";
            this.UltraDropDown1.Size = new System.Drawing.Size(112, 80);
            this.UltraDropDown1.TabIndex = 10;
            this.UltraDropDown1.ValueMember = "IDPARTNER";
            this.UltraDropDown1.Visible = false;
            // 
            // PartnerDataSet1
            // 
            this.PartnerDataSet1.DataSetName = "PARTNERDataSet";
            // 
            // UltraLabel3
            // 
            appearance.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel3.Appearance = appearance;
            this.UltraLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel3.Location = new System.Drawing.Point(7, 84);
            this.UltraLabel3.Name = "UltraLabel3";
            this.UltraLabel3.Size = new System.Drawing.Size(122, 23);
            this.UltraLabel3.TabIndex = 2;
            this.UltraLabel3.Text = "Datum dokumenta:";
            this.UltraLabel3.UseAppStyling = false;


            appearance.BackColor = System.Drawing.Color.Transparent;
            this.ulbOpis.Appearance = appearance;
            this.ulbOpis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ulbOpis.Location = new System.Drawing.Point(7, 111);
            this.ulbOpis.Name = "ulbOpis";
            this.ulbOpis.Size = new System.Drawing.Size(122, 23);
            this.ulbOpis.TabIndex = 2;
            this.ulbOpis.Text = "Opis dokumenta:";
            this.ulbOpis.UseAppStyling = false;


            // 
            // UltraLabel2
            // 
            appearance9.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel2.Appearance = appearance9;
            this.UltraLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel2.Location = new System.Drawing.Point(7, 57);
            this.UltraLabel2.Name = "UltraLabel2";
            this.UltraLabel2.Size = new System.Drawing.Size(100, 23);
            this.UltraLabel2.TabIndex = 1;
            this.UltraLabel2.Text = "Broj dokumenta:";
            this.UltraLabel2.UseAppStyling = false;
            // 
            // KONTO
            // 
            this.KONTO.CalcManager = this.UltraCalcManager1;
            this.KONTO.DataMember = "KONTO";
            this.KONTO.DataSource = this.KontoDataSet1;
            appearance35.BackColor = System.Drawing.Color.White;
            this.KONTO.DisplayLayout.Appearance = appearance35;
            ultraGridColumn60.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn60.Header.VisiblePosition = 0;
            ultraGridColumn60.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn60.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn60.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(138, 0);
            ultraGridColumn60.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn60.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn61.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn61.Header.VisiblePosition = 1;
            ultraGridColumn61.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn61.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn61.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(613, 0);
            ultraGridColumn61.RowLayoutColumnInfo.SpanX = 3;
            ultraGridColumn61.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn62.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn62.Header.VisiblePosition = 2;
            ultraGridColumn62.Hidden = true;
            ultraGridColumn63.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn63.Header.VisiblePosition = 3;
            ultraGridColumn63.RowLayoutColumnInfo.OriginX = 5;
            ultraGridColumn63.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn63.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn63.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn64.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn64.Header.VisiblePosition = 4;
            ultraGridBand6.Columns.AddRange(new object[] {
            ultraGridColumn60,
            ultraGridColumn61,
            ultraGridColumn62,
            ultraGridColumn63,
            ultraGridColumn64});
            ultraGridBand6.UseRowLayout = true;
            this.KONTO.DisplayLayout.BandsSerializer.Add(ultraGridBand6);
            this.KONTO.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.KONTO.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.KONTO.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.KONTO.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance36.BackColor = System.Drawing.Color.Transparent;
            this.KONTO.DisplayLayout.Override.CardAreaAppearance = appearance36;
            this.KONTO.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.KONTO.DisplayLayout.Override.CellPadding = 3;
            this.KONTO.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
            appearance37.TextHAlignAsString = "Left";
            this.KONTO.DisplayLayout.Override.HeaderAppearance = appearance37;
            this.KONTO.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance38.BorderColor = System.Drawing.Color.LightGray;
            appearance38.TextVAlignAsString = "Middle";
            this.KONTO.DisplayLayout.Override.RowAppearance = appearance38;
            appearance2.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance2.BorderColor = System.Drawing.Color.Black;
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.KONTO.DisplayLayout.Override.SelectedRowAppearance = appearance2;
            this.KONTO.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.KONTO.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.KONTO.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.KONTO.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.KONTO.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.KONTO.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.KONTO.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.KONTO.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.KONTO.Location = new System.Drawing.Point(1027, 21);
            this.KONTO.Name = "KONTO";
            this.KONTO.Size = new System.Drawing.Size(97, 80);
            this.KONTO.TabIndex = 12;
            this.KONTO.ValueMember = "IDKONTO";
            this.KONTO.Visible = false;
            this.KONTO.AfterCloseUp += new Infragistics.Win.UltraWinGrid.DropDownEventHandler(this.KONTO_AfterCloseUp);
            this.KONTO.TextChanged += new System.EventHandler(this.KONTO_TextChanged);
            // 
            // KontoDataSet1
            // 
            this.KontoDataSet1.DataSetName = "KONTODataSet";
            // 
            // UltraLabel1
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel1.Appearance = appearance3;
            this.UltraLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel1.Location = new System.Drawing.Point(7, 30);
            this.UltraLabel1.Name = "UltraLabel1";
            this.UltraLabel1.Size = new System.Drawing.Size(122, 23);
            this.UltraLabel1.TabIndex = 0;
            this.UltraLabel1.Text = "Šifra vrste dokumenta:";
            this.UltraLabel1.UseAppStyling = false;
            // 
            // txtNazivDokument
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.txtNazivDokument.Appearance = appearance4;
            this.txtNazivDokument.Location = new System.Drawing.Point(459, 24);
            this.txtNazivDokument.Name = "txtNazivDokument";
            this.txtNazivDokument.Size = new System.Drawing.Size(362, 23);
            this.txtNazivDokument.TabIndex = 6;
            // 
            // txtSifrDokumenta
            // 
            editorButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            editorButton1.Text = "Vrste dokumenata";
            editorButton2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            editorButton2.Key = "Uneseni";
            editorButton2.Text = "Uneseni dokumenti";
            this.txtSifrDokumenta.ButtonsRight.Add(editorButton1);
            this.txtSifrDokumenta.ButtonsRight.Add(editorButton2);
            this.txtSifrDokumenta.Location = new System.Drawing.Point(147, 26);
            this.txtSifrDokumenta.Name = "txtSifrDokumenta";
            this.txtSifrDokumenta.Size = new System.Drawing.Size(272, 21);
            this.txtSifrDokumenta.TabIndex = 0;
            this.txtSifrDokumenta.UseAppStyling = false;
            this.txtSifrDokumenta.ValueChanged += new System.EventHandler(this.txtSifrDokumenta_ValueChanged);
            this.txtSifrDokumenta.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.Textbox1_EditorButtonClick);
            this.txtSifrDokumenta.Validating += new System.ComponentModel.CancelEventHandler(this.Textbox1_Validating);
            // 
            // txtBrojDokumenta
            // 
            this.txtBrojDokumenta.Location = new System.Drawing.Point(147, 53);
            this.txtBrojDokumenta.Name = "txtBrojDokumenta";
            this.txtBrojDokumenta.Size = new System.Drawing.Size(272, 21);
            this.txtBrojDokumenta.TabIndex = 1;
            this.txtBrojDokumenta.UseAppStyling = false;
            this.txtBrojDokumenta.Validating += new CancelEventHandler(Textbox3_Validating);

            this.txtOpis.Location = new System.Drawing.Point(147, 107);
            this.txtOpis.Name = "txtOpis";
            this.txtOpis.Size = new System.Drawing.Size(272, 21);
            this.txtOpis.TabIndex = 1;
            this.txtOpis.UseAppStyling = false;
            txtOpis.ValueChanged += new EventHandler(OpisChanged);

            // 
            // dteDatumDokumenta
            // 
            editorButton3.Text = "Promijeni datum";
            this.dteDatumDokumenta.ButtonsRight.Add(editorButton3);
            this.dteDatumDokumenta.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.dteDatumDokumenta.Location = new System.Drawing.Point(147, 80);
            this.dteDatumDokumenta.Name = "dteDatumDokumenta";
            this.dteDatumDokumenta.Size = new System.Drawing.Size(272, 21);
            this.dteDatumDokumenta.TabIndex = 2;
            this.dteDatumDokumenta.UseAppStyling = false;
            this.dteDatumDokumenta.Appearance.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.dteDatumDokumenta.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.dvo_EditorButtonClick);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.Panel1.Controls.Add(this.ToolBar1);
            this.Panel1.Location = new System.Drawing.Point(0, 18);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1146, 68);
            this.Panel1.TabIndex = 29;
            // 
            // ToolBar1
            // 
            this.ToolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.ToolBarButton1,
            this.ToolBarButton2,
            this.ToolBarButton3,
            this.ToolBarButton4,
            this.ToolBarButton5,
            this.ToolBarButton6,
            this.ToolBarButton7,
            this.ToolBarButton8});
            this.ToolBar1.ButtonSize = new System.Drawing.Size(32, 32);
            this.ToolBar1.DropDownArrows = true;
            this.ToolBar1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ToolBar1.ImageList = this.ImageList1;
            this.ToolBar1.Location = new System.Drawing.Point(0, 0);
            this.ToolBar1.MinimumSize = new System.Drawing.Size(0, 60);
            this.ToolBar1.Name = "ToolBar1";
            this.ToolBar1.ShowToolTips = true;
            this.ToolBar1.Size = new System.Drawing.Size(1146, 60);
            this.ToolBar1.TabIndex = 0;
            this.ToolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.ToolBar1_ButtonClick);
            // 
            // ToolBarButton1
            // 
            this.ToolBarButton1.ImageIndex = 13;
            this.ToolBarButton1.Name = "ToolBarButton1";
            this.ToolBarButton1.Text = "Unesi";
            // 
            // ToolBarButton2
            // 
            this.ToolBarButton2.ImageIndex = 12;
            this.ToolBarButton2.Name = "ToolBarButton2";
            this.ToolBarButton2.Text = "Briši";
            // 
            // ToolBarButton3
            // 
            this.ToolBarButton3.ImageIndex = 5;
            this.ToolBarButton3.Name = "ToolBarButton3";
            this.ToolBarButton3.Text = "Ispiši";
            // 
            // ToolBarButton4
            // 
            this.ToolBarButton4.ImageIndex = 3;
            this.ToolBarButton4.Name = "ToolBarButton4";
            this.ToolBarButton4.Text = "Proknjiži";
            // 
            // ToolBarButton5
            // 
            this.ToolBarButton5.ImageIndex = 6;
            this.ToolBarButton5.Name = "ToolBarButton5";
            this.ToolBarButton5.Text = "Renumeriraj";
            // 
            // ToolBarButton6
            // 
            this.ToolBarButton6.ImageIndex = 4;
            this.ToolBarButton6.Name = "ToolBarButton6";
            this.ToolBarButton6.Text = "Otvorene";
            // 
            // ToolBarButton7
            // 
            this.ToolBarButton7.ImageIndex = 8;
            this.ToolBarButton7.Name = "ToolBarButton7";
            this.ToolBarButton7.Text = "Vezane stavke";
            // 
            // ToolBarButton8
            // 
            this.ToolBarButton8.ImageIndex = 8;
            this.ToolBarButton8.Name = "ToolBarButton8";
            this.ToolBarButton8.Text = "Izvodi";
            // 
            // ImageList1
            // 
            this.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ImageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Panel2
            // 
            this.Panel2.Location = new System.Drawing.Point(0, 16);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(413, 198);
            this.Panel2.TabIndex = 1;
            // 
            // GkstavkaDataSet1
            // 
            this.GkstavkaDataSet1.DataSetName = "GKSTAVKADataSet";
            // 
            // ugrdGK
            // 
            this.ugrdGK.CalcManager = this.UltraCalcManager1;
            this.ugrdGK.DataMember = "GKSTAVKA";
            this.ugrdGK.DataSource = this.GkstavkaDataSet1;
            appearance5.BackColor = System.Drawing.Color.White;
            this.ugrdGK.DisplayLayout.Appearance = appearance5;
            this.ugrdGK.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.VisiblePosition = 13;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.Header.VisiblePosition = 14;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.Header.VisiblePosition = 15;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.Header.VisiblePosition = 16;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn5.Header.Caption = "Stavka";
            ultraGridColumn5.Header.VisiblePosition = 0;
            ultraGridColumn5.Width = 20;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.Header.VisiblePosition = 17;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.Header.VisiblePosition = 18;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.Header.VisiblePosition = 2;
            ultraGridColumn8.NullText = "";
            ultraGridColumn8.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            ultraGridColumn8.Width = 46;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn9.Header.VisiblePosition = 10;
            ultraGridColumn9.Width = 81;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn10.Header.VisiblePosition = 1;
            ultraGridColumn10.Nullable = Infragistics.Win.UltraWinGrid.Nullable.Disallow;
            ultraGridColumn10.NullText = "";
            ultraGridColumn10.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            ultraGridColumn10.Width = 42;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn11.Header.VisiblePosition = 9;
            ultraGridColumn11.Width = 81;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn12.Header.VisiblePosition = 3;
            ultraGridColumn12.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            ultraGridColumn12.Width = 71;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn13.Header.VisiblePosition = 11;
            ultraGridColumn13.Width = 81;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn14.Header.VisiblePosition = 19;
            ultraGridColumn14.Hidden = true;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn15.Header.Caption = "Opis";
            ultraGridColumn15.Header.VisiblePosition = 5;
            ultraGridColumn15.Width = 154;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance1.FontData.BoldAsString = "True";
            appearance1.TextHAlignAsString = "Right";
            ultraGridColumn16.CellAppearance = appearance1;
            ultraGridColumn16.Header.Caption = "Duguje";
            ultraGridColumn16.Header.VisiblePosition = 6;
            ultraGridColumn16.MaskInput = "-nnnnnnnnn.nn";
            ultraGridColumn16.Width = 86;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance39.FontData.BoldAsString = "True";
            appearance39.TextHAlignAsString = "Right";
            ultraGridColumn17.CellAppearance = appearance39;
            ultraGridColumn17.Header.Caption = "Potražuje";
            ultraGridColumn17.Header.VisiblePosition = 7;
            ultraGridColumn17.MaskInput = "-nnnnnnnnn.nn";
            ultraGridColumn17.Width = 74;
            ultraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn18.Header.VisiblePosition = 20;
            ultraGridColumn18.Hidden = true;
            ultraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn19.Header.Caption = "Naziv partnera";
            ultraGridColumn19.Header.VisiblePosition = 4;
            ultraGridColumn19.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
            ultraGridColumn19.Width = 124;
            ultraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn20.Header.VisiblePosition = 12;
            ultraGridColumn20.Hidden = true;
            ultraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance40.TextHAlignAsString = "Right";
            ultraGridColumn21.CellAppearance = appearance40;
            ultraGridColumn21.Header.Caption = "Zatvoreno";
            ultraGridColumn21.Header.VisiblePosition = 8;
            ultraGridColumn21.MaskInput = "nnnnnnnnn.nn";
            ultraGridColumn21.Width = 91;
            ultraGridColumn22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn22.Header.Caption = "Valuta";
            ultraGridColumn22.Header.VisiblePosition = 21;
            ultraGridColumn22.Width = 93;
            ultraGridColumn23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn23.Header.VisiblePosition = 22;
            ultraGridColumn23.Hidden = true;
            ultraGridColumn24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn24.Header.VisiblePosition = 23;
            ultraGridColumn24.Hidden = true;
            ultraGridColumn25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn25.Header.VisiblePosition = 24;
            ultraGridColumn25.Hidden = true;
            ultraGridColumn26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn26.Formula = "[duguje] - [POTRAZUJE]";
            ultraGridColumn26.Header.Caption = "Saldo";
            ultraGridColumn26.Header.VisiblePosition = 25;
            ultraGridColumn26.Width = 81;
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
            ultraGridColumn22,
            ultraGridColumn23,
            ultraGridColumn24,
            ultraGridColumn25,
            ultraGridColumn26});
            appearance41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            appearance41.FontData.BoldAsString = "True";
            appearance41.TextHAlignAsString = "Right";
            summarySettings1.Appearance = appearance41;
            summarySettings1.DisplayFormat = "{0:#,##0.00}";
            summarySettings1.GroupBySummaryValueAppearance = appearance42;
            summarySettings1.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.TopFixed;
            appearance43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            appearance43.FontData.BoldAsString = "True";
            appearance43.TextHAlignAsString = "Right";
            summarySettings2.Appearance = appearance43;
            summarySettings2.DisplayFormat = "{0:#,##0.00}";
            summarySettings2.GroupBySummaryValueAppearance = appearance44;
            summarySettings2.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.TopFixed;
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            appearance45.FontData.BoldAsString = "True";
            appearance45.TextHAlignAsString = "Right";
            summarySettings3.Appearance = appearance45;
            summarySettings3.DisplayFormat = "{0:#,##0.00}";
            summarySettings3.GroupBySummaryValueAppearance = appearance46;
            summarySettings3.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.TopFixed;
            ultraGridBand1.Summaries.AddRange(new Infragistics.Win.UltraWinGrid.SummarySettings[] {
            summarySettings1,
            summarySettings2,
            summarySettings3});
            ultraGridBand1.SummaryFooterCaption = "Totali";
            this.ugrdGK.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ugrdGK.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance8.BackColor = System.Drawing.Color.Transparent;
            this.ugrdGK.DisplayLayout.Override.CardAreaAppearance = appearance8;
            this.ugrdGK.DisplayLayout.Override.CellPadding = 3;
            appearance10.TextHAlignAsString = "Left";
            this.ugrdGK.DisplayLayout.Override.HeaderAppearance = appearance10;
            appearance22.BorderColor = System.Drawing.Color.LightGray;
            appearance22.TextVAlignAsString = "Middle";
            this.ugrdGK.DisplayLayout.Override.RowAppearance = appearance22;
            this.ugrdGK.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            appearance23.BackColor = System.Drawing.Color.Navy;
            appearance23.BorderColor = System.Drawing.Color.Black;
            appearance23.ForeColor = System.Drawing.Color.White;
            this.ugrdGK.DisplayLayout.Override.SelectedRowAppearance = appearance23;
            this.ugrdGK.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.ugrdGK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ugrdGK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ugrdGK.Location = new System.Drawing.Point(0, 249);
            this.ugrdGK.Name = "ugrdGK";
            this.ugrdGK.Size = new System.Drawing.Size(1146, 278);
            this.ugrdGK.TabIndex = 3;
            this.ugrdGK.UseAppStyling = false;
            this.ugrdGK.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.UltraGrid1_AfterCellUpdate);
            this.ugrdGK.AfterEnterEditMode += new System.EventHandler(this.UltraGrid1_AfterEnterEditMode);
            this.ugrdGK.AfterRowsDeleted += new System.EventHandler(this.UltraGrid1_AfterRowsDeleted);
            this.ugrdGK.AfterRowUpdate += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.UltraGrid1_AfterRowUpdate);
            this.ugrdGK.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.UltraGrid1_BeforeCellActivate);
            this.ugrdGK.BeforeCellDeactivate += new System.ComponentModel.CancelEventHandler(this.UltraGrid1_BeforeCellDeactivate);
            this.ugrdGK.BeforeEnterEditMode += new System.ComponentModel.CancelEventHandler(this.UltraGrid1_BeforeEnterEditMode);
            this.ugrdGK.CellDataError += new Infragistics.Win.UltraWinGrid.CellDataErrorEventHandler(this.UltraGrid1_CellDataError);
            this.ugrdGK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UltraGrid1_KeyDown);
            // 
            // UltraDockManager1
            // 
            dockAreaPane1.DockedBefore = new System.Guid("30d2afde-e535-4c6c-818c-48404d8ec380");
            dockableControlPane1.Control = this.UltraGroupBox1;
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(126, 3, 881, 110);
            dockableControlPane1.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.Text = "Postavke dokumenta";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            dockAreaPane1.Size = new System.Drawing.Size(1146, 153);
            dockAreaPane2.DockedBefore = new System.Guid("0c9a1126-070b-43ca-9417-1f16f0893af8");
            dockableControlPane2.Control = this.Panel1;
            dockableControlPane2.OriginalControlBounds = new System.Drawing.Rectangle(131, 125, 200, 100);
            dockableControlPane2.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane2.Size = new System.Drawing.Size(100, 100);
            dockableControlPane2.Text = "Stavke dokumenta";
            dockAreaPane2.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane2});
            dockAreaPane2.Size = new System.Drawing.Size(1146, 86);
            dockAreaPane3.Closed = true;
            dockAreaPane3.FloatingLocation = new System.Drawing.Point(684, 492);
            dockableControlPane3.Control = this.Panel2;
            dockableControlPane3.OriginalControlBounds = new System.Drawing.Rectangle(131, 265, 200, 100);
            dockableControlPane3.Size = new System.Drawing.Size(100, 100);
            dockableControlPane3.Text = "Panel2";
            dockAreaPane3.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane3});
            dockAreaPane3.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.True;
            dockAreaPane3.Settings.AllowDockAsTab = Infragistics.Win.DefaultableBoolean.False;
            dockAreaPane3.Settings.AllowDockBottom = Infragistics.Win.DefaultableBoolean.False;
            dockAreaPane3.Settings.AllowDockLeft = Infragistics.Win.DefaultableBoolean.False;
            dockAreaPane3.Settings.AllowDockRight = Infragistics.Win.DefaultableBoolean.False;
            dockAreaPane3.Settings.AllowDockTop = Infragistics.Win.DefaultableBoolean.False;
            dockAreaPane3.Settings.AllowDragging = Infragistics.Win.DefaultableBoolean.True;
            dockAreaPane3.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.True;
            dockAreaPane3.Settings.AllowMaximize = Infragistics.Win.DefaultableBoolean.False;
            dockAreaPane3.Settings.AllowMinimize = Infragistics.Win.DefaultableBoolean.False;
            dockAreaPane3.Settings.AllowPin = Infragistics.Win.DefaultableBoolean.True;
            dockAreaPane3.Size = new System.Drawing.Size(413, 214);
            this.UltraDockManager1.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1,
            dockAreaPane2,
            dockAreaPane3});
            this.UltraDockManager1.HostControl = this;
            this.UltraDockManager1.UseAppStyling = false;
            this.UltraDockManager1.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2007;
            // 
            // _GKSmartPartUnpinnedTabAreaLeft
            // 
            this._GKSmartPartUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._GKSmartPartUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._GKSmartPartUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._GKSmartPartUnpinnedTabAreaLeft.Name = "_GKSmartPartUnpinnedTabAreaLeft";
            this._GKSmartPartUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            this._GKSmartPartUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 527);
            this._GKSmartPartUnpinnedTabAreaLeft.TabIndex = 27;
            // 
            // _GKSmartPartUnpinnedTabAreaRight
            // 
            this._GKSmartPartUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._GKSmartPartUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._GKSmartPartUnpinnedTabAreaRight.Location = new System.Drawing.Point(1146, 0);
            this._GKSmartPartUnpinnedTabAreaRight.Name = "_GKSmartPartUnpinnedTabAreaRight";
            this._GKSmartPartUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this._GKSmartPartUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 527);
            this._GKSmartPartUnpinnedTabAreaRight.TabIndex = 28;
            // 
            // _GKSmartPartUnpinnedTabAreaTop
            // 
            this._GKSmartPartUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._GKSmartPartUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._GKSmartPartUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._GKSmartPartUnpinnedTabAreaTop.Name = "_GKSmartPartUnpinnedTabAreaTop";
            this._GKSmartPartUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this._GKSmartPartUnpinnedTabAreaTop.Size = new System.Drawing.Size(1146, 0);
            this._GKSmartPartUnpinnedTabAreaTop.TabIndex = 29;
            // 
            // _GKSmartPartUnpinnedTabAreaBottom
            // 
            this._GKSmartPartUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._GKSmartPartUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._GKSmartPartUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 527);
            this._GKSmartPartUnpinnedTabAreaBottom.Name = "_GKSmartPartUnpinnedTabAreaBottom";
            this._GKSmartPartUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this._GKSmartPartUnpinnedTabAreaBottom.Size = new System.Drawing.Size(1146, 0);
            this._GKSmartPartUnpinnedTabAreaBottom.TabIndex = 30;
            // 
            // _GKSmartPartAutoHideControl
            // 
            this._GKSmartPartAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._GKSmartPartAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._GKSmartPartAutoHideControl.Name = "_GKSmartPartAutoHideControl";
            this._GKSmartPartAutoHideControl.Owner = this.UltraDockManager1;
            this._GKSmartPartAutoHideControl.Size = new System.Drawing.Size(0, 527);
            this._GKSmartPartAutoHideControl.TabIndex = 31;
            // 
            // WindowDockingArea1
            // 
            this.WindowDockingArea1.Controls.Add(this.DockableWindow1);
            this.WindowDockingArea1.Dock = System.Windows.Forms.DockStyle.Top;
            this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea1.Location = new System.Drawing.Point(0, 0);
            this.WindowDockingArea1.Name = "WindowDockingArea1";
            this.WindowDockingArea1.Owner = this.UltraDockManager1;
            this.WindowDockingArea1.Size = new System.Drawing.Size(1146, 158);
            this.WindowDockingArea1.TabIndex = 32;
            // 
            // DockableWindow1
            // 
            this.DockableWindow1.Controls.Add(this.UltraGroupBox1);
            this.DockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow1.Name = "DockableWindow1";
            this.DockableWindow1.Owner = this.UltraDockManager1;
            this.DockableWindow1.Size = new System.Drawing.Size(1146, 153);
            this.DockableWindow1.TabIndex = 34;
            // 
            // WindowDockingArea2
            // 
            this.WindowDockingArea2.Controls.Add(this.DockableWindow2);
            this.WindowDockingArea2.Dock = System.Windows.Forms.DockStyle.Top;
            this.WindowDockingArea2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea2.Location = new System.Drawing.Point(0, 158);
            this.WindowDockingArea2.Name = "WindowDockingArea2";
            this.WindowDockingArea2.Owner = this.UltraDockManager1;
            this.WindowDockingArea2.Size = new System.Drawing.Size(1146, 91);
            this.WindowDockingArea2.TabIndex = 33;
            // 
            // DockableWindow2
            // 
            this.DockableWindow2.Controls.Add(this.Panel1);
            this.DockableWindow2.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow2.Name = "DockableWindow2";
            this.DockableWindow2.Owner = this.UltraDockManager1;
            this.DockableWindow2.Size = new System.Drawing.Size(1146, 86);
            this.DockableWindow2.TabIndex = 35;
            // 
            // DockableWindow3
            // 
            this.DockableWindow3.Controls.Add(this.Panel2);
            this.DockableWindow3.Location = new System.Drawing.Point(-10000, 0);
            this.DockableWindow3.Name = "DockableWindow3";
            this.DockableWindow3.Owner = this.UltraDockManager1;
            this.DockableWindow3.Size = new System.Drawing.Size(413, 214);
            this.DockableWindow3.TabIndex = 36;
            // 
            // WindowDockingArea4
            // 
            this.WindowDockingArea4.Controls.Add(this.DockableWindow3);
            this.WindowDockingArea4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WindowDockingArea4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea4.Location = new System.Drawing.Point(4, 4);
            this.WindowDockingArea4.Name = "WindowDockingArea4";
            this.WindowDockingArea4.Owner = this.UltraDockManager1;
            this.WindowDockingArea4.Size = new System.Drawing.Size(413, 214);
            this.WindowDockingArea4.TabIndex = 0;
            // 
            // GKSmartPart
            // 
            this.Controls.Add(this._GKSmartPartAutoHideControl);
            this.Controls.Add(this.ugrdGK);
            this.Controls.Add(this.WindowDockingArea2);
            this.Controls.Add(this.WindowDockingArea1);
            this.Controls.Add(this._GKSmartPartUnpinnedTabAreaTop);
            this.Controls.Add(this._GKSmartPartUnpinnedTabAreaBottom);
            this.Controls.Add(this._GKSmartPartUnpinnedTabAreaLeft);
            this.Controls.Add(this._GKSmartPartUnpinnedTabAreaRight);
            this.Name = "GKSmartPart";
            this.Size = new System.Drawing.Size(1146, 527);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).EndInit();
            this.UltraGroupBox1.ResumeLayout(false);
            this.UltraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraCalcManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MjestotroskaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OJ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrgjedDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDropDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartnerDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KONTO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KontoDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifrDokumenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBrojDokumenta)).EndInit();

            ((System.ComponentModel.ISupportInitialize)(this.txtOpis)).EndInit();

            ((System.ComponentModel.ISupportInitialize)(this.dteDatumDokumenta)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GkstavkaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugrdGK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGridBagLayoutManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).EndInit();
            this.WindowDockingArea1.ResumeLayout(false);
            this.DockableWindow1.ResumeLayout(false);
            this.WindowDockingArea2.ResumeLayout(false);
            this.DockableWindow2.ResumeLayout(false);
            this.DockableWindow3.ResumeLayout(false);
            this.WindowDockingArea4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void OpisChanged(object sender, EventArgs e)
        {
            if (txtSifrDokumenta.Value != null)
            {
                SpremiOpisDokumneta(txtOpis.Value);
            }
        }

        public void IspisTemeljniceNaPapir()
        {
            CurrencyManager manager = (CurrencyManager) this.BindingContext[this.GkstavkaDataSet1.GKSTAVKA];
            if (manager.Count != 0)
            {
                DataRowView current = (DataRowView) manager.Current;
                ReportDocument rpt = new ReportDocument();
                rpt.Load(System.Windows.Forms.Application.StartupPath + @"\FinposIzvjestaji\rptDnevnik.rpt");
                S_FIN_DNEVNIKDataAdapter adapter = new S_FIN_DNEVNIKDataAdapter();
                S_FIN_DNEVNIKDataSet dataSet = new S_FIN_DNEVNIKDataSet();
                try
                {
                    if (Operators.ConditionalCompareObjectEqual(this.GkstavkaDataSet1.GKSTAVKA.Rows[0]["statusgk"], 0, false))
                    {
                        adapter.Fill(dataSet, -1, -1, Conversions.ToInteger(current["IDDOKUMENT"]), Conversions.ToInteger(current["BROJDOKumenta"]), Conversions.ToDate(current["DATUMDOKUMENTA"]), Conversions.ToDate(current["DATUMDOKUMENTA"]), " ", " ", false);
                    }
                    else
                    {
                        adapter.Fill(dataSet, -1, -1, Conversions.ToInteger(current["IDDOKUMENT"]), Conversions.ToInteger(current["BROJDOKumenta"]), Conversions.ToDate(current["DATUMDOKUMENTA"]), Conversions.ToDate(current["DATUMDOKUMENTA"]), " ", " ", true);
                    }
                }
                catch (SqlException exception1)
                {
                    throw exception1;
                    //SqlException exception = exception1;                                       
                }

                // db - 20.10.2016 
                // Set connection string from config in existing LogonProperties
                rpt.DataSourceConnections[0].SetConnection(Mipsed7.Core.ApplicationDatabaseInformation.ServerName, Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName, true);
                rpt.DataSourceConnections[0].SetLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);
                rpt.DataSourceConnections[0].IntegratedSecurity = false;

                rpt.SetDataSource(dataSet);
                rpt.SetParameterValue("POCETNI", RuntimeHelpers.GetObjectValue(current["DATUMDOKUMENTA"]));
                rpt.SetParameterValue("ZAVRSNI", RuntimeHelpers.GetObjectValue(current["DATUMDOKUMENTA"]));
                rpt.SetParameterValue("odkonta", "Sva konta");
                rpt.SetParameterValue("dokonta", "Sva konta");
                //za naslov su skombinirani Temeljnica + broj dokumenta
                rpt.SetParameterValue("naslov", Operators.AddObject(Operators.AddObject(Operators.AddObject("Temeljnica: ", this.GkstavkaDataSet1.GKSTAVKA.Rows[0]["nazivdokument"]), " - "), Conversions.ToString(this.GkstavkaDataSet1.GKSTAVKA.Rows[0]["BROJDOKUMENTA"])));
                // db 25.10.2016.
                rpt.SetParameterValue("OpisDokumenta", txtOpis.Text.ToString());
                mipsed.application.framework.Application.PostaviParametreIzvjestaja(ref rpt);
                ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                    StartPosition = FormStartPosition.CenterParent,
                    Modal = true,
                    Title = "Pregled izvještaja",
                    Description = "Pregled",
                    Icon = ImageResourcesNew.mbs
                };
                ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                if (item == null)
                {
                    item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                }
                item.Izvjestaj = rpt;
                item.Show(item.Workspaces["main"], info);
            }
        }

        private void IspisViseTemeljnica()
        {
            ReportDocument rpt = new ReportDocument();
            rpt.Load(System.Windows.Forms.Application.StartupPath + @"\FinposIzvjestaji\rptDnevnikRazdoblje.rpt");

            DataSet ds = new DataSet();

            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            SqlCommand command = new SqlCommand();

            command.Connection = client.sqlConnection;

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "S_FIN_DNEVNIKPoBroju";
            command.Parameters.AddWithValue("@OD", pocetna_temeljnica);
            command.Parameters.AddWithValue("@DO", zavrsna_temeljnica);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            // Set connection string from config in existing LogonProperties
            rpt.DataSourceConnections[0].SetConnection(Mipsed7.Core.ApplicationDatabaseInformation.ServerName, Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName, true);
            rpt.DataSourceConnections[0].SetLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;

            rpt.SetDataSource(ds);
            rpt.SetParameterValue("POCETNI", DateTime.Now);
            rpt.SetParameterValue("ZAVRSNI", DateTime.Now);
            rpt.SetParameterValue("odkonta", "Sva konta");
            rpt.SetParameterValue("dokonta", "Sva konta");
            rpt.SetParameterValue("naslov", "Temeljnica");

            DataRow korisnik = client.GetDataTable("SELECT TOP 1 korisnik1naziv,korisnik1adresa,korisnik1mjesto,kontakttelefon,kontaktfax,email,korisnikoib FROM KORISNIK").Rows[0];

            rpt.SetParameterValue("naziv", korisnik["KORISNIK1NAZIV"].ToString());
            rpt.SetParameterValue("adresa", korisnik["KORISNIK1ADRESA"].ToString() + ", " + korisnik["KORISNIK1MJESTO"].ToString());
            rpt.SetParameterValue("telefonfaxmail", "Telefon: " + korisnik["KONTAKTTELEFON"].ToString() + " Fax: " + korisnik["KONTAKTFAX"].ToString() + " Email: " + korisnik["EMAIL"].ToString());
            rpt.SetParameterValue("OIB", "Osobni identifikacijski broj: " + korisnik["KORISNIKOIB"].ToString());
            rpt.SetParameterValue("@OD", pocetna_temeljnica);
            rpt.SetParameterValue("@DO", zavrsna_temeljnica);
           
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
            {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja",
                Description = "Pregled",
                Icon = ImageResourcesNew.mbs
            };
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            if (item == null)
            {
                item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            item.Izvjestaj = rpt;
            item.Show(item.Workspaces["main"], info);
            
        }

        public void Izvrsi_renumeraciju_Stavaka()
        {
            IEnumerator enumerator = null;
            int num = 1;
            try
            {
                enumerator = this.GkstavkaDataSet1.GKSTAVKA.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    current.BeginEdit();
                    current["brojstavke"] = num;
                    num++;
                    current.EndEdit();
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
            GKSTAVKADataAdapter adapter = new GKSTAVKADataAdapter();
            try
            {
                adapter.Update(this.GkstavkaDataSet1);
                this.GkstavkaDataSet1.AcceptChanges();
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                //this.GkstavkaDataSet1.RejectChanges();
                
            }
            this.ugrdGK.PerformAction(UltraGridAction.FirstRowInGrid);
        }

        private void KONTO_AfterCloseUp(object sender, DropDownEventArgs e)
        {
            DataRowView current = null;
            UltraGridRow activeRow = this.ugrdGK.ActiveRow;
            if (current == null)
            {
                if (this.BindingContext[this.GkstavkaDataSet1, "GKSTAVKA"].Position == -1)
                {
                    return;
                }
                current = (DataRowView) this.BindingContext[this.GkstavkaDataSet1, "GKSTAVKA"].Current;
            }
            if (this.KONTO.SelectedRow != null)
            {
                if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(this.KONTO.SelectedRow.Cells["idaktivnost"].Value, 2, false), Operators.CompareObjectEqual(this.KONTO.SelectedRow.Cells["idaktivnost"].Value, 3, false))))
                {
                    //this.unospartnera = true;
                    this.ugrdGK.DisplayLayout.Bands[0].Columns["idpartner"].CellActivation = Activation.AllowEdit;
                    this.ugrdGK.DisplayLayout.Bands[0].Columns["GKDATUMVALUTE"].CellActivation = Activation.AllowEdit;
                }
                else
                {
                    //this.unospartnera = false;
                    this.ugrdGK.DisplayLayout.Bands[0].Columns["idpartner"].CellActivation = Activation.NoEdit;
                    this.ugrdGK.DisplayLayout.Bands[0].Columns["GKDATUMVALUTE"].CellActivation = Activation.NoEdit;
                    current["idpartner"] = DBNull.Value;
                    current["GKDATUMVALUTE"] = DBNull.Value;
                }
            }
        }

        private void KONTO_TextChanged(object sender, EventArgs e)
        {
            this.Spremi_Promjene();
        }

        private void MakeEnterActLikeTab(UltraGrid Grid)
        {
            GridKeyActionMappings.GridKeyActionMappingEnumerator enumerator = Grid.KeyActionMappings.GetEnumerator();
            while (enumerator.MoveNext())
            {
                GridKeyActionMapping current = enumerator.Current;
                if (current.KeyCode == Keys.Tab)
                {
                    GridKeyActionMapping mapping = new GridKeyActionMapping(Keys.Return, current.ActionCode, current.StateDisallowed, current.StateRequired, current.SpecialKeysDisallowed, current.SpecialKeysRequired);
                    Grid.KeyActionMappings.Add(mapping);
                }
            }
        }

        public void ObrisiStavku()
        {
            if (this.GkstavkaDataSet1.GKSTAVKA.Rows.Count != 0)
            {
                if (Operators.ConditionalCompareObjectEqual(this.GkstavkaDataSet1.GKSTAVKA.Rows[0]["statusgk"], true, false))
                {
                    Interaction.MsgBox("Dokument je proknjižen u Glavnu knjigu", MsgBoxStyle.OkOnly, null);
                }
                else
                {
                    int index = 0;
                    if (this.ugrdGK.ActiveRow != null)
                    {
                        index = this.ugrdGK.ActiveRow.Index;
                    }
                    DataRowView current = (DataRowView) this.BindingContext[this.GkstavkaDataSet1, "GKSTAVKA"].Current;
                    if (Operators.ConditionalCompareObjectNotEqual(current["zatvoreniiznos"], 0, false) && current["IDDOKUMENT"].ToString() != "997")
                    {
                        Interaction.MsgBox("Stavka korištena u vezama, brisanje nije moguće!", MsgBoxStyle.OkOnly, null);
                    }
                    else
                    {
                        if (Interaction.MsgBox("Želite li stvarno obrisati redak?", MsgBoxStyle.YesNo, "Potvrdite brisanje") == MsgBoxResult.Yes)
                        {
                            current.Delete();
                            this.Spremi_Promjene();
                            this.GkstavkaDataSet1.Clear();
                            this.daGKSTAVKA.FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE(this.GkstavkaDataSet1, Conversions.ToInteger(this.txtSifrDokumenta.Text), Conversions.ToInteger(this.txtBrojDokumenta.Text), mipsed.application.framework.Application.ActiveYear);
                        }
                        try
                        {
                            this.ugrdGK.ActiveRow = this.ugrdGK.Rows[index];
                            this.ugrdGK.ActiveRow.Selected = true;
                            this.ugrdGK.Focus();
                        }
                        catch (System.Exception)
                        {                            
                            if (this.ugrdGK.Rows.Count > 0)
                            {
                                this.ugrdGK.ActiveRow = this.ugrdGK.Rows[this.ugrdGK.Rows.Count - 1];
                                this.ugrdGK.ActiveRow.Selected = true;
                                this.ugrdGK.Focus();
                            }
                        }
                        this.Status_Dokumenta();
                        this.ProvjeriKnjizenje();
                    }
                }
            }
        }

        public void OdKnjizi()
        {
            if (this.GkstavkaDataSet1.GKSTAVKA.Rows.Count != 0)
            {
                int index = this.ugrdGK.ActiveRow.Index;
                SqlConnection connection = new SqlConnection {
                    ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
                };
                CurrencyManager manager = (CurrencyManager) this.BindingContext[this.GkstavkaDataSet1, "GKSTAVKA"];
                DataRowView current = (DataRowView) manager.Current;
                string str = "UPDATE GKSTAVKA SET STATUSGK = 0 WHERE BROJDOKUMENTA = @BROJDOKUMENTA AND IDDOKUMENT=@IDDOKUMENT";
                SqlCommand command = new SqlCommand {
                    Connection = connection,
                    CommandText = str,
                    CommandType = CommandType.Text
                };
                command.Parameters.Add("@BROJDOKUMENTA", SqlDbType.Int).Value = RuntimeHelpers.GetObjectValue(current["BROJDOKUMENTA"]);
                command.Parameters.Add("@IDDOKUMENT", SqlDbType.Int).Value = RuntimeHelpers.GetObjectValue(current["idDOKUMENT"]);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    this.GkstavkaDataSet1.Clear();
                    this.daGKSTAVKA.FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE(this.GkstavkaDataSet1, Conversions.ToInteger(this.txtSifrDokumenta.Text), Conversions.ToInteger(this.txtBrojDokumenta.Text), (short)DateAndTime.Year(mipsed.application.framework.Application.Zavrsni));
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                }
                try
                {
                    this.ugrdGK.ActiveRow = this.ugrdGK.Rows[index];
                    this.ugrdGK.ActiveRow.Selected = true;
                    this.ugrdGK.Focus();
                }
                catch (System.Exception exception3)
                {
                    throw exception3;
                    //Exception exception2 = exception3;
                }
                this.Status_Dokumenta();
            }
        }

        public void OmoguciUnos()
        {
            this.ToolBar1.Buttons[0].Enabled = true;
            this.ToolBar1.Buttons[1].Enabled = true;
        }

        public void OnemoguciUnos()
        {
            this.ToolBar1.Buttons[0].Enabled = false;
            this.ToolBar1.Buttons[1].Enabled = false;
        }

        public void OtvoriDokument()
        {
            frmListaDokumenataGK agk = new frmListaDokumenataGK();

            DialogResult odgovor = agk.ShowDialog();
            if (odgovor == DialogResult.Ignore)
            {
                IspisViseTemeljnica();
            }
            else
            {

                if (odgovor != DialogResult.OK)
                {
                    this.txtSifrDokumenta.Select();
                    goto Label_0276;
                }


                if (string.IsNullOrEmpty(agk.iddokument))
                    return;

                this.txtSifrDokumenta.Text = agk.iddokument;
                this.txtBrojDokumenta.Text = agk.brojdokumenta;
                txtOpis.Text = agk.opisDokumenta;
                this.povecavaj = false;
                this.GkstavkaDataSet1.Clear();
                this.GkstavkaDataSet1.GKSTAVKA.Clear();
                this.daGKSTAVKA.FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE(this.GkstavkaDataSet1, Conversions.ToInteger(this.txtSifrDokumenta.Text), Conversions.ToInteger(this.txtBrojDokumenta.Text), (short)DateAndTime.Year(this.zavrsniDatum));
                this.dteDatumDokumenta.SuspendLayout();
                if (this.GkstavkaDataSet1.GKSTAVKA.Rows.Count > 0)
                {
                    try
                    {
                        this.dteDatumDokumenta.Value = RuntimeHelpers.GetObjectValue(this.GkstavkaDataSet1.GKSTAVKA.Rows[0]["datumdokumenta"]);
                        this.txtNazivDokument.Text = Conversions.ToString(this.GkstavkaDataSet1.GKSTAVKA.Rows[0]["NAZIVDOKUMENT"]);
                        this.txtSifrDokumenta.ReadOnly = true;
                        this.txtBrojDokumenta.ReadOnly = true;
                        goto Label_022B;
                    }
                    catch (System.Exception exception1)
                    {
                        throw exception1;

                        //this.GkstavkaDataSet1.GKSTAVKA.Clear();
                        //this.txtSifrDokumenta.ReadOnly = false;
                        //this.txtBrojDokumenta.ReadOnly = false;
                        //this.txtSifrDokumenta.Clear();
                        //this.txtBrojDokumenta.Clear();
                        //this.txtNazivDokument.Text = "";
                        //this.txtSifrDokumenta.Focus();
                        //this.ponistitabstop();

                        //return;
                    }
                }
                try
                {
                    this.dteDatumDokumenta.Value = DateAndTime.Today;
                }
                catch (System.Exception exception3)
                {
                    this.dteDatumDokumenta.Value = this.pocetniDatum;
                    throw exception3;
                }

                this.dteDatumDokumenta.Focus();
                this.txtSifrDokumenta.ReadOnly = true;
                this.txtBrojDokumenta.ReadOnly = true;
            Label_022B:
                this.postavitabstop();
                this.txtSifrDokumenta.ReadOnly = true;
                this.txtBrojDokumenta.ReadOnly = true;
                this.txtBrojDokumenta.Focus();
                SendKeys.Send("{TAB}");
                SendKeys.Send("{TAB}");
            Label_0276:
                this.Status_Dokumenta();

            }
        }

        public void Izvodi()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.ShowDialog();

            Parser parser = new Parser(ofd.FileName);

        }

        public void PogledUVeze()
        {
            DataRowView current = (DataRowView)this.BindingContext[this.GkstavkaDataSet1, "GKSTAVKA"].Current;

            if (current == null)
                return;

            new frmPogledUVeze
            {
                IDGKSTAVKA = Conversions.ToInteger(current["IDGKSTAVKA"]),
                naslov = string.Format("Vezane stavke za {0}-{1}", RuntimeHelpers.GetObjectValue(current["nazivdokument"]), Conversions.ToString(current["brojdokumenta"]))
            }.ShowDialog();

            GKSTAVKADataAdapter adapter = new GKSTAVKADataAdapter();
            int iDGKSTAVKA = Conversions.ToInteger(current["idgkstavka"]);
            current.Delete();
            current.EndEdit();
            adapter.FillByIDGKSTAVKA(this.GkstavkaDataSet1, iDGKSTAVKA);
        }

        public void ponistitabstop()
        {
            this.txtSifrDokumenta.TabStop = true;
            this.txtNazivDokument.TabStop = true;
            this.txtBrojDokumenta.TabStop = true;
        }

        public void postavitabstop()
        {
            this.txtSifrDokumenta.TabStop = false;
            this.txtNazivDokument.TabStop = false;
            this.txtBrojDokumenta.TabStop = false;
        }

        public void Pregled_otvorenih_stavaka()
        {
            if ((this.GkstavkaDataSet1.GKSTAVKA.Rows.Count > 0) && Operators.ConditionalCompareObjectEqual(this.GkstavkaDataSet1.GKSTAVKA.Rows[0]["statusgk"], true, false))
            {
                Interaction.MsgBox("Dokument je proknjižen u glavnu knjigu, za nastavak rada odknjižite dokument!", MsgBoxStyle.OkOnly, null);
            }
            else
            {
                new frmRadSaOtvorenimStavkama(null, decimal.Zero, null, null, null) { __ParentForm = this }.ShowDialog();
                this.ugrdGK.PerformAction(UltraGridAction.FirstRowInBand);
                this.ProvjeriKnjizenje();
                this.Status_Dokumenta();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!((msg.Msg == 0x100) | (msg.Msg == 260)))
            {
                bool flag = false;
                return flag;
            }
            Keys keys = keyData;
            switch (keys)
            {
                case Keys.F12:
                    this.OdKnjizi();
                    return true;

                case Keys.Delete:
                    this.ObrisiStavku();
                    return true;
            }
            if (keys != Keys.Escape)
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
            if ((this.txtSifrDokumenta.Text == "") & (this.txtNazivDokument.Text == ""))
            {
                this.ParentForm.Close();
                return true;
            }
            if (this.ugrdGK.ActiveRow != null)
            {
                UltraGridRow activeRow = this.ugrdGK.ActiveRow;
                if (this.ugrdGK.ActiveRow.IsSummaryRow)
                {
                    this.povecavaj = true;
                    this.GkstavkaDataSet1.GKSTAVKA.Clear();
                    this.txtSifrDokumenta.ReadOnly = false;
                    this.txtBrojDokumenta.ReadOnly = false;
                    this.txtSifrDokumenta.Clear();
                    this.txtBrojDokumenta.Clear();
                    this.txtNazivDokument.Text = "";
                    this.txtSifrDokumenta.Focus();
                    this.ponistitabstop();
                    this.zaizlaz = false;
                    this.OmoguciUnos();
                    this.Status_Dokumenta();
                    return true;
                }
                if (!((DataRowView) activeRow.ListObject).IsNew)
                {
                    this.ugrdGK.PerformAction(UltraGridAction.ExitEditMode);
                    this.ugrdGK.ActiveRow = null;
                }
                if (((DataRowView) activeRow.ListObject).IsNew)
                {
                    this.zaizlaz = true;
                    activeRow.CancelUpdate();
                    activeRow.Delete(false);
                    this.ugrdGK.ActiveRow = null;
                    return true;
                }
            }
            this.povecavaj = true;
            this.GkstavkaDataSet1.GKSTAVKA.Clear();
            this.txtSifrDokumenta.ReadOnly = false;
            this.txtBrojDokumenta.ReadOnly = false;
            this.txtSifrDokumenta.Clear();
            this.txtBrojDokumenta.Clear();
            this.txtNazivDokument.Text = "";
            this.txtSifrDokumenta.Focus();
            this.ponistitabstop();
            this.zaizlaz = false;
            this.OmoguciUnos();
            this.Status_Dokumenta();
            return true;
        }

        public void ProKnjizi()
        {
            if (this.GkstavkaDataSet1.GKSTAVKA.Rows.Count != 0)
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = this.GkstavkaDataSet1.GKSTAVKA.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataRow current = (DataRow) enumerator.Current;
                        current.BeginEdit();
                        current["statusgk"] = Operators.NotObject(current["statusgk"]);
                        current.EndEdit();
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                if (Operators.ConditionalCompareObjectEqual(this.GkstavkaDataSet1.GKSTAVKA.Rows[0]["statusgk"], false, false))
                {
                    this.OmoguciUnos();
                }
                else
                {
                    this.OnemoguciUnos();
                }
                this.Spremi_Promjene();
                this.Status_Dokumenta();
                this.ugrdGK.PerformAction(UltraGridAction.FirstRowInGrid);
            }
        }

        public void ProvjeriKnjizenje()
        {
            if (this.GkstavkaDataSet1.GKSTAVKA.Rows.Count > 0)
            {
                decimal num = DB.N20(RuntimeHelpers.GetObjectValue(this.GkstavkaDataSet1.GKSTAVKA.Compute("SUM(DUGUJE)", "")));
                decimal num2 = DB.N20(RuntimeHelpers.GetObjectValue(this.GkstavkaDataSet1.GKSTAVKA.Compute("SUM(POTRAZUJE)", "")));
                if (decimal.Compare(decimal.Subtract(Math.Abs(num), Math.Abs(num2)), decimal.Zero) == 0)
                {
                    this.ToolBar1.Buttons[3].Enabled = true;
                }
                else
                {
                    this.ToolBar1.Buttons[3].Enabled = false;
                }
            }
            else
            {
                this.ToolBar1.Buttons[3].Enabled = false;
            }
        }

        private void SetSmartPartInfoInformation()
        {
            this.smartPartInfo1.Description = "Glavna knjiga";
        }

        public bool Spremi_Promjene()
        {
            bool flag = false;
            try
            {
                this.dagk.Update(this.GkstavkaDataSet1);
                flag = true;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                //this.GkstavkaDataSet1.GKSTAVKA.RejectChanges();
                //flag = false;
                
            }
            return flag;
        }

        public void Status_Dokumenta()
        {
            bool flag2;
            bool flag = false;
            if (this.GkstavkaDataSet1.GKSTAVKA.Rows.Count > 0)
            {
                flag = true;
                decimal num = DB.N20(RuntimeHelpers.GetObjectValue(this.GkstavkaDataSet1.GKSTAVKA.Compute("SUM(zatvoreniiznos)", "")));
                flag2 = Conversions.ToBoolean(this.GkstavkaDataSet1.GKSTAVKA.Rows[0]["statusgk"]);
            }
            else
            {
                flag2 = false;
            }
            if (flag2)
            {
                flag = true;
                this.dteDatumDokumenta.Enabled = false;
                this.ugrdGK.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
                this.OnemoguciUnos();
            }
            else
            {
                flag = false;
                this.dteDatumDokumenta.Enabled = true;
                this.ugrdGK.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True;
                this.OmoguciUnos();
            }
            if (flag)
            {
                this.ToolBar1.Buttons[3].Text = "Odknjiži";
            }
            else
            {
                this.ToolBar1.Buttons[3].Text = "Proknjiži";
            }
            this.ProvjeriKnjizenje();
        }

        private void TestSmartPart_Load(object sender, EventArgs e)
        {
            this.MakeEnterActLikeTab(this.ugrdGK);
            KONTODataAdapter adapter = new KONTODataAdapter();
            ORGJEDDataAdapter adapter3 = new ORGJEDDataAdapter();
            MJESTOTROSKADataAdapter adapter2 = new MJESTOTROSKADataAdapter();
            new partnerabecedaDataAdapter().Fill(this.PartnerDataSet1);
            adapter.Fill(this.KontoDataSet1);
            adapter3.Fill(this.OrgjedDataSet1);
            adapter2.Fill(this.MjestotroskaDataSet1);
            this.pocetniDatum = mipsed.application.framework.Application.Pocetni;
            this.zavrsniDatum = mipsed.application.framework.Application.Zavrsni;
            this.dteDatumDokumenta.MaxDate = this.zavrsniDatum;
            this.dteDatumDokumenta.MinDate = this.pocetniDatum;
            this.work = (UltraExplorerBarWorkspace) this.Controller.WorkItem.Workspaces["TaskPanel"];
            this.Controller.WorkItem.Workspaces["Dock"].Hide(this.work);
            if ((DateTime.Compare(DateAndTime.Today, this.pocetniDatum) >= 0) & (DateTime.Compare(DateAndTime.Today, this.zavrsniDatum) <= 0))
            {
                this.dteDatumDokumenta.Value = DateAndTime.Today;
            }
            else
            {
                this.dteDatumDokumenta.Value = this.pocetniDatum;
            }
            SendKeys.Send("{TAB}");
            SendKeys.Send("{TAB}");
            InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
            InfraCustom.PostaviEnterUTabSvimEditKontrolama(this);
        }

        private void Textbox1_EditorButtonClick(object sender, EditorButtonEventArgs e)
        {
            if (e.Button.Key == "Uneseni")
            {
                this.OtvoriDokument();
            }
            else if (this.GkstavkaDataSet1.GKSTAVKA.Rows.Count > 0)
            {
                this.ugrdGK.Focus();
            }
            else
            {
                DOKUMENTSelectionListWorkItem item = this.Controller.WorkItem.Items.AddNew<DOKUMENTSelectionListWorkItem>("test");
                DataRow row = item.ShowModal(true, "", null);
                item.Terminate();
                if (row != null)
                {
                    this.txtSifrDokumenta.ReadOnly = false;
                    this.txtBrojDokumenta.ReadOnly = false;
                    this.txtSifrDokumenta.Text = Conversions.ToString(row["iddokument"]);
                    this.txtNazivDokument.Text = Conversions.ToString(row["nazivdokument"]);
                    this.txtBrojDokumenta.Select();
                    this.txtBrojDokumenta.Text = Conversions.ToString(Operators.AddObject(this.ZadnjiBrojDokumenta(), 1));
                }
            }
        }

        private void Textbox1_Validating(object sender, CancelEventArgs e)
        {
            if (!this.txtSifrDokumenta.ReadOnly)
            {
                int num = 0;
                try
                {
                    num = Conversions.ToInteger(this.txtSifrDokumenta.Text);
                }
                catch (System.Exception)
                {
                    this.txtSifrDokumenta.Clear();
                    this.txtSifrDokumenta.Text = "0";
                    this.txtSifrDokumenta.Select();
                    
                    return;
                }

                DOKUMENTDataAdapter adapter = new DOKUMENTDataAdapter();
                DOKUMENTDataSet dataSet = new DOKUMENTDataSet();
                adapter.FillByIDDOKUMENT(dataSet, num);
                if (dataSet.DOKUMENT.Rows.Count == 0)
                {
                    this.txtSifrDokumenta.Text = "";
                    this.txtSifrDokumenta.Select();
                }
                else
                {
                    this.txtNazivDokument.Text = Conversions.ToString(dataSet.DOKUMENT.Rows[0]["NAZIVDOKUMENT"]);
                    if (Operators.ConditionalCompareObjectEqual(this.povecavaj, true, false))
                    {
                        this.txtBrojDokumenta.Text = Conversions.ToString(Operators.AddObject(this.ZadnjiBrojDokumenta(), 1));
                    }
                    e.Cancel = false;
                }
            }
        }

        private void Textbox3_Validating(object sender, CancelEventArgs e)
        {
            if (!this.txtBrojDokumenta.ReadOnly)
            {
                int num = 0;
                try
                {
                    num = int.Parse(this.txtBrojDokumenta.Text);
                }
                catch (System.Exception)
                {                    
                    this.txtBrojDokumenta.Clear();
                    this.txtSifrDokumenta.Clear();
                    this.txtSifrDokumenta.Focus();
                    
                    return;
                }
                this.GkstavkaDataSet1.Clear();
                this.daGKSTAVKA.FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE(this.GkstavkaDataSet1, Conversions.ToInteger(this.txtSifrDokumenta.Text), num, mipsed.application.framework.Application.ActiveYear);
                if (this.GkstavkaDataSet1.GKSTAVKA.Rows.Count > 0)
                {
                    try
                    {
                        this.dteDatumDokumenta.Value = RuntimeHelpers.GetObjectValue(this.GkstavkaDataSet1.GKSTAVKA.Rows[0]["datumdokumenta"]);
                        this.ugrdGK.Focus();
                    }
                    catch (System.Exception)
                    {
                        Interaction.MsgBox("Greška u datumu dokumenta! ", MsgBoxStyle.OkOnly, null);
                        this.GkstavkaDataSet1.GKSTAVKA.Clear();
                        this.txtSifrDokumenta.ReadOnly = false;
                        this.txtBrojDokumenta.ReadOnly = false;
                        this.txtSifrDokumenta.Clear();
                        this.txtBrojDokumenta.Clear();
                        this.txtNazivDokument.Text = "";
                        this.txtSifrDokumenta.Focus();
                        this.ponistitabstop();
                        
                        return;
                    }
                    this.txtSifrDokumenta.ReadOnly = true;
                    this.txtBrojDokumenta.ReadOnly = true;

                    GetOpisDokumenta(txtSifrDokumenta.Value, txtBrojDokumenta.Value);
                    
                }
                else
                {
                    try
                    {
                        this.dteDatumDokumenta.Value = DateAndTime.Today;
                    }
                    catch (System.Exception)
                    {
                        this.dteDatumDokumenta.Value = this.pocetniDatum;
                        
                    }
                    this.dteDatumDokumenta.Focus();
                    this.txtSifrDokumenta.ReadOnly = true;
                    this.txtBrojDokumenta.ReadOnly = true;
                }
                this.postavitabstop();
                this.Status_Dokumenta();
                InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
                this.ugrdGK.PerformAction(UltraGridAction.FirstRowInGrid);
            }
        }

        private void GetOpisDokumenta(object sifraDokumenta, object brojDokumenta)
        {
            Mipsed7.DataAccessLayer.SqlClient clinet = new Mipsed7.DataAccessLayer.SqlClient();

            try
            {
                if (sifraDokumenta != null && brojDokumenta != null)
                {
                    txtOpis.Value =  clinet.ExecuteScalar("Select Top 1 OpisDokumenta From GKSTAVKA Where BROJDOKUMENTA = '" + txtBrojDokumenta.Value +
                            "' And IDDOKUMENT = '" + txtSifrDokumenta.Value + "' And GKGODIDGODINE = '" + mipsed.application.framework.Application.ActiveYear + "'");
                }
            }
            catch { }
        }

        private void ToolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button.Name == "ToolBarButton1")
            {
                this.unos_stavke();
            }
            if (e.Button.Name == "ToolBarButton2")
            {
                this.ObrisiStavku();
            }
            if (e.Button.Name == "ToolBarButton3")
            {
            }
            if (e.Button.Name == "ToolBarButton4")
            {
                this.ProKnjizi();
            }
            if (e.Button.Name == "ToolBarButton5")
            {
                this.Izvrsi_renumeraciju_Stavaka();
            }
            if (e.Button.Name == "ToolBarButton6")
            {
                this.Pregled_otvorenih_stavaka();
            }
            if (e.Button.Name == "ToolBarButton3")
            {
                this.IspisTemeljniceNaPapir();
            }
            if (e.Button.Name == "ToolBarButton7")
            {
                this.PogledUVeze();
            }
            if (e.Button.Name == "ToolBarButton8")
            {
                this.Izvodi();
            }
        }

        private void txtSifrDokumenta_ValueChanged(object sender, EventArgs e)
        {
        }

        private void UltraGrid1_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell.Column.Key == "IDKONTO")
            {
                DataRow[] rowArray = this.KontoDataSet1.KONTO.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("IDKONTO = '", e.Cell.Value), "'")));
                if (rowArray.Length == 0)
                {
                    this.ugrdGK.DisplayLayout.Bands[0].Columns["idpartner"].CellActivation = Activation.NoEdit;
                    this.ugrdGK.DisplayLayout.Bands[0].Columns["GKDATUMVALUTE"].CellActivation = Activation.NoEdit;
                    e.Cell.IgnoreRowColActivation = true;
                }
                else if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(rowArray[0]["IDAKTIVNOST"], 2, false), Operators.CompareObjectEqual(rowArray[0]["IDAKTIVNOST"], 3, false))))
                {
                    this.ugrdGK.DisplayLayout.Bands[0].Columns["idpartner"].CellActivation = Activation.AllowEdit;
                    this.ugrdGK.DisplayLayout.Bands[0].Columns["GKDATUMVALUTE"].CellActivation = Activation.AllowEdit;
                    //this.unospartnera = true;
                }
                else
                {
                    this.ugrdGK.DisplayLayout.Bands[0].Columns["idpartner"].CellActivation = Activation.NoEdit;
                    this.ugrdGK.DisplayLayout.Bands[0].Columns["GKDATUMVALUTE"].CellActivation = Activation.NoEdit;
                }
            }
        }

        private void UltraGrid1_AfterEnterEditMode(object sender, EventArgs e)
        {
            if (this.ugrdGK.ActiveCell.Column.Key == "IDKONTO")
            {
                this.ugrdGK.ActiveCell.EditorResolved.DropDown();
            }
            if (this.ugrdGK.ActiveCell.Column.Key == "IDORGJED")
            {
                this.ugrdGK.ActiveCell.EditorResolved.DropDown();
            }
            if (this.ugrdGK.ActiveCell.Column.Key == "IDMJESTOTROSKA")
            {
                this.ugrdGK.ActiveCell.EditorResolved.DropDown();
            }
            if (this.ugrdGK.ActiveCell.Column.Key == "IDPARTNER")
            {
                this.ugrdGK.ActiveCell.EditorResolved.DropDown();
            }
            if (this.ugrdGK.ActiveCell.Column.Key == "duguje")
            {
                this.ugrdGK.ActiveCell.SelectAll();
            }
            if (this.ugrdGK.ActiveCell.Column.Key == "POTRAZUJE")
            {
                this.ugrdGK.ActiveCell.SelectAll();
            }
            if (this.ugrdGK.ActiveCell.Column.Key == "OPIS")
            {
                this.ugrdGK.ActiveCell.SelectAll();
            }
        }

        private void UltraGrid1_AfterRowsDeleted(object sender, EventArgs e)
        {
            this.Spremi_Promjene();
            this.Status_Dokumenta();
        }

        private void UltraGrid1_AfterRowUpdate(object sender, RowEventArgs e)
        {
            if (this.Spremi_Promjene())
            {
                this.Status_Dokumenta();
            }
        }

        private void UltraGrid1_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            if ((this.ugrdGK.ActiveRow.Cells["ZATVORENIIZNOS"].Value != DBNull.Value) && Operators.ConditionalCompareObjectGreater(this.ugrdGK.ActiveRow.Cells["ZATVORENIIZNOS"].Value, 0, false))
            {
                e.Cancel = true;
            }
            else if (e.Cell.Column.Key == "IDPARTNER")
            {
                DataRow[] rowArray = this.KontoDataSet1.KONTO.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("IDKONTO = '", this.ugrdGK.ActiveRow.Cells["idkonto"].Value), "'")));
                if (rowArray.Length == 0)
                {
                    this.ugrdGK.DisplayLayout.Bands[0].Columns["idpartner"].CellActivation = Activation.NoEdit;
                    this.ugrdGK.DisplayLayout.Bands[0].Columns["GKDATUMVALUTE"].CellActivation = Activation.NoEdit;
                    //this.unospartnera = false;
                    this.ugrdGK.PerformAction(UltraGridAction.NextCell);
                }
                else if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(rowArray[0]["IDAKTIVNOST"], 2, false), Operators.CompareObjectEqual(rowArray[0]["IDAKTIVNOST"], 3, false))))
                {
                    this.ugrdGK.DisplayLayout.Bands[0].Columns["idpartner"].CellActivation = Activation.AllowEdit;
                    this.ugrdGK.DisplayLayout.Bands[0].Columns["GKDATUMVALUTE"].CellActivation = Activation.AllowEdit;
                    //this.unospartnera = true;
                }
                else
                {
                    this.ugrdGK.DisplayLayout.Bands[0].Columns["idpartner"].CellActivation = Activation.NoEdit;
                    this.ugrdGK.DisplayLayout.Bands[0].Columns["GKDATUMVALUTE"].CellActivation = Activation.NoEdit;
                    //this.unospartnera = false;
                    this.ugrdGK.PerformAction(UltraGridAction.NextCell);
                }
            }
            else
            {
                e.Cancel = false;
                this.ugrdGK.PerformAction(UltraGridAction.NextCell);
            }
        }

        private void UltraGrid1_BeforeCellDeactivate(object sender, CancelEventArgs e)
        {
            if ((((UltraGrid) sender).ActiveCell.Column.Key == "IDMJESTOTROSKA") && Conversions.ToBoolean(Operators.AndObject(((UltraGrid) sender).ActiveCell.Value == DBNull.Value, Operators.CompareObjectEqual(this.zaizlaz, false, false))))
            {
                e.Cancel = true;
            }
            if ((((UltraGrid) sender).ActiveCell.Column.Key == "IDORGJED") && Conversions.ToBoolean(Operators.AndObject(((UltraGrid) sender).ActiveCell.Value == DBNull.Value, Operators.CompareObjectEqual(this.zaizlaz, false, false))))
            {
                e.Cancel = true;
            }
            if (Conversions.ToBoolean(Operators.AndObject(((UltraGrid) sender).ActiveCell.Column.Key == "IDKONTO", Operators.CompareObjectEqual(this.zaizlaz, false, false))) && (((UltraGrid) sender).ActiveCell.Value == DBNull.Value))
            {
                e.Cancel = true;
            }
            if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(((UltraGrid) sender).ActiveCell.Column.Key == "IDPARTNER", Operators.CompareObjectEqual(this.zaizlaz, false, false)), ((UltraGrid) sender).ActiveCell.Activation == Activation.AllowEdit)) && (((UltraGrid) sender).ActiveCell.Value == DBNull.Value))
            {
                e.Cancel = false;
            }
        }

        private void UltraGrid1_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            DataRowView current = null;
            if (current == null)
            {
                current = (DataRowView) this.BindingContext[this.GkstavkaDataSet1, "GKSTAVKA"].Current;
            }
            if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectGreater(this.ugrdGK.ActiveRow.Cells["ZATVORENIIZNOS"].Value, 0, false), (((this.ugrdGK.ActiveCell.Column.Key == "IDPARTNER") | (this.ugrdGK.ActiveCell.Column.Key == "IDKONTO")) | (this.ugrdGK.ActiveCell.Column.Key == "duguje")) | (this.ugrdGK.ActiveCell.Column.Key == "POTRAZUJE"))))
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void UltraGrid1_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            if (((UltraGrid) sender).ActiveCell.Column.Key == "IDKONTO")
            {
                Interaction.MsgBox("Ne postoji konto u kontnome planu", MsgBoxStyle.OkOnly, null);
                e.RaiseErrorEvent = false;
                e.StayInEditMode = true;
                ((UltraGrid) sender).ActiveCell.Value = DBNull.Value;
            }
            if (((UltraGrid) sender).ActiveCell.Column.Key == "IDMJESTOTROSKA")
            {
                Interaction.MsgBox("Ne postoji mjesto troška", MsgBoxStyle.OkOnly, null);
                e.RaiseErrorEvent = false;
                e.StayInEditMode = true;
                ((UltraGrid) sender).ActiveCell.Value = DBNull.Value;
            }
            if (((UltraGrid) sender).ActiveCell.Column.Key == "IDORGJED")
            {
                Interaction.MsgBox("Ne postoji organizacijska jedinica", MsgBoxStyle.OkOnly, null);
                e.RaiseErrorEvent = false;
                e.StayInEditMode = true;
                ((UltraGrid) sender).ActiveCell.Value = DBNull.Value;
            }
            if (((UltraGrid) sender).ActiveCell.Column.Key == "IDPARTNER")
            {
                Interaction.MsgBox("Ne postoji PARTNER", MsgBoxStyle.OkOnly, null);
                e.RaiseErrorEvent = false;
                e.StayInEditMode = true;
                ((UltraGrid) sender).ActiveCell.Value = DBNull.Value;
            }
        }

        private void UltraGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((this.ugrdGK.ActiveCell != null) && (((e.KeyCode == Keys.Tab) | (e.KeyCode == Keys.Return)) & (this.ugrdGK.ActiveCell.Column.Key == "POTRAZUJE")))
            {
                this.unos_stavke();
                e.Handled = true;
            }
        }

        private void UltraGroupBox1_Click(object sender, EventArgs e)
        {
        }

        public void unos_stavke()
        {
            if (this.txtBrojDokumenta.Text == "")
            {
                Interaction.MsgBox("Prije unosa potrebno je otvoriti postojeći ili započeti novu temeljnicu!", MsgBoxStyle.Critical, "Financijsko poslovanje");
            }
            else
            {
                this.ugrdGK.Focus();
                try
                {
                    this.BindingContext[this.GkstavkaDataSet1, "GKSTAVKA"].EndCurrentEdit();
                    this.Spremi_Promjene();

                    SpremiOpisDokumneta(txtOpis.Value);
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                    
                    
                    //return;
                }
                this.BindingContext[this.GkstavkaDataSet1, "GKSTAVKA"].AddNew();
                DataRowView current = (DataRowView) this.BindingContext[this.GkstavkaDataSet1, "GKSTAVKA"].Current;
                if (this.GkstavkaDataSet1.GKSTAVKA.Rows.Count > 0)
                {
                    current["datumdokumenta"] = RuntimeHelpers.GetObjectValue(this.dteDatumDokumenta.Value);
                    current["brojdokumenta"] = this.txtBrojDokumenta.Text;
                    current["brojstavke"] = this.GkstavkaDataSet1.GKSTAVKA.Rows.Count + 1;
                    current["IDORGJED"] = RuntimeHelpers.GetObjectValue(this.GkstavkaDataSet1.GKSTAVKA.Rows[this.GkstavkaDataSet1.GKSTAVKA.Rows.Count - 1]["IDORGJED"]);
                    current["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(this.GkstavkaDataSet1.GKSTAVKA.Rows[this.GkstavkaDataSet1.GKSTAVKA.Rows.Count - 1]["IDMJESTOTROSKA"]);
                    current["iddokument"] = RuntimeHelpers.GetObjectValue(this.GkstavkaDataSet1.GKSTAVKA.Rows[this.GkstavkaDataSet1.GKSTAVKA.Rows.Count - 1]["IDDOKUMENT"]);
                    current["OPIS"] = RuntimeHelpers.GetObjectValue(this.GkstavkaDataSet1.GKSTAVKA.Rows[this.GkstavkaDataSet1.GKSTAVKA.Rows.Count - 1]["OPIS"]);
                    current["zatvoreniiznos"] = 0;
                    current["statusgk"] = 0;
                    current["potrazuje"] = 0;
                    current["DUGUJE"] = 0;
                    current["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                    this.ugrdGK.ActiveRow = this.ugrdGK.Rows[this.ugrdGK.Rows.Count - 1];
                    this.ugrdGK.PerformAction(UltraGridAction.EnterEditMode);
                    this.ugrdGK.PerformAction(UltraGridAction.ActivateCell);
                    this.ugrdGK.PerformAction(UltraGridAction.NextCell);
                    this.ugrdGK.PerformAction(UltraGridAction.ActivateCell);
                    this.ugrdGK.PerformAction(UltraGridAction.EnterEditModeAndDropdown);
                }
                else
                {
                    current["datumdokumenta"] = RuntimeHelpers.GetObjectValue(this.dteDatumDokumenta.Value);
                    current["brojdokumenta"] = this.txtBrojDokumenta.Text;
                    current["brojstavke"] = this.GkstavkaDataSet1.GKSTAVKA.Rows.Count + 1;
                    current["iddokument"] = this.txtSifrDokumenta.Text;
                    current["OPIS"] = "";
                    current["zatvoreniiznos"] = 0;
                    current["statusgk"] = 0;
                    current["potrazuje"] = 0;
                    current["DUGUJE"] = 0;
                    current["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                    this.ugrdGK.ActiveRow = this.ugrdGK.Rows[this.ugrdGK.Rows.Count - 1];
                    this.ugrdGK.PerformAction(UltraGridAction.EnterEditMode);
                    this.ugrdGK.PerformAction(UltraGridAction.ActivateCell);
                    this.ugrdGK.PerformAction(UltraGridAction.NextCell);
                    this.ugrdGK.PerformAction(UltraGridAction.ActivateCell);
                    this.ugrdGK.PerformAction(UltraGridAction.EnterEditModeAndDropdown);
                }
            }
        }

        private void SpremiOpisDokumneta(object opis)
        {
            Mipsed7.DataAccessLayer.SqlClient clinet = new Mipsed7.DataAccessLayer.SqlClient();

            try
            {
                if (opis != null)
                {
                    clinet.ExecuteNonQuery("Update GKSTAVKA Set OpisDokumenta = '" + opis.ToString() + "' Where BROJDOKUMENTA = '" + txtBrojDokumenta.Value +
                    "' And IDDOKUMENT = '" + txtSifrDokumenta.Value + "' And GKGODIDGODINE = '" + mipsed.application.framework.Application.ActiveYear + "'");
                }
            }
            catch { }
        }

        public object ZadnjiBrojDokumenta()
        {
            object objectValue = new object();
            SqlConnection connection = new SqlConnection {
                ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
            };
            SqlCommand command = new SqlCommand {
                CommandType = CommandType.Text,
                CommandText = "SELECT MAX(CAST(BROJDOKUMENTA AS INTEGER)) FROM GKSTAVKA WHERE IDDOKUMENT = @IDDOKUMENT AND gkgodidgodine =@GODINA"
            };
            command.Parameters.AddWithValue("@IDDOKUMENT", Conversions.ToInteger(this.txtSifrDokumenta.Value));
            command.Parameters.AddWithValue("@GODINA", SqlDbType.VarChar).Value = mipsed.application.framework.Application.ActiveYear;
            command.Connection = connection;
            connection.Open();
            try
            {
                objectValue = RuntimeHelpers.GetObjectValue(command.ExecuteScalar());
                if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(objectValue)))
                {
                    objectValue = 0;
                }
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
            connection.Close();
            return objectValue;
        }

        private AutoHideControl _GKSmartPartAutoHideControl;

        private UnpinnedTabArea _GKSmartPartUnpinnedTabAreaBottom;

        private UnpinnedTabArea _GKSmartPartUnpinnedTabAreaLeft;

        private UnpinnedTabArea _GKSmartPartUnpinnedTabAreaRight;

        private UnpinnedTabArea _GKSmartPartUnpinnedTabAreaTop;

        [CreateNew]
        public MainController Controller { get; set; }

        public int CurrentRowIndex
        {
            get
            {
                if (this.ugrdGK.ActiveRow == null)
                {
                    return -1;
                }
                UltraGridRow activeRow = this.ugrdGK.ActiveRow;
                while ((activeRow.ParentRow != null) && !(activeRow.ParentRow is UltraGridGroupByRow))
                {
                    activeRow = activeRow.ParentRow;
                }
                return activeRow.ListIndex;
            }
        }

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

        public UltraDateTimeEditor dteDatumDokumenta;

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

        public GKSTAVKADataSet GkstavkaDataSet1;

        private ImageList ImageList1;

        private UltraDropDown KONTO;

        private KONTODataSet KontoDataSet1;

        private MJESTOTROSKADataSet MjestotroskaDataSet1;

        private UltraDropDown MT;

        private UltraDropDown OJ;

        private ORGJEDDataSet OrgjedDataSet1;

        private Panel Panel1;

        private Panel Panel2;

        private PARTNERDataSet PartnerDataSet1;

        public DataRow SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        private ToolBar ToolBar1;

        private ToolBarButton ToolBarButton1;

        private ToolBarButton ToolBarButton2;

        private ToolBarButton ToolBarButton3;

        private ToolBarButton ToolBarButton4;

        private ToolBarButton ToolBarButton5;

        private ToolBarButton ToolBarButton6;

        private ToolBarButton ToolBarButton8;

        private ToolBarButton ToolBarButton7;

        public UltraTextEditor txtBrojDokumenta;

        public UltraLabel txtNazivDokument;

        public UltraTextEditor txtSifrDokumenta;

        private UltraGrid ugrdGK;

        private UltraCalcManager UltraCalcManager1;

        private UltraDockManager UltraDockManager1;

        private UltraDropDown UltraDropDown1;

        private UltraGridBagLayoutManager UltraGridBagLayoutManager1;

        private UltraGroupBox UltraGroupBox1;

        private UltraLabel UltraLabel1;

        private UltraLabel UltraLabel2;

        private UltraLabel UltraLabel3;


        private UltraLabel ulbOpis;
        public UltraTextEditor txtOpis;


        private WindowDockingArea WindowDockingArea1;

        private WindowDockingArea WindowDockingArea2;

        private WindowDockingArea WindowDockingArea4;

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
            }
        }
    }
}


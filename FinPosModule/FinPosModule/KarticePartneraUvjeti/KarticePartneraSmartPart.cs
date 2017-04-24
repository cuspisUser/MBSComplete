using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.Workspaces;
using Evolve.Wpf.Samples;
using Hlp;
using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NetAdvantage.Controllers;
using NetAdvantage.WorkItems;
using mipsed.application.framework;
using Placa;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Forms;


namespace FinPosModule.KarticePartneraUvjeti
{

    [SmartPart]
    public class KarticePartneraSmartPart : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private IContainer components;
        private SmartPartInfoProvider infoProvider;
        
        private DateTime POCETNI;
        private ReportDocument rpt;
        private SmartPartInfo smartPartInfo1;
        private CheckBox cbkPartnerUcenik;
        private DateTime ZAVRSNI;

        public KarticePartneraSmartPart()
        {
            base.Load += new EventHandler(this.KarticePartneraSmartPart_Load);
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo("Izvještaji-SK-Kartice partnera", "Izvještaji-SK-Kartice partnera");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void BackgroundUpdate()
        {
            new ProgressDialog { WindowStartupLocation = WindowStartupLocation.CenterScreen, DialogText = "Pripremam izvještaj kartice partnera!", IsCancellingEnabled = false, AutoIncrementInterval = 150 }.RunWorkerThread(1, new DoWorkEventHandler(this.CountUntilCancelled));
        }

        private void BackgroundUpdateLand()
        {
            new ProgressDialog { WindowStartupLocation = WindowStartupLocation.CenterScreen, DialogText = "Pripremam izvještaj kartice partnera!", IsCancellingEnabled = false, AutoIncrementInterval = 150 }.RunWorkerThread(1, new DoWorkEventHandler(this.CountUntilCancelledLand));
        }

        private void cmboIDdok_BeforeDropDown(object sender, CancelEventArgs e)
        {
            DataRowCollection rows = this.DokumentDataSet1.DOKUMENT.Rows;
            DOKUMENTDataAdapter adapter = new DOKUMENTDataAdapter();
            if (rows.Count == 0)
            {
                adapter.Fill(this.DokumentDataSet1);
            }
            rows = null;
        }

        private void cmboIDkontopocetni_BeforeDropDown(object sender, CancelEventArgs e)
        {
            if (this.KontoDataSet1.KONTO.Rows.Count == 0)
            {
                new KONTODataAdapter().Fill(this.KontoDataSet1);
            }
        }

        private void cmboIDkontozavrsni_BeforeDropDown(object sender, CancelEventArgs e)
        {
            if (this.KontoDataSet1.KONTO.Rows.Count == 0)
            {
                new KONTODataAdapter().Fill(this.KontoDataSet1);
            }
        }

        private void cmboIDMT_BeforeDropDown(object sender, CancelEventArgs e)
        {
            if (this.MjestotroskaDataSet1.MJESTOTROSKA.Rows.Count == 0)
            {
                new MJESTOTROSKADataAdapter().Fill(this.MjestotroskaDataSet1);
            }
        }

        private void cmboIDOJ_BeforeDropDown(object sender, CancelEventArgs e)
        {
            DataRowCollection rows = this.OrgjedDataSet1.ORGJED.Rows;
            ORGJEDDataAdapter adapter = new ORGJEDDataAdapter();
            if (rows.Count == 0)
            {
                adapter.Fill(this.OrgjedDataSet1);
            }
            rows = null;
        }

        private void cmboIDPartner_BeforeDropDown(object sender, CancelEventArgs e)
        {
            try
            {
                PartnerDataSet1.PARTNER.Clear();
                PARTNERDataAdapter.prikaz_ucenika = cbkPartnerUcenik.Checked;
                new PARTNERDataAdapter().Fill(this.PartnerDataSet1);
            }
            catch { }
        }

        private void CountUntilCancelled(object sender, DoWorkEventArgs e)
        {
            S_FIN_KARTICEPARTNERADataAdapter adapter = new S_FIN_KARTICEPARTNERADataAdapter();
            S_FIN_KARTICEPARTNERADataSet dataSet = new S_FIN_KARTICEPARTNERADataSet();
            try
            {
                int num = 0;
                int num2 = 0;
                int num3 = 0;
                int num4 = 0;
                int num5 = 0;
                string str = string.Empty;
                string str3 = string.Empty;
                if (this.cmboIDOJ.SelectedRow != null)
                {
                    num5 = Conversions.ToInteger(this.cmboIDOJ.Value);
                }
                else
                {
                    num5 = -1;
                }
                if (this.cmboIDMT.SelectedRow == null)
                {
                    num4 = -1;
                }
                else
                {
                    num4 = Conversions.ToInteger(this.cmboIDMT.Value);
                }
                if (this.cmboIDdok.SelectedRow == null)
                {
                    num = -1;
                }
                else
                {
                    num = Conversions.ToInteger(this.cmboIDdok.Value);
                }
                DateTime rAZDOBLJEOD = Conversions.ToDate(this.datumod.Value);
                DateTime rAZDOBLJEDO = Conversions.ToDate(this.datumdo.Value);
                if (this.cmboIDkontopocetni.SelectedRow != null)
                {
                    str = Conversions.ToString(this.cmboIDkontopocetni.Value);
                }
                else
                {
                    str = " ";
                }
                if (this.cmboIDkontozavrsni.SelectedRow != null)
                {
                    str3 = Conversions.ToString(this.cmboIDkontozavrsni.Value);
                }
                else
                {
                    str3 = " ";
                }
                if (this.cmboPartnerAktivnost.SelectedRow != null)
                {
                    num2 = Conversions.ToInteger(this.cmboPartnerAktivnost.Value);
                }
                else
                {
                    num2 = -1;
                }
                if (this.cmboIDPartner.SelectedRow == null)
                {
                    num3 = -1;
                }
                else
                {
                    num3 = Conversions.ToInteger(this.cmboIDPartner.Value.ToString().Remove(0, this.cmboIDPartner.Value.ToString().LastIndexOf("|") + 1).Trim());
                }
                try
                {
                    string str2 = string.Empty;
                    if (this.CheckBox2.Checked)
                    {
                        str2 = "S";
                    }
                    else
                    {
                        str2 = "N";
                    }
                    adapter.Fill(dataSet, num5, num4, num, rAZDOBLJEOD, rAZDOBLJEDO, str, str3, num2, num3, str2);
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                }
                this.rpt = new ReportDocument();
                this.rpt.Load(System.Windows.Forms.Application.StartupPath + @"\FinposIzvjestaji\rptKarticePartnera.rpt");
                if (this.CheckBox1.Checked)
                {
                    this.rpt.ReportDefinition.Sections[4].SectionFormat.EnableNewPageAfter = true;
                }
                else
                {
                    this.rpt.ReportDefinition.Sections[4].SectionFormat.EnableNewPageAfter = false;
                }
                this.rpt.SetDataSource(dataSet);
                this.rpt.SetParameterValue("NASLOV", "Kartice poslovnih partnera za razdoblje od:" + Conversions.ToString(this.datumod.Value) + "-" + Conversions.ToString(this.datumdo.Value));
                mipsed.application.framework.Application.PostaviParametreIzvjestaja(ref this.rpt);
            }
            catch (System.Exception exception3)
            {
                throw exception3;
                
            }
        }

        private void CountUntilCancelledLand(object sender, DoWorkEventArgs e)
        {
            S_FIN_KARTICEPARTNERADataAdapter adapter = new S_FIN_KARTICEPARTNERADataAdapter();
            S_FIN_KARTICEPARTNERADataSet dataSet = new S_FIN_KARTICEPARTNERADataSet();
            try
            {
                int num = 0;
                int num2 = 0;
                int num3 = 0;
                int num4 = 0;
                int num5 = 0;
                string str = string.Empty;
                string str3 = string.Empty;
                if (this.cmboIDOJ.SelectedRow != null)
                {
                    num5 = Conversions.ToInteger(this.cmboIDOJ.Value);
                }
                else
                {
                    num5 = -1;
                }
                if (this.cmboIDMT.SelectedRow == null)
                {
                    num4 = -1;
                }
                else
                {
                    num4 = Conversions.ToInteger(this.cmboIDMT.Value);
                }
                if (this.cmboIDdok.SelectedRow == null)
                {
                    num = -1;
                }
                else
                {
                    num = Conversions.ToInteger(this.cmboIDdok.Value);
                }
                DateTime rAZDOBLJEOD = Conversions.ToDate(this.datumod.Value);
                DateTime rAZDOBLJEDO = Conversions.ToDate(this.datumdo.Value);
                if (this.cmboIDkontopocetni.SelectedRow != null)
                {
                    str = Conversions.ToString(this.cmboIDkontopocetni.Value);
                }
                else
                {
                    str = " ";
                }
                if (this.cmboIDkontozavrsni.SelectedRow != null)
                {
                    str3 = Conversions.ToString(this.cmboIDkontozavrsni.Value);
                }
                else
                {
                    str3 = " ";
                }
                if (this.cmboPartnerAktivnost.SelectedRow != null)
                {
                    num2 = Conversions.ToInteger(this.cmboPartnerAktivnost.Value);
                }
                else
                {
                    num2 = -1;
                }
                if (this.cmboIDPartner.SelectedRow == null)
                {
                    num3 = -1;
                }
                else
                {
                    num3 = Conversions.ToInteger(this.cmboIDPartner.Value.ToString().Remove(0, this.cmboIDPartner.Value.ToString().LastIndexOf("|") + 1).Trim());
                }
                try
                {
                    string str2 = string.Empty;
                    if (this.CheckBox2.Checked)
                    {
                        str2 = "S";
                    }
                    else
                    {
                        str2 = "N";
                    }
                    adapter.Fill(dataSet, num5, num4, num, rAZDOBLJEOD, rAZDOBLJEDO, str, str3, num2, num3, str2);
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                }
                this.rpt = new ReportDocument();
                this.rpt.Load(System.Windows.Forms.Application.StartupPath + @"\FinposIzvjestaji\rptKarticePartneraLand.rpt");
                if (this.CheckBox1.Checked)
                {
                    this.rpt.ReportDefinition.Sections[4].SectionFormat.EnableNewPageAfter = true;
                }
                else
                {
                    this.rpt.ReportDefinition.Sections[4].SectionFormat.EnableNewPageAfter = false;
                }
                this.rpt.SetDataSource(dataSet);
                this.rpt.SetParameterValue("NASLOV", "Kartice poslovnih partnera za razdoblje od:" + Conversions.ToString(this.datumod.Value) + "-" + Conversions.ToString(this.datumdo.Value));
                mipsed.application.framework.Application.PostaviParametreIzvjestaja(ref this.rpt);
            }
            catch (System.Exception exception3)
            {
                throw exception3;

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

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("PARTNER", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPARTNER");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVPARTNER");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MB");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNERMJESTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNERULICA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNEREMAIL");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNEROIB");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNERFAX");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNERTELEFON");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNERZIRO1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNERZIRO2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNER_PARTNERZADUZENJE");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("PARTNER_PARTNERZADUZENJE", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPARTNER");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDZADUZENJE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPROIZVOD");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVPROIZVOD");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CIJENA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KOLICINAZADUZENJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CIJENAZADUZENJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IZNOSZADUZENJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RABATZADUZENJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IZNOSRABATAZADUZENJE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CIJENAZAFAKTURU");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UGOVORBROJ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMUGOVORA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AKTIVNO");
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton2 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("AKTIVNOST", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAKTIVNOST");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVAKTIVNOST");
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton3 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand4 = new Infragistics.Win.UltraWinGrid.UltraGridBand("DOKUMENT", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDDOKUMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVDOKUMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn32 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDTIPDOKUMENTA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn33 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVTIPDOKUMENTA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn34 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PS");
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton4 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand5 = new Infragistics.Win.UltraWinGrid.UltraGridBand("KONTO", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn35 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn36 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVKONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn37 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAKTIVNOST");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn38 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVAKTIVNOST");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn39 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KONT");
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton5 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand6 = new Infragistics.Win.UltraWinGrid.UltraGridBand("KONTO", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn40 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn41 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVKONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn42 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAKTIVNOST");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn43 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVAKTIVNOST");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn44 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KONT");
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton6 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand7 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ORGJED", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn45 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDORGJED");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn46 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVORGJED");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn47 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("oj");
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton7 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand8 = new Infragistics.Win.UltraWinGrid.UltraGridBand("MJESTOTROSKA", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn48 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDMJESTOTROSKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn49 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVMJESTOTROSKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn50 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("mt");
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedTop, new System.Guid("c7bdb6aa-cda2-4f73-beb6-d7b6fb7aa102"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("21d38f17-d77f-48b5-849c-0c27dd8ca281"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("c7bdb6aa-cda2-4f73-beb6-d7b6fb7aa102"), -1);
            this.UltraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.cmboIDPartner = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.PartnerDataSet1 = new Placa.PARTNERDataSet();
            this.cmboPartnerAktivnost = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.AktivnostDataSet1 = new Placa.AKTIVNOSTDataSet();
            this.cmboIDdok = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.DokumentDataSet1 = new Placa.DOKUMENTDataSet();
            this.cmboIDkontozavrsni = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.KontoDataSet1 = new Placa.KONTODataSet();
            this.cmboIDkontopocetni = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.cmboIDOJ = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.OrgjedDataSet1 = new Placa.ORGJEDDataSet();
            this.cmboIDMT = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.MjestotroskaDataSet1 = new Placa.MJESTOTROSKADataSet();
            this.datumdo = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.datumod = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.CheckBox1 = new System.Windows.Forms.CheckBox();
            this.CheckBox2 = new System.Windows.Forms.CheckBox();
            this.ErrorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.UltraDockManager1 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._frmKARTICEPARTNERAUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._frmKARTICEPARTNERAUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._frmKARTICEPARTNERAUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._frmKARTICEPARTNERAUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._frmKARTICEPARTNERAAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.DockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.WindowDockingArea2 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.DockableWindow3 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.ctlReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.cbkPartnerUcenik = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).BeginInit();
            this.UltraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmboIDPartner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartnerDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboPartnerAktivnost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AktivnostDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboIDdok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DokumentDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboIDkontozavrsni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KontoDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboIDkontopocetni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboIDOJ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrgjedDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboIDMT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MjestotroskaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datumdo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datumod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).BeginInit();
            this.WindowDockingArea2.SuspendLayout();
            this.DockableWindow3.SuspendLayout();
            this.SuspendLayout();
            // 
            // UltraGroupBox1
            // 
            this.UltraGroupBox1.Controls.Add(this.cbkPartnerUcenik);
            this.UltraGroupBox1.Controls.Add(this.cmboIDPartner);
            this.UltraGroupBox1.Controls.Add(this.cmboPartnerAktivnost);
            this.UltraGroupBox1.Controls.Add(this.cmboIDdok);
            this.UltraGroupBox1.Controls.Add(this.cmboIDkontozavrsni);
            this.UltraGroupBox1.Controls.Add(this.cmboIDkontopocetni);
            this.UltraGroupBox1.Controls.Add(this.cmboIDOJ);
            this.UltraGroupBox1.Controls.Add(this.cmboIDMT);
            this.UltraGroupBox1.Controls.Add(this.datumdo);
            this.UltraGroupBox1.Controls.Add(this.datumod);
            this.UltraGroupBox1.Controls.Add(this.Label5);
            this.UltraGroupBox1.Controls.Add(this.Label6);
            this.UltraGroupBox1.Controls.Add(this.Label1);
            this.UltraGroupBox1.Controls.Add(this.Label2);
            this.UltraGroupBox1.Controls.Add(this.Label3);
            this.UltraGroupBox1.Controls.Add(this.Label4);
            this.UltraGroupBox1.Controls.Add(this.Label7);
            this.UltraGroupBox1.Controls.Add(this.Label8);
            this.UltraGroupBox1.Controls.Add(this.Label9);
            this.UltraGroupBox1.Controls.Add(this.CheckBox1);
            this.UltraGroupBox1.Controls.Add(this.CheckBox2);
            this.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraGroupBox1.Location = new System.Drawing.Point(0, 18);
            this.UltraGroupBox1.Name = "UltraGroupBox1";
            this.UltraGroupBox1.Size = new System.Drawing.Size(792, 272);
            this.UltraGroupBox1.TabIndex = 0;
            this.UltraGroupBox1.Text = "Odabir podataka";
            this.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            this.UltraGroupBox1.Click += new System.EventHandler(this.UltraGroupBox1_Click);
            // 
            // cmboIDPartner
            // 
            this.cmboIDPartner.AllowNull = Infragistics.Win.DefaultableBoolean.True;
            this.cmboIDPartner.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            appearance31.TextHAlignAsString = "Center";
            editorButton1.Appearance = appearance31;
            editorButton1.Text = "...";
            this.cmboIDPartner.ButtonsRight.Add(editorButton1);
            this.cmboIDPartner.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmboIDPartner.DataMember = "PARTNER";
            this.cmboIDPartner.DataSource = this.PartnerDataSet1;
            appearance42.BackColor = System.Drawing.SystemColors.Window;
            appearance42.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmboIDPartner.DisplayLayout.Appearance = appearance42;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Width = 75;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 250;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.Header.Caption = "Porezni broj";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Width = 100;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.Header.VisiblePosition = 4;
            ultraGridColumn4.Width = 150;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.Header.VisiblePosition = 6;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.Header.VisiblePosition = 7;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.Header.VisiblePosition = 3;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn10.Header.VisiblePosition = 9;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn11.Header.VisiblePosition = 10;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn12.Header.VisiblePosition = 11;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn13.Header.VisiblePosition = 12;
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
            ultraGridColumn13});
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn14.Header.VisiblePosition = 0;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn15.Header.VisiblePosition = 1;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn16.Header.VisiblePosition = 2;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn17.Header.VisiblePosition = 3;
            ultraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn18.Header.VisiblePosition = 4;
            ultraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn19.Header.VisiblePosition = 5;
            ultraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn20.Header.VisiblePosition = 6;
            ultraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn21.Header.VisiblePosition = 7;
            ultraGridColumn22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn22.Header.VisiblePosition = 8;
            ultraGridColumn23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn23.Header.VisiblePosition = 9;
            ultraGridColumn24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn24.Header.VisiblePosition = 10;
            ultraGridColumn25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn25.Header.VisiblePosition = 11;
            ultraGridColumn26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn26.Header.VisiblePosition = 12;
            ultraGridColumn27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn27.Header.VisiblePosition = 13;
            ultraGridBand2.Columns.AddRange(new object[] {
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
            ultraGridColumn26,
            ultraGridColumn27});
            this.cmboIDPartner.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.cmboIDPartner.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.cmboIDPartner.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmboIDPartner.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance53.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance53.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance53.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance53.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDPartner.DisplayLayout.GroupByBox.Appearance = appearance53;
            appearance64.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDPartner.DisplayLayout.GroupByBox.BandLabelAppearance = appearance64;
            this.cmboIDPartner.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance75.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance75.BackColor2 = System.Drawing.SystemColors.Control;
            appearance75.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance75.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDPartner.DisplayLayout.GroupByBox.PromptAppearance = appearance75;
            this.cmboIDPartner.DisplayLayout.MaxColScrollRegions = 1;
            this.cmboIDPartner.DisplayLayout.MaxRowScrollRegions = 1;
            appearance86.BackColor = System.Drawing.SystemColors.Window;
            appearance86.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmboIDPartner.DisplayLayout.Override.ActiveCellAppearance = appearance86;
            appearance.BackColor = System.Drawing.SystemColors.Highlight;
            appearance.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cmboIDPartner.DisplayLayout.Override.ActiveRowAppearance = appearance;
            this.cmboIDPartner.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cmboIDPartner.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            this.cmboIDPartner.DisplayLayout.Override.CardAreaAppearance = appearance2;
            appearance3.BorderColor = System.Drawing.Color.Silver;
            appearance3.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cmboIDPartner.DisplayLayout.Override.CellAppearance = appearance3;
            this.cmboIDPartner.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.cmboIDPartner.DisplayLayout.Override.CellPadding = 0;
            appearance4.BackColor = System.Drawing.SystemColors.Control;
            appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance4.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDPartner.DisplayLayout.Override.GroupByRowAppearance = appearance4;
            appearance5.TextHAlignAsString = "Left";
            this.cmboIDPartner.DisplayLayout.Override.HeaderAppearance = appearance5;
            this.cmboIDPartner.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cmboIDPartner.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.BorderColor = System.Drawing.Color.Silver;
            this.cmboIDPartner.DisplayLayout.Override.RowAppearance = appearance6;
            this.cmboIDPartner.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmboIDPartner.DisplayLayout.Override.TemplateAddRowAppearance = appearance7;
            this.cmboIDPartner.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cmboIDPartner.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cmboIDPartner.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cmboIDPartner.DisplayMember = "NAZIVPARTNER";
            this.cmboIDPartner.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmboIDPartner.Location = new System.Drawing.Point(144, 20);
            this.cmboIDPartner.Name = "cmboIDPartner";
            this.cmboIDPartner.Size = new System.Drawing.Size(500, 22);
            this.cmboIDPartner.TabIndex = 1;
            this.cmboIDPartner.ValueMember = "PT";
            this.cmboIDPartner.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cmboIDPartner_BeforeDropDown);
            // 
            // PartnerDataSet1
            // 
            this.PartnerDataSet1.DataSetName = "PARTNERDataSet";
            this.PartnerDataSet1.Locale = new System.Globalization.CultureInfo("hr-HR");
            // 
            // cmboPartnerAktivnost
            // 
            this.cmboPartnerAktivnost.AllowNull = Infragistics.Win.DefaultableBoolean.True;
            appearance8.TextHAlignAsString = "Center";
            editorButton2.Appearance = appearance8;
            editorButton2.Text = "...";
            this.cmboPartnerAktivnost.ButtonsRight.Add(editorButton2);
            this.cmboPartnerAktivnost.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmboPartnerAktivnost.DataMember = "AKTIVNOST";
            this.cmboPartnerAktivnost.DataSource = this.AktivnostDataSet1;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            appearance9.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmboPartnerAktivnost.DisplayLayout.Appearance = appearance9;
            ultraGridColumn28.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn28.Header.Caption = "Šifra";
            ultraGridColumn28.Header.VisiblePosition = 0;
            ultraGridColumn28.Width = 65;
            ultraGridColumn29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn29.Header.VisiblePosition = 1;
            ultraGridColumn29.Width = 200;
            ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn28,
            ultraGridColumn29});
            this.cmboPartnerAktivnost.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
            this.cmboPartnerAktivnost.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmboPartnerAktivnost.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance10.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboPartnerAktivnost.DisplayLayout.GroupByBox.Appearance = appearance10;
            appearance11.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboPartnerAktivnost.DisplayLayout.GroupByBox.BandLabelAppearance = appearance11;
            this.cmboPartnerAktivnost.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance12.BackColor2 = System.Drawing.SystemColors.Control;
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance12.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboPartnerAktivnost.DisplayLayout.GroupByBox.PromptAppearance = appearance12;
            this.cmboPartnerAktivnost.DisplayLayout.MaxColScrollRegions = 1;
            this.cmboPartnerAktivnost.DisplayLayout.MaxRowScrollRegions = 1;
            appearance13.BackColor = System.Drawing.SystemColors.Window;
            appearance13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmboPartnerAktivnost.DisplayLayout.Override.ActiveCellAppearance = appearance13;
            appearance14.BackColor = System.Drawing.SystemColors.Highlight;
            appearance14.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cmboPartnerAktivnost.DisplayLayout.Override.ActiveRowAppearance = appearance14;
            this.cmboPartnerAktivnost.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cmboPartnerAktivnost.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance15.BackColor = System.Drawing.SystemColors.Window;
            this.cmboPartnerAktivnost.DisplayLayout.Override.CardAreaAppearance = appearance15;
            appearance16.BorderColor = System.Drawing.Color.Silver;
            appearance16.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cmboPartnerAktivnost.DisplayLayout.Override.CellAppearance = appearance16;
            this.cmboPartnerAktivnost.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.cmboPartnerAktivnost.DisplayLayout.Override.CellPadding = 0;
            appearance17.BackColor = System.Drawing.SystemColors.Control;
            appearance17.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance17.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance17.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboPartnerAktivnost.DisplayLayout.Override.GroupByRowAppearance = appearance17;
            appearance18.TextHAlignAsString = "Left";
            this.cmboPartnerAktivnost.DisplayLayout.Override.HeaderAppearance = appearance18;
            this.cmboPartnerAktivnost.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cmboPartnerAktivnost.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance19.BackColor = System.Drawing.SystemColors.Window;
            appearance19.BorderColor = System.Drawing.Color.Silver;
            this.cmboPartnerAktivnost.DisplayLayout.Override.RowAppearance = appearance19;
            this.cmboPartnerAktivnost.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance20.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmboPartnerAktivnost.DisplayLayout.Override.TemplateAddRowAppearance = appearance20;
            this.cmboPartnerAktivnost.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cmboPartnerAktivnost.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cmboPartnerAktivnost.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cmboPartnerAktivnost.DisplayMember = "NAZIVAKTIVNOST";
            this.cmboPartnerAktivnost.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmboPartnerAktivnost.Location = new System.Drawing.Point(144, 44);
            this.cmboPartnerAktivnost.Name = "cmboPartnerAktivnost";
            this.cmboPartnerAktivnost.Size = new System.Drawing.Size(149, 22);
            this.cmboPartnerAktivnost.TabIndex = 3;
            this.cmboPartnerAktivnost.ValueMember = "IDAKTIVNOST";
            this.cmboPartnerAktivnost.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cmboPartnerAktivnost_BeforeDropDown);
            // 
            // AktivnostDataSet1
            // 
            this.AktivnostDataSet1.DataSetName = "AKTIVNOSTDataSet";
            this.AktivnostDataSet1.Locale = new System.Globalization.CultureInfo("hr-HR");
            // 
            // cmboIDdok
            // 
            this.cmboIDdok.AllowNull = Infragistics.Win.DefaultableBoolean.True;
            appearance21.TextHAlignAsString = "Center";
            editorButton3.Appearance = appearance21;
            editorButton3.Text = "...";
            this.cmboIDdok.ButtonsRight.Add(editorButton3);
            this.cmboIDdok.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmboIDdok.DataMember = "DOKUMENT";
            this.cmboIDdok.DataSource = this.DokumentDataSet1;
            appearance22.BackColor = System.Drawing.SystemColors.Window;
            appearance22.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmboIDdok.DisplayLayout.Appearance = appearance22;
            ultraGridColumn30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn30.Header.VisiblePosition = 0;
            ultraGridColumn30.Width = 65;
            ultraGridColumn31.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn31.Header.VisiblePosition = 1;
            ultraGridColumn31.Width = 150;
            ultraGridColumn32.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn32.Header.VisiblePosition = 2;
            ultraGridColumn33.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn33.Header.VisiblePosition = 3;
            ultraGridColumn34.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn34.Header.VisiblePosition = 4;
            ultraGridBand4.Columns.AddRange(new object[] {
            ultraGridColumn30,
            ultraGridColumn31,
            ultraGridColumn32,
            ultraGridColumn33,
            ultraGridColumn34});
            this.cmboIDdok.DisplayLayout.BandsSerializer.Add(ultraGridBand4);
            this.cmboIDdok.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmboIDdok.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance23.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance23.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance23.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDdok.DisplayLayout.GroupByBox.Appearance = appearance23;
            appearance24.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDdok.DisplayLayout.GroupByBox.BandLabelAppearance = appearance24;
            this.cmboIDdok.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance25.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance25.BackColor2 = System.Drawing.SystemColors.Control;
            appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance25.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDdok.DisplayLayout.GroupByBox.PromptAppearance = appearance25;
            this.cmboIDdok.DisplayLayout.MaxColScrollRegions = 1;
            this.cmboIDdok.DisplayLayout.MaxRowScrollRegions = 1;
            appearance26.BackColor = System.Drawing.SystemColors.Window;
            appearance26.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmboIDdok.DisplayLayout.Override.ActiveCellAppearance = appearance26;
            appearance27.BackColor = System.Drawing.SystemColors.Highlight;
            appearance27.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cmboIDdok.DisplayLayout.Override.ActiveRowAppearance = appearance27;
            this.cmboIDdok.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cmboIDdok.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance28.BackColor = System.Drawing.SystemColors.Window;
            this.cmboIDdok.DisplayLayout.Override.CardAreaAppearance = appearance28;
            appearance29.BorderColor = System.Drawing.Color.Silver;
            appearance29.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cmboIDdok.DisplayLayout.Override.CellAppearance = appearance29;
            this.cmboIDdok.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.cmboIDdok.DisplayLayout.Override.CellPadding = 0;
            appearance30.BackColor = System.Drawing.SystemColors.Control;
            appearance30.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance30.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance30.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance30.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDdok.DisplayLayout.Override.GroupByRowAppearance = appearance30;
            appearance32.TextHAlignAsString = "Left";
            this.cmboIDdok.DisplayLayout.Override.HeaderAppearance = appearance32;
            this.cmboIDdok.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cmboIDdok.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance33.BackColor = System.Drawing.SystemColors.Window;
            appearance33.BorderColor = System.Drawing.Color.Silver;
            this.cmboIDdok.DisplayLayout.Override.RowAppearance = appearance33;
            this.cmboIDdok.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance34.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmboIDdok.DisplayLayout.Override.TemplateAddRowAppearance = appearance34;
            this.cmboIDdok.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cmboIDdok.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cmboIDdok.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cmboIDdok.DisplayMember = "NAZIVDOKUMENT";
            this.cmboIDdok.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmboIDdok.Location = new System.Drawing.Point(144, 118);
            this.cmboIDdok.Name = "cmboIDdok";
            this.cmboIDdok.Size = new System.Drawing.Size(149, 22);
            this.cmboIDdok.TabIndex = 9;
            this.cmboIDdok.ValueMember = "IDDOKUMENT";
            this.cmboIDdok.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cmboIDdok_BeforeDropDown);
            // 
            // DokumentDataSet1
            // 
            this.DokumentDataSet1.DataSetName = "DOKUMENTDataSet";
            this.DokumentDataSet1.Locale = new System.Globalization.CultureInfo("hr-HR");
            // 
            // cmboIDkontozavrsni
            // 
            this.cmboIDkontozavrsni.AllowNull = Infragistics.Win.DefaultableBoolean.True;
            appearance35.TextHAlignAsString = "Center";
            editorButton4.Appearance = appearance35;
            editorButton4.Text = "...";
            this.cmboIDkontozavrsni.ButtonsRight.Add(editorButton4);
            this.cmboIDkontozavrsni.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmboIDkontozavrsni.DataMember = "KONTO";
            this.cmboIDkontozavrsni.DataSource = this.KontoDataSet1;
            appearance36.BackColor = System.Drawing.SystemColors.Window;
            appearance36.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmboIDkontozavrsni.DisplayLayout.Appearance = appearance36;
            ultraGridColumn35.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn35.Header.VisiblePosition = 0;
            ultraGridColumn35.Width = 65;
            ultraGridColumn36.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn36.Header.VisiblePosition = 1;
            ultraGridColumn36.Width = 200;
            ultraGridColumn37.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn37.Header.VisiblePosition = 2;
            ultraGridColumn37.Width = 65;
            ultraGridColumn38.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn38.Header.VisiblePosition = 3;
            ultraGridColumn38.Width = 100;
            ultraGridColumn39.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn39.Header.VisiblePosition = 4;
            ultraGridBand5.Columns.AddRange(new object[] {
            ultraGridColumn35,
            ultraGridColumn36,
            ultraGridColumn37,
            ultraGridColumn38,
            ultraGridColumn39});
            this.cmboIDkontozavrsni.DisplayLayout.BandsSerializer.Add(ultraGridBand5);
            this.cmboIDkontozavrsni.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmboIDkontozavrsni.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance37.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance37.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance37.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance37.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDkontozavrsni.DisplayLayout.GroupByBox.Appearance = appearance37;
            appearance38.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDkontozavrsni.DisplayLayout.GroupByBox.BandLabelAppearance = appearance38;
            this.cmboIDkontozavrsni.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance39.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance39.BackColor2 = System.Drawing.SystemColors.Control;
            appearance39.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance39.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDkontozavrsni.DisplayLayout.GroupByBox.PromptAppearance = appearance39;
            this.cmboIDkontozavrsni.DisplayLayout.MaxColScrollRegions = 1;
            this.cmboIDkontozavrsni.DisplayLayout.MaxRowScrollRegions = 1;
            appearance40.BackColor = System.Drawing.SystemColors.Window;
            appearance40.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmboIDkontozavrsni.DisplayLayout.Override.ActiveCellAppearance = appearance40;
            appearance41.BackColor = System.Drawing.SystemColors.Highlight;
            appearance41.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cmboIDkontozavrsni.DisplayLayout.Override.ActiveRowAppearance = appearance41;
            this.cmboIDkontozavrsni.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cmboIDkontozavrsni.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance43.BackColor = System.Drawing.SystemColors.Window;
            this.cmboIDkontozavrsni.DisplayLayout.Override.CardAreaAppearance = appearance43;
            appearance44.BorderColor = System.Drawing.Color.Silver;
            appearance44.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cmboIDkontozavrsni.DisplayLayout.Override.CellAppearance = appearance44;
            this.cmboIDkontozavrsni.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.cmboIDkontozavrsni.DisplayLayout.Override.CellPadding = 0;
            appearance45.BackColor = System.Drawing.SystemColors.Control;
            appearance45.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance45.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance45.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance45.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDkontozavrsni.DisplayLayout.Override.GroupByRowAppearance = appearance45;
            appearance46.TextHAlignAsString = "Left";
            this.cmboIDkontozavrsni.DisplayLayout.Override.HeaderAppearance = appearance46;
            this.cmboIDkontozavrsni.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cmboIDkontozavrsni.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance47.BackColor = System.Drawing.SystemColors.Window;
            appearance47.BorderColor = System.Drawing.Color.Silver;
            this.cmboIDkontozavrsni.DisplayLayout.Override.RowAppearance = appearance47;
            this.cmboIDkontozavrsni.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance48.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmboIDkontozavrsni.DisplayLayout.Override.TemplateAddRowAppearance = appearance48;
            this.cmboIDkontozavrsni.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cmboIDkontozavrsni.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cmboIDkontozavrsni.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cmboIDkontozavrsni.DisplayMember = "NAZIVKONTO";
            this.cmboIDkontozavrsni.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmboIDkontozavrsni.Location = new System.Drawing.Point(144, 168);
            this.cmboIDkontozavrsni.Name = "cmboIDkontozavrsni";
            this.cmboIDkontozavrsni.Size = new System.Drawing.Size(149, 22);
            this.cmboIDkontozavrsni.TabIndex = 13;
            this.cmboIDkontozavrsni.ValueMember = "IDKONTO";
            this.cmboIDkontozavrsni.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cmboIDkontozavrsni_BeforeDropDown);
            // 
            // KontoDataSet1
            // 
            this.KontoDataSet1.DataSetName = "KONTODataSet";
            this.KontoDataSet1.Locale = new System.Globalization.CultureInfo("hr-HR");
            // 
            // cmboIDkontopocetni
            // 
            this.cmboIDkontopocetni.AllowNull = Infragistics.Win.DefaultableBoolean.True;
            appearance49.TextHAlignAsString = "Center";
            editorButton5.Appearance = appearance49;
            editorButton5.Text = "...";
            this.cmboIDkontopocetni.ButtonsRight.Add(editorButton5);
            this.cmboIDkontopocetni.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmboIDkontopocetni.DataMember = "KONTO";
            this.cmboIDkontopocetni.DataSource = this.KontoDataSet1;
            appearance50.BackColor = System.Drawing.SystemColors.Window;
            appearance50.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmboIDkontopocetni.DisplayLayout.Appearance = appearance50;
            ultraGridColumn40.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn40.Header.VisiblePosition = 0;
            ultraGridColumn40.Width = 65;
            ultraGridColumn41.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn41.Header.VisiblePosition = 1;
            ultraGridColumn41.Width = 200;
            ultraGridColumn42.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn42.Header.VisiblePosition = 2;
            ultraGridColumn42.Width = 65;
            ultraGridColumn43.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn43.Header.VisiblePosition = 3;
            ultraGridColumn43.Width = 100;
            ultraGridColumn44.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn44.Header.VisiblePosition = 4;
            ultraGridBand6.Columns.AddRange(new object[] {
            ultraGridColumn40,
            ultraGridColumn41,
            ultraGridColumn42,
            ultraGridColumn43,
            ultraGridColumn44});
            this.cmboIDkontopocetni.DisplayLayout.BandsSerializer.Add(ultraGridBand6);
            this.cmboIDkontopocetni.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmboIDkontopocetni.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance51.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance51.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance51.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance51.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDkontopocetni.DisplayLayout.GroupByBox.Appearance = appearance51;
            appearance52.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDkontopocetni.DisplayLayout.GroupByBox.BandLabelAppearance = appearance52;
            this.cmboIDkontopocetni.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance54.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance54.BackColor2 = System.Drawing.SystemColors.Control;
            appearance54.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance54.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDkontopocetni.DisplayLayout.GroupByBox.PromptAppearance = appearance54;
            this.cmboIDkontopocetni.DisplayLayout.MaxColScrollRegions = 1;
            this.cmboIDkontopocetni.DisplayLayout.MaxRowScrollRegions = 1;
            appearance55.BackColor = System.Drawing.SystemColors.Window;
            appearance55.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmboIDkontopocetni.DisplayLayout.Override.ActiveCellAppearance = appearance55;
            appearance56.BackColor = System.Drawing.SystemColors.Highlight;
            appearance56.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cmboIDkontopocetni.DisplayLayout.Override.ActiveRowAppearance = appearance56;
            this.cmboIDkontopocetni.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cmboIDkontopocetni.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance57.BackColor = System.Drawing.SystemColors.Window;
            this.cmboIDkontopocetni.DisplayLayout.Override.CardAreaAppearance = appearance57;
            appearance58.BorderColor = System.Drawing.Color.Silver;
            appearance58.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cmboIDkontopocetni.DisplayLayout.Override.CellAppearance = appearance58;
            this.cmboIDkontopocetni.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.cmboIDkontopocetni.DisplayLayout.Override.CellPadding = 0;
            appearance59.BackColor = System.Drawing.SystemColors.Control;
            appearance59.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance59.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance59.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance59.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDkontopocetni.DisplayLayout.Override.GroupByRowAppearance = appearance59;
            appearance60.TextHAlignAsString = "Left";
            this.cmboIDkontopocetni.DisplayLayout.Override.HeaderAppearance = appearance60;
            this.cmboIDkontopocetni.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cmboIDkontopocetni.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance61.BackColor = System.Drawing.SystemColors.Window;
            appearance61.BorderColor = System.Drawing.Color.Silver;
            this.cmboIDkontopocetni.DisplayLayout.Override.RowAppearance = appearance61;
            this.cmboIDkontopocetni.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance62.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmboIDkontopocetni.DisplayLayout.Override.TemplateAddRowAppearance = appearance62;
            this.cmboIDkontopocetni.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cmboIDkontopocetni.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cmboIDkontopocetni.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cmboIDkontopocetni.DisplayMember = "NAZIVKONTO";
            this.cmboIDkontopocetni.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmboIDkontopocetni.Location = new System.Drawing.Point(144, 144);
            this.cmboIDkontopocetni.Name = "cmboIDkontopocetni";
            this.cmboIDkontopocetni.Size = new System.Drawing.Size(149, 22);
            this.cmboIDkontopocetni.TabIndex = 11;
            this.cmboIDkontopocetni.ValueMember = "IDKONTO";
            this.cmboIDkontopocetni.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cmboIDkontopocetni_BeforeDropDown);
            // 
            // cmboIDOJ
            // 
            this.cmboIDOJ.AllowNull = Infragistics.Win.DefaultableBoolean.True;
            appearance63.TextHAlignAsString = "Center";
            editorButton6.Appearance = appearance63;
            editorButton6.Text = "...";
            this.cmboIDOJ.ButtonsRight.Add(editorButton6);
            this.cmboIDOJ.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmboIDOJ.DataMember = "ORGJED";
            this.cmboIDOJ.DataSource = this.OrgjedDataSet1;
            appearance65.BackColor = System.Drawing.SystemColors.Window;
            appearance65.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmboIDOJ.DisplayLayout.Appearance = appearance65;
            ultraGridColumn45.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn45.Header.VisiblePosition = 0;
            ultraGridColumn45.Width = 65;
            ultraGridColumn46.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn46.Header.VisiblePosition = 1;
            ultraGridColumn46.Width = 150;
            ultraGridColumn47.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn47.Header.VisiblePosition = 2;
            ultraGridBand7.Columns.AddRange(new object[] {
            ultraGridColumn45,
            ultraGridColumn46,
            ultraGridColumn47});
            this.cmboIDOJ.DisplayLayout.BandsSerializer.Add(ultraGridBand7);
            this.cmboIDOJ.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmboIDOJ.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance66.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance66.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance66.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance66.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDOJ.DisplayLayout.GroupByBox.Appearance = appearance66;
            appearance67.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDOJ.DisplayLayout.GroupByBox.BandLabelAppearance = appearance67;
            this.cmboIDOJ.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance68.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance68.BackColor2 = System.Drawing.SystemColors.Control;
            appearance68.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance68.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDOJ.DisplayLayout.GroupByBox.PromptAppearance = appearance68;
            this.cmboIDOJ.DisplayLayout.MaxColScrollRegions = 1;
            this.cmboIDOJ.DisplayLayout.MaxRowScrollRegions = 1;
            appearance69.BackColor = System.Drawing.SystemColors.Window;
            appearance69.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmboIDOJ.DisplayLayout.Override.ActiveCellAppearance = appearance69;
            appearance70.BackColor = System.Drawing.SystemColors.Highlight;
            appearance70.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cmboIDOJ.DisplayLayout.Override.ActiveRowAppearance = appearance70;
            this.cmboIDOJ.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cmboIDOJ.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance71.BackColor = System.Drawing.SystemColors.Window;
            this.cmboIDOJ.DisplayLayout.Override.CardAreaAppearance = appearance71;
            appearance72.BorderColor = System.Drawing.Color.Silver;
            appearance72.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cmboIDOJ.DisplayLayout.Override.CellAppearance = appearance72;
            this.cmboIDOJ.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.cmboIDOJ.DisplayLayout.Override.CellPadding = 0;
            appearance73.BackColor = System.Drawing.SystemColors.Control;
            appearance73.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance73.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance73.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance73.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDOJ.DisplayLayout.Override.GroupByRowAppearance = appearance73;
            appearance74.TextHAlignAsString = "Left";
            this.cmboIDOJ.DisplayLayout.Override.HeaderAppearance = appearance74;
            this.cmboIDOJ.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cmboIDOJ.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance76.BackColor = System.Drawing.SystemColors.Window;
            appearance76.BorderColor = System.Drawing.Color.Silver;
            this.cmboIDOJ.DisplayLayout.Override.RowAppearance = appearance76;
            this.cmboIDOJ.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance77.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmboIDOJ.DisplayLayout.Override.TemplateAddRowAppearance = appearance77;
            this.cmboIDOJ.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cmboIDOJ.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cmboIDOJ.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cmboIDOJ.DisplayMember = "NAZIVORGJED";
            this.cmboIDOJ.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmboIDOJ.Location = new System.Drawing.Point(144, 70);
            this.cmboIDOJ.Name = "cmboIDOJ";
            this.cmboIDOJ.Size = new System.Drawing.Size(149, 22);
            this.cmboIDOJ.TabIndex = 5;
            this.cmboIDOJ.ValueMember = "IDORGJED";
            this.cmboIDOJ.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cmboIDOJ_BeforeDropDown);
            // 
            // OrgjedDataSet1
            // 
            this.OrgjedDataSet1.DataSetName = "ORGJEDDataSet";
            this.OrgjedDataSet1.Locale = new System.Globalization.CultureInfo("hr-HR");
            // 
            // cmboIDMT
            // 
            this.cmboIDMT.AllowNull = Infragistics.Win.DefaultableBoolean.True;
            appearance78.TextHAlignAsString = "Center";
            editorButton7.Appearance = appearance78;
            editorButton7.Text = "...";
            this.cmboIDMT.ButtonsRight.Add(editorButton7);
            this.cmboIDMT.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmboIDMT.DataMember = "MJESTOTROSKA";
            this.cmboIDMT.DataSource = this.MjestotroskaDataSet1;
            appearance79.BackColor = System.Drawing.SystemColors.Window;
            appearance79.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmboIDMT.DisplayLayout.Appearance = appearance79;
            ultraGridColumn48.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn48.Header.VisiblePosition = 0;
            ultraGridColumn48.Width = 65;
            ultraGridColumn49.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn49.Header.VisiblePosition = 1;
            ultraGridColumn49.Width = 150;
            ultraGridColumn50.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn50.Header.VisiblePosition = 2;
            ultraGridBand8.Columns.AddRange(new object[] {
            ultraGridColumn48,
            ultraGridColumn49,
            ultraGridColumn50});
            this.cmboIDMT.DisplayLayout.BandsSerializer.Add(ultraGridBand8);
            this.cmboIDMT.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmboIDMT.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance80.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance80.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance80.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance80.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDMT.DisplayLayout.GroupByBox.Appearance = appearance80;
            appearance81.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDMT.DisplayLayout.GroupByBox.BandLabelAppearance = appearance81;
            this.cmboIDMT.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance82.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance82.BackColor2 = System.Drawing.SystemColors.Control;
            appearance82.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance82.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDMT.DisplayLayout.GroupByBox.PromptAppearance = appearance82;
            this.cmboIDMT.DisplayLayout.MaxColScrollRegions = 1;
            this.cmboIDMT.DisplayLayout.MaxRowScrollRegions = 1;
            appearance83.BackColor = System.Drawing.SystemColors.Window;
            appearance83.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmboIDMT.DisplayLayout.Override.ActiveCellAppearance = appearance83;
            appearance84.BackColor = System.Drawing.SystemColors.Highlight;
            appearance84.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cmboIDMT.DisplayLayout.Override.ActiveRowAppearance = appearance84;
            this.cmboIDMT.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cmboIDMT.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance85.BackColor = System.Drawing.SystemColors.Window;
            this.cmboIDMT.DisplayLayout.Override.CardAreaAppearance = appearance85;
            appearance87.BorderColor = System.Drawing.Color.Silver;
            appearance87.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cmboIDMT.DisplayLayout.Override.CellAppearance = appearance87;
            this.cmboIDMT.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.cmboIDMT.DisplayLayout.Override.CellPadding = 0;
            appearance88.BackColor = System.Drawing.SystemColors.Control;
            appearance88.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance88.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance88.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance88.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDMT.DisplayLayout.Override.GroupByRowAppearance = appearance88;
            appearance89.TextHAlignAsString = "Left";
            this.cmboIDMT.DisplayLayout.Override.HeaderAppearance = appearance89;
            this.cmboIDMT.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cmboIDMT.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance90.BackColor = System.Drawing.SystemColors.Window;
            appearance90.BorderColor = System.Drawing.Color.Silver;
            this.cmboIDMT.DisplayLayout.Override.RowAppearance = appearance90;
            this.cmboIDMT.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance91.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmboIDMT.DisplayLayout.Override.TemplateAddRowAppearance = appearance91;
            this.cmboIDMT.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cmboIDMT.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cmboIDMT.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cmboIDMT.DisplayMember = "IDMJESTOTROSKA";
            this.cmboIDMT.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmboIDMT.Location = new System.Drawing.Point(144, 94);
            this.cmboIDMT.Name = "cmboIDMT";
            this.cmboIDMT.Size = new System.Drawing.Size(149, 22);
            this.cmboIDMT.TabIndex = 7;
            this.cmboIDMT.ValueMember = "IDMJESTOTROSKA";
            this.cmboIDMT.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cmboIDMT_BeforeDropDown);
            // 
            // MjestotroskaDataSet1
            // 
            this.MjestotroskaDataSet1.DataSetName = "MJESTOTROSKADataSet";
            this.MjestotroskaDataSet1.Locale = new System.Globalization.CultureInfo("hr-HR");
            // 
            // datumdo
            // 
            this.datumdo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.datumdo.Location = new System.Drawing.Point(144, 218);
            this.datumdo.Name = "datumdo";
            this.datumdo.PromptChar = ' ';
            this.datumdo.Size = new System.Drawing.Size(149, 21);
            this.datumdo.TabIndex = 17;
            // 
            // datumod
            // 
            this.datumod.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.datumod.Location = new System.Drawing.Point(144, 194);
            this.datumod.Name = "datumod";
            this.datumod.PromptChar = ' ';
            this.datumod.Size = new System.Drawing.Size(149, 21);
            this.datumod.TabIndex = 15;
            // 
            // Label5
            // 
            this.Label5.BackColor = System.Drawing.Color.Transparent;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label5.Location = new System.Drawing.Point(8, 70);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(119, 27);
            this.Label5.TabIndex = 4;
            this.Label5.Text = "Organizacijska jedinica:";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label6
            // 
            this.Label6.BackColor = System.Drawing.Color.Transparent;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label6.Location = new System.Drawing.Point(8, 94);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(119, 22);
            this.Label6.TabIndex = 6;
            this.Label6.Text = "Mjesto troška:";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label1.Location = new System.Drawing.Point(8, 118);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(119, 22);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "Vrsta dokumenta:";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label2.Location = new System.Drawing.Point(8, 144);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(119, 22);
            this.Label2.TabIndex = 10;
            this.Label2.Text = "Od konta:";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label3.Location = new System.Drawing.Point(8, 168);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(119, 22);
            this.Label3.TabIndex = 12;
            this.Label3.Text = "Do konta:";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label4.Location = new System.Drawing.Point(8, 194);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(119, 21);
            this.Label4.TabIndex = 14;
            this.Label4.Text = "Od datuma:";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label7
            // 
            this.Label7.BackColor = System.Drawing.Color.Transparent;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label7.Location = new System.Drawing.Point(8, 218);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(119, 21);
            this.Label7.TabIndex = 16;
            this.Label7.Text = "Do datuma:";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label8
            // 
            this.Label8.BackColor = System.Drawing.Color.Transparent;
            this.Label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label8.Location = new System.Drawing.Point(8, 20);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(119, 22);
            this.Label8.TabIndex = 0;
            this.Label8.Text = "Partner:";
            this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label9
            // 
            this.Label9.BackColor = System.Drawing.Color.Transparent;
            this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label9.Location = new System.Drawing.Point(8, 44);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(119, 22);
            this.Label9.TabIndex = 2;
            this.Label9.Text = "Vrsta partnera:";
            this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CheckBox1
            // 
            this.CheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CheckBox1.Location = new System.Drawing.Point(6, 242);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new System.Drawing.Size(227, 24);
            this.CheckBox1.TabIndex = 0;
            this.CheckBox1.Text = "Nova stranica za svakog partnera";
            this.CheckBox1.UseVisualStyleBackColor = false;
            // 
            // CheckBox2
            // 
            this.CheckBox2.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CheckBox2.Location = new System.Drawing.Point(254, 242);
            this.CheckBox2.Name = "CheckBox2";
            this.CheckBox2.Size = new System.Drawing.Size(239, 24);
            this.CheckBox2.TabIndex = 1;
            this.CheckBox2.Text = "Ispis po abecedi";
            this.CheckBox2.UseVisualStyleBackColor = false;
            // 
            // ErrorProvider1
            // 
            this.ErrorProvider1.ContainerControl = this;
            // 
            // UltraDockManager1
            // 
            dockAreaPane1.DefaultPaneSettings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane1.Control = this.UltraGroupBox1;
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(4, 30, 568, 320);
            dockableControlPane1.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(792, 290);
            this.UltraDockManager1.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1});
            this.UltraDockManager1.HostControl = this;
            this.UltraDockManager1.UseAppStyling = false;
            this.UltraDockManager1.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2007;
            // 
            // _frmKARTICEPARTNERAUnpinnedTabAreaLeft
            // 
            this._frmKARTICEPARTNERAUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._frmKARTICEPARTNERAUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._frmKARTICEPARTNERAUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._frmKARTICEPARTNERAUnpinnedTabAreaLeft.Name = "_frmKARTICEPARTNERAUnpinnedTabAreaLeft";
            this._frmKARTICEPARTNERAUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            this._frmKARTICEPARTNERAUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 526);
            this._frmKARTICEPARTNERAUnpinnedTabAreaLeft.TabIndex = 106;
            // 
            // _frmKARTICEPARTNERAUnpinnedTabAreaRight
            // 
            this._frmKARTICEPARTNERAUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._frmKARTICEPARTNERAUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._frmKARTICEPARTNERAUnpinnedTabAreaRight.Location = new System.Drawing.Point(792, 0);
            this._frmKARTICEPARTNERAUnpinnedTabAreaRight.Name = "_frmKARTICEPARTNERAUnpinnedTabAreaRight";
            this._frmKARTICEPARTNERAUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this._frmKARTICEPARTNERAUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 526);
            this._frmKARTICEPARTNERAUnpinnedTabAreaRight.TabIndex = 107;
            // 
            // _frmKARTICEPARTNERAUnpinnedTabAreaTop
            // 
            this._frmKARTICEPARTNERAUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._frmKARTICEPARTNERAUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._frmKARTICEPARTNERAUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._frmKARTICEPARTNERAUnpinnedTabAreaTop.Name = "_frmKARTICEPARTNERAUnpinnedTabAreaTop";
            this._frmKARTICEPARTNERAUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this._frmKARTICEPARTNERAUnpinnedTabAreaTop.Size = new System.Drawing.Size(792, 0);
            this._frmKARTICEPARTNERAUnpinnedTabAreaTop.TabIndex = 108;
            // 
            // _frmKARTICEPARTNERAUnpinnedTabAreaBottom
            // 
            this._frmKARTICEPARTNERAUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._frmKARTICEPARTNERAUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._frmKARTICEPARTNERAUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 526);
            this._frmKARTICEPARTNERAUnpinnedTabAreaBottom.Name = "_frmKARTICEPARTNERAUnpinnedTabAreaBottom";
            this._frmKARTICEPARTNERAUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this._frmKARTICEPARTNERAUnpinnedTabAreaBottom.Size = new System.Drawing.Size(792, 0);
            this._frmKARTICEPARTNERAUnpinnedTabAreaBottom.TabIndex = 109;
            // 
            // _frmKARTICEPARTNERAAutoHideControl
            // 
            this._frmKARTICEPARTNERAAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._frmKARTICEPARTNERAAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._frmKARTICEPARTNERAAutoHideControl.Name = "_frmKARTICEPARTNERAAutoHideControl";
            this._frmKARTICEPARTNERAAutoHideControl.Owner = this.UltraDockManager1;
            this._frmKARTICEPARTNERAAutoHideControl.Size = new System.Drawing.Size(0, 526);
            this._frmKARTICEPARTNERAAutoHideControl.TabIndex = 110;
            // 
            // DockableWindow1
            // 
            this.DockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow1.Name = "DockableWindow1";
            this.DockableWindow1.Size = new System.Drawing.Size(0, 0);
            this.DockableWindow1.TabIndex = 0;
            // 
            // WindowDockingArea2
            // 
            this.WindowDockingArea2.Controls.Add(this.DockableWindow3);
            this.WindowDockingArea2.Dock = System.Windows.Forms.DockStyle.Top;
            this.WindowDockingArea2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea2.Location = new System.Drawing.Point(0, 0);
            this.WindowDockingArea2.Name = "WindowDockingArea2";
            this.WindowDockingArea2.Owner = this.UltraDockManager1;
            this.WindowDockingArea2.Size = new System.Drawing.Size(792, 295);
            this.WindowDockingArea2.TabIndex = 112;
            // 
            // DockableWindow3
            // 
            this.DockableWindow3.Controls.Add(this.UltraGroupBox1);
            this.DockableWindow3.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow3.Name = "DockableWindow3";
            this.DockableWindow3.Owner = this.UltraDockManager1;
            this.DockableWindow3.Size = new System.Drawing.Size(792, 290);
            this.DockableWindow3.TabIndex = 114;
            // 
            // ctlReportViewer
            // 
            this.ctlReportViewer.ActiveViewIndex = -1;
            this.ctlReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctlReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.ctlReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlReportViewer.Location = new System.Drawing.Point(0, 295);
            this.ctlReportViewer.Name = "ctlReportViewer";
            this.ctlReportViewer.Size = new System.Drawing.Size(792, 231);
            this.ctlReportViewer.TabIndex = 113;
            this.ctlReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // cbkPartnerUcenik
            // 
            this.cbkPartnerUcenik.AutoSize = true;
            this.cbkPartnerUcenik.BackColor = System.Drawing.Color.Transparent;
            this.cbkPartnerUcenik.Location = new System.Drawing.Point(650, 25);
            this.cbkPartnerUcenik.Name = "cbkPartnerUcenik";
            this.cbkPartnerUcenik.Size = new System.Drawing.Size(103, 17);
            this.cbkPartnerUcenik.TabIndex = 19;
            this.cbkPartnerUcenik.Text = "Partneri/Učenici";
            this.cbkPartnerUcenik.UseVisualStyleBackColor = false;
            // 
            // KarticePartneraSmartPart
            // 
            this.Controls.Add(this._frmKARTICEPARTNERAAutoHideControl);
            this.Controls.Add(this.ctlReportViewer);
            this.Controls.Add(this.DockableWindow1);
            this.Controls.Add(this.WindowDockingArea2);
            this.Controls.Add(this._frmKARTICEPARTNERAUnpinnedTabAreaTop);
            this.Controls.Add(this._frmKARTICEPARTNERAUnpinnedTabAreaBottom);
            this.Controls.Add(this._frmKARTICEPARTNERAUnpinnedTabAreaLeft);
            this.Controls.Add(this._frmKARTICEPARTNERAUnpinnedTabAreaRight);
            this.Name = "KarticePartneraSmartPart";
            this.Size = new System.Drawing.Size(792, 526);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).EndInit();
            this.UltraGroupBox1.ResumeLayout(false);
            this.UltraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmboIDPartner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartnerDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboPartnerAktivnost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AktivnostDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboIDdok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DokumentDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboIDkontozavrsni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KontoDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboIDkontopocetni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboIDOJ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrgjedDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboIDMT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MjestotroskaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datumdo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datumod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).EndInit();
            this.WindowDockingArea2.ResumeLayout(false);
            this.DockableWindow3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void cmboPartnerAktivnost_BeforeDropDown(object sender, CancelEventArgs e)
        {
            AKTIVNOSTDataAdapter adapter = new AKTIVNOSTDataAdapter();
            if (this.AktivnostDataSet1.AKTIVNOST.Rows.Count == 0)
            {
                adapter.FillByIDAKTIVNOST(this.AktivnostDataSet1, 2);
                adapter.FillByIDAKTIVNOST(this.AktivnostDataSet1, 3);
            }
        }

        private void Ispisi()
        {
            this.BackgroundUpdate();
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - Kartice partnera",
                Description = "Pregled izvještaja - Kartice partnera",
                Icon = ImageResourcesNew.mbs
            };
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            if (item == null)
            {
                item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            item.Izvjestaj = this.rpt;
            item.Show(item.Workspaces["main"], info);
        }

        private void IspisiLand()
        {
            this.BackgroundUpdateLand();
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
            {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - Kartice partnera",
                Description = "Pregled izvještaja - Kartice partnera",
                Icon = ImageResourcesNew.mbs
            };
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            if (item == null)
            {
                item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            item.Izvjestaj = this.rpt;
            item.Show(item.Workspaces["main"], info);
        }

        private void KarticePartneraSmartPart_Load(object sender, EventArgs e)
        {
            this.POCETNI = mipsed.application.framework.Application.Pocetni;
            this.ZAVRSNI = mipsed.application.framework.Application.Zavrsni;
            this.CheckBox1.Checked = true;
            this.datumod.Value = this.POCETNI;
            this.datumdo.Value = this.ZAVRSNI;
            InfraCustom.InicijalizirajCombo(this.cmboIDPartner, null, false, false);
            InfraCustom.InicijalizirajCombo(this.cmboPartnerAktivnost, null);
            InfraCustom.InicijalizirajCombo(this.cmboIDOJ, null);
            InfraCustom.InicijalizirajCombo(this.cmboIDMT, null);
            InfraCustom.InicijalizirajCombo(this.cmboIDdok, null);
            InfraCustom.InicijalizirajCombo(this.cmboIDkontopocetni, null);
            InfraCustom.InicijalizirajCombo(this.cmboIDkontozavrsni, null);
            InfraCustom.PostaviEnterUTabSvimEditKontrolama(this);
            InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
        }

        [LocalCommandHandler("Kreiraj")]
        public void KreirajHandler(object sender, EventArgs e)
        {
            this.Ispisi();
        }

        [LocalCommandHandler("KreirajLand")]
        public void KreirajHandlerLand(object sender, EventArgs e)
        {
            this.IspisiLand();
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
                case Keys.F4:
                    this.Ispisi();
                    break;

                case Keys.Escape:
                    this.ParentForm.Close();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void UltraGroupBox1_Click(object sender, EventArgs e)
        {
        }

        private AutoHideControl _frmKARTICEPARTNERAAutoHideControl;

        private UnpinnedTabArea _frmKARTICEPARTNERAUnpinnedTabAreaBottom;

        private UnpinnedTabArea _frmKARTICEPARTNERAUnpinnedTabAreaLeft;

        private UnpinnedTabArea _frmKARTICEPARTNERAUnpinnedTabAreaRight;

        private UnpinnedTabArea _frmKARTICEPARTNERAUnpinnedTabAreaTop;

        private AKTIVNOSTDataSet AktivnostDataSet1;

        private CheckBox CheckBox1;

        private CheckBox CheckBox2;

        private UltraCombo cmboIDdok;

        private UltraCombo cmboIDkontopocetni;

        private UltraCombo cmboIDkontozavrsni;

        private UltraCombo cmboIDMT;

        private UltraCombo cmboIDOJ;

        private UltraCombo cmboIDPartner;

        private UltraCombo cmboPartnerAktivnost;

        [CreateNew]
        public RSmObrazacController Controller { get; set; }

        private CrystalReportViewer ctlReportViewer;

        private UltraDateTimeEditor datumdo;

        private UltraDateTimeEditor datumod;

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

        private DockableWindow DockableWindow3;

        private DOKUMENTDataSet DokumentDataSet1;

        private ErrorProvider ErrorProvider1;

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

        private KONTODataSet KontoDataSet1;

        private Label Label1;

        private Label Label2;

        private Label Label3;

        private Label Label4;

        private Label Label5;

        private Label Label6;

        private Label Label7;

        private Label Label8;

        private Label Label9;

        private MJESTOTROSKADataSet MjestotroskaDataSet1;

        private ORGJEDDataSet OrgjedDataSet1;

        private PARTNERDataSet PartnerDataSet1;

        public DataRow SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        private UltraDockManager UltraDockManager1;

        private UltraGroupBox UltraGroupBox1;

        private WindowDockingArea WindowDockingArea2;

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
            }
        }
    }
}


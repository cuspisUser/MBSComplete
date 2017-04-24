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
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Forms;
using Mipsed7.DataAccessLayer;


namespace FinPosModule
{

    [SmartPart]
    public class PrometPartneraSmartPart : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        //db - 31.01.2017
        SqlClient client = null;

        private IContainer components;
        private SmartPartInfoProvider infoProvider;
        
        private DateTime POCETNI;
        private ReportDocument rpt;
        private SmartPartInfo smartPartInfo1;
        private CheckBox cbkPartnerUcenik;
        private DateTime ZAVRSNI;

        public PrometPartneraSmartPart()
        {
            base.Load += new EventHandler(this.PrometPartneraSmartPart_Load);
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo("Izvještaji-SK-Promet po partnerima", "Izvještaji-SK-Promet po partnerima");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);

            client = new SqlClient();
        }

        private void BackgroundUpdate()
        {
            new ProgressDialog { WindowStartupLocation = WindowStartupLocation.CenterScreen, DialogText = "Pripremam izvještaj promet po partnerima!", IsCancellingEnabled = false, AutoIncrementInterval = 150 }.RunWorkerThread(1, new DoWorkEventHandler(this.CountUntilCancelled));
        }

        private void cmboDoPartner_BeforeDropDown(object sender, CancelEventArgs e)
        {
            try
            {
                PartnerDataSet1.PARTNER.Clear();
                PARTNERDataAdapter.prikaz_ucenika = cbkPartnerUcenik.Checked;
                new PARTNERDataAdapter().Fill(this.PartnerDataSet1);
            }
            catch { }
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
            ORGJEDDataAdapter adapter = new ORGJEDDataAdapter();
            if (this.OrgjedDataSet1.ORGJED.Rows.Count == 0)
            {
                adapter.Fill(this.OrgjedDataSet1);
            }
        }

        private void cmboOdPartner_BeforeDropDown(object sender, CancelEventArgs e)
        {
            try
            {
                PartnerDataSet1.PARTNER.Clear();
                PARTNERDataAdapter.prikaz_ucenika = cbkPartnerUcenik.Checked;
                new PARTNERDataAdapter().Fill(this.PartnerDataSet1);
            }
            catch { }
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

        private void CountUntilCancelled(object sender, DoWorkEventArgs e)
        {
            S_FIN_PROMET_PO_PARTNERIMADataAdapter adapter = new S_FIN_PROMET_PO_PARTNERIMADataAdapter();
            S_FIN_PROMET_PO_PARTNERIMADataSet dataSet = new S_FIN_PROMET_PO_PARTNERIMADataSet();
            string str3 = "Sva konta";
            string str2 = "Sva konta";
            string text = "-";
            try
            {
                string str = string.Empty;
                int num2 = 0;
                int num3 = 0;
                int num4 = 0;
                int num5 = 0;
                int num6 = 0;
                string str5 = string.Empty;
                string str6 = string.Empty;
                if (this.cmboOdPartner.SelectedRow != null)
                {
                    num5 = Conversions.ToInteger(this.cmboOdPartner.Value.ToString().Remove(0, this.cmboOdPartner.Value.ToString().LastIndexOf("|") + 1).Trim());
                }
                else
                {
                    num5 = -1;
                }
                if (this.cmboOdPartner.SelectedRow != null)
                {
                    num2 = Conversions.ToInteger(this.cmboDoPartner.Value.ToString().Remove(0, this.cmboDoPartner.Value.ToString().LastIndexOf("|") + 1).Trim());
                }
                else
                {
                    num2 = -1;
                }
                if (this.cmboIDMT.SelectedRow != null)
                {
                    num4 = Conversions.ToInteger(this.cmboIDMT.Value);
                }
                else
                {
                    num4 = -1;
                }
                if (this.cmboIDOJ.SelectedRow != null)
                {
                    text = this.cmboIDOJ.SelectedRow.Cells["idorgjed"].Text + "-";
                    text = this.cmboIDOJ.SelectedRow.Cells["nazivorgjed"].Text;
                    num6 = Conversions.ToInteger(this.cmboIDOJ.Value);
                }
                else
                {
                    num6 = -1;
                }
                if (this.cmboPartnerAktivnost.SelectedRow != null)
                {
                    num3 = Conversions.ToInteger(this.cmboPartnerAktivnost.Value);
                }
                else
                {
                    num3 = -1;
                }
                DateTime rAZDOBLJEOD = Conversions.ToDate(this.odDatuma.Value);
                DateTime rAZDOBLJEDO = Conversions.ToDate(this.doDatuma.Value);
                if (this.CheckBox1.Checked)
                {
                    str = "N";
                }
                else
                {
                    str = "S";
                }
                if (this.cmboIDkontopocetni.SelectedRow != null)
                {
                    str5 = this.cmboIDkontopocetni.SelectedRow.Cells["idkonto"].Text;
                }
                else
                {
                    str5 = " ";
                }
                if (this.cmboIDkontozavrsni.SelectedRow != null)
                {
                    str6 = Conversions.ToString(this.cmboIDkontozavrsni.Value);
                }
                else
                {
                    str6 = " ";
                }
                try
                {
                    try
                    {
                        adapter.Fill(dataSet, num5, num2, num4, num6, num3, rAZDOBLJEOD, rAZDOBLJEDO, str, str5, str6);
                    }
                    catch (System.Exception exception1)
                    {
                        throw exception1;
                    }
                }
                catch (System.Exception exception4)
                {
                    throw exception4;                    
                }

                //db - 31.01.2017 - promjena data sourcea 
                string stora = "S_FIN_PROMET_PO_PARTNERIMA_2";
                SqlCommand com = new SqlCommand(stora);
                com.Connection = client.sqlConnection;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ODPARTNERA",num5);
                com.Parameters.AddWithValue("@DOPARTNERA",num2);
                com.Parameters.AddWithValue("@MT",num4);
                com.Parameters.AddWithValue("@ORG",num6);
                com.Parameters.AddWithValue("@IDAKTIVNOST",num3);
                com.Parameters.AddWithValue("@RAZDOBLJEOD",rAZDOBLJEOD);
                com.Parameters.AddWithValue("@RAZDOBLJEDO",rAZDOBLJEDO);
                com.Parameters.AddWithValue("@dodatniuvjet",str);
                com.Parameters.AddWithValue("@POCETNIKONTO",str5);
                com.Parameters.AddWithValue("@ZAVRSNIKONTO",str6);


                DataTable dt = new DataTable();
                dt = client.GetDataTable(com);
                
                this.rpt = new ReportDocument();
                this.rpt.Load(System.Windows.Forms.Application.StartupPath + @"\FinposIzvjestaji\rptPrometPartnera.rpt");
                //this.rpt.SetDataSource(dataSet);
                this.rpt.SetDataSource(dt);
                this.rpt.SetParameterValue("odkonta", str3);
                this.rpt.SetParameterValue("dokonta", str2);
                this.rpt.SetParameterValue("ogranizac", text);
                this.rpt.SetParameterValue("naslov", "Promet poslovnih partnera za razdoblje: " + Conversions.ToString(this.odDatuma.Value) + "-" + Conversions.ToString(this.doDatuma.Value));
                mipsed.application.framework.Application.PostaviParametreIzvjestaja(ref this.rpt);
            }
            catch (System.Exception exception5)
            {
                throw exception5;                
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("KONTO", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVKONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAKTIVNOST");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVAKTIVNOST");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KONT");
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("KONTO", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVKONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAKTIVNOST");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVAKTIVNOST");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KONT");
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ORGJED", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDORGJED");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVORGJED");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("oj");
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand4 = new Infragistics.Win.UltraWinGrid.UltraGridBand("MJESTOTROSKA", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDMJESTOTROSKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVMJESTOTROSKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("mt");
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand5 = new Infragistics.Win.UltraWinGrid.UltraGridBand("PARTNER", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPARTNER");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVPARTNER");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MB");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNERMJESTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNERULICA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNEREMAIL");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNEROIB");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNERFAX");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNERTELEFON");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNERZIRO1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNERZIRO2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNER_PARTNERZADUZENJE");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand6 = new Infragistics.Win.UltraWinGrid.UltraGridBand("PARTNER_PARTNERZADUZENJE", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPARTNER");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDZADUZENJE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn32 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPROIZVOD");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn33 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVPROIZVOD");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn34 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CIJENA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn35 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KOLICINAZADUZENJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn36 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CIJENAZADUZENJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn37 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IZNOSZADUZENJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn38 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RABATZADUZENJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn39 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IZNOSRABATAZADUZENJE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn40 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CIJENAZAFAKTURU");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn41 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UGOVORBROJ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn42 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMUGOVORA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn43 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AKTIVNO");
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand7 = new Infragistics.Win.UltraWinGrid.UltraGridBand("PARTNER", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn44 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPARTNER");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn45 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVPARTNER");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn46 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MB");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn47 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNERMJESTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn48 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNERULICA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn49 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNEREMAIL");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn50 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNEROIB");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn51 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNERFAX");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn52 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNERTELEFON");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn53 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNERZIRO1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn54 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNERZIRO2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn55 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn56 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNER_PARTNERZADUZENJE");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand8 = new Infragistics.Win.UltraWinGrid.UltraGridBand("PARTNER_PARTNERZADUZENJE", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn57 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPARTNER");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn58 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDZADUZENJE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn59 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPROIZVOD");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn60 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVPROIZVOD");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn61 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CIJENA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn62 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KOLICINAZADUZENJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn63 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CIJENAZADUZENJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn64 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IZNOSZADUZENJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn65 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RABATZADUZENJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn66 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IZNOSRABATAZADUZENJE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn67 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CIJENAZAFAKTURU");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn68 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UGOVORBROJ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn69 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMUGOVORA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn70 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AKTIVNO");
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand9 = new Infragistics.Win.UltraWinGrid.UltraGridBand("AKTIVNOST", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn71 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAKTIVNOST");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn72 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVAKTIVNOST");
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
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedTop, new System.Guid("1361f6cd-36c3-4115-a864-abdf453bade5"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("d771823c-7767-4dc6-9029-937b8e87be22"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("1361f6cd-36c3-4115-a864-abdf453bade5"), -1);
            this.UltraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.cmboIDkontozavrsni = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.KontoDataSet1 = new Placa.KONTODataSet();
            this.cmboIDkontopocetni = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.cmboIDOJ = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.OrgjedDataSet1 = new Placa.ORGJEDDataSet();
            this.cmboIDMT = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.MjestotroskaDataSet1 = new Placa.MJESTOTROSKADataSet();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.cmboOdPartner = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.PartnerDataSet1 = new Placa.PARTNERDataSet();
            this.Label2 = new System.Windows.Forms.Label();
            this.cmboDoPartner = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.cmboPartnerAktivnost = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.AktivnostDataSet1 = new Placa.AKTIVNOSTDataSet();
            this.doDatuma = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.odDatuma = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.CheckBox1 = new System.Windows.Forms.CheckBox();
            this.ErrorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.MjestotroskaDataSet2 = new Placa.MJESTOTROSKADataSet();
            this.KontoDataSet2 = new Placa.KONTODataSet();
            this.UltraDockManager1 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._frmprometpartneraUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._frmprometpartneraUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._frmprometpartneraUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._frmprometpartneraUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._frmprometpartneraAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.WindowDockingArea2 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.DockableWindow2 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.RPV = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.cbkPartnerUcenik = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).BeginInit();
            this.UltraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmboIDkontozavrsni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KontoDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboIDkontopocetni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboIDOJ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrgjedDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboIDMT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MjestotroskaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboOdPartner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartnerDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboDoPartner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboPartnerAktivnost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AktivnostDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doDatuma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.odDatuma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MjestotroskaDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KontoDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).BeginInit();
            this.WindowDockingArea2.SuspendLayout();
            this.DockableWindow2.SuspendLayout();
            this.SuspendLayout();
            // 
            // UltraGroupBox1
            // 
            this.UltraGroupBox1.Controls.Add(this.cbkPartnerUcenik);
            this.UltraGroupBox1.Controls.Add(this.cmboIDkontozavrsni);
            this.UltraGroupBox1.Controls.Add(this.cmboIDkontopocetni);
            this.UltraGroupBox1.Controls.Add(this.Label1);
            this.UltraGroupBox1.Controls.Add(this.Label3);
            this.UltraGroupBox1.Controls.Add(this.cmboIDOJ);
            this.UltraGroupBox1.Controls.Add(this.cmboIDMT);
            this.UltraGroupBox1.Controls.Add(this.Label5);
            this.UltraGroupBox1.Controls.Add(this.Label6);
            this.UltraGroupBox1.Controls.Add(this.cmboOdPartner);
            this.UltraGroupBox1.Controls.Add(this.Label2);
            this.UltraGroupBox1.Controls.Add(this.cmboDoPartner);
            this.UltraGroupBox1.Controls.Add(this.cmboPartnerAktivnost);
            this.UltraGroupBox1.Controls.Add(this.doDatuma);
            this.UltraGroupBox1.Controls.Add(this.odDatuma);
            this.UltraGroupBox1.Controls.Add(this.Label11);
            this.UltraGroupBox1.Controls.Add(this.Label12);
            this.UltraGroupBox1.Controls.Add(this.Label13);
            this.UltraGroupBox1.Controls.Add(this.Label14);
            this.UltraGroupBox1.Controls.Add(this.CheckBox1);
            this.UltraGroupBox1.Location = new System.Drawing.Point(0, 18);
            this.UltraGroupBox1.Name = "UltraGroupBox1";
            this.UltraGroupBox1.Size = new System.Drawing.Size(792, 277);
            this.UltraGroupBox1.TabIndex = 0;
            this.UltraGroupBox1.Text = "Odabir podataka";
            this.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // cmboIDkontozavrsni
            // 
            this.cmboIDkontozavrsni.AllowNull = Infragistics.Win.DefaultableBoolean.True;
            this.cmboIDkontozavrsni.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            appearance31.TextHAlignAsString = "Center";
            editorButton1.Appearance = appearance31;
            editorButton1.Text = "...";
            this.cmboIDkontozavrsni.ButtonsRight.Add(editorButton1);
            this.cmboIDkontozavrsni.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmboIDkontozavrsni.DataMember = "KONTO";
            this.cmboIDkontozavrsni.DataSource = this.KontoDataSet1;
            appearance42.BackColor = System.Drawing.SystemColors.Window;
            appearance42.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmboIDkontozavrsni.DisplayLayout.Appearance = appearance42;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Width = 65;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 200;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Width = 65;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Width = 100;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5});
            this.cmboIDkontozavrsni.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.cmboIDkontozavrsni.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmboIDkontozavrsni.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance53.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance53.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance53.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance53.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDkontozavrsni.DisplayLayout.GroupByBox.Appearance = appearance53;
            appearance64.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDkontozavrsni.DisplayLayout.GroupByBox.BandLabelAppearance = appearance64;
            this.cmboIDkontozavrsni.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance75.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance75.BackColor2 = System.Drawing.SystemColors.Control;
            appearance75.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance75.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDkontozavrsni.DisplayLayout.GroupByBox.PromptAppearance = appearance75;
            this.cmboIDkontozavrsni.DisplayLayout.MaxColScrollRegions = 1;
            this.cmboIDkontozavrsni.DisplayLayout.MaxRowScrollRegions = 1;
            appearance86.BackColor = System.Drawing.SystemColors.Window;
            appearance86.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmboIDkontozavrsni.DisplayLayout.Override.ActiveCellAppearance = appearance86;
            appearance.BackColor = System.Drawing.SystemColors.Highlight;
            appearance.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cmboIDkontozavrsni.DisplayLayout.Override.ActiveRowAppearance = appearance;
            this.cmboIDkontozavrsni.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cmboIDkontozavrsni.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            this.cmboIDkontozavrsni.DisplayLayout.Override.CardAreaAppearance = appearance2;
            appearance3.BorderColor = System.Drawing.Color.Silver;
            appearance3.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cmboIDkontozavrsni.DisplayLayout.Override.CellAppearance = appearance3;
            this.cmboIDkontozavrsni.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.cmboIDkontozavrsni.DisplayLayout.Override.CellPadding = 0;
            appearance4.BackColor = System.Drawing.SystemColors.Control;
            appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance4.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDkontozavrsni.DisplayLayout.Override.GroupByRowAppearance = appearance4;
            appearance5.TextHAlignAsString = "Left";
            this.cmboIDkontozavrsni.DisplayLayout.Override.HeaderAppearance = appearance5;
            this.cmboIDkontozavrsni.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cmboIDkontozavrsni.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.BorderColor = System.Drawing.Color.Silver;
            this.cmboIDkontozavrsni.DisplayLayout.Override.RowAppearance = appearance6;
            this.cmboIDkontozavrsni.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmboIDkontozavrsni.DisplayLayout.Override.TemplateAddRowAppearance = appearance7;
            this.cmboIDkontozavrsni.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cmboIDkontozavrsni.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cmboIDkontozavrsni.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cmboIDkontozavrsni.DisplayMember = "NAZIVKONTO";
            this.cmboIDkontozavrsni.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmboIDkontozavrsni.Location = new System.Drawing.Point(150, 142);
            this.cmboIDkontozavrsni.Name = "cmboIDkontozavrsni";
            this.cmboIDkontozavrsni.Size = new System.Drawing.Size(116, 22);
            this.cmboIDkontozavrsni.TabIndex = 5;
            this.cmboIDkontozavrsni.Tag = "";
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
            this.cmboIDkontopocetni.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            appearance8.TextHAlignAsString = "Center";
            editorButton2.Appearance = appearance8;
            editorButton2.Text = "...";
            this.cmboIDkontopocetni.ButtonsRight.Add(editorButton2);
            this.cmboIDkontopocetni.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmboIDkontopocetni.DataMember = "KONTO";
            this.cmboIDkontopocetni.DataSource = this.KontoDataSet1;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            appearance9.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmboIDkontopocetni.DisplayLayout.Appearance = appearance9;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.Header.VisiblePosition = 0;
            ultraGridColumn6.Width = 65;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.Header.VisiblePosition = 1;
            ultraGridColumn7.Width = 200;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.Header.VisiblePosition = 2;
            ultraGridColumn8.Width = 65;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn9.Header.VisiblePosition = 3;
            ultraGridColumn9.Width = 100;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn10.Header.VisiblePosition = 4;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10});
            this.cmboIDkontopocetni.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.cmboIDkontopocetni.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmboIDkontopocetni.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance10.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDkontopocetni.DisplayLayout.GroupByBox.Appearance = appearance10;
            appearance11.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDkontopocetni.DisplayLayout.GroupByBox.BandLabelAppearance = appearance11;
            this.cmboIDkontopocetni.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance12.BackColor2 = System.Drawing.SystemColors.Control;
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance12.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDkontopocetni.DisplayLayout.GroupByBox.PromptAppearance = appearance12;
            this.cmboIDkontopocetni.DisplayLayout.MaxColScrollRegions = 1;
            this.cmboIDkontopocetni.DisplayLayout.MaxRowScrollRegions = 1;
            appearance13.BackColor = System.Drawing.SystemColors.Window;
            appearance13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmboIDkontopocetni.DisplayLayout.Override.ActiveCellAppearance = appearance13;
            appearance14.BackColor = System.Drawing.SystemColors.Highlight;
            appearance14.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cmboIDkontopocetni.DisplayLayout.Override.ActiveRowAppearance = appearance14;
            this.cmboIDkontopocetni.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cmboIDkontopocetni.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance15.BackColor = System.Drawing.SystemColors.Window;
            this.cmboIDkontopocetni.DisplayLayout.Override.CardAreaAppearance = appearance15;
            appearance16.BorderColor = System.Drawing.Color.Silver;
            appearance16.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cmboIDkontopocetni.DisplayLayout.Override.CellAppearance = appearance16;
            this.cmboIDkontopocetni.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.cmboIDkontopocetni.DisplayLayout.Override.CellPadding = 0;
            appearance17.BackColor = System.Drawing.SystemColors.Control;
            appearance17.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance17.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance17.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDkontopocetni.DisplayLayout.Override.GroupByRowAppearance = appearance17;
            appearance18.TextHAlignAsString = "Left";
            this.cmboIDkontopocetni.DisplayLayout.Override.HeaderAppearance = appearance18;
            this.cmboIDkontopocetni.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cmboIDkontopocetni.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance19.BackColor = System.Drawing.SystemColors.Window;
            appearance19.BorderColor = System.Drawing.Color.Silver;
            this.cmboIDkontopocetni.DisplayLayout.Override.RowAppearance = appearance19;
            this.cmboIDkontopocetni.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance20.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmboIDkontopocetni.DisplayLayout.Override.TemplateAddRowAppearance = appearance20;
            this.cmboIDkontopocetni.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cmboIDkontopocetni.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cmboIDkontopocetni.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cmboIDkontopocetni.DisplayMember = "NAZIVKONTO";
            this.cmboIDkontopocetni.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmboIDkontopocetni.Location = new System.Drawing.Point(150, 118);
            this.cmboIDkontopocetni.Name = "cmboIDkontopocetni";
            this.cmboIDkontopocetni.Size = new System.Drawing.Size(116, 22);
            this.cmboIDkontopocetni.TabIndex = 4;
            this.cmboIDkontopocetni.Tag = "";
            this.cmboIDkontopocetni.ValueMember = "IDKONTO";
            this.cmboIDkontopocetni.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cmboIDkontopocetni_BeforeDropDown);
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label1.Location = new System.Drawing.Point(8, 118);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(134, 22);
            this.Label1.TabIndex = 13;
            this.Label1.Text = "Od konta:";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label3.Location = new System.Drawing.Point(8, 142);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(134, 22);
            this.Label3.TabIndex = 15;
            this.Label3.Text = "Do konta:";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmboIDOJ
            // 
            this.cmboIDOJ.AllowNull = Infragistics.Win.DefaultableBoolean.True;
            appearance21.TextHAlignAsString = "Center";
            editorButton3.Appearance = appearance21;
            editorButton3.Text = "...";
            this.cmboIDOJ.ButtonsRight.Add(editorButton3);
            this.cmboIDOJ.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmboIDOJ.DataMember = "ORGJED";
            this.cmboIDOJ.DataSource = this.OrgjedDataSet1;
            appearance22.BackColor = System.Drawing.SystemColors.Window;
            appearance22.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmboIDOJ.DisplayLayout.Appearance = appearance22;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn11.Header.VisiblePosition = 0;
            ultraGridColumn11.Width = 65;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn12.Header.VisiblePosition = 1;
            ultraGridColumn12.Width = 150;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn13.Header.VisiblePosition = 2;
            ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13});
            this.cmboIDOJ.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
            this.cmboIDOJ.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmboIDOJ.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance23.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance23.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance23.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDOJ.DisplayLayout.GroupByBox.Appearance = appearance23;
            appearance24.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDOJ.DisplayLayout.GroupByBox.BandLabelAppearance = appearance24;
            this.cmboIDOJ.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance25.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance25.BackColor2 = System.Drawing.SystemColors.Control;
            appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance25.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDOJ.DisplayLayout.GroupByBox.PromptAppearance = appearance25;
            this.cmboIDOJ.DisplayLayout.MaxColScrollRegions = 1;
            this.cmboIDOJ.DisplayLayout.MaxRowScrollRegions = 1;
            appearance26.BackColor = System.Drawing.SystemColors.Window;
            appearance26.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmboIDOJ.DisplayLayout.Override.ActiveCellAppearance = appearance26;
            appearance27.BackColor = System.Drawing.SystemColors.Highlight;
            appearance27.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cmboIDOJ.DisplayLayout.Override.ActiveRowAppearance = appearance27;
            this.cmboIDOJ.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cmboIDOJ.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance28.BackColor = System.Drawing.SystemColors.Window;
            this.cmboIDOJ.DisplayLayout.Override.CardAreaAppearance = appearance28;
            appearance29.BorderColor = System.Drawing.Color.Silver;
            appearance29.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cmboIDOJ.DisplayLayout.Override.CellAppearance = appearance29;
            this.cmboIDOJ.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.cmboIDOJ.DisplayLayout.Override.CellPadding = 0;
            appearance30.BackColor = System.Drawing.SystemColors.Control;
            appearance30.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance30.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance30.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance30.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDOJ.DisplayLayout.Override.GroupByRowAppearance = appearance30;
            appearance32.TextHAlignAsString = "Left";
            this.cmboIDOJ.DisplayLayout.Override.HeaderAppearance = appearance32;
            this.cmboIDOJ.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cmboIDOJ.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance33.BackColor = System.Drawing.SystemColors.Window;
            appearance33.BorderColor = System.Drawing.Color.Silver;
            this.cmboIDOJ.DisplayLayout.Override.RowAppearance = appearance33;
            this.cmboIDOJ.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance34.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmboIDOJ.DisplayLayout.Override.TemplateAddRowAppearance = appearance34;
            this.cmboIDOJ.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cmboIDOJ.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cmboIDOJ.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cmboIDOJ.DisplayMember = "NAZIVORGJED";
            this.cmboIDOJ.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmboIDOJ.Location = new System.Drawing.Point(150, 68);
            this.cmboIDOJ.Name = "cmboIDOJ";
            this.cmboIDOJ.Size = new System.Drawing.Size(116, 22);
            this.cmboIDOJ.TabIndex = 2;
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
            appearance35.TextHAlignAsString = "Center";
            editorButton4.Appearance = appearance35;
            editorButton4.Text = "...";
            this.cmboIDMT.ButtonsRight.Add(editorButton4);
            this.cmboIDMT.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmboIDMT.DataMember = "MJESTOTROSKA";
            this.cmboIDMT.DataSource = this.MjestotroskaDataSet1;
            appearance36.BackColor = System.Drawing.SystemColors.Window;
            appearance36.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmboIDMT.DisplayLayout.Appearance = appearance36;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn14.Header.VisiblePosition = 0;
            ultraGridColumn14.Width = 65;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn15.Header.VisiblePosition = 1;
            ultraGridColumn15.Width = 150;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn16.Header.VisiblePosition = 2;
            ultraGridBand4.Columns.AddRange(new object[] {
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16});
            this.cmboIDMT.DisplayLayout.BandsSerializer.Add(ultraGridBand4);
            this.cmboIDMT.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmboIDMT.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance37.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance37.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance37.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance37.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDMT.DisplayLayout.GroupByBox.Appearance = appearance37;
            appearance38.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDMT.DisplayLayout.GroupByBox.BandLabelAppearance = appearance38;
            this.cmboIDMT.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance39.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance39.BackColor2 = System.Drawing.SystemColors.Control;
            appearance39.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance39.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDMT.DisplayLayout.GroupByBox.PromptAppearance = appearance39;
            this.cmboIDMT.DisplayLayout.MaxColScrollRegions = 1;
            this.cmboIDMT.DisplayLayout.MaxRowScrollRegions = 1;
            appearance40.BackColor = System.Drawing.SystemColors.Window;
            appearance40.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmboIDMT.DisplayLayout.Override.ActiveCellAppearance = appearance40;
            appearance41.BackColor = System.Drawing.SystemColors.Highlight;
            appearance41.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cmboIDMT.DisplayLayout.Override.ActiveRowAppearance = appearance41;
            this.cmboIDMT.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cmboIDMT.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance43.BackColor = System.Drawing.SystemColors.Window;
            this.cmboIDMT.DisplayLayout.Override.CardAreaAppearance = appearance43;
            appearance44.BorderColor = System.Drawing.Color.Silver;
            appearance44.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cmboIDMT.DisplayLayout.Override.CellAppearance = appearance44;
            this.cmboIDMT.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.cmboIDMT.DisplayLayout.Override.CellPadding = 0;
            appearance45.BackColor = System.Drawing.SystemColors.Control;
            appearance45.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance45.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance45.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance45.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDMT.DisplayLayout.Override.GroupByRowAppearance = appearance45;
            appearance46.TextHAlignAsString = "Left";
            this.cmboIDMT.DisplayLayout.Override.HeaderAppearance = appearance46;
            this.cmboIDMT.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cmboIDMT.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance47.BackColor = System.Drawing.SystemColors.Window;
            appearance47.BorderColor = System.Drawing.Color.Silver;
            this.cmboIDMT.DisplayLayout.Override.RowAppearance = appearance47;
            this.cmboIDMT.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance48.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmboIDMT.DisplayLayout.Override.TemplateAddRowAppearance = appearance48;
            this.cmboIDMT.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cmboIDMT.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cmboIDMT.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cmboIDMT.DisplayMember = "IDMJESTOTROSKA";
            this.cmboIDMT.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmboIDMT.Location = new System.Drawing.Point(150, 92);
            this.cmboIDMT.Name = "cmboIDMT";
            this.cmboIDMT.Size = new System.Drawing.Size(116, 22);
            this.cmboIDMT.TabIndex = 3;
            this.cmboIDMT.ValueMember = "IDMJESTOTROSKA";
            this.cmboIDMT.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cmboIDMT_BeforeDropDown);
            // 
            // MjestotroskaDataSet1
            // 
            this.MjestotroskaDataSet1.DataSetName = "MJESTOTROSKADataSet";
            this.MjestotroskaDataSet1.Locale = new System.Globalization.CultureInfo("hr-HR");
            // 
            // Label5
            // 
            this.Label5.BackColor = System.Drawing.Color.Transparent;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label5.Location = new System.Drawing.Point(8, 68);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(134, 22);
            this.Label5.TabIndex = 10;
            this.Label5.Text = "Organizacijska jedinica:";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label6
            // 
            this.Label6.BackColor = System.Drawing.Color.Transparent;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label6.Location = new System.Drawing.Point(8, 92);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(134, 22);
            this.Label6.TabIndex = 12;
            this.Label6.Text = "Mjesto troška:";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmboOdPartner
            // 
            this.cmboOdPartner.AllowNull = Infragistics.Win.DefaultableBoolean.True;
            this.cmboOdPartner.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            appearance49.TextHAlignAsString = "Center";
            editorButton5.Appearance = appearance49;
            editorButton5.Text = "...";
            this.cmboOdPartner.ButtonsRight.Add(editorButton5);
            this.cmboOdPartner.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmboOdPartner.DataMember = "PARTNER";
            this.cmboOdPartner.DataSource = this.PartnerDataSet1;
            appearance50.BackColor = System.Drawing.SystemColors.Window;
            appearance50.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmboOdPartner.DisplayLayout.Appearance = appearance50;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn17.Header.VisiblePosition = 0;
            ultraGridColumn17.Width = 75;
            ultraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn18.Header.VisiblePosition = 1;
            ultraGridColumn18.Width = 250;
            ultraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn19.Header.Caption = "Porezni broj";
            ultraGridColumn19.Header.VisiblePosition = 2;
            ultraGridColumn19.Width = 100;
            ultraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn20.Header.VisiblePosition = 4;
            ultraGridColumn20.Width = 150;
            ultraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn21.Header.VisiblePosition = 6;
            ultraGridColumn21.Hidden = true;
            ultraGridColumn22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn22.Header.VisiblePosition = 5;
            ultraGridColumn23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn23.Header.VisiblePosition = 7;
            ultraGridColumn24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn24.Header.VisiblePosition = 3;
            ultraGridColumn24.Hidden = true;
            ultraGridColumn25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn25.Header.VisiblePosition = 8;
            ultraGridColumn26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn26.Header.VisiblePosition = 9;
            ultraGridColumn26.Hidden = true;
            ultraGridColumn27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn27.Header.VisiblePosition = 10;
            ultraGridColumn27.Hidden = true;
            ultraGridColumn28.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn28.Header.VisiblePosition = 11;
            ultraGridColumn29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn29.Header.VisiblePosition = 12;
            ultraGridBand5.Columns.AddRange(new object[] {
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
            ultraGridColumn27,
            ultraGridColumn28,
            ultraGridColumn29});
            ultraGridColumn30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn30.Header.VisiblePosition = 0;
            ultraGridColumn31.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn31.Header.VisiblePosition = 1;
            ultraGridColumn32.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn32.Header.VisiblePosition = 2;
            ultraGridColumn33.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn33.Header.VisiblePosition = 3;
            ultraGridColumn34.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn34.Header.VisiblePosition = 4;
            ultraGridColumn35.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn35.Header.VisiblePosition = 5;
            ultraGridColumn36.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn36.Header.VisiblePosition = 6;
            ultraGridColumn37.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn37.Header.VisiblePosition = 7;
            ultraGridColumn38.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn38.Header.VisiblePosition = 8;
            ultraGridColumn39.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn39.Header.VisiblePosition = 9;
            ultraGridColumn40.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn40.Header.VisiblePosition = 10;
            ultraGridColumn41.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn41.Header.VisiblePosition = 11;
            ultraGridColumn42.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn42.Header.VisiblePosition = 12;
            ultraGridColumn43.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn43.Header.VisiblePosition = 13;
            ultraGridBand6.Columns.AddRange(new object[] {
            ultraGridColumn30,
            ultraGridColumn31,
            ultraGridColumn32,
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
            ultraGridColumn43});
            this.cmboOdPartner.DisplayLayout.BandsSerializer.Add(ultraGridBand5);
            this.cmboOdPartner.DisplayLayout.BandsSerializer.Add(ultraGridBand6);
            this.cmboOdPartner.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmboOdPartner.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance51.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance51.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance51.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance51.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboOdPartner.DisplayLayout.GroupByBox.Appearance = appearance51;
            appearance52.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboOdPartner.DisplayLayout.GroupByBox.BandLabelAppearance = appearance52;
            this.cmboOdPartner.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance54.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance54.BackColor2 = System.Drawing.SystemColors.Control;
            appearance54.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance54.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboOdPartner.DisplayLayout.GroupByBox.PromptAppearance = appearance54;
            this.cmboOdPartner.DisplayLayout.MaxColScrollRegions = 1;
            this.cmboOdPartner.DisplayLayout.MaxRowScrollRegions = 1;
            appearance55.BackColor = System.Drawing.SystemColors.Window;
            appearance55.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmboOdPartner.DisplayLayout.Override.ActiveCellAppearance = appearance55;
            appearance56.BackColor = System.Drawing.SystemColors.Highlight;
            appearance56.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cmboOdPartner.DisplayLayout.Override.ActiveRowAppearance = appearance56;
            this.cmboOdPartner.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cmboOdPartner.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance57.BackColor = System.Drawing.SystemColors.Window;
            this.cmboOdPartner.DisplayLayout.Override.CardAreaAppearance = appearance57;
            appearance58.BorderColor = System.Drawing.Color.Silver;
            appearance58.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cmboOdPartner.DisplayLayout.Override.CellAppearance = appearance58;
            this.cmboOdPartner.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.cmboOdPartner.DisplayLayout.Override.CellPadding = 0;
            appearance59.BackColor = System.Drawing.SystemColors.Control;
            appearance59.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance59.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance59.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance59.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboOdPartner.DisplayLayout.Override.GroupByRowAppearance = appearance59;
            appearance60.TextHAlignAsString = "Left";
            this.cmboOdPartner.DisplayLayout.Override.HeaderAppearance = appearance60;
            this.cmboOdPartner.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cmboOdPartner.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance61.BackColor = System.Drawing.SystemColors.Window;
            appearance61.BorderColor = System.Drawing.Color.Silver;
            this.cmboOdPartner.DisplayLayout.Override.RowAppearance = appearance61;
            this.cmboOdPartner.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance62.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmboOdPartner.DisplayLayout.Override.TemplateAddRowAppearance = appearance62;
            this.cmboOdPartner.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cmboOdPartner.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cmboOdPartner.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cmboOdPartner.DisplayMember = "NAZIVPARTNER";
            this.cmboOdPartner.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmboOdPartner.Location = new System.Drawing.Point(150, 168);
            this.cmboOdPartner.Name = "cmboOdPartner";
            this.cmboOdPartner.Size = new System.Drawing.Size(500, 22);
            this.cmboOdPartner.TabIndex = 6;
            this.cmboOdPartner.Tag = "";
            this.cmboOdPartner.ValueMember = "PT";
            this.cmboOdPartner.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cmboOdPartner_BeforeDropDown);
            // 
            // PartnerDataSet1
            // 
            this.PartnerDataSet1.DataSetName = "PARTNERDataSet";
            this.PartnerDataSet1.Locale = new System.Globalization.CultureInfo("hr-HR");
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label2.Location = new System.Drawing.Point(6, 168);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(134, 22);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Od partnera:";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmboDoPartner
            // 
            this.cmboDoPartner.AllowNull = Infragistics.Win.DefaultableBoolean.True;
            this.cmboDoPartner.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            appearance63.TextHAlignAsString = "Center";
            editorButton6.Appearance = appearance63;
            editorButton6.Text = "...";
            this.cmboDoPartner.ButtonsRight.Add(editorButton6);
            this.cmboDoPartner.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmboDoPartner.DataMember = "PARTNER";
            this.cmboDoPartner.DataSource = this.PartnerDataSet1;
            appearance65.BackColor = System.Drawing.SystemColors.Window;
            appearance65.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmboDoPartner.DisplayLayout.Appearance = appearance65;
            ultraGridColumn44.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn44.Header.VisiblePosition = 0;
            ultraGridColumn44.Width = 75;
            ultraGridColumn45.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn45.Header.VisiblePosition = 1;
            ultraGridColumn45.Width = 250;
            ultraGridColumn46.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn46.Header.Caption = "Porezni broj";
            ultraGridColumn46.Header.VisiblePosition = 2;
            ultraGridColumn46.Width = 100;
            ultraGridColumn47.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn47.Header.VisiblePosition = 4;
            ultraGridColumn47.Width = 150;
            ultraGridColumn48.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn48.Header.VisiblePosition = 6;
            ultraGridColumn48.Hidden = true;
            ultraGridColumn49.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn49.Header.VisiblePosition = 5;
            ultraGridColumn50.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn50.Header.VisiblePosition = 7;
            ultraGridColumn51.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn51.Header.VisiblePosition = 3;
            ultraGridColumn51.Hidden = true;
            ultraGridColumn52.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn52.Header.VisiblePosition = 8;
            ultraGridColumn53.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn53.Header.VisiblePosition = 9;
            ultraGridColumn53.Hidden = true;
            ultraGridColumn54.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn54.Header.VisiblePosition = 10;
            ultraGridColumn54.Hidden = true;
            ultraGridColumn55.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn55.Header.VisiblePosition = 11;
            ultraGridColumn56.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn56.Header.VisiblePosition = 12;
            ultraGridBand7.Columns.AddRange(new object[] {
            ultraGridColumn44,
            ultraGridColumn45,
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
            ultraGridColumn56});
            ultraGridColumn57.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn57.Header.VisiblePosition = 0;
            ultraGridColumn58.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn58.Header.VisiblePosition = 1;
            ultraGridColumn59.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn59.Header.VisiblePosition = 2;
            ultraGridColumn60.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn60.Header.VisiblePosition = 3;
            ultraGridColumn61.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn61.Header.VisiblePosition = 4;
            ultraGridColumn62.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn62.Header.VisiblePosition = 5;
            ultraGridColumn63.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn63.Header.VisiblePosition = 6;
            ultraGridColumn64.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn64.Header.VisiblePosition = 7;
            ultraGridColumn65.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn65.Header.VisiblePosition = 8;
            ultraGridColumn66.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn66.Header.VisiblePosition = 9;
            ultraGridColumn67.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn67.Header.VisiblePosition = 10;
            ultraGridColumn68.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn68.Header.VisiblePosition = 11;
            ultraGridColumn69.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn69.Header.VisiblePosition = 12;
            ultraGridColumn70.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn70.Header.VisiblePosition = 13;
            ultraGridBand8.Columns.AddRange(new object[] {
            ultraGridColumn57,
            ultraGridColumn58,
            ultraGridColumn59,
            ultraGridColumn60,
            ultraGridColumn61,
            ultraGridColumn62,
            ultraGridColumn63,
            ultraGridColumn64,
            ultraGridColumn65,
            ultraGridColumn66,
            ultraGridColumn67,
            ultraGridColumn68,
            ultraGridColumn69,
            ultraGridColumn70});
            this.cmboDoPartner.DisplayLayout.BandsSerializer.Add(ultraGridBand7);
            this.cmboDoPartner.DisplayLayout.BandsSerializer.Add(ultraGridBand8);
            this.cmboDoPartner.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmboDoPartner.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance66.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance66.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance66.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance66.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboDoPartner.DisplayLayout.GroupByBox.Appearance = appearance66;
            appearance67.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboDoPartner.DisplayLayout.GroupByBox.BandLabelAppearance = appearance67;
            this.cmboDoPartner.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance68.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance68.BackColor2 = System.Drawing.SystemColors.Control;
            appearance68.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance68.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboDoPartner.DisplayLayout.GroupByBox.PromptAppearance = appearance68;
            this.cmboDoPartner.DisplayLayout.MaxColScrollRegions = 1;
            this.cmboDoPartner.DisplayLayout.MaxRowScrollRegions = 1;
            appearance69.BackColor = System.Drawing.SystemColors.Window;
            appearance69.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmboDoPartner.DisplayLayout.Override.ActiveCellAppearance = appearance69;
            appearance70.BackColor = System.Drawing.SystemColors.Highlight;
            appearance70.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cmboDoPartner.DisplayLayout.Override.ActiveRowAppearance = appearance70;
            this.cmboDoPartner.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cmboDoPartner.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance71.BackColor = System.Drawing.SystemColors.Window;
            this.cmboDoPartner.DisplayLayout.Override.CardAreaAppearance = appearance71;
            appearance72.BorderColor = System.Drawing.Color.Silver;
            appearance72.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cmboDoPartner.DisplayLayout.Override.CellAppearance = appearance72;
            this.cmboDoPartner.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.cmboDoPartner.DisplayLayout.Override.CellPadding = 0;
            appearance73.BackColor = System.Drawing.SystemColors.Control;
            appearance73.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance73.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance73.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance73.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboDoPartner.DisplayLayout.Override.GroupByRowAppearance = appearance73;
            appearance74.TextHAlignAsString = "Left";
            this.cmboDoPartner.DisplayLayout.Override.HeaderAppearance = appearance74;
            this.cmboDoPartner.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cmboDoPartner.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance76.BackColor = System.Drawing.SystemColors.Window;
            appearance76.BorderColor = System.Drawing.Color.Silver;
            this.cmboDoPartner.DisplayLayout.Override.RowAppearance = appearance76;
            this.cmboDoPartner.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance77.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmboDoPartner.DisplayLayout.Override.TemplateAddRowAppearance = appearance77;
            this.cmboDoPartner.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cmboDoPartner.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cmboDoPartner.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cmboDoPartner.DisplayMember = "NAZIVPARTNER";
            this.cmboDoPartner.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmboDoPartner.Location = new System.Drawing.Point(150, 192);
            this.cmboDoPartner.Name = "cmboDoPartner";
            this.cmboDoPartner.Size = new System.Drawing.Size(500, 22);
            this.cmboDoPartner.TabIndex = 7;
            this.cmboDoPartner.Tag = "";
            this.cmboDoPartner.ValueMember = "PT";
            this.cmboDoPartner.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cmboDoPartner_BeforeDropDown);
            // 
            // cmboPartnerAktivnost
            // 
            this.cmboPartnerAktivnost.AllowNull = Infragistics.Win.DefaultableBoolean.True;
            appearance78.TextHAlignAsString = "Center";
            editorButton7.Appearance = appearance78;
            editorButton7.Text = "...";
            this.cmboPartnerAktivnost.ButtonsRight.Add(editorButton7);
            this.cmboPartnerAktivnost.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmboPartnerAktivnost.DataMember = "AKTIVNOST";
            this.cmboPartnerAktivnost.DataSource = this.AktivnostDataSet1;
            appearance79.BackColor = System.Drawing.SystemColors.Window;
            appearance79.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmboPartnerAktivnost.DisplayLayout.Appearance = appearance79;
            ultraGridColumn71.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn71.Header.Caption = "Šifra";
            ultraGridColumn71.Header.VisiblePosition = 0;
            ultraGridColumn71.Width = 65;
            ultraGridColumn72.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn72.Header.VisiblePosition = 1;
            ultraGridColumn72.Width = 200;
            ultraGridBand9.Columns.AddRange(new object[] {
            ultraGridColumn71,
            ultraGridColumn72});
            this.cmboPartnerAktivnost.DisplayLayout.BandsSerializer.Add(ultraGridBand9);
            this.cmboPartnerAktivnost.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmboPartnerAktivnost.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance80.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance80.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance80.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance80.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboPartnerAktivnost.DisplayLayout.GroupByBox.Appearance = appearance80;
            appearance81.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboPartnerAktivnost.DisplayLayout.GroupByBox.BandLabelAppearance = appearance81;
            this.cmboPartnerAktivnost.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance82.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance82.BackColor2 = System.Drawing.SystemColors.Control;
            appearance82.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance82.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboPartnerAktivnost.DisplayLayout.GroupByBox.PromptAppearance = appearance82;
            this.cmboPartnerAktivnost.DisplayLayout.MaxColScrollRegions = 1;
            this.cmboPartnerAktivnost.DisplayLayout.MaxRowScrollRegions = 1;
            appearance83.BackColor = System.Drawing.SystemColors.Window;
            appearance83.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmboPartnerAktivnost.DisplayLayout.Override.ActiveCellAppearance = appearance83;
            appearance84.BackColor = System.Drawing.SystemColors.Highlight;
            appearance84.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cmboPartnerAktivnost.DisplayLayout.Override.ActiveRowAppearance = appearance84;
            this.cmboPartnerAktivnost.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cmboPartnerAktivnost.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance85.BackColor = System.Drawing.SystemColors.Window;
            this.cmboPartnerAktivnost.DisplayLayout.Override.CardAreaAppearance = appearance85;
            appearance87.BorderColor = System.Drawing.Color.Silver;
            appearance87.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cmboPartnerAktivnost.DisplayLayout.Override.CellAppearance = appearance87;
            this.cmboPartnerAktivnost.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.cmboPartnerAktivnost.DisplayLayout.Override.CellPadding = 0;
            appearance88.BackColor = System.Drawing.SystemColors.Control;
            appearance88.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance88.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance88.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance88.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboPartnerAktivnost.DisplayLayout.Override.GroupByRowAppearance = appearance88;
            appearance89.TextHAlignAsString = "Left";
            this.cmboPartnerAktivnost.DisplayLayout.Override.HeaderAppearance = appearance89;
            this.cmboPartnerAktivnost.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cmboPartnerAktivnost.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance90.BackColor = System.Drawing.SystemColors.Window;
            appearance90.BorderColor = System.Drawing.Color.Silver;
            this.cmboPartnerAktivnost.DisplayLayout.Override.RowAppearance = appearance90;
            this.cmboPartnerAktivnost.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance91.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmboPartnerAktivnost.DisplayLayout.Override.TemplateAddRowAppearance = appearance91;
            this.cmboPartnerAktivnost.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cmboPartnerAktivnost.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cmboPartnerAktivnost.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cmboPartnerAktivnost.DisplayMember = "NAZIVAKTIVNOST";
            this.cmboPartnerAktivnost.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmboPartnerAktivnost.Location = new System.Drawing.Point(150, 218);
            this.cmboPartnerAktivnost.Name = "cmboPartnerAktivnost";
            this.cmboPartnerAktivnost.Size = new System.Drawing.Size(116, 22);
            this.cmboPartnerAktivnost.TabIndex = 8;
            this.cmboPartnerAktivnost.Tag = "";
            this.cmboPartnerAktivnost.ValueMember = "IDAKTIVNOST";
            this.cmboPartnerAktivnost.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cmboPartnerAktivnost_BeforeDropDown);
            // 
            // AktivnostDataSet1
            // 
            this.AktivnostDataSet1.DataSetName = "AKTIVNOSTDataSet";
            this.AktivnostDataSet1.Locale = new System.Globalization.CultureInfo("hr-HR");
            // 
            // doDatuma
            // 
            this.doDatuma.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.doDatuma.Location = new System.Drawing.Point(150, 44);
            this.doDatuma.Name = "doDatuma";
            this.doDatuma.PromptChar = ' ';
            this.doDatuma.Size = new System.Drawing.Size(116, 21);
            this.doDatuma.TabIndex = 1;
            // 
            // odDatuma
            // 
            this.odDatuma.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.odDatuma.Location = new System.Drawing.Point(150, 20);
            this.odDatuma.Name = "odDatuma";
            this.odDatuma.PromptChar = ' ';
            this.odDatuma.Size = new System.Drawing.Size(116, 21);
            this.odDatuma.TabIndex = 0;
            // 
            // Label11
            // 
            this.Label11.BackColor = System.Drawing.Color.Transparent;
            this.Label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label11.Location = new System.Drawing.Point(8, 20);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(134, 21);
            this.Label11.TabIndex = 0;
            this.Label11.Text = "Od datuma:";
            this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label12
            // 
            this.Label12.BackColor = System.Drawing.Color.Transparent;
            this.Label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label12.Location = new System.Drawing.Point(8, 44);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(134, 21);
            this.Label12.TabIndex = 2;
            this.Label12.Text = "Do datuma:";
            this.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label13
            // 
            this.Label13.BackColor = System.Drawing.Color.Transparent;
            this.Label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label13.Location = new System.Drawing.Point(6, 192);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(134, 22);
            this.Label13.TabIndex = 6;
            this.Label13.Text = "Do partnera:";
            this.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label14
            // 
            this.Label14.BackColor = System.Drawing.Color.Transparent;
            this.Label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label14.Location = new System.Drawing.Point(6, 218);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(134, 22);
            this.Label14.TabIndex = 8;
            this.Label14.Text = "Vrsta partnera:";
            this.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CheckBox1
            // 
            this.CheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CheckBox1.Location = new System.Drawing.Point(6, 246);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new System.Drawing.Size(324, 24);
            this.CheckBox1.TabIndex = 0;
            this.CheckBox1.Text = "Redoslijed partnera po nazivu";
            this.CheckBox1.UseVisualStyleBackColor = false;
            // 
            // ErrorProvider1
            // 
            this.ErrorProvider1.ContainerControl = this;
            // 
            // MjestotroskaDataSet2
            // 
            this.MjestotroskaDataSet2.DataSetName = "MJESTOTROSKADataSet";
            this.MjestotroskaDataSet2.Locale = new System.Globalization.CultureInfo("hr-HR");
            // 
            // KontoDataSet2
            // 
            this.KontoDataSet2.DataSetName = "KONTODataSet";
            this.KontoDataSet2.Locale = new System.Globalization.CultureInfo("hr-HR");
            // 
            // UltraDockManager1
            // 
            dockableControlPane1.Control = this.UltraGroupBox1;
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(4, 30, 588, 278);
            dockableControlPane1.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(792, 295);
            this.UltraDockManager1.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1});
            this.UltraDockManager1.HostControl = this;
            this.UltraDockManager1.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2007;
            // 
            // _frmprometpartneraUnpinnedTabAreaLeft
            // 
            this._frmprometpartneraUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._frmprometpartneraUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._frmprometpartneraUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._frmprometpartneraUnpinnedTabAreaLeft.Name = "_frmprometpartneraUnpinnedTabAreaLeft";
            this._frmprometpartneraUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            this._frmprometpartneraUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 484);
            this._frmprometpartneraUnpinnedTabAreaLeft.TabIndex = 107;
            // 
            // _frmprometpartneraUnpinnedTabAreaRight
            // 
            this._frmprometpartneraUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._frmprometpartneraUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._frmprometpartneraUnpinnedTabAreaRight.Location = new System.Drawing.Point(792, 0);
            this._frmprometpartneraUnpinnedTabAreaRight.Name = "_frmprometpartneraUnpinnedTabAreaRight";
            this._frmprometpartneraUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this._frmprometpartneraUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 484);
            this._frmprometpartneraUnpinnedTabAreaRight.TabIndex = 108;
            // 
            // _frmprometpartneraUnpinnedTabAreaTop
            // 
            this._frmprometpartneraUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._frmprometpartneraUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._frmprometpartneraUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._frmprometpartneraUnpinnedTabAreaTop.Name = "_frmprometpartneraUnpinnedTabAreaTop";
            this._frmprometpartneraUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this._frmprometpartneraUnpinnedTabAreaTop.Size = new System.Drawing.Size(792, 0);
            this._frmprometpartneraUnpinnedTabAreaTop.TabIndex = 109;
            // 
            // _frmprometpartneraUnpinnedTabAreaBottom
            // 
            this._frmprometpartneraUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._frmprometpartneraUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._frmprometpartneraUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 484);
            this._frmprometpartneraUnpinnedTabAreaBottom.Name = "_frmprometpartneraUnpinnedTabAreaBottom";
            this._frmprometpartneraUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this._frmprometpartneraUnpinnedTabAreaBottom.Size = new System.Drawing.Size(792, 0);
            this._frmprometpartneraUnpinnedTabAreaBottom.TabIndex = 110;
            // 
            // _frmprometpartneraAutoHideControl
            // 
            this._frmprometpartneraAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._frmprometpartneraAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._frmprometpartneraAutoHideControl.Name = "_frmprometpartneraAutoHideControl";
            this._frmprometpartneraAutoHideControl.Owner = this.UltraDockManager1;
            this._frmprometpartneraAutoHideControl.Size = new System.Drawing.Size(0, 0);
            this._frmprometpartneraAutoHideControl.TabIndex = 111;
            // 
            // WindowDockingArea2
            // 
            this.WindowDockingArea2.Controls.Add(this.DockableWindow2);
            this.WindowDockingArea2.Dock = System.Windows.Forms.DockStyle.Top;
            this.WindowDockingArea2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea2.Location = new System.Drawing.Point(0, 0);
            this.WindowDockingArea2.Name = "WindowDockingArea2";
            this.WindowDockingArea2.Owner = this.UltraDockManager1;
            this.WindowDockingArea2.Size = new System.Drawing.Size(792, 300);
            this.WindowDockingArea2.TabIndex = 113;
            // 
            // DockableWindow2
            // 
            this.DockableWindow2.Controls.Add(this.UltraGroupBox1);
            this.DockableWindow2.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow2.Name = "DockableWindow2";
            this.DockableWindow2.Owner = this.UltraDockManager1;
            this.DockableWindow2.Size = new System.Drawing.Size(792, 295);
            this.DockableWindow2.TabIndex = 115;
            // 
            // RPV
            // 
            this.RPV.ActiveViewIndex = -1;
            this.RPV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RPV.Cursor = System.Windows.Forms.Cursors.Default;
            this.RPV.DisplayBackgroundEdge = false;
            this.RPV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RPV.Location = new System.Drawing.Point(0, 300);
            this.RPV.Name = "RPV";
            this.RPV.Size = new System.Drawing.Size(792, 184);
            this.RPV.TabIndex = 114;
            this.RPV.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // cbkPartnerUcenik
            // 
            this.cbkPartnerUcenik.AutoSize = true;
            this.cbkPartnerUcenik.BackColor = System.Drawing.Color.Transparent;
            this.cbkPartnerUcenik.Location = new System.Drawing.Point(292, 24);
            this.cbkPartnerUcenik.Name = "cbkPartnerUcenik";
            this.cbkPartnerUcenik.Size = new System.Drawing.Size(103, 17);
            this.cbkPartnerUcenik.TabIndex = 19;
            this.cbkPartnerUcenik.Text = "Partneri/Učenici";
            this.cbkPartnerUcenik.UseVisualStyleBackColor = false;
            // 
            // PrometPartneraSmartPart
            // 
            this.Controls.Add(this._frmprometpartneraAutoHideControl);
            this.Controls.Add(this.RPV);
            this.Controls.Add(this.WindowDockingArea2);
            this.Controls.Add(this._frmprometpartneraUnpinnedTabAreaTop);
            this.Controls.Add(this._frmprometpartneraUnpinnedTabAreaBottom);
            this.Controls.Add(this._frmprometpartneraUnpinnedTabAreaLeft);
            this.Controls.Add(this._frmprometpartneraUnpinnedTabAreaRight);
            this.Name = "PrometPartneraSmartPart";
            this.Size = new System.Drawing.Size(792, 484);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).EndInit();
            this.UltraGroupBox1.ResumeLayout(false);
            this.UltraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmboIDkontozavrsni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KontoDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboIDkontopocetni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboIDOJ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrgjedDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboIDMT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MjestotroskaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboOdPartner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartnerDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboDoPartner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboPartnerAktivnost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AktivnostDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doDatuma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.odDatuma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MjestotroskaDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KontoDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).EndInit();
            this.WindowDockingArea2.ResumeLayout(false);
            this.DockableWindow2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void Ispisi()
        {
            this.BackgroundUpdate();
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - Promet po partnerima",
                Description = "Pregled izvještaja - Promet po partnerima",
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

        [LocalCommandHandler("Kreiraj")]
        public void KreirajHandler(object sender, EventArgs e)
        {
            this.Ispisi();
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
                    return true;

                case Keys.Escape:
                    this.ParentForm.Close();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void PrometPartneraSmartPart_Load(object sender, EventArgs e)
        {
            this.POCETNI = mipsed.application.framework.Application.Pocetni;
            this.ZAVRSNI = mipsed.application.framework.Application.Zavrsni;
            this.odDatuma.Value = this.POCETNI;
            this.doDatuma.Value = this.ZAVRSNI;
            InfraCustom.InicijalizirajCombo(this.cmboOdPartner, null, false, false);
            InfraCustom.InicijalizirajCombo(this.cmboDoPartner, null, false, false);
            InfraCustom.InicijalizirajCombo(this.cmboPartnerAktivnost, null);
            InfraCustom.InicijalizirajCombo(this.cmboIDkontopocetni, null);
            InfraCustom.InicijalizirajCombo(this.cmboIDkontozavrsni, null);
            InfraCustom.InicijalizirajCombo(this.cmboIDOJ, null);
            InfraCustom.InicijalizirajCombo(this.cmboIDMT, null);
            InfraCustom.PostaviEnterUTabSvimEditKontrolama(this);
            InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
        }

        private AutoHideControl _frmprometpartneraAutoHideControl;

        private UnpinnedTabArea _frmprometpartneraUnpinnedTabAreaBottom;

        private UnpinnedTabArea _frmprometpartneraUnpinnedTabAreaLeft;

        private UnpinnedTabArea _frmprometpartneraUnpinnedTabAreaRight;

        private UnpinnedTabArea _frmprometpartneraUnpinnedTabAreaTop;

        private AKTIVNOSTDataSet AktivnostDataSet1;

        private CheckBox CheckBox1;

        private UltraCombo cmboDoPartner;

        private UltraCombo cmboIDkontopocetni;

        private UltraCombo cmboIDkontozavrsni;

        private UltraCombo cmboIDMT;

        private UltraCombo cmboIDOJ;

        private UltraCombo cmboOdPartner;

        private UltraCombo cmboPartnerAktivnost;

        [CreateNew]
        public RSmObrazacController Controller { get; set; }

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

        private DockableWindow DockableWindow2;

        private UltraDateTimeEditor doDatuma;

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

        private KONTODataSet KontoDataSet2;

        private Label Label1;

        private Label Label11;

        private Label Label12;

        private Label Label13;

        private Label Label14;

        private Label Label2;

        private Label Label3;

        private Label Label5;

        private Label Label6;

        private MJESTOTROSKADataSet MjestotroskaDataSet1;

        private MJESTOTROSKADataSet MjestotroskaDataSet2;

        private UltraDateTimeEditor odDatuma;

        private ORGJEDDataSet OrgjedDataSet1;

        private PARTNERDataSet PartnerDataSet1;

        private CrystalReportViewer RPV;

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


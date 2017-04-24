using CrystalDecisions.CrystalReports.Engine;
using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.Workspaces;
using FinPosModule;
using FinPosModule.Fin.WorkItems;
using FinPosModule.NetAdvantage.WorkItems;
using FinPosModule.Plan;
using FinPosModule.Zatvaranje;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.EventBroker;
using Microsoft.VisualBasic.CompilerServices;
using NetAdvantage.WorkItems;
using mipsed.application.framework;
using Placa;
using System;
using System.Windows.Forms;
using NetAdvantage.Controllers;
using System.Data;
using System.Data.SqlClient;
using FinPosModule.ZatvaranjeBolnice;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using System.Linq;

namespace FinPosModule.FinPosModule
{
    public class MainController : Controller
    {
        [CommandHandler("Finpos.BilancaCommand")]
        public void BilancaCommand(object sender, EventArgs e)
        {
            BilancaWorkItem item = this.WorkItem.Items.Get<BilancaWorkItem>("Finpos.Bilanca");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<BilancaWorkItem>("Finpos.Bilanca");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Finpos.BLGUser")]
        public void BLGUserCommand(object sender, EventArgs e)
        {
            BlagajnaWorkItemUser user = this.WorkItem.Items.Get<BlagajnaWorkItemUser>("Fin.BLGUser");
            if (user == null)
            {
                user = this.WorkItem.Items.AddNew<BlagajnaWorkItemUser>("Fin.BLGUser");
            }
            user.Show(user.Workspaces["main"]);
        }

        [CommandHandler("Finpos.DnevnikCommand")]
        public void DnevnikKnjizenjaCommand(object sender, EventArgs e)
        {
            DnevnikKnjizenjaWorkItem item = this.WorkItem.Items.Get<DnevnikKnjizenjaWorkItem>("Finpos.Dnevnik");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<DnevnikKnjizenjaWorkItem>("Finpos.Dnevnik");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Finpos.DOKUMENT")]
        public void DOKUMENTCommand(object sender, EventArgs e)
        {
            DOKUMENTWorkWithWorkItem item = this.WorkItem.Items.Get<DOKUMENTWorkWithWorkItem>("Placa.DOKUMENT");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<DOKUMENTWorkWithWorkItem>("Placa.DOKUMENT");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Finpos.Plan")]
        public void FinposPlanCommand(object sender, EventArgs e)
        {
            PlanCustomCustomWorkItem item = this.WorkItem.Items.Get<PlanCustomCustomWorkItem>("Finpos.Plan");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PlanCustomCustomWorkItem>("Finpos.Plan");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Finpos.GKUser")]
        public void GKUserCommand(object sender, EventArgs e)
        {
            GKWorkItem item = this.WorkItem.Items.Get<GKWorkItem>("Fin.GKWorkItem");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<GKWorkItem>("Fin.GKWorkItem");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Finpos.IraUser")]
        public void IraUserCommand(object sender, EventArgs e)
        {
            IraUserWorkItem item = this.WorkItem.Items.Get<IraUserWorkItem>("Fin.IraUser");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<IraUserWorkItem>("Fin.IraUser");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Finpos.IRAVRSTAIZNOSACommand")]
        public void IRAVRSTAIZNOSACommand(object sender, EventArgs e)
        {
            IRAVRSTAIZNOSAWorkWithWorkItem item = this.WorkItem.Items.Get<IRAVRSTAIZNOSAWorkWithWorkItem>("Finpos.IRAVRSTAIZNOSA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<IRAVRSTAIZNOSAWorkWithWorkItem>("Finpos.IRAVRSTAIZNOSA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Finpos.KontniPlan")]
        public void IspisKontnogPlanaCommand(object sender, EventArgs e)
        {
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - Kontni plan!",
                Description = "Pregled izvještaja - Kontni plan!",
                Icon = ImageResourcesNew.mbs
            };
            ReportDocument document = new ReportDocument();
            document.Load(System.Windows.Forms.Application.StartupPath + @"\FinposIzvjestaji\rptKontniPlan.rpt");
            KONTODataAdapter adapter = new KONTODataAdapter();
            KONTODataSet dataSet = new KONTODataSet();
            adapter.Fill(dataSet);
            document.SetDataSource(dataSet);
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            PreviewReportWorkItem item = this.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            item.Izvjestaj = document;
            item.Show(item.Workspaces["main"], info);
        }

        [CommandHandler("Finpos.Partneri")]
        public void IspisPartneraCommand(object sender, EventArgs e)
        {
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - Partneri!",
                Description = "Pregled izvještaja - Partneri!",
                Icon = ImageResourcesNew.mbs
            };
            ReportDocument document = new ReportDocument();
            document.Load(System.Windows.Forms.Application.StartupPath + @"\FinposIzvjestaji\rptpartneri.rpt");
            PARTNERDataAdapter adapter = new PARTNERDataAdapter();
            PARTNERDataSet dataSet = new PARTNERDataSet();
            adapter.Fill(dataSet);
            document.SetDataSource(dataSet);
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            PreviewReportWorkItem item = this.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            item.Izvjestaj = document;
            item.Show(item.Workspaces["main"], info);
        }

        [CommandHandler("Finpos.JediniceMjere")]
        public void JediniceMjere(object sender, EventArgs e)
        {
            JEDINICAMJEREWorkWithWorkItem item = this.WorkItem.Items.Get<JEDINICAMJEREWorkWithWorkItem>("Finpos.JediniceMjereC");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<JEDINICAMJEREWorkWithWorkItem>("Finpos.JediniceMjereC");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Finpos.KarticeCommand")]
        public void KarticeCommand(object sender, EventArgs e)
        {
            KarticePartneraWorkItem item = this.WorkItem.Items.Get<KarticePartneraWorkItem>("Finpos.Kartice");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<KarticePartneraWorkItem>("Finpos.Kartice");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Finpos.KONTO")]
        public void KONTOCommand(object sender, EventArgs e)
        {
            KONTOWorkWithWorkItem item = this.WorkItem.Items.Get<KONTOWorkWithWorkItem>("Placa.KONTO");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<KONTOWorkWithWorkItem>("Placa.KONTO");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Finpos.KontoKarticeCommand")]
        public void KontoKarticeCommand(object sender, EventArgs e)
        {
            KontoKarticeWorkItem item = this.WorkItem.Items.Get<KontoKarticeWorkItem>("Finpos.KontoKartice");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<KontoKarticeWorkItem>("Finpos.KontoKartice");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Finpos.MT")]
        public void MJESTOTROSKACommand(object sender, EventArgs e)
        {
            MJESTOTROSKAWorkWithWorkItem item = this.WorkItem.Items.Get<MJESTOTROSKAWorkWithWorkItem>("Placa.MJESTOTROSKA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<MJESTOTROSKAWorkWithWorkItem>("Placa.MJESTOTROSKA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [EventSubscription("topic://NetAdvantage/OpenBusinessComponent")]
        public void OpenComponent(object sender, OpenComponentEventArgs args)
        {
            switch (args.ComponentName)
            {
                case "AKTIVNOST":
                    this.WorkItem.Items.AddNew<AKTIVNOSTWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "BANKE":
                    this.WorkItem.Items.AddNew<BANKEWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "BENEFICIRANI":
                    this.WorkItem.Items.AddNew<BENEFICIRANIWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "BLAGAJNA":
                    this.WorkItem.Items.AddNew<BLAGAJNAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "BLGVRSTEDOK":
                    this.WorkItem.Items.AddNew<BLGVRSTEDOKWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "BOLOVANJEFOND":
                    this.WorkItem.Items.AddNew<BOLOVANJEFONDWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "BRACNOSTANJE":
                    this.WorkItem.Items.AddNew<BRACNOSTANJEWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "DDIZDATAK":
                    this.WorkItem.Items.AddNew<DDIZDATAKWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "DDKATEGORIJA":
                    this.WorkItem.Items.AddNew<DDKATEGORIJAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "DDKOLONAIDD":
                    this.WorkItem.Items.AddNew<DDKOLONAIDDWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "DDOBRACUN":
                    this.WorkItem.Items.AddNew<DDOBRACUNWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "DDRADNIK":
                    this.WorkItem.Items.AddNew<DDRADNIKWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "DDVRSTEPOSLA":
                    this.WorkItem.Items.AddNew<DDVRSTEPOSLAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "DOKUMENT":
                    this.WorkItem.Items.AddNew<DOKUMENTWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "DOPRINOS":
                    this.WorkItem.Items.AddNew<DOPRINOSWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "DOSIPZAGLAVLJE":
                    this.WorkItem.Items.AddNew<DOSIPZAGLAVLJEWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "ELEMENT":
                    this.WorkItem.Items.AddNew<ELEMENTWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "FINPOREZ":
                    this.WorkItem.Items.AddNew<FINPOREZWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "GKSTAVKA":
                    this.WorkItem.Items.AddNew<GKSTAVKAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "GODINE":
                    this.WorkItem.Items.AddNew<GODINEWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "GRUPEKOEF":
                    this.WorkItem.Items.AddNew<GRUPEKOEFWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "GRUPEOLAKSICA":
                    this.WorkItem.Items.AddNew<GRUPEOLAKSICAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "IPIDENT":
                    this.WorkItem.Items.AddNew<IPIDENTWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "IRA":
                    this.WorkItem.Items.AddNew<IRAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "IRAVRSTAIZNOSA":
                    this.WorkItem.Items.AddNew<IRAVRSTAIZNOSAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "IZVORDOKUMENTA":
                    this.WorkItem.Items.AddNew<IZVORDOKUMENTAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "JEDINICAMJERE":
                    this.WorkItem.Items.AddNew<JEDINICAMJEREWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "KONTO":
                    this.WorkItem.Items.AddNew<KONTOWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "KORISNIK":
                    this.WorkItem.Items.AddNew<KORISNIKWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "KREDITOR":
                    this.WorkItem.Items.AddNew<KREDITORWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "KRIZNIPOREZ":
                    this.WorkItem.Items.AddNew<KRIZNIPOREZWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "MJESTOTROSKA":
                    this.WorkItem.Items.AddNew<MJESTOTROSKAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "MZOSTABLICE":
                    this.WorkItem.Items.AddNew<MZOSTABLICEWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "OBRACUN":
                    this.WorkItem.Items.AddNew<OBRACUNWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "OBUSTAVA":
                    this.WorkItem.Items.AddNew<OBUSTAVAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "OLAKSICE":
                    this.WorkItem.Items.AddNew<OLAKSICEWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "OPCINA":
                    this.WorkItem.Items.AddNew<OPCINAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "ORGDIO":
                    this.WorkItem.Items.AddNew<ORGDIOWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "ORGJED":
                    this.WorkItem.Items.AddNew<ORGJEDWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "OSNOVAOSIGURANJA":
                    this.WorkItem.Items.AddNew<OSNOVAOSIGURANJAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "OSOBNIODBITAK":
                    this.WorkItem.Items.AddNew<OSOBNIODBITAKWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "PARTNER":
                    this.WorkItem.Items.AddNew<PARTNERWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "POREZ":
                    this.WorkItem.Items.AddNew<POREZWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "PROIZVOD":
                    this.WorkItem.Items.AddNew<PROIZVODWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "PRPLACE":
                    this.WorkItem.Items.AddNew<PRPLACEWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "RACUN":
                    this.WorkItem.Items.AddNew<RACUNWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "RADNIK":
                    this.WorkItem.Items.AddNew<RADNIKWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "RADNOMJESTO":
                    this.WorkItem.Items.AddNew<RADNOMJESTOWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "RSMA":
                    this.WorkItem.Items.AddNew<RSMAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "RSVRSTEOBRACUNA":
                    this.WorkItem.Items.AddNew<RSVRSTEOBRACUNAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "RSVRSTEOBVEZNIKA":
                    this.WorkItem.Items.AddNew<RSVRSTEOBVEZNIKAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "SHEMAIRA":
                    this.WorkItem.Items.AddNew<SHEMAIRAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "SHEMAURA":
                    this.WorkItem.Items.AddNew<SHEMAURAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "SKUPPOREZAIDOPRINOSA":
                    this.WorkItem.Items.AddNew<SKUPPOREZAIDOPRINOSAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "SPOL":
                    this.WorkItem.Items.AddNew<SPOLWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "STRANEKNJIZENJA":
                    this.WorkItem.Items.AddNew<STRANEKNJIZENJAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "STRUCNASPREMA":
                    this.WorkItem.Items.AddNew<STRUCNASPREMAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "STRUKA":
                    this.WorkItem.Items.AddNew<STRUKAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "TIPDOKUMENTA":
                    this.WorkItem.Items.AddNew<TIPDOKUMENTAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "TIPIRA":
                    this.WorkItem.Items.AddNew<TIPIRAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "TIPIZNOSA":
                    this.WorkItem.Items.AddNew<TIPIZNOSAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "TIPOLAKSICE":
                    this.WorkItem.Items.AddNew<TIPOLAKSICEWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "TIPURA":
                    this.WorkItem.Items.AddNew<TIPURAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "TITULA":
                    this.WorkItem.Items.AddNew<TITULAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "URA":
                    this.WorkItem.Items.AddNew<URAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "URAVRSTAIZNOSA":
                    this.WorkItem.Items.AddNew<URAVRSTAIZNOSAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "VALUTE":
                    this.WorkItem.Items.AddNew<VALUTEWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "VERZIJA":
                    this.WorkItem.Items.AddNew<VERZIJAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "VIRMANI":
                    this.WorkItem.Items.AddNew<VIRMANIWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "VRSTADOPRINOS":
                    this.WorkItem.Items.AddNew<VRSTADOPRINOSWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "VRSTAELEMENT":
                    this.WorkItem.Items.AddNew<VRSTAELEMENTWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "VRSTAOBUSTAVE":
                    this.WorkItem.Items.AddNew<VRSTAOBUSTAVEWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "ZATVARANJA":
                    this.WorkItem.Items.AddNew<ZATVARANJAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;
            }
        }

        [CommandHandler("Finpos.ORGJED")]
        public void ORGJEDCommand(object sender, EventArgs e)
        {
            ORGJEDWorkWithWorkItem item = this.WorkItem.Items.Get<ORGJEDWorkWithWorkItem>("Placa.ORGJED");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<ORGJEDWorkWithWorkItem>("Placa.ORGJED");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Finpos.OtvoreneCommand")]
        public void OtvoreneCommand(object sender, EventArgs e)
        {
            OtvoreneIspisWorkItem item = this.WorkItem.Items.Get<OtvoreneIspisWorkItem>("Finpos.Otvorene");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<OtvoreneIspisWorkItem>("Finpos.Otvorene");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Finpos.PARTNER")]
        public void PARTNERCommand(object sender, EventArgs e)
        {
            PARTNERWorkWithWorkItem item = this.WorkItem.Items.Get<PARTNERWorkWithWorkItem>("Placa.PARTNER");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PARTNERWorkWithWorkItem>("Placa.PARTNER");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Finpos.Porezi")]
        public void Porezi(object sender, EventArgs e)
        {
            FINPOREZWorkWithWorkItem item = this.WorkItem.Items.Get<FINPOREZWorkWithWorkItem>("Finpos.PoreziC");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<FINPOREZWorkWithWorkItem>("Finpos.PoreziC");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Finpos.Proizvodi")]
        public void Proizvodi(object sender, EventArgs e)
        {
            PROIZVODWorkWithWorkItem item = this.WorkItem.Items.Get<PROIZVODWorkWithWorkItem>("Finpos.ProizvodiC");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PROIZVODWorkWithWorkItem>("Finpos.ProizvodiC");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Finpos.PrometPartneraCommand")]
        public void PrometPartneraCommand(object sender, EventArgs e)
        {
            PrometPartneraWorkItem item = this.WorkItem.Items.Get<PrometPartneraWorkItem>("Finpos.PrometPartnera");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PrometPartneraWorkItem>("Finpos.PrometPartnera");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Finpos.Opomene")]
        public void OpomeneCommand(object sender, EventArgs e)
        {
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
            {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - Opomene",
                Description = "Pregled izvještaja - Opomene"
            };
            ReportDocument rpt = new ReportDocument();
            rpt.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\crpOpomene.rpt");

            Mipsed7.DataAccessLayer.SqlClient conn = new Mipsed7.DataAccessLayer.SqlClient();
            try
            {
                ConnectionInfo connInfo = new ConnectionInfo();
                connInfo.ServerName = Mipsed7.Core.ApplicationDatabaseInformation.ServerName;
                connInfo.DatabaseName = Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName;
                connInfo.UserID = Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName;
                connInfo.Password = Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword;

                TableLogOnInfo tableLogOnInfo = new TableLogOnInfo();
                tableLogOnInfo.ConnectionInfo = connInfo;

                foreach (Table table in rpt.Database.Tables)
                {
                    table.ApplyLogOnInfo(tableLogOnInfo);
                    table.LogOnInfo.ConnectionInfo.ServerName = connInfo.ServerName;
                    table.LogOnInfo.ConnectionInfo.DatabaseName = connInfo.DatabaseName;
                    table.LogOnInfo.ConnectionInfo.UserID = connInfo.UserID;
                    table.LogOnInfo.ConnectionInfo.Password = connInfo.Password;
                }
            }
            catch (Exception exp) { MessageBox.Show(exp.Message); }

            frmOpomene objekt = new frmOpomene();

            if (objekt.ShowDialog() == DialogResult.OK)
            {
                DataSet ds = new DataSet("Opomene");
                SqlCommand sqlComm = new SqlCommand("sp_Opomene", conn.sqlConnection);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@IDPARTNER", frmOpomene.id_partnera);
                sqlComm.Parameters.AddWithValue("@godina", mipsed.application.framework.Application.ActiveYear);
                sqlComm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    rpt.SetDataSource(ds);
                    rpt.SetParameterValue("@IDPARTNER", frmOpomene.id_partnera);
                    rpt.SetParameterValue("@godina", mipsed.application.framework.Application.ActiveYear);

                    ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                    PreviewReportWorkItem item = this.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                    if (item == null)
                    {
                        item = this.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                    }
                    item.Izvjestaj = rpt;
                    item.Show(item.Workspaces["main"], info);
                }
                else
                {
                    MessageBox.Show("Za odabranog partnera ne postoji dugovanje.");
                }
            }
        }

        [CommandHandler("Finpos.PrometPoKontimaCommand")]
        public void PrometPoKontimaCommand(object sender, EventArgs e)
        {
            PrometPoKontimaWorkItem item = this.WorkItem.Items.Get<PrometPoKontimaWorkItem>("Finpos.PrometPoKontima");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PrometPoKontimaWorkItem>("Finpos.PrometPoKontima");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Finpos.FinaObrasci")]
        public void ProracunObrasciCommand(object sender, EventArgs e)
        {
            ProracunWorkItem item = this.WorkItem.Items.Get<ProracunWorkItem>("Finpos.ProracunObrasci");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<ProracunWorkItem>("Finpos.ProracunObrasci");
            }
            item.Show(item.Workspaces["main"]);
        }


        [CommandHandler("Finpos.Zaposleni")]
        public void CommandZaposleni(object sender, EventArgs e)
        {
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
            {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - Zaposleni",
                Description = "Pregled izvještaja - Zaposleni"
            };
            ReportDocument rpt = new ReportDocument();
            rpt.Load(System.Windows.Forms.Application.StartupPath + @"\MBSReport\Zaposleni.rpt");

            Mipsed7.DataAccessLayer.SqlClient conn = new Mipsed7.DataAccessLayer.SqlClient();
            try
            {
                ConnectionInfo connInfo = new ConnectionInfo();
                connInfo.ServerName = Mipsed7.Core.ApplicationDatabaseInformation.ServerName;
                connInfo.DatabaseName = Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName;
                connInfo.UserID = Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName;
                connInfo.Password = Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword;

                TableLogOnInfo tableLogOnInfo = new TableLogOnInfo();
                tableLogOnInfo.ConnectionInfo = connInfo;

                foreach (Table table in rpt.Database.Tables)
                {
                    table.ApplyLogOnInfo(tableLogOnInfo);
                    table.LogOnInfo.ConnectionInfo.ServerName = connInfo.ServerName;
                    table.LogOnInfo.ConnectionInfo.DatabaseName = connInfo.DatabaseName;
                    table.LogOnInfo.ConnectionInfo.UserID = connInfo.UserID;
                    table.LogOnInfo.ConnectionInfo.Password = connInfo.Password;
                }
            }
            catch (Exception exp) { MessageBox.Show(exp.Message); }

            DataSet ds = new DataSet("Zaposleni");
            SqlCommand sqlComm = new SqlCommand("spZaposleni", conn.sqlConnection);
            sqlComm.CommandType = CommandType.StoredProcedure;
            //sqlComm.Parameters.AddWithValue("@IDPARTNER", frmOpomene.id_partnera);
            //sqlComm.Parameters.AddWithValue("@godina", mipsed.application.framework.Application.ActiveYear);
            sqlComm.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlComm;
            da.Fill(ds);

            rpt.SetDataSource(ds);
            //rpt.SetParameterValue("@IDPARTNER", frmOpomene.id_partnera);
            //rpt.SetParameterValue("@godina", mipsed.application.framework.Application.ActiveYear);

            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            PreviewReportWorkItem item = this.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            item.Izvjestaj = rpt;
            item.Show(item.Workspaces["main"], info);
        }

        [CommandHandler("Finpos.ObvezeNaDan60")]
        public void CommandObvezeNaDan60(object sender, EventArgs e)
        {
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
            {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - Obveze 60",
                Description = "Pregled izvještaja - Obveze 60"
            };
            ReportDocument rpt = new ReportDocument();
            rpt.Load(System.Windows.Forms.Application.StartupPath + @"\MBSReport\ObvezeNaDan60.rpt");

            Mipsed7.DataAccessLayer.SqlClient conn = new Mipsed7.DataAccessLayer.SqlClient();

            try
            {
                ConnectionInfo connInfo = new ConnectionInfo();
                connInfo.ServerName = Mipsed7.Core.ApplicationDatabaseInformation.ServerName;
                connInfo.DatabaseName = Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName;
                connInfo.UserID = Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName;
                connInfo.Password = Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword;

                TableLogOnInfo tableLogOnInfo = new TableLogOnInfo();
                tableLogOnInfo.ConnectionInfo = connInfo;

                foreach (Table table in rpt.Database.Tables)
                {
                    table.ApplyLogOnInfo(tableLogOnInfo);
                    table.LogOnInfo.ConnectionInfo.ServerName = connInfo.ServerName;
                    table.LogOnInfo.ConnectionInfo.DatabaseName = connInfo.DatabaseName;
                    table.LogOnInfo.ConnectionInfo.UserID = connInfo.UserID;
                    table.LogOnInfo.ConnectionInfo.Password = connInfo.Password;
                }
            }
            catch (Exception exp) { MessageBox.Show(exp.Message); }                        

            frmDatumObvezePotrazivanja objekt = new frmDatumObvezePotrazivanja();

            if (objekt.ShowDialog() == DialogResult.OK)
            {
                DataSet ds = new DataSet("Obveze60");
                SqlCommand sqlComm = new SqlCommand("spObvezeNaDan60", conn.sqlConnection);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@datum", frmDatumObvezePotrazivanja.datum);
                sqlComm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;
                da.Fill(ds);

                rpt.SetDataSource(ds);
                rpt.SetParameterValue("@datum", frmDatumObvezePotrazivanja.datum);

                ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                PreviewReportWorkItem item = this.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                if (item == null)
                {
                    item = this.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                }
                item.Izvjestaj = rpt;
                item.Show(item.Workspaces["main"], info);
            }
        }


        [CommandHandler("Finpos.PotrazivanjaNaDan60")]
        public void CommandPotrazivanjaNaDan60(object sender, EventArgs e)
        {
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
            {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - Potrazivanja 60",
                Description = "Pregled izvještaja - Potrazivanja 60"
            };
            ReportDocument rpt = new ReportDocument();
            rpt.Load(System.Windows.Forms.Application.StartupPath + @"\MBSReport\PotrazivanjaNaDan60.rpt");

            Mipsed7.DataAccessLayer.SqlClient conn = new Mipsed7.DataAccessLayer.SqlClient();
            try
            {
                ConnectionInfo connInfo = new ConnectionInfo();
                connInfo.ServerName = Mipsed7.Core.ApplicationDatabaseInformation.ServerName;
                connInfo.DatabaseName = Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName;
                connInfo.UserID = Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName;
                connInfo.Password = Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword;

                TableLogOnInfo tableLogOnInfo = new TableLogOnInfo();
                tableLogOnInfo.ConnectionInfo = connInfo;

                foreach (Table table in rpt.Database.Tables)
                {
                    table.ApplyLogOnInfo(tableLogOnInfo);
                    table.LogOnInfo.ConnectionInfo.ServerName = connInfo.ServerName;
                    table.LogOnInfo.ConnectionInfo.DatabaseName = connInfo.DatabaseName;
                    table.LogOnInfo.ConnectionInfo.UserID = connInfo.UserID;
                    table.LogOnInfo.ConnectionInfo.Password = connInfo.Password;
                }
            }
            catch (Exception exp) { MessageBox.Show(exp.Message); }

            frmDatumObvezePotrazivanja objekt = new frmDatumObvezePotrazivanja();

            if (objekt.ShowDialog() == DialogResult.OK)
            {
                DataSet ds = new DataSet("Potrazivanje60");
                SqlCommand sqlComm = new SqlCommand("spPotrazivanjaNaDan60", conn.sqlConnection);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@datum", frmDatumObvezePotrazivanja.datum);
                sqlComm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;
                da.Fill(ds);

                rpt.SetDataSource(ds);
                rpt.SetParameterValue("@datum", frmDatumObvezePotrazivanja.datum);
                rpt.SetParameterValue("Datum", frmDatumObvezePotrazivanja.datum);

                ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                PreviewReportWorkItem item = this.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                if (item == null)
                {
                    item = this.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                }
                item.Izvjestaj = rpt;
                item.Show(item.Workspaces["main"], info);
            }
        }

        [CommandHandler("Finpos.PokazateljiMjesecni")]
        public void CommandPokazateljiMjesecni(object sender, EventArgs e)
        {
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
            {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - Pokazatelji mjesečni",
                Description = "Pregled izvještaja - Pokazatelji mjesečni"
            };
            ReportDocument rpt = new ReportDocument();
            rpt.Load(System.Windows.Forms.Application.StartupPath + @"\MBSReport\PokazateljiFinPos.rpt");

            Mipsed7.DataAccessLayer.SqlClient conn = new Mipsed7.DataAccessLayer.SqlClient();
            try
            {
                ConnectionInfo connInfo = new ConnectionInfo();
                connInfo.ServerName = Mipsed7.Core.ApplicationDatabaseInformation.ServerName;
                connInfo.DatabaseName = Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName;
                connInfo.UserID = Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName;
                connInfo.Password = Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword;

                TableLogOnInfo tableLogOnInfo = new TableLogOnInfo();
                tableLogOnInfo.ConnectionInfo = connInfo;

                foreach (Table table in rpt.Database.Tables)
                {
                    table.ApplyLogOnInfo(tableLogOnInfo);
                    table.LogOnInfo.ConnectionInfo.ServerName = connInfo.ServerName;
                    table.LogOnInfo.ConnectionInfo.DatabaseName = connInfo.DatabaseName;
                    table.LogOnInfo.ConnectionInfo.UserID = connInfo.UserID;
                    table.LogOnInfo.ConnectionInfo.Password = connInfo.Password;
                }
            }
            catch (Exception exp) { MessageBox.Show(exp.Message); }

            frmPokazateljMjesecno objekt = new frmPokazateljMjesecno();

            if (objekt.ShowDialog() == DialogResult.OK)
            {
                DataSet ds = new DataSet("PokazateljMjesecni");
                SqlCommand sqlComm = new SqlCommand("spPokazatelji", conn.sqlConnection);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@datumOd", frmPokazateljMjesecno.datumOd);
                sqlComm.Parameters.AddWithValue("@datumDo", frmPokazateljMjesecno.datumDo);

                sqlComm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;
                da.Fill(ds);

                rpt.SetDataSource(ds);
                rpt.SetParameterValue("@datumDo", frmPokazateljMjesecno.datumDo);
                rpt.SetParameterValue("@datumOd", frmPokazateljMjesecno.datumOd);
                rpt.SetParameterValue("Vrsta", "MJESEČNI");
                rpt.SetParameterValue("Razdoblje", string.Format("MJESEC {0}/{1}", frmPokazateljMjesecno.datumOd.Month, frmPokazateljMjesecno.datumOd.Year));

                ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                PreviewReportWorkItem item = this.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                if (item == null)
                {
                    item = this.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                }
                item.Izvjestaj = rpt;
                item.Show(item.Workspaces["main"], info);
            }
        }

        [CommandHandler("Finpos.PokazateljiPeriodicni")]
        public void CommandPokazateljiPeriodicni(object sender, EventArgs e)
        {
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
            {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - Pokazatelji periodični",
                Description = "Pregled izvještaja - pokazatelji periodični"
            };
            ReportDocument rpt = new ReportDocument();
            rpt.Load(System.Windows.Forms.Application.StartupPath + @"\MBSReport\PokazateljiFinPos.rpt");

            Mipsed7.DataAccessLayer.SqlClient conn = new Mipsed7.DataAccessLayer.SqlClient();
            try
            {
                ConnectionInfo connInfo = new ConnectionInfo();
                connInfo.ServerName = Mipsed7.Core.ApplicationDatabaseInformation.ServerName;
                connInfo.DatabaseName = Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName;
                connInfo.UserID = Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName;
                connInfo.Password = Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword;

                TableLogOnInfo tableLogOnInfo = new TableLogOnInfo();
                tableLogOnInfo.ConnectionInfo = connInfo;

                foreach (Table table in rpt.Database.Tables)
                {
                    table.ApplyLogOnInfo(tableLogOnInfo);
                    table.LogOnInfo.ConnectionInfo.ServerName = connInfo.ServerName;
                    table.LogOnInfo.ConnectionInfo.DatabaseName = connInfo.DatabaseName;
                    table.LogOnInfo.ConnectionInfo.UserID = connInfo.UserID;
                    table.LogOnInfo.ConnectionInfo.Password = connInfo.Password;
                }
            }
            catch (Exception exp) { MessageBox.Show(exp.Message); }

            frmPokazateljRazdoblje objekt = new frmPokazateljRazdoblje();

            if (objekt.ShowDialog() == DialogResult.OK)
            {
                DataSet ds = new DataSet("PokazateljPeriodicni");
                SqlCommand sqlComm = new SqlCommand("spPokazatelji", conn.sqlConnection);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@datumOd", frmPokazateljRazdoblje.datumOd);
                sqlComm.Parameters.AddWithValue("@datumDo", frmPokazateljRazdoblje.datumDo);
                sqlComm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;
                da.Fill(ds);

                rpt.SetDataSource(ds);
                rpt.SetParameterValue("@datumDo", frmPokazateljRazdoblje.datumDo);
                rpt.SetParameterValue("@datumOd", frmPokazateljRazdoblje.datumOd);
                rpt.SetParameterValue("Vrsta", "PERIODIČNI");
                rpt.SetParameterValue("Razdoblje", string.Format("{0} -  {1}", frmPokazateljRazdoblje.datumOd.ToString("dd.MM.yyyy"), frmPokazateljRazdoblje.datumDo.ToString("dd.MM.yyyy")));

                ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                PreviewReportWorkItem item = this.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                if (item == null)
                {
                    item = this.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                }
                item.Izvjestaj = rpt;
                item.Show(item.Workspaces["main"], info);
            }
        }

        [CommandHandler("Finpos.ObvezeNaDan")]
        public void CommandObvezeNaDan(object sender, EventArgs e)
        {
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
            {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - Obveze",
                Description = "Pregled izvještaja - Obveze"
            };
            ReportDocument rpt = new ReportDocument();
            rpt.Load(System.Windows.Forms.Application.StartupPath + @"\MBSReport\ObvezeNaDan.rpt");

            Mipsed7.DataAccessLayer.SqlClient conn = new Mipsed7.DataAccessLayer.SqlClient();

            try
            {
                ConnectionInfo connInfo = new ConnectionInfo();
                connInfo.ServerName = Mipsed7.Core.ApplicationDatabaseInformation.ServerName;
                connInfo.DatabaseName = Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName;
                connInfo.UserID = Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName;
                connInfo.Password = Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword;

                TableLogOnInfo tableLogOnInfo = new TableLogOnInfo();
                tableLogOnInfo.ConnectionInfo = connInfo;

                foreach (Table table in rpt.Database.Tables)
                {
                    table.ApplyLogOnInfo(tableLogOnInfo);
                    table.LogOnInfo.ConnectionInfo.ServerName = connInfo.ServerName;
                    table.LogOnInfo.ConnectionInfo.DatabaseName = connInfo.DatabaseName;
                    table.LogOnInfo.ConnectionInfo.UserID = connInfo.UserID;
                    table.LogOnInfo.ConnectionInfo.Password = connInfo.Password;
                }
            }
            catch (Exception exp) { MessageBox.Show(exp.Message); }

            frmDatumObvezePotrazivanja objekt = new frmDatumObvezePotrazivanja();

            if (objekt.ShowDialog() == DialogResult.OK)
            {
                DataTable ds = new DataTable("Obveze");
                SqlCommand sqlComm = new SqlCommand("spObvezeNaDan", conn.sqlConnection);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@datum", frmDatumObvezePotrazivanja.datum);
                sqlComm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;
                da.Fill(ds);

                rpt.SetDataSource(ds);
                rpt.SetParameterValue("@datum", frmDatumObvezePotrazivanja.datum);

                ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                PreviewReportWorkItem item = this.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                if (item == null)
                {
                    item = this.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                }
                item.Izvjestaj = rpt;
                item.Show(item.Workspaces["main"], info);
            }
        }

        [CommandHandler("Finpos.PotrazivanjaNaDan")]
        public void CommandPotrazivanjaNaDan(object sender, EventArgs e)
        {
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
            {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - Potrazivanja",
                Description = "Pregled izvještaja - Potrazivanja"
            };
            ReportDocument rpt = new ReportDocument();
            rpt.Load(System.Windows.Forms.Application.StartupPath + @"\MBSReport\PotrazivanjaNaDan.rpt");

            Mipsed7.DataAccessLayer.SqlClient conn = new Mipsed7.DataAccessLayer.SqlClient();
            try
            {
                ConnectionInfo connInfo = new ConnectionInfo();
                connInfo.ServerName = Mipsed7.Core.ApplicationDatabaseInformation.ServerName;
                connInfo.DatabaseName = Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName;
                connInfo.UserID = Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName;
                connInfo.Password = Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword;

                TableLogOnInfo tableLogOnInfo = new TableLogOnInfo();
                tableLogOnInfo.ConnectionInfo = connInfo;

                foreach (Table table in rpt.Database.Tables)
                {
                    table.ApplyLogOnInfo(tableLogOnInfo);
                    table.LogOnInfo.ConnectionInfo.ServerName = connInfo.ServerName;
                    table.LogOnInfo.ConnectionInfo.DatabaseName = connInfo.DatabaseName;
                    table.LogOnInfo.ConnectionInfo.UserID = connInfo.UserID;
                    table.LogOnInfo.ConnectionInfo.Password = connInfo.Password;
                }
            }
            catch (Exception exp) { MessageBox.Show(exp.Message); }

            frmDatumObvezePotrazivanja objekt = new frmDatumObvezePotrazivanja();

            if (objekt.ShowDialog() == DialogResult.OK)
            {
                DataSet ds = new DataSet("Potrazivanje");
                SqlCommand sqlComm = new SqlCommand("spPotrazivanjaNaDan", conn.sqlConnection);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@datum", frmDatumObvezePotrazivanja.datum);
                sqlComm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;
                da.Fill(ds);

                rpt.SetDataSource(ds);
                rpt.SetParameterValue("@datum", frmDatumObvezePotrazivanja.datum);
                rpt.SetParameterValue("Datum", frmDatumObvezePotrazivanja.datum);

                ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                PreviewReportWorkItem item = this.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                if (item == null)
                {
                    item = this.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                }
                item.Izvjestaj = rpt;
                item.Show(item.Workspaces["main"], info);
            }
        }

        [CommandHandler("Finpos.ObvezeDospjele60")]
        public void CommandObvezeDospjele60(object sender, EventArgs e)
        {
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
            {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - Obveze dospjele 60",
                Description = "Pregled izvještaja - Obveze dospjele 60"
            };
            ReportDocument rpt = new ReportDocument();
            rpt.Load(System.Windows.Forms.Application.StartupPath + @"\MBSReport\ObvezeDospjele60.rpt");

            Mipsed7.DataAccessLayer.SqlClient conn = new Mipsed7.DataAccessLayer.SqlClient();
            try
            {
                ConnectionInfo connInfo = new ConnectionInfo();
                connInfo.ServerName = Mipsed7.Core.ApplicationDatabaseInformation.ServerName;
                connInfo.DatabaseName = Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName;
                connInfo.UserID = Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName;
                connInfo.Password = Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword;

                TableLogOnInfo tableLogOnInfo = new TableLogOnInfo();
                tableLogOnInfo.ConnectionInfo = connInfo;

                foreach (Table table in rpt.Database.Tables)
                {
                    table.ApplyLogOnInfo(tableLogOnInfo);
                    table.LogOnInfo.ConnectionInfo.ServerName = connInfo.ServerName;
                    table.LogOnInfo.ConnectionInfo.DatabaseName = connInfo.DatabaseName;
                    table.LogOnInfo.ConnectionInfo.UserID = connInfo.UserID;
                    table.LogOnInfo.ConnectionInfo.Password = connInfo.Password;
                }
            }
            catch (Exception exp) { MessageBox.Show(exp.Message); }

            frmDatumObvezePotrazivanja objekt = new frmDatumObvezePotrazivanja();

            if (objekt.ShowDialog() == DialogResult.OK)
            {
                DataSet ds = new DataSet("Obveze60");
                SqlCommand sqlComm = new SqlCommand("spObvezeDospjele60", conn.sqlConnection);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@datum", frmDatumObvezePotrazivanja.datum);
                sqlComm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;
                da.Fill(ds);

                rpt.SetDataSource(ds);
                rpt.SetParameterValue("@datum", frmDatumObvezePotrazivanja.datum);

                ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                PreviewReportWorkItem item = this.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                if (item == null)
                {
                    item = this.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                }
                item.Izvjestaj = rpt;
                item.Show(item.Workspaces["main"], info);
            }
        }


        [CommandHandler("Finpos.OpzStat")]
        public void ProracunOPZCommand(object sender, EventArgs e)
        {
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
            {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - OPZ",
                Description = "Pregled izvještaja - OPZ"
            };
            ReportDocument rpt = new ReportDocument();
            rpt.Load(System.Windows.Forms.Application.StartupPath + @"\FinposIzvjestaji\rptOpzStat1.rpt");

            Mipsed7.DataAccessLayer.SqlClient conn = new Mipsed7.DataAccessLayer.SqlClient();
            // Set connection string from config in existing LogonProperties
            rpt.DataSourceConnections[0].SetConnection(Mipsed7.Core.ApplicationDatabaseInformation.ServerName, Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName, true);
            rpt.DataSourceConnections[0].SetLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;

            using (frmOPZ objekt = new frmOPZ())
            {
                if (objekt.ShowDialog() == DialogResult.OK)
                {
                    DataTable dtpartneri = new DataTable("OPZPartneri");
                    SqlCommand sqlComm = new SqlCommand("sp_OPZPartneri", conn.sqlConnection);
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@DatumOd", objekt.datumOd);
                    sqlComm.Parameters.AddWithValue("@DatumDo", objekt.datumDo);
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;
                    da.Fill(dtpartneri);

                    dtpartneri.Rows.Clear();

                    var Result = objekt.podaci.Rows.OfType<DataGridViewRow>().Select(
                                r => r.Cells.OfType<DataGridViewCell>().Select(c => c.Value).ToArray()).ToList();

                    Result.RemoveAt(Result.Count - 1);


                    var kupciDistinct = (from upit in Result
                                         select new
                                         {
                                             IDPARTNER = upit[2],
                                             oznakaPoreznogBroja = upit[5].ToString(),
                                             porezniBroj = upit[3].ToString(),
                                             nazivKupac = upit[4].ToString(),
                                         }).ToList().Distinct();

                    foreach (var partner in kupciDistinct)
                    {
                        dtpartneri.Rows.Add(partner.IDPARTNER, partner.porezniBroj, partner.nazivKupac, partner.oznakaPoreznogBroja);
                    }

                    DataRow korisnik = conn.GetDataTable("Select * From Korisnik").Rows[0];

                    rpt.SetDataSource(dtpartneri);

                    sqlComm = new SqlCommand("sp_OPZStavke", conn.sqlConnection);
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@DatumOd", objekt.datumOd);
                    sqlComm.Parameters.AddWithValue("@DatumDo", objekt.datumDo);
                    da.SelectCommand = sqlComm;
                    DataTable dtStavke = new DataTable();
                    da.Fill(dtStavke);

                    dtStavke.Rows.Clear();

                    foreach (var stavka in Result)
                    {
                        dtStavke.Rows.Add(stavka[6], stavka[2], stavka[7], stavka[8], stavka[9], stavka[10], stavka[11], stavka[12], stavka[13], stavka[14], stavka[15]);
                    }

                    //rpt.Subreports["PartnerRacuni"].SetDataSource(GetData(dtStavke, conn, objekt.datumOd, objekt.datumDo));
                    rpt.Subreports["PartnerRacuni"].SetDataSource(dtStavke);

                    rpt.SetParameterValue("@DatumOd", objekt.datumOd);
                    rpt.SetParameterValue("@DatumDo", objekt.datumDo);
                    rpt.SetParameterValue("UstanovaNaziv", korisnik["KORISNIK1NAZIV"].ToString());
                    rpt.SetParameterValue("UstanovaOIB", korisnik["KORISNIKOIB"].ToString());
                    rpt.SetParameterValue("UstanovaAdresa", korisnik["KORISNIK1ADRESA"].ToString() + ", " + korisnik["KORISNIK1MJESTO"].ToString());
                    rpt.SetParameterValue("UstanovaKorisnik", korisnik["KONTAKTOSOBA"].ToString());

                    rpt.SetParameterValue("IznosUkupno", GetIznosUkupno(objekt.datumOd, objekt.datumDo, conn));
                    rpt.SetParameterValue("IznosPDV", GetIznosPDV(objekt.datumOd, objekt.datumDo, conn));

                    ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                    PreviewReportWorkItem item = this.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                    if (item == null)
                    {
                        item = this.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                    }
                    item.Izvjestaj = rpt;
                    item.Show(item.Workspaces["main"], info);
                }
            }
        }

        private decimal GetIznosPDV(DateTime dateTime1, DateTime dateTime2, Mipsed7.DataAccessLayer.SqlClient conn)
        {
            DataTable tbl = conn.GetDataTable("SELECT IRA.PDV05 + IRA.PDV10 + IRA.PDV22 + IRA.PDV23 + IRA.PDV25 FROM dbo.GKSTAVKA As firstTbl " +
                "INNER JOIN dbo.KONTO ON firstTbl.IDKONTO = dbo.KONTO.IDKONTO INNER JOIN dbo.PARTNER ON firstTbl.IDPARTNER = dbo.PARTNER.IDPARTNER " +
                "Inner Join IRA On firstTbl.BROJDOKUMENTA = IRA.IRABROJ And firstTbl.GKGODIDGODINE = IRA.IRAGODIDGODINE And firstTbl.IDDOKUMENT = IRA.IRADOKIDDOKUMENT " +
                "WHERE KONTO.IDAKTIVNOST > 1 And DATEDIFF(DAY, firstTbl.GKDATUMVALUTE, '" + dateTime2.ToString("yyyy-MM-dd HH:mm:ss") + "') > 0 And PARTNER.Ucenik > 0 " +
                "And (Select ISNULL(SUM(ZATVARANJAIZNOS), 0) From ZATVARANJA Inner Join GKSTAVKA On ZATVARANJA.GK1IDGKSTAVKA = GKSTAVKA.IDGKSTAVKA " +
                "Where GKSTAVKA.DATUMDOKUMENTA <= '" + dateTime2.ToString("yyyy-MM-dd HH:mm:ss") + "' And GK2IDGKSTAVKA = firstTbl.IDGKSTAVKA) <> IRA.IRAUKUPNO And IRA.IRAGODIDGODINE = " + mipsed.application.framework.Application.ActiveYear);

            decimal ukupno = 0;

            foreach (DataRow item in tbl.Rows)
            {
                ukupno += Convert.ToDecimal(item[0]);
            }

            return ukupno;
        }

        private decimal GetIznosUkupno(DateTime dateTime1, DateTime dateTime2, Mipsed7.DataAccessLayer.SqlClient conn)
        {
            DataTable tbl = conn.GetDataTable("SELECT IRA.IRAUKUPNO FROM dbo.GKSTAVKA As firstTbl INNER JOIN dbo.KONTO ON firstTbl.IDKONTO = dbo.KONTO.IDKONTO " +
                "INNER JOIN dbo.PARTNER ON firstTbl.IDPARTNER = dbo.PARTNER.IDPARTNER Inner Join IRA On firstTbl.BROJDOKUMENTA = IRA.IRABROJ And firstTbl.GKGODIDGODINE = IRA.IRAGODIDGODINE " +
                "And firstTbl.IDDOKUMENT = IRA.IRADOKIDDOKUMENT WHERE KONTO.IDAKTIVNOST > 1 And DATEDIFF(DAY, firstTbl.GKDATUMVALUTE, '" + dateTime2.ToString("yyyy-MM-dd HH:mm:ss") + "') > 0 " +
                "And PARTNER.Ucenik > 0 And (Select ISNULL(SUM(ZATVARANJAIZNOS), 0) From ZATVARANJA Inner Join GKSTAVKA On ZATVARANJA.GK1IDGKSTAVKA = GKSTAVKA.IDGKSTAVKA " +
                "Where GKSTAVKA.DATUMDOKUMENTA <= '" + dateTime2.ToString("yyyy-MM-dd HH:mm:ss") + "' And GK2IDGKSTAVKA = firstTbl.IDGKSTAVKA) <> IRA.IRAUKUPNO And IRA.IRAGODIDGODINE = " + mipsed.application.framework.Application.ActiveYear);

            decimal ukupno = 0;

            foreach (DataRow item in tbl.Rows)
            {
                ukupno += Convert.ToDecimal(item[0]);
            }

            return ukupno;
        }

        private DataTable GetData(DataTable dsStavke, Mipsed7.DataAccessLayer.SqlClient conn, DateTime datumod, DateTime datumdo)
        {
            DataTable ds = new DataTable();
            SqlCommand sqlComm = new SqlCommand("sp_OPZStavke", conn.sqlConnection);
            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.Parameters.AddWithValue("@DatumOd", datumod);
            sqlComm.Parameters.AddWithValue("@DatumDo", datumdo);
            sqlComm.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlComm;
            da.Fill(ds);

            dsStavke.Rows.Clear();
            DataRow row;

            foreach (DataRow item in ds.Rows)
            {
                row = dsStavke.NewRow();
                row.BeginEdit();
                row["IDPARTNER"] = item["IDPARTNER"];
                row["BrojIzdanogRacuna"] = item["BrojIzdanogRacuna"];
                row["DatumIzdanogRacuna"] = item["DatumIzdanogRacuna"];
                row["ValutaPlacanja"] = item["ValutaPlacanja"];
                row["BrojDanaKasnjenja"] = item["BrojDanaKasnjenja"];
                row["IznosRacuna"] = item["IznosRacuna"];
                row["IznosPDVa"] = item["IznosPDVa"];
                row["UkupanIznosSaPDVom"] = item["UkupanIznosSaPDVom"];
                row["PlaceniIznosRacuna"] = item["PlaceniIznosRacuna"];
                row["NeplaceniDioRacuna"] = item["NeplaceniDioRacuna"]; 
                row.EndEdit();

                dsStavke.Rows.Add(row);
            }

            return dsStavke;
        }

        [CommandHandler("Finpos.RacuniCommand")]
        public void RacuniCommand(object sender, EventArgs e)
        {
            RacuniWorkItemUser user = this.WorkItem.Items.Get<RacuniWorkItemUser>("Finpos.Racuni");
            if (user == null)
            {
                user = this.WorkItem.Items.AddNew<RacuniWorkItemUser>("Finpos.Racuni");
            }
            user.Show(user.Workspaces["main"]);
        }

        [CommandHandler("Finpos.OdobrenjeCommand")]
        public void OdobrenjeCommand(object sender, EventArgs e)
        {
            OdobrenjeWorkItemUser user = this.WorkItem.Items.Get<OdobrenjeWorkItemUser>("Finpos.Odobrenje");
            if (user == null)
            {
                user = this.WorkItem.Items.AddNew<OdobrenjeWorkItemUser>("Finpos.Odobrenje");
            }
            user.Show(user.Workspaces["main"]);
        }

        [CommandHandler("Finpos.ShemaIRACommand")]
        public void SHEMAIRACommand(object sender, EventArgs e)
        {
            SHEMAIRAWorkWithWorkItem item = this.WorkItem.Items.Get<SHEMAIRAWorkWithWorkItem>("Finpos.ShemaIRA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<SHEMAIRAWorkWithWorkItem>("Finpos.ShemaIRA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Finpos.ShemaURACommand")]
        public void SHEMAURACommand(object sender, EventArgs e)
        {
            SHEMAURAWorkWithWorkItem item = this.WorkItem.Items.Get<SHEMAURAWorkWithWorkItem>("Finpos.ShemaURA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<SHEMAURAWorkWithWorkItem>("Finpos.ShemaURA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Finpos.TIPIRA")]
        public void TIPIRACommand(object sender, EventArgs e)
        {
            TIPIRAWorkWithWorkItem item = this.WorkItem.Items.Get<TIPIRAWorkWithWorkItem>("Placa.TIPIRA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<TIPIRAWorkWithWorkItem>("Placa.TIPIRA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Finpos.TIPURA")]
        public void TIPURACommand(object sender, EventArgs e)
        {
            TIPURAWorkWithWorkItem item = this.WorkItem.Items.Get<TIPURAWorkWithWorkItem>("Placa.TIPURA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<TIPURAWorkWithWorkItem>("Placa.TIPURA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Finpos.Upravljanje")]
        public void UpravljanjeCommandHandler(object sender, EventArgs e)
        {
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - Financijsko upravljanje",
                Description = "Pregled izvještaja - Financijsko upravljanje",
                Icon = ImageResourcesNew.mbs
            };
            ReportDocument rpt = new ReportDocument();
            rpt.Load(System.Windows.Forms.Application.StartupPath + @"\FinposIzvjestaji\rptFinancijskoUpravljanje.rpt");
            S_FIN_FINANCIJSKO_UPRAVLJANJEDataAdapter adapter = new S_FIN_FINANCIJSKO_UPRAVLJANJEDataAdapter();
            S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet dataSet = new S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet();
            frmParametriFakturiranja fakturiranja = new frmParametriFakturiranja("NotURA") {
                CheckBox1 = { Visible = false }
            };
            if (fakturiranja.ShowDialog() == DialogResult.OK)
            {
                adapter.Fill(dataSet, Conversions.ToDate(fakturiranja.oddatuma.Value), Conversions.ToDate(fakturiranja.dodatuma.Value));
                rpt.SetDataSource(dataSet);
                rpt.SetParameterValue("datumod", Conversions.ToDate(fakturiranja.oddatuma.Value));
                rpt.SetParameterValue("datumdo", Conversions.ToDate(fakturiranja.dodatuma.Value));
                mipsed.application.framework.Application.PostaviParametreIzvjestaja(ref rpt);
                ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                PreviewReportWorkItem item = this.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                if (item == null)
                {
                    item = this.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                }
                item.Izvjestaj = rpt;
                item.Show(item.Workspaces["main"], info);
            }
        }

        [CommandHandler("Finpos.UraUser")]
        public void UraUserCommand(object sender, EventArgs e)
        {
            UraUserWorkItem item = this.WorkItem.Items.Get<UraUserWorkItem>("Fin.UraUser");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<UraUserWorkItem>("Fin.UraUser");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Finpos.URAVRSTAIZNOSACommand")]
        public void URAVRSTAIZNOSACommand(object sender, EventArgs e)
        {
            URAVRSTAIZNOSAWorkWithWorkItem item = this.WorkItem.Items.Get<URAVRSTAIZNOSAWorkWithWorkItem>("Finpos.URAVRSTAIZNOSA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<URAVRSTAIZNOSAWorkWithWorkItem>("Finpos.URAVRSTAIZNOSA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Finpos.Zatvaranje")]
        public void ZatvaranjeCommand(object sender, EventArgs e)
        {
            ZatvaranjeStavakaWorkItem item = this.WorkItem.Items.Get<ZatvaranjeStavakaWorkItem>("Finpos.IRAVRSTAIZNOSA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<ZatvaranjeStavakaWorkItem>("Finpos.IRAVRSTAIZNOSA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Finpos.ZatvaranjeBolnice")]
        public void ZatvaranjeBolniceCommand(object sender, EventArgs e)
        {
            ZatvaranjeBolniceWorkItem item = this.WorkItem.Items.Get<ZatvaranjeBolniceWorkItem>("Finpos.ZatvaranjeBolnice");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<ZatvaranjeBolniceWorkItem>("Finpos.ZatvaranjeBolnice");
            }
            item.Show(item.Workspaces["main"]);
        }
    }
}


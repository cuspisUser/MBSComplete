namespace NetAdvantage
{
    using CrystalDecisions.CrystalReports.Engine;
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Workspaces;
    using IDObrazacNamespace;
    using IPKarticeNamespace;
    using IPP;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.Commands;
    using Microsoft.Practices.CompositeUI.EventBroker;
    using Microsoft.VisualBasic.CompilerServices;
    using NetAdvantage.SmartParts;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Collections;
    using System.Data;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using NetAdvantage.Controllers;
    using Microsoft.VisualBasic;

    public class MainController : Controller
    {
        [CommandHandler("Placa.AKTIVNOSTCommand")]
        public void AKTIVNOSTCommand(object sender, EventArgs e)
        {
            AKTIVNOSTWorkWithWorkItem item = this.WorkItem.Items.Get<AKTIVNOSTWorkWithWorkItem>("Placa.AKTIVNOST");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<AKTIVNOSTWorkWithWorkItem>("Placa.AKTIVNOST");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("OS.Amortizacija")]
        public void AmortizacijaCommandHandler(object sender, EventArgs e)
        {
            AmortizacijaWorkWith with = this.WorkItem.Items.Get<AmortizacijaWorkWith>("Amortizacija");
            if (with == null)
            {
                with = this.WorkItem.Items.AddNew<AmortizacijaWorkWith>("Amortizacija");
            }
            with.Show(with.Workspaces["main"]);
        }

        [CommandHandler("Placa.AMSKUPINECommand")]
        public void AMSKUPINECommand(object sender, EventArgs e)
        {
            AMSKUPINEWorkWithWorkItem item = this.WorkItem.Items.Get<AMSKUPINEWorkWithWorkItem>("Placa.AMSKUPINE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<AMSKUPINEWorkWithWorkItem>("Placa.AMSKUPINE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.BANKECommand")]
        public void BANKECommand(object sender, EventArgs e)
        {
            BANKEWorkWithWorkItem item = this.WorkItem.Items.Get<BANKEWorkWithWorkItem>("Placa.BANKE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<BANKEWorkWithWorkItem>("Placa.BANKE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("BazePodataka")]
        public void BazePodatakaCommandHandler(object sender, EventArgs e)
        {
            ExtendedWindowSmartPartInfo smartPartInfo = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterScreen,
                Modal = true,
                ControlBox = true,
                Title = "Servis - baze podataka",
                Icon = ImageResourcesNew.mbs
            };
            OdrzavanjeSmartPart smartPart = this.WorkItem.Items.AddNew<OdrzavanjeSmartPart>();
            this.WorkItem.RootWorkItem.Workspaces["window"].Show(smartPart, smartPartInfo);
        }

        [CommandHandler("Placa.BENEFICIRANICommand")]
        public void BENEFICIRANICommand(object sender, EventArgs e)
        {
            BENEFICIRANIWorkWithWorkItem item = this.WorkItem.Items.Get<BENEFICIRANIWorkWithWorkItem>("Placa.BENEFICIRANI");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<BENEFICIRANIWorkWithWorkItem>("Placa.BENEFICIRANI");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.BLAGAJNACommand")]
        public void BLAGAJNACommand(object sender, EventArgs e)
        {
            BLAGAJNAWorkWithWorkItem item = this.WorkItem.Items.Get<BLAGAJNAWorkWithWorkItem>("Placa.BLAGAJNA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<BLAGAJNAWorkWithWorkItem>("Placa.BLAGAJNA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.BLGVRSTEDOKCommand")]
        public void BLGVRSTEDOKCommand(object sender, EventArgs e)
        {
            BLGVRSTEDOKWorkWithWorkItem item = this.WorkItem.Items.Get<BLGVRSTEDOKWorkWithWorkItem>("Placa.BLGVRSTEDOK");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<BLGVRSTEDOKWorkWithWorkItem>("Placa.BLGVRSTEDOK");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.Bolovanje")]
        public void BolovanjeCommandHandler(object sender, EventArgs e)
        {
            BolovanjeWorkItem item = this.WorkItem.Items.Get<BolovanjeWorkItem>("BolovanjeWorkItem");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<BolovanjeWorkItem>("BolovanjeWorkItem");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.BOLOVANJEFONDCommand")]
        public void BOLOVANJEFONDCommand(object sender, EventArgs e)
        {
            BOLOVANJEFONDWorkWithWorkItem item = this.WorkItem.Items.Get<BOLOVANJEFONDWorkWithWorkItem>("Placa.BOLOVANJEFOND");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<BOLOVANJEFONDWorkWithWorkItem>("Placa.BOLOVANJEFOND");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.BRACNOSTANJECommand")]
        public void BRACNOSTANJECommand(object sender, EventArgs e)
        {
            BRACNOSTANJEWorkWithWorkItem item = this.WorkItem.Items.Get<BRACNOSTANJEWorkWithWorkItem>("Placa.BRACNOSTANJE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<BRACNOSTANJEWorkWithWorkItem>("Placa.BRACNOSTANJE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.BrziUnosKreditaCommand")]
        public void BrziUnosKreditaCommandHandler(object sender, EventArgs e)
        {
            UnosKreditaWorkItem item = this.WorkItem.Items.Get<UnosKreditaWorkItem>("UnosKreditaWorkItem");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<UnosKreditaWorkItem>("UnosKreditaWorkItem");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.DDIZDATAKCommand")]
        public void DDIZDATAKCommand(object sender, EventArgs e)
        {
            DDIZDATAKWorkWithWorkItem item = this.WorkItem.Items.Get<DDIZDATAKWorkWithWorkItem>("Placa.DDIZDATAK");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<DDIZDATAKWorkWithWorkItem>("Placa.DDIZDATAK");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.DDKATEGORIJACommand")]
        public void DDKATEGORIJACommand(object sender, EventArgs e)
        {
            DDKATEGORIJAWorkWithWorkItem item = this.WorkItem.Items.Get<DDKATEGORIJAWorkWithWorkItem>("Placa.DDKATEGORIJA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<DDKATEGORIJAWorkWithWorkItem>("Placa.DDKATEGORIJA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.DDKOLONAIDDCommand")]
        public void DDKOLONAIDDCommand(object sender, EventArgs e)
        {
            DDKOLONAIDDWorkWithWorkItem item = this.WorkItem.Items.Get<DDKOLONAIDDWorkWithWorkItem>("Placa.DDKOLONAIDD");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<DDKOLONAIDDWorkWithWorkItem>("Placa.DDKOLONAIDD");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.DDOBRACUNCommand")]
        public void DDOBRACUNCommand(object sender, EventArgs e)
        {
            DDOBRACUNWorkWithWorkItem item = this.WorkItem.Items.Get<DDOBRACUNWorkWithWorkItem>("Placa.DDOBRACUN");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<DDOBRACUNWorkWithWorkItem>("Placa.DDOBRACUN");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.DDRADNIKCommand")]
        public void DDRADNIKCommand(object sender, EventArgs e)
        {
            DDRADNIKWorkWithWorkItem item = this.WorkItem.Items.Get<DDRADNIKWorkWithWorkItem>("Placa.DDRADNIK");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<DDRADNIKWorkWithWorkItem>("Placa.DDRADNIK");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.DDVRSTEIZNOSACommand")]
        public void DDVRSTEIZNOSACommand(object sender, EventArgs e)
        {
            DDVRSTEIZNOSAWorkWithWorkItem item = this.WorkItem.Items.Get<DDVRSTEIZNOSAWorkWithWorkItem>("Placa.DDVRSTEIZNOSA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<DDVRSTEIZNOSAWorkWithWorkItem>("Placa.DDVRSTEIZNOSA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.DDVRSTEPOSLACommand")]
        public void DDVRSTEPOSLACommand(object sender, EventArgs e)
        {
            DDVRSTEPOSLAWorkWithWorkItem item = this.WorkItem.Items.Get<DDVRSTEPOSLAWorkWithWorkItem>("Placa.DDVRSTEPOSLA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<DDVRSTEPOSLAWorkWithWorkItem>("Placa.DDVRSTEPOSLA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.DOKUMENTCommand")]
        public void DOKUMENTCommand(object sender, EventArgs e)
        {
            DOKUMENTWorkWithWorkItem item = this.WorkItem.Items.Get<DOKUMENTWorkWithWorkItem>("Placa.DOKUMENT");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<DOKUMENTWorkWithWorkItem>("Placa.DOKUMENT");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.DOPRINOSCommand")]
        public void DOPRINOSCommand(object sender, EventArgs e)
        {
            DOPRINOSWorkWithWorkItem item = this.WorkItem.Items.Get<DOPRINOSWorkWithWorkItem>("Placa.DOPRINOS");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<DOPRINOSWorkWithWorkItem>("Placa.DOPRINOS");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.DOSIPZAGLAVLJECommand")]
        public void DOSIPZAGLAVLJECommand(object sender, EventArgs e)
        {
            DOSIPZAGLAVLJEWorkWithWorkItem item = this.WorkItem.Items.Get<DOSIPZAGLAVLJEWorkWithWorkItem>("Placa.DOSIPZAGLAVLJE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<DOSIPZAGLAVLJEWorkWithWorkItem>("Placa.DOSIPZAGLAVLJE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.DRZAVLJANSTVOCommand")]
        public void DRZAVLJANSTVOCommand(object sender, EventArgs e)
        {
            DRZAVLJANSTVOWorkWithWorkItem item = this.WorkItem.Items.Get<DRZAVLJANSTVOWorkWithWorkItem>("Placa.DRZAVLJANSTVO");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<DRZAVLJANSTVOWorkWithWorkItem>("Placa.DRZAVLJANSTVO");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.ELEMENTCommand")]
        public void ELEMENTCommand(object sender, EventArgs e)
        {
            ELEMENTWorkWithWorkItem item = this.WorkItem.Items.Get<ELEMENTWorkWithWorkItem>("Placa.ELEMENT");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<ELEMENTWorkWithWorkItem>("Placa.ELEMENT");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.EVIDENCIJACommand")]
        public void EVIDENCIJACommand(object sender, EventArgs e)
        {
            EVIDENCIJAWorkWithWorkItem item = this.WorkItem.Items.Get<EVIDENCIJAWorkWithWorkItem>("Placa.EVIDENCIJA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<EVIDENCIJAWorkWithWorkItem>("Placa.EVIDENCIJA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.FINPOREZCommand")]
        public void FINPOREZCommand(object sender, EventArgs e)
        {
            FINPOREZWorkWithWorkItem item = this.WorkItem.Items.Get<FINPOREZWorkWithWorkItem>("Placa.FINPOREZ");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<FINPOREZWorkWithWorkItem>("Placa.FINPOREZ");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.FondBolovanje")]
        public void FondBolovanjeCommandHandler(object sender, EventArgs e)
        {
            FondBolovanjeWorkItem item = this.WorkItem.Items.Get<FondBolovanjeWorkItem>("FondBolovanjeWorkItem");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<FondBolovanjeWorkItem>("FondBolovanjeWorkItem");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.GKSTAVKACommand")]
        public void GKSTAVKACommand(object sender, EventArgs e)
        {
            GKSTAVKAWorkWithWorkItem item = this.WorkItem.Items.Get<GKSTAVKAWorkWithWorkItem>("Placa.GKSTAVKA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<GKSTAVKAWorkWithWorkItem>("Placa.GKSTAVKA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.GODINA_I_MJESEC_OBRACUNACommand")]
        public void GODINA_I_MJESEC_OBRACUNACommand(object sender, EventArgs e)
        {
            GODINA_I_MJESEC_OBRACUNAWorkWithWorkItem item = this.WorkItem.Items.Get<GODINA_I_MJESEC_OBRACUNAWorkWithWorkItem>("Placa.GODINA_I_MJESEC_OBRACUNA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<GODINA_I_MJESEC_OBRACUNAWorkWithWorkItem>("Placa.GODINA_I_MJESEC_OBRACUNA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.GODINECommand")]
        public void GODINECommand(object sender, EventArgs e)
        {
            GODINEWorkWithWorkItem item = this.WorkItem.Items.Get<GODINEWorkWithWorkItem>("Placa.GODINE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<GODINEWorkWithWorkItem>("Placa.GODINE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.Godisnji")]
        public void GodisnjiCommandHandler(object sender, EventArgs e)
        {
            GodisnjiWorkItem item = this.WorkItem.Items.Get<GodisnjiWorkItem>("GodisnjiWorkItem");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<GodisnjiWorkItem>("GodisnjiWorkItem");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.GOOBRACUNCommand")]
        public void GOOBRACUNCommand(object sender, EventArgs e)
        {
            GOOBRACUNWorkWithWorkItem item = this.WorkItem.Items.Get<GOOBRACUNWorkWithWorkItem>("Placa.GOOBRACUN");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<GOOBRACUNWorkWithWorkItem>("Placa.GOOBRACUN");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.GRUPEKOEFCommand")]
        public void GRUPEKOEFCommand(object sender, EventArgs e)
        {
            GRUPEKOEFWorkWithWorkItem item = this.WorkItem.Items.Get<GRUPEKOEFWorkWithWorkItem>("Placa.GRUPEKOEF");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<GRUPEKOEFWorkWithWorkItem>("Placa.GRUPEKOEF");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.GRUPEOLAKSICACommand")]
        public void GRUPEOLAKSICACommand(object sender, EventArgs e)
        {
            GRUPEOLAKSICAWorkWithWorkItem item = this.WorkItem.Items.Get<GRUPEOLAKSICAWorkWithWorkItem>("Placa.GRUPEOLAKSICA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<GRUPEOLAKSICAWorkWithWorkItem>("Placa.GRUPEOLAKSICA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("IDObrazacCommand")]
        public void IDObrazacCommand(object sender, EventArgs e)
        {
            IDWorkItem item = this.WorkItem.Items.Get<IDWorkItem>("IDObrazac");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<IDWorkItem>("IDObrazac");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("IMPORTIP")]
        public void IMPORTIPCommandHandler(object sender, EventArgs e)
        {
            ExtendedWindowSmartPartInfo smartPartInfo = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterScreen,
                Modal = true,
                ControlBox = true,
                Title = "Servis - baze podataka",
                Icon = ImageResourcesNew.mbs
            };
            DOSPodaci smartPart = this.WorkItem.Items.AddNew<DOSPodaci>();
            this.WorkItem.RootWorkItem.Workspaces["window"].Show(smartPart, smartPartInfo);
        }

        [CommandHandler("OS.InventurnaLista")]
        public void InventurnaListaCommandHandler(object sender, EventArgs e)
        {
            S_OS_STANJE_LOKACIJA_SVI_BROJEVIDataAdapter adapter = new S_OS_STANJE_LOKACIJA_SVI_BROJEVIDataAdapter();
            S_OS_STANJE_LOKACIJA_SVI_BROJEVIDataSet dataSet = new S_OS_STANJE_LOKACIJA_SVI_BROJEVIDataSet();
            frmUvjetiInventurnaLista lista = new frmUvjetiInventurnaLista();
            lista.ShowDialog();
            ReportDocument document = new ReportDocument();
            adapter.Fill(dataSet);
            if (Operators.ConditionalCompareObjectEqual(lista.__Vrsta, 1, false))
            {
                document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptInventurnaLista.rpt");
            }
            else
            {
                document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptInventurnaListaBezGrupiranja.rpt");
            }
            if (Conversions.ToInteger(lista.__Sort) == 0)
            {
                document.SetDataSource(dataSet);
            }
            else
            {
                IEnumerator enumerator = null;
                DataSet set3 = new DataSet();
                try
                {
                    enumerator = dataSet.Tables.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataTable current = (DataTable) enumerator.Current;
                        if (current.TableName == "S_OS_STANJE_LOKACIJA_SVI_BROJEVI")
                        {
                            DataTable table = new DataTable();
                            table = new DataView(current) { Sort = "NAZIVOS" }.ToTable();
                            set3.Tables.Add(table);
                        }
                        else
                        {
                            set3.Tables.Add(current.Copy());
                        }
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                document.SetDataSource(set3);
            }
            KORISNIKDataSet set2 = new KORISNIKDataSet();
            new KORISNIKDataAdapter().Fill(set2);

            if (set2.KORISNIK.Rows.Count > 0)
            {
                document.SetParameterValue("ustanova", RuntimeHelpers.GetObjectValue(set2.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
                document.SetParameterValue("telefon", RuntimeHelpers.GetObjectValue(set2.KORISNIK.Rows[0]["KONTAKTTELEFON"]));
                document.SetParameterValue("fax", RuntimeHelpers.GetObjectValue(set2.KORISNIK.Rows[0]["KONTAKTFAX"]));
                document.SetParameterValue("mb", RuntimeHelpers.GetObjectValue(set2.KORISNIK.Rows[0]["KORISNIKOIB"]));
                document.SetParameterValue("adresa", RuntimeHelpers.GetObjectValue(set2.KORISNIK.Rows[0]["KORISNIK1ADRESA"]));
                document.SetParameterValue("adresa2", RuntimeHelpers.GetObjectValue(set2.KORISNIK.Rows[0]["KORISNIK1MJESTO"]));
            }

            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            PreviewReportWorkItem item = this.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            item.Izvjestaj = document;
            item.Activate();
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.IPIDENTCommand")]
        public void IPIDENTCommand(object sender, EventArgs e)
        {
            IPIDENTWorkWithWorkItem item = this.WorkItem.Items.Get<IPIDENTWorkWithWorkItem>("Placa.IPIDENT");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<IPIDENTWorkWithWorkItem>("Placa.IPIDENT");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("IPKarticeCommand")]
        public void IPKarticeCommandHandler(object sender, EventArgs e)
        {
            IPKarticeWorkItem item = this.WorkItem.Items.Get<IPKarticeWorkItem>("IPKartice");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<IPKarticeWorkItem>("IPKartice");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("IPPObrazacCommand")]
        public void IPPCommandHandler(object sender, EventArgs e)
        {
            IPPWorkItem item = this.WorkItem.Items.Get<IPPWorkItem>("IPPWorkItem");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<IPPWorkItem>("IPPWorkItem");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.IRACommand")]
        public void IRACommand(object sender, EventArgs e)
        {
            IRAWorkWithWorkItem item = this.WorkItem.Items.Get<IRAWorkWithWorkItem>("Placa.IRA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<IRAWorkWithWorkItem>("Placa.IRA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.IRAVRSTAIZNOSACommand")]
        public void IRAVRSTAIZNOSACommand(object sender, EventArgs e)
        {
            IRAVRSTAIZNOSAWorkWithWorkItem item = this.WorkItem.Items.Get<IRAVRSTAIZNOSAWorkWithWorkItem>("Placa.IRAVRSTAIZNOSA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<IRAVRSTAIZNOSAWorkWithWorkItem>("Placa.IRAVRSTAIZNOSA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.IZVORDOKUMENTACommand")]
        public void IZVORDOKUMENTACommand(object sender, EventArgs e)
        {
            IZVORDOKUMENTAWorkWithWorkItem item = this.WorkItem.Items.Get<IZVORDOKUMENTAWorkWithWorkItem>("Placa.IZVORDOKUMENTA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<IZVORDOKUMENTAWorkWithWorkItem>("Placa.IZVORDOKUMENTA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.JEDINICAMJERECommand")]
        public void JEDINICAMJERECommand(object sender, EventArgs e)
        {
            JEDINICAMJEREWorkWithWorkItem item = this.WorkItem.Items.Get<JEDINICAMJEREWorkWithWorkItem>("Placa.JEDINICAMJERE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<JEDINICAMJEREWorkWithWorkItem>("Placa.JEDINICAMJERE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.KONTOCommand")]
        public void KONTOCommand(object sender, EventArgs e)
        {
            KONTOWorkWithWorkItem item = this.WorkItem.Items.Get<KONTOWorkWithWorkItem>("Placa.KONTO");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<KONTOWorkWithWorkItem>("Placa.KONTO");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.KORISNIKCommand")]
        public void KORISNIKCommand(object sender, EventArgs e)
        {
            KORISNIKWorkWithWorkItem item = this.WorkItem.Items.Get<KORISNIKWorkWithWorkItem>("Placa.KORISNIK");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<KORISNIKWorkWithWorkItem>("Placa.KORISNIK");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.KREDITORCommand")]
        public void KREDITORCommand(object sender, EventArgs e)
        {
            KREDITORWorkWithWorkItem item = this.WorkItem.Items.Get<KREDITORWorkWithWorkItem>("Placa.KREDITOR");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<KREDITORWorkWithWorkItem>("Placa.KREDITOR");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.KRIZNIPOREZCommand")]
        public void KRIZNIPOREZCommand(object sender, EventArgs e)
        {
            KRIZNIPOREZWorkWithWorkItem item = this.WorkItem.Items.Get<KRIZNIPOREZWorkWithWorkItem>("Placa.KRIZNIPOREZ");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<KRIZNIPOREZWorkWithWorkItem>("Placa.KRIZNIPOREZ");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("ListaIznosaCommand")]
        public void ListaIznosaCommandHandler(object sender, EventArgs e)
        {
            ListaIznosaWorkItem item = this.WorkItem.Items.Get<ListaIznosaWorkItem>("ListaIznosa");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<ListaIznosaWorkItem>("ListaIznosa");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.LOKACIJECommand")]
        public void LOKACIJECommand(object sender, EventArgs e)
        {
            LokacijeWorkWithWorkItem item = this.WorkItem.Items.Get<LokacijeWorkWithWorkItem>("Placa.LOKACIJE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<LokacijeWorkWithWorkItem>("Placa.LOKACIJE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("MaticniKartonCommand")]
        public void MaticniKartonCommandHandler(object sender, EventArgs e)
        {
            MaticniKartonWorkItem item = this.WorkItem.Items.Get<MaticniKartonWorkItem>("MaticniKarton");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<MaticniKartonWorkItem>("MaticniKarton");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.MJESTOTROSKACommand")]
        public void MJESTOTROSKACommand(object sender, EventArgs e)
        {
            MJESTOTROSKAWorkWithWorkItem item = this.WorkItem.Items.Get<MJESTOTROSKAWorkWithWorkItem>("Placa.MJESTOTROSKA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<MJESTOTROSKAWorkWithWorkItem>("Placa.MJESTOTROSKA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.MZOSTABLICECommand")]
        public void MZOSTABLICECommand(object sender, EventArgs e)
        {
            MZOSTABLICEWorkWithWorkItem item = this.WorkItem.Items.Get<MZOSTABLICEWorkWithWorkItem>("Placa.MZOSTABLICE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<MZOSTABLICEWorkWithWorkItem>("Placa.MZOSTABLICE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.OBRACUNCommand")]
        public void OBRACUNCommand(object sender, EventArgs e)
        {
            OBRACUNWorkWithWorkItem item = this.WorkItem.Items.Get<OBRACUNWorkWithWorkItem>("Placa.OBRACUN");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<OBRACUNWorkWithWorkItem>("Placa.OBRACUN");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.OBUSTAVACommand")]
        public void OBUSTAVACommand(object sender, EventArgs e)
        {
            OBUSTAVAWorkWithWorkItem item = this.WorkItem.Items.Get<OBUSTAVAWorkWithWorkItem>("Placa.OBUSTAVA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<OBUSTAVAWorkWithWorkItem>("Placa.OBUSTAVA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.OLAKSICECommand")]
        public void OLAKSICECommand(object sender, EventArgs e)
        {
            OLAKSICEWorkWithWorkItem item = this.WorkItem.Items.Get<OLAKSICEWorkWithWorkItem>("Placa.OLAKSICE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<OLAKSICEWorkWithWorkItem>("Placa.OLAKSICE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.OPCINACommand")]
        public void OPCINACommand(object sender, EventArgs e)
        {
            OPCINAWorkWithWorkItem item = this.WorkItem.Items.Get<OPCINAWorkWithWorkItem>("Placa.OPCINA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<OPCINAWorkWithWorkItem>("Placa.OPCINA");
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

                case "AMSKUPINE":
                    this.WorkItem.Items.AddNew<AMSKUPINEWorkWithController>().Show(args.Mode, args.PrimaryKey);
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

                case "DDVRSTEIZNOSA":
                    this.WorkItem.Items.AddNew<DDVRSTEIZNOSAWorkWithController>().Show(args.Mode, args.PrimaryKey);
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

                case "DRZAVLJANSTVO":
                    this.WorkItem.Items.AddNew<DRZAVLJANSTVOWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "ELEMENT":
                    this.WorkItem.Items.AddNew<ELEMENTWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "EVIDENCIJA":
                    this.WorkItem.Items.AddNew<EVIDENCIJAWorkWithController>().Show(args.Mode, args.PrimaryKey);
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

                case "GOOBRACUN":
                    this.WorkItem.Items.AddNew<GOOBRACUNWorkWithController>().Show(args.Mode, args.PrimaryKey);
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

                case "LOKACIJE":
                    this.WorkItem.Items.AddNew<LOKACIJEWorkWithController>().Show(args.Mode, args.PrimaryKey);
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

                case "OS":
                    this.WorkItem.Items.AddNew<OSWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "OSDOKUMENT":
                    this.WorkItem.Items.AddNew<OSDOKUMENTWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "OSNOVAOSIGURANJA":
                    this.WorkItem.Items.AddNew<OSNOVAOSIGURANJAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "OSOBNIODBITAK":
                    this.WorkItem.Items.AddNew<OSOBNIODBITAKWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "OSRAZMJESTAJ":
                    this.WorkItem.Items.AddNew<OSRAZMJESTAJWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "OSVRSTA":
                    this.WorkItem.Items.AddNew<OSVRSTAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "OTISLI":
                    this.WorkItem.Items.AddNew<OTISLIWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "PARTNER":
                    this.WorkItem.Items.AddNew<PARTNERWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "PLAN":
                    this.WorkItem.Items.AddNew<PLANWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "PLVRSTEIZNOSA":
                    this.WorkItem.Items.AddNew<PLVRSTEIZNOSAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "POREZ":
                    this.WorkItem.Items.AddNew<POREZWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "POSTANSKIBROJEVI":
                    this.WorkItem.Items.AddNew<POSTANSKIBROJEVIWorkWithController>().Show(args.Mode, args.PrimaryKey);
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

                case "RAD1GELEMENTI":
                    this.WorkItem.Items.AddNew<RAD1GELEMENTIWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "RAD1GELEMENTIVEZA":
                    this.WorkItem.Items.AddNew<RAD1GELEMENTIVEZAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "RAD1MELEMENTI":
                    this.WorkItem.Items.AddNew<RAD1MELEMENTIWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "RAD1MELEMENTIVEZA":
                    this.WorkItem.Items.AddNew<RAD1MELEMENTIVEZAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "RAD1SPOL":
                    this.WorkItem.Items.AddNew<RAD1SPOLWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "RAD1SPREME":
                    this.WorkItem.Items.AddNew<RAD1SPREMEWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "RAD1SPREMEVEZA":
                    this.WorkItem.Items.AddNew<RAD1SPREMEVEZAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "RAD1VEZASPOL":
                    this.WorkItem.Items.AddNew<RAD1VEZASPOLWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "RADNIK":
                    this.WorkItem.Items.AddNew<RADNIKWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "RADNOMJESTO":
                    this.WorkItem.Items.AddNew<RADNOMJESTOWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "RADNOVRIJEME":
                    this.WorkItem.Items.AddNew<RADNOVRIJEMEWorkWithController>().Show(args.Mode, args.PrimaryKey);
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

                case "SHEMADD":
                    this.WorkItem.Items.AddNew<SHEMADDWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "SHEMAIRA":
                    this.WorkItem.Items.AddNew<SHEMAIRAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "SHEMAPLACA":
                    this.WorkItem.Items.AddNew<SHEMAPLACAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "SHEMAURA":
                    this.WorkItem.Items.AddNew<SHEMAURAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "SKUPPOREZAIDOPRINOSA":
                    this.WorkItem.Items.AddNew<SKUPPOREZAIDOPRINOSAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "SMJENE":
                    this.WorkItem.Items.AddNew<SMJENEWorkWithController>().Show(args.Mode, args.PrimaryKey);
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

                case "UCENIK":
                    this.WorkItem.Items.AddNew<UCENIKWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "UCENIKOBRACUN":
                    this.WorkItem.Items.AddNew<UCENIKOBRACUNWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "UCENIKRSMIDENT":
                    this.WorkItem.Items.AddNew<UCENIKRSMIDENTWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "UGOVORORADU":
                    this.WorkItem.Items.AddNew<UGOVORORADUWorkWithController>().Show(args.Mode, args.PrimaryKey);
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

                case "ZAPOSLENI":
                    this.WorkItem.Items.AddNew<ZAPOSLENIWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;

                case "ZATVARANJA":
                    this.WorkItem.Items.AddNew<ZATVARANJAWorkWithController>().Show(args.Mode, args.PrimaryKey);
                    break;
            }
        }

        [CommandHandler("Placa.ORGDIOCommand")]
        public void ORGDIOCommand(object sender, EventArgs e)
        {
            ORGDIOWorkWithWorkItem item = this.WorkItem.Items.Get<ORGDIOWorkWithWorkItem>("Placa.ORGDIO");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<ORGDIOWorkWithWorkItem>("Placa.ORGDIO");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.ORGJEDCommand")]
        public void ORGJEDCommand(object sender, EventArgs e)
        {
            ORGJEDWorkWithWorkItem item = this.WorkItem.Items.Get<ORGJEDWorkWithWorkItem>("Placa.ORGJED");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<ORGJEDWorkWithWorkItem>("Placa.ORGJED");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.OSCommand")]
        public void OSCommand(object sender, EventArgs e)
        {
            OSWorkWithWorkItem item = this.WorkItem.Items.Get<OSWorkWithWorkItem>("Placa.OS");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<OSWorkWithWorkItem>("Placa.OS");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.OSDOKUMENTCommand")]
        public void OSDOKUMENTCommand(object sender, EventArgs e)
        {
            OSDOKUMENTWorkWithWorkItem item = this.WorkItem.Items.Get<OSDOKUMENTWorkWithWorkItem>("Placa.OSDOKUMENT");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<OSDOKUMENTWorkWithWorkItem>("Placa.OSDOKUMENT");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.OSNOVAOSIGURANJACommand")]
        public void OSNOVAOSIGURANJACommand(object sender, EventArgs e)
        {
            OSNOVAOSIGURANJAWorkWithWorkItem item = this.WorkItem.Items.Get<OSNOVAOSIGURANJAWorkWithWorkItem>("Placa.OSNOVAOSIGURANJA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<OSNOVAOSIGURANJAWorkWithWorkItem>("Placa.OSNOVAOSIGURANJA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.OSOBNIODBITAKCommand")]
        public void OSOBNIODBITAKCommand(object sender, EventArgs e)
        {
            OSOBNIODBITAKWorkWithWorkItem item = this.WorkItem.Items.Get<OSOBNIODBITAKWorkWithWorkItem>("Placa.OSOBNIODBITAK");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<OSOBNIODBITAKWorkWithWorkItem>("Placa.OSOBNIODBITAK");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.OSRAZMJESTAJCommand")]
        public void OSRAZMJESTAJCommand(object sender, EventArgs e)
        {
            OSRAZMJESTAJWorkWithWorkItem item = this.WorkItem.Items.Get<OSRAZMJESTAJWorkWithWorkItem>("Placa.OSRAZMJESTAJ");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<OSRAZMJESTAJWorkWithWorkItem>("Placa.OSRAZMJESTAJ");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.OSVRSTACommand")]
        public void OSVRSTACommand(object sender, EventArgs e)
        {
            OSVRSTAWorkWithWorkItem item = this.WorkItem.Items.Get<OSVRSTAWorkWithWorkItem>("Placa.OSVRSTA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<OSVRSTAWorkWithWorkItem>("Placa.OSVRSTA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.OTISLICommand")]
        public void OTISLICommand(object sender, EventArgs e)
        {
            OTISLIWorkWithWorkItem item = this.WorkItem.Items.Get<OTISLIWorkWithWorkItem>("Placa.OTISLI");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<OTISLIWorkWithWorkItem>("Placa.OTISLI");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.partnerabecedaCommand")]
        public void partnerabecedaCommand(object sender, EventArgs e)
        {
            partnerabecedaWorkWithWorkItem item = this.WorkItem.Items.Get<partnerabecedaWorkWithWorkItem>("Placa.partnerabeceda");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<partnerabecedaWorkWithWorkItem>("Placa.partnerabeceda");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.PARTNERCommand")]
        public void PARTNERCommand(object sender, EventArgs e)
        {
            PARTNERWorkWithWorkItem item = this.WorkItem.Items.Get<PARTNERWorkWithWorkItem>("Placa.PARTNER");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PARTNERWorkWithWorkItem>("Placa.PARTNER");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.PLANCommand")]
        public void PLANCommand(object sender, EventArgs e)
        {
            PLANWorkWithWorkItem item = this.WorkItem.Items.Get<PLANWorkWithWorkItem>("Placa.PLAN");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PLANWorkWithWorkItem>("Placa.PLAN");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.PLVRSTEIZNOSACommand")]
        public void PLVRSTEIZNOSACommand(object sender, EventArgs e)
        {
            PLVRSTEIZNOSAWorkWithWorkItem item = this.WorkItem.Items.Get<PLVRSTEIZNOSAWorkWithWorkItem>("Placa.PLVRSTEIZNOSA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PLVRSTEIZNOSAWorkWithWorkItem>("Placa.PLVRSTEIZNOSA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.POREZCommand")]
        public void POREZCommand(object sender, EventArgs e)
        {
            POREZWorkWithWorkItem item = this.WorkItem.Items.Get<POREZWorkWithWorkItem>("Placa.POREZ");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<POREZWorkWithWorkItem>("Placa.POREZ");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.POSTANSKIBROJEVICommand")]
        public void POSTANSKIBROJEVICommand(object sender, EventArgs e)
        {
            POSTANSKIBROJEVIWorkWithWorkItem item = this.WorkItem.Items.Get<POSTANSKIBROJEVIWorkWithWorkItem>("Placa.POSTANSKIBROJEVI");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<POSTANSKIBROJEVIWorkWithWorkItem>("Placa.POSTANSKIBROJEVI");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.PregledObracunaCommand")]
        public void PregledObracunaCommand(object sender, EventArgs e)
        {
            PregledObracunaWorkWithWorkItem item = this.WorkItem.Items.Get<PregledObracunaWorkWithWorkItem>("Placa.PregledObracuna");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PregledObracunaWorkWithWorkItem>("Placa.PregledObracuna");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.PregledRadnikaCommand")]
        public void PregledRadnikaCommand(object sender, EventArgs e)
        {
            PregledRadnikaWorkWithWorkItem item = this.WorkItem.Items.Get<PregledRadnikaWorkWithWorkItem>("Placa.PregledRadnika");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PregledRadnikaWorkWithWorkItem>("Placa.PregledRadnika");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.PregledRadnikaSvihCommand")]
        public void PregledRadnikaSvihCommand(object sender, EventArgs e)
        {
            PregledRadnikaSvihWorkWithWorkItem item = this.WorkItem.Items.Get<PregledRadnikaSvihWorkWithWorkItem>("Placa.PregledRadnikaSvih");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PregledRadnikaSvihWorkWithWorkItem>("Placa.PregledRadnikaSvih");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.PREGLEDZADUZENJACommand")]
        public void PREGLEDZADUZENJACommand(object sender, EventArgs e)
        {
            PREGLEDZADUZENJAWorkWithWorkItem item = this.WorkItem.Items.Get<PREGLEDZADUZENJAWorkWithWorkItem>("Placa.PREGLEDZADUZENJA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PREGLEDZADUZENJAWorkWithWorkItem>("Placa.PREGLEDZADUZENJA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.PripremaCommand")]
        public void PripremaCommand(object sender, EventArgs e)
        {
            PripremaWorkItem item = this.WorkItem.Items.Get<PripremaWorkItem>("Obracun");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PripremaWorkItem>("Obracun");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.PRPLACECommandCustom")]
        public void PripremaCustomCommandHandler(object sender, EventArgs e)
        {
            PripremaPlaceWorkItem item = this.WorkItem.Items.Get<PripremaPlaceWorkItem>("PripremaPlaceWorkItem");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PripremaPlaceWorkItem>("PripremaPlaceWorkItem");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.PROIZVODCommand")]
        public void PROIZVODCommand(object sender, EventArgs e)
        {
            PROIZVODWorkWithWorkItem item = this.WorkItem.Items.Get<PROIZVODWorkWithWorkItem>("Placa.PROIZVOD");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PROIZVODWorkWithWorkItem>("Placa.PROIZVOD");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.ProsjekPlace")]
        public void ProsjekPlaceCommandHandler(object sender, EventArgs e)
        {
            ProsjekPlaceWorkItem item = this.WorkItem.Items.Get<ProsjekPlaceWorkItem>("ProsjekPlaceWorkItem");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<ProsjekPlaceWorkItem>("ProsjekPlaceWorkItem");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.PROVIDER_BRUTOCommand")]
        public void PROVIDER_BRUTOCommand(object sender, EventArgs e)
        {
            PROVIDER_BRUTOWorkWithWorkItem item = this.WorkItem.Items.Get<PROVIDER_BRUTOWorkWithWorkItem>("Placa.PROVIDER_BRUTO");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PROVIDER_BRUTOWorkWithWorkItem>("Placa.PROVIDER_BRUTO");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.PROVIDER_NETOCommand")]
        public void PROVIDER_NETOCommand(object sender, EventArgs e)
        {
            PROVIDER_NETOWorkWithWorkItem item = this.WorkItem.Items.Get<PROVIDER_NETOWorkWithWorkItem>("Placa.PROVIDER_NETO");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PROVIDER_NETOWorkWithWorkItem>("Placa.PROVIDER_NETO");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.PRPLACECommand")]
        public void PRPLACECommand(object sender, EventArgs e)
        {
            PRPLACEWorkWithWorkItem item = this.WorkItem.Items.Get<PRPLACEWorkWithWorkItem>("Placa.PRPLACE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PRPLACEWorkWithWorkItem>("Placa.PRPLACE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.PrPlaceCustom")]
        public void PrPlaceCustomCommandHandler(object sender, EventArgs e)
        {
            PripremaPlaceCustomWorkItem item = this.WorkItem.Items.Get<PripremaPlaceCustomWorkItem>("PripremaPlaceCustomWorkItem");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PripremaPlaceCustomWorkItem>("PripremaPlaceCustomWorkItem");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.RACUNCommand")]
        public void RACUNCommand(object sender, EventArgs e)
        {
            RACUNWorkWithWorkItem item = this.WorkItem.Items.Get<RACUNWorkWithWorkItem>("Placa.RACUN");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RACUNWorkWithWorkItem>("Placa.RACUN");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.RAD1GELEMENTICommand")]
        public void RAD1GELEMENTICommand(object sender, EventArgs e)
        {
            RAD1GELEMENTIWorkWithWorkItem item = this.WorkItem.Items.Get<RAD1GELEMENTIWorkWithWorkItem>("Placa.RAD1GELEMENTI");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RAD1GELEMENTIWorkWithWorkItem>("Placa.RAD1GELEMENTI");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.RAD1GELEMENTIVEZACommand")]
        public void RAD1GELEMENTIVEZACommand(object sender, EventArgs e)
        {
            RAD1GELEMENTIVEZAWorkWithWorkItem item = this.WorkItem.Items.Get<RAD1GELEMENTIVEZAWorkWithWorkItem>("Placa.RAD1GELEMENTIVEZA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RAD1GELEMENTIVEZAWorkWithWorkItem>("Placa.RAD1GELEMENTIVEZA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.RAD1MELEMENTICommand")]
        public void RAD1MELEMENTICommand(object sender, EventArgs e)
        {
            RAD1MELEMENTIWorkWithWorkItem item = this.WorkItem.Items.Get<RAD1MELEMENTIWorkWithWorkItem>("Placa.RAD1MELEMENTI");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RAD1MELEMENTIWorkWithWorkItem>("Placa.RAD1MELEMENTI");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.RAD1MELEMENTIVEZACommand")]
        public void RAD1MELEMENTIVEZACommand(object sender, EventArgs e)
        {
            RAD1MELEMENTIVEZAWorkWithWorkItem item = this.WorkItem.Items.Get<RAD1MELEMENTIVEZAWorkWithWorkItem>("Placa.RAD1MELEMENTIVEZA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RAD1MELEMENTIVEZAWorkWithWorkItem>("Placa.RAD1MELEMENTIVEZA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.RAD1SPOLCommand")]
        public void RAD1SPOLCommand(object sender, EventArgs e)
        {
            RAD1SPOLWorkWithWorkItem item = this.WorkItem.Items.Get<RAD1SPOLWorkWithWorkItem>("Placa.RAD1SPOL");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RAD1SPOLWorkWithWorkItem>("Placa.RAD1SPOL");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.RAD1SPREMECommand")]
        public void RAD1SPREMECommand(object sender, EventArgs e)
        {
            RAD1SPREMEWorkWithWorkItem item = this.WorkItem.Items.Get<RAD1SPREMEWorkWithWorkItem>("Placa.RAD1SPREME");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RAD1SPREMEWorkWithWorkItem>("Placa.RAD1SPREME");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.RAD1SPREMEVEZACommand")]
        public void RAD1SPREMEVEZACommand(object sender, EventArgs e)
        {
            RAD1SPREMEVEZAWorkWithWorkItem item = this.WorkItem.Items.Get<RAD1SPREMEVEZAWorkWithWorkItem>("Placa.RAD1SPREMEVEZA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RAD1SPREMEVEZAWorkWithWorkItem>("Placa.RAD1SPREMEVEZA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.RAD1VEZASPOLCommand")]
        public void RAD1VEZASPOLCommand(object sender, EventArgs e)
        {
            RAD1VEZASPOLWorkWithWorkItem item = this.WorkItem.Items.Get<RAD1VEZASPOLWorkWithWorkItem>("Placa.RAD1VEZASPOL");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RAD1VEZASPOLWorkWithWorkItem>("Placa.RAD1VEZASPOL");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.RADNIKCommand")]
        public void RADNIKCommand(object sender, EventArgs e)
        {
            RADNIKWorkWithWorkItem item = this.WorkItem.Items.Get<RADNIKWorkWithWorkItem>("Placa.RADNIK");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RADNIKWorkWithWorkItem>("Placa.RADNIK");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.RadnikPripremaCommand")]
        public void RadnikPripremaCommand(object sender, EventArgs e)
        {
            RadnikPripremaWorkWithWorkItem item = this.WorkItem.Items.Get<RadnikPripremaWorkWithWorkItem>("Placa.RadnikPriprema");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RadnikPripremaWorkWithWorkItem>("Placa.RadnikPriprema");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.RadnikZaObracunCommand")]
        public void RadnikZaObracunCommand(object sender, EventArgs e)
        {
            RadnikZaObracunWorkWithWorkItem item = this.WorkItem.Items.Get<RadnikZaObracunWorkWithWorkItem>("Placa.RadnikZaObracun");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RadnikZaObracunWorkWithWorkItem>("Placa.RadnikZaObracun");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.RADNOMJESTOCommand")]
        public void RADNOMJESTOCommand(object sender, EventArgs e)
        {
            RADNOMJESTOWorkWithWorkItem item = this.WorkItem.Items.Get<RADNOMJESTOWorkWithWorkItem>("Placa.RADNOMJESTO");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RADNOMJESTOWorkWithWorkItem>("Placa.RADNOMJESTO");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.RADNOVRIJEMECommand")]
        public void RADNOVRIJEMECommand(object sender, EventArgs e)
        {
            RADNOVRIJEMEWorkWithWorkItem item = this.WorkItem.Items.Get<RADNOVRIJEMEWorkWithWorkItem>("Placa.RADNOVRIJEME");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RADNOVRIJEMEWorkWithWorkItem>("Placa.RADNOVRIJEME");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.RSMACommand")]
        public void RSMACommand(object sender, EventArgs e)
        {
            RSMAWorkWithWorkItem item = this.WorkItem.Items.Get<RSMAWorkWithWorkItem>("Placa.RSMA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RSMAWorkWithWorkItem>("Placa.RSMA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.RSMObrazacCommand")]
        public void RSMObrazacCommand(object sender, EventArgs e)
        {
            RSMObrazacWorkItem item = this.WorkItem.Items.Get<RSMObrazacWorkItem>("RSMObrazac");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RSMObrazacWorkItem>("RSMObrazac");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.RSVRSTEOBRACUNACommand")]
        public void RSVRSTEOBRACUNACommand(object sender, EventArgs e)
        {
            RSVRSTEOBRACUNAWorkWithWorkItem item = this.WorkItem.Items.Get<RSVRSTEOBRACUNAWorkWithWorkItem>("Placa.RSVRSTEOBRACUNA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RSVRSTEOBRACUNAWorkWithWorkItem>("Placa.RSVRSTEOBRACUNA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.RSVRSTEOBVEZNIKACommand")]
        public void RSVRSTEOBVEZNIKACommand(object sender, EventArgs e)
        {
            RSVRSTEOBVEZNIKAWorkWithWorkItem item = this.WorkItem.Items.Get<RSVRSTEOBVEZNIKAWorkWithWorkItem>("Placa.RSVRSTEOBVEZNIKA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RSVRSTEOBVEZNIKAWorkWithWorkItem>("Placa.RSVRSTEOBVEZNIKA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_DD_IP1Command")]
        public void S_DD_IP1Command(object sender, EventArgs e)
        {
            S_DD_IP1WorkWithWorkItem item = this.WorkItem.Items.Get<S_DD_IP1WorkWithWorkItem>("Placa.S_DD_IP1");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_DD_IP1WorkWithWorkItem>("Placa.S_DD_IP1");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_DD_IPPCommand")]
        public void S_DD_IPPCommand(object sender, EventArgs e)
        {
            S_DD_IPPWorkWithWorkItem item = this.WorkItem.Items.Get<S_DD_IPPWorkWithWorkItem>("Placa.S_DD_IPP");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_DD_IPPWorkWithWorkItem>("Placa.S_DD_IPP");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_DD_KRIZNI_POREZCommand")]
        public void S_DD_KRIZNI_POREZCommand(object sender, EventArgs e)
        {
            S_DD_KRIZNI_POREZWorkWithWorkItem item = this.WorkItem.Items.Get<S_DD_KRIZNI_POREZWorkWithWorkItem>("Placa.S_DD_KRIZNI_POREZ");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_DD_KRIZNI_POREZWorkWithWorkItem>("Placa.S_DD_KRIZNI_POREZ");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_DD_LISTA_IZNOSA_RADNIKACommand")]
        public void S_DD_LISTA_IZNOSA_RADNIKACommand(object sender, EventArgs e)
        {
            S_DD_LISTA_IZNOSA_RADNIKAWorkWithWorkItem item = this.WorkItem.Items.Get<S_DD_LISTA_IZNOSA_RADNIKAWorkWithWorkItem>("Placa.S_DD_LISTA_IZNOSA_RADNIKA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_DD_LISTA_IZNOSA_RADNIKAWorkWithWorkItem>("Placa.S_DD_LISTA_IZNOSA_RADNIKA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_DD_POTVRDACommand")]
        public void S_DD_POTVRDACommand(object sender, EventArgs e)
        {
            S_DD_POTVRDAWorkWithWorkItem item = this.WorkItem.Items.Get<S_DD_POTVRDAWorkWithWorkItem>("Placa.S_DD_POTVRDA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_DD_POTVRDAWorkWithWorkItem>("Placa.S_DD_POTVRDA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_DD_REKAP_DOPRINOSCommand")]
        public void S_DD_REKAP_DOPRINOSCommand(object sender, EventArgs e)
        {
            S_DD_REKAP_DOPRINOSWorkWithWorkItem item = this.WorkItem.Items.Get<S_DD_REKAP_DOPRINOSWorkWithWorkItem>("Placa.S_DD_REKAP_DOPRINOS");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_DD_REKAP_DOPRINOSWorkWithWorkItem>("Placa.S_DD_REKAP_DOPRINOS");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_FIN_BILANCACommand")]
        public void S_FIN_BILANCACommand(object sender, EventArgs e)
        {
            S_FIN_BILANCAWorkWithWorkItem item = this.WorkItem.Items.Get<S_FIN_BILANCAWorkWithWorkItem>("Placa.S_FIN_BILANCA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_FIN_BILANCAWorkWithWorkItem>("Placa.S_FIN_BILANCA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_FIN_BLAGAJNA_U_GKCommand")]
        public void S_FIN_BLAGAJNA_U_GKCommand(object sender, EventArgs e)
        {
            S_FIN_BLAGAJNA_U_GKWorkWithWorkItem item = this.WorkItem.Items.Get<S_FIN_BLAGAJNA_U_GKWorkWithWorkItem>("Placa.S_FIN_BLAGAJNA_U_GK");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_FIN_BLAGAJNA_U_GKWorkWithWorkItem>("Placa.S_FIN_BLAGAJNA_U_GK");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_FIN_DNEVNIKBLAGAJNECommand")]
        public void S_FIN_DNEVNIKBLAGAJNECommand(object sender, EventArgs e)
        {
            S_FIN_DNEVNIKBLAGAJNEWorkWithWorkItem item = this.WorkItem.Items.Get<S_FIN_DNEVNIKBLAGAJNEWorkWithWorkItem>("Placa.S_FIN_DNEVNIKBLAGAJNE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_FIN_DNEVNIKBLAGAJNEWorkWithWorkItem>("Placa.S_FIN_DNEVNIKBLAGAJNE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_FIN_DNEVNIKBLAGAJNEODDOCommand")]
        public void S_FIN_DNEVNIKBLAGAJNEODDOCommand(object sender, EventArgs e)
        {
            S_FIN_DNEVNIKBLAGAJNEODDOWorkWithWorkItem item = this.WorkItem.Items.Get<S_FIN_DNEVNIKBLAGAJNEODDOWorkWithWorkItem>("Placa.S_FIN_DNEVNIKBLAGAJNEODDO");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_FIN_DNEVNIKBLAGAJNEODDOWorkWithWorkItem>("Placa.S_FIN_DNEVNIKBLAGAJNEODDO");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_FIN_DNEVNIKCommand")]
        public void S_FIN_DNEVNIKCommand(object sender, EventArgs e)
        {
            S_FIN_DNEVNIKWorkWithWorkItem item = this.WorkItem.Items.Get<S_FIN_DNEVNIKWorkWithWorkItem>("Placa.S_FIN_DNEVNIK");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_FIN_DNEVNIKWorkWithWorkItem>("Placa.S_FIN_DNEVNIK");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_FIN_FINANCIJSKO_UPRAVLJANJECommand")]
        public void S_FIN_FINANCIJSKO_UPRAVLJANJECommand(object sender, EventArgs e)
        {
            S_FIN_FINANCIJSKO_UPRAVLJANJEWorkWithWorkItem item = this.WorkItem.Items.Get<S_FIN_FINANCIJSKO_UPRAVLJANJEWorkWithWorkItem>("Placa.S_FIN_FINANCIJSKO_UPRAVLJANJE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_FIN_FINANCIJSKO_UPRAVLJANJEWorkWithWorkItem>("Placa.S_FIN_FINANCIJSKO_UPRAVLJANJE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_FIN_IRA_PLACANJECommand")]
        public void S_FIN_IRA_PLACANJECommand(object sender, EventArgs e)
        {
            S_FIN_IRA_PLACANJEWorkWithWorkItem item = this.WorkItem.Items.Get<S_FIN_IRA_PLACANJEWorkWithWorkItem>("Placa.S_FIN_IRA_PLACANJE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_FIN_IRA_PLACANJEWorkWithWorkItem>("Placa.S_FIN_IRA_PLACANJE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_FIN_IZVRSENJE_PLANACommand")]
        public void S_FIN_IZVRSENJE_PLANACommand(object sender, EventArgs e)
        {
            S_FIN_IZVRSENJE_PLANAWorkWithWorkItem item = this.WorkItem.Items.Get<S_FIN_IZVRSENJE_PLANAWorkWithWorkItem>("Placa.S_FIN_IZVRSENJE_PLANA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_FIN_IZVRSENJE_PLANAWorkWithWorkItem>("Placa.S_FIN_IZVRSENJE_PLANA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_FIN_KARTICEPARTNERACommand")]
        public void S_FIN_KARTICEPARTNERACommand(object sender, EventArgs e)
        {
            S_FIN_KARTICEPARTNERAWorkWithWorkItem item = this.WorkItem.Items.Get<S_FIN_KARTICEPARTNERAWorkWithWorkItem>("Placa.S_FIN_KARTICEPARTNERA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_FIN_KARTICEPARTNERAWorkWithWorkItem>("Placa.S_FIN_KARTICEPARTNERA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_FIN_KONTO_KARTICECommand")]
        public void S_FIN_KONTO_KARTICECommand(object sender, EventArgs e)
        {
            S_FIN_KONTO_KARTICEWorkWithWorkItem item = this.WorkItem.Items.Get<S_FIN_KONTO_KARTICEWorkWithWorkItem>("Placa.S_FIN_KONTO_KARTICE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_FIN_KONTO_KARTICEWorkWithWorkItem>("Placa.S_FIN_KONTO_KARTICE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_FIN_OTVORENE_STAVKECommand")]
        public void S_FIN_OTVORENE_STAVKECommand(object sender, EventArgs e)
        {
            S_FIN_OTVORENE_STAVKEWorkWithWorkItem item = this.WorkItem.Items.Get<S_FIN_OTVORENE_STAVKEWorkWithWorkItem>("Placa.S_FIN_OTVORENE_STAVKE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_FIN_OTVORENE_STAVKEWorkWithWorkItem>("Placa.S_FIN_OTVORENE_STAVKE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_FIN_PARTNERI_SA_OTVORENIMACommand")]
        public void S_FIN_PARTNERI_SA_OTVORENIMACommand(object sender, EventArgs e)
        {
            S_FIN_PARTNERI_SA_OTVORENIMAWorkWithWorkItem item = this.WorkItem.Items.Get<S_FIN_PARTNERI_SA_OTVORENIMAWorkWithWorkItem>("Placa.S_FIN_PARTNERI_SA_OTVORENIMA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_FIN_PARTNERI_SA_OTVORENIMAWorkWithWorkItem>("Placa.S_FIN_PARTNERI_SA_OTVORENIMA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_FIN_PROMET_PO_KONTIMACommand")]
        public void S_FIN_PROMET_PO_KONTIMACommand(object sender, EventArgs e)
        {
            S_FIN_PROMET_PO_KONTIMAWorkWithWorkItem item = this.WorkItem.Items.Get<S_FIN_PROMET_PO_KONTIMAWorkWithWorkItem>("Placa.S_FIN_PROMET_PO_KONTIMA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_FIN_PROMET_PO_KONTIMAWorkWithWorkItem>("Placa.S_FIN_PROMET_PO_KONTIMA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_FIN_PROMET_PO_PARTNERIMACommand")]
        public void S_FIN_PROMET_PO_PARTNERIMACommand(object sender, EventArgs e)
        {
            S_FIN_PROMET_PO_PARTNERIMAWorkWithWorkItem item = this.WorkItem.Items.Get<S_FIN_PROMET_PO_PARTNERIMAWorkWithWorkItem>("Placa.S_FIN_PROMET_PO_PARTNERIMA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_FIN_PROMET_PO_PARTNERIMAWorkWithWorkItem>("Placa.S_FIN_PROMET_PO_PARTNERIMA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_BOLOVANJE_FONDCommand")]
        public void S_OD_BOLOVANJE_FONDCommand(object sender, EventArgs e)
        {
            S_OD_BOLOVANJE_FONDWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_BOLOVANJE_FONDWorkWithWorkItem>("Placa.S_OD_BOLOVANJE_FOND");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_BOLOVANJE_FONDWorkWithWorkItem>("Placa.S_OD_BOLOVANJE_FOND");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_BOLOVANJE_POSLODAVACCommand")]
        public void S_OD_BOLOVANJE_POSLODAVACCommand(object sender, EventArgs e)
        {
            S_OD_BOLOVANJE_POSLODAVACWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_BOLOVANJE_POSLODAVACWorkWithWorkItem>("Placa.S_OD_BOLOVANJE_POSLODAVAC");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_BOLOVANJE_POSLODAVACWorkWithWorkItem>("Placa.S_OD_BOLOVANJE_POSLODAVAC");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_IP_ZBIRNICommand")]
        public void S_OD_IP_ZBIRNICommand(object sender, EventArgs e)
        {
            S_OD_IP_ZBIRNIWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_IP_ZBIRNIWorkWithWorkItem>("Placa.S_OD_IP_ZBIRNI");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_IP_ZBIRNIWorkWithWorkItem>("Placa.S_OD_IP_ZBIRNI");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_IPPCommand")]
        public void S_OD_IPPCommand(object sender, EventArgs e)
        {
            S_OD_IPPWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_IPPWorkWithWorkItem>("Placa.S_OD_IPP");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_IPPWorkWithWorkItem>("Placa.S_OD_IPP");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_KONACNI_POREZ_PO_OPCINAMACommand")]
        public void S_OD_KONACNI_POREZ_PO_OPCINAMACommand(object sender, EventArgs e)
        {
            S_OD_KONACNI_POREZ_PO_OPCINAMAWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_KONACNI_POREZ_PO_OPCINAMAWorkWithWorkItem>("Placa.S_OD_KONACNI_POREZ_PO_OPCINAMA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_KONACNI_POREZ_PO_OPCINAMAWorkWithWorkItem>("Placa.S_OD_KONACNI_POREZ_PO_OPCINAMA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_KONACNICommand")]
        public void S_OD_KONACNICommand(object sender, EventArgs e)
        {
            S_OD_KONACNIWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_KONACNIWorkWithWorkItem>("Placa.S_OD_KONACNI");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_KONACNIWorkWithWorkItem>("Placa.S_OD_KONACNI");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_KREDIT_OBRACUNATCommand")]
        public void S_OD_KREDIT_OBRACUNATCommand(object sender, EventArgs e)
        {
            S_OD_KREDIT_OBRACUNATWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_KREDIT_OBRACUNATWorkWithWorkItem>("Placa.S_OD_KREDIT_OBRACUNAT");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_KREDIT_OBRACUNATWorkWithWorkItem>("Placa.S_OD_KREDIT_OBRACUNAT");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_KRIZNI_POREZCommand")]
        public void S_OD_KRIZNI_POREZCommand(object sender, EventArgs e)
        {
            S_OD_KRIZNI_POREZWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_KRIZNI_POREZWorkWithWorkItem>("Placa.S_OD_KRIZNI_POREZ");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_KRIZNI_POREZWorkWithWorkItem>("Placa.S_OD_KRIZNI_POREZ");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_OBUSTAVA_OBRACUNATACommand")]
        public void S_OD_OBUSTAVA_OBRACUNATACommand(object sender, EventArgs e)
        {
            S_OD_OBUSTAVA_OBRACUNATAWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_OBUSTAVA_OBRACUNATAWorkWithWorkItem>("Placa.S_OD_OBUSTAVA_OBRACUNATA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_OBUSTAVA_OBRACUNATAWorkWithWorkItem>("Placa.S_OD_OBUSTAVA_OBRACUNATA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_OO_MJESECNOCommand")]
        public void S_OD_OO_MJESECNOCommand(object sender, EventArgs e)
        {
            S_OD_OO_MJESECNOWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_OO_MJESECNOWorkWithWorkItem>("Placa.S_OD_OO_MJESECNO");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_OO_MJESECNOWorkWithWorkItem>("Placa.S_OD_OO_MJESECNO");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_POREZ_MJESECNOCommand")]
        public void S_OD_POREZ_MJESECNOCommand(object sender, EventArgs e)
        {
            S_OD_POREZ_MJESECNOWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_POREZ_MJESECNOWorkWithWorkItem>("Placa.S_OD_POREZ_MJESECNO");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_POREZ_MJESECNOWorkWithWorkItem>("Placa.S_OD_POREZ_MJESECNO");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.s_od_pripremaCommand")]
        public void s_od_pripremaCommand(object sender, EventArgs e)
        {
            s_od_pripremaWorkWithWorkItem item = this.WorkItem.Items.Get<s_od_pripremaWorkWithWorkItem>("Placa.s_od_priprema");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<s_od_pripremaWorkWithWorkItem>("Placa.s_od_priprema");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_PROSJEK_PLACECommand")]
        public void S_OD_PROSJEK_PLACECommand(object sender, EventArgs e)
        {
            S_OD_PROSJEK_PLACEWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_PROSJEK_PLACEWorkWithWorkItem>("Placa.S_OD_PROSJEK_PLACE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_PROSJEK_PLACEWorkWithWorkItem>("Placa.S_OD_PROSJEK_PLACE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.s_od_rekap_brutoCommand")]
        public void s_od_rekap_brutoCommand(object sender, EventArgs e)
        {
            s_od_rekap_brutoWorkWithWorkItem item = this.WorkItem.Items.Get<s_od_rekap_brutoWorkWithWorkItem>("Placa.s_od_rekap_bruto");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<s_od_rekap_brutoWorkWithWorkItem>("Placa.s_od_rekap_bruto");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.s_od_rekap_doprinosCommand")]
        public void s_od_rekap_doprinosCommand(object sender, EventArgs e)
        {
            s_od_rekap_doprinosWorkWithWorkItem item = this.WorkItem.Items.Get<s_od_rekap_doprinosWorkWithWorkItem>("Placa.s_od_rekap_doprinos");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<s_od_rekap_doprinosWorkWithWorkItem>("Placa.s_od_rekap_doprinos");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_REKAP_FIKSNECommand")]
        public void S_OD_REKAP_FIKSNECommand(object sender, EventArgs e)
        {
            S_OD_REKAP_FIKSNEWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_REKAP_FIKSNEWorkWithWorkItem>("Placa.S_OD_REKAP_FIKSNE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_REKAP_FIKSNEWorkWithWorkItem>("Placa.S_OD_REKAP_FIKSNE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_REKAP_ISPLATACommand")]
        public void S_OD_REKAP_ISPLATACommand(object sender, EventArgs e)
        {
            S_OD_REKAP_ISPLATAWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_REKAP_ISPLATAWorkWithWorkItem>("Placa.S_OD_REKAP_ISPLATA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_REKAP_ISPLATAWorkWithWorkItem>("Placa.S_OD_REKAP_ISPLATA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_REKAP_KREDITNECommand")]
        public void S_OD_REKAP_KREDITNECommand(object sender, EventArgs e)
        {
            S_OD_REKAP_KREDITNEWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_REKAP_KREDITNEWorkWithWorkItem>("Placa.S_OD_REKAP_KREDITNE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_REKAP_KREDITNEWorkWithWorkItem>("Placa.S_OD_REKAP_KREDITNE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_REKAP_NETOCommand")]
        public void S_OD_REKAP_NETOCommand(object sender, EventArgs e)
        {
            S_OD_REKAP_NETOWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_REKAP_NETOWorkWithWorkItem>("Placa.S_OD_REKAP_NETO");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_REKAP_NETOWorkWithWorkItem>("Placa.S_OD_REKAP_NETO");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_REKAP_OLAKSICECommand")]
        public void S_OD_REKAP_OLAKSICECommand(object sender, EventArgs e)
        {
            S_OD_REKAP_OLAKSICEWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_REKAP_OLAKSICEWorkWithWorkItem>("Placa.S_OD_REKAP_OLAKSICE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_REKAP_OLAKSICEWorkWithWorkItem>("Placa.S_OD_REKAP_OLAKSICE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_REKAP_POREZCommand")]
        public void S_OD_REKAP_POREZCommand(object sender, EventArgs e)
        {
            S_OD_REKAP_POREZWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_REKAP_POREZWorkWithWorkItem>("Placa.S_OD_REKAP_POREZ");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_REKAP_POREZWorkWithWorkItem>("Placa.S_OD_REKAP_POREZ");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_REKAP_POSTOTNECommand")]
        public void S_OD_REKAP_POSTOTNECommand(object sender, EventArgs e)
        {
            S_OD_REKAP_POSTOTNEWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_REKAP_POSTOTNEWorkWithWorkItem>("Placa.S_OD_REKAP_POSTOTNE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_REKAP_POSTOTNEWorkWithWorkItem>("Placa.S_OD_REKAP_POSTOTNE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_STANJE_KREDITACommand")]
        public void S_OD_STANJE_KREDITACommand(object sender, EventArgs e)
        {
            S_OD_STANJE_KREDITAWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_STANJE_KREDITAWorkWithWorkItem>("Placa.S_OD_STANJE_KREDITA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_STANJE_KREDITAWorkWithWorkItem>("Placa.S_OD_STANJE_KREDITA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_STANJE_OBUSTAVACommand")]
        public void S_OD_STANJE_OBUSTAVACommand(object sender, EventArgs e)
        {
            S_OD_STANJE_OBUSTAVAWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_STANJE_OBUSTAVAWorkWithWorkItem>("Placa.S_OD_STANJE_OBUSTAVA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_STANJE_OBUSTAVAWorkWithWorkItem>("Placa.S_OD_STANJE_OBUSTAVA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_STAT_KREDITCommand")]
        public void S_OD_STAT_KREDITCommand(object sender, EventArgs e)
        {
            S_OD_STAT_KREDITWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_STAT_KREDITWorkWithWorkItem>("Placa.S_OD_STAT_KREDIT");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_STAT_KREDITWorkWithWorkItem>("Placa.S_OD_STAT_KREDIT");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_TABLICA01Command")]
        public void S_OD_TABLICA01Command(object sender, EventArgs e)
        {
            S_OD_TABLICA01WorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_TABLICA01WorkWithWorkItem>("Placa.S_OD_TABLICA01");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_TABLICA01WorkWithWorkItem>("Placa.S_OD_TABLICA01");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJICommand")]
        public void S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJICommand(object sender, EventArgs e)
        {
            S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIWorkWithWorkItem item = this.WorkItem.Items.Get<S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIWorkWithWorkItem>("Placa.S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIWorkWithWorkItem>("Placa.S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OS_BROJ_I_DATUMCommand")]
        public void S_OS_BROJ_I_DATUMCommand(object sender, EventArgs e)
        {
            S_OS_BROJ_I_DATUMWorkWithWorkItem item = this.WorkItem.Items.Get<S_OS_BROJ_I_DATUMWorkWithWorkItem>("Placa.S_OS_BROJ_I_DATUM");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OS_BROJ_I_DATUMWorkWithWorkItem>("Placa.S_OS_BROJ_I_DATUM");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OS_POSTOJECI_DOKUMENTICommand")]
        public void S_OS_POSTOJECI_DOKUMENTICommand(object sender, EventArgs e)
        {
            S_OS_POSTOJECI_DOKUMENTIWorkWithWorkItem item = this.WorkItem.Items.Get<S_OS_POSTOJECI_DOKUMENTIWorkWithWorkItem>("Placa.S_OS_POSTOJECI_DOKUMENTI");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OS_POSTOJECI_DOKUMENTIWorkWithWorkItem>("Placa.S_OS_POSTOJECI_DOKUMENTI");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJACommand")]
        public void S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJACommand(object sender, EventArgs e)
        {
            S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJAWorkWithWorkItem item = this.WorkItem.Items.Get<S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJAWorkWithWorkItem>("Placa.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJAWorkWithWorkItem>("Placa.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OS_REKAP_TEMELJNICECommand")]
        public void S_OS_REKAP_TEMELJNICECommand(object sender, EventArgs e)
        {
            S_OS_REKAP_TEMELJNICEWorkWithWorkItem item = this.WorkItem.Items.Get<S_OS_REKAP_TEMELJNICEWorkWithWorkItem>("Placa.S_OS_REKAP_TEMELJNICE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OS_REKAP_TEMELJNICEWorkWithWorkItem>("Placa.S_OS_REKAP_TEMELJNICE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICACommand")]
        public void S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICACommand(object sender, EventArgs e)
        {
            S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICAWorkWithWorkItem item = this.WorkItem.Items.Get<S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICAWorkWithWorkItem>("Placa.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICAWorkWithWorkItem>("Placa.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OS_STANJE_LOKACIJACommand")]
        public void S_OS_STANJE_LOKACIJACommand(object sender, EventArgs e)
        {
            S_OS_STANJE_LOKACIJAWorkWithWorkItem item = this.WorkItem.Items.Get<S_OS_STANJE_LOKACIJAWorkWithWorkItem>("Placa.S_OS_STANJE_LOKACIJA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OS_STANJE_LOKACIJAWorkWithWorkItem>("Placa.S_OS_STANJE_LOKACIJA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMACommand")]
        public void S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMACommand(object sender, EventArgs e)
        {
            S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMAWorkWithWorkItem item = this.WorkItem.Items.Get<S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMAWorkWithWorkItem>("Placa.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMAWorkWithWorkItem>("Placa.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_PLACA_KONACNI_REKAPOPCINECommand")]
        public void S_PLACA_KONACNI_REKAPOPCINECommand(object sender, EventArgs e)
        {
            S_PLACA_KONACNI_REKAPOPCINEWorkWithWorkItem item = this.WorkItem.Items.Get<S_PLACA_KONACNI_REKAPOPCINEWorkWithWorkItem>("Placa.S_PLACA_KONACNI_REKAPOPCINE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_PLACA_KONACNI_REKAPOPCINEWorkWithWorkItem>("Placa.S_PLACA_KONACNI_REKAPOPCINE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_PLACA_KREDITI_KARTICECommand")]
        public void S_PLACA_KREDITI_KARTICECommand(object sender, EventArgs e)
        {
            S_PLACA_KREDITI_KARTICEWorkWithWorkItem item = this.WorkItem.Items.Get<S_PLACA_KREDITI_KARTICEWorkWithWorkItem>("Placa.S_PLACA_KREDITI_KARTICE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_PLACA_KREDITI_KARTICEWorkWithWorkItem>("Placa.S_PLACA_KREDITI_KARTICE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_PLACA_ODBICI_GODINACommand")]
        public void S_PLACA_ODBICI_GODINACommand(object sender, EventArgs e)
        {
            S_PLACA_ODBICI_GODINAWorkWithWorkItem item = this.WorkItem.Items.Get<S_PLACA_ODBICI_GODINAWorkWithWorkItem>("Placa.S_PLACA_ODBICI_GODINA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_PLACA_ODBICI_GODINAWorkWithWorkItem>("Placa.S_PLACA_ODBICI_GODINA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_PLACA_RAD1G_IIICommand")]
        public void S_PLACA_RAD1G_IIICommand(object sender, EventArgs e)
        {
            S_PLACA_RAD1G_IIIWorkWithWorkItem item = this.WorkItem.Items.Get<S_PLACA_RAD1G_IIIWorkWithWorkItem>("Placa.S_PLACA_RAD1G_III");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_PLACA_RAD1G_IIIWorkWithWorkItem>("Placa.S_PLACA_RAD1G_III");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_PLACA_RAD1G_IVCommand")]
        public void S_PLACA_RAD1G_IVCommand(object sender, EventArgs e)
        {
            S_PLACA_RAD1G_IVWorkWithWorkItem item = this.WorkItem.Items.Get<S_PLACA_RAD1G_IVWorkWithWorkItem>("Placa.S_PLACA_RAD1G_IV");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_PLACA_RAD1G_IVWorkWithWorkItem>("Placa.S_PLACA_RAD1G_IV");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_PLACA_RAD1G_SATICommand")]
        public void S_PLACA_RAD1G_SATICommand(object sender, EventArgs e)
        {
            S_PLACA_RAD1G_SATIWorkWithWorkItem item = this.WorkItem.Items.Get<S_PLACA_RAD1G_SATIWorkWithWorkItem>("Placa.S_PLACA_RAD1G_SATI");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_PLACA_RAD1G_SATIWorkWithWorkItem>("Placa.S_PLACA_RAD1G_SATI");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_PLACA_RAD1GCommand")]
        public void S_PLACA_RAD1GCommand(object sender, EventArgs e)
        {
            S_PLACA_RAD1GWorkWithWorkItem item = this.WorkItem.Items.Get<S_PLACA_RAD1GWorkWithWorkItem>("Placa.S_PLACA_RAD1G");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_PLACA_RAD1GWorkWithWorkItem>("Placa.S_PLACA_RAD1G");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_PLACA_RAD1M_DIO1Command")]
        public void S_PLACA_RAD1M_DIO1Command(object sender, EventArgs e)
        {
            S_PLACA_RAD1M_DIO1WorkWithWorkItem item = this.WorkItem.Items.Get<S_PLACA_RAD1M_DIO1WorkWithWorkItem>("Placa.S_PLACA_RAD1M_DIO1");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_PLACA_RAD1M_DIO1WorkWithWorkItem>("Placa.S_PLACA_RAD1M_DIO1");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_PLACA_RAD1M_DIO2Command")]
        public void S_PLACA_RAD1M_DIO2Command(object sender, EventArgs e)
        {
            S_PLACA_RAD1M_DIO2WorkWithWorkItem item = this.WorkItem.Items.Get<S_PLACA_RAD1M_DIO2WorkWithWorkItem>("Placa.S_PLACA_RAD1M_DIO2");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_PLACA_RAD1M_DIO2WorkWithWorkItem>("Placa.S_PLACA_RAD1M_DIO2");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_PLACA_RAD1M_DIO3Command")]
        public void S_PLACA_RAD1M_DIO3Command(object sender, EventArgs e)
        {
            S_PLACA_RAD1M_DIO3WorkWithWorkItem item = this.WorkItem.Items.Get<S_PLACA_RAD1M_DIO3WorkWithWorkItem>("Placa.S_PLACA_RAD1M_DIO3");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_PLACA_RAD1M_DIO3WorkWithWorkItem>("Placa.S_PLACA_RAD1M_DIO3");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.SHEMADDCommand")]
        public void SHEMADDCommand(object sender, EventArgs e)
        {
            SHEMADDWorkWithWorkItem item = this.WorkItem.Items.Get<SHEMADDWorkWithWorkItem>("Placa.SHEMADD");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<SHEMADDWorkWithWorkItem>("Placa.SHEMADD");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.SHEMAIRACommand")]
        public void SHEMAIRACommand(object sender, EventArgs e)
        {
            SHEMAIRAWorkWithWorkItem item = this.WorkItem.Items.Get<SHEMAIRAWorkWithWorkItem>("Placa.SHEMAIRA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<SHEMAIRAWorkWithWorkItem>("Placa.SHEMAIRA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.SHEMAPLACACommand")]
        public void SHEMAPLACACommand(object sender, EventArgs e)
        {
            SHEMAPLACAWorkWithWorkItem item = this.WorkItem.Items.Get<SHEMAPLACAWorkWithWorkItem>("Placa.SHEMAPLACA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<SHEMAPLACAWorkWithWorkItem>("Placa.SHEMAPLACA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.SHEMAURACommand")]
        public void SHEMAURACommand(object sender, EventArgs e)
        {
            SHEMAURAWorkWithWorkItem item = this.WorkItem.Items.Get<SHEMAURAWorkWithWorkItem>("Placa.SHEMAURA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<SHEMAURAWorkWithWorkItem>("Placa.SHEMAURA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.SKUPPOREZAIDOPRINOSACommand")]
        public void SKUPPOREZAIDOPRINOSACommand(object sender, EventArgs e)
        {
            SKUPPOREZAIDOPRINOSAWorkWithWorkItem item = this.WorkItem.Items.Get<SKUPPOREZAIDOPRINOSAWorkWithWorkItem>("Placa.SKUPPOREZAIDOPRINOSA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<SKUPPOREZAIDOPRINOSAWorkWithWorkItem>("Placa.SKUPPOREZAIDOPRINOSA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.SMJENECommand")]
        public void SMJENECommand(object sender, EventArgs e)
        {
            SMJENEWorkWithWorkItem item = this.WorkItem.Items.Get<SMJENEWorkWithWorkItem>("Placa.SMJENE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<SMJENEWorkWithWorkItem>("Placa.SMJENE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.sp_diskete_za_bankuCommand")]
        public void sp_diskete_za_bankuCommand(object sender, EventArgs e)
        {
            sp_diskete_za_bankuWorkWithWorkItem item = this.WorkItem.Items.Get<sp_diskete_za_bankuWorkWithWorkItem>("Placa.sp_diskete_za_banku");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<sp_diskete_za_bankuWorkWithWorkItem>("Placa.sp_diskete_za_banku");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.SP_FIN_URAPLACANJECommand")]
        public void SP_FIN_URAPLACANJECommand(object sender, EventArgs e)
        {
            SP_FIN_URAPLACANJEWorkWithWorkItem item = this.WorkItem.Items.Get<SP_FIN_URAPLACANJEWorkWithWorkItem>("Placa.SP_FIN_URAPLACANJE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<SP_FIN_URAPLACANJEWorkWithWorkItem>("Placa.SP_FIN_URAPLACANJE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.sp_id_detaljiCommand")]
        public void sp_id_detaljiCommand(object sender, EventArgs e)
        {
            sp_id_detaljiWorkWithWorkItem item = this.WorkItem.Items.Get<sp_id_detaljiWorkWithWorkItem>("Placa.sp_id_detalji");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<sp_id_detaljiWorkWithWorkItem>("Placa.sp_id_detalji");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.sp_id_zaglavljeCommand")]
        public void sp_id_zaglavljeCommand(object sender, EventArgs e)
        {
            sp_id_zaglavljeWorkWithWorkItem item = this.WorkItem.Items.Get<sp_id_zaglavljeWorkWithWorkItem>("Placa.sp_id_zaglavlje");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<sp_id_zaglavljeWorkWithWorkItem>("Placa.sp_id_zaglavlje");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.sp_ip_detaljiCommand")]
        public void sp_ip_detaljiCommand(object sender, EventArgs e)
        {
            sp_ip_detaljiWorkWithWorkItem item = this.WorkItem.Items.Get<sp_ip_detaljiWorkWithWorkItem>("Placa.sp_ip_detalji");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<sp_ip_detaljiWorkWithWorkItem>("Placa.sp_ip_detalji");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.sp_ip_zaglavljeCommand")]
        public void sp_ip_zaglavljeCommand(object sender, EventArgs e)
        {
            sp_ip_zaglavljeWorkWithWorkItem item = this.WorkItem.Items.Get<sp_ip_zaglavljeWorkWithWorkItem>("Placa.sp_ip_zaglavlje");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<sp_ip_zaglavljeWorkWithWorkItem>("Placa.sp_ip_zaglavlje");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.SP_LISTA_IZNOSA_RADNIKACommand")]
        public void SP_LISTA_IZNOSA_RADNIKACommand(object sender, EventArgs e)
        {
            SP_LISTA_IZNOSA_RADNIKAWorkWithWorkItem item = this.WorkItem.Items.Get<SP_LISTA_IZNOSA_RADNIKAWorkWithWorkItem>("Placa.SP_LISTA_IZNOSA_RADNIKA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<SP_LISTA_IZNOSA_RADNIKAWorkWithWorkItem>("Placa.SP_LISTA_IZNOSA_RADNIKA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.sp_maticni_kartonCommand")]
        public void sp_maticni_kartonCommand(object sender, EventArgs e)
        {
            sp_maticni_kartonWorkWithWorkItem item = this.WorkItem.Items.Get<sp_maticni_kartonWorkWithWorkItem>("Placa.sp_maticni_karton");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<sp_maticni_kartonWorkWithWorkItem>("Placa.sp_maticni_karton");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.sp_RSOBRAZACCommand")]
        public void sp_RSOBRAZACCommand(object sender, EventArgs e)
        {
            sp_RSOBRAZACWorkWithWorkItem item = this.WorkItem.Items.Get<sp_RSOBRAZACWorkWithWorkItem>("Placa.sp_RSOBRAZAC");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<sp_RSOBRAZACWorkWithWorkItem>("Placa.sp_RSOBRAZAC");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.sp_VIRMANICommand")]
        public void sp_VIRMANICommand(object sender, EventArgs e)
        {
            sp_VIRMANIWorkWithWorkItem item = this.WorkItem.Items.Get<sp_VIRMANIWorkWithWorkItem>("Placa.sp_VIRMANI");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<sp_VIRMANIWorkWithWorkItem>("Placa.sp_VIRMANI");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.sp_zap1Command")]
        public void sp_zap1Command(object sender, EventArgs e)
        {
            sp_zap1WorkWithWorkItem item = this.WorkItem.Items.Get<sp_zap1WorkWithWorkItem>("Placa.sp_zap1");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<sp_zap1WorkWithWorkItem>("Placa.sp_zap1");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.SPOLCommand")]
        public void SPOLCommand(object sender, EventArgs e)
        {
            SPOLWorkWithWorkItem item = this.WorkItem.Items.Get<SPOLWorkWithWorkItem>("Placa.SPOL");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<SPOLWorkWithWorkItem>("Placa.SPOL");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.STRANEKNJIZENJACommand")]
        public void STRANEKNJIZENJACommand(object sender, EventArgs e)
        {
            STRANEKNJIZENJAWorkWithWorkItem item = this.WorkItem.Items.Get<STRANEKNJIZENJAWorkWithWorkItem>("Placa.STRANEKNJIZENJA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<STRANEKNJIZENJAWorkWithWorkItem>("Placa.STRANEKNJIZENJA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.STRUCNASPREMACommand")]
        public void STRUCNASPREMACommand(object sender, EventArgs e)
        {
            STRUCNASPREMAWorkWithWorkItem item = this.WorkItem.Items.Get<STRUCNASPREMAWorkWithWorkItem>("Placa.STRUCNASPREMA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<STRUCNASPREMAWorkWithWorkItem>("Placa.STRUCNASPREMA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.STRUKACommand")]
        public void STRUKACommand(object sender, EventArgs e)
        {
            STRUKAWorkWithWorkItem item = this.WorkItem.Items.Get<STRUKAWorkWithWorkItem>("Placa.STRUKA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<STRUKAWorkWithWorkItem>("Placa.STRUKA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Tablica018Command")]
        public void Tablica018CommandHandler(object sender, EventArgs e)
        {
            Tablica018WorkItem item = this.WorkItem.Items.Get<Tablica018WorkItem>("Tablica018WorkItem");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<Tablica018WorkItem>("Tablica018WorkItem");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Tablica01Command")]
        public void Tablica01CommandHandler(object sender, EventArgs e)
        {
            Tablica01WorkItem item = this.WorkItem.Items.Get<Tablica01WorkItem>("Tablica01WorkItem");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<Tablica01WorkItem>("Tablica01WorkItem");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("OS.TablicniRazmjestaj")]
        public void TablicniRazmjestajCommandHandler(object sender, EventArgs e)
        {
            TablicniRazmjestajSredstavaWorkWith with = this.WorkItem.Items.Get<TablicniRazmjestajSredstavaWorkWith>("TablicniRazmjestaj");
            if (with == null)
            {
                with = this.WorkItem.Items.AddNew<TablicniRazmjestajSredstavaWorkWith>("TablicniRazmjestaj");
            }
            with.Show(with.Workspaces["main"]);
        }

        [CommandHandler("Placa.TIPDOKUMENTACommand")]
        public void TIPDOKUMENTACommand(object sender, EventArgs e)
        {
            TIPDOKUMENTAWorkWithWorkItem item = this.WorkItem.Items.Get<TIPDOKUMENTAWorkWithWorkItem>("Placa.TIPDOKUMENTA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<TIPDOKUMENTAWorkWithWorkItem>("Placa.TIPDOKUMENTA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.TIPIZNOSACommand")]
        public void TIPIZNOSACommand(object sender, EventArgs e)
        {
            TIPIZNOSAWorkWithWorkItem item = this.WorkItem.Items.Get<TIPIZNOSAWorkWithWorkItem>("Placa.TIPIZNOSA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<TIPIZNOSAWorkWithWorkItem>("Placa.TIPIZNOSA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.TIPOLAKSICECommand")]
        public void TIPOLAKSICECommand(object sender, EventArgs e)
        {
            TIPOLAKSICEWorkWithWorkItem item = this.WorkItem.Items.Get<TIPOLAKSICEWorkWithWorkItem>("Placa.TIPOLAKSICE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<TIPOLAKSICEWorkWithWorkItem>("Placa.TIPOLAKSICE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.TIPURACommand")]
        public void TIPURACommand(object sender, EventArgs e)
        {
            TIPURAWorkWithWorkItem item = this.WorkItem.Items.Get<TIPURAWorkWithWorkItem>("Placa.TIPURA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<TIPURAWorkWithWorkItem>("Placa.TIPURA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.TITULACommand")]
        public void TITULACommand(object sender, EventArgs e)
        {
            TITULAWorkWithWorkItem item = this.WorkItem.Items.Get<TITULAWorkWithWorkItem>("Placa.TITULA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<TITULAWorkWithWorkItem>("Placa.TITULA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.trazi_partneraCommand")]
        public void trazi_partneraCommand(object sender, EventArgs e)
        {
            trazi_partneraWorkWithWorkItem item = this.WorkItem.Items.Get<trazi_partneraWorkWithWorkItem>("Placa.trazi_partnera");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<trazi_partneraWorkWithWorkItem>("Placa.trazi_partnera");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.trazi_proizvodCommand")]
        public void trazi_proizvodCommand(object sender, EventArgs e)
        {
            trazi_proizvodWorkWithWorkItem item = this.WorkItem.Items.Get<trazi_proizvodWorkWithWorkItem>("Placa.trazi_proizvod");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<trazi_proizvodWorkWithWorkItem>("Placa.trazi_proizvod");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.UCENIKCommand")]
        public void UCENIKCommand(object sender, EventArgs e)
        {
            UCENIKWorkWithWorkItem item = this.WorkItem.Items.Get<UCENIKWorkWithWorkItem>("Placa.UCENIK");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<UCENIKWorkWithWorkItem>("Placa.UCENIK");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.UCENIKOBRACUNCommand")]
        public void UCENIKOBRACUNCommand(object sender, EventArgs e)
        {
            UCENIKOBRACUNWorkWithWorkItem item = this.WorkItem.Items.Get<UCENIKOBRACUNWorkWithWorkItem>("Placa.UCENIKOBRACUN");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<UCENIKOBRACUNWorkWithWorkItem>("Placa.UCENIKOBRACUN");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.UCENIKRSMIDENTCommand")]
        public void UCENIKRSMIDENTCommand(object sender, EventArgs e)
        {
            UCENIKRSMIDENTWorkWithWorkItem item = this.WorkItem.Items.Get<UCENIKRSMIDENTWorkWithWorkItem>("Placa.UCENIKRSMIDENT");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<UCENIKRSMIDENTWorkWithWorkItem>("Placa.UCENIKRSMIDENT");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.UGOVORORADUCommand")]
        public void UGOVORORADUCommand(object sender, EventArgs e)
        {
            UGOVORORADUWorkWithWorkItem item = this.WorkItem.Items.Get<UGOVORORADUWorkWithWorkItem>("Placa.UGOVORORADU");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<UGOVORORADUWorkWithWorkItem>("Placa.UGOVORORADU");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("OS.UnosTemeljnice")]
        public void UnosTemeljniceCommandHandler(object sender, EventArgs e)
        {
            UnosTemeljniceWorkWith with = this.WorkItem.Items.Get<UnosTemeljniceWorkWith>("UnosTemeljniceOS");
            if (with == null)
            {
                with = this.WorkItem.Items.AddNew<UnosTemeljniceWorkWith>("UnosTemeljniceOS");
            }
            with.Show(with.Workspaces["main"]);
        }

        [CommandHandler("Placa.URACommand")]
        public void URACommand(object sender, EventArgs e)
        {
            URAWorkWithWorkItem item = this.WorkItem.Items.Get<URAWorkWithWorkItem>("Placa.URA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<URAWorkWithWorkItem>("Placa.URA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.uraDocsCommand")]
        public void uraDocsCommand(object sender, EventArgs e)
        {
            uraDocsWorkWithWorkItem item = this.WorkItem.Items.Get<uraDocsWorkWithWorkItem>("Placa.uraDocs");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<uraDocsWorkWithWorkItem>("Placa.uraDocs");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.URAVRSTAIZNOSACommand")]
        public void URAVRSTAIZNOSACommand(object sender, EventArgs e)
        {
            URAVRSTAIZNOSAWorkWithWorkItem item = this.WorkItem.Items.Get<URAVRSTAIZNOSAWorkWithWorkItem>("Placa.URAVRSTAIZNOSA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<URAVRSTAIZNOSAWorkWithWorkItem>("Placa.URAVRSTAIZNOSA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.V_DD_GODINE_ISPLATECommand")]
        public void V_DD_GODINE_ISPLATECommand(object sender, EventArgs e)
        {
            V_DD_GODINE_ISPLATEWorkWithWorkItem item = this.WorkItem.Items.Get<V_DD_GODINE_ISPLATEWorkWithWorkItem>("Placa.V_DD_GODINE_ISPLATE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<V_DD_GODINE_ISPLATEWorkWithWorkItem>("Placa.V_DD_GODINE_ISPLATE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.V_DD_PREGLED_OBRACUNACommand")]
        public void V_DD_PREGLED_OBRACUNACommand(object sender, EventArgs e)
        {
            V_DD_PREGLED_OBRACUNAWorkWithWorkItem item = this.WorkItem.Items.Get<V_DD_PREGLED_OBRACUNAWorkWithWorkItem>("Placa.V_DD_PREGLED_OBRACUNA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<V_DD_PREGLED_OBRACUNAWorkWithWorkItem>("Placa.V_DD_PREGLED_OBRACUNA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.VALUTECommand")]
        public void VALUTECommand(object sender, EventArgs e)
        {
            VALUTEWorkWithWorkItem item = this.WorkItem.Items.Get<VALUTEWorkWithWorkItem>("Placa.VALUTE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<VALUTEWorkWithWorkItem>("Placa.VALUTE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.VERZIJACommand")]
        public void VERZIJACommand(object sender, EventArgs e)
        {
            VERZIJAWorkWithWorkItem item = this.WorkItem.Items.Get<VERZIJAWorkWithWorkItem>("Placa.VERZIJA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<VERZIJAWorkWithWorkItem>("Placa.VERZIJA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.VIRMANICommand")]
        public void VIRMANICommand(object sender, EventArgs e)
        {
            VIRMANIWorkWithWorkItem item = this.WorkItem.Items.Get<VIRMANIWorkWithWorkItem>("Placa.VIRMANI");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<VIRMANIWorkWithWorkItem>("Placa.VIRMANI");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.VirmaniUserCommand")]
        public void VirmaniUserCommand(object sender, EventArgs e)
        {
            VirmaniWorkItemUser user = this.WorkItem.Items.Get<VirmaniWorkItemUser>("Virmani");
            if (user == null)
            {
                user = this.WorkItem.Items.AddNew<VirmaniWorkItemUser>("Virmani");
            }
            user.Show(user.Workspaces["main"]);
        }

        [CommandHandler("Placa.VRSTADOPRINOSCommand")]
        public void VRSTADOPRINOSCommand(object sender, EventArgs e)
        {
            VRSTADOPRINOSWorkWithWorkItem item = this.WorkItem.Items.Get<VRSTADOPRINOSWorkWithWorkItem>("Placa.VRSTADOPRINOS");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<VRSTADOPRINOSWorkWithWorkItem>("Placa.VRSTADOPRINOS");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.VRSTAELEMENTCommand")]
        public void VRSTAELEMENTCommand(object sender, EventArgs e)
        {
            VRSTAELEMENTWorkWithWorkItem item = this.WorkItem.Items.Get<VRSTAELEMENTWorkWithWorkItem>("Placa.VRSTAELEMENT");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<VRSTAELEMENTWorkWithWorkItem>("Placa.VRSTAELEMENT");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.VRSTAOBUSTAVECommand")]
        public void VRSTAOBUSTAVECommand(object sender, EventArgs e)
        {
            VRSTAOBUSTAVEWorkWithWorkItem item = this.WorkItem.Items.Get<VRSTAOBUSTAVEWorkWithWorkItem>("Placa.VRSTAOBUSTAVE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<VRSTAOBUSTAVEWorkWithWorkItem>("Placa.VRSTAOBUSTAVE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.vw_DD_MJESECI_GODINE_ISPLATECommand")]
        public void vw_DD_MJESECI_GODINE_ISPLATECommand(object sender, EventArgs e)
        {
            vw_DD_MJESECI_GODINE_ISPLATEWorkWithWorkItem item = this.WorkItem.Items.Get<vw_DD_MJESECI_GODINE_ISPLATEWorkWithWorkItem>("Placa.vw_DD_MJESECI_GODINE_ISPLATE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<vw_DD_MJESECI_GODINE_ISPLATEWorkWithWorkItem>("Placa.vw_DD_MJESECI_GODINE_ISPLATE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.VW_GODINE_ISPLATECommand")]
        public void VW_GODINE_ISPLATECommand(object sender, EventArgs e)
        {
            VW_GODINE_ISPLATEWorkWithWorkItem item = this.WorkItem.Items.Get<VW_GODINE_ISPLATEWorkWithWorkItem>("Placa.VW_GODINE_ISPLATE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<VW_GODINE_ISPLATEWorkWithWorkItem>("Placa.VW_GODINE_ISPLATE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.VW_GODINE_OBRACUNACommand")]
        public void VW_GODINE_OBRACUNACommand(object sender, EventArgs e)
        {
            VW_GODINE_OBRACUNAWorkWithWorkItem item = this.WorkItem.Items.Get<VW_GODINE_OBRACUNAWorkWithWorkItem>("Placa.VW_GODINE_OBRACUNA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<VW_GODINE_OBRACUNAWorkWithWorkItem>("Placa.VW_GODINE_OBRACUNA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.vw_mjeseci_godine_isplateCommand")]
        public void vw_mjeseci_godine_isplateCommand(object sender, EventArgs e)
        {
            vw_mjeseci_godine_isplateWorkWithWorkItem item = this.WorkItem.Items.Get<vw_mjeseci_godine_isplateWorkWithWorkItem>("Placa.vw_mjeseci_godine_isplate");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<vw_mjeseci_godine_isplateWorkWithWorkItem>("Placa.vw_mjeseci_godine_isplate");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.VW_MJESECI_GODINE_OBRACUNACommand")]
        public void VW_MJESECI_GODINE_OBRACUNACommand(object sender, EventArgs e)
        {
            VW_MJESECI_GODINE_OBRACUNAWorkWithWorkItem item = this.WorkItem.Items.Get<VW_MJESECI_GODINE_OBRACUNAWorkWithWorkItem>("Placa.VW_MJESECI_GODINE_OBRACUNA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<VW_MJESECI_GODINE_OBRACUNAWorkWithWorkItem>("Placa.VW_MJESECI_GODINE_OBRACUNA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.VW_ZADUZENI_PARTNERICommand")]
        public void VW_ZADUZENI_PARTNERICommand(object sender, EventArgs e)
        {
            VW_ZADUZENI_PARTNERIWorkWithWorkItem item = this.WorkItem.Items.Get<VW_ZADUZENI_PARTNERIWorkWithWorkItem>("Placa.VW_ZADUZENI_PARTNERI");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<VW_ZADUZENI_PARTNERIWorkWithWorkItem>("Placa.VW_ZADUZENI_PARTNERI");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("ZAP1Command")]
        public void ZAP1CommandHandler(object sender, EventArgs e)
        {
            Zap1WorkItem item = this.WorkItem.Items.Get<Zap1WorkItem>("Zap1");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<Zap1WorkItem>("Zap1");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.ZAPOSLENICommand")]
        public void ZAPOSLENICommand(object sender, EventArgs e)
        {
            ZAPOSLENIWorkWithWorkItem item = this.WorkItem.Items.Get<ZAPOSLENIWorkWithWorkItem>("Placa.ZAPOSLENI");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<ZAPOSLENIWorkWithWorkItem>("Placa.ZAPOSLENI");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.ZATVARANJACommand")]
        public void ZATVARANJACommand(object sender, EventArgs e)
        {
            ZATVARANJAWorkWithWorkItem item = this.WorkItem.Items.Get<ZATVARANJAWorkWithWorkItem>("Placa.ZATVARANJA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<ZATVARANJAWorkWithWorkItem>("Placa.ZATVARANJA");
            }
            item.Show(item.Workspaces["main"]);
        }

    }
}


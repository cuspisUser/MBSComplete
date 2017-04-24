using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Deklarit.Practices.CompositeUI.Commands;
using Materijalno.UI.Dokumenti;
using Materijalno.UI.Skladista;
using NetAdvantage.WorkItems;
using CrystalDecisions.CrystalReports.Engine;
using Deklarit.Practices.CompositeUI.Workspaces;
using System.Data;
using System.Data.SqlClient;
using Placa;
using System.Runtime.CompilerServices;
using CrystalDecisions.Shared;

namespace Materijalno
{
    public class MainController : Controller
    {
        #region Matični podaci 

        [CommandHandler("MT.Primka")]
        public void Primka_Command(object sender, EventArgs e)
        {
            PrimkaFormPregledWorkItem item = this.WorkItem.Items.Get<PrimkaFormPregledWorkItem>("MT.Primka");

            if (item == null)
            {
                item = WorkItem.Items.AddNew<PrimkaFormPregledWorkItem>("MT.Primka");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("MT.Meduskladisnica")]
        public void Meduskladisnica_Command(object sender, EventArgs e)
        {
            UnosMeduskladisniceFormPregledWorkItem item = this.WorkItem.Items.Get<UnosMeduskladisniceFormPregledWorkItem>("MT.Meduskladisnica");

            if (item == null)
            {
                item = WorkItem.Items.AddNew<UnosMeduskladisniceFormPregledWorkItem>("MT.Meduskladisnica");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("MT.Skladiste")]
        public void Skladiste_Command(object sender, EventArgs e)
        {
            OtvaranjeSkladistaFormWorkItem item = this.WorkItem.Items.Get<OtvaranjeSkladistaFormWorkItem>("MT.Skladiste");

            if (item == null)
            {
                item = WorkItem.Items.AddNew<OtvaranjeSkladistaFormWorkItem>("MT.Skladiste");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("MT.SkladistePregled")]
        public void SkladistePregled_Command(object sender, EventArgs e)
        {
            UI.Skladista.frmSkladiste objekt = new UI.Skladista.frmSkladiste();

            if (objekt.ShowDialog() == DialogResult.OK)
            {
                SkladistePregledWorkItem item = this.WorkItem.Items.Get<SkladistePregledWorkItem>("MT.SkladistePregled");

                if (item == null)
                {
                    item = WorkItem.Items.AddNew<SkladistePregledWorkItem>("MT.SkladistePregled");
                }
                item.Show(item.Workspaces["main"]);
            }
        }

        [CommandHandler("MT.TipSkladista")]
        public void TipSkladista_Command(object sender, EventArgs e)
        {
            TipSkladistaFormWorkItem item = this.WorkItem.Items.Get<TipSkladistaFormWorkItem>("MT.TipSkladista");

            if (item == null)
            {
                item = WorkItem.Items.AddNew<TipSkladistaFormWorkItem>("MT.TipSkladista");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("MT.Izdatnica")]
        public void Izdatnica_Command(object sender, EventArgs e)
        {
            IzdatnicaWorkItem item = this.WorkItem.Items.Get<IzdatnicaWorkItem>("MT.Izdatnica");

            if (item == null)
            {
                item = WorkItem.Items.AddNew<IzdatnicaWorkItem>("MT.Izdatnica");
            }
            item.Show(item.Workspaces["main"]);
        }

        //db - 30.11.2016
        [CommandHandler("MT.Inventura")]
        public void Inventura_Command(object sender, EventArgs e)
        {
            InventuraWorkItem item = this.WorkItem.Items.Get<InventuraWorkItem>("MT.Inventura");

            if (item == null)
            {
                item = WorkItem.Items.AddNew<InventuraWorkItem>("MT.Inventura");
            }
            item.Show(item.Workspaces["main"]);
        }
        
      
        [CommandHandler("MT.Narudzbenica")]
        public void Narudzbenica_Command(object sender, EventArgs e)
        {
            JavnaNabava.UI.Nabava.NarudzbenicaFormPregledWorkItem item = this.WorkItem.Items.Get<JavnaNabava.UI.Nabava.NarudzbenicaFormPregledWorkItem>("MT.Narudzbenica");

            if (item == null)
            {
                item = WorkItem.Items.AddNew<JavnaNabava.UI.Nabava.NarudzbenicaFormPregledWorkItem>("MT.Narudzbenica");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("MT.KarticaMaterijala")]
        public void KarticaMaterijala_Command(object sender, EventArgs e)
        {
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
            {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - Kartica reprodukcijskog materijala",
                Description = "Pregled izvještaja - Kartica reprodukcijskog materijala"
            };
            ReportDocument rpt = new ReportDocument();
            string datumOd;
            string datumDo;
            rpt.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\crpKarticaReprodukcijskogMaterijala.rpt");

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
            
            UI.Izvjestaji.frmKarticeArtikala objekt = new UI.Izvjestaji.frmKarticeArtikala();

            if (objekt.ShowDialog() == DialogResult.OK)
            {
                using (BusinessLogic.Proizvod objekt2 = new BusinessLogic.Proizvod())
                {
                    if (UI.Izvjestaji.frmKarticeArtikala.naDan != null)
                    {
                        datumDo = UI.Izvjestaji.frmKarticeArtikala.naDan.Value.ToString("yyyy-MM-dd");
                        datumOd = new DateTime(2000, 1, 1).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        datumDo = UI.Izvjestaji.frmKarticeArtikala.razdobljeDatumDo.Value.ToString("yyyy-MM-dd");
                        datumOd = UI.Izvjestaji.frmKarticeArtikala.razdobljeDatumOd.Value.ToString("yyyy-MM-dd");
                    }

                    KORISNIKDataSet set = new KORISNIKDataSet();
                    new KORISNIKDataAdapter().Fill(set);

                    rpt.SetDataSource(objekt2.GetKarticeArtiklaIspis(UI.Izvjestaji.frmKarticeArtikala.pProizvod, UI.Izvjestaji.frmKarticeArtikala.pSkladiste, datumOd, datumDo));

                    if (set.KORISNIK.Rows.Count > 0)
                    {
                        rpt.SetParameterValue("NAZIV", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
                        rpt.SetParameterValue("OIB", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIKOIB"]));
                        rpt.SetParameterValue("Adresa", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIK1ADRESA"]));
                    }

                    rpt.SetParameterValue("@ID", UI.Izvjestaji.frmKarticeArtikala.pProizvod);
                    rpt.SetParameterValue("@Skladiste", UI.Izvjestaji.frmKarticeArtikala.pSkladiste);
                    rpt.SetParameterValue("@DatumOd", datumOd);
                    rpt.SetParameterValue("@DatumDo", datumDo);

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

        [CommandHandler("MT.StanjeSkladista")]
        public void StanjeSkladista_Command(object sender, EventArgs e)
        {
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
            {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - Stanje skladišta",
                Description = "Pregled izvještaja - Stanje skladišta"
            };
            ReportDocument rpt = new ReportDocument();
            DateTime datumOd;
            
            rpt.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\crpStanjeSkladista.rpt");

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

            UI.Izvjestaji.frmStanjeSkladista objekt = new UI.Izvjestaji.frmStanjeSkladista();

            if (objekt.ShowDialog() == DialogResult.OK)
            {
                using (BusinessLogic.OtvaranjeSkladista objekt2 = new BusinessLogic.OtvaranjeSkladista())
                {
                    if (UI.Izvjestaji.frmStanjeSkladista.naDan != null)
                    {
                        //datumDo = UI.Izvjestaji.frmStanjeSkladista.naDan.Value;
                        datumOd = UI.Izvjestaji.frmStanjeSkladista.naDan.Value;
                    }
                    else
                    {
                        //datumDo = UI.Izvjestaji.frmStanjeSkladista.razdobljeDatumDo.Value;
                        datumOd = UI.Izvjestaji.frmStanjeSkladista.naDan.Value;
                    }

                    KORISNIKDataSet set = new KORISNIKDataSet();
                    new KORISNIKDataAdapter().Fill(set);

                    rpt.SetDataSource(objekt2.GetStanjeSkladistaIspis(UI.Izvjestaji.frmStanjeSkladista.pSkladiste, UI.Izvjestaji.frmStanjeSkladista.pSort, datumOd));
                   
                    if (set.KORISNIK.Rows.Count > 0)
                    {
                        rpt.SetParameterValue("NAZIV", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
                        rpt.SetParameterValue("OIB", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIKOIB"]));
                        rpt.SetParameterValue("Adresa", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIK1ADRESA"]));
                        rpt.SetParameterValue("Datum", UI.Izvjestaji.frmStanjeSkladista.naDan.Value.ToString("yyyy-MM-dd"));                       
                    }                   

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


        [CommandHandler("MT.PrimkeDobavljac")]
        public void PrimkeDobavljac_Command(object sender, EventArgs e)
        {
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
            {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - Primke dobavljač",
                Description = "Pregled izvještaja - Primke dobavljač"
            };
            ReportDocument rpt = new ReportDocument();
            rpt.Load(System.Windows.Forms.Application.StartupPath + @"\MBSReport\crpPrimkePoDobavljacu.rpt");

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

            UI.Izvjestaji.frmPrimkeDobavljac objekt = new UI.Izvjestaji.frmPrimkeDobavljac();

            if (objekt.ShowDialog() == DialogResult.OK)
            {
                using (BusinessLogic.OtvaranjeSkladista objekt2 = new BusinessLogic.OtvaranjeSkladista())
                {
                    KORISNIKDataSet set = new KORISNIKDataSet();
                    new KORISNIKDataAdapter().Fill(set);

                    rpt.SetDataSource(objekt2.GetPrimkeDobavljac(UI.Izvjestaji.frmPrimkeDobavljac.pDobavljac, 
                        UI.Izvjestaji.frmPrimkeDobavljac.datumOD.ToString("yyyy-MM-dd"),
                        UI.Izvjestaji.frmPrimkeDobavljac.datumDo.ToString("yyyy-MM-dd")));

                    if (set.KORISNIK.Rows.Count > 0)
                    {
                        rpt.SetParameterValue("NAZIV", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
                        rpt.SetParameterValue("OIB", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIKOIB"]));
                        rpt.SetParameterValue("Adresa", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIK1ADRESA"]));
                    }

                    rpt.SetParameterValue("DatumOD", UI.Izvjestaji.frmPrimkeDobavljac.datumOD.ToString("dd.MM.yyyy"));
                    rpt.SetParameterValue("DatumDo", UI.Izvjestaji.frmPrimkeDobavljac.datumDo.ToString("dd.MM.yyyy"));

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


        [CommandHandler("MT.UlazIzlazGrupa")]
        public void UlazIzlaz_Command(object sender, EventArgs e)
        {
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
            {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - ulaz/izlaz po grupama",
                Description = "Pregled izvještaja - ulaz/izlaz po grupama"
            };
            ReportDocument rpt = new ReportDocument();

            UI.Izvjestaji.frmUlazIzlaz objekt = new UI.Izvjestaji.frmUlazIzlaz();

            if (objekt.ShowDialog() == DialogResult.OK)
            {

                if (UI.Izvjestaji.frmUlazIzlaz.vrstaDokumenta == 1)
                {
                    rpt.Load(System.Windows.Forms.Application.StartupPath + @"\MBSReport\crpUtroseniMatMjPoGrupamaPrimka.rpt");
                }
                else
                {
                    rpt.Load(System.Windows.Forms.Application.StartupPath + @"\MBSReport\crpUtroseniMatMjPoGrupamaIzdatnica.rpt");
                }

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


                using (BusinessLogic.OtvaranjeSkladista objekt2 = new BusinessLogic.OtvaranjeSkladista())
                {
                    KORISNIKDataSet set = new KORISNIKDataSet();
                    new KORISNIKDataAdapter().Fill(set);

                    rpt.SetDataSource(objekt2.GetUlazIzlazGrupe(UI.Izvjestaji.frmUlazIzlaz.datumOd, UI.Izvjestaji.frmUlazIzlaz.datumDo, 
                        UI.Izvjestaji.frmUlazIzlaz.skladiste, UI.Izvjestaji.frmUlazIzlaz.vrstaDokumenta));

                    if (set.KORISNIK.Rows.Count > 0)
                    {
                        rpt.SetParameterValue("NAZIV", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
                        rpt.SetParameterValue("OIB", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIKOIB"]));
                        rpt.SetParameterValue("Adresa", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIK1ADRESA"]));
                        rpt.SetParameterValue("KontaktOsoba", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KONTAKTOSOBA"]));
                        rpt.SetParameterValue("SkladisteNaziv", objekt2.GetSkladisteNaziv(UI.Izvjestaji.frmUlazIzlaz.skladiste));
                    }

                    rpt.SetParameterValue("@datumOd", UI.Izvjestaji.frmUlazIzlaz.datumOd);
                    rpt.SetParameterValue("@dateumDo", UI.Izvjestaji.frmUlazIzlaz.datumDo);
                    rpt.SetParameterValue("@skladiste", UI.Izvjestaji.frmUlazIzlaz.skladiste);


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


        [CommandHandler("MT.MjestoTroskaIspis")]
        public void IspisMjestoTroska_Command(object sender, EventArgs e)
        {
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
            {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - mjesto troška",
                Description = "Pregled izvještaja - mjesto troška"
            };
            ReportDocument rpt = new ReportDocument();

            UI.Izvjestaji.frmMjestoTroska objekt = new UI.Izvjestaji.frmMjestoTroska();

            if (objekt.ShowDialog() == DialogResult.OK)
            {

                rpt.Load(System.Windows.Forms.Application.StartupPath + @"\MBSReport\rptMjestoTroska.rpt");

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


                using (BusinessLogic.OtvaranjeSkladista objekt2 = new BusinessLogic.OtvaranjeSkladista())
                {
                    KORISNIKDataSet set = new KORISNIKDataSet();
                    new KORISNIKDataAdapter().Fill(set);

                    rpt.SetDataSource(objekt2.GetMjestoTroska(UI.Izvjestaji.frmMjestoTroska.datumOd, UI.Izvjestaji.frmMjestoTroska.datumDo, 
                        UI.Izvjestaji.frmMjestoTroska.skladiste, UI.Izvjestaji.frmMjestoTroska.mjestoTroska));

                    if (set.KORISNIK.Rows.Count > 0)
                    {
                        rpt.SetParameterValue("NAZIV", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
                        rpt.SetParameterValue("OIB", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIKOIB"]));
                        rpt.SetParameterValue("Adresa", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIK1ADRESA"]));
                        rpt.SetParameterValue("KontaktOsoba", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KONTAKTOSOBA"]));
                        rpt.SetParameterValue("SkladisteNaziv", objekt2.GetSkladisteNaziv(UI.Izvjestaji.frmMjestoTroska.skladiste));
                        rpt.SetParameterValue("datumod", UI.Izvjestaji.frmMjestoTroska.datumOd.ToString("dd.MM.yyyy"));
                        rpt.SetParameterValue("datumdo", UI.Izvjestaji.frmMjestoTroska.datumDo.ToString("dd.MM.yyyy"));
                    }

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

        [CommandHandler("MT.StanjeDokumenti")]
        public void StanjeDokumenti_Command(object sender, EventArgs e)
        {
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
            {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - Stanje Dokumenti",
                Description = "Pregled izvještaja - Stanje Dokumenti"
            };
            ReportDocument rpt = new ReportDocument();

            rpt.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptStanjeDokumenti.rpt");

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

            //dohvat i interakcija s formom
            UI.Izvjestaji.frmStanjeDokumenti objekt = new UI.Izvjestaji.frmStanjeDokumenti();

            if (objekt.ShowDialog() == DialogResult.OK)
            {
                using (BusinessLogic.OtvaranjeSkladista objekt2 = new BusinessLogic.OtvaranjeSkladista())
                {
                    KORISNIKDataSet set = new KORISNIKDataSet();
                    new KORISNIKDataAdapter().Fill(set);

                    rpt.SetDataSource(objekt2.GetStanjeDokumenti(UI.Izvjestaji.frmStanjeDokumenti.datumOd, UI.Izvjestaji.frmStanjeDokumenti.datumDo, UI.Izvjestaji.frmStanjeDokumenti.idSkladista, UI.Izvjestaji.frmStanjeDokumenti.idMjestoTroska, UI.Izvjestaji.frmStanjeDokumenti.dokument));

                    if (set.KORISNIK.Rows.Count > 0)
                    {
                        rpt.SetParameterValue("NAZIV", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
                        rpt.SetParameterValue("OIB", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIKOIB"]));
                        rpt.SetParameterValue("Adresa", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIK1ADRESA"]));
                    }

                    rpt.SetParameterValue("DatumOD", UI.Izvjestaji.frmStanjeDokumenti.datumOd);
                    rpt.SetParameterValue("DatumDo", UI.Izvjestaji.frmStanjeDokumenti.datumDo);

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

        // db - 20.10.2016
        [CommandHandler("MT.SaldoKartica")]
        public void SaldoKartica_Command(object sender, EventArgs e)
        {
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
            {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - Saldo kartica",
                Description = "Pregled izvještaja - Saldo kartica"
            };
            ReportDocument rpt = new ReportDocument();

            rpt.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\crpSaldoKartica.rpt");
            
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

            //dohvat i interakcija s formom
            UI.Izvjestaji.frmSaldoKartica objekt = new UI.Izvjestaji.frmSaldoKartica();

            if (objekt.ShowDialog() == DialogResult.OK)
            {
                using (BusinessLogic.OtvaranjeSkladista objekt2 = new BusinessLogic.OtvaranjeSkladista())
                {
                    KORISNIKDataSet set = new KORISNIKDataSet();
                    new KORISNIKDataAdapter().Fill(set);

                    //tu sad ide logika da se iskopaju proizvodi dostupni u skladištu na dan/u razdoblju
                    DataTable dtSaldoKartice = objekt2.GetSaldoKartice(UI.Izvjestaji.frmSaldoKartica.DatumOd, UI.Izvjestaji.frmSaldoKartica.DatumDo,(int) UI.Izvjestaji.frmSaldoKartica.IdSkladista, UI.Izvjestaji.frmSaldoKartica.PProizvod);
                    DataTable dtProizvodiZaSaldoKartice = objekt2.GetProizvodiSaldoKartice(UI.Izvjestaji.frmSaldoKartica.DatumOd, UI.Izvjestaji.frmSaldoKartica.DatumDo, (int)UI.Izvjestaji.frmSaldoKartica.IdSkladista);
                    
                    rpt.SetDataSource(objekt2.GetSaldoKartice(UI.Izvjestaji.frmSaldoKartica.DatumOd, UI.Izvjestaji.frmSaldoKartica.DatumDo, (int)UI.Izvjestaji.frmSaldoKartica.IdSkladista, UI.Izvjestaji.frmSaldoKartica.PProizvod));

                    rpt.Subreports[0].SetDataSource(objekt2.GetSaldoGrupe(UI.Izvjestaji.frmSaldoKartica.DatumOd, UI.Izvjestaji.frmSaldoKartica.DatumDo, (int)UI.Izvjestaji.frmSaldoKartica.IdSkladista));

                    if (set.KORISNIK.Rows.Count > 0)
                    {
                        string naziv = (RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIK1NAZIV"])).ToString();
                        string oib  = (RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIKOIB"])).ToString();
                        string adresa = (RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIK1ADRESA"])).ToString();

                        int proizvod = (int)UI.Izvjestaji.frmSaldoKartica.PProizvod;
                        DateTime dtOD = UI.Izvjestaji.frmSaldoKartica.DatumOd;
                        DateTime dtDO = UI.Izvjestaji.frmSaldoKartica.DatumDo;
                        int skladiste = (int)UI.Izvjestaji.frmSaldoKartica.IdSkladista;

                        rpt.SetParameterValue("NAZIV", naziv);
                        rpt.SetParameterValue("OIB", oib);
                        rpt.SetParameterValue("Adresa", adresa);

                        //parametri u reportu
                        //rpt.SetParameterValue("ID", proizvod); //--> ovo ipak nece trebati jer se vec nakon odabira datuma i skladista filtriraju podaci iz baze
                        rpt.SetParameterValue("DatOD", dtOD);
                        rpt.SetParameterValue("DatDO", dtDO);

                        rpt.SetParameterValue("IDSklad", skladiste);
                    }                  

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

        [CommandHandler("MT.Partner")]
        public void Partner_Command(object sender, EventArgs e)
        {
            PARTNERWorkWithWorkItem item = this.WorkItem.Items.Get<PARTNERWorkWithWorkItem>("Placa.Partner");
            
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PARTNERWorkWithWorkItem>("Placa.Partner");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("MT.Proizvod")]
        public void Proizvod_Command(object sender, EventArgs e)
        {
            PROIZVODWorkWithWorkItem item = this.WorkItem.Items.Get<PROIZVODWorkWithWorkItem>("Placa.Proizvod");

            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PROIZVODWorkWithWorkItem>("Placa.Proizvod");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("MT.MjestoTroska")]
        public void MjestoTroska_Command(object sender, EventArgs e)
        {
            MJESTOTROSKAWorkWithWorkItem item = this.WorkItem.Items.Get<MJESTOTROSKAWorkWithWorkItem>("Placa.MjestoTroska");

            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<MJESTOTROSKAWorkWithWorkItem>("Placa.MjestoTroska");
            }
            item.Show(item.Workspaces["main"]);
        }


        [CommandHandler("MT.Grupe")]
        public void Grupe_Command(object sender, EventArgs e)
        {
            GrupeProizvodaWorkitem item = this.WorkItem.Items.Get<GrupeProizvodaWorkitem>("Placa.Grupe");

            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<GrupeProizvodaWorkitem>("Placa.Grupe");
            }
            item.Show(item.Workspaces["main"]);
        }


        [CommandHandler("MT.JednicaMjere")]
        public void JednicaMjere_Command(object sender, EventArgs e)
        {
            JEDINICAMJEREWorkWithWorkItem item = this.WorkItem.Items.Get<JEDINICAMJEREWorkWithWorkItem>("Placa.JedinicaMjere");

            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<JEDINICAMJEREWorkWithWorkItem>("Placa.JedinicaMjere");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("MT.Porez")]
        public void Porez_Command(object sender, EventArgs e)
        {
            FINPOREZWorkWithWorkItem item = this.WorkItem.Items.Get<FINPOREZWorkWithWorkItem>("Placa.Porez");

            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<FINPOREZWorkWithWorkItem>("Placa.Porez");
            }
            item.Show(item.Workspaces["main"]);
        }

        //db - 30.11.2016
        [CommandHandler("MT.InventurnaLista")]
        public void InventurnaLista_Command(object sender, EventArgs e)
        {
            DateTime datum = DateTime.MinValue;

            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
            {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Inventurna lista",
                Description = "Inventurna lista"
            };
            ReportDocument rpt = new ReportDocument();

            rpt.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\crpInventurnaLista.rpt");

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



            UI.Izvjestaji.frmInventurnaLista objekt = new UI.Izvjestaji.frmInventurnaLista();

            if (objekt.ShowDialog() == DialogResult.OK)
            {
                using (BusinessLogic.OtvaranjeSkladista objekt2 = new BusinessLogic.OtvaranjeSkladista())
                {
                    if (UI.Izvjestaji.frmInventurnaLista.naDan != null)
                    {
                        //datumDo = UI.Izvjestaji.frmStanjeSkladista.naDan.Value;
                        datum = UI.Izvjestaji.frmInventurnaLista.naDan.Value;                        
                    }
                    else
                    {
                        //datumDo = UI.Izvjestaji.frmStanjeSkladista.razdobljeDatumDo.Value;
                        datum = UI.Izvjestaji.frmInventurnaLista.naDan.Value;                       
                    }

                    KORISNIKDataSet set = new KORISNIKDataSet();
                    new KORISNIKDataAdapter().Fill(set);

                    rpt.SetDataSource(objekt2.GetStanjeSkladistaZaInventurniList(UI.Izvjestaji.frmInventurnaLista.pSkladiste, UI.Izvjestaji.frmInventurnaLista.pSort, UI.Izvjestaji.frmInventurnaLista.naDan.Value, UI.Izvjestaji.frmInventurnaLista.prikazatiKolicinu));
                   
                    if (set.KORISNIK.Rows.Count > 0)
                    {
                        rpt.SetParameterValue("NAZIV", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
                        rpt.SetParameterValue("OIB", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIKOIB"]));
                        rpt.SetParameterValue("Adresa", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIK1ADRESA"]));
                        rpt.SetParameterValue("Datum", UI.Izvjestaji.frmInventurnaLista.naDan.Value.ToString("yyyy-MM-dd"));
                        //rpt.SetParameterValue("Datum", datum);
                        //rpt.SetParameterValue("DatumDo", datumDo);
                    }

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

        //db - 23.1.2017
        [CommandHandler("MT.ZakljucivanjeOtvaranje")]
        public void ZakljucivanjeOtvaranje_Command(object sender, EventArgs e)
        {
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
            {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Zaključivanje/otvaranje",
                Description = "Zaključivanje godine/otvaranje nove"
            };
            ReportDocument rpt = new ReportDocument();
            DateTime datumOd;

            rpt.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\crpStanjeSkladista.rpt");

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
                        
            UI.Izvjestaji.frmZakljucivanjeGodine objekt = new UI.Izvjestaji.frmZakljucivanjeGodine();

            if (objekt.ShowDialog() == DialogResult.OK)
            {
                using (BusinessLogic.OtvaranjeSkladista objekt2 = new BusinessLogic.OtvaranjeSkladista())
                {
                    if (UI.Izvjestaji.frmStanjeSkladista.naDan != null)
                    {
                        //datumDo = UI.Izvjestaji.frmStanjeSkladista.naDan.Value;
                        datumOd = UI.Izvjestaji.frmStanjeSkladista.naDan.Value;
                    }
                    else
                    {
                        //datumDo = UI.Izvjestaji.frmStanjeSkladista.razdobljeDatumDo.Value;
                        datumOd = UI.Izvjestaji.frmStanjeSkladista.naDan.Value;
                    }

                    KORISNIKDataSet set = new KORISNIKDataSet();
                    new KORISNIKDataAdapter().Fill(set);

                    rpt.SetDataSource(objekt2.GetStanjeSkladistaIspis(UI.Izvjestaji.frmStanjeSkladista.pSkladiste, UI.Izvjestaji.frmStanjeSkladista.pSort, datumOd));

                    if (set.KORISNIK.Rows.Count > 0)
                    {
                        rpt.SetParameterValue("NAZIV", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
                        rpt.SetParameterValue("OIB", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIKOIB"]));
                        rpt.SetParameterValue("Adresa", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIK1ADRESA"]));
                        rpt.SetParameterValue("Datum", UI.Izvjestaji.frmStanjeSkladista.naDan.Value.ToString("yyyy-MM-dd"));
                    }

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


        #endregion

        private void CommandHandler(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("Button ''{0}'' not implemented!", ((ShortcutCommand)sender).Name.ToUpper()), "DEVELOPMENT", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }

}

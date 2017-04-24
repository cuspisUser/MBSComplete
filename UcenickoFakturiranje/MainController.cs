using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Deklarit.Practices.CompositeUI.Commands;
using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.Workspaces;
using Mipsed7.DataAccessLayer.EntityFramework;
using NetAdvantage.WorkItems;
using UcenickoFakturiranje.BusinessLogic;
using UcenickoFakturiranje.UI.MaticniPodaci;
using UcenickoFakturiranje.UI.SkolskeGodineRazrednaOdjeljenja;
using UcenickoFakturiranje.UI.ProizvodiCjeniciOlaksice;
using UcenickoFakturiranje.UI.Fakturiranje;
using UcenickoFakturiranje.UI.Izvjestaji;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Data.SqlClient;

namespace UcenickoFakturiranje
{
    public class MainController : Controller
    {
        #region Matični podaci 

        [CommandHandler("UF.UstanoveCommand")]
        public void Ustanove_Command(object sender, EventArgs e)
        {
            UstanovaFormPregledWorkItem item = this.WorkItem.Items.Get<UstanovaFormPregledWorkItem>("UF.Ustanove");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<UstanovaFormPregledWorkItem>("UF.Ustanove");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("UF.SkolskeGodineCommand")]
        public void SkolskeGodine_Command(object sender, EventArgs e)
        {
            SkolskaGodinaFormPregledWorkItem item = this.WorkItem.Items.Get<SkolskaGodinaFormPregledWorkItem>("UF.SkolskeGodine");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<SkolskaGodinaFormPregledWorkItem>("UF.SkolskeGodine");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("UF.RazrediCommand")]
        public void Razredi_Command(object sender, EventArgs e)
        {
            RazredFormPregledWorkItem item = this.WorkItem.Items.Get<RazredFormPregledWorkItem>("UF.Razredi");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RazredFormPregledWorkItem>("UF.Razredi");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("UF.OdjeljenjaCommand")]
        public void Odjeljenja_Command(object sender, EventArgs e)
        {
            OdjeljenjeFormPregledWorkItem item = this.WorkItem.Items.Get<OdjeljenjeFormPregledWorkItem>("UF.Odjeljenja");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<OdjeljenjeFormPregledWorkItem>("UF.Odjeljenja");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("UF.VoditeljiCommand")]
        public void Voditelji_Command(object sender, EventArgs e)
        {
            VoditeljFormPregledWorkItem item = this.WorkItem.Items.Get<VoditeljFormPregledWorkItem>("UF.Voditelji");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<VoditeljFormPregledWorkItem>("UF.Voditelji");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("UF.UceniciCommand")]
        public void Ucenici_Command(object sender, EventArgs e)
        {
            UcenikFormPregled.vrsta_osobe = false;
            UcenikFormPregledWorkItem item = this.WorkItem.Items.Get<UcenikFormPregledWorkItem>("UF.Ucenici");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<UcenikFormPregledWorkItem>("UF.Ucenici");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("UF.PostanskiBrojeviCommand")]
        public void PostanskiBrojevi_Command(object sender, EventArgs e)
        {
            POSTANSKIBROJEVIWorkWithWorkItem item = this.WorkItem.Items.Get<POSTANSKIBROJEVIWorkWithWorkItem>("Placa.POSTANSKIBROJEVI");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<POSTANSKIBROJEVIWorkWithWorkItem>("Placa.POSTANSKIBROJEVI");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("UF.RadnaMjestaCommand")]
        public void RadnaMjesta_Command(object sender, EventArgs e)
        {
            RADNOMJESTOWorkWithWorkItem item = this.WorkItem.Items.Get<RADNOMJESTOWorkWithWorkItem>("Placa.RADNOMJESTO");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RADNOMJESTOWorkWithWorkItem>("Placa.RADNOMJESTO");
            }
            item.Show(item.Workspaces["main"]);
        }

        #endregion

        #region Skolske godine razredi

        [CommandHandler("UF.OtvaranjeSkolskeGodineCommand")]
        public void OtvaranjeSkolskeGodine_Command(object sender, EventArgs e)
        {
            UstanovaSkolskaGodinaFormPregledWorkItem item = this.WorkItem.Items.Get<UstanovaSkolskaGodinaFormPregledWorkItem>("UF.OtvaranjeSkolskeGodine");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<UstanovaSkolskaGodinaFormPregledWorkItem>("UF.OtvaranjeSkolskeGodine");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("UF.OrganizacijaRazrednihOdjeljenjaCommand")]
        public void DodjeljivanjeUcenikaRazrednimOdjeljenjima_Command(object sender, EventArgs e)
        {
            UstanovaSkolskaGodinaRazrednoOdjeljenjeFormPregledWorkItem item = this.WorkItem.Items.Get<UstanovaSkolskaGodinaRazrednoOdjeljenjeFormPregledWorkItem>("UF.OrganizacijaRazrednihOdjeljenja");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<UstanovaSkolskaGodinaRazrednoOdjeljenjeFormPregledWorkItem>("UF.OrganizacijaRazrednihOdjeljenja");
            }
            item.Show(item.Workspaces["main"]);
            
        }

        #endregion

        #region Proizvodi, cjenici i olaksice

        [CommandHandler("UF.ProizvodiGrupeProizvodaCommand")]
        public void ProizvodiGrupeProizvoda_Command(object sender, EventArgs e)
        {
            ProizvodGrupaProizvodaWorkItem item = this.WorkItem.Items.Get<ProizvodGrupaProizvodaWorkItem>("UF.ProizvodiGrupeProizvoda");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<ProizvodGrupaProizvodaWorkItem>("UF.ProizvodiGrupeProizvoda");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("UF.CjeniciCommand")]
        public void Cjenici_Command(object sender, EventArgs e)
        {
            CjenikWorkItem item = this.WorkItem.Items.Get<CjenikWorkItem>("UF.Cjenik");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<CjenikWorkItem>("UF.Cjenik");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("UF.OlaksiceCommand")]
        public void Olaksice_Command(object sender, EventArgs e)
        {
            OlaksiceWorkItem item = this.WorkItem.Items.Get<OlaksiceWorkItem>("UF.Olaksice");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<OlaksiceWorkItem>("UF.Olaksice");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("UF.PorezneStopeCommand")]
        public void PorezneStope_Command(object sender, EventArgs e)
        {
            FINPOREZWorkWithWorkItem item = this.WorkItem.Items.Get<FINPOREZWorkWithWorkItem>("Finpos.PoreziC");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<FINPOREZWorkWithWorkItem>("Finpos.PoreziC");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("UF.MjerneJediniceCommand")]
        public void MjerneJedinice_Command(object sender, EventArgs e)
        {
            JEDINICAMJEREWorkWithWorkItem item = this.WorkItem.Items.Get<JEDINICAMJEREWorkWithWorkItem>("Finpos.JediniceMjereC");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<JEDINICAMJEREWorkWithWorkItem>("Finpos.JediniceMjereC");
            }
            item.Show(item.Workspaces["main"]);
        }

        #endregion

        #region Fakturiranje

        [CommandHandler("UF.PredlosciCommand")]
        public void Predlosci_Command(object sender, EventArgs e)
        {
            PredlosciPregledWorkItem item = this.WorkItem.Items.Get<PredlosciPregledWorkItem>("UF.Predlosci");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PredlosciPregledWorkItem>("UF.Predlosci");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("UF.ObracuniCommand")]
        public void Obracuni_Command(object sender, EventArgs e)
        {
            ObracuniPregledWorkItem item = this.WorkItem.Items.Get<ObracuniPregledWorkItem>("UF.Obracuni");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<ObracuniPregledWorkItem>("UF.Obracuni");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("UF.RacuniCommand")]
        public void Racuni_Command(object sender, EventArgs e)
        {
            RacuniPregledWorkItem item = this.WorkItem.Items.Get<RacuniPregledWorkItem>("UF.Racuni");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RacuniPregledWorkItem>("UF.Racuni");
            }
            item.Show(item.Workspaces["main"]);
        }

        #endregion

        #region Izvjestaji

        [CommandHandler("UF.IzvjestajiOtvoreneStavke")]
        public void IzvjestajiOtvoreneStavke(object sender, EventArgs e)
        {
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
            {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - Otvorene stavke po razredima",
                Description = "Pregled izvještaja - Otvorene stavke po razredima"
            };
            ReportDocument rpt = new ReportDocument();
            rpt.Load(System.Windows.Forms.Application.StartupPath + @"\FinposIzvjestaji\rptOtvoreneStavkePoRazredima.rpt");

            Mipsed7.DataAccessLayer.SqlClient conn = new Mipsed7.DataAccessLayer.SqlClient();
            // Set connection string from config in existing LogonProperties
            rpt.DataSourceConnections[0].SetConnection(Mipsed7.Core.ApplicationDatabaseInformation.ServerName, Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName, true);
            rpt.DataSourceConnections[0].SetLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;

           
            frmOtvoreneStavke otvorene_stavke = new frmOtvoreneStavke();

            if (otvorene_stavke.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = new DataTable("OtvoreneStavke");
                SqlCommand sqlComm = new SqlCommand("sp_OtvoreneStavkePoRazredima", conn.sqlConnection);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@RazdobljeDo", frmOtvoreneStavke.pDoDatuma);
                sqlComm.Parameters.AddWithValue("@IDRazredOdjeljenje", frmOtvoreneStavke.pRazred);
                sqlComm.Parameters.AddWithValue("@IDUstanova", frmOtvoreneStavke.pUstanova);
                sqlComm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;
                da.Fill(dt);

                DataTable dt_filter = new DataTable();
                if (dt.Rows.Count > 0)
                {
                    try
                    {
                        dt_filter = dt.Select("Otvoreno <> 0").CopyToDataTable();
                    }
                    catch {}
                }

                rpt.SetDataSource(dt_filter);
                rpt.SetParameterValue("@RazdobljeDo", frmOtvoreneStavke.pDoDatuma);
                rpt.SetParameterValue("@IDRazredOdjeljenje", frmOtvoreneStavke.pRazred);
                rpt.SetParameterValue("@IDUstanova", frmOtvoreneStavke.pUstanova);


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

        #endregion

        private void CommandHandler(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("Button ''{0}'' not implemented!", ((ShortcutCommand)sender).Name.ToUpper()), "DEVELOPMENT", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}

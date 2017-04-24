
using DDModule.IDD;
using DDModule.NetAdvantage.WorkItems;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using NetAdvantage.WorkItems;
using System;
using DDModule.NetAdvantage.SmartParts;
using Deklarit.Practices.CompositeUI.Workspaces;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Data.SqlClient;


namespace DDModule.DDModule
{

    public class MainController : Controller
    {
        [CommandHandler("DD.DDIZDATAKCommand")]
        public void DDIZDATAKCommand(object sender, EventArgs e)
        {
            DDIZDATAKWorkWithWorkItem item = this.WorkItem.Items.Get<DDIZDATAKWorkWithWorkItem>("DD.DDIZDATAK");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<DDIZDATAKWorkWithWorkItem>("DD.DDIZDATAK");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("DD.DDKATEGORIJACommand")]
        public void DDKATEGORIJACommand(object sender, EventArgs e)
        {
            DDKATEGORIJAWorkWithWorkItem item = this.WorkItem.Items.Get<DDKATEGORIJAWorkWithWorkItem>("DD.DDKATEGORIJA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<DDKATEGORIJAWorkWithWorkItem>("DD.DDKATEGORIJA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("DD.DDKOLONAIDDCommand")]
        public void DDKOLONAIDDCommand(object sender, EventArgs e)
        {
            DDKOLONAIDDWorkWithWorkItem item = this.WorkItem.Items.Get<DDKOLONAIDDWorkWithWorkItem>("DD.DDKOLONAIDD");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<DDKOLONAIDDWorkWithWorkItem>("DD.DDKOLONAIDD");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("DD.DDRADNIKCommand")]
        public void DDRADNIKCommand(object sender, EventArgs e)
        {
            DDRADNIKWorkWithWorkItem item = this.WorkItem.Items.Get<DDRADNIKWorkWithWorkItem>("DD.DDRADNIK");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<DDRADNIKWorkWithWorkItem>("DD.DDRADNIK");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("DD.DDVRSTEPOSLACommand")]
        public void DDVRSTEPOSLACommand(object sender, EventArgs e)
        {
            DDVRSTEPOSLAWorkWithWorkItem item = this.WorkItem.Items.Get<DDVRSTEPOSLAWorkWithWorkItem>("DD.DDVRSTEPOSLA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<DDVRSTEPOSLAWorkWithWorkItem>("DD.DDVRSTEPOSLA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("DD.IDDCOMMAND")]
        public void IDDCommand(object sender, EventArgs e)
        {
            IDDWorkItem item = this.WorkItem.Items.Get<IDDWorkItem>("DD.IDD");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<IDDWorkItem>("DD.IDD");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("DD.IP1COMMAND")]
        public void IP1Command(object sender, EventArgs e)
        {
            IP1WORKITEM ipworkitem = this.WorkItem.Items.Get<IP1WORKITEM>("DD.IP1");
            if (ipworkitem == null)
            {
                ipworkitem = this.WorkItem.Items.AddNew<IP1WORKITEM>("DD.IP1");
            }
            ipworkitem.Show(ipworkitem.Workspaces["main"]);
        }

        [CommandHandler("DD.ObracunCommand")]
        public void ObracunCommand(object sender, EventArgs e)
        {
            DDWorkItem item = this.WorkItem.Items.Get<DDWorkItem>("DD.Obracun");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<DDWorkItem>("DD.Obracun");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("DD.PotvrdaCommand")]
        public void PotvrdaCommand(object sender, EventArgs e)
        {
            PotvrdaWorkItem item = this.WorkItem.Items.Get<PotvrdaWorkItem>("DD.Potvrda");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PotvrdaWorkItem>("DD.Potvrda");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("DD.DNRCommand")]
        public void DNRCommand(object sender, EventArgs e)
        {
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
            {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - Evidencija o dohotku od nesamostalnog rada",
                Description = "Pregled izvještaja - videncija o dohotku od nesamostalnog rada"
            };
            ReportDocument rpt = new ReportDocument();
            rpt.Load(System.Windows.Forms.Application.StartupPath + @"\DDIzvjestaji\rptDNR.rpt");

            Mipsed7.DataAccessLayer.SqlClient conn = new Mipsed7.DataAccessLayer.SqlClient();
            // Set connection string from config in existing LogonProperties
            rpt.DataSourceConnections[0].SetConnection(Mipsed7.Core.ApplicationDatabaseInformation.ServerName, Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName, true);
            rpt.DataSourceConnections[0].SetLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;

            frmDNR dnr = new frmDNR();

            if (dnr.ShowDialog() == DialogResult.OK)
            {
                DataTable ds = new DataTable("DNR");
                SqlCommand sqlComm = new SqlCommand("sp_DNR", conn.sqlConnection);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@Godina", dnr.pGodina);
                sqlComm.Parameters.AddWithValue("@OdMjeseca", dnr.pOdMjeseca);
                sqlComm.Parameters.AddWithValue("@DoMjeseca", dnr.pDoMjeseca);
                sqlComm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;
                da.Fill(ds);

                DataTable dtosobe = new DataTable();
                try
                {
                    dtosobe = ds.Select("IDRADNIK In (" + dnr.pOsobe + ")").CopyToDataTable();
                }
                catch { }

                rpt.SetDataSource(dtosobe);

                DataRow korisnik = conn.GetDataTable("SELECT TOP 1 korisnik1naziv,korisnik1adresa,korisnik1mjesto,kontakttelefon,kontaktfax,email,korisnikoib FROM KORISNIK").Rows[0];

                rpt.SetParameterValue("@KorisnikNaziv", korisnik["KORISNIK1NAZIV"].ToString());
                rpt.SetParameterValue("@KorisnikAdresa", korisnik["KORISNIK1ADRESA"].ToString() + ", " + korisnik["KORISNIK1MJESTO"].ToString());
                rpt.SetParameterValue("@KorisnikOIB", korisnik["KORISNIKOIB"].ToString());

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
}


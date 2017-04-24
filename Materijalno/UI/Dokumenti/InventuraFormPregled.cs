using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI.SmartParts;
using Deklarit.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeUI.Commands;
using Infragistics.Win.UltraWinGrid.ExcelExport;
using System.Diagnostics;
using Infragistics.Win.UltraWinGrid;
using CrystalDecisions.CrystalReports.Engine;
using Deklarit.Practices.CompositeUI.Workspaces;
using NetAdvantage.WorkItems;
using System.Runtime.CompilerServices;
using Placa;
using System.Data.SqlClient;
using Mipsed7.DataAccessLayer;

namespace Materijalno.UI.Dokumenti
{
    public partial class InventuraFormPregled : UserControl, ISmartPartInfoProvider
    {
        //db - 06.12.2016
        SqlClient client = null;

        private InventuraForm _inv;
        public static int _idInv;

        //db - 02.02.2017 - flagovi za kontrolu koja se funkcija nad inventurom trenutno obavlja
        public static bool _insert;
        public static bool _update;

        #region Univerzalan kod koji se koristi za forme (Controller, WorkWith, itd...)

        private SmartPartInfo smartPartInfo1;
        private SmartPartInfoProvider infoProvider;

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        [CreateNew]
        public Microsoft.Practices.CompositeUI.Controller Controller { get; set; }

        #endregion

        #region Methods
        public InventuraFormPregled()
        {
            InitializeComponent();

            client = new SqlClient();

            _inv = new InventuraForm();
            _inv.MyEvent += OnSubmit;
            this.smartPartInfo1 = new SmartPartInfo("Unos inventure - pregled", "Unos inventure - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        public void OnSubmit(object sender, EventArgs e)
        {

        }

        private void LoadGridData()
        {
            using (BusinessLogic.Inventura objekt = new BusinessLogic.Inventura())
            {
                ugdFormPregled.DataSource = objekt.GetMainGridData();
                ugdFormPregled.DataBind();

                //db - 5.12.2016
                string[] popis = new string[] { "StvarnaKolicina" };
                //edit grida
                Utils.Tools.UltraGridStyling(ugdFormPregled, popis);

                if (ugdFormPregled.DisplayLayout.Bands.Count > 0)
                {
                    //1. layer u gridu
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["TS"].Hidden = true;
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["IDSkladista"].Hidden = true;

                    //2. layer u gridu
                    ugdFormPregled.DisplayLayout.Bands[1].Columns["ID"].Hidden = true;
                    ugdFormPregled.DisplayLayout.Bands[1].Columns["ID_Inventura"].Hidden = true;
                    ugdFormPregled.DisplayLayout.Bands[1].Columns["ID_Proizvod"].Hidden = true;
                    ugdFormPregled.DisplayLayout.Bands[1].Columns["CijenaPDV"].Hidden = false;

                    ////db - 9.11.2016
                    //ugdFormPregled.DisplayLayout.Bands[0].Columns["Ozn"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                    //ugdFormPregled.DisplayLayout.Bands[0].Columns["Ozn"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    //ugdFormPregled.DisplayLayout.Bands[0].Columns["Ozn"].Width = 20;

                    ugdFormPregled.DisplayLayout.Bands[0].Columns["IDGodina"].Header.Caption = "Godina";
                    ugdFormPregled.DisplayLayout.Bands[1].Columns["NAZIVPROIZVOD"].Header.Caption = "Proizvod";
                    ugdFormPregled.DisplayLayout.Bands[1].Columns["NAZIVJEDINICAMJERE"].Header.Caption = "Jedinica mjere";
                    //cijena
                    ugdFormPregled.DisplayLayout.Bands[1].Columns["KolicinaZaliha"].Header.Caption = "Količina zaliha";
                    ugdFormPregled.DisplayLayout.Bands[1].Columns["StvarnaKolicina"].Header.Caption = "Stvarna količina";

                    //ugdFormPregled.DisplayLayout.Bands[0].Columns["Sifra"].Width = 55;
                    //ugdFormPregled.DisplayLayout.Bands[0].Columns["Dokument"].Width = 180;
                    //ugdFormPregled.DisplayLayout.Bands[0].Columns["Skladiste"].Width = 130;
                    //ugdFormPregled.DisplayLayout.Bands[0].Columns["UkupanIznos"].Width = 80;
                    //ugdFormPregled.DisplayLayout.Bands[0].Columns["Napomena"].Width = 200;
                }

                foreach (UltraGridRow row in ugdFormPregled.Rows)
                {
                    if (row.Index == BusinessLogic.Inventura.pSelectedIndex)
                    {
                        ugdFormPregled.ActiveRow = row;
                    }
                }
            }
        }

        private Dictionary<int, int> VratiOznaceneInventure(RowsCollection rowsCollection)
        {
            Dictionary<int, int> oznaceni = new Dictionary<int, int>();

            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in rowsCollection)
            {
                if (row.Cells["Ozn"].Value.ToString() == "True")
                {
                    oznaceni.Add(Convert.ToInt32(row.Cells["ID"].Value), Convert.ToInt32(row.Cells["Sifra"].Value));
                }
            }

            return oznaceni;
        }

        #endregion

        #region Events

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            _insert = true;
            //if (ugdFormPregled.ActiveRow.ParentRow != null) return; //Ovo sprečava da se odabire s menija (insert, update, delete) ukoliko ne radi o Parent redu u gridu (Band[0])

            using (InventuraForm objekt = new InventuraForm(Enums.FormEditMode.Insert))
            {
                if (objekt.ShowDialogForm("Inventura") == DialogResult.OK)
                {
                    try
                    {
                        BusinessLogic.Inventura.pSelectedIndex = ugdFormPregled.Rows.Count;
                    }
                    catch { }
                    LoadGridData();
                }
            }

            _insert = false;
        }

        //db - Event služi da bi se ažurirala baza odmah po upisu vrijednosti u ćeliju
        private void ugdFormPregled_AfterCellUpdate(object sender, CellEventArgs e)
        {
            int idStavke = 0;
            decimal stvarnaKolicina = 0;

            try
            {
                idStavke = Convert.ToInt32(ugdFormPregled.ActiveRow.Cells["ID"].Value);
                stvarnaKolicina = Convert.ToDecimal(ugdFormPregled.ActiveRow.Cells["StvarnaKolicina"].Value);
            }
            catch { }

            UpdateStavkuPoStavku(idStavke, stvarnaKolicina);
        }

        /// <summary>
        /// Ažurira bazu odmah po upisu u ćeliju na gridu
        /// </summary>
        /// <param name="idStavke"></param>
        /// <param name="kolicina"></param>
        public void UpdateStavkuPoStavku(int idStavke, decimal kolicina)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.Parameters.AddWithValue("@ID", idStavke);
            sqlUpit.Parameters.AddWithValue("@StvarnaKolicina", kolicina);
            sqlUpit.Parameters.AddWithValue("@TS", DateTime.Now); //sprema datum u TRENUTKU UNOSA STVARNE KOLIČINE na skladištu u bazu!!

            sqlUpit.CommandText = "UPDATE MT_InventuraStavka SET StvarnaKolicina = @StvarnaKolicina, TS = @TS WHERE ID = @ID";

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch (SqlException ex) { }
            catch (Exception exx) { }
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            _update = true;

            if (ugdFormPregled.ActiveRow.ParentRow != null) return; //Ovo sprečava da se odabire s menija (insert, update, delete) ukoliko ne radi o Parent redu u gridu (Band[0])

            if (ugdFormPregled.ActiveRow != null)
            {
                try
                {
                    BusinessLogic.Inventura.pID = Convert.ToInt32(ugdFormPregled.ActiveRow.Cells["ID"].Value);
                }
                catch { }

                //db - 30.01.2017 --> kontrola odbijanja editiranja ukoliko je inventura već na skladištu
                string text = "select Prebaceno from MT_Inventura where ID = '" + BusinessLogic.Inventura.pID + "' ";
                SqlCommand com = new SqlCommand(text);
                com.Connection = client.sqlConnection;
                com.CommandType = CommandType.Text;

                int prebaceno = 0;
                try
                {
                    prebaceno = Convert.ToInt32(com.ExecuteScalar());
                }
                catch { }

                if (prebaceno == 1)
                {
                    MessageBox.Show("Odabrana inventura ne može se više uređivati jer je zaključena i prebačena na skladište.");
                    return;
                }
                

                using (InventuraForm objekt = new InventuraForm(Enums.FormEditMode.Update))
                {
                    if (objekt.ShowDialogForm("Inventura") == DialogResult.OK)
                    {
                        try
                        {
                            BusinessLogic.Inventura.pSelectedIndex = ugdFormPregled.ActiveRow.Index;
                        }
                        catch { }

                        ////db - 4.1.2017
                        //BusinessLogic.Inventura objekt2 = new BusinessLogic.Inventura();
                        //ugdFormPregled.DataSource = objekt2.GetMainGridData2();
                        //ugdFormPregled.DataBind();
                        //string[] popis = new string[] { "StvarnaKolicina" };                        
                        //Utils.Tools.UltraGridStyling(ugdFormPregled, popis);

                        LoadGridData();
                    }
                }
            }

            _update = true;
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (ugdFormPregled.ActiveRow.ParentRow != null) return; //Ovo sprečava da se odabire s menija (insert, update, delete) ukoliko ne radi o Parent redu u gridu (Band[0])

            if (ugdFormPregled.ActiveRow != null)
            {
                BusinessLogic.Inventura.pID = Convert.ToInt32(ugdFormPregled.ActiveRow.Cells["ID"].Value);

                DateTime dt = (DateTime)ugdFormPregled.ActiveRow.Cells["DatumInventure"].Value;
                string dat = dt.ToShortDateString();
                if (MessageBox.Show(string.Format("Obrisati Inventuru sa datumom '{0}'?", dat),
                    "Brisanje Inventure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (BusinessLogic.Inventura objekt = new BusinessLogic.Inventura())
                    {
                        StringBuilder message = new StringBuilder();

                        if (!objekt.Delete(message))
                        {
                            MessageBox.Show(message.ToString());
                        }
                        try
                        {
                            BusinessLogic.Inventura.pSelectedIndex = ugdFormPregled.ActiveRow.Index;
                        }
                        catch { }
                        LoadGridData();
                    }
                }
            }
        }

        [CommandHandler("Copy")]
        public void Copy(object sender, EventArgs e)
        {
            if (ugdFormPregled.ActiveRow != null)
            {
                BusinessLogic.Inventura.pID = (int)ugdFormPregled.ActiveRow.Cells["ID"].Value;

                using (InventuraForm objekt = new InventuraForm(Enums.FormEditMode.Copy))
                {
                    if (objekt.ShowDialogForm("Inventura") == DialogResult.OK)
                    {
                        try
                        {
                            BusinessLogic.Inventura.pSelectedIndex = ugdFormPregled.ActiveRow.Index;
                        }
                        catch { }
                        LoadGridData();
                    }
                }
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.Inventura.pSelectedIndex = ugdFormPregled.ActiveRow.Index;
            }
            catch { }
            LoadGridData();
        }

        [CommandHandler("Ispis")]
        public void Ispis(object sender, EventArgs e)
        {
            if (ugdFormPregled.ActiveRow != null)
            {
                ReportDocument rpt = new ReportDocument();

                //POTrEBNO JE KREIRATI NOVI REPORT SAMO ZA INVENTURE!!
                //rpt.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\crpIzdatnica.rpt");

                // Set connection string from config in existing LogonProperties
                rpt.DataSourceConnections[0].SetConnection(Mipsed7.Core.ApplicationDatabaseInformation.ServerName, Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName, true);
                rpt.DataSourceConnections[0].SetLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);
                rpt.DataSourceConnections[0].IntegratedSecurity = false;

                BusinessLogic.Inventura.pID = (int)ugdFormPregled.ActiveRow.Cells["ID"].Value;

                using (BusinessLogic.Inventura objekt = new BusinessLogic.Inventura())
                {
                    rpt.SetDataSource(objekt.GetInventuraIspis());

                    KORISNIKDataSet set2 = new KORISNIKDataSet();
                    new KORISNIKDataAdapter().Fill(set2);

                    //if (set2.KORISNIK.Rows.Count > 0)
                    //{
                    //    rpt.SetParameterValue("NAZIV", RuntimeHelpers.GetObjectValue(set2.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
                    //    rpt.SetParameterValue("OIB", RuntimeHelpers.GetObjectValue(set2.KORISNIK.Rows[0]["KORISNIKOIB"]));
                    //    rpt.SetParameterValue("Adresa", RuntimeHelpers.GetObjectValue(set2.KORISNIK.Rows[0]["KORISNIK1ADRESA"]));
                    //}

                    ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                    PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                    if (item == null)
                    {
                        item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                    }
                    item.Izvjestaj = rpt;
                    item.Activate();
                    item.Show(item.Workspaces["main"]);
                }
            }
        }

        //db - 10.11.2016
        [CommandHandler("IspisOzn")]
        public void IspisOzn(object sender, EventArgs e)
        {
            if (ugdFormPregled.ActiveRow != null)
            {
                ReportDocument rpt = new ReportDocument();

                //NOVI report za selektirane inventure
                rpt.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\crpIzdatnicaIspisOznacenih.rpt");
                //rpt.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\crpIzdatnica2.rpt");

                // Set connection string from config in existing LogonProperties
                rpt.DataSourceConnections[0].SetConnection(Mipsed7.Core.ApplicationDatabaseInformation.ServerName, Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName, true);
                rpt.DataSourceConnections[0].SetLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);
                rpt.DataSourceConnections[0].IntegratedSecurity = false;

                Dictionary<int, int> oznaceni = VratiOznaceneInventure(ugdFormPregled.Rows);

                if (oznaceni.Count > 0)
                {
                    BusinessLogic.Izdatnica.pID = (int)ugdFormPregled.ActiveRow.Cells["ID"].Value;

                    using (BusinessLogic.Izdatnica objekt = new BusinessLogic.Izdatnica())
                    {
                        rpt.SetDataSource(objekt.GetIzdatnicaIspisOznaceni(oznaceni));

                        KORISNIKDataSet set2 = new KORISNIKDataSet();
                        new KORISNIKDataAdapter().Fill(set2);

                        if (set2.KORISNIK.Rows.Count > 0)
                        {
                            rpt.SetParameterValue("NAZIV", RuntimeHelpers.GetObjectValue(set2.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
                            rpt.SetParameterValue("OIB", RuntimeHelpers.GetObjectValue(set2.KORISNIK.Rows[0]["KORISNIKOIB"]));
                            rpt.SetParameterValue("Adresa", RuntimeHelpers.GetObjectValue(set2.KORISNIK.Rows[0]["KORISNIK1ADRESA"]));
                        }

                        ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                        PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                        if (item == null)
                        {
                            item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                        }
                        item.Izvjestaj = rpt;
                        item.Activate();
                        item.Show(item.Workspaces["main"]);
                    }
                }
            }

            //if (ugdFormPregled.ActiveRow != null)
            //{
            //    Dictionary<int, int> oznaceni = VratiOznaceneIzdatnice(ugdFormPregled.Rows);

            //    if (oznaceni.Count > 0)
            //    {
            //        BusinessLogic.Izdatnica objekt = new BusinessLogic.Izdatnica();

            //        ReportDocument rpt = new ReportDocument();
            //        rpt.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\crpIzdatnica.rpt");

            //        // Set connection string from config in existing LogonProperties
            //        rpt.DataSourceConnections[0].SetConnection(Mipsed7.Core.ApplicationDatabaseInformation.ServerName, Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName, true);
            //        rpt.DataSourceConnections[0].SetLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);
            //        rpt.DataSourceConnections[0].IntegratedSecurity = false;

            //        rpt.SetDataSource(objekt.GetIzdatnicaIspisOznaceni(oznaceni));

            //        ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            //        PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            //        if (item == null)
            //        {
            //            item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            //        }
            //        item.Izvjestaj = rpt;
            //        item.Activate();
            //        item.Show(item.Workspaces["main"]);
            //    }
            //}
        }

        //db - 23.01.2017
        [CommandHandler("IspisManjak")]
        public void IspisManjak(object sender, EventArgs e)
        {
            if (ugdFormPregled.ActiveRow != null)
            {
                ReportDocument rpt = new ReportDocument();

                //NOVI report za selektirane inventure
                rpt.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\crpInventuraManjak.rpt");

                // Set connection string from config in existing LogonProperties
                rpt.DataSourceConnections[0].SetConnection(Mipsed7.Core.ApplicationDatabaseInformation.ServerName, Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName, true);
                rpt.DataSourceConnections[0].SetLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);
                rpt.DataSourceConnections[0].IntegratedSecurity = false;

                //Dictionary<int, int> oznaceni = VratiOznaceneInventure(ugdFormPregled.Rows);

                BusinessLogic.Inventura.pID = (int)ugdFormPregled.ActiveRow.Cells["ID"].Value;

                int idInv = Convert.ToInt32(ugdFormPregled.ActiveRow.Cells["ID"].Value);
                DateTime dat = Convert.ToDateTime(ugdFormPregled.ActiveRow.Cells["DatumInventure"].Value);

                using (BusinessLogic.Inventura objekt = new BusinessLogic.Inventura())
                {
                    rpt.SetDataSource(objekt.DohvatiInventuruManjak(idInv, dat));

                    KORISNIKDataSet set2 = new KORISNIKDataSet();
                    new KORISNIKDataAdapter().Fill(set2); 

                    if (set2.KORISNIK.Rows.Count > 0)
                    {
                        rpt.SetParameterValue("NAZIV", RuntimeHelpers.GetObjectValue(set2.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
                        rpt.SetParameterValue("OIB", RuntimeHelpers.GetObjectValue(set2.KORISNIK.Rows[0]["KORISNIKOIB"]));
                        rpt.SetParameterValue("Adresa", RuntimeHelpers.GetObjectValue(set2.KORISNIK.Rows[0]["KORISNIK1ADRESA"]));
                        rpt.SetParameterValue("Datum", dat);
                    }

                    ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                    PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                    if (item == null)
                    {
                        item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                    }
                    item.Izvjestaj = rpt;
                    item.Activate();
                    item.Show(item.Workspaces["main"]);
                }
            }
        }

        //db - 23.01.2017
        [CommandHandler("IspisVishak")]
        public void IspisVishak(object sendr, EventArgs e)
        {
            if (ugdFormPregled.ActiveRow != null)
            {
                ReportDocument rpt = new ReportDocument();

                //NOVI report za selektirane inventure
                rpt.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\crpInventuraVishak.rpt");

                // Set connection string from config in existing LogonProperties
                rpt.DataSourceConnections[0].SetConnection(Mipsed7.Core.ApplicationDatabaseInformation.ServerName, Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName, true);
                rpt.DataSourceConnections[0].SetLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);
                rpt.DataSourceConnections[0].IntegratedSecurity = false;

                //Dictionary<int, int> oznaceni = VratiOznaceneInventure(ugdFormPregled.Rows);

                BusinessLogic.Inventura.pID = (int)ugdFormPregled.ActiveRow.Cells["ID"].Value;

                int idInv = Convert.ToInt32(ugdFormPregled.ActiveRow.Cells["ID"].Value);
                DateTime dat = Convert.ToDateTime(ugdFormPregled.ActiveRow.Cells["DatumInventure"].Value);

                using (BusinessLogic.Inventura objekt = new BusinessLogic.Inventura())
                {
                    rpt.SetDataSource(objekt.DohvatiInventuruVishak(idInv, dat));

                    KORISNIKDataSet set2 = new KORISNIKDataSet();
                    new KORISNIKDataAdapter().Fill(set2);

                    if (set2.KORISNIK.Rows.Count > 0)
                    {
                        rpt.SetParameterValue("NAZIV", RuntimeHelpers.GetObjectValue(set2.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
                        rpt.SetParameterValue("OIB", RuntimeHelpers.GetObjectValue(set2.KORISNIK.Rows[0]["KORISNIKOIB"]));
                        rpt.SetParameterValue("Adresa", RuntimeHelpers.GetObjectValue(set2.KORISNIK.Rows[0]["KORISNIK1ADRESA"]));
                        rpt.SetParameterValue("Datum", dat);
                    }

                    ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                    PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                    if (item == null)
                    {
                        item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                    }
                    item.Izvjestaj = rpt;
                    item.Activate();
                    item.Show(item.Workspaces["main"]);
                }
            }
        }

        private void FormLoad(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.Inventura.pSelectedIndex = ugdFormPregled.ActiveRow.Index;
            }
            catch { }

            LoadGridData();
        }

        #endregion

        private void ugdFormPregled_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Down)
            {
                this.ugdFormPregled.PerformAction(UltraGridAction.BelowCell);

                this.ugdFormPregled.PerformAction(UltraGridAction.EnterEditMode);
            }
        }





    }
}

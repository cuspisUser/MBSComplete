namespace ServisModule
{
    using Deklarit.Practices.CompositeUI.Workspaces;
    using Deklarit.Resources;
    using Infragistics.Practices.CompositeUI.WinForms;
    using Infragistics.Win.UltraWinDock;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.Commands;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using NetAdvantage.SmartParts;
    using NetAdvantage.WorkItems;
    using mipsed.application.framework;
    using Placa;
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    using ServisModule.Migracija;

    public class MainController : Controller
    {
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

        [CommandHandler("IMPORTIP")]
        public void IMPORTIPCommandHandler(object sender, EventArgs e)
        {
            if (new frmLoginServiseri().ShowDialog() == DialogResult.OK)
            {
                ExtendedWindowSmartPartInfo smartPartInfo = new ExtendedWindowSmartPartInfo
                {
                    StartPosition = FormStartPosition.CenterScreen,
                    Modal = true,
                    ControlBox = true,
                    Title = "Obrazac IP - DOS / MIPSED.NET",
                    Icon = ImageResourcesNew.mbs
                };
                DOSPodaci smartPart = this.WorkItem.Items.AddNew<DOSPodaci>();
                this.WorkItem.RootWorkItem.Workspaces["window"].Show(smartPart, smartPartInfo);
            }
        }

        [CommandHandler("PomocPodrska_Upute1")]
        public void PomocPodrska_Upute1CommandHandler(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://vugergrad.hr/uploads/mipsed/upute/MIPSED7_Upute_Place.pdf");
        }

        [CommandHandler("PomocPodrska_Upute2")]
        public void PomocPodrska_Upute2CommandHandler(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://vugergrad.hr/uploads/mipsed/upute/Upute%20FINPOS.pdf");
        }

        [CommandHandler("PomocPodrska_Upute3")]
        public void PomocPodrska_Upute3CommandHandler(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://vugergrad.hr/uploads/mipsed/upute/MIPSED7_Upute_UF.pdf");
        }

        [CommandHandler("PomocPodrska_Upute4")]
        public void PomocPodrska_Upute4CommandHandler(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://vugergrad.hr/uploads/mipsed/upute/MIPSED7_Upute_Materijalno.pdf");
        }

        [CommandHandler("VugerVeza")]
        public void VugerVezaCommandHandler(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(System.Windows.Forms.Application.StartupPath + @"\App_Data\VugerVeza.exe");
        }

        [CommandHandler("Chat")]
        public void ChatCommandHandler(object sender, EventArgs e)
        {
            Chat.ChatWorkItem item = this.WorkItem.Items.Get<Chat.ChatWorkItem>("Chat");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<Chat.ChatWorkItem>("Chat");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("RSS")]
        public void RSSCommandHandler(object sender, EventArgs e)
        {
            RSSWorkWithWorkItem item = this.WorkItem.Items.Get<RSSWorkWithWorkItem>("RSS.Vijesti");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RSSWorkWithWorkItem>("RSS.Vijesti");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Osobe")]
        public void OsobeCommandHandler(object sender, EventArgs e)
        {

        }

        [CommandHandler("Obracuni")]
        public void ObracuniCommandHandler(object sender, EventArgs e)
        {

        }

        [CommandHandler("KategorijaObracun")]
        public void KategorijaObracunCommandHandler(object sender, EventArgs e)
        {

        }

        [CommandHandler("MigracijaMIPSED1")]
        public void MigracijaMIPSED1CommandHandler(object sender, EventArgs e)
        {
            if (new frmLoginServiseri().ShowDialog() == DialogResult.OK)
            {
                ExtendedWindowSmartPartInfo smartPartInfo = new ExtendedWindowSmartPartInfo
                {
                    StartPosition = FormStartPosition.CenterScreen,
                    Modal = true,
                    ControlBox = true,
                    Title = "Migracija podataka iz MIPSED.NET",
                    Icon = ImageResourcesNew.mbs
                };
                MigracijaMIPSED1 smartPart = this.WorkItem.Items.AddNew<MigracijaMIPSED1>();
                this.WorkItem.RootWorkItem.Workspaces["window"].Show(smartPart, smartPartInfo);
            }
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

        [CommandHandler("Servis.ZakljucnoStanje")]
        public void ZakljucnoStanje(object sender, EventArgs e)
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();
                try
                {
                    DialogResult result = MessageBox.Show("Zelite li napraviti prijenos zaključnog stanja u novu godinu?", "Zaključno stanje", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        int year = Convert.ToInt32(client.ExecuteScalar("Select IDGODINE From GODINE Where GODINEAKTIVNA = 1"));
                        int next_year = year + 1;
                        int broj_dokumenta = Convert.ToInt32(client.ExecuteScalar("Select Max(BrojDokumenta) From GKSTAVKA Where IDDOKUMENT = 1"));


                        client.ExecuteNonQuery("Insert Into GKSTAVKA Select '01.01." + next_year + "',1, BROJSTAVKE,IDDOKUMENT,IDMJESTOTROSKA,IDORGJED,IDKONTO,'početno stanje', " +
                                               "duguje, POTRAZUJE, '01.01." + next_year + "', IDPARTNER, ZATVORENIIZNOS, 0, ORIGINALNIDOKUMENT, " + next_year + ", GKDATUMVALUTE From GKSTAVKA " +
                                               "Where IDDOKUMENT = 1 And BROJDOKUMENTA = " + broj_dokumenta + " And GKGODIDGODINE = " + year + "");


                        client.ExecuteNonQuery("DECLARE @temp as money Update GKSTAVKA Set @temp = duguje, duguje = POTRAZUJE, POTRAZUJE = @temp " +
                                               "Where IDDOKUMENT = 1 And GKGODIDGODINE = " + next_year + " And BROJDOKUMENTA = 1");

                        IzmjenaKontniPlan(next_year, client);

                        MessageBox.Show("Molimo provjerite točnost podataka te u slučaju pogreške nazovite T4S.");
                    }
                }
                catch { MessageBox.Show("Dogodila se greška prilikom prijenosa. Molimo nazovite T4S."); }
        }

        private void IzmjenaKontniPlan(int next_year, Mipsed7.DataAccessLayer.SqlClient client)
        {
            DataTable tbl = client.GetDataTable("Select IDGKSTAVKA, GKSTAVKA.IDKONTO, duguje, Aktivan, Godina From GKSTAVKA " +
                                                "Inner Join KONTO On GKSTAVKA.IDKONTO = KONTO.IDKONTO Where IDDOKUMENT = 1 And BROJDOKUMENTA = 1 And GKGODIDGODINE = " + next_year);

            frmKontoZamjena zamjena;

            foreach (DataRow row in tbl.Rows)
            {
                if (row["Aktivan"].ToString().ToLower() == "false")
                {
                    zamjena = new frmKontoZamjena(row["IDKONTO"].ToString());

                    if (zamjena.ShowDialog() == DialogResult.OK)
                    {
                        client.ExecuteNonQuery("Update GKSTAVKA Set IDKONTO = '" + zamjena.idKonto + "' Where IDGKSTAVKA = '" + row["IDGKSTAVKA"].ToString() + "'");
                    }
                }
            }
        }

        [CommandHandler("Servis.PromjenaGodine")]
        public void PromjenaGodine(object sender, EventArgs e)
        {
            GODINESelectionListWorkItem item = this.WorkItem.Items.AddNew<GODINESelectionListWorkItem>("test");
            DataRow row2 = item.ShowModal(true, "", null);
            item.Terminate();
            if (row2 != null)
            {
                IEnumerator enumerator = null;
                GODINEDataAdapter adapter = new GODINEDataAdapter();
                GODINEDataSet dataSet = new GODINEDataSet();
                adapter.Fill(dataSet);
                try
                {
                    enumerator = dataSet.GODINE.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataRow current = (DataRow) enumerator.Current;
                        current["godineaktivna"] = false;
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                dataSet.GODINE.Select("idgodine =" + Conversions.ToString(row2["idgodine"]))[0]["godineaktivna"] = true;
                adapter.Update(dataSet);
                UltraExplorerBarWorkspace smartPart = (UltraExplorerBarWorkspace) this.WorkItem.Workspaces["Dock"].SmartParts[1];
                UltraDockSmartPartInfo smartPartInfo = new UltraDockSmartPartInfo {
                    DefaultPaneStyle = ChildPaneStyle.VerticalSplit,
                    Description = Deklarit.Resources.Resources.MainMenu
                };
                Size size = new System.Drawing.Size(180, 100);
                smartPartInfo.PreferredSize = size;
                smartPartInfo.DefaultLocation = DockedLocation.DockedLeft;
                smartPartInfo.Title = "Aktivna godina:" + Conversions.ToString((int) mipsed.application.framework.Application.ActiveYear);
                this.WorkItem.Workspaces["Dock"].ApplySmartPartInfo(smartPart, smartPartInfo);
            }
        }

        [CommandHandler("Servis.Porezi")]
        public void PromjenaStopaPorezaCommand(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("Želite li da se automatski izvrše promjene poreznih stopa usklađene sa novim zakonom o porezu na dohodak sa važenjem od 1.7.2010. godine ??? Ukoliko koristite MIO III molimo da se javite na naše brojeve telefona", MsgBoxStyle.YesNo, null) == MsgBoxResult.Yes)
            {
                mipsed.application.framework.Application.UpdateNoviZakon();
            }
        }

        [CommandHandler("Servis.Rezultat")]
        public void RezultatCommand(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("Želite li stvarno izvršiti utvrđivanje rezultata i zaključak klasa 3,4,5,6,7,8 ???", MsgBoxStyle.YesNo, null) != MsgBoxResult.No)
            {
                DOKUMENTSelectionListWorkItem item = this.WorkItem.Items.AddNew<DOKUMENTSelectionListWorkItem>("test");
                DataRow row = item.ShowModal(true, "", null);
                item.Terminate();
                if (row != null)
                {
                    int activeYear = mipsed.application.framework.Application.ActiveYear;
                    DateTime time = DateTime.Parse("31.12." + activeYear.ToString());
                    SqlParameter[] parameterArray = new SqlParameter[10];
                    SqlConnection connection = new SqlConnection {
                        ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
                    };
                    parameterArray[0] = new SqlParameter("@GODINA", SqlDbType.Int);
                    parameterArray[0].Value = activeYear;
                    parameterArray[1] = new SqlParameter("@DAT", SqlDbType.Date);
                    parameterArray[1].Value = time;
                    parameterArray[2] = new SqlParameter("@iddokument", SqlDbType.Int);
                    parameterArray[2].Value = RuntimeHelpers.GetObjectValue(row["IDDOKUMENT"]);
                    SqlCommand command = new SqlCommand {
                        CommandText = "S_FIN_REZULTAT_PRORACUN",
                        CommandType = CommandType.StoredProcedure
                    };
                    try
                    {
                        int index = 0;
                        do
                        {
                            command.Parameters.AddWithValue(parameterArray[index].ToString(), RuntimeHelpers.GetObjectValue(parameterArray[index].Value));
                            index++;
                        }
                        while (index <= 2);
                        command.Connection = connection;
                        connection.Open();
                        int num2 = command.ExecuteNonQuery();
                    }
                    catch (System.Exception exception1)
                    {
                        throw exception1;
                    }
                    Interaction.MsgBox("Pod vrstom dokumenta " + row["IDDOKUMENT"].ToString() + " kreirana je nova temeljnica! Provjerite temeljnicu i proknjižite!", MsgBoxStyle.OkOnly, null);
                    connection.Close();
                }
            }
        }

        [CommandHandler("Servis.Saldiranje")]
        public void SaldiranjeCommand(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("Želite li stvarno izvršiti saldiranje kartica???", MsgBoxStyle.YesNo, null) != MsgBoxResult.No)
            {
                DOKUMENTSelectionListWorkItem item = this.WorkItem.Items.AddNew<DOKUMENTSelectionListWorkItem>("test");
                DataRow row = item.ShowModal(true, "", null);
                item.Terminate();
                if (row != null)
                {
                    int activeYear = mipsed.application.framework.Application.ActiveYear;
                    DateTime time = DateTime.Parse("31.12." + activeYear.ToString());
                    SqlParameter[] parameterArray = new SqlParameter[10];
                    SqlConnection connection = new SqlConnection {
                        ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
                    };
                    parameterArray[0] = new SqlParameter("@GODINA", SqlDbType.Int);
                    parameterArray[0].Value = activeYear;
                    parameterArray[1] = new SqlParameter("@DAT", SqlDbType.Date);
                    parameterArray[1].Value = time;
                    parameterArray[2] = new SqlParameter("@iddokument", SqlDbType.Int);
                    parameterArray[2].Value = RuntimeHelpers.GetObjectValue(row["IDDOKUMENT"]);
                    SqlCommand command = new SqlCommand {
                        CommandText = "S_FIN_SALDIRANJE",
                        CommandType = CommandType.StoredProcedure
                    };
                    try
                    {
                        int index = 0;
                        do
                        {
                            command.Parameters.AddWithValue(parameterArray[index].ToString(), RuntimeHelpers.GetObjectValue(parameterArray[index].Value));
                            index++;
                        }
                        while (index <= 2);
                        command.Connection = connection;
                        connection.Open();
                        int num2 = command.ExecuteNonQuery();
                    }
                    catch (System.Exception exception1)
                    {
                        throw exception1;

                    }
                    Interaction.MsgBox("Pod šifrom dokumenta " + row["IDDOKUMENT"].ToString() + " kreirana je nova temeljnica! Provjerite temeljnicu i proknjižite!", MsgBoxStyle.OkOnly, null);
                    connection.Close();
                }
            }
        }

        [CommandHandler("Margine")]
        public void Margine(object sender, EventArgs e)
        {
            using (ServisModule.Margine.frmMargine margine = new ServisModule.Margine.frmMargine())
            {
                if (margine.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }
    }
}


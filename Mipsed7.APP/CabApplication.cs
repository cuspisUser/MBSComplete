using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.NetAdvantage;
using Deklarit.Practices.CompositeUI.NetAdvantage.MenuEntryAdapters;
using Deklarit.Practices.CompositeUI.NetAdvantage.UIElements;
using Deklarit.Resources;
using Evolve.Wpf.Samples;
using Hlp;
using Infragistics.Practices.CompositeUI.WinForms;
using Infragistics.Practices.CompositeUI.WinForms.Commands;
using Infragistics.Practices.CompositeUI.WinForms.UIElements;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.AppStyling;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinExplorerBar;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinTree;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.Services;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using mipsed.application.framework;
using Placa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Runtime;
using System.Runtime.InteropServices;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.WinForms.UIElements;
using Microsoft.Practices.CompositeUI.Utility;
using Microsoft.Practices.SmartClient.Library.Services;
using Deklarit.Practices.CompositeUI.Services;
using Deklarit.Practices.CompositeUI.NetAdvantage.Shell;
using Deklarit.Practices.CompositeUI.BuilderStrategies;
using System.Text;
using Mipsed7.APP;
using System.Net;
using System.ServiceProcess;
using System.Security.Principal;
using System.Diagnostics;
using Deklarit.Practices.CompositeUI.Workspaces;
using ServisModule.ServisModule.Migracija;
using NetAdvantage.WorkItems;
using Mipsed7.APP.NetAdvantage.WorkItems;
using Microsoft.Practices.CompositeUI.UIElements;

public class CabApplication : IGFormShellApplication<WorkItem, MainShell>
{
    public BackgroundWorker bw;

    protected override void AddBuilderStrategies(Builder builder)
    {
        base.AddBuilderStrategies(builder);
        builder.Strategies.AddNew<OnBuiltUpStrategy>(BuilderStage.Initialization);
        builder.Strategies.AddNew<LocalCommandStrategy>(BuilderStage.Initialization);
    }

    private UltraExplorerBarWorkspace AddLeftSideMenu()
    {
        UltraExplorerBarWorkspace explorerBar = this.RootWorkItem.Workspaces.AddNew<UltraExplorerBarWorkspace>("LeftMenu");
        UltraDockSmartPartInfo smartPartInfo = new UltraDockSmartPartInfo();
        this.RootWorkItem.Services.Get<IBatchUpdateService>().AddControl(new ExplorerBarBatchUpdateableControl(explorerBar));
        smartPartInfo.DefaultPaneStyle = ChildPaneStyle.VerticalSplit;
        smartPartInfo.Description = Deklarit.Resources.Resources.MainMenu;
        smartPartInfo.Pinned = true;

        // dimenzije (širina) glavnog menija
        System.Drawing.Size size = new System.Drawing.Size(250, 100);

        smartPartInfo.PreferredSize = size;
        smartPartInfo.DefaultLocation = DockedLocation.DockedLeft;
        smartPartInfo.Title = "Aktivna godina:" + Conversions.ToString((int) mipsed.application.framework.Application.ActiveYear);
        smartPartInfo.AllowClose = false;
        explorerBar.Dock = DockStyle.Fill;
        System.Drawing.Point point = new System.Drawing.Point(0, 0);
        explorerBar.Location = point;
        explorerBar.Name = "leftSideMenu";
        size = new System.Drawing.Size(0x159, 150);
        explorerBar.Size = size;
        explorerBar.Style = UltraExplorerBarStyle.Listbar;

        this.RootWorkItem.Workspaces["Dock"].Show(explorerBar, smartPartInfo);
        return explorerBar;
    }

    private UltraExplorerBarWorkspace AddTaskPanel()
    {
        UltraExplorerBarWorkspace explorerBar = this.RootWorkItem.Workspaces.AddNew<UltraExplorerBarWorkspace>("TaskPanel");
        UltraDockSmartPartInfo smartPartInfo = new UltraDockSmartPartInfo();
        this.RootWorkItem.Services.Get<IBatchUpdateService>().AddControl(new ExplorerBarBatchUpdateableControl(explorerBar));
        smartPartInfo.DefaultPaneStyle = ChildPaneStyle.VerticalSplit;
        smartPartInfo.Description = Deklarit.Resources.Resources.Tasks;
        smartPartInfo.Pinned = true;
        System.Drawing.Size size = new System.Drawing.Size(210, 100);
        smartPartInfo.PreferredSize = size;
        smartPartInfo.Title = Deklarit.Resources.Resources.Tasks;
        smartPartInfo.DefaultLocation = DockedLocation.DockedRight;
        smartPartInfo.AllowClose = false;
        explorerBar.Dock = DockStyle.Fill;
        System.Drawing.Point point = new System.Drawing.Point(0, 0);
        explorerBar.Location = point;
        explorerBar.Name = "taskPanel";
        size = new System.Drawing.Size(0x159, 150);
        explorerBar.Size = size;
        this.RootWorkItem.Workspaces["Dock"].Show(explorerBar, smartPartInfo);
       
        return explorerBar;
    }

    protected override void AddServices()
    {
        base.AddServices();
        this.RootWorkItem.Services.Remove<IModuleEnumerator>();
        this.RootWorkItem.Services.Remove<IModuleLoaderService>();
        this.RootWorkItem.Services.AddNew<ProfileCatalogModuleInfoStore, IModuleInfoStore>();
        this.RootWorkItem.Services.AddNew<XmlStreamDependentModuleEnumerator, IModuleEnumerator>();
        this.RootWorkItem.Services.AddNew<DependentModuleLoaderService, IModuleLoaderService>();
        this.RootWorkItem.Services.AddNew<ModalShellServiceTaskPane, IModalViewService>();
        this.RootWorkItem.Services.AddNew<WorkWithPanelUICommandDefinitionService, IWorkWithUICommandDefinitionService>();
        this.RootWorkItem.Services.AddNew<BatchUpdateService, IBatchUpdateService>();
        this.RootWorkItem.Services.AddNew<ToolStripMenuAdapter, IUICommandDefinitionMenuAdapterService>();
        this.RootWorkItem.Services.AddNew<ToolStripToolbarAdapter, IUICommandDefinitionToolbarAdapterService>();
        this.RootWorkItem.Services.AddNew<ToolStripExplorerBarAdapter, IUICommandDefinitionVerticalToolPanelAdapterService>();
        this.RootWorkItem.Services.AddNew<MessageBoxUIMessageService, IUIMessageService>();
        IConfigurationSource serviceInstance = ConfigurationSourceFactory.Create();
        this.RootWorkItem.Services.Add(typeof(IConfigurationSource), serviceInstance);
        this.RootWorkItem.Services.AddNew<NullAuthorizationService, IAuthorizationService>();
    }

    protected override void AfterShellCreated()
    {
        base.AfterShellCreated();
        UltraExplorerBarWorkspace taskPanel = this.AddTaskPanel();
        UltraExplorerBarWorkspace leftSideMenu = this.AddLeftSideMenu();

        this.RootWorkItem.UIExtensionSites.RegisterSite("TopMainMenu", RuntimeHelpers.GetObjectValue(this.Shell.MenuStrip));
        this.RootWorkItem.UIExtensionSites.RegisterSite("MainMenu", leftSideMenu);
        this.RootWorkItem.UIExtensionSites.RegisterSite("MainShellPanel", taskPanel);
        this.RootWorkItem.UIExtensionSites.RegisterSite("MainStatus", RuntimeHelpers.GetObjectValue(this.Shell.StatusStrip));


        ICommandAdapterMapService service = this.RootWorkItem.Services.Get<ICommandAdapterMapService>();
        service.UnRegister(typeof(UltraExplorerBarItem));
        service.UnRegister(typeof(ToolBase));
        service.Register(typeof(UltraExplorerBarItem), typeof(DeklaritExplorerBarCommandAdapter));
        service.Register(typeof(ToolBase), typeof(DeklaritToolBaseCommandAdapter));
        service.Register(typeof(UltraExplorerBarGroup), typeof(ExplorerBarGroupCommandAdapter));
        service.Register(typeof(UltraTreeNode), typeof(TreeNodeCommandAdapter));
        this.RootWorkItem.Services.Get<IUIElementAdapterFactoryCatalog>().RegisterFactory(new Infragistics.Practices.CompositeUI.WinForms.UIElements.TreeUIAdapterFactory());
        this.Shell.Text = "Placa";
        this.Shell.WindowState = FormWindowState.Maximized;
        //this.AddMenuEntries();
        this.SetInfragisticsResources();
    }

    private void BackgroundUpdate()
    {
        new ProgressDialog { WindowStartupLocation = WindowStartupLocation.CenterScreen,
                             DialogText = "Molimo pričekajte!", 
                             IsCancellingEnabled = false, 
                             AutoIncrementInterval = 150,
                             FontSize = 12f,
                             Height = 160,
                             Width = 600
        }.RunWorkerThread(1, new DoWorkEventHandler(this.CountUntilCancelled));
    }

    private string BuildExceptionString(Exception exception)
    {
        string str2 = string.Empty + exception.Message + Environment.NewLine + exception.StackTrace;
        while (exception.InnerException != null)
        {
            str2 = str2 + this.BuildInnerExceptionString(exception.InnerException);
            exception = exception.InnerException;
        }
        return str2;
    }

    private string BuildInnerExceptionString(Exception innerException)
    {
        string str2 = string.Empty + Environment.NewLine + " InnerException ";
        return (str2 + Environment.NewLine + innerException.Message + Environment.NewLine + innerException.StackTrace);
    }

    public static bool IsRunningAsAdministrator()
    {
        var wi = WindowsIdentity.GetCurrent();
        var wp = new WindowsPrincipal(wi);

        return wp.IsInRole(WindowsBuiltInRole.Administrator);
    }

    [STAThread]
    public static void Main(string[] args)
    {
        // --------------------------------------------------------------------
        // Solution for ClickOnce in Windows 8
        // --------------------------------------------------------------------
        string OSname = Mipsed7.Emailing.SendException.GetOSFriendlyName();

        // Ovo radimo samo ukoliko je OS windows 8, jer na taj način izbjegavamo da nam se nešto crash-ira na ostalim OS-ovima
        //
        //if (OSname.ToLower().Contains("windows 8"))
        //{
        //    if (!IsRunningAsAdministrator())
        //    {
        //        // It is not possible to launch a ClickOnce app as administrator directly, so instead we launch the app as administrator in a new process.
        //        var processInfo = new ProcessStartInfo(Assembly.GetEntryAssembly().CodeBase);

        //        // The following properties run the new process as administrator
        //        processInfo.UseShellExecute = true;
        //        processInfo.Verb = "runas";

        //        // Start the new process
        //        Process.Start(processInfo);

        //        // Shut down the current process
        //        //System.Windows.Application.Current.Shutdown();
        //    }
        //}
        // --------------------------------------------------------------------

        System.Windows.Forms.Application.SetUnhandledExceptionMode(UnhandledExceptionMode.Automatic);
        System.Windows.Forms.Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
        System.Windows.Forms.Application.ThreadExit += new EventHandler(Application_ThreadExit);

        //LoginDialog dialog = new LoginDialog();
        //if ((bool) dialog.ShowDialog())
        //{


        // ****************************************************************************************************
        // Puni podatke iz app.config-a, samo ukoliko u registry-u ne postoji taj podatak!
        // Ovo nam je vrlo važno, jer mi u app.configu imamo defaultne vrijednosti, a u registry-u mogu biti sasvim drugi podaci.
        // ****************************************************************************************************

        if (string.IsNullOrEmpty(Mipsed7.Core.ApplicationDatabaseInformation.ServerName))
            Mipsed7.Core.ApplicationDatabaseInformation.ServerName = System.Configuration.ConfigurationManager.AppSettings["ServerName"];

        if (string.IsNullOrEmpty(Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName))
            Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName = System.Configuration.ConfigurationManager.AppSettings["DatabaseName"];

        if (string.IsNullOrEmpty(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName))
            Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName = System.Configuration.ConfigurationManager.AppSettings["SqlUserName"];

        if (string.IsNullOrEmpty(Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword))
            Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword = System.Configuration.ConfigurationManager.AppSettings["SqlPassword"];

        if (string.IsNullOrEmpty(Mipsed7.Core.ApplicationDatabaseInformation.SMTPClient_Exceptions))
            Mipsed7.Core.ApplicationDatabaseInformation.SMTPClient_Exceptions = System.Configuration.ConfigurationManager.AppSettings["SMTPClient_Exceptions"];

        // OIB se uvijek mora podesiti na onaj iz baze pa koji god on bio
        Mipsed7.Core.ApplicationDatabaseInformation.OIB = new Mipsed7.DataAccessLayer.SqlClient().ExecuteScalar("SELECT KORISNIKOIB FROM dbo.KORISNIK WHERE IDKORISNIK = 1").ToString();


        // ****************************************************************************************************
        // Prikazivanje modula
        // ****************************************************************************************************

        if (string.IsNullOrEmpty(Mipsed7.Core.ApplicationDatabaseInformation.Modul_Place))
            Mipsed7.Core.ApplicationDatabaseInformation.Modul_Place = System.Configuration.ConfigurationManager.AppSettings["Modul_Place"];

        if (string.IsNullOrEmpty(Mipsed7.Core.ApplicationDatabaseInformation.Modul_Honorari))
            Mipsed7.Core.ApplicationDatabaseInformation.Modul_Honorari = System.Configuration.ConfigurationManager.AppSettings["Modul_Honorari"];

        if (string.IsNullOrEmpty(Mipsed7.Core.ApplicationDatabaseInformation.Modul_Finpos))
            Mipsed7.Core.ApplicationDatabaseInformation.Modul_Finpos = System.Configuration.ConfigurationManager.AppSettings["Modul_Finpos"];

        //if (string.IsNullOrEmpty(Mipsed7.Core.ApplicationDatabaseInformation.Modul_eDokumenti))
        //    Mipsed7.Core.ApplicationDatabaseInformation.Modul_eDokumenti = System.Configuration.ConfigurationManager.AppSettings["Modul_eDokumenti"];

        if (string.IsNullOrEmpty(Mipsed7.Core.ApplicationDatabaseInformation.Modul_Erv))
            Mipsed7.Core.ApplicationDatabaseInformation.Modul_Erv = System.Configuration.ConfigurationManager.AppSettings["Modul_Erv"];

        if (string.IsNullOrEmpty(Mipsed7.Core.ApplicationDatabaseInformation.Modul_Praksa))
            Mipsed7.Core.ApplicationDatabaseInformation.Modul_Praksa = System.Configuration.ConfigurationManager.AppSettings["Modul_Praksa"];

        if (string.IsNullOrEmpty(Mipsed7.Core.ApplicationDatabaseInformation.Modul_Imovina))
            Mipsed7.Core.ApplicationDatabaseInformation.Modul_Imovina = System.Configuration.ConfigurationManager.AppSettings["Modul_Imovina"];

        if (string.IsNullOrEmpty(Mipsed7.Core.ApplicationDatabaseInformation.Modul_KorisnikSifrarnici))
            Mipsed7.Core.ApplicationDatabaseInformation.Modul_KorisnikSifrarnici = System.Configuration.ConfigurationManager.AppSettings["Modul_KorisnikSifrarnici"];

        if (string.IsNullOrEmpty(Mipsed7.Core.ApplicationDatabaseInformation.Modul_ServisneFunkcije))
            Mipsed7.Core.ApplicationDatabaseInformation.Modul_ServisneFunkcije = System.Configuration.ConfigurationManager.AppSettings["Modul_ServisneFunkcije"];

        if (string.IsNullOrEmpty(Mipsed7.Core.ApplicationDatabaseInformation.Modul_JavnaNabava))
            Mipsed7.Core.ApplicationDatabaseInformation.Modul_JavnaNabava = System.Configuration.ConfigurationManager.AppSettings["Modul_JavnaNabava"];

        if (string.IsNullOrEmpty(Mipsed7.Core.ApplicationDatabaseInformation.Modul_Materijalno))
            Mipsed7.Core.ApplicationDatabaseInformation.Modul_Materijalno = System.Configuration.ConfigurationManager.AppSettings["Modul_Materijalno"];

        if (string.IsNullOrEmpty(Mipsed7.Core.ApplicationDatabaseInformation.Modul_UF))
            Mipsed7.Core.ApplicationDatabaseInformation.Modul_UF = System.Configuration.ConfigurationManager.AppSettings["Modul_UF"];

        if (string.IsNullOrEmpty(Mipsed7.Core.ApplicationDatabaseInformation.Modul_JOPPD))
            Mipsed7.Core.ApplicationDatabaseInformation.Modul_JOPPD = System.Configuration.ConfigurationManager.AppSettings["Modul_JOPPD"];

        if (string.IsNullOrEmpty(Mipsed7.Core.ApplicationDatabaseInformation.Modul_PutniNalog))
            Mipsed7.Core.ApplicationDatabaseInformation.Modul_PutniNalog = System.Configuration.ConfigurationManager.AppSettings["Modul_PutniNalog"];

        if (string.IsNullOrEmpty(Mipsed7.Core.ApplicationDatabaseInformation.Modul_COP))
            Mipsed7.Core.ApplicationDatabaseInformation.Modul_COP = System.Configuration.ConfigurationManager.AppSettings["Modul_COP"];

        if (string.IsNullOrEmpty(Mipsed7.Core.ApplicationDatabaseInformation.Modul_JOPPDRazno))
            Mipsed7.Core.ApplicationDatabaseInformation.Modul_JOPPDRazno = System.Configuration.ConfigurationManager.AppSettings["Modul_JOPPDRazno"];

        if (string.IsNullOrEmpty(Mipsed7.Core.ApplicationDatabaseInformation.Modul_Raspored))
            Mipsed7.Core.ApplicationDatabaseInformation.Modul_Raspored = System.Configuration.ConfigurationManager.AppSettings["Modul_Raspored"];


        // ----------------------------------------------------------------------------------------------------------------------------
        // Automatski backup baze
        // ----------------------------------------------------------------------------------------------------------------------------
        // postavljamo automatski update ukoliko nije podešen
        if (string.IsNullOrEmpty(Mipsed7.Core.ApplicationDatabaseInformation.AutoBackup_MIPSED7_dbBackup_StartAutomatically))
            Mipsed7.Core.ApplicationDatabaseInformation.AutoBackup_MIPSED7_dbBackup_StartAutomatically = "1";

        if (Mipsed7.Core.ApplicationDatabaseInformation.AutoBackup_MIPSED7_dbBackup_StartAutomatically == "1")
        {
            string appFullName = AppDomain.CurrentDomain.BaseDirectory + "MIPSED.7.dbbackup.exe";

            Mipsed7.Core.ApplicationDatabaseInformation.AutoBackup_MIPSED7_dbBackup = appFullName;
            System.Diagnostics.Process.Start(appFullName);
        }
        else
        {
            Mipsed7.Core.ApplicationDatabaseInformation.AutoBackup_MIPSED7_dbBackup = string.Empty;
        }


        // ----------------------------------------------------------------------------------------------------
        // Matija Božičević - 14.08.2012.
        // ----------------------------------------------------------------------------------------------------

        if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\DeklaritDefault.isl"))
        {
            StyleManager.Load(System.Windows.Forms.Application.StartupPath + @"\DeklaritDefault.isl");
        }
        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("hr");

        try
        {
            new CabApplication().Run();
        }
        catch { }
    }

    private void CountUntilCancelled(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = (BackgroundWorker) sender;
        int num = Conversions.ToInteger(e.Argument);


        // **************************************************************************************************************
        // Matija Božičević - 09.08.2012 
        // Izvršavanje UPDATE-a
        // **************************************************************************************************************
        if (double.Parse(Mipsed7.Core.ApplicationDatabaseInformation.ProgramVersion) > double.Parse(Mipsed7.Core.ApplicationDatabaseInformation.DatabaseVersion))
        {
            worker.ReportProgress(80, "Ažuriranje baze podataka...");
            mipsed.application.framework.Application.UpdateDatabase();
        }
        // --------------------------------------------------------------------------------------------------------------

        worker.ReportProgress(100, "Pokretanje MBS.Complete");
        /// Aplikacija učitava module za rad
        this.LoadModules();
        

        this.MainMenuCustomize();
        worker.Dispose();


        // **************************************************************************************************************
        // Provjera naplate
        // **************************************************************************************************************
        // 1.) update aplikacije i baze
        // 2.) provjera Internet konekcije
        //     - DA -> provjeriti da li je korisnik blokiran
        //     - NE -> nastaviti dalje -> NE provjeravamo blokadu!
        // --------------------------------------------------------------------------------------------------------------
        // Matija Božičević 13.08.2012.
        // --------------------------------------------------------------------------------------------------------------

        if (IsConnectedToInternet())
        {
            string connectionString = string.Format(
                "Data Source={0};Initial Catalog={1};User ID={2};Password={3};",
                "mssql6.mojsite.com,1555",
                "vugergrad_payment",
                "vugergrad_payment_read",
                Mipsed7.Security.Cryptography.EncodeDecode.Decrypt("SZY2gv2HEwJiKO669f/xXQ=="));

            // OIB korisnika u MIPSED.7
            Mipsed7.DataAccessLayer.SqlClient db = new Mipsed7.DataAccessLayer.SqlClient();
            string oibUMipsed7 = db.ExecuteScalar("SELECT TOP 1 KORISNIKOIB FROM dbo.KORISNIK").ToString().Trim();

            if (!string.IsNullOrEmpty(oibUMipsed7))
            {
                // da li postoji blokada korisnika
                db = new Mipsed7.DataAccessLayer.SqlClient(connectionString);

                object oibKlijenta = db.ExecuteScalar("SELECT OIBKlijenta FROM dbo.Klijenti_Blokada WHERE OIBKlijenta = '" + oibUMipsed7 + "'");
                object datumBlokade = db.ExecuteScalar("SELECT DatumBlokade FROM dbo.Klijenti_Blokada WHERE OIBKlijenta = '" + oibUMipsed7 + "'");
                
                // Klijent POSTOJI u evidenciji pa nastavi sa radom i uđi u provjeru blokade
                if (oibKlijenta != null)
                {
                    // Provjeri da li postoji blokada korisnika
                    if (!string.IsNullOrEmpty(datumBlokade.ToString()))
                    {
                        DateTime datumSistem = DateTime.Parse(db.ExecuteScalar("SELECT DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE()))").ToString());
                        TimeSpan timeSpan = Convert.ToDateTime(datumBlokade) - datumSistem;

                        if (timeSpan.Days > 0)
                        {
                            // blokada za X dana
                            System.Windows.Forms.MessageBox.Show(
                                "*******************************************************************" + Environment.NewLine +
                                "NEPODMIRENO DUGOVANJE" + Environment.NewLine +
                                "*******************************************************************" + Environment.NewLine + Environment.NewLine +
                                "Poštovani," + Environment.NewLine +
                                "zbog nepodmirenog dugovanja, rad u sustavu MBS.Complete će biti BLOKIRAN za *** " + timeSpan.Days + " *** dana, tj. na dan " + Convert.ToDateTime(datumBlokade).ToShortDateString() + "!!!" + Environment.NewLine + Environment.NewLine +
                                "Za sve dodatne informacije obratite nam se na telefon 01/4645-655." + Environment.NewLine +
                                "Tools4Schools d.o.o.",
                                "POZOR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            // BLOKIRAN
                            System.Windows.Forms.MessageBox.Show(
                                "*******************************************************************" + Environment.NewLine +
                                "NEPODMIRENO DUGOVANJE" + Environment.NewLine +
                                "*******************************************************************" + Environment.NewLine + Environment.NewLine +
                                "Poštovani," + Environment.NewLine +
                                "zbog nepodmirenog dugovanja, rad u sustavu MBS.Complete JE BLOKIRAN!!" + Environment.NewLine + Environment.NewLine +
                                "Za sve dodatne informacije obratite nam se na telefon 01/4645-655." + Environment.NewLine +
                                "Tools4Schools d.o.o.",
                                "POZOR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            // IZLAZ
                            Environment.Exit(0);
                        }
                    }

                    // Bilježimo klijentsku aktivnost i pamtimo ID pod kojim je korisnička aktvnost insertiran
                    object ID = db.ExecuteScalar(string.Format("INSERT INTO dbo.Klijenti_Aktivnost (OIBKlijenta, DatumLogIn, DatumLogOut, VerzijaPrograma, IPAdresa, ComputerName, UserName, OperativniSustav) " +
                        "VALUES ('{0}', GETDATE(), NULL, '{1}', '{2}', '{3}', '{4}', '{5}');SELECT SCOPE_IDENTITY() AS ID;",
                        oibUMipsed7,
                        Mipsed7.Core.ApplicationDatabaseInformation.ProgramVersion,
                        GetComputerIP(),
                        System.Environment.MachineName,
                        System.Environment.UserName,
                        Mipsed7.Emailing.SendException.GetOSFriendlyName() + " - " + Mipsed7.Emailing.SendException.Is32Or64()));

                    if (ID != null)
                        Mipsed7.Core.ApplicationDatabaseInformation.KorisnikAktivnost_ID = ID.ToString();

                    // Bilježimo korištenje pojedinih modula
                    // PAŽNJA: storana procedura se koristi iz sigurnosnih razloga (objašnjenje u descriptionu storane procedure)
                    db.ExecuteNonQuery(string.Format("EXEC dbo.ModuliKoristenje_Azuriraj '{0}', {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}",
                        oibKlijenta,
                        Mipsed7.Core.ApplicationDatabaseInformation.Modul_Place,
                        Mipsed7.Core.ApplicationDatabaseInformation.Modul_Honorari,
                        Mipsed7.Core.ApplicationDatabaseInformation.Modul_Finpos,
                        Mipsed7.Core.ApplicationDatabaseInformation.Modul_Erv,
                        Mipsed7.Core.ApplicationDatabaseInformation.Modul_Praksa,
                        Mipsed7.Core.ApplicationDatabaseInformation.Modul_Imovina,
                        Mipsed7.Core.ApplicationDatabaseInformation.Modul_KorisnikSifrarnici,
                        Mipsed7.Core.ApplicationDatabaseInformation.Modul_ServisneFunkcije,
                        Mipsed7.Core.ApplicationDatabaseInformation.Modul_JavnaNabava,
                        Mipsed7.Core.ApplicationDatabaseInformation.Modul_UF));

                    // continue...
                }
                // 
                else
                {
                    // KLIJENT ne postoji u evidenciji
                    System.Windows.Forms.MessageBox.Show(
                        "*******************************************************************" + Environment.NewLine +
                        "Evidencija korisnika" + Environment.NewLine +
                        "*******************************************************************" + Environment.NewLine + Environment.NewLine +
                        "Poštovani, Vaš OIB '" + oibUMipsed7 + "' ne postoji u našoj evidenciji korisnika aplikacije!" + Environment.NewLine + Environment.NewLine +
                        "Za sve dodatne informacije obratite nam se na telefon 01/4645-655." + Environment.NewLine +
                        "Tools4Schools d.o.o.",
                        "POZOR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    
                    // IZLAZ
                    Environment.Exit(0);
                }
            }

            db.CloseConnection();
            
        }

        
        NapuniElementeJOPPD();

        PrepraviIPIdent();

        
    }

    /// <summary>
    /// Punjenje elemenata za JOPPD ukoliko su tablice prazne
    /// </summary>
    private void NapuniElementeJOPPD()
    {
        try
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();
            DataTable tblElementi = client.GetDataTable("Select IDELEMENT, IDOSNOVAOSIGURANJA, PZELEMENT From ELEMENT");
            DataTable tblNacinIsplate = client.GetDataTable("Select * From JOPPDOznakaNacinaIsplateElement");
            DataTable tblNeoporeziviPrimitak = client.GetDataTable("Select * From JOPPDOznakaNeoporezivogPrimitkaElement");
            DataTable tblOsnovniPrimitak = client.GetDataTable("Select * From JOPPDOznakaPrimitkaElement");
            DataTable tblStjecateljPrimitka = client.GetDataTable("Select * From JOPPDOznakaStjecateljaPrimitkaElement");

            #region Elementi JOPPD
            //punjenje nacina isplate element
            if (tblNacinIsplate.Rows.Count == 0)
            {
                foreach (DataRow element in tblElementi.Rows)
                {
                    if (element["IDOSNOVAOSIGURANJA"].ToString() != "")
                    {
                        if (element["IDOSNOVAOSIGURANJA"].ToString() == "10" | element["IDOSNOVAOSIGURANJA"].ToString() == "11" | element["IDOSNOVAOSIGURANJA"].ToString() == "18" 
                            | element["IDOSNOVAOSIGURANJA"].ToString() == "17" | element["IDOSNOVAOSIGURANJA"].ToString() == "50" | element["IDOSNOVAOSIGURANJA"].ToString() == "51"
                            | element["IDOSNOVAOSIGURANJA"].ToString() == "52" | element["IDOSNOVAOSIGURANJA"].ToString() == "54" | element["IDOSNOVAOSIGURANJA"].ToString() == "55"
                            | element["IDOSNOVAOSIGURANJA"].ToString() == "56" | element["IDOSNOVAOSIGURANJA"].ToString() == "57" | element["IDOSNOVAOSIGURANJA"].ToString() == "58"
                            | element["IDOSNOVAOSIGURANJA"].ToString() == "60" | element["IDOSNOVAOSIGURANJA"].ToString() == "61")
                        {
                            client.ExecuteNonQuery("Insert Into JOPPDOznakaNacinaIsplateElement (JOPPDOznakaNacinaIsplateID, IDELEMENT) Values (2,'" + element["IDELEMENT"].ToString() + "')");
                        }
                    }
                    else if (element["PZELEMENT"].ToString() != "")
                    {
                        if (element["PZELEMENT"].ToString().Substring(0, 6) == "312199" | element["PZELEMENT"].ToString().Substring(0, 6) == "312123"
                            | element["PZELEMENT"].ToString().Substring(0, 6) == "312166" | element["PZELEMENT"].ToString().Substring(0, 6) == "312131"
                            | element["PZELEMENT"].ToString().Substring(0, 6) == "312158" | element["PZELEMENT"].ToString().Substring(0, 6) == "321218")
                        {
                            client.ExecuteNonQuery("Insert Into JOPPDOznakaNacinaIsplateElement (JOPPDOznakaNacinaIsplateID, IDELEMENT) Values (2,'" + element["IDELEMENT"].ToString() + "')");
                        }
                    }
                }
            }
            //punjenje neoporezivog primitka element
            if (tblNeoporeziviPrimitak.Rows.Count == 0)
            {
                foreach (DataRow element in tblElementi.Rows)
                {
                    if (element["IDOSNOVAOSIGURANJA"].ToString() != "")
                    {
                        if (element["IDOSNOVAOSIGURANJA"].ToString() == "10" | element["IDOSNOVAOSIGURANJA"].ToString() == "11" | element["IDOSNOVAOSIGURANJA"].ToString() == "18"
                            | element["IDOSNOVAOSIGURANJA"].ToString() == "17")
                        {
                            client.ExecuteNonQuery("Insert Into JOPPDOznakaNeoporezivogPrimitkaElement (JOPPDOznakaNeoporezivogPrimitkaID, IDELEMENT) Values (1,'" + element["IDELEMENT"].ToString() + "')");
                        }

                        if (element["IDOSNOVAOSIGURANJA"].ToString() == "50" | element["IDOSNOVAOSIGURANJA"].ToString() == "51" | element["IDOSNOVAOSIGURANJA"].ToString() == "52"
                            | element["IDOSNOVAOSIGURANJA"].ToString() == "54" | element["IDOSNOVAOSIGURANJA"].ToString() == "55" | element["IDOSNOVAOSIGURANJA"].ToString() == "56"
                            | element["IDOSNOVAOSIGURANJA"].ToString() == "57" | element["IDOSNOVAOSIGURANJA"].ToString() == "58" | element["IDOSNOVAOSIGURANJA"].ToString() == "60"
                            | element["IDOSNOVAOSIGURANJA"].ToString() == "61")
                        {
                            client.ExecuteNonQuery("Insert Into JOPPDOznakaNeoporezivogPrimitkaElement (JOPPDOznakaNeoporezivogPrimitkaID, IDELEMENT) Values (13,'" + element["IDELEMENT"].ToString() + "')");
                        }
                    }
                    else if (element["PZELEMENT"].ToString() != "")
                    {
                        if (element["PZELEMENT"].ToString().Substring(0, 6) == "312199" | element["PZELEMENT"].ToString().Substring(0, 6) == "312123"
                            | element["PZELEMENT"].ToString().Substring(0, 6) == "312166")
                        {
                            client.ExecuteNonQuery("Insert Into JOPPDOznakaNeoporezivogPrimitkaElement (JOPPDOznakaNeoporezivogPrimitkaID, IDELEMENT) Values (23,'" + element["IDELEMENT"].ToString() + "')");
                        }

                        if (element["PZELEMENT"].ToString().Substring(0, 6) == "312131")
                        {
                            client.ExecuteNonQuery("Insert Into JOPPDOznakaNeoporezivogPrimitkaElement (JOPPDOznakaNeoporezivogPrimitkaID, IDELEMENT) Values (23,'" + element["IDELEMENT"].ToString() + "')");
                        }

                        if (element["PZELEMENT"].ToString().Substring(0, 6) == "312158")
                        {
                            client.ExecuteNonQuery("Insert Into JOPPDOznakaNeoporezivogPrimitkaElement (JOPPDOznakaNeoporezivogPrimitkaID, IDELEMENT) Values (21,'" + element["IDELEMENT"].ToString() + "')");
                        }

                        if (element["PZELEMENT"].ToString().Substring(0, 6) == "321218")
                        {
                            client.ExecuteNonQuery("Insert Into JOPPDOznakaNeoporezivogPrimitkaElement (JOPPDOznakaNeoporezivogPrimitkaID, IDELEMENT) Values (20,'" + element["IDELEMENT"].ToString() + "')");
                        }
                    }
                }
            }
            //punjenje osnovnog primitka
            if (tblOsnovniPrimitak.Rows.Count == 0)
            {
                foreach (DataRow element in tblElementi.Rows)
                {
                    if (element["IDOSNOVAOSIGURANJA"].ToString() != "")
                    {
                        if (element["IDOSNOVAOSIGURANJA"].ToString() == "10" | element["IDOSNOVAOSIGURANJA"].ToString() == "11" | element["IDOSNOVAOSIGURANJA"].ToString() == "18")
                        {
                            client.ExecuteNonQuery("Insert Into JOPPDOznakaPrimitkaElement (JOPPDOznakaPrimitkaID, IDELEMENT) Values (2,'" + element["IDELEMENT"].ToString() + "')");
                        }

                        if (element["IDOSNOVAOSIGURANJA"].ToString() == "17")
                        {
                            client.ExecuteNonQuery("Insert Into JOPPDOznakaPrimitkaElement (JOPPDOznakaPrimitkaID, IDELEMENT) Values (6,'" + element["IDELEMENT"].ToString() + "')");
                        }

                        if (element["IDOSNOVAOSIGURANJA"].ToString() == "50" | element["IDOSNOVAOSIGURANJA"].ToString() == "51" | element["IDOSNOVAOSIGURANJA"].ToString() == "52"
                            | element["IDOSNOVAOSIGURANJA"].ToString() == "54" | element["IDOSNOVAOSIGURANJA"].ToString() == "55" | element["IDOSNOVAOSIGURANJA"].ToString() == "56"
                            | element["IDOSNOVAOSIGURANJA"].ToString() == "57" | element["IDOSNOVAOSIGURANJA"].ToString() == "58" | element["IDOSNOVAOSIGURANJA"].ToString() == "60"
                            | element["IDOSNOVAOSIGURANJA"].ToString() == "61")
                        {
                            client.ExecuteNonQuery("Insert Into JOPPDOznakaPrimitkaElement (JOPPDOznakaPrimitkaID, IDELEMENT) Values (1,'" + element["IDELEMENT"].ToString() + "')");
                        }
                    }
                    else if (element["PZELEMENT"].ToString() != "")
                    {
                        if (element["PZELEMENT"].ToString().Substring(0, 6) == "312199" | element["PZELEMENT"].ToString().Substring(0, 6) == "312123"
                            | element["PZELEMENT"].ToString().Substring(0, 6) == "312166" | element["PZELEMENT"].ToString().Substring(0, 6) == "312131"
                            | element["PZELEMENT"].ToString().Substring(0, 6) == "312158" | element["PZELEMENT"].ToString().Substring(0, 6) == "321218")
                        {
                            client.ExecuteNonQuery("Insert Into JOPPDOznakaPrimitkaElement (JOPPDOznakaPrimitkaID, IDELEMENT) Values (1,'" + element["IDELEMENT"].ToString() + "')");
                        }
                    }
                }
            }
            //punjenje stjecatelja primitka element
            if (tblStjecateljPrimitka.Rows.Count == 0)
            {
                foreach (DataRow element in tblElementi.Rows)
                {
                    if (element["IDOSNOVAOSIGURANJA"].ToString() != "")
                    {
                        if (element["IDOSNOVAOSIGURANJA"].ToString() == "10" | element["IDOSNOVAOSIGURANJA"].ToString() == "11" |
                            element["IDOSNOVAOSIGURANJA"].ToString() == "18" | element["IDOSNOVAOSIGURANJA"].ToString() == "17")
                        {
                            client.ExecuteNonQuery("Insert Into JOPPDOznakaStjecateljaPrimitkaElement (JOPPDOznakaStjecateljaPrimitkaID, IDELEMENT) Values (2,'" + element["IDELEMENT"].ToString() + "')");
                        }

                        if (element["IDOSNOVAOSIGURANJA"].ToString() == "50")
                        {
                            client.ExecuteNonQuery("Insert Into JOPPDOznakaStjecateljaPrimitkaElement (JOPPDOznakaStjecateljaPrimitkaID, IDELEMENT) Values (39,'" + element["IDELEMENT"].ToString() + "')");
                        }

                        if (element["IDOSNOVAOSIGURANJA"].ToString() == "51")
                        {
                            client.ExecuteNonQuery("Insert Into JOPPDOznakaStjecateljaPrimitkaElement (JOPPDOznakaStjecateljaPrimitkaID, IDELEMENT) Values (41,'" + element["IDELEMENT"].ToString() + "')");
                        }

                        if (element["IDOSNOVAOSIGURANJA"].ToString() == "52")
                        {
                            client.ExecuteNonQuery("Insert Into JOPPDOznakaStjecateljaPrimitkaElement (JOPPDOznakaStjecateljaPrimitkaID, IDELEMENT) Values (42,'" + element["IDELEMENT"].ToString() + "')");
                        }

                        if (element["IDOSNOVAOSIGURANJA"].ToString() == "54")
                        {
                            client.ExecuteNonQuery("Insert Into JOPPDOznakaStjecateljaPrimitkaElement (JOPPDOznakaStjecateljaPrimitkaID, IDELEMENT) Values (43,'" + element["IDELEMENT"].ToString() + "')");
                        }

                        if (element["IDOSNOVAOSIGURANJA"].ToString() == "55")
                        {
                            client.ExecuteNonQuery("Insert Into JOPPDOznakaStjecateljaPrimitkaElement (JOPPDOznakaStjecateljaPrimitkaID, IDELEMENT) Values (44,'" + element["IDELEMENT"].ToString() + "')");
                        }

                        if (element["IDOSNOVAOSIGURANJA"].ToString() == "56")
                        {
                            client.ExecuteNonQuery("Insert Into JOPPDOznakaStjecateljaPrimitkaElement (JOPPDOznakaStjecateljaPrimitkaID, IDELEMENT) Values (45,'" + element["IDELEMENT"].ToString() + "')");
                        }

                        if (element["IDOSNOVAOSIGURANJA"].ToString() == "57")
                        {
                            client.ExecuteNonQuery("Insert Into JOPPDOznakaStjecateljaPrimitkaElement (JOPPDOznakaStjecateljaPrimitkaID, IDELEMENT) Values (46,'" + element["IDELEMENT"].ToString() + "')");
                        }

                        if (element["IDOSNOVAOSIGURANJA"].ToString() == "58")
                        {
                            client.ExecuteNonQuery("Insert Into JOPPDOznakaStjecateljaPrimitkaElement (JOPPDOznakaStjecateljaPrimitkaID, IDELEMENT) Values (47,'" + element["IDELEMENT"].ToString() + "')");
                        }

                        if (element["IDOSNOVAOSIGURANJA"].ToString() == "60")
                        {
                            client.ExecuteNonQuery("Insert Into JOPPDOznakaStjecateljaPrimitkaElement (JOPPDOznakaStjecateljaPrimitkaID, IDELEMENT) Values (48,'" + element["IDELEMENT"].ToString() + "')");
                        }

                        if (element["IDOSNOVAOSIGURANJA"].ToString() == "61")
                        {
                            client.ExecuteNonQuery("Insert Into JOPPDOznakaStjecateljaPrimitkaElement (JOPPDOznakaStjecateljaPrimitkaID, IDELEMENT) Values (49,'" + element["IDELEMENT"].ToString() + "')");
                        }
                    }
                    else if (element["PZELEMENT"].ToString() != "")
                    {
                        if (element["PZELEMENT"].ToString().Substring(0, 6) == "312199" | element["PZELEMENT"].ToString().Substring(0, 6) == "312123"
                            | element["PZELEMENT"].ToString().Substring(0, 6) == "312166" | element["PZELEMENT"].ToString().Substring(0, 6) == "312131"
                            | element["PZELEMENT"].ToString().Substring(0, 6) == "312158" | element["PZELEMENT"].ToString().Substring(0, 6) == "321218")
                        {
                            client.ExecuteNonQuery("Insert Into JOPPDOznakaStjecateljaPrimitkaElement (JOPPDOznakaStjecateljaPrimitkaID, IDELEMENT) Values (1,'" + element["IDELEMENT"].ToString() + "')");
                        }
                    }
                }
            }
            #endregion

            string rkp_korisnik = client.ExecuteScalar("Select RKP From Korisnik").ToString();
            DataTable tblPorezi = client.GetDataTable("Select IDPOREZ, PZPOREZ From POREZ");
            string novi_poziv = string.Empty;

            if (rkp_korisnik.Length > 0)
            {
                foreach (DataRow red in tblPorezi.Rows)
                {
                    try
                    {
                        if (red["PZPOREZ"].ToString().Split('-')[2] == "15018")
                        {
                            novi_poziv = red["PZPOREZ"].ToString().Split('-')[0] + "-" + red["PZPOREZ"].ToString().Split('-')[1] + "-" + rkp_korisnik; 
                            client.ExecuteNonQuery("Update POREZ Set PZPOREZ = '" + novi_poziv + "' Where IDPOREZ = '" + red["IDPOREZ"].ToString() + "'");
                        }
                    }
                    catch { }
                }

                foreach (DataRow red in tblElementi.Rows)
                {
                    try
                    {
                        if (red["PZELEMENT"].ToString().Split('-')[2] == "15018")
                        {
                            novi_poziv = red["PZELEMENT"].ToString().Split('-')[0] + "-" + red["PZELEMENT"].ToString().Split('-')[1] + "-" + rkp_korisnik;
                            client.ExecuteNonQuery("Update ELEMENT Set PZELEMENT = '" + novi_poziv + "' Where IDELEMENT = '" + red["IDELEMENT"].ToString() + "'");
                        }
                    }
                    catch { }
                }
            }
            
            client.CloseConnection();
            
            tblElementi.Dispose();
            tblStjecateljPrimitka.Dispose();
            tblOsnovniPrimitak.Dispose();
            tblNeoporeziviPrimitak.Dispose();
            tblNacinIsplate.Dispose();
        }
        catch { }
        
    }

    private void PrepraviIPIdent()
    {
        if (double.Parse(Mipsed7.Core.ApplicationDatabaseInformation.ProgramVersion) < double.Parse("7.0.8.5"))
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();
            string id_ident = string.Empty;

            DataTable tblObracuniCop = client.GetDataTable("Select OBRACUN.IDOBRACUN, IDRADNIK, IDIPIDENT From OBRACUN Inner Join ObracunRadnici on " +
                                                           "Obracun.IDOBRACUN = ObracunRadnici.IDOBRACUN Where IDENTIFIKATOROBRASCA = 'COP'");
            foreach (DataRow row in tblObracuniCop.Rows)
            {
                id_ident = client.ExecuteScalar("Select IDIPIDENT From Radnik Where IDRADNIK = " + row["IDRADNIK"].ToString()).ToString();
                if (row["IDIPIDENT"].ToString() != id_ident)
                {
                    client.ExecuteNonQuery("Update ObracunRadnici Set IDIPIDENT = '" + id_ident + "' Where IDOBRACUN = '" + row["IDOBRACUN"].ToString() + "' And IDRADNIK = '" + row["IDRADNIK"].ToString() + "'");
                }
            }
        }
    }


    //Creating the extern function...
    [DllImport("wininet.dll")]
    private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

    //Creating a function that uses the API function...
    public static bool IsConnectedToInternet()
    {
        int description;
        return InternetGetConnectedState(out description, 0);
    }

    public string GetComputerIP()
    {
        string ip = string.Empty;

        try
        {
            WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
            // VAŽNO: ovaj običan request je trajao cca 3-4 sekunde, što je definitivno previše.
            // Problem je bio u tome, što Request configurira i auto-detektira proxy-e.
            // Ako se request.Proxy postavi na NULL, inicijalni delay se zaobilazi.
            // Ovom linijom koda smo dobili brže startanje aplikacije za 3-4 sekunde.
            request.Proxy = null;

            WebResponse response = request.GetResponse();
            StreamReader stream = new StreamReader(response.GetResponseStream());

            ip = stream.ReadToEnd();

            int first = ip.IndexOf("Address: ") + 9;
            int last = ip.LastIndexOf("</body>");

            ip = ip.Substring(first, last - first);
        }
        catch (Exception)
        {
            return "NO IP";
        }

        return ip;
    }

    public void LoadModules()
    {
        IModuleLoaderService service = this.RootWorkItem.Services.Get<IModuleLoaderService>();
        if (service != null)
        {
            string assemblyFile = "PlacaModule.dll";
            Assembly[] assemblies = new Assembly[] { mipsed.application.framework.Application.LoadAssembly(assemblyFile) };
            service.Load(this.RootWorkItem, assemblies);

            assemblyFile = "DDModule.dll";
            Assembly[] assemblyArray5 = new Assembly[] { mipsed.application.framework.Application.LoadAssembly(assemblyFile) };
            service.Load(this.RootWorkItem, assemblyArray5);

            assemblyFile = "FinPosModule.dll";
            Assembly[] assemblyArray7 = new Assembly[] { mipsed.application.framework.Application.LoadAssembly(assemblyFile) };
            service.Load(this.RootWorkItem, assemblyArray7);

            assemblyFile = "UcenickoFakturiranje.dll";
            Assembly[] assemblyArray10 = new Assembly[] { mipsed.application.framework.Application.LoadAssembly(assemblyFile) };
            service.Load(this.RootWorkItem, assemblyArray10);

            assemblyFile = "JavnaNabava.dll";
            Assembly[] assemblyArray1 = new Assembly[] { mipsed.application.framework.Application.LoadAssembly(assemblyFile) };
            service.Load(this.RootWorkItem, assemblyArray1);

            assemblyFile = "Materijalno.dll";
            Assembly[] assemblyArray11 = new Assembly[] { mipsed.application.framework.Application.LoadAssembly(assemblyFile) };
            service.Load(this.RootWorkItem, assemblyArray11);

            assemblyFile = "ePoreznaModule.dll";
            Assembly[] assemblyArray2 = new Assembly[] { mipsed.application.framework.Application.LoadAssembly(assemblyFile) };
            service.Load(this.RootWorkItem, assemblyArray2);

            assemblyFile = "EvModule.dll";
            Assembly[] assemblyArray8 = new Assembly[] { mipsed.application.framework.Application.LoadAssembly(assemblyFile) };
            service.Load(this.RootWorkItem, assemblyArray8);

            assemblyFile = "Ucenici.dll";
            Assembly[] assemblyArray3 = new Assembly[] { mipsed.application.framework.Application.LoadAssembly(assemblyFile) };
            service.Load(this.RootWorkItem, assemblyArray3);

            //assemblyFile = "OSModule.dll";
            //Assembly[] assemblyArray9 = new Assembly[] { mipsed.application.framework.Application.LoadAssembly(assemblyFile) };
            //service.Load(this.RootWorkItem, assemblyArray9);

            assemblyFile = "SifrarniciModule.dll";
            Assembly[] assemblyArray4 = new Assembly[] { mipsed.application.framework.Application.LoadAssembly(assemblyFile) };
            service.Load(this.RootWorkItem, assemblyArray4);

            assemblyFile = "ServisModule.dll";
            Assembly[] assemblyArray6 = new Assembly[] { mipsed.application.framework.Application.LoadAssembly(assemblyFile) };
            service.Load(this.RootWorkItem, assemblyArray6);

        }
    }

    static void Application_ThreadExit(object sender, EventArgs e)
    {
        // Kod izlaza iz aplikacije, update-amo datum izlaska
        string connectionString = string.Format(
                "Data Source={0};Initial Catalog={1};User ID={2};Password={3};",
                "mssql6.mojsite.com,1555",
                "vugergrad_payment",
                "vugergrad_payment_read",
                Mipsed7.Security.Cryptography.EncodeDecode.Decrypt("SZY2gv2HEwJiKO669f/xXQ=="));

        Mipsed7.DataAccessLayer.SqlClient db = new Mipsed7.DataAccessLayer.SqlClient(connectionString);

        if (!string.IsNullOrEmpty(Mipsed7.Core.ApplicationDatabaseInformation.KorisnikAktivnost_ID))
        {
            db.ExecuteNonQuery("UPDATE dbo.Klijenti_Aktivnost SET DatumLogOut = GETDATE() WHERE ID = " + Mipsed7.Core.ApplicationDatabaseInformation.KorisnikAktivnost_ID);
        }

        //micanje usera iz chata prilikom gasenja aplikacije
        Chat.uscChat.MicanjeUseraKodGasenja();
    }

    static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
    {
        string exception = e.Exception.Message;

        // Matija - neki exception su korisnički i nisu za slanje. npr. oni u datasetu kod update-anja ili brisanja.
        if (exception.Contains("Neispravno brisanje, postoje povezani podaci u") ||
            exception.Contains("Zapis već postoji") ||
            exception.Contains("Potrebno je upisati") ||
            exception.Contains("is constrained to be unique") ||
            exception.Contains("postoje povezani podaci") ||
            exception.Contains("se preklapaju") ||
            exception.Contains("Polje od datuma") ||
            exception.Contains("Nema podudarnog") ||
            exception.Contains("Greška u datumu") ||
            exception.Contains("Tu se već nalazi RADNIK s istim JMBG") ||
            exception.Contains("od strane drugog korisnika") ||
            exception.Contains("ne sadrži informaciju") ||
            exception.Contains("GREŠKA (Datoteka zbrojnog naloga)"))
        {
            System.Windows.Forms.MessageBox.Show(exception, "Greška");
        }
        else if (exception.Contains("does not allow nulls"))
        {
            System.Windows.Forms.MessageBox.Show(exception.Replace("Column", "Polje").Replace("does not allow nulls", "je obavezno za upis"), "Obavezan upis");
        }
        else if (exception.Contains("ForeignKeyConstraint"))
        {
            System.Windows.Forms.MessageBox.Show(string.Format("Nije moguće spremiti podatak, pošto ne postoji potrebna povezanost.\n\nOpis greške u nastavku:\n{0}", exception), "Povezivanje podataka");
        }
        else if (exception.Contains("Missing parameter values"))
        {
            System.Windows.Forms.MessageBox.Show(string.Format("Izvještaju nedostaje podatak za pokretanje.\n\nOpis greške u nastavku:\n{0}", exception), "Greška u izvještaju");
        }
        else if (exception.Contains("Year must be between"))
        {
            System.Windows.Forms.MessageBox.Show(exception.Replace("Year must be between", "Upisana godina mora biti između").Replace("and", "i"), "Greška u izvještaju");
        }
        else if (exception.Contains("String or binary data would be truncated"))
        {
            System.Windows.Forms.MessageBox.Show("Jedan od podataka nije mogao biti spremljen jer nadilazi predviđenu veličinu. Molimo, provjerite duljinu svih upisanih polja.", "Greška");
        }
        else if (exception.Contains("Could not find a part of the path"))
        {
            System.Windows.Forms.MessageBox.Show(exception.Replace("Could not find a part of the path", "Problem u radu sa putanjom"), "Greška");
        }
        else if (exception.Contains("od strane drugog korisnika"))
        {
            // ova se greška POKAZUJE i ŠALJE na email
            System.Windows.Forms.MessageBox.Show(exception, "Greška");
            new Mipsed7.Emailing.SendException(e.Exception).Send();
        }
        else
        {
            // ostali se šalju na email
            new Mipsed7.Emailing.SendException(e.Exception).Send();
            
        }
    }

    private void MainMenuCustomize()
    {
        System.Drawing.Size size = new System.Drawing.Size();
        UltraTreeNode current;
        UltraExplorerBarWorkspace smartPart = (UltraExplorerBarWorkspace) this.RootWorkItem.Workspaces["Dock"].SmartParts[1];
        UltraDockSmartPartInfo smartPartInfo = new UltraDockSmartPartInfo {
            DefaultPaneStyle = ChildPaneStyle.VerticalSplit,
            Description = Deklarit.Resources.Resources.MainMenu,
            Pinned = true,
            AllowClose = false
        };
        // Matija - širina glavnog izbornika
        System.Drawing.Size size2 = new System.Drawing.Size(340, 100);
        smartPartInfo.PreferredSize = size2;
        smartPartInfo.DefaultLocation = DockedLocation.DockedLeft;
        smartPartInfo.Title = "Izbornik";
        this.RootWorkItem.Workspaces["Dock"].ApplySmartPartInfo(smartPart, smartPartInfo);
        size.Width = 0x15;
        size.Height = 0x15;
        smartPart.Dock = DockStyle.Fill;
        //smartPart.Appearance.BackColor = Color.WhiteSmoke;
        smartPart.Appearance.BackColor = Color.LightGray;
        smartPart.ImageSizeSmall = size;
        smartPart.ImageSizeLarge = size;

        UltraTree tree = (UltraTree) smartPart.Groups[0].Container.Controls[0];
        //tree.Appearance.BackColor = Color.WhiteSmoke;
        tree.Appearance.BackColor = Color.LightGray;
        //tree.ExpandAll();
        NodeEnumerator enumerator = tree.Nodes.GetEnumerator();
        while (enumerator.MoveNext())
        {
            current = enumerator.Current;
            if (current.ToString() == "Obračun")
                current.ExpandAll();
            if (current.HasNodes)
            {
                current.Override.NodeAppearance.FontData.Bold = DefaultableBoolean.True;
                current.Override.NodeAppearance.FontData.Name = "Verdana";
                current.Override.NodeAppearance.FontData.SizeInPoints = 10f;
                NodeEnumerator enumerator2 = current.Nodes.GetEnumerator();
                while (enumerator2.MoveNext())
                {
                    UltraTreeNode node2 = enumerator2.Current;
                    node2.Override.NodeAppearance.FontData.Bold = DefaultableBoolean.False;
                    node2.Override.NodeAppearance.FontData.Name = "Verdana";
                    node2.Override.NodeAppearance.FontData.SizeInPoints = 8f;
                }
            }
        }


        if (smartPart.Groups.Count > 1)
        {
            tree = (UltraTree)smartPart.Groups[1].Container.Controls[0];
            //tree.Appearance.BackColor = Color.WhiteSmoke;
            tree.Appearance.BackColor = Color.LightGray;
            //tree.ExpandAll();
            NodeEnumerator enumerator3 = tree.Nodes.GetEnumerator();
            while (enumerator3.MoveNext())
            {
                current = enumerator3.Current;
                if (current.ToString() == "Registar putnih naloga")
                    current.ExpandAll();
                if (current.HasNodes)
                {
                    current.Override.NodeAppearance.FontData.Bold = DefaultableBoolean.True;
                    current.Override.NodeAppearance.FontData.Name = "Verdana";
                    current.Override.NodeAppearance.FontData.SizeInPoints = 10f;
                    NodeEnumerator enumerator4 = current.Nodes.GetEnumerator();
                    while (enumerator4.MoveNext())
                    {
                        UltraTreeNode node3 = enumerator4.Current;
                        node3.Override.NodeAppearance.FontData.Bold = DefaultableBoolean.False;
                        node3.Override.NodeAppearance.FontData.Name = "Verdana";
                        node3.Override.NodeAppearance.FontData.SizeInPoints = 8f;
                    }
                }
            }
        }


        if (smartPart.Groups.Count > 2)
        {
            tree = (UltraTree)smartPart.Groups[2].Container.Controls[0];
            //tree.Appearance.BackColor = Color.WhiteSmoke;
            tree.Appearance.BackColor = Color.LightGray;
            //tree.ExpandAll();
            NodeEnumerator enumerator3 = tree.Nodes.GetEnumerator();
            while (enumerator3.MoveNext())
            {
                current = enumerator3.Current;
                if (current.ToString() == "Obračun")
                    current.ExpandAll();
                if (current.HasNodes)
                {
                    current.Override.NodeAppearance.FontData.Bold = DefaultableBoolean.True;
                    current.Override.NodeAppearance.FontData.Name = "Verdana";
                    current.Override.NodeAppearance.FontData.SizeInPoints = 10f;
                    NodeEnumerator enumerator4 = current.Nodes.GetEnumerator();
                    while (enumerator4.MoveNext())
                    {
                        UltraTreeNode node3 = enumerator4.Current;
                        node3.Override.NodeAppearance.FontData.Bold = DefaultableBoolean.False;
                        node3.Override.NodeAppearance.FontData.Name = "Verdana";
                        node3.Override.NodeAppearance.FontData.SizeInPoints = 8f;
                    }
                }
            }
        }


        if (smartPart.Groups.Count > 3)
        {
            tree = (UltraTree)smartPart.Groups[3].Container.Controls[0];
            //tree.Appearance.BackColor = Color.WhiteSmoke;
            tree.Appearance.BackColor = Color.LightGray;
            //tree.ExpandAll();
            NodeEnumerator enumerator5 = tree.Nodes.GetEnumerator();
            while (enumerator5.MoveNext())
            {
                current = enumerator5.Current;

                // ---------------------
                current.ExpandAll(); // only for development time!!
                // ---------------------

                if (current.ToString() == "Fakturiranje")
                    current.ExpandAll();
                if (current.HasNodes)
                {
                    current.Override.NodeAppearance.FontData.Bold = DefaultableBoolean.True;
                    current.Override.NodeAppearance.FontData.Name = "Verdana";
                    current.Override.NodeAppearance.FontData.SizeInPoints = 10f;
                    NodeEnumerator enumerator6 = current.Nodes.GetEnumerator();
                    while (enumerator6.MoveNext())
                    {
                        UltraTreeNode node4 = enumerator6.Current;
                        node4.Override.NodeAppearance.FontData.Bold = DefaultableBoolean.False;
                        node4.Override.NodeAppearance.FontData.Name = "Verdana";
                        node4.Override.NodeAppearance.FontData.SizeInPoints = 8f;
                    }
                }
            }
        }


        if (smartPart.Groups.Count > 4)
        {
            tree = (UltraTree)smartPart.Groups[4].Container.Controls[0];
            //tree.Appearance.BackColor = Color.WhiteSmoke;
            tree.Appearance.BackColor = Color.LightGray;
            //tree.ExpandAll();
            NodeEnumerator enumerator13 = tree.Nodes.GetEnumerator();
            while (enumerator13.MoveNext())
            {
                current = enumerator13.Current;
                if (current.ToString() == "Fakturiranje")
                    current.ExpandAll();

                if (current.ToString() == "Nabava")
                    current.ExpandAll();

                if (current.HasNodes)
                {
                    current.Override.NodeAppearance.FontData.Bold = DefaultableBoolean.True;
                    current.Override.NodeAppearance.FontData.Name = "Verdana";
                    current.Override.NodeAppearance.FontData.SizeInPoints = 10f;
                    NodeEnumerator enumerator14 = current.Nodes.GetEnumerator();
                    while (enumerator14.MoveNext())
                    {
                        UltraTreeNode node8 = enumerator14.Current;
                        node8.Override.NodeAppearance.FontData.Bold = DefaultableBoolean.False;
                        node8.Override.NodeAppearance.FontData.Name = "Verdana";
                        node8.Override.NodeAppearance.FontData.SizeInPoints = 8f;
                    }
                }
            }
        }


        if (smartPart.Groups.Count > 5)
        {
            tree = (UltraTree)smartPart.Groups[5].Container.Controls[0];
            //tree.Appearance.BackColor = Color.WhiteSmoke;
            tree.Appearance.BackColor = Color.LightGray;
            //tree.ExpandAll();
            NodeEnumerator enumerator7 = tree.Nodes.GetEnumerator();
            while (enumerator7.MoveNext())
            {
                current = enumerator7.Current;
                if (current.ToString() == "Nabava")
                    current.ExpandAll();
                if (current.HasNodes)
                {
                    current.Override.NodeAppearance.FontData.Bold = DefaultableBoolean.True;
                    current.Override.NodeAppearance.FontData.Name = "Verdana";
                    current.Override.NodeAppearance.FontData.SizeInPoints = 10f;
                    NodeEnumerator enumerator8 = current.Nodes.GetEnumerator();
                    while (enumerator8.MoveNext())
                    {
                        UltraTreeNode node5 = enumerator8.Current;
                        node5.Override.NodeAppearance.FontData.Bold = DefaultableBoolean.False;
                        node5.Override.NodeAppearance.FontData.Name = "Verdana";
                        node5.Override.NodeAppearance.FontData.SizeInPoints = 8f;
                    }
                }
            }
        }


        if (smartPart.Groups.Count > 6)
        {
            tree = (UltraTree)smartPart.Groups[6].Container.Controls[0];
            //tree.Appearance.BackColor = Color.WhiteSmoke;
            tree.Appearance.BackColor = Color.LightGray;
            //tree.ExpandAll();
            NodeEnumerator enumerator15 = tree.Nodes.GetEnumerator();
            while (enumerator15.MoveNext())
            {
                current = enumerator15.Current;
                if (current.ToString() == "Unos")
                    current.ExpandAll();
                if (current.HasNodes)
                {
                    current.Override.NodeAppearance.FontData.Bold = DefaultableBoolean.True;
                    current.Override.NodeAppearance.FontData.Name = "Verdana";
                    current.Override.NodeAppearance.FontData.SizeInPoints = 10f;
                    NodeEnumerator enumerator16 = current.Nodes.GetEnumerator();
                    while (enumerator16.MoveNext())
                    {
                        UltraTreeNode node9 = enumerator16.Current;
                        node9.Override.NodeAppearance.FontData.Bold = DefaultableBoolean.False;
                        node9.Override.NodeAppearance.FontData.Name = "Verdana";
                        node9.Override.NodeAppearance.FontData.SizeInPoints = 8f;
                    }
                }
            }
        }


        if (smartPart.Groups.Count > 7)
        {
            tree = (UltraTree)smartPart.Groups[7].Container.Controls[0];
            //tree.Appearance.BackColor = Color.WhiteSmoke;
            tree.Appearance.BackColor = Color.LightGray;
            //tree.ExpandAll();
            NodeEnumerator enumerator9 = tree.Nodes.GetEnumerator();
            while (enumerator9.MoveNext())
            {
                current = enumerator9.Current;
                if (current.ToString() == "Obračun")
                    current.ExpandAll();
                if (current.HasNodes)
                {
                    current.Override.NodeAppearance.FontData.Bold = DefaultableBoolean.True;
                    current.Override.NodeAppearance.FontData.Name = "Verdana";
                    current.Override.NodeAppearance.FontData.SizeInPoints = 10f;
                    NodeEnumerator enumerator10 = current.Nodes.GetEnumerator();
                    while (enumerator10.MoveNext())
                    {
                        UltraTreeNode node6 = enumerator10.Current;
                        node6.Override.NodeAppearance.FontData.Bold = DefaultableBoolean.False;
                        node6.Override.NodeAppearance.FontData.Name = "Verdana";
                        node6.Override.NodeAppearance.FontData.SizeInPoints = 8f;
                    }
                }
            }
        }


        if (smartPart.Groups.Count > 8)
        {
            tree = (UltraTree)smartPart.Groups[8].Container.Controls[0];
            //tree.Appearance.BackColor = Color.WhiteSmoke;
            tree.Appearance.BackColor = Color.LightGray;
            //tree.ExpandAll();
            NodeEnumerator enumerator11 = tree.Nodes.GetEnumerator();
            while (enumerator11.MoveNext())
            {
                current = enumerator11.Current;
                if (current.ToString() == "Obračuni i pregled")
                    current.ExpandAll();
                if (current.HasNodes)
                {
                    current.Override.NodeAppearance.FontData.Bold = DefaultableBoolean.True;
                    current.Override.NodeAppearance.FontData.Name = "Verdana";
                    current.Override.NodeAppearance.FontData.SizeInPoints = 10f;
                    NodeEnumerator enumerator12 = current.Nodes.GetEnumerator();
                    while (enumerator12.MoveNext())
                    {
                        UltraTreeNode node7 = enumerator12.Current;
                        node7.Override.NodeAppearance.FontData.Bold = DefaultableBoolean.False;
                        node7.Override.NodeAppearance.FontData.Name = "Verdana";
                        node7.Override.NodeAppearance.FontData.SizeInPoints = 8f;
                    }
                }
            }
        }


        if (smartPart.Groups.Count > 9)
        {
            tree = (UltraTree)smartPart.Groups[9].Container.Controls[0];
            //tree.Appearance.BackColor = Color.WhiteSmoke;
            tree.Appearance.BackColor = Color.LightGray;
            //tree.ExpandAll();
            NodeEnumerator enumerator17 = tree.Nodes.GetEnumerator();
            while (enumerator17.MoveNext())
            {
                current = enumerator17.Current;
                if (current.ToString() == "Šifrarnici")
                    current.ExpandAll();
                if (current.HasNodes)
                {
                    current.Override.NodeAppearance.FontData.Bold = DefaultableBoolean.True;
                    current.Override.NodeAppearance.FontData.Name = "Verdana";
                    current.Override.NodeAppearance.FontData.SizeInPoints = 10f;
                    NodeEnumerator enumerator18 = current.Nodes.GetEnumerator();
                    while (enumerator18.MoveNext())
                    {
                        UltraTreeNode node10 = enumerator18.Current;
                        node10.Override.NodeAppearance.FontData.Bold = DefaultableBoolean.False;
                        node10.Override.NodeAppearance.FontData.Name = "Verdana";
                        node10.Override.NodeAppearance.FontData.SizeInPoints = 8f;
                    }
                }
            }
        }



        if (smartPart.Groups.Count > 10)
        {
            tree = (UltraTree)smartPart.Groups[10].Container.Controls[0];
            //tree.Appearance.BackColor = Color.WhiteSmoke;
            tree.Appearance.BackColor = Color.LightGray;
            tree.ExpandAll();

            NodeEnumerator enumerator17 = tree.Nodes.GetEnumerator();
            while (enumerator17.MoveNext())
            {
                current = enumerator17.Current;
                if (current.HasNodes)
                {
                    current.Override.NodeAppearance.FontData.Bold = DefaultableBoolean.True;
                    current.Override.NodeAppearance.FontData.Name = "Verdana";
                    current.Override.NodeAppearance.FontData.SizeInPoints = 10f;
                    NodeEnumerator enumerator18 = current.Nodes.GetEnumerator();
                    while (enumerator18.MoveNext())
                    {
                        UltraTreeNode node10 = enumerator18.Current;
                        node10.Override.NodeAppearance.FontData.Bold = DefaultableBoolean.False;
                        node10.Override.NodeAppearance.FontData.Name = "Verdana";
                        node10.Override.NodeAppearance.FontData.SizeInPoints = 8f;
                    }
                }
            }
        }



        if (smartPart.Groups.Count > 11)
        {
            tree = (UltraTree)smartPart.Groups[11].Container.Controls[0];
            //tree.Appearance.BackColor = Color.WhiteSmoke;
            tree.Appearance.BackColor = Color.LightGray;
            tree.ExpandAll();

            NodeEnumerator enumerator17 = tree.Nodes.GetEnumerator();
            while (enumerator17.MoveNext())
            {
                current = enumerator17.Current;
                if (current.HasNodes)
                {
                    current.Override.NodeAppearance.FontData.Bold = DefaultableBoolean.True;
                    current.Override.NodeAppearance.FontData.Name = "Verdana";
                    current.Override.NodeAppearance.FontData.SizeInPoints = 10f;
                    NodeEnumerator enumerator18 = current.Nodes.GetEnumerator();
                    while (enumerator18.MoveNext())
                    {
                        UltraTreeNode node10 = enumerator18.Current;
                        node10.Override.NodeAppearance.FontData.Bold = DefaultableBoolean.False;
                        node10.Override.NodeAppearance.FontData.Name = "Verdana";
                        node10.Override.NodeAppearance.FontData.SizeInPoints = 8f;
                    }
                }
            }
        }



        // ----------------------------------------------------------------
        // MODULE disable
        // ----------------------------------------------------------------
        foreach (var group in smartPart.Groups)
        {
            switch (group.Text)
            {
                case "PLAĆE":
                    group.Visible = (Mipsed7.Core.ApplicationDatabaseInformation.Modul_Place == "1");
                    break;
                case "HONORARI":
                    group.Visible = (Mipsed7.Core.ApplicationDatabaseInformation.Modul_Honorari == "1");
                    break;
                case "FINPOS":
                    group.Visible = (Mipsed7.Core.ApplicationDatabaseInformation.Modul_Finpos == "1");
                    break;
                case "eDokumenti":
                    group.Visible = (Mipsed7.Core.ApplicationDatabaseInformation.Modul_eDokumenti == "1");
                    break;
                case "ERV":
                    group.Visible = (Mipsed7.Core.ApplicationDatabaseInformation.Modul_Erv == "1");
                    break;
                case "PRAKSA":
                    group.Visible = (Mipsed7.Core.ApplicationDatabaseInformation.Modul_Praksa == "1");
                    break;
                case "KORISNIK - ŠIFRARNICI":
                    group.Visible = (Mipsed7.Core.ApplicationDatabaseInformation.Modul_KorisnikSifrarnici == "1");
                    break;
                case "SERVISNE FUNKCIJE":
                    group.Visible = (Mipsed7.Core.ApplicationDatabaseInformation.Modul_ServisneFunkcije == "1");
                    break;
                case "JAVNA NABAVA":
                    group.Visible = (Mipsed7.Core.ApplicationDatabaseInformation.Modul_JavnaNabava == "1");
                    break;
                case "UČENIČKO FAKTURIRANJE":
                    group.Visible = (Mipsed7.Core.ApplicationDatabaseInformation.Modul_UF == "1");
                    break;
                case "JOPPD":
                    group.Visible = (Mipsed7.Core.ApplicationDatabaseInformation.Modul_JOPPD == "1");
                    break;
                case "PUTNI NALOZI":
                    group.Visible = (Mipsed7.Core.ApplicationDatabaseInformation.Modul_PutniNalog == "1");
                    break;
                case "JOPPD RAZNO":
                    group.Visible = (Mipsed7.Core.ApplicationDatabaseInformation.Modul_JOPPDRazno == "1");
                    break;
                case "MATERIJALNO":
                    group.Visible = (Mipsed7.Core.ApplicationDatabaseInformation.Modul_Materijalno == "1");
                    break;
                case "RASPORED SATI":
                    group.Visible = (Mipsed7.Core.ApplicationDatabaseInformation.Modul_Raspored == "1");
                    break;
            }
        }

        smartPart.Appearance.BackColor = Color.LightGray;
        smartPart.ViewStyle = UltraExplorerBarViewStyle.Default;
        UltraExplorerBarWorkspace workspace = (UltraExplorerBarWorkspace)this.RootWorkItem.Workspaces["Dock"].SmartParts[0];
        workspace.ViewStyle = UltraExplorerBarViewStyle.Default;
        workspace.Appearance.BackColor = Color.LightGray;
    }

    private void SetInfragisticsResources()
    {
        ResourceCustomizer customizer = Infragistics.Win.UltraWinGrid.Resources.Customizer;
        customizer.SetCustomizedString("AddNewBoxDefaultPrompt", Deklarit.Resources.Resources.infragisticsAddNewBoxDefaultPrompt);
        customizer.SetCustomizedString("DataErrorCellUpdateDateNotInMinMaxRange", Deklarit.Resources.Resources.infragisticsDataErrorCellUpdateDateNotInMinMaxRange);
        customizer.SetCustomizedString("DataErrorCellUpdateEmptyValueNotAllowed", Deklarit.Resources.Resources.infragisticsDataErrorCellUpdateEmptyValueNotAllowed);
        customizer.SetCustomizedString("DataErrorCellUpdateInvalidDataValue", Deklarit.Resources.Resources.infragisticsDataErrorCellUpdateInvalidDataValue);
        customizer.SetCustomizedString("DataErrorCellUpdateInvalidDateFormat", Deklarit.Resources.Resources.infragisticsDataErrorCellUpdateInvalidDateFormat);
        customizer.SetCustomizedString("DataErrorCellUpdateUnableToConvert", Deklarit.Resources.Resources.infragisticsDataErrorCellUpdateUnableToConvert);
        customizer.SetCustomizedString("DataErrorCellUpdateUnableToUpdateValue", Deklarit.Resources.Resources.infragisticsDataErrorCellUpdateUnableToUpdateValue);
        customizer.SetCustomizedString("DataErrorDeleteRowUnableToDelete", Deklarit.Resources.Resources.infragisticsDataErrorDeleteRowUnableToDelete);
        customizer.SetCustomizedString("DataErrorMessageTitle", Deklarit.Resources.Resources.infragisticsDataErrorMessageTitle);
        customizer.SetCustomizedString("DataErrorRowAddMessage", Deklarit.Resources.Resources.infragisticsDataErrorRowAddMessage);
        customizer.SetCustomizedString("DataErrorRowUpdateUnableToUpdateRow", Deklarit.Resources.Resources.infragisticsDataErrorRowUpdateUnableToUpdateRow);
        customizer.SetCustomizedString("DeleteMultipleRowsPrompt", Deklarit.Resources.Resources.infragisticsDeleteMultipleRowsPrompt);
        customizer.SetCustomizedString("DeleteRowsMessageTitle", Deklarit.Resources.Resources.infragisticsDeleteRowsMessageTitle);
        customizer.SetCustomizedString("DeleteSingleRowPrompt", Deklarit.Resources.Resources.infragisticsDeleteSingleRowPrompt);
        customizer.SetCustomizedString("GroupByBoxDefaultPrompt", Deklarit.Resources.Resources.infragisticsGroupByBoxDefaultPrompt);
        customizer.SetCustomizedString("RowFilterDialogBlanksItem", Deklarit.Resources.Resources.infragisticsRowFilterDialogBlanksItem);
        customizer.SetCustomizedString("RowFilterDialogEmptyTextItem", Deklarit.Resources.Resources.infragisticsRowFilterDialogEmptyTextItem);
        customizer.SetCustomizedString("RowFilterDropDownAllItem", Deklarit.Resources.Resources.infragisticsRowFilterDropDownAllItem);
        customizer.SetCustomizedString("RowFilterDropDownBlanksItem", Deklarit.Resources.Resources.infragisticsRowFilterDropDownBlanksItem);
        customizer.SetCustomizedString("RowFilterDropDownCustomItem", Deklarit.Resources.Resources.infragisticsRowFilterDropDownCustomItem);
    }

    protected override void Start()
    {
        this.BackgroundUpdate();

        System.Windows.Forms.Timer t1 = new System.Windows.Forms.Timer();
        t1.Interval = 8000;
        t1.Tick += new EventHandler(t1_Tick);
        t1.Start();

        t1_Tick(null, null);
        this.Shell.WindowState = FormWindowState.Maximized;

        this.ShowRSSNews();

        base.Start();
    }

    private void t1_Tick(object sender, EventArgs e)
    {
        if (this.Shell.Text.Length > 50)
        {
            string godina = this.Shell.Text.Split(new[] { "Fisk. godina: " }, StringSplitOptions.None)[1];

            if (godina != mipsed.application.framework.Application.ActiveYear.ToString())
            {
                System.Windows.MessageBox.Show("Fiskalna godina je promjenjena!");
            }
        }

        this.Shell.Text = "Verzija: " + Mipsed7.Core.ApplicationDatabaseInformation.ProgramVersion +
            " // Podrška: 01 4645 655 i 01 4645 656 - pis@cuspis.com // baza: " + 
            Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName + " // Fisk. godina: " + mipsed.application.framework.Application.ActiveYear.ToString();
         
    }

    private void ShowRSSNews()
    {
        RSSWorkWithWorkItem item = this.RootWorkItem.Items.Get<RSSWorkWithWorkItem>("RSS.Vijesti");
        if (item == null)
        {
            item = this.RootWorkItem.Items.AddNew<RSSWorkWithWorkItem>("RSS.Vijesti");
        }
        item.Show(item.Workspaces["main"]);
    }

    private void ShowChatPanel()
    {
        //Chat.ChatWorkItem item =  this.MainMenuCustomize this.RootWorkItem.Items.Get<Chat.ChatWorkItem>("Chat").;

        //if (item == null)
        //{
        //    item = this.RootWorkItem.Items.AddNew<Chat.ChatWorkItem>("Chat");
        //}
        //item.Show(item.Workspaces["main"]);
    }

    public Assembly[] assemblyArray3 { get; set; }
}


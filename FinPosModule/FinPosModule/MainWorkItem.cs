
using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.Services;
using Microsoft.Practices.CompositeUI;
using Microsoft.VisualBasic.CompilerServices;
using mipsed.application.framework;
using Placa;
using System;
using System.Data;
using FinPosModule.FinPosModule;


namespace FinPosModule
{

    public class MainWorkItem : WorkItem
    {
        private IUICommandDefinitionAdapterService m_MenuAdapterService;
        private IUICommandDefinitionAdapterService m_UICommandDefinitionAdapterService;
        private Deklarit.Practices.CompositeUI.UICommandDefinitionContainer m_UICommandDefinitionContainer;

        public MainWorkItem()
        {
            this.m_UICommandDefinitionContainer = new Deklarit.Practices.CompositeUI.UICommandDefinitionContainer(this);
            
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos", "FINPOS", this.Site + "", 0, false, true, DeklaritMode.All));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Sifrarnici", "Matični podaci", this.Site + ".Finpos", true));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Knjizenja", "Knjiženje", this.Site + ".Finpos", true));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Fakt", "Fakturiranje", this.Site + ".Finpos", true));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("IzvGK", "Izvještaji glavne knjige", this.Site + ".Finpos", true));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("IzvSK", "Salda / Konti", this.Site + ".Finpos", true));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("IzvPR", "Izvještaji proračuna", this.Site + ".Finpos", true));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("IzvRazno", "Razno", this.Site + ".Finpos", true));
            //this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("IzvOstalo", "Izvještaji-ostalo", this.Site + ".Finpos", true));

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.ORGJED", "Organizacijske jedinice", this.Site + ".Finpos.Sifrarnici", null, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.MT", "Mjesta troška", this.Site + ".Finpos.Sifrarnici", null, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.KONTO", "Kontni plan", this.Site + ".Finpos.Sifrarnici", null, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.DOKUMENT", "Dokumenti", this.Site + ".Finpos.Sifrarnici", null, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.PARTNER", "Partneri", this.Site + ".Finpos.Sifrarnici", null, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.TIPURA", "Tip knjige URA", this.Site + ".Finpos.Sifrarnici", null, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.TIPIRA", "Tip knjige IRA", this.Site + ".Finpos.Sifrarnici", null, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.ShemaURACommand", "Shema-URA", this.Site + ".Finpos.Sifrarnici", null, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.ShemaIRACommand", "Shema-IRA", this.Site + ".Finpos.Sifrarnici", null, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.URAVRSTAIZNOSACommand", "URA-Vrste iznosa", this.Site + ".Finpos.Sifrarnici", null, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.IRAVRSTAIZNOSACommand", "IRA-Vrste iznosa", this.Site + ".Finpos.Sifrarnici", null, null, "AKTIVNOST.Select"));

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.GKUser", "Glavna knjiga", this.Site + ".Finpos.Knjizenja", null, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.UraUser", "URA", this.Site + ".Finpos.Knjizenja", null, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.IraUser", "IRA", this.Site + ".Finpos.Knjizenja", null, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.BLGUser", "Blagajna", this.Site + ".Finpos.Knjizenja", null, null, "AKTIVNOST.Select"));
            //this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.Zatvaranje", "Zatvaranje stavaka", this.Site + ".Finpos.Knjizenja", null, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.ZatvaranjeBolnice", "Zatvaranje stavaka", this.Site + ".Finpos.Knjizenja", null, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.Plan", "Budžetiranje", this.Site + ".Finpos.Knjizenja", null, null, "AKTIVNOST.Select"));

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.RacuniCommand", "Fakturiranje", this.Site + ".Finpos.Fakt", null, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.OdobrenjeCommand", "Odobrenje", this.Site + ".Finpos.Fakt", null, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.JediniceMjere", "Mjerne jedinice", this.Site + ".Finpos.Fakt", null, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.Porezi", "Porezne stope", this.Site + ".Finpos.Fakt", null, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.Proizvodi", "Proizvodi", this.Site + ".Finpos.Fakt", null, null, "AKTIVNOST.Select"));

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.BilancaCommand", "Bruto bilanca", this.Site + ".Finpos.IzvGK", null, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.KontoKarticeCommand", "Kartice konta", this.Site + ".Finpos.IzvGK", null, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.DnevnikCommand", "Dnevnik knjiženja", this.Site + ".Finpos.IzvGK", null, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.PrometPoKontimaCommand", "Promet po kontima", this.Site + ".Finpos.IzvGK", null, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.Upravljanje", "Financijsko upravljanje", this.Site + ".Finpos.IzvGK", null, null, "AKTIVNOST.Select"));

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.OtvoreneCommand", "Otvorene stavke", this.Site + ".Finpos.IzvSK", null, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.KarticeCommand", "Kartice partnera", this.Site + ".Finpos.IzvSK", null, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.PrometPartneraCommand", "Promet partnera", this.Site + ".Finpos.IzvSK", null, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.Opomene", "Opomene", this.Site + ".Finpos.IzvSK", null, null, "AKTIVNOST.Select"));

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.ObvezeNaDan", "Obveze na dan", this.Site + ".Finpos.IzvRazno", null, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.ObvezeNaDan60", "Obveze na dan 60", this.Site + ".Finpos.IzvRazno", null, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.ObvezeDospjele60", "Obveze dospjele do 60", this.Site + ".Finpos.IzvRazno", null, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.PotrazivanjaNaDan", "Potraživanja na dan", this.Site + ".Finpos.IzvRazno", null, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.PotrazivanjaNaDan60", "Potraživanja na dan 60", this.Site + ".Finpos.IzvRazno", null, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.PokazateljiMjesecni", "Pokazatelji mjesečni", this.Site + ".Finpos.IzvRazno", null, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.PokazateljiPeriodicni", "Pokazatelji periodični", this.Site + ".Finpos.IzvRazno", null, null, "AKTIVNOST.Select"));

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.FinaObrasci", "Fina obrasci", this.Site + ".Finpos.IzvPR", null, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.OpzStat", "Obrazac OPZ-STAT-1", this.Site + ".Finpos.IzvPR", null, null, "AKTIVNOST.Select"));
            //this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.Partneri", "Poslovni partneri", this.Site + ".Finpos.IzvOstalo", null, null, "AKTIVNOST.Select"));
            //this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos.KontniPlan", "Kontni plan", this.Site + ".Finpos.IzvOstalo", null, null, "AKTIVNOST.Select"));

            Configuration.ConfigurationProvider = new MipsedConfigurationProvider();
        }

        protected override void OnRunStarted()
        {
            this.MenuEntryAdapter.AddElements(this.RootWorkItem, this.m_UICommandDefinitionContainer, null);
            this.Items.AddNew<MainController>();
            base.OnRunStarted();
        }

        [ServiceDependency(Type=typeof(IUICommandDefinitionMenuAdapterService))]
        public virtual IUICommandDefinitionAdapterService MainMenuEntryAdapter
        {
            get
            {
                return this.m_MenuAdapterService;
            }
            set
            {
                this.m_MenuAdapterService = value;
            }
        }

        [ServiceDependency(Type=typeof(IUICommandDefinitionVerticalToolPanelAdapterService))]
        public virtual IUICommandDefinitionAdapterService MenuEntryAdapter
        {
            get
            {
                return this.m_UICommandDefinitionAdapterService;
            }
            set
            {
                this.m_UICommandDefinitionAdapterService = value;
            }
        }

        public string Site
        {
            get
            {
                return "MainMenu";
            }
        }

        public Deklarit.Practices.CompositeUI.UICommandDefinitionContainer UICommandDefinitionContainer
        {
            get
            {
                return this.m_UICommandDefinitionContainer;
            }
        }
    }
}


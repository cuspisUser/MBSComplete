namespace ServisModule.ServisModule
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Services;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.VisualBasic.CompilerServices;
    using mipsed.application.framework;
    using System;
    using System.Data;

    public class MainWorkItem : WorkItem
    {
        private IUICommandDefinitionAdapterService m_MenuAdapterService;
        private IUICommandDefinitionAdapterService m_UICommandDefinitionAdapterService;
        private Deklarit.Practices.CompositeUI.UICommandDefinitionContainer m_UICommandDefinitionContainer;

        public MainWorkItem()
        {
            this.m_UICommandDefinitionContainer = new Deklarit.Practices.CompositeUI.UICommandDefinitionContainer(this);

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("ServisneFunkcije", "SERVISNE FUNKCIJE", this.Site + "", 11, false, true, DeklaritMode.All));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Serviseri", "Serviseri", this.Site + ".ServisneFunkcije", true));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Saldiranje", "Saldiranje i zaključivanje", this.Site + ".ServisneFunkcije", true));


            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("BazePodataka", "Rad s bazama", this.Site + ".ServisneFunkcije.Serviseri", null, null, "BANKE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("MigracijaMIPSED1", "Migracija podataka iz MIPSED.NET", this.Site + ".ServisneFunkcije.Serviseri", null, null, "BANKE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("IMPORTIP", "Obrazac IP - DOS / MIPSED.NET", this.Site + ".ServisneFunkcije.Serviseri", null, null, "BANKE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Margine", "Podešavanje margina", this.Site + ".ServisneFunkcije.Serviseri", null, null, "BANKE.Select"));

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.OBRACUNCommand", "Ručna korekcija iznosa", this.Site + ".ServisneFunkcije.Saldiranje", null, null, "OBRACUN.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Servis.Rezultat", "Zatvaranje prihoda i rashoda", this.Site + ".ServisneFunkcije.Saldiranje", null, null, "OBRACUN.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Servis.Saldiranje", "Saldiranje imovine, obveza i izvora", this.Site + ".ServisneFunkcije.Saldiranje", null, null, "OBRACUN.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Servis.PromjenaGodine", "Promjena fiskalne godine", this.Site + ".ServisneFunkcije.Saldiranje", null, null, "OBRACUN.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Servis.ZakljucnoStanje", "Prijenos zaključnog stanja u novu godinu", this.Site + ".ServisneFunkcije.Saldiranje", null, null, "OBRACUN.Select"));
            
             // Privremena implementacija MenuItem "Pomoć i podrška"
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("PomocPodrska", "POMOĆ I PODRŠKA", this.Site + "", 11, false, true, DeklaritMode.All));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("PomocPodrskaUpute", "Upute", this.Site + ".PomocPodrska", true));

            //this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("PomocPodrska_Upute1", "Obračun plaća", this.Site + ".PomocPodrska.PomocPodrskaUpute", null, null, "BANKE.Select"));
            //this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("PomocPodrska_Upute2", "FINPOS", this.Site + ".PomocPodrska.PomocPodrskaUpute", null, null, "BANKE.Select"));
            //this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("PomocPodrska_Upute3", "UF", this.Site + ".PomocPodrska.PomocPodrskaUpute", null, null, "BANKE.Select"));
            //this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("PomocPodrska_Upute4", "Materijalno", this.Site + ".PomocPodrska.PomocPodrskaUpute", null, null, "BANKE.Select"));

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("VugerVeza", "TeamViewer", this.Site + ".PomocPodrska", null, null, "BANKE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Chat", "Chat", this.Site + ".PomocPodrska", null, null, "BANKE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("RSS", "RSS vijesti", this.Site + ".PomocPodrska", null, null, "BANKE.Select"));
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


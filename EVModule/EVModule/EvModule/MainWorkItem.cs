namespace EVModule.EvModule
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Services;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.VisualBasic.CompilerServices;
    using mipsed.application.framework;
    using System;
    using System.Data;
    using System.Collections.Generic;

    public class MainWorkItem : WorkItem
    {
        private IUICommandDefinitionAdapterService m_MenuAdapterService;
        private IUICommandDefinitionAdapterService m_UICommandDefinitionAdapterService;
        private Deklarit.Practices.CompositeUI.UICommandDefinitionContainer m_UICommandDefinitionContainer;

        public MainWorkItem()
        {
            this.m_UICommandDefinitionContainer = new Deklarit.Practices.CompositeUI.UICommandDefinitionContainer(this);
            
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Evidencija", "ERV", this.Site + "", 0, false, true, DeklaritMode.All));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Sifrarnici", "Matični podaci", this.Site + ".Evidencija", true));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Obracun", "Unos", this.Site + ".Evidencija", true));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Izvjestaji", "Izvještaji", this.Site + ".Evidencija", true));

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Ev.SmjeneCommand", "Smjene", this.Site + ".Evidencija.Sifrarnici", null, null, "RADNIK.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Ev.EvidencijaUnosCommand", "Unos evidencije", this.Site + ".Evidencija.Obracun", null, null, "RADNIK.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Ev.IDDCOMMAND", "Ispis evidencije", this.Site + ".Evidencija.Izvjestaji", null, null, "RADNIK.Select"));
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


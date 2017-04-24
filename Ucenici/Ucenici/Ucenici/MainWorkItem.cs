namespace Ucenici.Ucenici
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Services;
    using Microsoft.Practices.CompositeUI;
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

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Ucenici", "PRAKSA", this.Site + "", 0, false, true, DeklaritMode.All));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Unos", "Unos", this.Site + ".Ucenici", true));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Obracun", "Obračun", this.Site + ".Ucenici", true));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Izvjestaj", "Izvještaj", this.Site + ".Ucenici", true));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Import", "eMatica", this.Site + ".Ucenici.Unos", false));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Import2", "eMatica nova datoteka", this.Site + ".Ucenici.Unos", false));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.UCENIKCommand", "Učenici", this.Site + ".Ucenici.Unos", false));
            //this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Ucenik.Obracun", "Obračun", this.Site + ".Ucenici.Obracun", 11, null, "RADNIK.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Ucenik.Obracun", "Obračun", this.Site + ".Ucenici.Obracun", null, null, "RADNIK.Select"));
            //this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("IDD-1", "Obrazac IDD-1", this.Site + ".Ucenici.Izvjestaj", false));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Tiskanica-5", "Tiskanica 5", this.Site + ".Ucenici.Izvjestaj", false));
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


namespace DDModule.DDModule
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
            
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("DrugiDohodak", "HONORARI", this.Site + "", 0, false, true, DeklaritMode.All));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Sifrarnici", "Matični podaci", this.Site + ".DrugiDohodak", true));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Obracun", "Obračun", this.Site + ".DrugiDohodak", true));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Izvjestaji", "Izvještaji", this.Site + ".DrugiDohodak", true));

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("DD.DDIZDATAKCommand", "Priznati izdaci", this.Site + ".DrugiDohodak.Sifrarnici", null, null, "RADNIK.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("DD.DDKATEGORIJACommand", "Kategorije isplate", this.Site + ".DrugiDohodak.Sifrarnici", null, null, "RADNIK.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("DD.DDVRSTEPOSLACommand", "Vrste posla", this.Site + ".DrugiDohodak.Sifrarnici", null, null, "RADNIK.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("DD.DDKOLONAIDDCommand", "Stupci obrasca IDD", this.Site + ".DrugiDohodak.Sifrarnici", null, null, "RADNIK.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("DD.DDRADNIKCommand", "Honorarni djelatnici", this.Site + ".DrugiDohodak.Obracun", null, null, "RADNIK.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("DD.ObracunCommand", "Obračun", this.Site + ".DrugiDohodak.Obracun", null, null, "RADNIK.Select"));
            //hrvoje
            //this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("DD.IDDCOMMAND", "Obrazac IDD", this.Site + ".DrugiDohodak.Izvjestaji", null, null, "RADNIK.Select"));
            //this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("DD.IP1COMMAND", "Obrazac ID-1", this.Site + ".DrugiDohodak.Izvjestaji", null, null, "RADNIK.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("DD.PotvrdaCommand", "Potvrda o isplaćenom primitku", this.Site + ".DrugiDohodak.Izvjestaji", null, null, "RADNIK.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("DD.DNRCommand", "Dohodak od nesamostalnog rada", this.Site + ".DrugiDohodak.Izvjestaji", null, null, "RADNIK.Select"));
            //this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("DD.Import", "Uvoz primatelja", this.Site + ".DrugiDohodak.Izvjestaji", null, null, "RADNIK.Select"));
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


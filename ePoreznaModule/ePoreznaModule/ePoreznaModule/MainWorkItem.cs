namespace ePoreznaModule.ePoreznaModule
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

            //this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("ePorezna", "eDOKUMENTI", this.Site + "", 0, false, true, DeklaritMode.All));
            //this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("ePorezna1", "ePorezna", this.Site + ".ePorezna", true));
            ////this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("ID-2011", "ID obrazac ver. 2011", this.Site + ".ePorezna", false));
            //this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("ID-2011", "eID obrazac - plaća", this.Site + ".ePorezna.ePorezna1", false));
            //hrvoje
            //this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("IDD", "IDD obrazac", this.Site + ".ePorezna", false));
            //this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("IDD", "eIDD obrazac - honorari", this.Site + ".ePorezna.ePorezna1", false));
            //this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("PDV", "PDV obrazac", this.Site + ".ePorezna", false));
            
            // Diana: "ovo je potrebno zakomentirati jer ne radi"
            //this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("PDV", "ePDV", this.Site + ".ePorezna.ePorezna1", false));
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


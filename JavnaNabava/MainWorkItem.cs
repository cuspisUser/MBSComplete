using System;

using Microsoft.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.Services;

namespace JavnaNabava
{
    public class MainWorkItem : WorkItem
    {
        private IUICommandDefinitionAdapterService m_MenuAdapterService;
        private IUICommandDefinitionAdapterService m_UICommandDefinitionAdapterService;
        private Deklarit.Practices.CompositeUI.UICommandDefinitionContainer m_UICommandDefinitionContainer;

        public MainWorkItem()
        {
            this.m_UICommandDefinitionContainer = new UICommandDefinitionContainer(this);
            
            
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("JN", "JAVNA NABAVA", this.Site, 0, false, true, DeklaritMode.All));

            // ---------------------------------------------------------------------------------------------------------------
            // Maticni podaci
            // ---------------------------------------------------------------------------------------------------------------
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("MaticniPodaci", "Matični podaci", this.Site + ".JN", true));

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("JN.EVRStruktura", "EVR struktura", this.Site + ".JN.MaticniPodaci", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("JN.VrsteNabave", "Vrste nabave", this.Site + ".JN.MaticniPodaci", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("JN.CPVOznake", "CPV oznake", this.Site + ".JN.MaticniPodaci", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("JN.Ustanove", "Ustanove", this.Site + ".JN.MaticniPodaci", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("JN.FiskalneGodine", "Fiskalne godine", this.Site + ".JN.MaticniPodaci", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("JN.NacinPlacanja", "Način plačanja", this.Site + ".JN.MaticniPodaci", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("JN.NacinIsporuke", "Način isporuke", this.Site + ".JN.MaticniPodaci", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("JN.Partner", "Partner", this.Site + ".JN.MaticniPodaci", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("JN.Proizvod", "Proizvod", this.Site + ".JN.MaticniPodaci", null, null, string.Empty));
         
            // ---------------------------------------------------------------------------------------------------------------
            // Nabava
            // ---------------------------------------------------------------------------------------------------------------
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Nabava", "Nabava", this.Site + ".JN", true));

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("JN.Narudzbenica", "Narudžbenica", this.Site + ".JN.Nabava", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("JN.RegistarNabave", "Registar nabave", this.Site + ".JN.Nabava", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("JN.PlanNabave", "Plan nabave", this.Site + ".JN.Nabava", null, null, string.Empty));
            

            // ---------------------------------------------------------------------------------------------------------------
            // Izvjestaji
            // ---------------------------------------------------------------------------------------------------------------
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Izvjestaji", "Izvještaji", this.Site + ".JN", true));

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("JN.IspisPlanNabave", "Uskoro...", this.Site + ".JN.Izvjestaji", null, null, string.Empty));
            //this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("JN.IspisRegistarNabave", "Ispis registra nabave", this.Site + ".JN.Izvjestaji", null, null, string.Empty));

        }

        protected override void OnRunStarted()
        {
            this.MenuEntryAdapter.AddElements(this.RootWorkItem, this.m_UICommandDefinitionContainer, null);
            this.Items.AddNew<MainController>();
            base.OnRunStarted();
        }

        [ServiceDependency(Type = typeof(IUICommandDefinitionMenuAdapterService))]
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

        [ServiceDependency(Type = typeof(IUICommandDefinitionVerticalToolPanelAdapterService))]
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

using System;

using Microsoft.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.Services;

namespace Materijalno
{
    public class MainWorkItem : WorkItem
    {
        private IUICommandDefinitionAdapterService m_MenuAdapterService;
        private IUICommandDefinitionAdapterService m_UICommandDefinitionAdapterService;
        private Deklarit.Practices.CompositeUI.UICommandDefinitionContainer m_UICommandDefinitionContainer;

        public MainWorkItem()
        {
            this.m_UICommandDefinitionContainer = new UICommandDefinitionContainer(this);
            
            
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("MT", "MATERIJALNO", this.Site, 0, false, true, DeklaritMode.All));

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("MaticniPodaci", "Matični podaci", this.Site + ".MT", true));            
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("MT.Partner", "Partneri", this.Site + ".MT.MaticniPodaci", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("MT.Proizvod", "Proizvodi", this.Site + ".MT.MaticniPodaci", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("MT.Grupe", "Grupe proizvoda", this.Site + ".MT.MaticniPodaci", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("MT.JednicaMjere", "Mjerne jedinice", this.Site + ".MT.MaticniPodaci", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("MT.Porez", "Porezne stope", this.Site + ".MT.MaticniPodaci", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("MT.TipSkladista", "Tip Skladišta", this.Site + ".MT.MaticniPodaci", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("MT.Skladiste", "Skladiste", this.Site + ".MT.MaticniPodaci", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("MT.MjestoTroska", "Mjesto troška", this.Site + ".MT.MaticniPodaci", null, null, string.Empty));
           
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Obracun", "Obračun", this.Site + ".MT", true));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("MT.Narudzbenica", "Narudžbenica", this.Site + ".MT.Obracun", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("MT.Primka", "Primka", this.Site + ".MT.Obracun", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("MT.Izdatnica", "Izdatnice", this.Site + ".MT.Obracun", null, null, string.Empty));
            //30.11.2016
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("MT.Inventura", "Inventura", this.Site + ".MT.Obracun", null, null, string.Empty));
           // this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("MT.SkladistePregled", "Stanje skladišta", this.Site + ".MT.Obracun", null, null, string.Empty));
  
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Izvjestaji", "Izvještaji", this.Site + ".MT", true));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("MT.KarticaMaterijala", "Kartice reprodukcijskog materijala", this.Site + ".MT.Izvjestaji", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("MT.StanjeSkladista", "Stanje skladišta", this.Site + ".MT.Izvjestaji", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("MT.StanjeDokumenti", "Stanje dokumenata", this.Site + ".MT.Izvjestaji", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("MT.UlazIzlazGrupa", "Ulaz i izlaz po grupama", this.Site + ".MT.Izvjestaji", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("MT.MjestoTroskaIspis", "Ispis po mjestu troška", this.Site + ".MT.Izvjestaji", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("MT.PrimkeDobavljac", "Primke po dobavljaču", this.Site + ".MT.Izvjestaji", null, null, string.Empty));
            // db - 20.10.2016
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("MT.SaldoKartica", "Saldo kartica", this.Site + ".MT.Izvjestaji", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("MT.InventurnaLista", "Inventurna lista", this.Site + ".MT.Izvjestaji", null, null, string.Empty));

            //db - 17.1.2017
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("ZakljucivanjeOtvaranje", "Zaključivanje/otvaranje", this.Site + ".MT", true));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("MT.ZakljucivanjeOtvaranje", "Zaključivanje godine/otvaranje nove", this.Site + ".MT.ZakljucivanjeOtvaranje", null, null, string.Empty));          
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

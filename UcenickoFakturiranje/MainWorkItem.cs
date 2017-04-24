using System;

using Microsoft.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.Services;

namespace UcenickoFakturiranje
{
    public class MainWorkItem : WorkItem
    {
        private IUICommandDefinitionAdapterService m_MenuAdapterService;
        private IUICommandDefinitionAdapterService m_UICommandDefinitionAdapterService;
        private Deklarit.Practices.CompositeUI.UICommandDefinitionContainer m_UICommandDefinitionContainer;

        public MainWorkItem()
        {
            this.m_UICommandDefinitionContainer = new UICommandDefinitionContainer(this);
            
            
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("UF", "UČENIČKO FAKTURIRANJE", this.Site, 0, false, true, DeklaritMode.All));


            // ---------------------------------------------------------------------------------------------------------------
            // Matični podaci
            // ---------------------------------------------------------------------------------------------------------------
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("MaticniPodaci", "Matični podaci", this.Site + ".UF", true));

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("UF.UstanoveCommand", "Ustanove", this.Site + ".UF.MaticniPodaci", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("UF.SkolskeGodineCommand", "Školske godine", this.Site + ".UF.MaticniPodaci", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("UF.RazrediCommand", "Razredi", this.Site + ".UF.MaticniPodaci", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("UF.OdjeljenjaCommand", "Odjeljenja", this.Site + ".UF.MaticniPodaci", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("UF.VoditeljiCommand", "Voditelji", this.Site + ".UF.MaticniPodaci", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("UF.UceniciCommand", "Učenici", this.Site + ".UF.MaticniPodaci", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("UF.PostanskiBrojeviCommand", "Poštanski brojevi", this.Site + ".UF.MaticniPodaci", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("UF.RadnaMjestaCommand", "Radna mjesta", this.Site + ".UF.MaticniPodaci", null, null, string.Empty));



            // ---------------------------------------------------------------------------------------------------------------
            // Organizacija razreda
            // ---------------------------------------------------------------------------------------------------------------
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("SkolskeGodineRazrednaOdjeljenja", "Školske godine / razredi", this.Site + ".UF", true));

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("UF.OtvaranjeSkolskeGodineCommand", "Otvaranje školske godine", this.Site + ".UF.SkolskeGodineRazrednaOdjeljenja", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("UF.OrganizacijaRazrednihOdjeljenjaCommand", "Organizacija razrednih odjeljenja", this.Site + ".UF.SkolskeGodineRazrednaOdjeljenja", null, null, string.Empty));
            


            // ---------------------------------------------------------------------------------------------------------------
            // Proizvodi, cjenici i olakšice
            // ---------------------------------------------------------------------------------------------------------------
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("ProizvodiCjeniciOlaksice", "Proizvodi, cjenici i olakšice", this.Site + ".UF", true));

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("UF.MjerneJediniceCommand", "Mjerne jedinice", this.Site + ".UF.ProizvodiCjeniciOlaksice", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("UF.PorezneStopeCommand", "Porezne stope", this.Site + ".UF.ProizvodiCjeniciOlaksice", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("UF.OlaksiceCommand", "Olakšice", this.Site + ".UF.ProizvodiCjeniciOlaksice", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("UF.ProizvodiGrupeProizvodaCommand", "Proizvodi / grupe proizvoda", this.Site + ".UF.ProizvodiCjeniciOlaksice", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("UF.CjeniciCommand", "Cjenici", this.Site + ".UF.ProizvodiCjeniciOlaksice", null, null, string.Empty));
            


            // ---------------------------------------------------------------------------------------------------------------
            // Fakturiranje
            // ---------------------------------------------------------------------------------------------------------------
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Fakturiranje", "Fakturiranje", this.Site + ".UF", true));

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("UF.PredlosciCommand", "Predlošci", this.Site + ".UF.Fakturiranje", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("UF.ObracuniCommand", "Obračuni", this.Site + ".UF.Fakturiranje", null, null, string.Empty));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("UF.RacuniCommand", "Računi", this.Site + ".UF.Fakturiranje", null, null, string.Empty));
            


            // ---------------------------------------------------------------------------------------------------------------
            // Izvještaji
            // ---------------------------------------------------------------------------------------------------------------
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Izvjestaji", "Izvještaji", this.Site + ".UF", true));

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("UF.IzvjestajiOtvoreneStavke", "Otvorene stavke po razredima", this.Site + ".UF.Izvjestaji", null, null, string.Empty));
            


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

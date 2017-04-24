namespace SifrarniciModule.SifrarniciModule
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

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("OpciSifrarnici", "KORISNIK - ŠIFRARNICI", this.Site + "", 0, false, true, DeklaritMode.All));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Korisnici", "Korisnik", this.Site + ".OpciSifrarnici", true));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Sifrarnici", "Šifrarnici", this.Site + ".OpciSifrarnici", true));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Potrazivanja", "Potraživanja", this.Site + ".OpciSifrarnici", true));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Obveze", "Obveze", this.Site + ".OpciSifrarnici", true));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Pokazatelji", "Pokazatelji", this.Site + ".OpciSifrarnici", true));

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.KORISNIKCommand", "Korisnik aplikacije", this.Site + ".OpciSifrarnici.Korisnici", null, null, "KORISNIK.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.BANKECommand", "Banke", this.Site + ".OpciSifrarnici.Sifrarnici", null, null, "BANKE.Select"));

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.IZVORDOKUMENTACommand", "FINA - Izvor dokumenta", this.Site + ".OpciSifrarnici.Sifrarnici", null, null, "IZVORDOKUMENTA.Select"));

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.DOPRINOSCommand", "Doprinosi", this.Site + ".OpciSifrarnici.Sifrarnici", null, null, "DOPRINOS.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.OPCINACommand", "Općine", this.Site + ".OpciSifrarnici.Sifrarnici", null, null, "OPCINA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.POREZCommand", "Porezi", this.Site + ".OpciSifrarnici.Sifrarnici", null, null, "POREZ.Select"));

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.TIPIZNOSACommand", "Tip iznosa", this.Site + ".OpciSifrarnici.Sifrarnici", null, null, "TIPIZNOSA.Select"));

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.SHEMAPLACACommand", "Shema plaće", this.Site + ".OpciSifrarnici.Korisnici", null, null, "BANKE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.Shema_UF", "Shema učeničko fakturiranje", this.Site + ".OpciSifrarnici.Korisnici", null, null, "BANKE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.SHEMADDCommand", "Shema honorari", this.Site + ".OpciSifrarnici.Korisnici", null, null, "BANKE.Select"));

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.RAD1GELEMENTIVEZACommand", "RAD-1G Elementi veza", this.Site + ".OpciSifrarnici.Sifrarnici", null, null, "RAD1GELEMENTIVEZA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.RAD1MELEMENTIVEZACommand", "RAD-1M Elementi veza", this.Site + ".OpciSifrarnici.Sifrarnici", null, null, "RAD1MELEMENTIVEZA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.RAD1SPREMEVEZACommand", "RAD-1G Sprema veza", this.Site + ".OpciSifrarnici.Sifrarnici", null, null, "RAD1SPREMEVEZA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.RAD1VEZASPOLCommand", "RAD-1M Spol veza", this.Site + ".OpciSifrarnici.Sifrarnici", null, null, "RAD1VEZASPOL.Select"));

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("DefiniranjeObveze", "Definiranje obrasca obveza", this.Site + ".OpciSifrarnici.Obveze", null, null, "RAD1VEZASPOL.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("DefiniranjePotrazivanje", "Definiranje obrasca potraživanja", this.Site + ".OpciSifrarnici.Potrazivanja", null, null, "RAD1VEZASPOL.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("DefiniranjePokazatelji", "Definiranje obrasca pokazatelja", this.Site + ".OpciSifrarnici.Pokazatelji", null, null, "RAD1VEZASPOL.Select"));
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


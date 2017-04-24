namespace PlacaModule.PlacaModule
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
            
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa", "PLAĆE", this.Site + "", 0, false, true, DeklaritMode.All));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Sifrarnici", "Matični podaci", this.Site + ".Placa", true));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("ElementiPlaca", "Elementi plaća", this.Site + ".Placa", true));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Olaksice", "Olakšice", this.Site + ".Placa", true));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Obustave", "Obustave", this.Site + ".Placa", true));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Obracun", "Obračun", this.Site + ".Placa", true));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Pregledi", "Izvještaji", this.Site + ".Placa", true));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Prosjeci", "Prosjeci za institucije", this.Site + ".Placa", true));

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.ELEMENTCommand", "Elementi", this.Site + ".Placa.ElementiPlaca", null, null, "ELEMENT.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.OSOBNIODBITAKCommand", "Osobni odbici", this.Site + ".Placa.ElementiPlaca", null, null, "OSOBNIODBITAK.Select"));
            
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.SKUPPOREZAIDOPRINOSACommand", "Skupine poreza i doprinosa", this.Site + ".Placa.ElementiPlaca", null, null, "SKUPPOREZAIDOPRINOSA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.KREDITORCommand", "Kreditori", this.Site + ".Placa.Obustave", null, null, "KREDITOR.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.OBUSTAVACommand", "Obustave", this.Site + ".Placa.Obustave", null, null, "OBUSTAVA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.GRUPEOLAKSICACommand", "Grupe olakšica", this.Site + ".Placa.Olaksice", null, null, "GRUPEOLAKSICA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.TIPOLAKSICECommand", "Tipovi olakšica", this.Site + ".Placa.Olaksice", null, null, "TIPOLAKSICE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.OLAKSICECommand", "Olakšice", this.Site + ".Placa.Olaksice", null, null, "OLAKSICE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.GRUPEKOEFCommand", "Grupe koeficijenata", this.Site + ".Placa.Sifrarnici", null, null, "GRUPEKOEF.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.BENEFICIRANICommand", "Beneficirani staž", this.Site + ".Placa.Sifrarnici", null, null, "BENEFICIRANI.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.RADNOMJESTOCommand", "Radna mjesta", this.Site + ".Placa.Sifrarnici", null, null, "RADNOMJESTO.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.ORGDIOCommand", "Organizacijske cjeline", this.Site + ".Placa.Sifrarnici", null, null, "ORGDIO.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.TablicniPregledRadnika", "Pregled radnika", this.Site + ".Placa.Sifrarnici", null, null, "TITULA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.RADNIKCommand", "Zaposlenici", this.Site + ".Placa.Obracun", null, null, "RADNIK.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.BrziUnosKreditaCommand", "Unos kredita", this.Site + ".Placa.Obracun", null, null, "RADNIK.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.PrPlaceCustom", "Predložak plaće", this.Site + ".Placa.Obracun", null, null, "VRSTAOBUSTAVE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.PripremaCommand", "Obračun", this.Site + ".Placa.Obracun", null, null, "VRSTAOBUSTAVE.Select"));

            //this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("IDObrazacCommand", "Obrazac ID", this.Site + ".Placa.Pregledi", null, null, "BANKE.Select"));

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.VirmaniUserCommand", "Nalozi za plaćanje", this.Site + ".Placa.Obracun", null, null, "VRSTAOBUSTAVE.Select"));

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("ListaIznosaCommand", "Lista iznosa radnika", this.Site + ".Placa.Pregledi", null, null, "BANKE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("ZAP1Command", "Obrazac ZAP-1", this.Site + ".Placa.Pregledi", null, null, "BANKE.Select"));
            
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("IPKarticeCommand", "Obrasci IP", this.Site + ".Placa.Pregledi", null, null, "BANKE.Select"));

            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("MaticniKartonCommand", "Matični karton", this.Site + ".Placa.Pregledi", null, null, "BANKE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.Godisnji", "Prosjek za GO", this.Site + ".Placa.Prosjeci", null, null, "PRIPREMAPLACE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.Bolovanje", "Prosjek bolovanje", this.Site + ".Placa.Prosjeci", null, null, "PRIPREMAPLACE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.FondBolovanje", "Prosjek bolovanje/HZZO", this.Site + ".Placa.Prosjeci", null, null, "PRIPREMAPLACE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.ProsjekPlace", "Prosjek neto plaće", this.Site + ".Placa.Prosjeci", null, null, "PRIPREMAPLACE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.Tablica01Command", "Mirovinsko-Tablica 01/10", this.Site + ".Placa.Pregledi", null, null, "PRIPREMAPLACE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.Tablica011Command", "Mirovinsko-Tablica 01/11", this.Site + ".Placa.Pregledi", null, null, "PRIPREMAPLACE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.Tablica018Command", "Mirovinsko-Tablica 01/8", this.Site + ".Placa.Pregledi", null, null, "PRIPREMAPLACE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.RAD1M", "RAD-1M", this.Site + ".Placa.Pregledi", null, null, "PRIPREMAPLACE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.RAD1G", "RAD-1", this.Site + ".Placa.Pregledi", null, null, "PRIPREMAPLACE.Select"));

            if (Mipsed7.Core.ApplicationDatabaseInformation.Modul_PutniNalog == "1")
            {
                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("PutniNalog", "PUTNI NALOZI", this.Site, 0, false, true, DeklaritMode.All));
                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Nalog", "Registar putnih naloga", this.Site + ".PutniNalog", true));
                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("UnosPutnogNaloga", "Unos putnog naloga", this.Site + ".PutniNalog.Nalog", null, null, "UnosPutnogNaloga.Select"));
            }

            if (Mipsed7.Core.ApplicationDatabaseInformation.Modul_JOPPD == "1")
            {
                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("MainJOPPD", "JOPPD", this.Site, 0, false, true, DeklaritMode.All));
                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("MaticniPodaci", "Matični podaci", this.Site + ".MainJOPPD", true));
                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("OznakaPrimitka", "Oznaka primitka", this.Site + ".MainJOPPD.MaticniPodaci", null, null, "OznakaPrimitka.Select"));
                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("OznakaPrimitkaElement", "Ozn. primitka ELEMENT", this.Site + ".MainJOPPD.MaticniPodaci", null, null, "OznakaPrimitkaELEMENT.Select"));
                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("OznakaStjecatelja", "Oznaka stjecatelja primitka", this.Site + ".MainJOPPD.MaticniPodaci", null, null, "OznakaStjecatelja.Select"));
                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("OznakaStjecateljaElement", "Ozn. stjecatelja primitka ELEMENT", this.Site + ".MainJOPPD.MaticniPodaci", null, null, "OznakaStjecateljaELEMENT.Select"));
                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("OznakaNeoporezivog", "Oznaka neoporezivog primitka", this.Site + ".MainJOPPD.MaticniPodaci", null, null, "OznakaNeoporezivog.Select"));
                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("OznakaNeoporezivogElement", "Ozn. neoporezivog primitka ELEMENT", this.Site + ".MainJOPPD.MaticniPodaci", null, null, "OznakaNeoporezivogElement.Select"));
                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("OznakaNacinIsplate", "Oznaka načina isplate", this.Site + ".MainJOPPD.MaticniPodaci", null, null, "OznakaNacinIsplate.Select"));
                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("OznakaNacinIsplateElement", "Ozn. načina isplate ELEMENT", this.Site + ".MainJOPPD.MaticniPodaci", null, null, "OznakaNacinIsplateElement.Select"));
                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("OznakaRadnogVremena", "Oznaka radnog vremena", this.Site + ".MainJOPPD.MaticniPodaci", null, null, "OznakaRadnogVremena.Select"));
                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("OznakaMjesecaOsiguranja", "Oznaka mjeseca osiguranja", this.Site + ".MainJOPPD.MaticniPodaci", null, null, "OznakaMjesecaOsiguranja.Select"));
                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("JOPPDObrasci", "JOPPD obrazac", this.Site + ".MainJOPPD", true));
                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("JOPPDObrazac", "Kreiraj", this.Site + ".MainJOPPD.JOPPDObrasci", null, null, "JOPPDObrazac.Select"));
            }

            if (Mipsed7.Core.ApplicationDatabaseInformation.Modul_Raspored == "1")
            {
                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("RasporedSati", "RASPORED SATI", this.Site, 0, false, true, DeklaritMode.All));
                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("RasporedM", "Raspored Sati", this.Site + ".RasporedSati", true));
                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Raspored", "Raspored Sati", this.Site + ".RasporedSati.RasporedM", null, null, "RasporedSati"));
            }

            if (Mipsed7.Core.ApplicationDatabaseInformation.Modul_COP == "1")
            {

                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("COP", "COP", this.Site, 0, false, true, DeklaritMode.All));
                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("UvozObracuna", "Uvoz obračuna iz COP-a", this.Site + ".COP", true));
                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("UvozXML", "Uvoz iz JOPPD XML datoteke", this.Site + ".COP.UvozObracuna", null, null, "UvozXML.Select"));
                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("UvozCSV", "Uvoz iz CSV datoteke", this.Site + ".COP.UvozObracuna", null, null, "UvozCSV.Select"));

                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("ObracuniRazno", "Obračuni razno", this.Site + ".COP", true));
                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("OsobeObracun", "Osobe za obračun", this.Site + ".COP.ObracuniRazno", null, null, "OsobeObracun.Select"));
                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("SocijalnaPotpora", "Prijevoz - nezaposleni", this.Site + ".COP.ObracuniRazno", null, null, "SocijalnaPotpora.Select"));
                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("SocijalnaNaknada", "Socijalna naknada", this.Site + ".COP.ObracuniRazno", null, null, "SocijalnaNaknada.Select"));
                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Stipendije", "Stipendije - neoporezivo", this.Site + ".COP.ObracuniRazno", null, null, "Stipendije.Select"));
                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("NagradePraksa", "Nagrade-praksa", this.Site + ".COP.ObracuniRazno", null, null, "NagradePraksa.Select"));
                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("NagradeNatjecanja", "Nagrade-natjecanja", this.Site + ".COP.ObracuniRazno", null, null, "NagradeNatjecanja.Select"));
                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("StudentServisNeoporezivo", "Student servis-neoporezivo", this.Site + ".COP.ObracuniRazno", null, null, "StudentServisNeoporezivo.Select"));
                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("StudentServisOporezivo", "Student servis-oporezivo", this.Site + ".COP.ObracuniRazno", null, null, "StudentServisOporezivo.Select"));

            }

            if (Mipsed7.Core.ApplicationDatabaseInformation.Modul_Imovina == "1")
            {
                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("OS", "IMOVINA", this.Site + "", 0, false, true, DeklaritMode.All));

                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("NovaImovina", "Imovina", this.Site + ".OS", true));

                this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("NovaImovina.Nova", "Imovina", this.Site + ".OS.NovaImovina", null, null, "RADNIK.Select"));
            }
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


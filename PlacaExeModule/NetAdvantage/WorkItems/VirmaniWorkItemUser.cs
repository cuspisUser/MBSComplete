namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;
    using NetAdvantage.SmartParts;



    public class VirmaniWorkItemUser : MdiWorkItemBase
    {

        public static string obracun_id = "";
        public static string oznaka_izvjesca = "";
        public static bool isprazni_model = false;
        public static bool kontorla_potvde = false;
        public static bool invalid = false;

        public VirmaniWorkItemUser() : base("Virmani", new Virmani())
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("Obracun") {
                Text = "Obračuni",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition2 = new UICommandDefinition("Otvori") {
                Text = "Otvori obračun",
                Site = "MainShellPanel.Obracun",
                Image = ImageResourcesNew.layout
            };
            this.UICommandDefinitionContainer.Add(definition2);
            UICommandDefinition definition5 = new UICommandDefinition("PonovnoStvori") {
                Text = "Ponovno stvori virmane",
                Site = "MainShellPanel.Obracun",
                Image = ImageResourcesNew.cheque
            };
            this.UICommandDefinitionContainer.Add(definition5);
            UICommandDefinition definition11 = new UICommandDefinition("PromjenaBrojaZaduzenja") {
                Text = "Promjena broja zaduzenja",
                Site = "MainShellPanel.Obracun",
                Image = ImageResourcesNew.user_edit
            };
            this.UICommandDefinitionContainer.Add(definition11);
            UICommandDefinition definition30 = new UICommandDefinition("VirmanInvalide")
            {
                Text = "Virman za invalide",
                Site = "MainShellPanel.Obracun",
                Image = ImageResourcesNew.insert_element
            };
            this.UICommandDefinitionContainer.Add(definition30);
            UICommandDefinition definition14 = new UICommandDefinition("Oznake") {
                Text = "Označavanje",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(definition14);
            UICommandDefinition definition4 = new UICommandDefinition("Sve") {
                Text = "Označi sve",
                Site = "MainShellPanel.Oznake",
                Image = ImageResourcesNew.table_select_all
            };
            this.UICommandDefinitionContainer.Add(definition4);
            UICommandDefinition definition3 = new UICommandDefinition("Nista") {
                Text = "Skini oznake",
                Site = "MainShellPanel.Oznake",
                Image = ImageResourcesNew.table
            };
            this.UICommandDefinitionContainer.Add(definition3);
            UICommandDefinition definition = new UICommandDefinition("IspisVirmana") {
                Text = "Ispis virmana",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(definition);
            UICommandDefinition definition6 = new UICommandDefinition("HUB1MATRICNI") {
                Text = "HUB 1 Matrični",
                Site = "MainShellPanel.IspisVirmana",
                Image = ImageResourcesNew.printer
            };
            this.UICommandDefinitionContainer.Add(definition6);
            UICommandDefinition definition7 = new UICommandDefinition("HUB11matricni") {
                Text = "HUB 1-1 Matrični",
                Site = "MainShellPanel.IspisVirmana",
                Image = ImageResourcesNew.printer
            };
            this.UICommandDefinitionContainer.Add(definition7);
            UICommandDefinition definition8 = new UICommandDefinition("HUB11lASER") {
                Text = "HUB 1-1 Laser",
                Site = "MainShellPanel.IspisVirmana",
                Image = ImageResourcesNew.printer
            };
            this.UICommandDefinitionContainer.Add(definition8);
            UICommandDefinition definition22 = new UICommandDefinition("HUB3matricni")
            {
                Text = "HUB 3 Matrični",
                Site = "MainShellPanel.IspisVirmana",
                Image = ImageResourcesNew.printer
            };
            this.UICommandDefinitionContainer.Add(definition22);
            UICommandDefinition definition23 = new UICommandDefinition("HUB3Alaser")
            {
                Text = "HUB 3A Laser",
                Site = "MainShellPanel.IspisVirmana",
                Image = ImageResourcesNew.printer
            };
            this.UICommandDefinitionContainer.Add(definition23);
            
            #region MyRegion
                        
            UICommandDefinition definition9 = new UICommandDefinition("Zbrojni") {
                Text = "Zbrojni nalog",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(definition9);

            UICommandDefinition definition24 = new UICommandDefinition("SepaDatoteka")
            {
                Text = "SEPA datoteka za banku",
                Site = "MainShellPanel.Zbrojni",
                Image = ImageResourcesNew.sertificate
            };
            this.UICommandDefinitionContainer.Add(definition24);

            UICommandDefinition definition25 = new UICommandDefinition("SepaDatotekaFina")
            {
                Text = "SEPA datoteka za FINA-u",
                Site = "MainShellPanel.Zbrojni",
                Image = ImageResourcesNew.shading
            };
            this.UICommandDefinitionContainer.Add(definition25);
            
            //db - 03.02.2017
            UICommandDefinition definition12 = new UICommandDefinition("IspisiZN") {
                Text = "Zbrojni nalog ostalo",
                Site = "MainShellPanel.Zbrojni",
                Image = ImageResourcesNew.printer
            };
            this.UICommandDefinitionContainer.Add(definition12);

            UICommandDefinition definition99 = new UICommandDefinition("IspisiZNOsobe")
            {
                Text = "Zbrojni nalog plaća",
                Site = "MainShellPanel.Zbrojni",
                Image = ImageResourcesNew.printer
            };
            this.UICommandDefinitionContainer.Add(definition99);

            UICommandDefinition definition10 = new UICommandDefinition("SnimiDatoteku")
            {
                Text = "Kreiraj datoteku",
                Site = "MainShellPanel.Zbrojni",
                Image = ImageResourcesNew.save_as
            };
            //this.UICommandDefinitionContainer.Add(definition10);
                     
            #endregion

            UICommandDefinition definition15 = new UICommandDefinition("Banke") {
                Text = "Specifikacija isplate za banke",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(definition15);

            //db - 03.02.2017
            //UICommandDefinition definition16 = new UICommandDefinition("IzradiDatotekuBanke") {
            //    Text = "Snimi datoteku za banku",
            //    Site = "MainShellPanel.Banke",
            //    Image = ImageResourcesNew.save_as
            //};
            //this.UICommandDefinitionContainer.Add(definition16);

            UICommandDefinition definition17 = new UICommandDefinition("IspisiListuBanaka") {
                Text = "Liste isplata-samo zbirni",
                Site = "MainShellPanel.Banke",
                Image = ImageResourcesNew.list
            };
            //this.UICommandDefinitionContainer.Add(definition17);
            UICommandDefinition definition18 = new UICommandDefinition("IspisiListuBanakaSvi") {
                Text = "Liste isplata-svi",
                Site = "MainShellPanel.Banke",
                Image = ImageResourcesNew.legend
            };
            this.UICommandDefinitionContainer.Add(definition18);
            /*UICommandDefinition definition19 = new UICommandDefinition("DisketaHZZO") {
                Text = "Disketa HZZO",
                Site = "MainShellPanel.Banke",
                Image = ImageResourcesNew.save_as
            };
            this.UICommandDefinitionContainer.Add(definition19);*/
            UICommandDefinition definition20 = new UICommandDefinition("Nalog") {
                Text = "Nalog za isplatu",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(definition20);
            UICommandDefinition definition21 = new UICommandDefinition("Prilog1") {
                Text = "Prilog 1",
                Site = "MainShellPanel.Nalog",
                Image = ImageResourcesNew.script
            };
            this.UICommandDefinitionContainer.Add(definition21);
        }

        public override void OnBuiltUp(string id)
        {
            base.OnBuiltUp("");
        }

        public static class OsobeIzObracuna
        {
            // This member is serialized.
            public static int ? id { get; set; }

            // This is serialized even though it is private.
            public static  System.Collections.Generic.List<int> ucenici { get; set; }

            public static int ustanova { get; set; }

            //obracuni razno
            public static JOPPD.Enums.Vrstaobracuna obracunRaznoVrsta { get; set; }
        }
    }
}


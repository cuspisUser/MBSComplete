namespace IPKarticeNamespace
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;
    using NetAdvantage.SmartParts;

    public class IPKarticeWorkItem : MdiWorkItemBase
    {
        public IPKarticeWorkItem() : base("IPKartice", new IPKarticeNamespace.IPKartice())
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("IPObrasci") {
                Text = "IP Obrasci",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition9 = new UICommandDefinition("OtvoriGodinu") {
                Text = "Otvori godinu",
                Site = "MainShellPanel.IPObrasci",
                Image = ImageResourcesNew.calendar_view_month
            };
            this.UICommandDefinitionContainer.Add(definition9);
            UICommandDefinition definition11 = new UICommandDefinition("Zadaci") {
                Text = "Zadaci",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(definition11);
            UICommandDefinition definition5 = new UICommandDefinition("Ispisi") {
                Text = "IP Ispis prije 2011.",
                Site = "MainShellPanel.Zadaci",
                Image = ImageResourcesNew.script
            };
            this.UICommandDefinitionContainer.Add(definition5);
            UICommandDefinition definition7 = new UICommandDefinition("Ispisi2011") {
                Text = "IP-Ispis nakon 2011.",
                Site = "MainShellPanel.Zadaci",
                Image = ImageResourcesNew.script_go
            };
            this.UICommandDefinitionContainer.Add(definition7);
            UICommandDefinition definition6 = new UICommandDefinition("IspisiZbirni") {
                Text = "Ispiši zbirni IP",
                Site = "MainShellPanel.Zadaci",
                Image = ImageResourcesNew.script_link
            };
            this.UICommandDefinitionContainer.Add(definition6);
            UICommandDefinition definition2 = new UICommandDefinition("OznaciSve") {
                Text = "Označi sve",
                Site = "MainShellPanel.Zadaci",
                Image = ImageResourcesNew.page
            };
            this.UICommandDefinitionContainer.Add(definition2);
            UICommandDefinition definition3 = new UICommandDefinition("SkiniOznake") {
                Text = "Ukloni oznake",
                Site = "MainShellPanel.Zadaci",
                Image = ImageResourcesNew.page_white
            };
            this.UICommandDefinitionContainer.Add(definition3);
            UICommandDefinition definition = new UICommandDefinition("XML") {
                Text = "XML",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(definition);
            UICommandDefinition definition4 = new UICommandDefinition("IzradiXML") {
                Text = "Izradi IP XML",
                Site = "MainShellPanel.XML",
                Image = ImageResourcesNew.page_edit

            };
            this.UICommandDefinitionContainer.Add(definition4);
            UICommandDefinition definition8 = new UICommandDefinition("ProvjeriXML") {
                Text = "Provjeri IP XML",
                Site = "MainShellPanel.XML",
                Image = ImageResourcesNew.check_box
            };
            this.UICommandDefinitionContainer.Add(definition8);
        }

        public override void OnBuiltUp(string id)
        {
            base.OnBuiltUp("");
        }
    }
}


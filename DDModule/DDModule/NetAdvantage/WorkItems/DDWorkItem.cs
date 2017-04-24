
using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.WorkItems;
using System;
using DDModule.Obracun;

namespace DDModule.NetAdvantage.WorkItems
{

    public class DDWorkItem : MdiWorkItemBase
    {
        public DDWorkItem() : base("DDWorkItem", new ObracunDDSmartPart())
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("Obracun") {
                Text = "Obračun",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition2 = new UICommandDefinition("ZapocniNovi") {
                Text = "Započni novi",
                Site = "MainShellPanel.Obracun",
                Image = ImageResourcesNew.page_white
            };
            this.UICommandDefinitionContainer.Add(definition2);
            UICommandDefinition definition3 = new UICommandDefinition("OtvoriPostojeci") {
                Text = "Otvori postojeći",
                Site = "MainShellPanel.Obracun",
                Image = ImageResourcesNew.page
            };
            this.UICommandDefinitionContainer.Add(definition3);
            UICommandDefinition definition12 = new UICommandDefinition("DodajRadnike") {
                Text = "Dodaj radnike u obračun",
                Site = "MainShellPanel.Obracun",
                Image = ImageResourcesNew.user_go
            };
            this.UICommandDefinitionContainer.Add(definition12);
            UICommandDefinition definition13 = new UICommandDefinition("ObrisiRadnike") {
                Text = "Obriši radnike iz obračuna",
                Site = "MainShellPanel.Obracun",
                Image = ImageResourcesNew.user_delete
            };
            this.UICommandDefinitionContainer.Add(definition13);
            UICommandDefinition definition14 = new UICommandDefinition("Izlaz") {
                Text = "Izlaz iz obračuna",
                Site = "MainShellPanel.Obracun",
                Image = ImageResourcesNew.cancel
            };
            this.UICommandDefinitionContainer.Add(definition14);
            UICommandDefinition definition = new UICommandDefinition("Rekapitulacije") {
                Text = "Rekapitulacije",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(definition);
            UICommandDefinition definition11 = new UICommandDefinition("Rekapitulacija") {
                Text = "Rekapitulacija",
                Site = "MainShellPanel.Rekapitulacije",
                Image = ImageResourcesNew.table_sum
            };
            this.UICommandDefinitionContainer.Add(definition11);
            UICommandDefinition definition5 = new UICommandDefinition("Ispisi") {
                Text = "Ispisi",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(definition5);
            UICommandDefinition definition6 = new UICommandDefinition("IspisiPlatneCommand") {
                Text = "Platne/šifra/označeni",
                Site = "MainShellPanel.Ispisi",
                Image = ImageResourcesNew.page_red
            };
            this.UICommandDefinitionContainer.Add(definition6);
            //db - 18.01.2017
            //UICommandDefinition definition7 = new UICommandDefinition("IspisiPlatneAbecedaCommnd") {
            //    Text = "Platne/svi/abeceda",
            //    Site = "MainShellPanel.Ispisi",
            //    Image = ImageResourcesNew.page_white_c
            //};
            //this.UICommandDefinitionContainer.Add(definition7);
            //UICommandDefinition definition4 = new UICommandDefinition("IspisiPlatnePojedinacnoCommand") {
            //    Text = "Platna/odabrani",
            //    Site = "MainShellPanel.Ispisi",
            //    Image = ImageResourcesNew.page_green
            //};
            //this.UICommandDefinitionContainer.Add(definition4);
            UICommandDefinition definition8 = new UICommandDefinition("ListaIznosaCommand") {
                Text = "Lista iznosa",
                Site = "MainShellPanel.Ispisi",
                Image = ImageResourcesNew.page_white_h
            };
            this.UICommandDefinitionContainer.Add(definition8);
            UICommandDefinition definition9 = new UICommandDefinition("VirmaniCommand") {
                Text = "Virmani",
                Site = "MainShellPanel.Ispisi",
                Image = ImageResourcesNew.cheque
            };
            this.UICommandDefinitionContainer.Add(definition9);
            //UICommandDefinition definition10 = new UICommandDefinition("RSMCommand") {
            //    Text = "R-Sm Obrazac",
            //    Site = "MainShellPanel.Ispisi",
            //    Image = ImageResourcesNew.script
            //};
            //this.UICommandDefinitionContainer.Add(definition10);
        }

        public override void OnBuiltUp(string id)
        {
            base.OnBuiltUp("");
        }
    }
}


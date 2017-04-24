
using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.WorkItems;
using System;
using DDModule.ID1;

namespace DDModule.NetAdvantage.WorkItems
{

    public class IP1WORKITEM : MdiWorkItemBase
    {
        public IP1WORKITEM() : base("IP1WORKITEM", new IP1SmartPart())
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("Ip1ObrazacCommand") {
                Text = "ID-1 Obrazac",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition = new UICommandDefinition("OtvoriGodinu") {
                Text = "Za godinu",
                Site = "MainShellPanel.Ip1ObrazacCommand",
                Image = ImageResourcesNew.calendar_view_month
            };
            this.UICommandDefinitionContainer.Add(definition);
            UICommandDefinition definition6 = new UICommandDefinition("IzradiID1") {
                Text = "Snimi ID-1 XML",
                Site = "MainShellPanel.Ip1ObrazacCommand",
                Image = ImageResourcesNew.page_copy
            };
            this.UICommandDefinitionContainer.Add(definition6);
            /*
            UICommandDefinition definition2 = new UICommandDefinition("StariID1") {
                Text = "Stari program",
                Site = "MainShellPanel.Ip1ObrazacCommand",
                Image = ImageResourcesNew.application_form
            };
            this.UICommandDefinitionContainer.Add(definition2);
            */
            UICommandDefinition definition3 = new UICommandDefinition("Ispisi") {
                Text = "Ispiši",
                Site = "MainShellPanel.Ip1ObrazacCommand",
                Image = ImageResourcesNew.printer
            };
            this.UICommandDefinitionContainer.Add(definition3);
            /*
            UICommandDefinition definition5 = new UICommandDefinition("StariProgram") {
                Text = "StariProgram",
                Site = "MainShellPanel",
                IsCategory = true
            };
            
            this.UICommandDefinitionContainer.Add(definition5);
            UICommandDefinition definition7 = new UICommandDefinition("StariOIB") {
                Text = "Unos OIB-a",
                Site = "MainShellPanel.StariProgram",
                Image = ImageResourcesNew.user
            };
            this.UICommandDefinitionContainer.Add(definition7);
            */
        }

        public override void OnBuiltUp(string id)
        {
            base.OnBuiltUp("");
        }
    }
}


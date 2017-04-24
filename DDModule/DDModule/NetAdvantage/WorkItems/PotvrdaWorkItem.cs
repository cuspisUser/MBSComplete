
using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.WorkItems;
using System;
using DDModule.NetAdvantage.SmartParts;


namespace DDModule.NetAdvantage.WorkItems
{

    public class PotvrdaWorkItem : MdiWorkItemBase
    {
        public PotvrdaWorkItem() : base("PotvrdaWorkItem", new PotvrdaSmartPart())
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("Ip1ObrazacCommand") {
                Text = "Potvrda Obrazac",
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
            UICommandDefinition definition2 = new UICommandDefinition("Ispisi") {
                Text = "Ispiši",
                Site = "MainShellPanel.Ip1ObrazacCommand",
                Image = ImageResourcesNew.printer
            };
            this.UICommandDefinitionContainer.Add(definition2);
            UICommandDefinition definition3 = new UICommandDefinition("Stara") {
                Text = "Potvrda /stari program",
                Site = "MainShellPanel.Ip1ObrazacCommand",
                Image = ImageResourcesNew.application_form
            };
            this.UICommandDefinitionContainer.Add(definition3);
        }

        public override void OnBuiltUp(string id)
        {
            base.OnBuiltUp("");
        }
    }
}



using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.WorkItems;
using System;
using DDModule.NetAdvantage.SmartParts;

namespace DDModule.IDD
{

    public class IDDWorkItem : MdiWorkItemBase
    {
        public IDDWorkItem() : base("IDDWorkItem", new IDDSMARTPART())
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("IDDObrazacCommand") {
                Text = "IDD Obrazac",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition = new UICommandDefinition("OtvoriMjesecGodinu") {
                Text = "Za mjesec i godinu",
                Site = "MainShellPanel.IDDObrazacCommand",
                Image = ImageResourcesNew.calendar_view_month
            };
            this.UICommandDefinitionContainer.Add(definition);
        }

        public override void OnBuiltUp(string id)
        {
            base.OnBuiltUp("");
        }
    }
}


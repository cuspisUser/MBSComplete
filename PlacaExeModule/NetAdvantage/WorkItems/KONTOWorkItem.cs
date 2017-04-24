namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class KONTOWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new KONTODataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("KONTO", new FormDefinition(this, new KONTOFormUserControl(), StringResources.KONTOName, StringResources.KONTODescription, "NetAdvantage"));
            this.KONTO.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.KONTO.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewAMSKUPINE2", "AM skupine nabavne vrijednosti", this.KONTO.Site + ".New", 3, null, DeklaritMode.Update)
            {
                PermissionName = "AMSKUPINE.Insert"
            };
            this.KONTO.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewAMSKUPINE2", "AM skupine nabavne vrijednosti", this.KONTO.Site + ".View", 3, null, DeklaritMode.Update)
            {
                PermissionName = "AMSKUPINE.Select"
            };
            this.KONTO.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("NewAMSKUPINE1", "AM skupine ispravka vrijednosti", this.KONTO.Site + ".New", 3, null, DeklaritMode.Update)
            {
                PermissionName = "AMSKUPINE.Insert"
            };
            this.KONTO.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewAMSKUPINE1", "AM skupine ispravka vrijednosti", this.KONTO.Site + ".View", 3, null, DeklaritMode.Update)
            {
                PermissionName = "AMSKUPINE.Select"
            };
            this.KONTO.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("NewAMSKUPINE", "AM skupine izvora vlasništva", this.KONTO.Site + ".New", 3, null, DeklaritMode.Update)
            {
                PermissionName = "AMSKUPINE.Insert"
            };
            this.KONTO.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewAMSKUPINE", "AM skupine izvora vlasništva", this.KONTO.Site + ".View", 3, null, DeklaritMode.Update)
            {
                PermissionName = "AMSKUPINE.Select"
            };
            this.KONTO.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("NewBLAGAJNA", "BLAGAJNA", this.KONTO.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "BLAGAJNA.Insert"
            };
            this.KONTO.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewBLAGAJNA", "BLAGAJNA", this.KONTO.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "BLAGAJNA.Select"
            };
            this.KONTO.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("NewGKSTAVKA", "GKSTAVKA", this.KONTO.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "GKSTAVKA.Insert"
            };
            this.KONTO.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewGKSTAVKA", "GKSTAVKA", this.KONTO.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "GKSTAVKA.Select"
            };
            this.KONTO.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public FormDefinition KONTO
        {
            get
            {
                return base.m_FormDefinitionDictionary["KONTO"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.KONTO;
            }
        }
    }
}


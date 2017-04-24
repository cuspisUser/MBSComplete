namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class DOSIPZAGLAVLJEWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new DOSIPZAGLAVLJEDataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("DOSIPZAGLAVLJE", new FormDefinition(this, new DOSIPZAGLAVLJEFormUserControl(), StringResources.DOSIPZAGLAVLJEName, StringResources.DOSIPZAGLAVLJEDescription, "NetAdvantage"));
            this.DOSIPZAGLAVLJE.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.DOSIPZAGLAVLJE.Site));
            base.OnInitialized();
        }

        public FormDefinition DOSIPZAGLAVLJE
        {
            get
            {
                return base.m_FormDefinitionDictionary["DOSIPZAGLAVLJE"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.DOSIPZAGLAVLJE;
            }
        }
    }
}


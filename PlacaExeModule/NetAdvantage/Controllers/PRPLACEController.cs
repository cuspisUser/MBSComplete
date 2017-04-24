namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public class PRPLACEController : FormControllerBase
    {
        public DialogResult AddPRPLACEPRPLACEELEMENTI(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.PRPLACEWorkItem) this.WorkItem).PRPLACEPRPLACEELEMENTI.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult AddPRPLACEPRPLACEELEMENTIRADNIK(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.PRPLACEWorkItem) this.WorkItem).PRPLACEPRPLACEELEMENTIRADNIK.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult DeletePRPLACEPRPLACEELEMENTI(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.PRPLACEWorkItem) this.WorkItem).PRPLACEPRPLACEELEMENTI.Show(DeklaritMode.Delete, currentRow, false);
        }

        public DialogResult DeletePRPLACEPRPLACEELEMENTIRADNIK(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.PRPLACEWorkItem) this.WorkItem).PRPLACEPRPLACEELEMENTIRADNIK.Show(DeklaritMode.Delete, currentRow, false);
        }

        public override void DoUpdate()
        {
            DataAdapterFactory.GetPRPLACEDataAdapter().Update(this.DataSet);
        }

        public DialogResult UpdatePRPLACEPRPLACEELEMENTI(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.PRPLACEWorkItem) this.WorkItem).PRPLACEPRPLACEELEMENTI.Show(DeklaritMode.Update, currentRow, false);
        }

        public DialogResult UpdatePRPLACEPRPLACEELEMENTIRADNIK(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.PRPLACEWorkItem) this.WorkItem).PRPLACEPRPLACEELEMENTIRADNIK.Show(DeklaritMode.Update, currentRow, false);
        }

        public PRPLACEDataSet DataSet
        {
            get
            {
                return (PRPLACEDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition PRPLACEFormDefinition
        {
            get
            {
                return this.PRPLACEWorkItem.PRPLACE;
            }
        }

        public FormDefinition PRPLACEPRPLACEELEMENTIFormDefinition
        {
            get
            {
                return this.PRPLACEWorkItem.PRPLACEPRPLACEELEMENTI;
            }
        }

        public FormDefinition PRPLACEPRPLACEELEMENTIRADNIKFormDefinition
        {
            get
            {
                return this.PRPLACEWorkItem.PRPLACEPRPLACEELEMENTIRADNIK;
            }
        }

        public NetAdvantage.WorkItems.PRPLACEWorkItem PRPLACEWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.PRPLACEWorkItem) this.WorkItem;
            }
        }
    }
}


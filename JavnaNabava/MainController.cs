using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Deklarit.Practices.CompositeUI.Commands;
using NetAdvantage.WorkItems;
using JavnaNabava.BusinessLogic;
using JavnaNabava.UI.MaticniPodaci;
using JavnaNabava.UI.Nabava;
using UcenickoFakturiranje.UI.MaticniPodaci;

namespace JavnaNabava
{
    public class MainController : Controller
    {
        #region Matični podaci 

        [CommandHandler("JN.Partner")]
        public void Partner_Command(object sender, EventArgs e)
        {
            PARTNERWorkWithWorkItem item = this.WorkItem.Items.Get<PARTNERWorkWithWorkItem>("JN.Partner");
            if (item == null)
            {
                item = WorkItem.Items.AddNew<PARTNERWorkWithWorkItem>("JN.Partner");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("JN.Proizvod")]
        public void Proizvod_Command(object sender, EventArgs e)
        {
            PROIZVODWorkWithWorkItem item = this.WorkItem.Items.Get<PROIZVODWorkWithWorkItem>("JN.Proizvod");
            if (item == null)
            {
                item = WorkItem.Items.AddNew<PROIZVODWorkWithWorkItem>("JN.Proizvod");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("JN.EVRStruktura")]
        public void EVRStruktura_Command(object sender, EventArgs e)
        {
            EVRStrukturaFormPregledWorkItem item = this.WorkItem.Items.Get<EVRStrukturaFormPregledWorkItem>("JN.EVRStruktura");
            if (item == null)
            {
                item = WorkItem.Items.AddNew<EVRStrukturaFormPregledWorkItem>("JN.EVRStruktura");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("JN.VrsteNabave")]
        public void VrstaNabave_Command(object sender, EventArgs e)
        {
            VrsteNabaveFormPregledWorkItem item = this.WorkItem.Items.Get<VrsteNabaveFormPregledWorkItem>("JN.VrsteNabave");
            if (item == null)
            {
                item = WorkItem.Items.AddNew<VrsteNabaveFormPregledWorkItem>("JN.VrsteNabave");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("JN.CPVOznake")]
        public void CPVOznake_Command(object sender, EventArgs e)
        {
            CPVOznakeFormPregledWorkItem item = this.WorkItem.Items.Get<CPVOznakeFormPregledWorkItem>("JN.CPVOznake");
            if (item == null)
            {
                item = WorkItem.Items.AddNew<CPVOznakeFormPregledWorkItem>("JN.CPVOznake");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("JN.Ustanove")]
        public void Ustanove_Command(object sender, EventArgs e)
        {
            UstanovaFormPregledWorkItem item = this.WorkItem.Items.Get<UstanovaFormPregledWorkItem>("UF.Ustanove");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<UstanovaFormPregledWorkItem>("UF.Ustanove");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("JN.FiskalneGodine")]
        public void FiskalneGodine_Command(object sender, EventArgs e)
        {
            FiskalneGodineFormPregledWorkItem item = this.WorkItem.Items.Get<FiskalneGodineFormPregledWorkItem>("JN.FiskalneGodine");
            if (item == null)
            {
                item = WorkItem.Items.AddNew<FiskalneGodineFormPregledWorkItem>("JN.FiskalneGodine");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("JN.NacinIsporuke")]
        public void NacinIsporuke_Command(object sender, EventArgs e)
        {
            NacinIsporukeFormPregledWorkItem item = this.WorkItem.Items.Get<NacinIsporukeFormPregledWorkItem>("JN.NacinIsporuke");
            if (item == null)
            {
                item = WorkItem.Items.AddNew<NacinIsporukeFormPregledWorkItem>("JN.NacinIsporuke");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("JN.NacinPlacanja")]
        public void NacinPlacanja_Command(object sender, EventArgs e)
        {
            NacinPlacanjaFormPregledWorkItem item = this.WorkItem.Items.Get<NacinPlacanjaFormPregledWorkItem>("JN.NacinPlacanja");
            if (item == null)
            {
                item = WorkItem.Items.AddNew<NacinPlacanjaFormPregledWorkItem>("JN.NacinPlacanja");
            }
            item.Show(item.Workspaces["main"]);
        }

        #endregion

        #region Nabava

        [CommandHandler("JN.Narudzbenica")]
        public void Narudzbenica_Command(object sender, EventArgs e)
        {
            NarudzbenicaFormPregledWorkItem item = this.WorkItem.Items.Get<NarudzbenicaFormPregledWorkItem>("JN.Narudzbenica");
            if (item == null)
            {
                item = WorkItem.Items.AddNew<NarudzbenicaFormPregledWorkItem>("JN.Narudzbenica");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("JN.RegistarNabave")]
        public void RegistarNabave_Command(object sender, EventArgs e)
        {
            RegistarNabaveFormPregledWorkItem item = this.WorkItem.Items.Get<RegistarNabaveFormPregledWorkItem>("JN.RegistarNabave");
            if (item == null)
            {
                item = WorkItem.Items.AddNew<RegistarNabaveFormPregledWorkItem>("JN.RegistarNabave");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("JN.PlanNabave")]
        public void PlanNabave_Command(object sender, EventArgs e)
        {
            PlanNabaveFormPregledWorkItem item = this.WorkItem.Items.Get<PlanNabaveFormPregledWorkItem>("JN.PlanNabave");
            if (item == null)
            {
                item = WorkItem.Items.AddNew<PlanNabaveFormPregledWorkItem>("JN.PlanNabave");
            }
            item.Show(item.Workspaces["main"]);
        }

        #endregion

        #region Izvjestaji

        //[CommandHandler("JN.IspisPlanNabave")]
        //public void IspisPlanNabave_Command(object sender, EventArgs e)
        //{

        //}

        //[CommandHandler("JN.IspisRegistarNabave")]
        //public void IspisRegistarNabave_Command(object sender, EventArgs e)
        //{

        //}

        #endregion

        private void CommandHandler(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("Button ''{0}'' not implemented!", ((ShortcutCommand)sender).Name.ToUpper()), "DEVELOPMENT", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}

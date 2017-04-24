namespace SifrarniciModule.SifrarniciModule
{
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.Commands;
    using NetAdvantage.WorkItems;
    using System;
    using System.Windows.Forms;

    public class MainController : Controller
    {
        [CommandHandler("Placa.BANKECommand")]
        public void BANKECommand(object sender, EventArgs e)
        {
            BANKEWorkWithWorkItem item = this.WorkItem.Items.Get<BANKEWorkWithWorkItem>("Placa.BANKE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<BANKEWorkWithWorkItem>("Placa.BANKE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.DOPRINOSCommand")]
        public void DOPRINOSCommand(object sender, EventArgs e)
        {
            DOPRINOSWorkWithWorkItem item = this.WorkItem.Items.Get<DOPRINOSWorkWithWorkItem>("Placa.DOPRINOS");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<DOPRINOSWorkWithWorkItem>("Placa.DOPRINOS");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.DRZAVLJANSTVOCommand")]
        public void DRZAVLJANSTVOCommand(object sender, EventArgs e)
        {
            DRZAVLJANSTVOWorkWithWorkItem item = this.WorkItem.Items.Get<DRZAVLJANSTVOWorkWithWorkItem>("Placa.DRZAVLJANSTVO");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<DRZAVLJANSTVOWorkWithWorkItem>("Placa.DRZAVLJANSTVO");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.IZVORDOKUMENTACommand")]
        public void IZVORDOKUMENTACommand(object sender, EventArgs e)
        {
            IZVORDOKUMENTAWorkWithWorkItem item = this.WorkItem.Items.Get<IZVORDOKUMENTAWorkWithWorkItem>("Placa.IZVORDOKUMENTA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<IZVORDOKUMENTAWorkWithWorkItem>("Placa.IZVORDOKUMENTA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.KORISNIKCommand")]
        public void KORISNIKCommand(object sender, EventArgs e)
        {
            KORISNIKWorkWithWorkItem item = this.WorkItem.Items.Get<KORISNIKWorkWithWorkItem>("Placa.KORISNIK");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<KORISNIKWorkWithWorkItem>("Placa.KORISNIK");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.KRIZNIPOREZCommand")]
        public void KRIZNIPOREZCommand(object sender, EventArgs e)
        {
            KRIZNIPOREZWorkWithWorkItem item = this.WorkItem.Items.Get<KRIZNIPOREZWorkWithWorkItem>("Placa.KRIZNIPOREZ");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<KRIZNIPOREZWorkWithWorkItem>("Placa.KRIZNIPOREZ");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.OPCINACommand")]
        public void OPCINACommand(object sender, EventArgs e)
        {
            OPCINAWorkWithWorkItem item = this.WorkItem.Items.Get<OPCINAWorkWithWorkItem>("Placa.OPCINA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<OPCINAWorkWithWorkItem>("Placa.OPCINA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.OSNOVAOSIGURANJACommand")]
        public void OSNOVAOSIGURANJACommand(object sender, EventArgs e)
        {
            OSNOVAOSIGURANJAWorkWithWorkItem item = this.WorkItem.Items.Get<OSNOVAOSIGURANJAWorkWithWorkItem>("Placa.OSNOVAOSIGURANJA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<OSNOVAOSIGURANJAWorkWithWorkItem>("Placa.OSNOVAOSIGURANJA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.POREZCommand")]
        public void POREZCommand(object sender, EventArgs e)
        {
            POREZWorkWithWorkItem item = this.WorkItem.Items.Get<POREZWorkWithWorkItem>("Placa.POREZ");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<POREZWorkWithWorkItem>("Placa.POREZ");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.RAD1GELEMENTIVEZACommand")]
        public void RAD1GELEMENTIVEZACommand(object sender, EventArgs e)
        {
            RAD1GELEMENTIVEZAWorkWithWorkItem item = this.WorkItem.Items.Get<RAD1GELEMENTIVEZAWorkWithWorkItem>("Placa.RAD1GELEMENTIVEZA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RAD1GELEMENTIVEZAWorkWithWorkItem>("Placa.RAD1GELEMENTIVEZA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.RAD1MELEMENTIVEZACommand")]
        public void RAD1MELEMENTIVEZACommand(object sender, EventArgs e)
        {
            RAD1MELEMENTIVEZAWorkWithWorkItem item = this.WorkItem.Items.Get<RAD1MELEMENTIVEZAWorkWithWorkItem>("Placa.RAD1MELEMENTIVEZA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RAD1MELEMENTIVEZAWorkWithWorkItem>("Placa.RAD1MELEMENTIVEZA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.RAD1SPREMEVEZACommand")]
        public void RAD1SPREMEVEZACommand(object sender, EventArgs e)
        {
            RAD1SPREMEVEZAWorkWithWorkItem item = this.WorkItem.Items.Get<RAD1SPREMEVEZAWorkWithWorkItem>("Placa.RAD1SPREMEVEZA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RAD1SPREMEVEZAWorkWithWorkItem>("Placa.RAD1SPREMEVEZA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.RAD1VEZASPOLCommand")]
        public void RAD1VEZASPOLCommand(object sender, EventArgs e)
        {
            RAD1VEZASPOLWorkWithWorkItem item = this.WorkItem.Items.Get<RAD1VEZASPOLWorkWithWorkItem>("Placa.RAD1VEZASPOL");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RAD1VEZASPOLWorkWithWorkItem>("Placa.RAD1VEZASPOL");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.RSVRSTEOBRACUNACommand")]
        public void RSVRSTEOBRACUNACommand(object sender, EventArgs e)
        {
            RSVRSTEOBRACUNAWorkWithWorkItem item = this.WorkItem.Items.Get<RSVRSTEOBRACUNAWorkWithWorkItem>("Placa.RSVRSTEOBRACUNA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RSVRSTEOBRACUNAWorkWithWorkItem>("Placa.RSVRSTEOBRACUNA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.RSVRSTEOBVEZNIKACommand")]
        public void RSVRSTEOBVEZNIKACommand(object sender, EventArgs e)
        {
            RSVRSTEOBVEZNIKAWorkWithWorkItem item = this.WorkItem.Items.Get<RSVRSTEOBVEZNIKAWorkWithWorkItem>("Placa.RSVRSTEOBVEZNIKA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RSVRSTEOBVEZNIKAWorkWithWorkItem>("Placa.RSVRSTEOBVEZNIKA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.SHEMADDCommand")]
        public void SHEMADDCommand(object sender, EventArgs e)
        {
            SHEMADDWorkWithWorkItem item = this.WorkItem.Items.Get<SHEMADDWorkWithWorkItem>("Placa.SHEMADD");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<SHEMADDWorkWithWorkItem>("Placa.SHEMADD");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.SHEMAPLACACommand")]
        public void SHEMAPLACECommand(object sender, EventArgs e)
        {
            SHEMAPLACAWorkWithWorkItem item = this.WorkItem.Items.Get<SHEMAPLACAWorkWithWorkItem>("Placa.SHEMAPLACA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<SHEMAPLACAWorkWithWorkItem>("Placa.SHEMAPLACA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.STRANEKNJIZENJACommand")]
        public void STRANEKNJIZENJACommand(object sender, EventArgs e)
        {
            STRANEKNJIZENJAWorkWithWorkItem item = this.WorkItem.Items.Get<STRANEKNJIZENJAWorkWithWorkItem>("Placa.STRANEKNJIZENJA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<STRANEKNJIZENJAWorkWithWorkItem>("Placa.STRANEKNJIZENJA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.TIPIZNOSACommand")]
        public void TIPIZNOSACommand(object sender, EventArgs e)
        {
            TIPIZNOSAWorkWithWorkItem item = this.WorkItem.Items.Get<TIPIZNOSAWorkWithWorkItem>("Placa.TIPIZNOSA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<TIPIZNOSAWorkWithWorkItem>("Placa.TIPIZNOSA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.UGOVORORADUCommand")]
        public void UGOVORORADUCommand(object sender, EventArgs e)
        {
            UGOVORORADUWorkWithWorkItem item = this.WorkItem.Items.Get<UGOVORORADUWorkWithWorkItem>("Placa.UGOVORORADU");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<UGOVORORADUWorkWithWorkItem>("Placa.UGOVORORADU");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.VRSTADOPRINOSCommand")]
        public void VRSTADOPRINOSCommand(object sender, EventArgs e)
        {
            VRSTADOPRINOSWorkWithWorkItem item = this.WorkItem.Items.Get<VRSTADOPRINOSWorkWithWorkItem>("Placa.VRSTADOPRINOS");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<VRSTADOPRINOSWorkWithWorkItem>("Placa.VRSTADOPRINOS");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.Shema_UF")]
        public void SHEMA_UFCommand(object sender, EventArgs e)
        {
            UcenickoFakturiranje.UI.Fakturiranje.ShemaPregledWorkItem item = this.WorkItem.Items.Get<UcenickoFakturiranje.UI.Fakturiranje.ShemaPregledWorkItem>("UF.Shema");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<UcenickoFakturiranje.UI.Fakturiranje.ShemaPregledWorkItem>("UF.Shema");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("DefiniranjeObveze")]
        public void CommandDefiniranjeObveze(object sender, EventArgs e)
        {
            using (UcenickoFakturiranje.UI.MBS.DefiniranjeObveza.uscObveze objekt = new UcenickoFakturiranje.UI.MBS.DefiniranjeObveza.uscObveze(UcenickoFakturiranje.Enums.FormEditMode.Update))
            {
                objekt.ShowDialogForm("Obveze");
            }
        }

        [CommandHandler("DefiniranjePokazatelji")]
        public void CommandDefiniranjePokazatelji(object sender, EventArgs e)
        {
            using (UcenickoFakturiranje.UI.MBS.DefiniranjePokazatelji.uscPokazatelji objekt = new UcenickoFakturiranje.UI.MBS.DefiniranjePokazatelji.uscPokazatelji(UcenickoFakturiranje.Enums.FormEditMode.Update))
            {
                objekt.ShowDialogForm("Pokazatelji");
            }
        }

        [CommandHandler("DefiniranjePotrazivanje")]
        public void CommandDefiniranjePotrazivanje(object sender, EventArgs e)
        {
            using (UcenickoFakturiranje.UI.MBS.DefiniranjePotrazivanje.uscPotrazivanja objekt = new UcenickoFakturiranje.UI.MBS.DefiniranjePotrazivanje.uscPotrazivanja(UcenickoFakturiranje.Enums.FormEditMode.Update))
            {
                objekt.ShowDialogForm("Potrazivanja");
            }
        }

    }
}


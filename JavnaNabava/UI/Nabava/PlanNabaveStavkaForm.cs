using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JavnaNabava.Enums;

namespace JavnaNabava.UI.Nabava
{
    public partial class PlanNabaveStavkaForm : Controls.BaseUserControl
    {
        #region Metode

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        public PlanNabaveStavkaForm()
        {
            InitializeComponent();
        }

        private void LoadVrstaNabave(BusinessLogic.PlanNabave plan_nabave)
        {
            ucbVrstaNabave.DataSource = plan_nabave.GetVrsteNabave().DefaultView;
            ucbVrstaNabave.DataBind();
        }

        private void LoadStopaPoreza(BusinessLogic.PlanNabave plan_nabave)
        {
            ucbPoreznaStopa.DataSource = plan_nabave.GetStopePoreza().DefaultView;
            ucbPoreznaStopa.DataBind();

            if (ucbPoreznaStopa.DisplayLayout.Bands.Count > 0)
            {
                ucbPoreznaStopa.DisplayLayout.Bands[0].ColHeadersVisible = false;
                ucbPoreznaStopa.DisplayLayout.Bands[0].Columns[0].Hidden = true;
                ucbPoreznaStopa.DisplayLayout.Bands[0].Columns[2].Hidden = true;
            }
        }

        private void LoadKonto(BusinessLogic.PlanNabave plan_nabave)
        {
            ucbKonto.DataSource = plan_nabave.GetKonto().DefaultView;
            ucbKonto.DataBind();
        }

        private bool SaveData()
        {
            lblValidationMessages.ResetText();

            if (ucbKonto.Value != null)
                BusinessLogic.PlanNabave.pID_Konto = ucbKonto.Value.ToString().Trim();
            else
                BusinessLogic.PlanNabave.pID_Konto = "";
            BusinessLogic.PlanNabave.pID_StopaPoreza = (int?)ucbPoreznaStopa.Value;
            BusinessLogic.PlanNabave.pSaPorezom = Convert.ToDecimal(uneSaPDVom.Value);
            BusinessLogic.PlanNabave.pBezPoreza = Convert.ToDecimal(uneBezPDVa.Value);
            BusinessLogic.PlanNabave.pID_VrstaNabave = (int?)ucbVrstaNabave.Value;
            BusinessLogic.PlanNabave.pOpisStavka = txtOpisStavke.Text.Trim();

            StringBuilder message = ValidateDataInput();
            if (message.Length == 0)
            {
                try
                {
                    string naziv_konto = ucbKonto.Text.Split('|')[1];
                    string vrsta_nabave = ucbVrstaNabave.Text;

                    BusinessLogic.PlanNabave.pStavkePlanNabave.Rows.Add(false, BusinessLogic.PlanNabave.pID_Konto, naziv_konto, BusinessLogic.PlanNabave.pBezPoreza,
                                             BusinessLogic.PlanNabave.pID_StopaPoreza, BusinessLogic.PlanNabave.pSaPorezom, BusinessLogic.PlanNabave.pID_VrstaNabave, 
                                             vrsta_nabave, BusinessLogic.PlanNabave.pOpisStavka);

                    return true;
                }
                catch (Exception greska)
                {
                    message.Append(greska.Message);
                }
            }
            lblValidationMessages.Text = message.ToString();

            return false;
        }

        private StringBuilder ValidateDataInput()
        {
            StringBuilder message = new StringBuilder();

            if (BusinessLogic.PlanNabave.pID_VrstaNabave == null)
            {
                message.Append(" - Vrsta nabave je obavezno polje");
            }
            if (BusinessLogic.PlanNabave.pID_StopaPoreza == null)
            {
                message.Append(" - Stopa poreza je obavezno polje");
            }
            if (BusinessLogic.PlanNabave.pID_Konto == "")
            {
                message.Append(" - Konto je obavezno polje");
            }
            if (BusinessLogic.PlanNabave.pBezPoreza == 0)
            {
                message.Append(" - Bez poreza je obavezno polje");
            }
            if (BusinessLogic.PlanNabave.pOpisStavka.Length > 250)
            {
                message.Append(" - Opis stavke može sadržavati maksimalno 250 znakova");
            }

            return message;
        }

        #endregion

        #region Dogadaji

        private void ucbPoreznaStopa_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(uneBezPDVa.Value) > 0)
            {
                decimal pdv = 0;
                decimal bez_poreza = 0;

                bez_poreza = Convert.ToDecimal(uneBezPDVa.Value);
                pdv = bez_poreza * Convert.ToDecimal(ucbPoreznaStopa.SelectedRow.Cells["Stopa"].Value.ToString()) / 100;
                uneSaPDVom.Value = bez_poreza + pdv;
            }
        }

        private void uneBezPDVa_ValueChanged(object sender, EventArgs e)
        {
            if (ucbPoreznaStopa.Value != null)
            {
                decimal pdv = 0;
                decimal bez_poreza = 0;

                bez_poreza = Convert.ToDecimal(uneBezPDVa.Value);
                pdv = bez_poreza * Convert.ToDecimal(ucbPoreznaStopa.SelectedRow.Cells["Stopa"].Value.ToString()) / 100;
                uneSaPDVom.Value = bez_poreza + pdv;
            }
        }

        private void tsbNarudzbenicaOdustani_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.Cancel;
            base.ContainerForm.Close();
        }

        private void tsbNarudzbenicaSpremiZatvori_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                base.ContainerForm.DialogResult = DialogResult.OK;
                base.ContainerForm.Close();
            }
        }

        private void tsbNarudzbenicaSpremiNovi_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                ucbKonto.Value = null;
                uneBezPDVa.Value = 0;
                uneSaPDVom.Value = 0;
                ucbPoreznaStopa.Value = null;
                ucbVrstaNabave.Value = null;
                txtOpisStavke.Text = string.Empty;
            }
        }

        private void PlanNabaveStavkaForm_Load(object sender, EventArgs e)
        {
            BusinessLogic.PlanNabave plan_nabave = new BusinessLogic.PlanNabave();
            LoadVrstaNabave(plan_nabave);
            LoadStopaPoreza(plan_nabave);
            LoadKonto(plan_nabave);
        }

        #endregion

    }
}

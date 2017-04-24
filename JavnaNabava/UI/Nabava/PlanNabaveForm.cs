using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JavnaNabava.Enums;
using Infragistics.Win.UltraWinGrid;

namespace JavnaNabava.UI.Nabava
{
    public partial class uscPlanNabave : Controls.BaseUserControl
    {

        #region Svojstva

        private FormEditMode FormEditMode { get; set; }

        #endregion

        #region Metode

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        public uscPlanNabave(FormEditMode formEditMode)
        {
            InitializeComponent();

            FormEditMode = formEditMode;
        }

        private void LoadUstanova(BusinessLogic.PlanNabave plan_nabave)
        {
            ucbUstanova.DataSource = plan_nabave.GetUstanova().DefaultView;
            ucbUstanova.DataBind();
        }

        private void LoadFiskalnaGodina(BusinessLogic.PlanNabave plan_nabave)
        {
            ucbFiskalnaGodina.DataSource = plan_nabave.GetFiskalnaGodina().DefaultView;
            ucbFiskalnaGodina.DataBind();
        }

        private void LoadPlanNabaveByID(BusinessLogic.PlanNabave plan_nabave)
        {
            if (plan_nabave.PlanNabaveByID())
            {
                ucbUstanova.Value = BusinessLogic.PlanNabave.pID_Ustanova;
                ucbFiskalnaGodina.Value = BusinessLogic.PlanNabave.pID_FiskalnaGodina;
                uteOpisPlana.Text = BusinessLogic.PlanNabave.pNaziv;
                uteKlasa.Text = BusinessLogic.PlanNabave.pKlasa;
                uteUrBroj.Text = BusinessLogic.PlanNabave.pUrBroj;
                ugdPlanNabaveStavka.DataSource = BusinessLogic.PlanNabave.pStavkePlanNabave.DefaultView;

                UkupnaVrijednostSaPDVom(ugdPlanNabaveStavka);

                Utils.Tools.UltraGridStyling(ugdPlanNabaveStavka);

                if (ugdPlanNabaveStavka.DisplayLayout.Bands.Count > 0)
                {
                    ugdPlanNabaveStavka.DisplayLayout.Bands[0].Columns["ID_StopaPoreza"].Hidden = true;
                    ugdPlanNabaveStavka.DisplayLayout.Bands[0].Columns["ID_VrstaNabave"].Hidden = true;

                    ugdPlanNabaveStavka.DisplayLayout.Bands[0].Columns["SEL"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                    ugdPlanNabaveStavka.DisplayLayout.Bands[0].Columns["SEL"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;

                    ugdPlanNabaveStavka.DisplayLayout.Bands[0].Columns["Procijenjena vrijednost bez poreza"].Format = "N2";
                    ugdPlanNabaveStavka.DisplayLayout.Bands[0].Columns["Procijenjena vrijednost sa porezom"].Format = "N2";
                }
            }
        }

        private void UkupnaVrijednostSaPDVom(UltraGrid ugdPlanNabaveStavka)
        {
            decimal ukupno = 0;
            foreach (UltraGridRow red in ugdPlanNabaveStavka.Rows)
            {
                ukupno += Convert.ToDecimal(red.Cells[5].Value);
            }
            uneUkupno.Value = ukupno;
        }

        private bool SaveData()
        {
            lblValidationMessages.ResetText();

            BusinessLogic.PlanNabave.pID_Ustanova = (int?)ucbUstanova.Value;
            if (ucbFiskalnaGodina.Value != null)
                BusinessLogic.PlanNabave.pID_FiskalnaGodina = Convert.ToInt32(ucbFiskalnaGodina.Value);
            else
                BusinessLogic.PlanNabave.pID_FiskalnaGodina = null;
            BusinessLogic.PlanNabave.pNaziv = uteOpisPlana.Text.Trim();
            BusinessLogic.PlanNabave.pKlasa = uteKlasa.Text.Trim();
            BusinessLogic.PlanNabave.pUrBroj = uteUrBroj.Text.Trim();
            BusinessLogic.PlanNabave.pSaPorezomUkupno = Convert.ToDecimal(uneUkupno.Value);

            StringBuilder message = ValidateDataInput();
            if (message.Length == 0)
            {
                BusinessLogic.PlanNabave plan_nabave = new BusinessLogic.PlanNabave();

                if (FormEditMode == Enums.FormEditMode.Insert || FormEditMode == Enums.FormEditMode.Copy)
                {
                    if (plan_nabave.Insert(message, ugdPlanNabaveStavka))
                    {
                        FormEditMode = Enums.FormEditMode.Update;
                        return true;
                    }
                }
                else if (this.FormEditMode == Enums.FormEditMode.Update)
                {
                    if (plan_nabave.Update(message, ugdPlanNabaveStavka))
                    {
                        return true;
                    }
                }
            }

            lblValidationMessages.Text = message.ToString();

            return false;
        }

        private StringBuilder ValidateDataInput()
        {
            StringBuilder message = new StringBuilder();

            if (BusinessLogic.PlanNabave.pID_Ustanova == null)
            {
                message.Append(" - Ustanova je obavezno polje");
            }
            if (BusinessLogic.PlanNabave.pID_FiskalnaGodina == null)
            {
                message.Append(" - Fiskalna godina je obavezno polje");
            }
            if (BusinessLogic.PlanNabave.pNaziv.Length == 0)
            {
                message.Append(" - Naziv je obavezno polje");
            }
            else if (BusinessLogic.PlanNabave.pNaziv.Length > 50)
            {
                message.Append(" - Naziv nesmije biti duži od 50 znakova");
            }
            if (BusinessLogic.PlanNabave.pKlasa.Length > 40)
            {
                message.Append(" - Klasa nesmije biti duži od 40 znakova");
            }
            if (BusinessLogic.PlanNabave.pUrBroj.Length > 40)
            {
                message.Append(" - Ur.Broj nesmije biti duži od 40 znakova");
            }
            return message;
        }

        #endregion

        #region Dogadaji

        private void ugdPlanNabaveStavka_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
        }

        private void uneUkupno_ValueChanged(object sender, EventArgs e)
        {
            uneUkupno.FormatString = "N2";
        }

        private void btnNoviUnos_Click(object sender, EventArgs e)
        {
            using (PlanNabaveStavkaForm plan_nabave_stavka = new PlanNabaveStavkaForm())
            {
                plan_nabave_stavka.ShowDialogForm("Plan nabave stavke");
                ugdPlanNabaveStavka.DataSource = BusinessLogic.PlanNabave.pStavkePlanNabave.DefaultView;
                ugdPlanNabaveStavka.DataBind();
            }

            UkupnaVrijednostSaPDVom(ugdPlanNabaveStavka);

            Utils.Tools.UltraGridStyling(ugdPlanNabaveStavka);

            if (ugdPlanNabaveStavka.DisplayLayout.Bands.Count > 0)
            {
                ugdPlanNabaveStavka.DisplayLayout.Bands[0].Columns["ID_StopaPoreza"].Hidden = true;
                ugdPlanNabaveStavka.DisplayLayout.Bands[0].Columns["ID_VrstaNabave"].Hidden = true;

                ugdPlanNabaveStavka.DisplayLayout.Bands[0].Columns["SEL"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                ugdPlanNabaveStavka.DisplayLayout.Bands[0].Columns["SEL"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;

                ugdPlanNabaveStavka.DisplayLayout.Bands[0].Columns["Procijenjena vrijednost bez poreza"].Format = "N2";
                ugdPlanNabaveStavka.DisplayLayout.Bands[0].Columns["Procijenjena vrijednost sa porezom"].Format = "N2";
            }
        }

        private void btnBrisiOznacene_Click(object sender, EventArgs e)
        {
            for (int i = ugdPlanNabaveStavka.Rows.Count - 1; i > -1; i--)
            {
                if (bool.Parse(ugdPlanNabaveStavka.Rows[i].Cells["SEL"].Value.ToString()))
                {
                    ugdPlanNabaveStavka.Rows[i].Delete();
                }
            }
            UkupnaVrijednostSaPDVom(ugdPlanNabaveStavka);
        }

        private void btnFiskalnaGodina_Click(object sender, EventArgs e)
        {
            using (MaticniPodaci.uscFiskalneGodine fiskalne_godine = new MaticniPodaci.uscFiskalneGodine(Enums.FormEditMode.Insert))
            {
                BusinessLogic.PlanNabave plan_nabave = new BusinessLogic.PlanNabave();
                if (fiskalne_godine.ShowDialogForm("Fiskalne godine") == DialogResult.OK)
                    LoadFiskalnaGodina(plan_nabave);
            }
        }

        private void btnUstanova_Click(object sender, EventArgs e)
        {
            using (UcenickoFakturiranje.UI.MaticniPodaci.UstanovaForm ustanova = new UcenickoFakturiranje.UI.MaticniPodaci.UstanovaForm(UcenickoFakturiranje.Enums.FormEditMode.Insert, null))
            {
                BusinessLogic.PlanNabave plan_nabave = new BusinessLogic.PlanNabave();
                if (ustanova.ShowDialogForm("Ustanova") == DialogResult.OK)
                    LoadUstanova(plan_nabave);
            }
        }

        private void tsbPlanNabaveOdustani_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.Cancel;
            base.ContainerForm.Close();
        }

        private void tsbPlanNabaveSpremiZatvori_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                base.ContainerForm.DialogResult = DialogResult.OK;
                base.ContainerForm.Close();
            }
        }

        private void tsbPlanNabaveSpremiNovi_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                ucbUstanova.Value = null;
                ucbFiskalnaGodina.Value = null;
                uteOpisPlana.Text = string.Empty;
                uteKlasa.Text = string.Empty;
                uteUrBroj.Text = string.Empty;
                ugdPlanNabaveStavka.DataSource = null;
                uneUkupno.Value = 0;
                BusinessLogic.PlanNabave.pStavkePlanNabave.Clear();
                FormEditMode = Enums.FormEditMode.Insert;
            }
        }

        private void uscPlanNabave_Load(object sender, EventArgs e)
        {
            BusinessLogic.PlanNabave.pStavkePlanNabave = new DataTable();
            BusinessLogic.PlanNabave.pStavkePlanNabave.Columns.Add("SEL", typeof(bool));
            BusinessLogic.PlanNabave.pStavkePlanNabave.Columns.Add("Konto", typeof(string));
            BusinessLogic.PlanNabave.pStavkePlanNabave.Columns.Add("Naziv konta", typeof(string));
            BusinessLogic.PlanNabave.pStavkePlanNabave.Columns.Add("Procijenjena vrijednost bez poreza", typeof(decimal));
            BusinessLogic.PlanNabave.pStavkePlanNabave.Columns.Add("ID_StopaPoreza", typeof(int));
            BusinessLogic.PlanNabave.pStavkePlanNabave.Columns.Add("Procijenjena vrijednost sa porezom", typeof(decimal));
            BusinessLogic.PlanNabave.pStavkePlanNabave.Columns.Add("ID_VrstaNabave", typeof(int));
            BusinessLogic.PlanNabave.pStavkePlanNabave.Columns.Add("Vrsta nabave", typeof(string));
            BusinessLogic.PlanNabave.pStavkePlanNabave.Columns.Add("OpisStavka", typeof(string));

            BusinessLogic.PlanNabave plan_nabave = new BusinessLogic.PlanNabave();

            LoadUstanova(plan_nabave);
            LoadFiskalnaGodina(plan_nabave);

            if (FormEditMode == Enums.FormEditMode.Update || FormEditMode == Enums.FormEditMode.Copy)
            {
                LoadPlanNabaveByID(plan_nabave);
            }
        }

        #endregion

    }
}

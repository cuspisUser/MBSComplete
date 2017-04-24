using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinPosModule
{
    public partial class OdobrenjeStavkeForm : BaseUserControl
    {
        #region Properties

        private FormEditMode FormEditMode { get; set; }

        public decimal pKolicina { get; set; }
        public decimal pCijenaPDV { get; set; }
        public decimal pRabat { get; set; }
        public decimal pCijenaNeto { get; set; }
        public int pPorez { get; set; }
        public int pProizvod { get; set; }

        #endregion

        #region Methods

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        public OdobrenjeStavkeForm(FormEditMode formEditMode)
        {
            InitializeComponent();

            FormEditMode = formEditMode;
        }

        private bool SaveData()
        {
            lblValidationMessages.ResetText();

            StringBuilder message = ValidateDataInput();
            if (message.Length == 0)
            {
                decimal porez = Convert.ToDecimal(ucePorez.Value);
                decimal cijenaNeto = Convert.ToDecimal(uneCijenaNeto.Value);
                decimal cijenaPDV = Convert.ToDecimal(uneCijenaPDV.Value);
                decimal kolicina = Convert.ToDecimal(uneKolicina.Value);
                decimal rabat = Convert.ToDecimal(uneRabat.Value);
                int proizvod = Convert.ToInt32(uceProizvod.Value);

                if (FormEditMode == FormEditMode.Insert || FormEditMode == FormEditMode.Copy)
                {

                    DataRow row = Odobrenje.pOdobrenjeStavke.Rows.Find(proizvod);

                    if (row != null)
                    {
                        message.Append("- Proizvod je već dodan, nije moguće dodavati 2 ista proizvoda.");
                    }
                    else
                    {

                        Odobrenje.pOdobrenjeStavke.Rows.Add(false, Odobrenje.pID, proizvod, uceProizvod.Text, porez, ucePorez.Text, cijenaNeto, rabat, kolicina, cijenaPDV);

                        FormEditMode = FormEditMode.Update;
                        return true;
                    }
                }
                else if (this.FormEditMode == FormEditMode.Update)
                {
                    DataRow red = Odobrenje.pOdobrenjeStavke.Select("ID_Proizvod = " + proizvod)[0];

                    Odobrenje.pOdobrenjeStavke.Rows.Remove(red);
                    Odobrenje.pOdobrenjeStavke.AcceptChanges();

                    Odobrenje.pOdobrenjeStavke.Rows.Add(false, Odobrenje.pID, proizvod, uceProizvod.Text, porez, ucePorez.Text, cijenaNeto, rabat, kolicina, cijenaPDV);

                    return true;
                }
            }

            lblValidationMessages.Text = message.ToString();
            return false;
        }

        public StringBuilder ValidateDataInput()
        {
            StringBuilder message = new StringBuilder();

            if (uceProizvod.Value == null)
            {
                message.Append("- Prozvod je obavezan");
            }
            decimal parser;

            if (ucePorez.Value == null)
            {
                message.Append("- Porez je obavezan");
            }

            if (!decimal.TryParse(uneCijenaNeto.Value.ToString(), out parser))
            {
                message.Append("- Krivi format neto cijene");
            }

            if (!decimal.TryParse(uneCijenaPDV.Value.ToString(), out parser))
            {
                message.Append("- Krivi format cijene sa pdv-om");
            }

            if (!decimal.TryParse(uneRabat.Value.ToString(), out parser))
            {
                message.Append("- Krivi format rabata");
            }
            if (parser > 100 | parser < 0)
            {
                message.Append("- uneseni rabat nije moguć");
            }

            return message;
        }

        #endregion

        #region Dogadaji

        private void tsbSpremiZatvori_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                base.ContainerForm.DialogResult = DialogResult.OK;
                base.ContainerForm.Close();
            }
        }

        private void tsbOdustani_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.OK;
            base.ContainerForm.Close();
        }

        private void tsbSpremiNovi_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                uceProizvod.Value = null;
                ucePorez.Value = null;
                uneCijenaNeto.Value = null;
                uneRabat.Value = null;
                uneKolicina.Value = null;
                uneCijenaPDV.Value = null;

                FormEditMode = FormEditMode.Insert;
            }
        }

        private void FormLoad(object sender, EventArgs e)
        {
            using (Odobrenje objekt = new Odobrenje())
            {
                LoadProizvod(objekt);
                LoadPorez(objekt);

                if (FormEditMode == FormEditMode.Update || FormEditMode == FormEditMode.Copy)
                {
                    uceProizvod.Enabled = false;
                    ucePorez.Value = pPorez;
                    uceProizvod.Value = pProizvod;
                    uneCijenaNeto.Value = pCijenaNeto;
                    uneCijenaPDV.Value = pCijenaPDV;
                    uneRabat.Value = pRabat;
                    uneKolicina.Value = pKolicina;
                }
            }
        }

        private void LoadProizvod(Odobrenje objekt)
        {
            uceProizvod.DataSource = objekt.GetProizvod();
            uceProizvod.DataBind();
        }

        private void LoadPorez(Odobrenje objekt)
        {
            ucePorez.DataSource = objekt.GetPorez();
            ucePorez.DataBind();
        }

        #endregion

        private void uceProizvod_ValueChanged(object sender, EventArgs e)
        {
            if (uceProizvod.Value != null)
            {
                try
                {
                    FillMjeraPDV(Convert.ToInt32(uceProizvod.Value));
                }
                catch
                {
                    ucePorez.Value = null;
                    uneCijenaNeto.Value = null;
                    uneCijenaPDV.Value = null;
                    uneRabat.Value = null;
                    uneKolicina.Value = null;
                }
            }
        }

        private void FillMjeraPDV(int proizvod)
        {
            using (Odobrenje objekt = new Odobrenje())
            {
                DataRow row = objekt.GetPorezCijena(proizvod);

                ucePorez.Value = row["ID_PDV"];
                uneCijenaNeto.Value = row["Cijena"];
                uneCijenaPDV.Value = row["CijenaPDV"];

                //if (uneKolicina.Value != null)
                //{
                //    uneCijenaNeto.Value = Convert.ToDecimal(row["Cijena"]) * Convert.ToDecimal(uneKolicina.Value);
                //    uneCijenaPDV.Value = Convert.ToDecimal(row["CijenaPDV"]) * Convert.ToDecimal(uneKolicina.Value);
                //}
                //else
                //{
                //    uneCijenaNeto.Value = row["Cijena"];
                //    uneCijenaPDV.Value = row["CijenaPDV"];
                //}

                //if (uneRabat.Value != null)
                //{
                //    uneCijenaNeto.Value = Convert.ToDecimal(uneCijenaNeto.Value) + (Convert.ToDecimal(uneCijenaNeto.Value) * (Convert.ToDecimal(uneRabat.Value) / 100));
                //    uneCijenaPDV.Value = Convert.ToDecimal(uneCijenaPDV.Value) + (Convert.ToDecimal(uneCijenaPDV.Value) * (Convert.ToDecimal(uneRabat.Value) / 100));
                //}
            }
        }

        private void ucePorez_ValueChanged(object sender, EventArgs e)
        {
            using (Odobrenje objekt = new Odobrenje())
            {
                try
                {
                    decimal stopa = objekt.GetStopaPorez((int)ucePorez.Value);

                    if (uneCijenaNeto.Value != null)
                    {
                        uneCijenaPDV.Value = Convert.ToDecimal(uneCijenaNeto.Value) + (stopa * Convert.ToDecimal(uneCijenaNeto.Value) / 100);

                        //if (uneKolicina.Value != null)
                        //{
                        //    uneCijenaPDV.Value = Convert.ToDecimal(uneCijenaPDV.Value) * Convert.ToDecimal(uneKolicina.Value);
                        //}

                        //if (uneRabat.Value != null)
                        //{
                        //    uneCijenaPDV.Value = Convert.ToDecimal(uneCijenaPDV.Value) + (Convert.ToDecimal(uneCijenaPDV.Value) * (Convert.ToDecimal(uneRabat.Value) / 100));
                        //}
                    }
                    else if (uneCijenaPDV.Value != null)
                    {
                        uneCijenaNeto.Value = Convert.ToDecimal(uneCijenaPDV.Value) / (1 + (stopa / 100));

                        //if (uneKolicina.Value != null)
                        //{
                        //    uneCijenaNeto.Value = Convert.ToDecimal(uneCijenaNeto.Value) * Convert.ToDecimal(uneKolicina.Value);
                        //}

                        //if (uneRabat.Value != null)
                        //{
                        //    uneCijenaNeto.Value = Convert.ToDecimal(uneCijenaNeto.Value) + (Convert.ToDecimal(uneCijenaNeto.Value) * (Convert.ToDecimal(uneRabat.Value) / 100));
                        //}
                    }
                }
                catch { }
            }
        }

        private void uneCijenaNeto_ValueChanged(object sender, EventArgs e)
        {
            if (ucePorez.Value != null)
            {
                using (Odobrenje objekt = new Odobrenje())
                {
                    try
                    {
                        decimal porez = objekt.GetStopaPorez((int)ucePorez.Value) * Convert.ToDecimal(uneCijenaNeto.Value) / 100;
                        uneCijenaPDV.Value = Convert.ToDecimal(uneCijenaNeto.Value) + porez;
                    }
                    catch { }
                }
            }
        }

        private void uneRabat_ValueChanged(object sender, EventArgs e)
        {

        }

        private void uneKolicina_ValueChanged(object sender, EventArgs e)
        {

        }

        private void uneCijenaPDV_ValueChanged(object sender, EventArgs e)
        {
            if (ucePorez.Value != null)
            {
                using (Odobrenje objekt = new Odobrenje())
                {
                    try
                    {
                        uneCijenaNeto.Value = Convert.ToDecimal(uneCijenaPDV.Value) / (1 + (objekt.GetStopaPorez((int)ucePorez.Value) / 100));
                    }
                    catch { }
                }
            }
        }
    }
}

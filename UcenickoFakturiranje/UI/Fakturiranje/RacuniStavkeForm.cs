using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UcenickoFakturiranje.Enums;

namespace UcenickoFakturiranje.UI.Fakturiranje
{
    public partial class RacuniStavkeForm : Controls.BaseUserControl
    {
        #region Properties

        private FormEditMode FormEditMode { get; set; }
        public int pIDProizvod { get; set; }
        public string pNazivPriozvod { get; set; }
        public decimal pCijena { get; set; }
        public decimal pRabat { get; set; }
        public decimal pKolicina { get; set; }
        public decimal pPorez { get; set; }
        public decimal pCijenaPDV { get; set; }
        public int pBrojStavke { get; set; }

        #endregion

        #region Methods

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        public RacuniStavkeForm(FormEditMode formEditMode)
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
                decimal kolicina = Convert.ToDecimal(uneKolicina.Value);
                decimal cijena = Convert.ToDecimal(uneCijena.Value);
                decimal rabat = Convert.ToDecimal(uneRabat.Value);
                decimal pdv = Convert.ToDecimal(uneStopa.Value);
                decimal cijenaUkupno = Convert.ToDecimal(uneUkupnaCijena.Value);
                int brojStavke;

                if (FormEditMode == Enums.FormEditMode.Insert || FormEditMode == Enums.FormEditMode.Copy)
                {
                    DataRow row = BusinessLogic.Racuni.pRacuniStavke.Rows.Find((int)uceProizvod.Value);

                    if (row != null)
                    {
                        message.Append("- Proizvod je već dodan, nije moguće dodavati 2 ista proizvoda.");
                    }
                    else
                    {
                        brojStavke = BusinessLogic.Racuni.pRacuniStavke.Rows.Count + 1;

                        BusinessLogic.Racuni.pRacuniStavke.Rows.Add(false, brojStavke, (int)uceProizvod.Value, uteNazivProizvod.Value.ToString(), cijena, rabat, kolicina, pdv, cijenaUkupno);

                        FormEditMode = Enums.FormEditMode.Update;
                        return true;
                    }
                }
                else if (this.FormEditMode == Enums.FormEditMode.Update)
                {

                    DataRow red = BusinessLogic.Racuni.pRacuniStavke.Select("IDPROIZVOD = " + pIDProizvod)[0];

                    brojStavke = Convert.ToInt32(red["BROJSTAVKE"]);

                    BusinessLogic.Racuni.pRacuniStavke.Rows.Remove(red);
                    BusinessLogic.Racuni.pRacuniStavke.Rows.Add(false, brojStavke, (int)uceProizvod.Value, uteNazivProizvod.Value.ToString(), cijena, rabat, kolicina, pdv, cijenaUkupno);

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
                message.Append("- Proizvod je obavezan");
            }
            decimal parser;

            if (!decimal.TryParse(uneKolicina.Value.ToString(), out parser))
            {
                message.Append("- Krivi format količine");
            }

            if (!decimal.TryParse(uneCijena.Value.ToString(), out parser))
            {
                message.Append("- Krivi format cijene");
            }

            if (!decimal.TryParse(uneRabat.Value.ToString(), out parser))
            {
                message.Append("- Krivi format rabata");
            }

            if (!decimal.TryParse(uneStopa.Value.ToString(), out parser))
            {
                message.Append("- Krivi format poreza");
            }

            return message;
        }

        public Nullable<T> IsDbNull<T>(object value) where T : struct
        {
            if (value != DBNull.Value && value != null)
            {
                // return (T)value; // CAST
                return (T)Convert.ChangeType(value, typeof(T)); // CONVERT
            }
            return null;
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
                uneKolicina.Value = null;
                uneCijena.Value = null;

                FormEditMode = Enums.FormEditMode.Insert;
            }
        }

        private void FormLoad(object sender, EventArgs e)
        {
            using (BusinessLogic.Racuni objekt = new BusinessLogic.Racuni())
            {
                LoadProizvod(objekt);

                if (FormEditMode == Enums.FormEditMode.Update || FormEditMode == Enums.FormEditMode.Copy)
                {
                    uceProizvod.Value = pIDProizvod;
                    uteNazivProizvod.Value = pNazivPriozvod;
                    uneCijena.Value = pCijena;
                    uneRabat.Value = pRabat;
                    uneKolicina.Value = pKolicina;
                    uneStopa.Value = pPorez;
                    uneUkupnaCijena.Value = pCijenaPDV;
                }
            }
        }

        private void LoadProizvod(BusinessLogic.Racuni objekt)
        {
            uceProizvod.DataSource = objekt.GetProizvod();
            uceProizvod.DataBind();
        }

        #endregion

        private void uceProizvod_ValueChanged(object sender, EventArgs e)
        {
            uteNazivProizvod.Value = uceProizvod.Text;
            uneCijena.Value = GetCijena(uceProizvod.Value);

            uneUkupnaCijena.Value = GetUkupnaCijena(Convert.ToDecimal(uneCijena.Value), Convert.ToDecimal(uneRabat.Value), Convert.ToDecimal(uneKolicina.Value), Convert.ToDecimal(uneStopa.Value));
        }

        private object GetUkupnaCijena(decimal cijena, decimal rabat, decimal kolicina, decimal stopa)
        {
            decimal cijenaPDV = (cijena * stopa/100) + cijena;

            return (cijenaPDV - (cijenaPDV * rabat / 100)) * kolicina;
        }

        private object GetCijena(object proizvod)
        {
            using (BusinessLogic.Racuni objekt = new BusinessLogic.Racuni())
            {
                return objekt.GetCijena(Convert.ToInt32(proizvod));
            }
        }

        private void uneStopa_ValueChanged(object sender, EventArgs e)
        {
            uneUkupnaCijena.Value = GetUkupnaCijena(Convert.ToDecimal(uneCijena.Value), Convert.ToDecimal(uneRabat.Value), Convert.ToDecimal(uneKolicina.Value), Convert.ToDecimal(uneStopa.Value));
        }

        private void uneKolicina_ValueChanged(object sender, EventArgs e)
        {
            uneUkupnaCijena.Value = GetUkupnaCijena(Convert.ToDecimal(uneCijena.Value), Convert.ToDecimal(uneRabat.Value), Convert.ToDecimal(uneKolicina.Value), Convert.ToDecimal(uneStopa.Value));
        }

        private void uneRabat_ValueChanged(object sender, EventArgs e)
        {
            uneUkupnaCijena.Value = GetUkupnaCijena(Convert.ToDecimal(uneCijena.Value), Convert.ToDecimal(uneRabat.Value), Convert.ToDecimal(uneKolicina.Value), Convert.ToDecimal(uneStopa.Value));
        }

        private void uneCijena_ValueChanged(object sender, EventArgs e)
        {
            uneUkupnaCijena.Value = GetUkupnaCijena(Convert.ToDecimal(uneCijena.Value), Convert.ToDecimal(uneRabat.Value), Convert.ToDecimal(uneKolicina.Value), Convert.ToDecimal(uneStopa.Value));
        }
    }
}

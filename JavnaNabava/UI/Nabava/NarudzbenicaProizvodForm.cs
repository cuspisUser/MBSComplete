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
    public partial class NarudzbenicaProizvodForm : Controls.BaseUserControl
    {
        #region Metode

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        public NarudzbenicaProizvodForm()
        {
            InitializeComponent();
        }

        private void LoadProizvod(BusinessLogic.Narudzbenica objekt)
        {
            ucbProizvod.DataSource = objekt.GetProizvod();
            ucbProizvod.DataBind();
        }

        private void LoadJedinicaMjere(BusinessLogic.Narudzbenica objekt)
        {
            lblJedinicaMjere.Text = objekt.GetJedinicaMjere();
        }

        private bool SaveData()
        {
            lblValidationMessages.ResetText();

            BusinessLogic.Narudzbenica.pID_Proizvod = (int?)ucbProizvod.Value;
            BusinessLogic.Narudzbenica.pNazivProizvod = ucbProizvod.Text;
            BusinessLogic.Narudzbenica.pKolicinaProizvod = BusinessLogic.Narudzbenica.IsDbNull<decimal>(uneKolicina.Value);

            StringBuilder message = ValidateDataInput();
            if (message.Length == 0)
            {
                try
                {
                    BusinessLogic.Narudzbenica.pNarudzbeProizvod.Rows.Add(false, BusinessLogic.Narudzbenica.pID_Proizvod,
                                    BusinessLogic.Narudzbenica.pNazivProizvod, BusinessLogic.Narudzbenica.pJedinicaMjere, BusinessLogic.Narudzbenica.pKolicinaProizvod, BusinessLogic.Narudzbenica.pID_JedinicaMjere);

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

            if (BusinessLogic.Narudzbenica.pID_Proizvod == null)
            {
                message.Append(" - Proizvod je obavezno polje");
            }
            if (BusinessLogic.Narudzbenica.pKolicinaProizvod == null)
            {
                message.Append(" - Količina je obavezno polje");
            }
            else if (BusinessLogic.Narudzbenica.pKolicinaProizvod == 0)
            {
                message.Append(" - Količina je obavezno polje");
            }
            return message;
        }

        #endregion

        #region Dogadaji

        private void tsbNarudzbenicaOdustani_Click(object sender, EventArgs e)
        {
            ContainerForm.DialogResult = DialogResult.Cancel;
            ContainerForm.Close();
        }

        private void tsbNarudzbenicaSpremiZatvori_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                ContainerForm.DialogResult = DialogResult.OK;
                ContainerForm.Close();
            }
        }

        private void tsbNarudzbenicaSpremiNovi_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                lblJedinicaMjere.Text = null;
                ucbProizvod.Value = null;
                uneKolicina.Value = 0;

                BusinessLogic.Narudzbenica.pOdabraniProizvodi.Clear();
                foreach (DataRow odabrani in BusinessLogic.Narudzbenica.pNarudzbeProizvod.Rows)
                {
                    BusinessLogic.Narudzbenica.pOdabraniProizvodi.Add(odabrani["ID Proizvod"].ToString());
                }
                BusinessLogic.Narudzbenica objekt = new BusinessLogic.Narudzbenica();
                LoadProizvod(objekt);
            }
        }

        private void NarudzbenicaProizvodForm_Load(object sender, EventArgs e)
        {
            BusinessLogic.Narudzbenica objekt = new BusinessLogic.Narudzbenica();
            LoadProizvod(objekt);
        }

        private void ucbProizvod_ValueChanged(object sender, EventArgs e)
        {
            BusinessLogic.Narudzbenica.pID_Proizvod = BusinessLogic.Narudzbenica.IsDbNull<int>(ucbProizvod.Value);
            if (ucbProizvod.Value != null)
            {
                BusinessLogic.Narudzbenica objekt = new BusinessLogic.Narudzbenica();
                LoadJedinicaMjere(objekt);
            }
        }

        #endregion

    }
}

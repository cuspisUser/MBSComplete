using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using JOPPD.Enums;

namespace JOPPD
{
    public partial class uscPutniNalog : Controls.BaseUserControl
    {
        #region Svojstva

        private JOPPD.Enums.FormEditMode FormEditMode
        {
            get;
            set;
        }

        #endregion

        #region Metode

        public uscPutniNalog(FormEditMode formEditMode)
        {
            InitializeComponent();
            FormEditMode = formEditMode;
        }

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);

        }

        private bool SaveData()
        {
            this.lblValidationMessages.ResetText();

            BusinessLogic save = new BusinessLogic();

            if (this.FormEditMode == Enums.FormEditMode.Insert)
            {
                if (save.InsertPutniNalog())
                {
                    FormEditMode = Enums.FormEditMode.Update;
                    return true;
                }
            }
            else if (this.FormEditMode == Enums.FormEditMode.Update)
            {
                if (save.UpdatePutniNalog())
                {
                    return true;
                }
            }

            return false;
        }

        public StringBuilder ValidateDataInput()
        {
            StringBuilder message = new StringBuilder();

            if (BusinessLogic.pID_Radnik == null)
            {
                message.Append(" - Radnik je obavezno polje");
            }
            if (BusinessLogic.pID_Likvidator == null)
            {
                message.Append(" - Likvidator je obavezno polje");
            }
            if (BusinessLogic.pID_NacinIsplate == null)
            {
                message.Append(" - Način isplate je obavezno polje");
            }
            if (BusinessLogic.pSifraPutnogNaloga.Length > 50)
            {
                message.Append(" - Šifra putnog naloga može sadržavati maksimalno 50 znakova");
            }

            return message;
        }

        private void NapuniRadnike(BusinessLogic element, short vrsta)
        {
            if (vrsta == 1)
            {
                ucbImePrezime.DataSource = element.GetRadnici().DefaultView;
                ucbImePrezime.DataBind();
            }

            if (vrsta == 2)
            {
                ucbImePrezime.DataSource = element.GetHonorari().DefaultView;
                ucbImePrezime.DataBind();
            }

            ucbLikvidator.DataSource = element.GetRadnici().DefaultView;
            ucbLikvidator.DataBind();
        }

        private void NapuniNacinIsplate(BusinessLogic element)
        {
            ucbNacinIsplate.DataSource = element.GetJOPPDOznakaNacinIsplate().DefaultView;
            ucbNacinIsplate.DataBind();
        }

        #endregion

        #region Događaji

        private void btnZatvori_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.OK;
            base.ContainerForm.Close();
        }

        private T IsDbNull<T>(object value)
        {
            if (value != DBNull.Value && value != null)
            {
                // return (T)value; // CAST
                return (T)Convert.ChangeType(value, typeof(T)); // CONVERT
            }

            return default(T);
        }

        private void btnSpremiZatvori_Click(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.pID_Radnik = (int?)ucbImePrezime.Value;
            }
            catch { }
            BusinessLogic.pID_Likvidator = (int?)ucbLikvidator.Value;
            BusinessLogic.pDatumPutnogNaloga = (DateTime?)udtDatumNaloga.Value;
            BusinessLogic.pSifraPutnogNaloga = txtSifraNaloga.Text.Trim();
            BusinessLogic.pTroskoviPutovanja = IsDbNull<decimal>(uneTroskoviAutoputa.Value);
            BusinessLogic.pTroskoviVlastitogVozila = IsDbNull<decimal>(uneTroskoviVlVozila.Value);
            BusinessLogic.pOstaliTroskovi = IsDbNull<decimal>(uneDrugiTroskovi.Value);
            BusinessLogic.pDnevnice = IsDbNull<decimal>(uneTroskoviDnevnice.Value);
            BusinessLogic.pID_NacinIsplate = (int?)ucbNacinIsplate.Value;
            BusinessLogic.pTroskoviSmjestaja = IsDbNull<decimal>(uneTroskoviSjestaja.Value);
            BusinessLogic.pIsDrugiTroskovi = cbkDrugiTroskovi.Checked;
            BusinessLogic.pIsTroskoviSmjestaja = cbkTroskoviSmjestaja.Checked;
            BusinessLogic.pAkontacija = IsDbNull<decimal>(uneAkontacija.Value);
            BusinessLogic.pDatumObracuna = (DateTime?)udtDatumObracuna.Value;
            BusinessLogic.pIsTroskoviAutoputa = cbkTroskoviAutoputa.Checked;
            if (cbkZaposlenici.Checked)
            {
                BusinessLogic.pVrstaRadnika = 1;
            }
            else if (cbkHonorari.Checked)
            {
                BusinessLogic.pVrstaRadnika = 2;
            }
            else
            {
                MessageBox.Show("Odaberite vrstu djelatnika za koje želite kreirati putne naloge");
                return;
            }

            StringBuilder message = ValidateDataInput();
            if (message.Length == 0)
            {
                if (SaveData())
                {
                    base.ContainerForm.DialogResult = DialogResult.OK;
                    base.ContainerForm.Close();
                }
                else
                {
                    lblValidationMessages.Text = "Dogodila se greška prilikom upisa putnog naloga.\nKontaktirajte administratora";
                }
            }
            else
            {
                lblValidationMessages.Text = message.ToString();
                return;
            }
        }

        private void btnSpremiNovi_Click(object sender, EventArgs e)
        {
            BusinessLogic.pID_Radnik = (int?)ucbImePrezime.Value;
            BusinessLogic.pID_Likvidator = (int?)ucbLikvidator.Value;
            BusinessLogic.pDatumPutnogNaloga = udtDatumNaloga.DateTime;
            BusinessLogic.pSifraPutnogNaloga = txtSifraNaloga.Text.Trim();
            BusinessLogic.pTroskoviPutovanja = IsDbNull<decimal>(uneTroskoviAutoputa.Value);
            BusinessLogic.pTroskoviVlastitogVozila = IsDbNull<decimal>(uneTroskoviVlVozila.Value);
            BusinessLogic.pOstaliTroskovi = IsDbNull<decimal>(uneDrugiTroskovi.Value);
            BusinessLogic.pDnevnice = IsDbNull<decimal>(uneTroskoviDnevnice.Value);
            BusinessLogic.pID_NacinIsplate = (int?)ucbNacinIsplate.Value;
            BusinessLogic.pTroskoviSmjestaja = IsDbNull<decimal>(uneTroskoviSjestaja.Value);
            BusinessLogic.pIsDrugiTroskovi = cbkDrugiTroskovi.Checked;
            BusinessLogic.pIsTroskoviSmjestaja = cbkTroskoviSmjestaja.Checked;
            BusinessLogic.pAkontacija = IsDbNull<decimal>(uneAkontacija.Value);
            BusinessLogic.pDatumObracuna = udtDatumObracuna.DateTime;
            BusinessLogic.pIsTroskoviAutoputa = cbkTroskoviAutoputa.Checked;
            if (cbkZaposlenici.Checked)
            {
                BusinessLogic.pVrstaRadnika = 1;
            }
            else if (cbkHonorari.Checked)
            {
                BusinessLogic.pVrstaRadnika = 2;
            }
            else
            {
                MessageBox.Show("Odaberite vrstu djelatnika za koje želite kreirati putne naloge");
                return;
            }

            StringBuilder message = ValidateDataInput();
            if (message.Length == 0)
            {
                if (SaveData())
                {
                    ucbImePrezime.Value = null;
                    ucbLikvidator.Value = null;
                    udtDatumNaloga.Value = null;
                    txtSifraNaloga.Text = string.Empty;
                    uneTroskoviAutoputa.Value = null;
                    uneTroskoviVlVozila.Value = null;
                    uneDrugiTroskovi.Value = null;
                    uneTroskoviDnevnice.Value = null;
                    ucbNacinIsplate.Value = null;
                    cbkDrugiTroskovi.Checked = false;
                    cbkTroskoviSmjestaja.Checked = false;
                    uneAkontacija.Value = null;
                    udtDatumObracuna.Value = null;
                    uneTroskoviSjestaja.Value = null;
                    cbkHonorari.Checked = false;
                    cbkZaposlenici.Checked = false;

                    FormEditMode = Enums.FormEditMode.Insert;
                }
                else
                {
                    lblValidationMessages.Text = "Dogodila se greška prilikom upisa putnog naloga.\nKontaktirajte administratora";
                }
            }
            else
            {
                lblValidationMessages.Text = message.ToString();
                return;
            }
        }

        private void uscStjecateljPrimitka_Load(object sender, EventArgs e)
        {
            BusinessLogic element = new BusinessLogic();

            NapuniNacinIsplate(element);

            if (BusinessLogic.pVrstaRadnika == 1)
            {
                NapuniRadnike(element, 1);
            }
            if (BusinessLogic.pVrstaRadnika == 2)
            {
                NapuniRadnike(element, 2);
            }

            if (FormEditMode == Enums.FormEditMode.Update)
            {
                cbkDrugiTroskovi.Checked = BusinessLogic.pIsDrugiTroskovi;
                cbkTroskoviSmjestaja.Checked = BusinessLogic.pIsTroskoviSmjestaja;
                cbkTroskoviAutoputa.Checked = BusinessLogic.pIsTroskoviAutoputa;
                ucbImePrezime.Value = BusinessLogic.pID_Radnik;
                ucbLikvidator.Value = BusinessLogic.pID_Likvidator;
                udtDatumNaloga.Value = BusinessLogic.pDatumPutnogNaloga;
                txtSifraNaloga.Text = BusinessLogic.pSifraPutnogNaloga;
                uneTroskoviAutoputa.Value = BusinessLogic.pTroskoviPutovanja;
                uneTroskoviVlVozila.Value = BusinessLogic.pTroskoviVlastitogVozila;
                uneDrugiTroskovi.Value = BusinessLogic.pOstaliTroskovi;
                uneTroskoviDnevnice.Value = BusinessLogic.pDnevnice;
                ucbNacinIsplate.Value = BusinessLogic.pID_NacinIsplate;
                uneTroskoviSjestaja.Value = BusinessLogic.pTroskoviSmjestaja;
                uneAkontacija.Value = BusinessLogic.pAkontacija;
                udtDatumObracuna.Value = BusinessLogic.pDatumObracuna;
                
                if (BusinessLogic.pVrstaRadnika == 1)
                {
                    cbkZaposlenici.Checked = true;
                }
                else if (BusinessLogic.pVrstaRadnika == 2)
                {
                    cbkHonorari.Checked = true;
                }
            }
        }

        private void uneTroskoviAutoputa_ValueChanged(object sender, EventArgs e)
        {
            decimal? troskovi_vl_vozila;
            decimal? drugi_troskovi;
            decimal? troskovi_dnevnice;
            decimal? troskovi_smjestaja;
            decimal? akontacija;
            decimal troskovi_autoputa;

            troskovi_vl_vozila = IsDbNull<decimal>(uneTroskoviVlVozila.Value);
            troskovi_dnevnice = IsDbNull<decimal>(uneTroskoviDnevnice.Value);
            drugi_troskovi = IsDbNull<decimal>(uneDrugiTroskovi.Value);
            troskovi_smjestaja = IsDbNull<decimal>(uneTroskoviSjestaja.Value);
            akontacija = IsDbNull<decimal>(uneAkontacija.Value);
            troskovi_autoputa = IsDbNull<decimal>(uneTroskoviAutoputa.Value);


            if (cbkDrugiTroskovi.Checked)
            {
                drugi_troskovi = 0;
            }
            if (cbkTroskoviSmjestaja.Checked)
            {
                troskovi_smjestaja = 0;
            }
            if (cbkTroskoviAutoputa.Checked)
                troskovi_autoputa = 0;

            uneIznosZaIsplatu.Value = drugi_troskovi + troskovi_dnevnice + troskovi_vl_vozila + troskovi_smjestaja + troskovi_autoputa - akontacija;

        }

        #endregion

        private void cbkZaposlenici_CheckedChanged(object sender, EventArgs e)
        {
            BusinessLogic element = new BusinessLogic();

            if (((ButtonBase)(sender)).Text == cbkHonorari.Text)
            {
                if (((CheckBox)(sender)).Checked)
                {
                    NapuniRadnike(element, 2);
                    cbkZaposlenici.Checked = false;
                }
            }

            if (((ButtonBase)(sender)).Text == cbkZaposlenici.Text)
            {
                if (((CheckBox)(sender)).Checked)
                {
                    NapuniRadnike(element, 1);
                    cbkHonorari.Checked = false;
                }
            }
        }
    }
}

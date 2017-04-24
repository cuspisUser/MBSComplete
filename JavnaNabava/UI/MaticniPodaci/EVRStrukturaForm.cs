using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JavnaNabava.Enums;

namespace JavnaNabava.UI.MaticniPodaci
{
    public partial class uscEVRStruktura : Controls.BaseUserControl
    {

        #region Svojstva

        private FormEditMode FormEditMode { get; set; }

        #endregion

        #region Metode

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        public uscEVRStruktura(FormEditMode formEditMode)
        {
            InitializeComponent();

            FormEditMode = formEditMode;
        }

        private bool SaveData()
        {
            lblValidationMessages.ResetText();

            BusinessLogic.EVRStruktura.pNaziv = uteNaziv.Text;
            BusinessLogic.EVRStruktura.pPozicija_EVR = ucbPozicijaTeksta.Value.ToString();
            BusinessLogic.EVRStruktura.pSeparator_EVR = ucbSeparator.Value.ToString();
            BusinessLogic.EVRStruktura.pDuzinaBloka = (int)ucbDuzinaBloka.Value;
            BusinessLogic.EVRStruktura.pOrganizacijskaJedinica = cbkOrganizacijskaJedinica.Checked;
            BusinessLogic.EVRStruktura.pMjestoTroska = cbkMjestoTroska.Checked;
            if (ucbSeparatorBlokova.Value != null)
                BusinessLogic.EVRStruktura.pSeparatorBloka = ucbSeparatorBlokova.Value.ToString();
            else
                BusinessLogic.EVRStruktura.pSeparatorBloka = string.Empty;

            StringBuilder message = ValidateDataInput();
            if (message.Length == 0)
            {
                BusinessLogic.EVRStruktura evr_struktura = new BusinessLogic.EVRStruktura();

                if (FormEditMode == Enums.FormEditMode.Insert || FormEditMode == Enums.FormEditMode.Copy)
                {
                    if (evr_struktura.Insert(message))
                    {
                        FormEditMode = Enums.FormEditMode.Update;
                        return true;
                    }
                }
                else if (this.FormEditMode == Enums.FormEditMode.Update)
                {
                    if (evr_struktura.Update(message))
                    {
                        return true;
                    }
                }
            }

            lblValidationMessages.Text = message.ToString();

            return false;
        }

        public StringBuilder ValidateDataInput()
        {
            StringBuilder message = new StringBuilder();

            if (BusinessLogic.EVRStruktura.pNaziv.Length == 0)
            {
                message.Append(" - Naziv je obavezno polje");
            }
            else if (BusinessLogic.EVRStruktura.pNaziv.Length > 50)
            {
                message.Append(" - Naziv može sadržavati maksimalno 50 znakova");
            }
            if (BusinessLogic.EVRStruktura.pPozicija_EVR.Length == 0)
            {
                message.Append(" - Pozicija EVR je obavezno polje");
            }
            if (BusinessLogic.EVRStruktura.pSeparator_EVR.Length == 0)
            {
                message.Append(" - Separator EVR je obavezno polje");
            }
            if (BusinessLogic.EVRStruktura.pDuzinaBloka == null)
            {
                message.Append(" - Duzina bloka je obavezno polje");
            }

            return message;
        }

        private void LoadEVRStrukturaByID(BusinessLogic.EVRStruktura evr_struktura)
        {
            if (evr_struktura.EVRStrukturaByID())
            {
                uteNaziv.Value = BusinessLogic.EVRStruktura.pNaziv;
                ucbPozicijaTeksta.Value = BusinessLogic.EVRStruktura.pPozicija_EVR;
                ucbSeparator.Value = BusinessLogic.EVRStruktura.pSeparator_EVR;
                ucbDuzinaBloka.Value = BusinessLogic.EVRStruktura.pDuzinaBloka;
                cbkOrganizacijskaJedinica.Checked = BusinessLogic.EVRStruktura.pOrganizacijskaJedinica;
                cbkMjestoTroska.Checked = BusinessLogic.EVRStruktura.pMjestoTroska;
                ucbSeparatorBlokova.Value = BusinessLogic.EVRStruktura.pSeparatorBloka;
            }
        }

        private string KreirajFormatEVRBroja(object pozicija_evr, object separator_evr, object separator_blok, object duzina_blok, bool organizacijska_jedinica, bool mjesto_troska)
        {
            string format_erv_broja = string.Empty;

            if (pozicija_evr.ToString() == "pocetak")
            {
                if (duzina_blok.ToString() == "2")
                {
                    if (organizacijska_jedinica & mjesto_troska)
                    {
                        format_erv_broja = "EVR " + separator_evr.ToString() + " XX " + separator_blok + " XX " + separator_blok.ToString() + " XX";
                    }
                    else if (!organizacijska_jedinica & mjesto_troska)
                    {
                        format_erv_broja = "EVR " + separator_evr.ToString() + " XX " + separator_blok.ToString() + " XX";
                    }
                    else if (organizacijska_jedinica & !mjesto_troska)
                    {
                        format_erv_broja = "EVR " + separator_evr.ToString() + " XX " + separator_blok.ToString() + " XX";
                    }
                    else if (!organizacijska_jedinica & !mjesto_troska)
                    {
                        format_erv_broja = "EVR " + separator_evr.ToString() + " XX";
                    }
                }
                else if (duzina_blok.ToString() == "3")
                {
                    if (organizacijska_jedinica & mjesto_troska)
                    {
                        format_erv_broja = "EVR " + separator_evr.ToString() + " XXX " + separator_blok + " XXX " + separator_blok.ToString() + " XXX";
                    }
                    else if (!organizacijska_jedinica & mjesto_troska)
                    {
                        format_erv_broja = "EVR " + separator_evr.ToString() + " XXX " + separator_blok.ToString() + " XXX";
                    }
                    else if (organizacijska_jedinica & !mjesto_troska)
                    {
                        format_erv_broja = "EVR " + separator_evr.ToString() + " XXX " + separator_blok.ToString() + " XXX";
                    }
                    else if (!organizacijska_jedinica & !mjesto_troska)
                    {
                        format_erv_broja = "EVR " + separator_evr.ToString() + " XXX";
                    }
                }
                else if (duzina_blok.ToString() == "4")
                {
                    if (organizacijska_jedinica & mjesto_troska)
                    {
                        format_erv_broja = "EVR " + separator_evr.ToString() + " XXXX " + separator_blok + " XXXX " + separator_blok.ToString() + " XXXX";
                    }
                    else if (!organizacijska_jedinica & mjesto_troska)
                    {
                        format_erv_broja = "EVR " + separator_evr.ToString() + " XXXX" + separator_blok.ToString() + " XXXX";
                    }
                    else if (organizacijska_jedinica & !mjesto_troska)
                    {
                        format_erv_broja = "EVR " + separator_evr.ToString() + " XXXX " + separator_blok.ToString() + " XXXX";
                    }
                    else if (!organizacijska_jedinica & !mjesto_troska)
                    {
                        format_erv_broja = "EVR " + separator_evr.ToString() + " XXXX";
                    }
                }
            }
            else
            {
                if (duzina_blok.ToString() == "2")
                {
                    if (organizacijska_jedinica & mjesto_troska)
                    {
                        format_erv_broja = "XX " + separator_blok + " XX " + separator_blok.ToString() + " XX " + separator_evr.ToString() + " EVR";
                    }
                    else if (!organizacijska_jedinica & mjesto_troska)
                    {
                        format_erv_broja = "XX " + separator_blok.ToString() + " XX " + separator_evr.ToString() + " EVR";
                    }
                    else if (organizacijska_jedinica & !mjesto_troska)
                    {
                        format_erv_broja = "XX " + separator_blok.ToString() + " XX " + separator_evr.ToString() + " EVR";
                    }
                    else if (!organizacijska_jedinica & !mjesto_troska)
                    {
                        format_erv_broja = "XX " + separator_evr.ToString() + " EVR";
                    }
                }
                else if (duzina_blok.ToString() == "3")
                {
                    if (organizacijska_jedinica & mjesto_troska)
                    {
                        format_erv_broja = "XXX " + separator_blok + " XXX " + separator_blok.ToString() + " XXX " + separator_evr.ToString() + " EVR";
                    }
                    else if (!organizacijska_jedinica & mjesto_troska)
                    {
                        format_erv_broja = "XXX " + separator_blok.ToString() + " XXX " + separator_evr.ToString() + " EVR";
                    }
                    else if (organizacijska_jedinica & !mjesto_troska)
                    {
                        format_erv_broja = "XXX " + separator_blok.ToString() + " XXX " + separator_evr.ToString() + " EVR";
                    }
                    else if (!organizacijska_jedinica & !mjesto_troska)
                    {
                        format_erv_broja = "XXX " + separator_evr.ToString() + " EVR";
                    }
                }
                else if (duzina_blok.ToString() == "4")
                {
                    if (organizacijska_jedinica & mjesto_troska)
                    {
                        format_erv_broja = "XXXX " + separator_blok + " XXXX " + separator_blok.ToString() + " XXXX " + separator_evr.ToString() + " EVR";
                    }
                    else if (!organizacijska_jedinica & mjesto_troska)
                    {
                        format_erv_broja = "XXXX " + separator_blok.ToString() + " XXXX " + separator_evr.ToString() + " EVR";
                    }
                    else if (organizacijska_jedinica & !mjesto_troska)
                    {
                        format_erv_broja = "XXXX " + separator_blok.ToString() + " XXXX " + separator_evr.ToString() + " EVR";
                    }
                    else if (!organizacijska_jedinica & !mjesto_troska)
                    {
                        format_erv_broja = "XXXX " + separator_evr.ToString() + " EVR";
                    }
                }
            }

            return format_erv_broja;
        }

        #endregion

        #region Dogadaji

        private void tsbCPVOznakeSpremiNovi_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                uteNaziv.Text = string.Empty;
                ucbPozicijaTeksta.Value = null;
                ucbSeparator.Value = null;
                ucbDuzinaBloka.Value = null;
                ucbSeparatorBlokova.Value = null;
                cbkMjestoTroska.Checked = false;
                cbkOrganizacijskaJedinica.Checked = false;
                FormEditMode = Enums.FormEditMode.Insert;
            }
        }

        private void tsbCPVOznakeSpremiZatvori_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                base.ContainerForm.DialogResult = DialogResult.OK;
                base.ContainerForm.Close();
            }
        }

        private void tsbCPVOznakeOdustani_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.Cancel;
            base.ContainerForm.Close();
        }

        private void ucbPozicijaTeksta_ValueChanged(object sender, EventArgs e)
        {
            if (ucbSeparator.Value != null & ucbDuzinaBloka.Value != null)
            {
                lblPrikazEVRFormata.Text = KreirajFormatEVRBroja(ucbPozicijaTeksta.Value, ucbSeparator.Value, ucbSeparatorBlokova.Value,
                                                                 ucbDuzinaBloka.Value, cbkOrganizacijskaJedinica.Checked, cbkMjestoTroska.Checked);
            }
        }

        private void ucbSeparator_ValueChanged(object sender, EventArgs e)
        {
            if (ucbPozicijaTeksta.Value != null & ucbDuzinaBloka.Value != null)
            {
                lblPrikazEVRFormata.Text = KreirajFormatEVRBroja(ucbPozicijaTeksta.Value, ucbSeparator.Value, ucbSeparatorBlokova.Value,
                                                                 ucbDuzinaBloka.Value, cbkOrganizacijskaJedinica.Checked, cbkMjestoTroska.Checked);
            }
        }

        private void ucbSeparatorBlokova_ValueChanged(object sender, EventArgs e)
        {
            if (ucbPozicijaTeksta.Value != null & ucbSeparator.Value != null & ucbDuzinaBloka.Value != null)
            {
                lblPrikazEVRFormata.Text = KreirajFormatEVRBroja(ucbPozicijaTeksta.Value, ucbSeparator.Value, ucbSeparatorBlokova.Value,
                                                                 ucbDuzinaBloka.Value, cbkOrganizacijskaJedinica.Checked, cbkMjestoTroska.Checked);
            }
        }

        private void ucbDuzinaBloka_ValueChanged(object sender, EventArgs e)
        {
            if (ucbPozicijaTeksta.Value != null & ucbSeparator.Value != null)
            {
                lblPrikazEVRFormata.Text = KreirajFormatEVRBroja(ucbPozicijaTeksta.Value, ucbSeparator.Value, ucbSeparatorBlokova.Value,
                                                                 ucbDuzinaBloka.Value, cbkOrganizacijskaJedinica.Checked, cbkMjestoTroska.Checked);
            }
        }

        private void cbkOrganizacijskaJedinica_CheckedChanged(object sender, EventArgs e)
        {
            if (cbkMjestoTroska.Checked | cbkOrganizacijskaJedinica.Checked)
            {
                lblSeparatorBlokova.Visible = true;
                ucbSeparatorBlokova.Visible = true;
            }
            else
            {
                lblSeparatorBlokova.Visible = false;
                ucbSeparatorBlokova.Visible = false;
                ucbSeparatorBlokova.Value = null;
            }

            if (ucbPozicijaTeksta.Value != null & ucbSeparator.Value != null & ucbSeparatorBlokova.Value != null & ucbDuzinaBloka.Value != null)
            {
                lblPrikazEVRFormata.Text = KreirajFormatEVRBroja(ucbPozicijaTeksta.Value, ucbSeparator.Value, ucbSeparatorBlokova.Value, 
                                                                 ucbDuzinaBloka.Value, cbkOrganizacijskaJedinica.Checked, cbkMjestoTroska.Checked);
            }
        }

        private void cbkMjestoTroska_CheckedChanged(object sender, EventArgs e)
        {
            if (cbkMjestoTroska.Checked | cbkOrganizacijskaJedinica.Checked)
            {
                lblSeparatorBlokova.Visible = true;
                ucbSeparatorBlokova.Visible = true;
            }
            else
            {
                lblSeparatorBlokova.Visible = false;
                ucbSeparatorBlokova.Visible = false;
                ucbSeparatorBlokova.Value = null;
            }

            if (ucbPozicijaTeksta.Value != null & ucbSeparator.Value != null & ucbSeparatorBlokova.Value != null & ucbDuzinaBloka.Value != null)
            {
                lblPrikazEVRFormata.Text = KreirajFormatEVRBroja(ucbPozicijaTeksta.Value, ucbSeparator.Value, ucbSeparatorBlokova.Value, 
                                                                 ucbDuzinaBloka.Value, cbkOrganizacijskaJedinica.Checked, cbkMjestoTroska.Checked);
            }
        }

        private void uscEVRStruktura_Load(object sender, EventArgs e)
        {
            BusinessLogic.EVRStruktura evr_struktura = new BusinessLogic.EVRStruktura();


            if (FormEditMode == Enums.FormEditMode.Update || FormEditMode == Enums.FormEditMode.Copy)
            {
                LoadEVRStrukturaByID(evr_struktura);
            }
        }

        #endregion
    }
}

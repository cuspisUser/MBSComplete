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
    public partial class uscObracuni : Controls.BaseUserControl
    {
        #region Svojstva

        private FormEditMode pFormEditMode
        {
            get;
            set;
        }

        private Vrstaobracuna pVrstaObracuna
        {
            get;
            set;
        }

        #endregion

        #region Metode

        public uscObracuni(FormEditMode vrsta_promjene, Vrstaobracuna vrsta_obracuna)
        {
            InitializeComponent();
            pFormEditMode = vrsta_promjene;
            pVrstaObracuna = vrsta_obracuna;
        }

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        private int GenerateSifraObracuna()
        {
            int sifra;

            BusinessLogic.ObracunRazno objekt = new BusinessLogic.ObracunRazno();

            sifra = objekt.GetLastSifraObracuna();

            return sifra;
        }

        private bool SaveData()
        {
            lblValidationMessages.ResetText();

            BusinessLogic.ObracunRazno.pNaziv = txtNazivObracuna.Text.Trim();
            BusinessLogic.ObracunRazno.pMjesec = Convert.ToByte(uneMjesec.Value);
            BusinessLogic.ObracunRazno.pGodina = Convert.ToInt16(uneGodina.Value);
            BusinessLogic.ObracunRazno.pOstalo = cbkOstalo.Checked;
            BusinessLogic.ObracunRazno.pRoditelj = cbkRoditelj.Checked;
            BusinessLogic.ObracunRazno.pUcenik = cbkUcenici.Checked;
            BusinessLogic.ObracunRazno.pUF = cbkUF.Checked;
            BusinessLogic.ObracunRazno.pPraksa = cbkPraksa.Checked;

            if (pFormEditMode == FormEditMode.Insert)
            {
                BusinessLogic.ObracunRazno.pSifra = GenerateSifraObracuna();
                BusinessLogic.ObracunRazno.pVrstaObracuna = lblVrstaObracuna.Text.Trim();
            }

            StringBuilder message = ValidateDataInput();
            if (message.Length == 0)
            {
                if (pFormEditMode == FormEditMode.Insert)
                {
                    using (uscObracuniOsobe objekt = new uscObracuniOsobe(Enums.FormEditMode.Insert))
                    {
                        if (objekt.ShowDialogForm(BusinessLogic.ObracunRazno.pVrstaObracuna) == DialogResult.OK)
                        {
                            return true;
                        }
                    }
                }
                else if (pFormEditMode == FormEditMode.Update)
                {
                    using (uscObracuniOsobe objekt = new uscObracuniOsobe(Enums.FormEditMode.Update))
                    {
                        if (objekt.ShowDialogForm(BusinessLogic.ObracunRazno.pVrstaObracuna) == DialogResult.OK)
                        {
                            return true;
                        }
                    }
                }
            }

            lblValidationMessages.Text = message.ToString();
            return false;
        }

        private StringBuilder ValidateDataInput()
        {
            StringBuilder message = new StringBuilder();

            if (BusinessLogic.ObracunRazno.pNaziv.Length == 0)
            {
                message.Append(" - Naziv obračuna je obavezno polje");
            }
            else if (BusinessLogic.ObracunRazno.pNaziv.Length > 100)
            {
                message.Append(" - Naziv ne smije sadržavati više od 100 znakova");
            }
            if (BusinessLogic.ObracunRazno.pMjesec < 1)
            {
                message.Append(" - Mjesec je obavezno polje");
            }
            if (BusinessLogic.ObracunRazno.pGodina < 2010)
            {
                message.Append(" - Godina je obavezno polje");
            }
            if (!BusinessLogic.ObracunRazno.pOstalo & !BusinessLogic.ObracunRazno.pUcenik & !BusinessLogic.ObracunRazno.pRoditelj)
            {
                message.Append(" - Potrebno je odabrati za koga će se raditi obračun");
            }

            return message;
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

        private void LoadObracunByID()
        {
            BusinessLogic.ObracunRazno objekt = new BusinessLogic.ObracunRazno();

            BusinessLogic.ObracunRazno.pVrstaObracuna = lblVrstaObracuna.Text;

            if (objekt.ObracunByID())
            {
                uneMjesec.Value = BusinessLogic.ObracunRazno.pMjesec;
                uneGodina.Value = BusinessLogic.ObracunRazno.pGodina;
                txtNazivObracuna.Text = BusinessLogic.ObracunRazno.pNaziv;
                cbkOstalo.Checked = BusinessLogic.ObracunRazno.pOstalo;
                cbkUcenici.Checked = BusinessLogic.ObracunRazno.pUcenik;
                cbkRoditelj.Checked = BusinessLogic.ObracunRazno.pRoditelj;
                cbkUF.Checked = BusinessLogic.ObracunRazno.pUF;
                cbkPraksa.Checked = BusinessLogic.ObracunRazno.pPraksa;
            }
        }

        #endregion

        #region Događaji

        private void uscObracuni_Load(object sender, EventArgs e)
        {
            lblVrstaObracuna.Text = pVrstaObracuna.ToString();

            if (pFormEditMode == Enums.FormEditMode.Update)
            {
                LoadObracunByID();
                btnKreni.Text = "Pregledaj/Uredi";
            }
        }

        private void btnKreni_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                ContainerForm.DialogResult = DialogResult.OK;
                ContainerForm.Close();
            }
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            ContainerForm.DialogResult = DialogResult.OK;
            ContainerForm.Close();
        }

        #endregion

        private void cbkUcenici_CheckedChanged(object sender, EventArgs e)
        {
            if (cbkUcenici.Checked)
            {
                cbkUF.Visible = true;
                cbkPraksa.Visible = true;
            }
            else
            {
                cbkUF.Visible = false;
                cbkPraksa.Visible = false;
                cbkUF.Checked = false;
                cbkPraksa.Checked = false;
            }
        }
    }
}
